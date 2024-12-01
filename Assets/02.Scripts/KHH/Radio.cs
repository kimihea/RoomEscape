using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Radio: MonoBehaviour
{
    public TextMeshProUGUI m_TextMeshPro;
    public List<AudioClip> audioClips;
    private AudioSource audioSource;
    private int currentClipIndex = 0;

    public float scrollSpeed = 2f;
    private Vector3 originalPosition;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[currentClipIndex];
        UpdateMusicName(currentClipIndex);
        audioSource.Play();
        audioSource.playOnAwake = true;
        audioSource.loop = true;
        originalPosition = m_TextMeshPro.transform.position;
        

    }
    private void Update()
    {
        if (m_TextMeshPro.rectTransform.localPosition.x < 28f)
        {
            m_TextMeshPro.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }
        else
        {
            m_TextMeshPro.transform.position = originalPosition;
            Debug.Log("Reset");
        }
    }

    public void PauseClip()
    {
        if(audioSource.isPlaying)
            audioSource.Stop();
        else
            audioSource.Play();
    }
    [MenuItem("Tools/PlayNextBgm")]
    public void PlayNextBgmClip()
    {
        currentClipIndex = (currentClipIndex + 1) % audioClips.Count;
        UpdateMusicName(currentClipIndex);
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();
    }
    public void PlayPreviousBgmClip()
    {
        currentClipIndex = (currentClipIndex - 1) % audioClips.Count;
        UpdateMusicName(currentClipIndex);
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();
    }
    void UpdateMusicName(int index)
    {
        string musicName;
        musicName = audioClips[index].name;
        m_TextMeshPro.text = musicName;
    }

}

