using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    public sealed class CHtmlDOMParser : CHtmlNode, ICommonObjectInterface 
    {
        internal System.WeakReference ___MultiversalWindowWeakReference = null;
        internal string ___baseThreadURL = "";
        /// <summary>
        /// holds strong reference for document
        /// </summary>

        public async Task<CHtmlDocument> parseFromString(object ___strContentObject, object ___domtype)
        {
            CHtmlDocument ___xmldom = null;
            string ___strContent = commonHTML.GetStringValue(___strContentObject);
            string ___strDomType = commonHTML.GetStringValue(___domtype);
            try
            {
                CHtmlDomModeType ___targetDOMType = CHtmlDomModeType.XMLDOM;
                switch (___strDomType)
                {
                    case "application/xml":
                    case "text/xml":
                        ___targetDOMType = CHtmlDomModeType.XMLDOM;
                        break;
                    case "text/html":
                    case "text/xhtml":
                    case "text/plain":
                    case "text/htm":
                        ___targetDOMType = CHtmlDomModeType.HTMLSegment;
                        break;
                    case "text/svg":
                    case "image/svg+xml":
                    case "image/svg":
                    case "application/svg":
                        ___targetDOMType = CHtmlDomModeType.SVGDOM;
                        break;
                    default:
                        break;
                }
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("++++++++DOMParser mime type : {0} [{1}] will loading+++++++++++++", ___strDomType, ___targetDOMType);

                   commonLog.LogEntry(___strContent);
                   commonLog.LogEntry("++++++++++++++++++++++++++++++++++++++++++++++++++++");
                }
                string ___xmlCharset = null;

                switch (___targetDOMType)
                {
                    case CHtmlDomModeType.SVGDOM:
                        ___xmldom = new CHtmlDocument(CHtmlDomModeType.SVGDOM);
                        ___xmlCharset = commonHTML.GetXMLEncodingStringFromBytes(System.Text.UTF8Encoding.UTF8.GetBytes(___strContent));
                        break;
                    case CHtmlDomModeType.XMLDOM:
                        ___xmldom = new CHtmlDocument(CHtmlDomModeType.XMLDOM);
                        ___xmlCharset = commonHTML.GetXMLEncodingStringFromBytes(System.Text.UTF8Encoding.UTF8.GetBytes(___strContent));
                        break;
                    case CHtmlDomModeType.HTML:
                        ___xmldom = new CHtmlDocument(CHtmlDomModeType.HTMLSegment);
                        break;
                    default:
                        ___xmldom = new CHtmlDocument(CHtmlDomModeType.XMLDOM);
                        ___xmlCharset = commonHTML.GetXMLEncodingStringFromBytes(System.Text.UTF8Encoding.UTF8.GetBytes(___strContent));
         
                        break;
                }
                if (this.___MultiversalWindowWeakReference != null)
                {
                    CHtmlMultiversalWindow ___multiversalWindow = this.___MultiversalWindowWeakReference.Target as CHtmlMultiversalWindow;
                    if (___multiversalWindow != null)
                    {
                        // we like to track the document. 
                        if (___multiversalWindow.___dynamicallyCreateObjectList == null)
                        {
                            ___multiversalWindow.___dynamicallyCreateObjectList = new System.Collections.ArrayList();
                        }
                        ___multiversalWindow.___dynamicallyCreateObjectList.Add(___xmldom);

                    }
                }

                if (___targetDOMType == CHtmlDomModeType.SVGDOM || ___targetDOMType == CHtmlDomModeType.XMLDOM)
                {
                    if (string.IsNullOrEmpty(___xmlCharset) == false)
                    {
                        ___xmldom.___charset = ___xmlCharset;
                    }
                    else
                    {
                        ___xmldom.___charset = "utf-8";
                    }
                    ___xmldom.___IsHtmlCharSetDetectionCompleted = true;
                }
                ___xmldom.___IsElementCreationNeedsToBeDynamic = true;
                ___xmldom.___IsHtmlResponseCompleted = true;
                ___xmldom.___responseStartTime = DateTime.Now;
                ___xmldom.___IsHtm1stHttpResponseCompleted = true;
                if (string.IsNullOrEmpty(___strDomType) == false)
                {
                    ___xmldom.___contentType = string.Copy(___strDomType);
                }
                ___xmldom.___HtmlBuilder.Append(___strContent);
                ___xmldom.___HtmlBuilderLength = ___xmldom.___HtmlBuilder.Length;
                CHtmlDocument ____xmldoc = new CHtmlDocument(___targetDOMType);
                

                return ____xmldoc;
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("parseFromString() Exception ", ex);
                }
            }
            return ___xmldom;
        }

        #region IPropertBox メンバ

       
        public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {

                case "__iterator__":
                    return commonHTML.rhinoForLoopEnumratorFunction;
            }
            return null;
        }

        public void ___setPropertyByName(string ___name, object val)
        {
            switch (___name)
            {
                default:
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    break;
            }
        }
        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }


        public bool ___hasPropertyByName(string ___name)
        {
            switch (___name)
            {
                case "__iterator__":
                    return true;
            }

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
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
            }
            return "DOMParser";
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
        public new IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.DOMParser;
            }
        }






        #endregion

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

        public object ___getPropertyByIndex(int ___index)
        {
            throw new NotImplementedException();
        }
    }
}
