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
            Debug.Log("I got hit by" + other.name + " for " + other.GetComponent<Hitbox>().damage + " damage.");
            attacked = true;
            takenDamage = other.GetComponent<Hitbox>().damage;
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
