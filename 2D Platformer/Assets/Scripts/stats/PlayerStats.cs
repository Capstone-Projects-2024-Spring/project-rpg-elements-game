using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour {

    //Assignments for the player's stats.
    public StatsConfig statsConfig;
    public CharacterStat Strength;
    public CharacterStat Speed;
    public CharacterStat Health;

    public void Awake()
    {
        Strength = new CharacterStat(statsConfig.baseStrength);
        Speed = new CharacterStat(statsConfig.baseSpeed);
        Health = new CharacterStat(statsConfig.baseHealth);
    }

    //Subscribes to the event in which level increases.
    private void OnEnable()
    {
    if (Level.Instance != null)
        {
            Debug.Log("Subscribed to Level");
            Level.LevelStatUp += HandleLevelUp;
        }
        else
        {
            Debug.LogError("Subscription failed. Instance or event is null.");
        }
    }
    
    //Unsubscribes when disabled.
    private void OnDisable()
    {
        Debug.Log("Unsubscribed");
        Level.LevelStatUp -= HandleLevelUp;
        
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

    //Function that will handle stat increases.
    private void HandleLevelUp(int level)
    {
        Debug.Log("Current player level is: " + level);
    }
}