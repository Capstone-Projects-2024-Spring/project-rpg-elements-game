using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Properties;

//The basic attack script that all attacks will inherit from. Contains logic that all attacks should follow.
public abstract class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerStats statSheet;

    protected Animator anim;
    protected Movement playerMovement;

/* 
Base damage of the move. Later, attacks will also account for the player's strength stat when
calculating damage
*/
    [SerializeField] protected int power; 

//Base knockback of the move. Unlike with power, this should NOT change based on the player's strength stat
//First item is knockback in the x direction. The second one is knockback in the y direction.
    [SerializeField] protected float[] knockback = {4, 3};
/* 
The key that's pressed to trigger the attack.
Later, when the attack menu is being created, these can be changed in-game based on which attacks the
player is equipping. For now, before that gets implemented, every attack will have a unique trigger key
for testing purposes
 */
    [SerializeField] protected KeyCode triggerKey;
//Knockback in the x direction as a variable. Used to account for player direction when dealing knockback
    protected float xKnockbackValue;
//Array of which hitboxes will be used by the attack.
    [SerializeField] protected Hitbox[] hitboxes;
//For development purposes. In the final game, all hitboxes will be invisible
    [SerializeField] protected bool visible_hitboxes = true;
    [SerializeField] public String attackName = "strike";
    [SerializeField] public string attackDescription = "A placeholder description for attacks. Seen by the user in the attack menu.";
/*
For the animator to know which animation to trigger. 
It's a separate variable from attackName since I'll probably have to capialize the attack names later, but
not the animation triggers
 */
    [SerializeField] protected string animationTrigger = "attack";

//How many times the attack is used. Used when creating the "Attack ID"
    protected int uses = 0;
//The time (in seconds) a player and enemy is frozen for when an attack connects
    protected double hitlag;
//Whether or not the attack hits.
    protected bool success = false;
/*
Used to signify that if a specific attack is being used or not. Important for making sure two attacks
don't trigger at the same time. Shouldn't really be messed with. */
    protected bool active;

    private float hitlagTimer = 0;
/*
Used for getting the ID of who the attack landed on. Important for making sure the attack hits an enemy only
once when it's active and not on every frame
*/
    private String receiverID = "";

    protected Rigidbody2D body;
/*Used when the player freezes in hitlag to make sure any momentum 
they had beforehand is preserved for when they unfreeze
*/
    private Vector2 storedVelocity = new Vector2();
// A boolean to be used by other attacks that would want to limit whether or not an attack could be used
    protected bool other_constraints = true;
//Runs once when the script is started.
    protected virtual void Awake(){
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();
        body = GetComponentInParent<Rigidbody2D>();
        xKnockbackValue = Math.Abs(knockback[0]);
        hitlag = setHitlag(knockback[0], knockback[1]);
    }
/*
    Sets up the following for each hitbox in the attack: Damage, Knockback, Hitlag, Visibility
*/
    protected virtual void setHitboxes(){
        foreach(Hitbox hitbox in hitboxes){
            hitbox.setDamage(power);
            hitbox.setKnockback(knockback);
            hitbox.setHitlag(hitlag);
            setHitboxVisibility(hitbox);
        }
    }

    protected virtual void setHitboxVisibility(Hitbox hitbox){
        if(visible_hitboxes){
            hitbox.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,0f,0f,0.5f);
        }else{
            hitbox.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);

        }
    }
/*
Used in the update function to decide if the player can attack. 
An attack can only be triggered if the following are true:
    - Did the player hit the attack button?
    - Is the player not in an attacking state already?
    - Any other constraints that should prevent the player from attacking?
*/
    protected virtual bool checkForInput(){
        if(!Input.GetKeyDown(triggerKey)){
            return false;
        }
        if (!playerMovement.canAttack()){
            return false;
        }
        if(!other_constraints){
            return false;
        }
        return true;

    }

    protected virtual void Update(){
    /*
        When an attack is triggered, the following are true:
         - The attack is now "active". Only one attack can be active at a time
         - The player is now in an "attacking" state. So they shouldn't be able to run or jump.
         - The hitboxes in the attack are set
         - The "attack ID" is set (more information in setAttackName())
         - The animation for the attack triggers
    */
        if(checkForInput()){
            playerMovement.setAttackStateTrue();
            active = true;
            setHitboxes();
            setAttackName();
            Attack();
        }
    //Reverses knockback if the player is facing left.
        setKnockbackDirection();
    /*
        The following code should NOT run UNLESS the attack is active.
        Consequently, only one attack should be able to access this code at a time.
    */
        if(!active){
            //Debug.Log(attackName + "is not active");
            return;
        }
        Debug.Log(attackName + " is active!");

    
    //If the attack manages to hit something, the player should freeze for a short amount of time
    
        checkSuccess();
        if(success){
            enterHitlag();
            //Debug.Log("This should only print once");
            success = false;
        }
    /*
    If the player is frozen after hitting something, a timer starts.
    Animations are frozen until the timer is greater than how much "hitlag" the attack has.
    Once the timer reaches that point, the player unfreezes.
    */
        if(anim.enabled == false){
            hitlagTimer += Time.deltaTime;
            //Debug.Log(hitlagTimer);
            if(hitlagTimer > hitlag){
                exitHitlag();
            }
        }

    }
/*
Sets success to true if the attack has landed.
Only hits an enemy once until the attack ends.
*/
    protected void checkSuccess(){
        //Debug.Log(attackName);
        foreach(Hitbox hitbox in hitboxes){
            if(hitbox.getSuccess() && !string.Equals(hitbox.getReceiverID(), receiverID)){
                //Debug.Log("We hit " + hitbox.getReceiverID());
                receiverID = hitbox.getReceiverID();
                success = true;
            }
        }

    }
/*
    Gives each attack an "ID" based on the attack name and how many times it's been used.
    Used to ensure that an enemy doesn't get hit by an attack each frame.
    Once multiplayer is integrated, each player should also have a unique ID, and that ID should
    be a part of the attack ID as well so that 2 players can never have the same attack ID.
*/
    protected virtual void setAttackName(){
        uses += 1;
        string attackUses = uses.ToString();
        string ID = attackName + attackUses;
        foreach(Hitbox hitbox in hitboxes){
            hitbox.setAttackID(ID);
            //Debug.Log(hitbox.getAttackID());
        }
    }
/*
    Calculates hitlag. "Hitlag" is how much time (in seconds) the player and enemy are frozen for 
    if the attack lands.
*/
    protected double setHitlag(float xknockback,float yknockback){
        double calculated_hitlag = (Math.Sqrt(Math.Pow(Math.Abs(xknockback), 2) + Math.Pow(Math.Abs(yknockback), 2)) * 0.65 + 6)/60;
        if(calculated_hitlag > 0.5){calculated_hitlag = 0.5;}
        return calculated_hitlag;

    }
/*
    Called by the Update function to freeze the player in place when an attack lands.
    Any momentum the player had beforehand is stored until they unfreeze.
*/
    protected void enterHitlag(){
        hitlagTimer = 0;
        anim.enabled = false;
        storedVelocity = body.velocity;
        body.constraints = RigidbodyConstraints2D.FreezeAll;
        //Debug.Log("Before " + attackName + ": " + storedVelocity);
        
    }
/*
    Used by the Update function to unfreeze a player once enough time has passed after an attack has landed.
*/
    protected void exitHitlag(){
        anim.enabled = true;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        body.velocity = storedVelocity;
        //Debug.Log("After " + attackName + ": " + body.velocity);
        //Debug.Log("No longer in hitlag");
    }
/*
    Inverts knockback in the x direction if the player is facing left.
    Ensures that attack knockback behaves the same regardless of if the player is facing left or right.
*/
    protected virtual void setKnockbackDirection(){
        if(playerMovement.getDirection() == Direction.left){
            knockback[0] = xKnockbackValue * -1;
        }
        if(playerMovement.getDirection() == Direction.right){
            knockback[0] = xKnockbackValue;
        }
    }
/*
    Triggers the animation for the attack. In hindsight, this could either be renamed, have more stuff moved
    into it, or just have this one line of code moved to the Update function and then delete it.
    But for now it stays.
*/
    protected void Attack(){
        //Debug.Log("This should only print once");
        anim.SetTrigger(animationTrigger);
    }
    
/*
    USED BY THE ANIMATOR ONLY
    Turns on all hitboxes used by whichever attack is active.
*/
    protected virtual void ActivateHitbox(){
        if(!active){
            return;
        }
        foreach(Hitbox hitbox in hitboxes){
            hitbox.gameObject.SetActive(true);
        }

    }
/*
    USED BY THE ANIMATOR ONLY
    Turns OFF all hitboxes and sets "active" to false.
    Note that this DOESN'T turn off attacking state. That's a separate function used in the movement script.
    If an attack is NOT active, but the player is STILL in an attacking state, then the player is in
    the COOLDOWN portion of the attack.
*/
    protected void DeactivateHitbox(){
        if(!active){
            return;
        }
        foreach(Hitbox hitbox in hitboxes){
            hitbox.setSuccess(false);
            hitbox.gameObject.SetActive(false);
        }
        active = false;
        success = false;


    }

}
