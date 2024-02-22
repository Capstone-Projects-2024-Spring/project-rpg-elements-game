using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour {

    public int baseStrength = 10;
    public CharacterStat Strength;
    public int baseSpeed = 10;
    public CharacterStat Speed;

    public void Awake()
    {
        Strength = new CharacterStat(baseStrength);
        Speed = new CharacterStat(baseSpeed);
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
        StatModifier speedBoots = new StatModifier(2);
        Speed.AddModifier(speedBoots);
    }
}