using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    public class CHtmlRectangle : CHtmlNode, ICommonObjectInterface
    {
        private RectangleFSpec ___rect;

        public CHtmlRectangle()
        {
            ___rect = RectangleFSpec.Empty;
        }
        
        public double top
        {
            get
            {
                return ___rect.Y;
            }
            set
            {
                ___rect.Y = (float)value;
            }
        }
        public double Top
        {
            get
            {
                return ___rect.Y;
            }
            set
            {
                ___rect.Y = (float)value;
            }
        }
        public double left
        {
            get
            {
                return ___rect.X;
            }

        }
        public double Left
        {
            get
            {
                return ___rect.X;
            }

        }

        public double right
        {
            get
            {
                return ___rect.X + ___rect.Width;
            }

        }
        public double Right
        {
            get
            {
                return ___rect.X + ___rect.Width;
            }

        }
        public double bottom
        {
            get
            {
                return ___rect.Y + ___rect.Height;
            }

        }
        public double Bottom
        {
            get
            {
                return ___rect.Y + ___rect.Height;
            }

        }
        public double width
        {
            get
            {
                return ___rect.Width;
            }
            set
            {
                ___rect.Width = (float)value;
            }
        }
        public double Width
        {
            get
            {
                return ___rect.Width;
            }
            set
            {
                ___rect.Width = (float)value;
            }
        }
        public double height
        {
            get
            {
                return ___rect.Height;
            }
            set
            {
                ___rect.Height  = (float)value;
            }
        }
        public double X
        {
            get
            {
                return ___rect.X;
            }
            set
            {
                ___rect.X = (float)value;
            }
        }
        public double Y
        {
            get { return ___rect.Y; }
            set { ___rect.Y = (float)value; }
        }

        public double Height
        {
            get
            {
                return ___rect.Height;
            }
            set
            {
                ___rect.Height = (float)value;
            }
        }
        #region IPropertBox メンバ

        public object ___getPropertyByName(string ___name)
        {
            switch (___name)
            {
                case "left":
                    return ___rect.X;
                case "right": return ___rect.X + ___rect.Width;
                case "top": return ___rect.Y;
                case "bottom": return ___rect.Y + ___rect.Height;
                case "height": return ___rect.Height;
                case "width": return ___rect.Width;

                default:
                    break;
            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
            }
            return null;
        }

        public void ___setPropertyByName(string ___name, object val)
        {
            switch (___name)
            {
                default:
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                        commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    break;
            }
        }
        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("GetPropertyValueInex for {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public bool ___hasPropertyByName(string ___name)
        {
            if (___name == null)
                return false;

            return false;
        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }
        public object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }
        public string ___getClassName()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
            }
            return this.GetType().Name;
        }
        public object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public object ___getParentScope()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public object ___getProtoType()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }

        #endregion
    }
}
