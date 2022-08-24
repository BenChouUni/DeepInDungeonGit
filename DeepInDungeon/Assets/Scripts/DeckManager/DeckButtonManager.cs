using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckButtonManager : MonoBehaviour
{
    public GameObject startBattleButton;
    public GameObject checkDeckButton;

    private void Start()
    {
        //開場隱藏進入戰鬥按鈕
        HideButton();
        
    }
    public void HideButton()
    {
        startBattleButton.SetActive(false);
    }
    public void ShowButton()
    {
        startBattleButton.SetActive(true);
        
    }
}
