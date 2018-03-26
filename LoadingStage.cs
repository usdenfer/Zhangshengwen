using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingStage : MonoBehaviour
{
    private AsyncOperation async;

    // Use this for initialization
    void Start()
    {
        async = SceneManager.LoadSceneAsync("MainStage");
        async.allowSceneActivation = false;
        LoadStage();
    }
    public void LoadStage()
    {
        StartCoroutine(StartLoading());
    }
    private IEnumerator StartLoading()
    {
        while (async.progress == 0.9f)
            yield return new WaitForSeconds(4f);
        LoadComplete();
    }
    public void LoadComplete()
    {
        async.allowSceneActivation = true;
    }



}
