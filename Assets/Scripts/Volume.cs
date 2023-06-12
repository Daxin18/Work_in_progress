using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider volumeSlider;
    public Text volumeText;

    // Start is called before the first frame update
    void Start()
    {
        float volumeValue = PlayerPrefs.HasKey("VolumeValue") ? PlayerPrefs.GetFloat("VolumeValue") : 0.33f;
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    // Update is called once per frame
    void Update()
    {
        float volumeValue = volumeSlider.value;
        
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        AudioListener.volume = volumeValue;
        volumeText.text = (int)(volumeValue * 100) + "%"; 
    }
}
