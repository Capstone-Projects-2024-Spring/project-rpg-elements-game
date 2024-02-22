using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Health
{
    public float Value;
    public bool Alive = true;

    public Health(float baseValue)
    {
        Value = baseValue;
    }
    //Use negative number to reduce stat, positive to increase
    public void changeHealth(int amt)
    {
        Value += amt;
        if (Value < 0)
        {
            Value = 0;
            if (Alive)
            {
                die();
            }
        }
    }
    public void die()
    {
        //this.GameObject().gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        Alive = false;
    }
    public void setHealth(int amt)
    {
        Value = amt;
    }
    public void checkHealth()
    {
        Debug.Log("Health is [" + Value + "]");
    }
}

