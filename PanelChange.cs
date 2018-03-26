using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class PanelChange : MonoBehaviour
{

    public GameObject ruPanel;
    public GameObject shiPanel;
    public GameObject daoPanel;
    public GameObject bookMark1;
    public GameObject bookMark2;
    public GameObject bookMark3;

    private int bookNum;

    private void Start()
    {
        ruPanel.SetActive(false);
        shiPanel.SetActive(false);
        daoPanel.SetActive(false);
        bookMark1.SetActive(false);
        bookMark2.SetActive(false);
        bookMark3.SetActive(false);

    }
    public void Init(){
        if(ES2.Exists("TraditionalBookMark"))
        {
            bookNum = ES2.Load<int>("TraditionalBookMark");
            if (bookNum == 1)
            {
                bookMark1.SetActive(true);
            }
            else if (bookNum == 2)
            {
                bookMark2.SetActive(true);
            }
            else if (bookNum == 3)
            {
                bookMark3.SetActive(true);
            }
            else
            {
                return;
            }
        }
        else
        {
            bookMark1.SetActive(false);
            bookMark2.SetActive(false);
            bookMark3.SetActive(false);
        }
    }

    public void OnContentClick(int value)//点击切换儒、释、道内容
    {
        switch (value)
        {
            case 1:
                ruPanel.SetActive(true);
                shiPanel.SetActive(false);
                daoPanel.SetActive(false);
                bookMark1.SetActive(true);
                bookMark2.SetActive(false);
                bookMark3.SetActive(false);
                bookNum = 1;
                break;
            case 2:
                shiPanel.SetActive(true);
                ruPanel.SetActive(false);
                daoPanel.SetActive(false);
                bookMark2.SetActive(true);
                bookMark1.SetActive(false);
                bookMark3.SetActive(false);
                bookNum = 2;
                break;
            case 3:
                daoPanel.SetActive(true);
                ruPanel.SetActive(false);
                shiPanel.SetActive(false);
                bookMark3.SetActive(true);
                bookMark1.SetActive(false);
                bookMark2.SetActive(false);
                bookNum = 3;
                break;
        }
    }
    public void OnContentClose()//关闭内容显示面板
    {
        ruPanel.SetActive(false);
        shiPanel.SetActive(false);
        daoPanel.SetActive(false);
    }
#if UNITY_IPHONE||UNITY_ANDROID
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            ES2.Save(bookNum, "TraditionalBookMark");
        }
    }
    private void OnApplicationQuit()
    {
        ES2.Save(bookNum, "TraditionalBookMark");
    }
#else
    private void OnApplicationQuit()
    {
        ES2.Save(bookNum, "TraditionalBookMark");
    }
#endif
    private void Update()
    {
        //Debug.Log(bookNum);
    }
}
