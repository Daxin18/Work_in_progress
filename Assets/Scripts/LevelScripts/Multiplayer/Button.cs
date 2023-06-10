using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject level;
    public Sprite off;
    public Sprite on;
    public bool isButtonA = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "DeadBody")
        {
            level.GetComponent<ButtonManager>().SetButton(isButtonA, true);
            GetComponent<SpriteRenderer>().sprite = on;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "DeadBody")
        {
            level.GetComponent<ButtonManager>().SetButton(isButtonA, true);
            GetComponent<SpriteRenderer>().sprite = on;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "DeadBody")
        {
            level.GetComponent<ButtonManager>().SetButton(isButtonA, false);
            GetComponent<SpriteRenderer>().sprite = off;
        }
    }
}
