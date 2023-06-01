using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBase : MonoBehaviour
{
    public GameObject currentLevel;
    public GameObject nextLevel;
    public int enteranceCounter = 0; //for safety

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if player manages to enter the collider, exit and enter again we don't want to load the level twice
        if (enteranceCounter == 0 && collision.gameObject.tag == "Player")
        {
            enteranceCounter++;

            //TODO: load next level here
            Instantiate(nextLevel);
            Destroy(currentLevel);

            //Debug.Log("Loading level: " + nextLevel);
        }
    }
}
