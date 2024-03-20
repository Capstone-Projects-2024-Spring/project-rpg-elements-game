using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkrakeAI : MonoBehaviour
{

    private Transform player;
    [SerializeField] private float visionRange;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer sb;
    private Color defaultColor;
    private bool touchingPlayer = false;
    private bool inHitstun = false;

    void Start()
    {
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
        if ((transform.position.x < player.position.x) && !touchingPlayer && !inHitstun)
        {
            //player is on the right, move right
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if ((transform.position.x > player.position.x) && !touchingPlayer && !inHitstun)
        {
            //player is on the left, move left
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
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
