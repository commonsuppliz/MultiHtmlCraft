using System;
using System.Collections;


using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlCHtmlCollection 
	/// </summary>
	public class CHtmlSortedList : SortedList, ICommonObjectInterface 
	{
        internal IMutilversalObjectType  ___multiversalClassType;
		

		internal CHtmlHTMLCollectionType ___CollectionType = CHtmlHTMLCollectionType.Unknown;

        internal bool ___IsPrototype = false;
        internal System.WeakReference ___prototypeWeakReference = null;

		public CHtmlSortedList(System.Collections.IComparer icom):base(icom)
		{

		}
        public CHtmlSortedList()
        {

        }
		public int length
		{
			get{return this.Count;}
		}
		public override string ToString()
		{
			return string.Format("CHtmlSortedList {0} {1} items", this.___CollectionType, this.Count);
		}
        /// <summary>
        /// Retuns Constuctor Function of HTMLCollection
        /// it should be Protype function
        /// </summary>
        public object constructor
        {
            get
            {
                if (this.___IsPrototype == false)
                {
                    if (this.___prototypeWeakReference != null)
                    {
                        return this.___prototypeWeakReference.Target;
                    }
                }
                return null;
            }

        }

		/// <summary>
		/// DHTML tags funtionality support
		/// e.x. myDocumentElements=document.allinernal.tags("meta")
		/// </summary>
		/// <param name="otag"></param>
		/// <returns></returns>
		
		
		public bool hasOwnProperty(object _oname)
		{

			return true;

		}
	
		public object item(int i)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {

               commonLog.LogEntry("calling CHtmlSortedList.item({0}) ", i);
            }
			if(i >= 0 && i < this.Count)
			{
				try
				{
                    return this.GetByIndex(i);
				}
				catch(Exception ex)
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
					{
					
						commonLog.LogEntry("CHtmlSortedList.item({0}) returns null {1}", i, ex.Message );
					}
					return null;
				}
			}
			else
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
				{
					commonLog.LogEntry("CHtmSortedList.item({0}) returns null", i);
				}
				return null;
			}
		}
        public void refresh()
        {
            this.___refresh_innner(false);
        }
        public void refresh(bool ___paramBool)
        {
            this.___refresh_innner(___paramBool);
        }
        internal void ___refresh_innner(bool ___paramBool)
        {

            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.refresh()", this);
            }
        }
		public object this[int i]
		{
			get
			{
				try
				{
                    if (i >= 0 && i < this.Count)
                    {
                        return this.GetByIndex(i);
                    }
                    else
                    {
                        return null;
                    }
				}
				catch(Exception ex)
				{
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                    {
                       commonLog.LogEntry("CHtmlSortedList GetByIndex() failed", ex);
                    }
				}
				return null;
			}
		}
		
		
		public object this[string s]
		{
			get
			{
				try
				{
					return base[s];
				}
				catch
				{
					
				}
				//commonLog.LogEntry("CHtmlSortedList this[{0}] failed", s);
				return null;

			}
			set
			{
				try
				{
					base[s] = value;
				}
				catch{}
			}
		}
        public object namedItem(object __oName)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0} : CHtmSortedList.namedItem({1}) called", this, __oName);
            }
            string sName = commonHTML.GetStringValue(__oName);
            if(base.ContainsKey(sName))
            {
                return base[sName];
            }
            return null;
        }

		#region IPropertBox ƒƒ“ƒo

		public object ___getPropertyByName(string ___name)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.GetPropertyValue({1})...", this, ___name);
            }
			switch(___name)
			{
				case "length":
					return this.Count;
                case "constructor":
                    return this.constructor;
                case "__iterator__":
                    return commonHTML.rhinoForLoopEnumratorFunction;
				default:
					int pos = -1;
					try
					{
						if(this.___CollectionType != CHtmlHTMLCollectionType.NavigatorPlugins && this.___CollectionType != CHtmlHTMLCollectionType.NavigatorMimeTypes)
						{
							pos = this.IndexOfKey(___name);
							if(pos > -1 )
							{
								return this.GetByIndex(pos);
							}
						}
						else
						{
							// Plugins collections are case sensitive. 
							pos = this.IndexOfKey(___name);
							if(pos > -1 )
							{
								return this.GetByIndex(pos);
							}

						}
					}
					catch{}
					break;
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} \"{2}\" failed",this.GetType(), this, ___name);
			}
			return null;
		}

		public void ___setPropertyByName(string ___name, object val)
		{
			if(___name == null || ___name.Length == 0)
			{
				return;
			}
			
			
			this[___name] = val;


			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("SetPropertyValue by name {0} {1}  \"{2}\" = {3} success",this.GetType(), this, ___name, val);
			}
		}

		/// <summary>
		/// when CHtmlElement is accessed by like document.body[1], it should return the input selement. not child nodes
		/// </summary>
		/// <param name="___index"></param>
		/// <returns></returns>
		public object ___getPropertyByIndex(int ___index)
		{
			if(___index > -1 && ___index < this.Count)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
				{
					commonLog.LogEntry("GetPropertyValueByIndex for {0} {1} {2} success",this.GetType(), this, ___index);
				}
				return this.GetByIndex(___index);
			}
			else
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
				{
					commonLog.LogEntry("GetPropertyValueByIndex for {0} {1} {2} failed",this.GetType(), this, ___index);
				}
				return null;
			}
		}
		public void ___setPropertyByIndex(int ___index, object val)
		{
			if(___index >= 0 && ___index < this.Count)
			{
				this.SetByIndex(___index, val);
			}
		}

		public bool ___hasPropertyByName(string ___name)
		{

			return false;
		}
		public bool ___hasPropertyByIndex(int ___index)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("entering ___hasPropertyByIndex for {0} {1} ", this, ___index);
            }
            if (___index >= 0 && ___index < this.Count)
            {
                return true;
            }
			return false;
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
                return this.___multiversalClassType;
            }
        }

		#endregion
	}
}
