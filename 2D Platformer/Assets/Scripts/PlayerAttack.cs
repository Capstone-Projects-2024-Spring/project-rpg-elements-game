using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] private float attackCooldown;
    private Animator anim;
    private Movement playerMovement;
    //private float cooldownTimer = Mathf.Infinity;

    public int damage;
    public Hitbox hitbox;
    public Transform[] transforms;
    public float[] attackRange;
    public LayerMask enemyLayers;
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
        /* Unused code from following a tutorial with a different approach
        for(int i = 0; i < transforms.Length; i++)
        {
            Collider2D[] hitenemies = Physics2D.OverlapCircleAll(transforms[i].position, attackRange[i], enemyLayers);
            foreach(Collider2D Enemies in hitenemies)
            {
                Debug.Log("We hit " + Enemies.name);
            }
        }
        */
        //hitbox.useResponder(this);
       // hitbox.startCheckingCollision();
        //Debug.Log("Collision checking starting!");
    }




    void ActivateHitbox(){
        //print(hitbox1);
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }

    void DeactivateHitbox(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }
    /* More unused code from following a tutorial with a different approach
        private void OnDrawGizmosSelected(){
        for(int i = 0; i < transforms.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transforms[i].position, attackRange[i]);
        }
    }
    */
    /*
    public void collisionedWith(Collider collider){
        Hurtbox hurtbox = collider.GetComponent<Hurtbox>();
        hurtbox?.getHitBy(damage);
    }
    */

}
