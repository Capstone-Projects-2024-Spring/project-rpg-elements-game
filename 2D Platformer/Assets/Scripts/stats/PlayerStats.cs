using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour {

    public int baseStrength = 10;
    public CharacterStat Strength;
    public int baseSpeed = 10;
    public CharacterStat Speed;
    public int baseHealth = 100;
    public CharacterStat Health;

    public void Awake()
    {
        Strength = new CharacterStat(baseStrength);
        Speed = new CharacterStat(baseSpeed);
        Health = new CharacterStat(baseHealth);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CheckStats();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AddSpeed();
        }
    }
    public void CheckStats()
    {
        print("Speed is " + Speed.Value);
    }
    public void AddSpeed()
    {
        Speed.IncreaseStat(2);
    }
    public void takeDamage(int damageTaken)
    {
        Health.DecreaseStat(damageTaken);
        print("Player [" + this.gameObject.name + "] took [" + damageTaken + "] damage and is now at [" + Health.Value + "] health.");
        if (Health.Value <= 0)
        {
            die();
        }
    }
    public void die()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        print(this.gameObject.name + " is dead");
    }
}