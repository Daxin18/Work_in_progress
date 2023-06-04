using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public bool ButtonA = false;
    public bool ButtonB = false;
    public GameObject doorPrefab;

    public void FixedUpdate()
    {
        var door = GameObject.FindGameObjectWithTag("Door");
        if (ButtonA && ButtonB)
        {
            if(door != null)
            {
                Destroy(door);
            }
        }
        else
        {
            if(door == null)
            {
                Instantiate(doorPrefab);
            }
        }
    }

    public void SetButton(bool isButtonA, bool value)
    {
        if (isButtonA)
        {
            ButtonA = value;
        }
        else
        {
            ButtonB = value;
        }
    }
}
