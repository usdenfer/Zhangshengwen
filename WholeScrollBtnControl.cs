using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UISpace;


public class WholeScrollBtnControl : MonoBehaviour
{
    public GameObject pics;
    public GameObject nameBtn;
    public GameObject contentPanel;
    public GameObject wholeScroll;
    public GameObject voiceBtn;
    public Button partBtn;
    public Button languageButton;

    public GameObject Painting;
    public GameObject Emperor;
    public GameObject KingKong;
    public GameObject Shijia;
    public GameObject Dragon;
    public GameObject Arhats;
    public GameObject Inherait;
    public GameObject Monks;
    public GameObject Debate;
    public GameObject Meeting;
    public GameObject Potrait;
    public GameObject GuanYin;
    public GameObject GuanYinPotrait;
    public GameObject ThirteenEmperors;
    public GameObject Guardian;
    public GameObject Pillar;
    public GameObject Stamp;
    public GameObject Instruments;

    private float picsX;

    public Scrollbar scrollBar;

    public Text content, title, buttonName,titleEN;
    public Image Icon;

    public AudioSource NowAudio;



    private TyWholeScroll NowWhole;

    bool isPlaying = false;

    public int num = 0;

    bool isChinese = true;

   
    private void Start()
    {
        Image langSp = languageButton.gameObject.GetComponent<Image>();
        langSp.sprite = Resources.Load<Sprite>("UI/WorldUI/ChineseTranslation");
    }
    public void init()
    {

        if (ES2.Exists("WholePosition"))
        {
            picsX = ES2.Load<float>("WholePosition");
        }
        else
        {
            picsX = 25000;
        }
        pics.transform.localPosition = new Vector3(picsX, 0);
        NowWhole = DataGlobal.GetWholeScroll(1);
        buttonName.text = NowWhole.buttonName;
        Sprite TempSP = new Sprite();
        TempSP = Resources.Load<Sprite>(NowWhole.iconID.ToString()) as Sprite;
        if (TempSP != null)
            Icon.sprite = TempSP;
    }
    #region 内容切换
    public void onBtnChange()//滑动以切换名牌显示
    {
		int ChangeID = 0;
        if (pics.transform.localPosition.x < 27220)//乾隆题字
        {            
			ChangeID = 1;
        }
        else if (pics.transform.localPosition.x >= 27220 && pics.transform.localPosition.x < 29310)//利贞皇帝礼佛图
        {          
			ChangeID = 2;
        }
        else if (pics.transform.localPosition.x >= 29310 && pics.transform.localPosition.x < 30000)//金刚力士图
        {            
			ChangeID = 3;
        }
        else if (pics.transform.localPosition.x >= 30000 && pics.transform.localPosition.x < 30560)//释迦降魔图
        {            
			ChangeID = 4;
        }
        else if (pics.transform.localPosition.x >= 30560 && pics.transform.localPosition.x < 34505)//龙众与天众图
        {            
			ChangeID = 5;
        }
        else if (pics.transform.localPosition.x >= 34505 && pics.transform.localPosition.x < 39400)//十六罗汉图
        {            
			ChangeID = 6;
        }
        else if (pics.transform.localPosition.x >= 39400 && pics.transform.localPosition.x < 42400)//法脉传承图
        {           
			ChangeID = 7;
        }
        else if (pics.transform.localPosition.x >= 42400 && pics.transform.localPosition.x < 44890)//大理国八大高僧图
        {           
			ChangeID = 8;
        }
        else if (pics.transform.localPosition.x >= 44890 && pics.transform.localPosition.x < 46150)//维摩诘辩经图
        {            
			ChangeID = 9;
        }
        else if (pics.transform.localPosition.x >= 46150 && pics.transform.localPosition.x < 51700)//三大佛会图
        {            
			ChangeID = 10;
        }
        else if (pics.transform.localPosition.x >= 51700 && pics.transform.localPosition.x < 53280)//诸佛群相图
        {            
			ChangeID = 11;
        }
        else if (pics.transform.localPosition.x >= 53280 && pics.transform.localPosition.x < 54830)//云南福星阿嵯耶观音
        {           
			ChangeID = 12;
        }
        else if (pics.transform.localPosition.x >= 54830 && pics.transform.localPosition.x < 58570)//观音群相图1
        {            
			ChangeID = 13;
        }
        else if (pics.transform.localPosition.x >= 58570 && pics.transform.localPosition.x < 58880)//大理国历代皇帝图
        {           
			ChangeID = 14;
        }
        else if (pics.transform.localPosition.x >= 58880 && pics.transform.localPosition.x < 62000)//观音群相图2
        {           
			ChangeID = 15;
        }
        else if (pics.transform.localPosition.x >= 62000 && pics.transform.localPosition.x < 66700)//护法群相图
        {           
			ChangeID = 16;
        }
        else if (pics.transform.localPosition.x >= 66700 && pics.transform.localPosition.x < 69240)//经幢与十六国大众图
        {           
			ChangeID = 17;         
        }
		if (NowWhole != null && ChangeID == NowWhole.ID)
			return;
		NowWhole = DataGlobal.GetWholeScroll(ChangeID);         
		buttonName.text = NowWhole.buttonName;
		nameBtn.GetComponent<RectTransform>().sizeDelta = new Vector2(85, 180+30*NowWhole.buttonName.Length);
    }
    #endregion
    #region 内容面板控制
    public void OnPartClick()//分卷跳转
    {
		if (num == 1) {
			return;                  
		} else {
			UIGlobal.ShowPartScroll (num);
		}

    }
    public void LanguageChange()
    {
        Image langSp = languageButton.gameObject.GetComponent<Image>();
        if (isChinese)
        {
            content.text = NowWhole.contentEN;
            langSp.sprite = Resources.Load<Sprite>("UI/WorldUI/EnglishTranslation");
            isChinese = false;
        }
        else
        {
            content.text = NowWhole.contentCN;
            langSp.sprite = Resources.Load<Sprite>("UI/WorldUI/ChineseTranslation");
            isChinese = true;
        }
    }

    public void OnClose()
    {
        if (num == 1)
            return;
        contentPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, 750, 0);
        wholeScroll.SetActive(false);
        
        if (isPlaying == true)
        {
            NowAudio.Stop();
            isPlaying = false;
        }
    }
    public void OnBtnClick()
    {
        iTween.MoveTo(contentPanel, iTween.Hash("y", 0, "time", .8));
    }
    public void OnCloseClick()
    {
        if (isPlaying == true)
        {
            NowAudio.Stop();
            isPlaying = false;
        }
        iTween.MoveTo(contentPanel, iTween.Hash("y", 10, "time", .8));

    }
    #endregion
    #region 内容页功能
    public void OnContentClick()
    {
		num = NowWhole.ID;
		content.text = NowWhole.contentCN;
		title.text = NowWhole.titleCN;
		titleEN.text = NowWhole.titleEN;
		NowAudio.clip = (AudioClip)Resources.Load("AudioClip/" + NowWhole.audioName);
    }
    #endregion
    #region 内容语音控制
    public void OnAudioPlay()
    {
        if (isPlaying == false)
        {
            NowAudio.Play();
            isPlaying = true;
        }
        else
        {
            NowAudio.Stop();
            isPlaying = false;
        }
    }
    #endregion
    private void Update()
    {
        onBtnChange();
      
    }
    #region 保存
#if UNITY_IPHONE || UNITY_ANDROID
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            ES2.Save(pics.GetComponent<Transform>().localPosition.x, "WholePosition");
        }
    }
    private void OnApplicationQuit()
    {
        ES2.Save(pics.GetComponent<Transform>().localPosition.x, "WholePosition");
    }

#else
    private void OnApplicationQuit()
    {
        ES2.Save(pics.GetComponent<Transform>().localPosition.x, "WholePosition");
    }
#endif
#endregion


}

