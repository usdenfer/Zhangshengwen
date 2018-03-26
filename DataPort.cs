using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UISpace;
using TableData;



namespace Data
{
    public static class DataPort
    {
       public static void GetWholeScrollData()
        {
            DataGlobal.WholeScrollList.Clear();
            List<DtWholeScroll> TempList = WholeScrollData.GetWholeContentList();
            for(int i = 0; i < TempList.Count; i++)
            {
                TyWholeScroll TempWS = new TyWholeScroll();
                TempWS.ID = TempList[i].ID;
                TempWS.iconID = TempList[i].IconID;
                TempWS.contentCN = TempList[i].ContentCN;
                TempWS.contentEN = TempList[i].ContentEN;
                TempWS.audioName = TempList[i].AudioName;
                TempWS.titleCN = TempList[i].TitleCN;
                TempWS.titleEN = TempList[i].TitleEN;
                TempWS.buttonName=TempList[i].ButtonName;
              
                
                DataGlobal.WholeScrollList.Add(TempWS);
            }
        }
        public static void GetDaliData()
        {
            DataGlobal.DaliList.Clear();
            List<DtDaliStory> TempList = DaliStoryData.GetDaliContentList();
            for(int i = 0; i < TempList.Count; i++)
            {
                TyDaliStory TempDS = new TyDaliStory();
                TempDS.ID = TempList[i].ID;
                TempDS.contentCN = TempList[i].ContentCN;
                TempDS.contentEN = TempList[i].ContentEN;
                TempDS.titleCN = TempList[i].TitleCN;
                TempDS.titleEN = TempList[i].TitleEN;
                TempDS.value = TempList[i].Value;
				TempDS.backGround = TempList [i].BackGround;
                TempDS.coverContentCN = TempList[i].CoverContentCN;
                TempDS.coverContentEN = TempList[i].CoverContentEN;
                TempDS.coverTitleCN = TempList[i].CoverTitleCN;
                TempDS.coverTitleEN = TempList[i].CoverTitleEN;
                TempDS.guideCN = TempList[i].GuideCN;
                TempDS.guideEN = TempList[i].GuideEN;
                

                DataGlobal.DaliList.Add(TempDS);
            }
        }
        public static void GetWorldData()
        {
            DataGlobal.WorldList.Clear();
            List<DtWorldEvent> TempList = WorldEventData.GetWorldEventList();
            for(int i = 0; i < TempList.Count; i++)
            {
                TyWorldEvent TempWE = new TyWorldEvent();
                TempWE.ID = TempList[i].ID;
                TempWE.titleCN = TempList[i].TitleCN;
                TempWE.titleEN = TempList[i].TitleEN;
                TempWE.worldTitleCN = TempList[i].WorldTitleCN;
                TempWE.worldTitleEN = TempList[i].WorldTitleEN;
                TempWE.worldContentCN = TempList[i].WorldContentCN;
                TempWE.worldContentEN = TempList[i].WorldContentEN;
                TempWE.chinaTitleCN = TempList[i].ChinaTitleCN;
                TempWE.chinaTitleEN = TempList[i].ChinaTitleEN;
                TempWE.chinaContentCN = TempList[i].ChinaContentCN;
                TempWE.chinaContentEN = TempList[i].ChinaContentEN;
                TempWE.yunnanTitleCN = TempList[i].YunnanTitleCN;
                TempWE.yunnanTitleEN = TempList[i].YunnanTitleEN;
                TempWE.yunnanContentCN = TempList[i].YunnanContentCN;
                TempWE.yunnanContentEN = TempList[i].YunnanContentEN;
                TempWE.upButtonCN = TempList[i].UpButtonCN;
                TempWE.upButtonEN = TempList[i].UpButtonEN;
                TempWE.downButtonCN = TempList[i].DownButtonCN;
                TempWE.downButtonEN = TempList[i].DownButtonEN;
                TempWE.coverContentCN = TempList[i].CoverContentCN;
                TempWE.coverContentEN = TempList[i].CoverContentEN;
                TempWE.guideCN = TempList[i].GuideCN;
                TempWE.guideEN = TempList[i].GuideEN;
                TempWE.background = TempList[i].BackGround;

                DataGlobal.WorldList.Add(TempWE);
            }
        }
		public static void GetSubsectionData(){
			DataGlobal.SubList.Clear ();
			List<DtSubsection> TempList = SubsectionData.GetSubsectionList ();
			for (int i = 0; i < TempList.Count; i++) {
				TyAVG TempAVG = new TyAVG ();
				TempAVG.ID = TempList [i].ID;
				TempAVG.dialogCN = TempList [i].Dialog;
				TempAVG.dialogEN = TempList [i].DialogEN;
				TempAVG.backGround = TempList [i].BackGround;
				TempAVG.audio = TempList [i].Audio;
                TempAVG.idol = TempList [i].Idol;

				DataGlobal.SubList.Add(TempAVG);
			
			}
		}
        public static void GetLiteratureData()
        {
            DataGlobal.LiteList.Clear();
            List<DtLiterature> TempList = LiteratureData.GetLiteratureList();
            for(int i = 0; i < TempList.Count; i++)
            {
                TyLiterature TempLt = new TyLiterature();
                TempLt.ID = TempList[i].ID;
                TempLt.content = TempList[i].Content;

                DataGlobal.LiteList.Add(TempLt);
            }
        }
        public static void GetTraditionalData()
        {
            DataGlobal.TradList.Clear();
            List<DtTraditional> TempList = TraditionalData.GetTraditionalList();
            for ( int i = 0;i < TempList.Count; i++)
            {
                TyTraditional TempTC = new TyTraditional();
                TempTC.ID = TempList[i].ID;
                TempTC.titleCN = TempList[i].TitleCN;
                TempTC.titleEN = TempList[i].TitleEN;
                TempTC.contentCN = TempList[i].ContentCN;
                TempTC.contentEN = TempList[i].ContentEN;
                TempTC.backGround = TempList[i].BackGround;
                TempTC.coverTitleCN = TempList[i].CoverTitleCN;
                TempTC.coverTitleEN = TempList[i].CoverTitleEN;
                TempTC.coverContentCN = TempList[i].CoverContentCN;
                TempTC.coverContentEN = TempList[i].CoverContentEN;
                TempTC.guideCN = TempList[i].GuideCN;
                TempTC.guideEN = TempList[i].GuideEN;

                DataGlobal.TradList.Add(TempTC);
            }
        }
       
        
        
    }
    
}
