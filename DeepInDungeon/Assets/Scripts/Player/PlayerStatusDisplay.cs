using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 工具程式用來顯示玩家狀態
/// </summary>
public class PlayerStatusDisplay : MonoBehaviour, IDataPersistence
{
    public PlayerStatus playerStatus;

    #region
    public List<Text> playerName;
    
    public HealthBar healthBar;
    public List<Text> coinText;

    #endregion
    private void Start()
    {
        foreach (Text text in playerName)
        {
            ShowName(text, playerStatus.playerName);
        }
        
        UpdatePlayerStatus();
    }
    /// <summary>
    /// 更新時不會檢查名字
    /// </summary>
    public void UpdatePlayerStatus()
    {
        ShowHp(playerStatus.hpStatus);

        foreach (Text text in coinText)
        {
            ShowCoin(text, playerStatus.coin);
        }
    }

    private void ShowName(Text nameText,string playerName)
    {
        if (nameText == null)
        {
            return;
        }
        nameText.text = playerName;

    }

    private void ShowHp(HpStatus hpStatus)
    {
        if (healthBar == null)
        {
            return;
        }
        healthBar.SetMaxHealth(hpStatus.hpMax);
        healthBar.SetHealth(hpStatus.hp);
        

    }

    private void ShowCoin(Text numText,int coinNum)
    {
        if (numText == null)
        {
            return;
        }
        numText.text = coinNum.ToString();
    }

    public void LoadData(GameData data)
    {
        this.playerStatus = data.playerStatus;
    }

    public void SaveData(ref GameData data)
    {
        //data.playerStatus = this.playerStatus;
    }
}
