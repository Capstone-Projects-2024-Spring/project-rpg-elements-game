using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level;
    public int experience;
    public int requiredExperience;

    public LevelConfig levelConfig;

    private void OnEnable()
    {
    if (ExperienceManager.Instance != null)
        {
            Debug.Log("Subscribed");
            ExperienceManager.Instance.OnExperienceChange += IncreaseExp;
        }
        else
        {
            Debug.LogError("Subscription failed. Instance or event is null.");
        }
    }
    
    private void OnDisable()
    {
        Debug.Log("Unsubscribed");
        ExperienceManager.Instance.OnExperienceChange -= IncreaseExp;
    }
    // Start is called before the first frame update
    void Start()
    {
        CalculateRequiredExp();
    }

    public void IncreaseExp(int value)
    {
        experience += value;
        Debug.Log("Experience ["+experience+"]");

        if(experience>= requiredExperience)
        {
            while(experience>= requiredExperience)
            {
                experience -= requiredExperience;
                LevelUp();
            }
        }
    }

    public void LevelUp()
    {
        level++;
        Debug.Log("Leveled up to: " + level);
        CalculateRequiredExp();
    }

    public void CalculateRequiredExp()
    {
        requiredExperience = levelConfig.GetRequiredExp(level);
        Debug.Log("Next maximum: " + requiredExperience);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
