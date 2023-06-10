using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILever : MonoBehaviour
{
    public float escapeRange = 3.5f;
    public float leverSpeed = 5f;

    private GameObject lever;
    public GameObject player;
    private Rigidbody2D rigidBody;

    private bool alreadySaid = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        //coroutine to prevent setting lever as a lever from the previous level (which, surprise, breaks the game)
        StartCoroutine(AssignLeverShortlyAfterLoad());
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= escapeRange)
        {
            if(lever != null)
            {
                lever.GetComponent<Animator>().SetBool("IsRunning", true);
            }
            Vector2 direction = transform.position - player.transform.position;
            rigidBody.velocity = direction.normalized * leverSpeed;
            if(!alreadySaid)
            {
                NarratorManager narrator = GameObject.Find("NarratorManager").GetComponent<NarratorManager>();
                narrator.Say("FirstRun");
                alreadySaid = true;
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        TeleportToStart();
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
