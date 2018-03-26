using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using DataLoader;


namespace TableData
{
    public class DtLiterature
    {
        public int ID;
        public string Content;
    }
    public static class LiteratureData
    {
        private static Dictionary<int, DtLiterature> LiteratureList = new Dictionary<int, DtLiterature>();

        public static List<DtLiterature> GetLiteratureList()
        {
            List<DtLiterature> RtList = new List<DtLiterature>();
            foreach(DtLiterature lt in LiteratureList.Values)
            {
                DtLiterature Lite = new DtLiterature();
                Lite = lt;
                RtList.Add(Lite);
            }
            return RtList;
        }
        public static void PrepareLoadFile(string FileName)
        {
            FileLoader.PrepareLoadFileByPath(FileName, LoadFileFinish);
        }
        public static void LoadFileFinish(String Str)
        {
            LiteratureList.Clear();
            string[][] Values = CSVUtil.SplitCsv(Str);
            for (int i = 1; i < Values.Length - 1; i++)
            {
                try
                {
                    DtLiterature Temp = new DtLiterature();
                    int index = 0;
                    Temp.ID = int.Parse(Values[i][index++]);
                    if (LiteratureList.ContainsKey(Temp.ID))
                    {
                        Debug.LogWarning("Contained Key:" + Temp.ID);
                        continue;
                    }
                    Temp.Content = Values[i][index++];

                    LiteratureList.Add(Temp.ID, Temp);
                }
                catch(Exception e)
                {
                    Debug.LogError(e.Message + "At line:" + (i + 1));
                }
            }
        }
    }
}