using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Invisible boxes turned on by each attack to determine where an attack is going to strike.
    Shouldn't interact with anything except for hurtboxes
*/
public class Hitbox : MonoBehaviour
{
/* 
    All of these variables have getters and setters used by the attack that's using the hitbox,
    as well as the hurtbox the hitbox is colliding with
*/
//How much damage and knockback the hitbox does
    private int damage;
    private float[] knockback = new float[2];
//How long the receiver and sender is frozen for when an attack connects.
    private double hitlag;
/*
    ID variables used to make sure:
     - A hurtbox only gets hit by an attack once.
     - An attack only hits a hurtbox once.
    Prevents an hurtbox from getting hit by the same attack each frame.
*/
    private string attackID;
    private string receiverID = "";
//Used to determine if an attack has connected or not.
    private bool success;


   

    private void Awake(){
    }

    private void Update(){
        //Debug.Log("Hitbox ID: " + attackID);
    //Resets the value of success.
        if(success){
            success = false;
        }
    }

/*
    Detects collision with hurtboxes. Currently, the hurtbox is the one that sets everything,
    but this code is still here if the hitbox ever does anything.
*/
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "EnemyHurtbox"){
            //Debug.Log("ATTACK " + attackID + " DEALS " + hitlag + " HITLAG TO " + other.name);
        }
    }

    public void setDamage(int _damage){
        damage = _damage;
    }

    public int getDamage(){
        return damage;
    }

    public void setKnockback(float[] _knockback){
        knockback[0] = _knockback[0];
        knockback[1] = _knockback[1];
    }

    public float[] getKnockback(){
        return knockback;
    }
    public void setAttackID(string _attackID){
        attackID = _attackID;
    }

    public string getAttackID(){
        return attackID;
    }


    public void setHitlag(double _hitlag){
        hitlag = _hitlag;
    }

    public double getHitlag(){
        return hitlag;
    }

    public bool getSuccess(){
        return success;
    }

    public void setSuccess(bool _success){
        success = _success;
    }

    public void setReceiverID(string _receiverID){
        receiverID = _receiverID;

    }

    public string getReceiverID(){
        return receiverID;
    }

    
}
