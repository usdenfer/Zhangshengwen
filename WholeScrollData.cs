using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using DataLoader;


namespace TableData
{
    public class DtWholeScroll
    {
        public int ID;
        public int IconID;
        public string ContentCN;
        public string ContentEN;
        public string AudioName;
        public string TitleCN;
        public string TitleEN;
        public string ButtonName;
       
    }

    public static class WholeScrollData
    {
        private static Dictionary<int, DtWholeScroll> WholeContentList = new Dictionary<int, DtWholeScroll>();

        public static List<DtWholeScroll> GetWholeContentList()
        {
            List<DtWholeScroll> RtList = new List<DtWholeScroll>();
            foreach(DtWholeScroll ws in WholeContentList.Values)
            {
                DtWholeScroll WholeS = new DtWholeScroll();
                WholeS = ws;
                RtList.Add(WholeS);
            }
            return RtList;
        }
       
        public static void PrepareLoadFile(string FileName)
        {
            FileLoader.PrepareLoadFileByPath(FileName, LoadFileFinish);
        }
        public static void LoadFileFinish(String Str)
        {
            WholeContentList.Clear();
            string[][] Values = CSVUtil.SplitCsv(Str);
            for (int i = 1; i < Values.Length - 1; i++)
            {
                try
                {
                    DtWholeScroll Temp = new DtWholeScroll();
                    int index = 0;
                    Temp.ID = int.Parse(Values[i][index++]);
                    if (WholeContentList.ContainsKey(Temp.ID))
                    {
                        Debug.LogWarning("Contained Key:" + Temp.ID);
                        continue;
                    }
                    Temp.IconID = int.Parse(Values[i][index++]);
                    Temp.ContentCN = Values[i][index++];
                    Temp.ContentEN = Values[i][index++];
                    Temp.AudioName = Values[i][index++];
                    Temp.TitleCN = Values[i][index++];
                    Temp.TitleEN = Values[i][index++];
                    Temp.ButtonName = Values[i][index++];
                   
                    WholeContentList.Add(Temp.IconID, Temp);

                }
                catch(Exception e)
            {
                Debug.LogError(e.Message + "At line:" + (i + 1));
            }
            }
        }

    }
}