using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUtils : MonoBehaviour
{
    public static double GetZoomScaleByDistance(float distance)
    {
        return 1 / (Math.Log10(distance + 1) + 1);
    }
}
