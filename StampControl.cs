using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UISpace;
using DG.Tweening;


public class StampControl : MonoBehaviour {

    public Button touchArea;
    public Button shareBtn;
    public Button closeBtn;
    public Button shelfBtn;
    public Button voiceBtn;
    public Button langBtn;
    public Button toWholeBtn;
    public Text dialog;
    public GameObject shelf;
    public Image kangXiNew;
    public Image postScript1New;
    public Image postScript2New;
    public Image postScript3New;
    public Image postScript4New;
    public Image switchIMG;


    GameObject wholeScroll;
    GameObject pics;

    Image backGround;
    AudioSource backGroundVoice;
    Image idol;

    bool isChinese=true;

    int i = 1;

    TyAVG NowSt;

    bool isTransparent = true;
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
    }
    public void PushStory()
    {
        i++;
        if (i == 1)
        {
            NowSt = DataGlobal.GetSubsection(161);          
        }
        if (i == 2)
        {
            NowSt = DataGlobal.GetSubsection(162);           
        }
        if (i == 3)
        {
            NowSt = DataGlobal.GetSubsection(163);          
        }
        if (i == 4)
        {
            NowSt = DataGlobal.GetSubsection(164);          
        }
        if (i == 5)
        {
            NowSt = DataGlobal.GetSubsection(165);          
        }
        if (i == 6)
        {
            NowSt = DataGlobal.GetSubsection(166);         
        }
        if (i == 7)
        {
            NowSt = DataGlobal.GetSubsection(167);           
        }
        if (i == 8)
        {
            NowSt = DataGlobal.GetSubsection(168);          
        }
        if (i > 0 && i < 9)
        {
            dialog.text = NowSt.dialogCN;
            Sprite TempSP = new Sprite();
            TempSP = Resources.Load<Sprite>("StampSprite/" + NowSt.backGround.ToString()) as Sprite;
            if (TempSP != null)
            {
                backGround.sprite = TempSP;
            }
            Sprite TempPO = new Sprite();
            TempPO = Resources.Load<Sprite>("AVGIdol/" + NowSt.idol.ToString()) as Sprite;
            if (TempPO != null)
            {
                idol.sprite = TempPO;
            }
            backGroundVoice.clip = Resources.Load<AudioClip>("StampAudioClip/" + NowSt.audio);
        }
    }
    public void LanguageChange()
    {
        if (isChinese)
        {
            dialog.text = NowSt.dialogEN;
            isChinese = false;
        }
        else
        {
            dialog.text = NowSt.dialogCN;
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
    public void OnChangeClick()
    {
        if (isTransparent)
        {
            postScript1New.DOColor(new Color(1, 1, 1, 1), 2f);
            postScript2New.DOColor(new Color(1, 1, 1, 1), 2f);
            postScript3New.DOColor(new Color(1, 1, 1, 1), 2f);
            postScript4New.DOColor(new Color(1, 1, 1, 1), 2f);
            kangXiNew.DOColor(new Color(1, 1, 1, 1), 2f);
            isTransparent = false;
            switchIMG.sprite = Resources.Load<Sprite>("StampSprite/UI1");
        }
        else
        {
            postScript1New.DOColor(new Color(1, 1, 1, 0), 2f);
            postScript2New.DOColor(new Color(1, 1, 1, 0), 2f);
            postScript3New.DOColor(new Color(1, 1, 1, 0), 2f);
            postScript4New.DOColor(new Color(1, 1, 1, 0), 2f);
            kangXiNew.DOColor(new Color(1, 1, 1, 0), 2f);
            isTransparent = true;
            switchIMG.sprite = Resources.Load<Sprite>("StampSprite/UI2");
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
            GameObject.Find("PartControl").gameObject.GetComponent<PartScrollControl>().OnArhatsClick();
            AVGClose();
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
            OnShelfClick();
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
            dialog.text = NowSt.dialogCN;
        }
        else
        {
            dialog.text = NowSt.dialogEN;
        }
	}
}
