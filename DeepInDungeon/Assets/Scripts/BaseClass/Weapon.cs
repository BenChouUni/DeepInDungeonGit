using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public int id;
    public string name;
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int slotNumber;
    public string weaponDescribtion;

    public Weapon(int _id,string _name,int _atk, int _def, int _slot,string _describtion)
    {
        this.id = _id;
        this.name = _name;
        this.Attack = _atk;
        this.Defense = _def;
        this.slotNumber = _slot;
        this.weaponDescribtion = _describtion;
    }
}
