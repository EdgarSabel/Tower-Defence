using System.Collections;
using TMPro;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static bool isSetup;
    public AudioSource mainAudioSource;
    public GameObject[] musics;
    public GameObject musicParent;
    public GameObject textHolder;
    public TextMeshProUGUI text;
    public float showTextTime;
    int songNum;
    bool checkIfSongStopped;
    IEnumerator coroutine;

    private void Awake()
    {
        if(isSetup == false)
        {
            isSetup = true;
            DontDestroyOnLoad(this);
            Setup();
        }
        else
        {
            Destroy(this.gameObject);
        }
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
        textHolder.SetActive(false);
        for (int i = 0; i < musics.Length; i++)
        {
            musics[i] = musicParent.transform.GetChild(i).gameObject;
        }
        mainAudioSource.clip = musics[songNum].GetComponent<AudioSource>().clip;
        mainAudioSource.Play();
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = ShowSongName();
        StartCoroutine(coroutine);
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
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = ShowSongName();
        StartCoroutine(coroutine);
        checkIfSongStopped = true;
    }
    IEnumerator ShowSongName()
    {
        text.text = musicParent.transform.GetChild(songNum).gameObject.name;
        textHolder.SetActive(true);
        yield return new WaitForSeconds(showTextTime);
        textHolder.SetActive(false);
    }
}
