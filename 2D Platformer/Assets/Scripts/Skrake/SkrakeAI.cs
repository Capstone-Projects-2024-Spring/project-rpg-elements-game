using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Linq;

public class SkrakeAI : NetworkBehaviour
{
    private GameObject[] players;
    [SerializeField] private float visionRange = 5;
    private Rigidbody2D rb;
    private SpriteRenderer sb;
    private Animator anim;
    private Color defaultColor;
    private bool currentlyAttacking = false;
    private bool inHitstun = false;
    private Vector3 localScale;
    [SerializeField] private EnemyStats SkrakeStats;
    [SerializeField] private Hurtbox hurtbox;
    private float moveSpeed = 1;
    private bool playerIsOnLeft = false;
    private float attackDirection = 1;
    private bool running = false;
    private Transform closestPlayer;

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
        if (isServer)
        {
            StartCoroutine(ServerUpdate());
        }
    }

    [Server]
    IEnumerator ServerUpdate()
    {

        while (true)
        {
            // Your server-specific logic here
            players = GameObject.FindGameObjectsWithTag("Player");
            closestPlayer = getClosestPlayer(players.ToList<GameObject>());
            float distToPlayer = Vector2.Distance(transform.position, closestPlayer.transform.position);

            if (distToPlayer < visionRange)
            {
                ChasePlayer();
            }

            if (running)
            {
                ChangeDirection();
            }
            sendHitstunStatus();

            yield return null; // Optionally, you can yield for a specific time interval
        }

        //old code that would run on client

        //players = GameObject.FindGameObjectsWithTag("Player");
        //anim.SetBool("run", running);
        //anim.SetBool("hurt", inHitstun);

        //closestPlayer = getClosestPlayer(players.ToList<GameObject>());
        //float distToPlayer = Vector2.Distance(transform.position, closestPlayer.transform.position);

        //if (distToPlayer < visionRange)
        //{
        //    ChasePlayer();
        //}

        //if (running)
        //{
        //    ChangeDirection();
        //}
        //sendHitstunStatus();
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
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            playerIsOnLeft = false;
        }
        else if ((transform.position.x > closestPlayer.position.x) && (Mathf.Abs(transform.position.x - closestPlayer.position.x) > 2.5) && !currentlyAttacking && !inHitstun)
        {
            running = true;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
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
}
