using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataFlowController : MonoBehaviour
{
    private Box start = null;
    private Box end = null;

    public float timeThreshold = 20f;
    private float timer = 0f;
    private bool alreadyConnected = false;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.FindGameObjectWithTag("Player").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= timeThreshold)
        {
            if(!alreadyConnected)
            {
                NarratorManager narrator = GameObject.Find("NarratorManager").GetComponent<NarratorManager>();
                narrator.Say("NoConnect");
            }
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.transform.CompareTag("DataFlow"))
            {
                start = hit.transform.GetComponent<Box>();
                if (start.isReady) start.Focus();
                else start = null;
            }
        }

        if (start != null && Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.transform.CompareTag("DataFlow"))
            {
                end = hit.transform.GetComponent<Box>();
                if (start.CheckIfIsNext(hit.transform.gameObject))
                {
                    alreadyConnected = true;
                    start.Satisfy();
                    end.CheckIfReady();
                }
            }
            start.UnFocus();
            start = null;
        }
    }
}
