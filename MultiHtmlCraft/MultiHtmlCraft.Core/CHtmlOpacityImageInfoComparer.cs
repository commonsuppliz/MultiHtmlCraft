using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// Comarer  Opacity Changed Image into List
    /// </summary>
    public sealed class CHtmlOpacityImageInfoComaprer : System.Collections.Generic.IEqualityComparer<CHtmlOpacityImageInfo>, System.Collections.IComparer
    {
        public int Compare(CHtmlOpacityImageInfo imgInfoX, CHtmlOpacityImageInfo imgInfoY)
        {
            if (imgInfoX == null && imgInfoY == null)
            {
                return 0;
            }
            if (imgInfoX == null)
            {
                return -1;
            }
            if (imgInfoY == null)
            {
                return 1;
            }
            int UrlResult = string.Compare(imgInfoX.Url, imgInfoY.Url, StringComparison.Ordinal);
            if (UrlResult != 0)
            {
                return UrlResult;
            }
            else
            {
                return imgInfoX.Opacity.CompareTo(imgInfoY.Opacity);
            }
        }
        public int GetHashCode(CHtmlOpacityImageInfo imgInfoX)
        {
            return imgInfoX.GetHashCode();
        }
        public bool Equals(CHtmlOpacityImageInfo imgInfoX, CHtmlOpacityImageInfo imgInfoY)
        {
            if (this.Compare(imgInfoX, imgInfoY) == 0)
            {
                return true;
            }
            return false;
        }
        public int Compare(object imgInfoXObject, object imgInfoYObject)
        {
            CHtmlOpacityImageInfo imgInfoX = imgInfoXObject as CHtmlOpacityImageInfo;
            CHtmlOpacityImageInfo imgInfoY = imgInfoXObject as CHtmlOpacityImageInfo;
            if (imgInfoX == null && imgInfoY == null)
            {
                return 0;
            }
            if (imgInfoX == null)
            {
                return -1;
            }
            if (imgInfoY == null)
            {
                return 1;
            }
            int UrlResult = string.Compare(imgInfoX.Url, imgInfoY.Url, StringComparison.Ordinal);
            if (UrlResult != 0)
            {
                return UrlResult;
            }
            else
            {
                return imgInfoX.Opacity.CompareTo(imgInfoY.Opacity);
            }
        }
    }
}
