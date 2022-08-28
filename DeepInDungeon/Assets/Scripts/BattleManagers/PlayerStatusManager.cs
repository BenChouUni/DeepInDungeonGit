using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 戰鬥時的玩家數值
/// </summary>
public class PlayerStatusManager : MonoBehaviour,IDataPersistence
{
    public PlayerStatus playerStatus;

    public int shield;
    public ShieldDisplay shieldDisplay;
    public int maxEnergy = 3;
    public int energy;
    public EnergyDisplay energyDisplay;

    public PlayerStatusDisplay playerStatusDisplay;


    private void Start()
    {
        playerStatusDisplay = this.GetComponent<PlayerStatusDisplay>();
    }
    public void LoadData(GameData data)
    {
        this.playerStatus = data.playerStatus;
    }

    public void SaveData(ref GameData data)
    {
        
    }

    public void RecieveDamage(int num)
    {
        if (num <= 0)
        {
            Debug.Log("沒傷害");
            return;
        }
        Debug.Log("玩家受到"+num.ToString()+"點傷害");

        playerStatus.hpStatus.hp -= num;
        CheckDeath();
        UpdateDisplay();
    }

    private void CheckDeath()
    {
        if (playerStatus.hpStatus.hp <=0)
        {
            Debug.Log("玩家死亡");
            playerStatus.hpStatus.hp = 0;
        }
    }
    public void UpdateDisplay()
    {
        playerStatusDisplay.playerStatus = playerStatus;
        playerStatusDisplay.UpdatePlayerStatus();
        shieldDisplay.SetShield(shield);
        energyDisplay.SetMaxEnergy(maxEnergy);
    }
}