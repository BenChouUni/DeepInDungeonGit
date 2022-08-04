using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpStatus : MonoBehaviour
{
    private int hp;
    public int Hp
    {
        get { return hp; }
        
    }

    private int hpMax;
    public int HpMax
    {
        get { return hpMax; }

        set { hpMax = value; }
    }



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
