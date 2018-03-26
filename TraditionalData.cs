using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using DataLoader;

namespace TableData
{
    public class DtTraditional
    {
        public int ID;
        public string TitleCN;
        public string TitleEN;
        public string ContentCN;
        public string ContentEN;
        public int BackGround;
        public string CoverTitleCN;
        public string CoverTitleEN;
        public string CoverContentCN;
        public string CoverContentEN;
        public string GuideCN;
        public string GuideEN;
    }
    public static class TraditionalData
    {
        private static Dictionary<int, DtTraditional> TraditionalList = new Dictionary<int, DtTraditional>();

        public static List<DtTraditional> GetTraditionalList()
        {
            List<DtTraditional> RtList = new List<DtTraditional>();
            foreach(DtTraditional tc in TraditionalList.Values)
            {
                DtTraditional Trad = new DtTraditional();
                Trad = tc;
                RtList.Add(Trad);
            }
            return RtList;
        }
        public static void PrepareLoadFile(string FileName)
        {
            FileLoader.PrepareLoadFileByPath(FileName, LoadFileFinish);
        }
        public static void LoadFileFinish(String Str)
        {
            TraditionalList.Clear();
            string[][] Values = CSVUtil.SplitCsv(Str);
            for(int i = 1; i < Values.Length - 1; i++)
            {
                try
                {
                    DtTraditional Temp = new DtTraditional();
                    int index = 0;
                    Temp.ID = int.Parse(Values[i][index++]);
                    if (TraditionalList.ContainsKey(Temp.ID))
                    {
                        Debug.LogWarning("Contained Key:" + Temp.ID);
                        continue;

                    }
                    Temp.TitleCN = Values[i][index++];
                    Temp.TitleEN = Values[i][index++];
                    Temp.ContentCN = Values[i][index++];
                    Temp.ContentEN = Values[i][index++];
                    Temp.BackGround = int.Parse(Values[i][index++]);
                    Temp.CoverTitleCN = Values[i][index++];
                    Temp.CoverTitleEN = Values[i][index++];
                    Temp.CoverContentCN = Values[i][index++];
                    Temp.CoverContentEN = Values[i][index++];
                    Temp.GuideCN = Values[i][index++];
                    Temp.GuideEN = Values[i][index++];

                    TraditionalList.Add(Temp.ID, Temp);
                }
                catch(Exception e)
                {
                    Debug.LogError(e.Message + "At line:" + (i + 1));
                }
            }
        }
    }
}


