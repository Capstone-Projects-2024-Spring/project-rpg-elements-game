using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeableDashAttack : PlayerAttack
{
    private float chargeTimer = 0;
    [SerializeField] private float midLevelThreshold = 1.0f;
    [SerializeField] private float maxLevelThreshold = 2.0f;
    [SerializeField] private float midLevelMultiplier = 1.2f;

    [SerializeField] private float maxLevelMultiplier = 1.35f;

    [SerializeField] private float dashAcceleration = 2.0f;

    [SerializeField] private float maxVelocity = 10.0f;

    [SerializeField] private float dashTimer = 0.5f;
    [SerializeField] private float startingLag = 0.33f;


    private float storeTimer;
    private int storePower;
    private float[] storeKnockback = new float[2];

    private bool dashed = false;

    private bool stopped = false;

    private bool dashStartup = false;

    private float multiplier;

    private float storeMaxVelocity;

    private float storeAcceleration;

    private SpriteRenderer sprite;

    protected override void Awake()
    {
        base.Awake();
        storeTimer = dashTimer;
        storePower = power;
        storeKnockback[0] = knockback[0];
        storeKnockback[1] = knockback[1];
        storeMaxVelocity = maxVelocity;
        storeAcceleration = dashAcceleration;

        sprite = GetComponent<SpriteRenderer>();

    }

    protected override bool checkForInput(){
        
        if (!playerMovement.canAttack()){
            return false;
        }
        if(!other_constraints){
            return false;
        }
        if(Input.GetKey(triggerKey)){
            return true;
        }
        return false;


    }

    // Update is called once per frame
    protected override void Update()
    {
        //Debug.Log(hitboxes[0].getDamage());
        
        base.Update();
            if(chargeTimer < midLevelThreshold){
                multiplier = 1.0f;
            } 
            if (chargeTimer >= midLevelThreshold){
                //Debug.Log("Set the mid level velocity!");
                multiplier = midLevelMultiplier;
                sprite.color = new Color(0.4198113f,0.9234585f,1f,1f);
            }
            if(chargeTimer >= maxLevelThreshold){
                //Debug.Log("Set the max level threshold!");
                multiplier = maxLevelMultiplier;
                sprite.color = new Color(1f,0.4196079f, 0.8923197f,1f);
            }


        if(Input.GetKey(triggerKey)){
            chargeTimer += Time.deltaTime;

        }
        if(Input.GetKeyUp(triggerKey)){
            setupDash();
            //Debug.Log(power);
        }

        setHitboxes();

        

        if(!dashed){
            return;
        }

        sprite.color = new Color(1,1f,1f,1f);
    
        if(chargeTimer < startingLag){
            dashStartup = true;
            chargeTimer += Time.deltaTime;
            return;
        }
        dashStartup = false;
        dashTimer -= Time.deltaTime;
        dash();
    
        if(dashTimer <= 0){
            stopped = true;
            dashed = false;
            chargeTimer = 0;
            dashTimer = storeTimer;
            power = storePower;
            knockback[0] = storeKnockback[0];
            knockback[1] = storeKnockback[1];
            xKnockbackValue = Math.Abs(knockback[0]);
            maxVelocity = storeMaxVelocity;
            dashAcceleration = storeAcceleration;

            //Debug.Log(body.velocity[0]);

        }

        anim.SetBool("dashed", dashed);
        anim.SetBool("stopped", stopped);
        anim.SetBool("dashStartup", dashStartup);





        
    }

    protected override void setKnockbackDirection(){
        if(playerMovement.getDirection() == Direction.left){
            knockback[0] = xKnockbackValue * -1;
            dashAcceleration = Math.Abs(dashAcceleration) * -1;
        }
        if(playerMovement.getDirection() == Direction.right){
            knockback[0] = xKnockbackValue;
            dashAcceleration = Math.Abs(dashAcceleration);
        }
    }

    private void setupDash(){
            power = (int) (power * multiplier);
            knockback[0] *= multiplier;
            xKnockbackValue *= multiplier;
            knockback[1] *= multiplier;
            maxVelocity *= multiplier;
            dashTimer *= multiplier;
            dashAcceleration *= multiplier;
            stopped = false;
            dashed = true;
    }

    private void detect_stopping(){
        if(success){
            stopped = false;
        }
        if(Math.Abs(body.velocity[0]) <= 0.3){
            stopped = true;
        }else{
            stopped = false;
        }
    }

    private void dash(){
        dashed = true;
        if(Math.Abs(body.velocity[0]) >= maxVelocity){
            return;
        }
        body.AddForce(new Vector2(dashAcceleration, 0), ForceMode2D.Impulse);
        //body.velocity = new Vector2(dashAcceleration, body.velocity[1]);
    }

    private void DeactivateDashing(){
        base.DeactivateHitbox();
        dashed = false;
    }
}
