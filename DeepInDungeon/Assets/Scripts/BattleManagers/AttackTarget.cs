using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackTarget : MonoBehaviour, IPointerEnterHandler,IDropHandler
{
    public bool attackable = true;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        if (attackable && BattleManager.attackingPrepare)
        {
            Debug.Log("準備被攻擊");
            BattleManager.Instance.PlayerAttackConfirm();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }


}


    

