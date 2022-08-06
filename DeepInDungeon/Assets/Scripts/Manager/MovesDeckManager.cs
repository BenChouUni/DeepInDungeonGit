using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovesDeckManager : MonoBehaviour,IDataPersistence
{
    
    public GameObject movesCardPrefab;

    
    public List<Moves> moveList = new List<Moves>();
    

    public Transform MovesDeckPanel;

    public TextAsset MovesCardDeck;



    //List<GameObject> childGo = new List<GameObject>();
    public void CreateMovesDeckByWeapon(Weapon weapon)
    {
        List<Moves> moves = LoadMoves(weapon);
        
        for (int i = 0; i < moves.Count; i++)
        {
            //Debug.Log("創建"+ moves[i].name);
            CreateMoveCard(moves[i]);
        }

    }


    public void CreateMoveCard(Moves _moves)//同卡分不同張
    {

        GameObject newMoves = GameObject.Instantiate(movesCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newMoves.transform.SetParent(MovesDeckPanel, false);

        newMoves.GetComponent<MovesCardDisplay>().move = _moves;
        moveList.Add(_moves);

    }

    private List<GameObject> FindAllChildOnPanel()
    {
        List<GameObject> childGo = new List<GameObject>();

        for (int i = 0; i < MovesDeckPanel.childCount; i++)
        {
            childGo.Add(MovesDeckPanel.GetChild(i).gameObject);
        }

        return childGo;


    }


    /// <summary>
    /// 摧毀牌組中有隸屬某武器的行動卡
    /// </summary>
    /// <param name="weapon"></param>
    public void DestroyMovesByWeapon(Weapon weapon)
    {
        List<GameObject> childs = FindAllChildOnPanel();

        foreach (GameObject child in childs)
        {
            if (child.gameObject.GetComponent<MovesCardDisplay>() != null)
            {
                Moves move = child.gameObject.GetComponent<MovesCardDisplay>().move;
                if (move.weaponName == weapon.name)
                {
                    moveList.Remove(move);
                    Destroy(child);
                }
            }
        }
    }

    public void LoadData(GameData data)
    {
        //this.moveList = data.playerMovesDeck;
        //因為武器已經決定了，之後生成自然會載入
    }

    public void SaveData(ref GameData data)
    {
        if (this.moveList.Count == 0)
        {
            Debug.LogError("沒有牌組");
        }
        else
        {
           
            data.playerMovesDeck = this.moveList;
        }
        
    }

    public List<Moves> LoadMoves(Weapon weapon)
    {
        string[] dataRow = MovesCardDeck.text.Split('\n');
        List<Moves> MovesList = new List<Moves>();

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


                Moves move = new Moves(id, name, discription, cost, weapon.name);
                MovesList.Add(move);
            }

        }

        return MovesList;

    }
}
