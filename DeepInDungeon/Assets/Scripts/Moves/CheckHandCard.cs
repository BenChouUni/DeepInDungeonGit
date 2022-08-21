using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckHandCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Transform Canvas;
    private Transform startParent;
    public float UpLengh;
    private bool hasCheck = false;
    [SerializeField]
    private float originalRotate;
    private int siblingIndex;

    private void Start()
    {
        FindCanvas();
        //startParent = this.transform.parent;
        //originalRotate = this.transform.eulerAngles.z;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hasCheck)
        {
            return;
        }

        startParent = this.transform.parent;
        siblingIndex = this.transform.GetSiblingIndex();
        originalRotate = this.transform.eulerAngles.z;

        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        this.transform.SetParent(Canvas,true);
        this.transform.Translate(0,UpLengh,0);
        hasCheck = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.rotation = Quaternion.Euler(0, 0, originalRotate);
        this.transform.Translate(0, -UpLengh, 0);
        this.transform.SetParent(startParent,true);
        this.transform.SetSiblingIndex(siblingIndex);
        
        hasCheck = false;
    }

    private void FindCanvas()
    {
        Canvas = GameObject.Find("Canvas").gameObject.transform;
    }
}
