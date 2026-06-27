using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// The FileReader object lets web applications asynchronously read the contents
    /// of files (or raw data buffers) stored on the user's computer, using File or Blob
    /// objects to specify the file or data to read.
    /// </summary>
    public sealed class CHtmlFileReader : CHtmlNode, ICommonObjectInterface
    {
     
        internal int ___readyState = 0;
        internal object ___error = null;
        internal object ___result = null;


        #region FileReader.readyState constants
        public int DONE
        {
            get
            {
                return 2;
            }
        }
        public int LOADING
        {
            get
            {
                return 1;
            }
        }
        public int EMPTY
        {
            get
            {
                return 0;
            }
        }
        #endregion
        public object result
        {
            get
            {
                return this.___result;
            }
        }
        public object error
        {
            get { return this.___error; }
        }
        /// <summary>
        /// Ready State 
        /// 0: Noe, 1 : Loading 2: DONE
        /// </summary>
        public double readyState
        {
            get { return (double)this.___readyState; }
        }
        public object onerror
        {
            get
            {
                return this.____getPropertyFromPropertiesList("onerror");
            }
            set {
                this.___properties["onerror"] = value;
            }
        }
        public object onload
        {
            get
            {
                return this.____getPropertyFromPropertiesList("onload");
            }
            set
            {
                this.___properties["onload"] = value;
            }
        }
        public object onloadstart
        {
            get
            {
                return this.____getPropertyFromPropertiesList("onloadstart");
            }
            set
            {
                this.___properties["onloadstart"] = value;
            }
        }
        public object onloadend
        {
            get
            {
                return this.____getPropertyFromPropertiesList("onloadend");
            }
            set
            {
                this.___properties["onloadend"] = value;
            }
        }
        public object onprogess
        {
            get
            {
                return this.____getPropertyFromPropertiesList("onprogress");
            }
            set
            {
                this.___properties["onprogress"] = value;
            }
        }
        private object ____getPropertyFromPropertiesList(string ___name)
        {
            object ___objProp = null;
            if (this.___properties.TryGetValue(___name, out ___objProp) == true)
            {
                return ___objProp;
            }
            return null;
        }
        /// <summary>
        /// The abort method is used to aborts the read operation. Upon return, the readyState will be DONE.
        /// </summary>
        public void abort()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: CHtmlFileReader.abort() is called...");
            }
            this.___readyState = this.DONE;
        }
        /// <summary>
        /// The readAsArrayBuffer method is used to start reading the contents of a specified Blob or File. When the read operation is finished, the readyState becomes DONE, and the loadend is triggered. At that time, the result attribute contains an ArrayBuffer representing the file's data.
        /// </summary>
        /// <param name="___blobobject"></param>
        public void readAsArrayBuffer(object ___blobobject)
        {

            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("CHtmlFileReader.readAsArrayBuffer() is called for {0}...", ___blobobject);
            }
            try
            {
                this.___result = ___convertBlobObjectIntoNativeArray(CHtmlNumericArrayType.ArrayBuffer, ___blobobject);
                this.___readyState = 2;
            }catch(Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("readAsArrayBuffer() Exception.", ex);
                }
                this.___readyState = 2;
            }
           
            return;
        }
        private object ___convertBlobObjectIntoNativeArray(CHtmlNumericArrayType arrayType, object ___blobobject)
        {
            if(___blobobject is CHtmlNativeArray)
            {
                CHtmlNativeArray _chtmlnativeArray = ___blobobject as CHtmlNativeArray;
                CHtmlNativeArray newArray = new CHtmlNativeArray(CHtmlNumericArrayType.ArrayBuffer, _chtmlnativeArray.___int16Array.Length);
                switch(_chtmlnativeArray.___arrayType)
                {
                    case CHtmlNumericArrayType.Uint8Array:
                    case CHtmlNumericArrayType.Uint16Array:
                    case CHtmlNumericArrayType.Int8Array:
                    case CHtmlNumericArrayType.Int16Array:
                        _chtmlnativeArray.___int16Array.CopyTo(newArray.___floatArray, (int)newArray.length);
                        break;
                }
                return newArray;
            }

            throw new NotSupportedException("ArrayType is not supported :" + ___blobobject.GetType().ToString());

            //return null;
        }
        /// <summary>
        /// The readAsBinaryString method is used to starts reading 
        /// the contents of the specified Blob or File. When the read operation is finished,
        /// the readyState becomes DONE, and the loadend is triggered. At that time, the result
        /// attribute contains the raw binary data from the file.
        /// Note that this method is now deprecated as per the 12 July 2012 Working Draft from the W3C
        /// </summary>
        /// <param name="___blobobject"></param>
        /// <returns></returns>
        public object readAsBinaryString(object ___blobobject)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: CHtmlFileReader.readAsBinaryString() is called...");
            }
            return null;
        }
        /// <summary>
        /// The readAsDataURL method is used to starts reading the contents of the specified Blob or File. When the read operation is finished, the readyState becomes DONE, and the loadend is triggered. At that time, the result attribute contains a data: URL representing the file's data as base64 encoded string.
        /// </summary>
        /// <param name="___blobobject"></param>
        /// <returns>string</returns>
        public string readAsDataURL(object ___blobobject)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("CHtmlFileReader.readAsDataURL() is called with {0}...", ___blobobject);

            }
            CHtmlBlob blob = null;
            if(___blobobject is CHtmlBlob )
            {
                blob = ___blobobject as CHtmlBlob;
           
            }
            if (blob != null)
            {
                string result =  commonHTML.convertBlobToDataURL(blob);
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("CHtmlFileReader.readAsDataURL()  convert to Blob {0} Result: {1}...", blob, result);

                }
                return result;
            }
            else
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("BUGBUG!!! CHtmlFileReader.readAsDataURL() could not convert to Blob {0}...", ___blobobject);

                }
                return "";
            }
            
        }
        /// <summary>
        /// The readAsText method is used to read the contents of the specified Blob or File. When the read operation is complete, the readyState is changed to DONE, the loadend is triggered, and the result attribute contains the contents of the file as a text string.
        /// </summary>
        /// <param name="___blobobject"></param>
        /// <param name="___encoding"></param>
        /// <returns></returns>
        public string readAsText(object ___blobobject, object ___encoding)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: CHtmlFileReader.readAsText() is called...");
            }
            return this.___readAdText_Inner(___blobobject, ___encoding);
        }
        /// <summary>
        /// The readAsText method is used to read the contents of the specified Blob or File. When the read operation is complete, the readyState is changed to DONE, the loadend is triggered, and the result attribute contains the contents of the file as a text string.
        /// </summary>
        /// <param name="___blobobject"></param>
        /// <returns></returns>
        public string readAsText(object ___blobobject)
        {
            return this.___readAdText_Inner(___blobobject, null);
        }
        private string ___readAdText_Inner(object ___blobobject, object ___encoding)
        {
            return "";
        }
        #region IPropertBox メンバ


   
        public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling GetPropertyValue for {0} {1} '{2}' ", this.GetType(), this, ___name);
            }
            switch (___name)
            {
                case "result":
                    return this.___result;
                case "readyState":
                    return (double)this.___readyState;
                case "DONE":
                    return this.DONE;
                case "LOADING":
                    return this.LOADING;
                case "EMPTY":
                    return this.EMPTY;
                case "error": // this is not same as onerror
                    return this.error;
                case "onload": 
                    return this.onload;
                case "onloadstart":
                    return this.onloadstart;
                case "onloadend":
                    return this.onloadend;
                case "onprogress":
                    return this.onprogess;
                case "onerror": // do not comfuse with this.error
                    return this.onerror;
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

   
        public void ___setPropertyByName(string ___name, object val)
        {
            bool ___ValueStored = false;
            switch (___name)
            {
                case "onerror":
                    this.onerror = val;
                    ___ValueStored = true;
                    break;
                case "onload":
                    this.onload = val;
                    ___ValueStored = true;
                    break;
                case "onloadstart":
                    this.onloadstart = val;
                    ___ValueStored = true;
                    break;
                case "onloadend":
                    this.onloadend = val;
                    ___ValueStored = true;
                    break;
                case "onprogress":
                    this.onprogess = val;
                    ___ValueStored = true;
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
            return true;

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
        public bool hasOwnProperty(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry(" {0}.hasOwnProperty {1} called : {2}", this.GetType(), this, ___name);
            }
            return this.___hasPropertyByName(___name);
        }

        #endregion

        public override string ToString()
        {
            return "[object " + this.multiversalClassType.ToString() + "]";
        }
        public new IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.FileReader;
            }
        }
        public bool isPrototypeOf(object ___protoObject)
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
    }
}
