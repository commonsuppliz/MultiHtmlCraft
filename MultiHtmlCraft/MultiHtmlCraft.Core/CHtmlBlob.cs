using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// The Blob object represents a byte sequence similar to a file and provides methods and properties to create or manipulate ranges of binary data. A blob can be created either using the constructor as shown here, or as a return value of the slice method.
    /// </summary>
    public class CHtmlBlob : CHtmlNode, ICommonObjectInterface
    {
        


 
        /// <summary>
        /// The type property of a Blob object returns the MIME type of the file.
        /// </summary>
        internal string ___type = "";
        internal string ___internalSrc;
        internal double ___size = 0;
        /// <summary>
        /// an enum which can take the values "transparent" or "native". By default this is set to "transparent".
        /// If set to "native", line endings will be converted to native in any USVString elements in blobParts.
        /// </summary>
        internal string ___endings = "transparent";
        internal CHtmlNativeArray ___blobArray = null;

        #region FileObjectOnlyFeilds
        internal string ___name = null;
        /// <summary>
        /// The last modified date of the file. On getting, if user agents can make this information available, 
        /// this must return a long long set to the time the file was last modified as the number of milliseconds
        /// since the Unix Epoch. If the last modification date and time are not known, the attribute must 
        /// return the current date and time as a long long representing the number of milliseconds since the Unix Epoch;
        /// this is equivalent to Date.now() [ECMA-262]. 
        /// </summary>
        internal double ___lastModifiled = 0;

        internal string ___relativePath = null;

        #endregion
        /// <summary>
        /// The type property of a Blob object returns the MIME type of the file.
        /// </summary>
        public string type
        {
            get { return commonHTML.___convertNullToEmpty(this.___type); }
            set { this.___type = value; }

        }
        public double size
        {
            get { return this.___size; }
        }

        #region slice
        /// <summary>
        /// Returns a new Blob object with bytes ranging from its optional start parameter up to but not including its optional end parameter.
        /// </summary>
        /// <param name="___start"></param>
        /// <param name="___end"></param>
        /// <param name="___contentType"></param>
        /// <returns></returns>
        public CHtmlBlob slice(object ___start, object ___end, object ___contentType)
        {
            return this.___slice_inner(___start, ___end, ___contentType);
        }
        public CHtmlBlob slice()
        {
            return this.___slice_inner(null, null, null);
        }
        public CHtmlBlob slice(object ___start)
        {
            return this.___slice_inner(___start, null, null);
        }
        public CHtmlBlob slice(object ___start, object ___end)
        {
            return this.___slice_inner(___start, ___end, null);
        }

        private CHtmlBlob ___slice_inner(object ___startObj, object ___endObj, object ___contentTypeObj)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.slice({1}, {2}, {3}) is called....", this, ___startObj, ___endObj, ___contentTypeObj);
            }
            long ___start = 0;
            long  ___end = (long)this.___size;
            string newContentType = null;
            CHtmlBlob ___newBlob = new CHtmlBlob();
            if (___contentTypeObj != null)
            {
                string str = commonHTML.GetStringValue(___contentTypeObj);
                if (string.IsNullOrEmpty(str) == false)
                {
                    newContentType = str;
                }
            }
            if (string.IsNullOrEmpty(newContentType) == true)
            {
                ___newBlob.___type = this.___type;
            }
            else
            {
                ___newBlob.___type = newContentType;
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                    if (this.___type != newContentType)
                    {
                       commonLog.LogEntry("{0}.slice() content-type is different {1} : {2} . additional conversion may be required....", this, this.___type, newContentType);
                    }
                }
            }
            try
            {
                if (___startObj != null)
                {
                    ___start = commonHTML.GetIntFromObject(___startObj, 0);
                }
                if (___endObj != null)
                {
                    ___end = commonHTML.GetIntFromObject(___endObj, 0);
                }
                else
                {
                    ___end = (long)this.___size;
                }
                // bounds check
                if(___start < 0 || ___start > this.___size)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("Blob.slice() start param is out of bounds : {0}....", ___start);
                    }
                    ___start = 0;
                }
                if (___end < 0 || ___end > this.___size)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("Blob.slice() end param is out of bounds {0}....", ___end);
                    }
                    ___end = (int)this.___size - ___start;
                }
                ___newBlob.___blobArray = new CHtmlNativeArray(this.___blobArray.___arrayType);
                switch(___newBlob.___blobArray.___arrayType)
                {
                    case CHtmlNumericArrayType.ArrayBuffer:
                    case CHtmlNumericArrayType.ByteArray:
                    case CHtmlNumericArrayType.Uint8ClampedArray:
                        ___newBlob.___blobArray.___byteArray = new byte[___end - ___start];
                        Array.Copy(this.___blobArray.___byteArray, ___start, ___newBlob.___blobArray.___byteArray, 0, ___end - ___start);
                        ___newBlob.___blobArray.___arrayLength = ___newBlob.___blobArray.___byteArray.Length;
                        ___newBlob.___size = ___newBlob.___blobArray.___arrayLength;
                        break;
                    case CHtmlNumericArrayType.Uint16Array:
                    case CHtmlNumericArrayType.Int16Array:
                    case CHtmlNumericArrayType.Int8Array:
                    case CHtmlNumericArrayType.Uint8Array:
                        ___newBlob.___blobArray.___int16Array = new short[___end - ___start];
                        Array.Copy(this.___blobArray.___int16Array, ___start, ___newBlob.___blobArray.___int16Array, 0, ___end - ___start);
                        ___newBlob.___blobArray.___arrayLength = ___newBlob.___blobArray.___int16Array.Length;
                        ___newBlob.___size = ___newBlob.___blobArray.___arrayLength;
                        break;
                    case CHtmlNumericArrayType.Int32Array:
                    case CHtmlNumericArrayType.Uint32Array:
                    case CHtmlNumericArrayType.Uint64Array:
                    case CHtmlNumericArrayType.Int64Array:
                        ___newBlob.___blobArray.___int32Array = new int[___end - ___start];
                        Array.Copy(this.___blobArray.___int32Array, ___start, ___newBlob.___blobArray.___int32Array, 0, ___end - ___start);
                        ___newBlob.___blobArray.___arrayLength = ___newBlob.___blobArray.___int32Array.Length;
                        ___newBlob.___size = ___newBlob.___blobArray.___arrayLength;
                        break;
                    case CHtmlNumericArrayType.Float64Array:
                        ___newBlob.___blobArray.___floatArray = new float[___end - ___start];
                        Array.Copy(this.___blobArray.___floatArray, ___start, ___newBlob.___blobArray.___floatArray, 0, ___end - ___start);
                        ___newBlob.___blobArray.___arrayLength = ___newBlob.___blobArray.___floatArray.Length;
                        ___newBlob.___size = ___newBlob.___blobArray.___arrayLength;
                        break;
                    default:
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                        {
                           commonLog.LogEntry("Blob.slice() Copy Operation is not defained for this array type : {1}...", ___newBlob.___blobArray.___arrayType);
                        }
                        break;

                }

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                       commonLog.LogEntry("Blob.slice() Exceptioin....", ex);   
                }
            }
            return ___newBlob;
        }
        #endregion
        public CHtmlBlob()
        {
            this.___ctor(new CHtmlNativeArray(CHtmlNumericArrayType.ByteArray), "",null, double.NaN);
            
        }
        public CHtmlBlob(CHtmlNativeArray nativeArray, string mimeType)
        {
            this.___ctor(nativeArray, mimeType, null, double.NaN);
        }
        internal void ___ctor(CHtmlNativeArray nativeArray, string mimeType, string fname, double ___dateValue)
        {
            this.___ctor(nativeArray, mimeType, fname, ___dateValue, null);
        }
        internal void ___ctor(CHtmlNativeArray nativeArray,  string mimeType, string filename, double ___dateValue, string strEndings)
        {

            this.___blobArray = nativeArray;
            this.___size = nativeArray.___arrayLength;
            this.___type = mimeType;
            this.___multiversalClassType = IMutilversalObjectType.Blob;
            this.___lastModifiled = ___dateValue;
            this.___name = filename;
            if (string.IsNullOrEmpty(strEndings) == false)
            {
                this.___endings = strEndings;
            }

        }
        public CHtmlBlob(object[] ___args)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.constuctor called with args:... ", this, ___args);
            }
            if (___args != null)
            {
                int __paramCount = ___args.Length;
                string strMimeType = null;
                string strFileName = null;
                string strEndings = null;
                CHtmlNativeArray array = null;
                int arrayLen = 0;
                double dateTimeValue = 0;

                if (__paramCount > 0)
                {
                    array = CHtmlNativeArray.convertArrayObjectIntoCHtmlNativeArray(___args[0], CHtmlNumericArrayType.ByteArray);
                    arrayLen = (int)array.length;
                }
                if (__paramCount > 1)
                {
                    if (___args[1] is string)
                    {
                        strFileName = commonHTML.GetStringValue(___args[1]);
                    }
                }
                if(__paramCount > 2)
                {

                }
                if(string.IsNullOrEmpty(strFileName) == false && strFileName.Contains("/") == true)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("strange. FileName contains / {0}. it may be mimetype? ", strFileName);
                    }
                    strMimeType = strFileName;
                }
                if(__paramCount > 0)
                {
                    this.___ctor(array, strMimeType,strFileName, dateTimeValue, strEndings);
                }
                
            }
        }

        public void close()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.close() is called....", this);
            }
        }
        /// <summary>
        /// Retreives type property from object
        /// </summary>
        /// <param name="___obj"></param>
        /// <returns></returns>
        internal object  ___getTypePropertyFromObject(string propName, object ___obj)
        {

            
                System.Reflection.PropertyInfo typePropertyInfo = ___obj.GetType().GetProperty(propName);
                if (typePropertyInfo != null)
                {
                    return typePropertyInfo.GetValue(___obj, null);
                }
            
            return "";
        }

        /// <summary>
        /// The arrayBuffer() method in the Blob interface returns a Promise that resolves with the
        /// contents of the blob as binary data contained in an ArrayBuffer.
        /// </summary>
        /// <returns></returns>
        public object arrayBuffer()
        {
            return null;
        }
        /// <summary>
        /// returns ReadableStream object
        /// </summary>
        /// <returns></returns>
        public object stream()
        {
            return null;
        }
        /// <summary>
        /// The text() method in the Blob interface returns a Promise that
        /// resolves with a string containing the contents of the blob, interpreted as UTF-8.
        /// Note) use readAsText() to ___getInner string directly, rather than text() promise.
        /// </summary>
        /// <returns></returns>
        public object text()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.text() called ... return null ", this);
            }
            return null;
        }

        #region IPropertBox メンバ

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
   
        public object ___getPropertyByName(string ___name)
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
        public  string ___getClassName()
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
        public new IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.Blob;
            }
        }
        public override string ToString()
        {
            return "[object " + this.___multiversalClassType.ToString() + "]";
        }


        #endregion
    }
}
