using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class LevelBase : MonoBehaviour
{
    private GameObject finish;
    public GameObject nextLevel; //will be Scene, not yet sure if I it's a GameObject, bur when using Scene all of it breaks


    private void Start()
    {
        finish = GameObject.FindGameObjectWithTag("Finish");
    }
}
