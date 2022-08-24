using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovesDeckManager : MonoBehaviour,IDataPersistence
{
    
    public GameObject movesCardPrefab;

    
    public List<Moves> playerMoveList = new List<Moves>();
    

    public Transform MovesDeckPanel;

    public TextAsset AllMovesData;
    private MovesDataStore movesDataStore;

    //武器對應move表
    public TextAsset MovesByWeapon;
    

    private void Awake()
    {
        movesDataStore = new MovesDataStore(AllMovesData);
    }

    //List<GameObject> childGo = new List<GameObject>();
    public void CreateMovesDeckByWeapon(Weapon weapon)
    {
        List<Moves> moves = GetMovesListByWeapon(weapon);
        
        for (int i = 0; i < moves.Count; i++)
        {
            //Debug.Log("創建"+ moves[i].name);
            CreateMoveCard(moves[i]);
            playerMoveList.Add(moves[i]);
        }

    }


    public void CreateMoveCard(Moves _moves)//同卡分不同張
    {

        GameObject newMoves = GameObject.Instantiate(movesCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newMoves.transform.SetParent(MovesDeckPanel, false);

        newMoves.GetComponent<MovesCardDisplay>().move = _moves;
        

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
                    playerMoveList.Remove(move);
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
        if (this.playerMoveList.Count == 0)
        {
            Debug.LogError("沒有牌組");
        }
        else
        {
           
            data.playerMovesDeck = this.playerMoveList;
        }
        
    }


    private List<int> GetMovesIndexList(Weapon weapon)
    {
        List<int> MovesIndexList = new List<int>();
        int weaponIndex = weapon.id;
        string[] dataRow = MovesByWeapon.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            
            if (rowArray[0].Trim()== "weaponID")
            {
                continue;
            }
            if (int.Parse(rowArray[0].Trim()) != weaponIndex)//跳過不一樣標號的
            {
                continue;
            }
            else
            {//從第二個開始全取
                Debug.Log("weaponid"+weaponIndex.ToString());
                Debug.Log("row" + rowArray[0]);
                Debug.Log("id" + rowArray[1]);
                //最後一格會是空的不要
                for (int i = 1; i < rowArray.Length; i++)
                {
                    if (rowArray[i].Trim()=="")
                    {
                        continue;
                    }
                    Debug.Log(rowArray[i]);
                    int index = int.Parse(rowArray[i].Trim());
                    MovesIndexList.Add(index);
                }
            }

        }
        return MovesIndexList;
    }

    public List<Moves> GetMovesListByWeapon(Weapon weapon)
    {
        List<int> MovesIndexList = GetMovesIndexList(weapon);
        List<Moves> list = new List<Moves>();
        for (int i = 0; i < MovesIndexList.Count; i++)
        {
            Moves move = movesDataStore.FindMovesByIndex(MovesIndexList[i]);
            //避免引用重複
            Moves newMove = new Moves(move.id, move.name, move.cardDescription, move.cost, move.aim, weapon.name);
            //move.weaponName = weapon.name;//在此加入武器名
            list.Add(newMove);
        }

        return list;
    }
}
