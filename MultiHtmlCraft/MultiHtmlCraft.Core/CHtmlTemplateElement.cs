using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// HTML5 Template Element which ___hasInner special read-only 'content' property to access child nodes
    /// </summary>
    public sealed class CHtmlTemplateElement : CHtmlElement 
    {
        public CHtmlTemplateElement()
        {
            base.___multiversalClassType = IMutilversalObjectType.HTMLTemplateElement;
            this.___isInactivativeElementNodeChild = true;
        }
        /// <summary>
        /// readonly property Element to access child node as 'template'
        /// </summary>
        public new CHtmlElement content
        {
            get
            {
                CHtmlElement ___contentNode = null;
                if (this.___childNodes.Count == 1)
                {
                    ___contentNode = this.___childNodes[0] as CHtmlElement;
                }
                else
                {
                    ___contentNode = this;
                }
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("{0}.content will returns this template node : {1}.....", this.toLogString(), ___contentNode);
                }
                return ___contentNode;
            }
        }
        public override object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
            {
                commonLog.LogEntry("entering {0}.___getPropertyByName({1}).....", this.toLogString(), ___name);
            }
            if (string.Equals(___name, "content", StringComparison.Ordinal) == true)
            {
                return this.content;
            }
            return String.Empty;
        }
        public override bool ___hasPropertyByName(string ___name)
        {
            if (string.Equals(___name, "content", StringComparison.Ordinal) == true)
            {
                return true;
            }
            return base.___hasPropertyByName(___name);
        }
        public override string ToString()
        {
            return "[object " + base.___multiversalClassType.ToString() + "]";
        }
        public IMutilversalObjectType multiversalObjectType
        {
            get { return base.___multiversalClassType; }
        }
    }
}
