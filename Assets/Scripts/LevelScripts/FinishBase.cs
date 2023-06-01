using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBase : MonoBehaviour
{
    public int nextLevel = 0;
    public int enteranceCounter = 0; //for safety

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if player manages to enter the collider, exit and enter again we don't want to load the level twice
        if (enteranceCounter == 0 && collision.gameObject.tag == "Player")
        {
            enteranceCounter++;

            //TODO: load next level here

            Debug.Log("Loading level: " + nextLevel);
        }
    }
}