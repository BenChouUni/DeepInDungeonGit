using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class HpStatus
{
    private int hp;
    public int Hp
    {
        get { return hp; }
        
    }

    public int hpMax;
    



    public HpStatus(int _hpMax)
    {
        this.hpMax = _hpMax;
        this.hp = _hpMax;
    }

    public void GotDamage(int dmg)
    {
        if (dmg<=0)
        {
            return;
        }

        this.hp -= dmg;
    }
}
