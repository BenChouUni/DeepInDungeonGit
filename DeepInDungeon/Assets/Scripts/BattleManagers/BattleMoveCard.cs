using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleMoveCard : MonoBehaviour,IPointerUpHandler,IBeginDragHandler
{
    public Moves move;

    void Start()
    {
        move = GetComponent<MovesCardDisplay>().move;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (move.aim)
        {
            Debug.Log("準備攻擊");
            BattleManager.Instance.PlayerAttackRequest(move);
        }
    }
}
