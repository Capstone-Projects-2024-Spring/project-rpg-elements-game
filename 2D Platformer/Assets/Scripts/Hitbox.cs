using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private int damage;
    private float[] knockback;

   

    private void Awake(){
        Debug.Log("Hello");

        
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "EnemyHurtbox"){
            Debug.Log("DEAL " + damage + " DAMAGE TO " + other.name);
        }
    }

    public void setDamage(int _damage){
        damage = _damage;
    }

    public int getDamage(){
        return damage;
    }

    public void setKnockback(float[] _knockback){
        knockback = _knockback;
    }

    public float[] getKnockback(){
        return knockback;
    }


    
}
