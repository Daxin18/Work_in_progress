using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] //this makes it so we can create object in unity and change all the InteractionMechanic variables
public class EndingInteraction : InteractionMechanic
{
    public override bool Interact(GameObject parent)
    {
        if(EndingManager.interactionCounter == 6)
        {
            //play cutscene here
        }
        else
        {
            GameObject.FindGameObjectWithTag("ENDING").GetComponent<EndingManager>().Do(EndingManager.interactionCounter++);
            return true;
        }
        return false;
    }
}
