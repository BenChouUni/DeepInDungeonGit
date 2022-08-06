using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusDisplay : MonoBehaviour
{
    public Text playerNameText;
    public Text coinText;
    public Text maxHealth;

    public PlayerStatus playerStatus;


    public void ShowPlayer()
    {
        playerNameText.text = playerStatus.playerName;
        coinText.text = playerStatus.coin.ToString();
        maxHealth.text = playerStatus.hpStatus.hpMax.ToString();
    }
}
