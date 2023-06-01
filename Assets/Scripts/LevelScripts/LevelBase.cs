using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class LevelBase : MonoBehaviour
{
    public GameObject finish;
    public GameObject nextLevel;

    private int id = 0; //level identification

    //may want to change some stuff here - the class is barely needed
    private void Start()
    {
        //there must be a way to do it more elegantly, but it'll do for now
        foreach (Transform child in gameObject.transform)
        {
            if (child.tag == "Squad Member")
            {
                finish = child.gameObject;
                break;
            }
        }
        var finishScript = finish.GetComponent<FinishBase>();
        finishScript.currentLevel = gameObject;
        finishScript.nextLevel = nextLevel;
        finishScript.enteranceCounter = 0;
    }
}
