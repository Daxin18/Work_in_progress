using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] //this makes it so we can create object in unity and change all the InteractionMechanic variables
public class TEST_move_up : InteractionMechanic //just a test mechanic to see if everything works
{
    public override void Interact(GameObject parent)
    {
        //base.Interact(); //not needed, base method is empty
        Rigidbody2D player = parent.GetComponent<Rigidbody2D>();

        player.transform.position += new Vector3(0, 1, 0);
    }
}
