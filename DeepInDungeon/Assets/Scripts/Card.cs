using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public int id;
    public string cardName;
    public string cardDiscription;
    public int cost;

    public Card(int _id, string _cardName,string _discription,int _cost)
    {
        this.id = _id;
        this.cardName = _cardName;
        this.cost = _cost;
        this.cardDiscription = _discription;
    }
}

public class AttackCard : Card //攻擊卡
{
    public int attack;
    

    public AttackCard(int _id, string _cardName, string _discription, int _cost, int _attack) : base(_id, _cardName,_discription,_cost)
    {
        this.attack = _attack;
        
    }
}

public class DefendCard : Card //防禦卡
{
    public int defend;

    public DefendCard(int _id, string _cardName, string _discription, int _cost, int _defend) : base(_id, _cardName, _discription, _cost)
    {
        this.defend = _defend;
    }

}

public class WeaponCard : Card//武器卡
{
    public int attack;
    public int defend;

    public WeaponCard(int _id, string _cardName, string _discription, int _cost, int _attack, int _defend):base(_id, _cardName, _discription, _cost)
    {
        this.attack = _attack;
        this.defend = _defend;
    }
}
