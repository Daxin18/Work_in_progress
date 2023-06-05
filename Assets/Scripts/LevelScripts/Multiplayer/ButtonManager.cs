using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public bool ButtonA = false;
    public bool ButtonB = false;
    public GameObject doorPrefab;
    private bool narrateFirstButton = false;
    private bool ableToSay = true;

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

        if (ableToSay && narrateFirstButton)
        {
            ableToSay = false;
            GameObject narrator = GameObject.Find("FirstButton");
            if (narrator != null)
                narrator.GetComponent<Narrator>().Say();
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
        narrateFirstButton = value ? value : narrateFirstButton;
    }
}
