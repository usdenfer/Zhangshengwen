using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using DataLoader;

namespace TableData{
	public class DtSubsection{
		public int ID;
		public string Dialog;
		public string DialogEN;
		public int BackGround;
		public string Audio;
		public int Idol;
	}
	public static class SubsectionData{
		private static Dictionary<int,DtSubsection> SubsectionList = new Dictionary<int, DtSubsection> ();

		public static List<DtSubsection>GetSubsectionList(){
			List<DtSubsection> RtList = new List<DtSubsection> ();
			foreach (DtSubsection ss in SubsectionList.Values) {
				DtSubsection Subs = new DtSubsection ();
				Subs = ss;
				RtList.Add (Subs);
			}
			return RtList;
		}
		public static void PrepareLoadFile(string FileName){
			FileLoader.PrepareLoadFileByPath (FileName, LoadFileFinish);
		}
		public static void LoadFileFinish(String Str){
			SubsectionList.Clear ();
			string[][] Values = CSVUtil.SplitCsv (Str);
			for(int i=1;i<Values.Length-1;i++){
				try{DtSubsection Temp=new DtSubsection();
					int index=0;
					Temp.ID=int.Parse(Values[i][index++]);
					if(SubsectionList.ContainsKey(Temp.ID))
					{
						Debug.LogWarning("Contained Key:"+Temp.ID);
						continue;
					}
					Temp.Dialog=Values[i][index++];
					Temp.DialogEN=Values[i][index++];
					Temp.BackGround=int.Parse(Values[i][index++]);
					Temp.Audio=Values[i][index++];
					Temp.Idol=int.Parse(Values[i][index++]);

					SubsectionList.Add(Temp.ID,Temp);
				}
				catch(Exception e){
					Debug.LogError (e.Message + "At line:" + (i + 1));
				}
		}
	}
	}
}
