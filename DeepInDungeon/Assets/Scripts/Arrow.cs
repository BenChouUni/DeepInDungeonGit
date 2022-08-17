using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject[] points;

    public GameObject point;
    public GameObject arrow;

    public int numOfPoints;

    public static Vector2 startPoint;

    public float distance;

    public Vector2 direction;
    public float force;

    public static bool _Show;
   

    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numOfPoints];

        for (int i = 0; i < numOfPoints; i++)
        {
            if (i != numOfPoints -1)
            {
                points[i] = Instantiate(point,this.transform.position,Quaternion.identity);
                
            }
            else
            {
                points[i] = Instantiate(arrow, this.transform.position, Quaternion.identity);
            }
            points[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numOfPoints; i++)
        {
            points[i].transform.position = Vector2.Lerp(startPoint,direction,i*0.1f);

            direction = Input.mousePosition;

            distance = Vector3.Distance(startPoint,direction);

            if (_Show == true)
            {
                Show();
                
            }
            else
            {
                Hide();
            }


        }
    }

    private void Show()
    {
        for (int i = 0; i < numOfPoints; i++)
        {
            points[i].SetActive(true);
        }
    }

    private void Hide()
    {
        for (int i = 0; i < numOfPoints; i++)
        {
            points[i].SetActive(false);
        }
    }
}
