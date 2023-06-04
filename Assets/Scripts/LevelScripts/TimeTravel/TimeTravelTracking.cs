using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelTracking : MonoBehaviour
{
    public bool isGloveOn = false;
    private int timeTravelCount = 0;

    void Start()
    {
        isGloveOn = false;
        timeTravelCount = 0;
    }

    public void TakeGlove()
    {
        isGloveOn = true;
    }

    public int incrementTravelCount()
    {
        timeTravelCount++;
        return timeTravelCount;
    }
}
