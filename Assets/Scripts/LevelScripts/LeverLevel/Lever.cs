using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var interactionScript = (LeverInteraction) collision.gameObject.GetComponent<MechanicHolder>().mechanic;
            interactionScript.inRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var interactionScript = (LeverInteraction)collision.gameObject.GetComponent<MechanicHolder>().mechanic;
            interactionScript.inRange = false;
        }
    }
}
