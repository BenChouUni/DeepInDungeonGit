using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackTarget : MonoBehaviour, IPointerEnterHandler
{
    public bool attackable = true;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (attackable && BattleManager.attackingPrepare)
        {
            Debug.Log("準備被攻擊");
            BattleManager.Instance.PlayerAttackConfirm();
        }
    }
}


    

