using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class HpStatus
{

    public int hp;


    public int hpMax;


    public HpStatus(int _hpMax)
    {
        this.hpMax = _hpMax;
        this.hp = _hpMax;
    }


}
