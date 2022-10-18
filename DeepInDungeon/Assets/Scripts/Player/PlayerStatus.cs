using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerStatus:Unit
{
    private int energy;
    public int Energy { get { return energy; } }
    private int coin;
    public int Coin { get { return coin; } }
    

    public PlayerStatus(string _name,int _maxHealth,int _shield,int _energy,int _coins):base(_name,_maxHealth,_shield)
    {
        this.energy = _energy;
        this.coin = _coins;
       
    }
    /// <summary>
    /// 給測試時的基本初始化 內容是("無名氏",100,0,3,50)
    /// </summary>
    public PlayerStatus():this("無名氏",100,0,3,50)
    {
        
    }

    public void EnergyMinus(int num)
    {
        if (num < 0)
        {
            Debug.Log("能量不能扣負數");
            return;
        }
        this.energy -= num;
        return;
    }

    public void CoinGet(int num)
    {
        if (num <= 0)
        {
            return;
        }
        this.coin += num;
        return;
    }

    public void CoinCost(int num)
    {
        if (num < 0)
        {
            return;
        }
        this.coin -= num;
        return;
    }
}

