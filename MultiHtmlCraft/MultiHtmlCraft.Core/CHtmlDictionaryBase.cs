using System;
using System.Collections.Generic;

using System.Text;


namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// This class is simple inherits of System.Collections.Generic.Dictionary
    /// to replace System.Collections.SortedList which is used for NDP 1.1
    /// 1) string
    /// 2) object
    /// </summary>
    public class CHtmlDictionaryBase : System.Collections.Generic.Dictionary<string, object>
    {
        public CHtmlDictionaryBase(IEqualityComparer<string> comp)
            : base(comp)
        {
        }
        public object GetByIndex(int i)
        {
            object[] arArray = new object[base.Count];
            base.Values.CopyTo(arArray, 0);
            
            if (i >= 0 && i < arArray.Length)
            {
                return arArray[i];
            }
            arArray = null;
            return null;
        }
        public string GetKey(int i)
        {
            string[] __copyKeys = new string[base.Count];
            base.Keys.CopyTo(__copyKeys, 0);
            int pos = 0;
            foreach (string s in __copyKeys)
            {
                if (pos == i)
                {
                    return s;
                }
                pos++;

            }
            return "";
        }
    }
}
