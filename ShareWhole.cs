using UnityEngine;
using System.Collections;
using cn.sharesdk.unity3d;

public class ShareWhole : MonoBehaviour {

    ShareSDK ssdk;

    void Start()
    {
        ssdk = GetComponent<ShareSDK>();
        ssdk.shareHandler += ShareResultHandle;
    }
    public void OnShareClick()
    {
        
        ShareContent content = new ShareContent();
        content.SetText("张胜温画卷");
        content.SetTitle("张胜温画卷");
        Application.CaptureScreenshot("WholeScrollScreenShot.png");
        content.SetImageUrl( Application.persistentDataPath+ "/WholeScrollScreenShot.png");
        content.SetUrl("http://www.innyo.com");
        content.SetShareType(ContentType.Image);
        //content.SetDesc("empty");

        //ssdk.ShowShareContentEditor(PlatformType.WeChat, content);
        ssdk.ShowPlatformList(null, content, 100, 100);
    }
    void ShareResultHandle(int reID, ResponseState state, PlatformType type, Hashtable result)
    {
        if (state == ResponseState.Success)
        {
            print("share result:");
            print(MiniJSON.jsonEncode(result));
        }
        else if (state == ResponseState.Fail)
        {
            print("fail! error code = " + result["error_code"] + ";error msg=" + result["error_msg"]);
        }
        else if (state == ResponseState.Cancel)
        {
            print("Cancel!");
        }
    }


}
