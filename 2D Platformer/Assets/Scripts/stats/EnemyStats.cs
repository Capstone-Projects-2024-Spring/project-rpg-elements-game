using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float baseHealth = 50;
    public float baseStrength = 1;
    public float baseSpeed = 10;
    public CharacterStat Health;
    public CharacterStat Strength;
    public CharacterStat Speed;
    public void Awake()
    {
        Health = new CharacterStat(baseHealth);
        Strength = new CharacterStat(baseStrength);
        Speed = new CharacterStat(baseSpeed);
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    CheckStats();
        //}

        
    }
    public void CheckStats()
        {
            print("Health is " + Health.Value);
        }

}