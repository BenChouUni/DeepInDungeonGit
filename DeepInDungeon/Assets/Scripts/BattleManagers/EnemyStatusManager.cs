using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatusManager : MonoBehaviour
{
    public Enemy enemyStatus;

    public Text enemyName;
    public Text enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        //ShowEnemyStatus();
    }


    public void ShowEnemyStatus()
    {
        enemyName.text = enemyStatus.name;
        int maxHealth = enemyStatus.hpStatus.hpMax;
        int hp = enemyStatus.hpStatus.Hp;
        enemyHealth.text = hp.ToString() + "/" + maxHealth.ToString();
    }
}
