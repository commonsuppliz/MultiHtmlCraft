using System;
using System.Runtime.InteropServices;
using System.Collections;

using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlRange
	/// </summary>
	[ComVisible(true)]
	
	public class CHtmlRange : CHtmlBase,ICommonObjectInterface
	{
		private CHtmlElement _startElement = null;
		private CHtmlElement _endElement = null;
        public enum RangeType : ushort
        {
            NotSet = 0,
            Document = 1,
            DocumentSelection=2,
            Element = 10,
            
        }
        internal RangeType ___rangeType = RangeType.NotSet;
        internal System.WeakReference ___ownerElementWeakReference = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="___referenceNodeObject"></param>
        /// <returns></returns>
        public object compareNode(object ___referenceNodeObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.compareNode({1})", this, ___referenceNodeObject);
            }
            return 0;

        }
        public object compareBoundaryPoints(object ___objectHow, object ___sourceRangeObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.compareBoundaryPoints({1}, {2})", this, ___objectHow, ___sourceRangeObject);
            }
            return 0;
        }
        public void execCommand(object ___command)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.execCommand({1})", this, ___command);
            }
            
        }
        public void collapse(object ___param)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.collapse({1})", this, ___param);
            }
        }
        public void moveStart (object objectunitToMove, object objectnumberOfUnits)
        {
            this.___moveStart_Inner(objectunitToMove, objectnumberOfUnits);
        }
        public void moveStart(object objectunitToMove)
        {
            this.___moveStart_Inner(objectunitToMove, null);
        }
        private void ___moveStart_Inner(object objectunitToMove, object objectnumberOfUnits)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.moveStart({1}, {2})", this, objectunitToMove, objectnumberOfUnits );
            }
        }
        public void moveEnd(object objectunitToMove, object objectnumberOfUnits)
        {
            this.___moveEnd_Inner(objectunitToMove, objectnumberOfUnits);
        }
        public void moveEnd(object objectunitToMove)
        {
            this.___moveEnd_Inner(objectunitToMove, null);
        }
        private void ___moveEnd_Inner(object objectunitToMove, object objectnumberOfUnits)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.moveEnd({1}, {2})", this, objectunitToMove, objectnumberOfUnits);
            }
        }
        public void select()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.select()", this);
            }
        }
        public bool findText(object ___textToFind, object ___direction, object ___flags)
        {
            return this.___findText_Inner(___textToFind, ___direction, ___flags);
        }
        public bool findText(object ___textToFind, object ___direction)
        {
            return this.___findText_Inner(___textToFind, ___direction, null);
        }
        public bool findText(object ___textToFind)
        {
            return this.___findText_Inner(___textToFind, null, null);
        }
        private bool ___findText_Inner(object ___textToFind, object ___direction, object ___flags)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.findText()", this);
            }
            return true;
        }
        public override string ToString()
        {
            return "Range of " + this.___rangeType.ToString();
        }
		public CHtmlRange()
		{
			// 
			// 
			//
		}
		public CHtmlElement startContainer
		{
			get
			{
				return this._startElement;
			}
		}
		public CHtmlElement endContainer
		{
			get
			{
				return this._endElement;
			}
		}
		public int startOffset
		{
			get
			{
				if(this._startElement != null)
				{
					return this._startElement.___ChildNodeIndex;
				}
				return -1;
			}
		}
		public int endOffset
		{
			get
			{
				if(this._endElement != null)
				{
					return this._endElement.___ChildNodeIndex;
				}
				return -1;
			}

		}
		
		#region IPropertBox ƒƒ“ƒo

		public object ___getPropertyByName(string ___name)
		{
			switch(___name)
			{
				case "startContainer":
					return this._startElement;
				case "endContainer":
					return this._endElement;
				case "startOffset":
					return this.startOffset;
				case "endOffset":
					return this.endOffset;
				default:
					break;
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
			}
			return null;
		}

		public void ___setPropertyByName(string ___name, object val)
		{
			switch(___name)
			{
				default:
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
					{
						commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed",this.GetType(), this, ___name, val);
					}
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
			if(___name == null)
				return false;

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

		#endregion
	}
}
