using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongPressToClear : MonoBehaviour
    , IPointerDownHandler

{
    [SerializeField, Tooltip("2秒后清除")] private int holdTime = 2;
    public UnityEvent onLongPress = new UnityEvent();

    #region 长按清空数据
    public void OnPointerDown(PointerEventData eventData)
    {
        Invoke("OnLongPress", holdTime);
    }
    private void OnLongPress()
    {
        onLongPress.Invoke();
    }
    public void Clear()
    {
        Debug.Log("Clear");
        ES2.Delete("indexPosition");
        ES2.Delete("PageIndex");
        ES2.Delete("WholePosition");
        ES2.Delete("daojiaPosition");
        ES2.Delete("rujiaPosition");
        ES2.Delete("shijiaPosition");
        ES2.Delete("TraditionalBookMark");
        ES2.Delete("ContentPosition");
        ES2.Delete("WorldContentPosition");

    }
    #endregion
}
