using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerWeapon
{
    public Weapon mainWeapon;
    public Weapon secondaryWeapon;

    /// <summary>
    /// 這樣初始化是空武器
    /// </summary>
    public PlayerWeapon()
    {
        this.mainWeapon = null;
        this.secondaryWeapon = null;
    }

    public PlayerWeapon(Weapon _mainWeapon, Weapon _secWeapon)
    {
        this.mainWeapon = _mainWeapon;
        this.secondaryWeapon = _secWeapon;
    }
}
