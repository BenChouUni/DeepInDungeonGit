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
    //回合控制
    public GamePhase gamePhase = GamePhase.gameStart;
    public  Text GamePhaseShow;
    //manager
    public BattleCardManager playerMovesDeckManager;
    //public WeaponBattleManager weaponBattleManager;
    public EnemyStatusManager enemyStatusManager;
    public PlayerStatusManager playerStatusManager;
    //acction manager
    public EnemyActionManager EnemyActionManager;
    //data manager
    public EnemyDataManager enemyDataManager;
    
    //輔助變量
    private Moves attackingMove;//準備發起攻擊的move
    private Weapon attackingWeapon;
    private BattleMoveCard attackingMoveCard;//發起攻擊牌的組件
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

        WeaponBattleManager.Instance.ShowWeapon();

        playerMovesDeckManager.ShuffleMoves();

        playerStatusManager.UpdateDisplay();
        enemyStatusManager.enemyStatusDisplay.InitialEnemyStatus(enemyDataManager.LoadCertainEnemy(0));
        


        PlayerTurnStart();
        ShowGamePhase();

    }
    public void PlayerTurnStart()
    {
        gamePhase = GamePhase.playerTurn;
        playerMovesDeckManager.DrawCards(drawNumber);
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

    //攻擊

    public void PlayerAttackRequest(BattleMoveCard _attackingMoveCard,Moves moves)
    {
        if (gamePhase != GamePhase.playerTurn)
        {
            Debug.Log("不是玩家回合，不可以發動攻擊");
            return;
        }
        this.attackingMoveCard = _attackingMoveCard;
        this.attackingMove = moves;
        this.attackingWeapon = WeaponBattleManager.Instance.FindWeaponByName(moves.weaponName);
        attackingPrepare = true;
    }

    public void PlayerAttackConfirm()
    {
        if (attackingWeapon==null)
        {
            return;
        }
        AttackEnemy(attackingWeapon.Attack);

        attackingPrepare = false;
        attackingWeapon = null;
    }

    public void AttackEnemy(int dmg)
    {
        enemyStatusManager.enemyStatus.GetDamage(dmg);
        attackingMoveCard.DiscardItself();
    }
}
