using System;
using System.Collections;
using MultiHtmlCraft.Interfaces;
using System.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlAttributeList : Collection of CHtmlAttribute
    /// this class is Generic Dictionary Base.
	/// </summary>
	public class CHtmlAttributeList : System.Collections.Generic.Dictionary<string, CHtmlAttribute>, ICommonObjectInterface , IDynamicMetaObjectProvider
	{
        public CHtmlHTMLCollectionType CollectionType = CHtmlHTMLCollectionType.Unknown;

        internal System.WeakReference ___ownerNodeWeakReference = null;
        /// <summary>
        /// Keys Array which is used for access by index
        /// </summary>
        internal string[] ___keysArray = null;
        public CHtmlAttributeList(System.Collections.Generic.IEqualityComparer<string> icom)
		{
            
		
		}
        /// <summary>
        /// Create or check Keys Array
        /// </summary>
        private void ___checkOrCreateKeysArray()
        {
            bool ___needsOperateCopyTo = false;
            if (this.___keysArray == null || this.___keysArray.Length != this.Keys.Count)
            {
                this.___keysArray = new string[base.Keys.Count];
                ___needsOperateCopyTo = true;
            }
            if (___needsOperateCopyTo == true)
            {
                base.Keys.CopyTo(this.___keysArray, 0);
            }
        }
        /// <summary>
        /// GetKey By Position
        /// </summary>
        /// <param name="___index"></param>
        /// <returns></returns>
        public string GetKey(int ___index)
        {
            this.___checkOrCreateKeysArray();
            if (___index >= 0 && ___index < this.___keysArray.Length)
            {
                return this.___keysArray[___index];
            }
            return "";
        }
		public void Add(string key, object value)
		{
			try
			{
				if(value is CHtmlAttribute)
				{
                    base[key] = value as CHtmlAttribute;
					return;
				}
				else
				{
					CHtmlAttribute newAttr = new CHtmlAttribute();
                    newAttr.name = key.ToString();
					newAttr.___tagName = newAttr.name;
					newAttr.value  = value;
					base[newAttr.name] = newAttr;
					return;
				}
			} 
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
				{
					commonLog.LogEntry("CHtmlAttributeList Add Failed : {0} {1} {2} ",  key, value, ex.Message);
				}
			}
		}
		public int length
		{
			get{return this.Count;}
		}
		public override string ToString()
		{
			return string.Format("{0}[{1}]", this.CollectionType, this.Count);
		}
        public CHtmlAttribute getNamedItemNS(string ___p1, string ___p2)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: entering {0}.getNamedItemNS({1}) ", this, ___p1, ___p2);
            }
            CHtmlAttribute attr = null;
            if(base.TryGetValue(___p2, out attr))
            {
                return attr;
            }
            return null;
        }
        public CHtmlAttribute GetByIndex(int ___index)
        {
            this.___checkOrCreateKeysArray();
            if (___index >= 0 && ___index < this.___keysArray.Length)
            {
                string strKey = this.___keysArray[___index];
                CHtmlAttribute attr = null;
                if (base.TryGetValue(strKey, out attr) == true)
                {
                    return attr;
                }
            }
            return null;
        }
       
        public CHtmlAttribute getNamedItem(string _sName)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("entering {0}.getNamedItem({1}) ", this, _sName);
            }
            CHtmlAttribute attr = null;
            if (base.TryGetValue(_sName, out attr) == true)
            {
                return attr;
            }
            return null;
        }
        public void setNamedItem(object ___valueAttr)
        {
            this.___setNamedItemInner(null, null, ___valueAttr);
        }
        public void setNamedItemNS(string ___nameSpace,  object ___valueAttr)
        {
            this.___setNamedItemInner(___nameSpace, null, ___valueAttr);
        }
        private void ___setNamedItemInner(string ___nameSpane, string ___name, object ___valueAttr)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("entering {0}.setNamedItem({1}, {2}, {3}) ", this, ___nameSpane, ___name, ___valueAttr);
            }
            CHtmlAttribute __attrNew = null;
            if (___valueAttr is CHtmlAttribute)
            {
                __attrNew = ___valueAttr as CHtmlAttribute;
            }
            if (__attrNew != null)
            {
                base[__attrNew.___name] = __attrNew;
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("{0}.setNamedItem({1}, {2}, {3}) success", this, ___nameSpane, ___name, ___valueAttr);
                }
                return;
            }
            else
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("BUGBUG! {0}.setNamedItemInner({1}, {2}, {3}) failed ", this, ___nameSpane, ___name, ___valueAttr);
                }
            }
        }
		/*
		public object this[int o]
		{
			___getInner
			{
				return base[o];
			}
			set
			{
			
				base[o] = value;
				
			}
		}
		*/
		/// <summary>
		/// IE Specific XML Dom
		/// </summary>
		/// <param name="oNew"></param>
		/// <param name="oref"></param>
		/// <returns></returns>
		
		public CHtmlAttribute insertBefore(object _objNew, object __refAttribute)
		{
            int posRef = -1;
			if(posRef == -1)
			{
				if(_objNew != null && _objNew is CHtmlAttribute)
				{
					CHtmlAttribute _ctmlAttribute = _objNew as CHtmlAttribute;
					if(_ctmlAttribute != null)
					{
						
						this[_ctmlAttribute.name] = _ctmlAttribute;
						return  _ctmlAttribute;
					}

				}
			}
			else
			{

				if(_objNew != null && _objNew is CHtmlAttribute)
				{
					CHtmlAttribute _ctmlAttribute = _objNew as CHtmlAttribute;
					if(_ctmlAttribute != null)
					{

						this[_ctmlAttribute.name] = _ctmlAttribute;
						return  _ctmlAttribute;
					}

				}
			}
			return null;
		}
		public  object this[object key]
		{
           
			get
			{
                CHtmlAttribute objReturn = null;
				if(key is string)
				{
                    if (base.TryGetValue(key as string, out objReturn) == true)
                    {
                        return objReturn;
                    }
                    return null;
                }

                else if (key != null && commonHTML.isClrNumeric(key))
                {
                    int __intKey = Convert.ToInt32(key);
                    if (__intKey >= 0 && base.Count > __intKey)
                    {
                        return this.GetByIndex(__intKey);
                    }
                    else
                    {
                        return null;
                    }
                }

                else
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("CHtmlAttributeList Unknown type indexer {0}, return null.", key);
                    }
                    return null;
                }
			}
			set
			{
				try
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 150)
					{
						commonLog.LogEntry("trying set item[{0}] value from '{1}' ", key, this);
					}
					if(key is String)
					{
                        string _strKey = key as string;
						if(value is CHtmlAttribute)
						{
                            base[_strKey] = value as CHtmlAttribute;
						}
						else
						{
							CHtmlAttribute newAttr = new CHtmlAttribute();
							newAttr.name = _strKey;
							newAttr.___tagName = _strKey;
							newAttr.@value = value;
							base[_strKey] = newAttr;
						}
					}
					else if(commonHTML.isClrNumeric(key) == true)
					{
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("TODO {0} failed to set value '{1}' = {2}", this, key, value);
                        }
						
					}
				}
				catch(Exception ex)
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
					{
						commonLog.LogEntry("{0} failed to set value '{1}' = {2} {3}", this, key, value, ex.Message);
					}
				}
			}
		}
		public object item(object _key)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 500)
            {
               commonLog.LogEntry("calling item({0}) to ___getInner value '{1}' ", _key, this);
            }
            if(_key is string)
			{
                return base[commonHTML.GetStringValue(_key)];
			}
            int intValue = (int)commonData.GetDoubleFromObject(_key,-1);
            if (intValue >= 0 && intValue < this.Count)
            {
                return this.GetByIndex(intValue);
            }


            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}.item({1}) ___hasInner failed. may be unkown type... ", this, _key);
            }
			return null;
		}
   
        public bool hasOwnProperty(object _oname)
        {


            return false;
        }
        internal double ___getAttributeByNameInDouble(string ___attrName, int ___criteria)
        {
            CHtmlAttribute attr = null;
            if (this.TryGetValue(___attrName, out attr) == true)
            {
                return commonData.GetDoubleFromObject(attr.___value, ___criteria);
            }
            return 0;
        }
		
		#region IPropertBox ƒƒ“ƒo

		public object ___getPropertyByName(string ___name)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("calling {0}.GetPropertyValue for  \'{1}\'", this, ___name);
			}
            
			switch(___name)
			{
				case "length":
					return this.Count;
                case "nodeType":
                    return null; // Chrome does not have nodeType
                case "__iterator__":
					//return commonHTML.rhinoForLoopEnumratorFunction;
					return null;
				default:
					try
					{
                        // NOTE) attibutes["property"] should returns CHtmlAttributes Object (Not Value) appropriate
                        //           ex. meta element ["property"]
                        //           if value is exists with key value.
                       //           if attributes is not found, it will retuns null.
                        CHtmlAttribute ___objReturn = null;
                        if (base.TryGetValue(___name, out ___objReturn))
                        {
                            if (___objReturn != null)
                            {
                                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                                {
                                   commonLog.LogEntry("{0}.GetPropertyValue({1}) will returns {2}", this, ___name, ___objReturn);
                                }
                                return ___objReturn;
                            }
                        }
					}
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                        }
                    }
					break;
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("{0}.GetPropertyValue({1})' retuns null....",this, ___name);
			}
			return null;
		}

		public void ___setPropertyByName(string ___name, object val)
		{
            
			if(val is CHtmlAttribute)
			{
				this[___name] = val;
			}
			else
			{
				CHtmlAttribute newAttr = new CHtmlAttribute();
				newAttr.name = ___name;
				newAttr.value = val;
				this[___name] = newAttr;
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 10)
			{
				commonLog.LogEntry("{0} SetPropertyValue by Name {1}={2}", this.GetType(), ___name, val);
			}
											 
		}

		/// <summary>
		/// attibutes[0] should returns CHtmlAttribute Node. not value it self
		/// </summary>
		/// <param name="___index"></param>
		/// <returns></returns>
		public object ___getPropertyByIndex(int ___index)
		{
			try
			{
				if(___index >= 0 && ___index < this.Count)
				{

					CHtmlAttribute retAttr = this.GetByIndex(___index) as CHtmlAttribute;
                    if (retAttr != null)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("{0}.GetPropertyValueByIndex({1}) returns {2}.", this, ___index, retAttr);
                        }
                        return retAttr;
                    }
				}
			}
			catch (Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
				{
					commonLog.LogEntry("___getPropertyByName by index ___hasInner exception", ex);
				}
			}
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}.GetPropertyValueByIndex({1}) returns null.", this, ___index);
            }
			return null;
		}
		public void ___setPropertyByIndex(int ___index, object val)
		{
			try
			{
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("TODO: SetPropertyValue {0} {1} : {2}", this, ___index, val);
                }
			}
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
				{
					commonLog.LogEntry("SetPropertyValue {0} {1} : {2}", ___index, val, ex.Message);
				}
			}
		}

		public bool ___hasPropertyByName(string ___name)
		{
			return false;

		}
		public bool ___hasPropertyByIndex(int ___index)
		{
			if(___index >=0 && ___index < this.Count)
			{
				return true;
			}
			else
			{
				return false;
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
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.NamedNodeMap;
            }
        }


        #endregion

        #region IDyamicMetaObjectProvider support to get and set properties
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlAttributeList>(parameter, this);
        }
        public object GetDynamicMember(string name)
        {
            object objValue = null;
           // this.___properties.TryGetValue(name, out objValue);
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
            //this.___properties[name] = value;
        }
        public IEnumerable<string> GetDynamicMemberNames()
        {
            List<string> members = new List<string>();
			/*
            members.AddRange(CHtmlDocumentProperties.Keys);
            if (this.___properties.Count > 0)
            {
                members.AddRange(this.___properties.Keys);
            }
			*/
            return members;
        }
        #endregion
    }
}
