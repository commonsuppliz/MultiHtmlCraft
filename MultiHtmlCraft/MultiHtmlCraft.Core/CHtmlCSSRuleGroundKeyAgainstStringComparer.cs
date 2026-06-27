using System;
using System.Collections;
using System.Text;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlStyleElementKeyClassComparerer 
	/// </summary>
	
	public sealed class CHtmlCSSRuleGroundKeyAgainstStringComparer : System.Collections.IComparer, System.Collections.Generic.IComparer<CHtmlCSSRule>
	{
		//
		//public enum ICHtmlStyleElementCompareType{WorkingListTop=0, WorkingListEnd=1, OriginalListTop=10, OriginalListEnd=11}; 
		//
		//public ICHtmlStyleElementCompareType CompareType = ICHtmlStyleElementCompareType.OriginalListTop;
		#region IComparer メンバ
		/*

		   0 より小さい値 a が b より小さい。 
		   0 a と b は等しい。 
		   0 より大きい値 a が b より大きい。 
		   
		*/
   
        public int Compare(CHtmlCSSRule  styleX, CHtmlCSSRule styleY)
        {
            if (styleX == null)
            {
                return -1;
            }
            if (styleY == null)
            {
                return 1;
            }
            // NOTE) DO NOT Change OrdinalIgnoreCase is best
            //       string.CompareOrdinalMay Miss hit.


            return string.Compare(styleX.___GroundSortKey , styleY.___GroundSortKey, StringComparison.OrdinalIgnoreCase);

        }
		
		public int Compare(object x, object y)
		{
			string xKey = null;
			string yKey = null;
			
			CHtmlCSSRule styleX = x as CHtmlCSSRule;
            if(styleX != null)
            {
				xKey = styleX.___GroundSortKey;
                goto XDone;
            }		
			else
			{
				xKey = x as string;
                goto XDone;
			}
            XDone:
			//CHtmlStyleKey xKey = null;
			CHtmlCSSRule styleY = null;
			
				styleY = y as CHtmlCSSRule;
                if (styleY != null)
                {
                    yKey = styleY.___GroundSortKey;
                    goto YDone;
                }
                else
                {
                    yKey = y as string;
                }
           YDone:
                if (xKey == null)
                {
                    return -1;
                }
                if (yKey  == null)
                {
                    return 1;
                }
            // NOTE) DO NOT Change OrdinalIgnoreCase is best
            //       string.CompareOrdinalMay Miss hit.
			return string.Compare(xKey, yKey, StringComparison.OrdinalIgnoreCase);

		}
		#endregion
	}


}