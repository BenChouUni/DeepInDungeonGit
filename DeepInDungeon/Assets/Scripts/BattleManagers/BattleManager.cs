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
    public WeaponBattleManager weaponBattleManager;
    public EnemyStatusManager enemyStatusManager;
    public PlayerStatusManager playerStatusManager;
    //acction manager
    public EnemyActionManager EnemyActionManager;
    
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

        
        weaponBattleManager.ShowWeapon();

        playerMovesDeckManager.ShuffleMoves(); 
        enemyStatusManager.ShowEnemyStatus();


        PlayerTurnStart();
        ShowGamePhase();

    }
    public void PlayerTurnStart()
    {
        gamePhase = GamePhase.playerTurn;
        playerMovesDeckManager.CreateMovesCard(drawNumber);
    }
    public void PlayerTurnEnd()
    {
        playerMovesDeckManager.DiscardAllMovesInHand();
        EndTurn();
        
        
    }
    public void EndTurn()
    {
        if (gamePhase == GamePhase.playerTurn)
        {
            Debug.Log("玩家回合結束，進入敵方回合");
            EnemyActionManager.Action();
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
