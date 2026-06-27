using System;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlMediaTimeRanges 
	/// </summary>
	public class CHtmlTimeRanges : ICommonObjectInterface 
	{
		public CHtmlTimeRanges()
		{
			// 
			// 
			//
		}
		#region IPropertBox ƒƒ“ƒo

		public void ___setPropertyByName(string name, object val)
		{
			// TODO:  CHtmlWindowScreen.___setPropertyByIndex ŽÀ‘•‚ð’Ç‰Á‚µ‚Ü‚·B
		}

		public bool ___hasPropertyByName(string name)
		{
			// TODO:  CHtmlWindowScreen._x__HasProperty ŽÀ‘•‚ð’Ç‰Á‚µ‚Ü‚·B
			return true;
		}
		public bool ___hasPropertyByIndex(int ___index)
		{
            // TODO:
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

        public object ___getPropertyByName(string ___name)
		{

			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed",this.GetType(), this, ___name);
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
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.TimeRanges;
            }
        }
		#endregion
	}
}
