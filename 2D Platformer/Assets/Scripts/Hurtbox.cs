using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour 
{
    public int health = 100;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Attack"){
            Debug.Log("I got hit by" + other.name + " for " + other.GetComponent<Hitbox>().damage + " damage.");
            health -= other.GetComponent<Hitbox>().damage;
            Debug.Log("I now have " + health + " health.");
        }
    }

}
