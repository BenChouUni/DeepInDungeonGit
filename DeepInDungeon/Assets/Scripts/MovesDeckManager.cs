using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovesDeckManager : MonoBehaviour,IDataPersistence
{
    public MovesCardLoadByWeapon loadmoves;
    public GameObject movesCardPrefab;

    
    public List<Moves> moveList = new List<Moves>();
    

    public Transform MovesDeckPanel;

    //List<GameObject> childGo = new List<GameObject>();
    public void CreateMovesDeckByWeapon(Weapon weapon)
    {
        List<Moves> moves = loadmoves.LoadMoves(weapon);
        
        for (int i = 0; i < moves.Count; i++)
        {
            Debug.Log("創建"+ moves[i].name);
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

        for (int i = 0; i < childs.Count; i++)
        {
            Moves move = childs[i].GetComponent<MovesCardDisplay>().move;
            if (move.weaponName == weapon.name)
            {
                moveList.Remove(move);
                Destroy(childs[i]);
            }
        }
    }

    public void LoadData(GameData data)
    {
        this.moveList = data.playerMovesDeck;
    }

    public void SaveData(ref GameData data)
    {
        if (this.moveList[0] == null)
        {
            Debug.LogError("沒有牌組");
        }
        else
        {
           
            data.playerMovesDeck = this.moveList;
        }
        
    }
}
