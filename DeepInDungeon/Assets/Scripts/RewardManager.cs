using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public Transform cardsArea;
    public GameObject rewardCardPrefab;

    public GameObject DataManager;
    private PlayerDeckStore playerDeckStore;
    private MovesCardLoadByWeapon cardStore;

    /*

    // Start is called before the first frame update
    void Start()
    {
        playerDeckStore = DataManager.GetComponent<PlayerDeckStore>();
        cardStore = DataManager.GetComponent<MovesCardLoadByWeapon>();
        

        DrawThreeRandomCards();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearRewardCards()
    {
        int childCount = cardsArea.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(cardsArea.GetChild(i).gameObject);
        }
    }

    public int[] RandomNonUpgradedID(int _number)//要幾個ID
    {
        int count = cardStore.MovesList.Count/2;//總清單有多少種牌，沒升級的牌只有一半
        int[] sequence = new int[cardStore.MovesList.Count];
        int[] output = new int[_number];
        for (int i = 0; i < cardStore.MovesList.Count; i++)
        {
            sequence[i] = i;
        }
        int end = count - 1;
        for (int i = 0; i < _number; i++)
        {
            //随机一个数，每随机一次，随机区间-1
            int num = Random.Range(0, end + 1);
            
            output[i] = 2*sequence[num];//將所有號碼變成偶數就是沒升級的牌
            //将区间最后一个数赋值到取到数上
            sequence[num] = sequence[end];
            end--;
            //执行一次效果如：1，2，3，4，5 取到2
            //则下次随机区间变为1,5,3,4;
        }
        return output;

    }

    public void CreateRewardCards(int[] _ids)//輸入一個id矩陣
    {
        for (int i = 0; i < _ids.Length; i++)
        {
            GameObject newCard = GameObject.Instantiate(rewardCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            newCard.transform.SetParent(cardsArea, false);
            int id = _ids[i];
            
            newCard.GetComponent<CardDisplay>().card = cardStore.MovesList[id];
        }
        

   
    }
    
    public void DrawThreeRandomCards()
    {
        ClearRewardCards();
        int[] ids = RandomNonUpgradedID(3);
        CreateRewardCards(ids);
    }
    */
}
