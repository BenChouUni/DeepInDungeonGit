using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovesDataStore : MonoBehaviour
{
    public List<Moves> allMovesList;
    


    public MovesDataStore(TextAsset csvdata)
    {

        this.allMovesList = LoadCsvData(csvdata);
    }

    public Moves FindMovesByIndex(int index)
    {
        foreach (Moves move in allMovesList)
        {
            if (move.id == index)
            {
                return move;
            }

        }
        Debug.LogError("move牌池中找不到對應卡牌");
        return null;
    }

    private List<Moves> LoadCsvData(TextAsset allMovesData)
    {
        string[] dataRow = allMovesData.text.Split('\n');
        List<Moves> MovesList = new List<Moves>();

        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0].Trim() == "id")//跳過開頭是＃
            {
                continue;
            }

            int id = int.Parse(rowArray[0]);
            string name = rowArray[1];
            int cost = int.Parse(rowArray[2]);
            string discription = rowArray[3];
            bool aim = false;
            if (rowArray[4].Trim() == "1")
            {
                aim = true;
            }


            Moves move = new Moves(id, name, discription, cost,aim);
            //創建為指定武器的
            MovesList.Add(move);

        }

        return MovesList;
    }
}
