using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //名字
    private string name;
    //金錢
    private int money;
    public int Money { get { return money; } }
    private int crystal;
    public int Crystal { get { return crystal; } }
    //生命值
    public HpStatus hpStatus { get; set; }
    //護盾
    public int Shield { get; set; }
    //武器
    Weapon mainWeapon;
    Weapon secondaryWeapon;
    //牌組
    List<Moves> movesDeck = new List<Moves>();
    //狀態列
    private List<StatusClass> statusList = new List<StatusClass>();
    //手牌數 
    private int handCards;
    public int HandCards
    {
        get { return handCards; }
    }

 
    //函數區


}
