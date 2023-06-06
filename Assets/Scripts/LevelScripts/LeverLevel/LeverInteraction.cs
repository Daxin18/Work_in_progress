using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] //this makes it so we can create object in unity and change all the InteractionMechanic variables
public class LeverInteraction : InteractionMechanic //just a test mechanic to see if everything works
{
    public bool inRange = false;

    public override bool Interact(GameObject parent)
    {
        if (inRange)
        {
            GameObject door = GameObject.Find("Door");
            if (door != null)
            {
                GameObject narrator = GameObject.Find("NarratorManager");
                if (narrator != null)
                    narrator.GetComponent<NarratorManager>().Say("LeverComment");
                GameObject lever = GameObject.Find("Lever");
                if (lever != null)
                {
                    lever.GetComponent<Animator>().SetBool("LeverUp", true);
                }

                //
                // deleting doors in LeverBehaviourManager.cs (aka script for LeverUp state)
                //

                return true;
            }
            else
            {
                //Debug.Log("No door found");
            }
        }
        return false;
    }
}
