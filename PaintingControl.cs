using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UISpace;

public class PaintingControl : MonoBehaviour {

    public Button touchArea;
    public Button shareBtn;
    public Button closeBtn;
    public Button shelfBtn;
    public Button voiceBtn;
    public Button langBtn;
    public Text dialog;
    public GameObject shelf;

    Image backGround;
    AudioSource backGroundVoice;
    Image idol;
    bool isChinese=true;
    bool isPlaying = false;


    int i = 1;
    private TyAVG NowPa;

    // Use this for initialization
    void Start () {
        shareBtn.onClick.AddListener(delegate ()
        {
            GameObject.Find("Main Camera").GetComponent<ShareWhole>().OnShareClick();
        });
        langBtn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/ChineseTranslation");
        voiceBtn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/PublicUI/Music_Close");
        backGround = GameObject.Find("BackGround").GetComponent<Image>();
        idol = GameObject.Find("Idol").GetComponent<Image>();
        backGroundVoice = GameObject.Find("StoryAudio").GetComponent<AudioSource>();
        PushStory();
    }
    public void PushStory()
    {
        i++;
        if (isChinese) {
            if (i == 1)
            {
                NowPa = DataGlobal.GetSubsection(1);               
            }
            if (i == 2)
            {
                NowPa = DataGlobal.GetSubsection(2);             
            }
            if (i == 3)
            {
                NowPa = DataGlobal.GetSubsection(3);             
            }
            if (i == 4)
            {
                NowPa = DataGlobal.GetSubsection(4);            
            }
            if (i == 5)
            {
                NowPa = DataGlobal.GetSubsection(5);              
            }
            if (i > 0 && i < 6)
            {
                dialog.text = NowPa.dialogCN;
                Sprite TempSP = new Sprite();
                TempSP = Resources.Load<Sprite>("PaintingSprite/" + NowPa.backGround.ToString()) as Sprite;
                if (TempSP != null)
                {
                    backGround.sprite = TempSP;
                }
                Sprite TempPO = new Sprite();
                TempSP = Resources.Load<Sprite>("AVGIdol/" + NowPa.idol.ToString()) as Sprite;
                if (TempPO != null)
                {
                    idol.sprite = TempPO;
                }
                backGroundVoice.clip = Resources.Load<AudioClip>("PaintingAudioClip/" + NowPa.audio);
            }
         }
    }
    public void LanguageChange()
    {
        switch (isChinese)
        {
            case true:
                langBtn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/EnglishTranslation");
                isChinese = false;
                break;
            case false:
                langBtn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/ChineseTranslation");
                isChinese = true;
                break;
        }
    }
    public void VoiceChange()
    {
        if (isPlaying)
        {
            voiceBtn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/PublicUI/Music_Close");
            backGroundVoice.Stop();
            isPlaying = false;
        }
        else
        {
            voiceBtn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/PublicUI/Music_Open");
            backGroundVoice.Play();
            isPlaying = true;
        }
        
    }
    public void AVGClose()
    {
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("PartScrollPanel").gameObject.SetActive(true);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    bool isEnter = false;
    public void OnShelfClick()
    {
        if (!isEnter)
        {
            iTween.MoveTo(shelf, iTween.Hash("y", -5, "time", 1));
            isEnter = true;
        }
        else
        {
            iTween.MoveTo(shelf, iTween.Hash("y", 5, "time", 1));
            isEnter = false;
        }
    }
    public void ShelfItemClick(int ID)
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (ID == 1)
        {
            OnShelfClick();
        }else if (ID == 2)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnEmperorClick();
            AVGClose();
        }else if (ID == 3)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnKingKongClick();
            AVGClose();
        }else if (ID == 4)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnShijiaClick();
            AVGClose();
        }else if (ID == 5)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnDragonClick();
            AVGClose();
        }else if (ID == 6)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnArhatsClick();
            AVGClose();
        }else if (ID == 7)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnInheraitClick();
            AVGClose();
        }else if (ID == 8)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnMonksClick();
            AVGClose();
        }else if (ID == 9)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnDebateClick();
            AVGClose();
        }else if (ID == 10)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnMeetingClick();
            AVGClose();
        }else if (ID == 11)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnPotraitClick();
            AVGClose();
        }else if (ID == 12)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnGuanYinClick();
            AVGClose();
        }else if (ID == 13)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnGuanYinPoClick();
            AVGClose();
        }else if (ID == 14)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnThirteenClick();
            AVGClose();
        }else if (ID == 15)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnGuardianClick();
            AVGClose();
        }else if (ID == 16)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnPillarClick();
            AVGClose();
        }else if (ID == 17)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnStampClick();
            AVGClose();
        }else if (ID == 18)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnInstrumentsClick();
            AVGClose();
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
