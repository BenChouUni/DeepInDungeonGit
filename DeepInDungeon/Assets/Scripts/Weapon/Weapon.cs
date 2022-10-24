using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Weapon:Card
{
    
    public enum Hand
    {
        Empty = 0, Main = 1, Secondary = 2, TwoHanded = 3
    }
    
    public Hand hand;

    public int Attack;
    public int Defense;
    public int slotNumber;


    private int i;

    
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

    public static Hand CheckHandByString(string str)
    {


        switch (str.Trim())
        {
            case "main":
                //Debug.Log("主要");
                return Hand.Main;

            case "sec":
                //Debug.Log("副手");
                return Hand.Secondary;

            case "two":
                //Debug.Log("雙手");
                return Hand.TwoHanded;


            default:
                //Debug.Log("空");
                return Hand.Empty;


        }

    }

}
