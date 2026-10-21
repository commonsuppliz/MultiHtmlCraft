using MultiHtmlCraft.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// Minimal CSSStyleDeclaration-like class for getComputedStyle results.
    /// - Provides getPropertyValue(name) and setProperty(name, value)
    /// - Supports string indexer: style["border-top-width"]
    /// - Provides toString() via CLR ToString(), ClearScript binder will expose a callable delegate.
    /// - Stores values case-insensitively.
    /// </summary>
    public class CHtmlCSSStyleDeclaration : ICHtmlCSSStyleDeclaration ,  ICommonObjectInterface
    {
        IMutilversalObjectType ICommonObjectInterface.multiversalClassType => IMutilversalObjectType.CSSStyleDeclaration;
        internal ICHtmlCSSStyleDeclaration? ____parentStyleSheet = null;

        private readonly Dictionary<string, string> ___properties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public CHtmlCSSStyleDeclaration() {
            
            /*
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"{this} constructor is called)...");
            }
            */

        }

        public CHtmlCSSStyleDeclaration(IDictionary<string, string> initial)
        {
            if (initial != null)
            {
                foreach (var kv in initial)
                {
                    this.___properties[kv.Key] = kv.Value ?? string.Empty;
                }
            }
        }

        public string this[string name]
        {
            get => getPropertyValue(name) ?? string.Empty;
            set => setProperty(name, value);
        }
        private static string ___convertNullToEmpty(string ___value)
        {
            if (___value == null)
                return "";
            return ___value;
        }

        public string? getPropertyValue(string name)
        {
            string strResult = string.Empty;
            if(commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"enter {this}.getPropertyValue({name})...");
            }
            if (!string.IsNullOrEmpty(name))
            {
                if (____parentStyleSheet != null)
                {
                    var parentValue = ____parentStyleSheet.getPropertyValue(name);
                    if (!string.IsNullOrEmpty(parentValue))
                    {
                        strResult = parentValue;
                    }
                    goto PropertyValueObtained;
                } else {
                    strResult = string.Empty;
                }
                strResult =  this.___getPropertyByName(name)?.ToString() ?? string.Empty;
            }
        PropertyValueObtained:
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"reterns {this}.getPropertyValue({name}) :  {strResult}...");
            }
            return strResult;
        }

        public void setProperty(string name, string? value)
        {
            if (string.IsNullOrEmpty(name)) return;
            this.___properties[name] = value ?? string.Empty;
        }

        public void removeProperty(string name)
        {
            if (string.IsNullOrEmpty(name)) return;
            this.___properties.Remove(name);
        }

        public IEnumerable<string> getPropertyNames()
        {
            return this.___properties.Keys.ToArray();
        }

        public override string ToString()
        {
            // Simple serialization like: "prop: value; prop2: value2;"
            if (this.___properties.Count == 0) return string.Empty;
            return string.Join("; ", this.___properties.Select(kv => $"{kv.Key}: {kv.Value}")) + ";";
        }
        #region IPropertBox メンバ

        public object ___getPropertyByName(string ___name)
        {
            object? cssPropertyResult = null;
            string ___nameLow = null;
            if (___name != null)
            {
                ___nameLow = commonHTML.FasterTrimAndToLower(___name);
            }
            var ___cssStyleheet = this as CHtmlCSSStyleSheet;
            if (___cssStyleheet != null)
            {
                cssPropertyResult = ___cssStyleheet.___getPropertyByName(___name);

            }
            if(commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"{this}.___getProppetyValue({___name } returns : {cssPropertyResult}");
            }

            return cssPropertyResult; // style property access always returns "" if not found.
        }

        public void ___setPropertyByName(string ___name, object val)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("calling setPropertyValueIndex for {0} {1}  {2} = {3}", this.GetType(), this, ___name, val);
            }
            switch (___name)
            {


                default:
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                        commonLog.LogEntry("setPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    this.___properties[___name] = commonHTML.GetStringValue(val);
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
        public object ___getPropertyByName(string ___name, bool ___isGetOnly)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___getPropertyByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }
            return null;
        }


        #endregion

    }
}
