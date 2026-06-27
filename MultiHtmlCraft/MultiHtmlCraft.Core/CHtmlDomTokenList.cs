using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
using System.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlDomTokenList is collections of class Name list of each element
	/// </summary>
	public class CHtmlDomTokenList : CHtmlNode, ICHtmlDomTokenInterface, ICommonObjectInterface , IDynamicMetaObjectProvider, IEnumerable
	{
        internal static Dictionary<string, int> CHtmlDomTokenListProperties = getCHtmlDomTokenProperties();
        internal static Dictionary<string, int> CHtmlDomTokenListMethods = getCHtmlDomTokenMethods();

        private static Dictionary<string, int> getCHtmlDomTokenProperties()
        {
            Dictionary<string, int> propList = new Dictionary<string, int>
            {
                       
            { "length", 1},
            { "value", 3},

            };
            return propList;
        }
        private static Dictionary<string, int> getCHtmlDomTokenMethods()
        {
            Dictionary<string, int> methodList = new Dictionary<string, int>
            {

            { "add", 1},
            { "contains", 2},
            { "entries", 3},
                        { "keys", 4},
                                    { "remove", 5},
                                       { "replace", 6},
                                          { "supports",7},
             { "toggle",8},
                          { "values",9},
            };
            return methodList;
        }

        internal CHtmlBase ___parentBase;

        internal string[] ___strKeyArray;

		public CHtmlHTMLCollectionType CollectionType = CHtmlHTMLCollectionType.Unknown;

        /// <summary>
        /// List actually holds string class value (case insensitive).
        /// </summary>
        internal System.Collections.Generic.Dictionary<string, int> ___keyList;
		public CHtmlDomTokenList()
		{
			this.CollectionType = CHtmlHTMLCollectionType.ElementClassList;
            base.___multiversalClassType = IMutilversalObjectType.DOMTokenList;
            this.___keyList = new System.Collections.Generic.Dictionary<string,int>(StringComparer.OrdinalIgnoreCase);
		}


        internal void ___CopyFromClassList(CHtmlDomTokenList __originalList)
        {
            int oriCount = __originalList.Count;
            if (__originalList != null && oriCount > 0)
            {
                foreach (string strKey in __originalList.___keyList.Keys)
                {
                    this.___keyList[strKey] = 1;
                }
            }
        }
		#region CHtmlDomTokenInterface ƒƒ“ƒo

		public bool contains(object  ___tokensObject)
		{
            string tokens = commonHTML.GetStringValue(___tokensObject);
            string[] tokenSplit = CHtmlDomTokenList.___GetTokenList(tokens);
            int tokenSplitLen = tokenSplit.Length;
            for (int i = tokenSplitLen - 1; i >= 0; i--)
            {
                if (tokenSplit[i].Length == 0)
                {
                    continue;
                }
				if(this.___keyList.ContainsKey(tokenSplit[i]) == true)
				{
					return true;
				}
			}
			return false;
		}
		public int Length
		{
			get{return this.___keyList.Count;}
		}
		public int length
		{
            get { return this.___keyList.Count; }
		}
        public string this[int pos]
        {
            get
            {
                if (this.___strKeyArray == null)
                {
                    this.___createKeyArray();
                }
                if (pos >= 0 && pos < this.___keyList.Count)
                {
                    return this.___strKeyArray[pos];
                }
                return "";
            }
        }
        public int Count
        {
            get
            {
                return this.___keyList.Keys.Count;
            }
        }
        public void Clear()
        {
            this.___keyList.Clear();
        }
		internal CHtmlBase parentBase
		{
			set{this.___parentBase = value;}
			get{return this.___parentBase;}
		}
        public int Add(string s)
        {
            this.___keyList[s] = 1;
            return 1;
        }

        public void add(object ___tokensObject1, object ___tokensObject2)
        {
            ___add_inner(string.Concat(commonHTML.GetStringValue(___tokensObject1), ", ", commonHTML.GetStringValue(___tokensObject2)));
        }
        public void add(object ___tokensObject1, object ___tokensObject2, object ___tokensObject3)
        {
            ___add_inner(string.Concat(commonHTML.GetStringValue(___tokensObject1),   ", ", commonHTML.GetStringValue(___tokensObject2),  ", ", commonHTML.GetStringValue(___tokensObject3)));
        }
        public void add(object ___tokensObject1, object ___tokensObject2, object ___tokensObject3, object ___tokensObject4)
        {
            ___add_inner(string.Concat(commonHTML.GetStringValue(___tokensObject1), ", ", commonHTML.GetStringValue(___tokensObject2), ", ", commonHTML.GetStringValue(___tokensObject3), ", ", commonHTML.GetStringValue(___tokensObject4)));
        }
        public void add(object ___tokensObject1, object ___tokensObject2, object ___tokensObject3, object ___tokensObject4, object ___tokensObject5)
        {
            ___add_inner(string.Concat(commonHTML.GetStringValue(___tokensObject1), ", ", commonHTML.GetStringValue(___tokensObject2), ", ", commonHTML.GetStringValue(___tokensObject3), ", ", commonHTML.GetStringValue(___tokensObject4),", ", commonHTML.GetStringValue(___tokensObject5)));
        }
        public void add(object ___tokensObject1, object ___tokensObject2, object ___tokensObject3, object ___tokensObject4, object ___tokensObject5, object ___tokensObject6)
        {
            ___add_inner(string.Concat(commonHTML.GetStringValue(___tokensObject1), ", ", commonHTML.GetStringValue(___tokensObject2), ", ", commonHTML.GetStringValue(___tokensObject3), ", ", commonHTML.GetStringValue(___tokensObject4), ", ", commonHTML.GetStringValue(___tokensObject5),  ", ", commonHTML.GetStringValue(___tokensObject6)));
        }
        internal void ___add_inner(string tokens)
        {
            if (tokens == null && tokens.Length == 0)
            {
                return;
            }
            bool ___IsAltered = false;
            string[] tokenSplit = CHtmlDomTokenList.___GetTokenList(tokens);
            int tokenSplitLen = tokenSplit.Length;
            for (int i = tokenSplitLen - 1; i >= 0; i--)
            {
                if (tokenSplit[i].Length == 0)
                {
                    continue;
                }
                if (this.___keyList.ContainsKey(tokenSplit[i]) == false)
                {
                    this.___keyList[tokenSplit[i]] = 1;
                    ___IsAltered = true;
                }

            }
            if (___IsAltered == true)
            {
                this.ReflectClassNamesForParentBase();
            }
        }
		public void add(object ___tokensObject)
		{
            if (___tokensObject == null)
                return;
            string tokens = commonHTML.GetStringValue(___tokensObject);
            ___add_inner(tokens);
		}
		/// <summary>
		/// Returns string into list of arrayList
		/// </summary>
		/// <param name="tokens"></param>
		/// <returns></returns>
        private static string[] ___GetTokenList(string tokens)
        {
            if (tokens.Length == 0)
            {
                return new string[] { };
            }
            return tokens.Split(___ClassStringSplittingChar,StringSplitOptions.RemoveEmptyEntries);
        }
        static char[] ___ClassStringSplittingChar = new char[] { ' ', '\t', '\r','\n', ',' };

        public void remove(object ___tokensObject)
        {
            string tokens = commonHTML.GetStringValue(___tokensObject);
            if (tokens == null && tokens.Length == 0)
            {
                return;
            }
            bool ___IsAltered = false;
            string[] tokenSplit = CHtmlDomTokenList.___GetTokenList(tokens);
            for (int i = tokenSplit.Length - 1; i >= 0; i--)
            {
                if (tokenSplit[i].Length == 0)
                {
                    continue;
                }
                if (this.___keyList.ContainsKey(tokenSplit[i]))
                {
                    this.___keyList.Remove(tokenSplit[i]);
                    ___IsAltered = true;
                }
            }
            if (___IsAltered == true)
            {
                this.ReflectClassNamesForParentBase();
            }

        }
		/// <summary>
		/// returns true if _key (a single lowercase word) is in this list.
		/// </summary>
		/// <param name="_key"></param>
		/// <returns></returns>
		public bool ContainsKey(string _key)
		{
            return this.___keyList.ContainsKey(_key);
		}

		private bool toggle_Inner(string token,  bool force)
		{
            if (string.IsNullOrEmpty(token) == true)
            {
                return false;
            }
			if(this.ContainsKey(token)== true)
			{
				this.___keyList.Remove(token);
				
				ReflectClassNamesForParentBase();
				return true;
			}
			else
			{
				this.Add(token);
				ReflectClassNamesForParentBase();
				return true;
			}
		}
		public bool toggle(string token,  bool force)
		{	
			return this.toggle_Inner(token, force);
		}
		public bool toggle(string token)
		{
			return this.toggle_Inner(token, false);
		}
		private void ReflectClassNamesForParentBase()
		{
			try
			{
				if(this.___parentBase != null)
				{
					this.___parentBase.RebuildClassNameFromClassNameValue();

				}
			}
			catch(Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("ReflectClassNamesForParentBase Error", ex);
                }
            }

		}
		#endregion

		#region IPropertBox ƒƒ“ƒo

		public void ___setPropertyByIndex(int ___index, object val)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("SetPropertyValueByIndex {0} {1} called TODO:", this.GetType(), this);
            }
		}

		public void ___setPropertyByName(string ___name, object val)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("{0}.SetPropertyValueByName( {1}, {2} ) called",this,  ___name, val);
			}
            this.___properties[___name] = val;
		}

		public bool ___hasPropertyByIndex(int ___index)
		{
            if (___index >= 0 && ___index < this.___keyList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
		}

        public bool ___hasPropertyByName(string ___name)
        {
            switch (___name)
            {
                case "length":
                    return true;
            }
            if (this.___keyList.Count > 0 && this.___keyList.ContainsKey(___name))
            {
                return true;
            }
            else
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("_x__HasProperty {0} {1} returns false", this, ___name);
                }
                return false;
            }
        }
        private void ___createKeyArray()
        {
            this.___strKeyArray = new string[this.___keyList.Count];
            this.___keyList.Keys.CopyTo(this.___strKeyArray, 0);
        }

		public object ___getPropertyByIndex(int ___index)
		{
            try
            {
                if (this.___strKeyArray == null)
                {
                    this.___createKeyArray();
                }
                if (___index >= 0 && ___index < this.___strKeyArray.Length)
                {
                    return this.___strKeyArray[___index];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("___getPropertyByName {0} {1} error {2}", this.GetType(), this, ex.Message);
                }
            }
            return null;
		}

		public object ___getPropertyByName(string ___name)
		{
			// TODO:  CHtmlDomTokenList.Prototype.IPropertBox.___getPropertyByName ŽÀ‘•‚ð’Ç‰Á‚µ‚Ü‚·B
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getPropertyByName {0} {1} called", this.GetType(), this);
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
			return "DOMTokenList";
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
            return "[object " + base.___multiversalClassType.ToString() + "]";
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

        #region IDyamicMetaObjectProvider support to get and set properties

        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlDomTokenList>(parameter, this);
        }
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
            List<string> members = new List<string>();
            
            members.AddRange(CHtmlDomTokenListProperties.Keys);
            members.AddRange(CHtmlDomTokenListMethods.Keys);
            if (this.___properties.Count > 0)
            {
                members.AddRange(this.___properties.Keys);
            }
            
            return members;
        }

        public IEnumerator<object> GetEnumerator()
        {
            //yield return base.ToArray().GetEnumerator();
            yield return this.___keyList.GetEnumerator();
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}