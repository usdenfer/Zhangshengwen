using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextAutoScroll : MonoBehaviour {

    public float textScrollSpeed;
    public GameObject mask;
    public GameObject scrollBar;

    private bool autoMove = true;
    
   
    public void OnDrag()
    {  
        autoMove = false;
    }
    public void OnDrop()
    {
        autoMove = true;
    }
    public void OnDropDown()
    {
        Invoke("OnDrop", 3f);
    }
    private void Update()
    {
        if ( transform.localPosition.y < GetComponent<RectTransform>().rect.height - mask.GetComponent<RectTransform>().rect.height&&autoMove==true)
        {
            
            transform.Translate(Vector3.up * Time.deltaTime * textScrollSpeed);
           
        }
        else
        {
            transform.Translate(Vector3.up * 0);
            GetComponent<ScrollRect>().verticalScrollbar = scrollBar.GetComponent<Scrollbar>();
        }
        
    }
}
