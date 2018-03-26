using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UISpace;

public class LiteratureContentControl : MonoBehaviour {

    
    private TyLiterature NowLite;

  
    void Start()
    {
        Text text = GetComponent<Text>();
        NowLite = DataGlobal.GetLiterature(1);
        text.text = NowLite.content;
    }
}
