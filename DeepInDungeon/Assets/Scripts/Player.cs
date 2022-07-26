using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    /*
     整場唯一
     */
    private string name;
    //金錢
    private int money;
    public int Money { get { return money; } }
    //生命值 不可隨意更改
    private int health;
    public int Health
    {
        get { return health; }
        
    }
    //護盾
    public int Shield { get; set; }
    //狀態列
    private List<StatusClass> statusList = new List<StatusClass>();
    //手牌數 不可隨意更改
    private int handCards;
    public int HandCards
    {
       
        get { return handCards; }

        
    }
    //武器
    Weapon mainWeapon ;
    Weapon secondaryWeapon;



    //函數區
    public void ChangeHealth(int value)
    {
        this.health += value;
    }

    public void ChangeShield(int value)
    {
        this.Shield += value;
    }

    public void AddStatus(StatusClass status)
    {
        statusList.Add(status);
    }

    public StatusClass GetStatus(int index)
    {
        return statusList[index];
    }

    public int GetStatusCount()
    {
        return statusList.Count;
    }
}
