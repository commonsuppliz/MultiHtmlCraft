using System;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlStyleElementPseudoClassValue 
	/// </summary>
	public struct CHtmlStyleElementPseudoClassValue 
	{
		public CHtmlStyleElementPseudoClassValueType ValueType;
		public CHtmlElementType ParameterTagType;
        public CHtmlPseudoClassType PseudoType;

        public string name;
        public object value;
        

        /// <summary>
        /// ArrayList holds StyleElement for ":not" or ":matches" psudo classes
        /// </summary>
        public System.Collections.ArrayList SubStyleElementList;
		
        public CHtmlStyleElementPseudoClassValue CloneValue()
        {
            CHtmlStyleElementPseudoClassValue val = new CHtmlStyleElementPseudoClassValue();
            val.ValueType = this.ValueType;
            val.ParameterTagType = this.ParameterTagType;
            val.PseudoType = this.PseudoType;
            if (this.SubStyleElementList != null && this.SubStyleElementList.Count > 0)
            {
                val.SubStyleElementList = new System.Collections.ArrayList();
                val.SubStyleElementList.AddRange(this.SubStyleElementList as System.Collections.ICollection);
            }
            return val;
        }
	}
}
