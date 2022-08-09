using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovesDeckManager : MonoBehaviour,IDataPersistence
{
    public List<Moves> playerDeck;
    public Transform playerHandArea;
    public GameObject movesCardPrefab;
    //discard
    public List<Moves> discardDeck;
    //rotate
    public OrderHandCard orderHandCard;

    public void CreateMovesCard(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject moveCard = GameObject.Instantiate(movesCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            moveCard.transform.SetParent(playerHandArea, false);

            moveCard.gameObject.GetComponent<MovesCardDisplay>().move = playerDeck[i];
            
        }
        
        playerDeck.RemoveRange(0, num);
        orderHandCard.UpdateHandCard();
        
    }

    
    public void ShuffleMoves()
    {
        System.Random random = new System.Random();
        for (int i = 0; i < playerDeck.Count; i++)
        {
            int j = random.Next(i, playerDeck.Count);
            Moves temp = playerDeck[i];
            playerDeck[i] = playerDeck[j];
            playerDeck[j] = playerDeck[i];
        }
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
    }
    public void LoadData(GameData data)
    {
        this.playerDeck = data.playerMovesDeck;
    }

    public void SaveData(ref GameData data)
    {
        
    }



}
