using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// File Class inherits Blob
    /// Note) File is almost identical to Blob. Please create it in Blob first
    /// window.File
    /// https://developer.mozilla.org/en-US/docs/Web/API/File
    /// </summary>
    public sealed class CHtmlFile : CHtmlBlob, ICommonObjectInterface
    {
        
   

        public CHtmlFile(): base()
        {
            this.___multiversalClassType = IMutilversalObjectType.File;
        }
        public CHtmlFile(CHtmlNativeArray nativeArray, string mimeType) : base(nativeArray, mimeType)
        {
            this.___multiversalClassType = IMutilversalObjectType.File;
        }
        public CHtmlFile(object[] ___args) :base( ___args)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.constuctor called with args:... ", this, ___args);
            }
            this.___multiversalClassType = IMutilversalObjectType.File;
        }
        public string name
        {
            get { return this.___name; }
            set { this.___name = value; }
        }
        public string relativePath
        {
            get { return this.___relativePath; }
            set { this.___relativePath = value; }
        }
        public string webkitRelativePath
        {
            get { return this.___relativePath; }
            set { this.___relativePath = value; }
        }
        public double lastModified
        {
            get { return this.___lastModifiled; }
            set { this.___lastModifiled = value; }

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
                case "size":
                    return this.___size;
                case "type":
                    return commonHTML.___convertNullToEmpty(this.___type);
                case "name":
                    return commonHTML.___convertNullToEmpty(this.___name);
                case "lastModified":
                    return this.___lastModifiled;
                case "relativePath":
                case "webkitRelativePath":
                case "mozRelativePath":

                    return this.___relativePath;
                default:
                    object ___propValue = null;
                    if (this.___properties.TryGetValue(___name, out ___propValue) == true)
                    {
                        return ___propValue;
                    }
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
                case "name":
                    this.___name = commonHTML.GetStringValue(val);
                    break;
                case "relativePath":
                case "webKitRelativePath":
                    this.___relativePath = commonHTML.GetStringValue(val);
                    break;
                case "lastModified":
                    this.___lastModifiled = commonData.GetDoubleFromObject(val, 0);
                    break;
                default:
                    this.___properties[___name] = val;
                    ___ValueStored = true;
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
                return IMutilversalObjectType.File;
            }
        }
        public override string ToString()
        {
            return "[object " + this.___multiversalClassType.ToString() + "]";
        }


        #endregion
    }
}
