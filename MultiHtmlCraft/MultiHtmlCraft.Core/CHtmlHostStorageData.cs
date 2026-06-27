using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Core
{
    [Serializable]
    public sealed class CHtmlHostStorageData
    {
        public System.Collections.Generic.Dictionary<string, string> urlList;
        public CHtmlHostStorageData()
        {
            this.urlList = new Dictionary<string,string>(StringComparer.Ordinal);
        }

    }
}
