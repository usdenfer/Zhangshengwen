using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class PartScrollControl : MonoBehaviour
{
    public GameObject painting;
    public GameObject emperor;
    public GameObject kingKong;
    public GameObject shijia;
    public GameObject dragon;
    public GameObject arhats;
    public GameObject inherait;
    public GameObject monks;
    public GameObject debate;
    public GameObject meeting;
    public GameObject potrait;
    public GameObject guanYin;
    public GameObject guanYinPotrait;
    public GameObject thirteenEmperors;
    public GameObject guardian;
    public GameObject pillar;
    public GameObject stamp;
    public GameObject instruments;
    public GameObject flash;


	public GameObject[] PartScrolls;


    public GameObject paintingBtn;
    public GameObject emperorBtn;
    public GameObject kingKongBtn;
    public GameObject shijiaBtn;
    public GameObject dragonBtn;
    public GameObject arhatsBtn;
    public GameObject inheraitsBtn;
    public GameObject monksBtn;
    public GameObject debateBtn;
    public GameObject meetingBtn;
    public GameObject potraitBtn;
    public GameObject guanYinBtn;
    public GameObject guanYinPotraitBtn;
    public GameObject thirteenEmperorBtn;
    public GameObject guardianBtn;
    public GameObject pillarBtn;
    public GameObject stampBtn;
    public GameObject instrumentsBtn;

    GameObject paint;
    GameObject markPoint;
    GameObject Emp;
    GameObject k;
    GameObject s;
    GameObject d;
    GameObject a;
    GameObject i;
    GameObject m;
    GameObject de;
    GameObject me;
    GameObject po;
    GameObject gy;
    GameObject gp;
    GameObject t;
    GameObject gua;
    GameObject pi;
    GameObject st;
    GameObject ins;

    public int num=1;

    private void Start()
    {
        markPoint =Instantiate(flash);
		UIGlobal.partcontrol = this;
    }


	public void ShowPartScrollByID(int ID){
		if (ID > 0 && ID < 18) {
			GameObject st = Instantiate(PartScrolls[ID-1]);
			st.transform.SetParent(GameObject.Find("Canvas").transform);
			st.transform.localPosition = new Vector3(0, 0, 0);
			st.transform.localScale = new Vector3(1, 1, 1);
			st.SetActive(true);
		}
	}

    public void OnPaintingClick()
    {
        num = 1;
        paint = Instantiate(painting);
        paint.transform.SetParent(GameObject.Find("Canvas").transform);
        paint.transform.localPosition = new Vector3(0, 0, 0);
        paint.transform.localScale = new Vector3(1, 1, 1);
        paint.SetActive(true);       
        markPoint.transform.SetParent(paintingBtn.transform);
        MarkPositioning();
    }
    public void OnEmperorClick()
    {
        num = 2;
        Emp =Instantiate(emperor);
        Emp.transform.SetParent(GameObject.Find("Canvas").transform);
        Emp.transform.localPosition = new Vector3(0, 0, 0);
        Emp.transform.localScale = new Vector3(1, 1, 1);
        Emp.SetActive(true);
        markPoint.transform.SetParent(emperorBtn.transform);
        MarkPositioning();
    }
    public void OnKingKongClick()
    {
        num = 3;
        k = Instantiate(kingKong);
        k.transform.SetParent(GameObject.Find("Canvas").transform);
        k.transform.localPosition = new Vector3(0, 0, 0);
        k.transform.localScale = new Vector3(1, 1, 1);
        k.SetActive(true);
        markPoint.transform.SetParent(kingKongBtn.transform);
        MarkPositioning();
    }
    public void OnShijiaClick()
    {
        num = 4;
        s = Instantiate(shijia);
        s.transform.SetParent(GameObject.Find("Canvas").transform);
        s.transform.localPosition = new Vector3(0, 0, 0);
        s.transform.localScale = new Vector3(1, 1, 1);
        s.SetActive(true);
        markPoint.transform.SetParent(shijiaBtn.transform);
        MarkPositioning();
    }
    public void OnDragonClick()
    {
        num = 5;
        dragon.SetActive(true);
        markPoint.transform.SetParent(dragonBtn.transform);
        MarkPositioning();
    }
    public void OnArhatsClick()
    {
        num = 6;
        arhats.SetActive(true);
        markPoint.transform.SetParent(arhatsBtn.transform);
        MarkPositioning();
    }
    public void OnInheraitClick()
    {
        num = 7;
        inherait.SetActive(true);
        markPoint.transform.SetParent(inheraitsBtn.transform);
        MarkPositioning();
    }
    public void OnMonksClick()
    {
        num = 8;
        monks.SetActive(true);
        markPoint.transform.SetParent(monksBtn.transform);
        MarkPositioning();
    }
    public void OnDebateClick()
    {
        num = 9;
        de = Instantiate(debate);
        de.transform.SetParent(GameObject.Find("Canvas").transform);
        de.transform.localPosition = new Vector3(0, 0, 0);
        de.transform.localScale = new Vector3(1, 1, 1);
        de.SetActive(true);
        markPoint.transform.SetParent(debateBtn.transform);
        MarkPositioning();
    }
    public void OnMeetingClick()
    {
        num = 10;
        me = Instantiate(meeting);
        me.transform.SetParent(GameObject.Find("Canvas").transform);
        me.transform.localPosition = new Vector3(0, 0, 0);
        me.transform.localScale = new Vector3(1, 1, 1);
        me.SetActive(true);
        markPoint.transform.SetParent(meetingBtn.transform);
        MarkPositioning();
    }
    public void OnPotraitClick()
    {
        num = 11;
        potrait.SetActive(true);
        markPoint.transform.SetParent(potraitBtn.transform);
        MarkPositioning();
    }
    public void OnGuanYinClick()
    {
        num = 12;
        gy = Instantiate(guanYin);
        gy.transform.SetParent(GameObject.Find("Canvas").transform);
        gy.transform.localPosition = new Vector3(0, 0, 0);
        gy.transform.localScale = new Vector3(1, 1, 1);
        gy.SetActive(true);
        markPoint.transform.SetParent(guanYinBtn.transform);
        MarkPositioning();
    }
    public void OnGuanYinPoClick()
    {
        num = 13;
        guanYinPotrait.SetActive(true);
        markPoint.transform.SetParent(guanYinPotraitBtn.transform);
        MarkPositioning();
    }
    public void OnThirteenClick()
    {
        num = 14;
        t = Instantiate(thirteenEmperors);
        t.transform.SetParent(GameObject.Find("Canvas").transform);
        t.transform.localPosition = new Vector3(0, 0, 0);
        t.transform.localScale = new Vector3(1, 1, 1);
        t.SetActive(true);
        markPoint.transform.SetParent(thirteenEmperorBtn.transform);
        MarkPositioning();
    }
    public void OnGuardianClick()
    {
        num = 15;
        guardian.SetActive(true);
        markPoint.transform.SetParent(guardianBtn.transform);
        MarkPositioning();
    }
    public void OnPillarClick()
    {
        num = 16;
        pi = Instantiate(pillar);
        pi.transform.SetParent(GameObject.Find("Canvas").transform);
        pi.transform.localPosition = new Vector3(0, 0, 0);
        pi.transform.localScale = new Vector3(1, 1, 1);
        pi.SetActive(true);
        markPoint.transform.SetParent(pillarBtn.transform);
        MarkPositioning();
    }
    public void OnStampClick()
    {
        num = 17;
        stamp.SetActive(true);      
        markPoint.transform.SetParent(stampBtn.transform);
        MarkPositioning();
    }
    public void OnInstrumentsClick()
    {
        num = 18;
        ins = Instantiate(instruments);
        ins.transform.SetParent(GameObject.Find("Canvas").transform);
        ins.transform.localPosition = new Vector3(0, 0, 0);
        ins.transform.localScale = new Vector3(1, 1, 1);
        ins.SetActive(true);
        markPoint.transform.SetParent(instrumentsBtn.transform);
        MarkPositioning();
    }
    void MarkPositioning()
    {
        markPoint.transform.localScale = new Vector3(1, 1, 1);
        markPoint.transform.localPosition = new Vector3(139, -240, 0);
    }

	void Destroy(){
		UIGlobal.partcontrol = null;
	}
}

    
    

