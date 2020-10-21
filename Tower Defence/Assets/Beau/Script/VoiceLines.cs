using UnityEngine;

public class VoiceLines : MonoBehaviour
{
    public AudioSource beginRound, endRound, nuke, freeze, death;
    public GameObject parentAudios;
    public AudioSource mainAudioSource;
    private void Start()
    {
        
    }
    public void StartAudioSource(AudioSource audio)
    {
        mainAudioSource.clip = audio.clip;
        mainAudioSource.Play();
    }
}   
