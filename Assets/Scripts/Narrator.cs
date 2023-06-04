using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Narrator : MonoBehaviour
{
    public AudioClip audio;
    public string audioText;
    public Text textObject;
    public GameObject canvas;
    public GameObject nextAudio;
    
    private bool alreadySaid = false;
    private AudioSource source;

    public void Start()
    {
        canvas.SetActive(false);
        textObject.text = audioText;
        source = GetComponent<AudioSource>();
        source.clip = audio;
    }

    public void FixedUpdate()
    {
        if(alreadySaid)
        {
            if(!source.isPlaying)
            {
                canvas.SetActive(false);
                if (nextAudio != null)
                {
                    nextAudio.GetComponent<Narrator>().Say();
                }
            }
        }
    }

    public void Say()
    {
        source = GetComponent<AudioSource>();
        if (!source.isPlaying)
        {
            if (!alreadySaid)
            {
                alreadySaid = true;
                source.Play();
                canvas.SetActive(true);
            }
        }
    }
}
