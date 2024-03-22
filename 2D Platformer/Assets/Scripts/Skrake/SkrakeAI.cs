using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkrakeAI : MonoBehaviour
{

    private Transform player;
    [SerializeField] private float visionRange;
    private Rigidbody2D rb;
    private SpriteRenderer sb;
    private Color defaultColor;
    private bool touchingPlayer = false;
    private bool inHitstun = false;
    private Vector3 localScale;
    [SerializeField] private EnemyStats SkrakeStats;
    private float moveSpeed = 1;

    void Start()
    {
        moveSpeed = SkrakeStats.Speed.Value;
        localScale = transform.localScale;
        sb = GetComponent<SpriteRenderer>();
        defaultColor = sb.color;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distToPlayer < visionRange)
        {
            //move towards detected player
            ChasePlayer();
        }
    }


    private void ChasePlayer()
    {
        if ((transform.position.x < player.position.x) && (Mathf.Abs(transform.position.x - player.position.x) > 0.5) && !touchingPlayer && !inHitstun)
        {
            //player is on the right, move right
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (localScale.x > 0 && Mathf.Abs(transform.position.x - player.position.x) > 1) //face right if not already
            {
                localScale.x *= -1;
            }
        }
        else if ((transform.position.x > player.position.x) && (Mathf.Abs(transform.position.x - player.position.x) > 0.5) && !touchingPlayer && !inHitstun)
        {
            //player is on the left, move left
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (localScale.x < 0 && Mathf.Abs(transform.position.x - player.position.x) > 1) //face left if not already
            {
                localScale.x *= -1;
            }
        }
        //update left/right rotation
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")){
            StartCoroutine(StopChasing());
        }
        if (collider.CompareTag("Attack"))
        {
            StartCoroutine(BeginHitstun());
        }
    }
    
    private IEnumerator StopChasing()
    {
        touchingPlayer = true;
        sb.color = Color.yellow;
        yield return new WaitForSeconds(1);
        sb.color = defaultColor;
        touchingPlayer = false;
    }
    private IEnumerator BeginHitstun()
    {
        inHitstun = true;
        sb.color = Color.blue;
        yield return new WaitForSeconds(2);
        sb.color = defaultColor;
        inHitstun = false;
    }

}
