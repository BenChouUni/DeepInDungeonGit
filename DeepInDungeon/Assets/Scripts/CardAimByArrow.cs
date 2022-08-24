using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardAimByArrow : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    
    public void OnBeginDrag(PointerEventData eventData)
    {

        if (eventData.pointerDrag.GetComponent<MovesCardDisplay>().move.aim == false)
        {
            return;
        }
        if (BattleManager.gamePhase == GamePhase.playerTurn)
        {
            Arrow.startPoint = this.transform.position;
            Arrow._Show = true;

        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<CheckHandCard>().EndShowCard();
        Arrow._Show = false;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        Arrow._Show = false;
    }


}
