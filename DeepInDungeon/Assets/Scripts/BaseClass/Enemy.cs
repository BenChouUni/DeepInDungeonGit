using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public int id;
    //生命值
    public HpStatus hpStatus;
    public int atk;
    //名字
    public string name;


    public Enemy(int _id,string _name,int _maxHealth,int _atk)
    {
        this.id = _id;
        this.hpStatus = new HpStatus(_maxHealth);
        this.name = _name;
        this.atk = _atk;
    }


    //受傷

}
