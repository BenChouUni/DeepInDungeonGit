using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatusManager : MonoBehaviour
{
    public Enemy enemyStatus;

    public HealthBar healthBar;
    public Text enemyName;
    

   
    void Start()
    {
        //ShowEnemyStatus();
    }


    public void ShowEnemyStatus()
    {
        enemyName.text = enemyStatus.name;
        healthBar.SetMaxHealth(enemyStatus.hpStatus.hpMax);
        healthBar.SetHealth(enemyStatus.hpStatus.hp);
    }

    public void RecieveDamage(int dmg)
    {
        if (dmg <= 0)
        {

            return;
        }
        Debug.Log("敵人受到" + dmg.ToString() + "點傷害");

        enemyStatus.hpStatus.hp -= dmg;
        CheckDeath();
        ShowEnemyStatus();
    }

    private void CheckDeath()
    {
        if (enemyStatus.hpStatus.hp <= 0)
        {
            Debug.Log("敵方死亡");
            
        }
    }
}
