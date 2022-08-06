using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public PlayerWeapon playerWeapon;
    public List<Moves> playerMovesDeck;
    

    public PlayerStatus playerStatus;

    public GameData()
    {
        //初始化
        this.playerWeapon = new PlayerWeapon(null, null);
        this.playerMovesDeck = new List<Moves>();
        this.playerStatus = new PlayerStatus("無名氏",50,0);
    }
}
