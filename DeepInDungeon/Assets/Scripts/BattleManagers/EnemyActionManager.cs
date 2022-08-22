using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyActionManager : MonoBehaviour
{
    //敵人
    public Enemy enemy;

    //動作標示
    public Text actionShow;
    public Image actionIcon;
    //manager
    public BattleManager battleManager;

    public void Action()
    {
        Attack(10);
    }
    /// <summary>
    ///  展示出敵人下回合的攻擊
    /// </summary>
    /// <param name="str"></param>
    private void ShowAction(string str)
    {
        
    }
    //攻擊
    public void Attack(int dmg)
    {

        battleManager.playerStatusManager.RecieveDamage(dmg);
    }
    public void Attack(int dmg,int time)
    {
        for (int i = 0; i < time; i++)
        {
            battleManager.playerStatusManager.RecieveDamage(dmg);
        }
        
    }
    //給自己護盾
    public void Shield()
    {

    }
}
