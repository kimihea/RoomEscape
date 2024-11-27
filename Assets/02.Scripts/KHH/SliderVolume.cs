using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public string targetVolume;
    public Slider slider;
    public string s_PlayerPrefs;
    public void Start()
    {
        slider.value = PlayerPrefs.GetFloat(s_PlayerPrefs, 0.7f);
    }
    public void SetVolume(float sliderVal)
    {
        mixer.SetFloat(targetVolume, Mathf.Log10(sliderVal) * 20);
        PlayerPrefs.SetFloat(s_PlayerPrefs, sliderVal);
        PlayerPrefs.Save();
    }
}
