using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum PartType
{
    Equipment,Body
}

[Serializable]
public class Part
{
    
    public string name;
    public HpStatus hpStatus;
    public int shield;
    public int endurance;

    public PartType partType;
    
    public Part(string _name,int _maxHealth,PartType _partType)
    {
        name = _name;
        hpStatus = new HpStatus(_maxHealth);
        shield = 0;
        endurance = _maxHealth / 3;
        partType = _partType;
    }

    public static PartType FindPartTypeByText(string str)
    {
        /*PartType myPartType = (PartType)Enum.Parse(typeof(PartType), str);
        return myPartType;
        */

        if (str == "Body")
        {
            return PartType.Body;
        }
        else
        {
            return PartType.Equipment;
        }
    }
}
