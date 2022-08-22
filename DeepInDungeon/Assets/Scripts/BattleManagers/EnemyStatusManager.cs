using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatusManager : MonoBehaviour
{
    public Enemy enemyStatus;

    public Text enemyName;
    public Text enemyHealth;

   
    void Start()
    {
        //ShowEnemyStatus();
    }


    public void ShowEnemyStatus()
    {
        enemyName.text = enemyStatus.name;
        int maxHealth = enemyStatus.hpStatus.hpMax;
        int hp = enemyStatus.hpStatus.hp;
        enemyHealth.text = hp.ToString() + "/" + maxHealth.ToString();
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
