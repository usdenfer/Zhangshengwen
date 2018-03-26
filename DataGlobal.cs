using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Data;


namespace UISpace {
    public class TyWholeScroll
    {
        public int ID;
        public int iconID;
        public string contentCN;
        public string contentEN;
        public string audioName;
        public string titleCN;
        public string titleEN;
        public string buttonName;  
    }
    public class TyDaliStory
    {
        public int ID;
        public string contentCN;
        public string contentEN;
        public string titleCN;
        public string titleEN;
        public float value;
		public int backGround;
        public string coverContentCN;
        public string coverContentEN;
        public string coverTitleCN;
        public string coverTitleEN;
        public string guideCN;
        public string guideEN;
    }
    public class TyWorldEvent
    {
        public int ID;
        public string titleCN;
        public string titleEN;
        public string worldTitleCN;
        public string worldTitleEN;
        public string worldContentCN;
        public string worldContentEN;
        public string chinaTitleCN;
        public string chinaTitleEN;
        public string chinaContentCN;
        public string chinaContentEN;
        public string yunnanTitleCN;
        public string yunnanTitleEN;
        public string yunnanContentCN;
        public string yunnanContentEN;
        public string upButtonCN;
        public string upButtonEN;
        public string downButtonCN;
        public string downButtonEN;
        public string coverContentCN;
        public string coverContentEN;
        public string guideCN;
        public string guideEN;
        public string background;
    }
	public class TyAVG{
		public int ID;
		public string dialogCN;
		public string dialogEN;
		public int backGround;
		public string audio;
		public int idol;
	}
    public class TySubsection
    {
        public int ID;
        public string dialogCN;
        public string dialogEN;
        public int backGround;
        public string audio;
        public int idol;
    }
    public class TyLiterature
    {
        public int ID;
        public string content;
    }
    public class TyTraditional
    {
        public int ID;
        public string titleCN;
        public string titleEN;
        public string contentCN;
        public string contentEN;
        public int backGround;
        public string coverTitleCN;
        public string coverTitleEN;
        public string coverContentCN;
        public string coverContentEN;
        public string guideCN;
        public string guideEN;
    }

    public static class DataGlobal {

        public static List<TyWholeScroll> WholeScrollList = new List<TyWholeScroll>();
        public static List<TyDaliStory> DaliList = new List<TyDaliStory>();
        public static List<TyWorldEvent> WorldList = new List<TyWorldEvent>();
		public static List<TyAVG>SubList=new List<TyAVG>();
        public static List<TyLiterature> LiteList = new List<TyLiterature>();
        public static List<TyTraditional> TradList = new List<TyTraditional>();
        public static List<TySubsection> SsList = new List<TySubsection>();


        #region DataProcess
        public static void InitData()//获取数据
        {
            DataPort.GetWholeScrollData();
            DataPort.GetDaliData();
            DataPort.GetWorldData();
			DataPort.GetSubsectionData ();
            DataPort.GetLiteratureData();
            DataPort.GetTraditionalData();
            
        }
        public static TyWholeScroll GetWholeScroll(int ID)
        {
            for(int i = 0; i < WholeScrollList.Count; i++)
            {
                if (ID == WholeScrollList[i].ID)
                {
                    return WholeScrollList[i];
                }
            }
            return null;
        }
        public static TyDaliStory GetDaliStory(int ID)
        {
            for(int i = 0; i < DaliList.Count; i++)
            {
                if (ID == DaliList[i].ID)
                {
                    return DaliList[i];
                }
            }
            return null;
        }
        public static TyWorldEvent GetWorldEvent(int ID)
        {
            for(int i = 0; i < WorldList.Count; i++)
            {
                if (ID == WorldList[i].ID)
                {
                    return WorldList[i];
                }
            }
            return null;
        }
		public static TyAVG GetSubsection(int ID){
			for (int i = 0; i < SubList.Count; i++) {
				if (ID == SubList [i].ID) {
					return SubList [i];
				}
			}
			return null;
		}
        
        public static TyLiterature GetLiterature(int ID)
        {
            for(int i = 0; i < LiteList.Count; i++)
            {
                if (ID == LiteList[i].ID)
                {
                    return LiteList[i];
                }
            }
            return null;
        }
        public static TyTraditional GetTraditional(int ID)
        {
            for(int i = 0; i < TradList.Count; i++)
            {
                if (ID == TradList[i].ID)
                {
                    return TradList[i];
                }
            }
            return null;
        }
       





        #endregion

    }
}
