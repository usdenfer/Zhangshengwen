using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using RenderHeads.Media.AVProVideo;
using UnityEngine.UI;

public class VideoCtrl : MonoBehaviour {

    public GameObject historyPanel;
    public GameObject videoPanel;
    public GameObject uipanel;
    private bool isEnter=false;
    public MediaPlayer _mediaPlayer;
    public Slider _videoSlider;

    bool isPlaying = true;

    private void Start()
    {
        uipanel.SetActive(false);
    }
    public void OnClick() { 
        if (isEnter)
        {          
            iTween.MoveTo(uipanel,iTween.Hash("y",-5,"time",1f,"oncomplete","OnUIClose","oncompletetarget",gameObject));
            isEnter = false;
        }
        else
        {
            uipanel.SetActive(true);
            iTween.MoveTo(uipanel,iTween.Hash("y",-3,"time",1f));
            isEnter = true;
        }
    }
    public void OnClose()
    {
            uipanel.SetActive(false);
            uipanel.transform.localPosition = new Vector2(0, -370);
            isEnter = false;
            isPlaying = false;
            _mediaPlayer.Control.Stop();      
    }
    void OnUIClose()
    {
        uipanel.SetActive(false);
    }
    void Update()
    {
		if (isPlaying&& _mediaPlayer != null) {
			if (_mediaPlayer.Control == null || _mediaPlayer.Info == null)
				return;
			float currentTime = _mediaPlayer.Control.GetCurrentTimeMs() / 1000;
			if (_mediaPlayer.Info.GetDurationMs() / 1000 - currentTime < 3f)
				Load();
		}
    }
    public void Load()
    {
        OnClose();     
        videoPanel.SetActive(false);
        historyPanel.SetActive(true); 
        _mediaPlayer.Control.Seek(0f);
        //_mediaPlayer.Control.Stop();
        

    }
    




}
