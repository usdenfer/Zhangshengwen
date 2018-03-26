using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UISpace;

public class TraditionalCoverControl : MonoBehaviour {
    
    public Text content;


    private TyTraditional NowTradition;

    bool isChinese;
    private void Start()
    {
        if (ES2.Exists("LanguageChange"))
        {
            isChinese = ES2.Load<bool>("LanguageChange");
        }
        NowTradition = DataGlobal.GetTraditional(1);
        if (isChinese)
        {
         
            content.text = "\u3000\u3000"+NowTradition.coverContentCN;
        }
        else
        {
           
            content.text = "\u3000\u3000"+NowTradition.coverContentEN;
        }

    }
    public void OnCoverClick()
    {

        iTween.MoveTo(gameObject, iTween.Hash("y", 10, "time", .5));

    }
    public void OnCoverClose()
    {
        gameObject.transform.localPosition = new Vector2(0, 0);
    }
   
   
}
