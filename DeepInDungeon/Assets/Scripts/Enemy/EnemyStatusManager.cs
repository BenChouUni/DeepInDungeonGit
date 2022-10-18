using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 包括顯示敵人
/// </summary>
public class EnemyStatusManager : MonoSingleton<EnemyStatusManager>
{
    public EnemyStatus enemyStatus;

    public HealthBar healthBar;
    public Text enemyName;

    public EnemyStatusDisplay enemyStatusDisplay;

    private void Awake()
    {
        enemyStatusDisplay = this.GetComponent<EnemyStatusDisplay>();
    }

    void Start()
    {
        
        enemyStatusDisplay.UpdateEnemyStatus(enemyStatus);
    }


    public void UpdateDisplay()
    {
        enemyStatusDisplay.UpdateEnemyStatus(enemyStatus);
    }

    private void CheckDeath()
    {
        if (enemyStatus.HpStatus.hp <= 0)
        {
            Debug.Log("敵方死亡");
            
        }
    }
}
