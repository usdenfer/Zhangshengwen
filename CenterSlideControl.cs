using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CenterSlideControl : MonoBehaviour
{
    public ScrollRect _scrollRect;
    public Scrollbar _scrollbar;
    public GameObject contentPanel;

    private float mTargetValue;

    public bool mNeedMove = false;

    private const float MOVE_SPEED = 1f;

    private const float SMOOTH_TIME = 0.6f;

    private float mMoveSpeed = 0f;

    private float panelY;

    private float difference;



    public void OnPointerDown()
    {
        mNeedMove = false;
    }
    public void OnPointerUp()
    {
        if (panelY >= 375 && panelY < 600)
        {
            mTargetValue = 1f;
        }
        else if (panelY >= 600 && panelY < 900 && difference < 0)
        {
            mTargetValue = 1f;
        }
        else if (panelY >= 600 && panelY < 900 && difference > 0)
        {
            mTargetValue = 0.75f;
        }
        else if (panelY >= 900 && panelY < 1300)
        {
            mTargetValue = 0.75f;
        }
        else if (panelY >= 1300 && panelY < 1700 && difference < 0)
        {
            mTargetValue = 0.75f;
        }
        else if (panelY >= 1300 && panelY < 1700 && difference > 0)
        {
            mTargetValue = 0.5f;
        }
        else if (panelY >= 1700 && panelY < 2100)
        {
            mTargetValue = 0.5f;
        }
        else if (panelY >= 2100 && panelY < 2400 && difference < 0)
        {
            mTargetValue = 0.5f;
        }
        else if (panelY >= 2100 && panelY < 2400 && difference > 0)
        {
            mTargetValue = 0.25f;
        }
        else if (panelY > 2400 && panelY < 2800)
        {
            mTargetValue = 0.25f;
        }
        else if (panelY >= 2800 && panelY < 3150 && difference < 0)
        {
            mTargetValue = 0.25f;
        }
        else if (panelY >= 2800 && panelY < 3150 && difference > 0)
        {
            mTargetValue = 0f;
        }
        else if (panelY >= 3150 && panelY <= 3375)
        {
            mTargetValue = 0f;
        }
        mNeedMove = true;
        mMoveSpeed = 0;
    }
    private void Update()
    {
        if (mNeedMove)
        {
            if (Mathf.Abs(_scrollbar.value - mTargetValue) < 0.0001f)
            {
                _scrollbar.value = mTargetValue;
                mNeedMove = false;
                return;
            }
            _scrollbar.value = Mathf.SmoothDamp(_scrollbar.value, mTargetValue, ref mMoveSpeed, SMOOTH_TIME);
        }
        //Debug.Log(contentPanel.transform.localPosition.y);
        Debug.Log(panelY);
        panelY = contentPanel.transform.localPosition.y;
        difference = mTargetValue - _scrollbar.value;
    }
}

