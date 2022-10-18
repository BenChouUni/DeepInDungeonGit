using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Text nameText;
    
    public Text discriptiontText;

    public Image Image;

    public Card card;


    public void ShowCard()
    {


        nameText.text = this.card.name;
       
        if (discriptiontText.text!=null)
        {
            discriptiontText.text = card.cardDescription;
        }
        


    }
}