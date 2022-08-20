using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GamePhase
{
    gameStart,playerTurn,enemyTurn,

    gameEnd
}

public class BattleManager : MonoBehaviour
{

    public PlayerMovesDeckManager playerMovesDeckManager;

    [SerializeField]
    public static GamePhase gamePhase = GamePhase.gameStart;
    [SerializeField]
    private int drawNumber;

    private void Start()
    {
        GameStart();
    }

    private void GameStart()
    {
        gamePhase = GamePhase.gameStart;

        playerMovesDeckManager.ShuffleMoves();
        playerMovesDeckManager.CreateMovesCard(drawNumber);


        gamePhase = GamePhase.playerTurn;

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
            
            gamePhase = GamePhase.enemyTurn;
        }

        if (gamePhase == GamePhase.enemyTurn)
        {
            gamePhase = GamePhase.playerTurn;
           
        }
    }

    public void EndBattle()
    {
        gamePhase = GamePhase.gameEnd;
    }
}
