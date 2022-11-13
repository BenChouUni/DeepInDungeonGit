using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家即敵人透過此腳本來執行行為
//由battleManager管理
public class BattleActionManager
{
    //由BattleManager傳入
    public EnemyStatus enemy;
    public PlayerStatus player;
    public Weapon mainWeapon;
    public Weapon secWeapon;
    //aaction
    public void WeaponAttack(Weapon weapon)
    {
        int dmg = weapon.Attack;
        if (dmg > 0)
        {
            enemy.GetDamage(dmg);
        }
        
    }
}
