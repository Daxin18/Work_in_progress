using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMovementAfterTheTalk : MonoBehaviour
{
    private AudioSource source;
    private Narrator narrator;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        narrator = GetComponent<Narrator>();
    }

    public void FixedUpdate()
    {
        if (narrator.alreadySaid)
        {
            if (!source.isPlaying)
            {
                if (!narrator.isEnded)
                {
                    FirstLevel script = GameObject.Find("First level").GetComponent<FirstLevel>();
                    script.NISInstalled = true;
                    GameObject.Find("Player").GetComponent<playerController>().isMovementBlocked = false;
                    GameObject.Find("Player").GetComponent<MechanicHolder>().isInteractionBlocked = false;
                }
            }
        }
    }
}
