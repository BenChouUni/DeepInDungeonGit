using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyDatamanager : MonoBehaviour
{
    public TextAsset EnemyList;

    public Enemy enemy;
    //敵人狀態管理器
    public EnemyStatusManager enemyStatusManager;

    // Start is called before the first frame update
    void Awake()
    {
        LoadCertainEnemy(0);
    }

    private void LoadCertainEnemy(int id)
    {
        string[] dataRow = EnemyList.text.Split('\n');
        

        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0].Trim() != id.ToString())
            {
                continue;
            }

            string name = rowArray[1];
            int maxHp = int.Parse(rowArray[2]);
            int atk = int.Parse(rowArray[3]);


            enemy = new Enemy(id, name, maxHp, atk); 

        }
        if (enemy.name == null)
        {
            Debug.LogError("找不到敵人");
        }
        else
        {
            enemyStatusManager.enemyStatus = enemy;
        }
        
    }


}
