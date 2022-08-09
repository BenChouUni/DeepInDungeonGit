using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusDisplayManager : MonoBehaviour, IDataPersistence
{
    public PlayerStatus playerStatus;
    

    public Text playerNameText;
    public Text coinText;
    public Text maxHealth;

    
    public void Start()
    {
        if (playerStatus.playerName!=null)
        {
            ShowPlayer();
        }
        else
        {
            Debug.LogError("玩家資料可能是空的");
        }
        
    }


    public void LoadData(GameData data)
    {
        this.playerStatus = data.playerStatus;
        
        
    }

    public void SaveData(ref GameData data)
    {
        data.playerStatus = this.playerStatus;
    }
    public void ShowPlayer()
    {
        playerNameText.text = playerStatus.playerName;
        coinText.text = playerStatus.coin.ToString();
        maxHealth.text = playerStatus.hpStatus.hpMax.ToString();
    }

}
