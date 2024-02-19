using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerStats statSheet;

    protected Animator anim;
    protected Movement playerMovement;

    [SerializeField] protected int power;

    [SerializeField] protected float[] knockback = {4, 3};

    [SerializeField] protected KeyCode triggerKey;

    private float xKnockbackValue;
    [SerializeField] protected Hitbox[] hitboxes;

    [SerializeField] protected bool visible_hitboxes = true;

    public String attackName = "strike";

    [SerializeField] protected string animationTrigger = "attack";


    private int uses = 0;

    private double hitlag;
    protected bool success = false;
    protected bool active;

    private float hitlagTimer = 0;

    private String receiverID = "";

    protected Rigidbody2D body;

    private Vector2 storedVelocity = new Vector2();

    protected bool other_constraints = true;

    protected virtual void Awake(){
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();
        body = GetComponentInParent<Rigidbody2D>();
        xKnockbackValue = Math.Abs(knockback[0]);
        hitlag = setHitlag(knockback[0], knockback[1]);
    }

    protected void setHitboxes(){
        foreach(Hitbox hitbox in hitboxes){
            hitbox.setDamage(power);
            hitbox.setKnockback(knockback);
            hitbox.setHitlag(hitlag);
            if(!visible_hitboxes){
                hitbox.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
            }
        }
    }

    protected virtual void Update(){

        if(Input.GetKeyDown(triggerKey) && playerMovement.canAttack() && other_constraints){
            playerMovement.setAttackStateTrue();
            setHitboxes();
            setAttackName();
            Attack();
        }

        setKnockbackDirection();
        if(!active){
            //Debug.Log(attackName + "is not active");
            return;
        }
        //Debug.Log(attackName + " is active!");
        checkSuccess();
        if(success){
            enterHitlag();
            //Debug.Log("This should only print once");
            success = false;
        }
    
        if(anim.enabled == false){
            hitlagTimer += Time.deltaTime;
            //Debug.Log(time);
            if(hitlagTimer > hitlag){
                exitHitlag();
            }
        }

    }

    protected void checkSuccess(){
        //Debug.Log(attackName);
        foreach(Hitbox hitbox in hitboxes){
            if(hitbox.getSuccess() && !string.Equals(hitbox.getReceiverID(), receiverID)){
                success = true;
            }
        }

    }

    protected void setAttackName(){
        uses += 1;
        String attackUses = uses.ToString();
        String ID = attackName + attackUses;
        foreach(Hitbox hitbox in hitboxes){
            hitbox.setAttackID(ID);
            //Debug.Log(hitbox.getAttackID());
        }
    }

    protected double setHitlag(float xknockback,float yknockback){
        double calculated_hitlag = (Math.Sqrt(Math.Pow(Math.Abs(xknockback), 2) + Math.Pow(Math.Abs(yknockback), 2)) * 0.65 + 6)/60;
        if(calculated_hitlag > 0.5){calculated_hitlag = 0.5;}
        return calculated_hitlag;

    }

    protected void enterHitlag(){
        hitlagTimer = 0;
        anim.enabled = false;
        storedVelocity = body.velocity;
        body.constraints = RigidbodyConstraints2D.FreezeAll;
        //Debug.Log("Before " + attackName + ": " + storedVelocity);
        
    }

    protected void exitHitlag(){
        anim.enabled = true;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        body.velocity = storedVelocity;
        //Debug.Log("After " + attackName + ": " + body.velocity);
        //Debug.Log("No longer in hitlag");
    }

    protected void setKnockbackDirection(){
        if(playerMovement.getDirection() == Direction.left){
            knockback[0] = xKnockbackValue * -1;
        }
        if(playerMovement.getDirection() == Direction.right){
            knockback[0] = xKnockbackValue;
        }
    }

    protected void Attack(){
        //Debug.Log("This should only print once");
        anim.SetTrigger(animationTrigger);
    }

    protected virtual void ActivateHitbox(){
        foreach(Hitbox hitbox in hitboxes){
            hitbox.gameObject.SetActive(true);
        }

    }




    protected void DeactivateHitbox(){
        foreach(Hitbox hitbox in hitboxes){
            hitbox.setSuccess(false);
            hitbox.gameObject.SetActive(false);
        }
        active = false;
        success = false;


    }

}
