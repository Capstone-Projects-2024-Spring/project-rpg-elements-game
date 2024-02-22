using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour 
{

    [SerializeField] EnemyStats statSheet;
    public int baseHealth;
    Health health = new Health(10);
    private bool attacked = false;
    private int takenDamage = 0;

    private float[] takenKnockback = {0, 0};


    private Rigidbody2D body;

    private double takenHitlag = 0.0;

    private String previousReceivedAttack = "";
    private float time = 0;

    private int times_attacked = 0;

    public string characterName = "Skrake";

    private string ID;

    private bool frozen = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Attack" && (attacked == false) && !(string.Equals(other.GetComponent<Hitbox>().getAttackID(), previousReceivedAttack))){
            
            Debug.Log("I, " + this.name + " got hit by" + other.name + " in the attack " + other.GetComponent<Hitbox>().getAttackID() + " for " + other.GetComponent<Hitbox>().getDamage() + " damage."
            + " and (" + other.GetComponent<Hitbox>().getKnockback()[0] + ", " + other.GetComponent<Hitbox>().getKnockback()[1] + ") knockback.");
            
            attacked = true;
            takenDamage = other.GetComponent<Hitbox>().getDamage();
            takenKnockback = other.GetComponent<Hitbox>().getKnockback();
            takenHitlag = other.GetComponent<Hitbox>().getHitlag();
            previousReceivedAttack = other.GetComponent<Hitbox>().getAttackID();
            times_attacked += 1;
            ID = characterName + times_attacked.ToString();
        }
    }

    private void Awake(){
        body = GetComponentInParent<Rigidbody2D>();
        health.setHealth(baseHealth);
        print(health + "@@@@@@@@@");
    }
    private void Update(){
        if (attacked){
            LowerHealth();
            freezeInHitlag(takenHitlag);
            attacked = false;
        }
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

    private void increaseTimer(){
        time += Time.deltaTime;
    }

    private void freezeInHitlag(double _hitlag){
        time = 0;
        body.constraints = RigidbodyConstraints2D.FreezeAll;
        frozen = true;
        //Debug.Log("Received hitstun:" + _hitlag);

    }

    private void LowerHealth(){
        health.changeHealth(-takenDamage);
        health.checkHealth();
        takenDamage = 0;
        if (!health.Alive)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            print("I died");
        }
    }

    private void FlyAway(){
        Vector2 force = new Vector2(takenKnockback[0], takenKnockback[1]);
        //Debug.Log("Flying away with force " + force);
        body.AddForce(force, ForceMode2D.Impulse);
    }

    public string getName(){
        return ID;
    }


}
