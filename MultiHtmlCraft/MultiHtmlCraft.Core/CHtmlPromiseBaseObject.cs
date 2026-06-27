using System;
using System.Collections;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
	/// <summary>
    /// CHtmlPromisingFunctionObject is base object for Promise ES6 
	/// </summary>
	
	public sealed class CHtmlPromisingFunctionObject : ICommonObjectInterface
	{



        /// <summary>
        /// Name of Fuction this promise created
        /// </summary>
        internal string ____functionOrigin = null;

        /// <summary>
        /// Orignal Object this Promise is created
        /// </summary>
        internal System.WeakReference ___originalObjectWeakReference = null;

        internal System.WeakReference ___param1WeakReference = null;
        internal System.WeakReference ___param2WeakReference = null;
        internal System.WeakReference ___param3WeakReference = null;
        internal System.WeakReference ___param4WeakReference = null;
        internal System.WeakReference ___param5WeakReference = null;

        public CHtmlPromisingFunctionObject()
		{

		}
        public object Then(object ___objFunction)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.Then({1})", this, ___objFunction);
            }
            return this.____then_inner(new object[]{___objFunction});
        }
        public object then(object ___objFunction)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.Then({1})", this, ___objFunction);
            }
            return this.____then_inner(new object[]{___objFunction}) ;
        }
        public object then(object ___obj1, object ___obj2, object ___obj3)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.Then({1})", this, ___obj1);
            }
            return this.____then_inner(new object[]{___obj1 , ___obj2 , ___obj3});
        }
        private object ____then_inner(object[] ___objFunction)
        {
            return null;
        }

   
        public bool hasOwnProperty(object _oname)
        {

            return false;
        }
		private void CleanUp()
		{
			
		}


		#region IPropertBox ƒƒ“ƒo


		
		public object ___getPropertyByName(string ___name)
		{
            switch (___name)
			{

				default:
					break;
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} '{2}' failed",this.GetType(), this, ___name);
			}
			return null;
		}

		
		public void ___setPropertyByName(string ___name, object val)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling SetPropertyValue for {0} {1}  '{2}' = {3}", this.GetType(), this, ___name, val);
            }
			switch(___name)
			{
				default:
					bool ___ValueStored = false;
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
					{
						commonLog.LogEntry("TODO: SetPropertyValue for {0} {1}  '{2}' = {3} failed : {4}",this.GetType(), this, ___name, val, ___ValueStored );
					}
					break;
			}
		}
		
		public void ___setPropertyByIndex(int ___index, object val)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("TODO : SetPropertyValueIndex for {0} \'{1}\' {2} = {3} failed",this.GetType(), this, ___index, val);
			}
			
		}
		
		public object ___getPropertyByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("TODO : ___getPropertyByName by index {0} {1} {2} failed",this.GetType(), this, ___index);
			}
			return null;
		}

		
		public bool ___hasPropertyByName(string ___name)
		{

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
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.Promise;
            }
        }
		#endregion
	}
}
