using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GamePhase
{
    gameStart,playerTurn,enemyTurn,

    gameEnd
}

public class BattleManager : MonoSingleton<BattleManager>
{
    public  Text GamePhaseShow;
    //
    public PlayerMovesDeckManager playerMovesDeckManager;
    public WeaponBattleManager weaponBattleManager;
    public EnemyStatusManager enemyStatusManager;
    public PlayerStatusManager playerStatusManager;
    //acction manager
    public EnemyActionManager EnemyActionManager;
    
    public GamePhase gamePhase = GamePhase.gameStart;
    //輔助變量
    private Moves attackingMove;//準備發起攻擊的武器
    public static bool attackingPrepare;
    [SerializeField]
    private int drawNumber;

    private void Start()
    {
        //Debug.Log(Application.persistentDataPath);
        GameStart();
    }


    public void ShowGamePhase()
    {
        GamePhaseShow.text = gamePhase.ToString();
    }

    private void GameStart()
    {
        gamePhase = GamePhase.gameStart;

        attackingPrepare = false;
        
        weaponBattleManager.ShowWeapon();

        playerMovesDeckManager.ShuffleMoves();
        playerStatusManager.UpdateDisplay();
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

    public void PlayerAttackRequest(Moves moves)
    {
        if (gamePhase != GamePhase.playerTurn)
        {
            Debug.Log("不是玩家回合，不可以發動攻擊");
            return;
        }

        attackingMove = moves;
        attackingPrepare = true;
    }

    public void PlayerAttackConfirm()
    {
        AttackEnemy(5);

        attackingPrepare = false;
    }

    public void AttackEnemy(int dmg)
    {
        enemyStatusManager.RecieveDamage(dmg);
       
    }
}
