using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelTracking : MonoBehaviour
{
    public bool isGloveOn = false;
    private int timeTravelCount = 0;

    public GameObject now;
    public GameObject future;

    void Start()
    {
        isGloveOn = false;
        timeTravelCount = 0;
        future.SetActive(false);
    }

    public void TakeGlove()
    {
        isGloveOn = true;
    }

    public int incrementTravelCount()
    {
        timeTravelCount++;
        future.SetActive(!future.activeSelf);
        now.SetActive(!now.activeSelf);
        return timeTravelCount;
    }
}
