using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] //this makes it so we can create object in unity and change all the InteractionMechanic variables
public class AttackInteraction : InteractionMechanic
{

    public GameObject attackPrefab;

    public override bool Interact(GameObject parent)
    {
        var attack = Instantiate(attackPrefab);
        attack.GetComponent<Attack>().SetParent(parent.GetComponent<Collider2D>());
        attack.transform.position = parent.transform.position;

        return true;
    }
}
