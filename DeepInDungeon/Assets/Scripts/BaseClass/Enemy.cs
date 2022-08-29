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
public class Enemy
{
    public int id;
    //生命值
    public HpStatus hpStatus;
    public int atk;
    public int shield;
    //名字
    public string name;
    //種族
    public Species species;
    public int speciesID;
    //部位
    public List<Part> parts;
    


    public Enemy(int _id,string _name,int _maxHealth,int _atk,Species _species,int _speciesID,List<Part> _parts)
    {
        this.id = _id;
        this.name = _name;
        this.hpStatus = new HpStatus(_maxHealth);
        this.shield = 0;
        this.atk = _atk;
        species = _species;
        speciesID = _speciesID;
        parts = _parts;
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
