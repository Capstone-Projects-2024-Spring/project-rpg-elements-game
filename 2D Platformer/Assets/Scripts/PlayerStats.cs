using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour {

    public CharacterStat Health = new CharacterStat(10);
    public CharacterStat Strength = new CharacterStat(10);
    public CharacterStat Speed = new CharacterStat(10);

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