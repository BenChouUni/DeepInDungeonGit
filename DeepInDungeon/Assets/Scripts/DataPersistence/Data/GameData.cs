using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public PlayerStatus playerStatus;
    public PlayerWeapon playerWeapon;
    public List<Moves> playerMovesDeck;
    

    public GameData()
    {
        //初始化
        this.playerStatus = new PlayerStatus();
        this.playerWeapon = new PlayerWeapon();
        this.playerMovesDeck = new List<Moves>();
        
    }
}
