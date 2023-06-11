using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMovementAfterTheTalk : MonoBehaviour
{
    private Narrator narrator;
    private bool enabledMovement = false;

    private void Start()
    {
        narrator = GetComponent<Narrator>();
    }

    public void FixedUpdate()
    {
        if (narrator.alreadySaid)
        {
            if (narrator.isEnded)
            {
                if(!enabledMovement)
                {
                    FirstLevel script = GameObject.FindGameObjectWithTag("First level").GetComponent<FirstLevel>();
                    Debug.Log(script);
                    script.NISInstalled = true;
                    GameObject.Find("Player").GetComponent<playerController>().isMovementBlocked = false;
                    GameObject.Find("Player").GetComponent<MechanicHolder>().isInteractionBlocked = false;
                    enabledMovement = true;
                }
            }
        }
    }
}
