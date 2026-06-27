using System;
using System.Runtime.InteropServices;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlLinkBase is object inner of document.links
	/// </summary>
	[ComVisible(true)]
	
	public class CHtmlLinkItem :  ICommonObjectInterface
	{
		private string ___nameofElement = null;
		private string ___text = null;
		private string ___target = null;
		private string ___id = null;
		private string ___rel = null;
		private string ___nodeName = null;
        private string ___href = null;

		private System.WeakReference ___ownerElementWeakReference = null;


		public CHtmlLinkItem()
		{
			
		}
		#region IPropertBox ƒƒ“ƒo

		public  void ___setPropertyByName(string name, object val)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("calling SetPropertyValue for {0} {1} {2}={3}",this.GetType(), this,  name, val);
			}
			CHtmlElement ___ownerElement = this.____GetOwerElement();
			if(___ownerElement != null)
			{
				// Since most of propery of CHtmlLocationBase is eqal to CHtmlElement,
				// We use ownerElement property seter.
				//
				___ownerElement.___setPropertyByName(name, val);
			}
		}

		public bool ___hasPropertyByName(string name)
		{
			return true;
		}
		public bool ___hasPropertyByIndex(int ___index)
		{
			return true;
		}

		public void ___setPropertyByIndex(int ___index, object val)		
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed",this.GetType(), this, ___index, val);
			}
		}
		public object ___getPropertyByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed",this.GetType(), this, ___index);
			}
			return null;
		}
		public object ___common_object_clone()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("x__Clone {0} {1} called",this.GetType(), this);
			}
			return this;
		}
		public void ___deleteByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}",this.GetType(), this, ___index);
			}
		}
		public void ___deleteByName(string ___name)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByName {0} {1} called : {2}",this.GetType(), this, ___name);
			}

		}
		public object[] ___getByIds()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getByIds() {0} {1} called",this.GetType(), this);
			}
				return null;

		}
		public string ___getClassName()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getClassName {0} {1} called",this.GetType(), this);
			}
			return this.GetType().Name;
		}
		public object ___getDefaultValue()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getDefaultValue {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public object ___getParentScope()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getParentScope {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public void ___setParentScope(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___setParentScope {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}
		public object ___getProtoType()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getProtoType {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public bool ___hasInstance(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___hasInstance {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return false;
		}
		public bool ___instanceEquals(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___instanceEquals {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return object.ReferenceEquals(this, ___object);
		}
		public void ___setProtoType(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___setProtoType {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}

		internal void SetPropertiesFromElement(CHtmlElement element)
		{
			try
			{
				if(element != null)
				{
					if(string.IsNullOrEmpty(element.___hrefBase.___Href) == false)
					{
						this.___href = string.Copy(element.___hrefBase.___Href);
					}
					if(string.IsNullOrEmpty(element.___name) == false)
					{
                        this.___nameofElement = string.Copy(element.___name);
					}
					if(element.___attributes.ContainsKey("target"))
					{
						this.___target = string.Copy(commonHTML.GetElementAttributeInString(element, "target"));
					}
					if(string.IsNullOrEmpty(element.___id) == false)
					{
						this.___id = string.Copy(element.___id);
					}
					if(element.___attributes.ContainsKey("rel"))
					{
						this.___rel = string.Copy(commonHTML.GetElementAttributeInString(element, "rel"));
					}

					this.___nodeName = element.nodeName;
					
	
					this.___ownerElementWeakReference = new WeakReference(element, false);
				}
			}
			catch{}
		}
		private string ___GetHrefProperty(string _propname)
		{
			if(string.IsNullOrEmpty(this.___href) == false)
			{
                CHtmlUri ___uri = new CHtmlUri();
                ___uri.href = string.Copy(___href);
				switch(_propname)
				{
					case "protocol":
						return ___uri.Protocol + ":";
					case "host":
					case "hostname":
                        return ___uri.Hostname;
					case "hash":
                        return ___uri.Hash;
					case "port":
                        return ___uri.Port;

					case "search":
                        return ___uri.Query;
					case "pathname":
                        return ___uri.Pathname;
				}
			}
			return "";
		}

        public object ___getPropertyByName(string ___name)
		{

            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("entering {0}.__GetPropertyValue('{1}')", this, ___name);
            }
			switch(___name)
			{
				case "href":
					return commonHTML.___convertNullToEmpty(this.___href);
				case "hostname":
                case "hostName":
					return ___GetHrefProperty("hostname");
				case "host":
					return ___GetHrefProperty("hostname");
				case "hash":
					return ___GetHrefProperty("hash");
				case "name":
                    return commonHTML.___convertNullToEmpty(this.___nameofElement);
				case "target":
					return commonHTML.___convertNullToEmpty(this.___target);
				case "text":
					return commonHTML.___convertNullToEmpty(this.___text);
				case "protocol":
					return ___GetHrefProperty("protocol");
				case "pathname":
					return ___GetHrefProperty("pathname");
				case "search":
					return ___GetHrefProperty("search");
				case "port":
					return ___GetHrefProperty("port");
				case "id":
					return commonHTML.___convertNullToEmpty(this.___id);
				case "rel":
					return commonHTML.___convertNullToEmpty(this.___rel);
				case "nodename":
                case "nodeName":
					return commonHTML.___convertNullToEmpty(this.___nodeName);
				case "class":
				case "classname":
                case "className":
					CHtmlElement ___ownerElement = this.____GetOwerElement();
					if(___ownerElement != null)
					{
						return ___ownerElement.className;
					}
					return "";
				default:
					break;
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed",this.GetType(), this, ___name);
			}
			return "";
		}
		public CHtmlElement ____GetOwerElement()
		{
			if(this.___ownerElementWeakReference != null)
			{
				return this.___ownerElementWeakReference.Target as CHtmlElement;
			}
			return null;
		}
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.HTMLLinkElement;
            }
        }
		#endregion

	}
}
