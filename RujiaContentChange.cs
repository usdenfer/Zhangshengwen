using UnityEngine;
using System.Collections;
using UISpace;
using UnityEngine.UI;

public class RujiaContentChange : MonoBehaviour
{


    public Text title;
    public Text content;
    public Scrollbar scrollbar;
    public GameObject mainPanel;

    private TyTraditional NowTradition;

    bool isChinese;
    private float contentPos;


    private void Start()
    {
        NowTradition = DataGlobal.GetTraditional(1);
    }
    public void Init()
    {
        if (ES2.Exists("rujiaPosition"))
        {
            contentPos = ES2.Load<float>("rujiaPosition");
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
            NowTradition = DataGlobal.GetTraditional(1);        
        }
        else if (scrollbar.value > 0.6f)
        {
            NowTradition = DataGlobal.GetTraditional(2);          
        }
        else if (scrollbar.value > 0.35f)
        {
            NowTradition = DataGlobal.GetTraditional(3);         
        }
        else if (scrollbar.value > 0.1f)
        {
            NowTradition = DataGlobal.GetTraditional(4);          
        }
        else if (scrollbar.value > 0)
        {
            NowTradition = DataGlobal.GetTraditional(5);           
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
            NowTradition = DataGlobal.GetTraditional(1);
        }
        else if (scrollbar.value > 0.6f)
        {
            NowTradition = DataGlobal.GetTraditional(2);
        }
        else if (scrollbar.value > 0.35f)
        {
            NowTradition = DataGlobal.GetTraditional(3);
        }
        else if (scrollbar.value > 0.1f)
        {
            NowTradition = DataGlobal.GetTraditional(4);
        }
        else if (scrollbar.value > 0)
        {
            NowTradition = DataGlobal.GetTraditional(5);
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
    public void PanelClose(){
        ES2.Save(scrollbar.value, "rujiaPosition");

    }
#if UNITY_IPHONE||UNITY_ANDROID
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            ES2.Save(scrollbar.value, "rujiaPosition");
            ES2.Save(isChinese, "LanguageChange");
        }
    }
    private void OnApplicationQuit()
    {
        ES2.Save(scrollbar.value, "rujiaPosition");
        ES2.Save(isChinese, "LanguageChange");
    }
#else
    private void OnApplicationQuit()
    {
        ES2.Save(scrollbar.value, "rujiaPosition");
        ES2.Save(isChinese, "LanguageChange");
    }
#endif
}
