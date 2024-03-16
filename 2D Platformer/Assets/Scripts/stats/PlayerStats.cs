using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour {

    [Header("Strength")]
    public int baseStrength = 10;
    public AnimationCurve strengthCurve;
    public CharacterStat Strength;
    
    [Header("Speed")]
    public int baseSpeed = 10;
    public AnimationCurve speedCurve;
    public CharacterStat Speed;

    [Header("Health")]
    public int baseHealth = 100;
    public AnimationCurve healthCurve;
    public CharacterStat Health;

    public void Awake()
    {
        Strength = new CharacterStat(baseStrength);
        Speed = new CharacterStat(baseSpeed);
        Health = new CharacterStat(baseHealth);
    }

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

    private void HandleLevelUp(int level)
    {
        Debug.Log("Current player level is: " + level);
    }
}