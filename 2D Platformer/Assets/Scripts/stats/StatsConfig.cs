using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatsConfig", menuName = "ScriptableObjects/StatsConfig", order = 2)]
//Config file, base values aren't actually needed since you can just modify the values in editor
public class StatsConfig : ScriptableObject
{
    [Header("Strength")]
    public int baseStrength = 10;
    public AnimationCurve strengthCurve;
    public CharacterStat Strength;
    
    [Header("Speed")]
    public int baseSpeed = 10;
    public AnimationCurve speedCurve;
    public CharacterStat Speed;

    [Header("Health")]
    public int baseHealth = 100;
    public AnimationCurve healthCurve;
    public CharacterStat Health;
}