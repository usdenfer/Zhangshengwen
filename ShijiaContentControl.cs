using UnityEngine;
using System.Collections;
using UISpace;
using UnityEngine.UI;

public class ShijiaContentControl : MonoBehaviour
{


    public Text title;
    public Text content;
    public Scrollbar scrollbar;
    public GameObject mainPanel;

    private TyTraditional NowTradition;

    private float contentPos;
    bool isChinese;

    private void Start()
    {
        NowTradition = DataGlobal.GetTraditional(6);
    }
    public void Init()
    {
        if (ES2.Exists("shijiaPosition"))
        {
            contentPos = ES2.Load<float>("shijiaPosition");
            scrollbar.value = contentPos;
        }
        else
        {
            contentPos = 1;
            scrollbar.value = contentPos;
        }
    }
    public void ContentSwap()
    {
        isChinese = mainPanel.GetComponent<LanguageChange>().isChinese;

        if (scrollbar.value > 0.85f)
        {
            NowTradition = DataGlobal.GetTraditional(6);           
        }
        else if (scrollbar.value > 0.6f)
        {
            NowTradition = DataGlobal.GetTraditional(7);          
        }
        else if (scrollbar.value > 0.35f)
        {
            NowTradition = DataGlobal.GetTraditional(8);            
        }
        else if (scrollbar.value > 0.1f)
        {
            NowTradition = DataGlobal.GetTraditional(9);          
        }
        else if (scrollbar.value > 0)
        {
            NowTradition = DataGlobal.GetTraditional(10);           
        }
        if (isChinese)
        {
            title.text = NowTradition.titleCN;
            content.text = NowTradition.contentCN;
        }
        else
        {
            title.text = NowTradition.titleEN;
            content.text = NowTradition.contentEN;
        }
    }
    public void LanguageChange()
    {
        isChinese = mainPanel.GetComponent<LanguageChange>().isChinese;

        if (scrollbar.value > 0.85f)
        {
            NowTradition = DataGlobal.GetTraditional(6);
        }
        else if (scrollbar.value > 0.6f)
        {
            NowTradition = DataGlobal.GetTraditional(7);
        }
        else if (scrollbar.value > 0.35f)
        {
            NowTradition = DataGlobal.GetTraditional(8);
        }
        else if (scrollbar.value > 0.1f)
        {
            NowTradition = DataGlobal.GetTraditional(9);          
        }
        else if (scrollbar.value > 0)
        {
            NowTradition = DataGlobal.GetTraditional(10);        
        }
        if (isChinese)
        {
            title.text = NowTradition.titleEN;
            content.text = NowTradition.contentEN;
        }
        else
        {
            title.text = NowTradition.titleCN;
            content.text = NowTradition.contentCN;
        }
    }
    public void PanelClose()
    {
        ES2.Save(scrollbar.value, "shijiaPosition");
    }

#if UNITY_IPHONE||UNITY_ANDROID
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            ES2.Save(scrollbar.value, "shijiaPosition");
            ES2.Save(isChinese, "LanguageChange");
        }
    }
    private void OnApplicationQuit()
    {
        ES2.Save(scrollbar.value, "shijiaPosition");
        ES2.Save(isChinese, "LanguageChange");
    }
#else
    private void OnApplicationQuit()
    {
        ES2.Save(scrollbar.value, "shijiaPosition");
        ES2.Save(isChinese, "LanguageChange");
    }
#endif
    private void Update()
    {
        //Debug.Log(scrollbar.value);
    }

}

