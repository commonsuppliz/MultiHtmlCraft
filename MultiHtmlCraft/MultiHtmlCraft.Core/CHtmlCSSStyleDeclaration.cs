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
    public class CHtmlCSSStyleDeclaration : ICHtmlCSSStyleDeclaration 
    {
        internal ICHtmlCSSStyleDeclaration? ____parentStyleSheet = null;

        private readonly Dictionary<string, string> _props = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public CHtmlCSSStyleDeclaration() {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"{this} constructor is called)...");
            }

        }

        public CHtmlCSSStyleDeclaration(IDictionary<string, string> initial)
        {
            if (initial != null)
            {
                foreach (var kv in initial)
                {
                    _props[kv.Key] = kv.Value ?? string.Empty;
                }
            }
        }

        public string this[string name]
        {
            get => getPropertyValue(name) ?? string.Empty;
            set => setProperty(name, value);
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
                strResult =  _props.TryGetValue(name, out var v) ? v : string.Empty;
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
            _props[name] = value ?? string.Empty;
        }

        public void removeProperty(string name)
        {
            if (string.IsNullOrEmpty(name)) return;
            _props.Remove(name);
        }

        public IEnumerable<string> getPropertyNames()
        {
            return _props.Keys.ToArray();
        }

        public override string ToString()
        {
            // Simple serialization like: "prop: value; prop2: value2;"
            if (_props.Count == 0) return string.Empty;
            return string.Join("; ", _props.Select(kv => $"{kv.Key}: {kv.Value}")) + ";";
        }
    }
}
