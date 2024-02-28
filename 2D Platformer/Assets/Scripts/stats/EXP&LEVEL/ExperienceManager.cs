using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;
    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChange;

    public void AddExperience(int amount)
    {
        Debug.Log("AddExperience invoked with amount: " + amount);
        Debug.Log("Number of subscribers: " + (OnExperienceChange != null ? OnExperienceChange.GetInvocationList().Length : 0));
        OnExperienceChange?.Invoke(amount);
    }
    //Checks if an instance of this already exists
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
