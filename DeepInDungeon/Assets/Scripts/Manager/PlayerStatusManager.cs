using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatusManager : MonoBehaviour, IDataPersistence
{
    public PlayerStatus playerStatus;
    public PlayerStatusDisplay PlayerStatusDisplay;

    public void Start()
    {
        PlayerStatusDisplay.playerStatus = this.playerStatus;
        PlayerStatusDisplay.ShowPlayer();
    }


    public void LoadData(GameData data)
    {
        this.playerStatus = data.playerStatus;
        
        
    }

    public void SaveData(ref GameData data)
    {
        data.playerStatus = this.playerStatus;
    }

    
}
