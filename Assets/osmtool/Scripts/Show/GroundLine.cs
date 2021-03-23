using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLine : MonoBehaviour
{
    public float Width;
    public float Length;
    public float unit;
    public GameObject Line;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void SetLines()
    {
        while (transform.childCount != 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        for (int i = 0; i < Width / unit; i++)
        {
            LineRenderer lr = Instantiate(Line, transform).GetComponent<LineRenderer>();
            lr.GetComponent<LineRenderer>().positionCount = 2;
            lr.SetPosition(0, new Vector3(-Length / 2 , 0, -Width / 2 + i * unit));
            lr.SetPosition(1, new Vector3(Length / 2, 0, -Width / 2 + i * unit));
        }

        for (int i = 0; i < Length / unit; i++)
        {
            LineRenderer lr = Instantiate(Line, transform).GetComponent<LineRenderer>();
            lr.GetComponent<LineRenderer>().positionCount = 2;
            lr.SetPosition(0, new Vector3(-Length / 2 + i * unit, 0,-Width / 2 ));
            lr.SetPosition(1, new Vector3(-Length / 2 + i * unit, 0, Width / 2));
        }
    }

}
