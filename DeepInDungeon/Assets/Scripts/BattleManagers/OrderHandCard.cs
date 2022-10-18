using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderHandCard : MonoSingleton<OrderHandCard>
{
    

    public float totalRotateRate;
    public float moveDownDistancePerCard;
    public float distanceBetweenCard = 100;
    
    public List<GameObject> handCardList = new List<GameObject>();



    public void GetAllCardsOnLayer()
    {
        handCardList.Clear();
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
        if (totalHandCardNumber == 0)
        {
            return;
        }
        else
        {/*
            float startTranslate = -(distanceBetweenCard * (totalHandCardNumber - 1) / 2);
            /*
            //正的是逆時針
            float startRotate = 1f * (totalRotateRate / 2f);
            float rotatePerCard = -(totalRotateRate / (totalHandCardNumber + 1));
            */
            for (int i = 0; i < totalHandCardNumber; i++)
            {
                RotateLayout(handCardList[i].transform, totalHandCardNumber, i);
                HorizontalLayout(handCardList[i].transform, totalHandCardNumber, i);
                /*
                //分隔牌
                float xTranslateForCard = startTranslate + i * distanceBetweenCard;
                handCardList[i].transform.Translate(xTranslateForCard, 0, 0);
                //旋轉牌
                float twistForCard = startRotate + (i + 1) * rotatePerCard;
                handCardList[i].transform.Rotate(0, 0, twistForCard);
                //卡牌旋轉後周邊的卡會降低一點
                float nudgeThisCard = Mathf.Abs(twistForCard);
                nudgeThisCard *= moveDownDistancePerCard;
                handCardList[i].transform.Translate(0, -nudgeThisCard, 0);
                */
            }
        }

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="transform">每張牌的trandform</param>
    /// <param name="num">總共多少牌</param>
    /// <param name="index">第幾張牌</param>
    private void HorizontalLayout(Transform transform,int num,int index)
    {
        float startX = -(distanceBetweenCard * (num - 1) / 2);
        float xTranslateForCard = startX + index * distanceBetweenCard;
        float yTranslateForCard = 0;
        if (num % 2 == 1)
        {
            yTranslateForCard = Mathf.Abs(index - (num / 2));
            yTranslateForCard *= -moveDownDistancePerCard;


        }
        else
        {
            int maxIndex = num / 2;
            int minIndex = num / 2 - 1;
            if (index <= minIndex)
            {
                yTranslateForCard = (minIndex - index + 1) * -moveDownDistancePerCard;
            }
            else if (index >= maxIndex)
            {
                yTranslateForCard = (index - maxIndex + 1) * -moveDownDistancePerCard;
            }

        }

        transform.localPosition = new Vector3(xTranslateForCard, yTranslateForCard, 0);

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="transform">每張牌的trandform</param>
    /// <param name="num">總共多少牌</param>
    /// <param name="index">第幾張牌</param>
    private void RotateLayout(Transform transform, int num, int index)
    {
        float startRotate = 1f * (totalRotateRate / 2f);
        float rotatePerCard = -(totalRotateRate / (num + 1));
        float twistForCard = startRotate + (index + 1) * rotatePerCard;

        transform.eulerAngles = new Vector3(0,0, twistForCard);
    }

}
