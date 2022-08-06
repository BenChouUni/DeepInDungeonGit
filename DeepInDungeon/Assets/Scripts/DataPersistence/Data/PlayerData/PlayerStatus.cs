using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerStatus
{
    public string playerName;
    public HpStatus hpStatus;
    public int coin;

    public PlayerStatus(string _name,int _maxHp,int _coins)
    {
        this.playerName = _name;
        this.hpStatus = new HpStatus(_maxHp);
        this.coin = _coins;
    }


}

