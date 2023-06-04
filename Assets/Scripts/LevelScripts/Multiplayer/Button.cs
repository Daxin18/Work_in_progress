using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject level;
    public bool isButtonA = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            level.GetComponent<ButtonManager>().SetButton(isButtonA, true);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            level.GetComponent<ButtonManager>().SetButton(isButtonA, true);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            level.GetComponent<ButtonManager>().SetButton(isButtonA, false);
    }
}
