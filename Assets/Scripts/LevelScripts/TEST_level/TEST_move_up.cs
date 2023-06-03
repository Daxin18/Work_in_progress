using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] //this makes it so we can create object in unity and change all the InteractionMechanic variables
public class TEST_move_up : InteractionMechanic //just a test mechanic to see if everything works
{

    public override void Interact(GameObject parent)
    {
        GameObject narrator = GameObject.Find("Narrator");
        narrator.GetComponent<Narrator>().Say();
    }
}
