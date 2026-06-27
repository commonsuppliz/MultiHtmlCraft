using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    public class CHtmlCanvasContextAttributes : ICommonObjectInterface
    {
        internal System.WeakReference ___canvasContextWeakReference = null;
        #region IPropertBox メンバ


   
        public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling GetPropertyValue for {0} {1} '{2}' ", this.GetType(), this, ___name);
            }
            CHtmlCanvasContext2D ____ownerContext = null;
            if (this.___canvasContextWeakReference != null)
            {
                ____ownerContext = this.___canvasContextWeakReference.Target as CHtmlCanvasContext2D;
            }
            if (____ownerContext == null)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("calling GetPropertyValue for {0} {1} '{2}'  cancelled due to no context", this.GetType(), this, ___name);
                }
                return null;
            }
            switch (___name)
            {
                  case "alpha":
                    return ____ownerContext.alpha;
                    
                case "depth":
                    return ____ownerContext.depth;
                    
                 case "stencil":
                    return ____ownerContext.stencil;
                    
                 case "antialias":
                    return ____ownerContext.antialias;
                    
                 case "premultipliedAlpha":
                    return ____ownerContext.premultipliedAlpha;
                    
                 case "preserveDrawingBuffer":
                    return ____ownerContext.preserveDrawingBuffer;
                    
                default:
                    break;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} '{2}' failed", this.GetType(), this, ___name);
            }
            return null;
        }

   
        public void ___setPropertyByName(string ___name, object ___val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("entering SetPropertyValue for {0} {1}  '{2}' = {3}", this.GetType(), this, ___name, ___val);
            }
                        CHtmlCanvasContext2D ____ownerContext = null;
            if (this.___canvasContextWeakReference != null)
            {
                ____ownerContext = this.___canvasContextWeakReference.Target as CHtmlCanvasContext2D;
            }
            if (____ownerContext == null)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("calling SetPropertyValue for {0} {1} '{2}'  cancelled due to no context", this.GetType(), this, ___name);
                }
                return;
            }
            switch (___name)
            {
                case "alpha":
                    ____ownerContext.alpha = commonData.convertObjectToBoolean(___val);
                    break;
                case "depth":
                    ____ownerContext.depth = commonData.convertObjectToBoolean(___val);
                    break;
                 case "stencil":
                    ____ownerContext.stencil = commonData.convertObjectToBoolean(___val);
                    break;
                 case "antialias":
                    ____ownerContext.antialias = commonData.convertObjectToBoolean(___val);
                    break;
                 case "premultipliedAlpha":
                    ____ownerContext.premultipliedAlpha = commonData.convertObjectToBoolean(___val);
                    break;
                 case "preserveDrawingBuffer":
                    ____ownerContext.preserveDrawingBuffer  = commonData.convertObjectToBoolean(___val);
                    break;
                   


                default:
                    bool ___ValueStored = false;
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("SetPropertyValue for {0} {1}  '{2}' = {3} failed : {4}", this.GetType(), this, ___name, ___val, ___ValueStored);
                    }
                    break;
            }
        }
   
        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO : SetPropertyValueIndex for {0} \'{1}\' {2} = {3} failed", this.GetType(), this, ___index, val);
            }

        }
   
        public object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO : ___getPropertyByName by index {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

   
        public bool ___hasPropertyByName(string ___name)
        {
            if (this.___getPropertyByName(___name) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
   
        public bool ___hasPropertyByIndex(int ___index)
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
