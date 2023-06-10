using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicHolder : MonoBehaviour
{
    public InteractionMechanic mechanic;
    float cooldownTime;

    public bool isInteractionBlocked = false;

    enum InteractionState
    {
        ready,
        cooldown
    }
    InteractionState state = InteractionState.ready;

    
    void FixedUpdate()
    {
        if(state == InteractionState.cooldown)
        {
            if (cooldownTime > 0)
            {
                cooldownTime = Math.Max((cooldownTime - Time.deltaTime), 0f);
            }
            else
            {
                state = InteractionState.ready;
            }
        }
    }

    public void _Interact()
    {
        if(!isInteractionBlocked)
        {
            if (state == InteractionState.ready)
            {
                if (mechanic != null)
                {
                    bool success = mechanic.Interact(gameObject); //aka self
                    if (success)
                    {
                        state = InteractionState.cooldown;
                        cooldownTime = mechanic.cooldownTime;
                    }
                }
            }
        }
    }
}
