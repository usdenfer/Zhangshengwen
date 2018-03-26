using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using DataLoader;

namespace TableData
{
    public class DtDaliStory
    {
        public int ID;
        public string ContentCN;
        public string ContentEN;
        public string TitleCN;
        public string TitleEN;
        public float Value;
		public int BackGround;
        public string CoverContentCN;
        public string CoverContentEN;
        public string CoverTitleCN;
        public string CoverTitleEN;
        public string GuideCN;
        public string GuideEN;
      
    }
    public static class DaliStoryData
    {
        private static Dictionary<int, DtDaliStory> DaliContentList = new Dictionary<int, DtDaliStory>();

        public static List<DtDaliStory> GetDaliContentList()
        {
            List<DtDaliStory> RtList = new List<DtDaliStory>();
            foreach(DtDaliStory ds in DaliContentList.Values)
            {
                DtDaliStory Dali = new DtDaliStory();
                Dali = ds;
                RtList.Add(Dali);
            }
            return RtList;
        }
        public static void PrepareLoadFile(string FileName)
        {
            FileLoader.PrepareLoadFileByPath(FileName, LoadFileFinish);
        }
        public static void LoadFileFinish(string Str)
        {
            DaliContentList.Clear();
            string[][] Values = CSVUtil.SplitCsv(Str);
            for(int i = 1; i < Values.Length - 1; i++)
            {
                try
                {
                    DtDaliStory Temp = new DtDaliStory();
                    int index = 0;
                    Temp.ID = int.Parse(Values[i][index++]);
                    if (DaliContentList.ContainsKey(Temp.ID))
                    {
                        Debug.LogWarning("Contained Key:" + Temp.ID);
                        continue;
                    }
                    Temp.ContentCN = Values[i][index++];
                    Temp.ContentEN = Values[i][index++];
                    Temp.TitleCN = Values[i][index++];
                    Temp.TitleEN = Values[i][index++];
                    Temp.Value = float.Parse(Values[i][index++]);
					Temp.BackGround=int.Parse(Values[i][index++]);
                    Temp.CoverContentCN = Values[i][index++];
                    Temp.CoverContentEN = Values[i][index++];
                    Temp.CoverTitleCN = Values[i][index++];
                    Temp.CoverTitleEN = Values[i][index++];
                    Temp.GuideCN = Values[i][index++];
                    Temp.GuideEN = Values[i][index++];
                    

                    DaliContentList.Add(Temp.ID,Temp);
                }
                catch(Exception e)
                {
                    Debug.LogError(e.Message + "At line:" + (i + 1));
                }
            }
        }
    }
}
