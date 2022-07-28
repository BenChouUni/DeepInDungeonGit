using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用event system
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    //初始parent 以便放開後返回
    private Transform startParent = null;
    public Transform StartParent
    {
        get { return startParent; }
    }
    

    public Transform parentReturnTo = null;//要返回的位置的parent
 

    public void OnBeginDrag(PointerEventData eventData)//開始拖動執行一次
    {
        startParent = this.transform.parent;
        parentReturnTo = startParent;
        Debug.Log("開始拖"+gameObject.name.ToString());
        this.transform.SetParent(this.transform.parent.parent.parent);
    }


    public void OnDrag(PointerEventData eventData)//拖動中
    {
        this.transform.position = eventData.position;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentReturnTo);
    }

    public void ReturnToStartParent()
    {
        this.transform.SetParent(startParent);
    }
}
