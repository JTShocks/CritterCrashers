using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class VehicleStat
{
    public float BaseValue;

    public float Value {
    get{
        if(isDirty)
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

    //Constructor for a given stat
    public VehicleStat(float baseValue)
    {
        BaseValue = baseValue;
    }

    public void AddModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
    }

    public bool RemoveModifier(StatModifier mod)
    {
        //Removes the mod from the list
        isDirty = true;
        return statModifiers.Remove(mod);
    }

    private float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        for(int i = 0; i < statModifiers.Count; i++)
        {
            finalValue += statModifiers[i].Value;
        }

        // We clamp the result between 1 and 6, since those are our current caps for vehicle stats
        return (float)Math.Clamp(finalValue, 1, 6);
    }



}
