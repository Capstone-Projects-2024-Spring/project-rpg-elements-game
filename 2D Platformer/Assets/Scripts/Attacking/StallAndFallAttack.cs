using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StallAndFallAttack : PlayerAttack
{
    protected bool aerial = false;
    [SerializeField] protected int aerialPower; 

    [SerializeField] protected float[] aerialKnockback = {4, 3};

    protected float aerialXKnockbackValue;
    [SerializeField] protected Hitbox[] aerialHitboxes;

    [SerializeField] Vector2 fallingVelocity = new Vector2(0, -1);
    private float fallingVelocityXValue;

    private double aerialHitlag;

    private bool diving = false;

    protected override void Awake(){
        base.Awake();
        aerialHitlag = setHitlag(aerialKnockback[0], aerialKnockback[1]);
        aerialXKnockbackValue = Math.Abs(aerialKnockback[0]);
        fallingVelocityXValue = Math.Abs(fallingVelocity[0]);

    }

    protected override void Update(){
        //Debug.Log(aerial);
        anim.SetBool("diving", diving);

        base.Update();
        if(!active){
            return;
        }
        if(!aerial){
            return;
        }
        if(!diving){
            return;
        }
        fallAttack();
        if(playerMovement.isGrounded() || (body.velocity != fallingVelocity)){
            aerial = false;
            diving = false;
        }

    }


    protected override void Attack(){
        if(playerMovement.isGrounded()){
            anim.SetTrigger(animationTrigger + "ground");
            aerial = false;
        }else{
            anim.SetTrigger(animationTrigger + "air");
            aerial = true;
        }
        //Debug.Log("This should only print once");
    }

    protected override void setHitboxes(){
        int hitboxPower = power;
        float[] hitboxKnockback = {knockback[0], knockback[1]};
        double hitboxHitlag = hitlag;
        if(!playerMovement.isGrounded()){
            hitboxPower = aerialPower;
            hitboxKnockback[0] = aerialKnockback[0];
            hitboxKnockback[1] = aerialKnockback[1];
            hitboxHitlag = aerialHitlag;
        }
        foreach(Hitbox hitbox in hitboxes){
            hitbox.setDamage(hitboxPower);
            hitbox.setKnockback(hitboxKnockback);
            hitbox.setHitlag(hitboxHitlag);
            setHitboxVisibility(hitbox);
        }
    }

    protected override void setKnockbackDirection(){
        if(playerMovement.getDirection() == Direction.left){
            knockback[0] = xKnockbackValue * -1;
            aerialKnockback[0] = aerialXKnockbackValue * -1;
            fallingVelocity[0] = fallingVelocityXValue * -1;
        }
        if(playerMovement.getDirection() == Direction.right){
            knockback[0] = xKnockbackValue;
            aerialKnockback[0] = aerialXKnockbackValue;
            fallingVelocity[0] = fallingVelocityXValue;
        }
    }

    protected virtual void ActivateAerialHitbox(){
        if(!active){
            return;
        }
        foreach(Hitbox hitbox in aerialHitboxes){
            hitbox.gameObject.SetActive(true);
        }
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        diving = true;

    }

    protected void fallAttack(){
        body.velocity = fallingVelocity;
    }





}
