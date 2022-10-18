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
public class Part:Unit
{

    public int endurance;

    public PartType partType;
    
    public Part(string _name,int _maxHealth,int _shield,PartType _partType):base(_name,_maxHealth,_shield)
    {
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
