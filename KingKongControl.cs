using UnityEngine;
using UnityEngine.UI;
using UISpace;
using System.Collections;

public class KingKongControl : MonoBehaviour {

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

    bool isChinese = true;

    int i = 1;
   
    private TyAVG NowKK;

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
        NowKK = DataGlobal.GetSubsection(21);
        dialog.text = NowKK.dialogCN;
        Sprite TempSP = new Sprite();
        TempSP = Resources.Load<Sprite>("KingKongSprite/" + NowKK.backGround.ToString()) as Sprite;
        if (TempSP != null)
        {
            backGround.sprite = TempSP;
        }
        backGround.SetNativeSize();
        Sprite TempPO = new Sprite();
        TempPO = Resources.Load<Sprite>("AVGIdol/" + NowKK.idol.ToString()) as Sprite;
        if (TempPO != null)
        {
            idol.sprite = TempPO;
        }
        backGroundVoice.clip = Resources.Load<AudioClip>("KingKongAudioClip/" + NowKK.audio);
    }
    public void LanguageChange()
    {
        if (isChinese)
        {
            dialog.text = NowKK.dialogEN;
            isChinese = false;
        }
        else
        {
            dialog.text = NowKK.dialogCN;
            isChinese = true;
        }
    }
    public void PushStory()
    {
        i++;
        if (i == 1)
        {
            NowKK = DataGlobal.GetSubsection(21);           
        }
        if (i == 2)
        {
            NowKK = DataGlobal.GetSubsection(22);           
        }
        if (i == 3)
        {
            NowKK = DataGlobal.GetSubsection(23);           
        }
        if (i == 4)
        {
            NowKK = DataGlobal.GetSubsection(24);          
        }
        if (i == 5)
        {
            NowKK = DataGlobal.GetSubsection(25);          
            iTween.ScaleTo(backGround.gameObject, new Vector3(2, 2, 2), 3f);
            iTween.MoveTo(backGround.gameObject, iTween.Hash("y", 7, "time", 3f));            
        }
        if (i == 6)
        {
            NowKK = DataGlobal.GetSubsection(26);            
        }
        if (i == 7)
        {
            NowKK = DataGlobal.GetSubsection(27);          
            iTween.ScaleTo(backGround.gameObject, new Vector3(1, 1, 1), 3f);
            iTween.MoveTo(backGround.gameObject,new Vector3(0,0,0),3f);                
        }
        if (i > 0 && i < 8)
        {
            dialog.text = NowKK.dialogCN;
            backGroundVoice.clip = Resources.Load<AudioClip>("KingKongAudioClip/" + NowKK.audio);
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
            OnShelfClick();
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
            if (isChinese)
            {
                dialog.text = NowKK.dialogCN;
            }
            else
            {
                dialog.text = NowKK.dialogEN;
            }
        }
    

}
