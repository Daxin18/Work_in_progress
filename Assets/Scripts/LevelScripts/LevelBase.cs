using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class LevelBase : MonoBehaviour
{
    private GameObject finish;
    public GameObject nextLevel; //leaving it like this for now - it's supposed to be a scene


    private void Start()
    {
        finish = GameObject.FindGameObjectWithTag("Finish");
    }
}
