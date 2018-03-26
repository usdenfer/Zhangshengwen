using UnityEngine;
using UnityEngine.UI;
using RenderHeads.Media.AVProVideo;
using System.Collections;

public class VCR : MonoBehaviour {

    public MediaPlayer _mediaPlayer;

    public Slider _videoSeekSlider;
    private float _setVideoSeekSliderValue;
    bool _wasPlayingOnScrub;

    public GameObject PlayButton;
    public GameObject PauseButton;

    public string[] _videoFiles = { };

    private int _VideoIndex = 0;

    public void OnOpenVideoFile()
    {
        _mediaPlayer.m_VideoPath = string.Empty;
        _mediaPlayer.m_VideoPath = _videoFiles[_VideoIndex];
        _VideoIndex = (_VideoIndex + 1) % (_videoFiles.Length);
        if (string.IsNullOrEmpty(_mediaPlayer.m_VideoPath))
        {
            _mediaPlayer.CloseVideo();
            _VideoIndex = 0;
        }
        else
        {
            _mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, _mediaPlayer.m_VideoPath);
        }
    }
    public void OnPlayButton()
    {
        if (_mediaPlayer)
        {
            _mediaPlayer.Control.Play();
            PlayButton.SetActive(false);
            PauseButton.SetActive(true);
        }
    }
    public void OnPauseButton()
    {
        if (_mediaPlayer)
        {
            _mediaPlayer.Control.Pause();
            PauseButton.SetActive(false);
            PlayButton.SetActive(true);
        }
    }
    public void OnVideoSeekSlider()
    {
        if (_mediaPlayer && _videoSeekSlider && _videoSeekSlider.value != _setVideoSeekSliderValue)
        {
            _mediaPlayer.Control.Seek(_videoSeekSlider.value * _mediaPlayer.Info.GetDurationMs());
        }
    }
    public void OnVideoSliderDown()
    {
        if (_mediaPlayer)
        {
            _wasPlayingOnScrub = _mediaPlayer.Control.IsPlaying();
            if (_wasPlayingOnScrub)
            {
                _mediaPlayer.Control.Pause();
            }
            OnVideoSeekSlider();
        }
    }
    public void OnVideoSliderUp()
    {
        if (_mediaPlayer && _wasPlayingOnScrub)
        {
            _mediaPlayer.Control.Play();
            _wasPlayingOnScrub = false;
        }
    }
    public void OnCloseButton()
    {
        if (_mediaPlayer)
        {
            _mediaPlayer.Control.CloseVideo();
            
        }
    }
    void Start()
    {
        if (_mediaPlayer)
        {
            _mediaPlayer.Events.AddListener(OnVideoEvent);
            //OnOpenVideoFile();

        }
    }
    void Update()
    {
        if (_mediaPlayer && _mediaPlayer.Info != null && _mediaPlayer.Info.GetDurationMs() > 0f)
        {
            float time = _mediaPlayer.Control.GetCurrentTimeMs();
            float d = time / _mediaPlayer.Info.GetDurationMs();
            _setVideoSeekSliderValue = d;
            _videoSeekSlider.value = d;
        }
        if ( _mediaPlayer&&_mediaPlayer.Info!=null&&_mediaPlayer.Control.IsFinished())
        {
            OnCloseButton();
        }
    }
    public void OnVideoEvent(MediaPlayer mp,MediaPlayerEvent.EventType et,ErrorCode errorCode)
    {
        switch (et)
        {
            case MediaPlayerEvent.EventType.ReadyToPlay:
                break;
            case MediaPlayerEvent.EventType.Started:
                break;
            case MediaPlayerEvent.EventType.FirstFrameReady:
                break;
            case MediaPlayerEvent.EventType.FinishedPlaying:
                break;
        }
        Debug.Log("Event:" + et.ToString());
    }

    

    
}
