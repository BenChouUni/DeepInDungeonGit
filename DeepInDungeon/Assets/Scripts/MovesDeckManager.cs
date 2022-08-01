using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesDeckManager : MonoBehaviour
{
    public MovesCardStore movesCardStore;
    public GameObject movesCardPrefab;

    
    private List<Moves> moveList = new List<Moves>();
    

    public Transform DeckPanel;


    public void ReplaceNewMoveCards(Weapon weapon)
    {
        moveList.RemoveRange(0, moveList.Count);//全刪光
        moveList = SetMoveList(weapon);
        for (int i = 0; i < moveList.Count; i++)
        {
            CreateMoveCard(moveList[i]);
        }

    }

    public List<Moves> SetMoveList(Weapon weapon)
    {
        movesCardStore.weapon = weapon;
        movesCardStore.LoadBaseMoves();
        return movesCardStore.MovesList;

    }

    public void CreateMoveCard(Moves _moves)//同卡分不同張
    {

        GameObject newMoves = GameObject.Instantiate(movesCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newMoves.transform.SetParent(DeckPanel, false);

        newMoves.GetComponent<MovesCardDisplay>().move = _moves;


    }


}
