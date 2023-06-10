using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject player;
    public GameObject grid;
    public GameObject PROMPT;

    public static int interactionCounter = 0;

    private int iterationMinRange = 3;
    private int iterationMaxRange = 7;

    private float waitMinRange = 0.1f;
    private float waitMaxRange = 0.5f;

    private float movementRange = 1.5f;
    private float promptAfter = 16f;

    // Start is called before the first frame update
    void Start()
    {
        PROMPT.SetActive(false);
        interactionCounter = 0;

        StartCoroutine(WaitForPrompt());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Do(int i)
    {
        Debug.Log(i);
        StartCoroutine(Shake(i + 1));
    }

    private IEnumerator WaitForPrompt()
    {
        yield return new WaitForSeconds(promptAfter);

        GameObject.Find("Player").GetComponent<MechanicHolder>().isInteractionBlocked = false;
        PROMPT.SetActive(true);
    }

    private IEnumerator Shake(int i)
    {
        GameObject narrator = GameObject.Find("NarratorManager");
        if (narrator != null)
            narrator.GetComponent<NarratorManager>().Say("X_" + i);

        int iterations = Random.Range(iterationMinRange, iterationMaxRange);

        for(int j=0; j < iterations; j++)
        {
            float playerOffsetX = Random.Range(-movementRange, movementRange);
            float playerOffsetY = Random.Range(-movementRange, movementRange);
            float gridOffsetX = Random.Range(-movementRange, movementRange);
            float gridOffsetY = Random.Range(-movementRange, movementRange);

            player.gameObject.transform.position = new Vector2(player.gameObject.transform.position.x + playerOffsetX,
                                                                player.gameObject.transform.position.y + playerOffsetY);
            grid.gameObject.transform.position = new Vector2(grid.gameObject.transform.position.x + gridOffsetX,
                                                                grid.gameObject.transform.position.y + gridOffsetY);

            yield return new WaitForSeconds(0.2f);

            player.gameObject.transform.position = new Vector2(player.gameObject.transform.position.x - playerOffsetX,
                                                    player.gameObject.transform.position.y - playerOffsetY);
            grid.gameObject.transform.position = new Vector2(grid.gameObject.transform.position.x - gridOffsetX,
                                                                grid.gameObject.transform.position.y - gridOffsetY);

            yield return new WaitForSeconds(Random.Range(waitMinRange, waitMaxRange));
        }
    }
}
