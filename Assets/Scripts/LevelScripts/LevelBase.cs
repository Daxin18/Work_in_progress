using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class LevelBase : MonoBehaviour
{
    private GameObject finish;
    private GameObject sceneManager;

    private int id = 0; //level identification
    private int nextLevelId = 1; //next level, makes it easier to swap levels in game

    //may want to change some stuff here - the class is barely needed
    private void Start()
    {
        finish = GameObject.FindGameObjectWithTag("Finish");
        finish.GetComponent<FinishBase>().nextLevel = nextLevelId;
    }
}
