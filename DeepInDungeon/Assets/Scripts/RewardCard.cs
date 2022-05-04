using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RewardCard : MonoBehaviour, IPointerDownHandler
{
    private GameObject DataManager;
    private PlayerDeckStore playerDeckStore;

    private GameObject RewardsManager;
    private RewardManager rewardManager;
    // Start is called before the first frame update
    void Start()
    {
        DataManager = GameObject.Find("DataManager");
        RewardsManager = GameObject.Find("RewardsManager");

        playerDeckStore = DataManager.GetComponent<PlayerDeckStore>();
        rewardManager = RewardsManager.GetComponent<RewardManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        int id = this.GetComponent<CardDisplay>().card.id;
        playerDeckStore.PlayerDeckCards.Add(id);

        playerDeckStore.SavePlayerDeck();
        rewardManager.ClearRewardCards();

    }
}