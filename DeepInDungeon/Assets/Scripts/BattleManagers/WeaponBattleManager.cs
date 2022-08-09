using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBattleManager : MonoBehaviour,IDataPersistence
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
        ShowWeapon();
    }

    private void ShowWeapon()
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
}
