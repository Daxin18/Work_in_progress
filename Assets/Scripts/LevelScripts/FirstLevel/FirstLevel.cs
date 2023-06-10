using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel : MonoBehaviour
{
    public float waitTime = 3f;

    public bool NISInstalled = false; //NIS - New Input System
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        player.GetComponent<MechanicHolder>().isInteractionBlocked = true;
        StartCoroutine(WaitForInstall());
    }

    private void Update()
    {
        if(!NISInstalled)
        {
            player.GetComponent<playerController>().isMovementBlocked = true;
        }
    }

    private IEnumerator WaitForInstall()
    {
        yield return new WaitForSeconds(waitTime);
        NarratorManager narrator = GameObject.Find("NarratorManager").GetComponent<NarratorManager>();
        narrator.Say("AfterXSeconds");
    }

}
