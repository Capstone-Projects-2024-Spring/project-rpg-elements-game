using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;
    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChange;

    //Invokes function to anything subscribed to the instance
    public void AddExperience(int amount)
    {
        Debug.Log("AddExperience invoked with amount: " + amount);
        Debug.Log("Number of subscribers: " + (OnExperienceChange != null ? OnExperienceChange.GetInvocationList().Length : 0));
        OnExperienceChange?.Invoke(amount);
    }

    //Checks if there are any other ExperienceManager instances
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
}
