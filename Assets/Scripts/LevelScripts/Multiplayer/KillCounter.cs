using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public int counter = 0;
    public int killThreshold = 30;

    private bool saidFK = false;
    private bool saidAXK = false;

    public void Start()
    {
        counter = 0;
    }
    public void FixedUpdate()
    {
        if (counter == 1)
        {
            if (!saidFK)
            {
                GameObject narrator = GameObject.Find("NarratorManager");
                if (narrator != null)
                    narrator.GetComponent<NarratorManager>().Say("FirstKill");
                saidFK = true;
            }
            UnlockPlayer2();
        }
        else if (counter == killThreshold)
        {
            if(!saidAXK)
            {
                GameObject narrator = GameObject.Find("NarratorManager");
                if (narrator != null)
                    narrator.GetComponent<NarratorManager>().Say("AfterXKills");
                saidAXK = true;
            }
        }
    }
    public void countKill()
    {
        counter++;
    }

    private void UnlockPlayer2()
    {
        var player = GameObject.Find("Player_2");
        if(player != null)
        {
            player.GetComponent<playerController>().isMovementBlocked = false;
            player.GetComponent<MechanicHolder>().isInteractionBlocked = false;
        }
    }
}
