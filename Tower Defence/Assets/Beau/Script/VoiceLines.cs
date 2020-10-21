using System.Collections.Generic;
using UnityEngine;

public class VoiceLines : MonoBehaviour
{
    public List<AudioSource> audios = new List<AudioSource>();
    public GameObject parentAudios;
    public AudioSource mainAudioSource;
    public int currentAudio;
    private void Start()
    {
        foreach(Transform child in parentAudios.transform)
        {
            audios.Add(child.GetComponent<AudioSource>());
        }
        StartAudioSource();
    }
    public void StartAudioSource()
    {
        mainAudioSource.clip = audios[currentAudio].clip;
        mainAudioSource.Play();
        currentAudio++;
    }
}   
