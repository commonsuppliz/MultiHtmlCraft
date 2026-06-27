using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{

    /// <summary>
    /// W3C HTML Living Standard - 4.5.4 TextMetrics
    /// </summary>
    public sealed class CHtmlTextMetrics : CHtmlNode, ICommonObjectInterface
    {
        public static Dictionary<string, object> CHtmlTextMetricsProperties = createCHtmlTextMetricsProperties();
        private static Dictionary<string, object> createCHtmlTextMetricsProperties()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["width"] = 0.0;
            dict["actualBoundingBoxLeft"] = 0.0;
            dict["actualBoundingBoxTop"] = 0.0;
            dict["actualBoundingBoxRight"] = 0.0;
            dict["actualBoundingBoxBottom"] = 0.0;
            dict["emHeightAscent"] = 0.0;
            dict["emHeightDescent"] = 0.0;
            dict["fontBoundingBoxAscent"] = 0.0;
            dict["fontBoundingBoxDescent"] = 0.0;
            dict["hangingBaseline"] = 0.0;
            dict["alphabeticBaseline"] = 0.0;
            dict["fontBaseline"] = 0.0;
            dict["textBaseline"] = 0.0;
            dict["ideographicBaseline"] = 0.0;
            return dict;
        }
        public CHtmlTextMetrics(): base()
        {
            this.___multiversalClassType = IMutilversalObjectType.TextMetrix;
        }
        public double ___width = 0;

        public double ___actualBoundingBoxLeft = 0;
        public double ___actualBoundingBoxTop = 0;
        public double ___actualBoundingBoxRight = 0;
        public double ___actualBoundingBoxBottom = 0;
        public double ___emHeightAscent = 0;
        public double ___emHeightDescent = 0;
        public double ___fontBoundingBoxAscent = 0;
        public double ___fontBoundingBoxDescent = 0;
        public double ___hangingBaseline = 0;
        public double ___alphabeticBaseline = 0;
        public double ___fontBaseline = 0;
        public double ___textBaseline = 0;
        public double ___ideographicBaseline = 0;


        public double width
        {
            get { return this.___width; }
            set { this.___width = value; }
        }

        public double actualBoundingBoxLeft
        {
            get { return this.___actualBoundingBoxLeft; }
            set { this.___actualBoundingBoxLeft = value; }
        }
        public double actualBoundingBoxTop
        {
            get { return this.___actualBoundingBoxTop; }
            set { this.___actualBoundingBoxTop = value; }
        }
        public double actualBoundingBoxRight
        {
            get { return this.___actualBoundingBoxRight; }
            set { this.___actualBoundingBoxRight = value; }
        }
        public double actualBoundingBoxBottom
        {
            get { return this.___actualBoundingBoxBottom; }
            set { this.___actualBoundingBoxBottom = value; }
        }
        public double emHeightAscent
        {
            get { return this.___emHeightAscent; }
            set { this.___emHeightAscent = value; }
        }
        public double emHeightDescent
        {
            get { return this.___emHeightDescent; }
            set { this.___emHeightDescent = value; }
        } 





        #region IPropertBox メンバ

        public new bool isPrototypeOf(object ___protoObject)
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
   
        public new object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling GetPropertyValue for {0} {1} '{2}' ", this.GetType(), this, ___name);
            }
            switch (___name)
            {
                case "width":
                    return this.___width;

                case "actualBoundingBoxLeft":
                    return this.___actualBoundingBoxLeft;
                case "actualBoundingBoxTop":
                    return this.___actualBoundingBoxTop;
                case "actualBoundingBoxRight":
                    return this.___actualBoundingBoxRight;

                case "emHeightAscent":
                    return this.___emHeightAscent;

                default:
                    return 0;

                    break;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} '{2}' failed", this.GetType(), this, ___name);
            }
            return null;
        }

   
        public new void ___setPropertyByName(string ___name, object val)
        {
            bool ___ValueStored = false;
            switch (___name)
            {
                case "width":
                    this.___width = this.___width;

                    ___ValueStored = true;
                    break;

                default:
      
                    break;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValue for {0} {1}  '{2}' = {3} Success : {4}", this.GetType(), this, ___name, val, ___ValueStored);
            }
        }
   
        public new void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO : SetPropertyValueIndex for {0} \'{1}\' {2} = {3} failed", this.GetType(), this, ___index, val);
            }

        }
   
        public new object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO : ___getPropertyByName by index {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }


        public new bool ___hasPropertyByName(string ___name)
        {

            return false;
        }
   
        public new bool ___hasPropertyByIndex(int ___index)
        {

            return true;
        }
        public new object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public new void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public new void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public new object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }
        public new string ___getClassName()
        {
            return this.GetType().Name;
        }
        public new object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public new object ___getParentScope()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public new void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public new  object ___getProtoType()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public new bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public new bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public new void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public new bool hasOwnProperty(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry(" {0}.hasOwnProperty {1} called : {2}", this.GetType(), this, ___name);
            }
            return this.___hasPropertyByName(___name);
        }
        public new IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.TextMetrix;
            }
        }
        public override string ToString()
        {
            return "[object " + this.___multiversalClassType.ToString() + "]";
        }
        public string ToLogString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} {{ ", this.GetType().Name);
            sb.AppendFormat(" width={0}", this.___width);
            sb.Append(" }");
            return sb.ToString();
        }

        #endregion
    }
}
