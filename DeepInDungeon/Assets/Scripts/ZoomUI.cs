using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomUI : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public float zoomSize = 1.5f;

    public void OnPointerEnter(PointerEventData pointerEvent)
    {
        transform.localScale = new Vector3(zoomSize, zoomSize, 1.0f);


    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        transform.localScale = Vector3.one;
    }

}
