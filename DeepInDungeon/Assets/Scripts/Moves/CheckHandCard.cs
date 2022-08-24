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
    private Vector3 originalPosistion;

    private void Start()
    {
        FindCanvas();
        InitializeOrigin();
        //startParent = this.transform.parent;
        //originalRotate = this.transform.eulerAngles.z;

    }
    public void InitializeOrigin()
    {
        originalPosistion = this.transform.position;
        startParent = this.transform.parent;
        siblingIndex = this.transform.GetSiblingIndex();
        originalRotate = this.transform.eulerAngles.z;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        InitializeOrigin();
        if (hasCheck)
        {
            return;
        }

        ShowCard();
    }

    public void ShowCard()
    {


        Vector3 upPosition = originalPosistion + new Vector3(0, UpLengh, 0);

        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        this.transform.SetParent(Canvas, true);
        this.transform.position = upPosition;
        hasCheck = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (Arrow._Show)
        {
            return;
        }
        EndShowCard();
    }

    public void EndShowCard()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, originalRotate);
        this.transform.position = originalPosistion;
        this.transform.SetParent(startParent, true);
        this.transform.SetSiblingIndex(siblingIndex);

        hasCheck = false;
    }
    private void FindCanvas()
    {
        Canvas = GameObject.Find("Canvas").gameObject.transform;
       
    }
}
