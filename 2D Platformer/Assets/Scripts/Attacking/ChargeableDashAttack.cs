using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    For chargeable attacks that send the player forwards
    How long they charge the move is how long they hold the button for.
    How long they charge affects the following:
    - How far do they go?
    - How fast are they?
    - How much damage do they do?
    - How much knockback do they do?
    - How long are they charging for?
*/
public class ChargeableDashAttack : PlayerAttack
{
    // Keeps track of how long the move is charged for.
    private float chargeTimer = 0;
    /*
        Determines how long (in seconds) the player has to charge for until they reach the next level
        of charge.
        Mid level is the 2nd level of charge.
        Max level is the 3rd and highest level of charge.
        If neither of these levels are meet, the attack's default values are used instead.
    */
    [SerializeField] private float midLevelThreshold = 1.0f;
    [SerializeField] private float maxLevelThreshold = 2.0f;
    /*
        Multipliers for when the player reaches certain levels of charge.
        They amplify the folllowing: Damage, knockback, velocity, acceleration, dashTimer
        Of course, max level charge should be more intense than mid level.
    */
    [SerializeField] private float midLevelMultiplier = 1.2f;

    [SerializeField] private float maxLevelMultiplier = 1.35f;
    //Decide the acceleration and speed of the player while they're dashing.
    [SerializeField] private float dashAcceleration = 2.0f;

    [SerializeField] private float maxVelocity = 10.0f;
    //Decides how long the player is dashing for.
    [SerializeField] private float dashTimer = 0.5f;
    /*
        The minimum amount of time (in seconds) the player is required to be charging for.
        Even if the player releases the attack before this point, they are required to wait
        this long until the charge is released.
    */
    [SerializeField] private float startingLag = 0.33f;

// "store" variables used for resetting the attack to its default settings.
    private float storeTimer;
    private int storePower;
    private float[] storeKnockback = new float[2];

    private float storeMaxVelocity;

    private float storeAcceleration;
//booleans used by this script and the animator to determine which phase of the attack the player's in. 
    private bool dashed = false;

    private bool stopped = false;

    private bool dashStartup = false;
//Multiplied with the other properties to amplify the attack.
    private float multiplier;



    private SpriteRenderer sprite;
//Sets all of the "store" variables. Oh, and the sprite too.
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
//Overrides the parent function so that it detects if the button is being held down, not just pushed.
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

    //Increments the charge timer based on how long the button is being held.
        if(Input.GetKey(triggerKey)){
            chargeTimer += Time.deltaTime;

        }

    //Sets the multiplier and sprite color based on how long the attack is charging for.
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

    //If the button is released, amplify everything that needs to be amplified.
        if(Input.GetKeyUp(triggerKey)){
            setupDash();
            //Debug.Log(power);
        }
        
    /*
    The following should ONLY run if the player is currently in the dashing phase.
    */
        if(!dashed){
            return;
        }
    //Restore default color to the sprite
        sprite.color = new Color(1,1f,1f,1f);
    /*
    If the player released the attack before they reached the attack's starting lag, they're forced to
    charge until they do so. Prevents them from instantaneously dashing.
    */
        if(chargeTimer < startingLag){
            dashStartup = true;
            chargeTimer += Time.deltaTime;
            return;
        }
    /*
        Moves the player forwards and decreases the "dash timer"
    */
        dashStartup = false;
        dashTimer -= Time.deltaTime;
        dash();
    //Once the dash timer hits 0, the player stops dashing and everything is reset.
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
    //Used by the animator to convey which phase of the attack the player's in.
        anim.SetBool("dashed", dashed);
        anim.SetBool("stopped", stopped);
        anim.SetBool("dashStartup", dashStartup);





        
    }
//Overrides the parent function by also setting acceleration based on which way the player's facing.
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
/*
    Used by the Update function to multiply everything that needs to be multiplied.
    Booleans are also changed so Update knows which phase of the attack the player's in.
    The hitboxes are also set again with these new, amplified values.
*/
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
            setHitboxes();
            //Debug.Log(power + " " + hitboxes[0].getDamage());
    }

/*
    Used by update to move the player forwards.
    Unlike with rising attacks, this is called every frame to ensure that there's acceleration to the attack
    And to ensure that the player will reach their max speed regardless of friction
    Oh yeah, and the player can't move faster than whatever max velocity is set as (which also depends on
    how long they've charged the attack for) 
*/
    private void dash(){
        dashed = true;
        if(Math.Abs(body.velocity[0]) >= maxVelocity){
            return;
        }
        body.AddForce(new Vector2(dashAcceleration, 0), ForceMode2D.Impulse);
        //body.velocity = new Vector2(dashAcceleration, body.velocity[1]);
    }
/*
    USED BY THE ANIMATOR ONLY
    Turns off hitboxes and resets the dash boolean
*/
    private void DeactivateDashing(){
        base.DeactivateHitbox();
        dashed = false;
    }
}
