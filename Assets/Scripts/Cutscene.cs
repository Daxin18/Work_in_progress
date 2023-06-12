using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
    [SerializeField] string videoFileName;
    public GameObject next;

    void Start()
    {
        PlayVideo();
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


    public void PlayVideo()
    {
        VideoPlayer vp = GetComponent<VideoPlayer>();

        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        Debug.Log(videoPath);
        vp.url = videoPath;
        vp.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        if(next != null)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            Instantiate(next);
            Destroy(gameObject);
        }
        else
        {
            PlayerPrefs.SetInt("Level", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
