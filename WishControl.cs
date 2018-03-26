using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UISpace;


public class WishControl : MonoBehaviour {

    public Button firstWish;
    public Button secondWish;
    public Button thirdWish;
    public Button forthWish;
    public Button fifthWish;
    public Button sixthWish;
    public Button seventhWish;
    public Button eighthWish;
    public Button ninthWish;
    public Button tenthWish;
    public Button eleventhWish;
    public Button twelfthWish;
    public Button langBtn;

    public GameObject content;
    public GameObject mask;
    public GameObject avg;
    public Text dialog;

    GameObject c;

    bool isChinese = true;

    int num;

    TyAVG NowWish;

   

    // Use this for initialization
    void Start () {
        mask.SetActive(false);
        avg.SetActive(false);
        langBtn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/ChineseTranslation");
        langBtn.gameObject.SetActive(false);
        
    }
	public void OnFirstClick()
    {
        num = 1;
        NowWish = DataGlobal.GetSubsection(201);
        c = Instantiate(content);
        c.GetComponent<Image>().sprite = Resources.Load<Sprite>("WishSprite/FirstWish");
        c.transform.SetParent(gameObject.transform);
        c.transform.localPosition = new Vector3(0, 103, 0);
        c.transform.localScale = new Vector3(1, 1, 1);
        iTween.ScaleFrom(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1));
        iTween.MoveFrom(c, new Vector3(firstWish.transform.position.x, firstWish.transform.position.y, 0), 1f);
        BtnShow();
    }
    public void OnSecondClick()
    {
        num = 2;
        NowWish = DataGlobal.GetSubsection(202);
        c = Instantiate(content);
        c.GetComponent<Image>().sprite = Resources.Load<Sprite>("WishSprite/SecondWish");
        c.transform.SetParent(gameObject.transform);
        c.transform.localPosition = new Vector3(0, 103, 0);
        c.transform.localScale = new Vector3(1, 1, 1);
        iTween.ScaleFrom(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1));
        iTween.MoveFrom(c, new Vector3(secondWish.transform.position.x, secondWish.transform.position.y, 0), 1f);
        BtnShow();
    }
    public void OnThirdClick()
    {
        num = 3;
        NowWish = DataGlobal.GetSubsection(203);
        c = Instantiate(content);
        c.GetComponent<Image>().sprite = Resources.Load<Sprite>("WishSprite/ThirdWish");
        c.transform.SetParent(gameObject.transform);
        c.transform.localPosition = new Vector3(0, 103, 0);
        c.transform.localScale = new Vector3(1, 1, 1);
        iTween.ScaleFrom(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1));
        iTween.MoveFrom(c, new Vector3(thirdWish.transform.position.x, thirdWish.transform.position.y, 0), 1f);
        BtnShow();
    }
    public void OnForthClick()
    {
        num = 4;
        NowWish = DataGlobal.GetSubsection(204);
        c = Instantiate(content);
        c.GetComponent<Image>().sprite = Resources.Load<Sprite>("WishSprite/ForthWish");
        c.transform.SetParent(gameObject.transform);
        c.transform.localPosition = new Vector3(0, 103, 0);
        c.transform.localScale = new Vector3(1, 1, 1);
        iTween.ScaleFrom(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1));
        iTween.MoveFrom(c, new Vector3(forthWish.transform.position.x, forthWish.transform.position.y, 0), 1f);
        BtnShow();
    }
    public void OnFifthClick()
    {
        num = 5;
        NowWish = DataGlobal.GetSubsection(205);
        c = Instantiate(content);
        c.GetComponent<Image>().sprite = Resources.Load<Sprite>("WishSprite/FifthWish");
        c.transform.SetParent(gameObject.transform);
        c.transform.localPosition = new Vector3(0, 103, 0);
        c.transform.localScale = new Vector3(1, 1, 1);
        iTween.ScaleFrom(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1));
        iTween.MoveFrom(c, new Vector3(fifthWish.transform.position.x, fifthWish.transform.position.y, 0), 1f);
        BtnShow();
    }
    public void OnSixthClick()
    {
        num = 6;
        NowWish = DataGlobal.GetSubsection(206);
        c = Instantiate(content);
        c.GetComponent<Image>().sprite = Resources.Load<Sprite>("WishSprite/SixthWish");
        c.transform.SetParent(gameObject.transform);
        c.transform.localPosition = new Vector3(0, 103, 0);
        c.transform.localScale = new Vector3(1, 1, 1);
        iTween.ScaleFrom(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1));
        iTween.MoveFrom(c, new Vector3(sixthWish.transform.position.x, sixthWish.transform.position.y, 0), 1f);
        BtnShow();
    }
    public void OnSeventhClick()
    {
        num = 7;
        NowWish = DataGlobal.GetSubsection(207);
        c = Instantiate(content);
        c.GetComponent<Image>().sprite = Resources.Load<Sprite>("WishSprite/SeventhWish");
        c.transform.SetParent(gameObject.transform);
        c.transform.localPosition = new Vector3(0, 103, 0);
        c.transform.localScale = new Vector3(1, 1, 1);
        iTween.ScaleFrom(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1));
        iTween.MoveFrom(c, new Vector3(seventhWish.transform.position.x, seventhWish.transform.position.y, 0), 1f);
        BtnShow();
    }
    public void OnEighthClick()
    {
        num = 8;
        NowWish = DataGlobal.GetSubsection(208);
        c = Instantiate(content);
        c.GetComponent<Image>().sprite = Resources.Load<Sprite>("WishSprite/EighthWish");
        c.transform.SetParent(gameObject.transform);
        c.transform.localPosition = new Vector3(0, 103, 0);
        c.transform.localScale = new Vector3(1, 1, 1);
        iTween.ScaleFrom(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1));
        iTween.MoveFrom(c, new Vector3(eighthWish.transform.position.x, eighthWish.transform.position.y, 0), 1f);
        BtnShow();
    }
    public void OnNinthClick()
    {
        num = 9;
        NowWish = DataGlobal.GetSubsection(209);
        c = Instantiate(content);
        c.GetComponent<Image>().sprite = Resources.Load<Sprite>("WishSprite/NinthWish");
        c.transform.SetParent(gameObject.transform);
        c.transform.localPosition = new Vector3(0, 103, 0);
        c.transform.localScale = new Vector3(1, 1, 1);
        iTween.ScaleFrom(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1));
        iTween.MoveFrom(c, new Vector3(ninthWish.transform.position.x, ninthWish.transform.position.y, 0), 1f);
        BtnShow();
    }
    public void OnTenthClick()
    {
        num = 10;
        NowWish = DataGlobal.GetSubsection(210);
        c = Instantiate(content);
        c.GetComponent<Image>().sprite = Resources.Load<Sprite>("WishSprite/TenthWish");
        c.transform.SetParent(gameObject.transform);
        c.transform.localPosition = new Vector3(0, 103, 0);
        c.transform.localScale = new Vector3(1, 1, 1);
        iTween.ScaleFrom(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1));
        iTween.MoveFrom(c, new Vector3(tenthWish.transform.position.x, tenthWish.transform.position.y, 0), 1f);
        BtnShow();
    }
    public void OnEleventhClick()
    {
        num = 11;
        NowWish = DataGlobal.GetSubsection(210);
        c = Instantiate(content);
        c.GetComponent<Image>().sprite = Resources.Load<Sprite>("WishSprite/EleventhWish");
        c.transform.SetParent(gameObject.transform);
        c.transform.localPosition = new Vector3(0, 103, 0);
        c.transform.localScale = new Vector3(1, 1, 1);
        iTween.ScaleFrom(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1));
        iTween.MoveFrom(c, new Vector3(eleventhWish.transform.position.x, eleventhWish.transform.position.y, 0), 1f);
        BtnShow();
    }
    public void OnTwelfthClick()
    {
        num = 12;
        NowWish = DataGlobal.GetSubsection(211);
        c = Instantiate(content);
        c.GetComponent<Image>().sprite = Resources.Load<Sprite>("WishSprite/TwelfthWish");
        c.transform.SetParent(gameObject.transform);
        c.transform.localPosition = new Vector3(0, 103, 0);
        c.transform.localScale = new Vector3(1, 1, 1);
        iTween.ScaleFrom(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1));
        iTween.MoveFrom(c, new Vector3(twelfthWish.transform.position.x, twelfthWish.transform.position.y, 0), 1f);
        BtnShow();
    }
    void BtnShow()
    {
        mask.SetActive(true);
        avg.SetActive(true);
        langBtn.gameObject.SetActive(true);
        dialog.text = NowWish.dialogCN;
    }
    public void OnAvgClose()
    {
        avg.SetActive(false);
        iTween.ScaleTo(c, iTween.Hash("x", 0.6, "y", 0.6, "time", 1, "oncomplete", "Destruction", "oncompletetarget", gameObject));
        
        if (num == 1)
        {
            iTween.MoveTo(c, new Vector3(firstWish.transform.position.x, firstWish.transform.position.y, 0), 1f);
            langBtn.gameObject.SetActive(false);
        }else if (num == 2)
        {
            iTween.MoveTo(c, new Vector3(secondWish.transform.position.x, secondWish.transform.position.y, 0), 1f);
            langBtn.gameObject.SetActive(false);
        }
        else if (num == 3)
        {
            iTween.MoveTo(c, new Vector3(thirdWish.transform.position.x, thirdWish.transform.position.y, 0), 1f);
            langBtn.gameObject.SetActive(false);
        }
        else if (num == 4)
        {
            iTween.MoveTo(c, new Vector3(forthWish.transform.position.x, forthWish.transform.position.y, 0), 1f);
            langBtn.gameObject.SetActive(false);
        }
        else if (num == 5)
        {
            iTween.MoveTo(c, new Vector3(fifthWish.transform.position.x, fifthWish.transform.position.y, 0), 1f);
            langBtn.gameObject.SetActive(false);
        }
        else if (num == 6)
        {
            iTween.MoveTo(c, new Vector3(sixthWish.transform.position.x, sixthWish.transform.position.y, 0), 1f);
            langBtn.gameObject.SetActive(false);
        }
        else if (num == 7)
        {
            iTween.MoveTo(c, new Vector3(seventhWish.transform.position.x, seventhWish.transform.position.y, 0), 1f);
            langBtn.gameObject.SetActive(false);
        }
        else if (num == 8)
        {
            iTween.MoveTo(c, new Vector3(eighthWish.transform.position.x, eighthWish.transform.position.y, 0), 1f);
            langBtn.gameObject.SetActive(false);
        }
        else if (num == 9)
        {
            iTween.MoveTo(c, new Vector3(ninthWish.transform.position.x, ninthWish.transform.position.y, 0), 1f);
            langBtn.gameObject.SetActive(false);
        }
        else if (num == 10)
        {
            iTween.MoveTo(c, new Vector3(tenthWish.transform.position.x, tenthWish.transform.position.y, 0), 1f);
            langBtn.gameObject.SetActive(false);
        }
        else if (num == 11)
        {
            iTween.MoveTo(c, new Vector3(eleventhWish.transform.position.x, eleventhWish.transform.position.y, 0), 1f);
            langBtn.gameObject.SetActive(false);
        }
        else if (num == 12)
        {
            iTween.MoveTo(c, new Vector3(twelfthWish.transform.position.x, twelfthWish.transform.position.y, 0), 1f);
            langBtn.gameObject.SetActive(false);
        }
        
    }
    public void OnClose()
    {
        gameObject.SetActive(false);
    }
    public void LanguageChange()
    {
        if (isChinese)
        {
            dialog.text = NowWish.dialogEN;
            isChinese = false;
        }
        else
        {
            dialog.text = NowWish.dialogCN;
            isChinese = true;
        }
    }
    void Destruction()
    {
        mask.SetActive(false);
        c.SetActive(false);
        Destroy(c);
    }
	// Update is called once per frame
	void Update () {
       
	}
}
