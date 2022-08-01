using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Hand
{
    Empty,Main, Secondary, TwoHanded
}

public class Weapon:Card
{

    

    
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int slotNumber;
    

    private Hand hand;
    public Hand WeaponHand
    {
        get { return hand; }
    }

    public Weapon(int _id, string _name, int _atk, int _def, int _slot, string _description, Hand _hand) : base(_id, _name, _description)
    {
        this.id = _id;
        this.name = _name;
        this.Attack = _atk;
        this.Defense = _def;
        this.slotNumber = _slot;
        this.cardDescription = _description;
        this.hand = _hand;
    }


}
