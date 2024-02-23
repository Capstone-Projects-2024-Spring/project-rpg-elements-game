using System;
using System.Collections.Generic;

public class CharacterStat
{
    public float BaseValue;
    public float Value { 
        get { 
            if (isDirty)
            {
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        } 

    }

    private bool isDirty = true;
    private float _value;

    private readonly List<StatModifier> statModifiers;

    public CharacterStat(float baseValue)
    {
        BaseValue = baseValue;
        statModifiers = new List<StatModifier>();
    }
    //Use negative number to reduce stat, positive to increase
    public void ChangeStat(int amt)
    {
        StatModifier reducedByMethod = new StatModifier(amt);
        AddModifier(reducedByMethod);
    }
    public void AddModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
    }

    public bool RemoveModifier(StatModifier mod)
    {
        isDirty = true;
        return statModifiers.Remove(mod);
    }

    public float CalculateFinalValue()
    {
        float finalValue = BaseValue;

        for (int i = 0; i < statModifiers.Count; i++)
        {
            finalValue += statModifiers[i].Value;
        }
        // 12.0001f != 12f
        return (float)Math.Round(finalValue, 4);
    }

}

