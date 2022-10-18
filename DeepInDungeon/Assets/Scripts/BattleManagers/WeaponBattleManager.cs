using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBattleManager : MonoSingleton<WeaponBattleManager>,IDataPersistence
{
    public GameObject weaponPrefab;
    public Transform mainWeaponZone;
    public Transform secWeaponZone;

    public PlayerWeapon playerWeapon;

    public void LoadData(GameData data)
    {
        this.playerWeapon = data.playerWeapon;
    }

    public void SaveData(ref GameData data)
    {
        //戰鬥中武器應該不會有更新
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowWeapon()
    {
        //先生成主武器
        GameObject mainWeapon = GameObject.Instantiate(weaponPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        mainWeapon.transform.SetParent(mainWeaponZone, false);
        mainWeapon.GetComponent<WeaponDisplay>().weapon = playerWeapon.mainWeapon;
        //判斷有副武器生成
        if (playerWeapon.secondaryWeapon.hand != Weapon.Hand.Empty)
        {
            GameObject secWeapon = GameObject.Instantiate(weaponPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            secWeapon.transform.SetParent(secWeaponZone, false);
            secWeapon.GetComponent<WeaponDisplay>().weapon = playerWeapon.secondaryWeapon;
        }
    }
    /// <summary>
    /// 因為move只存武器名字，所以需要透過此方法來找武器，未來可能會改move的東西
    /// </summary>
    /// <param name="weaponName"></param>
    /// <returns></returns>
    public Weapon FindWeaponByName(string weaponName)
    {
        if (playerWeapon.mainWeapon.name == weaponName)
        {
            return playerWeapon.mainWeapon;
        }
        else if (playerWeapon.secondaryWeapon.name == weaponName)
        {
            return playerWeapon.secondaryWeapon;
        }
        Debug.LogError("無法透過move名字找到對應武器");
        return null;
    }
}
