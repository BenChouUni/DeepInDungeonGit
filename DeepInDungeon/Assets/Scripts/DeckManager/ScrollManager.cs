using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrollManager : MonoBehaviour
{

    public ScrollRect scrollRect;

    // Start is called before the first frame update
    void Start()
    {
        scrollRect = this.GetComponent<ScrollRect>();
        scrollRect.horizontal = false;
        scrollRect.scrollSensitivity = 5;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
