using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public static Transform[] points;

    private void Awake()
    {

        // Makes an array dependent on the number of children this has
        points = new Transform[transform.childCount];

        // Iterates through the different children and adds it to the array

        for (int i = 0; i < points.Length; i++)
        {

            points[i] = transform.GetChild(i);

        }

    }

}
