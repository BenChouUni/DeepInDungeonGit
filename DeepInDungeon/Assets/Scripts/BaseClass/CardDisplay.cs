using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Text nameText;
    
    public Text discriptiontText;

    public Image Image;

    public CardData card;


    public void ShowCard()
    {


        nameText.text = this.card.cardName;
       
        if (discriptiontText.text!=null)
        {
            discriptiontText.text = card.cardDescription;
        }
        


    }
}
