using System;
using System.Collections;
using System.Text;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlStyleElementSearchHitForThisNodeKeyClassComparerer 
	/// </summary>
	public sealed class CHtmlCSSRuleSearchHitForThisNodeClassComparer : System.Collections.IComparer
	{
		#region IComparer メンバ
		/*

		   0 より小さい値  : a が b より小さい。 
		   0 a と b は等しい。 
		   0 より大きい値  :  a が b より大きい。 
		   
		*/
		/*
		 * After Sortring
		 * ~~~~~~~~~~~~~~
		 * [Hit]
		 * [*]  a
		 * [*]  div
		 * [*]  id.afdafd.
		 * [*]  dfare.reread
		 * [-]  p
		 * [-]  span.ssaa
		 * [-]  #areare 
		*/
		public int Compare(object x, object y)
		{
            CHtmlCSSRule styleX = x as CHtmlCSSRule;
            CHtmlCSSRule styleY = y as CHtmlCSSRule;
			if(styleX == null)
			{
				return -1;
			}
			if(styleY == null)
			{
				return 1;
			}
			int WorkingResult =  styleX.___styleKeyWorkingList.Count - styleY.___styleKeyWorkingList.Count;
			if(WorkingResult != 0)
			{
				return WorkingResult;
			}
			else
			{
				return styleX.SelectorID.Length - styleY.SelectorID.Length;
			}

		}
		#endregion
	}
}