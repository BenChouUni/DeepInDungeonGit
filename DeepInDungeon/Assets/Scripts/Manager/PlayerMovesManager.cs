using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovesManager : MonoBehaviour, IDataPersistence
{
    public GameObject movesCardPrefab;


    public List<Moves> moveList = new List<Moves>();


    public Transform MovesDeckPanel;

    private void Start()
    {
        CreateAllMovesCard();
    }

    public void LoadData(GameData data)
    {
        this.moveList = data.playerMovesDeck;
        Debug.Log("讀取玩家moves：有"+moveList.Count.ToString());
    }


    public void SaveData(ref GameData data)
    {
        //不能被編輯
    }

    public void CreateAllMovesCard()
    {
        foreach (Moves move in moveList)
        {
            Debug.Log("生成"+move.name);
            GameObject newMoves = GameObject.Instantiate(movesCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            newMoves.transform.SetParent(MovesDeckPanel, false);

            newMoves.GetComponent<MovesCardDisplay>().move = move;

        }

    }
}
