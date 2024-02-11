using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] private float attackCooldown;
    private Animator anim;
    private Movement playerMovement;
    //private float cooldownTimer = Mathf.Infinity;

    private BoxCollider2D hitbox1;
    private BoxCollider2D hitbox2;
    private BoxCollider2D hitbox3;
    private BoxCollider2D hitbox4;
    private void Start(){
        hitbox1 = transform.GetChild(0).GetComponent<BoxCollider2D>();
        hitbox2 = transform.GetChild(1).GetComponent<BoxCollider2D>();
        hitbox3 = transform.GetChild(2).GetComponent<BoxCollider2D>();
        hitbox4 = transform.GetChild(3).GetComponent<BoxCollider2D>();
    }

    private void Awake(){
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();

    }

    private void Update(){
        if(Input.GetKey(KeyCode.LeftShift) && playerMovement.canAttack()){
            Attack();
        }

        //cooldownTimer += Time.deltaTime;
    }

    private void Attack(){
        anim.SetTrigger("attack");
        //Invoke("ActivateHitbox", 0.1f);
        //Invoke("DeactivateHitbox", 0.2f);
        //cooldownTimer = 0;
    }

    void ActivateHitbox(){
        //print(hitbox1);
        hitbox1.gameObject.SetActive(true);
        hitbox2.gameObject.SetActive(true);
        hitbox3.gameObject.SetActive(true);
        hitbox4.gameObject.SetActive(true);
    }

    void DeactivateHitbox(){
        hitbox1.gameObject.SetActive(false);
        hitbox2.gameObject.SetActive(false);
        hitbox3.gameObject.SetActive(false);
        hitbox4.gameObject.SetActive(false);
    }
}
