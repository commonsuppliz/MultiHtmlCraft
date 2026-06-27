using System;
using System.Runtime.InteropServices;
using System.Collections;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlDTD 
	/// </summary>
	[ComVisible(true)]
	
	public sealed class CHtmlDTD : CHtmlElement
	{

        internal string ___publicId = null;
        internal string ___systemId = null;
        internal string ___dtdname = null;
        internal string ___internalSubset = null;
		public CHtmlDTD()
		{
			this.___elementTagType = CHtmlElementType.DOCTYPE;
			base.___SetNodeType(CHtmlNodeType.DOCUMENT_TYPE_NODE);
		}
        public string publicId
        {
            get { return commonHTML.___convertNullToEmpty(this.___publicId); }
        }
        public string systemId
        {
            get { return commonHTML.___convertNullToEmpty(this.___systemId); }
        }
        public new string name
        {
            get { return commonHTML.___convertNullToEmpty(this.___dtdname); }
        }
        public string internalSubset
        {
            get { return commonHTML.___convertNullToEmpty(this.___internalSubset); }
        }
        public override bool ___hasPropertyByName(string ___name)
        {
            switch (___name)
            {
                case "name":
                case "publicId":
                case "systemId":
                case "internalSubset":
                    return true;
            }
            return false;
        }
        public override object ___getPropertyByName(string ___name)
        {
            switch (___name)
            {
                case "name":
                    return commonHTML.___convertNullToEmpty(this.___dtdname);
                case "publicId":
                    return commonHTML.___convertNullToEmpty(this.___publicId);
                case "systemId":
                    return commonHTML.___convertNullToEmpty(this.___systemId);
                case "internalSubset":
                    return commonHTML.___convertNullToEmpty(this.___internalSubset);
            }
            return base.___getPropertyByName(___name);
        }

	}
}
