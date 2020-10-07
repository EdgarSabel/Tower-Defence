using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource mainAudioSource;
    public GameObject[] musics;
    public GameObject musicParent;
    public int songNum;
    bool checkIfSongStopped;

    private void Start()
    {
        Setup();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            mainAudioSource.Stop();
        }
        if (mainAudioSource.isPlaying == false && checkIfSongStopped == true)
        {
            checkIfSongStopped = false;
            StartNewSong();
        }
    }

    void Setup()
    {
        for (int i = 0; i < musics.Length; i++)
        {
            musics[i] = musicParent.transform.GetChild(i).gameObject;
        }
        mainAudioSource.clip = musics[songNum].GetComponent<AudioSource>().clip;
        mainAudioSource.Play();
        checkIfSongStopped = true;
    }
    void StartNewSong()
    {
        songNum++;
        if(songNum == musics.Length)
        {
            songNum = 0;
        }
        mainAudioSource.clip = musics[songNum].GetComponent<AudioSource>().clip;
        mainAudioSource.Play();
        checkIfSongStopped = true;
    }
}
