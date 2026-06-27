using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text;
using Interfaces;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// The ImageData interface represents the underlying pixel data of an area of a <canvas> element. It is created using the ImageData() constructor or creator methods on the CanvasRenderingContext2D object associated with a canvas: createImageData() and getImageDataInner(). It can also be used to set a part of the canvas by using putImageData().
    /// </summary>
    public class CHtmlCanvas2DImageData : CHtmlNode, ICommonObjectInterface , ICHtmlCanvas2DImageData, IDynamicMetaObjectProvider
    {
      
        internal System.WeakReference ___ownerDocumentWeakReference = null;
        public static Dictionary<string, object> CHtmlCanvas2DImageDataProperties = createCHtmlCanvas2DImageDataPropertiesList();

        private static Dictionary<string, object> createCHtmlCanvas2DImageDataPropertiesList()
        {
             var list = new Dictionary<string, object>();
            list["width"] = null;
            list["height"] = null;
            list["data"] = null;
            return list;
        }

        public static Dictionary<string, object> CHtmlCanvas2DImageDataMethods = new Dictionary<string, object>();


        internal double ___width = 0;
        internal double ___height = 0;
        /// <summary>
        /// The readonly ImageData.data property returns a Uint8ClampedArray that contains the ImageData object's pixel data. Data is stored as a one-dimensional array in the RGBA order, with integer values between 0 and 255 (inclusive).
        /// </summary>
        internal CHtmlNativeArray ___data;

        public CHtmlCanvas2DImageData()
        {
           
        }
        public double width
        {
            get { return this.___width; }
            set { ___width = value; }
        }
        public double height
        {
            get { return this.___height; }
            set { ___width = value; }
        }
        /// <summary>
        /// The readonly ImageData.data property returns a Uint8ClampedArray that contains the ImageData object's pixel data. Data is stored as a one-dimensional array in the RGBA order, with integer values between 0 and 255 (inclusive).
        /// </summary>
        public CHtmlNativeArray data
        {
            get
            {
                return ___data;
            }
            set
            {
                ___data = value;
            }
        }


        public string getClassName()
        {
            return this.GetType().Name;
        }
        public override string ToString()
        {
            if (this.___IsPrototype == false)
            {
                return this.GetType().Name;
            }
            else
            {
                return this.GetType().Name + "[prototype]";
            }
        }

        public  bool hasOwnProperty(string ___name)
        {
            return this.___hasPropertyByName(___name);
        }


        #region IPropertBox メンバ

        public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("enter {0} GetPropertyValue for {1} ", this, ___name);
            }
            switch (___name)
            {
                case "data":
                    return this.___data;
                case "width":
                    return this.___width;
                case "height":
                    return this.___height;
                default:
                    break;
            }
            object propValue;
            if (___properties.TryGetValue(___name, out propValue) == true)
            {
                return propValue;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0} GetPropertyValue for {1} failed", this, ___name);
            }
            return null;
        }

        public void ___setPropertyByName(string ___name, object val)
        {
            switch (___name)
            {
                default:
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    this.___properties[___name] = val;
                    break;
            }
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
               commonLog.LogEntry("GetPropertyValueInex for {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public  bool ___hasPropertyByName(string ___name)
        {

            return false;
        }
        public   bool ___hasPropertyByIndex(int ___index)
        {
            return true;
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
        public  void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public  object[] ___getByIds()
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
        public  void ___setParentScope(object ___object)
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

        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
             return new CHtmlClearScriptDynamicMetaObject<CHtmlCanvas2DImageData>(parameter, this);
        }

        public new IMutilversalObjectType multiversalClassType
        {
            get { return IMutilversalObjectType.ImageData; }
        }

        object ICHtmlCanvas2DImageData.data => data;

        public string colorSpace => throw new NotImplementedException();
        #endregion
    }
}
