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

    //When level is enabled (for example when game starts) it attempts to subscribe to the
    //ExperienceManager's event
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

    //When it is disabled it will unsubscribed so it's not left hanging
    private void OnDisable()
    {
        Debug.Log("Unsubscribed");
        ExperienceManager.Instance.OnExperienceChange -= IncreaseExp;
    }

    //Checks that there is only one instance so that multiple messages aren't passed when event called
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

    //Increments the level than calls CalculateRequiredExp() to figure out new exp amount
    public void LevelUp()
    {
        level++;
        Debug.Log("Leveled up to: " + level);
        CalculateRequiredExp();

        //Invokes event that informs PlayerStats to increase
        LevelStatUp?.Invoke(level);
    }

    //Checks scriptable object level config to calculate new exp req.
    public void CalculateRequiredExp()
    {
        requiredExperience = levelConfig.GetRequiredExp(level);
        Debug.Log("Next maximum: " + requiredExperience);
    }
}
