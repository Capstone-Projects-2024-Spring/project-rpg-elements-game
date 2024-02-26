using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
/*
    Attacks that send the player upwards.
    
*/
public class RisingAttack : PlayerAttack
{
    /*
        Detects if the player is falling.
        It's important to note that the animator does NOT change the attack state to false, nor does
        it turn off the hitboxes.
        Instead, the attack's hitboxes will automatically turn off when the player starts falling while
        it's active, and the attack state will be set to false as well.
    */
    private bool falling = false;
    /*
        The attack can only be used when charged is true.
        Charged is true by default, but using the attack sets it to false.
        Once charged is false, it can be set to true again if the player is grounded.
        (Maybe getting attacked will also recharge it, like with all Up-B moves in Smash Bros. 
        But that is not implemented yet.)
    */
    private bool charged = true;
    /*
        Checks whether or not the player has activated the burst() function.
        Used when turning off the attack.
    */
    private bool bursted = false;
/*
    Determines how high the attack goes.
*/
    [SerializeField] float rising_velocity = 15;
/*
    Change the player's gravity to change how fast they rise.
    Gravity should only be changed when the player is RISING. When the player is falling, 
    gravity should be normal. 
*/
    [SerializeField] float gravity_reduction = 1.0f;
/*
    Stores the player's default gravity scale.
*/
    private float stored_gravity;

    protected override void Awake(){
        base.Awake();
        stored_gravity = body.gravityScale; 
    }
    protected override void Update(){
        //Debug.Log(playerMovement.canAttack());
        //Debug.Log(playerMovement.isGrounded());
        
    /*
        If the player is grounded, charged will always be true.
        If the attack is active, charged will always be false.
    */
        if(playerMovement.isGrounded()){
            charged = true;
        }
        if(active){
            charged = false;
        }
    //Ensures that the attack can't be used if charged is false.
        other_constraints = charged;

    //Calls the parent update function  
        base.Update();

        if(!active){
            return;
        }
    //If the player is falling and the attack has been used up, then the attack turns off.
        detect_falling();

        if(falling && bursted){
            Deactivate();
        }
    }

//  Sets "falling" as true if the player is in the air and falling.
    private void detect_falling(){
        if(!playerMovement.isGrounded() && body.velocity[1] < 0){
            falling = true;
        }else{
            falling = false;
        }
        anim.SetBool("falling", falling);
    }
//Turns off active hitboxes. Sets attack state to false. Resets everything to their default position.
    private void Deactivate(){
        //Debug.Log("Skyslash deactivated the attack!");
        base.DeactivateHitbox();
        playerMovement.setAttackStateFalse();
        body.gravityScale = stored_gravity;
        bursted = false;

    }

/*
    USED BY THE ANIMATOR ONLY
    Freezes the player in place before the attack comes out.
*/
    protected override void freeze(){
        if(!active){
            return;
        }

        bursted = false;
        body.constraints = RigidbodyConstraints2D.FreezeAll;
    }
/*
    USED BY THE ANIMATOR ONLY
    Unfreezes the player and sends them upwards
    In hindsight, "rise" is probably a better name than burst O_O Might rename this function later lol
*/
    private void burst(){
        if(!active){
            return;
        }
        bursted = true;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        body.gravityScale *= gravity_reduction;
        body.velocity =  new UnityEngine.Vector2(0, rising_velocity);

    }
}
