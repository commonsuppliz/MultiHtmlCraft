
using System;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlElementDataSet HTML5 DataSet Class
	/// </summary>
	public class CHtmlElementDataSet: ICommonObjectInterface
	{
        private System.WeakReference __ownerElementWeakReference = null;
		public CHtmlElementDataSet()
		{
			// 
			// 
			//
		}

		public CHtmlElement parentNode
		{
			get{
                if(this.__ownerElementWeakReference != null)
                {
                    return this.__ownerElementWeakReference.Target as CHtmlElement;
                }
                return null;
            }
			set{this.__ownerElementWeakReference = new WeakReference(value, false);}
		}
        /// <summary>
        /// Convert string "SampleExample" to "data-Sample-Example";
        /// </summary>
        /// <param name="__nonData"></param>
        /// <returns></returns>
        internal static string ___ConvertNonDataPrefixStringIntoDataPrifiexedString(string __nonData)
        {
            char[] cs = __nonData.ToCharArray();
            System.Text.StringBuilder sbText = new System.Text.StringBuilder();
            sbText.Append("data-");
            bool IsLastCharLower = false;
            bool IsLastCharUpper = false;
            int csLen = cs.Length;
            for (int i = 0; i < csLen; i++)
            {
                char c = cs[i];
                if(c >= 'a' && c <= 'z')
                {
                    sbText.Append(c);
                    if (IsLastCharLower == false)
                    {
                        IsLastCharLower = true;
                    }
                    if (IsLastCharUpper == false)
                    {
                        IsLastCharUpper = false;
                    }
                    continue;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    if (sbText.Length > 5)
                    {
                        if (IsLastCharLower == true)
                        {
                            sbText.Append('-');
                        }
                    }
                    sbText.Append(c);

                    IsLastCharLower = false;
                    IsLastCharUpper = true;
                    continue;
                }
                else
                {
                    sbText.Append(c);
                    IsLastCharLower = true;
                    IsLastCharUpper = false;
                    continue;
                }
            }
            return sbText.ToString();
        }
        /// <summary>
        /// Convert string  "data-Sample-Example-sample" to SampleExampleSample
        /// </summary>
        /// <param name="__nonData"></param>
        /// <returns></returns>
        internal static string ___ConvertStringIntoNonDataPrefiexString(string __nonData)
        {
            if (__nonData.Length == 0)
                return "";

            if (__nonData.StartsWith("data-", StringComparison.OrdinalIgnoreCase) == true)
            {
                System.Text.StringBuilder sbText = new System.Text.StringBuilder(__nonData);
                sbText.Remove(0, 4);
                return sbText.ToString();
            }
            else
            {
                return __nonData;
            }
        }
		#region IPropertBox ƒƒ“ƒo

		public object ___getPropertyByName(string ___name)
		{
			if(___name == null ||  ___name.Length == 0)
				return null;
	
                string __dataKey = ___ConvertNonDataPrefixStringIntoDataPrifiexedString(___name);
				CHtmlElement parentElement = this.parentNode;
				if(parentElement != null)
				{

                    if (parentElement.___attributes.ContainsKey(__dataKey) == true)
                    {
                        return commonHTML.GetElementAttributeInString(parentElement, __dataKey);
                    }
					
				}
              
			
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
			}
			// dataset should returns undefined if not exists
			return null;
		}


		public void ___setPropertyByName(string ___name, object val)
		{
			if(___name == null || ___name.Length == 0)
				return;
			if(this.__ownerElementWeakReference  != null)
			{
                CHtmlElement parentElement = this.parentNode;
                if (parentElement != null)
				{
                    string __dataKey = ___ConvertNonDataPrefixStringIntoDataPrifiexedString(___name);
					CHtmlAttribute attr =new CHtmlAttribute();
					attr.name = __dataKey;
					attr.value = commonHTML.GetStringValue(val);
                    attr.setParentNode(parentElement);
                    parentElement.___attributes[__dataKey] = attr;
					return;
				}
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed",this.GetType(), this, ___name, val);
			}
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
				commonLog.LogEntry("GetPropertyValueInex for {0} {1} {2} failed",this.GetType(), this, ___index);
			}
			return null;
		}

		public bool ___hasPropertyByName(string ___name)
		{
			if(___name == null ||  ___name.Length == 0)
				return false;
            string _namePrefixed = ___ConvertNonDataPrefixStringIntoDataPrifiexedString(___name);
			CHtmlElement __element = this.parentNode;
			if(__element != null)
			{
                if (__element.___attributes.ContainsKey(_namePrefixed))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
		public bool ___hasPropertyByIndex(int ___index)
		{
			return true;
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
        public override string ToString()
        {
            return "[object " + this.multiversalClassType.ToString() + "]";
        }
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.DOMStringMap;
            }
        }

		#endregion
        public bool isPrototypeOf(object ___protoObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.isPrototpyeOf('{1}') ", this, ___protoObject);
            }
            switch (commonHTML.isPrototypeOf_precheck(this, ___protoObject))
            {
                case 0:
                default:
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("TODO:  {0}.isPrototpyeOf('{1}') test needs more test. returns true for now... ", this, ___protoObject);
                    }
                    break;
                case 1:
                    return true;
                case 2:
                    return false;
            }
            return true;
        }
	}
}
