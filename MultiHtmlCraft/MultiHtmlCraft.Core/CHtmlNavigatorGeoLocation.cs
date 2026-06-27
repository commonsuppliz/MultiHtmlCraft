using System;
using System.Collections;

using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlNavigatorGeoLocation This specification defines an API that provides scripted access to geographical location information associated with the hosting device. 
	/// </summary>
	public class CHtmlNavigatorGeoLocation : CHtmlNode, ICommonObjectInterface
	{
		/// <summary>
		/// Property and Methods List Cache for CHtmlMediaElement (Case Sensitive)
		/// </summary>
		

		public CHtmlNavigatorGeoLocation()
		{

		}
		public void getCurrentPosition(object p1, object p2, object p3)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GeoLocation getCurrentPosition({0}, {1}, {2})", p1, p2, p3); 
			}
		}

		public long watchPosition(object p1, object p2, object p3)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GeoLocation watchPosition({0}, {1}, {2})", p1, p2, p3); 
			}
			return 0;
		}

		public void clearWatch(long watchId)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GeoLocation clearWatch({0})", watchId); 
			}
		}
		
		public bool hasOwnProperty(object _oname)
		{
			return true;

		}
		#region IPropertBox ƒƒ“ƒo

		public void ___setPropertyByIndex(int ___index, object val)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GeoLocation  _x__SetPropertyValu({0}, {1})", ___index, val);
            }
		}

		public void ___setPropertyByName(string name, object val)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GeoLocation  _x__SetPropertyValu({0}, {1})", name, val);
            }
		}

		public bool ___hasPropertyByIndex(int ___index)
		{
			// TODO:  CHtmlNavigatorGeoLocation._x__HasProperty ŽÀ‘•‚ð’Ç‰Á‚µ‚Ü‚·B
			return true;
		}

		public bool ___hasPropertyByName(string ___name)
		{
			return false;
		}

		public object ___getPropertyByIndex(int ___index)
		{
			// TODO:  CHtmlNavigatorGeoLocation.___getPropertyByName ŽÀ‘•‚ð’Ç‰Á‚µ‚Ü‚·B
			return null;
		}

        public object ___getPropertyByName(string __name)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO : getPropretyValue {0} {1} called : {2}", this.GetType(), this, __name);
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

		#endregion
	}
}
