using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovesCardDisplay : CardDisplay
{

    public Text costText;
    public Text weaponBelong;
    public Image backgound;//用來變色
    public Moves move;

    public void Start()
    {
        ShowMovesCard();
    }

    private void ShowMovesCard()
    {
        card = move;
        ShowCard();
        
        costText.text = move.cost.ToString();
        weaponBelong.text = move.weaponName;
        
        

    }
}
