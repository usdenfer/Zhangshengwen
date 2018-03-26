using UnityEngine;
using System.Collections;
using RenderHeads.Media.AVProVideo;
using UnityEngine.SceneManagement;


public class PlayVideo : MonoBehaviour
{

    public MediaPlayer _mediaPlayer;

    public GameObject skipBtn;
    private AsyncOperation async;


    bool isplaying = false;


    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        async = SceneManager.LoadSceneAsync("MainStage");
        async.allowSceneActivation = false;
        if (_mediaPlayer)
        {
            _mediaPlayer.m_VideoPath = "Story.mp4";
            _mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, _mediaPlayer.m_VideoPath);
            isplaying = true;
        }
        skipBtn.SetActive(false);
    }

    public void Touch()
    {
        skipBtn.SetActive(true);
    }

    void Update()
    {

        if (isplaying && _mediaPlayer != null)
        {
            if (_mediaPlayer.Control.IsFinished())
            {
                Load();
            }
        }
        else
        {
            return;
        }
    }
    public void Load()
    {
        StartCoroutine(MainMenuLoad());
    }
    IEnumerator MainMenuLoad()
    {
        yield return new WaitForSeconds(.5f);
        async.allowSceneActivation = true;
    }


}