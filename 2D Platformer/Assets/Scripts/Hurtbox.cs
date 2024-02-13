using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour 
{
    public int health = 100;
    private bool attacked = false;
    private int takenDamage = 0;

    private float[] takenKnockback = {0, 0};


    private Rigidbody2D body;

    private float hitstop = 0.0f;

    private String previousReceivedAttack = "";

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Attack" && (attacked == false) && !(string.Equals(other.GetComponent<Hitbox>().getAttackID(), previousReceivedAttack))){
            Debug.Log("I, " + this.name + " got hit by" + other.name + " in the attack " + other.GetComponent<Hitbox>().getAttackID() + " for " + other.GetComponent<Hitbox>().getDamage() + " damage."
            + " and (" + other.GetComponent<Hitbox>().getKnockback()[0] + ", " + other.GetComponent<Hitbox>().getKnockback()[1] + ") knockback.");
            attacked = true;
            takenDamage = other.GetComponent<Hitbox>().getDamage();
            takenKnockback = other.GetComponent<Hitbox>().getKnockback();
            previousReceivedAttack = other.GetComponent<Hitbox>().getAttackID();
        }
    }

    private void Awake(){
        body = GetComponentInParent<Rigidbody2D>();
    }
    private void Update(){
        if (attacked){
            LowerHealth();
            setHitstop(takenKnockback);
            Debug.Log("Received hitstun:" + hitstop);
            Invoke("FlyAway", hitstop);
            attacked = false;
        }
    }

    private void setHitstop(float[] _knockback){
        hitstop = (Math.Abs(_knockback[0]) + Math.Abs(_knockback[1])) * 0.02f;
    }

    private void LowerHealth(){
        health -= takenDamage;
        takenDamage = 0;
    }

    private void FlyAway(){
        Vector2 force = new Vector2(takenKnockback[0], takenKnockback[1]);
        //Debug.Log("Flying away with force " + force);
        body.AddForce(force, ForceMode2D.Impulse);

    }


}
