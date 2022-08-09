using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderHandCard : MonoBehaviour
{
    

    public float totalRotateRate;
    public float moveDownRate;
    public float gapBetweenCard;
    
    public List<GameObject> handCardList = new List<GameObject>();



    private void GetAllCardsOnLayer()
    {
        List<GameObject> newList = new List<GameObject>();
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.GetComponent<MovesCardDisplay>()!=null)
            {
                newList.Add(child.gameObject);
            }
        }
        this.handCardList = newList;
    }

    public void UpdateHandCard()
    {
        GetAllCardsOnLayer();
        LayoutCards();
    }


    private void LayoutCards()
    {
        int totalHandCardNumber = handCardList.Count;
        if (totalHandCardNumber <= 1)
        {
            return;
        }
        else
        {
            float startTranslate = -(gapBetweenCard * (totalHandCardNumber - 1)/2);
            //正的是逆時針
            float startRotate = 1f * (totalRotateRate/2f);
            float rotatePerCard = -(totalRotateRate / (totalHandCardNumber + 1));
            for (int i = 0; i < totalHandCardNumber; i++)
            {
                //分隔牌
                float xTranslateForCard = startTranslate + i * gapBetweenCard;
                handCardList[i].transform.Translate(xTranslateForCard,0,0);
                //旋轉牌
                float twistForCard = startRotate + (i+1) * rotatePerCard;
                handCardList[i].transform.Rotate(0, 0, twistForCard);
                //卡牌旋轉後周邊的卡會降低一點
                float nudgeThisCard = Mathf.Abs(twistForCard);
                nudgeThisCard *= moveDownRate;
                handCardList[i].transform.Translate(0,-nudgeThisCard,0);
            }
        }

    }
    

}
