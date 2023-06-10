using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBorder : MonoBehaviour
{
    private GameObject block;
    private GameObject backBlock;

    private void Start()
    {
        block = GameObject.Find("Block");
        backBlock = GameObject.Find("BackwardsBlock");
        backBlock.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "AILever")
        {
            collision.GetComponent<AILever>().TeleportToStart();
        }
        else if(collision.gameObject.tag == "Player")
        {
            backBlock.SetActive(true);
            NarratorManager narrator = GameObject.Find("NarratorManager").GetComponent<NarratorManager>();
            narrator.Say("OnDoorWalkthrough");
            StartCoroutine(WaitAndOpen());
        }
    }

    private IEnumerator WaitAndOpen()
    {
        yield return new WaitForSeconds(5);
        block.SetActive(false);
    }
}
