using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMechanic : ScriptableObject
{
    public string name; //name of a mechanic or level it's used on
    public float cooldownTime; //cooldown, only added for an attack mechanic in local multiplayer level, set it to 0 or some super small value in other levels

    public virtual void Interact(GameObject parent) { } //method that dictates what the interaction will do
}
