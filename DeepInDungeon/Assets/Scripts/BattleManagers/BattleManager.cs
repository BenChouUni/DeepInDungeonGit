using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GamePhase
{
    gameStart,playerTurn,enemyTurn,

    gameEnd
}

public class BattleManager : MonoBehaviour
{
    public  Text GamePhaseShow;
    //
    public PlayerMovesDeckManager playerMovesDeckManager;
    public PlayerStatusBattleManager playerStatusBattleManager;
    public WeaponBattleManager weaponBattleManager;
    public EnemyStatusManager enemyStatusManager;
    
    public static GamePhase gamePhase = GamePhase.gameStart;
    [SerializeField]
    private int drawNumber;

    private void Start()
    {
        GameStart();
    }


    public void ShowGamePhase()
    {
        GamePhaseShow.text = gamePhase.ToString();
    }

    private void GameStart()
    {
        gamePhase = GamePhase.gameStart;

        playerStatusBattleManager.ShowPlayerBasicInformation();
        weaponBattleManager.ShowWeapon();

        playerMovesDeckManager.ShuffleMoves();
        playerMovesDeckManager.CreateMovesCard(drawNumber);
        enemyStatusManager.ShowEnemyStatus();


        gamePhase = GamePhase.playerTurn;
        ShowGamePhase();

    }

    public void PlayerTurnEnd()
    {
        playerMovesDeckManager.DiscardAllMovesInHand();
        EndTurn();
        
        //playerMovesDeckManager.CreateMovesCard(drawNumber);
    }
    public void EndTurn()
    {
        if (gamePhase == GamePhase.playerTurn)
        {
            Debug.Log("玩家回合結束，進入敵方回合");
            gamePhase = GamePhase.enemyTurn;
        }
        else if (gamePhase == GamePhase.enemyTurn)
        {
            gamePhase = GamePhase.playerTurn;
           
        }

        ShowGamePhase();
    }

    public void EndBattle()
    {
        gamePhase = GamePhase.gameEnd;
    }
}
