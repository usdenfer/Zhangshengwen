using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UISpace;



public class WorldControl : MonoBehaviour
{
	public GameObject worldPanel;
	public GameObject chinaPanel;
	public GameObject yunnanPanel;
	public GameObject LanguageButton;
	public GameObject CloseButton;
	public GameObject mainPanel;
	public GameObject uiPanel;
	public GameObject coverPanel;
	public GameObject yunnanMask;
	public GameObject upButton;
	public GameObject downButton;
	public GameObject bookMark;
	public GameObject mask;
	public GameObject englishButton;
	public GameObject bookMarkButton;
	public GameObject shareButton;
	public GameObject maskPanel;
	public GameObject backGroundButton;

	public GameObject bookMark1;
	public GameObject bookMark2;
	public GameObject bookMark3;
	public GameObject bookMark4;
	public GameObject bookMark5;
	public GameObject bookMark6;
	public GameObject bookMark7;
	public GameObject bookMark8;
	public GameObject bookMark9;
	public GameObject bookMark10;
	public GameObject bookMark11;
	public GameObject bookMark12;
	public GameObject bookMark13;


	public Image upArrow;
	public Image downArrow;
	public Text upButtonText;
	public Text downButtonText;
	public Text coverContent;
	public Text guide;

	public Text yearTitle;
	public Text worldTitle;
	public Text chinaTitle;
	public Text yunnanTitle;
	public Text worldContent;
	public Text chinaContent;
	public Text yunnanContent;

	public GameObject flash;



	public Scrollbar scrollBar;


	private TyWorldEvent NowWorld;


	bool isEnter = false;
	bool isChinese = true;

	GameObject f;

	void Start()
	{
		LanguageButton.SetActive(false);
		yearTitle.gameObject.SetActive(false);
		CloseButton.SetActive(false);
		upButton.SetActive(false);
		downButton.SetActive(false);
		shareButton.SetActive(false);
		bookMarkButton.SetActive(false);
		f = Instantiate(flash);


		LanguageButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/ChineseTranslation");
		englishButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/ChineseTranslation");

		
        JumpChange();
		

	}
	public void PanelMove()
	{
		iTween.MoveTo(worldPanel, iTween.Hash("y", -5, "time", 1));
		iTween.MoveTo(chinaPanel, iTween.Hash("y", -5, "time", 1.5));
		iTween.MoveTo(yunnanPanel, iTween.Hash("y", -5, "time", 2));

		iTween.MoveTo(maskPanel, iTween.Hash("x", 9, "time", 0.8f));
		yearTitle.gameObject.SetActive(true);
		backGroundButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/BackGround_Show");
		backGroundButton.GetComponent<Image>().color = new Color(1, 1, 1, 1);
		Invoke("MoveFinished", 2);
	}
	private void MoveFinished()
	{
		LanguageButton.SetActive(true);
		CloseButton.SetActive(true);
		upButton.SetActive(true);
		downButton.SetActive(true);
		shareButton.SetActive(true);
		bookMarkButton.SetActive(true);
		mainPanel.GetComponent<ScrollRect>().enabled = true;

		isEnter = true;
	}
	#region 点击封面
	public void OnCoverClick()
	{
		iTween.MoveTo(coverPanel, iTween.Hash("y", 10, "time", 1.5));
		backGroundButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/BackGround_Hide");
		backGroundButton.GetComponent<Image>().color = new Color((float)0.2, (float)0.2, (float)0.2, (float)0.8);
		Invoke("PanelMove", 1);
	}
	#endregion
	#region 显示和取消图片
	public void OnImageClick()
	{

		if (isEnter)
		{
			iTween.MoveTo(worldPanel, iTween.Hash("y", 5, "time", 1.8));
			iTween.MoveTo(chinaPanel, iTween.Hash("y", 5, "time", 1.4));
			iTween.MoveTo(yunnanPanel, iTween.Hash("y", 5, "time", 1));
			iTween.MoveTo(scrollBar.gameObject, iTween.Hash("y", -8, "time", 1));

			iTween.MoveTo(maskPanel, iTween.Hash("x", -10, "time", 0.8f));

			LanguageButton.SetActive(false);
			yearTitle.gameObject.SetActive(false);
			CloseButton.SetActive(false);
			bookMarkButton.SetActive(false);
			upButton.SetActive(false);
			downButton.SetActive(false);
			shareButton.SetActive(false);
			backGroundButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/BackGround_Hide");
			backGroundButton.GetComponent<Image>().color = new Color((float)0.2, (float)0.2, (float)0.2, (float)0.8);
			StartCoroutine(MoveControl());
		}

		else
		{
			iTween.MoveTo(worldPanel, iTween.Hash("y", -5, "time", 1));
			iTween.MoveTo(chinaPanel, iTween.Hash("y", -5, "time", 1.4));
			iTween.MoveTo(yunnanPanel, iTween.Hash("y", -5, "time", 1.8));
			iTween.MoveTo(scrollBar.gameObject, iTween.Hash("y", -4, "time", 1));
			iTween.MoveTo(maskPanel, iTween.Hash("x", 9, "time", 0.8f));

			backGroundButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/BackGround_Show");
			backGroundButton.GetComponent<Image>().color = new Color(1, 1, 1, 1);
			StartCoroutine(MoveControl());

		}

	}
	#endregion
	IEnumerator MoveControl()
	{
		if (isEnter)
		{
			yield return new WaitForSeconds(0);
			mainPanel.GetComponent<ScrollRect>().enabled = false;
			isEnter = false;
		}
		else
		{
			yield return new WaitForSeconds(1f);
			LanguageButton.SetActive(true);
			yearTitle.gameObject.SetActive(true);
			CloseButton.SetActive(true);
			bookMarkButton.SetActive(true);
			upButton.SetActive(true);
			downButton.SetActive(true);
			shareButton.SetActive(true);
			mainPanel.GetComponent<ScrollRect>().enabled = true;
			isEnter = true;
		}
	}

	#region 文化溯源内容管理
	public void OnContentChange()
	{
		yunnanMask.GetComponent<ScrollRect>().enabled = false;
		if (scrollBar.value > 0.96f && scrollBar.value <= 1f)
		{
			NowWorld = DataGlobal.GetWorldEvent(1);
		}
		else if (scrollBar.value > 0.88f && scrollBar.value <= 0.96f)
		{
			NowWorld = DataGlobal.GetWorldEvent(2);
		}
		else if (scrollBar.value > 0.80f && scrollBar.value <= 0.88f)
		{
			NowWorld = DataGlobal.GetWorldEvent(3);
		}
		else if (scrollBar.value > 0.71f && scrollBar.value <= 0.80f)
		{
			NowWorld = DataGlobal.GetWorldEvent(4);
		}
		else if (scrollBar.value > 0.63f && scrollBar.value <= 0.71f)
		{
			NowWorld = DataGlobal.GetWorldEvent(5);
		}
		else if (scrollBar.value > 0.54f && scrollBar.value <= 0.63f)
		{
			NowWorld = DataGlobal.GetWorldEvent(6);
		}
		else if (scrollBar.value > 0.46f && scrollBar.value <= 0.54f)
		{
			NowWorld = DataGlobal.GetWorldEvent(7);
		}
		else if (scrollBar.value > 0.38f && scrollBar.value <= 0.46f)
		{
			NowWorld = DataGlobal.GetWorldEvent(8);
		}
		else if (scrollBar.value > 0.29f && scrollBar.value <= 0.38f)
		{
			NowWorld = DataGlobal.GetWorldEvent(9);
		}
		else if (scrollBar.value > 0.21f && scrollBar.value <= 0.29f)
		{
			NowWorld = DataGlobal.GetWorldEvent(10);
		}
		else if (scrollBar.value > 0.13f && scrollBar.value <= 0.21f)
		{
			NowWorld = DataGlobal.GetWorldEvent(11);
			yunnanMask.GetComponent<ScrollRect>().enabled = true;

		}
		else if (scrollBar.value > 0.04f && scrollBar.value <= 0.13f)
		{
			NowWorld = DataGlobal.GetWorldEvent(12);
			yunnanMask.GetComponent<ScrollRect>().enabled = true;

		}
		else if (scrollBar.value >= 0 && scrollBar.value <= 0.04f)
		{
			NowWorld = DataGlobal.GetWorldEvent(13);
			yunnanMask.GetComponent<ScrollRect>().enabled = true;

		}

		if (isChinese) {
			yearTitle.text = NowWorld.titleCN;
			worldTitle.text = NowWorld.worldTitleCN;
			chinaTitle.text = NowWorld.chinaTitleCN;
			yunnanTitle.text = NowWorld.yunnanTitleCN;
			worldContent.text = NowWorld.worldContentCN;
			chinaContent.text = NowWorld.chinaContentCN;
			yunnanContent.text = NowWorld.yunnanContentCN;
			upButtonText.text = NowWorld.upButtonCN;
			downButtonText.text = NowWorld.downButtonCN;
		} else {
			yearTitle.text = NowWorld.titleEN;
			worldTitle.text = NowWorld.worldTitleEN;
			chinaTitle.text = NowWorld.chinaTitleEN;
			yunnanTitle.text = NowWorld.yunnanTitleEN;
			worldContent.text = NowWorld.worldContentEN;
			chinaContent.text = NowWorld.chinaContentEN;
			yunnanContent.text = NowWorld.yunnanContentEN;
			upButtonText.text = NowWorld.upButtonEN;
			downButtonText.text = NowWorld.downButtonEN;
		}
	}
	#endregion
	public void CoverChange()
	{
		NowWorld = DataGlobal.GetWorldEvent(1);
		if (isChinese)
		{
			coverContent.text = NowWorld.coverContentCN;

		}
		else
		{
			coverContent.text = NowWorld.coverContentEN;

		}
	}
	#region 语言切换
	public void LanguageChange(GameObject go)
	{
		if (isChinese)
		{
			yearTitle.text = NowWorld.titleEN;
			worldTitle.text = NowWorld.worldTitleEN;
			chinaTitle.text = NowWorld.chinaTitleEN;
			yunnanTitle.text = NowWorld.yunnanTitleEN;
			worldContent.text = NowWorld.worldContentEN;
			chinaContent.text = NowWorld.chinaContentEN;
			yunnanContent.text = NowWorld.yunnanContentEN;
			coverContent.text = NowWorld.coverContentEN;
			guide.text = NowWorld.guideEN;
			upButtonText.text = NowWorld.upButtonEN;
			downButtonText.text = NowWorld.downButtonEN;
			go.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/EnglishTranslation");
			coverContent.gameObject.transform.localPosition = new Vector2(0, -70);
			isChinese = false;
		}
		else
		{
			NowWorld = DataGlobal.GetWorldEvent(1);
			yearTitle.text = NowWorld.titleCN;
			worldTitle.text = NowWorld.worldTitleCN;
			chinaTitle.text = NowWorld.chinaTitleCN;
			yunnanTitle.text = NowWorld.yunnanTitleCN;
			worldContent.text = NowWorld.worldContentCN;
			chinaContent.text = NowWorld.chinaContentCN;
			yunnanContent.text = NowWorld.yunnanContentCN;
			coverContent.text = NowWorld.coverContentCN;
			guide.text = NowWorld.guideCN;
			upButtonText.text = NowWorld.upButtonCN;
			downButtonText.text = NowWorld.downButtonCN;
			go.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/WorldUI/ChineseTranslation");
			coverContent.gameObject.transform.localPosition = new Vector2(0, -30);
			isChinese = true;
		}
	}
	#endregion 书签跳转
	public void JumpChange()
	{
		if (scrollBar.value > 0.96f && scrollBar.value <= 1f)
		{
			JumpEventChange (1);
		}
		else if (scrollBar.value > 0.88f && scrollBar.value <= 0.96f)
		{
			JumpEventChange (2);
		}
		else if (scrollBar.value > 0.80f && scrollBar.value <= 0.88f)
		{
			JumpEventChange (3);
		}
		else if (scrollBar.value > 0.71f && scrollBar.value <= 0.80f)
		{
			JumpEventChange (4);
		}
		else if (scrollBar.value > 0.63f && scrollBar.value <= 0.71f)
		{
			JumpEventChange (5);
		}
		else if (scrollBar.value > 0.54 && scrollBar.value <= 0.63f)
		{
			JumpEventChange (6);
		}
		else if (scrollBar.value > 0.46 && scrollBar.value <= 0.54)
		{
			JumpEventChange (7);
		}
		else if (scrollBar.value > 0.38 && scrollBar.value <= 0.46)
		{
			JumpEventChange (8);
		}
		else if (scrollBar.value > 0.29 && scrollBar.value <= 0.38)
		{
			JumpEventChange (9);
		}
		else if (scrollBar.value > 0.21 && scrollBar.value <= 0.29)
		{
			JumpEventChange (10);
		}
		else if (scrollBar.value > 0.13 && scrollBar.value <= 0.21)
		{
			JumpEventChange (11);
		}
		else if (scrollBar.value > 0.04 && scrollBar.value <= 0.13)
		{
			JumpEventChange (12);
		}
		else if (scrollBar.value >= 0 && scrollBar.value <= 0.04)
		{
			JumpEventChange (13);
		}

	}

	private void JumpEventChange(int index){
		if(index>0 && index<14){
			
			bookMarkButton.GetComponent<Button>().onClick.RemoveAllListeners();
			bookMarkButton.GetComponent<Button>().onClick.AddListener(delegate ()
				{
					BookMarkClick(index);
				});
			if(index != 1)
				upButton.GetComponent<Button>().onClick.AddListener(delegate ()
					{
						mainPanel.GetComponent<SliderControl>().OnButtonClick(index-1);
					});
			if(index != 13)
				downButton.GetComponent<Button>().onClick.AddListener(delegate ()
					{
						mainPanel.GetComponent<SliderControl>().OnButtonClick(index + 1);
					});
			
			if (index == 1) {
				upButton.GetComponent<Button> ().enabled = false;
				upArrow.color = new Color (1, 1, 1, 0.3f);
				upButtonText.color = new Color (1, 1, 1, 0.3f);
			} else if (index == 2) {
				upButton.GetComponent<Button> ().enabled = true;
				upArrow.color = new Color (1, 1, 1, 1);
				upButtonText.color = new Color (1, 1, 1, 1);

			} else if (index == 12) {
				downArrow.color = new Color (1, 1, 1, 1);
				downButtonText.color = new Color (1, 1, 1, 1);
				downButton.GetComponent<Button> ().enabled = true;
			} else if (index == 13) {
				downArrow.color = new Color(1, 1, 1, 0.3f);
				downButtonText.color = new Color(1, 1, 1, 0.3f);
				downButton.GetComponent<Button> ().enabled = false;
			}
		}else{
			return;
		}
	}

	public void BookMarkClick(int ID)
	{
		Transform Trans = bookMark1.transform;
		switch (ID)
		{
		case 1:
			Trans = bookMark1.transform;
			bookMark.transform.localPosition = new Vector3(0, 0, 0);
			break;
		case 2:
			Trans = bookMark2.transform;
			bookMark.transform.localPosition = new Vector3(0, 0, 0);
			break;
		case 3:
			bookMark.transform.localPosition = new Vector3(0, 148, 0);
			Trans = bookMark3.transform;
			break;
		case 4:
			bookMark.transform.localPosition = new Vector3(0, 320, 0);
			Trans = bookMark4.transform;
			break;
		case 5:
			bookMark.transform.localPosition = new Vector3(0, 492, 0);
			Trans = bookMark5.transform;
			break;
		case 6:
			bookMark.transform.localPosition = new Vector3(0, 724, 0);
			Trans = bookMark6.transform;
			break;
		case 7:
			bookMark.transform.localPosition = new Vector3(0, 868, 0);
			Trans = bookMark7.transform;
			break;
		case 8:
			bookMark.transform.localPosition = new Vector3(0, 1041, 0);
			Trans = bookMark8.transform;
			break;
		case 9:
			bookMark.transform.localPosition = new Vector3(0, 1200, 0);
			Trans = bookMark9.transform;
			break;
		case 10:
			bookMark.transform.localPosition = new Vector3(0, 1376, 0);
			Trans = bookMark10.transform;
			break;
		case 11:
			bookMark.transform.localPosition = new Vector3(0, 1555, 0);
			Trans = bookMark11.transform;
			break;
		case 12:
			bookMark.transform.localPosition = new Vector3(0, 1617, 0);
			Trans = bookMark12.transform;
			break;
		case 13:
			bookMark.transform.localPosition = new Vector3(0, 1617, 0);
			Trans = bookMark13.transform;
			break;
		}
		if (ID > 0 && ID < 14) {
			iTween.MoveTo(bookMark, iTween.Hash("x", 7, "time", 1.2f));
			iTween.MoveTo(mask, new Vector3(0, 0, 0), 1.2f);
			f.transform.SetParent(Trans);
			f.transform.localPosition = new Vector3(0, 0, 0);
			f.transform.localScale = new Vector3(1, 1, 1);
			f.transform.localPosition = new Vector3(114, -57, 0);
		}
	}
	public void BlankClick()
	{
		iTween.MoveTo(bookMark, iTween.Hash("x", 12, "time", 2f));
		iTween.MoveTo(mask, iTween.Hash("y", -10, "time", 2f));
		//flash1.SetActive(false);

	}
	public void BookMarkChange(int id)
	{
		if (id > 0 && id < 14) {
			mainPanel.GetComponent<SliderControl>().OnButtonClick(id);
			BlankClick();
		}
	}

	public void OnClose()
	{
		coverPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
		worldPanel.GetComponent<RectTransform>().localPosition = new Vector3(-672, 375, 0);
		chinaPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, 375, 0);
		yunnanPanel.GetComponent<RectTransform>().localPosition = new Vector3(222, 375, 0);
		maskPanel.GetComponent<RectTransform>().localPosition = new Vector3(-672, -375, 0);
		LanguageButton.SetActive(false);
		yearTitle.gameObject.SetActive(false);
		CloseButton.SetActive(false);
		upButton.SetActive(false);
		downButton.SetActive(false);
		shareButton.SetActive(false);
		bookMarkButton.SetActive(false);
	}
	private void Update()
	{
		OnContentChange();
		CoverChange();
		//Debug.Log(bookMark.transform.localPosition);
		//Debug.Log(scrollBar.value);
	}


}

