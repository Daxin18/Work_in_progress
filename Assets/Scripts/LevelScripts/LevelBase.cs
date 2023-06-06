using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LevelBase : MonoBehaviour
{
    public GameObject finish;
    public GameObject nextLevel;

    private int id = 0; //don't really think it's useful, but gonna leave it here for now

    //may want to change some stuff here - the class is barely needed
    private void Start()
    {
        //there must be a way to do it more elegantly, but it'll do for now
        foreach (Transform child in gameObject.transform)
        {
            if (child.tag == "Finish")
            {
                finish = child.gameObject;
                break;
            }
        }
        var finishScript = finish.GetComponent<FinishBase>();
        finishScript.currentLevel = gameObject;
        finishScript.nextLevel = nextLevel;
        finishScript.enteranceCounter = 0;

        //first narrator text in the level has to be named Intro
        StartCoroutine(WaitAndSay());
    }

    IEnumerator WaitAndSay()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject narrator = GameObject.Find("NarratorManager");
        if (narrator != null)
            narrator.GetComponent<NarratorManager>().Say("Intro");
    }
}
