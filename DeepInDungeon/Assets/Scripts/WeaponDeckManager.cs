using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDeckManager : MonoBehaviour
{
    public TextAsset weaponData;
    public List<Weapon> WeaponList = new List<Weapon>();

    public Transform weaponDeck;
    public GameObject weaponPrefab;

    //武器擺放空間
    public WeaponDropZone mainWeaponZone;
    public WeaponDropZone secondaryWeaponZone;

    private void Awake()
    {
        initialWeaponZone();
        LoadWeaponData();
    }

    private void Start()
    {
    
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
                //Debug.Log(rowArray[6]+"有"+ rowArray[6].Length+"長度");
                string s = rowArray[6].Trim();



                Hand hand = CheckHandByString(s);

                
                Weapon weapon = new Weapon(id, name, atk, def, slot, describtion,hand);

                WeaponList.Add(weapon);


            }

            
        }
    }

    public static Hand CheckHandByString(string str)
    {

        
        switch (str)
        {
            case "main":
                //Debug.Log("主要");
                return Hand.Main;
                
            case "sec":
                //Debug.Log("副手");
                return Hand.Secondary;
                
            case "two":
                //Debug.Log("雙手");
                return Hand.TwoHanded;
                

            default:
                //Debug.Log("空");
                return Hand.Empty;
                
                
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

    public void initialWeaponZone()
    {
        mainWeaponZone.hand = Hand.Main;
        secondaryWeaponZone.hand = Hand.Secondary;
    }
 

}