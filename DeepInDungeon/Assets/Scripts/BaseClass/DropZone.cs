using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DropZone : MonoBehaviour
{
    private List<GameObject> zoneList = new List<GameObject>(5);
    public List<GameObject> ZoneList
    {
        get { return zoneList; }
    }

    /// <summary>
    /// 有draggable的全部返回
    /// </summary>
    public void ReturnAllObjectToOrigin()
    {
        GameObject gameObject = null;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Draggable drg = this.transform.GetChild(i).gameObject.GetComponent<Draggable>();
            if (drg != null)
            {
                gameObject = this.transform.GetChild(i).gameObject;
                gameObject.GetComponent<Draggable>().ReturnToStartParent();

            }
        }
        zoneList.RemoveRange(0,zoneList.Count);//全部移除
    }

    protected void DropIn(GameObject go)
    {
        Draggable drg = go.GetComponent<Draggable>();
        if (drg != null)
        {
            go.GetComponent<Draggable>().parentReturnTo = this.transform;
            zoneList.Add(go);
        }

    }
    /// <summary>
    /// 把單一有draggable的物件回歸
    /// </summary>
    /// <param name="go"></param>
    public void ReturnObjectToOrigin(GameObject go)
    {
        go.GetComponent<Draggable>().ReturnToStartParent();
        zoneList.Remove(go);
    }

    public void ReturnObjectToOrigin(GameObject[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            ReturnObjectToOrigin(list[i]);
        }
    }



 

    public void UndropByClass<T>(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<T>() != null)
        {
            ReturnObjectToOrigin(eventData.pointerDrag);
        }
        
    }

    public bool CheckHas<T>()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            object ob = this.transform.GetChild(i).gameObject.GetComponent<T>();
            if (ob != null)
            {

                return true;
            }
        }
        return false;
    }


}
