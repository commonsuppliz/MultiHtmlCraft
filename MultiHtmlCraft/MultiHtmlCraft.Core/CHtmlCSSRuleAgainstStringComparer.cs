using System;
using System.Collections;
using System.Text;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlStyleElementKeyClassComparerer 
	/// </summary>
	
	public sealed class CHtmlWorkingCSSRuleAgainstStringComparer:  System.Collections.Generic.IComparer<CHtmlCSSRule>
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
   
        public int Compare(CHtmlCSSRule styleX, CHtmlCSSRule styleY)
        {
            try
            {

                return string.CompareOrdinal(styleX.___WorkingKey, styleY.___WorkingKey);
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled)
                {
                   commonLog.LogEntry("CHtmlWorkingCSSRuleAgainstStringComparerabnormal error!", ex);
                }
                //CHtmlStyleKey yKey = null;
                if (styleX == null && styleY == null)
                {
                    return 0;
                }
                if (styleX == null)
                {
                    return -1;
                }
                if (styleY == null)
                {
                    return 1;
                }
                return string.CompareOrdinal(styleX.___WorkingKey, styleY.___WorkingKey);
            }

        }
        /*
		
		public int Compare(object x, object y)
		{
			string xKey = null;
			string yKey = null;
			if(x is CHtmlCSSStyleSheet)
			{
				CHtmlCSSStyleSheet styleX = x as CHtmlCSSStyleSheet;
				xKey = styleX.___WorkingKey;
			}
			else if(x is String)
			{
				xKey = x as string;
			}
			//CHtmlStyleKey xKey = null;
			CHtmlCSSStyleSheet styleY = null;
			if(y is CHtmlCSSStyleSheet)
			{
				styleY = y as CHtmlCSSStyleSheet;
				yKey = styleY.___WorkingKey;
			} 
			else if(y is string)
			{
				yKey = y as string;
			}
			//CHtmlStyleKey yKey = null;
			if(xKey == null && yKey == null)
			{
				return 0;
			}
			if(xKey == null)
			{
				return -1;
			}
			if(yKey == null)
			{
				return 1;
			}
			return string.CompareOrdinal(xKey, yKey);

		}
        */
        #endregion

    }


}