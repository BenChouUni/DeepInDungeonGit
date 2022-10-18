using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 戰鬥時的玩家數值
/// </summary>
public class PlayerStatusManager : MonoSingleton<PlayerStatusManager>,IDataPersistence
{
    public PlayerStatus playerStatus;

    public EnergyDisplay energyDisplay;

    public PlayerStatusDisplay playerStatusDisplay;

    private void Awake()
    {
        playerStatusDisplay = this.GetComponent<PlayerStatusDisplay>();
    }
    private void Start()
    {
        //playerStatusDisplay = this.GetComponent<PlayerStatusDisplay>();
    }
    public void LoadData(GameData data)
    {
 
        this.playerStatus = data.playerStatus;
    }

    public void SaveData(ref GameData data)
    {
        
    }


    private void CheckDeath()
    {
        if (playerStatus.HpStatus.hp <=0)
        {
            Debug.Log("玩家死亡");
            
        }
    }
    public void UpdateDisplay()
    {
 
        playerStatusDisplay.UpdatePlayerStatus(playerStatus);
       
    }
}
