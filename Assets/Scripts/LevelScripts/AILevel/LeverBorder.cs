using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBorder : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "AILever")
        {
            collision.GetComponent<AILever>().TeleportToStart();
        }
        else if(collision.gameObject.tag == "Player")
        {
            NarratorManager narrator = GameObject.Find("NarratorManager").GetComponent<NarratorManager>();
            narrator.Say("OnDoorWalkthrough");
        }
    }
}
