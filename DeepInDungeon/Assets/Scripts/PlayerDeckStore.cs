using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDeckStore : MonoBehaviour
{
    public CardStore CardStore;

    
     //PlayerCards[i]代表索引值i有多少張牌
    public List<int> PlayerDeckCards = new List<int>();//用list才能改變串列長度

    public TextAsset playerDeck;
    //之後可能會有不同的玩家資料

    void Awake()
    {
        DataLoad();
    }

    // Update is called once per frame
    public void DataLoad()
    {
        CardStore.LoadCardData();//先將卡牌資料庫存到CardList才能調用LoadPLayerData
        CardStore.TestLoad();
        LoadPlayerDeck();
        
    }

    public void LoadPlayerDeck()
    {

        //PlayerDeckCards = new int[];
        

        string[] dataRow = playerDeck.text.Split('\n');//用換行來確定第幾列

        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');//用逗點確定一行中第幾個
            if (rowArray[0] == "#")//跳過開頭是＃
            {
                continue;
            }

            else if (rowArray[0] == "deck")//載入卡組
            {
                int index = int.Parse(rowArray[1]);
                int ID = int.Parse(rowArray[2]);

                //PlayerDeckCards[index] = ID;
                PlayerDeckCards.Add(ID);
            }
            else
            {
                return;
            }
        }
    }

    public void SavePlayerDeck()
    {
        string path = Application.dataPath + "/Data/PlayerDeck.csv"; //路徑名稱，務必確認


        List<string> datas = new List<string>();
        
        datas.Add("#,index,ID");

       

        //保存玩家卡組
        for (int i = 0; i < PlayerDeckCards.Count; i++)
        {
            if (PlayerDeckCards[i] != 0)
            {
                datas.Add("deck," + i.ToString() + "," + PlayerDeckCards[i].ToString());
            }

        }
        File.WriteAllLines(path, datas);
    }
}
