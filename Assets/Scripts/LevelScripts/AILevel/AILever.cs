using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILever : MonoBehaviour
{
    public float escapeRange = 3.5f;

    private GameObject lever;
    public GameObject player;
    private Rigidbody2D rigidBody;
    public GameObject cage;

    private int cageTeleportThreshold = 5;
    private int teleportCounter = 0;
    private bool caged = false;

    // Start is called before the first frame update
    void Start()
    {
        teleportCounter = 0;
        cage.SetActive(false);
        rigidBody = this.GetComponent<Rigidbody2D>();
        //coroutine to prevent setting lever as a lever from the previous level (which, surprise, breaks the game)
        StartCoroutine(AssignLeverShortlyAfterLoad());
    }

    // Update is called once per frame
    void Update()
    {
        if (!caged)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance <= escapeRange)
            {
                if (lever != null)
                {
                    lever.GetComponent<Animator>().SetBool("IsRunning", true);
                }
            }
            else
            {
                if (distance > escapeRange + .05f)
                {
                    if (lever != null)
                    {
                        lever.GetComponent<Animator>().SetBool("IsRunning", false);
                    }
                }
                rigidBody.velocity = Vector2.zero;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        TeleportToStart();
        if(!caged)
        {
            teleportCounter++;
            if (teleportCounter >= cageTeleportThreshold)
            {
                caged = true;
                lever.GetComponent<Animator>().SetTrigger("Cage");
            }
        }
    }

    public void TeleportToStart()
    {
        transform.position = Vector3.zero;
        lever.GetComponent<Animator>().SetBool("IsRunning", false);
    }

    private IEnumerator AssignLeverShortlyAfterLoad()
    {
        yield return new WaitForSeconds(0.5f);
        lever = GameObject.Find("Lever");
    }
}
