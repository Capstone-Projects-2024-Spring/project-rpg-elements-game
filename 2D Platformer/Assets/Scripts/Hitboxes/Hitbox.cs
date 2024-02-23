using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private int damage;
    private float[] knockback = new float[2];

    private double hitlag;

    private String attackID;


    private bool success;

    private String receiverID = "";

   

    private void Awake(){
    }

    private void Update(){
        if(success){
            success = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "EnemyHurtbox"){
            //Debug.Log("ATTACK " + attackID + " DEALS " + hitlag + " HITLAG TO " + other.name);
            //receiverID = other.GetComponent<Hurtbox>().getName();
            //success = true;
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



    public void setAttackID(String _attackID){
        attackID = _attackID;
    }

    public String getAttackID(){
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

    public float getKnockback(int position){
        return knockback[position];
    }


    
}
