using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public float baseHealth = 50;
    public float baseStrength = 1;
    public float baseSpeed = 10;
    public CharacterStat Health;
    public Image healthBar;
    public Transform skrakeTransform;
    public Transform healthTransform;
    public CharacterStat Strength;
    public CharacterStat Speed;

    private Color currentA;
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

        
        if(Health.Value < baseHealth){
            currentA.a = 1f;
            currentA.r = 255f;
            healthBar.fillAmount = Health.Value/baseHealth;
        } else {
            currentA.a = 0f;
        }
    healthTransform.localScale = new Vector3(skrakeTransform.localScale.x, healthTransform.localScale.y, healthTransform.localScale.z);
    healthBar.color = currentA;
    }
    public void CheckStats()
        {
            print("Health is " + Health.Value);
        }

}