using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesCardStore : MonoBehaviour
{
    public TextAsset BaseMoves;
    public List<Moves> MovesList = new List<Moves>();
    public Weapon weapon { get; set; }


    public void LoadBaseMoves()
    {
        string[] dataRow = BaseMoves.text.Split('\n');

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


                Moves move = new Moves(id,name,discription,cost,weapon);
                MovesList.Add(move);
            }
            

           
        }

    }


    /*
    public void TestLoad() //測試用
    {
        foreach (var item in MovesList)
        {
            Debug.Log("卡牌" + item.id.ToString() + item.name);
        }

    }
    
    public Card RandomCard()
    {
        Card card = MovesList[Random.Range(0, MovesList.Count)];
        return card;
    }
    */
}
