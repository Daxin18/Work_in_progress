using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu] //this makes it so we can create object in unity and change all the InteractionMechanic variables
public class TimeTravelInteraction : InteractionMechanic
{
    public bool inRange = false;
    public int tooMuchTravel = 30;

    private Transform now;
    private Transform future;

    public override bool Interact(GameObject parent)
    {
        var isGloveOn = GameObject.FindGameObjectWithTag("TimeTravel").GetComponent<TimeTravelTracking>().isGloveOn;
        if (isGloveOn)
        {
            int travelCount = GameObject.FindGameObjectWithTag("TimeTravel").GetComponent<TimeTravelTracking>().incrementTravelCount();
            if (travelCount == 1)
                CommentEvent("FirstTimeTravel");
            if (travelCount == tooMuchTravel)
                CommentEvent("TooMuchTravel");
            Vector3 helper = now.position;
            now.position = future.position;
            future.position = helper;
            return true;
        }
        else if (inRange)
        {
            CommentEvent("GlovePickup");
            GameObject.FindGameObjectWithTag("TimeTravel").GetComponent<TimeTravelTracking>().TakeGlove();
            now = GameObject.Find("Now").transform;
            future = GameObject.Find("Future").transform;
            return true;
        }
        return false;
    }

    private void CommentEvent(string narratedEvent)
    {
        GameObject narrator = GameObject.Find("NarratorManager");
        if (narrator != null)
            narrator.GetComponent<NarratorManager>().Say(narratedEvent);
    }
}