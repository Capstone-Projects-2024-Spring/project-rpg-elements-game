using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour 
{
    public int health = 100;
    private bool attacked = false;
    private int takenDamage = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Attack" && attacked == false){
            Debug.Log("I, " + this.name + " got hit by" + other.name + " for " + other.GetComponent<Hitbox>().getDamage() + " damage.");
            attacked = true;
            takenDamage = other.GetComponent<Hitbox>().getDamage();
        }
    }
    private void Update(){
        if (attacked){
            LowerHealth();
        }
    }

    private void LowerHealth(){
        health -= takenDamage;
        takenDamage = 0;
        attacked = false;
    }

}
