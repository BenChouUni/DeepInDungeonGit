using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DropZone : MonoBehaviour,IDropHandler
{
    //確認是否能夠drop
   

    public void OnDrop(PointerEventData eventData)
    {
        if (HasWeapon())
        {
            Debug.Log("上面有武器了");
            ReturnObjectToOrigin();
        }

        DropIn(eventData);

    }
    /// <summary>
    /// 額外確認是否有drag的腳本在其中
    /// </summary>
    /// <param name="eventData"></param>
    private void DropIn(PointerEventData eventData)
    {
        //確認是否有drag的腳本
        Draggable drg = eventData.pointerDrag.GetComponent<Draggable>();
        if (drg != null)
        {
            Debug.Log("can drop");
            drg.parentReturnTo = this.transform;
        }
    }

    private void ReturnObjectToOrigin()
    {
        GameObject gameObject = null;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            WeaponDisplay w = this.transform.GetChild(i).gameObject.GetComponent<WeaponDisplay>();
            if (w != null)
            {
                gameObject = this.transform.GetChild(i).gameObject;
                break;//找到有武器的條件就退出

            }
        }
        gameObject.GetComponent<Draggable>().ReturnToStartParent();
    }

    private bool HasWeapon()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            WeaponDisplay w = this.transform.GetChild(i).gameObject.GetComponent<WeaponDisplay>();
            if (w != null)
            {
                
                return true;
            }
        }
        return false;
    }
}
