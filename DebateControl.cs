﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UISpace;

public class DebateControl : MonoBehaviour {

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

    private TyAVG NowDe;

    void Start()
    {
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
        NowDe = DataGlobal.GetSubsection(81);
        dialog.text = NowDe.dialogCN;
        Sprite TempSP = new Sprite();
        TempSP = Resources.Load<Sprite>("DebateSprite/" + NowDe.backGround.ToString()) as Sprite;
        if (TempSP != null)
        {
            backGround.sprite = TempSP;
        }
        backGround.SetNativeSize();
        Sprite TempPO = new Sprite();
        TempPO = Resources.Load<Sprite>("AVGIdol/" + NowDe.idol.ToString()) as Sprite;
        if (TempPO != null)
        {
            idol.sprite = TempPO;
        }
        backGroundVoice.clip = Resources.Load<AudioClip>("DebateAudioClip/" + NowDe.audio);
    }
    public void PushStory()
    {
        i++;
        if (i == 1)
        {
            NowDe = DataGlobal.GetSubsection(81);
        }
        if (i == 2)
        {
            NowDe = DataGlobal.GetSubsection(82);           
        }
        if (i == 3)
        {
            NowDe = DataGlobal.GetSubsection(83);                             
        }
        if (i > 0 && i < 4)
        {
            dialog.text = NowDe.dialogCN;
            backGroundVoice.clip = Resources.Load<AudioClip>("DebateAudioClip/" + NowDe.audio);
        }else if (i == 3)
        {
            Sprite TempSP = new Sprite();
            TempSP = Resources.Load<Sprite>("DebateSprite/" + NowDe.backGround.ToString()) as Sprite;
            if (TempSP != null)
            {
                backGround.sprite = TempSP;
            }
            backGround.SetNativeSize();          
        }
    }
    public void LanguageChange()
    {
        if (isChinese)
        {
            dialog.text = NowDe.dialogEN;
            isChinese = false;
        }
        else
        {
            dialog.text = NowDe.dialogCN;
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
            OnShelfClick();
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
    private void Update()
    {
       
    }
}
