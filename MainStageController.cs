using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RenderHeads.Media.AVProVideo;

public class MainStageController : MonoBehaviour
{
    void HandleInsetsForScreenOreitationDelegate(global::UniWebView webView, global::UniWebViewOrientation orientation)
    {

    }

    public GameObject index;
    public GameObject menu;
    public GameObject history;
    public GameObject daliStory;
    public GameObject subsection;
    public GameObject partScroll;
    public GameObject wholeScroll;
    public GameObject worldStage;
    public GameObject video;
    public GameObject copyRightPage;
    public GameObject tradition;
    public GameObject pics;
    public GameObject flash;

    public MediaPlayer _video;



    bool isEnter = false;

    GameObject Avg;
    
    GameObject Emp;

	private UniWebView webView;

    void Start()
    {
        copyRightPage.SetActive(false);
    }
#region 目录页面
    public void OnAppreciationClick()//点击赏析按钮
    {
        index.SetActive(false);
        menu.SetActive(true);
    }
    public void OnMenuClose()
    {
        menu.SetActive(false);
        index.SetActive(true);
    }
    public void OnHistoryClick()//点击历史按钮
    {
        history.SetActive(true);
        index.SetActive(false);
    }
    public void OnHistoryClose()
    {
        history.SetActive(false);
        index.SetActive(true);
    }
    public void OnStoreClick()//点击商城按钮
    {
#if UNITY_ANDROID
		if(webView == null){
			var webViewObject = GameObject.Find("WebView");
			if (webViewObject == null)
			{
				webViewObject = new GameObject("WebView");
			}
			webView = webViewObject.AddComponent<UniWebView>();
		}
        webView.OnLoadComplete += OnLoadComplete;
        webView.Show();
        webView.toolBarShow = false;       
        webView.url = "http://118.190.20.41:8080/zsw/cityinfo.html";
        webView.Load();
#elif UNITY_IPHONE
        if(webView == null){
			var webViewObject = GameObject.Find("WebView");
			if (webViewObject == null)
			{
				webViewObject = new GameObject("WebView");
			}
			webView = webViewObject.AddComponent<UniWebView>();
		}
        webView.OnLoadComplete += OnLoadComplete;
        webView.Show();
        webView.insets.bottom = 20;
        webView.toolBarShow = true;       
        webView.url = "http://118.190.20.41:8080/zsw/cityinfo.html";
        webView.Load();
        
#else
        Application.OpenURL("http://118.190.20.41:8080/zsw/cityinfo.html"); 
#endif
    }
    void OnLoadComplete(UniWebView webView, bool success, string errorMessage)
    {
        if (success)
        {
            webView.Show();
        }
        else
        {
            Debug.Log("Something went wrong" + errorMessage);
        }
    }
#endregion
#region 文献页面
    public void OnCopyRightClick()
    {
        if (isEnter == false)
        {
            copyRightPage.SetActive(true);
            iTween.MoveFrom(copyRightPage, iTween.Hash("y", 10, "time", 1));
            isEnter = true;
        }
        else
        {

            iTween.MoveTo(copyRightPage, iTween.Hash("y", 10, "time", 1,"oncomplete","OnCopyRightClose","oncompletetarget",gameObject));
            isEnter = false;
        }
    }
    void OnCopyRightClose()
    {
        copyRightPage.SetActive(false);
        copyRightPage.transform.position = new Vector3(0, 0, 0);
    }
#endregion
#region 画卷赏析菜单
    public void OnWholeSrollClick()
    {
        wholeScroll.SetActive(true);
        menu.SetActive(false);
    }
    public void OnPartScrollClick()
    {
        partScroll.SetActive(true);
        menu.SetActive(false);
    }

#endregion
#region 大理故事
    public void OnDaliStoryClick()
    {
        daliStory.SetActive(true);
        history.SetActive(false);
    }
    public void OnDaliStoryClose()
    {
        daliStory.SetActive(false);
        history.SetActive(true);
    }
#endregion
#region 画卷故事
    public void OnStoryClick()
    {
        video.SetActive(true);
        history.SetActive(false);
        //video.GetComponent<VideoCtrl>().StoryStart();
        _video.Control.Play();
    }
    public void OnStoryClose()

    {
        StartCoroutine(CloseVideo());
    }
    IEnumerator CloseVideo()
    {
        yield return new WaitForSeconds(0.1f);
        video.SetActive(false);
        history.SetActive(true);
        _video.Control.Seek(0f);
        //_video.Control.Stop();
    }

#endregion
#region 文化溯源
    public void OnCultureClick()
    {
        worldStage.SetActive(true);
        history.SetActive(false);
    }
    public void OnCultureClose()
    {
        worldStage.SetActive(false);
        history.SetActive(true);
    }
#endregion
#region 传统文化
    public void OnTraditionClick()
    {
        tradition.SetActive(true);
        history.SetActive(false);
    }
    public void OnTraditionClose()
    {
        tradition.SetActive(false);
        history.SetActive(true);
    }
#endregion
#region 全卷欣赏
    public void OnWholeScrollClose()
    {
        wholeScroll.SetActive(false);
        menu.SetActive(true);
    }
#endregion
#region 分卷赏析
    public void OnPartScrollClose()
    {
        partScroll.SetActive(false);
        menu.SetActive(true);
    }   
    //从分卷到全卷
    public void BackToWhole()
    {
        subsection.SetActive(false);
        wholeScroll.SetActive(true);     
    }
#endregion

    private void Update()
    {

    }

}