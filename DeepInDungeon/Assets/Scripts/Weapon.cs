using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public int ID;
    public string weaponName;
    public int atk;
    public int def;

    public Weapon()
    {
        weaponName = "";
    }
}

[CreateAssetMenu(fileName ="New Weapon",menuName = "Create SO/Create Weapon")]
public class WeaponSo : ScriptableObject
{
    Weapon weaponData;

}
