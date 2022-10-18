using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyActionManager : MonoSingleton<EnemyActionManager>
{
    //敵人
    public EnemyStatus enemy;

    //動作標示
    public Text actionShow;
    public Image actionIcon;
    //manager
    

    public void Action()
    {
        EndAction();
    }
    /// <summary>
    ///  展示出敵人下回合的攻擊
    /// </summary>
    /// <param name="str"></param>
    private void ShowAction(string str)
    {
        
    }
    //攻擊

    //給自己護盾
    public void Shield()
    {

    }
    public void EndAction()
    {
        BattleManager.Instance.gamePhase = GamePhase.playerTurn;
    }
}
