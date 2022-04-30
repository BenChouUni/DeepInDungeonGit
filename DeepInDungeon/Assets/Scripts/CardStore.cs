using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStore : MonoBehaviour
{
    public TextAsset cardData;
    public List<Card> CardList = new List<Card>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadCardData()
    {
        string[] dataRow = cardData.text.Split('\n');

        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")//跳過開頭是＃
            {
                continue;
            }
            else if (rowArray[0] == "attack")//新建攻擊
            {
                int id = int.Parse(rowArray[1]);
                string name = rowArray[2];
                int cost = int.Parse(rowArray[3]);
                string discription = rowArray[4];
                int attack = int.Parse(rowArray[5]);

                AttackCard attackCard = new AttackCard(id,name,discription,cost,attack);
;               

                CardList.Add(attackCard);


            }
            else if (rowArray[0] == "defend")//新建防禦
            {
                int id = int.Parse(rowArray[1]);
                string name = rowArray[2];
                int cost = int.Parse(rowArray[3]);
                string discription = rowArray[4];
                int defend = int.Parse(rowArray[6]);

                DefendCard defendCard = new DefendCard(id, name, discription, cost, defend);
                CardList.Add(defendCard);

                
            }
            else
            {
                return;//沒有就結束了
            }
        }

    }

    public void TestLoad() //測試用
    {
        foreach (var item in CardList)
        {
            Debug.Log("卡牌" + item.id.ToString() + item.cardName);
        }

    }

    public Card RandomCard()
    {
        Card card = CardList[Random.Range(0, CardList.Count)];
        return card;
    }
}
