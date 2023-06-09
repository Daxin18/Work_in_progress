using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    private SpriteRenderer box;
    public List<GameObject> required;
    public bool isSatisfy = false;
    public bool isReady = false;
    public GameObject next;
    public GameObject arrow;
    public bool IsDestination = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (arrow != null)
        {
            arrow.SetActive(false);
        }
        box = GetComponent<SpriteRenderer>();
        box.color = new Color(0.75f, 0.75f, 0.75f);
        CheckIfReady();
        if (IsDestination)
        {
            //GameObject.FindGameObjectWithTag("Player").SetActive(true);
            player.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckIfReady()
    {
        if (isSatisfy) return false;
        foreach (GameObject previous in required)
        {
            if (!previous.GetComponent<Box>().isSatisfy) return false;
        }
        box.color = new Color(1f, 1f, 1f);
        isReady = true;
        if (IsDestination)
        {
            //GameObject.FindGameObjectWithTag("Player").SetActive(true);
            player.SetActive(true);
        }
        return true;
    }

    public void Focus()
    {
        box.color = new Color(0.8f, 0.8f, 1f) ;
    }

    public void UnFocus()
    {
        box.color = new Color(1f, 1f, 1f);
    }

    public bool CheckIfIsNext(GameObject gameObject)
    {
        return gameObject == next;
    }

    public void Satisfy()
    {
        isSatisfy = true;
        isReady = false;
        arrow.SetActive(true);
        //arrow.transform.position = Vector3.zero;
    }
}
