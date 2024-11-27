using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    GameObject audioObject;
    AudioSource audioSource;
    AudioSource effectAudioSource;
    public List<AudioClip> audioClips;
    private int currentClipIndex = 0;

    private AudioMixer audioMixer;
    private AudioMixerGroup musicGroup;
    private AudioMixerGroup effectsGroup;

    public static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<AudioManager>();
                    singletonObject.name = typeof(AudioManager).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        LoadAudioComponent();
    }
    void Start()
    {
        //add BgmClips
        //audioClips.Add(Resources.Load<AudioClip>("AudioSource/Music/Dream"));
        
    }

    private void LoadAudioComponent()
    {
        //init audiosources
        audioMixer = Resources.Load<AudioMixer>("AudioSource/NewAudioMixer");
        musicGroup = audioMixer.FindMatchingGroups("Master")[1];
        effectsGroup = audioMixer.FindMatchingGroups("Master")[2];

        audioObject = new GameObject("AudioSource");
        audioObject.transform.SetParent(this.transform);

        audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = musicGroup;
        audioSource.maxDistance = 5f;

        effectAudioSource = audioObject.AddComponent<AudioSource>();
        effectAudioSource.outputAudioMixerGroup = effectsGroup;
    }



    public void PlayEffect(string effectName)
    {
        AudioClip myClip = Resources.Load<AudioClip>("AudioSource/Effect/" + effectName);
        if (myClip != null)
        {
            effectAudioSource.PlayOneShot(myClip);
            //Debug.Log("AudioClip 로드 성공: " + myClip.name);
        }
        else
        {
            //Debug.LogError("AudioClip 로드 실패");
        }
    }
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextBgmClip();
        }
    }
    void PlayNextBgmClip()
    {
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();
        currentClipIndex = (currentClipIndex + 1) % audioClips.Count;

    }
}
