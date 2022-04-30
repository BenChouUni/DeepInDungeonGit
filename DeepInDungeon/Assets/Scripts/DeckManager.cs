using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public GameObject DataManager;

    private PlayerDeckStore playerDeckStore;
    private CardStore cardStore;

    public Transform deckPanel;
    public GameObject CardPrefab;

    //private Dictionary<int, GameObject> deckDic = new Dictionary<int, GameObject>();
    void Start()
    {
        playerDeckStore = DataManager.GetComponent<PlayerDeckStore>();
        cardStore = DataManager.GetComponent<CardStore>();

        UpdateDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateDeckCard(int _index)//同卡分不同張
    {

        GameObject newCard = GameObject.Instantiate(CardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newCard.transform.SetParent(deckPanel, false);
        int id = playerDeckStore.PlayerDeckCards[_index];
        //newCard.GetComponent<CardCounter>().SetCounter(refData[_id]);
        newCard.GetComponent<CardDisplay>().card = cardStore.CardList[id];

        //deckDic.Add(id, newCard);
    }

    public void UpdateDeck()
    {
        for (int i = 0; i < playerDeckStore.PlayerDeckCards.Count; i++)
        {
            CreateDeckCard(i);

        }
    }
}
