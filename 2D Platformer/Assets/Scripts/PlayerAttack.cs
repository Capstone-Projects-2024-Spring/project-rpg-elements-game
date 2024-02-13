using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private Movement playerMovement;

    public int power = 10;

    public float[] knockback = {4, 3};

    private float xKnockbackValue;
    public Hitbox[] hitboxes;
    private void Awake(){
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();
        xKnockbackValue = Math.Abs(knockback[0]);
        setHitboxes();

    }

    private void setHitboxes(){
        foreach(Hitbox hitbox in hitboxes){
            hitbox.setDamage(power);
            hitbox.setKnockback(knockback);
        }
    }

    private void Update(){
        if(Input.GetKey(KeyCode.LeftShift) && playerMovement.canAttack()){
            Attack();
        }
        setKnockbackDirection();


    }

    private void setKnockbackDirection(){
        if(playerMovement.getDirection() == Direction.left){
            knockback[0] = xKnockbackValue * -1;
        }
        if(playerMovement.getDirection() == Direction.right){
            knockback[0] = xKnockbackValue;
        }
    }

    private void Attack(){
        anim.SetTrigger("attack");
    }

    void ActivateHitbox(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }

    void DeactivateHitbox(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }

}
