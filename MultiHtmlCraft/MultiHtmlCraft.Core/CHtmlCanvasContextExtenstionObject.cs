using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlCanvasContextExtenstionObject 
	/// </summary>
	public sealed class CHtmlCanvasContextExtenstionObject : ICommonObjectInterface
	{

        internal System.WeakReference ___parentElementWeakReference = null;
        internal System.WeakReference ___ownerDocumentWeakReference = null;
        internal System.WeakReference ___ownerCanvasContextWeakReference = null;
        internal CanvasExtentionObjectType ___ContextGraphicsObjectType = CanvasExtentionObjectType.UNKNOWN;
        /// <summary>
        /// Stores un-common Attributes into list. well-used info should be stored in indiviual fields to gain performance.
        /// </summary>
        internal Dictionary<string, object> ___attributes = null;
        internal System.Collections.Generic.SortedList<double, Color> ___ColorStopList = null;
        /// <summary>
        /// Stores Base Rectange Attributes Info 1
        /// </summary>
        internal RectangleF ___baseRectangle1;
        /// <summary>
        /// Stores Base Rectange Attributes Info 2
        /// </summary>
        internal RectangleF ___baseRectangle2;
        /// <summary>
        /// Stores Base Width Parameter
        /// </summary>
        internal double ___baseWidth;
        /// <summary>
        /// Stores Base Height Parameter
        /// </summary>
        internal double ___baseHeight;
        /// <summary>
        /// Stores Src Info
        /// </summary>
        internal string ___baseSrc;
        /// <summary>
        /// Stores Pattern Info
        /// </summary>
        internal string ___basePattern;


        /// <summary>
        /// Flags indicates this object is prototypoe mather.
        /// </summary>
        public bool ___IsPrototype = false;


        public CHtmlElement ___canvasPatternCanvas = null;
        

        internal string ___repeatPatternArg = null;
        internal WeakReference ___grapicPathWeakRef;

        public string repeatPatternArg
        {
            get
            {
                return this.___repeatPatternArg;
            }
            set
            {
                this.___repeatPatternArg = value;
            }
        }
        public CHtmlElement canvasPatternCanvas
        {
            get
            {
                return this.___canvasPatternCanvas;
            }
            set
            {
                this.___canvasPatternCanvas = value;
            }
        }


        public CHtmlCanvasContextExtenstionObject(CanvasExtentionObjectType __extentionType) 
		{

            this.___ContextGraphicsObjectType = __extentionType;
            this.___attributes = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (__extentionType == CanvasExtentionObjectType.LinerGradient || __extentionType == CanvasExtentionObjectType.RadialGradient)
            {
                this.___ColorStopList = new System.Collections.Generic.SortedList<double, Color>();
            }
		}
		public override string ToString()
		{
			return string.Format("Context Extention Object : {0}", this.___ContextGraphicsObjectType);
		}
        public void addColorStop(double _colorPos, object _color)
        {
            if (_color == null)
            {
                return;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.addColorStop({1}, '{2}')", this, _colorPos, _color);
            }
            string strColorValue = commonHTML.GetStringValue(_color);
            Color colorStop = Color.Transparent;





            colorStop = commonHTML.GetColorFromHTMLColorExtend(strColorValue);



            this.___ColorStopList[_colorPos] = colorStop;

        }
        #region IPropertBox ƒƒ“ƒo

        public void ___setPropertyByName(string name, object val)
        {
            // TODO:  CHtmlWindowScreen.___setPropertyByIndex ŽÀ‘•‚ð’Ç‰Á‚µ‚Ü‚·B
        }

        public bool ___hasPropertyByName(string name)
        {
            // TODO:  CHtmlWindowScreen._x__HasProperty ŽÀ‘•‚ð’Ç‰Á‚µ‚Ü‚·B
            if(this.___attributes.ContainsKey(name))
            {
                return true;
            }
            else{
                return false;
            }
        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            return true;

        }



        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public object ___getPropertyByName(string ___name)
        {
            switch(this.___ContextGraphicsObjectType)
            {
                case CanvasExtentionObjectType.MeasureTextResult:
                    switch(___name)
                    {
                        case "width":
                            return this.___baseWidth;
                            
                        case "height":
                            return this.___baseHeight;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            object attributesValue = null;
            this.___attributes.TryGetValue(___name, out attributesValue);
            if (attributesValue != null)
            {
                return attributesValue;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
            }
            return null;
        }
        public object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }
        public string ___getClassName()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
            }
            return this.GetType().Name;
        }
        public object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public object ___getParentScope()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public object ___getProtoType()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.Unkown;
            }
        }

        #endregion

	}
}
