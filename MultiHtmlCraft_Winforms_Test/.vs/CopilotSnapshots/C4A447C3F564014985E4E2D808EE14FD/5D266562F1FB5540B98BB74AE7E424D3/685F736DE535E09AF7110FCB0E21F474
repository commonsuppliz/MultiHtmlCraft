using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Interfaces
{
    public interface ICHtmlDocumentInterface
    {
        ICHtmlElementInterface body { get;  }
        ICHtmlElementInterface activeElement { get;  }
        string charset { get; }
        string characterSet { get; }
        string defaultCharset { get; }
        string cookie { get; set; }
        object doctype { get; }
        string dir { get; }
        ICHtmlElementInterface documentElement { get; }
        object documentMode { get; }
        string domain { get; }
        ICHtmlElementInterface head { get; }
        ICHtmlElementInterface firstChild { get; }
        ICHtmlElementInterface lastChild { get; }
        string lastModified { get; }
        string localName { get; }
        string namespaceURI { get; }
        string prefix { get; }
        string protocol { get; }
        string readyState { get; }
        string referrer { get; }
        string title { get; }
        string uniqueID { get; }
        string URL { get; }
        string xmlEncoding { get; }
        string xmlStandalone { get; }
        string xmlVersion { get; }
        string innerHTML { get; set; }
        object location { get; }
        object onload { get; set; }
     


        /// <summary>
        /// In order to support document.all for IE, this must be supported.
        /// </summary>
        /// <param name="___baseList">base element list</param>
        /// <returns>MSIE document.all function object</returns>
        object ___createDocumentAllFunctionObject(System.Collections.ArrayList ___baseList);
    }
}
