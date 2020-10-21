using UnityEngine;

public class VoiceLines : MonoBehaviour
{
    [System.Serializable]
    public class Audios
    {
        public AudioSource beginRound2, endRound5, nuke, freeze, death;
    }
    public Audios audios;
    public GameObject parentAudios;
    public AudioSource mainAudioSource;
    
    public void SelectAudio(int id)
    {
        if(id == 0)
        {
            StartAudioSource(audios.beginRound2);
        }
        else if(id == 1)
        {
            StartAudioSource(audios.endRound5);
        }
    }
    public void StartAudioSource(AudioSource audio)
    {
        if(audio.clip != null)
        {
            mainAudioSource.clip = audio.clip;
            mainAudioSource.Play();
        }
        else
        {
            print("onee audio clip leeg");
        }
    }
}   
