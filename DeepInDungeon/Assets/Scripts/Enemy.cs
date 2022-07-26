using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public int id;
    //生命值
    public int Health { get; set; }

    //名字
    public string name;
    //所有部位
    List<Part> partsList = new List<Part>();

    public Enemy(int _id,string _name,int _health)
    {
        this.id = _id;
        this.Health = _health;
        this.name = _name;
    }

    //加入部位
    public void AddPart(Part _part)
    {
        partsList.Add(_part);
    }
    //受傷
    public void GetDamage(int _dmg)
    {
        this.Health -= _dmg;
    }
}
