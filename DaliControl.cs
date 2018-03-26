using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UISpace;

public class DaliControl : MonoBehaviour
{
    public GameObject bookMark;
    public GameObject mask;
    public GameObject content;
    public GameObject cover;
    public GameObject bookMarkPanel;
    public GameObject languageButton;
    public GameObject coverLanguageButton;
    public GameObject boat;

    public GameObject flash1;
  
    public Text coverContent;
    public Text coverTitle;
    public Text guide;

    public Image backGround;
    public Text title;
    public Scrollbar scrollBar;
    public Button bookMarkButton;

    bool isChinese = true;

    private TyDaliStory NowDali;
    private float ContentPos;


    private void Start()
    {

        if (ES2.Exists("DaliLanguage"))
        {
            isChinese = ES2.Load<bool>("DaliLanguage");
        }
        NowDali = DataGlobal.GetDaliStory(1);
        coverContent.text = NowDali.coverContentCN;
        coverTitle.text = NowDali.coverTitleCN;
        guide.text = NowDali.guideCN;

        bookMarkButton.onClick.AddListener(delegate ()
        {
            OnBookMarkPageClick(1);
        });
        coverLanguageButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/DaliUI/ChineseTranslation");
        languageButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/DaliUI/ChineseTranslation");
        ContentChange();
    }
    public void Init()
    {
        boat.SetActive(true);
        iTween.MoveFrom(boat, iTween.Hash("x", 3, "time", 15f, "easetype", "easeoutcubic"));
    }
    public void BackFromCover(){
        iTween.Stop(boat);
        boat.transform.localPosition = new Vector2(-100, -200);
        boat.SetActive(false);
    }
    public void OnCoverClick()
    {
        flash1.SetActive(false);    

        if (ES2.Exists("ContentPosition"))
        {
            ContentPos = ES2.Load<float>("ContentPosition");
        }
        else
        {
            ContentPos = 0;
        }
        iTween.Stop(boat);
        boat.transform.localPosition = new Vector2(-100, -200);
        boat.SetActive(false);
        iTween.MoveTo(cover, iTween.Hash("y", 10, "time", 1));
        if (isChinese)
        {
            NowDali = DataGlobal.GetDaliStory(1);
            content.GetComponent<Text>().text = NowDali.contentCN;
            content.transform.localPosition = new Vector3(0, ContentPos);
            title.fontSize = 52;
            title.text = NowDali.titleCN;
        }
        else
        {
            NowDali = DataGlobal.GetDaliStory(1);
            content.GetComponent<Text>().text = NowDali.contentEN;
            content.transform.localPosition = new Vector3(0, ContentPos);
            title.fontSize = 40;
            title.text = NowDali.titleEN;
        }
    }
    #region 内容切换
    public void ContentChange()
    {
        if (content.transform.localPosition.y >= 0 && content.transform.localPosition.y < 370)//名词释义--风物志
        {
            bookMarkBtnChange(1);
            NowDali = DataGlobal.GetDaliStory(1);
        }
        else if (content.transform.localPosition.y >= 370 && content.transform.localPosition.y < 1326)//妙香佛国
        {
            bookMarkBtnChange(2);
            NowDali = DataGlobal.GetDaliStory(2);            
        }
        else if (content.transform.localPosition.y >= 1326 && content.transform.localPosition.y < 2300)//南诏国1，2段
        {
            bookMarkBtnChange(3);
            NowDali = DataGlobal.GetDaliStory(3);          
        }
        else if (content.transform.localPosition.y >= 2300 && content.transform.localPosition.y < 3860)
        {//南诏国3，4段
            bookMarkBtnChange(3);
            NowDali = DataGlobal.GetDaliStory(4);          
        }
        else if (content.transform.localPosition.y >= 3860 && content.transform.localPosition.y < 6022)
        {//大理国1，2段
            bookMarkBtnChange(4);
            NowDali = DataGlobal.GetDaliStory(5);            
        }
        else if (content.transform.localPosition.y >= 6022 && content.transform.localPosition.y < 7540)
        {//大理国3，4段
            bookMarkBtnChange(4);
            NowDali = DataGlobal.GetDaliStory(6);           
        }
        else if (content.transform.localPosition.y >= 7540 && content.transform.localPosition.y < 8620)
        {//大理国第5段
            bookMarkBtnChange(4);
            NowDali = DataGlobal.GetDaliStory(7);            
        }
        else if (content.transform.localPosition.y >= 8620 && content.transform.localPosition.y < 9300)
        {//火烧松明楼第1段
            bookMarkBtnChange(5);
            NowDali = DataGlobal.GetDaliStory(8);        
        }
        else if (content.transform.localPosition.y >= 9300 && content.transform.localPosition.y < 10290)
        {//火烧松明楼第2段
            bookMarkBtnChange(5);
            NowDali = DataGlobal.GetDaliStory(9);           
        }
        else if (content.transform.localPosition.y >= 10290 && content.transform.localPosition.y < 10700)
        {//火烧松明楼第3段
            bookMarkBtnChange(6);
            NowDali = DataGlobal.GetDaliStory(10);          
        }
        else if (content.transform.localPosition.y >= 10700 && content.transform.localPosition.y < 11460)
        {//天宝之战1，2段
            bookMarkBtnChange(6);
            NowDali = DataGlobal.GetDaliStory(11);        
        }
        else if (content.transform.localPosition.y >= 11460 && content.transform.localPosition.y < 12450)
        {//天宝之战第3，4，5段
            bookMarkBtnChange(6);
            NowDali = DataGlobal.GetDaliStory(12);
           
        }
        else if (content.transform.localPosition.y >= 12450 && content.transform.localPosition.y < 13425)
        {//天宝之战第6段
            bookMarkBtnChange(6);
            NowDali = DataGlobal.GetDaliStory(13);                  
        }
        else if (content.transform.localPosition.y >= 13425 && content.transform.localPosition.y < 15450)
        {//皇室崇佛1，2段
            bookMarkBtnChange(7);
            NowDali = DataGlobal.GetDaliStory(14);                 
        }
        else if (content.transform.localPosition.y >= 15450 && content.transform.localPosition.y < 16660)
        {//皇室崇佛3，4段
            bookMarkBtnChange(7);
            NowDali = DataGlobal.GetDaliStory(15);          
        }
        else if (content.transform.localPosition.y >= 16660 && content.transform.localPosition.y < 17450)
        {//皇室与权臣
            bookMarkBtnChange(8);
            NowDali = DataGlobal.GetDaliStory(16);            
        }
        else if (content.transform.localPosition.y >= 17450 && content.transform.localPosition.y < 18100)
        {//江湖情1，2段
            bookMarkBtnChange(9);
            NowDali = DataGlobal.GetDaliStory(17);           
        }
        Sprite TempSP = new Sprite();
        TempSP = Resources.Load<Sprite>("DaLiSprite/" + NowDali.backGround.ToString()) as Sprite;
        if (TempSP != null)
            backGround.sprite = TempSP;
    }
    
    public void bookMarkBtnChange(int ID)
    {
        bookMarkButton.onClick.RemoveAllListeners();
        bookMarkButton.onClick.AddListener(delegate ()
        {
            OnBookMarkPageClick(ID);
        });
    }
    
    #endregion
    public void LanguageChange()
    {
        NowDali = DataGlobal.GetDaliStory(1);
        if (isChinese)
        {          
            coverContent.text = NowDali.coverContentEN;
            coverTitle.text = NowDali.coverTitleEN;
            guide.text = NowDali.guideEN;
            title.text = NowDali.titleEN;
            title.fontSize = 40;
            content.GetComponent<Text>().text = NowDali.contentEN;
            content.GetComponent<ScrollRect>().StopMovement();
            coverLanguageButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/DaliUI/EnglishTranslation");
            languageButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/DaliUI/EnglishTranslation");
            isChinese = false;
        }
        else
        {
            coverContent.text = NowDali.coverContentCN;
            coverTitle.text = NowDali.coverTitleCN;
            guide.text = NowDali.guideCN;
            title.text = NowDali.titleCN;
            title.fontSize = 70;
            content.GetComponent<Text>().text = NowDali.contentCN;
            content.GetComponent<ScrollRect>().StopMovement();
            coverLanguageButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/DaliUI/ChineseTranslation");
            languageButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/DaliUI/ChineseTranslation");
            isChinese = true;
        }
    }

    public void OnBookMarkPageClick(int ID)//点击书签后跳转位置也需要调整
    {
        switch (ID)
        {
            case 1:               
                bookMarkPanel.transform.localPosition = new Vector3(152.5f, 0, 0);
                flash1.SetActive(true);
                break;
            case 2:             
                bookMarkPanel.transform.localPosition = new Vector3(152.5f, 0, 0);               
                break;
            case 3:                
                bookMarkPanel.transform.localPosition = new Vector3(152.5f, 140, 0);                
                break;
            case 4:                
                bookMarkPanel.transform.localPosition = new Vector3(152.5f, 326, 0);              
                break;
            case 5:                
                bookMarkPanel.transform.localPosition = new Vector3(152.5f, 489, 0);               
                break;
            case 6:                
                bookMarkPanel.transform.localPosition = new Vector3(152.5f, 1253, 0);             
                break;
            case 7:                
                bookMarkPanel.transform.localPosition = new Vector3(152.5f, 1575, 0);                
                break;
            case 8:                
                bookMarkPanel.transform.localPosition = new Vector3(152.5f, 1815, 0);                
                break;
            case 9:
                bookMarkPanel.transform.localPosition = new Vector3(152.5f, 2115, 0);               
                break;           
        }
        if (ID > 0 && ID < 10)
        {
            iTween.MoveTo(bookMark, iTween.Hash("x", 5, "time", 1.2f));
            iTween.MoveTo(mask, iTween.Hash("y", 5, "time", .2f));
        }
        else
        {
            return;
        }

    }
    public void OnBlankClick()
    {
        iTween.MoveTo(bookMark, iTween.Hash("x", 10, "time", 2f));
        iTween.MoveTo(mask, iTween.Hash("y", -5, "time", .2f));
     
    }
    public void OnBookMarkClick(int index)//书签点击后跳转
    {
        switch (index)
        {
            case 1:
                NowDali = DataGlobal.GetDaliStory(1);
                iTween.MoveTo(content, iTween.Hash("y", 7, "time", 1f));
                OnBlankClick();
                break;
            case 2:
                NowDali = DataGlobal.GetDaliStory(2);
                iTween.MoveTo(content, iTween.Hash("y", 39, "time", 1f));
                OnBlankClick();
                break;
            case 3:
                NowDali = DataGlobal.GetDaliStory(3);
                iTween.MoveTo(content, iTween.Hash("y", 90, "time", 1f));
                OnBlankClick();
                break;
            case 4:
                NowDali = DataGlobal.GetDaliStory(4);
                iTween.MoveTo(content, iTween.Hash("y", 123, "time", 1f));
                OnBlankClick();
                break;
            case 5:
                NowDali = DataGlobal.GetDaliStory(5);
                iTween.MoveTo(content, iTween.Hash("y", 100, "time", 1f));
                OnBlankClick();
                break;
            case 6:
                NowDali = DataGlobal.GetDaliStory(6);
                iTween.MoveTo(content, iTween.Hash("y", 100, "time", 1f));
                OnBlankClick();
                break;
            case 7:
                NowDali = DataGlobal.GetDaliStory(7);
                iTween.MoveTo(content, iTween.Hash("y", 100, "time", 1f));
                OnBlankClick();
                break;
            case 8:
                NowDali = DataGlobal.GetDaliStory(8);
                iTween.MoveTo(content, iTween.Hash("y", 100, "time", 1f));
                OnBlankClick();
                break;
            case 9:
                NowDali = DataGlobal.GetDaliStory(9);
                iTween.MoveTo(content, iTween.Hash("y", 100, "time", 1f));
                OnBlankClick();
                break;
            default:
                Debug.Log(123);
                break;
        }
    }
    public void OnClose()
    {
        cover.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        ES2.Save(content.transform.localPosition.y, "ContentPosition");
    }
    private void Update()
    {
       
    }
#if UNITY_IPHONE||UNITY_ANDROID
    public void OnApplicationPause()
    {
        ES2.Save(content.transform.localPosition.y, "ContentPosition");
        ES2.Save(isChinese, "Languagechange");
    }
    public void OnApplicationQuit()
    {
        ES2.Save(content.transform.localPosition.y, "ContentPosition");
        ES2.Save(isChinese, "Languagechange");
    }
#else
    public void OnApplicationQuit()
    {
        ES2.Save(content.transform.localPosition.y, "ContentPosition");
        ES2.Save(isChinese, "Languagechange");
    }
#endif
}
