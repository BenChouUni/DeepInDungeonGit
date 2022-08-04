using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDeckStore : MonoBehaviour
{
    public MovesDeckManager MDManager;
    public WeaponDeckManager WDManager;

    public Weapon mainWeapon { get; set; }
    public Weapon secWeapon { get; set; }
    public List<Moves> movesDeck = new List<Moves>();

    public TextAsset WeaponDeckText;
    public TextAsset MovesDeckText;
  
   
    public void DataLoad()
    {
        //CardStore.LoadMovesData();//先將卡牌資料庫存到CardList才能調用LoadPLayerData
        //CardStore.TestLoad();
        //LoadPlayerDeck();
        
    }

    public void SetPlayerWeapon()
    {
        mainWeapon = WDManager.MainWeapon;
        secWeapon = WDManager.SecondaryWeapon;
        SavePlayerWeapon();
    }

    public void SetMovesDeck()
    {
        movesDeck = MDManager.moveList;
        SaveMovesDeck();
    }

    public void LoadPlayerWeapon()
    {
        string[] dataRow = WeaponDeckText.text.Split('\n');

        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "id")
            {
                continue;
            }
            else
            {
                int id = int.Parse(rowArray[0]);
                string name = rowArray[2];
                int atk = int.Parse(rowArray[3]);
                int def = int.Parse(rowArray[4]);
                int slot = int.Parse(rowArray[5]);
                string describtion = rowArray[6];
                Weapon.Hand hand = Weapon.CheckHandByString(rowArray[1]);
                if (hand == Weapon.Hand.Main|| hand == Weapon.Hand.TwoHanded)
                {
                    mainWeapon = new Weapon(id, name, atk, def, slot, describtion, hand);
                }
                else if (hand == Weapon.Hand.Secondary)
                {
                    secWeapon = new Weapon(id, name, atk, def, slot, describtion, hand);
                }
                else
                {
                    Debug.Log("讀取武器出錯，不是正常型別");
                }

            }


        }
    }



    public void LoadMovesDeck()
    {
        string[] dataRow = MovesDeckText.text.Split('\n');

        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0].Trim() == "weapon")//跳過開頭是＃
            {
                continue;
            }

            if (rowArray[0].Trim() == "all")
            {
                int id = int.Parse(rowArray[1]);
                string name = rowArray[2];
                int cost = int.Parse(rowArray[3]);
                string discription = rowArray[4];
                string weaponName = rowArray[0];

                Moves move = new Moves(id, name, discription, cost, weaponName);
                movesDeck.Clear();
                movesDeck.Add(move);
            }

        }

    }



   
    public void SavePlayerWeapon()
    {
        string path = Application.dataPath + "/Data/PlayerWeapon.csv"; //路徑名稱，務必確認
        Debug.Log("進行玩家資料儲存");

        List<string> datas = new List<string>();
        
        datas.Add("id,hand,name,atk ,def,slotNumber,description,slot1,slot2,slot3");

   
        //儲存主武器
        if (mainWeapon != null)
        {
            datas.Add("0,main,"+mainWeapon.name + "," + mainWeapon.Attack.ToString() + "," + mainWeapon.Defense.ToString() + "," + mainWeapon.slotNumber + "," + mainWeapon.cardDescription);
        }

        if (secWeapon != null)
        {
            datas.Add("1,sec," + mainWeapon.name + "," + mainWeapon.Attack.ToString() + "," + mainWeapon.Defense.ToString() + "," + mainWeapon.slotNumber + "," + mainWeapon.cardDescription);
        }

        File.WriteAllLines(path, datas);
        
        
    }

    public void SaveMovesDeck()
    {
        string path = Application.dataPath + "/Data/PlayerDeck.csv"; //路徑名稱，務必確認
        Debug.Log("進行玩家資料儲存");

        List<string> datas = new List<string>();

        datas.Add("weapon,ID,Name,Cost,Description,Attack,Defend");

        for (int i = 0; i < movesDeck.Count; i++)
        {
            Moves move = movesDeck[i];

            datas.Add(move.weaponName + "," + i.ToString() + "," + move.name + "," + move.cost.ToString() + "," + move.cardDescription + "," + "0,0");
        }

        File.WriteAllLines(path, datas);
    }
}
