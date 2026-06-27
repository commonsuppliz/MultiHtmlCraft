using System;
using System.Collections;
using System.Text;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlStyleElementSearchHitForThisNodeKeyClassComparerer 
	/// </summary>
	public sealed class CHtmlCSSRuleRankingComparer : System.Collections.Generic.IComparer<CHtmlCSSRule>, System.Collections.IComparer
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
        public int Compare(CHtmlCSSRule styleX, CHtmlCSSRule styleY)
        {
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
            int rankComp = styleY.___SelectorRanking.CompareTo(styleX.___SelectorRanking);
            if (rankComp != 0)
            {
                return rankComp;
            }
            else
            {
                // ==============================================================================================
                // as we check may sites SelectorConmaCount should be higher rank than MediaQueryRanking
                // see http://recode.net
                // ==============================================================================================
                int selectorConmaComp = styleX.___SelectorConmaCount.CompareTo(styleY.___SelectorConmaCount);
                if (selectorConmaComp != 0)
                {
                    return selectorConmaComp;
                }

                int mediaRatio = styleY.___SelectorMediaQueryRanking.CompareTo(styleX.___SelectorMediaQueryRanking);
                if (mediaRatio != 0)
                {
                    return mediaRatio;
                }
                else
                {


                    return styleX.___CSSPosition.CompareTo(styleY.___CSSPosition);

                }

            }
        }
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
		   int rankComp = styleY.___SelectorRanking.CompareTo(styleX.___SelectorRanking);
           if (rankComp != 0)
           {
               return rankComp;
           }
           else
           {
               // ==============================================================================================
               // as we check may sites SelectorConmaCount should be higher rank than MediaQueryRanking
               // see http://recode.net
               // ==============================================================================================
               int selectorConmaComp = styleX.___SelectorConmaCount.CompareTo(styleY.___SelectorConmaCount);
               if (selectorConmaComp != 0)
               {
                   return selectorConmaComp;
               }

               int mediaRatio = styleY.___SelectorMediaQueryRanking.CompareTo(styleX.___SelectorMediaQueryRanking);
               if (mediaRatio != 0)
               {
                   return mediaRatio;
               }
               else
               {


                   return styleX.___CSSPosition.CompareTo(styleY.___CSSPosition);

               }

           }

		}
		#endregion
	}
}