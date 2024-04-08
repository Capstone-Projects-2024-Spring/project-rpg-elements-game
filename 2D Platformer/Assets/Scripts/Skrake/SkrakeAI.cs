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
    private float moveSpeed = 1;
    private bool playerIsOnLeft = false;
    private float attackDirection = 1;
    private bool running = false;
    Transform closestPlayer;

    void Start()
    {
        moveSpeed = SkrakeStats.Speed.Value;
        localScale = transform.localScale;
        sb = GetComponent<SpriteRenderer>();
        defaultColor = sb.color;
        rb = GetComponent<Rigidbody2D>();
        players = GameObject.FindGameObjectsWithTag("Player");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("run", running);
        anim.SetBool("hurt", inHitstun);
        try
        {
            float distToPlayer = Vector2.Distance(transform.position, closestPlayer.transform.position);
            closestPlayer = getClosestPlayer(players.ToList<GameObject>()); if (distToPlayer < visionRange)
            {
                //move towards detected player
                ChasePlayer();
            }
        } catch (NullReferenceException ex)
        {
            Debug.Log(ex + "No objects with player tag detected");
        } catch (UnassignedReferenceException ex)
        {
            Debug.Log(ex + "No objects with player tag to find distance to"); 
        }
        
    }

    private Transform getClosestPlayer(List<GameObject> players)
    {
        return players.OrderBy(o => Vector2.Distance(transform.position, o.transform.position)).ToList()[0].transform;
    }

    private void ChasePlayer()
    {
        if ((transform.position.x < closestPlayer.position.x) && (Mathf.Abs(transform.position.x - closestPlayer.position.x) > 2.5) && !currentlyAttacking && !inHitstun)
        {
            //player is on the right, move right
            running = true;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            playerIsOnLeft = false;
            if (localScale.x > 0 && Mathf.Abs(transform.position.x - closestPlayer.position.x) > 1) //face right if not already
            {
                localScale.x *= -1;
            }
        }
        else if ((transform.position.x > closestPlayer.position.x) && (Mathf.Abs(transform.position.x - closestPlayer.position.x) > 2.5) && !currentlyAttacking && !inHitstun)
        {
            //player is on the left, move left
            running = true;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            playerIsOnLeft = true;
            if (localScale.x < 0 && Mathf.Abs(transform.position.x - closestPlayer.position.x) > 1) //face left if not already
            {
                print(playerIsOnLeft);
                localScale.x *= -1;
            }
        }
        else if ((Mathf.Abs(transform.position.x - closestPlayer.position.x) < 2.5) && !currentlyAttacking && !inHitstun)
        {
            StartCoroutine(StartAttack());
        }
        //update left/right rotation
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !currentlyAttacking){
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
        //check for what direction player was
        if (playerIsOnLeft)
            attackDirection = -1;
        else
            attackDirection = 1;
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

}
