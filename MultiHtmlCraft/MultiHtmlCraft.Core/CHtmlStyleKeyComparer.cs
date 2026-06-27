using System;
using System.Collections;
using System.Text;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlStyleElementKeyClassComparerer 
	/// </summary>
	public sealed class CHtmlStyleKeyComparer : System.Collections.IComparer, System.Collections.Generic.IComparer<CHtmlStyleKey>
	{
		#region IComparer メンバ
		/*

		   0 より小さい値 a が b より小さい。 
		   0 a と b は等しい。 
		   0 より大きい値 a が b より大きい。 
		   
		*/
        public int Compare(CHtmlStyleKey sKeyX, CHtmlStyleKey sKeyY)
        {
            if (sKeyX == null && sKeyY == null)
            {
                return 0;
            }
            if (sKeyX == null)
            {
                return -1;
            }
            if (sKeyY == null)
            {
                return 1;
            }
            return string.Compare(sKeyX.SortShortName, sKeyY.SortShortName, StringComparison.OrdinalIgnoreCase);

        }
		public int Compare(object x, object y)
		{
			CHtmlStyleKey  sKeyX = x as CHtmlStyleKey;
			CHtmlStyleKey  sKeyY = y as CHtmlStyleKey;
			if(sKeyX == null && sKeyY == null)
			{
				return 0;
			}
			if(sKeyX == null)
			{
				return -1;
			}
			if(sKeyY == null)
			{
				return 1;
			}
			return string.Compare(sKeyX.SortShortName, sKeyY.SortShortName,StringComparison.OrdinalIgnoreCase);
		}
		#endregion
	}
}
