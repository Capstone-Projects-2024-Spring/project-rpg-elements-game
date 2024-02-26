using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Can adjust config to curve
[CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/LevelConfig", order = 1)]
public class LevelConfig : ScriptableObject
{
    [Header("Animation Curve")]
    public AnimationCurve animationCurve;
    public int MaxLevel;
    public int MaxRequiredExp;

    public int GetRequiredExp(int level)
    {
        int requiredExperience = Mathf.RoundToInt(animationCurve.Evaluate(Mathf.InverseLerp(0, MaxLevel, level)) * MaxRequiredExp);
        return requiredExperience;
    }
}
