using System;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlCSSRuleWorkingKeyStringComparer 
	/// </summary>
	
	public sealed class CHtmlCSSRuleWorkingKeyStringComparer : System.Collections.IComparer, System.Collections.Generic.IComparer<CHtmlCSSRule>
	{
   
        public int Compare(CHtmlCSSRule styleX, CHtmlCSSRule styleY)
        {
            try
            {

                return string.Compare(styleX.___WorkingKey, styleY.___WorkingKey, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled)
                {
                   commonLog.LogEntry("CHtmlCSSRuleWorkingKeyStringComparer abnormal error", ex);
                }
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
                return string.Compare(styleX.___WorkingKey, styleY.___WorkingKey, StringComparison.OrdinalIgnoreCase);
            }
        }

		#region IComparer メンバ
		/*

			   0 より小さい値 a が b より小さい。 
			   0 a と b は等しい。 
			   0 より大きい値 a が b より大きい。 
		   
			*/
		
		public int Compare(object x, object y)
		{
            CHtmlCSSRule styleX = x as CHtmlCSSRule;
            CHtmlCSSRule styleY = y as CHtmlCSSRule;
			
			if(styleX == null && styleY == null)
			{
				return 0;
			}
			if(styleX == null)
			{
				return -1;
			}
			if(styleY == null)
			{
				return 1;
			}

			return string.Compare(styleX.___WorkingKey, styleY.___WorkingKey, StringComparison.OrdinalIgnoreCase);

		}
		#endregion
	}
}

