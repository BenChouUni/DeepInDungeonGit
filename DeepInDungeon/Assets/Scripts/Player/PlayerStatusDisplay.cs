using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 顯示玩家狀態用 可以自動調用也可以被調用
/// </summary>
public class PlayerStatusDisplay : MonoBehaviour, IDataPersistence
{
    public PlayerStatus playerStatus;

    #region
    public List<Text> playerName;
    public HealthBar healthBar;
    public Text shieldText;
    public Text coinText;

    #endregion
    private void Start()
    {
        if (playerStatus == null)
        {
            Debug.LogError("找不到玩家資料");
        }
        //Debug.Log("名字" + playerStatus.Name);
        InitialPlayerStatus(playerStatus);


    }
    public void InitialPlayerStatus(PlayerStatus _playerStatus)
    {
        foreach (Text text in playerName)
        {
            Unit.ShowUnit(_playerStatus, text, healthBar, shieldText);
        }
        ShowCoin(coinText, _playerStatus.Coin);
    }
    /// <summary>
    /// 更新狀態 名字不會更新
    /// </summary>
    public void UpdatePlayerStatus(PlayerStatus _playerStatus)
    {
        Unit.UpdateUnitStatus(_playerStatus, healthBar, shieldText);

        ShowCoin(coinText, _playerStatus.Coin);
        
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
