using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using DataLoader;

namespace TableData
{
    public class DtWorldEvent
    {
        public int ID;
        public string TitleCN;
        public string TitleEN;
        public string WorldTitleCN;
        public string WorldTitleEN;
        public string WorldContentCN;
        public string WorldContentEN;
        public string ChinaTitleCN;
        public string ChinaTitleEN;
        public string ChinaContentCN;
        public string ChinaContentEN;
        public string YunnanTitleCN;
        public string YunnanTitleEN;
        public string YunnanContentCN;
        public string YunnanContentEN;
        public string UpButtonCN;
        public string DownButtonCN;
        public string UpButtonEN;
        public string DownButtonEN;
        public string CoverContentCN;
        public string CoverContentEN;
        public string GuideCN;
        public string GuideEN;
        public string BackGround;
       
    }
    public static class WorldEventData
    {
        private static Dictionary<int, DtWorldEvent> WorldEventList = new Dictionary<int, DtWorldEvent>();

        public static List<DtWorldEvent> GetWorldEventList()
        {
            List<DtWorldEvent> RtList = new List<DtWorldEvent>();
            foreach(DtWorldEvent we in WorldEventList.Values)
            {
                DtWorldEvent WorldE = new DtWorldEvent();
                WorldE = we;
                RtList.Add(WorldE);
            }
            return RtList;
        } public static void PrepareLoadFile(string FileName)
        {
            FileLoader.PrepareLoadFileByPath(FileName, LoadFileFinish);
        }
        public static void LoadFileFinish(String Str)
        {
            WorldEventList.Clear();
            string[][] Values = CSVUtil.SplitCsv(Str);
            for(int i = 1; i < Values.Length - 1; i++)
            {
                try
                {
                    DtWorldEvent Temp = new DtWorldEvent();
                    int index = 0;
                    Temp.ID = int.Parse(Values[i][index++]);
                    if (WorldEventList.ContainsKey(Temp.ID))
                    {
                        Debug.LogWarning("Contained Key:" + Temp.ID);
                        continue;
                    }
                    Temp.TitleCN = Values[i][index++];
                    Temp.TitleEN = Values[i][index++];
                    Temp.WorldTitleCN = Values[i][index++];
                    Temp.WorldTitleEN = Values[i][index++];
                    Temp.WorldContentCN = Values[i][index++];
                    Temp.WorldContentEN = Values[i][index++];
                    Temp.ChinaTitleCN = Values[i][index++];
                    Temp.ChinaTitleEN = Values[i][index++];
                    Temp.ChinaContentCN = Values[i][index++];
                    Temp.ChinaContentEN = Values[i][index++];
                    Temp.YunnanTitleCN = Values[i][index++];
                    Temp.YunnanTitleEN = Values[i][index++];
                    Temp.YunnanContentCN = Values[i][index++];
                    Temp.YunnanContentEN = Values[i][index++];
                    Temp.UpButtonCN = Values[i][index++];
                    Temp.DownButtonCN = Values[i][index++];
                    Temp.UpButtonEN = Values[i][index++];
                    Temp.DownButtonEN = Values[i][index++];
                    Temp.CoverContentCN = Values[i][index++];
                    Temp.CoverContentEN = Values[i][index++];
                    Temp.GuideCN = Values[i][index++];
                    Temp.GuideEN = Values[i][index++];
                    Temp.BackGround = Values[i][index++];

                    WorldEventList.Add(Temp.ID, Temp);
                }
                catch(Exception e)
                {
                    Debug.LogError(e.Message + "At line:" + (i + 1));
                }
            }

    }
        



    }


}