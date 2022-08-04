using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerWeapon
{
    public Weapon mainWeapon;
    public Weapon secondaryWeapon;

    public PlayerWeapon(Weapon _mainWeapon,Weapon _secWeapon)
    {
        this.mainWeapon = _mainWeapon;
        this.secondaryWeapon = _secWeapon;
    }


}
