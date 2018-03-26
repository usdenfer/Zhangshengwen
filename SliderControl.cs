using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour {
    public Scrollbar m_Scrollbar;
    public ScrollRect m_ScrollRect;
    public GameObject BackGround;

    private float mTargetValue;

    public bool mNeedMove = false;

    private const float MOVE_SPEED = 1f;

    private const float SMOOTH_TIME = 0.6f;

    private float mMoveSpeed = 0f;

    private float worldPosY;

    private void Start()
    {
      
    }
    public void Init(){
        if (ES2.Exists("WorldContentPosition"))
        {
            worldPosY = ES2.Load<float>("WorldContentPosition");
        }
        else
        {
            worldPosY = 0;
        }
        BackGround.transform.localPosition = new Vector3(0, worldPosY);
    }
    public void OnPointerDown()
    {
        mNeedMove = false;
    }
    public void OnPointerUp()//判断当前区间，设置滑动位置  
    {      
         if (BackGround.GetComponent<RectTransform>().localPosition.y>=8625)
        {
            mTargetValue = 0f;
        } else if (BackGround.GetComponent<RectTransform>().localPosition.y>=7875)
        {
            mTargetValue = 0.08334f;
        } else if (BackGround.GetComponent<RectTransform>().localPosition.y>=7125)
        {
            mTargetValue = 0.1664f;
        } else if (BackGround.GetComponent<RectTransform>().localPosition.y>=6375)
        {
            mTargetValue = 0.24976f;
        } else if (BackGround.GetComponent<RectTransform>().localPosition.y>=5625)
        {
            mTargetValue = 0.33359f;
        } else if (BackGround.GetComponent<RectTransform>().localPosition.y>=4875)
        {
            mTargetValue = 0.41667f;
        } else if (BackGround.GetComponent<RectTransform>().localPosition.y>=4125)
        {
            mTargetValue = 0.5f;
        } else if (BackGround.GetComponent<RectTransform>().localPosition.y>=3375)
        {
            mTargetValue = 0.58333f;
        }else if (BackGround.GetComponent<RectTransform>().localPosition.y>=2625)
        {
            mTargetValue = 0.66667f;
        }else if(BackGround.GetComponent<RectTransform>().localPosition.y>=1875)
        {
            mTargetValue =0.75f;
        }else if (BackGround.GetComponent<RectTransform>().localPosition.y>=1125)
        {
            mTargetValue =0.83333f;
        }else if (BackGround.GetComponent<RectTransform>().localPosition.y>=375)
        {
            mTargetValue = 0.91667f;
        }
        else
        {
            mTargetValue = 1f;
        }
        mNeedMove = true;
        mMoveSpeed = 0;
    }
    public void OnButtonClick(int value)
    {
        switch (value)
        {
            case 1:
                mTargetValue = 1f;
                break;
            case 2:
                mTargetValue = 0.91667f;
                break;
            case 3:
                mTargetValue = 0.83333f;
                break;
            case 4:
                mTargetValue = 0.75f;
                break;
            case 5:
                mTargetValue = 0.66667f;
                break;
            case 6:
                mTargetValue = 0.58333f;
                break;
            case 7:
                mTargetValue = 0.5f;
                break;
            case 8:
                mTargetValue = 0.41667f;
                break;
            case 9:
                mTargetValue = 0.33359f;
                break;
            case 10:
                mTargetValue = 0.24976f;
                break;
            case 11:
                mTargetValue = 0.1664f;
                break;
            case 12:
                mTargetValue= 0.08334f;
                break;
            case 13:
                mTargetValue = 0;
                break;

            default:
                Debug.LogError("////");
                break;
        }
        mNeedMove = true;
    }
    private void Update()
    {
        if (mNeedMove)
        {
            if (Mathf.Abs(m_Scrollbar.value - mTargetValue) < 0.0001f)
            {
                m_Scrollbar.value = mTargetValue;
                mNeedMove = false;
                return;
            }
            m_Scrollbar.value = Mathf.SmoothDamp(m_Scrollbar.value, mTargetValue, ref mMoveSpeed, SMOOTH_TIME);
        }

    }
#if UNITY_IPHONE
    void OnApplicationPause(bool pause)
    {
        if(pause)
        ES2.Save(BackGround.GetComponent<RectTransform>().localPosition.y, "WorldContentPosition");
    }
#endif
    private void OnApplicationQuit()
    {
        ES2.Save(BackGround.GetComponent<RectTransform>().localPosition.y, "WorldContentPosition");
    }
}
