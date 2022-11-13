using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckSceneManager : MonoBehaviour
{
    public WeaponDeckManager weaponDeckManager;



    public void ToShowMovesScene()
    {

        SceneManager.LoadScene("ShowMovesScene");
        
    }

    public void ToBattleScene()
    {
        if (weaponDeckManager.MainWeapon.cardName != null)
        {
            SceneManager.LoadScene("BattleScene");
        }
        else
        {
            Debug.LogError("沒有主武器無法開始戰鬥");
        }
        
    }


}
