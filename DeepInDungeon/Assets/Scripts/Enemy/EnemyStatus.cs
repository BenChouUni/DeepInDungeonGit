using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 種族，主要是敵人的分類用
/// </summary>
[Serializable]
public enum Species
{
   Humans,Trees,
}

[Serializable]
public class EnemyStatus:Unit
{
    public int id;
    [SerializeField]
    private int atk;
    //種族
    public Species species;
    public int speciesID;
    //部位
    //public List<Part> parts;
    


    public EnemyStatus(int _id,string _name,int _maxHealth,int _shield,int _atk,Species _species,int _speciesID):base(_name,_maxHealth,_shield)
    {
        this.id = _id;
        this.atk = _atk;
        species = _species;
        speciesID = _speciesID;
        
    }

    public static Species FindSpeciesByText(string str)
    {

        if (str == "Trees")
        {
            return Species.Trees;
        }

        return Species.Humans;
    }

}
