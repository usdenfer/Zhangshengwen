using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class WholeScrollUIControl : MonoBehaviour
{

    public GameObject wholeScroll;
    public GameObject pics;
    public GameObject nameButton;
    public GameObject backButton;
    public GameObject maskPanel;
    public GameObject closeButton;

    public GameObject bgm;

    public GameObject uiPanel;


    bool isEnter = false;
    bool isScroll = false;

    void Start()
    {
        backButton.SetActive(false);
        maskPanel.SetActive(false);
        closeButton.SetActive(false);
    }
    public void OnClick()
    {
        if (isScroll)
        {
            isScroll = false;
            return;
        }
        if (isEnter)
        {          
            iTween.MoveTo(uiPanel, iTween.Hash("y", -7, "time", 1f));
            backButton.SetActive(false);
            closeButton.SetActive(false);
            isEnter = false;
            maskPanel.SetActive(false);
            uiPanel.SetActive(false);
        }
        else
        {
            uiPanel.SetActive(true);
            iTween.MoveTo(uiPanel, iTween.Hash("y", -3.3, "time", 1f));
            backButton.SetActive(true);
            iTween.MoveFrom(backButton, iTween.Hash("x", -12, "time", 1f));
            closeButton.SetActive(true);
            isEnter = true;
            maskPanel.SetActive(true);

        }
    }

    public void OnScroll()
    {
        isScroll = true;
    }

    public void PlayAudio(GameObject go)
    {
        if (bgm.GetComponent<AudioSource>().isPlaying)
        {
            bgm.GetComponent<AudioSource>().Pause();
            go.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/PublicUI/Music_Close");
        }
        else
        {
            bgm.GetComponent<AudioSource>().Play();
            go.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/PublicUI/Music_Open");
        }
    }
    public void OnClose()
    {
        //Tween.MoveTo(uiPanel,iTween.Hash("y",-7,"time",0.001f));
        uiPanel.SetActive(false);
        uiPanel.transform.localPosition = new Vector3(0, -500);
        backButton.SetActive(false);
        closeButton.SetActive(false);
        isEnter = false;
        maskPanel.SetActive(false);
        Invoke("ClosePanel", 0.3f);
    }
    public void ClosePanel()
    {
        FindObjectOfType<MainStageController>().OnWholeScrollClose();
    }


    void Update()
    {
        //Debug.Log(uiPanel.transform.localPosition);
    }


}





