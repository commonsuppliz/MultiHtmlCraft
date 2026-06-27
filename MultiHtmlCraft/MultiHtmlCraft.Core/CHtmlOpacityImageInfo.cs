using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Core
{
    public sealed class CHtmlOpacityImageInfo
    {
        public string Url;
        public float Opacity;
        public CHtmlOpacityImageInfo(string ___Url, float ___Opacity)
        {
            Url = ___Url;
            Opacity = ___Opacity;
        }
    }

}
