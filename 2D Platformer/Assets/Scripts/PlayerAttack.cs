using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement playerMovement;

    public int power = 10;

    public float[] knockback = {4, 3};

    private float xKnockbackValue;
    public Hitbox[] hitboxes;

    private String attackName = "Dogstrike";

    private int uses = 0;

    private double hitlag;
    private bool success;
    private bool active;

    private float time = 0;

    private String receiverID = "";

    private Rigidbody2D body;

    Vector2 storedVelocity = new Vector2();
    private void Awake(){
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        body = GetComponentInParent<Rigidbody2D>();
        xKnockbackValue = Math.Abs(knockback[0]);
        hitlag = setHitlag(knockback[0], knockback[1]);
        setHitboxes();

    }

    private void setHitboxes(){
        foreach(Hitbox hitbox in hitboxes){
            hitbox.setDamage(power);
            hitbox.setKnockback(knockback);
            hitbox.setHitlag(hitlag);
        }
    }

    private void Update(){
        if(Input.GetKey(KeyCode.LeftShift) && playerMovement.canAttack()){
            Attack();

        }

        setKnockbackDirection();
        if(active){
            checkSuccess();
        }
        if(success){
            //Debug.Log("Landed a hit!");
            enterHitlag();
            success = false;
        }
    
        if(anim.enabled == false){
            time += Time.deltaTime;
            //Debug.Log(time);
            if(time > hitlag){
                anim.enabled = true;
                body.constraints = RigidbodyConstraints2D.FreezeRotation;
                body.velocity = storedVelocity;
                //Debug.Log("No longer in hitlag");
            }
        }

    


    }

    private void checkSuccess(){
        int hits = 0;
        foreach(Hitbox hitbox in hitboxes){
            if(hitbox.getSuccess() && !string.Equals(hitbox.getReceiverID(), receiverID)){
                hits += 1;
                receiverID = hitbox.getReceiverID();
                //Debug.Log(receiverID);
            }
        }
        if(hits > 0){
            success = true;
        }
    }

    private void setAttackName(){
        uses += 1;
        String attackUses = uses.ToString();
        String ID = attackName + attackUses;
        foreach(Hitbox hitbox in hitboxes){
            hitbox.setAttackID(ID);
            //Debug.Log(hitbox.getAttackID());
        }
    }

    private double setHitlag(float xknockback,float yknockback){
        double calculated_hitlag = (Math.Sqrt(Math.Pow(Math.Abs(xknockback), 2) + Math.Pow(Math.Abs(yknockback), 2)) * 0.65 + 6)/60;
        if(calculated_hitlag > 0.5){calculated_hitlag = 0.5;}
        return calculated_hitlag;

    }

    private void enterHitlag(){
        time = 0;
        anim.enabled = false;
        storedVelocity = body.velocity;
        body.constraints = RigidbodyConstraints2D.FreezeAll;
        //Debug.Log(storedVelocity);
        
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
        active = true;

    }

    void DeactivateHitbox(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        active = false;
        success = false;
        foreach(Hitbox hitbox in hitboxes){
            hitbox.setSuccess(false);
        }

    }

}
