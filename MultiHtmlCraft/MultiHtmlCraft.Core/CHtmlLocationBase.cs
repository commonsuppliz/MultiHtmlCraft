using System;
using System.Text;
using System.ComponentModel;
using MultiHtmlCraft.Interfaces;
using System.Collections;
using System.Runtime.InteropServices;

using System.Dynamic;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace MultiHtmlCraft.Core
{
	/*[TypeConverter(typeof(LocationBaseConverter))]*/
	[ComVisible(true)]
	
	// =============================================================================
	// MS JScript causes trouble when accessing System.IConvertible
	// Use Simple Class
	// =============================================================================
	public class CHtmlLocationBase : CHtmlNode, ICommonObjectInterface, IDynamicMetaObjectProvider
    {
        internal static Dictionary<string, int> CHtmlLocationBaseProperties = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "href", 0 },
            { "protocol", 1 },
            { "host", 2 },
            { "hostname", 3 },
            { "port", 4 },
            { "pathname", 5 },
            { "search", 6 },
            { "hash", 7 },
            { "origin", 8 }
        };
        internal static Dictionary<string, int> CHtmlLocationBaseMethods = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "reload", 0 },
            { "replace", 1 },
            { "assign", 2 },
            { "toString", 3 },
            { "valueOf", 4 }
        };
        internal Type ___ownerObjectType = typeof(object);

        internal bool ___IsAdhocLocation = false;

		private string _href = null;
		private string _protocol = null;
		private string _host = null;
		private string _hostname = null;
		private string _hash = null;
		private string _pathname = null;
		/// <summary>
		/// Locatoin port is string not number
		/// </summary>
		private string _port = null;
		private string _search = null;
		private string _origin = null;
		private System.WeakReference _ownerObject = null;
		internal static object toStringFunctionOfRhino = null;
		internal bool ___DisableLocationAnalyzation = false;
        internal bool ___DisableHrefNavigate = false;
        internal CHtmlUriProtocolType ___protocolType = CHtmlUriProtocolType.None;
		public object ownerElement
		{
			get{
                if (this._ownerObject != null)
                {
                    return this._ownerObject.Target;
                }
                else
                {
                    return null;
                }
            }
			set{
                if (value != null)
                {
                    this._ownerObject = new System.WeakReference(value, false);
                    this.___ownerObjectType = value.GetType();
                }
                else
                {
                    this._ownerObject = null;
                }
                
            }
		}
	
		public CHtmlLocationBase()
		{
			

		}
		public string protocol
		{
			set{this._protocol = value;}
			get{return  commonHTML.___convertNullToEmpty(this._protocol);}
		}
		public string host
		{
			set{this._host = value;}
			get{return  commonHTML.___convertNullToEmpty(this._host);}
		}
		public string hostname
		{
			set{this._hostname = value;}
			get{return  commonHTML.___convertNullToEmpty(this._hostname);}
		}
		public string port
		{
			set{this._port = value;}
			get{return commonHTML.___convertNullToEmpty(this._port);}
		}
		public string href
		{
			get{
                return commonHTML.___convertNullToEmpty(this._href);
			}
			set
			{
                if (this.___DisableLocationAnalyzation == false)
                {
                    string ___strOldHref = null;
                    if (string.IsNullOrEmpty(this._href) == false)
                    {
                        ___strOldHref = string.Copy(this._href);
                    }
                    this._href = value;
                    this.___AnalyzeLocation();
                    if (this.___DisableHrefNavigate == false)
                    {
                        if (string.Equals(___strOldHref, this._href, StringComparison.Ordinal) == false)
                        {
                            this.PerformNavigationIfNesseary();
                        }
                    }
                    
                }
                else
                {
                    this._href = value;
                }
			}
		}
        public int ___indexOf_Inner(object __find)
        {
            string findString = commonHTML.GetStringValue(__find);
            int r = this._href.IndexOf(findString, StringComparison.OrdinalIgnoreCase);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("Location IndexOf({0}) retuns {1} from {2}", __find, r, this._href);
            }
            return r;
        }
        /*
        public int indexOf(object __find)
        {
            return this.___indexOf_Inner(__find);
        }
        public int indexof(object __find)
        {
            return this.___indexOf_Inner(__find);
        }
         */
		public string hash
		{
			set{this._hash = value;}
			get{return   commonHTML.___convertNullToEmpty(this._hash);}

		}
		public string pathname
		{
			set{this._pathname = value;}
			get{return   commonHTML.___convertNullToEmpty(this._pathname);}
		}
		public string search
		{
			set{this._search = value;}
			get{return  commonHTML.___convertNullToEmpty(this._search);}
		}
		public string origin
		{
			get{return commonHTML.___convertNullToEmpty(this._origin);}
		}
			 
		
		public override string ToString()
		{
			return this._href;
		}

        internal bool ___IsHttpOrHttps()
        {
            if (this.___protocolType == CHtmlUriProtocolType.http || this.___protocolType == CHtmlUriProtocolType.https)
            {
                return true;
            }
            return false;
        }

        public object valueOf()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("Location.valueOf() returns location itself" );
            }
            return this;
        }
		
		
		public void reload(bool option)
		{
            this.___reloadInner(option);
		}
		public void reload()
		{
            this.___reloadInner(false);
		}
		private  void ___reloadInner(bool option)
		{
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {  
                   commonLog.LogEntry("calling {0}.reaload({1})", this, option);
                
            }
            if (option == true)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("TODO : needs to reload from server {0}.reaload({1})", this, option);
                }
            }
            return;
		}
		public void Replace(string s)
		{
			this.replaceInner(s);
		}
		public void replace(string s)
		{
			this.replaceInner(s);
		}
		public void replaceInner(string s)
		{
            if (s.IndexOf(':') == -1)
            {
                if (string.IsNullOrEmpty(this._href) == false)
                {
                    if (string.Equals(this._href, s, StringComparison.Ordinal) == false)
                    {
                        string strOld = s;
                        s = commonHTML.GetAbsoluteUri(this._href, null, s);
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                        {
                           commonLog.LogEntry("location.replace('{0}') is changed to {1} ", strOld, s);
                        }
                    }
                }
                else
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("location.replace('{0}') is partical url but no full url ",  s);
                    }
                }
            }
            this.href = s;
		}
		public void assign(string s)
		{

            this.href = s;
		}
        internal void copyFromLocationBase(CHtmlLocationBase ___orignalLocationBase)
        {
            if (___orignalLocationBase != null)
            {
                if (string.IsNullOrEmpty(___orignalLocationBase._href) == false)
                {
                    this._href = string.Copy(___orignalLocationBase._href);
                }
                if (string.IsNullOrEmpty(___orignalLocationBase._protocol) == false)
                {
                    this._protocol = string.Copy(___orignalLocationBase._protocol);
                }
                if (string.IsNullOrEmpty(___orignalLocationBase._port) == false)
                {
                    this._port = string.Copy(___orignalLocationBase._port);
                }
                if (string.IsNullOrEmpty(___orignalLocationBase._host) == false)
                {
                    this._host = string.Copy(___orignalLocationBase._host);
                }
                if (string.IsNullOrEmpty(this._hostname) == true && string.IsNullOrEmpty(this._host) == false )
                {
                    this._hostname = string.Copy(this._host);
                }
                if (string.IsNullOrEmpty(___orignalLocationBase.hash) == false)
                {
                    this._hash = string.Copy(___orignalLocationBase._hash);
                }
                if (string.IsNullOrEmpty(___orignalLocationBase._pathname) == false)
                {
                    this._pathname = string.Copy(___orignalLocationBase._pathname);
                }
                if (string.IsNullOrEmpty(___orignalLocationBase._search) == false)
                {
                    this._search = string.Copy(___orignalLocationBase._search);
                }
                this.___protocolType = ___orignalLocationBase.___protocolType;
            }
        }

		private void PerformNavigationIfNesseary()
		{
            try
            {
                if(this.___ownerObjectType == typeof(CHtmlMultiversalWindow))
                {
                    CHtmlMultiversalWindow multiWindow = this.ownerElement as CHtmlMultiversalWindow;
                    if (multiWindow != null)
                    {
                        CHtmlDocument ___multiDocument = multiWindow.___document;
                        if (___multiDocument != null)
                        {
                            if (___multiDocument.___readyStateType != CHtmlReadytStateType.complete)
                            {
                                ___multiDocument.___MetaRefreshSeconds = 3;
                                ___multiDocument.___MetaRefreshUrl = string.Copy(this._href);
                                ___multiDocument.___MetaRefreshBaseElement = null;
                                ___multiDocument.___HasMetaRefresh = true;
                            }
                            else
                            {
                                multiWindow.___navigateUrl(this._href, "");
                            }
                            return;
                        }
                        else
                        {
                            multiWindow.___navigateUrl(this._href, "");
                        }
                    }
                }
                else if (this.___ownerObjectType == typeof(CHtmlDocument))
                {
                    CHtmlDocument doc = this.ownerElement as CHtmlDocument;
                    if (doc != null)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                        {
                            commonLog.LogEntry("Via Location Object, Document  location changed. redirection using metarefresh : {0} 3 seconds", this._href);
                        }
                        doc.___MetaRefreshSeconds = 3;
                        doc.___MetaRefreshUrl = this._href;
                        doc.___MetaRefreshBaseElement = null;
                        doc.___HasMetaRefresh = true;
                        return;
                    }
                }
                else if (this.___ownerObjectType == typeof(CHtmlElement))
                {
                    CHtmlElement elem = this.ownerElement as CHtmlElement;

                    commonLog.LogEntry("{0} location changed but skip", this);


                }

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("Location", ex);
                }
            }
		}
		
		public bool hasOwnProperty(string _oname)
		{
            switch (_oname)
            {
                case "origin":
                case "href":
                case "host":
                case "hostname":
                case "hostName":
                case "port":
                case "hash":
                case "protocol":
                case "pathname":
                case "pathName":
                case "query":
                case "search":
                case "ancestororigins":
                case "ancestorOrigins":
                case "toString":
                    return true;
            }
            if(base.___properties.ContainsKey(_oname))
            {
                return true;
            }
            return false;
		}
        internal void ___setHrefDirect(string __str)
        {
            this._href = __str;
        }
        internal void ___CopyValuesFromCHtmlUri(CHtmlUri ___uri)
        {
            if (___uri != null)
            {
                if (string.IsNullOrEmpty(___uri.___Href) == false)
                {
                    this._href = string.Copy(___uri.___Href);
                }
                if (string.IsNullOrEmpty(___uri.Protocol) == false)
                {
                    this._protocol = string.Copy(___uri.Protocol);
                }
                if (string.IsNullOrEmpty(___uri.Port) == false)
                {
                    this._port = string.Copy(___uri.Port);
                }
                if (string.IsNullOrEmpty(___uri.Hostname) == false)
                {
                    this._host = string.Copy(___uri.Hostname);
                }
                if (string.IsNullOrEmpty(___uri.Hash) == false)
                {
                    this._hash = string.Copy(___uri.Hash);
                }
                if (string.IsNullOrEmpty(___uri.Query) == false)
                {
                    this._search = string.Copy(___uri.Query);
                }
                this.___protocolType = ___uri.ProtocolType;
                
            }
        }

		
		internal void ___AnalyzeLocation()
		{
            this._port = null;
            this._host = null;
            this._protocol = null;
            this._hostname = null;
            this._host = null;
			this._hash = null;
			try
			{
				CHtmlUri  uri = new CHtmlUri(this._href);
                if (string.IsNullOrEmpty(uri.Protocol) == false)
                {
                    this._protocol = string.Copy(uri.Protocol);
                }
                if (string.IsNullOrEmpty(uri.Hostname) == false)
                {
                    this._hostname = string.Copy(uri.Hostname);
                    this._host = string.Copy(uri.Hostname);
                }
                
				if(string.IsNullOrEmpty(uri.Port) == false)
				{
                    this._port = string.Copy(uri.Port);
				}
				else
				{
				}
                if (string.IsNullOrEmpty(uri.Hash) == false)
                {
                    this._hash = string.Copy(uri.Hash);

                }
                if (string.IsNullOrEmpty(uri.Query) == false)
                {
                    this._search = string.Copy(uri.Query);
                }
				this._origin = this._protocol + "//" + this._hostname;
                if (string.IsNullOrEmpty(uri.Pathname) == false)
                {
                    this._pathname = string.Copy(uri.Pathname);
                }

                this.___protocolType = uri.ProtocolType;
                if (string.Equals(this._href, this._origin, StringComparison.Ordinal) == true)
                {
                    this._href = this._origin + "/";
                }
                uri = null;
				
			} 
			catch (Exception ex)
			{
				if(commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
				{
					commonLog.LogEntry("Analyze Location Faild :{0} {1} ", this._href, ex.Message );
				}

			}

		}
		#region ICloneable メンバ

		public CHtmlLocationBase Clone()
		{
			CHtmlLocationBase urlLocation = new CHtmlLocationBase();
            urlLocation.___protocolType = urlLocation.___protocolType;
            if (string.IsNullOrEmpty(this._href) == false)
            {
                urlLocation._href = string.Copy(this._href);
            }
            if (string.IsNullOrEmpty(this._host) == false)
            {
                urlLocation._host = string.Copy(this._host);
            }
            if (string.IsNullOrEmpty(this.port) == false)
            {
                urlLocation._port = string.Copy(this._port);
            }
            if (string.IsNullOrEmpty(this._protocol) == false)
            {
                urlLocation._protocol = string.Copy(this._protocol);
            }
            if (string.IsNullOrEmpty(this._pathname) == false)
            {
                urlLocation._pathname = string.Copy(this._pathname);
            }
            if (string.IsNullOrEmpty(this._hash) == false)
            {
                urlLocation._hash = string.Copy(this._hash);
            }
            if (string.IsNullOrEmpty(this._search) == false)
            {
                urlLocation._search = string.Copy(this._search);
            }
			return urlLocation;
		}

		#endregion

        public CHtmlCollection ancestorOrigins
        {
            get
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("TODO: Location is creating 0 length ancestorOrigins List ");
                }
                CHtmlCollection ancestororiginsList = new CHtmlCollection();
                ancestororiginsList.___CollectionType = CHtmlHTMLCollectionType.LocationAncestorOriginsList;
                return ancestororiginsList;
            }
        }
		
		#region IConvertible メンバ

		public ulong ToUInt64(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToUInt64 実装を追加します。
			return 0;
		}

		public sbyte ToSByte(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToSByte 実装を追加します。
			return 0;
		}

		public double ToDouble(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToDouble 実装を追加します。
			return 0;
		}

		public DateTime ToDateTime(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToDateTime 実装を追加します。
			return new DateTime ();
		}

		public float ToSingle(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToSingle 実装を追加します。
			return 0;
		}

		public bool ToBoolean(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToBoolean 実装を追加します。
			return false;
		}

		public int ToInt32(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToInt32 実装を追加します。
			return 0;
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToUInt16 実装を追加します。
			return 0;
		}

		public short ToInt16(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToInt16 実装を追加します。
			return 0;
		}

		/*
		string System.IConvertible.ToString(IFormatProvider provider)
		{
			//commonLog.LogEntry("ToString() is called");
			return this._href.ToString();
		}
		*/
		

		public byte ToByte(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToByte 実装を追加します。
			return 0;
		}

		public char ToChar(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToChar 実装を追加します。
			return '\0';
		}

		public long ToInt64(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToInt64 実装を追加します。
			return 0;
		}

		public System.TypeCode GetTypeCode()
		{
			//commonLog.LogEntry("GetTypeCode is called");
			return new System.TypeCode ();
		}

		public decimal ToDecimal(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToDecimal 実装を追加します。
			return 0;
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			//commonLog.LogEntry("ToType is called");
			return null;
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			// TODO:  CHtmlLocationBase.ToUInt32 実装を追加します。
			return 0;
		}
		#endregion	

		#region IPropertBox メンバ

		public object ___getPropertyByName(string ___name)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling ___getPropertyByName for {0} {1} {2} ", this.GetType(), this, ___name);
            }
            
            switch (___name)
			{
                case "__iterator__":
					return null;
				case "href":
                case "Href":
                    if (string.IsNullOrEmpty(this._href) == false)
                    {
                        if (string.Equals(this._href, this._origin, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            return this._href + "/";
                        }
                        else
                        {
                            return this._href;
                        }
                    }
                    else
                    {
                        return "";
                    }
                case "origin":
                    if (string.IsNullOrEmpty(this._protocol) == false && string.IsNullOrEmpty(this._hostname) == false)
                    {
                        return this._protocol + "//" + this._hostname;
                    }
                    else
                    {
                        return "http://" + this._hostname;
                    }
				case "host":
                case "Host":
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                        if (this._host == null)
                        {
                           commonLog.LogEntry("Strange. CHtmlLocationBase host is null....");
                        }
                    }
					return commonHTML.___convertNullToEmpty(this._host);
				case "hostname":
                case "Hostname":
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                        if (this._hostname == null)
                        {

                           commonLog.LogEntry("Strange. CHtmlLocationBase hostname is null....");
                        }
                    }
					return commonHTML.___convertNullToEmpty(this._hostname);
				case "pathname":
                case "pathName":
                case "Pathname":
               
					return commonHTML.___convertNullToEmpty(this._pathname);
				case "port":
                case "Port":
					return commonHTML.___convertNullToEmpty(this._port);
				case "search":
                case "Search":
					return commonHTML.___convertNullToEmpty(this._search);
				case "hash":
					return  commonHTML.___convertNullToEmpty(this._hash);
				case "protocol":
					return commonHTML.___convertNullToEmpty(this._protocol);
				case "tostring":
                case "toString":
					return CHtmlLocationBase.toStringFunctionOfRhino;
                case "ancestororigins":
                case "ancestorOrigins":
                    return this.ancestorOrigins;
                case "nodetype":
                case "nodeType":
                    return null; // nodeType is normally not defined.

				default:
					break;
			}
            object ___propertyObject = null;
            if (base.___properties.TryGetValue(___name, out ___propertyObject))
            {
                if (___propertyObject != null)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("GetPropertyValue for {0} {1} {2} returns {3}", this.GetType(), this, ___name, ___propertyObject);
                    }
                    return ___propertyObject;
                }
            }
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
			}
			// 
			return null;
		}

		public void ___setPropertyByName(string ___name, object val)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling SetPropertyValue for {0} {1}  {2} = {3} ", this.GetType(), this, ___name, val);
            }
			switch(___name)
			{
				case "href":
					try
					{
						this.replace(commonHTML.GetStringValue(val));
					}
					catch{}
					break;
				case "tostring":
                case "toString":
					if(val != null)
					{
						CHtmlLocationBase.toStringFunctionOfRhino = val;
					}
					break;
				case "protocol":
                case "host":
                case "prort":
                case "query":
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
					{
						commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed",this.GetType(), this, ___name, val);
					}
					break;
                default:
                    base.___properties[___name] = val;
                    break;
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
            return this.hasOwnProperty(___name);
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
			return this._href;
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

		#endregion
	}
	public class LocationBaseConverter : System.ComponentModel.ExpandableObjectConverter 
	{
		private ArrayList _values = new ArrayList();

		public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			commonLog.LogEntry("ConvertFrom Called...");
			return base.ConvertFrom (context, culture, value);
		}
		public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, Type sourceType)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("CanConvertFrom Called...");
			}
			return base.CanConvertFrom (context, sourceType);
		}
		public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, Type destinationType)
		{
			commonLog.LogEntry("CanConvertTo Called...");
			return base.CanConvertTo (context, destinationType);
		}

		public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			commonLog.LogEntry("ConvertTo Called...");
			return base.ConvertTo (context, culture, value, destinationType);
		}
		public override System.ComponentModel.PropertyDescriptorCollection GetProperties(System.ComponentModel.ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			commonLog.LogEntry("GetProerties Called...");
			return base.GetProperties (context, value, attributes);
		}
		public override bool GetPropertiesSupported(System.ComponentModel.ITypeDescriptorContext context)
		{
			commonLog.LogEntry("GetPropertiesSupported Called...");
			return base.GetPropertiesSupported (context);
		}
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
		// Returns a StandardValuesCollection of standard value objects.
		public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
		{        
			// Passes the local integer array.
			StandardValuesCollection svc = new StandardValuesCollection(_values);       
			return svc;
		}
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.Location;
            }
        }
        #region IDyamicMetaObjectProvider support to get and set properties
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlLocationBase>(parameter, this);
        }
        SortedList<string, object> ___properties = new SortedList<string, object>();
        public object GetDynamicMember(string name)
        {
            object objValue = null;
            this.___properties.TryGetValue(name, out objValue);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.GetDynamicMember({1} returns : {2}", this, name, objValue);
            }
            return objValue;
        }
        public void SetDynamicMember(string name, object value)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.SettDynamicMember({1} is called value: {2}", this, name, value);
            }
            this.___properties[name] = value;
        }
        public IEnumerable<string> GetDynamicMemberNames()
        {
            return this.___properties.Keys;
        }
        #endregion


    }

}
