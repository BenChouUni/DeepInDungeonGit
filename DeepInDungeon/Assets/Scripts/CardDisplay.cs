using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Text nameText;
    public Text costText;
    
    public Text discriptiontText;

    public Image Image;

    public Card card;

    // Start is called before the first frame update
    void Start()
    {
        ShowCard();
    }

    public void ShowCard()
    {


        nameText.text = card.cardName;
        costText.text = card.cost.ToString();//數字換成文字
        discriptiontText.text = card.cardDiscription;

        if (card is AttackCard)
        {

            
        }
        else if (card is DefendCard)
        {
            
        }
    }
}
