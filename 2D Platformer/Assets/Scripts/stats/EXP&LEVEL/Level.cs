using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level Instance;
    public delegate void LevelChangeHandler(int level);
    public static event LevelChangeHandler LevelStatUp;

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

        private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CalculateRequiredExp();
    }

    //Adds the value to total experience, then checks if player can level up
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

        //Invokes event that informs PlayerStats to increase
        LevelStatUp?.Invoke(level);
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
