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
            GameObject narrator = GameObject.Find("FirstKill");
            if (narrator != null)
                narrator.GetComponent<Narrator>().Say();
        }
        else if (counter == killThreshold)
        {
            GameObject narrator = GameObject.Find("AfterXKills");
            if (narrator != null)
                narrator.GetComponent<Narrator>().Say();
        }
    }
    public void countKill()
    {
        counter++;
    }
}
