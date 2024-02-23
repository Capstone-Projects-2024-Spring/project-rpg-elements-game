using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Invisible boxes that collide with hitboxes to detect whether or not the character has been hit by something.
*/
public class Hurtbox : MonoBehaviour 
{

    [SerializeField] EnemyStats statSheet;
//Boolean value that detects whether or not the hurtbox has collided with a hitbox.
    private bool attacked = false;

//Received information from the hitbox the hurtbox has collided with
    private int takenDamage = 0;
    private float[] takenKnockback = {0, 0};

    private double takenHitlag = 0.0;

    private Rigidbody2D body;

/*
    A string that's compared with the hitboxes ID to make sure that it's not being hit 
    by the same attack multiple times.
*/
    private String previousReceivedAttack = "";
//Timer used for freezing the hurtbox in place if it's received an attack
    private float time = 0;
//Checks if the hurtbox is currently frozen in place or not
    private bool frozen = false;


/*
    Variables used to create a "receiverID" for an attack to make sure it's not hitting 
    the same hurtbox multiple times.
*/
    private int times_attacked = 0;

    public string characterName = "Skrake";

    private string ID;

/*
    When a hurtbox collides with a hitbox, the following is checked:
        - Does this have the tag I want to be hit by?
        - Am I in an attacked state already?
        - Have I already been hit by this attack ID?
    If all of these checks passes, the relevant variables in both the hurtbox and 
    the hitbox connecting with it are updated.
    It's also important to note that this function gets called BEFORE Update.
*/
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Attack" && (attacked == false) && !(string.Equals(other.GetComponent<Hitbox>().getAttackID(), previousReceivedAttack))){
              
            attacked = true;
            takenDamage = other.GetComponent<Hitbox>().getDamage();
            takenKnockback = other.GetComponent<Hitbox>().getKnockback();
            takenHitlag = other.GetComponent<Hitbox>().getHitlag();
            previousReceivedAttack = other.GetComponent<Hitbox>().getAttackID();
            times_attacked += 1;
            ID = characterName + times_attacked.ToString();
            other.GetComponent<Hitbox>().setReceiverID(getName());
            other.GetComponent<Hitbox>().setSuccess(true);
             Debug.Log("I, " + ID + " got hit by" + other.name + " in the attack " + other.GetComponent<Hitbox>().getAttackID() + " for " + other.GetComponent<Hitbox>().getDamage() + " damage."
            + " and (" + other.GetComponent<Hitbox>().getKnockback()[0] + ", " + other.GetComponent<Hitbox>().getKnockback()[1] + ") knockback.");
        }
        else if (other.tag == "PlayerHurtbox")
        {
            print("I am touching a player");
            other.GetComponent<PlayerStats>().takeDamage((int)statSheet.Strength.Value);

        }
    }

    private void Awake(){
        body = GetComponentInParent<Rigidbody2D>();
    }
    private void Update(){
    /*
        If the hurtbox has been attacked, freeze the hurtbox in place and lower the
        character's health (lowering the character's health might have to be moved to
        another script if we ever create something with multiple hurtboxes)
    */
        if (attacked){
            LowerHealth();
            freezeInHitlag(takenHitlag);
            attacked = false;
        }
    /*
        If the hurtbox is frozen in hitlag, increase a timer.
        Once the timer is high enough, the hurtbox unfreezes and flies away based on 
        how much knockback it has received.
    */
        if(frozen){
            increaseTimer();
            if (time > takenHitlag){
                frozen = false;
                body.constraints = RigidbodyConstraints2D.FreezeRotation;
                //Debug.Log("Body is no longer in hitlag!");
                FlyAway();            

            }
        }
    }
//Used by update to keep track of how long the hurtbox needs to be frozen for.
    private void increaseTimer(){
        time += Time.deltaTime;
    }
//Freezes the hurtbox in place when an attack hits it.
    private void freezeInHitlag(double _hitlag){
        time = 0;
        body.constraints = RigidbodyConstraints2D.FreezeAll;
        frozen = true;
        //Debug.Log("Received hitstun:" + _hitlag);

    }
//Lowers the health of the receiver.
    private void LowerHealth(){
        statSheet.Health.DecreaseStat(takenDamage);
        print("my health is now ["+statSheet.Health.Value+"]");
        takenDamage = 0;
        if (statSheet.Health.Value <= 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            print("I died");
        }
    }
//Makes the hurtbox recoil based on the attack's knockback
    private void FlyAway(){
        Vector2 force = new Vector2(takenKnockback[0], takenKnockback[1]);
        //Debug.Log("Flying away with force " + force);
        body.AddForce(force, ForceMode2D.Impulse);
    }
//Used by the hitbox to get the ID of the hurtbox, ensuring an attack only hits it once.
    public string getName(){
        return ID;
    }


}
