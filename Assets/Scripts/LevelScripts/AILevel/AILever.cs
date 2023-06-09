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

    // Start is called before the first frame update
    void Start()
    {
        lever = GameObject.Find("Lever");
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= escapeRange)
        {
            lever.GetComponent<Animator>().SetBool("IsRunning", true);
            Vector2 direction = transform.position - player.transform.position;
            rigidBody.velocity = direction.normalized * leverSpeed;
        }
        else
        {
            if (distance > escapeRange + .05f)
                lever.GetComponent<Animator>().SetBool("IsRunning", false);
            rigidBody.velocity = Vector2.zero;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = Vector3.zero;
        lever.GetComponent<Animator>().SetBool("IsRunning", false);
    }
}
