using System;
using System.Runtime.InteropServices;

using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlTextRectangle TextRectangle Object
	/// </summary>
	[ComVisible(true)]
	
	public sealed class CHtmlTextRectangle : ICommonObjectInterface 
	{


		public CHtmlTextRectangle()
		{

		}
		private double _left = 0;
		public double left
		{
			get{return this._left;}
			set{this._left = value;}
		}
		private double _top = 0;
		public double top
		{
			get{return this._top;}
			set{this._top = value;}
		}

		private double _right = 0;
		public double right
		{
			get{return this._right;}
			set{this._right = value;}
		}
		private double _bottom = 0;
		public double bottom
		{
			get{return this._bottom;}
			set{this._bottom = value;}
		}
		
		#region IPropertBox ƒƒ“ƒo


		
		public object ___getPropertyByName(string ___name)
		{
			switch(___name)
			{
				case "left":
                case "Left":
					return this._left;
				case "right":
                case "Right":
					return this._right;
				case "bottom":
                case "Bottom":
					return this._bottom;
				case "top":
                case "Top":
					return this._top;
                case "width":
                    return this._right - this._left;
                case "height":
                    return this._bottom - this._top;
				default:
					break;
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} '{2}' failed",this.GetType(), this, ___name);
			}
			return 0;
		}

		
		public void ___setPropertyByName(string ___name, object val)
		{
            string __nameLow = commonHTML.FasterTrimAndToLower(___name);
			switch(__nameLow)
			{
				case "left":
                case "Left":
					this._left   = commonHTML.GetIntFromObject(val, 0);
					return;
				case "right":
                case "Right":
					this._right  = commonHTML.GetIntFromObject(val, 0);
					break;
				case "top":
                case "Top":
					this._top    = commonHTML.GetIntFromObject(val, 0);
					break;
				case "bottom":
                case "Bottom":
					this._bottom = commonHTML.GetIntFromObject(val, 0);
					break;
				default:
					bool ___ValueStored = false;
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
					{
						commonLog.LogEntry("SetPropertyValue for {0} {1}  '{2}' = {3} Success : {4}",this.GetType(), this, ___name, val, ___ValueStored );
					}
					break;
			}
		}
		
		public void ___setPropertyByIndex(int ___index, object val)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("SetPropertyValueIndex for {0} \'{1}\' {2} = {3} failed",this.GetType(), this, ___index, val);
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
                return IMutilversalObjectType.TextRectangle;
            }
        }
		#endregion
	}
}
