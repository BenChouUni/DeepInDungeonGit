using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusBattleManager : MonoBehaviour,IDataPersistence
{
    public PlayerStatus playerStatus;

    #region
    public List<Text> playerName;
    public List<Text> playerHealth;
    
    #endregion

    public void LoadData(GameData data)
    {
        this.playerStatus = data.playerStatus;
    }

    public void SaveData(ref GameData data)
    {
        data.playerStatus = this.playerStatus;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerBasicInformation();
    }

    private void LoadPlayerBasicInformation()
    {
        foreach (Text text in playerName)
        {
            text.text = playerStatus.playerName;
        }

        foreach (Text text in playerHealth)
        {
            string currentHp = playerStatus.hpStatus.Hp.ToString();
            string maxHp = playerStatus.hpStatus.hpMax.ToString();
            string str = currentHp + " / " + maxHp;
            text.text = str;
        }
    }

}
