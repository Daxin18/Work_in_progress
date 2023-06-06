using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorManager : MonoBehaviour
{
    public bool isNarratorSpeaking = false;

    private Queue<string> narrators = new Queue<string>();

    void FixedUpdate()
    {
        if (!isNarratorSpeaking)
        {
            if(narrators.Count > 0)
            {
                isNarratorSpeaking = true;
                PlayNarrator(narrators.Dequeue());
            }
        }
    }

    public void Say(string narrator)
    {
        narrators.Enqueue(narrator);
    }

    public void EndSpeech()
    {
        isNarratorSpeaking = false;
    }

    private void PlayNarrator(string narrator)
    {
        GameObject narr = GameObject.Find(narrator);
        if (narr != null)
            narr.GetComponent<Narrator>().Say();
    }

}
