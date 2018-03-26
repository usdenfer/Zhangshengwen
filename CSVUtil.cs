using System;
using UnityEngine;

public class CSVUtil  {
	public static String[][] SplitCsv(String src){
		if (src == null || src.Length == 0) {
			return new String[0][]{};
		}
		String st = "";
		System.Collections.ArrayList lines = new System.Collections.ArrayList ();
		System.Collections.ArrayList cells = new System.Collections.ArrayList ();
		bool beginWithQuote = false;
		int maxColumns = 0;
		for (int i =0; i<src.Length; i++) {
			char ch=src[i];
			#region CR OR LF
			if(ch =='\r'){
				#region CR 
				if(beginWithQuote){
					st +=ch;
				}else{
					if(i+1<src.Length && src[i+1]=='\n'){//若紧接着是LF,直接吃LF.
						i++;
					}
					cells.Add(st);
					st ="";
					beginWithQuote = false;
					maxColumns = (cells.Count>maxColumns?cells.Count:maxColumns);
					lines.Add(cells);
					st ="";
					cells = new System.Collections.ArrayList();
				}
				#endregion CR
			}else if(ch == '\n'){
				#region LF
				if(beginWithQuote){
					st+=ch;
				}else{
					if(i+1<src.Length&&src[i+1]=='\r'){
						i++;
					}
					cells.Add(st);
					st ="";
					beginWithQuote = false;
					maxColumns = (cells.Count>maxColumns?cells.Count:maxColumns);
					lines.Add(cells);
					st ="";
					cells = new System.Collections.ArrayList();
				}
				#endregion LF
			}
			#endregion CR OR LF
			else if(ch == '\"'){
				#region 双引号
				if(beginWithQuote){
					i++;
					if(i>=src.Length){
						cells.Add(st);
						st="";
						beginWithQuote = false;
					}else{
						ch=src[i];
						if(ch=='\"'){
							st+=ch;
						}else if(ch==','){
							cells.Add(st);
							st="";
							beginWithQuote =false;
						}else if(ch=='\r'||ch=='\n'){
							beginWithQuote =false;
							i--;
						}else{
							throw new UnityException("single double-quote char mustn't exist in field"+(cells.Count+1)+"while it is begin with quote \n char at:"+i);
						}
					}
				}
				else if(st.Length == 0){
					beginWithQuote = true;
				}else{
					st +=ch;
			    }
				#endregion 双引号
			}else if(ch==','){
				#region 逗号
				if(beginWithQuote){
					st+=ch;
				}else{
					cells.Add(st);
					st="";
					beginWithQuote = false;
				}
				#endregion 逗号
			}else{
				#region 其他符号
				st+=ch;
				#endregion 其他符号
			}
		}
		if (st.Length == 0) {
			if(beginWithQuote){
				throw new UnityException("last fielf is begin with but not end with double quote");
			}else{
				cells.Add(st);
				maxColumns =  (cells.Count>maxColumns?cells.Count:maxColumns);
				lines.Add(cells);
			}
		}
		String[][] ret = new String[lines.Count][];
		for (int i=0; i<ret.Length; i++) {
			cells = (System.Collections.ArrayList)lines[i];
			ret[i] = new String[maxColumns];
			for(int j=0;j<maxColumns;j++){
				if(j<cells.Count){
					ret[i][j] = cells[j].ToString();
				}else{
					ret[i][j] ="";
				}
			}
		}
		return ret;
	}

}
