using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

    public GameObject canvas;
    public bool isArrow;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");

        this.transform.SetParent(canvas.transform);
        this.transform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}