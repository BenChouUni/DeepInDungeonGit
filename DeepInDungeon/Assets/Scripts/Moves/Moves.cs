using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Moves : Card,IAction
{

    public int cost;
    public string weaponName;
    public bool aim;
    //public Weapon weapon;
    
    

    public Moves(int _id, string _name, string _description, int _cost,bool _aim, string _WeaponName) : base(_id, _name, _description)
    {
        this.id = _id;
        this.cardName = _name;
        this.cardDescription = _description;

        this.cost = _cost;
        this.weaponName = _WeaponName;

        aim = _aim;
    }

    public Moves(int _id, string _name, string _description, int _cost,bool _aim) : base(_id, _name, _description)
    {
        this.id = _id;
        this.cardName = _name;
        this.cardDescription = _description;

        this.cost = _cost;
        this.weaponName = "undefined";

        aim = _aim;
    }

    public void Action()
    {
        
    }
}

[CreateAssetMenu(fileName = "MyObject", menuName = "CreateMyObject/Move")]
public class MoveCard:ScriptableObject
{
    public Moves move;
    public List<MoveAction.BaseAction> baseActions;
    public List<MoveAction.ApplyAction> applyActions;
    public List<MoveAction.GainAction> gainActions;
}