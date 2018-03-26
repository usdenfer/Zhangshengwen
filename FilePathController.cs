
/// <summary>
///This Script is added for Path in Multi-Platform 
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public static class FilePathController {
	private static Dictionary<string,string> PathList = new Dictionary<string, string> ();
	public static string GetWWWPath(string FileName){
		string ThisPath;
		ThisPath = GetPath (FileName);
#if UNITY_IPHONE
		ThisPath = "file://"+ThisPath;
#endif
		return ThisPath;
	}

	public static string GetPath(string FileName){
//		if (FileName == "ServerList.txt") {
//#if UNITY_ANDROID
//			return "file://"+VersionUpdater.DownloadPath+"ServerList.txt";
//#elif UNITY_IPHONE
//			return VersionUpdater.DownloadPath+"ServerList.txt";
//#else
//			return Application.streamingAssetsPath+"ServerList.txt";
//#endif
//		}
		string ThisPath = null ;
		PathList.TryGetValue(FileName,out ThisPath);
		if(ThisPath == null){
		#if UNITY_ANDROID
			return "jar:file://" + Application.dataPath + "!/assets/"+FileName;
		#elif UNITY_IPHONE
			return Application.dataPath + "/Raw/"+FileName;
		#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
			return "file://" + Application.dataPath + "/StreamingAssets/"+FileName;
#endif
		}
		return ThisPath;
		}
}
