using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace MultiHtmlCraft.Interfaces
{
    /// <summary>
    /// Interface for CSSStyleDeclaration-like objects returned from getComputedStyle.
    /// </summary>
    public interface ICHtmlCSSStyleDeclaration
    {
        // string indexer: style["border-top-width"]
        string this[string name] { get; set; }

        // get property by name (returns empty string when not found)
        string? getPropertyValue(string name);

        // set property by name (null value is treated as empty string)
        void setProperty(string name, string? value);

        // remove property by name
        void removeProperty(string name);

        // enumerate property names
        IEnumerable<string> getPropertyNames();

        // serialize to string (e.g., "prop: value; ...")
        string ToString();
    }
}