using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleCardManager : MonoSingleton<BattleCardManager>,IDataPersistence
{
    public List<Moves> playerDeck;
    public Transform playerHandArea;
    public GameObject movesCardPrefab;
    //discard
    public List<Moves> discardDeck;
    //rotate
    public OrderHandCard orderHandCard;
    //抽排棄牌堆
    public Text deckNum;
    public Text discardNum;

    private void Start()
    {
        deckNum.text = playerDeck.Count.ToString();
        discardNum.text = "0";

    }

    public void DrawCards(int num)
    {

        for (int i = 0; i < num; i++)
        {
            DrawACard();
        }

        orderHandCard.UpdateHandCard();
        deckNum.text = playerDeck.Count.ToString();
    }

    private void DrawACard()
    {
        if (playerDeck.Count == 0)
        {
            if (discardDeck.Count != 0)
            {
                ReDeck();
            }
            else
            {
                return;
            }
        }
        GameObject moveCard = GameObject.Instantiate(movesCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        moveCard.transform.SetParent(playerHandArea, false);

        moveCard.gameObject.GetComponent<MovesCardDisplay>().move = playerDeck[0];
        playerDeck.RemoveAt(0);
        
    }

    public void ShuffleMoves()
    {
        System.Random random = new System.Random();
        for (int i = 0; i < playerDeck.Count; i++)
        {
            int j = random.Next(i, playerDeck.Count);
            Moves temp = playerDeck[i];
            playerDeck[i] = playerDeck[j];
            playerDeck[j] = temp;
        }
    }

    private void ReDeck()
    {
        foreach (Moves move in discardDeck)
        {
            playerDeck.Add(move);
        }
        discardDeck.Clear();

        deckNum.text = playerDeck.Count.ToString();
        discardNum.text = discardDeck.Count.ToString();
        ShuffleMoves();
    }



    public void DiscardAllMovesInHand()
    {
        foreach (Transform child in playerHandArea)
        {
            if (child.gameObject.GetComponent<MovesCardDisplay>()!=null)
            {
                discardDeck.Add(child.gameObject.GetComponent<MovesCardDisplay>().move);
                Destroy(child.gameObject);

            }
        }
        
        discardNum.text = discardDeck.Count.ToString();
        //orderHandCard.UpdateHandCard();
    }
    public void LoadData(GameData data)
    {
        this.playerDeck = data.playerMovesDeck;
    }

    public void SaveData(ref GameData data)
    {
        
    }



}
