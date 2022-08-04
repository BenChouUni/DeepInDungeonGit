using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Moves : Card
{

    public int cost;
    public string weaponName;
    //public Weapon weapon;


    public Moves(int _id, string _name, string _description, int _cost,string _WeaponName) : base(_id, _name, _description)
    {
        this.id = _id;
        this.name = _name;
        this.cardDescription = _description;

        this.cost = _cost;
        this.weaponName = _WeaponName;
    }
}