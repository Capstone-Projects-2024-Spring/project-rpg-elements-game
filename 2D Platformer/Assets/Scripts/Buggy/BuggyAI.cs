using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Linq;

public class BuggyAI : NetworkBehaviour
{
    [SerializeField] private float visionRange = 20;
    [SerializeField] private float attackRange = 20;
    [SerializeField] private EnemyStats SkrakeStats;
    [SerializeField] private Hurtbox hurtbox;
    private Rigidbody2D rb;
    private SpriteRenderer sb;
    private Animator anim;
    private Color defaultColor;
    private Vector3 localScale;
    private Vector2 to_target;
    private Vector2 offset;
    private GameObject[] players;
    private Transform closestPlayer;
    private bool currentlyAttacking = false;
    private bool inHitstun = false;
    private bool playerIsOnLeft = false;
    private bool running = false;
    private bool attacking = false;
    private float moveSpeed = 1;
    private float attackDirection = 1;
    private float[,] EndPoints;
    private float[,] ControlPoints_1;
    private float[,] ControlPoints_2;
    private float[] next_xy;
    private float distanceToTarget;
    private float t = 0.0f;
    private float dt = 0.0f;
    private int n = 0;
    private int n_updates = 0;
    private int i_currentCurve = 0;
    private int i_nextCurve = 1;

    [SyncVar(hook = nameof(OnFacingDirectionChanged))]
    private float facingDirection = 1;
    
    void Start()
    {
        moveSpeed = SkrakeStats.Speed.Value;
        localScale = transform.localScale;
        sb = GetComponent<SpriteRenderer>();
        defaultColor = sb.color;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dt = Time.fixedDeltaTime;
        n = Mathf.RoundToInt(1 / Time.fixedDeltaTime);
        EndPoints = new float[,] { { 0.0f, 0.0f }, { 0.0f, 0.0f } };
        ControlPoints_1 = new float[,] { { 0.0f, 0.0f }, { 0.0f, 0.0f } };
        ControlPoints_2 = new float[,] { { 0.0f, 0.0f }, { 0.0f, 0.0f } };
        next_xy = new float[] { 0.0f, 0.0f };
}

    [Server]
    void Update()
    {
        if (running)
        {
            ChangeDirection();
        }
        sendHitstunStatus();
    }

    [Server]
    private void FixedUpdate()
    {
        if (!attacking)
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            anim.SetBool("run", running);
            anim.SetBool("hurt", inHitstun);
            closestPlayer = getClosestPlayer(players.ToList<GameObject>());
            distanceToTarget = Vector2.Distance(transform.position, closestPlayer.transform.position);
            if (distanceToTarget > 0 && distanceToTarget < visionRange)
            {
                ChasePlayer();
            }
        }
        else
        {
            distanceToTarget = Vector2.Distance(transform.position, closestPlayer.transform.position);
        }

        if (distanceToTarget > 0 && distanceToTarget < attackRange)
        {
            if (!attacking)
            {
                EndPoints[0, 0] = transform.position.x;
                EndPoints[0, 1] = transform.position.y;
                EndPoints[1, 0] = closestPlayer.position.x;
                EndPoints[1, 1] = closestPlayer.position.y;
                to_target = new Vector2(EndPoints[0, 0], EndPoints[0, 1]) - new Vector2(EndPoints[1, 0], EndPoints[1, 1]).normalized;
                offset = Vector2.Perpendicular(to_target).normalized;
                for (int i = 0; i < 4; i++)
                {
                    float mag_a = UnityEngine.Random.Range(0.0f, distanceToTarget);
                    float mag_b = UnityEngine.Random.Range(-distanceToTarget, distanceToTarget);
                    Vector2 vec_to_controlPoint = (mag_a * to_target) + (mag_b * offset);
                    Debug.Log("vec_to_controlPoint: " + vec_to_controlPoint.x.ToString() + ", " + vec_to_controlPoint.y.ToString());
                    if (i < 2)
                    {
                        ControlPoints_1[i, 0] = EndPoints[0, 0] + vec_to_controlPoint.x;
                        ControlPoints_1[i, 1] = EndPoints[0, 1] + vec_to_controlPoint.y;
                    }
                    else
                    {
                        ControlPoints_2[i - 2, 0] = EndPoints[1, 0] + vec_to_controlPoint.x;
                        ControlPoints_2[i - 2, 1] = EndPoints[1, 1] + vec_to_controlPoint.y;
                    }
                }
            }
            attacking = true;
        }

        if (attacking)
        {
            if (n_updates == 0 && i_currentCurve == 0 && distanceToTarget > attackRange)
            {
                Debug.Log("PLAYER MOVED OUT OF RANGE RANGE");
                attacking = false;
            }
            else
            {
                /*
                Debug.Log("EndPoints 1: " + EndPoints[0,0].ToString() + ", " + EndPoints[0, 1].ToString());
                Debug.Log("EndPoints 2: " + EndPoints[1, 0].ToString() + ", " + EndPoints[1, 1].ToString());
                Debug.Log("CP 1: " + ControlPoints_1.ToString());
                Debug.Log("CP 2: " + ControlPoints_2.ToString());
                */
                next_xy = CalcBezTimeStep(t, EndPoints[0, 0], EndPoints[0, 1], ControlPoints_1[i_currentCurve, 0], ControlPoints_1[i_currentCurve, 1], ControlPoints_2[i_currentCurve, 0], ControlPoints_2[i_currentCurve, 1], EndPoints[1, 0], EndPoints[1, 1]);
                Debug.Log("New position: " + next_xy.ToString());
                transform.position = new Vector2(next_xy[0], next_xy[1]);
                t += dt;
                n_updates++;
                if (n_updates == n)
                {
                    i_currentCurve = i_nextCurve;
                    i_nextCurve = i_nextCurve == 1 ? 0 : 1;
                    n_updates = 0;
                    t = 0.0f;
                    if (i_currentCurve == 0)
                    {
                        to_target = (new Vector2(EndPoints[0, 0], EndPoints[0, 1]) - new Vector2(EndPoints[1, 0], EndPoints[1, 1])).normalized;
                        offset = Vector2.Perpendicular(new Vector2(to_target.x, to_target.y));
                        for (int i = 0; i < 4; i++)
                        {
                            Debug.Log("distanceToTarget: " + distanceToTarget.ToString());
                            float mag_a = UnityEngine.Random.Range(0.0f, distanceToTarget);
                            float mag_b = UnityEngine.Random.Range(-distanceToTarget, distanceToTarget);
                            Vector2 vec_to_controlPoint = (mag_a * to_target) + (mag_b * offset);
                            Debug.Log("vec_to_controlPoint: " + vec_to_controlPoint.x.ToString() + ", " + vec_to_controlPoint.y.ToString());
                            if (i < 2)
                            {
                                ControlPoints_1[i, 0] = EndPoints[0, 0] + vec_to_controlPoint.x;
                                ControlPoints_1[i, 1] = EndPoints[0, 1] + vec_to_controlPoint.y;
                            }
                            else
                            {
                                ControlPoints_2[i - 2, 0] = EndPoints[1, 0] + vec_to_controlPoint.x;
                                ControlPoints_2[i - 2, 1] = EndPoints[1, 1] + vec_to_controlPoint.y;
                            }
                        }
                    }
                }
            }
        }
    }

    private void ChangeDirection()
    {
        facingDirection = Mathf.Sign(rb.velocity.x);
    }

    [Server]
    private Transform getClosestPlayer(List<GameObject> players)
    {
        try
        {
            return players.OrderBy(o => Vector2.Distance(transform.position, o.transform.position)).ToList()[0].transform;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Debug.Log(ex);
            return transform;
        }
    }

    [Server]
    private void ChasePlayer()
    {
        if ((transform.position.x < closestPlayer.position.x) && (Mathf.Abs(transform.position.x - closestPlayer.position.x) > 2.5) && !currentlyAttacking && !inHitstun)
        {
            running = true;
            //rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            playerIsOnLeft = false;
        }
        else if ((transform.position.x > closestPlayer.position.x) && (Mathf.Abs(transform.position.x - closestPlayer.position.x) > 2.5) && !currentlyAttacking && !inHitstun)
        {
            running = true;
            //rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            playerIsOnLeft = true;
        }
        else if ((Mathf.Abs(transform.position.x - closestPlayer.position.x) < 2.5) && !currentlyAttacking && !inHitstun)
        {
            StartCoroutine(StartAttack());
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !currentlyAttacking)
        {
            StartCoroutine(StartAttack());
        }
        if (collider.CompareTag("Attack"))
        {
            StartCoroutine(BeginHitstun());
        }
    }

    private IEnumerator StartAttack()
    {
        currentlyAttacking = true;
        running = false;
        sb.color = Color.yellow;
        attackDirection = playerIsOnLeft ? -1 : 1;
        yield return new WaitForSeconds(0.5f);
        if (inHitstun)
            StopCoroutine(StartAttack());
        rb.velocity = new Vector2(moveSpeed * attackDirection, moveSpeed);
        yield return new WaitForSeconds(1);
        sb.color = defaultColor;
        currentlyAttacking = false;
    }

    private IEnumerator BeginHitstun()
    {
        inHitstun = true;
        running = false;
        sb.color = Color.blue;
        yield return new WaitForSeconds(2);
        sb.color = defaultColor;
        inHitstun = false;
    }

    private void OnFacingDirectionChanged(float oldValue, float newValue)
    {
        facingDirection = newValue;
        if (newValue < 0)
        {
            localScale.x = Mathf.Abs(localScale.x);
        }
        else
        {
            localScale.x = Mathf.Abs(localScale.x) * -1;
        }
        transform.localScale = localScale;
    }

    private void sendHitstunStatus()
    {
        hurtbox.setHitstun(inHitstun);
    }

    private float[] CalcBezTimeStep(float t, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
    {
        Debug.Log("CALCULATING BEZIER STEP!");
        // float array to hold final values
        float[] p_xy = { 0.0f, 0.0f }; // x,y positions

        // ax bx cx dx
        float bx = 3 * (x2 - x1);
        float cx = 3 * (x3 - x2) - bx;
        float dx = x4 - x1 - bx - cx;

        // ay by cy dy
        float by = 3 * (y2 - y1);
        float cy = 3 * (y3 - y2) - by;
        float dy = y4 - y1 - by - cy;

        // xt
        p_xy[0] = x1 + t * (bx + t * (cx + t * dx));

        // yt
        p_xy[1] = y1 + t * (by + t * (cy + t * dy));

        return p_xy;
    }
}
