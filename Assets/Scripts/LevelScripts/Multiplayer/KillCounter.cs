using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public int counter = 0;
    public int killThreshold = 30;

    public void Start()
    {
        counter = 0;
    }
    public void FixedUpdate()
    {
        if (counter == 1)
        {
            GameObject narrator = GameObject.Find("NarratorManager");
            if (narrator != null)
                narrator.GetComponent<NarratorManager>().Say("FirstKill");
        }
        else if (counter == killThreshold)
        {
            GameObject narrator = GameObject.Find("NarratorManager");
            if (narrator != null)
                narrator.GetComponent<NarratorManager>().Say("AfterXKills");
        }
    }
    public void countKill()
    {
        counter++;
    }
}
