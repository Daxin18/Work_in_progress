using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Collider2D parent;
    private float sizeIncrement = 35f;
    private float maxSize = 10f;

    public void FixedUpdate()
    {
        var size = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(size.x + (sizeIncrement * Time.deltaTime), size.y + (sizeIncrement * Time.deltaTime), size.z);

        //x and y are the same here
        if (gameObject.transform.localScale.x >= maxSize)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != parent && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerController>().Die();
            KillCounter counter = GameObject.FindGameObjectWithTag("Multiplayer").GetComponent<KillCounter>();
            counter.countKill();
        }
    }

    public void SetParent(Collider2D parent)
    {
        this.parent = parent;
    }
}
