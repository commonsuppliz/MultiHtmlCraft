using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Linq.Expressions;
using MultiHtmlCraft.Interfaces;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Collections;
using NiL.JS.Core;

namespace MultiHtmlCraft.Core
{
    public class CHtmlURLSearchParams : ICommonObjectInterface, IDynamicMetaObjectProvider, IEnumerable
    {
        private readonly Dictionary<string, List<string>> _params;

        public CHtmlURLSearchParams()
        {
            _params = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("constructor {0}.URLSearchParams() returns is done ...", this);
            }

        }
        public CHtmlURLSearchParams(string query = "")
        {
            try
            {
                _params = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
                ___parseQuery(query);
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("constructor {0}.URLSearchParams({1} returns is done ...", this, query);
                }
            } catch(Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("constructor{0}.URLSearchParams ___hasInner error {1}", this,ex);
                }
            }
        }
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            foreach (var pair in _params)
            {
                foreach (var value in pair.Value)
                {
                    yield return new KeyValuePair<string, string>(pair.Key, value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ___parseQuery(string query)
        {
            if (string.IsNullOrEmpty(query)) return;

            var pairs = query.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in pairs)
            {
                var parts = pair.Split('=', 2);
                var key = Uri.UnescapeDataString(parts[0]);
                var value = parts.Length > 1 ? Uri.UnescapeDataString(parts[1]) : string.Empty;

                if (!_params.ContainsKey(key))
                {
                    _params[key] = new List<string>();
                }
                _params[key].Add(value);
            }
        }


        public void append(string key, string value)
        {
            if (!_params.ContainsKey(key))
            {
                _params[key] = new List<string>();
            }
            _params[key].Add(value);
        }


        public void delete(string key)
        {
            _params.Remove(key);
        }
        public object? get(object  objKey)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel <= 10)
            {
                commonLog.LogEntry("enter {0}.URLSearchParams.___getInner ({1}) ...", this, objKey);
            }
            string strKey = commonHTML.GetStringValue(objKey);
            var resultOfKey = _params.ContainsKey(strKey) ? _params[strKey].FirstOrDefault() : null;
            return resultOfKey;
        }

        private object? ___getInner(string key)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel <= 10)
            {
                commonLog.LogEntry("enter {0}.URLSearchParams.___getInner ({1}) ...", this, key);
            }
            var resultOfKey =  _params.ContainsKey(key) ? _params[key].FirstOrDefault() : null;
            if (commonLog.LoggingEnabled && commonLog.LogLevel <= 10)
            {
                commonLog.LogEntry(" {0}.URLSearchParams.___getInner ({1}) returns {2}...", this, key, resultOfKey);
            }
            return resultOfKey;
        }
        public object? get(string key)
        {
            return ___getInner(key);
        }

 

        /*

        public IEnumerable<string> GetAll(string key)
        {

            return _params.ContainsKey(key) ? _params[key] : Enumerable.Empty<string>();
        }
        */

        /*
        public bool has(object keyObject)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel <= 10)
            {
                commonLog.LogEntry("enter {0}.URLSearchParams.___hasInner ({1}) ...", this, keyObject);
            }
            return _params.ContainsKey(commonHTML.GetStringValue(keyObject));
        }*/

        public bool has(string key)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel <= 10)
            {
                commonLog.LogEntry("enter {0}.URLSearchParams.___hasInner ({1}) ...", this, key);
            }
            return this.___hasInner(key, null);
        }
        public bool has(string param1, string param2)
        {
            return this.___hasInner(param1, param2);
        }
        public bool has(string paramObj1, object paramObj2)
        {
            return this.___hasInner(commonHTML.GetStringValue(paramObj1), commonHTML.GetStringValue(paramObj2));
        }
        private bool ___hasInner
            (string key, string value)
        {

            if (commonLog.LoggingEnabled && commonLog.LogLevel <= 10)
            {
                commonLog.LogEntry("enter {0}.URLSearchParams.___hasInner ({1}) ...", this, key);
            }
            List<string>  _paramsValue = null;
            if ( _params.TryGetValue(key, out _paramsValue) == true)
            {
                _paramsValue.Contains(value);
                return true;
            }
            return false;
        }
        

        public string getAll(string arg1)
        {
            List<string> _paramsValue = null;
            if (commonLog.LoggingEnabled && commonLog.LogLevel <= 10)
            {
                commonLog.LogEntry("enter {0}.URLSearchParams.getAll ({1}) ...", this, arg1);
            }
            if (_params.TryGetValue(arg1, out _paramsValue) == true)
            {
                StringBuilder sbValue = new StringBuilder();
                foreach (string str in _paramsValue)
                {
                    {
                        sbValue.Append(str);
                    }
                }
                return sbValue.ToString();
            }
            return string.Empty;
        }


        public void set(string key, string value)
        {
            _params[key] = new List<string> { value };
        }

   
        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var pair in _params)
            {
                foreach (var value in pair.Value)
                {
                    if (builder.Length > 0) builder.Append('&');
                    builder.Append(Uri.EscapeDataString(pair.Key));
                    builder.Append('=');
                    builder.Append(Uri.EscapeDataString(value));
                }
            }
            return builder.ToString();
        }

   
        public void ___setPropertyByName(string name, object val)
        {
            set(name, val.ToString());
        }

        public object ___getPropertyByName(string name)
        {
            return ___getInner(name) ?? string.Empty;
        }

        public void ___setPropertyByIndex(int ___index, object val)
        {
            throw new NotImplementedException();
        }

        public object ___getPropertyByIndex(int ___index)
        {
            throw new NotImplementedException();
        }

        public bool ___hasPropertyByName(string name)
        {
            return has(name);
        }

        public bool ___hasPropertyByIndex(int ___index)
        {
            throw new NotImplementedException();
        }

        public void ___deleteByIndex(int ___index)
        {
            throw new NotImplementedException();
        }

        public void ___deleteByName(string ___Name)
        {
           delete(___Name);
        }

        public object[] ___getByIds()
        {
            return _params.Keys.ToArray();
        }

        public object ___getDefaultValue()
        {
            return ToString();
        }

        public object ___getProtoType()
        {
            return null;
        }

        public void ___setProtoType(object __object)
        {
            throw new NotImplementedException();
        }

        public void ___setParentScope(object __object)
        {
            throw new NotImplementedException();
        }

        public object ___getParentScope()
        {
            throw new NotImplementedException();
        }

        public string ___getClassName()
        {
            return "URLSearchParams";
        }

        public bool ___hasInstance(object __object)
        {
            return __object is CHtmlURLSearchParams;
        }

        public bool ___instanceEquals(object __object)
        {
            return ReferenceEquals(this, __object);
        }

        public object ___common_object_clone()
        {
            return new CHtmlURLSearchParams(ToString());
        }

        public IMutilversalObjectType multiversalClassType => IMutilversalObjectType.URLSearchParams;

        #region IDyamicMetaObjectProvider support to get and set properties
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlURLSearchParams>(parameter, this);
        }
        SortedList<string, object> ___properties = new SortedList<string, object>();
        public object GetDynamicMember(string name)
        {
            object objValue = null;
            this.___properties.TryGetValue(name, out objValue);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.GetDynamicMember({1} returns : {2}", this, name, objValue);
            }
            return objValue;
        }
        public void SetDynamicMember(string name, object value)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.SettDynamicMember({1} is called value: {2}", this, name, value);
            }
            this.___properties[name] = value;
        }
        public IEnumerable<string> GetDynamicMemberNames()
        {
            return this.___properties.Keys;
        }
        #endregion
    }
}