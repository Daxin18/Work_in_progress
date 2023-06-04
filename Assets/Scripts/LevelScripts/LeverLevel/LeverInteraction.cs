using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] //this makes it so we can create object in unity and change all the InteractionMechanic variables
public class LeverInteraction : InteractionMechanic //just a test mechanic to see if everything works
{
    public GameObject lever;
    public bool inRange = false;

    public override bool Interact(GameObject parent)
    {
        if (inRange)
        {
            //Rigidbody2D player = parent.GetComponent<Rigidbody2D>();
            GameObject door = GameObject.Find("Door");
            if (door != null)
            {
                GameObject narrator = GameObject.Find("LeverComment");
                if (narrator != null)
                    narrator.GetComponent<Narrator>().Say();
                //TODO: animacja
                Destroy(door);
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
