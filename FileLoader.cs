using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataLoader{
	public delegate void LoadFishEvent(string str);
	public delegate void LoadByteFinishEvent(byte[] bytes);
	public delegate void AllLoadFinishEvent();

	/// <summary>
	/// 数据加载类.
	/// </summary>
	public class FileLoader:MonoBehaviour  {
		public static FileLoader Loader;
		public enum FileType{
			StringFile = 0,
			ByteFile = 1,
		}

		void Awake(){
			Loader = this;
		}
		/// <summary>
		/// 加载节点.
		/// </summary>
		public struct LoadNode{
			public string FileName;
			public FileType FileType;
			public LoadFishEvent OnLoadFinish;
			public LoadByteFinishEvent onLoadByteFinish;
		}
		
		public static AllLoadFinishEvent AllLoadFinish;
		public static bool Loading = false;
		public static List<LoadNode> LoadList = new List<LoadNode>();

		/// <summary>
		///通过路径预加载. 
		/// </summary>
		/// <param name="FileName">文件名.</param>
		/// <param name="onLoadFinish">加载结束委托.</param>
		public static void PrepareLoadFileByPath(string FileName,LoadFishEvent onLoadFinish){
			LoadNode newLoad = new LoadNode ();
			newLoad.FileName = FileName;
			newLoad.FileType = FileType.StringFile;
			newLoad.OnLoadFinish = onLoadFinish;
			LoadList.Add (newLoad);
		}

		/// <summary>
		///预加载文件. 
		/// </summary>
		/// <param name="fn">文件名.</param>
		/// <param name="Finish">加载结束委托.</param>
		public static void PrepareLoadFile(string fn, LoadFishEvent Finish){
			LoadNode newLoad = new LoadNode ();
			newLoad.FileName = FilePathController.GetWWWPath (fn);
			newLoad.FileType = FileType.StringFile;
			newLoad.OnLoadFinish = Finish;
			LoadList.Add (newLoad);
		}
		
		public WWW NowLoadWWW;
		
		IEnumerator LoadAllFile(){
			Loading = true;
			LoadNode NLN;
			while (LoadList.Count>0) {
				NLN =LoadList[0];
				NowLoadWWW = new WWW(NLN.FileName);
				yield return NowLoadWWW;
				if(NowLoadWWW.error == null){
					if(NLN.FileType == FileType.StringFile){
						NLN.OnLoadFinish(NowLoadWWW.text);
					}else{
						NLN.onLoadByteFinish(NowLoadWWW.bytes);
					}
				}else{
					Debug.LogError("Load file failed :"+NLN.FileName +NowLoadWWW.error);
				}
				LoadList.RemoveAt(0);
			}
			Loading = false;
			NowLoadWWW.Dispose ();
			if (AllLoadFinish != null) {
				AllLoadFinish();
			}
		}

		/// <summary>
		///开始加载函数. 
		/// </summary>
		/// <param name="AllFinish">所有加载结束委托.</param>
		public  void StartLoad(AllLoadFinishEvent AllFinish){
			if (!Loading) {
				AllLoadFinish = AllFinish;
				StartCoroutine (LoadAllFile ());
			} else {
				Debug.Log(" is Loading");
			}
		}	
	}
}
