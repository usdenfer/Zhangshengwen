using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using DataLoader;
using TableData;
using RenderHeads.Media.AVProVideo;

public class AppStart : MonoBehaviour {

    public MediaPlayer mediaPlayer;
    //private DtWholeScroll NowWholeScroll;

    private void Start()
    {
        LoadAllTableDatas();
        
    }
    void LoadAllTableDatas()
    {

#if UNITY_ANDROID && !UNITY_EDITOR
        WholeScrollData.PrepareLoadFile(Application.streamingAssetsPath+"/tb_WholeScroll.csv");
        DaliStoryData.PrepareLoadFile(Application.streamingAssetsPath+"/tb_DaliStory.csv");
        WorldEventData.PrepareLoadFile(Application.streamingAssetsPath+"/tb_WorldEvent.csv");
		SubsectionData.PrepareLoadFile(Application.streamingAssetsPath+"/tb_Subsection.csv");
        LiteratureData.PrepareLoadFile(Application.streamingAssetsPath+"/tb_Literature.csv");
        TraditionalData.PrepareLoadFile(Application.streamingAssetsPath+"/tb_TraditionalCulture.csv");
        //EmperorData.PreloaFile(Application.streamingAssetsPath+"/tb_Emperor.csv");     
#else
        WholeScrollData.PrepareLoadFile("file://" + Application.streamingAssetsPath + "/tb_WholeScroll.csv");
        DaliStoryData.PrepareLoadFile("file://" + Application.streamingAssetsPath + "/tb_DaliStory.csv");
        WorldEventData.PrepareLoadFile("file://" + Application.streamingAssetsPath + "/tb_WorldEvent.csv");
		SubsectionData.PrepareLoadFile("file://"+Application.streamingAssetsPath+"/tb_Subsection.csv");
        LiteratureData.PrepareLoadFile("file://" + Application.streamingAssetsPath + "/tb_Literature.csv");
        TraditionalData.PrepareLoadFile("file://" + Application.streamingAssetsPath + "/tb_TraditionalCulture.csv");

#endif
        FileLoader.Loader.StartLoad(StartLoadingScene);
    }
    void StartLoadingScene()
    {
        UISpace.DataGlobal.InitData();
     
            StartCoroutine("LoadingScene");
        
    }
    IEnumerator LoadingScene()
    {
        
            yield return new WaitForSeconds(10f);
            SceneManager.LoadSceneAsync("Video");
        
    }
   
}

