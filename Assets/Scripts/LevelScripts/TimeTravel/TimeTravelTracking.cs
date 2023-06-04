using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelTracking : MonoBehaviour
{
    public bool isGloveOn = false;

    void Start()
    {
        isGloveOn = false;
    }

    public void TakeGlove()
    {
        isGloveOn = true;
    }
}
