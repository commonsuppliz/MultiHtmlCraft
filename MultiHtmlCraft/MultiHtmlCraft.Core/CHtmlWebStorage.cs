using System;
using System.Collections;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlWebStorage is HTML5 localsStorage and sessionStorage
	/// </summary>
	public sealed class CHtmlWebStorage :CHtmlNode, System.IDisposable, ICommonObjectInterface 
	{
		private bool __hasWebStorageAccessedOnce = false;
		public enum WebStorageStatus : byte {NonInitialized = 0, Init = 1, Read = 2, Written=3, Saved = 10};
		public WebStorageStatus StorageStatus = WebStorageStatus.NonInitialized;
		private System.Collections.Generic.SortedList<string, object> ___ValueList = null;
		/// <summary>
		/// Domain Name
		/// </summary>
		private string ___port = null;
		private string ___host = null;
		private string ___protocol = null;

		private CHtmlWebStorageType _StorageType = CHtmlWebStorageType.localStorage;
		private string _DataFilePath = null;
   
        public CHtmlWebStorage(string strProtocol, string strHost, string strPort, CHtmlWebStorageType storeType)
		{
            this.___protocol = strProtocol;
            this.___host = strHost;
            this.___port = strPort;
			this.__hasWebStorageAccessedOnce = false;
			this.StorageType = storeType;
			this.StorageStatus = WebStorageStatus.NonInitialized;
            this.___ValueList = new System.Collections.Generic.SortedList<string,object>(StringComparer.OrdinalIgnoreCase);
       
		}
		~CHtmlWebStorage()
		{
			this.CleanUp();
		}
		private void CleanUp()
		{
			if(this.StorageStatus == WebStorageStatus.Written && this.___ValueList != null)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
				{
					commonLog.LogEntry("{0} ___hasInner data needs to write", this);
				}
				this.StorageStatus = WebStorageStatus.Saved;
			}
			if(this.___ValueList != null)
			{
				this.___ValueList = null;
			}

     
		}
		/// <summary>
		/// Returns Web Storage Type
		/// </summary>
		public CHtmlWebStorageType StorageType
		{
			get{return  this._StorageType;}
			set{this._StorageType = value;}
		}
		public void setItem(object ___key, object ___value)
		{
			InitSession();
			this.StorageStatus = WebStorageStatus.Written;
            this.___ValueList[commonHTML.GetStringValue(___key)] = ___value;

		}
        private static string ConvertKeyLowerString(object ___key)
        {
            string sKey =  commonHTML.GetStringValue(___key);
            if (sKey.Length != 0)
            {
                return commonHTML.FasterToLower(sKey);
            }
            return sKey;
        }
		public object getItem(object ___key)
		{
			InitSession();
			if(this.StorageStatus != WebStorageStatus.Written || this.StorageStatus != WebStorageStatus.Saved)
			{
				this.StorageStatus = WebStorageStatus.Read;
			}
            object ___objStored = null;
            if(this.___ValueList.TryGetValue(commonHTML.GetStringValue(___key), out ___objStored))
            {
                return ___objStored;
            }
            return null;
		}
		public void removeItem(object ___key)
		{
			InitSession();
			this.StorageStatus = WebStorageStatus.Written;
            this.___ValueList.Remove(commonHTML.GetStringValue(___key));
		}
		public object this[object ___key]
		{
			get
			{
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("calling Web Store by indexer {0} ", ___key );
                }

                object ___objStored = null;
                if (this.___ValueList.TryGetValue(commonHTML.GetStringValue(___key), out ___objStored))
                {
                    return ___objStored;
                }
                return null;
                
			}
			set
			{
                this.setItem(___key, value);
			}
		}
		public object key(object  ___indexObject)
		{
            if (___indexObject is string)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("wired Web Store by {0}.key({1}) it is string... returns null....", this, ___indexObject);
                }
                return null;
            }
            int ___index = commonHTML.GetIntFromObject(___indexObject, 0);
			InitSession();
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling Web Store by {0}.key({1})",this, ___index);
            }
            if (___index >= 0 && ___index < this.___ValueList.Count)
            {
                return this.___ValueList.Keys[___index];
            }
            else
            {
                return null;
            }
		}
		public int length
		{
			get
			{
				InitSession();
				return this.___ValueList.Count;
			}
		}
		public override string ToString()
		{
			return string.Format("WebStorage {0} for {1} : {2}", this.StorageType, this.___host,  this.___ValueList.Count);
		}

		private void InitSession()
		{
			if(this.__hasWebStorageAccessedOnce == true)
			{
				return;
			}
			else
			{
				try
				{
					this.StorageStatus = WebStorageStatus.Init;
                    if (this.___ValueList != null && this.___ValueList.Count > 0)
                    {
                        this.___ValueList.Clear();
                    }
;

				}
				catch(Exception ex)
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
					{
						commonLog.LogEntry("Init Web Store ", ex);
					}
				}
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
				{
					commonLog.LogEntry("{0} ___hasInner been inited", this);
				}
				this.__hasWebStorageAccessedOnce = true;
			}
		}
        public bool hasOwnProperty(string ___name)
        {
            bool ___result = false;
            if (string.IsNullOrEmpty(___name) == true)
            {
                return false;
            }
            if (___name.Length == 6 && string.Equals(___name, "length", StringComparison.Ordinal) == true)
            {
                return true;
            }
            if (this.___ValueList.ContainsKey(___name) == true)
            {
                ___result = true;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.hasOwnProperty(\'{0}\') returns {1}", this, ___name, ___result);
            }
            return ___result;
        }

		public void clear()
		{
			InitSession();

		}
		#region IDisposable ƒƒ“ƒo

		public void Dispose()
		{
			this.CleanUp();
		}

		#endregion

		#region IPropertBox ƒƒ“ƒo

		public void ___setPropertyByIndex(int ___index, object val)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: {0}._x__SetProppertyByIndex({1}) called...", this, ___index);
            }
		}

		public void ___setPropertyByName(string name, object val)
		{
			this.setItem(name, val);
		}

		public bool ___hasPropertyByIndex(int ___index)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}._x__HasProppertyByIndex({1}) called...", this, ___index);
            }
			return true;
		}

		public bool ___hasPropertyByName(string ___name)
		{
            if (string.IsNullOrEmpty(___name) == true)
            {
                return false;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}._x__HasProperty({1}) called...", this, ___name);
            }
            if (___name.Length == 6 && string.Equals(___name, "length", StringComparison.Ordinal) == true)
            {
                return true;
            }
            if (this.___ValueList.ContainsKey(___name))
            {
                return true;
            }
            else
            {
                return false;
            }

		}

		public object ___getPropertyByIndex(int ___index)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}._x__GetPropertyValueByIndex({1}) called...", this, ___index);
            }
			return this.key(___index);
		}

        public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}.___getPropertyByName({1}) called...",  this, ___name);
            }
            switch (___name)
            {
                case "__iterator__":
                    return commonHTML.rhinoForLoopEnumratorFunction;
                case "length":
                    return this.___ValueList.Count;
                default:
                    return this.getItem(___name);
            }

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
        public new IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.Storage;
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
