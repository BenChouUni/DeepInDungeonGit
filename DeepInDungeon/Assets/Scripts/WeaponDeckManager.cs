using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDeckManager : MonoBehaviour
{
    public TextAsset weaponData;
    public List<Weapon> WeaponList = new List<Weapon>();

    public Transform weaponDeck;
    public GameObject weaponPrefab;

    private void Awake()
    {
        LoadWeaponData();
    }
    private void Start()
    {
        Debug.Log(WeaponList.Count);
        CreateAllWeaponDeck();
        
    }
    //讀取資料
    public void LoadWeaponData()
    {
        string[] dataRow = weaponData.text.Split('\n');

        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] =="id")
            {
                continue;
            }
            else
            {
                int id = int.Parse(rowArray[0]);
                string name = rowArray[1];
                int atk = int.Parse(rowArray[2]);
                int def = int.Parse(rowArray[3]);
                int slot = int.Parse(rowArray[4]);
                string describtion = rowArray[5];


                Weapon weapon = new Weapon(id, name, atk, def, slot, describtion);

                WeaponList.Add(weapon);


            }

            
        }
    }

    public void CreateWeapon(int _id)//同卡分不同張
    {
        
        GameObject newWeapon = GameObject.Instantiate(weaponPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newWeapon.transform.SetParent(weaponDeck, false);
       
        newWeapon.GetComponent<WeaponDisplay>().weapon = WeaponList[_id];

        
    }

    public void CreateAllWeaponDeck()
    {
        for (int i = 0; i < WeaponList.Count; i++)
        {
            CreateWeapon(i);
        }
    }

}