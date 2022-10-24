using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyStatusDisplay : MonoBehaviour
{
    //public EnemyStatus enemyStatus;

    #region
    public Text playerName;
    public HealthBar healthBar;
    public Text shieldText;

    #endregion
    // Start is called before the first frame update
    public void InitialEnemyStatus(EnemyStatus enemyStatus)
    {
        Unit.ShowUnit(enemyStatus, playerName, healthBar, shieldText);
    }

    public void UpdateEnemyStatus(EnemyStatus enemyStatus)
    {
        //Debug.Log("EnemyStatusDisplay.UpdateEnemyStatus");
        Unit.UpdateUnitStatus(enemyStatus, healthBar, shieldText);

    }
}
