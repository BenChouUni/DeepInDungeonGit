using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDeckManager : MonoBehaviour,IDataPersistence
{
    public TextAsset weaponData;
    public List<Weapon> WeaponList = new List<Weapon>();

    public Transform weaponPanel;
    public GameObject weaponPrefab;

    //玩家武器
    public PlayerWeapon playerWeapon;
    //行動管理器
    public MovesDeckManager mdManager;
    //武器擺放空間
    public GameObject mainWeaponZone;
    private Weapon mainWeapon;
    public Weapon MainWeapon
    {
        get { return mainWeapon; }
        set
        {
            this.mainWeapon = value;
            Debug.Log("主手武器是" + value.name);
            
            mdManager.CreateMovesDeckByWeapon(value);
        }
    }

    public GameObject secondaryWeaponZone;
    private Weapon secWeapon;
    public Weapon SecondaryWeapon
    {
        get { return secWeapon; }
        set
        {
            this.secWeapon = value;
            Debug.Log("副手武器是" + value.name);
            mdManager.CreateMovesDeckByWeapon(value);
        }
    }
    


    private void Awake()
    {
        initialWeaponZone();
        LoadWeaponData();
    }

    private void Start()
    {
        //先創建所有牌庫在轉移
        CreateAllWeaponDeck();
        CreatePlayWeapon();

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



                Weapon.Hand hand = Weapon.CheckHandByString(s);

                
                Weapon weapon = new Weapon(id, name, atk, def, slot, describtion,hand);

                WeaponList.Add(weapon);


            }

            
        }
    }



    public void CreateWeaponOnPanel(Weapon weapon)//同卡分不同張
    {
        
        GameObject newWeapon = GameObject.Instantiate(weaponPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        if (newWeapon.GetComponent<Draggable>()!=null)
        {
            newWeapon.GetComponent<Draggable>().StartParent = weaponPanel;
        }
        newWeapon.transform.SetParent(weaponPanel, false);

        newWeapon.GetComponent<WeaponDisplay>().weapon = weapon;

        
    }

    public void CreateAllWeaponDeck()
    {
        foreach (Weapon weapon in WeaponList)
        {
            CreateWeaponOnPanel(weapon);
        }
    }

    private void CreatePlayWeapon()
    {
        Weapon main = playerWeapon.mainWeapon;
        Weapon sec = playerWeapon.secondaryWeapon;

        if (main.hand != Weapon.Hand.Empty)
        {

            GameObject newMainWeapon = FindWeaponObjInPanel(main);
            newMainWeapon.transform.SetParent(mainWeaponZone.transform, false);

            this.MainWeapon = main;
        }

        if (sec.hand != Weapon.Hand.Empty)
        {
            GameObject newSecWeapon = FindWeaponObjInPanel(sec);
            newSecWeapon.transform.SetParent(secondaryWeaponZone.transform, false);

            this.SecondaryWeapon = sec;
        }
        
    }

    private GameObject FindWeaponObjInPanel(Weapon weapon)
    {
        Debug.Log("嘗試在panel尋找"+weapon.name);
        foreach (Transform child in weaponPanel)
        {
            Weapon childWeapon = child.gameObject.GetComponent<WeaponDisplay>().weapon;
            Debug.Log(childWeapon.name);
            if (childWeapon.name == weapon.name)
            {
                Debug.Log("在武器庫找到" + childWeapon.name);
                return child.gameObject;
            }
       
        }
        Debug.LogError("在武器庫找不到所要武器");
        return null;
    }
    

    public void initialWeaponZone()
    {
        mainWeaponZone.GetComponent<WeaponDropZone>().hand = Weapon.Hand.Main;
        secondaryWeaponZone.GetComponent<WeaponDropZone>().hand = Weapon.Hand.Secondary;
    }
 /// <summary>
 /// 輸入武器告訴movesmanager把該武器的牌刪掉
 /// </summary>
 /// <param name="weapon"></param>
    public void TellMDMDestroyMoves(Weapon weapon)
    {
        mdManager.DestroyMovesByWeapon(weapon);
    }

    public void LoadData(GameData data)
    {
        this.playerWeapon = data.playerWeapon;
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log("將"+mainWeapon.name+"存入");
        this.playerWeapon = new PlayerWeapon(mainWeapon, secWeapon);
        data.playerWeapon = this.playerWeapon;
        data.mainWeaponName = mainWeapon.name;
        
    }
}