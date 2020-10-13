using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneScript : MonoBehaviour
{
    public GameObject loadingScreen;
    private void Awake()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
    }
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public void LoadLevel1()
    {
        loadingScreen.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync("MainMenu"));
        scenesLoading.Add(SceneManager.LoadSceneAsync("BeauScene", LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }

    public IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }
        loadingScreen.SetActive(false);
    }
}
