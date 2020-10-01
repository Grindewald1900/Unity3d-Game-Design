using System;
using UnityEngine;

namespace Utils
{
    public class MyUtils : MonoBehaviour
    {
        public static double GetZoomScaleByDistance(float distance)
        {
            return 1 / (Math.Log10(distance + 1) + 1);
        }
    }
}
