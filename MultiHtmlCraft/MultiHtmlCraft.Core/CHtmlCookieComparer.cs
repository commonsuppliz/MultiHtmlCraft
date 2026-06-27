using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Core
{
    public class CHtmlCookieComparer : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {

            CHtmlCookie cookieX = x as CHtmlCookie;
            CHtmlCookie cookieY = y as CHtmlCookie;
            if (cookieX == null && cookieY == null)
            {
                return 0;
            }
            if (cookieX == null)
            {
                return -1;
            }
            if (cookieY == null)
            {
                return 1;
            }
            return string.CompareOrdinal(cookieX.ToStringComp(), cookieY.ToStringComp());
        }
    }
    public class CHtmlCookieComparerGeneric : System.Collections.Generic.IComparer<CHtmlCookie>
    {
        public int Compare(CHtmlCookie cookieX, CHtmlCookie  cookieY)
        {
            if (cookieX == null && cookieY == null)
            {
                return 0;
            }
            if (cookieX == null)
            {
                return -1;
            }
            if (cookieY == null)
            {
                return 1;
            }
            return string.CompareOrdinal(cookieX.ToStringComp(), cookieY.ToStringComp());
        }
    }
}
