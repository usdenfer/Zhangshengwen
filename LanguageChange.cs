using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UISpace;


public class LanguageChange : MonoBehaviour
{
    public bool isChinese;
    public GameObject LanguageButton;

    public Text coverContent;

    private TyTraditional NowTradition;

    private void Start()
    {
        if (ES2.Exists("LanguageChange"))
        {
            isChinese = ES2.Load<bool>("LanguageChange");
        }
        LanguageButton.GetComponent<Image>().sprite=Resources.Load<Sprite>("UI/DaliUI/ChineseTranslation");
    }
    public void OnLanguageChange()
    {
        if (isChinese)
        {
            NowTradition = DataGlobal.GetTraditional(1);
            coverContent.text = NowTradition.coverContentEN;
            LanguageButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/DaliUI/EnglishTranslation");
            isChinese = false;
        }
        else
        {
            NowTradition = DataGlobal.GetTraditional(1);
            coverContent.text = NowTradition.coverContentCN;
            LanguageButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/DaliUI/ChineseTranslation");
            isChinese = true;
        }
    }
    private void Update()
    {
        
    }
#if UNITY_IPHONE || UNITY_ANDROID
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            ES2.Save(isChinese, "LanguageChange");
        }
    }
    private void OnApplicationQuit()
    {
        ES2.Save(isChinese, "LanguageChange");
    }
#else
    private void OnApplicationQuit()
    {
        ES2.Save(isChinese, "LanguageChange");
    }
#endif
}
