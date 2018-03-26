using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UISpace;

public class ArhatsControl : MonoBehaviour {
    public Button touchArea;
    public Button shareBtn;
    public Button closeBtn;
    public Button shelfBtn;
    public Button voiceBtn;
    public Button langBtn;
    public Button toWholeBtn;
    public Text dialog;
    public GameObject shelf;

    GameObject wholeScroll;
    GameObject pics;

    Image backGround;
    AudioSource backGroundVoice;
    Image idol;

    int i = 1;

    bool isChinese = true;

    private TyAVG NowAr;
    // Use this for initialization
    void Start () {
        GameObject canvas = GameObject.Find("Canvas");
        wholeScroll = canvas.transform.Find("WholeScrollPanel").gameObject;

        shareBtn.onClick.AddListener(delegate ()
        {
            GameObject.Find("Main Camera").GetComponent<ShareWhole>().OnShareClick();
        });
        toWholeBtn.onClick.AddListener(delegate ()
        {
            GameObject.Find("GameController").GetComponent<BackToWhole>().OnBackToWholeClick();
        });
        langBtn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/ChineseTranslation");
        voiceBtn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/PublicUI/Music_Close");
        backGround = GameObject.Find("BackGround").GetComponent<Image>();
        idol = GameObject.Find("Idol").GetComponent<Image>();
        backGroundVoice = GameObject.Find("StoryAudio").GetComponent<AudioSource>();
        NowAr = DataGlobal.GetSubsection(51);
        dialog.text = NowAr.dialogCN;
        Sprite TempSP = new Sprite();
        TempSP = Resources.Load<Sprite>("ArhatsSprite/" + NowAr.backGround.ToString()) as Sprite;
        if (TempSP != null)
        {
            backGround.sprite = TempSP;
        }
        backGround.SetNativeSize();
        Sprite TempPO = new Sprite();
        TempPO = Resources.Load<Sprite>("AVGIdol/" + NowAr.idol.ToString()) as Sprite;
        if (TempPO != null)
        {
            idol.sprite = TempPO;
        }
        backGroundVoice.clip = Resources.Load<AudioClip>("ArhatsAudioClip/" + NowAr.audio);
    }
	public void PushStory()
    {
        i++;
        if (i == 1)
        {
            NowAr = DataGlobal.GetSubsection(51);
            dialog.text = NowAr.dialogCN;
            backGroundVoice.clip = Resources.Load<AudioClip>("ArhatsAudioClip/" + NowAr.audio);
        }
        if (i == 2)
        {
            NowAr = DataGlobal.GetSubsection(52);
            dialog.text = NowAr.dialogCN;         
            backGroundVoice.clip = Resources.Load<AudioClip>("ArhatsAudioClip/" + NowAr.audio);
        }
        if (i == 3)
        {
            NowAr = DataGlobal.GetSubsection(53);
            dialog.text = NowAr.dialogCN;
            backGroundVoice.clip = Resources.Load<AudioClip>("ArhatsAudioClip/" + NowAr.audio);
        }
    }
    public void LanguageChange()
    {
        if (isChinese)
        {
            dialog.text = NowAr.dialogEN;
            isChinese = false;
        }
        else
        {
            dialog.text = NowAr.dialogCN;
            isChinese = true;
        }
    }
    public void VoiceChange()
    {

    }
    public void ToWhole()
    {
        AVGClose();
        wholeScroll.SetActive(true);
    }
    public void AVGClose()
    {
        gameObject.SetActive(false);
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("PartScrollPanel").gameObject.SetActive(true);
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

        if (ID == 1)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnPaintingClick();
            AVGClose();
        }
        else if (ID == 2)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnEmperorClick();
            AVGClose();
        }
        else if (ID == 3)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnKingKongClick();
            AVGClose();
        }
        else if (ID == 4)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnShijiaClick();
            AVGClose();
        }
        else if (ID == 5)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnDragonClick();
            AVGClose();
        }
        else if (ID == 6)
        {
            OnShelfClick();
        }
        else if (ID == 7)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnInheraitClick();
            AVGClose();
        }
        else if (ID == 8)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnMonksClick();
            AVGClose();
        }
        else if (ID == 9)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnDebateClick();
            AVGClose();
        }
        else if (ID == 10)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnMeetingClick();
            AVGClose();
        }
        else if (ID == 11)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnPotraitClick();
            AVGClose();
        }
        else if (ID == 12)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnGuanYinClick();
            AVGClose();
        }
        else if (ID == 13)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnGuanYinPoClick();
            AVGClose();
        }
        else if (ID == 14)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnThirteenClick();
            AVGClose();
        }
        else if (ID == 15)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnGuardianClick();
            AVGClose();
        }
        else if (ID == 16)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnPillarClick();
            AVGClose();
        }
        else if (ID == 17)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnStampClick();
            AVGClose();
        }
        else if (ID == 18)
        {
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnInstrumentsClick();
            AVGClose();
        }
    }
    // Update is called once per frame
    void Update () {
        if (isChinese)
        {
            dialog.text = NowAr.dialogCN;
        }
        else
        {
            dialog.text = NowAr.dialogEN;
        }
	}
}
