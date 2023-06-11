using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
    public GameObject FirstLevel;

    void Start()
    {
        StartCoroutine(WaitAndSay());
        gameObject.GetComponent<VideoPlayer>().loopPointReached += EndReached;
    }

    IEnumerator WaitAndSay()
    {
        yield return new WaitForSeconds(0.05f);
        GameObject narrator = GameObject.Find("NarratorManager");
        if (narrator != null)
            narrator.GetComponent<NarratorManager>().Say("Intro");
    }

    void EndReached(VideoPlayer vp)
    {
        Instantiate(FirstLevel);
        Destroy(gameObject);
    }
}
