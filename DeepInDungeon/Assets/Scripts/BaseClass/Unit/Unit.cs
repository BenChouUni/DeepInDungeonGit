using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 玩家以及敵人部位等主要互動單位
/// </summary>
[Serializable]
public abstract class Unit
{
    [SerializeField]
    private string unitName;
    public string Name { get { return unitName; } }//名字不該隨便變動
    [SerializeField]
    private HpStatus hpStatus;
    public HpStatus HpStatus { get { return hpStatus; } }
    [SerializeField]
    private int shield;
    public int Shield { get { return shield; } }

    [SerializeField]
    private List<State> unitStates;

    //是否死亡
    
    private bool isDeath;
    public bool IsDeath { get { return isDeath; } }

    public Unit(string _name, int _maxHealth,int _shield)
    {
        unitName = _name;
        hpStatus = new HpStatus(_maxHealth);
        shield = _shield;
        isDeath = false;
    }

    //如果要初始化狀態
    public Unit(string _name, int _maxHealth, int _shield,List<State> _states)
    {
        unitName = _name;
        hpStatus = new HpStatus(_maxHealth);
        shield = _shield;
        unitStates = _states;
        isDeath = false;
    }

    //函數 除了名字不該改其他都要提供可更動函數

    /// <summary>
    /// 不應該傳入負數 成功造成傷害回傳真 若被阻擋則假
    /// </summary>
    /// <param name="dmg"> 傷害值 </param>
    /// <returns></returns>
    public virtual bool GetDamage(int dmg)
    {
        if (dmg <= 0)
        {
            Debug.Log("傷害傳入小於零");
            return false;
        }
        int healthDmg = dmg;
        if (this.Shield != 0)
        {
            healthDmg -= this.Shield;
            ShiedMinus(dmg);
            //被阻擋
            if (healthDmg <= 0)
            {
                return false;
            }
        }

        this.HpStatus.hp -= healthDmg;

        //如果hp扣到零以下 則改為零
        if (this.HpStatus.hp <= 0)
        {
            isDeath = true;
            this.hpStatus.hp = 0;
        }
        return true;
    }
    /// <summary>
    /// 回血，不能傳入負數
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public bool RestoreHealth(int num)
    {
        if (num <= 0)
        {
            //GetDamage(-num);
            return false;
        }
        hpStatus.hp += num;
        return true;
    }
    //護盾的調整
    public bool ShieldAdd(int num)
    {
        if (num <= 0)
        {
            return false;
        }

        shield += num;
        return true;
    }
    public bool ShiedMinus(int num)
    {
        if (num <= 0)
        {
            return false;
        }
        shield -= num;
        if (shield<=0)
        {
            shield = 0;
        }
        return true;
    }
    //狀態欄
    public List<State> StatesListGet()
    {
        return unitStates;
    }
    public bool StateAdd(State state)
    {
        unitStates.Add(state);
        return true;
    }
    public bool StateDelete(State state)
    {
        if (unitStates.Count == 0)
        {
            return false;
        }
        unitStates.Remove(state);
        return true;
    }


    /// <summary>
    /// 初始化顯示Unit基礎元件
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="nameText"></param>
    /// <param name="healthBar"></param>
    /// <param name="shieldText"></param>
    public static void ShowUnit(Unit unit, Text nameText, HealthBar healthBar, Text shieldText)
    {
        nameText.text = unit.Name;
        healthBar.ShowHealthBar(unit.HpStatus);
        if (shieldText == null)
        {
            return;
        }
        shieldText.text = unit.Shield.ToString();

    }

    public static void UpdateUnitStatus(Unit unit, HealthBar healthBar, Text shieldText)
    {
        healthBar.ShowHealthBar(unit.HpStatus);
        if (shieldText == null)
        {
            return;
        }
        shieldText.text = unit.Shield.ToString();
    }


}
