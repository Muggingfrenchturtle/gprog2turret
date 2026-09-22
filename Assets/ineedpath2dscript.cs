using System;
using UnityEngine;

public class ineedpath2dscript : MonoBehaviour
{
    public Vector2[] points = new Vector2[2];

    //public float distancebetweenpointAB;

    public various_useful_functions vuf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < points.Length; i++) 
        { 
            points[i] = transform.GetChild(i).position;//fills out the points arreay with the points

            Console.WriteLine(points[i]);
        }



        //distancebetweenpointAB = vuf.getDistanceBetweenPoints(points[0], points[1]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
