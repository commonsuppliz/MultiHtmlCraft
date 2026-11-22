using Avalonia.Controls.Documents;
using Microsoft.ClearScript;
using MultiHtmlCraft.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ClearScript.JavaScript;

namespace MultiHtmlCraft.Core
{
    public class CHtmlFetchResponse : ICommonObjectInterface, IDynamicMetaObjectProvider
    {
        internal static Dictionary<string, int> CHtmlFetchResponseProperties = createCHtmlFetchResponsePropertiesList();
        internal  static Dictionary<string, int> CHtmlFetchResponseMethods = createCHtmlFetchResponseMethodList();


        private static Dictionary<string, int> createCHtmlFetchResponseMethodList()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            list.Add("json", 0);
            list.Add("text", 1);
            list.Add("arrayBuffer", 2);
            list.Add("blob", 3);
            list.Add("formData", 4);
            list.Add("clone", 5);
            list.Add("bytes", 6);
            return list;
        }
        private static Dictionary<string, int> createCHtmlFetchResponsePropertiesList()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            list.Add("body", 0);
            list.Add("bodyUsed", 1);
            list.Add("headers", 2);
            list.Add("ok", 3);
            list.Add("redirected", 4);
            list.Add("status", 5);
            list.Add("statusText", 6);
            list.Add("type", 7);
            list.Add("url", 8);
            return list;
        }
        private readonly HttpResponseMessage _res;
        private  byte[]  _byteContent;
        internal Dictionary<string, object> ___properties = new Dictionary<string, object>();

        public CHtmlFetchResponse(HttpResponseMessage res, byte[] content)
        {
            ___fetchResponseOk = true;
            _res = res;
            _byteContent = content;

        }
        public CHtmlFetchResponse()
        {
            
        }
        private WeakReference<ScriptEngine>? _engineRef;
        public ScriptEngine? v8ScriptEngine
        {
            get => _engineRef != null && _engineRef.TryGetTarget(out var eng) ? eng : null;
            set => _engineRef = value != null ? new WeakReference<ScriptEngine>(value) : null;
        }
        private bool ___fetchResponseOk = false;

        public int status => (int)_res.StatusCode;
        // public bool ok => _res.IsSuccessStatusCode;
        public bool ok
        {
            get
            {
                return ___fetchResponseOk;
            }
        }
        public string statusText => _res.ReasonPhrase;
        public object GetDynamicMember(string name)
        {
            object objValue = null;
            objValue = this.___getPropertyByName(name);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.GetDynamicMember({1} returns : {2}", this, name, objValue);
            }
            return objValue;
        }

        public object text()
        {
            string? ___charset = "UTF-8";
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
                {
                    commonLog.LogEntry($"{this}.text() enter");
                }
                if (_res != null && _res.Content != null && _res.Content.Headers != null && _res.Content.Headers.ContentType != null)
                {
                    ___charset = _res.Content.Headers.ContentType?.CharSet;
                }


                string ___fetchText = string.Empty;
                if (_byteContent is null || _byteContent.Length == 0)
                {
                    return Task.FromResult(string.Empty);
                }
                System.Text.Encoding? _encodindgs = null;

                if (!string.IsNullOrWhiteSpace(___charset))
                {
                    if (!string.IsNullOrWhiteSpace(___charset))
                    {

                        ___charset = ___charset.Trim('"');
                        try
                        {
                            string ____fetchEncodingString = commonData.GetCharsetFromHTMLCharset(___charset);
                            try
                            {
                                _encodindgs = Encoding.GetEncoding(____fetchEncodingString);
                            }
                            catch
                            {
                                _encodindgs = Encoding.UTF8;
                            }
                        }
                        catch (ArgumentException ax)
                        {
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
                            {
                                commonLog.LogEntry($"{this} text() Argument error", ax);
                            }
                            _encodindgs = Encoding.UTF8;
                        }
                    }

                }
                if(_encodindgs == null)
                {
                    _encodindgs = Encoding.UTF8;
                }
                try

                {
                     var textResult = Task.FromResult(_encodindgs.GetString(_byteContent));
                    if (v8ScriptEngine != null)
                    {
                        return textResult.ToPromise<string>(v8ScriptEngine); 
                    }
                    else
                    {
                        return textResult;
                    }


                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
                    {
                        commonLog.LogEntry($"{this} text() convert error");
                    }
                    return Task.FromResult(_encodindgs.GetString(_byteContent));
                }
            } catch (Exception fetchException)
            { 
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
            {
                commonLog.LogEntry($"{this} text() convert error final");
                return Task.FromResult(System.Text.UTF8Encoding.UTF8.GetString(this._byteContent));
            }
        }
              return Task.FromResult(System.Text.UTF8Encoding.UTF8.GetString(this._byteContent));

        }

        public object json()
        {

            //return V8ScriptEngine.GetCurrent().Evaluate($"JSON.parse({@$"'{_byteContent.Replace("'", "\\'")}'"})");
            return string.Empty;
        }
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlFetchResponse>(parameter, this);
        }
        internal byte[] byteContent
        {
            get
            {
                return _byteContent;
            }
            set
            {
                _byteContent = value;
            }
        }
        #region IPropertBox メンバ

        public new bool isPrototypeOf(object ___protoObject)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("calling {0}.isPrototpyeOf('{1}') ", this, ___protoObject);
            }
            switch (commonHTML.isPrototypeOf_precheck(this, ___protoObject))
            {
                case 0:
                default:
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
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
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("calling GetPropertyValue for {0} {1} '{2}' ", this.GetType(), this, ___name);
            }
            switch (___name)
            {

                default:
                    object ___propValue = null;
                    if (this.___properties.TryGetValue(___name, out ___propValue) == true)
                    {
                        return ___propValue;
                    }
                    break;
            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
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

                default:
                    this.___properties[___name] = val;
                    ___ValueStored = true;
                    break;
            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("SetPropertyValue for {0} {1}  '{2}' = {3} Success : {4}", this.GetType(), this, ___name, val, ___ValueStored);
            }
        }

    public new void ___setPropertyByIndex(int ___index, object val)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
        {
            commonLog.LogEntry("TODO : SetPropertyValueIndex for {0} \'{1}\' {2} = {3} failed", this.GetType(), this, ___index, val);
        }

    }

    public new object ___getPropertyByIndex(int ___index)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
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
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
        }
        return this;
    }
    public new void ___deleteByIndex(int ___index)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
        }
    }
    public new void ___deleteByName(string ___name)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
        }

    }
    public new object[] ___getByIds()
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
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
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
        }
        return null;
    }
    public new object ___getParentScope()
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
        }
        return null;
    }
    public new void ___setParentScope(object ___object)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
        }
    }
    public new object ___getProtoType()
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
        }
        return null;
    }
    public new bool ___hasInstance(object ___object)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
        }
        return false;
    }
    public new bool ___instanceEquals(object ___object)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
        }
        return object.ReferenceEquals(this, ___object);
    }
    public new void ___setProtoType(object ___object)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
        }
    }
    public new bool hasOwnProperty(string ___name)
    {
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            commonLog.LogEntry(" {0}.hasOwnProperty {1} called : {2}", this.GetType(), this, ___name);
        }
        return this.___hasPropertyByName(___name);
    }
    public new IMutilversalObjectType multiversalClassType
    {
        get
        {
                return IMutilversalObjectType.Unkown;
        }
    }
    public override string ToString()
    {
        return "[object Response]";
    }


    #endregion
}
}
