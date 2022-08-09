using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GamePhase
{
    gameStart,playerAction,enemyAction
}

public class BattleManager : MonoBehaviour
{
    public GamePhase gamePhase = GamePhase.gameStart;

    public PlayerMovesDeckManager playerMovesDeckManager;
    [SerializeField]
    private int drawNumber = 4;

    private void Start()
    {
        GameStart();
    }

    public void GameStart()
    {
        playerMovesDeckManager.ShuffleMoves();
        playerMovesDeckManager.CreateMovesCard(drawNumber);


        gamePhase = GamePhase.playerAction;

    }

    public void EndTurn()
    {
        if (gamePhase == GamePhase.playerAction)
        {
            gamePhase = GamePhase.enemyAction;
        }

        if (gamePhase == GamePhase.enemyAction)
        {
            gamePhase = GamePhase.playerAction;
        }
    }
}
