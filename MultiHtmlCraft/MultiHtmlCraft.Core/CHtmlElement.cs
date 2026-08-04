
using MultiHtmlCraft.Interfaces;
using Newtonsoft.Json.Linq;
using NiL.JS.Core.Interop;
using NiL.JS.Statements;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.ClearScript;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// Dirty Implementation of
	/// IHTMLElement
	/// ms-help://MS.VSCC.2003/MS.MSDNQTR.2003FEB.1041/progie/workshop/browser/mshtml/reference/ifaces/document2/document2.htm
	/// </summary>
	[ComVisible(true)]
	
	public class CHtmlElement : CHtmlBase, ICommonObjectInterface, ICHtmlElementInterface  
	{
        public static readonly Dictionary<string, int> CHtmlElementProperties = InitalizeCHtmlElementPropertiyNames();

        private static Dictionary<string, int> InitalizeCHtmlElementPropertiyNames()
        {
            Dictionary<string, int> list = new Dictionary<string, int>
        {
            { "nodeName", 0 },
            { "name", 1 },
            { "clientWidth", 2 },
            { "clientHeight", 3 },
            { "clientTop", 4 },
            { "clientLeft", 5 },
            { "offsetWidth", 6 },
            { "offsetLeft", 7 },
            { "offsetTop", 8 },
            { "offsetHeight", 9 },
            { "availWidth", 10 },
            { "availHeight", 11 },
            { "availLeft", 12 },
            { "availTop", 13 },
            { "paddingLeft", 14 },
            { "paddingRight", 15 },
            { "paddingTop", 16 },
            { "paddingBottom", 17 },
            { "leftMargin", 18 },
            { "marginLeft", 19 },
            { "marginRight", 20 },
            { "rightMargin", 21 },
            { "marginTop", 22 },
            { "marginBottom", 23 },
            { "bottomMargin", 24 },
            { "minHeight", 25 },
            { "minWidth", 26 },
            { "maxWidth", 27 },
            { "maxHeight", 28 },
            { "clientRectangle", 29 },
            { "itemScope", 30 },
            { "validationMessage", 31 },
            { "prototype", 32 },
            { "offsetBounds", 33 },
            { "TableCells", 34 },
            { "TableRows", 35 },
            { "layerX", 36 },
            { "layerY", 37 },
            { "offsetParent", 38 },
            { "parent", 39 },
            { "parentElement", 40 },
            { "parentNode", 41 },
            { "form", 42 },
            { "firstChild", 43 },
            { "lastChild", 44 },
            { "attributes", 45 },
            { "style", 46 },
            { "runtimeStyle", 47 },
            { "stylesheet", 48 },
            { "styleSheet", 49 },
            { "tagNameNoNS", 50 },
            { "tagName", 51 },
            { "src", 52 },
            { "target", 53 },
            { "href", 54 },
            { "html", 55 },
            { "rel", 56 },
            { "innerText", 57 },
            { "offsetScreenBounds", 58 },
            { "scrollTop", 59 },
            { "scrollLeft", 60 },
            { "scrollWidth", 61 },
            { "scrollHeight", 62 },
            { "scrollDelay", 63 },
            { "scrollAmount", 64 },
            { "uniqueID", 65 },
            { "uniqueNumber", 66 },
            { "dataset", 67 },
            { "dataSet", 68 },
            { "DataSet", 69 },
            { "document", 70 },
            { "elements", 71 },
            { "outerHTML", 72 },
            { "outerXml", 73 },
            { "innerHTML", 74 },
            { "ownerDocument", 75 },
            { "autocomplete", 76 },
            { "accessKey", 77 },
            { "childNodes", 78 },
            { "onload", 79 },
            { "onunload", 80 },
            { "onblur", 81 },
            { "onmove", 82 },
            { "onpaste", 83 },
            { "oncopy", 84 },
            { "oncut", 85 },
            { "onchange", 86 },
            { "oncellchange", 87 },
            { "onbeforecut", 88 },
            { "onselectstart", 89 },
            { "oncontextmenu", 90 },
            { "onmouseover", 91 },
            { "onmousemove", 92 },
            { "onmousedown", 93 },
            { "onmouseup", 94 },
            { "onmouseout", 95 },
            { "onmousewheel", 96 },
            { "onmouseenter", 97 },
            { "onmouseleave", 98 },
            { "onkeydown", 99 },
            { "onkeyup", 100 },
            { "onkeypress", 101 },
            { "onscroll", 102 },
            { "onsubmit", 103 },
            { "ondragstart", 104 },
            { "ondragend", 105 },
            { "ondrag", 106 },
            { "ondrop", 107 },
            { "onhover", 108 },
            { "onerror", 109 },
            { "onerrorupdate", 110 },
            { "onresize", 111 },
            { "ontouchstart", 112 },
            { "ontouchend", 113 },
            { "onresizestart", 114 },
            { "onresizeend", 115 },
            { "onactivate", 116 },
            { "onbeforeactivate", 117 },
            { "onfocus", 118 },
            { "onfocusin", 119 },
            { "onfocusout", 120 },
            { "onclick", 121 },
            { "ondblclick", 122 },
            { "onabort", 123 },
            { "onreadystatechange", 124 },
            { "readyState", 125 },
            { "readyStateValue", 126 },
            { "currentStyle", 127 },
            { "canHaveChildren", 128 },
            { "nextElementSibling", 129 },
            { "nextSibling", 130 },
            { "previousElementSibling", 131 },
            { "previousSibling", 132 },
            { "contentWindow", 133 },
            { "disabled", 134 },
            { "isdisabled", 135 },
            { "height", 136 },
            { "width", 137 },
            { "dataSrc", 138 },
            { "datasrc", 139 },
            { "DataSrc", 140 },
            { "syncMaster", 141 },
            { "isTextEdit", 142 },
            { "istextedit", 143 },
            { "isTextedit", 144 },
            { "isMultiline", 145 },
            { "vLink", 146 },
            { "vlink", 147 },
            { "aLink", 148 },
            { "alink", 149 },
            { "Link", 150 },
            { "link", 151 },
            { "vspace", 152 },
            { "hspace", 153 },
            { "canHaveHTML", 154 },
            { "atomicselection", 155 },
            { "timerContainer", 156 },
            { "Method", 157 },
            { "method", 158 },
            { "multiple", 159 },
            { "length", 160 },
            { "object", 161 },
            { "hasMedia", 162 },
            { "cols", 163 },
            { "rows", 164 },
            { "cells", 165 },
            { "rev", 166 },
            { "Rev", 167 },
            { "rules", 168 },
            { "background", 169 },
            { "Background", 170 },
            { "content", 171 },
            { "sheet", 172 },
            { "scheme", 173 },
            { "httpEquiv", 174 },
            { "size", 175 },
            { "sizcache", 176 },
            { "srcdoc", 177 },
            { "longdesc", 178 },
            { "localName", 179 },
            { "baseUri", 180 },
            { "textContent", 181 },
            { "sizset", 182 },
            { "httpequiv", 183 },
            { "version", 184 },
            { "bgColor", 185 },
            { "encoding", 186 },
            { "enctype", 187 },
            { "backgroundcolor", 188 },
            { "backgroundColor", 189 },
            { "foregroundcolor", 190 },
            { "foregroundColor", 191 },
            { "encType", 192 },
            { "acceptCharset", 193 },
            { "pluginsPage", 194 },
            { "pluginspage", 195 },
            { "prefix", 196 },
            { "namespaceURI", 197 },
            { "valueType", 198 },
            { "valuetype", 199 },
            { "mimetype", 200 },
            { "mimeType", 201 },
            { "scope", 202 },
            { "ch", 203 },
            { "chOff", 204 },
            { "choff", 205 },
            { "axis", 206 },
            { "auto", 207 },
            { "async", 208 },
            { "autoplay", 209 },
            { "defer", 210 },
            { "autofocus", 211 },
            { "abbr", 212 },
            { "scopeName", 213 },
            { "loop", 214 },
            { "accept", 215 },
            { "isMap", 216 },
            { "Accept", 217 },
            { "Start", 218 },
            { "contentDocument", 219 },
            { "dynsrc", 220 },
            { "coords", 221 },
            { "acceptcharset", 222 },
            { "BGColor", 223 },
            { "BgColor", 224 },
            { "summary", 225 },
            { "tagUrn", 226 },
            { "hideFocus", 227 },
            { "role", 228 },
            { "recordNumber", 229 },
            { "isContentEditable", 230 },
            { "isDisabled", 231 },
            { "bgProperties", 232 },
            { "action", 233 },
            { "blockDirection", 234 },
            { "alt", 235 },
            { "Alt", 236 },
            { "wrap", 237 },
            { "tabIndex", 238 },
            { "maxLength", 239 },
            { "maxlength", 240 },
            { "sourceIndex", 241 },
            { "border", 242 },
            { "Border", 243 },
            { "borderColor", 244 },
            { "bordercolor", 245 },
            { "borderColorDark", 246 },
            { "bordercolordark", 247 },
            { "borderColorLight", 248 },
            { "bordercolorlight", 249 },
            { "data", 250 },
            { "code", 251 },
            { "classid", 252 },
            { "classID", 253 },
            { "charset", 254 },
            { "caption", 255 },
            { "cellPadding", 256 },
            { "cellpadding", 257 },
            { "cellSpacing", 258 },
            { "cellspacing", 259 },
            { "label", 260 },
            { "selected", 261 },
            { "defaultselected", 262 },
            { "defaultSelected", 263 },
            { "codeType", 264 },
            { "codetype", 265 },
            { "end", 266 },
            { "unselectable", 267 },
            { "UnSelectable", 268 },
            { "altHTML", 269 },
            { "htmlFor", 270 },
            { "htmlfor", 271 },
            { "altHtml", 272 },
            { "althtml", 273 },
            { "archive", 274 },
            { "basehref", 275 },
            { "BaseHref", 276 },
            { "units", 277 },
            { "frameBorder", 278 },
            { "text", 279 },
            { "options", 280 },
            { "onOffBehavior", 281 },
            { "trueSpeed", 282 },
            { "media", 283 },
            { "scroll", 284 },
            { "scrolling", 285 },
            { "translate", 286 },
            { "title", 287 },
            { "dataFld", 288 },
            { "hidden", 289 },
            { "datafld", 290 },
            { "dir", 291 },
            { "readOnly", 292 },
            { "readonly", 293 },
            { "language", 294 },
            { "lang", 295 },
            { "allowtransparency", 296 },
            { "contentEditable", 297 },
            { "Align", 298 },
            { "align", 299 },
            { "type", 300 },
            { "selectedIndex", 301 },
            { "value", 302 },
            { "nodeValue", 303 },
            { "nodeType", 304 },
            { "image", 305 },
            { "outerText", 306 },
            { "parentBlockElement", 307 },
            { "defaultView", 308 },
            {"firstElementChild", 309 },
            {"shadowRoot", 310 },
            {"className", 311 },
            {"class", 312 },
            {"complete",313 },
            {"input", 314 },
            {"output", 315 },
            {"progress", 316 },
            {"change", 317  },
            {"click", 318  },
            {"files" , 319   }
               



            }; 



            return list;
        }
        internal static readonly Dictionary<string, int> CHtmlElementMethods = new Dictionary<string, int>
    {

        { "createDocumentFragment", 0 },
        { "createElement", 0 },
        { "item", 0 },
        { "hasAttributes", 0 },
        { "hasAttribute", 0 },
        { "createTextRange", 0 },
        { "isSupported", 0 },
        { "isEqualNode", 0 },
        { "getAttribute", 0 },
        { "getAttributeNS", 0 },
        { "hasAttributeNS", 0 },
        { "setAttributeNS", 0 },
        { "removeAttributeNS", 0 },
        { "getAttributeNode", 0 },
        { "setAttributeNode", 0 },
        { "removeAttributeNode", 0 },
        { "removeAttribute", 0 },
        { "setAttribute", 0 },
        { "getElementsByTagNameNS", 0 },
        { "getElementsByTagName", 0 },
        { "getElementsByName", 0 },
        { "getElementsByClassName", 0 },
        { "getElementById", 0 },
        { "querySelectorAll", 0 },
        { "querySelector", 0 },
        { "matches", 0 },
        { "matchesSelector", 0 },
        { "mozMatchesSelector", 0 },
        { "webkitMatchesSelector", 0 },
        { "replaceChild", 0 },
        { "swapNode", 0 },
        { "supports", 0 },
        { "insertBefore", 0 },
        { "removeChild", 0 },
        { "removeNode", 0 },
        { "clearAttributes", 0 },
        { "ResetScreenBounds", 0 },
        { "normalize", 0 },
        { "doScroll", 0 },
        { "contains", 0 },
        { "appendChild", 0 },
        { "update", 0 },
        { "scrollIntoView", 0 },
        { "addEventListener", 0 },
        { "detachEvent", 0 },
        { "dispatchEvent", 0 },
        { "attachEvent", 0 },
        { "focus", 0 },
        { "compareDocumentPosition", 0 },
        { "createEventObject", 0 },
        { "fireEvent", 0 },
        { "insertAdjacentElement", 0 },
        { "insertAdjacentHTML", 0 },
        { "insertAdjacentText", 0 },
        { "blur", 0 },
        { "addBehavior", 0 },
        { "removeBehavior", 0 },
        { "getVariable", 0 },
        { "reset", 0 },
        { "save", 0 },
        { "click", 0 },
        { "hasChildNodes", 0 },
        { "setExpression", 0 },
        { "insertRow", 0 },
        { "insertCell", 0 },
        { "start", 0 },
        { "stop", 0 },
        { "toDataURL", 0 },
        { "toDataUrl", 0 },
        { "getContext", 0 },
        { "requestPointerLock", 0 },
        { "webkitRequestPointerLock", 0 },
        { "mozRequestPointerLock", 0 },
        { "checkValidity", 0 },
        { "mergeAttributes", 0 },
        { "setActive", 0 },
        { "getBoundingClientRect", 0 },
        { "getClientRects", 0 },
        { "LogElementDOMTree", 0 },
        { "captureEvents", 0 },
        { "isHomePage", 0 },
        { "mozRequestFullscreen", 0 },
        { "mozRequestFullScreen", 0 },
        { "webkitRequestFullscreen", 0 },
        { "webkitRequestFullScreen", 0 },
        { "msRequestFullscreen", 0 },
        { "msRequestFullScreen", 0 },
        { "requestFullscreen", 0 },
        { "requestFullScreen", 0 },
        { "mozCancelFullscreen", 0 },
        { "mozCancelFullScreen", 0 },
        { "webkitCancelFullscreen", 0 },
        { "webkitCancelFullScreen", 0 },
        { "msCancelFullscreen", 0 },
        { "msCancelFullScreen", 0 },
        { "cancelFullscreen", 0 },
        { "cancelFullScreen", 0 },
        { "mozExitFullscreen", 0 },
        { "mozExitFullScreen", 0 },
        { "webkitExitFullscreen", 0 },
        { "webkitExitFullScreen", 0 },
        { "msExitFullscreen", 0 },
        { "msExitFullScreen", 0 },
        { "exitFullscreen", 0 },
        { "exitFullScreen", 0 },
        { "hasClassName", 0 },
        { "remove", 0 },
        { "hasOwnProperty", 0 },
        { "toString", 0 },
        { "isPrototypeOf", 0 },
        { "cloneNode", 0 },

    };


        internal CHtmlVersionType ___ElementVersion = CHtmlVersionType.Version1;
        internal System.WeakReference ___documentWeakRef = null;
        internal System.WeakReference ___DocumentHiddenWeakReference = null;
        internal string ___namepaceURI = null;
        internal System.IntPtr ___CMZ_ManagedControlCreatedWindowHandle = IntPtr.Zero;
		//private CHtmlCollection _textNodes = null;
		public System.Collections.Generic.List<CHtmlDrawingObject> ___drawingObjectList = null;
		public bool ___AcceptsCrlf = false;
		public bool ___IsPreserveWhiteSpacesCrlf = false;
		//public string PlainText = ""; -> use .value
		/// <summary>
		/// Flag to indicate map infomation if exists.
		/// </summary>
		internal bool ___HasMapInfo = false;	
		public int MapTagDocumentElemementIndex = -1;

		public CHtmlAttributeList ___attributes = null;
		/// <summary>
		/// ___parent can be document or element it is internal
		/// </summary>
		public System.WeakReference  ___parentWeakRef = null;
        internal int ___elementOID = commonHTML.getElementAdhocRandomNumber();
        /// <summary>
        /// StopWatch to monitor element.src for image/audo download elapsedTime
        /// </summary>
        internal System.Diagnostics.Stopwatch ___elementResouceDownloadElapsedWatch = null;
        internal CHtmlBase ___parent
        {
            get
            {

                if (___parentWeakRef == null)
                    return null;
                   object rebinstanace  = ___parentWeakRef.Target;
                  CHtmlBase baseins = rebinstanace as CHtmlBase;
                  if (baseins != null)
                  {
                      return baseins;
                  }
               
                    return null;
                
            }
        }

        public CHtmlElement ___getParentElement()
        {
            if (this.___parentWeakRef == null)
                return null;
            else
                return this.___parentWeakRef.Target as CHtmlElement;
        }
        public CHtmlDocument ___getDocument()
        {
            if (this.___documentWeakRef != null)
            {
                return this.___documentWeakRef.Target as CHtmlDocument;
            }
            return null;
        }

        internal CHtmlDocument ___Document
        {
            get
            {
                if (this.___documentWeakRef != null)
                {
                    return this.___documentWeakRef.Target as CHtmlDocument;
                }
                return null;
            }
        }
		/// <summary>
		/// Internal Owner Table Element 
		/// </summary>
		public CHtmlElement ___ownerTableElement = null;
    
		private CHtmlElement[,] ___tableCells = null;
		private CHtmlElement[] ___tableRows = null;
	
		public int ___TableRowCount = 0;

        internal bool ___IsDownloadComplete = false;
        /// <summary>
        /// File path for this media
        /// </summary>
        internal string ___LocalFilePath = null;

        /// <summary>
        /// Raw Media File Content Length (Total)
        /// </summary>
        internal double ___rawMediaFileByteTotalLength = 0;
        /// <summary>
        /// Raw Media File Downloaded Length (Loaded)
        /// </summary>
        internal double ___rawMediaFileByteLoadedLength = 0;
		/// <summary>
		/// Flag Table TD Cell width are fiexed size for each columns
		/// </summary>
		public bool ___IsTableCellWidthFixedOnEachColumn = false;
		
		public bool ___IsAttributesMergedToInlineStyle = false;
		public bool ___isApplyElemenetStyleSheetCalled = false;
		/// <summary>
		/// If True, StyleList ___hasInner sorted by HitForThisNode
		/// </summary>
		public bool ___IsStyleListSortedByHitForThisNode = false;
        /// <summary>
        /// True if OnLoadWindowDocumentCompleted() is called
        /// </summary>
        public bool ___IsOnLoadWindowDocumentCompleted = false;

        internal CHtmlCollection ___childNodesQuickList = null;

        public bool ___IsElementPrefetchDummy = false;

        internal int ___applyCSSMethodCount = 0;

        internal int ___calcBoundsMethodCount = 0;
	
		
		public CHtmlTagClosedReasonType ___ClosedReson = CHtmlTagClosedReasonType.Open;
        // [To Be removed]
		//private ArrayList _InnerTextList;
		//private SortedList _InnerCharList;
		//private int _LastInnerTextRangeCreatedPos = -1;
		//public bool ___IsInnerTextComposed = false;
		//private ArrayList _InnerParagraphList = null;
        // [old class]
		//private CHtmlParagraphDrawingList ___renderingInformationList = null;
		/// <summary>
		/// Inline Style for CHtmlElement
		/// </summary>
		public  CHtmlCSSStyleSheet ___style = null;
		public  CHtmlCSSStyleSheet ___styleHover = null;
		// _styleActive should be equal to _style (normal style information)
		public CHtmlCSSStyleSheet ___styleActive = null;
        internal System.Collections.Generic.List<CHtmlCSSRule> ___stylesheetsForNextNodeList = null;
       
        internal CHtmlSelectorKeyClassType ___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType = CHtmlSelectorKeyClassType.NotSet;
        internal System.Collections.Generic.List<CHtmlCSSRule> ___stylesheetsForCurrentNodeList = null;
        internal CHtmlSelectorKeyClassType ___stylesheetsForCurrentNodeListNextLevelTopSelectorKeyClassType = CHtmlSelectorKeyClassType.NotSet;
		public int ___stylesheetsForNextNodeListWorkingSelectorMaximumCount = 0;
		public int ___stylesheetsForNextNodeListOriginalSelectorMaximumCount = 0;
		internal CHtmlFloatList ___cssFloatLeftElementList  = null;
        internal System.Collections.ArrayList ___cssFloatLeftDoneList = null;
		internal CHtmlFloatList ___cssFloatRightElementList = null;
        internal System.Collections.ArrayList ___cssFloatRightDoneList = null;
		//private FloatInfoList _floatMiddleDocumentIndexList = null;
		internal CHtmlNumberList  ___cssFloatTopPostionList = null;


        /// <summary>
        /// Equivalent to XMLNode.localName
        /// </summary>
        internal string ___elementTagNameCaseSensitive = null;

        /// <summary>
        /// Equivalent to XMLNode.name
        /// </summary>
        internal string ___elementTagNameWithNSCaseSensitive = null;

        /// <summary>
        /// Equivalent XML.namespace
        /// </summary>
        internal string ___elementNameSpaceCaseSensitive = null;
		
		public RectangleFSpec ___BaseControlDisplayRectangle = RectangleFSpec.Empty;
		public int ___ResetScreenBoundsAtFinalStageCount = 0;
		public int ___ResetScreenBoundsCount = 0;
		public bool ___IsHiddenElement = false;
        /// <summary>
        /// Flag which becomes true if css recaluculation only.
        /// </summary>
        internal bool ___IsElementUnderCSSRecaluculation = false;
		// =======================================
		// DO NOT USE THIS. THIS IS OLD
		// =======================================
		public bool ___IsChildrenAllSentence = false;
		public bool ___IsChildrenAllInline = false;
		/// <summary>
		/// True if element child ___hasInner block element. ex. div, p, etc. this is important for inline element boundary check such as span
		/// </summary>
		public bool ___IsElementContainsBlockElement = false;
		public int ___RenderingParentIndex = -1;
		
		public bool ___IsLayoutTag = false;
		public bool ___IsContainsDisplayableCharactersInnerText = false;

		public bool ___IsParentsAbsolutePosition = false;
		public bool ___IsElementVisible = true;
        /// <summary>
        /// if this element ___hasInner owner CSS element to be the owner 
        /// </summary>
        public bool ___hasMustInheritCSSElement = false;
        public bool ___isSVGGroupingChildElmentNode = false;
        public CHtmlElementType ___groupingElementType = CHtmlElementType._UNDEFINED;
        internal System.Collections.Generic.Dictionary<CSSAttributeType, string> ___mustInheritAttributeList;
        /// <summary>
        /// Weak Reference for owner css Element
        /// </summary>
        public System.WeakReference ___inheritCSSOwnerElementWeakReference = null;
        //public bool ___IsElementRemoved = false;
        public bool ___IsParentVisible = true;
		public bool ___IsElementBlock = true;
		public bool ___IsElementFloat = false;
		public bool ___IsElementClear = false;
		public bool ___IsLocationChangedByInlineLayout = false;
		public bool ___IsDrawDone = false;
        public bool ___IsElementBeforeCreated = false;
        public bool ___IsElementAfterCreated  = false;
        internal CHtmlElement  ___ElementBefore = null;
        internal CHtmlElement  ___ElementAfter = null;
		/// <summary>
		/// Element ___hasInner been created for system handling purpose. It is #Text Element normally. Used for Input Element
		/// </summary>
		public bool ___IsSystemHidden = false;

        internal bool ___IsElementBeforeAfterAddRequied = false;

		/// <summary>
		/// Element ___hasInner drawing Element direct below the object just in element, not in #text
		/// </summary>
		public bool ___HasDrawingElementInElement = false;


		private delegate void DelegatePerformAction(CHtmlElement element, CHtmlElement pelement, string args);

		/// <summary>
		/// If this flag is on Block element will be layout in the same as inline-block
		/// </summary>
		public bool ___IsElementLayoutByInlineBlockWay = false;
		
		/// <summary>
		/// Element is created dynamically by script
		/// </summary>
		public bool ___IsDynamicElement = false;
		/// <summary>
		/// Dynamic Element Process Done  Calcuate etc
		/// </summary>
		public bool ___IsDynamicProcessDone = false;

        /// <summary>
        /// True if postProcessMethod called for this node.
        /// </summary>
        public bool ___IsDynamicPostPorocessEntered = false;

        /// <summary>
        /// If script ___hasInner been executed.
        /// </summary>
        public bool ___IsScriptExecuted = false;

		public bool ___IsTagImmediateClosed = false;
		public bool ___IsElementAligned = false;
		/// <summary>
		/// Maximum of SelectorKey Working Key Count InElement
		/// Note: This functionality turns out degrade performance.  Delete 2013/07/22
		/// </summary>
		//
		//public int ___MaxNumOfSelectorWorkingKeyCountInElement = 0;


		/// <summary>
		/// When an element is disabled, it appears dimmed and does not respond to
		/// user input. Disabled elements do not respond to mouse events, nor will
		/// they respond to the contentEditable property. 
		/// </summary>
		private bool ___disabled = false;


        public bool ___IsMainDocumentNodeElement = false;

        /// <summary>
        /// How Image will be drawn
        /// -1 : unknown
        /// 1 : as Drawimae
        /// 10: As PictureBox
        /// </summary>
        internal int ___ElementImageFrameModeType = -1;

        /// <summary>
        /// MediaElement preload type
        /// </summary>
        internal CHtmlMediaElementPreloadType ___preloadType = CHtmlMediaElementPreloadType.unkonwn;

        internal ushort ___ElementPendingContenRetrialCount = 0;


        private string ___previousInnerText = null;
        private int ___previousChildCount = 0;

		// _async is async field 2012/11 HTML5 is boolean

        /// <summary>
        /// Img src ___hasInner loaded or not.
        /// </summary>


		
	
		private bool ___complete = false;
		/// <summary>
		/// Used only when document is not set like dynamic = true
		/// OBSOLUTE: ANY ELEMENT should attached to document then it created so documentEventList should be accessable
		/// </summary>
		/// public System.Collections.ArrayList ElementEventList = null;


		internal int ___ImageFrameCount = 0;

        

		/// <summary>
		/// offsetHeight Retrieves the height of the object relative to the layout or coordinate parent, as specified by the IHTMLElement::offsetParent property.  
		/// </summary>
		public double  ___offsetHeight;
		/// <summary>
		/// offsetLeft Retrieves the calculated left position of the object relative to the layout or coordinate parent, as specified by the IHTMLElement::offsetParent property. 
		/// </summary>
		public  double  ___offsetLeft;
		/// <summary>
		/// offsetParent Retrieves a reference to the container object that defines the IHTMLElement::offsetTop and IHTMLElement::offsetLeft properties of the object. 
		/// </summary>
		//private double  ___offsetParent;
        internal CHtmlDrawingObject ___PriorDrawingObject = null;
		/// <summary>
		/// offsetTop Retrieves the calculated top position of the object relative to the layout or coordinate parent, as specified by the IHTMLElement::offsetParent property.  
		/// </summary>
		public double  ___offsetTop;
		/// <summary>
		/// offsetWidth Retrieves the width of the object relative to the layout or coordinate parent, as specified by the IHTMLElement::offsetParent property. 		
		/// IE and Chorme string
		/// </summary>
		public double  ___offsetWidth;

		public double  ___paddingLeft;
		public double  ___paddingTop;
		public double  ___paddingBottom;
		public double  ___paddingRight;

		public double  ___marginLeft;
		public double  ___marginTop;
		public double  ___marginBottom;
        public double  ___marginRight;
		public double  ___minHeight;

		public double  ___maxHeight;

	    public double ___minWidth;
		public double  ___maxWidth;
        /// <summary>
        /// d
        /// 
        /// </summary>
        public  double ___layerY;
        public double ___layerX;

        public double  ___availWidth;
		public double  ___availHeight;
        public double  ___availLeft;
		public double  ___availTop;



	   public  double ___offsetRight;
	    public double ___offsetBottom;


        public RectangleFSpec ___offsetScreenBounds = RectangleFSpec.Empty;

        public PointFSpec ___offfsetParentPoint = PointFSpec.Empty;
		
		public IntPtr ___ManagedControlHandle = IntPtr.Zero;
   
        public System.WeakReference ___ManagedControlWeakReference = null;
		public bool ___ManagedControlShouldOnlyRelocatedByDrawElement = false;

		public uint ___MeasureRegionIndex = 0;
		public double ___BackgroundPositionX = 0;
		public double ___BackgroundPositionY = 0;



        internal bool ___IsElementIncludedInFormCacheList = false;
		// ===================================================================================
		// IHtmlElement2 property support
		// ===================================================================================
		internal string ___dataSrc = null;
		internal bool ___syncMaster = false;
	

		private bool ___isMultiline = false;
		
		private bool ___isTextEdit = false;
	
		private bool ___canHaveHTML = true;
		private string ___timerContainer = null;
		public bool ___isCalculateElementBoundsCalled;

	
        /// <summary>
        /// This value will be set from Element Style Element
        /// </summary>
		internal double ___TextIndentStyleParsed = 0;

		private CHtmlElementDataSet ___dataset = null;
		internal string ___tagNameNoNS = null;

		public bool ___IsNoScriptBlock = false;

        /// <summary>
        /// Flag if this element is created as resulf 'new ActiveXObjecet('Shockwave.Flash')
        /// </summary>
        internal bool ___IsElementAsShockwaveFlashActiveXObject = false;

		/// <summary>
		/// Count of 'on' methods
		/// </summary>
	

		public bool ___HasChildNodesPerentageHeight = false;

		public bool ___IsNodePercentageHeight = false;


		public CHtmlElement ___InlineVeryTopTextElement = null;
		public CHtmlElement ___InlineLastTextElement = null;
		/// <summary>
		/// List of Parents Searched Prior Text Element.
		/// </summary>
		internal CHtmlCollection ___ParentInlineTextLookedupedList = null;

		public CHtmlMediaQueryNode ___MediaQueryNode = null;

        /// <summary>
        /// CHtmlCSSyleSeet (instance)
        /// </summary>
        internal CHtmlCSSStyleSheet ___sheet = null;

        /// <summary>
        /// List of Form Element List Cached.
        /// </summary>
        internal CHtmlCollection ___FormElementCacheList = null;
        internal int ___FormElementChildCount = -1;

        /// <summary>
        /// For CSS3.0 :nth-of-type(n) usage.
        /// This element CHtmlElementType Count located in children.
        /// Value should be greater than 0 after added in children collection.
        /// 0 = Not Set.
        /// </summary>
        public int ___ElementNthOfNameType = 0;

        internal bool ___IsHTMLSelectElementSizeSpecified = false;
        /// <summary>
        /// If No Wrap Elements No more Drawing Element Creation
        /// </summary>
        internal bool ___ProhibitsDrawingElementCreationByNoWrap = false;
        internal bool ___defer = false;

        internal bool ___async = false;



 

        public bool ___IsElementofffsetParentPointCaluculationRequired = true;

        public bool ___IsElementCloned = false;

        /// <summary>
        /// How may Drawing Elements are checked to calucuate this elements bounds size
        /// </summary>
        public int ___BoundsCalucByDrawElementsCount = 0;

        /// <summary>
        ///  How may Normal HTML Elements are checked to calucuate this elements bounds size
        /// </summary>
        public int ___BoundsCalucByHTMLElementsCount = 0;

        /// <summary>
        /// Total Draw Element to ___getInner Bounds (Child)
        /// </summary>
        public int ___BoundsCalucWithChildDrawElementsTotalCount = 0;

        /// <summary>
        ///  Total HTML Element to ___getInner Bounds (Child)
        /// </summary>
        public int ___BoundsCalucWithChildHTMLElementsTotalCount = 0;

   
		private CHtmlElementAlignType ___nodeAlignType;
		
		private CHtmlElementAlignType ___nodeInheritedAlignType;

		internal string ___scopename = null;
		/// <summary>
		/// this control is enabled or not
		/// </summary>
		private bool ___enabled = true;

		//public int TextIndex = -1;

		/// <summary>
		/// DHTML createTextNode use
		/// </summary>
		// public bool AsTextNode = false;

		private CHtmlElement ___parentBlockElement = null;

		

		public PointF ___InlineStringLayoutPoint = PointF.Empty;
		public int  ___ElementInlineLevel = 0;
		/// <summary>
		/// Flag For Element position is using inline way. 
		/// Set this Flag only at CaluculateElementTextElement Section.
		/// </summary>
		public bool ___ElementInlineShifted = false;
		public int  ___ElementChildMinInlineLevel = 9999999;
		public bool ___IgnoreInlineLevelToGetPosition = false;

		internal System.Drawing.PointF ___InlineCornorPoint = PointF.Empty;

		/// <summary>
		/// As the element is analyzed, when block && non-float element closed, parent element will have the bottom position
		/// </summary>
		internal double ___CHtmlElementPreviousBlockElementBottom = 0;
		internal double ___CHtmlElementWorkingBlockElementBottom = 0;



		/// <summary>
		/// Flag if style ___hasInner overflow = {hidden, auto, scoll} with fixed size
		/// </summary>
		internal bool ___HasOverflowHidden = false;
		internal SizeF ___StyleOverFlowSize = SizeF.Empty;
		internal bool ___WillCreateMangedControl = false;
		internal bool ___WillElementIDAlternationRequiresDocumentCheck = false;
		public CHtmlEmbededObjectType ___EmbeddedControlType = CHtmlEmbededObjectType.NotSet;
		/// <summary>
		/// IFrame Window
		/// This is only created for iframe and frame
		/// </summary>
		// private CHtmlDocumentRenderer _iframeWindowObject = null;
        private System.Drawing.Image ___imageDownloadtemporarily = null;



		public bool ___IsStyleTagElementInnserStyleSheetProcessed = false;

	

		/// <summary>
		/// DrawElements TextRendering will be skipped
		/// </summary>
		public bool ___IsTextRenderSkip = false;

		public bool ___IsStyleHoverSet = false;

		public bool ___IsStyleActiveSet = false;
		public bool ___IsFloatStyleTopShiftOccurred = false;
		

		/// <summary>
		/// CSS Adjacent Combinator (~) Style SelectorKey needs to look up in this node
		/// </summary>
		public bool ___HasCSSIndirectAdjacentCombinator = false;
		/// <summary>
		/// CSS Adjacent Combinator (~) Style SelectorKey is created one of this childnodes.
		/// </summary>
		public bool ___HasCSSIndirectAdjacentCombinatorInChildren = false;

		/// <summary>
		/// CSS Adjacent Sibling Combinator (+) Style SelectorKey needs to look up in this node
		/// </summary>
		public bool ___HasCSSAdjacentSiblingCombinator = false;
		/// <summary>
		/// CSS Adjacent Sibling Combinator (+) Style SelectorKey is created one of this childnodes.
		/// </summary>
		public bool ___HasCSSAdjacentSiblingCombinatorInChildren = false;

		/// <summary>
		/// full url for href
		/// </summary>
		public CHtmlUri ___hrefBase = null;

		/// <summary>
		/// full url for src
		/// </summary>
		public CHtmlUri ___srcBase = null;

		

		internal System.WeakReference ___firstChildWeakReference = null;





        public CHtmlElementDeclaredAttributeType ___KeyAttributes = CHtmlElementDeclaredAttributeType.TagOnly;


		/// <summary>
		/// Flag if the node is removeNode is called.
		/// </summary>
		
		public bool ___HasElementRemoved = false;


        /// <summary>
        /// if Svg Element child.
        /// </summary>
   
        public bool ___isSvgElement = false;


        /// <summary>
        /// Style ___hasInner copied from siblings
        /// </summary>
        public bool ___IsStyleCopiedFromIdenticalSibling = false;


		/// <summary>
		/// List of ChildElement which ___hasInner Z-Index non zero, default is null
		/// </summary>
		internal System.Collections.Generic.List<CHtmlElement>___ZIndexedChildElementList = null;

	
        /// <summary>
        /// isInactivativeElementNodeChild represents the child is child of documentFragment or Template tag child
        /// the element is not be processed
        /// </summary>
        internal bool ___isInactivativeElementNodeChild = false;

        /// <summary>
        /// Flag for CSS :last-num type of node.
        /// </summary>
        internal bool ___IsElementCSSQuickLookup = false;
        /// <summary>
        /// Base Image For Canvas 2D
        /// </summary>
        internal System.Drawing.Image ___CanvasGdiImage = null;
        internal SkiaSharp.SKBitmap ___CanvasSkiaBitmap = null;

        internal double ___CanvasGetContext = 0;

        /// <summary>
        /// Latest Canvas Type of getContext()
        /// </summary>
        public CanvasContextModeType ___ElementCanvasContextType = CanvasContextModeType.None;

        internal CHtmlCanvasContext2D ___canvasContextCurrent2D = null;
        internal CHtmlWebGLRenderingContext __canvasContextCurrentWebGL = null;
        internal CHtmlAudioContext  ___audioBasedContext = null;
        internal CHtmlCanvasContext2D  ___webGLRenderingContext = null;

        /// <summary>
        /// Weak Reference of current active Canvas context for this element
        /// </summary>
        internal System.WeakReference ___canvasContextActiveWeakReference = null;



        internal double[] ___framesetRowsParsedArray;

        internal double[] ___framesetColsParsedArray;

        public System.WeakReference ___ElementMouseUpFunctionWeakReference = null;
        public System.WeakReference ___ElementMouseDownFunctionWeakReference = null;
        public System.WeakReference ___ElementMouseMoveFunctionWeakReference = null;
        public System.WeakReference ___ElementMouseOutFunctionWeakReference = null;
        public System.WeakReference ___ElementMouseWheelFunctionWeakReference = null;
        public System.WeakReference ___ElementContextMenuFunctionWeakReference = null;
        public System.WeakReference ___ElementScrollFunctionWeakReference = null;
        public System.WeakReference ___ElementResizeFunctionWeakReference = null;
        public System.WeakReference ___ElementErrorFunctionWeakReference = null;
        public System.WeakReference ___ElementDblClickFunctionWeakReference = null;
        public System.WeakReference ___ElementMouseOverFunctionWeakReference = null;
        public System.WeakReference ___ElementMouseEnterFunctionWeakReference = null;
        public System.WeakReference ___ElementMouseLeaveFunctionWeakReference = null;
        public System.WeakReference ___ElementMouseHoverFunctionWeakReference = null;
        public System.WeakReference ___ElementKeyUpFunctionWeakReference = null;
        public System.WeakReference ___ElementKeyDownFunctionWeakReference = null;
        public System.WeakReference ___ElementKeyPressFunctionWeakReference = null;
        public System.WeakReference ___ElementSelectedIndexChangedFunctionWeakReference = null;
        public System.WeakReference ___ElementSelectedValueChangedFunctionWeakReference = null;
        public System.WeakReference ___ElementOnSelectFunctionWeakReference = null;
        public System.WeakReference ___ElementOnChangeFunctionWeakReference = null;
        public System.WeakReference ___ElementLoadFunctionWeakReference = null;
        public System.WeakReference ___ElementReadyStateChangeFunctionWeakReference = null;
        public System.WeakReference ___ElementUnloadFunctionWeakReference = null;
        public System.WeakReference ___ElementCanPlayThroughFunctionWeakReference = null;
        public System.WeakReference ___ElementCanPlayFunctionWeakReference = null;
        public System.WeakReference ___ElementProgressFunctionWeakReference = null;
        /// <summary>
        /// LoadData function For Video and Audio
        /// </summary>
        public System.WeakReference ___ElementLoadedDataFunctionWeakReference = null;
        public System.WeakReference ___ElementClickFunctionWeakReference = null;
        public System.WeakReference ___ElementDoubleClickFunctionWeakReference = null;

        /// <summary>
        /// Size of Rem Size of HTML Element
        /// default : -1
        /// </summary>
        internal double ___HTMLTagRemUnitSize = -1;


        /// <summary>
        /// Strong Reference for Element MultiversalWindow, for iframe, frame etc.
        /// </summary>
        public CHtmlMultiversalWindow? ___iframeMultiversalWindow = null;

        /// <summary>
        /// Element Multiversal WeakReference (Dynamic Elements Only)
        /// </summary>
        internal System.WeakReference ___MultiversalWindowWeakReference = null;

        /// <summary>
        /// Status For Image, audio, video download status
        /// </summary>
        internal CHtmlHttpResourceResultStatusType ___elementResourceDownloadStatus = CHtmlHttpResourceResultStatusType.NotYet;

        /// <summary>   
        /// TimeStamp when this element is drawn 
        /// for SVGElement, etc.
        /// </summary>
        internal System.DateTime ___elementDrawnTime;

		public CHtmlElement()
		{
            base.___multiversalClassType = IMutilversalObjectType.Element;
            base.___childNodes.___CollectionType = CHtmlHTMLCollectionType.ElementChildNodes;
            base.___childNodes.___parentNode = this;
            this.___elementDrawnTime = DateTime.MinValue;
			this.___hrefBase = new CHtmlUri();
			this.___hrefBase.___DisableLocationAnalyzation = false;
            this.___hrefBase.___OriginatingElementReference = new WeakReference(this, false);
			this.___srcBase = new CHtmlUri();
			this.___srcBase.___DisableLocationAnalyzation = false;
            this.___srcBase.___OriginatingElementReference = new WeakReference(this, false);
            this.___locationBase.___DisableLocationAnalyzation = true;
            this.___locationBase.___DisableHrefNavigate = true;

			this.___TagOpenStartPosition = -1;
			this.___TagOpenEndPosition = -1;
			this.___TagCloseStartPosition = -1;
			this.___TagCloseEndPosition = -1;

			//this._children.ChildrenAdded +=new EventHandler(children_ChildrenAdded);
			this.___attributes =new  CHtmlAttributeList(StringComparer.OrdinalIgnoreCase); // must be case insensitive for dataset access
            this.___attributes.CollectionType = CHtmlHTMLCollectionType.ElementAttributes;
            this.___attributes.___ownerNodeWeakReference = new WeakReference(this, false);


			this.___cssFloatLeftElementList   = new CHtmlFloatList(CHtmlFloatType.Left);
			this.___cssFloatRightElementList  = new CHtmlFloatList(CHtmlFloatType.Right);
            this.___cssFloatLeftDoneList = new ArrayList();
            this.___cssFloatRightDoneList = new ArrayList();
			
			//this._textNodes = new CHtmlCollection();
            this.___drawingObjectList = new System.Collections.Generic.List<CHtmlDrawingObject>();
                           
            this.___mustInheritAttributeList = new System.Collections.Generic.Dictionary<CSSAttributeType, string>();

	
			this.___style = new CHtmlCSSStyleSheet(CHtmlElementStyleType.Element);
            this.___style.___ownerElementWeakReference = new WeakReference(this, false);
           
			//this.___styleActive = new CHtmlCSSStyleSheet();
			//this.___styleActive.StyleType = CHtmlElementStyleType.Active;
			//this.___styleActive.ownerElement = this;
			this.___styleHover = new CHtmlCSSStyleSheet(CHtmlElementStyleType.Hover);

            this.___styleHover.___ownerElementWeakReference = new WeakReference(this, false);
			this.___dataset =new CHtmlElementDataSet();
			this.___dataset.parentNode = this;
			this.___SetNodeType(CHtmlNodeType.ELEMENT_NODE);
			this.___cssFloatTopPostionList = new CHtmlNumberList(10);
			this.___ParentInlineTextLookedupedList = new CHtmlCollection();
			this.___ParentInlineTextLookedupedList.___CollectionType = CHtmlHTMLCollectionType.TextElementParentLookedupedList;
			// ********************************************************************************************
			// All Elements ___hasInner ___stylesheetsForCurrentNodeList and ___stylesheetsForNextNodeList at begin
			// ********************************************************************************************
            this.___stylesheetsForCurrentNodeList = new System.Collections.Generic.List<CHtmlCSSRule>();
            this.___stylesheetsForNextNodeList = new System.Collections.Generic.List<CHtmlCSSRule>();
			// ********************************************************************************************

		}
		~CHtmlElement()
		{
            base.___IsDisposing = true;
			this.CleanUp();
		}


		public string ___AAA
		{
			get{return this.toLogString();}
		}
		public CHtmlElementAlignType NodeAlignType
		{
			get{return this.___nodeAlignType;}
			set{this.___nodeAlignType = value;}
		}
		public CHtmlElementAlignType NodeInheritedAlignType
		{
			get{return this.___nodeInheritedAlignType;}
			set{this.___nodeInheritedAlignType = value;}
		}
		
		public CHtmlElement createDocumentFragment()
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 7)
            {
               commonLog.LogEntry("{0}.createDocumentFragment() is called....", this);
            }
            CHtmlElement fragElement = new CHtmlElement();
            fragElement.___SetTagNameOnly("#DOCUMENT-FRAGMENT");
			fragElement.___SetNodeType(CHtmlNodeType.DOCUMENT_FRAGMENT_NODE);
            fragElement.___elementTagType = CHtmlElementType._DOCUMENT_FRAGMENT;
			fragElement.___IsDynamicElement = true;
            fragElement.___parentWeakRef = new WeakReference(this, false);
            if (this.___documentWeakRef != null)
            {
                fragElement.___documentWeakRef = new WeakReference(this.___documentWeakRef.Target, false); // DocuemntFramgMent ownerDocument should be same same as root Document
            }
            fragElement.___isInactivativeElementNodeChild = true;
			return fragElement;
		}


		public CHtmlElement createElement(string __name)
		{
			CHtmlElement newElement = null;
            CHtmlDocument ___ownerDocument = null;
            if (this.___documentWeakRef != null)
            {
                ___ownerDocument = this.___documentWeakRef.Target as CHtmlDocument;
            }
            if (___ownerDocument != null)
            {
                newElement = ___ownerDocument.createElementInner("", __name);
                newElement.___IsDynamicElement = true;
            }
            else
            {
                
          
                System.Collections.SortedList __srAttributes = CHtmlDocument.___CreateElementTagNameAndAttributeList(__name);
                if (__srAttributes.ContainsKey("tagname"))
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 7)
                    {
                       commonLog.LogEntry("TODO:  {0} acessing slow createElement() with slow functions.... replaceit", this, __name);
                    }
                    string sTagName = __srAttributes["tagname"] as string;
                    if (___ownerDocument != null)
                    {
                        newElement = CHtmlDocument.createCHtmlElementWithDomType(commonHTML.FasterToUpper(sTagName), ___ownerDocument.___documentDomType, null);
                    }else
                    {
                        newElement = CHtmlDocument.createCHtmlElementWithDomType(commonHTML.FasterToUpper(sTagName), CHtmlDomModeType.HTMLDOM, null);
                    }
                }
                if (newElement.___elementTagType == CHtmlElementType.STYLE || newElement.___elementTagType == CHtmlElementType.LINK)
                {
                    CHtmlCSSStyleSheet.___createCHtmlCSSStylesheetForElement(newElement);
                }

                //newElement.___elementTagType = commonGetTagNameType(newElement.tagName);
                newElement.___IsDynamicElement = true;
                if (___ownerDocument != null)
                {
                    newElement.___documentWeakRef = new WeakReference(___ownerDocument, false);
                }
            
                if (__srAttributes != null)
                {
                	int __srAttributesCount = __srAttributes.Count;
                    for (int i = 0; i < __srAttributesCount; i++)
                    {
                        string sKey = __srAttributes.GetKey(i) as string;

                        // ___srAttributesList does contains tagname. skip it.
                        if (string.Equals(sKey, "tagname", StringComparison.OrdinalIgnoreCase) == true)
                            continue;
                        CHtmlAttribute attr = new CHtmlAttribute();
                        attr.name = string.Copy(sKey);
                        attr.setParentNode(newElement);
                        attr.value = string.Copy(__srAttributes[sKey] as string);
                        newElement.___attributes[sKey] = attr;
                    }
                }
			}
            if (___ownerDocument != null)
            {
                if (___ownerDocument.___IsDomModeFullParseMode() == true)
                {
                    if (___ownerDocument.___ElementImgAudioVideoDynamicallyCreatedWorkingQueueList != null)
                    {
                        switch (newElement.___elementTagType)
                        {
                            case CHtmlElementType.IMG:
                            case CHtmlElementType.AUDIO:
                            case CHtmlElementType.VIDEO:
                                this.___Document.___ElementImgAudioVideoDynamicallyCreatedWorkingQueueList.Add(new WeakReference(newElement, false));
                                break;
                        }
                    }
                }
            }
            newElement.___parentWeakRef = new WeakReference(this, false);
			newElement.___WillElementIDAlternationRequiresDocumentCheck = true;
			return newElement;
		}

        /// <summary>
        /// Checks if ChildNodes Contains Seek Element Recursively
        /// </summary>
        /// <param name="___seekElement"></param>
        /// <param name="StackDepth"></param>
        /// <returns></returns>
        internal bool ___IsContainsElementWithinChildNodesRecursively(CHtmlElement ___seekElement, ref int StackDepth)
        {
            if (StackDepth >= commonHTML.ELEMENT_CONTAINS_SEARCH_LOOKUP_STACK_LIMIT)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 7)
                {
                   commonLog.LogEntry(" {0}.contains({1}) will performing recurse lookup Abort", this, ___seekElement);
                }
                return false;
            }
            for (int i = this.___childNodes.Count - 1; i >= 0; i--)
            {
                CHtmlElement ___childNode = this.___childNodes[i] as CHtmlElement;
                if (___childNode != null)
                {
                    if (object.ReferenceEquals(___childNode, ___seekElement) == true)
                    {
                        return true;
                    }
                    else
                    {
                        if (___childNode.___childNodes.Count > 0)
                        {
                            StackDepth++;
                            if (___childNode.___IsContainsElementWithinChildNodesRecursively(___seekElement,ref StackDepth))
                            {
                                return true;
                            }
                            else
                            {
                                StackDepth--;
                                continue;
                            }
                        }
                    }
                }
            }
            return false;
        }
		/// <summary>
		/// Read Only Property for tagName
		/// </summary>
        public string nodeName
        {
            get
            {
                switch (this.___elementTagType)
                {
                    case CHtmlElementType._DOCUMENT_FRAGMENT:
                        return "#document-fragment";
                    case CHtmlElementType._ITEXT:
                        return "#text";
                    case CHtmlElementType._IDRAW:
                        return "#text";
                    default:
                        return base.___tagName;
                }
            }
        }
        public  new string name
        {
            get { return base.name; }
            set { 
                base.name = value;
                if (this.___elementTagType == CHtmlElementType.IFRAME || this.___elementTagType == CHtmlElementType.FRAME)
                {
                    this.___setIFrameNameIfExists();
                }
            }
        }

        /// <summary>
        /// Set/check Iframe name if child Multiversal object exists.
        /// Note) Some Scripts Dynamically assign iframe name by scripts.
        /// 
        /// </summary>
        private void ___setIFrameNameIfExists()
        {
            if (this.___elementTagType == CHtmlElementType.IFRAME)
            {
                if (this.___iframeMultiversalWindow != null)
                {
                    if (string.Equals(this.___iframeMultiversalWindow.___name, base.___name, StringComparison.Ordinal) == false)
                    {
                        ___iframeMultiversalWindow.___name = string.Copy(base.___name);
                    }
                }
            }
        }
		
		internal bool ___IsElementContainsChildElement(CHtmlElement __targetElement, ref int __Depth)
		{
			if(__Depth >= 50)
			{
				return false;
			}
			try
			{
				int ___childNodesCount = this.___childNodes.Count;
				for(int i = 0; i < ___childNodesCount; i ++)
				{
					CHtmlElement __child = this.___childNodes[i] as CHtmlElement;
					if(__child == null)
						continue;
					if(object.ReferenceEquals(__child,  __targetElement) == true)
					{
						return true;
					}
					else if(___childNodesCount > 0)
					{
						__Depth ++;
						bool childResult = __child.___IsElementContainsChildElement(__targetElement, ref __Depth);
						__Depth --;
						if(childResult == true)
						{
							return true;
						}
						else
						{
							continue;
						}
					}
				}
			}
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
				{
					commonLog.LogEntry("IsElementContainsChildElement", ex);
				}
			}
			return false;
		}




        /// <summary>
        /// Get Element Hosting Managed Control From Element Weak Reference
        /// </summary>
        /// <returns>Weak Reference Target Object</returns>
        public object getElementManagedControlFromWeakReference()
        {
            if (this.___ManagedControlWeakReference != null)
            {
                return this.___ManagedControlWeakReference.Target;
            }
            return null;
        }



		
		private void CleanUp()
		{
            if (this.___ManagedControlWeakReference != null)
            {
                this.___ManagedControlWeakReference = null;
            }
            if (this.___iframeMultiversalWindow != null)
            {
                try
                {
                    if (this.___iframeMultiversalWindow.___document != null)
                    {
                        try
                        {
                            this.___iframeMultiversalWindow.___document.Dispose();
                        }
                        catch (Exception exIFrameDocEx)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel > 10)
                            {
                               commonLog.LogEntry("CleanUp IFrame Window Document Disponse Exception", exIFrameDocEx);
                            }
                        }
                    }
                    this.___iframeMultiversalWindow.___document = null;
                    this.___iframeMultiversalWindow.Dispose();
                }
                catch (Exception exIFrameWindow)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel > 10)
                    {
                       commonLog.LogEntry("CleanUp IFrame Window Disponse Exception", exIFrameWindow);
                    }
                }
                this.___iframeMultiversalWindow = null;
            }
            if(this.___canvasContextActiveWeakReference != null)
            {
                ___canvasContextActiveWeakReference = null;
            }
            if (this.___canvasContextCurrent2D != null)
            {
                try
                {
                    this.___canvasContextCurrent2D.Dispose();
                   
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel > 10)
                    {
                       commonLog.LogEntry("CleanUp Canvas Context error",ex);
                    }

                }
                this.___canvasContextCurrent2D = null;
            }
            if(this.___childNodesQuickList != null)
            {
                this.___childNodesQuickList = null;
            }

			if(this.___previousInnerText != null)
			{
				this.___previousInnerText = null;
			}
			if(this.___MediaQueryNode != null)
			{
				this.___MediaQueryNode = null;
			}
			if(this.___ParentInlineTextLookedupedList != null)
			{
				this.___ParentInlineTextLookedupedList = null;
			}
			if(this.___InlineVeryTopTextElement != null)
			{
				this.___InlineVeryTopTextElement = null;
			}
			if(this.___InlineLastTextElement != null)
			{
				this.___InlineLastTextElement = null;
			}
			if(this.___ZIndexedChildElementList != null)
			{
				this.___ZIndexedChildElementList = null;
			}
            if (this.___FormElementCacheList != null)
            {
                this.___FormElementCacheList = null;
            }


			if(this.___dataset != null)
			{
				this.___dataset = null;
			}

            if (this.___style != null)
            {
                this.___style.___ownerElementWeakReference = null;
                this.___style.___documentWeakReference = null;
                this.___style = null;
            }
			if(this.___styleActive != null)
			{
                this.___styleActive.___ownerElementWeakReference = null;
                this.___styleActive.___documentWeakReference = null;
				this.___styleActive = null;
			}
            if (this.___styleHover != null)
            {
                this.___styleHover.___ownerElementWeakReference = null;
                this.___styleHover.___documentWeakReference = null;
                this.___styleHover = null;
            }
            if (this.___ElementAfter != null)
            {
                this.___ElementAfter.Dispose();
                this.___ElementAfter = null;
            }
            if (this.___ElementBefore != null)
            {
                this.___ElementBefore.Dispose();
                this.___ElementBefore = null;
            }
			

			if(this.___parentBlockElement != null)
			{
				this.___parentBlockElement = null;
			}

			if(this.___ManagedControlHandle != IntPtr.Zero)
			{
				this.___ManagedControlHandle = IntPtr.Zero;
			}
			if(this.___firstChildWeakReference != null)
			{
				this.___firstChildWeakReference = null;
			}

			if(this.___cssFloatRightElementList != null)
			{
				this.___cssFloatRightElementList.IsCleanUp = true;

				this.___cssFloatRightElementList = null;
			}
			if(this.___cssFloatLeftElementList != null)
			{
				this.___cssFloatLeftElementList.IsCleanUp = true;
				this.___cssFloatLeftElementList = null;
			}
            if (this.___cssFloatLeftDoneList != null)
            {
                this.___cssFloatLeftDoneList = null;
            }
            if (this.___cssFloatRightDoneList != null)
            {
                this.___cssFloatRightDoneList = null;
            }
			if(this.___cssFloatTopPostionList != null)
			{
				this.___cssFloatTopPostionList = null;
			}

		
			if(this.___stylesheetsForNextNodeList != null)
			{
				this.___stylesheetsForNextNodeList = null;
			}
			if(this.___drawingObjectList != null)
			{
				this.___drawingObjectList = null;
			}

            if (this.___CanvasGdiImage != null)
            {
                try
                {
                    this.___CanvasGdiImage.Dispose();
                    this.___CanvasGdiImage = null;
                }
                catch { }
                this.___CanvasGdiImage = null;
            }
			if(this.___attributes != null)
			{
            
                this.___attributes = null;
			}

		
			


			if(this.___tableCells != null)
			{
				this.___tableCells = null;
			}
			if(this.___tableRows != null)
			{
				this.___tableRows = null;
			}
			if(this.___ownerTableElement != null)
			{
				this.___ownerTableElement = null;
			}
            if (this.___documentWeakRef != null)
            {
                this.___documentWeakRef = null;
            }


			if(this.___stylesheetsForCurrentNodeList != null)
			{
		
				this.___stylesheetsForCurrentNodeList = null;
			}
            if (this.___imageDownloadtemporarily != null)
            {
                this.___imageDownloadtemporarily.Dispose();
                this.___imageDownloadtemporarily = null;
            }
            if (this.___sheet != null)
            {
                this.___sheet = null;
            }
			if(this.___srcBase != null)
			{
				this.___srcBase  = null;
			}
			if(this.___hrefBase != null)
			{
				this.___hrefBase  = null;
			}

		}
		public new void Dispose()
		{
            base.___IsDisposing = true;
			this.CleanUp();
			base.Dispose();
			GC.SuppressFinalize(this);
		}


        public double clientWidth
        {
            set { this.___offsetWidth = value; }
            get
            {
                if (this.___offsetWidth > 0 )
                {
                    return this.___offsetWidth;
                }
                else
                {
                    if (this.___elementTagType != CHtmlElementType.HTML && this.___elementTagType != CHtmlElementType.BODY)
                    {
                        return this.___offsetWidth;
                    }
                    else
                    {
                        if (this.___documentWeakRef != null)
                        {
                            CHtmlDocument ___ownerDoc = this.___documentWeakRef.Target as CHtmlDocument;
                            if (___ownerDoc != null && ___ownerDoc.parentWindow != null)
                            {
                                CHtmlMultiversalWindow ___multiWindow = ___ownerDoc.parentWindow  as CHtmlMultiversalWindow;
                                if (___multiWindow != null)
                                {
                                    return ___multiWindow.___getinnerWidth();
                                }
                            }

                        }
                    }

                }
                return 1200;


            }
        }
        public double clientHeight
        {
            set { this.___offsetHeight = value; }
            get
            {
                if (this.___offsetHeight > 0)
                {
                    return this.___offsetHeight;
                }
                else
                {
                    if (this.___elementTagType != CHtmlElementType.HTML && this.___elementTagType != CHtmlElementType.BODY)
                    {
                        return this.___offsetWidth;
                    }
                    else
                    {
                        if (this.___documentWeakRef != null)
                        {
                            CHtmlDocument ___ownerDoc = this.___documentWeakRef.Target as CHtmlDocument;
                            if (___ownerDoc != null)
                            {
                                CHtmlMultiversalWindow ___multiWindow = ___ownerDoc.___window as CHtmlMultiversalWindow;
                                if (___multiWindow != null)
                                {
                                    return ___multiWindow.___getinnerHeight();
                                }
                            }

                        }
                    }


                }
                return 1000;
            }
        }
        public double clientTop
        {
            set { this.___offsetTop = value; }
            get { return this.___offsetTop; }
        }
        public double clientLeft
        {
            set { this.___offsetLeft = value; }
            get { return this.___offsetLeft; }
        }




       		/// <summary>
		/// offsetWidth Retrieves the width of the object relative to the layout or coordinate parent, as specified by the IHTMLElement::offsetParent property. 		
		/// </summary>
		public double  offsetWidth
		{
			set
			{
				this.___offsetWidth = value;
				// Width Does not effect child corner point , so do not reset
				//ResetScreenBounds();
			}
			get{return this.___offsetWidth;}
		}


		/// <summary>
		/// offsetLeft Retrieves the calculated left position of the object relative to the layout or coordinate parent, as specified by the IHTMLElement::offsetParent property. 
		/// </summary>
		public double offsetLeft
		{
			set
			{
				this.___offsetLeft = value;
				//ResetScreenBounds(true,false);
			}
			get{return this.___offsetLeft;}
		}

		/// <summary>
		/// offsetTop Retrieves the calculated top position of the object relative to the layout or coordinate parent, as specified by the IHTMLElement::offsetParent property.  
		/// </summary>
		public double offsetTop
		{
			set
			{
				this.___offsetTop = value;
				//ResetScreenBounds(true, false);
			}
			get{return this.___offsetTop;}
		}
		/// <summary>
		/// offsetHeight Retrieves the height of the object relative to the layout or coordinate parent, as specified by the IHTMLElement::offsetParent property.  
		/// </summary>
		public double offsetHeight
		{
			set
			{
				this.___offsetHeight = value;
				// Width Does not effect child corner point , so do not reset
				//ResetScreenBounds();
			}
			get{return this.___offsetHeight;}
		}
		public double  availWidth
		{
			set{this.___availWidth = value;}
			get{return this.___availWidth;}
		}
		public double  availHeight
		{
			set{this.___availHeight = value;}
			get{return this.___availHeight;}
		}
		public double  availLeft
		{
			set{this.___availLeft = value;}
			get{return this.___availLeft;}
		}
		public double  availTop
		{
			set{this.___availTop = value;}
			get{return this.___availTop;}
		}

        public double  paddingLeft
		{
			set{this.___paddingLeft = value;}
			get{return this.___paddingLeft;}
		}
		public double  paddingRight
		{
			set{this.___paddingRight = value;}
			get{return this.___paddingRight;}
		}
		public double paddingTop
		{
			set{this.___paddingTop = value;}
			get{return this.___paddingTop;}
		}
		public double paddingBottom
		{
			set{this.___paddingBottom = value;}
			get{return this.___paddingBottom;}
		}
		public double leftMargin
		{
			set{this.___marginLeft = value;}
			get{return this.___marginLeft;}
		}
		public double marginLeft
		{
			set{this.___marginLeft = value;}
			get{return this.___marginLeft;}
		}
		public double marginRight
		{
			set{this.___marginRight = value;}
			get{return this.___marginRight;}
		}
		public double rightMargin
		{
			set{this.___marginRight = value;}
			get{return this.___marginRight;}
		}
		public double marginTop
		{
			set{this.___marginTop = value;}
			get{return this.___marginTop;}
		}
		public double marginBottom
		{
			set{this.___marginBottom = value;}
			get{return this.___marginBottom;}
		}
		public double bottomMargin
		{
			set{this.___marginBottom = value;}
			get{return this.___marginBottom;}
		}
		public double minHeight
		{
			set{this.___minHeight = value;}
			get{return this.___minHeight;}
		}
		public double minWidth
		{
			set{this.___minWidth = value;}
			get{return this.___minWidth;}
		}
		public double maxWidth
		{
			set{this.___maxWidth = value;}
			get{return this.___maxWidth;}
		}
		public double maxHeight
		{
			set{this.___maxHeight = value;}
			get{return this.___maxHeight;}
		}

        /// <summary>
        /// Non Standard offestRight
        /// </summary>
        public double offsetRight_CMZ
        {
            set { this.___offsetRight = value; }
            get { return this.___offsetRight; }
        }
        /// <summary>
        /// Non Standard offsetBottom
        /// </summary>
        public double offsetBottom_CMZ
        {
            set { this.___offsetBottom = value; }
            get { return this.___offsetBottom; }
        }
        /*
		publicCHtmlFontInfo FontInfo
		{
			set{this._FontInfo = value;}
			___getInner{return this._FontInfo;}
		}
		*/
		public RectangleSpec clientRectangle
		{
			get
			{
				return commonHTML.RectangleFToRectangle(this.___offsetScreenBounds);
			}
		}
        /// <summary>
        /// itemScope is MicroData specification. on Firefox it is boolean.
        /// Chrome and IE returns undefind. We Follow Firefox data type.
        /// </summary>
        public bool itemScope
        {
            set {
                if (value == true)
                {
                    this.SetGetAttributesByName("itemscope", value, true);
                }
                else
                {
                    this.___attributes.Remove("itemscope");
                }
            }
            get
            {
                try
                {
                    object objBool = this.SetGetAttributesByName("itemscope", null, false);
                    if (objBool != null)
                    {
                        return commonData.convertObjectToBoolean(objBool);
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
                return false;
            }
        }
		/// <summary>
		/// Retrieves a node based on its index within the document tree. IE4+ and FireFox1+.
		/// </summary>
		/// <param name="___index"></param>
		/// <returns></returns>
		
		public CHtmlElement item(int ___index)
		{
			if(___index >= 0&& ___index < this.___childNodes.Count)
			{
				return this.___childNodes[___index] as CHtmlElement;
			}
			return null;
		}
        public CHtmlElement firstElementChild
        {
            get
            {
                if(this.___childNodes.Count > 0)
                {
                    var firstChild = this.___childNodes[0] as CHtmlElement;
                    if(firstChild != null)
                    {
                        return firstChild;
                    }
             
                }
                return null;
            }
        }
		
		public bool hasAttributes()
		{
			if(this.___attributes != null && this.___attributes.Count > 0)
			{
				return true;
			}
			return false;
		}
		
		public bool hasAttribute(string _sName)
		{
            if (string.IsNullOrEmpty(_sName) == true)
            {
                return false;
            }
			if(this.___attributes.ContainsKey(_sName) == true)
			{
				return true;
			}
            if (___properties.ContainsKey(_sName) == true)
            {
                return true;
            }
			return false;
		}
        public string validationMessage
        {
            get {return "required"; }
        }
        /// <summary>
        /// Create TextRange for this Element Node
        /// </summary>
        /// <returns>Range</returns>
        public CHtmlRange createTextRange()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel > 5)
            {
               commonLog.LogEntry("entering {0}.createTextRange()...", this);
            }
            CHtmlRange ___elementRange = new CHtmlRange();
            ___elementRange.___rangeType = CHtmlRange.RangeType.Element;
            ___elementRange.___ownerElementWeakReference = new WeakReference(this, false);
            return ___elementRange;
        }
		/// <summary>
		/// Returns a Boolean true if the current node supports (i.e., conforms to the required specifications of) a stated W3C DOM module and version. While the document.implementation object's hasFeature( ) method performs the same test, it does so on the entire browser application. The isSupported( ) method performs the test on an individual node, allowing you to verify feature support for the current node type. Parameter values for isSupported( ) are the same as for document.implementation.hasFeature( ).
        /// Firefox ___hasInner droped this feature. 
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <returns>always true</returns>
		
		public bool isSupported(object ___p1, object ___p2)
		{
            return true;
		}
   
        public bool isSupported(object ___p1)
        {
            return true;
        }
		/// <summary>
		/// Chrome implmementation
		/// </summary>
		/// <param name="__elem"></param>
		/// <returns></returns>
		
        public bool isEqualNode(object ___obj)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.isEqualNode(\'{1}\'}\')", this, ___obj);
            }
            if (___obj == null)
                return false;
            return object.Equals(this, ___obj);
        }

        /// <summary>
        /// CHtmlElement.getAttribute() returns object by attribute name.
        /// </summary>
        /// <param name="__attrName"></param>
        /// <returns></returns>
        public object getAttribute(string __attrName)
		{
            object ___objReturn = null;
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("calling {0} {1}.___getPropertyByName(({2})", this.GetType().FullName.ToLower(), this.toLogString(), __attrName);
                }
                ___objReturn = this.___getPropertyByName(__attrName);
                if (___objReturn != null)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                    {
                        commonLog.LogEntry($"{this.toLogString()}.___getPropertyByName({__attrName}) sucess returning : {___objReturn}");
                    }
                    ___getAttributeFinalReturnValueCheck(__attrName, ___objReturn);
                }
            } finally
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry($"{this.toLogString ()}.___getPropertyByName({__attrName}) returning : {___objReturn}");
                }
            }
            return ___objReturn;

		}
        /// <summary>
        /// ____getAttributeFinalReturnValueCheck() will performs final value check for Element.getAttribute() function.
        /// Because getAttribute() normally returns null if attribute is not assigned property.
        /// </summary>
        /// <param name="__attrName"></param>
        /// <param name="___returnValue"></param>
        /// <returns></returns>
        public static object ___getAttributeFinalReturnValueCheck(string __attrName, object ___returnValue)
        {
            if (___returnValue is string)
            {
                string strValue = ___returnValue as string;
                if (string.IsNullOrEmpty(strValue) == true)
                {
                    return null;
                }
            }

            return ___returnValue;
        }
		/// <summary>
		/// 0		Default. Performs a property search that is not case-sensitive, and returns an interpolated value if the property is found.
		/// 1		Performs a case-sensitive property search. To find a match, the uppercase and lowercase letters in strAttributeName
		///         must exactly match those in the attribute name.
		/// 2   	Returns attribute value as a String. This flag does not work for event properties.
		/// 4		Returns attribute value as a fully expanded URL. Only works for URL attributes.
		/// </summary>
		/// <param name="__attrName"></param>
		/// <param name="paramInt1"></param>
		/// <returns></returns>
		
		public object getAttribute(string __attrName, int  paramInt1)
		{

            object ___oReturn = this.___getPropertyByName(__attrName);
			
			if(paramInt1 == 2)
			{
				// 2: String Value
				return commonHTML.GetStringValue(___oReturn);
			}
			else if(paramInt1 == 4)
			{   // okay it expects Full Url is possible
                switch (__attrName)
				{
					case "href":
					case "src":
					case "url":
                        if (___oReturn == null)
                        {
                            return null;
                        }
						string ___attrValue = commonHTML.GetStringValue(___oReturn);
						if( ___attrValue.Length != 0)
						{
							if(this.___Document != null)
							{
								return commonHTML.GetAbsoluteUri(this.___Document.___URL, this.___Document.___baseUrl,  ___attrValue);
							}
						}
						break;
					default:
						break;
				}

			}
            return ___getAttributeFinalReturnValueCheck(__attrName, ___oReturn);
		}
        /// <summary>
        /// Seaches Attribute value 
        /// </summary>
        /// <param name="__attrName">attribute name</param>
        /// <param name="b">case sensitive(this not work)</param>
        /// <returns>attribute value</returns>
		
		public object getAttribute(string __attrName, bool b)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.getAttribute({1})", this, __attrName);
            }
            object objReturn =  this.___getPropertyByName(__attrName);
            if (objReturn != null)
            {
                return ___getAttributeFinalReturnValueCheck(__attrName, objReturn);
            }
            else
            {
                return null;
            }

            

		}
        /// <summary>
        /// Seaches Attribute value 
        /// </summary>
        /// <param name="__NameSpace">NameSpace of Attribute</param>
        /// <param name="__Name">attribute name</param>
        /// <returns>attribute value</returns>
   
        public object getAttributeNS(string __NameSpace, string __Name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.getAttributeNS({1}, {2})", this, __NameSpace, __Name);
            }
            return this.___getPropertyByName(string.Concat(__NameSpace, ':', __Name));
        }
    
        public bool hasAttributeNS(string __NameSpace, string __Name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.hasAttributeNS({1}, {2})", this, __NameSpace, __Name);
            }
            return this.___hasPropertyByName((string.Concat(__NameSpace, ':', __Name)));
        }
    
         public void setAttributeNS(string __NameSpace, string __Name, object __value)
         {
             this.setAttributeInner(__Name, __value, 0);
 
         }
         public void removeAttributeNS(string __NameSpace, string __Name)
         {
             if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
             {
                commonLog.LogEntry("calling {0}.removeAttributeNS({1}, {2})", this, __NameSpace, __Name);
             }
             this.removeAttribute(string.Concat(__NameSpace, ':', __Name));
         }

		/// <summary>
		/// Return Value must be primitive value
		/// </summary>
		/// <param name="__attrName"></param>
		/// <param name="__CaseSensitive"></param>
		/// <returns></returns>
         [System.Obsolete("use ___getPropertyValueByName()")]
         private object getAttributeInner(string __attrName, bool __CaseSensitive, string ___NameSpace)
         {
             if (string.IsNullOrEmpty(__attrName) == true)
             {
                 return null;
             }
             
             
             switch (__attrName)
             {
                 case "class":
                 case "classname":
                 case "className":
                     if (string.IsNullOrEmpty(base.___class) == false)
                     {
                         return base.___class;
                     }
                     else
                     {
                         return null;
                     }
                 case "id":
                 case "Id":
                 case "ID":
                     if (string.IsNullOrEmpty(base.___id) == false)
                     {
                         return base.___id;
                     }
                     else
                     {
                         return null;
                     }
                 case "name":
                     if (string.IsNullOrEmpty(base.___name) == false)
                     {
                         return base.___name;
                     }
                     else
                     {
                         return null;
                     }
                 case "tagName":
                 case "tagname":
                     if (string.IsNullOrEmpty(base.___tagName) == false)
                     {
                         return commonHTML.___convertNullToEmpty(base.___tagName);
                     }
                     else
                     {
                         return null;
                     }
             }
             CHtmlAttribute attr = null;
             
             if (this.___attributes.TryGetValue(__attrName, out attr) == true)
             {
                 if (attr != null)
                 {
                     return attr.value;
                 }
             }
             if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
             {
                commonLog.LogEntry("calling {0}.getAttributeInner({1}) failed...", this, __attrName);
             }
             return null;
         }
		public CHtmlAttribute getAttributeNode(string _sName)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.getAttributeNode({1})", this, _sName);
            }
        
            if (string.IsNullOrEmpty(_sName) == false)
            {
                CHtmlAttribute ___attr = null;
                if (this.___attributes.Count > 0 && this.___attributes.TryGetValue(_sName, out  ___attr) == true)
                {
                    if (___attr != null)
                    {
                        return ___attr;
                    }
                }
                switch (_sName)
                {
                    case "class":
                    case "className":
                    case "classname":
                        if (string.IsNullOrEmpty(base.___class) == false)
                        {
                            return ___getClassNameAttribute();
                        }
                        break;

                }
            }


            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.getAttributeNode({1}) ___hasInner failed", this, _sName);
            }
            return null;
		}
        /// <summary>
        /// Returns class Attribute Node
        /// </summary>
        /// <returns></returns>
        private CHtmlAttribute ___getClassNameAttribute()
        {
            CHtmlAttribute ___classAttr = null;
            if (this.___attributes.TryGetValue("class", out ___classAttr) == true)
            {
                return ___classAttr;
            }
            if (this.___attributes.TryGetValue("classname", out ___classAttr) == true)
            {
                return ___classAttr;
            }
            return null;

        }
		public void setAttributeNode(CHtmlAttribute newAttribute)
		{
            
            this.___attributes[newAttribute.name] = newAttribute;
            this.___setPropertyByName(newAttribute.name, newAttribute.___value);
		}
		public void removeAttributeNode(CHtmlAttribute _oAttribute)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.removeAttributeNode({1})", this, _oAttribute);
            }
			if(_oAttribute !=null)
			{
                if (string.IsNullOrEmpty(_oAttribute.name) == false)
                {
                    this.___attributes.Remove(_oAttribute.name);
                }
			}
		}
		public void removeAttribute(string ___Name)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.removeAttribute({1})", this, ___Name);
            }
			if(string.IsNullOrEmpty(___Name) == false)
			{
				try
				{
					this.___attributes.Remove(___Name);
				}
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
			}
		}

		public object this[string sKey]
		{
			get
			{
				if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
				{
				   commonLog.LogEntry("entering CHtmlElement ___hasInner accessed by indexer \"{0}\" sKey=\"{1}\"", this, sKey);
				}
				object result = null;
				try
				{
					result = this.getAttribute(sKey);
				}
				catch (Exception ex)
				{
					if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
					{
					   commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
					}
				}
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("CHtmlElement ___hasInner accessed by indexer \"{0}\" sKey=\"{1}\"= {2}", this, sKey, result);
				}
				return result;
			}
			set
			{
				if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
				{
				   commonLog.LogEntry("TODO : CHtmlElement ___hasInner accessed by indexer \"{0}\" sKey=\"{1}\"= {2}", this, sKey, value);
				}

			}
		}
        /// <summary>
        /// Element[int] returns null on chrome and ie always.
        /// </summary>
        /// <param name="intKey"></param>
        /// <returns></returns>
		public object this[int intKey]
		{
			get
			{
                object result = null;

				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
                   commonLog.LogEntry("CHtmlElement ___hasInner accessed by indexer \"{0}\" {1}= {2}", this, intKey, result);
				}
				return result;
			}
			set
			{
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("CHtmlElement ___hasInner set indexer \"{0}\" {1}= {2}", this, intKey, value);
                }
				
			}
		}
		/// <summary>
		/// DHTML setAttribute
		/// </summary>
		/// <param name="__attrName"></param>
		/// <param name="__attrValue"></param>
		
		public void setAttribute(string __attrName, object __attrValue)
		{
			this.setAttributeInner(__attrName,  __attrValue, 0);

		}
		
		public void setAttribute(string __attrName, object __attrValue, double __flag)
		{
			this.setAttributeInner(__attrName,  __attrValue, __flag);

		}
		
		public void setAttribute(string __attrName, object __attrValue, object __flag)
		{
			this.setAttributeInner(__attrName,  __attrValue, 0);

		}
        public void setAttribute(object __attrNameObject, object __attrValue, object ___objFlag)
        {
            this.setAttributeInner(commonHTML.GetStringValue(__attrNameObject), __attrValue, 0);
        }
        public void setAttribute(object __attrNameObject, object __attrValue)
        {
            this.setAttributeInner(commonHTML.GetStringValue(__attrNameObject), __attrValue, 0);
        }

		/// <summary>
		/// DHTML setAttribute
		/// </summary>
		/// <param name="__attrName"></param>
		/// <param name="__attrValue"></param>
		/// <param name="_flag"></param>
		
		private void setAttributeInner(string __attrName, object __attrValue, double _flag)
		{
            try
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("calling {0}.setAttributeInner({1}, {2}) ", this, __attrName, __attrValue);
                }
                if (string.IsNullOrEmpty(__attrName) == false)
                {
                    __attrName = commonHTML.FasterToLower(__attrName);
                }
                CHtmlAttribute nAttr = null;
                CHtmlAttribute attrExisting = null;
                bool IsValueFound = false;
                if (this.___attributes.Count > 0)
                {
                    if (this.___attributes.TryGetValue(__attrName, out attrExisting) == true)
                    {
                        IsValueFound = true;
                    }
                }
                if (attrExisting != null)
                {
                    if (attrExisting.value == __attrValue)
                    {
                        goto FinalCheck;
                    }
                    else
                    {
                        attrExisting.value = __attrValue;
                        nAttr = attrExisting;
                        goto FinalCheck;
                    }
                }

                if (__attrValue != null)
                {
                    if (__attrValue is string)
                    {
                        nAttr = new CHtmlAttribute();
                        if (string.IsNullOrEmpty(__attrName) == false)
                        {
                            nAttr.name = string.Copy(__attrName);
                        }
                        nAttr.___tagName = nAttr.name;
                        if (__attrValue is string)
                        {
                            nAttr.value = __attrValue;
                        }
                       
                        else
                        {
                            nAttr.value = __attrValue;
                        }
                        if (string.IsNullOrEmpty(__attrName) == false)
                        {
                            nAttr.___tagName = string.Copy(__attrName);
                        }
                        nAttr.setParentNode(this);

                        goto FinalCheck;
                    }
                    else
                    if (commonHTML.isClrNumeric(__attrValue) == true)
                    {
                        nAttr = new CHtmlAttribute();
                        nAttr.name = string.Copy(__attrName);
                        nAttr.___tagName = nAttr.name;

                        nAttr.value = __attrValue;
                        
                        nAttr.___tagName = string.Copy(__attrName);
                        nAttr.setParentNode(this);
                        goto FinalCheck;
                    }
                    else if (__attrValue is CHtmlAttribute)
                    {
                        nAttr = __attrValue as CHtmlAttribute;
                        goto FinalCheck;
                    }
                    else
                    {
                        nAttr = new CHtmlAttribute();
                        if (string.IsNullOrEmpty(__attrName) == false)
                        {
                            nAttr.name = string.Copy(__attrName);
                        }
                        nAttr.___tagName = nAttr.name;
                        if (__attrValue is string)
                        {
                            nAttr.value = __attrValue;
                        }
                        
                        else
                        {
                            nAttr.value = __attrValue;
                        }
                        if (string.IsNullOrEmpty(__attrName) == false)
                        {
                            nAttr.___tagName = string.Copy(__attrName);
                        }
                        nAttr.setParentNode(this);

                        goto FinalCheck;
                    }


                }
                if (nAttr == null)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("setAttribute is not allowed {0} {1} : {2}", __attrName, __attrValue, __attrValue.GetType());
                    }
                    return;
                }
                FinalCheck:
                if (commonHTML.ElementFieldsNeedsToTypeConversionSortedList.ContainsKey(__attrName) == true)
                {
                    if (string.IsNullOrEmpty(nAttr.___name) == true)
                    {
                        nAttr.name = string.Copy(__attrName);
                    }
                    commonHTML.ConvertAttributeValueByNameIfNessesary(nAttr);
                }
                if (IsValueFound == false)
                {
                    this.___attributes[__attrName] = nAttr;
                }


                this.___setPropertyByName(__attrName, nAttr.___value);
            }
            catch (Exception ex)
            {

                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("{0}.setAttributeInner() exception. ", ex);
                }
            }
        
		}
   
        public CHtmlCollection getElementsByTagNameNS(string __NS, string __LocalName)
        {
            CHtmlCollection arReturn = new CHtmlCollection();
            arReturn.___CollectionType = CHtmlHTMLCollectionType.ElementGetElementsByNameList;
            if (this.___Document != null && this.___Document.___IsMultiversalDocument == true)
            {
                this.___Document.___assignHTMLCollectionPrototype(ref arReturn);
            }
            if (__LocalName.Length == 1 && __LocalName[0] ==  '*')
            {
                this.___createChildElementListWithEnqueueDequeue(arReturn, CHtmlElementQueryType.All, "");
            }
            else
            {
                this.___createChildElementListWithEnqueueDequeue(arReturn, CHtmlElementQueryType.GetElementsByTagNameNS, string.Concat(__NS, ':', __LocalName));
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.getElementsByTagNameNS({1},{2}) returns: {3}", this, __NS, __LocalName, arReturn.Count);
            }
            arReturn.IsEnumByIndex = true;
            return arReturn;
        }
   
        public CHtmlCollection getElementsByTagName(string __tagName)
        {
            CHtmlCollection arReturn = new CHtmlCollection();
            arReturn.___CollectionType = CHtmlHTMLCollectionType.ElementGetElementsByTagNameList;
            if (this.___Document != null  && this.___Document.___IsMultiversalDocument == true)
            {
                this.___Document.___assignHTMLCollectionPrototype(ref arReturn);
            }
            if (this.___childNodes.Count >= 0)
            {
                if (__tagName.Length == 1 && __tagName[0] == '*')
                {
                    this.___createChildElementListWithEnqueueDequeue(arReturn, CHtmlElementQueryType.All, "");
                }
                else
                {
                    this.___createChildElementListWithEnqueueDequeue(arReturn, CHtmlElementQueryType.GetElementsByTagName, __tagName);
                }
            }
            arReturn.IsEnumByIndex = true;
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("{0}.getElementsByTagName({1}) returns: {2}", this, __tagName, arReturn.Count);
            }
            return arReturn;
        }
		/// <summary>
		/// DHTML getElementsByTagName return ArrayList
		/// </summary>
		/// <param name="__tagName"></param>
		/// <returns></returns>
		
		public CHtmlCollection  getElementsByName(string __Name)
		{
			CHtmlCollection  arReturn = new CHtmlCollection();
			arReturn.___CollectionType = CHtmlHTMLCollectionType.ElementGetElementsByNameList;
            if (this.___Document != null && this.___Document.___IsMultiversalDocument == true)
            {
                this.___Document.___assignHTMLCollectionPrototype(ref arReturn);
            }
            if (string.IsNullOrEmpty(__Name) == false && __Name.Length == 1 && __Name[0] == '*')
            {
                this.___createChildElementListWithEnqueueDequeue(arReturn, CHtmlElementQueryType.All, "");
            }
            else
            {
                this.___createChildElementListWithEnqueueDequeue(arReturn, CHtmlElementQueryType.GetElementsByName, __Name);
            }
			arReturn.IsEnumByIndex = true;
			return arReturn;
		}
		/// <summary>
		/// DHTML getElementsByClassName return ArrayList
		/// </summary>
		/// <param name="__tagName"></param>
		/// <returns></returns>
		
		public CHtmlCollection getElementsByClassName(string __className)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel > 8)
            {
               commonLog.LogEntry("calling {0}.getElementByClassName(\"{1}\") ", this, __className);
            }
			CHtmlCollection  arReturn = new CHtmlCollection();
			
			arReturn.___CollectionType = CHtmlHTMLCollectionType.ElementGetElementsByClassNameList;
            CHtmlDocument ___doc = this.___getDocument();
            if (___doc != null && ___doc.___IsMultiversalDocument == true)
            {
                ___doc.___assignHTMLCollectionPrototype(ref arReturn);
            }
            this.___createChildElementListWithEnqueueDequeue(arReturn, CHtmlElementQueryType.GetElementsByClassName, __className);
			arReturn.IsEnumByIndex = true;
            if (commonLog.LoggingEnabled &&commonLog.LogLevel > 8)
            {
               commonLog.LogEntry("{0}.getElementByClassName(\"{1}\") returns {2}...", this, __className, arReturn.Count);
            }
			return arReturn;
		}
		/// <summary>
		/// DHTML getElementsByClassName return ArrayList
		/// </summary>
		/// <param name="__tagName"></param>
		/// <returns></returns>
		
		public CHtmlElement getElementById(string __id)
		{
			CHtmlCollection arReturn = new CHtmlCollection();
			try
			{
				arReturn.___CollectionType = CHtmlHTMLCollectionType.ElementGetElementsByIDList;
				this.___createChildElementListWithEnqueueDequeue(arReturn, CHtmlElementQueryType.GetElementById , __id);
                if (arReturn.Count > 0)
                {
                    return arReturn[0] as CHtmlElement;
                }
			}
			catch(Exception ex)
			{
                if (commonLog.LoggingEnabled &&commonLog.LogLevel > 8)
                {
                   commonLog.LogEntry("{0} getElementById({1}) Exception {2}", this, __id,commonData.GetExceptionAsString(ex));
                }
				return null;
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel > 8)
			{
				commonLog.LogEntry("CHtmlElement {0} getElementById({1}) returns null", this, __id);
			}
		
			return null;
}
		
		public CHtmlCollection querySelectorAll(object queryValueObject)
		{
            string sQuery = commonHTML.GetStringValue(queryValueObject);
			try
			{
				CHtmlCollection arReturn = commonHTML.___getQuerySelectorListProcessorInner(this, sQuery, CHtmlQuerySelectorType.element_querySelectorAll);
                if (this.___Document != null && this.___Document.___IsMultiversalDocument)
                {
                    this.___Document.___assignHTMLCollectionPrototype(ref arReturn);
                }
                return arReturn;
			}
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("querySelectorAll", ex);
				}
				return new CHtmlCollection();
			}
		}
		
		public CHtmlElement querySelector(object queryValueObject)
		{
            string sQuery = commonHTML.GetStringValue(queryValueObject);
			try
			{
				CHtmlCollection list = commonHTML.___getQuerySelectorListProcessorInner(this, sQuery, CHtmlQuerySelectorType.element_querySelector);
				if(list.Count > 0)
				{
					return list[0] as CHtmlElement;
				}
				else
				{
					return null;
				}
			}
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("querySelector", ex);
				}
				return null;
			}
		}
        #region matchesSelector
   
        public bool matches(string ___test)
        {
            string sTest = ___test;
            return this.matchesSelectorInner(this, sTest);
        }
   
		public bool matchesSelector(string ___test)
		{
			string sTest = ___test;
            return this.matchesSelectorInner(this,sTest);
		}
		
		public bool mozMatchesSelector(string  __selector)
		{
			string sTest = __selector;
			return this.matchesSelectorInner(this, sTest);
		}
        /*
        public bool matches(CHtmlElement elem, string __selector)
        {
            return this.matchesSelectorInner(elem, __selector);
        }
		
		public bool mozMatchesSelector(CHtmlElement elem, string __selector)
		{
			return this.matchesSelectorInner(elem, __selector);
		}
		
		public bool webkitMatchesSelector(CHtmlElement elem, string __selector)
		{
			return this.matchesSelectorInner(elem, __selector);
		}
		
		public bool webkitMatchesSelector(string ___selector)
		{
			return this.matchesSelectorInner(this, commonHTML.GetStringValue(___selector));
		}
		
		private bool matchesSelector(CHtmlElement elem, string __selector)
		{
			return this.matchesSelectorInner(elem, __selector);
		}
		
        */
		private bool matchesSelectorInner(CHtmlElement elem, string __selector)
		{
            bool result = false;
			if(elem == null)
			{
				elem = this;
			}
			if(elem.___parentWeakRef  == null)
			{
				return false;
			}
			CHtmlCollection resultset = elem.___getParentElement().querySelectorAll(__selector.ToString());
            result = resultset.___containsObjectHash(elem.GetHashCode());
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("{0},matchesSelectorInner({1}) result : {2}", this, __selector, result);
            }
            return result;
		}
		#endregion
		/// <summary>
		/// The node to be replaced must be an immediate child of the parent object.
		///  The new node must be created using the createElement method.
		/// This property is accessible at run time. If elements are removed 
		/// at run time, before the closing tag is parsed, areas of the document
		///  might not render.
		/// </summary>
		/// <param name="newchild"></param>
		/// <param name="refchild"></param>
		/// <returns></returns>
		public object replaceChild(object newElement, object oldElement)
		{
			if(newElement is CHtmlElement && oldElement is CHtmlElement)
			{
				return this.replaceChildInner(newElement as CHtmlElement ,oldElement as CHtmlElement);
			}
			else
			{
                /*
				CHtmlElement ochildElement = commonHTML.GetElementFromJSObject(newElement);
				CHtmlElement refchildElement = commonHTML.GetElementFromJSObject(oldElement);
				return this.replaceChildInner(ochildElement, refchildElement);
                */
                return null;
			}


		}
        /// <summary>
        /// DOM compatible insertBefore implementation exposed to script engines.
        /// </summary>
        /// <param name="newChildObj"></param>
        /// <param name="refChildObj"></param>
        /// <returns></returns>
        public object insertBefore(object newChildObj, object refChildObj)
        {
            try
            {
                CHtmlElement newChild = commonData.convertObjectIntoCHtmlElement(newChildObj);
                CHtmlElement refChild = commonData.convertObjectIntoCHtmlElement(refChildObj);

                if (newChild == null)
                    return null;

                // If refChild is not supplied or not a child, append to end
                if (refChild == null)
                {
                    if (newChild.___parentWeakRef == null || !object.ReferenceEquals(newChild.___parentWeakRef.Target, this))
                    {
                        newChild.___parentWeakRef = new WeakReference(this, false);
                    }
                    this.___childNodes.Add(newChild);
                    return newChild;
                }

                int pos = this.___childNodes.IndexOf(refChild);
                if (pos < 0)
                {
                    // fallback to append
                    if (newChild.___parentWeakRef == null || !object.ReferenceEquals(newChild.___parentWeakRef.Target, this))
                    {
                        newChild.___parentWeakRef = new WeakReference(this, false);
                    }
                    this.___childNodes.Add(newChild);
                    return newChild;
                }

                if (newChild.___parentWeakRef == null || !object.ReferenceEquals(newChild.___parentWeakRef.Target, this))
                {
                    newChild.___parentWeakRef = new WeakReference(this, false);
                }
                this.___childNodes.Insert(pos, newChild);
                return newChild;
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("insertBefore error: {0}", ex);
                }
                return null;
            }
        }

        /// <summary>
        /// DOM compatible appendChild implementation exposed to script engines.
        /// </summary>
        /// <param name="newChildObj"></param>
        /// <returns></returns>
        public object appendChild(object newChildObj)
        {
            try
            {
                CHtmlElement newChild = commonData.convertObjectIntoCHtmlElement(newChildObj);
                if (newChild == null)
                    return null;
                if (newChild.___parentWeakRef == null || !object.ReferenceEquals(newChild.___parentWeakRef.Target, this))
                {
                    newChild.___parentWeakRef = new WeakReference(this, false);
                }
                this.___childNodes.Add(newChild);
                return newChild;
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("appendChild error: {0}", ex);
                }
                return null;
            }
        }

        /// <summary>
        /// DOM compatible removeChild implementation exposed to script engines.
        /// </summary>
        /// <param name="childObj"></param>
        public void removeChild(object childObj)
        {
            try
            {
                CHtmlElement child = commonData.convertObjectIntoCHtmlElement(childObj);
                if (child == null)
                    return;
                int idx = this.___childNodes.IndexOf(child);
                if (idx >= 0)
                {
                    this.___childNodes.RemoveAt(idx);
                    child.___parentWeakRef = null;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("removeChild error: {0}", ex);
                }
            }
        }
		public object replaceChild(CHtmlElement  newchild, CHtmlElement refchild)
		{
			return this.replaceChildInner(newchild, refchild);
		}
        internal void ___ClearDocumentChildFlagRecursively()
        {
            int fragmentchlildCount = 0;
            for (int i = 0; i < this.___childNodes.Count; i++)
            {
                CHtmlElement fragmentChild = this.___childNodes[i] as CHtmlElement;
                if (fragmentChild.___isInactivativeElementNodeChild == true)
                {
                    fragmentChild.___isInactivativeElementNodeChild = false;
                    fragmentChild.___DocumentHiddenWeakReference = null;
                    if (this.___Document != null && fragmentChild.___Document == null)
                    {
                        fragmentChild.___documentWeakRef = new WeakReference(this.___Document, false);
                    }
                    fragmentchlildCount++;
                    fragmentChild.___ClearDocumentChildFlagRecursively();
                }
            }
        }
        /// <summary>
        /// Clear DocumentIndex (including SubNodes)
        /// </summary>
        internal void ___clearDocumentIndexRecursively(bool isCrlearStyleFlag)
        {
           // this.___DocumentElementIndex = -1;
            if (isCrlearStyleFlag)
            {
                this.___isApplyElemenetStyleSheetCalled = false;
                this.___isCalculateElementBoundsCalled = false;
            }
            for (int i = 0; i < this.___childNodes.Count; i++)
            {
                CHtmlElement ___childNode = this.___childNodes[i] as CHtmlElement;
                if (___childNode != null)
                {
                    //___childNode.___DocumentElementIndex = -1;
                    if (isCrlearStyleFlag)
                    {
                        ___childNode.___isApplyElemenetStyleSheetCalled = false;
                        ___childNode.___isCalculateElementBoundsCalled = false;
                    }
                    ___childNode.___clearDocumentIndexRecursively(isCrlearStyleFlag);
                }
            }
        }
        /// <summary>
        /// The node to be replaced must be an immediate child of the parent object.
        ///  The new node must be created using the createElement method.
        /// This property is accessible at run time. If elements are removed 
        /// at run time, before the closing tag is parsed, areas of the document
        ///  might not render.
        /// </summary>
        /// <param name="newchild"></param>
        /// <param name="refchild"></param>
        /// <returns>Returns a reference to the object that is replaced. (refchild)</returns>
        private object replaceChildInner(CHtmlElement __appendingChild, CHtmlElement refchild)
		{
			 ___ClearFirstChildWeakReference();
			CHtmlElement  __newchild = null;
			try
			{
				if(__appendingChild == null)
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
					{
						commonLog.LogEntry("replaceChild ___hasInner passed null object!");
					}
					return refchild;
				}
				if(object.ReferenceEquals(__appendingChild, this) == false)
				{
                    if (__appendingChild.___parentWeakRef != null)
                    {
                        __newchild = ___PreCheckAppendingNodeParentExistance(__appendingChild);
                    }
                    else
                    {
                        __newchild = __appendingChild;
                    }
				}
				else
				{
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("replaceChild First node is identical parent node. make clone");
                    }
					__newchild = __appendingChild.cloneNode(false);
				}

                if (this.___elementTagType == CHtmlElementType._DOCUMENT_FRAGMENT || this.___isInactivativeElementNodeChild == true)
                {
                    __newchild.___isInactivativeElementNodeChild = true;
                    if (this.___DocumentHiddenWeakReference != null && __newchild.___DocumentHiddenWeakReference == null)
                    {
                        __newchild.___DocumentHiddenWeakReference = this.___DocumentHiddenWeakReference;
                    }
                }
                else
                {
                    if (__newchild.___isInactivativeElementNodeChild == true)
                    {
                        __newchild.___isInactivativeElementNodeChild = false;
                    }
                }
                if (__newchild.___elementTagType == CHtmlElementType._DOCUMENT_FRAGMENT)
                {
                    int __FragmentChildCount = __newchild.___childNodes.Count;
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                    {
                       commonLog.LogEntry("{0}.replaceChild for DocumentFragment length of {1}", this, __FragmentChildCount);
                    }
                    for (int fragPos = 0; fragPos < __FragmentChildCount; fragPos++)
                    {
                        CHtmlElement fragChild = __newchild.___childNodes[fragPos] as CHtmlElement;
                        if (fragChild != null)
                        {
                            if (this.___isInactivativeElementNodeChild == false)
                            {
                                this.___ClearDocumentChildFlagRecursively();
                                if (this.___documentWeakRef != null)
                                {
                                    fragChild.___documentWeakRef = new WeakReference(this.___documentWeakRef.Target, false);
                                }
                            }
                            fragChild.___isInactivativeElementNodeChild = this.___isInactivativeElementNodeChild;
                            this.replaceChildInner(fragChild, refchild);
                        }
                    }
                    return __newchild;
                }
                if (__newchild.___parentWeakRef == null || object.ReferenceEquals(__newchild.___parentWeakRef.Target , this) == false)
				{
                    __newchild.___parentWeakRef = new WeakReference(this, false);
				}
                if (__newchild.___isInactivativeElementNodeChild == false)
                {

                    if (__newchild.___documentWeakRef == null || (this.___documentWeakRef != null && object.ReferenceEquals(__newchild.___documentWeakRef.Target, this.___documentWeakRef.Target) == false))
                    {
                        __newchild.___documentWeakRef = new WeakReference(this.___documentWeakRef.Target, false);
                        __newchild.___ChildNodeIndex = -1;
                    }
                }
                CHtmlDocument ___doc = this.___getDocument();
                if (___doc != null && (__newchild.___elementTagType == CHtmlElementType.BODY || __newchild.___elementTagType == CHtmlElementType.HEAD))
				{
                    if (__newchild.___isInactivativeElementNodeChild == false)
                    {
                        ___doc.___CheckDynamicallyCreatedHeadBodyElementValidForDocument(__newchild);
                    }
				}
				int indexofref = this.___childNodes.IndexOf(refchild);
				if(indexofref >= 0)
				{
					// 1) Remove ref child
					try
					{
						this.___childNodes.Remove(refchild);
						refchild.___HasElementRemoved = true;
						//refchild.Dispose();
						//refchild = null;
					}
					catch
					{
						if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
						{
							commonLog.LogEntry("replaceChild remove failed!");
						}
					}
                    if (___doc != null && ___doc.___IsDomModeFullParseMode())
					{
                        if (__newchild.___isInactivativeElementNodeChild == false)
                        {
                            CHtmlElement.___PreProcessNewlyCreateNode(__newchild);
                        }
					}
					this.___childNodes.Insert(indexofref, __newchild);
                    this.___setElementCriticalPropertiesChildNode(__newchild);
                    if (___doc != null && ___doc.___IsDomModeFullParseMode())
					{
						int __StackDepth = 0;
                        if (__newchild.___isInactivativeElementNodeChild == false && __newchild.___IsMainDocumentNodeElement == true )
                        {
                            ___doc.___postprocessDynamicElementCHtmlElement(__newchild, ref __StackDepth);
                        }
					}
					
					return refchild;
				}
				else
				{
					this.___appendChildInner(__newchild);
					return refchild;
				}
				
			}
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("CHtmlElement replaceChild failed {0} : {1} : {2}", __newchild, refchild,commonData.GetExceptionAsString(ex));
				}
			}
			return refchild;
		}
		
		private static void ___PreProcessNewlyCreateNode(CHtmlElement newchild)
		{
			if( newchild.___Document != null)
			{
                try
                {
                    CHtmlDocument ___rootDoc = newchild.___Document;
                    ___rootDoc.___registerElementDocumentElementID(newchild);
                    int currentChildCount = newchild.___childNodes.Count;
                    if (currentChildCount > 0)
                    {
                        for (int i = 0; i < currentChildCount; i++)
                        {
                            CHtmlElement ___newchildchild = newchild.___childNodes[i] as CHtmlElement;
                            if (___newchildchild == null)
                                continue;
                            if (true)
                            {
                                ___rootDoc.___registerElementDocumentElementID(___newchildchild);

                            }
                            int __level2Count = ___newchildchild.___childNodes.Count;
                            if (__level2Count == 0)
                                continue;
                            for (int __level2 = 0; __level2 < __level2Count; __level2++)
                            {
                                CHtmlElement ___level2dchild = ___newchildchild.___childNodes[__level2] as CHtmlElement;
                                if (___level2dchild == null)
                                    continue;
                                if (true)
                                {
                                    ___rootDoc.___registerElementDocumentElementID(___level2dchild);
                                }
                                int __level3Count = ___level2dchild.___childNodes.Count;
                                if (__level3Count == 0)
                                    continue;
                                for (int __level3 = 0; __level3 < __level3Count; __level3++)
                                {
                                    CHtmlElement ___level3dchild = ___level2dchild.___childNodes[__level3] as CHtmlElement;
                                    if (___level3dchild == null)
                                        continue;
                                    if (true)
                                    {
                                        ___rootDoc.___registerElementDocumentElementID(___level3dchild);
                                    }
                                    int __level4Count = ___level3dchild.___childNodes.Count;
                                    if (__level4Count == 0)
                                        continue;
                                    if (__level4Count > 0)
                                    {
                                        for (int __level4 = 0; __level4 < __level4Count; __level4++)
                                        {
                                            CHtmlElement ___level4dchild = ___level3dchild.___childNodes[__level4] as CHtmlElement;
                                            if (___level4dchild == null)
                                                continue;
                                            if (true)
                                            {
                                                ___rootDoc.___registerElementDocumentElementID(___level4dchild);
                                            }

                                            int __level5Count = ___level4dchild.___childNodes.Count;
                                            if (__level5Count == 0)
                                                continue;
                                                if (__level5Count > 0)
                                            {
                                                for (int __level5 = 0; __level5 < __level5Count; __level5++)
                                                {
                                                    CHtmlElement ___level5child = ___level4dchild.___childNodes[__level5] as CHtmlElement;
                                                    if (___level5child == null)
                                                        continue;
                                                    if (true)
                                                    {
                                                        int ___cureentLevel = 5;
                                                        ___level5child.___CallAddToDocumentDynamicallyAndRecursively(___rootDoc, ___cureentLevel);

                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                    {
                        commonLog.LogEntry("PreProcessNewlyCreatedNode", ex);
                    }
                }
                    
			}
		}
        public object prototype
        {
            get
            {


                object ___protoValue;
                if (this.___properties.TryGetValue("prototype", out ___protoValue))
                {
                    if (___protoValue != null)
                    {
                        return ___protoValue;
                    }
                }

                if (this.___IsPrototype == false)
                {
                    if (this.___prototypeWeakReference != null)
                    {
                        return this.___prototypeWeakReference.Target;
                    }
                    return this;
                }
                else
                {
                    return this;
                }
            }
            set {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("prototype set called for {0} {1}", this, this.toLogString());
                }
            }
        }



		/// <summary>
		/// Exchanges the location of two objects in the document hierarchy.
		/// </summary>
		/// <param name="childX"></param>
		/// <param name="childY"></param>
		/// <returns>True = Success
		/// False = Fail
		/// </returns>
		public bool swapNode(CHtmlElement childX, CHtmlElement childY)
		{
			int indexofX = base.___childNodes.IndexOf(childX);
			int indexofY = base.___childNodes.IndexOf(childY);
			bool __IsSuccess = false;
			if(indexofX > -1 && indexofY > -1)
			{
				try
				{
					base.___childNodes.RemoveAt(indexofX);
					base.___childNodes.RemoveAt(indexofY);
					base.___childNodes.Insert(indexofX, childY);
					base.___childNodes.Insert(indexofY, childX);
					childX.___ChildNodeIndex = indexofY;
					childY.___ChildNodeIndex = indexofX;
					__IsSuccess = true;
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
					{
						commonLog.LogEntry("SwapNode Success {0}:{1} <-> {2}:{3}", childX, indexofX, childY, indexofY);
					}
					return true;
				}
				catch 
				{
					__IsSuccess = false;
				}
			}
			if(__IsSuccess == false)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
				{
					commonLog.LogEntry("SwapNode Failed {0}:{1} <-> {2}:{3}", childX, indexofX, childY, indexofY);
				}

			}
			return false;
		}
        public CHtmlElement ___getParentElementByTagType(CHtmlElementType tagType)
        {
            CHtmlElement current = this;
            while (true)
            {
                current = current.parentElement;
                if (current == null)
                    return null;
                if (current.___elementTagType == tagType)
                    return current;
            }
        }
        /// <summary>
        /// Tests to see if this DOM implementation supports a particular feature.
        /// </summary>
        /// <param name="__feature"></param>
        /// <param name="__version"></param>
        /// <returns></returns>

        public bool supports(object __feature, object __version)
		{
			return this.supports_inner(__feature, __version);
		}
		
		public bool supports(object __feature)
		{
			return this.supports_inner(__feature, null);

		}
		private bool supports_inner(object __feature, object __version)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("support({0}, {1})", __feature, __version);
			}
			return true;
		}

        
        public CHtmlElement insertBefore(CHtmlElement newchild)
		{
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                if(newchild != null)
                {
                    commonLog.LogEntry($"{this.GetType().FullName} {this.toLogString()}. entering ___insertBefore() {newchild.GetType().FullName} {newchild.toLogString()}");
                }
                else
                {
                    commonLog.LogEntry($"{this.GetType().FullName} {this.toLogString()}. entering ___insertBefore() null exit");
                    return null;
                }
                commonLog.LogEntry($"{this.GetType().FullName} {this.toLogString()}. entering ___insertBefore() {newchild}");
            }
            return this.___appendChildInner(newchild);
		}
        
		public object insertBefore(CHtmlElement  ochild, CHtmlElement refo)
		{
			if(ochild is CHtmlElement && ( refo is CHtmlElement || refo == null))
			{
				return this.___insertBeforeInner(ochild as CHtmlElement,  refo as CHtmlElement);
			}
			else
			{
				CHtmlElement ochildElement = null;
				if(ochild != null)
				{
                    ochildElement = commonData.convertObjectIntoCHtmlElement(ochild);
				}
				CHtmlElement refchildElement = null;
				if(refo != null)
				{
                    refchildElement = commonData.convertObjectIntoCHtmlElement(refo);
				}
				return this.___insertBeforeInner(ochildElement, refchildElement);
			}
		}
		/* ----------------------------------------------------
		 * IT May cause ambigurous errot with above code
		 * comment out is better solution.
		 * -----------------------------------------------------
		public  CHtmlElement insertBefore(CHtmlElement  newchild, CHtmlElement refchild)
		{
			return  this.___insertBeforeInner(newchild,  refchild);
		}
		*/
		
		private CHtmlElement ___insertBeforeInner(CHtmlElement __appendingChild, CHtmlElement refchild)
		{
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("entering {0}___insertBeforeInner() {1} {2}" , this, __appendingChild, refchild);
            }
            bool isReferenceChildExists = commonHTML.IsNotNull(refchild);
            CHtmlElement  __newchild = null;
            if (this.___childNodes.Count > commonHTML.MAX_ELEMENT_APPENDCHILD_COUNT)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                {
                   commonLog.LogEntry("{0}.insertBefore() exceeds the limit. abort now.", this, this.___childNodes.Count);
                }
                throw new System.OverflowException("insertBefore() exceeds system limit : "+ commonHTML.MAX_ELEMENT_APPENDCHILD_COUNT.ToString());
            }
			try
			{

				___ClearFirstChildWeakReference();

				if(__appendingChild == null)
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
					{
						commonLog.LogEntry("insertBefore called but child is null");
					}
					return __appendingChild;
				}
				// ------------------------------------------------------------------------
				// The Appending Node may be static node. in that case, make clone
				// ------------------------------------------------------------------------
                if ( object.ReferenceEquals(__appendingChild, this) == false)
                {
                    if (__appendingChild.___parentWeakRef != null)
                    {
                        __newchild = ___PreCheckAppendingNodeParentExistance(__appendingChild);
                    }
                    else
                    {
                        __newchild = __appendingChild;
                    }
				}
				else
				{
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                    {
                       commonLog.LogEntry("insertBefore to the same node. make shallow clone.");
                    }
					__newchild = __appendingChild.cloneNode(false);
				}
                if (this.___elementTagType == CHtmlElementType._DOCUMENT_FRAGMENT || this.___isInactivativeElementNodeChild == true)
                {
                    __newchild.___isInactivativeElementNodeChild = true;
                    if (this.___DocumentHiddenWeakReference != null && __newchild.___DocumentHiddenWeakReference == null)
                    {
                        __newchild.___DocumentHiddenWeakReference = this.___DocumentHiddenWeakReference;

                    }
                }
                else
                {
                    if (__newchild.___isInactivativeElementNodeChild == true)
                    {
                        __newchild.___isInactivativeElementNodeChild = false;
                    }
                }

                if (__newchild.___elementTagType == CHtmlElementType._DOCUMENT_FRAGMENT)
                {
                    int insertPos = -1;
                    if (refchild != null)
                    {
                        insertPos = this.___childNodes.IndexOf(refchild);
                    }

                    this.___appendOrInsertChildRange(__newchild.___childNodes, true, insertPos);
                    /*
                    int __FragmentChildCount = __newchild.___childNodes.Count;
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                    {
                       commonLog.LogEntry("{0}.insertBefore for DocumentFragment length of {1}", this, __FragmentChildCount);
                    }
                    for (int fragPos = 0; fragPos < __FragmentChildCount; fragPos++)
                    {
                        CHtmlElement fragChild = __newchild.___childNodes[fragPos] as CHtmlElement;
                        if (fragChild != null)
                        {
                            if (this.___isInactivativeElementNodeChild == false)
                            {
                                this.___ClearDocumentChildFlagRecursively();
                                fragChild.___Document = this.___Document;
                            }
                            fragChild.___isInactivativeElementNodeChild = this.___isInactivativeElementNodeChild;
                            this.___insertBeforeInner(fragChild, refchild);
                        }
                    }
                     */
                    return __newchild;
                }

                if (__newchild.___parentWeakRef == null || object.ReferenceEquals(__newchild.___parentWeakRef.Target, this) == false)
				{
                    __newchild.___parentWeakRef = new WeakReference(this, false);
				}

                if (__newchild.___isInactivativeElementNodeChild == false)
                {
                    if (__newchild.___Document == null || object.ReferenceEquals(__newchild.___Document, this.___Document) == false)
                    {
                        __newchild.___documentWeakRef = new WeakReference(this.___Document, false);
                        __newchild.___ChildNodeIndex = -1;
                    }
                }
                if (__newchild.___isInactivativeElementNodeChild == false)
                {
                    if (this.___Document != null && (__newchild.___elementTagType == CHtmlElementType.BODY || __newchild.___elementTagType == CHtmlElementType.HEAD))
                    {
                        this.___Document.___CheckDynamicallyCreatedHeadBodyElementValidForDocument(__newchild);
                    }
                }

				int ___ProcessPos = 0;
				int ___pos = -1;
				if(refchild == null)
				{
					___pos = -1;
				}
				else
				{
					try
					{
                        if (refchild.___elementTagType != CHtmlElementType.HEAD)
                        {
                            ___pos = this.___childNodes.IndexOf(refchild);
                        }
                        else
                        {
                            ___pos = -1;
                        }
					}
					catch(Exception ex)
					{
						if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
						{
							commonLog.LogEntry("Indexof faieled, but cont... " + ex.Message);
						}
					}
				}
                if (___pos > -1)
                {
                    try
                    {

                        if (__newchild.___style == null)
                        {
                            __newchild.___style = new CHtmlCSSStyleSheet(CHtmlElementStyleType.Element);
                        }


                        if (__newchild.___isInactivativeElementNodeChild == false)
                        {
                            if (this.___Document != null && this.___Document.___documentDomType == CHtmlDomModeType.HTMLDOM)
                            {
                                CHtmlElement.___PreProcessNewlyCreateNode(__newchild);
                            }
                        }

                        ___ProcessPos = 1;
                        this.___childNodes.Insert(___pos, __newchild);
                        this.___setElementCriticalPropertiesChildNode(__newchild);
                        __newchild.___ChildNodeIndex = ___pos;
                        commonHTML.ResetCHtmlElementChildIndex(this, ___pos + 1);

                        ___ProcessPos = 2;
                        if (__newchild.___isInactivativeElementNodeChild == false)
                        {
                            if (this.___Document != null && (this.___Document.___IsDomModeFullParseMode()))
                            {
                                int __StackDepth = 0;
                                bool DoNotProcessAfterProcessHTMLElement = false;
                                if (this.___elementTagType == CHtmlElementType.HEAD)
                                {
                                    if (__newchild.___elementTagType == CHtmlElementType.SCRIPT)
                                    {
                                        if (__newchild.___srcBase != null && string.IsNullOrEmpty(__newchild.___srcBase.___Href) == false)
                                        {
                                            if (this.___Document.___PageRequestedUrlList.ContainsKey(__newchild.___srcBase.___Href) == true)
                                            {
                                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                                {
                                                    commonLog.LogEntry("HEAD already contains same src scrip tag");
                                                }
                                                DoNotProcessAfterProcessHTMLElement = true;
                                                __newchild.___IsDynamicProcessDone = true;
                                                __newchild.___IsElementVisible = true;
                                                __newchild.___isCalculateElementBoundsCalled = true;
                                            }

                                        }
                                    }
                                }
                                if (this.___Document.___IsDomModeFullParseMode() == true && __newchild.___IsMainDocumentNodeElement == false)
                                {
                                    __newchild.___IsMainDocumentNodeElement = true;
                                }
                                if (DoNotProcessAfterProcessHTMLElement == false && __newchild.___IsMainDocumentNodeElement)
                                {
                                    this.___Document.___postprocessDynamicElementCHtmlElement(__newchild, ref __StackDepth);
                                }
                            }
                        }

                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                        {
                            commonLog.LogEntry("Call For Element {0} insertBefore({1}, {2}) inserted at {3} : {4} nodes", this, __newchild, refchild, ___pos, this.___childNodes.Count);
                        }
                        if (commonHTML.elementTagTypesAppearsOnlyHeaderSortedList.ContainsKey(__newchild.___elementTagType) == false && __newchild.___IsElementVisible == true && __newchild.___offsetHeight > 0)
                        {
                            int ___childNodesCount = this.___childNodes.Count;
                            for (int i = ___pos + 1; i < ___childNodesCount; i++)
                            {
                                CHtmlElement shiftingElement = this.___childNodes[i] as CHtmlElement;
                                if (shiftingElement != null && shiftingElement.___IsElementVisible == true && shiftingElement.___IsElementFloat == false)
                                {
                                    double _curTop = shiftingElement.___offsetTop;
                                    shiftingElement.___offsetTop += __newchild.___offsetHeight + 1;
                                    //commonLog.LogEntry("{0} : {1} >> {2}", i, shiftingElement, _curTop, shiftingElement.___offsetTop);
                                    shiftingElement.___offfsetParentPoint = commonHTML.MinusPoint;
                                    shiftingElement.___IsElementofffsetParentPointCaluculationRequired = true;
                                }
                            }
                        }
                    }
                    catch
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                        {
                            commonLog.LogEntry("{0} Strange insertBefore failed with  '{0}'. Insert at Last", this, ___pos);
                        }
                        if (___ProcessPos < 0)
                        {
                            this.___appendChildInner(__newchild);
                        }
                    }
                }
                else
                {
                    if (isReferenceChildExists == false)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                        {
                            commonLog.LogEntry("insertBefore() Method Call does not have refrerenceChild instanse. Use AppendChild");

                            this.___appendChildInner(__newchild);
                        }
                    }
				}
				___ReConfirmElementVisibility(__newchild);
			}
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
				{
					commonLog.LogEntry("insertBeforeInner Faied", ex);
				}

			}
			return __newchild;
		}

		/*
			/// <summary>
			/// Remove Child and Returns Removed Child
			/// </summary>
			/// <param name="_removingChild"></param>
			/// <returns>Removed Child</returns>
		public object removeChild(object o)
		{
			if(o != null)
			{
				try
				{
					if(o is  CHtmlElement)
					{
						return this.removeChildInner(o as  CHtmlElement);
					}
					else
					{
						if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
						{
							commonLog.LogEntry("removeChild failed {0}, unexpected type", o);
						}
					}

				} 
				catch(Exception ex)
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
					{
						commonLog.LogEntry("removeChild", ex);
					}
				}
			}
			return o;
		}
        */
		/// <summary>
		/// Remove Child and Returns Removed Child
		/// </summary>
		/// <param name="_removingChild"></param>
		/// <returns>Removed Child</returns>
		
		public CHtmlElement removeChild( CHtmlElement _removingChild)
		{
			return this.removeChildInner(_removingChild);

		}

        
        /// <summary>
        /// Remove Child and Returns Removed Child 
        /// </summary>
        /// <param name="_removingChild"></param>
        /// <returns>Removed Child</returns>
   
        public CHtmlElement removeChild(CHtmlElement _removingChildOne, CHtmlElement _removingChildTwo)
        {
            this.removeChildInner(_removingChildOne);
            this.removeChildInner(_removingChildTwo);
            return _removingChildOne;
        }
        
		
		private CHtmlElement removeChildInner( CHtmlElement _removingChild)
		{
            try
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                {
                   commonLog.LogEntry("calling {0}.removeChild({1})", this, _removingChild);
                }
                if(_removingChild == null)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                    {
                       commonLog.LogEntry("{0} removeChild called with null object. exit.", this);
                    }
                    return null;
                }
                if (object.ReferenceEquals(this, _removingChild) == true)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                    {
                       commonLog.LogEntry("{0} removeChild({1}) is same node. exit.", this, _removingChild);
                    }
                    return _removingChild;
                }
                ___ClearFirstChildWeakReference();

               

                int _prevCount = this.___childNodes.Count;
                try
                {
                    this.___childNodes.Remove(_removingChild);

                    if (this.___childNodes.Count > 0)
                    {
                        commonHTML.ResetCHtmlElementChildIndex(this, -1);
                    }
                }
                finally
                {
                    if (_removingChild.___parentWeakRef != null)
                    {
                        if (object.ReferenceEquals(_removingChild.___parentWeakRef.Target, this) == true)
                        {
                            _removingChild.___parentWeakRef = null;
                        }
                    }
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                    {
                        if (_prevCount != this.___childNodes.Count)
                        {
                           commonLog.LogEntry("{0} removeChild({1}) Success. Before : {2} Now : {3}", this, _removingChild, _prevCount, this.___childNodes.Count );
                        }
                        else
                        {
                           commonLog.LogEntry("{0} removeChild({1}) Unsuccessuful  Before : {2} Now : {3}", this, _removingChild, _prevCount, this.___childNodes.Count);

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("removeChildInner", ex);
                }
            }
			return _removingChild;
		}
		
		public bool removeNode()
		{
			return this.removeNode(false);
		}
		/// <summary>
		/// Removes the object from the document hierarchy.
		/// </summary>
		/// <param name="IsRemoveChild"></param>
		/// <returns>true=children are removed,false=childrens are not removed</returns>
		
		public bool removeNode(object ___IsRemoveChildObject)
		{
            bool IsRemoveChild = false;
            if (___IsRemoveChildObject == null)
            {
                IsRemoveChild = false;
            }
            else
            {
                IsRemoveChild = commonData.convertObjectToBoolean(___IsRemoveChildObject);
            }
			
			if(this.___parentWeakRef == null)
				return false;
			this.___ClearFirstChildWeakReference();
			bool __IsChildrenActuallyRemoved = false;
			if(IsRemoveChild)
			{
                int ___cCount = this.___childNodes.Count;
				for(int i = 0; i < ___cCount ; i ++)
				{
                    CHtmlElement elem = this.___childNodes[i] as CHtmlElement;
					if(elem != null)
					{
						elem.___HasElementRemoved = true;
                        elem.___parentWeakRef  = null;
					}
				}
				if(this.___childNodes.Count > 0)
				{
                    this.___childNodes.Clear();
					__IsChildrenActuallyRemoved = true;
				}
			}
			if(this.___parentWeakRef != null)
			{
				this.___parent.___childNodes.Remove(this);
			}
            this.___parentWeakRef = null;
			this.___HasElementRemoved = true;
			return  __IsChildrenActuallyRemoved;
		}
		
		public void removeEventListener(string __Name, object ___function, object boolObj)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
			{
				commonLog.LogEntry("___ called {0} : {1}", __Name, ___function);
			}
			this.___removeEventInner(__Name, ___function);
		}
   
        public void removeEventListener(object __NameObject, object ___function)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
            {
               commonLog.LogEntry("___ called {0} : {1}", __NameObject, ___function);
            }
            this.___removeEventInner(commonHTML.GetStringValue(__NameObject), ___function);
        }
        private bool ___removeEventInner(string __Name, object ___function)
        {
            if (__Name == null || __Name.Length == 0)
                return false;
            try
            {
                /*
                CHtmlAttributeType eventType = commongetAttributeType(__Name);
                if (eventType != CHtmlAttributeType.UNKNOWN)
                {
                    this.___UnRegisterEventFunctionWeakReference(eventType);
                }
                */
                this.___attributes.Remove(__Name);
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
                {
                   commonLog.LogEntry("___ error", ex);


                }

            }
            return false;
        }


		public RectangleFSpec offsetBounds
		{
            get { return new RectangleFSpec((float)this.___offsetLeft, (float)this.___offsetTop, (float)this.___offsetWidth, (float)this.___offsetHeight); }
		}

		/// <summary>
		/// INTENAL Proprties CHtmlElement[,] TableCells
		/// Element.cells is table cells="5"
		/// </summary>
		public CHtmlElement[,] TableCells
		{
			get
			{
				return this.___tableCells;
			}
			set{this.___tableCells = value;}
		}
		/// <summary>
		/// INTENAL Proprties CHtmlElement[,] TableCells
		/// Element.cells is table cells="5"
		/// </summary>
		public CHtmlElement[] TableRows
		{
			get
			{
				return this.___tableRows;
			}
			set{this.___tableRows = value;}
		}
        public double layerX
        {
            get { return this.___layerX; }
            set { this.___layerX = value; }
        }
        public double layerY
        {
            get { return this.___layerY; }
            set { this.___layerY = value; }
        }



		/// <summary>
		/// offsetParent Retrieves a reference to the container object that defines the IHTMLElement::offsetTop and IHTMLElement::offsetLeft properties of the object. It it is hidden returns null.
		/// </summary>
		
		public CHtmlElement offsetParent
		{
			//set{this._offsetParent = value;}
			get{
				
                    CHtmlElement ___parentElelent = this.___getParentElement();
                    if (___parentElelent != null)
                    {
                     
                        if (___parentElelent.___IsElementVisible == true)
                        {
                            return ___parentElelent;
                        }

                    }
				
				return null;
			}
		}

		/*
		public PointF offsetParentPoint
		{
			set{this.___offfsetParentPoint = value;}
			___getInner{return this.___offfsetParentPoint;}
		}
		*/
        // [old class]
        /*
		public CHtmlParagraphDrawingList RenderingInformationList
		{
			set{this.___renderingInformationList .___complete= value;}
			___getInner{return this._RenderingInformationList;}
		}
         */

		
		public CHtmlBase parent
		{
            set { this.___parentWeakRef = new WeakReference(value, false ); }
			get
			{
				if(this.___parentWeakRef  != null)
				{
                    return (CHtmlBase)this.___parentWeakRef.Target;
				}
				else
				{
					if(this.___elementTagType == CHtmlElementType.HTML)
					{
						return this.___Document;
					}
				}
				return null;
			}
		}
		
        /// <summary>
        /// returns parentElement
        /// </summary>
		public CHtmlElement parentElement
		{
			
            get
            {
                if (this.___parentWeakRef == null)
                {
                    return null;
                }
                else
                {
                    return this.___parentWeakRef.Target as CHtmlElement;
                }
            }
		}
        private CHtmlElement ____getParentElementInner()
        {
            if (this.___parentWeakRef == null)
            {
                return null;
            }
            else
            {
                return this.___parentWeakRef.Target as CHtmlElement;
            }
        }
        /// <summary>
        /// parentNode can returns either CHtmlNode or CHtmlElement of parentElement.
        /// </summary>
        public CHtmlElement  parentNode
        {
            get {
                CHtmlElement _parentNodeObject = base.parentNode as CHtmlElement;
                if (_parentNodeObject != null)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel <= 5)
                    {
                        commonLog.LogEntry("element {0} property parentNode returns {1}", this, _parentNodeObject.ToString());
                    }
                }else
                {
           
                    _parentNodeObject = ____getParentElementInner();
                    if (commonLog.LoggingEnabled && commonLog.LogLevel <= 5)
                    {
                        commonLog.LogEntry("element {0} property base.parentNode is null, returns parentElement instead {1}", this, _parentNodeObject);
                    }
                    return _parentNodeObject;
                }
                return _parentNodeObject;
            
            }

        }
        internal void setParentNode(CHtmlNode _parentNode)
        {
            base.setParentNode(_parentNode);
        }

		/// <summary>
		/// Returns a reference parent form tag element
		/// </summary>
		public CHtmlElement form
		{
			get
			{
				CHtmlElement ___lookup = this;
				int LookupLimit = 4;
				int CurLookup = 0;
				while(___lookup != null)
				{
					if(___lookup.___elementTagType == CHtmlElementType.FORM )
					{
						return ___lookup;
					}
                    ___lookup = ___lookup.___getParentElement();
					if(CurLookup >= LookupLimit)
					{
						break;
					}
					CurLookup++;
				}
				return null;
			}
		}
		/// <summary>
		/// First Child will include #Text Node (Chrome and IE10 Default Behavior)
		/// </summary>
		public ICHtmlElementInterface  firstChild
		{
			get
			{

				if(this.___childNodes.Count > 0)
				{
					if(this.___firstChildWeakReference != null )
					{
						return this.___firstChildWeakReference.Target as CHtmlElement;
					}
					int baseChildCount = base.___childNodes.Count;
					for(int i = 0; i < baseChildCount; i ++)
					{
						CHtmlElement elem = base.___childNodes[i] as CHtmlElement;
                        if (elem == null)
                        {
                            continue;
                        }
						if(commonHTML.IsSystemHiddenElement(elem.___elementTagType) == false)
						{
							this.___firstChildWeakReference = new WeakReference(elem, false);
							return elem;
						}
						else
						{
							continue;
						}
					}
					return null;
				}
				else
				{
					return null;
				}
			}
		}
		private void ___ClearFirstChildWeakReference()
		{
			this.___firstChildWeakReference = null;
		}

	   
		/// <summary>
		/// last child include text node
		/// </summary>
		public ICHtmlElementInterface lastChild
		{
			get
			{
				if(this.___childNodes.Count > 0)
				{
					for(int i = this.___childNodes.Count -1 ; i >= 0 ; i --)
					{
						CHtmlElement elem = this.___childNodes[i] as CHtmlElement;
						if(elem.___elementTagType  != CHtmlElementType.COMMENT && (elem is CHtmlDTD) == false )
						{
							return elem;
						}
						else
						{
							continue;
						}
					}
					return null;
				}
				else
				{
					return null;
				}
			}
		}
		// It is internal use onlyso make it hidden
		/*
		public CHtmlElement ownerTableElement
		{
			set{this._ownerTableElement = value;}
			___getInner{return this._ownerTableElement;}
		}
		*/
        
		public CHtmlAttributeList attributes
		{
			get{return this.___attributes;}
		}
       
		public void clearAttributes()
		{
			if(this.___attributes != null)
			{
				this.___attributes.Clear();
			}
		}

		/*
		public CHtmlCollection textNodes
		{
			___getInner{return this._textNodes;}
		}
		*/

		/* ***********************************************************************************************
		 * Document all are not supported
		 * ***********************************************************************************************/
		/*
		public CHtmlCollection all
		{
			___getInner{return this._children;}
		}
		*/




		public void ResetScreenBounds()
		{
			//ResetScreenBounds(true, false);
		}
		


		

		/// <summary>
		/// Set or Retrieves an inline style sheet for the tag. not style="width:10px"
		/// </summary>
		public ICHtmlCSSStyleDeclaration style
		{
			

			get{return this.___style;}
		}
        public CHtmlCSSStyleSheet runtimeStyle
        {
            get { return this.___style; }
        }
		/// <summary>
		/// Set or Retrieves an inline style sheet for the tag. not style="width:10px"
		/// </summary>
		public CHtmlCSSStyleSheet stylesheet
		{
			get{return this.___style;}
		}
		/// <summary>
		/// Set or Retrieves an inline style sheet for the tag. not style="width:10px"
		/// </summary>
		public CHtmlCSSStyleSheet styleSheet
		{
			get{return this.___style;}
		}
		/// <summary>
		/// Set or Retrieves an inline style sheet for the tag. not style="width:10px"
		/// </summary>
	
		/*
		 * Note) Active style should be equal to Element.style
		/// <summary>
		/// Set or Retrieves an inline style sheet for the tag. not style="width:10px"
		/// </summary>
		public CHtmlCSSStyleSheet styleActive
		{
			set{this.___styleActive = value;}
			___getInner{return this.___styleActive;}
		}
		*/

		/// <summary>
		/// TagNameWithoutNameSpace G:PLUSONE -> PLUSONE
		/// </summary>
		public string tagNameNoNS
		{
			get{return commonHTML.___convertNullToEmpty(this.___tagNameNoNS);}
		}
		internal void ___SetTagNameOnly(string _sName)
		{
			base.___tagName = _sName;
		}

		public string tagName
		{
			set
			{
				string sValue = value;
                if (sValue.Length != 0)
                {
                    // Only Checks Last Char
                    char charLast = sValue[sValue.Length - 1];
                    if (charLast >= 'a' && charLast <= 'z')
                    {
                        sValue = commonHTML.FasterToUpper(sValue);
                    }
                }
                int posCoron = sValue.IndexOf(':');
				if(posCoron > -1 && posCoron +1 <= sValue.Length)
				{
					this.___tagNameNoNS = sValue.Substring(posCoron + 1);

				}
				else
				{
					this.___tagNameNoNS = sValue;
				}

				if(string.IsNullOrEmpty(sValue) == false && sValue.Length == 1 && sValue[0] == '*')
				{
					sValue = "ASTERISK";
				}
				base.___tagName = sValue;
				if(this.___Document !=null && this.___Document.___documentDomType == CHtmlDomModeType.XMLDOM)
				{
					base.___elementTagType = CHtmlElementType.UNKNOWN;
				}
				else
				{
					base.___elementTagType = commonHTML.GetTagNameType(sValue);
                    if (base.___elementTagType == CHtmlElementType.UNKNOWN)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("UNKOWN TAG {0} ", sValue);
                        }
                    }
                    else
                    {
                        this.___multiversalClassType = CHtmlElement.___getMultiversalObectTypeFromTagType(base.___elementTagType);
                    }
				}

				if(this.___elementTagType == CHtmlElementType.NOSCRIPT)
				{
					this.___IsNoScriptBlock = true;
					this.___IsElementVisible = false;
				}
				if(commonHTML.elementTagTypesHonorsCrlfSortedList.ContainsKey(this.___elementTagType) == true)
				{
					this.___AcceptsCrlf = true;
				}
				else
				{
					this.___AcceptsCrlf =false;
				}
				if(commonHTML.elementTagTypesPreserveWhiteSpacesCrlfSortedList.ContainsKey(this.___elementTagType) == true)
				{
					this.___IsPreserveWhiteSpacesCrlf = true;
				}
				else
				{
					this.___IsPreserveWhiteSpacesCrlf = false;
				}
                if (commonHTML.IsElemeneITextOrIDrawOrComment(this) == true)
                {
                    if (this.___elementTagType == CHtmlElementType.COMMENT)
                    {
                        this.___SetNodeType(CHtmlNodeType.COMMENT_NODE);
                    }
                    else if (this.___elementTagType == CHtmlElementType._ITEXT && this.___nodeType != CHtmlNodeType.TEXT_NODE)
                    {
                        this.___SetNodeType(CHtmlNodeType.TEXT_NODE);
                    }
                }
			}
			get {return base.___tagName;}
        }
        internal bool ___IsComplete;
        public bool complete
        {             
            get { return this.___IsComplete; }
        }

        public override string src
		{
			set
			{
                bool ___isSrcAltered = false;
				string ___oldsrc;
                if (string.IsNullOrEmpty(base.___src) == false)
                {
                    ___oldsrc = base.___src;
                    ___isSrcAltered = true;
                }
                else
                {
                    ___oldsrc = "";
                }
                if (value == null)
                {
                    base.src = "";
                }
                else
                {
                    base.src = value;

                    if(commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                        {
                        commonLog.LogEntry($"{this.toLogString()} .src set to {value}");
                    }

                    ___isSrcAltered = true;
                }
#if DEBUG
                if (this.___Document != null && this.___elementTagType  == CHtmlElementType.IMG)
                {
                    if (this.___isCalculateElementBoundsCalled == true)
                    {
                       commonLog.LogEntry("src ___hasInner alstered");
                    }
                }
#endif
                if (string.IsNullOrEmpty(base.___src) == false && base.___src.IndexOf("\\/",StringComparison.OrdinalIgnoreCase) > -1)
                {

                    base.___src = base.___src.Replace("\\/", "/");
                }

                if (this.___attributes.ContainsKey("src") == false)
                {
                    CHtmlAttribute srcAttribute = new CHtmlAttribute();
                    srcAttribute.name = "src";
                    srcAttribute.setParentNode(this);
                    if (string.IsNullOrEmpty(base.___src) == false)
                    {
                        srcAttribute.value = base.___src;
                    }
                    else
                    {
                        srcAttribute.value = "";
                    }
                    this.___attributes["src"] = srcAttribute;
                }
                else
                {
                    CHtmlAttribute __storedSrc = null;
                    if (this.___attributes.TryGetValue("src", out __storedSrc) == true)
                    {
                        if (__storedSrc != null)
                        {
                            if (string.Equals(__storedSrc.value as string, base.___src, StringComparison.Ordinal) == false)
                            {
                                __storedSrc.value = base.___src;
                            }
                        }
                    }
                }
                // it src is "#" it does not process any more
                if(string.IsNullOrEmpty(base.___src) == false && base.___src.Length == 1 && base.___src[0] == '#')
                {
                    if (this.___srcBase != null && string.IsNullOrEmpty(this.___srcBase.Href) == false)
                    {
                        this.___srcBase.Href = "";
                    }
                    return;
                }

                if (this.___srcBase != null && string.IsNullOrEmpty(base.___src) == false)
				{
                    if (this.___Document != null)
                    {
                        this.___srcBase.href = commonHTML.GetAbsoluteUri(this.___Document.___URL, this.___Document.___baseUrl, base.___src);
                        if (this.___elementTagType == CHtmlElementType.IFRAME || this.___elementTagType == CHtmlElementType.FRAME)
                        {
                            if (string.Equals(this.___locationBase.href, this.___srcBase.href, StringComparison.Ordinal) == false)
                            {
                                this.___locationBase.___CopyValuesFromCHtmlUri(this.___srcBase);
                               
                            }
                        }
                        if (___oldsrc.Length > 0 && string.Equals(___oldsrc, base.___src, StringComparison.Ordinal) == false)
                        {
                            if (this.___elementTagType == CHtmlElementType.IMG || this.___elementTagType == CHtmlElementType.INPUT)
                            {
                                if (this.___style.___IMG_ImageWeakReference != null)
                                {
                                    this.___style.___IMG_FullURL = "";
                                    this.___style.___IMG_ImageWeakReference = null;
                                    this.___style.___IMG_FullURL = this.___srcBase.___Href;
                                }
                            }
                        }
                    }
                    else
                    {
                        // We dont have document reference but we should build src href based upon url
                        if (string.IsNullOrEmpty(base.___src) == false && base.___src.IndexOf(':') > -1)
                        {
                            this.___srcBase.href = string.Copy(base.___src);
                            if (this.___elementTagType == CHtmlElementType.IFRAME || this.___elementTagType == CHtmlElementType.FRAME)
                            {
                                if (string.Equals(this.___locationBase.href, this.___srcBase.href, StringComparison.Ordinal) == false)
                                {
                                    this.___locationBase.___CopyValuesFromCHtmlUri(this.___srcBase);
                                }
                            }
                        }
                    }
					
				}
                if (this.___IsElementPrefetchDummy == true)
                {
                    return;
                }
				if(this.___Document != null)
				{
					if(string.IsNullOrEmpty(base.___src) == false)
					{

						string __srcFullUrl = this.___srcBase.___Href;
						if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
						{
							commonLog.LogEntry("{0}.src {1} => {2}", this, ___oldsrc, __srcFullUrl);
						}

                        try
                        {
                            switch (this.___elementTagType)
                            {
                                case CHtmlElementType.FRAME:
                                case CHtmlElementType.IFRAME:


                                    if (string.Equals(___oldsrc, base.src, StringComparison.Ordinal) == false)
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                        {
                                            commonLog.LogEntry("{0} is src ___hasInner been altered but control is not main document", this);
                                        }
                                    }
                                    return;
                                                                              
                                case CHtmlElementType.IMG:
                                    {
                                        if (this.___elementTagType == CHtmlElementType.IMG && this.___IsDynamicElement)
                                        {
                                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                            {
                                                commonLog.LogEntry($"{this.toLogString()}  src : {this.___src} is DynaimicElement and Image.src has been altered");
                                            }
                                            var imgCache = CHmlMultiversalWebCache.getMultiversalContentDataSync(this.___srcBase.href, null);
                                            if (imgCache != null)
                                            {
                                                this.___Document.___setDocumentUrlImage(__srcFullUrl, imgCache);
                                                this.___complete = true;
                                            }
                                            // onload handler (property or attribute)
                                            object elementSrcScriptHandler = null;
                                            if (this.___attributes != null && this.___attributes.TryGetValue("onload", out var ___loadfunction) && ___loadfunction != null)
                                            {
                                                elementSrcScriptHandler = ___loadfunction.value;
                                            }
                                            else
                                            {
                                              if(this.___ElementLoadFunctionWeakReference != null)
                                                {
                                                    elementSrcScriptHandler = this.___ElementLoadFunctionWeakReference.Target;
                                                }
                                            }
                                            if (elementSrcScriptHandler != null && this.___complete == true)
                                            {
                                                try
                                                {
                                                    bool isFunction = false;
                                                    var scriptObj = elementSrcScriptHandler as Microsoft.ClearScript.ScriptObject;
                                                    if (scriptObj != null)
                                                    {
                                                        isFunction = scriptObj.GetProperty("call") != null;
                                                    }
                                                    else if (elementSrcScriptHandler is Delegate || elementSrcScriptHandler is System.Dynamic.DynamicObject)
                                                    {
                                                        isFunction = true;
                                                    }else if(elementSrcScriptHandler != null &&
    elementSrcScriptHandler.GetType().FullName == "Microsoft.ClearScript.V8.SplitProxy.V8ObjectImpl")
                                                    {
                                                        isFunction = true;
                                                    }
                                                    else
                                                    {
                                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                                        {
                                                            commonLog.LogEntry($"IMG onload handler is not function, type : {elementSrcScriptHandler.GetType().FullName}");
                                                        }
                                                    }
                                                   
                                                    if (isFunction)
                                                    {
                                                        try
                                                        {
                                                            // Try the normal execution path first. If the script engine
                                                            // rejects cross-thread invocation this may throw; fall back
                                                            // to invoking via the script processor if available.
                                                            this.___Document.___window.___executeElementEventFunction("onload", this, elementSrcScriptHandler, new object[] { });
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            // Log and attempt a safer invocation via the processor API
                                                            try
                                                            {
                                                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                                                {
                                                                    commonLog.LogEntry($"IMG onload direct invoke failed, attempting processor.callfunction: {ex.Message}");
                                                                }
                                                            }
                                                            catch { }

                                                            try
                                                            {
                                                                var wnd = this.___Document?.___window;
                                                                if (wnd != null && elementSrcScriptHandler != null)
                                                                {
                                                                    // Try to obtain a script processor that can call the function.
                                                                    try
                                                                    {
                                                                        var proc = wnd.getMultiversalScriptProcessorByScriptObjectType(elementSrcScriptHandler.GetType());
                                                                        if (proc != null)
                                                                        {
                                                                            // callfunction should route through ClearScriptProcessor and handle invocation
                                                                            proc.callfunction(elementSrcScriptHandler, new object[] { });
                                                                        }
                                                                        else
                                                                        {
                                                                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                                                            {
                                                                                commonLog.LogEntry("IMG onload: no suitable script processor found for fallback invocation.");
                                                                            }
                                                                        }
                                                                    }
                                                                    catch (Exception ex2)
                                                                    {
                                                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                                                        {
                                                                            commonLog.LogEntry($"IMG onload processor.callfunction failed: {ex2.Message}");
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            catch { }
                                                        }
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                                    {
                                                        commonLog.LogEntry($"IMG onload handler invoke failed: {ex.Message}");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;


                            }

                   
                        }
                     







                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                            {
                                commonLog.LogEntry("Element.src handling exception", ex);
                            }
                        }
					}	
				}
				else
				{

				}
            

            }
			get
			{
                return commonHTML.___convertNullToEmpty(base.___src);
			}

		}
		public void normalize()
		{
			// 1) first check all nodes are text node
			bool __IsChildAllText = true;
			int  __ChildCount = 0;
			__ChildCount = this.___childNodes.Count;
			for(int i = 0; i < __ChildCount; i ++)
			{
				CHtmlElement ele = this.___childNodes[i] as CHtmlElement;
				if(ele.___elementTagType == CHtmlElementType._ITEXT)
				{
					__ChildCount ++;
					continue;
				}
				else
				{
					__IsChildAllText = true;
					break;
				}
			}
			if( __IsChildAllText && __ChildCount > 0)
			{
				System.Text.StringBuilder sbText =new System.Text.StringBuilder();
				for(int i = 0; i < __ChildCount; i ++)
				{
					CHtmlElement ele = this.___childNodes[i] as CHtmlElement;
					if(ele.___elementTagType == CHtmlElementType._ITEXT)
					{
						sbText.Append(ele.value);
						if(i > 0)
						{
							this.___childNodes.Remove(ele);
						}
					}
				}
				if(__ChildCount > 0)
				{
					CHtmlElement ele = this.___childNodes[0] as CHtmlElement;
					if(ele != null)
					{
                        ele.___drawingObjectList = new System.Collections.Generic.List<CHtmlDrawingObject>();
						ele.value = sbText.ToString();
						ele.___isCalculateElementBoundsCalled = false;
					}
				}
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("normalize() done");
				}
			}
			else
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("normalize() skip");
				}
			}
			
		}
		
		public string target
		{
			set
			{
				this.SetGetAttributesByName("target", value, true);
			}
			get
			{
				return this.SetGetAttributesByName("target", null, false) as string;
			}
		}

        public void doScroll()
        {
            this.doScroll_Inner(null);
        }
        public void doScroll(object _args)
        {
            this.doScroll_Inner(_args);
        }
        private void doScroll_Inner(object _args)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("Element doScroll() skip");
            }
        }
		
		public new string href
		{
			set
			{

				string __oldHref = string.Copy(base.href);
                if (value == null)
                {
                    base.href = "";
                }
                else
                {

                    base.href = string.Copy(value);
                }
                if (string.Equals(__oldHref, base.href,StringComparison.Ordinal) == true)
                {
                    return;
                }
                if (base.href.IndexOf("\\/", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    /*
                    http:\\/\\/l3.yimg.com\\/nn\\/fp\\/rsz\\/111313\\/images\\/smush\\/Snapchat_635x250_1384379248.jpg\\\" class=\\\"fptoday-img\\\" alt=\\\"Company rejects $3 billion offer from Facebook (AP)\\\" title=\\\"Company rejects $3 billion offer from Facebook (AP)\\\" width=\\\"635\\\" height=\\\"250\\\"
                    */
                    base.href = base.href.Replace("\\/", "/");
                }
                if (this.___attributes.ContainsKey("href") == false)
                {
                    CHtmlAttribute hrefAttribute = new CHtmlAttribute();
                    hrefAttribute.name = "href";
                    hrefAttribute.value = string.Copy(base.href);
                    hrefAttribute.setParentNode(this);
                    this.___attributes["href"] = hrefAttribute;
                }
                else
                {
                    CHtmlAttribute __storedHref = null;
                    if (this.___attributes.TryGetValue("href", out __storedHref))
                    {
                        if (__storedHref != null)
                        {
                            if (string.Equals(base.href, __storedHref.value as string, StringComparison.Ordinal) == false)
                            {
                                __storedHref.value = string.Copy(base.href);
                            }
                        }
                    }
                }
                // =======================================================================================
                // Single "#" href will be ignored
                // =======================================================================================
                if (base.href.Length == 1 && base.href[0] == '#')
                {
                    if (this.___hrefBase != null && string.IsNullOrEmpty(this.___hrefBase.href) == false)
                    {
                        this.___hrefBase.href = "";
                    }
                    return;
                }
				if(this.___hrefBase != null && this.___Document != null)
				{
					this.___hrefBase.href =  commonHTML.GetAbsoluteUri(this.___Document.___URL, this.___Document.___baseUrl, base.href);
				}
				else
				{
					// ===============================================================
					// following may not occur. but just in case
					// ===============================================================
                    int posSlash = base.href.IndexOf(':');
					if(posSlash > -1)
					{
						string __PartScheme = base.href.Substring(0, posSlash);
						if(__PartScheme .Length != 0)
						{
							switch(__PartScheme)
							{
								case "https":
								case "http":
								case "ftp":
								case "file":
								case "about":
								case "mailto":
								case "javascript":
								case "data":
	
									this.___hrefBase.href = string.Copy(base.href);
									break;
									
								default:
									this.___hrefBase.href = "";
									break;
							}
						}
					}
				}
			}
			get
			{
				return base.href;
			}
		}
		public string html
		{
			set{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("HTML :: {0}", value);
				}
			}
			get{return "";}
		}
		
		public string rel
		{
			set
			{
				this.SetGetAttributesByName("rel", value, true);
			}
			get
			{
				if(this.___attributes.ContainsKey("rel") == false)
					return "";

				string ret = this.SetGetAttributesByName("rel", null, false) as string;
				if(ret == null)
				{
					return "";
				}
				return ret;
			}
		}





        internal void ___createCaseSensitiveElementNames(string ___strSensitive)
        {
            this.___elementTagNameWithNSCaseSensitive = ___strSensitive;
            if (string.IsNullOrEmpty(this.___elementTagNameWithNSCaseSensitive) == false)
            {
                int posDoubleColum = this.___elementTagNameWithNSCaseSensitive.IndexOf(':');
                if (posDoubleColum > -1)
                {
                    this.___elementNameSpaceCaseSensitive = this.___elementTagNameWithNSCaseSensitive.Substring(0, posDoubleColum);
                    if (posDoubleColum + 1 < this.___elementTagNameWithNSCaseSensitive.Length)
                    {
                        this.___elementTagNameCaseSensitive = this.___elementTagNameWithNSCaseSensitive.Substring(posDoubleColum + 1);
                    }
                }
                else
                {
                    this.___elementTagNameCaseSensitive = this.___elementTagNameWithNSCaseSensitive;
                }
            }
        }


		public string innerText
		{
			get
			{
                try
                {

                    if (this.___ElementVersion == CHtmlVersionType.Version1)
                    {
                        //this.ComposeInnnerText();
                    }
                    if (base.___childNodes == null)
                    {
                        return "";
                    }
                    System.Text.StringBuilder sbText = new System.Text.StringBuilder();
                    switch (this.___ElementVersion)
                    {

                        case CHtmlVersionType.Version1:
                        case CHtmlVersionType.Version3:
                            if (base.___childNodes.Count > 0)
                            {
                                if (this.___previousChildCount == base.___childNodes.Count)
                                {
                                    return this.___previousInnerText;
                                }
                                int baseChildCount = base.___childNodes.Count;
                                for (int i = 0; i < baseChildCount; i++)
                                {
                                    CHtmlElement element = base.___childNodes[i] as CHtmlElement;
                                    if (element != null)
                                    {
                                        if (commonHTML.IsElemeneITextOrIDraw(element) == true)
                                        {
                                            sbText.Append(element.value);
                                        }
                                        else
                                        {
                                            //sbText.Append(element.innerText);
                                        }
                                    }
                                }
                                this.___previousChildCount = baseChildCount;
                            }
                            else if (base.@value != null)
                            {
                                return commonHTML.GetStringValue(base.@value);
                            }
                            break;
                    }
                    ___previousInnerText = sbText.ToString();
                    return ___previousInnerText;
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("___getInner innerText Exception ",ex);
                    }
                }
                return "";
			}
			set
			{
				


				this.___childNodes.Clear();
				this.___drawingObjectList.Clear();
				CHtmlTextElement  textElement = new CHtmlTextElement();
				textElement.___elementTagType = CHtmlElementType._ITEXT;
				textElement.___IsDynamicElement = true;
				textElement.@value = value;
                textElement.___parentWeakRef = new WeakReference(this, false);
				this.___appendChildInner(textElement);

				/*
				CHtmlParagraph pInfo = new CHtmlParagraph();
				pInfo.Text = value;
				pInfo.DocumentElementIndex = this.DocumentElementIndex;
				pInfo.tagName = this.tagName;
				pInfo.___elementTagType = this.___elementTagType;
				pInfo.element = this;
				//this._InnerParagraphList.Add(pInfo);
				if(this.___Document != null && this.___Document.IsRenderingHasStarted)
				{
					if(Array.IndexOf(commonTagsForNonSentence, this.tagName) == -1)
					{
						Unicus.CHtmlGraphicContainer _grCon = this.___Document.window.CreateGraphicContainer();
						_grCon.IsUIThreadPaint = false;
						if(this.RenderingInformationList != null)
						{
							this.RenderingInformationList.Clear();
						}
						this.RenderingInformationList = null;
					
						//	SizeF sizeF = this.___Document.MeasureAndDrawChildSentences(this, this.___offsetWidth, false, ref _grCon, false);
						SizeF sizeF = SizeF.Empty;
						if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
						{
						commonLog.LogEntry("Called MeasureAndDrawChildSentences : {0} : {1}", sizeF, value);
						}
						if(this.IsDrawDone == true && this.ManagedControlHandle == IntPtr.Zero)
						{
					
							commonLog.LogEntry("Calling DrawTagElement");
							//this.___Document.DrawTagElement(this,ref _grCon, true);
							this.RenderingInformationList.EnableChilrenLayoutTagDrawing = false;
							this.RenderingInformationList.Draw(ref _grCon);
							this.RenderingInformationList.EnableChilrenLayoutTagDrawing = true;
						
						}
						if(this.___offsetWidth < (int)sizeF.Width)
						{
							this.___offsetWidth = (int)sizeF.Width;
						}
						if(this.___offsetHeight < (int)sizeF.Height)
						{
							this.___offsetHeight = (int)sizeF.Height;
						}
						_grCon.Dispose(true);
					}
					
				}
				*/
				//base.@value = value;
			}
		}




		


		public RectangleFSpec offsetScreenBounds
		{
			get{return new RectangleFSpec(this.___offfsetParentPoint.X , this.___offfsetParentPoint.Y,(float)this.___offsetWidth, (float)this.___offsetHeight);}
		}
		public PointFSpec GetScreenPointFromTotalParentOffsetBounds()
		{
            
			if(this.___isElementPositionAbsoluteOrStatic == true)
			{
				int __x = commonHTML.GetIntValueFromString(this.___style.Left, 1000);
				int __y =  commonHTML.GetIntValueFromString(this.___style.Top, 1000);
				this.___offfsetParentPoint = new PointFSpec(__x, __y);
				return this.___offfsetParentPoint;
			}


            if (this.___IsElementofffsetParentPointCaluculationRequired == false)
            {
                if (this.___offfsetParentPoint.X != commonHTML.MinusPoint.X && this.___offfsetParentPoint.Y != commonHTML.MinusPoint.Y)
                {
                    return this.___offfsetParentPoint;
                }

            }
            else
            {
                this.___offfsetParentPoint = new PointFSpec(0, 0);
                CHtmlElement ___parent = this.___parent as CHtmlElement;
                while (___parent != null)
                {
                    this.___offfsetParentPoint.X += (float)___parent.___offsetLeft;
                    this.___offfsetParentPoint.Y += (float)___parent.___offsetTop;
                    if (___parent.___isElementPositionAbsoluteOrStatic)
                    {
                        //break;
                    }
                    ___parent = this.___parent as CHtmlElement;
                }
                if (this.___documentWeakRef != null)
                {
                    CHtmlDocument __doc = this.___getDocument();
                    if (__doc.___BodyElementBounds.Height < this.___offfsetParentPoint.Y + this.___offsetHeight)
                    {
                        __doc.___BodyElementBounds.Height = (float)(this.___offfsetParentPoint.Y + this.___offsetHeight);

                    }
                    if (__doc.___BodyElementBounds.Width < this.___offfsetParentPoint.X + this.___offsetWidth)
                    {
                        __doc.___BodyElementBounds.Width = (float)(this.___offfsetParentPoint.X + this.___offsetWidth);
                    }
                }
            }

                return this.___offfsetParentPoint;

            }
        /*
		public PointF GetMaxBoundsOfChildElement(int __LookupChildrenCount, int __Depth, ref PointF curMax)
		{
			if(__Depth > 500)
			{
				commonLog.LogEntry("{0} ___hasInner been called GetMaxBoundsOfChildElement {1}", this, __Depth);
				return curMax;
			}
			System.Drawing.RectangleF rectScreen = this.___offsetScreenBounds;
			if(curMax.X < rectScreen.X + rectScreen.Width)
			{
				curMax.X = rectScreen.X + rectScreen.Width;
			}
			if(curMax.Y < rectScreen.Y + rectScreen.Height)
			{
				curMax.Y = rectScreen.Y + rectScreen.Height;
			}
			for(int i = this.children.Count -1 ; i >= 0; i --)
			{
				CHtmlElement cElement = this.children[i] as CHtmlElement;
				if(cElement != null)
				{
					__Depth ++;
					curMax = cElement.GetMaxBoundsOfChildElement(__LookupChildrenCount, __Depth, ref curMax);
					__Depth --;
					if(this.children.Count - i > __LookupChildrenCount)
					{
						break;
					}
				}
			}
			return curMax;
		}
		*/

            /// <summary>
            /// AppendCharByIndex Only Store Character Index, not by characer
            /// </summary>
            /// <param name="_Pos"></param>
            /// <param name="__c"></param>
        internal void AppendCharByIndex(int _Pos, char __c)
		{

		}
		/// <summary>
		/// AppendCharByIndex Only Store Character Index, not by characer
		/// </summary>
		/// <param name="_Pos"></param>
		/// <param name="__c"></param>
		internal void ___AppendChar(int pos, char __c)
		{
			return;
			/*
			try
			{
				if(this.___AcceptsCrlf == false)
				{
					if(Array.IndexOf(commonCharCrLfTab, __c) > -1)
					{
						return;
					}
				}
				this._InnerCharList.Add(pos, __c);
			} 
			catch
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("AppendChar({0}, {1}) Failed ", pos, __c);
				}
			}
			*/
		}

        /*
		internal int CreateTextRangeBasedUponAppendedChars(int ___docpos)
		{
			try
			{
				if(this._InnerCharList.Count > 0)
				{

					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					int AppendFirstPos = -1;
					int[] _Keys = new int[this._InnerCharList.Keys.Count];
					this._InnerCharList.Keys.CopyTo(_Keys,0);
					int _keyLen = _Keys.Length;
					for(int i = 0; i < _keyLen; i ++)
					{
						int key = _Keys[i];
						if(this._LastInnerTextRangeCreatedPos > 0)
						{
							if(key < this._LastInnerTextRangeCreatedPos)
							{
								continue;
							}
						}
						char c = (char)this._InnerCharList[key];
						if(c == '&')
						{
							int _LookupCharMax = 20;
							System.Text.StringBuilder sbSpecial = new System.Text.StringBuilder();
							int _KeysLen = _Keys.Length;
							for(int _Lookup = i ; _Lookup < _KeysLen ; _Lookup ++)
							{
								int _LookupKey = _Keys[_Lookup];
								char spChar = (char)this._InnerCharList[_LookupKey];
								if(spChar == '(' || spChar == ' ' || spChar == '=')
								{
									break;
								}
								else if(spChar == '&')
								{
									if(sbSpecial.Length >= 1)
									{
										break;
									}
								}

								sbSpecial.Append(spChar);
								if(sbSpecial.Length > 0 && sbSpecial[sbSpecial.Length -1] == ';')
								{
									char cnew = commonGetHTMLCharStringHTMLString(sbSpecial.ToString(), '\x0');
									if(cnew != '\x0')
									{
										c = cnew;
										i = _Lookup;
										break;
									}
									else
									{
										break;
									}
								}
								if(_Lookup - key>= _LookupCharMax)
								{
									break;
								}
							}
						}
						if(AppendFirstPos  == -1)
						{
							AppendFirstPos = key;
						}
						sb.Append(c);
					}
					if(this.___IsElementBlock == true || this.___elementTagType != CHtmlElementType.PRE || this.___elementTagType != CHtmlElementType.CODE)
					{
						commonStringBuilderTrim(ref sb);
					}
					if(sb.Length > 0)
					{
						this._LastInnerTextRangeCreatedPos = ___docpos;
						if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
						{
							//commonLog.LogEntry("{0} {1}", this, sb.ToString());
						}
						CHtmlTextElement textElement = new CHtmlTextElement();
						textElement.___Document = this.___Document;
						textElement.___parent = this;
                        textElement.___SetTagNameOnly("#TEXT");
						textElement.___elementTagType = CHtmlElementType._ITEXT;
						textElement.___DocumentElementIndex = this.___DocumentElementIndex;
						textElement.___IsElementBlock = false;
						textElement.___isCalculateElementBoundsCalled = false;
						textElement.value = sb.ToString();
						textElement.___TagOpenStartPosition = AppendFirstPos;
						textElement.___TagOpenEndPosition = AppendFirstPos;
						textElement.___TagCloseEndPosition   = ___docpos;
						textElement.___TagCloseStartPosition = ___docpos;
						int pos = this.___childNodes.Add(textElement);
                        this.___setElementCriticalPropertiesChildNode(textElement);
						textElement.___ChildNodeIndex = pos;
						return pos;
					}
				}
			} 
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("CreateTextRangeBasedUponAppendedChars", ex);
				}
			}
			return -1;
		}
 
*/
		/*
		public int CreateTextRangeForBR(int ___docpos)
		{
			CHtmlTextElement textElement = new CHtmlTextElement();
			textElement.parent = this;
			textElement.tagName = "TEXT";
			textElement.___Document = this.___Document;
			textElement.DocumentElementIndex = this.DocumentElementIndex;
			textElement.___IsElementBlock = false;
			textElement.IsCalculateElementBoundsCalled = false;
			textElement.PlainText = "\r";
			textElement.TagOpenStartPosition = ___docpos;
			textElement.TagOpenEndPosition = ___docpos;
			textElement.TagCloseEndPosition   = ___docpos;
			textElement.TagCloseStartPosition = ___docpos;
			return this._textNodes.Add(textElement);
		}*/

		/// <summary>
		/// Precheck newchild's parent 
		/// </summary>
		/// <param name="__newchild"></param>
		private CHtmlElement ___PreCheckAppendingNodeParentExistance(CHtmlElement __newchild)
		{
			bool _____IsParentRemoved = false;
			bool _____IsDocumentIndexRemoved = false;
			CHtmlElement returningElement = null;
            
			if(__newchild == null)
				return __newchild;
            if (__newchild.___IsMainDocumentNodeElement == false)
            {
                __newchild.___parentWeakRef  = null;
                return __newchild;
            }
            if (__newchild.___isInactivativeElementNodeChild == true)
            {
                __newchild.___parentWeakRef  = null;
                return __newchild;
            }
			try
			{
                CHtmlElement __parentElement = __newchild.___parent as CHtmlElement;
				if(__parentElement == null)
					return __newchild;
				if(object.ReferenceEquals(__parentElement, this))
				{
					// appending parent is identical to this node. It is ok
					return __newchild;
				}
				
			
				/*
				int __childIndex = __parentElement.children.IndexOf(__newchild);
				if(__childIndex > -1)
				{
					__parentElement.children.RemoveAt(__childIndex);
					_____IsParentRemoved  = true;


				}
				else
				{
					_____IsParentRemoved = false;
				}
				*/
                if (__parentElement.___childNodes.Count > 0)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("New Node parent diffent from targetNode. Remove Reference...", __newchild, __parentElement, _____IsParentRemoved, _____IsDocumentIndexRemoved);
                    }
                    /*
                    for (int x = __parentElement.children.Count - 1; x >= 0; x--)
                    {
                        CHtmlElement ___childElement = __parentElement.children[x] as CHtmlElement;

                        if (___childElement != null && object.ReferenceEquals(___childElement, __newchild) == true)
                        {
                            _____IsParentRemoved = true;
                            ___childElement.___IsElementRemoved = true;
                            __parentElement.children.RemoveAt(x);
                            returningElement = __newchild.___cloneNodeInner(false);
                            continue;
                        }
                    }
                     */
                    if (__parentElement.___childNodes.___containsObjectHash(__newchild.GetHashCode()) == true)
                    {
                        __parentElement.___childNodes.Remove(__newchild);
                    }
                }
				if(__newchild.___ChildNodeIndex > -1)
				{

				}
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
				{
					commonLog.LogEntry("New Element '{0}' ___hasInner parent assigned {1} PreChec Result ParentRemove: {2} Document Remove : {3}", __newchild, __parentElement,  _____IsParentRemoved, _____IsDocumentIndexRemoved);
				}
			}
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
				{
					commonLog.LogEntry("___PreCheckAppendingNodeParentExistance", ex);
				}
			}
			if(returningElement == null)
			{
				return __newchild;
			}
			else
			{
				return returningElement;
			}
		}

		/// <summary>
		/// DHTML appendChild() Function 
		/// </summary>
		/// <param name="child">oNode Required. Object that specifies the element to append.</param>
		/// <returns>Returns a reference to the element that is appended to the object.</returns>
		internal CHtmlElement ___appendChildInner(CHtmlElement __appendingChild)
		{
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("entering {0} ___appendChildInner({1})", this, __appendingChild );
            }

            CHtmlElement __newchild = null;
            if(__appendingChild == null)
            {
                throw new InvalidOperationException("___appendChild is called with null");
            }
            if (this.___childNodes.Count > commonHTML.MAX_ELEMENT_APPENDCHILD_COUNT)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                {
                   commonLog.LogEntry("{0}.appendChild() exceeds the limit. abort now.", this, this.___childNodes.Count);
                }
                throw new System.OverflowException("appendChild() exceeds system limit : " + commonHTML.MAX_ELEMENT_APPENDCHILD_COUNT.ToString());
            }

			if( __appendingChild == null)
			{
				return null;
			}
            
            
			// ------------------------------------------------------------------------
			// The Appending Node may be static node. in that case, make clone
			// ------------------------------------------------------------------------
            if (object.ReferenceEquals(__appendingChild, this) == false)
            {
                if (__appendingChild.___parentWeakRef != null)
                {
                    __newchild = ___PreCheckAppendingNodeParentExistance(__appendingChild);
                }
                else
                {
                    __newchild = __appendingChild;
                }
			}
			else
			{
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                {
                   commonLog.LogEntry("insertBefore to the same node. make shallow clone.");
                }
				__newchild = __appendingChild.cloneNode(false);
			}
            
            if (__newchild.___elementTagType == CHtmlElementType._DOCUMENT_FRAGMENT)
            {
                this.___appendOrInsertChildRange(__newchild.___childNodes, false, -1);
                return __newchild;
            }



            if (__newchild.___parentWeakRef == null || object.ReferenceEquals(__newchild.___parentWeakRef.Target, this) == false)
			{
                __newchild.___parentWeakRef = new WeakReference(this, false);
                goto AfterParentElementWeakRefCreation;
			}
            if (__newchild.___parentWeakRef == null)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                {
                   commonLog.LogEntry("strange parent is null : {0}" , __newchild);
                }
            }
            AfterParentElementWeakRefCreation:
            if (this.___elementTagType == CHtmlElementType._DOCUMENT_FRAGMENT || this.___isInactivativeElementNodeChild == true)
            {
                __newchild.___isInactivativeElementNodeChild = true;
                if (this.___DocumentHiddenWeakReference != null && __newchild.___DocumentHiddenWeakReference == null)
                {
                    __newchild.___DocumentHiddenWeakReference = this.___DocumentHiddenWeakReference;
                }
                if (__newchild.___documentWeakRef == null && this.___documentWeakRef != null)
                {
                    __newchild.___documentWeakRef = new WeakReference(this.___documentWeakRef.Target, false);
                }
                else if (object.ReferenceEquals(__newchild.___documentWeakRef.Target , this.___documentWeakRef.Target) == false)
                {
                    __newchild.___documentWeakRef = new WeakReference(this.___documentWeakRef.Target, false);
                }
            }
            else
            {
                if (__newchild.___isInactivativeElementNodeChild == true)
                {
                    __newchild.___isInactivativeElementNodeChild = false;
                }
            }
            if (__newchild.___isInactivativeElementNodeChild == false)
            {
                
                if (__newchild.___Document == null || object.ReferenceEquals(__newchild.___Document, this.___Document) == false)
                {
                    __newchild.___documentWeakRef = new WeakReference(this.___Document, false);
                    __newchild.___ChildNodeIndex = -1;

                    
                }
                if (this.___Document != null && (__newchild.___elementTagType == CHtmlElementType.BODY || __newchild.___elementTagType == CHtmlElementType.HEAD))
                {
                    this.___Document.___CheckDynamicallyCreatedHeadBodyElementValidForDocument(__newchild);
                }
            }
     
			if(__newchild.___elementTagType == CHtmlElementType.COMMENT)
			{
				//this.InnerParagraphList.Clear();
				int pos = this.___childNodes.Add(__newchild);
                this.___setElementCriticalPropertiesChildNode(__newchild);
				__newchild.___ChildNodeIndex = pos;
				if(__newchild.___elementTagType == CHtmlElementType.COMMENT)
				{
					__newchild.___IsElementVisible = false;
				}
		
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("appendChild as TextNode called {0}  ", __newchild.ToString());
				}
				___ReConfirmElementVisibility(__newchild);
				__newchild.___IsDynamicProcessDone = true;
				__newchild.___isCalculateElementBoundsCalled = true;
				return __newchild;
			}
			else
			{
				__newchild.___ClosedReson = CHtmlTagClosedReasonType.Direct;
				string strREL = __newchild.rel;
                if (__newchild.___isInactivativeElementNodeChild == false)
                {
                    if (this.___Document != null && this.___Document.___IsDomModeFullParseMode() == true)
                    {
                        CHtmlElement.___PreProcessNewlyCreateNode(__newchild);
                    }
                }

				bool ___Monitored = false;

                try
                {
                    if (System.Threading.Monitor.TryEnter(this.___childNodes.SyncRoot, 1000))
                    {
                        ___Monitored = true;

                        __newchild.___ChildNodeIndex = this.___childNodes.Add(__newchild);
                        this.___setElementCriticalPropertiesChildNode(__newchild);
                    }
                }
                finally
                {
                    if (___Monitored)
                    {
                        System.Threading.Monitor.Exit(this.___childNodes.SyncRoot);
                    }
                }
                
				if(this.___Document != null && this.___Document.___IsDomModeFullParseMode() == true)
				{
					int __StackDepth = 0;
					bool DoNotProcessAfterProcessHTMLElement  = false;
					if(this.___elementTagType == CHtmlElementType.HEAD)
					{
						if(__newchild.___elementTagType == CHtmlElementType.SCRIPT)
						{
							if(__newchild.src.Length != 0)
							{
								if(this.___Document.___PageRequestedUrlList.ContainsKey(__newchild.src) == true)
								{
									if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
									{
										commonLog.LogEntry("PageRequestedUrlList ___hasInner same src, execute will stop");
									}
									DoNotProcessAfterProcessHTMLElement = true;
									__newchild.___IsDynamicProcessDone = true;
									__newchild.___IsElementVisible = true;
									__newchild.___isCalculateElementBoundsCalled = true;

								}
								else
								{
									if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
									{
										commonLog.LogEntry("HEAD does not have same Script src : \"{0}\"", __newchild.src);
									}
                                    if (this.___Document.___IsDomModeFullParseMode() == true && __newchild.___IsMainDocumentNodeElement == false)
                                    {
                                        __newchild.___IsMainDocumentNodeElement = true;
                                    }
								}
							}
						}
					}
                    if (__newchild.___IsMainDocumentNodeElement  == true && this.___Document.___IsDomModeFullParseMode())
                    {
                        if (DoNotProcessAfterProcessHTMLElement == false)
                        {
                            this.___Document.___postprocessDynamicElementCHtmlElement(__newchild, ref __StackDepth);
                        }
                    }
				}
			}
			___ReConfirmElementVisibility(__newchild);
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("{0} ___hasInner processed appendChildInner({1}) at {2}", this.toLogString(), __newchild.toLogString(), __newchild.___ChildNodeIndex);
			}
			return __newchild;
		}
        private void ___ReConfirmElementVisibility(CHtmlElement elem)
        {
            if (elem == null)
                return;
            switch (elem.___elementTagType)
            {
                case CHtmlElementType.META:
                case CHtmlElementType.LINK:
                case CHtmlElementType.HEAD:
                case CHtmlElementType.SCRIPT:
                case CHtmlElementType.NOFRAME:
                case CHtmlElementType.STYLE:
                case CHtmlElementType.TITLE:
                case CHtmlElementType.COMMENT:
                case CHtmlElementType.AREA:
                    // #TEXT, #AFTER, #BEFORE should keep visibility as is.
                    if (elem.___IsElementVisible == true)
                    {
                        elem.___IsElementVisible = false;
                    }
                    break;
            }
        }
        /// <summary>
        /// returns true 1) target is current node it self 2) target is direct child 3) target is any of ChildNodes.
        /// </summary>
        /// <param name="__seek">Target Element</param>
        /// <returns>true (Yes) false (Not contains)</returns>
        public bool contains(object __seek)
        {
            bool __Result = false;
            bool __IsGoodPeration = false;

            CHtmlElement ___seekElement = null;
            CHtmlStopWatch __stopWatch = null;
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 7)
            {
                __stopWatch = new CHtmlStopWatch();
            }

            try
            {
                if (__seek == null)
                {

                    goto ResultPhase;
                }
                if (__seek is CHtmlElement)
                {

                    ___seekElement = __seek as CHtmlElement;
                    goto SeekFound;
                }
                else
                {
                    ___seekElement = commonData.convertObjectIntoCHtmlElement(__seek);
                }


            SeekFound:
                if (___seekElement != null)
                {
                    __IsGoodPeration = true;
                    // Seek may be this it self
                    if (object.ReferenceEquals(___seekElement, this) == true)
                    {
                        __Result = true;
                        goto ResultPhase;
                    }
                    // Look For this Direct ChildNodes
                    if (this.___childNodes.___containsObjectHash(___seekElement.GetHashCode()))
                    {
                        __Result = true;
                        goto ResultPhase;
                    }
                    // may be sub child contains this element
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 7)
                    {
                       commonLog.LogEntry(" {0}.contains({1}) will performing recurse lookup", this, ___seekElement);
                    }
                    for (int i = this.___childNodes.Count - 1; i >= 0; i--)
                    {
                        CHtmlElement ___childNode = this.___childNodes[i] as CHtmlElement;
                        if (___childNode != null)
                        {
                            int ___stackDepth = 0;
                            if (___childNode.___IsContainsElementWithinChildNodesRecursively(___seekElement, ref ___stackDepth) == true)
                            {
                                __Result = true;
                                goto ResultPhase;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                }
                else
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 7)
                    {
                       commonLog.LogEntry("TODO: {0}.contains({1}) Type Conversion Failed", this, __seek);
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 7)
                {
                   commonLog.LogEntry("{0}.contains({1}) result error : {2}", this, __seek, ex.Message);
                }
                __Result = false;
            }
        ResultPhase:
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 7)
            {
               commonLog.LogEntry("{0}.contains(\'{1}\') Result : {2} GoodSearch : {3} Elapsed : {4}", this, __seek, __Result, __IsGoodPeration, __stopWatch);
            }
            return __Result;
        }
        /*
		public CHtmlElement appendChild( object appendChildParam1)
		{
			if(appendChildParam1 is CHtmlElement)
			{
				return this.___appendChildInner(appendChildParam1 as CHtmlElement);
			}
			else
			{
                CHtmlElement elem = commonData.convertObjectIntoCHtmlElement(appendChildParam1);
				if(elem != null)
				{
					return this.___appendChildInner(elem);
				}
				else
				{
					Type tpObject = null;
					string strMessage = "";
					if(appendChildParam1 != null)
					{
						tpObject = appendChildParam1.GetType();
						strMessage = string.Format("{0}.appendChild({1}) is called with unexpedted type: \"{2}\"",this,   appendChildParam1, tpObject);
					}
					else
					{
						 strMessage = string.Format("{0}.appendChild({1}) is called with null",this,   appendChildParam1);
					}

					if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
					{

						commonLog.LogEntry(strMessage);
					}
					if(appendChildParam1 == null)
					{
						throw new System.ArgumentNullException(strMessage);
					}
					else
					{
						throw new NotImplementedException(strMessage);
					}
					
				}
			
			}
		}
        */
        

        public CHtmlElement appendChild(CHtmlElement ___elem)
        {
            if (___elem != null)
            {
                switch (___elem)
                {
                    case CHtmlElement elem:
                        return this.___appendChildInner(___elem);
                }
         
            }
            return null;
        }
        /// <summary>
        /// Some scripts performs appendChild with 2 parameters. if it is not same as this node, perform appendChild.
        /// </summary>
        /// <param name="elem1"></param>
        /// <param name="elem2"></param>
        /// <returns></returns>
        public CHtmlElement appendChild(CHtmlElement elem1, CHtmlElement elem2)
        {
            if (elem1 != null)
            {
                if (object.ReferenceEquals(elem1, this) == false)
                {
                    this.___appendChildInner(elem1);
                }
            }
            if(object.ReferenceEquals(elem1 , elem2) == true)
            {
                return elem1;
            }
            if (elem2 != null)
            {
                if (object.ReferenceEquals(elem2, this) == false)
                {
                    return this.___appendChildInner(elem2);
                }
            }
            return elem1;
        }
        /// <summary>
        /// Result of  GetElementBoundsOnScreen()
        /// </summary>
        public RectangleFSpec ___ScreenRectangle = RectangleFSpec.Empty;

		
		public RectangleFSpec GetElementBoundsOnScreen()
		{	
			if(this.___isElementPositionAbsoluteOrStatic == false)
			{
               this.___ScreenRectangle = new RectangleFSpec((float)(this.___offfsetParentPoint.X - this.___BaseControlDisplayRectangle.Left),
                    (float)(this.___offfsetParentPoint.Y - this.___BaseControlDisplayRectangle.Top),
                    (float)this.___offsetWidth,
                    (float)this.___offsetHeight);
               return this.___ScreenRectangle;
			}
			else
			{
                this.___ScreenRectangle = new RectangleFSpec((float)(this.___offfsetParentPoint.X - this.___BaseControlDisplayRectangle.Left),
                    (float)(this.___offfsetParentPoint.Y - this.___BaseControlDisplayRectangle.Top),
                    (float)this.___offsetWidth,
                    (float)this.___offsetHeight);
                return this.___ScreenRectangle;
			}
		}
		/*
		public void CreateChildrenHtmlBaseList(ref ArrayList ar)
		{
			int ___childrenCount = this.children.Count;
			for(int i = 0; i < ___childrenCount; i ++)
			{
				CHtmlElement cElement = this.children[i] as CHtmlElement;
				if(cElement != null)
				{
					CHtmlBase cBase        = new CHtmlBase();
					cBase.tagName               = cElement.tagName;
					cBase.TagOpenStartPosition  = cElement.TagOpenStartPosition;
					cBase.TagOpenEndPosition    = cElement.TagOpenEndPosition;
					cBase.TagCloseStartPosition = cElement.TagCloseStartPosition;
					cBase.TagCloseEndPosition   = cElement.TagCloseEndPosition;
					ar.Add(cBase);
					if(___childrenCount > 0)
					{
					   cElement.CreateChildrenTagNameList(ref ar);
					}
				}
			}
		}
		*/
        /// <summary>
        /// Faster Version of CreateAttributes. User This Methods
        /// </summary>
        /// <param name="element"></param>
        /// <param name="strAttributes"></param>
        public void ___createElementAttributesFromString(ref System.Text.StringBuilder sbAttributes)
        {
            /*
#if DEBUG
            if (this.___elementTagType == CHtmlElementType.BODY) 
            {
               commonLog.LogEntry("HERE");
            }
#endif
             * */
             
            int _sbAttributesLength = sbAttributes.Length;     
            if (_sbAttributesLength == 0)
                return;
       

            //
            // We should not remove ending shash in this function.
            /*
			if(commonFasterEndsWith(strAttributes, "/"))
			{
				strAttributes = strAttributes.Remove(_sbAttributesLength -1,1);
				_sbAttributesLength = sbAttributes.Length;
			}
             * */
            /*
            try
            {
                // some HTML attributes does not contains space in between
                // example
                // "allowfullscreen='true'allowscriptaccess='always'bgcolor='#000000'flashvars='i..'
                // Lookup Rule 1)
                // Every Value must be quoted correctly
                int ___firstEqual = strAttributes.IndexOf('=');
                if (___firstEqual > -1)
                {
                    char[] attrArray = strAttributes.ToCharArray();
                    char _quoteChar = attrArray[___firstEqual + 1];

                    if (_quoteChar == '\'' || _quoteChar == '\"')
                    {
                        // cpos will start +2 because ='
                        for (int cpos = ___firstEqual + 2; cpos < _sbAttributesLength; cpos++)
                        {
                            if (attrArray[cpos] == _quoteChar)
                            {
                                if (attrArray[cpos - 1] != '\\')
                                {
                                    if (cpos + 1 < _sbAttributesLength)
                                    {
                                        char cJustAfter = attrArray[cpos + 1];
                                        if (commonHTML.FasterIsWhiteSpaceLimited(cJustAfter))
                                        {
                                            // if first check is white space. lets think all ___hasInner spaced correctly.
                                            continue;
                                        }
                                        if (char.IsLetterOrDigit(cJustAfter))
                                        {
                                            // okay. next name is started with letter or number without spaces
                                            System.Text.StringBuilder _sbWhite = new System.Text.StringBuilder();
                                            for (int c = 0; c <= cpos; c++)
                                            {
                                                _sbWhite.Append(attrArray[c]);
                                            }
                                            _sbWhite.Append(' ');
                                            // First attributes created
                                            int __curMode = 0;
                                            if (__curMode == -1) { ;}
                                            bool __IsInQuote = false;
                                            for (int _c = cpos + 1; _c < _sbAttributesLength; _c++)
                                            {
                                                char _cc = attrArray[_c];
                                                bool __DoWhiteSpace = false;
                                                switch (_cc)
                                                {
                                                    case '=':
                                                        if (__IsInQuote == false)
                                                        {
                                                            __curMode = 0; // Name Mode
                                                        }
                                                        else
                                                        {
                                                            __curMode = 1;
                                                        }
                                                        break;
                                                    case '\'':
                                                    case '\"':
                                                        if (_cc == _quoteChar)
                                                        {
                                                            if (attrArray[_c - 1] != '\\')
                                                            {
                                                                if (__IsInQuote == false)
                                                                {
                                                                    __IsInQuote = true;
                                                                }
                                                                else
                                                                {
                                                                    __IsInQuote = false;
                                                                    // Means name="HOGEHOGE"ends
                                                                    if (_c + 1 < _sbAttributesLength;)
                                                                    {
                                                                        char _afterChar = attrArray[_c + 1];
                                                                        if (char.IsLetter(_afterChar))
                                                                        {
                                                                            __DoWhiteSpace = true;
                                                                            __curMode = 0; // Name Mode
                                                                        }
                                                                    }

                                                                }
                                                            }
                                                        }
                                                        break;
                                                    default:
                                                        break;

                                                }
                                                _sbWhite.Append(_cc);
                                                if (__DoWhiteSpace)
                                                {
                                                    _sbWhite.Append(' ');
                                                    __DoWhiteSpace = false;
                                                }
                                            }
                                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                                            {
                                               commonLog.LogEntry("{0} ___hasInner non spaced attributes \"{1}\" converted \"{2}\"", this, strAttributes, _sbWhite.ToString());
                                            }
                                            strAttributes = _sbWhite.ToString();
                                            continue;

                                        }
                                        else
                                        {
                                            continue;

                                        }
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        goto SpaceCheckDone;
                    }

                }
                else
                {
                    goto SpaceCheckDone;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 1)
                {
                   commonLog.LogEntry("{0}.___createElementAttributesFromString(\"{1}\") failed : {2}", this, strAttributes,commonData.GetExceptionAsString(ex));
                }
            }
             */

            try
            {
                if (this.___elementTagType == CHtmlElementType.DOCTYPE)
                {
                    // DTD Declareration ___hasInner innormal name and value
                    int sbLen = _sbAttributesLength;
                    System.Text.StringBuilder sbDTDValue = new System.Text.StringBuilder();
                    int ___dtdAttributePosition = 0;
                    CHtmlDTD ___elementDTD = this as CHtmlDTD;
                    bool ___IsPublicID = false;
                    bool ___IsSystemID = false;
                    char ___QuotedStartedChar = '\0';
                    if (___elementDTD == null)
                        return;
                    bool ___IsAppendingChar = false;
                    int ___boxbracketStartCount = 0;
                    bool ___boxbracketEnter = false;
                    int ___boxbracketEndCount = 0;
                    if (___boxbracketEndCount == 10)
                    {
                        ;
                    }
                    for (int i = 0; i < sbLen; i++)
                    {
                        ___IsAppendingChar = false;
                        char dtdc = sbAttributes[i];
                        if (commonHTML.FasterIsWhiteSpaceLimited(dtdc) == true)
                        {
                            if (___boxbracketStartCount > 0)
                                continue;
                            ___IsAppendingChar = false;
                        }
                        else
                        {
                            if (dtdc == '[' && sbDTDValue.Length != 0 && ___QuotedStartedChar == sbDTDValue[sbDTDValue.Length -1])
                            {
                                ___boxbracketStartCount++;
                                ___boxbracketEnter = true;
                                ___IsAppendingChar = false;
                            }
                            else
                            {
                                if (dtdc == '[')
                                {
                                    if (sbDTDValue.Length == 0)
                                    {
                                        ___boxbracketStartCount++;
                                        ___boxbracketEnter = true;
                                        continue;
                                    }
                                }
                                else if (dtdc == ']' && ___boxbracketEnter == true && ___boxbracketStartCount > 0)
                                {
                                    ___IsAppendingChar = false;
                                }
                                else
                                {
                                    ___IsAppendingChar = true;
                                }
                            }
                        }
                        if(___IsAppendingChar == false)
                        {
                            if (sbDTDValue.Length == 0)
                                continue;
                            ___dtdAttributePosition++;
                            if (___boxbracketEnter == true)
                            {
                                ___elementDTD.___internalSubset = sbDTDValue.ToString();
                                if(string.IsNullOrEmpty(___elementDTD.___internalSubset) == false && (commonHTML.FasterIsWhiteSpaceLimited(___elementDTD.___internalSubset[0]) == true || commonHTML.FasterIsWhiteSpaceLimited(___elementDTD.___internalSubset[___elementDTD.___internalSubset.Length -1]) == true))
                                {
                                    ___elementDTD.___internalSubset  = ___elementDTD.___internalSubset.Trim();
                                }
                                ___boxbracketStartCount = 0;
                                ___boxbracketEndCount = 0;
                                ___boxbracketEnter = false;
                                goto SetDone;
                            }
                            switch (___dtdAttributePosition)
                            {
                                case 1:
                                    ___elementDTD.___name = sbDTDValue.ToString();
                                    break;
                                case 2:
                                    string ___IDIdentifier = sbDTDValue.ToString();
                                    if (string.IsNullOrEmpty(___IDIdentifier) == false && (commonHTML.FasterIsWhiteSpaceLimited(___IDIdentifier[0]) || commonHTML.FasterIsWhiteSpaceLimited(___IDIdentifier[___IDIdentifier.Length - 1])))
                                    {
                                        ___IDIdentifier = ___IDIdentifier.Trim();
                                    }
                                    switch (___IDIdentifier)
                                    {
                                        case "PUBLIC":
                                        case "public":
                                        case "Public":
                                            ___IsPublicID = true;
                                            break;
                                        case "SYSTEM":
                                        case "System":
                                        case "system":
                                            ___IsSystemID = true;
                                            break;
                                    }
                                    break;
                                default:
                                    if (___IsPublicID == true)
                                    {
                                        ___elementDTD.___publicId = sbDTDValue.ToString();
                                        ___IsPublicID = false;
                                        ___IsSystemID = true;
                                    }
                                    else if (___IsSystemID == true)
                                    {
                                        ___elementDTD.___systemId = sbDTDValue.ToString();
                                    }
                                    break;
                            }
                        SetDone:
                            sbDTDValue = null;
                            sbDTDValue = new System.Text.StringBuilder();
                            ___QuotedStartedChar = '\0';
                        }
                        else
                        {
                            if (sbDTDValue.Length == 0)
                            {
                                if (dtdc == '\'' || dtdc == '\"')
                                {
                                    ___QuotedStartedChar = dtdc;
                                }
                            }
                            sbDTDValue.Append(dtdc);
                        }
                    }
                    this.value = sbAttributes.ToString();
                    return;
                }
               
                bool _rightAfterEqual = false;
                int __LastAttributePoint = -1;
                int __oldPos = -1;
                char c = 'a';
                for (int i = 0; i < _sbAttributesLength; i++)
                {
                    c = sbAttributes[i];
                    switch (c)
                    {
                        case '=':
                            _rightAfterEqual = true;
                            continue;
                        case '\"':
                            __oldPos = i;
                            i = commonHTML.GetNextCharacterPositionFromStringBuilder('\"', i, ref  sbAttributes, false);
                            if (i + 1 < _sbAttributesLength && commonHTML.FasterIsWhiteSpaceLimited(sbAttributes[i + 1]) == false)
                            {
                                sbAttributes.Insert(i +1 , ' ');
                            }
                            __LastAttributePoint = i;
                            if (_rightAfterEqual == true)
                            {
                                try
                                {
                                    this.___AddAttributesNameValueIntoArrayList(__oldPos, i, ref sbAttributes);
                                }
                                catch (Exception AddEx)
                                {
                                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                                    {
                                       commonLog.LogEntry("AddAttributesNameValueIntoArrayList 1", AddEx);
                                    }
                                }
                                _rightAfterEqual = false;
                            }
                            continue;
                        case '\'':
                            __oldPos = i;
                            i = commonHTML.GetNextCharacterPositionFromStringBuilder('\'', i, ref  sbAttributes, false);
                            if (i + 1 < _sbAttributesLength && commonHTML.FasterIsWhiteSpaceLimited(sbAttributes[i + 1]) == false)
                            {
                                sbAttributes.Insert(i +1, ' ');
                            }
                            __LastAttributePoint = i;
                            if (_rightAfterEqual == true)
                            {
                                try
                                {
                                    this.___AddAttributesNameValueIntoArrayList(__oldPos, i, ref sbAttributes);
                                }
                                catch (Exception AddEx)
                                {
                                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                                    {
                                       commonLog.LogEntry("AddAttributesNameValueIntoArrayList 2", AddEx);
                                    }
                                }
                                _rightAfterEqual = false;
                            }
                            continue;
                        default:

                            if (char.IsLetterOrDigit(c) || commonHTML.IsCharacterNonEqAndNonQuoteChar(c) == true)
                            {
                                if (_rightAfterEqual)
                                {
                                    __oldPos = i;
                                    int _wordEndPoint = commonHTML.GetNextCharacterPositionFromStringBuilder(' ', i, ref  sbAttributes, true);
                                    if (i < _wordEndPoint)
                                    {
                                        sbAttributes.Insert(i, "\"");
                                        sbAttributes.Insert(_wordEndPoint + 1, "\"");
                                        i = _wordEndPoint + 1;
                                        __LastAttributePoint = i;
                                    }
                                    try
                                    {
                                        this.___AddAttributesNameValueIntoArrayList(__oldPos, _wordEndPoint + 1, ref sbAttributes);
                                    }
                                    catch (Exception AddEx)
                                    {
                                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                                        {
                                           commonLog.LogEntry("AddAttributesNameValueIntoArrayList 3", AddEx);
                                        }
                                    }
                                    _rightAfterEqual = false;
                                }
                                else
                                {
                                    // ----------------------------------------------------------
                                    // May be last string segument is attribute name
                                    // "src=http://localhost async>"
                                    // ----------------------------------------------------------
                                    if (i == _sbAttributesLength - 1)
                                    {
                                        if (__LastAttributePoint == -1)
                                        {
                                            __LastAttributePoint = 0;
                                        }
                                        if (__LastAttributePoint < i)
                                        {
                                            System.Text.StringBuilder sbNameTemp = new System.Text.StringBuilder();
                                            for (int tc = __LastAttributePoint; tc <= i; tc++)
                                            {
                                                if (sbAttributes[tc] == '\'' || sbAttributes[tc] == '\"')
                                                {
                                                    goto NextChar;
                                                }
                                                else if (commonHTML.FasterIsWhiteSpaceLimited(sbAttributes[tc]))
                                                {
                                                    break;
                                                }
                                                sbNameTemp.Append(sbAttributes[tc]);
                                            }
                                            if (sbNameTemp.Length > 0)
                                            {

                                                this.___AddAttributesNameValueIntoArrayList(sbNameTemp.ToString(), true);
                                                __LastAttributePoint = i + 1;
                                                goto NextChar;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // alphabet or number is not last positon. and Not after '='
                                        if (i > 2 && i < _sbAttributesLength)
                                        {
                                            if (commonHTML.FasterIsWhiteSpaceLimited(sbAttributes[i - 1]) == true)
                                            {
                                                int LastAlphabetOrNumberPosition = -1;
                                                char cPrev = '\0';
                                                for (int prevCharPos = i - 2; prevCharPos >= 0; prevCharPos--)
                                                {
                                                    cPrev = sbAttributes[prevCharPos];
                                                    if (cPrev == '\"' || cPrev == '\'')
                                                    {
                                                        goto NextChar;
                                                    }
                                                    else if (char.IsLetterOrDigit(cPrev))
                                                    {
                                                        LastAlphabetOrNumberPosition = prevCharPos;
                                                        break;

                                                    }
                                                }
                                                if (LastAlphabetOrNumberPosition > -1)
                                                {
                                                    // Okay its prior string character is not quoted and alphabet
                                                    char cPrevZ = '\0';
                                                    System.Text.StringBuilder sbPrevString = new System.Text.StringBuilder();
                                                    for (int prevCharPosZ = LastAlphabetOrNumberPosition; prevCharPosZ >= 0; prevCharPosZ--)
                                                    {
                                                        cPrevZ = sbAttributes[prevCharPosZ];
                                                        if (cPrevZ == '\"' || cPrevZ == '\'' || cPrevZ == '=')
                                                        {
                                                            goto NextChar;
                                                        }
                                                        else if (char.IsLetterOrDigit(cPrevZ))
                                                        {
                                                            if (cPrevZ >= 'A' && cPrevZ <= 'Z')
                                                            {
                                                                sbPrevString.Append(commonHTML.FasterToLower(cPrevZ));
                                                            }
                                                            else
                                                            {
                                                                sbPrevString.Append(cPrevZ);

                                                            }
                                                            continue;
                                                        }
                                                        else if (commonHTML.FasterIsWhiteSpaceLimited(cPrevZ))
                                                        {
                                                            if (sbPrevString.Length > 0)
                                                            {
                                                                for (int prevCharPosZZ = prevCharPosZ - 1; prevCharPosZZ >= 0; prevCharPosZZ--)
                                                                {
                                                                    if (sbAttributes[prevCharPosZZ] == '=')
                                                                    {
                                                                        goto NextChar;
                                                                    }
                                                                    else if (sbAttributes[prevCharPosZZ] == '\'' || sbAttributes[prevCharPosZZ] == '\"')
                                                                    {
                                                                        break;
                                                                    }
                                                                }
                                                                char[] charPrevStringRev = sbPrevString.ToString().ToCharArray();
                                                                Array.Reverse(charPrevStringRev);
                                                                string strSingleAttr = new string(charPrevStringRev);
                                      
                                                                this.___AddAttributesNameValueIntoArrayList(strSingleAttr, true);
                                                                


                                                            }
                                                            goto NextChar;
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (commonHTML.FasterIsWhiteSpaceLimited(c))
                                {
                                    if (__LastAttributePoint == -1)
                                    {
                                        __LastAttributePoint = 0;
                                    }
                                    if (__LastAttributePoint < i)
                                    {
                                        System.Text.StringBuilder sbNameTemp = new System.Text.StringBuilder();
                                        for (int tc = __LastAttributePoint; tc < i; tc++)
                                        {
                                            if (sbAttributes[tc] == '\'' || sbAttributes[tc] == '\"')
                                            {
                                                goto NextChar;
                                            }
                                            else if (commonHTML.FasterIsWhiteSpaceLimited(sbAttributes[tc]))
                                            {
                                                break;
                                            }
                                            sbNameTemp.Append(sbAttributes[tc]);
                                        }
                                        if (sbNameTemp != null && sbNameTemp.Length > 0)
                                        {

                                            this.___AddAttributesNameValueIntoArrayList(sbNameTemp.ToString(), true);
                                            __LastAttributePoint = i + 1;
                                        }
                                    }
                                }
                            }
                        NextChar:
                            continue;
                    }
                }
                if (__LastAttributePoint > -1 && __LastAttributePoint + 2 < _sbAttributesLength)
                {
                    string __atterAfter = sbAttributes.ToString(__LastAttributePoint + 2, _sbAttributesLength - (__LastAttributePoint + 2) );
                    string[] __atterAfterSplit = __atterAfter.Split(commonHTML.CharSpaceCrLfTabZentakuSpace);
                    int __atterAfterSplitLen = __atterAfterSplit.Length;
                    for (int p = 0; p < __atterAfterSplitLen; p++)
                    {
                        if (__atterAfterSplit[p].Length > 0)
                        {
                            if (char.IsLetter(__atterAfterSplit[p][0]) == true)
                            {
                                if(this.___attributes.ContainsKey(__atterAfterSplit[p]) == false)
                                {
                                    this.___AddAttributesNameValueIntoArrayList(__atterAfterSplit[p], true);
                                }
                            }
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                {
                   commonLog.LogEntry(" ___createElementAttributesFromString Error." , ex);
                }
            }
        }
		internal void ___AddAttributesNameValueIntoArrayList(string __attrName, object __attrValue)
		{
			if(__attrName == null || __attrName.Length == 0)
				return;
            if(commonHTML.FasterIsWhiteSpaceLimited(__attrName[0]) == true ||(__attrName.Length > 1 && commonHTML.FasterIsWhiteSpaceLimited(__attrName[__attrName.Length -1])))
            {
                __attrName = __attrName.Trim();
            }
			CHtmlAttribute newAttr = new CHtmlAttribute();
            var attrName = __attrName;
			newAttr.name =  __attrName;
			newAttr.___tagName =  __attrName;
            newAttr.setParentNode(this);
            if (__attrValue is string)
            {
                if (attrName.IndexOf('&') > -1)
                {
                    newAttr.value = commonHTML.ReplaceAsmpdandString(__attrName);
                }
                else
                {
                    newAttr.value = __attrValue;
                }
            }
            else
            {
                newAttr.value = __attrValue;
            }

            if (commonHTML.ElementFieldsNeedsToTypeConversionSortedList.ContainsKey(newAttr.name) == true)
            {
                if (this.___elementTagType == CHtmlElementType.FRAMESET || this.___elementTagType == CHtmlElementType.FRAME)
                {
                    if (string.Equals(newAttr.name, "rows", StringComparison.OrdinalIgnoreCase) == true || string.Equals(newAttr.name, "cols", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        // frameset rows and cols conversion is not required.
                        
                        goto ConversionDone;
                    }
                }
                commonHTML.ConvertAttributeValueByNameIfNessesary(newAttr);
            }
            ConversionDone:
            if(commonHTML.WellKnownCHtmlEmementAttributesDictionary.ContainsKey(newAttr.name))
            {
                if (newAttr.value is String)
                {
                    this.___SetCHtmlElementWellKnownAttribute(newAttr.name, newAttr.value as string);
                }
                else
                {
                    if (newAttr.___value != null)
                    {
                        this.___SetCHtmlElementWellKnownAttribute(newAttr.name, newAttr.___value.ToString());
                    }
                    else
                    {
                        this.___SetCHtmlElementWellKnownAttribute(newAttr.name, "");
                    }
                }
              
            }

			
	
			this.___attributes[newAttr.name] = newAttr;	
		}

		internal  void ___AddAttributesNameValueIntoArrayList(int _start, int _end,ref System.Text.StringBuilder sb)
		{
			System.Text.StringBuilder sbName = new System.Text.StringBuilder();
			System.Text.StringBuilder sbValue = new System.Text.StringBuilder();
			// ========================================================================
			// Name Segment
			// ========================================================================
            char nc = '\0';
			for(int n = _start - 2; n >= 0; n --)
			{
			    nc = sb[n];
				if(nc != ' ' && nc != '=')
				{
                    if(nc >= 'A' && nc <= 'Z')
                    {
					    sbName.Insert(0,commonHTML.FasterToLower(nc));
                    }else
                    {
                        sbName.Insert(0, nc);
                    }
				}
				else
				{
					if(sbName.Length > 0)
					{
						break;
					}
				}
			}
			


			// ========================================================================

			// ========================================================================
			// Value Segment
			// ========================================================================
            bool ___IsContainsAmpsand = false;
			for(int v = _start; v <  _end; v ++)
			{
                if (sb[v] == '&')
                {
                    if (___IsContainsAmpsand == false)
                    {
                        for (int vNext = v + 1; vNext < _end; vNext++)
                        {
                            char vSymbol = sb[vNext];
                            if (char.IsLetterOrDigit(vSymbol))
                            {
                                continue;
                            }
                            else if (vSymbol == '=' || vSymbol == '$' || vSymbol == '+' || vSymbol == ' ')
                            {
                                break;
                            }
                            else if(vSymbol == ';')
                            {
                                ___IsContainsAmpsand = true;
                                break;
                            }
                        }
                        
                    }
                }
				sbValue.Append(sb[v]);
			}
			// ==== Remove '"' or ''' Beging 
			int sbValueLen = sbValue.Length;
			for(int i = 0; i < sbValueLen; i ++)
			{
				char cb = sbValue[i];
				if(char.IsLetterOrDigit(cb))
				{
					break;
				}
				else if(cb == '\"' || cb == '\'')
				{
					if(i + 1 < sbValue.Length  && sbValue[i + 1] != '\\')
					{
						sbValue.Remove(i, 1);
						sbValueLen = sbValue.Length;
						break;
					}
				}
				else
				{
					if(cb != ' ')
					{
						break;
					}
				}
			}
			// ==== Remove '"' or ''' Beging 
           char ce = '\0';
			for(int i = sbValueLen - 1; i >= 0; i --)
			{
				ce = sbValue[i];
				if(char.IsLetterOrDigit(ce))
				{
					break;
				}
				else if(ce == '\"' || ce == '\'')
				{
					if(i - 1 >= 0 && sbValue[i - 1] != '\\')
					{
						sbValue.Remove(i,1);
						sbValueLen = sbValue.Length;
						break;
					}
                }
                else
                {
                    if (ce != ' ')
                    {
                        break;
                    }
                }
			}
			if(sbValueLen == 1 && ( sbValue[0] == '\"' || sbValue[0] == '\''))
			{
				sbValue.Remove(0, 1);
				sbValueLen = sbValue.Length;
			}
            while (sbName.Length > 0 && commonHTML.FasterIsWhiteSpaceLimited(sbName[0]))
            {
                sbName.Remove(0, 1);
                sbValueLen = sbValue.Length;
            }
            // ========================================================================
            if (sbName.Length > 0)
            {
                CHtmlAttribute newAttr = new CHtmlAttribute();
                var attrname = sbName.ToString();
                newAttr.name = attrname;
                newAttr.___tagName = attrname;
                var attrValue = sbValue.ToString();
                newAttr.value = attrValue;
                newAttr.specifid = true;
                newAttr.setParentNode(this);
                this.___attributes[attrname] = newAttr;
                if(commonHTML. WellKnownCHtmlEmementAttributesDictionary.ContainsKey(attrname))
                { 
                    ___SetCHtmlElementWellKnownAttribute(attrname, attrValue);
                }

            }
		}
		
        /// <summary>
		/// Set Well Known Attributes into fields (or conver type)
		/// Note : all fields should be enlisted in commonWellKnownStringAttributesSortedList.
		/// </summary>
		/// <param name="aKey">lower name</param>
		/// <param name="sValue">value</param>

		internal void ___SetCHtmlElementWellKnownAttribute(string aKey, string sValue)
		{
			switch(aKey)
			{
				case "type":
					this.type = commonHTML.FasterToLower(sValue);
					if(((this.___KeyAttributes & CHtmlElementDeclaredAttributeType.Type) == CHtmlElementDeclaredAttributeType.Type)== false)
					{
						this.___KeyAttributes = this.___KeyAttributes | CHtmlElementDeclaredAttributeType.Type;
					}
					break;
				case "class":
					this.className = sValue;
					if(((this.___KeyAttributes & CHtmlElementDeclaredAttributeType.Class) == CHtmlElementDeclaredAttributeType.Class)== false)
					{
						this.___KeyAttributes = this.___KeyAttributes | CHtmlElementDeclaredAttributeType.Class;
					}
					break;
				case "id":
                    this.id = sValue;
					if(((this.___KeyAttributes & CHtmlElementDeclaredAttributeType.ID) == CHtmlElementDeclaredAttributeType.ID)== false)
					{
						this.___KeyAttributes = this.___KeyAttributes | CHtmlElementDeclaredAttributeType.ID;
					}
					break;
				case "name":
					this.name = sValue;
					if(((this.___KeyAttributes & CHtmlElementDeclaredAttributeType.Name) == CHtmlElementDeclaredAttributeType.Name)== false)
					{
						this.___KeyAttributes = this.___KeyAttributes | CHtmlElementDeclaredAttributeType.Name;
					}
					break;
				case "checked":
                    if (string.Equals(sValue, "checked", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        base.@checked = true;
                    }
                    else if(string.Equals(sValue, "false", StringComparison.OrdinalIgnoreCase) == true)
					{
						base.@checked = false;
					}
					else
					{
						base.@checked = true;
					}
					break;
				case "src":
				{

					this.src = sValue;
				}
					break;
				case "href":
				{
					// ======================================================================
					// NOTE) DO NOT CHANGE URL at this point.
					//       IT MAKES DEBUG VERY DIFFICULT
					//       CONVERT URL IF Nessesary
					// ======================================================================

					this.href = sValue;
				}
					break;
				case "disabled":
					try
					{
						switch(sValue)
						{
							case "disabled":
                            case "Disabled":
                            case "DISABLED":
							case "true":
                            case "True":
                            case "TRUE":
							case "yes":
                            case "Yes":
                            case "YES":
							case "":
								this.___disabled = true;
								break;
							case "False":
							case "false":
							case "none":
                            case "None":
                            case "NONE":
							case "enabled":
								this.___disabled = false;
								break;
							default:
								if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
								{
									commonLog.LogEntry("Parse bool failed {0}", sValue);
								}
								break;

						}
					} 
					catch
					{
							
					}
					break;
				case "async":
					if(sValue.Length > 0)
					{

						if(string.Equals(sValue, "async", StringComparison.OrdinalIgnoreCase) == true)
						{
							this.___async = true;
							break;
						}
                        try
                        {
                            bool ___boolResult;
                            bool.TryParse(sValue, out ___boolResult);
                            if (this.___async != ___boolResult)
                            {
                                this.___async = ___boolResult;
                            }
                            if (this.___attributes.ContainsKey(aKey) == false)
                            {
                                this.async = ___boolResult;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
                            {
                               commonLog.LogEntry("Parse async failed {0} : {1}", sValue, ex.Message);
                            }

                        }
					}
					else
					{   // if async flag exists means async = true
						this.___async = true;
					}
					break;
				case "defer":
					if(sValue.Length != 0)
					{
						if(string.Equals(sValue, "defer", StringComparison.OrdinalIgnoreCase) == true)
						{
							this.___defer = true;
							break;
						}
						try
						{
							this.___defer = bool.Parse(sValue);
						}
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
                            {
                               commonLog.LogEntry("Parse defer failed {0} : {1}", sValue, ex.Message);
                            }

                        }
					}
					else
					{   // if async flag exists means async = true
						this.___defer = true;
					}
					break;
				case "value":
					this.value = sValue;
					break;
                // ===============================================================================
                // Event For Elements 
                // No Event Setting Becaluse no DocumentElmentIdex as assigned
                // ===============================================================================
                /*
                case "onmouseover":
                    this.onmouseover = sValue;
                    break;
                case "onmousedown":
                    this.onmousedown = sValue;
                    break;
                case "onmouseup":
                    this.onmouseup = sValue;
                    break;
                case "onmouseout":
                    this.onmouseout = sValue;
                    break;
                case "onmousewheel":
                    this.onmousewheel = sValue;
                    break;
                case "onscroll":
                    this.onscroll = sValue;
                    break;
                case "onmouseenter":
                    this.onmouseenter = sValue;
                    break;
                case "onresize":
                    this.onresize = sValue;
                    break;
                case "onclick":
                    this.onclick = sValue;
                    break;
                case "ondblclick":
                    this.ondblclick  = sValue;
                    break;
                case "onactivate":
                    this.onactivate = sValue;
                    break;
                case "onkeydown":
                    this.onkeydown = sValue;
                    break;
                case "onkeyup":
                    this.onkeyup = sValue;
                    break;
                case "onkeypress":
                    this.onkeypress = sValue;
                    break;
                case "onfocus":
                    this.onfocus = sValue;
                    break;
                case "oncontextmenu":
                    this.oncontextmenu = sValue;
                    break;
                case "onreadystatechange":
                    this.onreadystatechange = sValue;
                    break;
                */
                default:
                    this.___setPropertyByName(aKey, sValue);
                    break;
			}
		}

		public bool CheckChildNodeIsParagraphTagsOnly()
		{
			bool r = this.___IsChildNodesContains(commonHTML.TagsForNonSentence);
			if(r == true)
			{
				this.___IsChildrenAllSentence= false;
			}
			else
			{
				this.___IsChildrenAllSentence  = true;
			}
			return this.___IsChildrenAllSentence;
		}
		public bool CheckChildNodeIsInlineTagsOnly()
		{
			int ___childNodesCount = this.___childNodes.Count;
			for(int i = 0; i < ___childNodesCount ; i ++)
			{
				CHtmlElement eElement = this.___childNodes[i] as CHtmlElement;
				if(eElement.___IsElementBlock)
				{
					return false;
				}
				if(!eElement.CheckChildNodeIsInlineTagsOnly())
				{
					return false;
				}
			}
			return true;
		}
		public void SetChildrenDisplayStyle(string DisplayStyle, bool recursemode, bool SkipInVisible)
		{
			int ___childNodesCount = this.___childNodes.Count;
			for(int i = 0; i < ___childNodesCount ; i ++)
			{
				CHtmlElement eElement = this.___childNodes[i] as CHtmlElement;
				if(SkipInVisible == false ||(  SkipInVisible == true && eElement.___IsElementVisible == true))
				{
					
					if(eElement.___style != null && eElement.___style.Display != DisplayStyle)
					{
						eElement.___style.Display = DisplayStyle;
						eElement.___IsElementBlock = commonHTML.IsBlockElement(eElement);
					}
				}
				if(recursemode)
				{
					if(eElement.___childNodes.Count > 0)
					{
						eElement.SetChildrenDisplayStyle(DisplayStyle, recursemode,  SkipInVisible);
					}
				}
			}
		}

        private static int CHILDLIST_MAX_LIMIT = 5000;
        private static int CHILDLIST_MAX_Element_Count_Including_IText = 10000;

        private static int ___CreateChildNodeList_LoopLimit = 10000;



        internal void ___createChildElementListWithEnqueueDequeue(CHtmlCollection nodes, CHtmlElementQueryType _queryType, string _Query)
        {
            System.Collections.Generic.Queue<CHtmlElement> queue = new System.Collections.Generic.Queue<CHtmlElement>();
            CHtmlElementType __QueryTagType = CHtmlElementType.UNKNOWN;
            string[] ClassNamesLow = null;
            int ClassNamesLowLength = 0;
            switch (_queryType)
            {
                case CHtmlElementQueryType.GetElementsByTagName:
                    if (string.IsNullOrEmpty(_Query) == false)
                    {
                        int nsPos = _Query.IndexOf(':');
                        if (nsPos == -1)
                        {
                            __QueryTagType = commonHTML.GetTagNameType(_Query);
                        }
                        else
                        {
                            __QueryTagType = CHtmlElementType.UNKNOWN;
                            if (_Query.Length > nsPos + 1)
                            {
                                _Query = _Query.Substring(nsPos + 1);
                            }
                        }
                    }
                    break;
                case CHtmlElementQueryType.GetElementsByClassName:
                    if (string.IsNullOrEmpty(_Query) == false)
                    {
                        ClassNamesLow = commonHTML.FasterToLower(_Query).Split(commonHTML.CharSpaceCrLfTab, StringSplitOptions.RemoveEmptyEntries);
                        ClassNamesLowLength = ClassNamesLow.Length;
                    }
                    break;
            }

            //
            // Bang all the top nodes into the queue.
            //
            int ___childNodesCount = this.___childNodes.Count;
            for (int i = 0; i < ___childNodesCount; i++)
            {
                CHtmlElement top = this.___childNodes[i] as CHtmlElement;
                if (top != null)
                {
                    if (_queryType != CHtmlElementQueryType.All_Including_IText_Before_After)
                    {
                        if (commonHTML.elementTagTypesShouldIncludedAllChildList.ContainsKey(top.___elementTagType) == true)
                        {
                            continue;
                        }
                    }
                    queue.Enqueue(top);
                }
            }
            int ___whileCount = 0;
            while (queue.Count > 0)
            {
                ___whileCount++;
                if (___whileCount > ___CreateChildNodeList_LoopLimit)
                {
                    if (commonLog.LoggingEnabled)
                    {
                       commonLog.LogEntry("___createChildElementListWithEnqueueDequeue seems over limit :{0}", ___CreateChildNodeList_LoopLimit);
                    }
                    goto ReportPhase;
                }
                CHtmlElement node = queue.Dequeue();
                if (node != null)
                {
                    //
                    // Add the node to the list of nodes.
                    //
                    switch (_queryType)
                    {
                        case CHtmlElementQueryType.GetElementsByTagName:
                        case CHtmlElementQueryType.GetElementsByTagNameNS:
                            if (__QueryTagType != CHtmlElementType.UNKNOWN)
                            {
                                if (node.___elementTagType == __QueryTagType)
                                {
                                    nodes.Add(node);
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(node.___tagNameNoNS) == false)
                                {
                                    if (string.Equals(node.tagNameNoNS, _Query, StringComparison.OrdinalIgnoreCase) == true)
                                    {
                                        nodes.Add(node);
                                    }
                                }
                            }
                            break;
                        case CHtmlElementQueryType.GetElementsByName:
                            if (string.IsNullOrEmpty(node.___name) == false)
                            {
                                if (string.Equals(node.___name, _Query, StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    nodes.Add(node);
                                }
                            }
                            break;
                        case CHtmlElementQueryType.GetElementsByClassName:
                            if (node.___classList.Count > 0)
                            {
                                if (ClassNamesLow == null)
                                {
                                    if (node.___classList.ContainsKey(_Query))
                                    {
                                        nodes.Add(node);
                                    }
                                }
                                else
                                {
                                    uint ClassMatchCount = 0;
                                    for (int cp = 0; cp < ClassNamesLowLength; cp++)
                                    {
                                        if (node.___classList.ContainsKey(ClassNamesLow[cp]) == true)
                                        {
                                            ClassMatchCount++;
                                            if (ClassMatchCount == ClassNamesLowLength)
                                            {
                                                nodes.Add(node);
                                                break;
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                }
                            }
                            break;
                        case CHtmlElementQueryType.GetElementById:
                            if (string.IsNullOrEmpty(node.___id) == false)
                            {
                                if (string.Equals(node.___id, _Query, StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    nodes.Add(node);
                                    goto ReportPhase;
                                }
                            }
                            break;
                        case CHtmlElementQueryType.All:
                        case CHtmlElementQueryType.All_Including_IText_Before_After:
                        default:
                            if (_queryType != CHtmlElementQueryType.All_Including_IText_Before_After)
                            {
                                if (node.___IsSystemHidden == false && commonHTML.elementTagTypesShouldIncludedAllChildList.ContainsKey(node.___elementTagType) == false)
                                {

                                    nodes.Add(node);
                                }
                            }
                            else
                            {
                                nodes.Add(node);
                            }
                            if (_queryType != CHtmlElementQueryType.All_Including_IText_Before_After)
                            {
                                if (nodes.Count >= CHILDLIST_MAX_LIMIT)
                                {
                                    goto ReportPhase;
                                }
                            }
                            else
                            {
                                if (nodes.Count >= CHILDLIST_MAX_Element_Count_Including_IText)
                                {
                                    goto ReportPhase;
                                }
                            }
                            break;
                    }
                    int nodeChildCount = node.___childNodes.Count;

                    if (nodeChildCount > 0)
                    {
                        //
                        // Enqueue the child nodes.
                        //
                        /*
                        foreach (CHtmlElement child in node.___childNodes)
                        {
                            queue.Enqueue(child);
                        }
                         */

                        for (int nc = 0; nc < nodeChildCount; nc++)
                        {
                            CHtmlElement ncc = node.___childNodes[nc] as CHtmlElement;

                            if (ncc != null)
                            {
                                if (_queryType != CHtmlElementQueryType.All_Including_IText_Before_After)
                                {
                                    if (commonHTML.elementTagTypesShouldIncludedAllChildList.ContainsKey(ncc.___elementTagType) == false)
                                    {
                                        queue.Enqueue(ncc);
                                    }
                                }
                                else
                                {
                                    queue.Enqueue(ncc);
                                }
                            }

                        }
                    }
                }
            }
        ReportPhase:
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 50)
            {
               commonLog.LogEntry("___createChildElementListWithEnqueueDequeue created {0} items for {1} {2}", nodes.Count, _queryType, _Query);
            }
        }


		public bool ___IsChildNodesContains(string tagName)
		{
			tagName = tagName.Replace(" ", "");
			string[] sp = null;
            if (tagName.IndexOf(',') > -1)
			{
				sp = commonHTML.FasterToLower(tagName).Split(',');
			}
            else if (tagName.IndexOf(';') > -1)
			{
				sp = commonHTML.FasterToLower(tagName).Split(';');
			}
			else
			{
				sp = new string[]{tagName};
			}
			return ___IsChildNodesContains(sp);
		}
		public void CleanUpChildrenRecursively()
		{
			if(this.___childNodes != null)
			{
				for(int i = this.___childNodes.Count -1; i >= 0 ; i --)
				{
					CHtmlElement cElement = this.___childNodes[i] as CHtmlElement;
					if(cElement != null)
					{
						cElement.CleanUpChildrenRecursively();
                        this.___childNodes.RemoveAt(i);
						cElement.Dispose();
						cElement = null;
					}
				}
				if(this.___childNodes != null)
				{
					this.___childNodes.Clear();
				}
			}
		}

		public void update()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
			{
				commonLog.LogEntry("update() is called");
			}
		}
		public void update(object _o)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
			{
				commonLog.LogEntry("update() is called");
			}
		}
        private void ___scrollIntoViewInner(object ___objParam)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("scrollIntoView({0}) is called", ___objParam);
            }
        }

		public void scrollIntoView(object ___objParam)
		{
            this.___scrollIntoViewInner(___objParam);
		}
		public void scrollIntoView()
		{
            this.___scrollIntoViewInner(null);
		}
		/// <summary>
		/// Sets or retrieves the distance between the top of the object and the topmost portion of the content currently visible in the window.
        /// Chrome and IE only documentElement or Body returns proper value
		/// </summary>
		public double scrollTop
		{
            get {
                if (this.___elementTagType == CHtmlElementType.HTML || this.___elementTagType == CHtmlElementType.BODY)
                {
                    return Math.Abs(this.___ScreenRectangle.Y);
                }
                else
                {
                    return 0;
                }

            }
			set{this.___ScreenRectangle.Y  = (float)value;}
		}
		/// <summary>
		/// エレメントの左端部と現在見えているエレメントの最左端部との間の距離をピクセル単位で設定したり、設定を読み出す。これは、エレメントのコンテントを水平方向にスクロールした距離に等しい。 
        /// Chrome and IE only documentElement or Body returns proper value
		/// </summary>
		public double scrollLeft
		{
			get{
                if (this.___elementTagType == CHtmlElementType.HTML || this.___elementTagType == CHtmlElementType.BODY)
                {
                    return Math.Abs(this.___ScreenRectangle.X);
                }
                else
                {
                    return 0;
                }
            }
			set{this.___ScreenRectangle.X  = (float)value;}
		}
		public double scrollWidth
		{
			get{return this.___ScreenRectangle.Width;}
			set{this.___ScreenRectangle.Width  = (float)value;}
		}
		public double scrollHeight
		{
			get{return this.___ScreenRectangle.Height ;}
            set { this.___ScreenRectangle.Height = (float)value; }
		}
		/// <summary>
		/// MARQUEE Element
		/// </summary>
		public int scrollDelay
		{
			set{this.SetGetAttributesByName("scrolldelay", value, true);}
			get
			{ 
				try
				{
					object  oVal = this.SetGetAttributesByName("scrolldelay", null, false);
                    if (oVal != null && commonHTML.isClrNumeric(oVal) == true)
                    {
                        return commonHTML.GetIntFromObject(oVal, 0);
                    }
					
				}
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
				return 0;
			}
		}
		/// <summary>
		/// MARQUEE Element
		/// </summary>
		public int scrollAmount
		{
			set{this.SetGetAttributesByName("scrollamount", value, true);}
			get
			{ 
				try
				{
                    object oVal = this.SetGetAttributesByName("scrollamount", null, false);
                    if (oVal != null && commonHTML.isClrNumeric(oVal) == true)
                    {
                        return commonHTML.GetIntFromObject(oVal, 0);
                    }
					return 0;
				}
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
				return 0;
			}
		}
        /// <summary>
        /// MSIE Specific property returns string unique id. It returns "ms__id" + arbitaray id.
        /// </summary>
        public string uniqueID
        {
            get
            {
                return "ms__id" + this.___elementOID.ToString();
            }
        }
        /// <summary>
        /// MSIE Specific property returns string unique id as number
        /// </summary>
        public double uniqueNumber
        {
            get
            {

                return (double)this.___elementOID;

            }

        }
		public bool ___IsChildNodesContains(string[] tagNames)
		{
			bool r = false;
			int __childCount = this.___childNodes.Count;
			for(int i = 0; i < __childCount; i ++)
			{
				CHtmlElement cPart = this.___childNodes[i] as CHtmlElement;
				if(cPart != null)
				{
					if(Array.IndexOf(tagNames, cPart.tagName) > -1)
					{
						r = true;
					}
					if(r == false)
					{
						r = cPart.___IsChildNodesContains(tagNames);
					}
				}
				if(r == true)
					return true;
			}
			return false;
		}
		public void SetChildrenElementVisibilityAndRenderingRecursibly(bool __IsVisible, bool __IsRenderByParent)
		{
			int __childCount = this.___childNodes.Count;
			for(int i = 0; i < __childCount; i ++)
			{
				CHtmlElement childElement = this.___childNodes[i] as CHtmlElement;
				childElement.___IsRenderedByParent = __IsRenderByParent;
				if(childElement.___style != null)
				{
					if(__IsVisible)
					{
						childElement.___style.Visibility = "visible";
						childElement.___IsElementVisible = true;
					}
					else
					{
						if(childElement.___IsElementVisible == true)
						{
							childElement.___style.Visibility = "none";
							childElement.___IsElementVisible = false;
						}
					}
				}
				childElement.SetChildrenElementVisibilityAndRenderingRecursibly(__IsVisible, __IsRenderByParent);
			}
		}
		public void SetChildrenElementWidthRecursibly(int __Width)
		{
			int __childCount = this.___childNodes.Count;
			for(int i = 0; i < __childCount; i ++)
			{
				CHtmlElement childElement= this.___childNodes[i] as CHtmlElement;

				if(childElement.___IsElementVisible)
				{
					if(childElement.___offsetWidth  > __Width)
					{
						childElement.___offsetWidth = __Width;
					}
				}
				childElement.SetChildrenElementWidthRecursibly(__Width);
			}
		}


		/// <summary>
		/// dataset is readonly
		/// </summary>
		public CHtmlElementDataSet dataset
		{
			get{return this.___dataset;}
			
		}
		public CHtmlElementDataSet dataSet
		{
			get{return this.___dataset;}

		}
		public CHtmlElementDataSet DataSet
		{
			get{return this.___dataset;}
		}





        public void InvestigateParentCHtmlStyleElement(ref CHtmlStyleKey searchKey, ref ArrayList parentStyleList, ref CHtmlElement originElement, ref System.Collections.Generic.Dictionary<int, int> guidList)
		{
			if(this.___parentWeakRef  != null && this.___parentWeakRef.Target is CHtmlElement)
			{
				if(object.ReferenceEquals(this, this.___parentWeakRef.Target) == false)
				{
					this.___getParentElement().InvestigateParentCHtmlStyleElement(ref searchKey, ref parentStyleList, ref originElement, ref guidList);
				}
				else
				{
					//commonLog.LogEntry("InvestigateParentCHtmlStyleElement Abort for Parent it is the same object {0} : {1}" , this, this.parent);
				}
			}
			/*
			if(this.___MaxNumOfSelectorWorkingKeyCountInElement <= 0)
			{
				return;
			}
			*/
			if( this.___stylesheetsForNextNodeList.Count > 0)
			{
				for(int i = this.___stylesheetsForNextNodeList.Count -1; i >= 0; i--)
				{
					CHtmlCSSRule sPart = this.___stylesheetsForNextNodeList[i];
					if(sPart != null)
					{
						if(sPart.___isCSSRuleForThisNode == true )
						{
							continue;
						}
						if(sPart.___styleKeyWorkingList == null || sPart.___styleKeyWorkingList.Count == 0)
						{
							continue;
						}
                        if (guidList != null && guidList.ContainsKey(sPart.GetHashCode()) == true)
							continue;
						CHtmlStyleKey searchKeyNew = new CHtmlStyleKey();
						if(searchKey.TagName.Length != 0)
						{
							searchKeyNew.TagName   = searchKey.TagName;
                            searchKeyNew.___elementTagType = searchKey.___elementTagType;
                            searchKeyNew.___elementTagType = searchKey.___elementTagType;
						}
						if(searchKey.CssID.Length != 0)
						{
							searchKeyNew.CssID     = searchKey.CssID;
						}
						if(searchKey.___classList.Length <= 0)
						{
							InvestigatCHtmlStyleElementEqality(ref searchKey, ref parentStyleList,  ref sPart,ref searchKeyNew, this,  ref originElement,  ref guidList, false);
						} 
						else
						{
							foreach(string searchClass in  searchKey.___classList.___keyList.Keys)
							{
								if(searchClass.Length != 0)
								{
									if(string.CompareOrdinal(searchClass, 0, ".", 0 , 1 ) == 0)
									{
										searchKeyNew.CssClass = searchClass;
										InvestigatCHtmlStyleElementEqality(ref searchKey, ref parentStyleList,  ref sPart,ref searchKeyNew,  this, ref originElement,ref guidList,  false);
									}
									else
									{
										searchKeyNew.CssClass = "." + searchClass;
										InvestigatCHtmlStyleElementEqality(ref searchKey, ref parentStyleList,  ref sPart,ref searchKeyNew, this, ref originElement,ref guidList,  false);
									}
								}
							}
						}
					}
				}
			}
		}
        public void InvestigateAdjacentCHtmlStyleElement(ref CHtmlStyleKey searchKey, ref ArrayList parentStyleList, ref CHtmlElement originElement, ref System.Collections.Generic.Dictionary<int, int> guidList, char __LookupCombinator)
		{
			if( this.___stylesheetsForNextNodeList.Count > 0 )
			{
				for(int i = this.___stylesheetsForNextNodeList.Count -1; i >= 0; i--)
				{
					CHtmlCSSRule sPart = this.___stylesheetsForNextNodeList[i];
					if(sPart != null)
					{
						if(sPart.___isCSSRuleForThisNode == true || sPart.___HasCombinatorChar == false)
						{
							continue;
						}
						if(sPart.___styleKeyWorkingList.Count == 0)
							continue;
						CHtmlStyleKey __curKey = sPart.___styleKeyWorkingList[0] as CHtmlStyleKey;
						if(__curKey == null)
							continue;
						if(__curKey.Combinator != __LookupCombinator)
						{
							continue;
						}
						CHtmlStyleKey searchKeyNew = new CHtmlStyleKey();
						searchKeyNew.TagName   = searchKey.TagName;
                        searchKey.___elementTagType = searchKey.___elementTagType;
						searchKeyNew.CssID     = searchKey.CssID;
						if(searchKey.___classList.Length <= 0)
						{
							InvestigatCHtmlStyleElementEqality(ref searchKey, ref parentStyleList,  ref sPart,ref searchKeyNew, this,  ref originElement, ref guidList, true);
						} 
						else
						{
							foreach(string searchClass in  searchKey.___classList.___keyList.Keys)
							{
								
								if(searchClass .Length != 0)
								{
									searchKeyNew.CssClass = "." + searchClass;
									InvestigatCHtmlStyleElementEqality(ref searchKey, ref parentStyleList, ref sPart,ref searchKeyNew, this, ref originElement,ref guidList,  true);
								}
							}
						}
					}
				}
			}
		}
        internal static void InvestigatCHtmlStyleElementEqality(ref CHtmlStyleKey searchKey, ref ArrayList parentStyleList, ref CHtmlCSSRule sPart, ref CHtmlStyleKey searchKeyNew, CHtmlElement containerElement, ref CHtmlElement originElement, ref System.Collections.Generic.Dictionary<int, int> guidList, bool LookupAdjacentElement)
		{
			try
			{
				if(sPart.___isCSSRuleForThisNode == false)
				{
					if(sPart.___styleKeyWorkingList.Count > 0)
					{
						CHtmlStyleKey __curKey =sPart.___styleKeyWorkingList[0] as CHtmlStyleKey;
						if(__curKey != null)
						{
                            if (string.IsNullOrEmpty(__curKey.TagName) == false && __curKey.TagName.Length == 1 && __curKey.TagName[0] =='*')
							{
								if( LookupAdjacentElement == true)
								{
									if(__curKey.Combinator == '+')
									{
										goto AsteriskDone;
									}
								}
                                CHtmlCSSRule copyPart = sPart.cloneCSSRule();
								copyPart.___styleKeyWorkingList.RemoveAt(0);
								copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
								int iWorkCount = copyPart.___styleKeyWorkingList.Count;
								if(originElement.___stylesheetsForNextNodeListWorkingSelectorMaximumCount < iWorkCount)
								{
									originElement.___stylesheetsForNextNodeListWorkingSelectorMaximumCount = iWorkCount;
								}
								if(iWorkCount == 0)
								{
									copyPart.___isCSSRuleForThisNode = true;
								}								
								else
								{
									if(copyPart.___HasCombinatorChar == true)
									{
										// Next Selector Key may be '~'.
										// In the case. Set Element ___hasInner Indirect Adjacent Combinator Flag
										// in order to indicate the node ___hasInner '~' style to be looked up.
										if(originElement != null && originElement.___HasCSSIndirectAdjacentCombinator == false)
										{
											bool _containsIndirectCombinator = false;
											bool _containsAdjacentSiblingCombinator = false;
											if(copyPart.___styleKeyWorkingList.Count > 0)
											{
												CHtmlStyleKey _lowKey = copyPart.___styleKeyWorkingList[0] as CHtmlStyleKey;
												if(_lowKey != null)
												{
													if(_lowKey.Combinator == '~')
													{
														_containsIndirectCombinator = true;
													}
													if(_lowKey.Combinator == '+')
													{
														_containsAdjacentSiblingCombinator = true;
													}
												}
											}
											originElement.___HasCSSIndirectAdjacentCombinator = _containsIndirectCombinator;
											if(_containsIndirectCombinator == true && originElement.___parentWeakRef  != null)
											{
                                                originElement.___getParentElement().___HasCSSIndirectAdjacentCombinatorInChildren = true;
											}
											if(_containsAdjacentSiblingCombinator == true)
											{
												originElement.___HasCSSAdjacentSiblingCombinator = _containsAdjacentSiblingCombinator;
												if(originElement.___HasCSSAdjacentSiblingCombinator == true && originElement.___parentWeakRef != null)
												{
                                                    originElement.___getParentElement().___HasCSSAdjacentSiblingCombinatorInChildren = true;
												}
											}
										}
									}
								}
								/*
								if(originElement.___MaxNumOfSelectorWorkingKeyCountInElement < iWorkCount)
								{
									originElement.___MaxNumOfSelectorWorkingKeyCountInElement = iWorkCount;
								}
								*/
								if(guidList != null)
								{
                                    guidList[copyPart.GetHashCode()] = copyPart.___styleKeyWorkingList.Count;
								}
								parentStyleList.Add(copyPart);
								return;
							}
						AsteriskDone:

							bool r = commonHTML.IsCHtmlStyleElementKeyClassEqual(searchKeyNew,__curKey);
							if(r == true)
							{
								bool ___FoundClassOrIDMismatch = false;
								if(__curKey.___StyleSelectorKeyDataMode == CHtmlStyleSelectorKeyDataModeType.TagOnly)
								{
									goto CombinatorLookUpSection;
								}

								if(searchKeyNew.CssClass.Length != 0  && __curKey.CssClass.Length != 0 && string.Equals(searchKeyNew.CssClass, __curKey.CssClass, StringComparison.Ordinal) == false)
								{
									if(searchKeyNew.___classList.Count <= 1 && __curKey.___classList.Count <= 1)
									{			
										___FoundClassOrIDMismatch = true;
										return;
									}
									
								}
								if(searchKeyNew.CssID .Length != 0 && __curKey.CssID .Length != 0 && string.Equals(searchKeyNew.CssID, __curKey.CssID, StringComparison.Ordinal) == false)
								{
									___FoundClassOrIDMismatch = true;
									return;
								}
								if(searchKeyNew.CssID.Length == 0 &&  __curKey.CssID .Length != 0)
								{
									___FoundClassOrIDMismatch = true;
									return;
								}
								if(searchKeyNew.CssClass.Length == 0 &&  __curKey.CssClass .Length != 0)
								{
									___FoundClassOrIDMismatch = true;
									return;
								}
								if(__curKey.___classList.Count == 1)
								{
									/*
									 * WorkingSelectorKey ___hasInner one single class name and TargetElement ___hasInner may ___hasInner multiple classes names.
									 * if it does not found in target names. skip it.
									 */
									if(searchKeyNew.___classList.ContainsKey(__curKey.CssClassLowSimple) == false)
									{
										___FoundClassOrIDMismatch = true;
										return;
									}
								}
								else if(__curKey.___classList.Count > 1)
								{
									int __ShouldMatchCount = __curKey.___classList.Count;
									int __FoundMatchCount = 0;
									if(originElement.___classList.Count < __curKey.___classList.Count)
									{
										// there is less number of class than expected. it should not match
										___FoundClassOrIDMismatch = true;
										return;
									}
									foreach(string __curKeyClass in __curKey.___classList.___keyList.Keys)
									{
										if(originElement.___classList.ContainsKey(__curKeyClass))
										{
											__FoundMatchCount ++;
										}

									}
									if(__FoundMatchCount < __ShouldMatchCount)
									{
										___FoundClassOrIDMismatch = true;
										return;
									}
								}
								if(__curKey.___StyleSelectorKeyDataMode == CHtmlStyleSelectorKeyDataModeType.IDOnly || __curKey.___StyleSelectorKeyDataMode == CHtmlStyleSelectorKeyDataModeType.ClassOnly)
								{
									goto CombinatorLookUpSection;
								}
                                if (__curKey.___attributeKeyList !=null && __curKey.___attributeKeyList.Count > 0)
								{

                                    int ____curKeyAttributesCount = __curKey.___attributeKeyList.Count;
                                    foreach( CHtmlStyleElementSelectorKeyAttributeClass? __curKeyNullable in __curKey.___attributeKeyList.Values)
                                    {
                                        if (__curKeyNullable != null)
										{
                                            CHtmlStyleElementSelectorKeyAttributeClass __curKeyAttr = __curKeyNullable.Value;
											if(originElement.___attributes.ContainsKey(__curKeyAttr.Name) == false)
											{
												___FoundClassOrIDMismatch = true;
												return;
											}
											else
											{
												string ___attrValue = commonHTML.GetElementAttributeInString(originElement, __curKeyAttr.Name);
												if(__curKeyAttr.IsValueMatches(___attrValue) == true)
												{
													continue;
												}
												else
												{
													___FoundClassOrIDMismatch = true;
													return;
												}

											}
										}
									}
								}



								if(__curKey.___pseudoTitleParamList.Count > 0)
								{
									/*
									 *  :link
										:visited
										:active
										:hover
										:focus
										:nth-child
										:nth-last-child
										:nth-of-type
										:first-of-type
										:last-of-type
										:empty
										:target
										:checked
										:enabled
										:disabled
									*/
									foreach(CHtmlPseudoClassType  ___preudoType in __curKey.___pseudoTitleParamList.Keys)
									{
                                        switch (___preudoType)
										{
										
											case CHtmlPseudoClassType.LinkPseudoClass:
											case  CHtmlPseudoClassType.ActivePseudoClass:
											case  CHtmlPseudoClassType.HoverPseudoClass:
											case  CHtmlPseudoClassType.VisitedPseudoClass:
											case CHtmlPseudoClassType.FocusPseudoClass:
												break;
											default:
												// may be first-chid;
												if(__curKey.IsSuffixMatchToElement(originElement)== false)
												{
													___FoundClassOrIDMismatch = true;
												}
												break;
										}
									}
								}
							CombinatorLookUpSection:
								if(__curKey.Combinator != '\0')
								{
									//commonLog.LogEntry(__curKey.Combinator);
									if(__curKey.Combinator == '+')
									{
										if( LookupAdjacentElement == false)
										{
											___FoundClassOrIDMismatch = true;
											return;
										}
									}
									else if(__curKey.Combinator == '>')
									{
										
										if(originElement != null && containerElement.___childNodes.Count > 0 && containerElement.___childNodes.Contains(originElement))
										{
											if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 100)
											{
												commonLog.LogEntry("Combinator Matches Container : {0} > Orignal : {1}", containerElement, originElement);
											}
										}
										else
										{
											___FoundClassOrIDMismatch = true;
											return;
										}

									} 
									else if(__curKey.Combinator == '~')
									{
										// This is after hit. Continue;
									}
									else
									{
										if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 30)
										{
											commonLog.LogEntry("Unknown combinabor but cont : {0}", __curKey.Combinator);
										}
									}
								}
											
								if(___FoundClassOrIDMismatch)
								{
									return;
								}

								CHtmlCSSRule copyPart = sPart.cloneCSSRule();
								copyPart.___styleKeyWorkingList.RemoveAt(0);
								copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
								int iWorkCount = copyPart.___styleKeyWorkingList.Count;
								if(originElement.___stylesheetsForNextNodeListWorkingSelectorMaximumCount < iWorkCount)
								{
									originElement.___stylesheetsForNextNodeListWorkingSelectorMaximumCount = iWorkCount;
								}
								if(iWorkCount == 0)
								{
									copyPart.___isCSSRuleForThisNode = true;
								}
								else
								{
									if(copyPart.___HasCombinatorChar == true)
									{
										// Next Selector Key may be '~'.
										// In the case. Set Element ___hasInner Indirect Adjacent Combinator Flag
										// in order to indicate the node ___hasInner '~' style to be looked up.
										if(originElement != null && originElement.___HasCSSIndirectAdjacentCombinator == false)
										{
											bool _containsIndirectCombinator = false;
											bool _containsAdjacentSiblingCombinator = false;
											if(copyPart.___styleKeyWorkingList.Count > 0)
											{
												CHtmlStyleKey _lowKey = copyPart.___styleKeyWorkingList[0] as CHtmlStyleKey;
												if(_lowKey != null)
												{
													if(_lowKey.Combinator == '~')
													{
														_containsIndirectCombinator = true;
													}
													if(_lowKey.Combinator == '+') 
													{
														_containsAdjacentSiblingCombinator = true;
													}
												}
											}
											originElement.___HasCSSIndirectAdjacentCombinator = _containsIndirectCombinator;
											if(_containsIndirectCombinator ==true && originElement.___parentWeakRef != null)
											{
												originElement.___getParentElement().___HasCSSIndirectAdjacentCombinatorInChildren = true;
											}
											if(_containsAdjacentSiblingCombinator == true)
											{
												originElement.___HasCSSAdjacentSiblingCombinator = _containsAdjacentSiblingCombinator;
												if(originElement.___HasCSSAdjacentSiblingCombinator == true && originElement.___parentWeakRef != null)
												{
                                                    originElement.___getParentElement().___HasCSSAdjacentSiblingCombinatorInChildren = true;
												}
											}
										}
									}
								}
								/*
								if(originElement.___MaxNumOfSelectorWorkingKeyCountInElement < iWorkCount)
								{
									originElement.___MaxNumOfSelectorWorkingKeyCountInElement = iWorkCount;
								}
								*/
								if(guidList != null)
								{
                                    guidList[copyPart.GetHashCode()] = copyPart.___styleKeyWorkingList.Count;
								}
								if(originElement.___stylesheetsForNextNodeListOriginalSelectorMaximumCount  < copyPart.___styleKeyOrignalList.Count)
								{
									originElement.___stylesheetsForNextNodeListOriginalSelectorMaximumCount  = copyPart.___styleKeyOrignalList.Count;
								}
								parentStyleList.Add(copyPart);
							}
						}
					}
				}
			}
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("InvestigatCHtmlStyleElementEqality", ex);
				}
			}
		}


		public void addEventListener(string __Name, object ___function, object boolObj)
		{

			this.___addEventListenerInner(__Name, ___function,commonData.convertObjectToBoolean(boolObj));
		}

		// 2-parameter overload for standard DOM usage (e.g., jQuery)
		public void addEventListener(string __Name, object ___function)
		{
			this.___addEventListenerInner(__Name, ___function, false);
		}

		public void addEventListener(object __NameObject, object ___function, [System.Runtime.InteropServices.Optional] object boolObj)
		{
			string name = __NameObject as string ?? (__NameObject?.ToString() ?? string.Empty);
			bool capture = false;
			if (boolObj != null && boolObj != System.Type.Missing)
			{
				 if (boolObj is bool b) capture = b;
				 else capture = commonData.convertObjectToBoolean(boolObj);
			}
			this.___addEventListenerInner(name, ___function, capture);
		}


		public bool detachEvent(string __Name, object ___function)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
			{
				commonLog.LogEntry("detachEvent called {0} : {1}", __Name, ___function);
			}
			return this.___removeEventInner(__Name, ___function);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="__eventObject"></param>
		/// <returns> True : Normal, False : preventDefault() is called</returns>
		
		public  bool dispatchEvent(object __eventObject)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("Element.dispatchEvent  {0} : {1} is enter", this, __eventObject);
            }
            try
            {
                CHtmlWindowEvent __dispEvent = __eventObject as CHtmlWindowEvent;
                if (__dispEvent != null)
                {
                    if (__dispEvent.___IsPreventDefaultCalled == true)
                    {
                        return false;
                    }
                    if (this.___Document != null)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("Element.dispatchEvent  {0} is about to calling Title : {1} Type : {2}", this, __dispEvent.EventTitle, __dispEvent.type);
                        }

                        CHtmlAttribute attributeEvent  = this.___attributes[__dispEvent.type] as CHtmlAttribute;
                        if (attributeEvent != null)
                        {
                            this.___Document.PerformCHtmlElementAction(this, attributeEvent, null, false, true);
                        }
                    }
                    else
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("Element.dispatchEvent  {0} is skip. No Document.", this);
                        }

                    }
                    return true;
                }
                else
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("TODO : Element.dispatchEvent  {0} : {1} is unexptected Type", this, __eventObject);
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("Element.dispatchEvent Error", ex);
                }
            }
			return true;
		}
		
		internal object ___getEventInfo(string __Name)
		{
			if(this.___attributes !=null && this.___attributes.length > 0)
			{
                CHtmlAttribute attr = null;
                if (this.___attributes.TryGetValue(__Name, out attr) == true)
                {
                    if (attr != null)
                    {
                        return attr.value;
                    }
                }
			}
            if (this.___IsPrototype == false && this.___Document != null)
            {

            }

			return null;
		}
        public void attachEvent(string __Name, object ___function)
        {
            if(commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
            {
               commonLog.LogEntry("attachEvent called {0} : {1}", __Name, ___function);
            }
            this.___addEventListenerInner(__Name, ___function, false);
        }
        internal void ___addEventListenerInner(string __evtName, object ___function, bool ___bool)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"enter {this}.___addEventListenerInner({__evtName}, {___function}, {___bool})");
            }
            // #region agent log
            try
            {
                var payload = System.Text.Json.JsonSerializer.Serialize(new Dictionary<string, object?>
                {
                    ["sessionId"] = "b0830d",
                    ["hypothesisId"] = "E",
                    ["location"] = "CHtmlElement:___addEventListenerInner",
                    ["message"] = "handler registered",
                    ["data"] = new Dictionary<string, object?>
                    {
                        ["evtName"] = __evtName,
                        ["handlerType"] = ___function?.GetType().FullName,
                        ["isScriptObject"] = ___function is Microsoft.ClearScript.ScriptObject,
                        ["element"] = this.ToString()
                    },
                    ["timestamp"] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                }) + Environment.NewLine;
                var logPaths = new[]
                {
                    System.IO.Path.GetFullPath(System.IO.Path.Combine(AppContext.BaseDirectory, "debug-b0830d.log")),
                    System.IO.Path.GetFullPath(System.IO.Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "debug-b0830d.log")),
                    @"C:\Users\USER\source\repos\MultiHtmlCraft\MultiHtmlCraaft.AvaloniaControl_Tesst\debug-b0830d.log"
                };
                foreach (var p in logPaths) { try { System.IO.File.AppendAllText(p, payload); break; } catch { } }
            }
            catch { }
            // #endregion
            if (this.___IsPrototype == true)
            {
                goto AttributeSection;
            }

            switch(__evtName)
            {
                case "onload":
                case "load":
                    this.___ElementLoadFunctionWeakReference = new WeakReference(___function);
                        callElementEventFunctionIfPossibible(__evtName, ___function);
                    break;

                case "onerror":
                case "error":
                    this.___ElementErrorFunctionWeakReference = new WeakReference(___function);
                    callElementEventFunctionIfPossibible(__evtName, ___function);
                    break;
                case "onclick":
                case "click":
                    this.___ElementClickFunctionWeakReference = new WeakReference(___function);
                    break;
                case "mouseover":
                case "onmouseover":
                        this.___ElementMouseOverFunctionWeakReference = new WeakReference(___function);
                        break;
                case "mouseout":
                case "onmouseout":
                    this.___ElementMouseOutFunctionWeakReference = new WeakReference(___function);
                    break;
                case "mousemove":
                case "onmousemove":
                    this.___ElementMouseMoveFunctionWeakReference = new WeakReference(___function);
                    break;
                case "mousedown":
                case "onmousedown":
                    this.___ElementMouseDownFunctionWeakReference = new WeakReference(___function); break;
                    break;

                case "dblclick":
                case "ondblclick":
                    this.___ElementDblClickFunctionWeakReference = new WeakReference(___function); break;
                    break;

                case "onkeypress":
                case "keypress":
                    this.___ElementKeyPressFunctionWeakReference = new WeakReference(___function); break;
                        break;
                case "onkeydown":
                case "keydown":
                    this.___ElementKeyDownFunctionWeakReference = new WeakReference(___function); break;
                    break;
                case "onkeyup":
                case "keyup":
                    this.___ElementKeyUpFunctionWeakReference = new WeakReference(___function); break;
                    break;
                case "onscroll":
                case "scroll":
                    this.___ElementScrollFunctionWeakReference = new WeakReference(___function); break;
                    break;

                default:
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                        commonLog.LogEntry($"Event {__evtName} is not supported for attachEvent in {this}");
                    }
                    return;
            }

        AttributeSection:
            CHtmlAttribute attr = new CHtmlAttribute();
            attr.name = __evtName;
            attr.setParentNode(this);
            attr.value = ___function;
            if (this.___IsElementPrefetchDummy == false)
            {

            }

            this.___attributes[__evtName] = attr;
            if (this.___IsPrototype == true)
            {
                this.___ElementPrototypeMethodPropertyCount++;
            }

        }
        internal void  callElementEventFunctionIfPossibible(string ___evtName, object ___function)
        {
            bool _isSrcDataCached = false;
            string _srcAbsouteUrlString = null;
            if (this.___elementTagType == CHtmlElementType.IMG || this.___elementTagType == CHtmlElementType.AUDIO || this.___elementTagType == CHtmlElementType.VIDEO)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry($"Attempting to call event handler for {___evtName} on {this} during ____addEventListener()");
                }
                string srcValue = commonHTML.GetElementAttributeInString(this, "src");
                if (!string.IsNullOrEmpty(srcValue))
                {

                    if (srcValue.StartsWith("http", StringComparison.OrdinalIgnoreCase) || srcValue.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                    {
                        _srcAbsouteUrlString = srcValue;
                    }
                    else if (this.___Document != null)
                    {
                        _srcAbsouteUrlString = commonHTML.GetAbsoluteUri(this.___Document.___src, "", srcValue);
                    }

                    if (CHmlMultiversalWebCache.isUrlDataCached(_srcAbsouteUrlString))
                    {
                        _isSrcDataCached = true;
                        goto ElementSrcDataIsFound;
                    }
                }
            }
            else
            {


                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry($"Event handler for {___evtName} on {this} is {(_isSrcDataCached ? "cached" : "not cached")} with src {_srcAbsouteUrlString}");
                    
                }
                return;
            }
            ElementSrcDataIsFound:
            if (___function != null && _isSrcDataCached)
            {
                try
                {
                    if (this.___Document == null || this.___Document.___window == null)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                        {
                            commonLog.LogEntry($"Cannot execute event handler for {___evtName} on {this} because document or window is null.");
                        }
                        return;
                    }
                    else
                        
                         if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                        commonLog.LogEntry($"Document and window are available for {this}. Attempting to execute event handler for {___evtName}.");
                    }
                    this.___Document.___window.___executeElementEventFunction(___evtName, this, ___function, new object[] { }) ;

                
                
                 

                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                        commonLog.LogEntry($"Error calling event handler for event {___evtName} in {this}", ex);
                    }
                }
            }
        }

        private bool ___IsElementNeedsFireTrackingQueueList()
        {
            switch (this.___elementTagType)
            {
                case CHtmlElementType.IMG:
                case CHtmlElementType.AUDIO:
                case CHtmlElementType.VIDEO:
                case CHtmlElementType.BODY:
                    return true;
            }
            return false;
        }
        


		public void focus()
		{

		}
		
		public double compareDocumentPosition(object otherNode)
		{
            CHtmlElement __otherNodeElement = null;
            if (otherNode is CHtmlElement)
            {
                __otherNodeElement = otherNode as CHtmlElement;
            }
            if (__otherNodeElement == null)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                {

                   commonLog.LogEntry(" compareDocumentPosition enment fail");

                }
                return 1;
            }
            return commonHTML.compareDocumentPositionInner(this, __otherNodeElement);
		}
		
		public CHtmlWindowEvent createEventObject()
		{
			CHtmlWindowEvent evt =new CHtmlWindowEvent();
			return evt;
		}
		
		public bool fireEvent(object _eventName)
		{
			return processEventInner(commonHTML.GetStringValue(_eventName), null, null,null);
		}
		
		public bool fireEvent(object _eventName, object __EventObject)
		{
			return processEventInner( commonHTML.GetStringValue(_eventName),  __EventObject, null,null);
		}
   
        public bool fireEvent(object _eventName, object __EventObject, object ___objCancelled)
        {
            return processEventInner(commonHTML.GetStringValue(_eventName), __EventObject,null, ___objCancelled);
        }
		
		private bool processEventInner(string _eventName, object __EventObject, CHtmlWindowEvent __dispEvent, object ___objCancelled)
		{
			try
			{
				if(_eventName.Length == 0 && __dispEvent != null)
				{
					_eventName = __dispEvent.EventTitle;
				}
             //   _eventName = _eventName;
				if(_eventName .Length != 0 && this.___Document != null)
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
					{
			
							commonLog.LogEntry("Invoking Event {0} : {1}", _eventName, this);
						
					}
					try
					{
                        CHtmlAttribute attributeEvent = null;

                        if (this.___attributes.TryGetValue(_eventName, out attributeEvent) == true)
                        {
                            if (attributeEvent != null)
                            {
                                this.___Document.PerformCHtmlElementAction(this, attributeEvent, null, false, true);
                            }
                        }
					}
					catch(Exception ex)
					{
						if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
						{
							commonLog.LogEntry("procesEventInner", ex);
						}
					}
					return true;
				}
				else
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
					{
						commonLog.LogEntry("Invoking Event {0} : {1} is cancelled no document", _eventName, this);
					}
				}
			}
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("processEventInner" + _eventName, ex);
				}
			}
			return false;
		}
		public CHtmlElement insertAdjacentElement(string sWhere, CHtmlElement oElement)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
            {
               commonLog.LogEntry("calling {0}.insertAdjacentElement({1}, {2})", this, sWhere, oElement);
            }
            CHtmlHtmlAdjacentType ___adjType = commonHTML.GetAdjacentType(sWhere);
            CHtmlCollection __newCol = new CHtmlCollection();
            if (oElement != null)
            {
                __newCol.Add(oElement);
                ___insertAdjacentProcessor(___adjType, __newCol);
            }
			return oElement;
		}
		public void insertAdjacentHTML(string sWhere, string sHTML)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 3)
			{
				commonLog.LogEntry("calling {0}.insertAdjacentHTML ({1}, {2})",this, sWhere, sHTML);
			}
            CHtmlHtmlAdjacentType ___adjType = commonHTML.GetAdjacentType(sWhere);
            CHtmlCollection ___col = commonHTML.CreateCHtmlElementsFromHTML(sHTML);
            ___insertAdjacentProcessor(___adjType, ___col);
			return;
		}
        private void ___insertAdjacentProcessor(CHtmlHtmlAdjacentType ___adjuType , CHtmlCollection __newNodes)
        {
            int ___processedNodeCount = 0;
            try
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                    CHtmlElement ___rootElement = null;
                    if (__newNodes.Count > 0)
                    {
                        ___rootElement = __newNodes[0] as CHtmlElement;
                       commonLog.LogEntry("<<<<<<<<<<<<<<<<<<<X>>>>>>>>>>>>>>>>>>>");
                       commonUtils.LogElementDOMTree( ___rootElement, "");
                       commonLog.LogEntry("<<<<<<<<<<<<<<<<<<<X>>>>>>>>>>>>>>>>>>>");
                    }
                    else
                    {

                    }
                }
                int __nodescount = __newNodes.Count;
                CHtmlElement ___eachNode = null;
                CHtmlElement ___parentNodeCur = null;
                CHtmlElement ___refNode = null;
                if (this.___parentWeakRef != null)
                {
                    ___parentNodeCur = this.___parent as CHtmlElement;
                }
                for (int i = 0; i < __nodescount; i++)
                {
                    ___eachNode = __newNodes[i] as CHtmlElement;
                    if (___eachNode == null)
                        continue;
                    ___processedNodeCount++;
                    switch (___adjuType)
                    {
                        case CHtmlHtmlAdjacentType.beforebegin:
                            // Insert as Before this node
                            // <--------------- This Point
                            // [This Node]
                            if (___parentNodeCur != null)
                            {
                                ___parentNodeCur.___insertBeforeInner(___eachNode, this);
                            }
                            break;
                        case CHtmlHtmlAdjacentType.beforeend:
                            // Insert as First  into this.childnodes
                            // [This Node]
                            //    +<--------This point
                            //    +[child1]
                            //    +[child2]
                            //    +[child3]
                            // [Next Node]
                            if (this.___childNodes.Count == 0)
                            {
                                this.___appendChildInner(___eachNode);
                            }
                            else
                            {
                                ___refNode = this.___childNodes[0] as CHtmlElement;
                                if (___refNode != null)
                                {
                                    // this implementation ___hasInner some issues, but it is ok now.
                                    this.___insertBeforeInner(___eachNode, ___refNode);
                                }
                            }
                            break;
                        case CHtmlHtmlAdjacentType.afterbegin:
                            // Insert as Last  into this.childnodes
                            // [This Node]
                            //    +[child1]
                            //    +[child2]
                            //    +[child3]
                            //    +<--------This point
                            // [Next Node]
                            this.___appendChildInner(___eachNode);
                            break;
                        case CHtmlHtmlAdjacentType.afterend:
                        case CHtmlHtmlAdjacentType.unknown:
                            // Insert Right After This node
                            if (___parentNodeCur != null)
                            {
                                if (___parentNodeCur.___childNodes.Count <= 1)
                                {
                                    ___parentNodeCur.appendChild(___eachNode);
                                }
                                else
                                {
                                    
                                    if(___parentNode.___childNodes.Count > this.___ChildNodeIndex + 1)
                                    {
                                    ___refNode = ___parentNode.___childNodes[this.___ChildNodeIndex + 1] as CHtmlElement;
                                    }else
                                    {
                                        ___refNode = this;
                                    }
                                    if (___refNode != null)
                                    {
                                        ___parentNodeCur.___insertBeforeInner(___eachNode, ___refNode);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("___insertAdjacentProcessor() Exception", ex);
                }
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___insertAdjacentProcessor() ___hasInner processed. with {0} new elements.", ___processedNodeCount);
            }
        }
		public void insertAdjacentText(string sWhere, string sText)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
            {
               commonLog.LogEntry("calling {0}.insertAdjacentText({1},{2})", this, sWhere, sText);
            }
            CHtmlHtmlAdjacentType ___adjType = commonHTML.GetAdjacentType(sWhere);
            CHtmlCollection ___col = commonHTML.CreateCHtmlElementsFromHTML(sText);
            this.___insertAdjacentProcessor(___adjType, ___col);
			return;
		}
		public CHtmlDocument document
		{
			get{return this.___Document;}
		}
		/// <summary>
		/// 
		/// </summary>
		public void blur()
		{

		}
		/// <summary>
		/// Retrieves a collection, in source order, of all controls in a given form. input type=image objects are excluded from the collection.
		/// Array of button, input, select, and textArea objects. 
		/// </summary>
		public CHtmlCollection elements
		{
			get
			{
				
                return this.GetFormElementList();
			}
		}

		/// <summary>
		/// Return previous element
		/// </summary>
		internal CHtmlElement PreviousElement
		{
			get
			{
                if (this.___parentWeakRef != null)
				{
					int pos = this.___parent.___childNodes.IndexOf(this);
					if(pos > 0)
					{
						return this.___parent.___childNodes[pos -1] as CHtmlElement;
					}
				}
				return null;
			}
		}

		
		public string outerHTML
		{
			get
			{
				System.Text.StringBuilder sbOuterHTML =new System.Text.StringBuilder();
				if(base.innerHTML.Length == 0)
				{
					sbOuterHTML.Append("<");
					sbOuterHTML.Append(this.tagName);
					sbOuterHTML.Append(">");
					sbOuterHTML.Append(this.innerHTML);
					sbOuterHTML.Append("</");
					sbOuterHTML.Append(this.tagName);
					sbOuterHTML.Append(">");
				}
				else
				{
					sbOuterHTML.Append("<");
					sbOuterHTML.Append(this.tagName);
					sbOuterHTML.Append(">");
					sbOuterHTML.Append(base.innerHTML);
					sbOuterHTML.Append("</");
					sbOuterHTML.Append(this.tagName);
					sbOuterHTML.Append(">");

				}
				return sbOuterHTML.ToString();

			}
			set
			{
                this.___ProcessOuterHTML(value);
			}

		}

   
        public string outerXml
        {
            get
            {
                System.Text.StringBuilder sbOuterHTML = new System.Text.StringBuilder();
                if (base.innerHTML.Length == 0)
                {
                    sbOuterHTML.Append("<");
                    sbOuterHTML.Append(this.tagName);
                    sbOuterHTML.Append(">");
                    sbOuterHTML.Append(this.innerHTML);
                    sbOuterHTML.Append("</");
                    sbOuterHTML.Append(this.tagName);
                    sbOuterHTML.Append(">");
                }
                else
                {
                    sbOuterHTML.Append("<");
                    sbOuterHTML.Append(this.tagName);
                    sbOuterHTML.Append(">");
                    sbOuterHTML.Append(base.innerHTML);
                    sbOuterHTML.Append("</");
                    sbOuterHTML.Append(this.tagName);
                    sbOuterHTML.Append(">");

                }
                return sbOuterHTML.ToString();

            }
            set
            {

                this.___ProcessOuterHTML(value);
            }

        }
        private void ___ProcessOuterHTML(string _html)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO : {0} ___hasInner set outerXml:{1}", this, _html);
            }

            int pos = -1;
            try
            {
                CHtmlElement ___parent = this.___parent as CHtmlElement;
                if (___parent == null)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("outerHtml counld not found prent", this);
                    }
                }
                    
                pos = this.___ChildNodeIndex;
             
                CHtmlCollection _nodeList = commonHTML.CreateCHtmlElementsFromHTML(_html);
                if (_nodeList.Count > 0)
                {
                    for (int i = 0; i < _nodeList.Count; i++)
                    {
                        CHtmlElement __nodeElement = _nodeList[i] as CHtmlElement;
                        if (__nodeElement != null)
                        {
                            ___parent.insertBefore(__nodeElement, this);
                            ___parent.removeChild(this);
                           
                            break;
                        }
                    }
                }
                _nodeList = null;

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("___ProcessOuterHTML ___hasInner set outerXml Error",ex);

                }
            }
        }
		
		public string innerHTML
		{
			set
			{
                if (base.innerHTML.Length != 0 && string.Equals(base.innerHTML, value,StringComparison.Ordinal) == true)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel > 10)
                    {
                       commonLog.LogEntry("set InnerHTML is called but value is identical. skip now...");
                    }
                    return;
                }
				base.innerHTML = value;
				if( this.___childNodes.Count > 0)
				{
					this.___childNodes.Clear();
				}
				if(this.___drawingObjectList != null && this.___drawingObjectList.Count > 0)
				{
                    this.___drawingObjectList = new System.Collections.Generic.List<CHtmlDrawingObject>();
				}
				if(this.___elementTagType == CHtmlElementType.SCRIPT || this.___elementTagType == CHtmlElementType.STYLE || this.___elementTagType == CHtmlElementType.COMMENT)
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 7)
					{
						commonLog.LogEntry("innerHTML  ___hasInner changed for {0}, it special node type.  just create Text Node: {1}" , this, value);
					}
					try
					{
						base.innerHTML = ""; // no innerHTML
						CHtmlTextElement ___textData = new CHtmlTextElement();
						___textData.___IsDynamicElement = true;
						___textData.___IsDynamicProcessDone = true;
						___textData.___IsHiddenElement = true;
						___textData.___IsElementVisible = false;
                        ___textData.___parentWeakRef = new WeakReference(this, false);
						___textData.value = value;
                        ___textData.___documentWeakRef = new WeakReference(this.___Document, false);
						___textData.___isApplyElemenetStyleSheetCalled = true;
						___textData.___isCalculateElementBoundsCalled = true;
						if(this.___Document != null && this.___Document.___IsDomModeFullParseMode() == true)
						{
							this.___Document.___registerElementDocumentElementID(___textData);
						}
						___textData.___ChildNodeIndex = this.___childNodes.Add(___textData);
                        this.___setElementCriticalPropertiesChildNode(___textData);
						if(this.___IsElementVisible == true)
						{
							this.___IsElementVisible = false;
						}
					}
					catch(Exception ex)
					{
						if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
						{
							commonLog.LogEntry("innerHTML createTextNode Failed {0} {1}" , this, ex.Message);
						}
						
					}
					return;
						
				}
				if(this.___Document == null)
				{
					//this.textNodes.Clear();

					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
					{
						commonLog.LogEntry("innerHTML ___hasInner set but Document is null: " + this.ToString());
					}
					return;
				}
				CHtmlDocument ___dynamicDoc = null;
				try
				{
                    if (this.___childNodes.Count > 0)
                    {
                        this.___childNodes.Clear();
                    }
                    this.___drawingObjectList = new System.Collections.Generic.List<CHtmlDrawingObject>();

					if(this.___Document != null)
					{
		
						if(base.innerHTML == null || base.innerHTML.Length == 0)
						{
							if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
							{
								commonLog.LogEntry(this.ToString() + " innerHTML changed to empty");
							}
							return;
						}
						if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
						{
							string __ProcessMode = "DynamicFullThreadDocumentMode";
							if(base.innerHTML.Length <= commonHTML.InnerHTMLCreateNodeCharCountSwitch)
							{
								__ProcessMode = "ManualParseMode";

							}
							commonLog.LogEntry(this.ToString() + " innerHTML changed using " + __ProcessMode + ") : "+ value);
						}
						if(base.innerHTML.Length > commonHTML.InnerHTMLCreateNodeCharCountSwitch)
						{
							 ___dynamicDoc = CHtmlDocument.CreateCHtmlDocumentFromHTML(base.innerHTML, this.___Document.charset, this.___Document.___URL,CHtmlDomModeType.HTMLSegment, true,true, true);
                             CHtmlElement __partialBodyElement = null;
                             if (___dynamicDoc.___body != null)
                             {
                                 __partialBodyElement = ___dynamicDoc.___body;
                                 goto BodyFound;
                             }
                             else
                             {
                                 if (___dynamicDoc.___documentElement != null)
                                 {
                                     foreach (CHtmlElement elem in ___dynamicDoc.___documentElement.___childNodes)
                                     {

                                         if (elem != null)
                                         {
                                             if (___ElementAfter.___elementTagType == CHtmlElementType.BODY)
                                             {
                                                 __partialBodyElement = elem;
                                                 goto BodyFound;
                                             }
                                         }
                                     }
                                 }
                                 
                             }
                             if (__partialBodyElement == null)
                             {
                                 if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
                                 {
                                    commonLog.LogEntry("Strange. Created Document ___hasInner no <body>...");
                                 }
                             }
                        BodyFound:
							if(__partialBodyElement != null)
							{
                                int __partialBodyElementChildNodeCount = __partialBodyElement.___childNodes.Count;
                                if (__partialBodyElementChildNodeCount == 0)
                                {
                                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
                                    {
                                       commonLog.LogEntry("Strange. Created Document  <body> have no childnodes ...");
                                    }
                                }
								for(int bPos = 0; bPos < __partialBodyElementChildNodeCount  ; bPos ++)
								{
									CHtmlElement __createdChild = __partialBodyElement.___childNodes[bPos] as CHtmlElement;
                                    if (__createdChild == null)
                                        continue;
                                    if (__createdChild.___IsDynamicElement == false)
                                    {
                                        __createdChild.___IsDynamicElement = true;
                                    }

                                    // ===============================================
                                    // Because Full Parsed node have assinged Document Element ID already, but it is old value
                                    // We neeed to clear to -1.
                                    // ===============================================
                                    __createdChild.___clearDocumentIndexRecursively(true);

                                    this.___appendChildInner(__createdChild);
                               
								}

							}
							else
							{
								if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
								{
									commonLog.LogEntry("innerHTML ___hasInner altered but no body craeted. Do nothing");
								}

                                //___dynamicDoc.Dispose(); // Do Not Dispose Elements.
                                ___dynamicDoc = null;
							}
						}
						else
						{
							CHtmlCollection _nodeList = commonHTML.CreateCHtmlElementsFromHTML(base.innerHTML);
                            int _nodeListCount = _nodeList.Count;
                            if (_nodeListCount > 0)
							{
                                this.___appendOrInsertChildRange(_nodeList, false, - 1);
							}
							_nodeList = null;
						}
                        if (this.___IsElementVisible == true && commonHTML.elementTagTypesNeverSeachStyleSheetSortedList.ContainsKey(this.___elementTagType) == false)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                            {
                                /*
                                 * May be reconsider elements bounds check later on
                                 */
                                if (this.___ClosedReson != CHtmlTagClosedReasonType.Open && this.___isCalculateElementBoundsCalled == true)
                                {
                                   commonLog.LogEntry("{0}.innerHTML ___hasInner altered childrens, but bounds check may be requied", this);

                                }
                            }
                        }
                        
						if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
						{
							commonLog.LogEntry("<<<<<<<<<<<<<<<<<<<X>>>>>>>>>>>>>>>>>>>");
							this.PrintChildNodeDOMTree("");
							commonLog.LogEntry("<<<<<<<<<<<<<<<<<<<X>>>>>>>>>>>>>>>>>>>");
						}
					}

				}
				catch(Exception ex)
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
					{
						commonLog.LogEntry("set {0}.innerHTML error : {1} '{2}'", this, ex.Message , value);
					}
					if( ___dynamicDoc != null)
					{
						 ___dynamicDoc.Dispose();
						 ___dynamicDoc = null;
					}
				}
			}
			get
			{
				return GetInnerHTMLInner();
			}
		}
		private string GetInnerHTMLInner()
		{
			if(this.___IsDynamicElement == true)
			{
				return commonHTML.CreateElementInnerHTML(this);
			}
			else
			{
				if(string.IsNullOrEmpty(base.___innerHTML) == true)
				{
					this.CreateInnerHTML();
                    if (string.IsNullOrEmpty(base.___innerHTML) == false)
                    {
                        return base.___innerHTML;
                    }
                    else
                    {
                        return "";
                    }
				}
				else
				{
                    if (string.IsNullOrEmpty(base.___innerHTML) == false)
                    {
                        return base.___innerHTML;
                    }
                    else
                    {
                        return "";
                    }
				}
			}

		}

		private void CreateInnerHTML()
		{
			if(string.IsNullOrEmpty(base.innerHTML) == true)
			{
				try
				{
					System.Text.StringBuilder sbInnerHTML = new System.Text.StringBuilder();
					if(this.___Document != null)
					{
						if(this.___TagOpenEndPosition > - 1 &&  this.___TagCloseStartPosition > - 1 && this.___TagOpenEndPosition  < this.___TagCloseStartPosition )
						{
							for(int i = this.___TagOpenEndPosition +1 ; i < this.___TagCloseStartPosition; i ++)
							{
                                sbInnerHTML.Append(this.___Document.___HtmlBuilder[i]);
							}
						}
						else
						{
							//commonLog.LogEntry("innerHTML {0} ___hasInner invalid postion ", this, this.TagOpenStartPosition, this.TagCloseEndPosition);
						}
					}
					base.innerHTML = sbInnerHTML.ToString();
				} 
				catch
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
					{
						commonLog.LogEntry("innerHTML {0} ___hasInner invalid data ", this, this.___TagOpenStartPosition, this.___TagCloseEndPosition);
					}
				}
			}
			else
			{
				return;
			}

		}

        /// <summary>
        /// return ownerDocument
        /// </summary>
		public CHtmlDocument ownerDocument
		{
			get{
                CHtmlDocument ___ownerDocumentReturnObject = null;
                if (this.___Document != null)
                {
                    ___ownerDocumentReturnObject = this.___Document;
                    goto ReturnPhase;
                }

            ReturnPhase:
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
                {
                    if (___ownerDocumentReturnObject != null)
                    {
                       commonLog.LogEntry("ownerDocument property for {0} will returns {1}", this, ___ownerDocumentReturnObject);
                    }
                    else
                    {
                       commonLog.LogEntry("ownerDocument property for {0} will returns null.", this);
                    }
                }
                return ___ownerDocumentReturnObject;
            }
		}




		public string autocomplete
		{
			set{this.SetGetAttributesByName("autocomplete", value, true);}
			get
			{
				if(this.___attributes.ContainsKey("autocomplete"))
				{
					return commonHTML.GetElementAttributeInString(this, "autocomplete");
				}
				return "off";
			}
		}


		/// <summary>
		/// accesskey property. Value is string, not char.
		/// </summary>
		public string accessKey
		{
			set
			{
				if(this.___attributes.ContainsKey("accesskey"))
				{
					this.___attributes["accesskey"] = value;
				}
				else
				{
					this.___attributes.Add("accesskey", value);
				}
			}
			get
			{
				if(this.___attributes.ContainsKey("accesskey"))
				{
					return commonHTML.GetElementAttributeInString(this, "accesskey");
				}
				else
				{
					return "";
				}
			}
		}


		
        public double addBehavior(object __bstrUrlObject, object ___pvarFactoryObject)
		{
            return this.___addBehavior_inner(__bstrUrlObject, ___pvarFactoryObject);
		}
   
        public double addBehavior(object __bstrUrlObject)
        {
            return this.___addBehavior_inner(__bstrUrlObject, null);
        }
        private double ___addBehavior_inner(object __bstrUrlObject, object ___pvarFactoryObject)
		{
            string strUrlObject = commonHTML.GetStringValue(__bstrUrlObject);
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 30)
            {
               commonLog.LogEntry("{0}.addBehavior({1}, {2}) called. just skip.", this, __bstrUrlObject, ___pvarFactoryObject);
            }
            return -1;
		}


		
		public bool removeBehavior(object ___oid)
		{
            /*
			if(this.___style != null)
			{
				this.___style.Behavior = "";
			}
             * */
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 30)
            {
               commonLog.LogEntry("{0}.removeBehavior({1}) called. do thing.", this, ___oid);
            }

			return true;
		}


        public ICHtmlCollectionInterface childNodes
        {
            get
            {
                var _cResultList = this.___childNodes as ICHtmlCollectionInterface;
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    int resultlen = _cResultList.length;
                    commonLog.LogEntry("returns {0}.childNode : {1} {2}", this, _cResultList, resultlen);
                }
                return _cResultList;

            }
        }


        /// <summary>
        /// ___cloneNodeInner can be called from script and code inside
        /// </summary>
        /// <returns></returns>

        public CHtmlElement cloneNode()
		{
			return ___cloneNode_Inner(false);
		}
        public CHtmlElement cloneNode(object childCopyObject)
        {
            return ___cloneNode_Inner(childCopyObject);
        } 


        internal  CHtmlElement ___cloneNode_Inner(object childCopyObject)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 3)
            {
               commonLog.LogEntry("calling {0}.___cloneNodeInner({1})...", this, childCopyObject);
            }
             bool childCopy = false;
             if (childCopyObject != null)
             {
                 childCopy = commonData.convertObjectToBoolean(childCopyObject);
             }
			/*
			if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
			{
				//commonLog.LogEntry("{0} ___cloneNodeInner({1}) is called", this, childCopy);
			}
			*/
			CHtmlElement cloneElement = this.___createCHtmlElementWithDomType();
			cloneElement.___IsDynamicElement = true;
			cloneElement.___SetTagNameOnly(this.tagName);
            cloneElement.___IsElementCloned = true;
			// We should not copy id of element. it should be identical for document
			// cloneElement.id = string.copy(this.id);
			
			if(string.IsNullOrEmpty(base.___name) == false)
			{
				cloneElement.___name = string.Copy(base.___name);
			}
			
			if(string.IsNullOrEmpty(base.___class) == false)
			{
                cloneElement.___DontPerformClassListChange = true;

				cloneElement.___class = string.Copy(base.___class);
               
                cloneElement.___classList.___CopyFromClassList(this.___classList);
                cloneElement.___DontPerformClassListChange = false;
			}
			if(string.IsNullOrEmpty(base.___id) == false)
			{
				cloneElement.id = string.Copy(base.___id);
			}
			
			
			
			cloneElement.___elementTagType = this.___elementTagType;

            cloneElement.___documentWeakRef = new WeakReference(this.___Document, false);
			

			//cloneElement.DocumentElementIndex = this.DocumentElementIndex;
			try
			{
				// ==============================================================================
				//                          Copy TextRange
				// ==============================================================================
				int ___childNodeCount = this.___childNodes.Count;
				if(___childNodeCount > 0)
				{
					for(int i = 0; i < ___childNodeCount; i ++)
					{
						CHtmlElement  _textNode = this.___childNodes[i] as CHtmlElement;
						if(_textNode !=null)
						{
							if(_textNode.___elementTagType == CHtmlElementType._ITEXT)
							{
								CHtmlTextElement _textClone = new CHtmlTextElement();
								_textClone.___IsDynamicElement = true;
								_textClone.___SetTagNameOnly(_textNode.tagName);
								_textClone.___elementTagType = _textNode.___elementTagType;
								
								try
								{
                                    if (_textNode.value is string || string.IsNullOrEmpty(_textNode.value as string) == false)
                                    {
                                        _textClone.value = string.Copy(_textNode.value as string);
                                    }
								}
                                catch (Exception ex)
                                {
                                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                                    {
                                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                                    }
                                }
                                _textClone.___parentWeakRef = new WeakReference(cloneElement, false);
								_textClone.___ChildNodeIndex = cloneElement.___childNodes.Add(_textClone);
                                cloneElement.___setElementCriticalPropertiesChildNode(_textClone);
								
							}
							else 
							{
								if(childCopy)
								{
									CHtmlElement element = _textNode;
									if(element != null)
									{
										CHtmlElement __childCloned = element.cloneNode(true);
										if(__childCloned != null)
										{
                                            __childCloned.___IsDynamicElement = true;

                                            __childCloned.___parentWeakRef = new WeakReference(cloneElement, false);
											__childCloned.___ChildNodeIndex = cloneElement.___childNodes.Add(__childCloned);
                                            cloneElement.___setElementCriticalPropertiesChildNode(__childCloned);
										}
									}
								}
							}
						}
					}
				}
			}
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                }
            }
		
			try
			{
				foreach(CHtmlAttribute objAttr in this.___attributes.Values)
				{
                    if (objAttr != null)
                    {
                        cloneElement.___attributes[objAttr.name] = objAttr.cloneNode();
                    }
				}
			}
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                }
            }
			/*
			if(InnerParagraphList != null)
			{
				cloneElement.InnerParagraphList.AddRange(this.InnerParagraphList.Clone() as ICollection);
			}
			*/
			if(string.IsNullOrEmpty(this.___src) == false)
			{
				cloneElement.src = string.Copy(base.___src);
			}
			if(string.IsNullOrEmpty(base.___href) == false)
			{
				cloneElement.href = string.Copy(base.___href);
			}
			
			if(this.___style != null)
			{
				cloneElement.___style = this.___style.CloneCHtmlStyleElement();
			
				cloneElement.___style.___StyleType = CHtmlElementStyleType.Element;
                cloneElement.___style.___ownerElementWeakReference = new WeakReference(cloneElement, false);
			}
	
			cloneElement.___isCalculateElementBoundsCalled = false;
			cloneElement.___IsStyleListSortedByHitForThisNode = false;
			cloneElement.value = this.value;
            // copyed object should have unique element oid
            cloneElement.___elementOID = commonHTML.getElementAdhocRandomNumber();
			return cloneElement;
		}

		#region GetVaiable
		/// <summary>
		/// [object] element support function
		/// </summary>
		/// <param name="_p1"></param>
		/// <returns></returns>
		
		public object GetVariable(object _p1)
		{
			return this.GetVariableInner(_p1, null, null);
		}
		/// <summary>
		/// [object] element support function
		/// </summary>
		/// <param name="_p1"></param>
		/// <returns></returns>
		
		public object GetVariable(object _p1, object _p2)
		{
			return this.GetVariableInner(_p1, _p2, null);
		}
		/// <summary>
		/// [object] element support function
		/// </summary>
		/// <param name="_p1"></param>
		/// <returns></returns>
		
		public object GetVariable(object _p1, object _p2, object _p3)
		{
			return this.GetVariableInner(_p1, _p2, _p3);

		}
		/// <summary>
		/// [object] element support function
		/// </summary>
		/// <param name="_p1"></param>
		/// <returns></returns>
		
		public object getVariable(object _p1)
		{
			return this.GetVariableInner(_p1, null, null);
		}
		/// <summary>
		/// [object] element support function
		/// </summary>
		/// <param name="_p1"></param>
		/// <returns></returns>
		
		public object getVariable(object _p1, object _p2)
		{
			return this.GetVariableInner(_p1, _p2, null);
		}
		/// <summary>
		/// [object] element support function
		/// </summary>
		/// <param name="_p1"></param>
		/// <returns></returns>
		
		public object getVariable(object _p1, object _p2, object _p3)
		{
			return this.GetVariableInner(_p1, _p2, _p3);

		}
		private object GetVariableInner(object _p1, object _p2, object _p3)
		{

			try
			{
				string __p1string = commonHTML.GetStringValue(_p1);
				switch(commonHTML.FasterToLower(__p1string))
				{
					case "$version":
						if(this.___elementTagType == CHtmlElementType.OBJECT || this.___elementTagType == CHtmlElementType.EMBED)
						{
							if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 10)
							{
								commonLog.LogEntry("{0}.GetVariable({1}, {2} , {3}) returns flash version string. simply cause object tag", this, _p1, _p2, _p3);
							}
                            if (CHtmlNavigator.___FlashVersionString != null && CHtmlNavigator.___FlashVersionString.Length != 0)
                            {
                                return CHtmlNavigator.___FlashVersionString;
                            }
                            else
                            {
                                return "14.0 r800";
                            }
						}
						break;
					default:
						break;
				}
			} catch(Exception ex)
			{

                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("GetVariableInner Exception.", ex);
                }
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 10)
			{
				commonLog.LogEntry("{0}.GetVariable({1}, {2} , {3}) returns empty string", this, _p1, _p2, _p3);
			}
			return (object)"";
		}
		#endregion

        /*
   
        public void load()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: Behaviors {0}.load() called :", this);
            }
        }

		
		public void load(object  ___s)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
			{
				commonLog.LogEntry("TODO: Behaviors {0}.load({1}) called :", this, ___s);
			}
		}
         * */
		
		public void reset()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
			{
				commonLog.LogEntry("reset() called");
			}

		}
		
		public void save(string ___s)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
			{
				commonLog.LogEntry("TODO: Behaviors Save() called :" + ___s);
			}
		}
		
		public object onload
		{
			get
			{
				return this.___getEventInfo("onload");
			}
			set
			{
                this.___addEventListenerInner("onload", value, false);
			}
		}
		/// <summary>
		/// FrameSet ___hasInner onunload property. just in case...
		/// </summary>
		
		public object onunload
		{
			get
			{
				return this.___getEventInfo("onunload");
			}
			set
			{
                this.___addEventListenerInner("onunload", value, false);
			}
		}
		
		public object onblur
		{
			get
			{
				return this.___getEventInfo("onblur");
			}
			set
			{
                this.___addEventListenerInner("onblur", value, false);
			}
		}
		
		public object onmove
		{
			get
			{
				return this.___getEventInfo("onmove");
			}
			set
			{
				this.attachEvent("onmove", value);
			}
		}
		
		public object onpaste
		{
			get
			{
				return this.___getEventInfo("onpaste");
			}
			set
			{
				this.attachEvent("onpaste", value);
			}
		}
		
		public object oncopy
		{
			get
			{
				return this.___getEventInfo("oncopy");
			}
			set
			{
                this.___addEventListenerInner("oncopy", value, false);
			}
		}
		
		public object oncut
		{
			get
			{
				return this.___getEventInfo("oncut");
			}
			set
			{
				this.attachEvent("oncut", value);
			}
		}
		
		public object onchange
		{
			get
			{
				return this.___getEventInfo("onchange");
			}
			set
			{
				this.attachEvent("onchange", value);
			}
		}
		
		public object oncellchange
		{
			get
			{
				return this.___getEventInfo("oncellchange");
			}
			set
			{
				this.attachEvent("oncellchange", value);
			}
		}
		
		public object onbeforecut
		{
			get
			{
				return this.___getEventInfo("onbeforecut");
			}
			set
			{
				this.attachEvent("onbeforecut", value);
			}
		}
		
		public object onselectstart
		{
			get
			{
				return this.___getEventInfo("onselectstart");
			}
			set
			{
				this.attachEvent("onselectstart", value);
			}
		}
		
		public object oncontextmenu
		{
			get
			{
				return this.___getEventInfo("oncontextmenu");
			}
			set
			{
				this.attachEvent("oncontextmenu", value);
			}
		}
		
		public object onmouseover
		{
			get
			{
				return this.___getEventInfo("onmouseover");
			}
			set
			{
                this.___addEventListenerInner("onmouseover", value, false);
			}
		}
		
		public object onmousemove
		{
			get
			{
				return this.___getEventInfo("onmousemove");
			}
			set
			{
                this.___addEventListenerInner("onmousemove", value, false);
			}
		}
		
		public object onmousedown
		{
			get
			{
				return this.___getEventInfo("onmousedown");
			}
			set
			{
				 this.___addEventListenerInner("onmousedown", value, false);
			}
		}
		
		public object onmouseup
		{
			get
			{
				return this.___getEventInfo("onmouseup");
			}
			set
			{
				 this.___addEventListenerInner("onmouseup", value, false);
			}
		}
		
		public object onmouseout
		{
			get
			{
				return this.___getEventInfo("onmouseout");
			}
			set
			{
				 this.___addEventListenerInner("onmouseout", value, false);
			}
		}
		
		public object onmousewheel
		{
			get
			{
				return this.___getEventInfo("onmousewheel");
			}
			set
			{
				 this.___addEventListenerInner("onmousewheel", value, false);
			}
		}
		
		public object onmouseenter
		{
			get
			{
				return this.___getEventInfo("onmouseenter");
			}
			set
			{
				 this.___addEventListenerInner("onmouseenter", value, false);
			}
		}
		
		public object onmouseleave
		{
			get
			{
				return this.___getEventInfo("onmouseleave");
			}
			set
			{
				 this.___addEventListenerInner("onmouseleave", value, false);
			}
		}
		
		public object onkeydown
		{
			get
			{
				return this.___getEventInfo("onkeydown");
			}
			set
			{
				 this.___addEventListenerInner("onkeydown", value, false);
			}
		}
		
		public object onkeyup
		{
			get
			{
				return this.___getEventInfo("onkeyup");
			}
			set
			{
				 this.___addEventListenerInner("onkeyyp", value, false);
			}
		}
		
		public object onkeypress
		{
			get
			{
				return this.___getEventInfo("onkeypress");
			}
			set
			{
				 this.___addEventListenerInner("onkeypress", value, false);
			}
		}
		
		public object onscroll
		{
			get
			{
				return this.___getEventInfo("onscroll");
			}
			set
			{
				 this.___addEventListenerInner("onscroll", value, false);
			}
		}
   
        public object onsubmit
        {
            get
            {
                return this.___getEventInfo("onsubmit");
            }
            set
            {
                this.___addEventListenerInner("onsubmit", value, false);
            }
        }
   
        public object ondragstart
        {
            get
            {
                return this.___getEventInfo("ondragstart");
            }
            set
            {
                this.___addEventListenerInner("ondragstart", value, false);
            }
        }
   
        public object ondragend
        {
            get
            {
                return this.___getEventInfo("ondragend");
            }
            set
            {
                this.___addEventListenerInner("ondragend", value, false);
            }
        }
   
        public object ondrag
        {
            get
            {
                return this.___getEventInfo("ondrag");
            }
            set
            {
                this.___addEventListenerInner("ondrag", value, false);
            }
        }
   
        public object ondrop
        {
            get
            {
                return this.___getEventInfo("ondrop");
            }
            set
            {
                this.___addEventListenerInner("ondrop", value, false);
            }
        }
		
		public object onhover
		{
			get
			{
				return this.___getEventInfo("onhover");
			}
			set
			{
				this.attachEvent("onhover", value);
			}
		}
		
		public object onerror
		{
			get
			{
				return this.___getEventInfo("onerror");
			}
			set
			{
				 this.___addEventListenerInner("onerror", value, false);
			}
		}
		
		public object onerrorupdate
		{
			get
			{
				return this.___getEventInfo("onerrorupdate");
			}
			set
			{
				this.attachEvent("onerrorupdate", value);
			}
		}
		
		public object onresize
		{
			get
			{
				return this.___getEventInfo("onresize");
			}
			set
			{
				 this.___addEventListenerInner("onresize", value, false);
			}
		}
   
        public object ontouchstart
        {
            get
            {
                return this.___getEventInfo("ontouchstart");
            }
            set
            {
                this.___addEventListenerInner("ontouchstart", value, false);
            }
        }
   
        public object ontouchend
        {
            get
            {
                return this.___getEventInfo("ontouchend");
            }
            set
            {
                this.___addEventListenerInner("ontouchend", value, false);
            }
        }
		
		public object onresizestart
		{
			get
			{
				return this.___getEventInfo("onresizestart");
			}
			set
			{
				this.attachEvent("onresizestart", value);
			}
		}
		
		public object onresizeend
		{
			get
			{
				return this.___getEventInfo("onresizeend");
			}
			set
			{
				this.attachEvent("onresizeend", value);
			}
		}
		
		public object onactivate
		{
			get
			{
				return this.___getEventInfo("onactivate");
			}
			set
			{
				 this.___addEventListenerInner("onactivate", value, false);
			}
		}
		
		public object onbeforeactivate
		{
			get
			{
				return this.___getEventInfo("onbeforeactivate");
			}
			set
			{
				this.attachEvent("onbeforeactivate", value);
			}
		}
		
		public object onfocus
		{
			get
			{
				return this.___getEventInfo("onfocus");
			}
			set
			{
				 this.___addEventListenerInner("onfocus", value, false);
			}
		}
		
		public object onfocusin
		{
			get
			{
				return this.___getEventInfo("onfocusin");
			}
			set
			{
				 this.___addEventListenerInner("onfocusin", value, false);
			}
		}
		
		public object onfocusout
		{
			get
			{
				return this.___getEventInfo("onfocusout");
			}
			set
			{
			 this.___addEventListenerInner("onfocusout", value, false);
			}
		}
        /// <summary>
        /// All Element should have Element.click() function
        /// It is not identical to Element.onclick or Element.addEventListener("click", func).
        /// </summary>
        public void click()
        {
            object ___clickFunction = null;
            if (this.___ElementClickFunctionWeakReference != null)
            {
                ___clickFunction = this.___ElementClickFunctionWeakReference.Target;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: calling {0}.click() FunctionObject: {1}", this.toLogString(), ___clickFunction);
            }
            return;
        }
		
		public object onclick
		{
			get
			{
				return this.___getEventInfo("onclick");
			}
			set
			{
				 this.___addEventListenerInner("onclick", value, false);
			}
		}

		
		public object ondblclick
		{
			get
			{
				return this.___getEventInfo("ondblclick");
			}
			set
			{
				this.___addEventListenerInner("ondblclick", value, false);
			}
		}
		
		public object onabort
		{
			get
			{
				return  this.___getEventInfo("onabort");
			}
			set
			{
				this.___addEventListenerInner("onabort", value, false);
			}
		}

		
		
		public object onreadystatechange
		{
			get
			{
				return this.___getEventInfo("onreadystatechange");
			}
			set
			{
				this.___addEventListenerInner("onreadystatechange", value, false);
			}
		}
		public string readyState
		{
			get
			{
				if(this.___Document != null)
				{
					return this.___Document.readyState;
				}
				else
				{
					return "complete";
				}
			}
		}
		public string readyStateValue
		{
			get
			{
				if(this.___Document != null)
				{
					return this.___Document.readyState;
				}
				else
				{
					return "loading";
				}
			}
		}
		public CHtmlCSSStyleSheet currentStyle
		{
			get{return this.___style;}
		}

		/// <summary>
		/// Retrieves a value indicating whether the object can contain children.
		/// </summary>
		public bool canHaveChildren
		{
			get{return true;}
		}
        public ICHtmlElementInterface nextElementSibling
        {
            get
            {
                return this.nextSibling;
            }
        }
		/// <summary>
		/// Retrieves a reference to the next child of the parent for the object.
		/// </summary>
		
		public ICHtmlElementInterface nextSibling
		{
			get
			{
				CHtmlElement __parentNode = this.___parent as CHtmlElement;
				if(__parentNode != null)
				{
					int pos = this.___ChildNodeIndex + 1;
                    while (pos < __parentNode.___childNodes.Count)
                    {
                        try
                        {
                            CHtmlElement elem = __parentNode.___childNodes[pos] as CHtmlElement;
                            if (elem == null)
                                goto NextEelement;
                            if (commonHTML.IsSystemHiddenElement(elem.___elementTagType) == false)
                            {
                                return elem;
                            }
                            else
                            {
                                goto NextEelement;
                            }


                        }
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 11)
                            {
                               commonLog.LogEntry("nextSibling Error : " + ex.Message);
                            }
                            return null;
                        }
                    NextEelement:
                        pos++;
                    }
				}
				else
				{
					return null;
				}
				return null;
			}
		}
   
        public ICHtmlElementInterface previousElementSibling
        {
            get
            {
                return this.previousSibling;
            }
        }
		/// <summary>
		/// Retrieves a reference to the next child of the parent for the object. Assuming ChildNodeIndex is proper value
		/// Note) It may returns Text Node
		/// </summary>
		
		public ICHtmlElementInterface previousSibling
		{
			get
			{
				CHtmlElement __parentNode = this.___parent as CHtmlElement;
				if( __parentNode != null)
				{
					int pos =  this.___ChildNodeIndex - 1;
					while(pos >= 0)
					{
						try
						{
                            if (pos >= 0)
                            {
                                CHtmlElement prvNode = __parentNode.___childNodes[pos] as CHtmlElement;
                                if (prvNode != null)
                                {
                                    if (commonHTML.IsSystemHiddenElement(prvNode.___elementTagType) == false)
                                    {
                                        return prvNode;
                                    }
                                    else
                                    {
                                        goto NextElement;
                                    }
                                }
                                else
                                {
                                    goto NextElement;
                                }
                            }
                            else
                            {
                                break;
                            }
						}
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 11)
                            {
                               commonLog.LogEntry("previousSibling Error : " + ex.Message);
                            }
                            return null;
                        }
                    NextElement:
						pos --;
					}
				}
				else
				{
					return null;
				}
				return null;
			}
		}

		/// <summary>
		/// Property For IFrame
		/// </summary>
        public object contentWindow
        {
            get
            {



                if (this.___elementTagType == CHtmlElementType.IFRAME || this.___elementTagType == CHtmlElementType.FRAME)
                {
                    if (this.___iframeMultiversalWindow != null)
                    {
                        return this.___iframeMultiversalWindow;
                    }
                    else
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("Strange!  {0}.contentWindow returns ___hasInner failed....", this);
                        }
                    }
                }



                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("{0}.contentWindow returns ___hasInner failed....", this);
                }



                return null;
            }
        }
        

        /// <summary>
        /// Set Element Status Comelete 
        /// </summary>
        /// <param name="___isComplete"></param>
        internal void ___set_element_complete(bool ___isComplete)
        {
            this.___complete = ___isComplete;
        }
		
		/// <summary>
		/// When an element is disabled, it appears dimmed and does not respond to user input. Disabled elements do not respond to mouse events, nor will they respond to the contentEditable property. 
		/// </summary>
		public bool disabled
		{
			get
			{
				return this.___disabled;
				
			}
			set
			{
				this.SetGetAttributesByName("disabled", value, true);
				this.___disabled = value;
                if (this.___elementTagType == CHtmlElementType.LINK)
                {

                    if (this.___hrefBase != null && string.IsNullOrEmpty(this.___hrefBase.___Href) == false && this.___documentWeakRef != null)
                    {

                        if (this.___getDocument().___IsDomModeFullParseMode() == true && this.___getDocument().___LinkDisabledHerfList != null)
                        {
                            if (System.Threading.Monitor.TryEnter(this.___getDocument().___LinkDisabledLockingObject, 1))
                            {
                                try
                                {
                                    if (value == true)
                                    {
                                        this.___getDocument().___LinkDisabledHerfList[this.___hrefBase.___Href] = null;
                                    }
                                    else
                                    {
                                        if (this.___getDocument().___LinkDisabledHerfList.ContainsKey(this.___hrefBase.___Href) == true)
                                        {
                                            this.___getDocument().___LinkDisabledHerfList.Remove(this.___hrefBase.___Href);
                                        }
                                    }
                                }
                                catch(Exception ex)
                                {
                                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                                    {
                                       commonLog.LogEntry("Element disable processing error", ex);
                                    }
                                }
                                finally
                                {
                                    System.Threading.Monitor.Exit(this.___Document.___LinkDisabledLockingObject);
                                }
                            }
                        }
                    }
                }
			}
		}
		public bool isdisabled
		{
			get{return this.___disabled;}
			set
			{
				this.___disabled = value;
				this.SetGetAttributesByName("disabled", value, true);
			}
		}

		/// <summary>
		/// Attributes for image only 
		/// </summary>
		public double height
		{
			get
			{
				if(this.___style != null)
				{
                    return commonHTML.GetDoubleValueFromString(this.___style.___Height, 0, 0);
                }
				else
				{
					return 0;
				}
			}
		}
		/// <summary>
		/// Attributes for image only 
		/// </summary>
		public double width
		{
			get
			{
				if(this.___style != null)
				{
                   return commonHTML.GetDoubleValueFromString(this.___style.___Width, 0,0);
				}
				else
				{
					return 0;
				}
			}
		}

	
		public string dataSrc
		{
            set { this.___dataSrc = value; }
            get { return commonHTML.___convertNullToEmpty(this.___dataSrc); }
		}
		public string datasrc
		{
            set { this.___dataSrc = value; }
            get { return commonHTML.___convertNullToEmpty(this.___dataSrc); }
		}
		public string DataSrc
		{
			set{this.___dataSrc = value;}
            get { return commonHTML.___convertNullToEmpty(this.___dataSrc); }
		}
		public bool syncMaster
		{
			set{this.___syncMaster = value;}
			get{return this.___syncMaster;}
		}

		public bool isTextEdit
		{
			set{this.___isTextEdit = value;}
			get{return this.___isTextEdit;}
		}
		public bool istextedit
		{
			set{this.___isTextEdit = value;}
			get{return this.___isTextEdit;}
		}
		public bool isTextedit
		{
			set{this.___isTextEdit = value;}
			get{return this.___isTextEdit;}
		}
		public bool isMultiline
		{
			set{
				this.___isMultiline = value;
				this.SetGetAttributesByName("ismultiline", value, true);
			}
			get{
				return this.___isMultiline;
			}
		}

		public string vLink
		{
			set{this.SetGetAttributesByName("vlink", value, true);}
			get{return this.SetGetAttributesByName("vlink", null, false) as string;}
		}
		public string vlink
		{
			set{this.SetGetAttributesByName("vlink", value, true);}
			get{return this.SetGetAttributesByName("vlink", null, false) as string;}
		}
		public string aLink
		{
			set{this.SetGetAttributesByName("alink", value, true);}
			get{return this.SetGetAttributesByName("alink", null, false) as string;}
		}
		public string alink
		{
			set{this.SetGetAttributesByName("alink", value, true);}
			get{return this.SetGetAttributesByName("alink", null, false) as string;}
		}
		public string Link
		{
			set{this.SetGetAttributesByName("link", value, true);}
			get{return this.SetGetAttributesByName("link", null, false) as string;}
		}
		public string link
		{
			set{this.SetGetAttributesByName("link", value, true);}
			get{return this.SetGetAttributesByName("link", null, false) as string;}
		}

		public string vspace
		{
			get
			{
				if(this.___style != null)
				{
					return this.___style.MarginTop;
				}
				return "";
			}
			set
			{
				if(this.___style != null)
				{
					this.___style.MarginTop = value;
				}
			}

		}
		public string hspace
		{
			get
			{
				if(this.___style != null)
				{
					return this.___style.MarginLeft;
				}
				return "";
			}
			set
			{
				if(this.___style != null)
				{
					this.___style.MarginLeft = value;
				}
			}
		}

		public bool canHaveHTML
		{
			set
			{
				this.SetGetAttributesByName("canhavehtml", value, true);
				this.___canHaveHTML = value;
			}
			get
			{
				return commonData.convertObjectToBoolean(this.SetGetAttributesByName("canhavehtml", null, false));
				
			}
		}

		public bool atomicselection
		{
			set
			{
				this.SetGetAttributesByName("atomicselection", value, true);
			}
			get
			{
				return commonData.convertObjectToBoolean(this.SetGetAttributesByName("atomicselection", null, false));
			}
		}
        public string timerContainer
        {
            set { this.___timerContainer = value; }
            get
            {
                if (string.IsNullOrEmpty(this.___timerContainer) == false)
                {
                    return this.___timerContainer;
                }
                else
                {
                    return "none";

                }
            }
        }

		public string Method
		{
			set
			{
				this.SetGetAttributesByName("method", value, true);
			}
			get
			{
				return commonHTML.GetStringValue(this.SetGetAttributesByName("method", null, false));
			}
		}
		public string method
		{
			set
			{
				this.SetGetAttributesByName("method", value, true);
			}
			get
			{
				return commonHTML.GetStringValue(this.SetGetAttributesByName("method", null, false));
			}
		}
		/// <summary>
		/// Boolean that indicates whether this SELECT allows more than one option to be selected simultaneously.
		/// </summary>
		public bool multiple
		{
			set
			{
				this.SetGetAttributesByName("multiple", value, true);
			}
			get
			{
				try
				{
					return commonData.convertObjectToBoolean(this.SetGetAttributesByName("multiple", null, false));
				}
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
				return false;
			}
		}

		internal object SetGetAttributesByName(string _attrName, object ___value, bool ___IsSet)
		{
            // Assuming _attrName is lowerCased
            string _NameLow = _attrName.ToLowerInvariant();
			if(___IsSet)
			{
                CHtmlAttribute existAttr = null;
                if (this.___attributes.TryGetValue(_attrName, out existAttr) == true)
				{
					bool ___IsValueSet = false;

                    if (existAttr != null)
					{
                        if (existAttr.value != ___value)
                        {
                            existAttr.value = ___value;
                            ___IsValueSet = true;
                        }
                        else
                        {
                            return "";
                        }
					}
				
					//if(commonCHtmlAttributeNamesDefaultValueIsStringList.ContainsKey(_NameLow) == false)
					//{
					if(___IsValueSet)
					{
                        if (commonHTML.ElementFieldsNeedsToTypeConversionSortedList.ContainsKey(existAttr.name) == true)
                        {
                            commonHTML.ConvertAttributeValueByNameIfNessesary(existAttr);

                        }
					}
					//}
					
				}
				else
				{
					CHtmlAttribute attr =new CHtmlAttribute();
					attr.name = _NameLow;
					attr.value = ___value;
					if(commonHTML.ElementFieldsNeedsToTypeConversionSortedList.ContainsKey(_NameLow) == false)
					{
						commonHTML.ConvertAttributeValueByNameIfNessesary(attr);
					}
					this.___attributes[_NameLow] = attr;
				}	
				
				return "";
			}
			else
			{
				try
				{
                    CHtmlAttribute attr = null;
					if(this.___attributes.TryGetValue(_NameLow, out attr) == true)
                    {
						if(attr != null)
						{
							return attr.value;
						}
						else
						{
							return null;
						}
					}
					else
					{
                        return null;
					}
				}
				catch (Exception ex)
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
					{
						commonLog.LogEntry("SetGetAttributesByName", ex);
					}
				}
				return null;
			}
		}
		/// <summary>
		/// HTMLElement length
		/// Sets or retrieves the number of objects in a collection.
		/// The form.length property does not count input type=image elements.
		///  To access all elements contained in a form, use the children collection.
		/// </summary>
		public object length
		{
			get
			{
				if(this.___Document != null && (this.___Document.___documentDomType == CHtmlDomModeType.XMLDOM || this.___Document.___documentDomType == CHtmlDomModeType.SVGDOM))
				{
					return this.___childNodes.length;
				}
				switch(this.___elementTagType)
				{
					case CHtmlElementType._ITEXT:
						string sText = this.value as string;
						if(sText != null)
						{
							return sText.Length;
						}
						else
						{
							return 0;
						}
					case CHtmlElementType.FORM:
					case CHtmlElementType.SELECT:
						return this.GetFormElementList().length;
					default:
						// other normal tag does not have length
						// therefore, "undefined". but let us return child count
						if(this.___childNodes != null)
						{
							return this.___childNodes.length;
						}
						else
						{
							return 0;
						}
				} 
			}
		}
		public object @object
		{
			get
			{
				//commonLog.LogEntry("CHtmlElement.object returns null");
				return null;
			}
		}
		public bool hasChildNodes()
		{
			if(this.___childNodes.Count > 0)
			{
				return true;
			}
			return false;
		}
		public bool hasMedia
		{
			set
			{
				this.SetGetAttributesByName("hasmedia", value, true);
			}
			get
			{
				try
				{
					return commonData.convertObjectToBoolean(this.SetGetAttributesByName("hasmedia", null, false));
				}
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
				return false;
			}
		}
		public void setExpression(string sPropertyName,string sExpression)
		{
			this.setExpression(sPropertyName,  sExpression, "");
		}
		public void setExpression(string sPropertyName,string sExpression, string sLanguage)
		{
			if(this.___style != null)
			{
				try
				{
					this.___style.GetType().InvokeMember(sPropertyName, System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance, null, this.___style, new object[]{sExpression});
					if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
					{
						commonLog.LogEntry("setExpression({0}, {1} success", sPropertyName, sExpression);
					}
				}
				catch
				{
					if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
					{
						commonLog.LogEntry("setExpression({0}, {1} failed", sPropertyName, sExpression);
					}
				}


				this.___style.setAttributeInner(commonHTML.FasterToLower(sPropertyName), sExpression, true, true);
				
			}
		}
		/// <summary>
		/// Rows and Cols is numeric value not string for IE and chrome
		/// FrameObject may returns string
		/// </summary>
		public object cols
		{
			set{this.SetGetAttributesByName("cols", value, true);}
			get{
                try
                {
                    if (this.___elementTagType == CHtmlElementType.FRAMESET)
                    {
                        return commonHTML.GetElementAttributeInString(this, "cols");

                    }
                    else
                    {

                        CHtmlAttribute attrValue = null;
                        this.___attributes.TryGetValue("cols", out attrValue);
                        if (attrValue != null)
                        {
                            if (this.___elementTagType == CHtmlElementType.TEXTAREA)
                            {
                                if (commonHTML.isClrNumeric(attrValue.___value))
                                {
                                    return attrValue.value;
                                }
                                else
                                {
                                    return commonData.GetDoubleFromObject(attrValue.value, 0);
                                }
                            }
                            else
                            {
                                return attrValue.value;
                            }
                        }
                        else
                        {
                            if (this.___elementTagType == CHtmlElementType.TEXTAREA)
                            {
                                return 0;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner row error {1}", this,commonData.GetExceptionAsString(ex));
                    }

                }
                return null;

			}
		}
		/// <summary>
		/// Rows and Cols is numeric value not string for IE and chrome
		/// if it is TABLE Element it should returns Array of elements
		/// </summary>
		public object rows
		{
			set
			{
				try
				{
					this.SetGetAttributesByName("rows", value, true);
				}
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
				
			}
			get{
				if(this.___elementTagType != CHtmlElementType.TABLE)
				{
					try
					{
                        if (this.___elementTagType == CHtmlElementType.FRAMESET)
                        {
                            return commonHTML.GetElementAttributeInString(this, "rows");

                        }
                        else
                        {
                            CHtmlAttribute attrValue = null;
                            this.___attributes.TryGetValue("rows", out attrValue);
                            if (attrValue != null)
                            {
                                if (this.___elementTagType == CHtmlElementType.TEXTAREA)
                                {
                                    if (attrValue.value is int)
                                    {
                                        return attrValue.value;
                                    }
                                    else
                                    {
                                        return (int)commonData.GetDoubleFromObject(attrValue.value, 0);
                                    }
                                }
                                else
                                {
                                    return attrValue.value;
                                }
                            }
                            else
                            {
                                if (this.___elementTagType == CHtmlElementType.TEXTAREA)
                                {
                                    return 0;
                                }
                            }
                        

                        }
					}catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("{0} ___hasInner row error {1}", this,commonData.GetExceptionAsString(ex));
                        }

                    }
                    return null;

				}
				else
				{
					return this.getElementsByTagName("TR");
				}
			}
		}
		/// <summary>
		/// TABLE Tags Cell element if it is TR Element it should returls list
		/// </summary>
		public object cells
		{
			set{
				if(this.___elementTagType == CHtmlElementType.TR || this.___elementTagType == CHtmlElementType.TD || this.___elementTagType == CHtmlElementType.TABLE)
				{
					return;
				}
				this.SetGetAttributesByName("cells", value, true);
			}
			get
			{
				if(this.___elementTagType != CHtmlElementType.TR && this.___elementTagType != CHtmlElementType.TD && this.___elementTagType != CHtmlElementType.TABLE)
				{
					try
					{
						return this.SetGetAttributesByName("cells", null, false);
					}
					catch
					{
						return null;
					}
				}
				else
				{
					if(this.___elementTagType == CHtmlElementType.TR)
					{
						return this.___childNodes;
					}
					else
					{
						// TD and TABLE SHOUD NOT HAVE CELLS
						return null;
					}
				}
			}
		}
		/// <summary>
		/// An integer that specifies the position of the row to insert (starts at 0). 
		/// The value of -1 can also be used; which result in that the new row will be inserted at the last position.
		/// This parameter is required in Firefox and Opera, but optional in Internet Explorer, Chrome and Safari.
		/// Normally insertedRow is not use appendChild. it should be appended to table when it is created.
		/// </summary>
		/// <param name="___rowPos"></param>
		private CHtmlElement insertRowInner(int ___rowPos)
		{
			CHtmlElement ___rowElement = this.createElement("TR");
			//___rowElement.id = "TEST";
			if(this.TableCells != null)
			{
				int __Cols = this.TableCells.GetLength(1);
				int __Rows = this.TableCells.GetLength(0);
				this.TableCells = commonHTML.ResizeTableCells(__Cols, __Rows + 1, ___rowPos, this.TableCells);
				int __PosInRow = 0;
				if(this.TableRows  != null)
				{
					this.TableRows = commonHTML.ResizeTableRow(__Rows + 1, ___rowPos, this.TableRows);
					try
					{
						if(___rowPos >= -1 && this.TableRows.Length > ___rowPos)
						{
							this.TableRows[___rowPos] = ___rowElement;
							__PosInRow = ___rowPos;
						}
						else
						{
							this.TableRows[this.TableRows.Length -1] = ___rowElement;
							__PosInRow = this.TableRows.Length -1;
						}
					}
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                        }
                    }
				}
				CHtmlElement __priorRow = null;
				if(__PosInRow == 0)
				{
					try
					{
						if(this.TableRows.Length > 0 && this.TableRows[1].___parentWeakRef != null)
						{
							try
							{
								this.TableRows[1].___parent.___childNodes.Insert(0, ___rowElement);
                                ___rowElement.___parentWeakRef = new WeakReference(this.TableRows[1].___parent);
                                ((CHtmlElement)this.TableRows[1].___parent).___setElementCriticalPropertiesChildNode(___rowElement);
							}
							catch
							{
								if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
								{
									commonLog.LogEntry("this.TableRows Error!");
								}

							}
						}
						else
						{
							if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
							{
								commonLog.LogEntry("Counld not find row at 0");
							}
						}
						goto InsertFinish;
					}
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                        }
                    }
				}
				if(__PosInRow > 0)
				{
					try
					{
						__priorRow  = this.TableRows[__PosInRow -1] as CHtmlElement;
					}
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                        }
                    }
				}
				if(__PosInRow != 0 && __priorRow == null)
				{
					try
					{
						__priorRow = this.TableRows[this.TableRows.Length -1] as CHtmlElement;
					}
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                        }
                    }
				}
				if(__priorRow != null)
				{
					int posPrior = __priorRow.___parent.___childNodes.IndexOf(__priorRow);
					if(posPrior != -1)
					{
						__priorRow.___parent.___childNodes.Insert(posPrior +1, ___rowElement);
                        ___rowElement.___parentWeakRef = new WeakReference(__priorRow.___parentWeakRef.Target, false);
                        if (___rowElement.___parentWeakRef.Target  is CHtmlElement)
                        {
                            CHtmlElement ____rowElementParent = ___rowElement.___parentWeakRef.Target as CHtmlElement;
                            ____rowElementParent.___setElementCriticalPropertiesChildNode(___rowElement);
                        }
					}
					else
					{
						__priorRow.___parent.___childNodes.Add(___rowElement);


                        ___rowElement.___parentWeakRef = new WeakReference(__priorRow.___parentWeakRef.Target, false);
                        if (___rowElement.___parentWeakRef.Target is CHtmlElement)
                        {
                            CHtmlElement ____rowElementParent = ___rowElement.___parentWeakRef.Target as CHtmlElement;
                            ____rowElementParent.___setElementCriticalPropertiesChildNode(___rowElement);
                        }
					}
					
				}
				

			}
			else
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 11)
				{
					commonLog.LogEntry("strange... insertRow() is called for non-table {0}, but cont", this);
				}
				this.appendChild(___rowElement);
			}
			InsertFinish:
			return ___rowElement;
		}
		/// <summary>
		/// An integer that specifies the position of the row to insert (starts at 0). 
		/// The value of -1 can also be used; which result in that the new row will be inserted at the last position.
		/// This parameter is required in Firefox and Opera, but optional in Internet Explorer, Chrome and Safari.
		/// </summary>
		/// <param name="___rowPos"></param>
		/// <returns>HTMLElement if success or returns null if error</returns>
		public CHtmlElement insertRow(int ___rowPos)
		{
			return this.insertRowInner(___rowPos);
		}
		public CHtmlElement insertRow()
		{
			return this.insertRowInner(-1);
		}
		public CHtmlElement insertCell()
		{
			return this.insertCell(-1);
		}
		public CHtmlElement insertCell(int __cellPos)
		{
			CHtmlElement tdElement = this.createElement("TD");
			if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
			{
				commonLog.LogEntry("TODO : Insert Cell is called");
			}
			return this.appendChild(tdElement);
		}
		public string rev
		{
			set{this.SetGetAttributesByName("rev", value, true);}
				get{return commonHTML.GetStringValue(this.SetGetAttributesByName("rev", null, false));}
		}
		public string Rev
		{
			set{this.SetGetAttributesByName("rev", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("rev", null, false));}
		}

		public string rules
		{
			set{this.SetGetAttributesByName("rule", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("rules", null, false));}
		}
		public string background
		{
			set{this.SetGetAttributesByName("background", value, true);}
			get{return this.SetGetAttributesByName("background", null, false) as string;}
		}
		public string Background
		{
			set{this.SetGetAttributesByName("background", value, true);}
			get{return this.SetGetAttributesByName("background", null, false) as string;}
		}

		public string content
		{
			set{this.SetGetAttributesByName("content", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("content", null, false));}
		}
        /// <summary>
        /// CSSStylesheet
        /// </summary>
        public CHtmlCSSStyleSheet sheet
        {
            get
            {
                return this.___sheet;
            }
            // we should not have setter for this.
        }
		public string scheme
		{
			set{this.SetGetAttributesByName("scheme", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("scheme", null, false));}
		}
		public string httpEquiv
		{
			set{this.SetGetAttributesByName("httpequiv", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("httpequiv", null, false));}
		}
		/// <summary>
		/// Select Size Property is ListBox Height to display if non exists, Select become as dropbox
		/// </summary>
		public object size
		{
			set{this.SetGetAttributesByName("size", value, true);}
			get{return this.SetGetAttributesByName("size", null, false);}
		}
		/// <summary>
		/// IE Specific
		/// </summary>
		public string sizcache
		{
			set{this.SetGetAttributesByName("sizcache", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("sizecache", null, false));}
		}
        /// <summary>
        /// IE Specific
        /// </summary>
        public string srcdoc
        {
            set { this.SetGetAttributesByName("srcdoc", value, true); }
            get { return commonHTML.GetStringValue(this.SetGetAttributesByName("srcdoc", null, false)); }
        }
        public string longdesc
        {
            set { this.SetGetAttributesByName("longdesc", value, true); }
            get { return commonHTML.GetStringValue(this.SetGetAttributesByName("longdesc", null, false)); }
        }
        /// <summary>
        /// HTML : 
        /// </summary>
        public string localName
        {
            get
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("calling {0}.localName returns empty", this.toLogString());
                }
                return this.___tagNameNoNS;
                
            }
        }
        public string baseUri
        {
            get
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("calling {0}.baseUri returns empty", this.toLogString());
                }
                if (string.IsNullOrEmpty(this.___namepaceURI))
                {
                    return this.___namepaceURI;
                }else
                {
                    return "";
                }
            }
        }
        public string textContent
        {
            get
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("entering element.textContent...");
                }
                return this.innerText;
            }
            set { this.innerText = value; }
        }
        /// <summary>
        /// IE Specific
        /// </summary>
        public string sizset
		{
			set{this.SetGetAttributesByName("sizset", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("sizeset", null, false));}
		}
		public string httpequiv
		{
			set{this.SetGetAttributesByName("httpequiv", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("httpequiv", null, false));}
		}
		/// <summary>
		/// HTML object
		/// </summary>
		public string version
		{
			set{this.SetGetAttributesByName("version", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("version", null, false));}
		}

		public string bgColor
		{
			set{this.SetGetAttributesByName("bgcolor", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("bgcolor", null, false));}
		}
		public string encoding
		{
			set{this.SetGetAttributesByName("encoding", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("encoding", null, false));}
		}
		public string enctype
		{
			set{this.SetGetAttributesByName("enctype", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("enctype", null, false));}
		}
		/// <summary>
		/// string backgroundColor, user ___backgroundsysColor for true color
		/// </summary>
		public string backgroundcolor
		{
			set{this.SetGetAttributesByName("backgroundcolor", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("backgroundcolor", null, false));}
		}
		/// <summary>
		/// string backgroundColor, user ___backgroundsysColor for true color
		/// </summary>
		public string backgroundColor
		{
			set{this.SetGetAttributesByName("backgroundcolor", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("backgroundcolor", null, false));}
		}
		/// <summary>
		/// string foregroundColor, user ___foregroundsysColor for true color
		/// </summary>
		public string foregroundcolor
		{
			set{this.SetGetAttributesByName("foregroundcolor", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("foregroundcolor", null, false));}
		}
		/// <summary>
		/// string foregroundColor, user ___foregroundsysColor for true color
		/// </summary>
		public string foregroundColor
		{
			set{this.SetGetAttributesByName("foregroundcolor", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("foregroundcolor", null, false));}
		}
		public string encType
		{
			set{this.SetGetAttributesByName("enctype", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("enctype", null, false));}
		}
		public string acceptCharset
		{
			set{this.SetGetAttributesByName("acceptcharset", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("acceptcharset", null, false));}
		}
		public string pluginsPage
		{
			set{this.SetGetAttributesByName("pluginspage", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("pluginpage", null, false));}
		}
		public string pluginspage
		{
			set{this.SetGetAttributesByName("pluginspage", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("pluginpage", null, false));}
		}
		public string prefix
		{
			set{this.SetGetAttributesByName("prefix", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("prefix", null, false));}
		}
		public string namespaceURI
		{
			set{
                this.SetGetAttributesByName("namespaceuri", value, true);
                this.___namepaceURI = value;
            }
			get{
                return commonHTML.___convertNullToEmpty(this.___namepaceURI);

            }
		}
		public string valueType
		{
			set{this.SetGetAttributesByName("valuetype", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("valuetype", null, false));}
		}
		public string valuetype
		{
			set{this.SetGetAttributesByName("valuetype", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("valuetype", null, false));}
		}
		public string mimetype
		{
			set{this.SetGetAttributesByName("mimetype", value, true);}
			get{return commonHTML.GetElementAttributeInString(this, "mimetype");}
		}
		public string mimeType
		{
			set{this.SetGetAttributesByName("mimetype", value, true);}
			get{return commonHTML.GetElementAttributeInString(this, "mimetype");}
		}
		/// <summary>
		/// Sets or retrieves the group of cells in a table to which the object's information applies.
		/// td object
		/// </summary>
		public string scope
		{
			set{this.SetGetAttributesByName("scope", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("scope", null, false));}
		}
		/// <summary>
		/// Sets or retrieves a value that you can use to implement your own ch functionality for the object.
		/// td object
		/// </summary>
		public string ch
		{
			set{this.SetGetAttributesByName("ch", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("ch", null, false));}
		}
		/// <summary>
		/// Sets or retrieves a value that you can use to implement your own chOff functionality for the object.
		/// td object
		/// </summary>
		public string chOff
		{
			set{this.SetGetAttributesByName("choff", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("choff", null, false));}
		}
		public string choff
		{
			set{this.SetGetAttributesByName("choff", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("choff", null, false));}
		}
		/// <summary>
		/// Sets or retrieves a comma-delimited list of conceptual categories associated with the object.
		/// </summary>
		public string axis
		{
			set{this.SetGetAttributesByName("axis", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("axis", null, false));}
		}
		/// <summary>
		/// obsolute attribute but to support legacy
		/// </summary>
		public string auto
		{
			set{this.SetGetAttributesByName("auto", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("auto", null, false));}
		}
		/// <summary>
		/// obsolute attribute but to support legacy
		/// </summary>
		public bool async
		{
			set
			{
				try
				{
                    this.___async = value;
					this.SetGetAttributesByName("async", value, true);
				}
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
			}
			get
			{
                return this.___async;
			}
		}
        /// <summary>
        /// html5 autoplay is boolean
        /// </summary>
        public bool autoplay
        {
            set
            {
                try
                {
                    this.SetGetAttributesByName("autoplay", value, true);
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
            }
            get
            {
                if (this.___attributes.ContainsKey("autoplay") == false)
                {
                    return false;
                }
                return commonData.convertObjectToBoolean(this.SetGetAttributesByName("autoplay", null, false), false);
            }
        }
		public bool defer
		{
			set{this.SetGetAttributesByName("defer", value, true);}
			get
			{
                return this.___defer;
			}
		}
		/// <summary>
		/// HTML5 TEXTAREA autofocus boolean
		/// </summary>
		public bool autofocus
		{
			set{this.SetGetAttributesByName("autofocus", value, true);}
			get{
				return commonData.convertObjectToBoolean(this.SetGetAttributesByName("autofocus", null, false));
			}
		}
		/// <summary>
		/// Sets or retrieves abbreviated text for the object.
		/// new for IE6 td object
		/// </summary>
		public string abbr
		{
			set{this.SetGetAttributesByName("abbr", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("abbr", null, false));}
		}
		public object scopeName
		{
			set{
                this.SetGetAttributesByName("scopename", value, true);
                this.___scopename = commonHTML.GetStringValue(value);
            }
            get
            {
                
                if (string.IsNullOrEmpty(this.___scopename) == false)
                {
                    return this.___scopename;
                }
                else
                {
                    return null;
                }
            }
		}

		public int loop
		{
			set{this.SetGetAttributesByName("loop", value, true);}
			get
			{
				try
				{
					object ___objLoop = this.SetGetAttributesByName("loop", null, false);
                    if (___objLoop != null && commonHTML.isClrNumeric(___objLoop) == true)
                    {
                        return commonHTML.GetIntFromObject(___objLoop, 0);
                    }
                    return 0;
				}
				catch
				{
					return 0;
				}
			}
		}
		public string accept
		{
			set{this.SetGetAttributesByName("accept", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("accept", null, false));}
		}
		public bool isMap
		{
			set{this.SetGetAttributesByName("ismap", value, true);}
			get
			{
				try
				{
					return commonData.convertObjectToBoolean(this.SetGetAttributesByName("ismap", null, false));
				}
				catch
				{
					return false;
				}
			}
		}

		public string Accept
		{
			set{this.SetGetAttributesByName("accept", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("accept", null, false));}
		}
		public string Start
		{
			set{this.SetGetAttributesByName("start", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("start", null, false));}
		}
		/// <summary>
		/// if object is iframe, it should return the iframe7s document, not root document
		/// </summary>
		public CHtmlDocument contentDocument
		{
			get
			{
                CHtmlDocument ___contentDocumentResult = null;
                if (this.___elementTagType == CHtmlElementType.IFRAME || this.___elementTagType == CHtmlElementType.FRAME)
                {
                    object objWindow = this.contentWindow;
                    if (objWindow != null)
                    {
                        CHtmlMultiversalWindow __muitiWindow = objWindow as CHtmlMultiversalWindow;
                        if (__muitiWindow != null)
                        {
                            if (__muitiWindow.___document != null)
                            {
                                ___contentDocumentResult = __muitiWindow.___document;
                            }
                            else
                            {
                                ___contentDocumentResult = null;
                            }
                            goto ReturnObjet;
                        }
                    }
               
                    ___contentDocumentResult = null;
                    goto ReturnObjet;
                }
                else
                {
                    if (this.___isInactivativeElementNodeChild == true)
                    {
                        ___contentDocumentResult = null;
                        goto ReturnObjet;
                    }
                    ___contentDocumentResult = this.___Document;
                    goto ReturnObjet;
                }
            ReturnObjet:
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                    if (___contentDocumentResult != null)
                    {
                       commonLog.LogEntry("{0}.contentDocument returns {1}", this, ___contentDocumentResult);
                    }
                    else
                    {
                       commonLog.LogEntry("{0}.contentDocument returns null", this);
                    }
                }
                return ___contentDocumentResult;
			}
		}
		/// <summary>
		/// Starts scrolling the marquee.
		/// </summary>
		public void start()
		{
		}
		/// <summary>
		/// Stop scrolling the marquee.
		/// </summary>
		public void stop()
		{
		}
		public string dynsrc
		{
			set{this.SetGetAttributesByName("dynsrc", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("dynsrc", null, false));}
		}
		/// <summary>
		/// Area object
		/// </summary>
		public string coords
		{
			set{this.SetGetAttributesByName("coords", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("coords", null, false));}
		}
		public string acceptcharset
		{
			set{this.SetGetAttributesByName("acceptcharset", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("acceptcharset", null, false));}
		}

		public string BGColor
		{
			set{this.SetGetAttributesByName("bgcolor", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("bgcolor", null, false));}
		}
		public string BgColor
		{
			set{this.SetGetAttributesByName("bgcolor", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("bgcolor", null, false));}
		}
		public string summary
		{
			set{this.SetGetAttributesByName("summary", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("summary", null, false));}
		}
		public string tagUrn
		{
			set{this.SetGetAttributesByName("tagurn", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("tagurn", null, false));}
		}

		public string hideFocus
		{
			set{this.SetGetAttributesByName("hidefocus", value, true);}
			get{return this.SetGetAttributesByName("hidefocus", null, false) as string;}
		}
		
		public string role
		{
			set{this.SetGetAttributesByName("role", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("role", null, false));}
		}
		public string recordNumber
		{
			set{this.SetGetAttributesByName("recordnumber", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("recordnumber", null, false));}
		}
		public bool isContentEditable
		{
			set{this.SetGetAttributesByName("iscontenteditable", value, true);}
			get{
				try
				{
					object objBool = this.SetGetAttributesByName("iscontenteditable", null, false) ;
                    if (objBool != null)
                    {
                        return commonData.convertObjectToBoolean(objBool);
                    }
                    return false;
				}
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
				return false;
			}
		}
		public bool isDisabled
		{
			get{
				return this.___disabled;
			}
			set
			{
				this.___disabled = value;
				try
				{
					this.SetGetAttributesByName("isdisabled", value, true);
				}
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
			}
		}
		public string bgProperties
		{
			set{this.SetGetAttributesByName("bgproperties", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("bgproperties", null, false));}
		}
		public string action
		{
			set{this.SetGetAttributesByName("action", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("action", null, false));}
		}
		public string blockDirection
		{
			set{this.SetGetAttributesByName("blockdirection", value, true);}
			get{return this.SetGetAttributesByName("blockdirection", null, false) as string;}
		}
		public string alt
		{
			set{this.SetGetAttributesByName("alt", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("alt", null, false));}
		}
		public string Alt
		{
			set{this.SetGetAttributesByName("alt", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("alt", null, false));}
		}
		/// <summary>
		/// HTML5 TEXTAREA Wrap is not boolean, it is STRING for IE and Chrome
		/// </summary>
		public string wrap
		{
			set{this.SetGetAttributesByName("wrap", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("wrap", null, false));}
		}




        public int tabIndex
		{
			set{this.SetGetAttributesByName("tabindex", value, true);}
			get
			{
				try
				{
					object objTabIndex = this.SetGetAttributesByName("tabindex", null, false);
                    if (objTabIndex != null && commonHTML.isClrNumeric(objTabIndex) == true)
                    {
                        return commonHTML.GetIntFromObject(objTabIndex,0);
                    }
                    return 0;
				}
				catch
				{
					return 0;
				}
			}
		}
       
		public int maxLength
		{
			set{this.SetGetAttributesByName("maxlength", value, true);}
			get
			{
				try
				{
					object __objMaxLength = this.SetGetAttributesByName("maxlength", null, false);
                    if (__objMaxLength != null && commonHTML.isClrNumeric(__objMaxLength) == true)
                    {
                        return commonHTML.GetIntFromObject(__objMaxLength, 0);
                    }
                    return 0;
				}
				catch
				{
					return 0;
				}
			}
		}
		/// <summary>
		/// input=type object
		/// </summary>
		public int maxlength
		{
			set{this.SetGetAttributesByName("maxlength", value, true);}
			get
			{
				try
				{
					return (int)this.SetGetAttributesByName("maxlength", null, false);
				}
				catch
				{
					return 0;
				}
			}
		}
		/// <summary>
		/// Retrieves the ordinal position of the object, in source order, as the object appears in the document's all collection
		/// </summary>
		public int sourceIndex
		{
			get
			{
                return this.___elementOID;
			}
		}
		public string border
		{
			set{this.SetGetAttributesByName("border", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("border", null, false));}
		}
		public string Border
		{
			set{this.SetGetAttributesByName("border", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("border", null, false));}
		}
		public string borderColor
		{
			set{this.SetGetAttributesByName("bordercolor", value, true);}
			get{return this.SetGetAttributesByName("bordercolor", null, false) as string;}
		}
		public string bordercolor
		{
			set{this.SetGetAttributesByName("bordercolor", value, true);}
			get{return this.SetGetAttributesByName("bordercolor", null, false) as string;}
		}
		public string borderColorDark
		{
			set{this.SetGetAttributesByName("bordercolordark", value, true);}
			get{return this.SetGetAttributesByName("bordercolordark", null, false) as string;}
		}
		public string bordercolordark
		{
			set{this.SetGetAttributesByName("bordercolordark", value, true);}
			get{return this.SetGetAttributesByName("bordercolordark", null, false) as string;}
		}
		public string borderColorLight
		{
			set{this.SetGetAttributesByName("bordercolorlight", value, true);}
			get{return this.SetGetAttributesByName("bordercolorlight", null, false) as string;}
		}
		public string bordercolorlight
		{
			set{this.SetGetAttributesByName("bordercolorlight", value, true);}
			get{return this.SetGetAttributesByName("bordercolorlight", null, false) as string;}
		}


		public string data
		{
			set{this.SetGetAttributesByName("data", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("data", null, false));}
		}
		public string code
		{
			set{this.SetGetAttributesByName("code", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("code", null, false));}
		}
		/// <summary>
		/// Object tag support. not same as className or 'class' of element
		/// </summary>
        public string classid
        {
            set { this.SetGetAttributesByName("classid", value, true); }
            get { return commonHTML.GetElementAttributeInString(this, "classid"); }
        }
		public string classID
		{
			set{this.SetGetAttributesByName("classid", value, true);}
            get { return commonHTML.GetElementAttributeInString(this, "classid"); }
		}
		public string charset
		{
			set{this.SetGetAttributesByName("charset", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("charset", null, false));}
		}
		public string caption
		{
			set{this.SetGetAttributesByName("caption", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("caption", null, false));}
		}
		public string cellPadding
		{
			set{this.SetGetAttributesByName("cellpadding", value, true);}
			get{return this.SetGetAttributesByName("cellpadding", null, false) as string;}
		}
		public string cellpadding
		{
			set{this.SetGetAttributesByName("cellpadding", value, true);}
			get{return this.SetGetAttributesByName("cellpadding", null, false) as string;}
		}
		public string cellSpacing
		{
			set{this.SetGetAttributesByName("cellspacing", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("cellspacing", null, false));}
		}
		public string cellspacing
		{
			set{this.SetGetAttributesByName("cellspacing", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("cellspacing", null, false));}
		}
		public string label
		{
			set{this.SetGetAttributesByName("label", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("label", null, false));}
		}
        /*
         * Normal Element does not declare select method!!! 
         * Only HtmlInput Or TextArea ___hasInner select()
         */
        /*
		public void select()
		{
			if(this.___documentWeakRef  != null)
			{
				this.___getDocument().___x_selectedElement = this;
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
			{
				commonLog.LogEntry("{0}.selected()", this);
			}
		}
        */
		public bool selected
		{
			set{this.SetGetAttributesByName("selected", value, true);}
			get
			{
                CHtmlAttribute attrSelected = null;
				if(this.___attributes.TryGetValue("selected", out attrSelected))
				{
                    if (attrSelected != null)
                    {
                        if (attrSelected.___value is bool)
                        {
                            return (bool)attrSelected.___value;
                        }
                        return commonHTML.GetBooleanForSelectedAttribute(attrSelected.___value);
                    }
					return false;
				}
				else
				{
					return false;
				}
			}
		}
		public bool defaultselected
		{
			set{this.SetGetAttributesByName("defaultselected", value, true);}
            get
            {
                CHtmlAttribute attrSelected = null;
                if (this.___attributes.TryGetValue("defaultselected", out attrSelected))
                {
                    if (attrSelected != null)
                    {
                        if (attrSelected.___value is bool)
                        {
                            return (bool)attrSelected.___value;
                        }
                        return commonHTML.GetBooleanForSelectedAttribute(attrSelected.___value);
                    }
                    return false;
                }
                else
                {
                    return false;
                }

            }
		}
		public bool defaultSelected
		{
			set{this.SetGetAttributesByName("defaultselected", value, true);}
			get
			{
                return this.defaultselected;
			}
		}

        internal void ___appendOrInsertChildRange(CHtmlCollection ___elementList, bool ___isInsertMode, int ___insertPos)
        {
            try
            {
                if (___elementList == null || ___elementList.Count == 0)
                {
                    return;
                }
                if (___isInsertMode == true)
                {
                    if (this.___childNodes.Count == 0)
                    {
                        ___isInsertMode = false;
                    }
                    else
                        if (___insertPos <= 0)
                        {
                            ___isInsertMode = false;
                        }
                    if (___insertPos >= this.___childNodes.Count)
                    {
                        ___isInsertMode = false;
                    }
                }
                int __childCount = ___elementList.Count;
                for (int i = 0; i < __childCount; i++)
                {
                    CHtmlElement ___listChildElement = ___elementList[i] as CHtmlElement;
                    if (___listChildElement != null)
                    {
                        if (object.ReferenceEquals(___listChildElement.___Document, this.___Document) == false)
                        {
                            ___listChildElement.___documentWeakRef  = new WeakReference(this.___getDocument(), false);
                        }
                        ___listChildElement.___parentWeakRef = new WeakReference(this, false);
                        ___listChildElement.___isInactivativeElementNodeChild = this.___isInactivativeElementNodeChild;
                        if (___isInsertMode == false)
                        {
                            ___listChildElement.___ChildNodeIndex = this.___childNodes.Add(___listChildElement);
                        }
                        else
                        {
                            this.___childNodes.Insert(___insertPos, ___listChildElement);
                            ___insertPos++;
                        }
                        if (this.___isInactivativeElementNodeChild == false)
                        {
                            ___listChildElement.___isInactivativeElementNodeChild = false;
                            if (this.___documentWeakRef  != null)
                            {
                                if (this.___getDocument().___IsDomModeFullParseMode() == true)
                                {
                                    CHtmlElement.___PreProcessNewlyCreateNode(___listChildElement);
                                }
                            }
                        }
                    }
                }
                if (___isInsertMode == true)
                {
                    commonHTML.ResetCHtmlElementChildIndex(this, 0);
                }
            }
            catch (Exception ex1stStage)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("___appendOrInsertChildRange() 1st stage exception. ", ex1stStage);
                }
            }
            try
            {
                if (this.___Document != null && this.___Document.___IsDomModeFullParseMode() == true)
                {
                    int __childCount = ___elementList.Count;
                    for (int i = 0; i < __childCount; i++)
                    {
                        CHtmlElement ___listChildElement = ___elementList[i] as CHtmlElement;
                        if (___listChildElement != null)
                        {
                            if (___listChildElement.___IsDynamicElement == true && ___listChildElement.___IsDynamicProcessDone == false)
                            {
                                int __stackLen = 0;
                                this.___Document.___postprocessDynamicElementCHtmlElement(___listChildElement, ref  __stackLen);
                            }
                        }
                    }
                }
            }
            catch (Exception ex2ndStage)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("___appendOrInsertChildRange() 2nd stage exception. ", ex2ndStage);
                }
            }
        }


        public string codeType
		{
			set{this.SetGetAttributesByName("codetype", value, true);}
			get{return this.SetGetAttributesByName("codetype", null, false) as string;}
		}
		public string codetype
		{
			set{this.SetGetAttributesByName("codetype", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("codetype", null, false));}
		}
		/// <summary>
		/// Sets or retrieves the delay time before the timeline ends playing on the element.
		/// </summary>
		public string end
		{
			set{this.SetGetAttributesByName("end", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("end", null, false));}
		}

		public string unselectable
		{
			set{this.SetGetAttributesByName("unselectable", value, true);}
			get{return this.SetGetAttributesByName("unselectable", null, false) as string;}
		}
		public string UnSelectable
		{
			set{this.SetGetAttributesByName("unselectable", value, true);}
			get{return this.SetGetAttributesByName("unselectable", null, false) as string;}
		}
		public string altHTML
		{
			set{this.SetGetAttributesByName("althtml", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("althtml", null, false));}
		}
		public string htmlFor
		{
			set{this.SetGetAttributesByName("for", value, true);}
			get{
				return commonHTML.GetStringValue(this.SetGetAttributesByName("for", null, false));
			}
		}
		/// <summary>
		/// Script object. Sets or retrieves the object that is bound to the event script. 
		/// this is same as 'for'
		/// </summary>
		public string htmlfor
		{
			set{this.SetGetAttributesByName("for", value, true);}
			get{
				return commonHTML.GetStringValue(this.SetGetAttributesByName("for", null, false));
			}
		}

		public string altHtml
		{
			set{this.SetGetAttributesByName("althtml", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("althtml", null, false));}
		}
		public string althtml
		{
			set{this.SetGetAttributesByName("althtml", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("althtml", null, false));}
		}
		public string archive
		{
			set{this.SetGetAttributesByName("archive", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("archive", null, false));}
		}
		public string basehref
		{
			set{this.SetGetAttributesByName("basehref", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("basehref", null, false));}
		}
		public string BaseHref
		{
			set{this.SetGetAttributesByName("basehref", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("basehref", null, false));}
		}
		
		public string units
		{
			set{this.SetGetAttributesByName("units", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("units", null, false));}
		}

		public string frameBorder
		{
			set{this.SetGetAttributesByName("frameborder", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("frameborder", null, false));}
		}

		public string text
		{
			set{this.innerText = value;}
			get{return this.innerText;}
		}
		public CHtmlCollection options
		{
			get{
				if(this.___elementTagType == CHtmlElementType.SELECT)
				{
					return this.CreateOptionsListForSelectTag();
				}
				else
				{
					return null;
				}
			}
		}
        private ICHtmlShadowRoot? ___shadowRoot = null;
        public ICHtmlShadowRoot? shadowRoot
        {
            get
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("TODO : {0}.shadowRoot called ", this.toLogString());
                }
                if (this.___elementTagType == CHtmlElementType.SHADOW_ROOT)
                {
                    return this as ICHtmlShadowRoot;
                }
                return null;
            }
        }
        public ICHtmlShadowRoot? attachRoot(params object[] ___params)
        {
          

            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("TODO : {0}.attachRoot() called with {1} parameters.", this, ___params.Length);
                }
            // return CHtmlShadowRoot.___performAttachRootOperation(this, ___params);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("{0}.attachRoot() returns with {1}", this,___shadowRoot);
            }
            return ___shadowRoot;

        }
        /// <summary>
        /// Canvas toDataURL
        /// </summary>
        /// <param name="__imageTypes">ImageType</param>
        /// <param name="___imageQuality">Numeric</param>
        /// <returns></returns>
        public string toDataURL(object __imageTypes, object ___imageQuality)
        {
            if (this.___elementTagType == CHtmlElementType.CANVAS)
            {
                return CHtmlCanvasContext2D.___performToDataURLOperation(commonHTML.GetStringValue(__imageTypes), -1, -1, -1, null, this);

            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Canvas toDataURL
        /// </summary>
        /// <param name="__imageTypes">imageType</param>
        /// <returns>dataImage</returns>
        public string toDataURL(object __imageTypes)
        {
            if (this.___elementTagType == CHtmlElementType.CANVAS)
            {
                return CHtmlCanvasContext2D.___performToDataURLOperation(commonHTML.GetStringValue(__imageTypes), -1, -1, -1, null, this);

            }
            else
            {
                return null;
            }
        }

        public string toDataURL()
        {
            if (this.___elementTagType == CHtmlElementType.CANVAS)
            {
                return CHtmlCanvasContext2D.___performToDataURLOperation("", -1, -1, -1, null, this);
            }
            else
            {
                return null;
            }
        }
        public string toDataUrl()
        {
            if (this.___elementTagType == CHtmlElementType.CANVAS)
            {
                return CHtmlCanvasContext2D.___performToDataURLOperation("", -1, -1, -1, null, this);
           
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get HTML5 Canvas Context
        /// </summary>
        /// <returns>CanvasContext</returns>
        public object getContext(params object[] args)
        {
            string ___contextID = string.Empty;
            string ___param = string.Empty;
            if (args == null || args.Length == 0 )
            {
                return null;
            }
            else
            {
                if(args.Length == 2)
                {
                    ___contextID = args[0].ToString();
                    ___param = args[1].ToString();
                }
                else if(args.Length == 1 )
                {
                    ___contextID = args[0].ToString();

                }
            }

                var newNode = this.___getContext_inner(___contextID, ___param);
            if (newNode is CHtmlCanvasContext2D)
            {
                CHtmlCanvasContext2D newContext = newNode as CHtmlCanvasContext2D;
                if (newContext.___contextAttributes == null)
                {
                    if (___param != null)
                    {
                        newContext.___contextAttributes = new CHtmlCanvasContextAttributes();
                        newContext.___contextAttributes.___canvasContextWeakReference = new WeakReference(newContext, false);
                  
                        if (___param is System.Array)
                        {

                        }

                    }
                }
                else
                {
  
                }
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("getContext() returns CHtmlCanvasContest with : {0}, {1}, {2}", ___contextID, ___param, newContext);
                }
                return newContext;
            }
            return null;
        }
        public void requestPointerLock()
        {
            this.___requestPointerLock__inner();
        }
        public void webkitRequestPointerLock()
        {
            this.___requestPointerLock__inner();
        }
        public void mozRequestPointerLock()
        {
            this.___requestPointerLock__inner();
        }
        private void ___requestPointerLock__inner()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}.requestPointerLock() called...", this);
            }
        }

        internal object ___getCanvasContext_inner(object ___contextID, object ___paramArray)
        {
            var newNode = this.___getContext_inner(___contextID, ___paramArray);

            return newNode as CHtmlCanvasContext2D;
        }

        internal object ___getContext_inner(object ___contextID, object ___paramArray)
        {
            if (this.___Document != null && this.___Document.___Disposing == true)
            {
                return null;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("entering {0}.getContext({1}, {2}).", this.toLogString(), ___contextID, ___paramArray);
            }
            string _contenxtName = commonHTML.GetStringValue(___contextID);
            CanvasContextModeType _canvasType = CHtmlCanvasContext2D.___GetCanvasTypeFromName(_contenxtName);

            if (this.___canvasContextCurrent2D != null)
            {
                if (this.___canvasContextCurrent2D.___CanvasContextModeType == _canvasType)
                {
                    return this.___canvasContextCurrent2D;
                }
                // last canvas is still alive. disponse now
                try
                {
                    this.___canvasContextCurrent2D.Dispose();
                    this.___canvasContextCurrent2D = null;
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("getContext({0}) dispose last canvascontext.", ex);
                    }
                }
            }


            if (_canvasType == CanvasContextModeType.OtherType)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("getContext({0}) is unknown type use 2D...", ___contextID);
                }
                _canvasType = CanvasContextModeType.Canvas2D;
            }
            this.___CanvasGetContext++;
            if (this.___CanvasGetContext >= double.MaxValue)
            {
                this.___CanvasGetContext = 1;
            }
            switch (_canvasType)
            {
                case CanvasContextModeType.Canvas2D:
                case CanvasContextModeType.Canvas2DPrototype:
                case CanvasContextModeType.SVG:
                    this.___canvasContextCurrent2D = new CHtmlCanvasContext2D();
                    this.___canvasContextCurrent2D.___CanvasGraphicAPIType = commonHTML.GraphicApiType;
                    break;
                case CanvasContextModeType.AudioContext:
                    this.___audioBasedContext = new CHtmlAudioContext();
                    this.___audioBasedContext.___audioDestinationNode = new CHtmlAudioDestinationNode();
                    this.___audioBasedContext.___audioDestinationNode.___ownerContextWeakReference = new WeakReference(this, false);
                    break;
               

                case CanvasContextModeType.WebGL:
                case CanvasContextModeType.WebGLPrototype:
                    this.__canvasContextCurrentWebGL = new CHtmlWebGLRenderingContext();
                    break;
            }

            if (this.___style.___IsBackgroundColorSpecified == true)
            {
                this.___canvasContextCurrent2D.___CanvasBackgroundSysColor = this.___style.___BackgroundSysColor;
                this.___canvasContextCurrent2D.___IsCanvasBackgroundSysColorSpecified = true;

            }
            else
            {
                int ___parentCount = 0;
                CHtmlElement ___parentElem = this.parentElement  as CHtmlElement;
                // ------------------------------------------------------------------------------------------------------------
                // Some Game use background div for as background image, use background transparent to let them see thru.
                // ------------------------------------------------------------------------------------------------------------
                while(___parentElem != null)
                {
                    if (___parentElem.___style.___IsBackgroundColorSpecified == true)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("{0} does not have background-color, use parentNode {1} background-color: {2}", this.toLogString(), ___parentElem.toLogString(), ___parentElem.___style.___BackgroundSysColor);
                        }
                        this.___style.___IsBackgroundColorSpecified = true;
                        this.___style.___BackgroundSysColor = ___parentElem.___style.___BackgroundSysColor;
                        this.___canvasContextCurrent2D.___CanvasBackgroundSysColor = this.___style.___BackgroundSysColor;
                        this.___canvasContextCurrent2D.___IsCanvasBackgroundSysColorSpecified = true;

                        break;
                    }
                    else
                    {
                        ___parentCount++;
                        if (___parentCount > 16)
                        {
                            break;
                        }
                        ___parentElem = ___parentElem.parentElement as CHtmlElement;
                    }
                }

            }

            if (this.___style.___IsForegroundSysColorSpecified == true)
            {
                this.___canvasContextCurrent2D.___CanvasForegroundSysColor = this.___style.___ForegroundSysColor;
            }
            else
            {
                
                this.___canvasContextCurrent2D.___CanvasForegroundSysColor = ColorSpec.Black;
            }
            this.___canvasContextCurrent2D.ContextMode = _contenxtName;
            this.___canvasContextCurrent2D.___CanvasContextModeType = _canvasType;
            this.___canvasContextCurrent2D.___parentElementWeakReference = new WeakReference(this, false);
#if DEBUG
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("Canvas attributes length: {0}", this.___attributes.length);
             }
#endif
            this.___canvasContextCurrent2D.___parentElementOID = this.___elementOID;
            this.___canvasContextCurrent2D.___ownerDocumentWeakReference = new WeakReference(this.___Document, false);
            this.___ElementCanvasContextType = _canvasType;
            this.___canvasContextCurrent2D.___CanvasWidth = this.___offsetWidth;
            this.___canvasContextCurrent2D.___CanvasHeight = this.___offsetHeight;
            if (this.___offsetWidth == 0)
            {
                CHtmlAttribute attributeWidtthValue = null;
                if (this.___attributes.TryGetValue("width", out attributeWidtthValue))
                {
                    double ___widthValue = 0;
                    if (double.TryParse(attributeWidtthValue.value.ToString(), out ___widthValue))
                    {
                        this.___style.width = ___widthValue.ToString();
                        this.___offsetWidth = ___widthValue;
                    }
                }
            }
            if (this.___offsetHeight == 0)
            {
                CHtmlAttribute attributeHeightValue = null;
                if (this.___attributes.TryGetValue("height", out attributeHeightValue))
                {
                    double ___heightValue = 0;
                    if (double.TryParse(attributeHeightValue.value.ToString(), out ___heightValue))
                    {
                        this.___style.height = ___heightValue.ToString();
                        this.___offsetHeight = ___heightValue;
                    }
                }
            }

            if (this.___canvasContextCurrent2D.___CanvasContextModeType  == CanvasContextModeType.Canvas2D || this.___canvasContextCurrent2D.___CanvasContextModeType == CanvasContextModeType.SVG)
            {
                if (this.___CanvasGdiImage == null)
                {

                    if (this.___offsetHeight > 0 && this.___offsetWidth > 0)
                    {
                        bool ___IsStartupCanvasSizeMayBeWrong = false;
                        if (this.___offsetWidth > 5000)
                        {
                            ___IsStartupCanvasSizeMayBeWrong = true;
                        }
                        if (this.___offsetHeight > 5000)
                        {
                            ___IsStartupCanvasSizeMayBeWrong = true;
                        }

                    }

                    try
                    {

                        switch (commonHTML.GraphicApiType)
                        {
                            case GraphicAPIType.WinformsGDI:
#if WINDOWS
                                System.Drawing.Bitmap canvasBitmap = null;
                                if (this.___offsetWidth > 0 && this.___offsetHeight > 0)
                                {
                                    canvasBitmap = new Bitmap((int)this.___offsetWidth, (int)this.___offsetHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                                }
                                else
                                {
                                    canvasBitmap = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                                }
                                System.Drawing.Color defaultCanvasColor = commonHTML.GetColorFromHTMLColorExtend(this.___style.backgroundColor);

                                this.___CanvasGdiImage = canvasBitmap as Image;
                                Graphics gr = null;
                                if (canvasBitmap != null)
                                {

                                    gr = Graphics.FromImage(this.___CanvasGdiImage);

                                }
                                gr.Clear(commonTypeConverter.convertColorSpecToGDIDrawingColor(this.___canvasContextCurrent2D.___CanvasBackgroundSysColor));
                                gr.Dispose();

                                this.___canvasContextCurrent2D.___CanvasGraphicAPIType = commonHTML.GraphicApiType;


                                this.___canvasContextCurrent2D.___CanvasGdiImageWeakReference = new WeakReference(this.___CanvasGdiImage, false);
                                break;
#else
                            case GraphicAPIType.Avalonia:
                            case GraphicAPIType.SkiaSharp:
                                {
                                    if (this.___offsetWidth > 0 && this.___offsetHeight > 0)
                                    {

                                        this.___CanvasSkiaBitmap = new SkiaSharp.SKBitmap((int)this.___offsetWidth, (int)this.___offsetHeight, SkiaSharp.SKColorType.Bgra8888, SkiaSharp.SKAlphaType.Premul);
                                        this.___canvasContextCurrent2D.___CanvasSkiaBitmapWeakReference = new WeakReference(this.___CanvasSkiaBitmap, false);
                                    }
                                    else
                                    {
                                        this.___CanvasSkiaBitmap = new SkiaSharp.SKBitmap(1, 1, SkiaSharp.SKColorType.Bgra8888, SkiaSharp.SKAlphaType.Premul);
                                        this.___canvasContextCurrent2D.___CanvasSkiaBitmapWeakReference = new WeakReference(this.___CanvasSkiaBitmap, false);
                                    }
                                }
                                this.___canvasContextCurrent2D.___CanvasGraphicAPIType = commonHTML.GraphicApiType;


                                break;
#endif
                            default:
                                break;
                        }


                    }
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                        {
                            commonLog.LogEntry("getContext({0})__getContext_inner exception {1}", ___contextID, ex);
                        }
                    }
                }
        

            }
            else
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("getContext({0}) ___hasInner been created for {1}", ___contextID, this);
                }

            }
            this.___canvasContextActiveWeakReference = new WeakReference(this.___canvasContextCurrent2D);
            this.___ElementCanvasContextType = _canvasType;
            return this.___canvasContextCurrent2D;
		}

		/// <summary>
		/// onOffBehavior Property (deprecated)
		/// </summary>
		public bool onOffBehavior
		{
			set{this.SetGetAttributesByName("onoffbehavior", value.ToString(), true);}
			get
			{
				object objBool = this.SetGetAttributesByName("onoffbehavior", null, false);
				try
				{
                    if (objBool != null)
                    {
                        return commonData.convertObjectToBoolean(objBool);
                    }
				}
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
				return false;
			}
		}
        public bool checkValidity()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.checkValidily() called. return true...", this);
            }
            return true;
        }

		/// <summary>
		/// Marquee  trueSpeed Property
		/// </summary>
		public bool trueSpeed
		{
			set{this.SetGetAttributesByName("truespeed", value.ToString(), true);}
			get
			{
				return commonData.convertObjectToBoolean(this.SetGetAttributesByName("truespeed", null, false), false);
			}
		}
		/// <summary>
		/// Support For [Link] Attribute
		/// </summary>
		public string media
		{
			set{this.SetGetAttributesByName("media", value, true);}
			get{
				/*return commonHTML.GetElementAttributeInString(this, "media");*/
				return commonHTML.GetStringValue(this.SetGetAttributesByName("media", null, false));
			}
		}
        /// <summary>
        /// Copies all read/write attributes to the specified element.
        /// </summary>
        /// <param name="___elem">Element</param>
        /// <param name="___flags">Flags</param>
        public void mergeAttributes(CHtmlElement ___srcElement, bool ___flags)
        {
            this.___mergeAttibutesInner(___srcElement, true);
        }
        /// <summary>
        /// Copies all read/write attributes to the specified element.
        /// </summary>
        /// <param name="___elem">Element</param>
        /// <param name="___flags">Preserve</param>
        public void mergeAttributes(CHtmlElement ___srcElement)
        {
            this.___mergeAttibutesInner(___srcElement, true);

        }

        public void mergeAttributes(object ___srcObject)
        {
            CHtmlElement ___srcElement = commonData.convertObjectIntoCHtmlElement(___srcObject);
            this.___mergeAttibutesInner(___srcElement, true);
        }

        private void ___mergeAttibutesInner(CHtmlElement ___srcElement, bool ___flags)
        {

            int ___attributesCount = ___srcElement.___attributes.Count;
            int ___copyCount = 0;
            if (___srcElement != null)
            {
                for (int i = 0; i < ___attributesCount; i++)
                {
                    CHtmlAttribute xattr = ___srcElement.___attributes.GetByIndex(i) as CHtmlAttribute;
                    if (xattr != null)
                    {
                        if (___flags == true)
                        {
                            if (string.Equals(xattr.name, "name", StringComparison.OrdinalIgnoreCase) == true || string.Equals(xattr.name, "id", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                continue;
                            }
                            CHtmlAttribute ___currentAttr = null;
                            this.___attributes.TryGetValue(xattr.name,out  ___currentAttr);
                            if (___currentAttr != null)
                            {
                                // Attributes Exists just copy
                                ___currentAttr.value = xattr.____GetValueClone();
                                ___copyCount++;
                                continue;
                            }
                            else
                            {
                                // Attributes not Exists create new
                                CHtmlAttribute ___newAttr = new CHtmlAttribute();
                                ___newAttr.name = xattr.name;
                                ___newAttr.setParentNode(this);
                                ___newAttr.value = xattr.____GetValueClone();
                                this.___attributes[___newAttr.name] = ___newAttr;
                                ___copyCount++;
                            }
                        }
                    }
                }
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("\'{0}\'.mergeAttributes(\'{1}\', {2}) Result : {3}", this, ___srcElement, ___flags, ___copyCount);
            }
        }

        public void setActive()
		{

		}

		/// <summary>
		/// Sets or gets a value that indicates whether the scroll bars are turned on or off.
		/// IE Specific Functitionality.
		/// IT only applies to BODY element.
		/// Valid values are: yes no auto. Default is yes.
		/// </summary>
		public string scroll
		{
			get
			{
				//return this.SetGetAttributesByName("scroll", null, false) as string;
				if(this.___elementTagType == CHtmlElementType.BODY)
					return "yes";
				else
					return "";
			
			}
            set
            { 
            }
		}
        public string scrolling
        {
            set
            {
                this.SetGetAttributesByName("scrolling", value, true);
            }
            get { return commonHTML.GetElementAttributeInString(this, "scrolling"); }
        }
	

		/// <summary>
		/// The translate attribute is an enumerated attribute that is used to specify whether an
		///  element's attribute values and the values of its Text node children are to be translated
		///  when the page is localized, or whether to leave them unchanged.
		///  The attribute's keywords are the empty string, yes, and no. The empty string and the yes
		///  keyword map to the yes state. The no keyword maps to the no state. In addition, there is
		///  a third state, the inherit state, which is the missing value default
		///  and the invalid value default.
		///  NOTE: SVG Element ___hasInner translate(x,y) methods
		/// </summary>
		public string translate
		{
			set
			{
				this.SetGetAttributesByName("tranalate", value, true);
			}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("translate", null, false));}
		}
       

		/// <summary>
		/// HTML element.translate property is 'yes' 'no'
		/// </summary>
		public string title
		{
			set
			{
				this.SetGetAttributesByName("title", value, true);
				this.___title = value;
			}
			get{return commonHTML.___convertNullToEmpty(this.___title);}
		}
		

		public string dataFld
		{
			set{this.SetGetAttributesByName("datafld", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("datafld", null, false));}
		}
		public bool hidden
		{
			set{this.SetGetAttributesByName("hidden", value, true);}
			get
			{
				return !this.___IsElementVisible;
			}
		}
		public string datafld
		{
			set{this.SetGetAttributesByName("datafld", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("datafld", null, false));}
		}
        /// <summary>
        /// The dir attribute specifies the text direction of the element's content.
        /// values  : ltr, rtl, auto, empty
        /// </summary>
		public string dir
		{
			set{this.SetGetAttributesByName("dir", value, true);}
			get{return commonHTML.GetElementAttributeInString(this, "dir");}
		}
		public bool readOnly
		{
			set{this.SetGetAttributesByName("readonly", value, true);}
			get{
				if(this.___attributes.ContainsKey("readonly") == false)
				{
					return false;
				}
				return commonData.convertObjectToBoolean( this.SetGetAttributesByName("readonly", null, false), false);
			}
		}
		public bool @readonly
		{
			set{this.SetGetAttributesByName("readonly", value, true);}
			get
			{
				if(this.___attributes.ContainsKey("readonly") == false)
				{
					return false;
				}
				return commonData.convertObjectToBoolean( this.SetGetAttributesByName("readonly", null, false), false);
			}
		}
		public string language
		{
			set{this.SetGetAttributesByName("language", value, true);}
			get{return ___getLangAttribute();}
		}
		public string lang
		{
			set{this.SetGetAttributesByName("language", value, true);}
            get { return ___getLangAttribute(); }
		}
        private string ___getLangAttribute()
        {
            CHtmlAttribute ___langAttr = null;
            if (___attributes.TryGetValue("lang", out ___langAttr) == true)
            {
                goto FoundPhase;
            }
            else if (___attributes.TryGetValue("language", out ___langAttr) == true)
            {
                goto FoundPhase;
            }
            else
            {
                goto ReturnEmptyString;
            }
            FoundPhase:
            return commonHTML.GetStringValue(___langAttr.___value);

            ReturnEmptyString:
            // Edge and Chrome returns ''(empty string) not undefind.
            return string.Empty;
        }



		public bool allowtransparency
		{
			set{this.SetGetAttributesByName("allowtransparency", value, true);}
			get
			{
				try
				{
					return commonData.convertObjectToBoolean( this.SetGetAttributesByName("allowtransparency", null, false), true);
				}
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                    }
                }
				return true;
			}
		}


		public bool contentEditable
		{
			set{this.SetGetAttributesByName("contenteditable", value, true);}
			get
			{
				return commonData.convertObjectToBoolean( this.SetGetAttributesByName("contenteditable", null, false), true);
			}
		}
		public string Align
		{
			set{this.SetGetAttributesByName("align", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("align", null, false));}
		}
		public string align
		{
			set{this.SetGetAttributesByName("align", value, true);}
			get{return commonHTML.GetStringValue(this.SetGetAttributesByName("align", null, false));}
		}

		private CHtmlCollection GetFormElementList()
		{
			CHtmlCollection arElements = new CHtmlCollection();
			arElements.___CollectionType = CHtmlHTMLCollectionType.FormElementsList;
            if (this.___FormElementCacheList != null)
            {
                if (___FormElementChildCount == this.___childNodes.Count)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("elements retuns with cached list");
                    }
                    arElements.AddRange(this.___FormElementCacheList as ICollection);
                    goto ResultReturnPhase;
                }
                else
                {
                    this.___FormElementChildCount = -1;
                    this.___FormElementCacheList = null;
                }
            }
			try
			{
				int ___childNodesCount = this.___childNodes.Count;
				for(int i = 0; i < ___childNodesCount; i ++)
				{
					CHtmlElement cNode = this.___childNodes[i] as CHtmlElement;
					if(cNode != null)
					{
						switch(cNode.___elementTagType)
						{
							case CHtmlElementType.INPUT:
							case CHtmlElementType.TEXTAREA:
							case CHtmlElementType.BUTTON:
							case CHtmlElementType.SELECT:
								arElements.Add(cNode);
                                cNode.___IsElementIncludedInFormCacheList = true;
								break;
						}
					}
					if(cNode.___childNodes.Count > 0)
					{
						int cNodechildNodesCount = cNode.___childNodes.Count;
						for(int ci = 0; ci < cNodechildNodesCount; ci ++)
						{
							CHtmlElement CCNode = cNode.___childNodes[ci] as CHtmlElement;
							if(CCNode != null)
							{
								switch(CCNode.___elementTagType)
								{
									case CHtmlElementType.INPUT:
									case CHtmlElementType.TEXTAREA:
									case CHtmlElementType.BUTTON:
									case CHtmlElementType.SELECT:
										arElements.Add(CCNode);
                                        CCNode.___IsElementIncludedInFormCacheList = true;
										break;
								}
							}

						}

					}
				}
			}
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("GetFormElementList", ex);
				}
			}
            if (arElements.Count > 0 && this.___FormElementCacheList == null)
            {
                this.___FormElementCacheList = new CHtmlCollection();
                this.___FormElementCacheList.___CollectionType = CHtmlHTMLCollectionType.FormElementsList;
                this.___FormElementCacheList.AddRange(arElements as ICollection);
                this.___FormElementChildCount = this.___childNodes.Count;
            }
            ResultReturnPhase:
			return arElements;
		}

		public new string type
		{
			set
			{
				this.SetGetAttributesByName("type", value, true);
				base.type = value;
				/*
				if(((this.___CSSPseudoClassAccumulated & CHtmlPseudoClassType.ActivePseudoClass) == CHtmlPseudoClassType.ActivePseudoClass)== false)
				{
					this.___CSSPseudoClassAccumulated = this.___CSSPseudoClassAccumulated | CHtmlPseudoClassType.ActivePseudoClass;
					if(sPart.____PseudoClassCount == 1)
					{
						goto AccumatedCSSTypeCheckDone;
					}

				}
				*/
				/*
				if(((this.___KeyAttributes & CHtmlElementDeclaredAttributeType.Type) == CHtmlElementDeclaredAttributeType.Type)== false)
				{
					this.___KeyAttributes = this.___KeyAttributes | CHtmlElementDeclaredAttributeType.Type;
				}
				*/
			}
			get{
                var attrValue = this.SetGetAttributesByName("type", null, false) as string;
                return commonHTML.___convertNullToEmpty(attrValue ?? base.___type);
            }
		}
		/// <summary>
		/// Sets or retrieves the index of the selected option in a select object.
		/// </summary>
		public int selectedIndex
		{
			set
			{
				
			}
			get
			{
                return -1;
			}

		}
  

		/// <summary>
		/// Chrome set element.value does not change its content to be displayed.
		/// </summary>
		public new object @value
		{
			get
			{

                    if (base.@value != null)
                    {
                        return commonHTML.___convertNullToEmpty(base.@value.ToString());
                    }
                    else
                    {
                        return null;
                    }
				
				
			}
			set
			{

					base.@value = value;
				
			}
		}
		/// <summary>
		/// returns Value
		/// </summary>
		public object nodeValue
		{
			get
			{
				return base.@value;
			}
			set
			{
				base.@value = value;
			}
		}
		public new double nodeType
		{
			get{return (double)base.nodeType;}
		}
		/* Chrome and FireFox does not support element.visible
		public bool Visible
		{
			set{this._IsElementVisible = value;}
			___getInner{return this._IsElementVisible;}
		}
		public bool visible
		{
			set{this._IsElementVisible = value;}
			___getInner{return this._IsElementVisible;}
		}
		*/
		
		/// <summary>
		/// Sets or retrieves the MicrosoftR DirectAnimationR Image (DAImage class) displayed by the anim:DA element.
		/// Not Implemented
		/// </summary>
		
		public object image
		{
			set{;}
			get{return null;}
		}

		/// <summary>
		/// Returns a TextRectangle object. Each rectangle ___hasInner four integer properties (top, left, right, and bottom) that represent a coordinate of the rectangle, in pixels.
		/// </summary>
		/// <returns>One CHtmlTextRectangle</returns>
		public CHtmlTextRectangle getBoundingClientRect()
		{
            if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}.getBoundingClientRect() called...", this);
            }
			CHtmlTextRectangle rect =new CHtmlTextRectangle();
            RectangleF __clientRectangle = commonTypeConverter.ToRectangleF(this.GetElementBoundsOnScreen());
            rect.left = (int)__clientRectangle.X;
            rect.right = (int)(__clientRectangle.X + this.___offsetWidth);
            rect.top = (int)__clientRectangle.Y;
            rect.bottom = (int)(__clientRectangle.Y + this.___offsetHeight);
			return rect;
		}
		/// <summary>
		/// Retrieves a collection of rectangles that describes the layout of the contents of an object or range within the client. Each rectangle describes a single line. 
		/// </summary>
		/// <returns>List of TextRectangle</returns>
		public CHtmlCollection getClientRects()
		{
			CHtmlCollection ar = new CHtmlCollection();
			CHtmlTextRectangle rect =new CHtmlTextRectangle();
			rect.left = (int)this.___offfsetParentPoint.X;
			rect.right = (int)(this.___offfsetParentPoint.X + this.___offsetWidth);
			rect.top = (int)this.___offfsetParentPoint.Y;
			rect.bottom =(int)( this.___offfsetParentPoint.Y + this.___offsetHeight);
			ar.Add(rect);
			ar.IsEnumByIndex = true;
			return ar;
		}

        internal void ___resetC2DBitmapImageBaseduponOffsetSize()
        {
            if (this.___CanvasGdiImage != null)
            {
                if (Math.Abs(this.___CanvasGdiImage.Width -  this.___offsetWidth) < 0 && Math.Abs(this.___CanvasGdiImage.Height - this.___offsetHeight) < 0)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("Resetting 2D Canvas BitmapSize  skip...");
                    }
                    return;
                }
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("Resetting 2D Canvas BitmapSize {0} : {1} x {2}", this, this.___offsetWidth, this.___offsetHeight);
                }

            }
        }




		public void PrintChildNodeDOMTree(string prefix)
		{
			commonLog.LogEntry("{0} + {1} : {2}", prefix, this, this.___childNodes.Count);
            int ___thisChildCount = this.___childNodes.Count;
			for(int i= 0; i < ___thisChildCount; i ++)
			{
                CHtmlElement n = this.___childNodes[i] as CHtmlElement;
                if (n == null)
                {
                    continue;
                }
				if (this.___childNodes.IndexOf(n, true) == this.___childNodes.Count - 1)
					n.PrintChildNodeDOMTree(prefix + "    ");
				else
					n.PrintChildNodeDOMTree(prefix + "   |");
			}
		}

        public void captureEvents(object oEvent)
		{
			return;
		}
		public string outerText
		{
			set{;}
			get{return "";}
		}
		/// <summary>
		/// Returns parent Block Element. If Block Element returns self
		/// </summary>
		public CHtmlElement parentBlockElement
		{
			get
			{
				if(this.___parentBlockElement != null)
				{
					return this.___parentBlockElement;
				}
				else
				{
					if(this.___IsElementBlock == true)
					{
						this.___parentBlockElement = null;
						return this;
					}
                    CHtmlElement ___parentLookup = this.___parent as CHtmlElement;
					while(___parentLookup !=null)
					{
						if(___parentLookup.___IsElementBlock == true)
						{
							this.___parentBlockElement = ___parentLookup;
							return this.___parentBlockElement;
						}
                        ___parentLookup = ___parentLookup.___parent as CHtmlElement;
					}
					return this;
				}
			}
			set
			{
				this.___parentBlockElement =value;
			}

		}
		/// <summary>
		/// returns True if this element is inline but parent is block
		/// </summary>
		/// <returns></returns>
		internal bool ___IsElementInlineTop()
		{
			if(this.___IsElementBlock == false)
			{
				return false;
			}
			else
			{
                if (this.___parentWeakRef != null && this.___parentWeakRef.Target is CHtmlElement)
				{
                    CHtmlElement __parentElement = this.___getParentElement();
                    if (__parentElement != null && __parentElement.___IsElementBlock == true)
					{
						return true;
					}
				}
			}
			return false;
		}


        public object defaultView
        {
            get
            {
                if (this.___Document != null)
                {
                    if (this.___elementTagType != CHtmlElementType.IFRAME && this.___elementTagType != CHtmlElementType.FRAME)
                    {
                        return this.___Document.defaultView;
                    }
                    else
                    {
                        if (this.___iframeMultiversalWindow != null)
                        {
                            return this.___iframeMultiversalWindow;
                        }
                        return null;
                    }
                }
                return null;
            }
        }

        internal System.Drawing.SizeF ___getImgTagSrcImageSizeF()
        {
            SizeF resultSize = new SizeF(0, 0);
            try
            {
                if (this.___srcBase != null && this.___srcBase.href.Length > 0)
                {
                    if (this.___Document != null)
                    {
                        Image ___img = null;
                        this.___Document.___imageRawConcurrentDictionaryForGdi.TryGetValue(this.___srcBase.href, out ___img);
                        if (___img != null)
                        {
                            resultSize = new SizeF(___img.Width, ___img.Height);
                            goto ReturnPhage;
                        }
                    }
                }
                if (this.___imageDownloadtemporarily != null)
                {
                    resultSize = new SizeF(this.___imageDownloadtemporarily.Width, this.___imageDownloadtemporarily.Height);
                    goto ReturnPhage;
                }

                // image is not found, but it may be critical for script processing
                // ___getInner it now
                if (this.___srcBase.___IsProtocolTypeHTTPorHTTPS() == true)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("image Size is accessed but not cached yet..: ", this.___srcBase.href );
                    }
                   
                }
            }
            catch (Exception ex)
            {

                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("___getImgTagSrcImageSizeF() Error", this, ex);
                }
            }
            ReturnPhage:
            return resultSize;
        }



        /// <summary>
        /// Create Options CHTMLList selelct.options property
        /// </summary>
        /// <returns></returns>
        private CHtmlCollection CreateOptionsListForSelectTag()
		{
			CHtmlCollection ___optionsList = new CHtmlCollection();
			___optionsList.___CollectionType = CHtmlHTMLCollectionType.SelectOptions;
			if(this.___elementTagType != CHtmlElementType.SELECT)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
				{
					commonLog.LogEntry("Strange. options property is accessed for {0}. but cont...", this);
				}
			}
			int ___childNodesCount = this.___childNodes.Count;
			for(int i = 0; i < ___childNodesCount; i ++)
			{
				CHtmlElement _optionsElement = this.___childNodes[i] as CHtmlElement;
				if(_optionsElement != null &&  _optionsElement.___elementTagType == CHtmlElementType.OPTION)
				{
					___optionsList.Add(_optionsElement);
				}
			}

			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("{0} ___hasInner created options list of {1}...", this, ___optionsList.Count);
			}
			
			return ___optionsList;
		}
		private CHtmlElement ___createCHtmlElementWithDomType()
		{
			CHtmlElement element = null;
            /*
			if(this.___Document == null ||this.___Document.ClassInterface == 0)
			{
                if(this.___elementTagType == CHtmlElementType.AUDIO || this.___elementTagType == CHtmlElementType.VIDEO)
                {
                    element = new CHtmlMediaElement();
                }
                else if (this.___elementTagType == CHtmlElementType.SVG) 
                {
                    element = new CHtmlSVGElement();
                }
                else
                {
                    element = new CHtmlElement();
                }
			}
			else if(this.___Document.ClassInterface ==(int)CHtmlBaseInterfaceType.IExpando)
			{
                if (this.___elementTagType == CHtmlElementType.AUDIO || this.___elementTagType == CHtmlElementType.VIDEO)
                {
                    element = new CHtmlMediaElement();
                }
                else if (this.___elementTagType == CHtmlElementType.SVG)
                {
                    element = new CHtmlSVGElement();
                }
                else
                {
                    element = new CHtmlElement();
                }
			}
			else
			{
                if (this.___elementTagType != CHtmlElementType.AUDIO && this.___elementTagType != CHtmlElementType.VIDEO)
                {
                    element = new CHtmlMediaElement();
                }
                else if (this.___elementTagType == CHtmlElementType.SVG)
                {
                    element = new CHtmlSVGElement();
                }
                else
                {
                    element = new CHtmlElement();
                }
			}
             */
            switch (this.___elementTagType)
            {
                case CHtmlElementType.AUDIO:
                case CHtmlElementType.VIDEO:
                case CHtmlElementType.TRACK:
                case CHtmlElementType.SOURCE:
                    element = new CHtmlMediaElement();
                    break;
                case CHtmlElementType.SVG:
                    element = new CHtmlSVGElement();
                    break;
                default:
                    element = new CHtmlElement();
                    break;
            }
			return element;
		}
		/// <summary>
		/// #default#homePage default false;
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public bool isHomePage(string s)
		{
			return true;
		}


		private bool ___ThisNodeTrulyFirstVisibieNodeResult = false;
		private int  ___ThisNodeTrulyFirstVisibieNodeCheckStatus = -1;
		private int  ___ThisNodeTrulyFirstVisibieNodeCheckNodeCount = -1;

        public void mozRequestFullscreen()
        {
            ___requestFullscreen_Inner();
        }
        public void mozRequestFullScreen()
        {
            ___requestFullscreen_Inner();
        }
        public void webkitRequestFullscreen()
        {
            ___requestFullscreen_Inner();
        }
        public void webkitRequestFullScreen()
        {
            ___requestFullscreen_Inner();
        }
        public void msRequestFullscreen()
        {
            ___requestFullscreen_Inner();
        }
        public void msRequestFullScreen()
        {
            ___requestFullscreen_Inner();
        }


        public void requestFullscreen()
        {
            ___requestFullscreen_Inner();
        }
        public void requestFullScreen()
        {
            ___requestFullscreen_Inner();
        }

        private void ___requestFullscreen_Inner()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO : ___requestFullScreen_Inner()");
            }
        }

        public void mozCancelFullscreen()
        {
            ___cancelFullscreen_Inner();
        }
        public void mozCancelFullScreen()
        {
            ___cancelFullscreen_Inner();
        }
        public void webkitCancelFullscreen()
        {
            ___cancelFullscreen_Inner();
        }
        public void webkitCancelFullScreen()
        {
            ___cancelFullscreen_Inner();
        }
        public void msCancelFullscreen()
        {
            ___cancelFullscreen_Inner();
        }
        public void msCancelFullScreen()
        {
            ___cancelFullscreen_Inner();
        }


        public void cancelFullscreen()
        {
            ___cancelFullscreen_Inner();
        }
        public void cancelFullScreen()
        {
            ___cancelFullscreen_Inner();
        }


        private void ___cancelFullscreen_Inner()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO : ___cancellFullScreen_Inner()");
            }
        }

        public void mozExitFullscreen()
        {
            ___exitFullscreen_Inner();
        }
        public void mozExitFullScreen()
        {
            ___exitFullscreen_Inner();
        }
        public void webkitExitFullscreen()
        {
            ___exitFullscreen_Inner();
        }
        public void webkitExitFullScreen()
        {
            ___exitFullscreen_Inner();
        }
        public void msExitFullscreen()
        {
            ___exitFullscreen_Inner();
        }
        public void msExitFullScreen()
        {
            ___exitFullscreen_Inner();
        }


        public void exitFullscreen()
        {
            ___exitFullscreen_Inner();
        }
        public void exitFullScreen()
        {
            ___exitFullscreen_Inner();
        }


        private void ___exitFullscreen_Inner()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO : ___exitFullScreen_Inner()");
            }
        }

		/// <summary>
		/// Returns true if this node is first visible node (including TextNode)
		/// Checks all previous element at run time.
		/// </summary>
		/// <param name="__ExcludeAbsolute"></param>
		/// <param name="___ExcludeFloat"></param>
		/// <returns></returns>
		public bool ___IsElementTruelyFirstVisibleNode()
		{
			if(___ThisNodeTrulyFirstVisibieNodeCheckStatus == 1)
			{
				if(___ThisNodeTrulyFirstVisibieNodeCheckNodeCount == this.___childNodes.Count)
				{
					return ___ThisNodeTrulyFirstVisibieNodeResult;
				}
				else
				{
					___ThisNodeTrulyFirstVisibieNodeCheckStatus = -1;
					___ThisNodeTrulyFirstVisibieNodeCheckNodeCount = -1;
				}
			}
			if(this.___ChildNodeIndex == -1)
				return false;
			if(this.___elementTagType == CHtmlElementType.COMMENT)
				return false;
            if (this.___parentWeakRef != null)
			{
                CHtmlElement ___parentElement = this.___getParentElement();
				if(___parentElement != null)
				{
					int ___parentElementchildNodesCount = ___parentElement.___childNodes.Count;
					for(int i = 0; i < ___parentElementchildNodesCount; i ++)
					{
						CHtmlElement ___parentChild = ___parentElement.___childNodes[i] as CHtmlElement;
						if(___parentChild != null)
						{
							if(___parentChild.___elementTagType == CHtmlElementType.COMMENT)
								continue;
							if(___parentChild.___IsElementVisible == true || commonHTML.IsElemeneITextOrIDraw(___parentChild) == true)
							{
								if(object.ReferenceEquals(this, ___parentChild) == true)
								{
									___ThisNodeTrulyFirstVisibieNodeCheckStatus = 1;
									___ThisNodeTrulyFirstVisibieNodeResult = true;
									___ThisNodeTrulyFirstVisibieNodeCheckNodeCount = this.___childNodes.Count;
									return true;
								}
								else
								{
									___ThisNodeTrulyFirstVisibieNodeCheckStatus = 1;
									___ThisNodeTrulyFirstVisibieNodeResult = false;
									___ThisNodeTrulyFirstVisibieNodeCheckNodeCount = this.___childNodes.Count;
									return false;
								}

							}
						}
					}

				}
				else
				{
					return false;
				}
			}
			return false;

		}
        internal void ___setElementCriticalPropertiesChildNode(CHtmlElement elem)
        {
            if (elem != null)
            {
                if (elem.___parentWeakRef  == null)
                {
                    elem.___parentWeakRef = new WeakReference(this, false);
                }
                elem.___IsNoScriptBlock = this.___IsNoScriptBlock;
                elem.___IsParentVisible = this.___IsParentVisible;
                elem.___ProhibitsDrawingElementCreationByNoWrap = this.___ProhibitsDrawingElementCreationByNoWrap;
                if (elem.___IsParentVisible == true && this.___IsElementVisible == false)
                {
                    elem.___IsParentVisible = false;
                }
                elem.___isInactivativeElementNodeChild = this.___isInactivativeElementNodeChild;
                elem.___IsMainDocumentNodeElement = this.___IsMainDocumentNodeElement;
                if (elem.___IsNoScriptBlock == true)
                {
                    elem.___IsElementVisible = false;
                }
                if (this.___isSvgElement == true)
                {
                    elem.___isSvgElement = true;
                    if(this.___isSVGGroupingChildElmentNode == true)
                    {
                        elem.___isSVGGroupingChildElmentNode = true;
                        elem.___groupingElementType = this.___groupingElementType;
                    }
                }
                elem.___DOM_Level = this.___DOM_Level + 1;
                // ===============================================
                // Set By Parent
                // ===============================================
                switch(this.___elementTagType)
                {
                    case CHtmlElementType.NOSCRIPT:
                    case CHtmlElementType.CANVAS:
                        elem.___IsNoScriptBlock = true;
                        break;
                    case CHtmlElementType.OBJECT:
                        elem.___IsNoScriptBlock = true;
                        elem.___IsElementVisible = false;
                        break;
                    case CHtmlElementType.G:
                        if (this.___isSvgElement == true)
                        {
                            elem.___hasMustInheritCSSElement = true;
                            elem.___isSVGGroupingChildElmentNode = true;
                            elem.___groupingElementType = this.___elementTagType;
                            elem.___inheritCSSOwnerElementWeakReference = new WeakReference(this, false);
                        }
                        break;
                    case CHtmlElementType.SYMBOL:
                    case CHtmlElementType.DEFS:
                        if (this.___isSvgElement == true)
                        {
                            elem.___isSVGGroupingChildElmentNode  = true;
                            elem.___groupingElementType = this.___elementTagType;
                        }
                        break;
                        
                }
                // ===============================================
                // Set By Child Element
                // ===============================================
                switch (elem.___elementTagType)
                {
                    case CHtmlElementType.TEMPLATE:
                        elem.___isInactivativeElementNodeChild = true;
                        break;
                }
                if(elem.___isSvgElement == true && this.___hasMustInheritCSSElement == true && this.___inheritCSSOwnerElementWeakReference != null)
                {
                    elem.___hasMustInheritCSSElement = true;

                    elem.___inheritCSSOwnerElementWeakReference = new WeakReference(this.___inheritCSSOwnerElementWeakReference.Target, false);
                }
                

            }
        }
        /// <summary>
        /// This is prototype.js function. 
        /// </summary>
        /// <param name="____elemObject"></param>
        /// <param name="___textClass"></param>
        /// <returns></returns>
   
        public bool hasClassName(object ____elemObject, string ___textClass)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 100)
            {
               commonLog.LogEntry("TODO: {0}.hasClassName {1} for {2}", this, ____elemObject, ___textClass);
            }
            if (____elemObject == null)
            {
                if (this.___classList.ContainsKey(___textClass))
                {

                    return true;
                }
            }
            else
            {

            }
            return false;
        }
        #region nodeType const value

        #endregion
        public void remove()
        {

            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 100)
            {
               commonLog.LogEntry("calling {0}.remove() as removeNode()", this);
            }
            this.removeNode();
        }


        public bool hasClassName(string ___textClass)
        {
            return this.hasClassName(null, ___textClass);
        }

		
		public bool hasOwnProperty(object _oname)
		{
            string sName = commonHTML.GetStringValue(_oname);

            return this.___hasPropertyByName(sName);
		}
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

  

        #region ____defineGetter___ ____defineSetter___
        public void __defineGetter__(string ___propName, object ____getFunction)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}.__defineGetter___({1}, {2})", this, ___propName, ____getFunction);
            }
            this.___getterProperties[___propName] = ____getFunction;
        }
        public void __defineSetter__(string ___propName, object ____getFunction)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}.__defineSetter___({1}, {2})", this, ___propName, ____getFunction);
            }
            this.___setterProperties[___propName] = ____getFunction;
        }

        #endregion
        #region IPropertBox メンバ

        public virtual object ___getPropertyByName(string ___name)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
               commonLog.LogEntry($"entering {this.toLogString()}.___getPropertyByName({___name})");
			}
            if (string.IsNullOrEmpty(___name))
            {
                return null;
            }


                try
                {

				switch(___name)
				{
                    case "ELEMENT_NODE":
                        return 1;
                    case "ATTRIBUTE_NODE":
                        return 2;
                    case "TEXT_NODE":
                        return 3;
                    case "CDATA_SECTION_NODE":
                        return 4;
                    case "ENTITY_REFERENCE_NODE":
                        return 5;
                    case "ENTITY_NODE":
                        return 6;
                    case "PROCESSING_INSTRUCTION_NODE":
                        return 7;
                    case "COMMENT_NODE":
                        return 8;
                    case "DOCUMENT_NODE":
                        return 9;
                    case "DOCUMENT_TYPE_NODE":
                        return 10;
                    case "DOCUMENT_FRAGMENT_NODE":
                        return 11;
                    case "NOTATION_NODE":
                        return 12;
                    case "prototype":
                    case "__proto__":
                        return this.prototype;
                    case "sheet":
                        return this.___sheet;
					case "attributes":
						return this.___attributes;
						//case "__iterator__":
						//	return "";
					case "name":
                        return commonHTML.___convertNullToEmpty(base.___name);
					case "id":
                    case "Id":
                    case "ID":
                        return commonHTML.___convertNullToEmpty(this.___id);
					case "alt":
						return this.alt;
                    case "type":
                        return commonHTML.___convertNullToEmpty(base.___type);
					case "src":
                        return commonHTML.___convertNullToEmpty(base.___src);
					case "class":
					case "classname":
                    case "className":
                        return commonHTML.___convertNullToEmpty(base.___class);
                    case "classid":
                    case "classId":
                    case "classiID":
                        return this.classid;
                    case "srcdoc":
                    case "srcDoc":
                        return this.srcdoc;
					case "tagname":
                    case "tagName":
						if(commonHTML.IsSystemHiddenElement(this.___elementTagType) == false)
						{
							return base.___tagName;
						}
						else
						{
							return "";
						}
                    case "__noSuchMethod__":
                        return null;
                    case "title":
                        return commonHTML.___convertNullToEmpty(this.___title);
					case "nodetype":
                    case "nodeType":
						// In order to allow 'typeof element.nodeType == 'number', return type needs to be 'double'.
						return (double)base.nodeType;
                    case "prevSibling":
                        return this.previousSibling;
					case "nodename":
                    case "nodeName":
                        if (commonHTML.IsSystemHiddenElement(this.___elementTagType) == false)
                        {
                            return base.___tagName;
                        }
                        else
                        {
                            if (this.___elementTagType == CHtmlElementType._ITEXT)
                            {
                                return "#text";

                            }
                            else if (this.___elementTagType == CHtmlElementType._IDRAW)
                            {
                                return "#draw";

                            }
                            else if (this.___elementTagType == CHtmlElementType._DOCUMENT_FRAGMENT)
                            {
                                return "#document-fragment";
                            }
                            else
                            {
                                return base.___tagName;
                            }
                        }
					case "style":
                    case "runtimeStyle":
					case "currentstyle":
                    case "currentStyle":
					case "stylesheet":
                    case "styleSheet":
						if(this.___style != null)
						{
							return this.___style;
						}
						else
						{
							if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
							{
								commonLog.LogEntry("Strange script access to '{0}' found nulll style", this);
							}
							this.___style = new CHtmlCSSStyleSheet(CHtmlElementStyleType.Element);
							return this.___style;
						}
                    case "namespaceuri":
                    case "namespaceUri":
                    case "namespaceURI":
                        if(string.IsNullOrEmpty(this.___namepaceURI) == true)
                        {
                            return commonHTML.namespaceUriDefault;
                        }
                        else
                        {
                            return this.___namepaceURI;
                        }
                    case "itemscope":
                    case "itemScope":
                        return this.itemScope;
					case "value":
					case "nodevalue":
                    case "nodeValue":
						return this.@value;
                    case "dir":
                        return this.dir;
                    case "nodeTypedValue":
                        if (this.___Document != null && this.___Document.___IsDomModeXMLLikeStyleMode() == true)
                        {
                            return commonHTML.GetElementInnerText(this);
                        }
                        else
                        {
                            return this.@value;
                        }
					case "elements": // document.forms[0].elements[0].value support
						return this.GetFormElementList();
					case "innerhtml":
                    case "innerHtml":
                    case "innerHTML":
						return this.GetInnerHTMLInner();
					case "outerhtml":
                    case "outerHTML":
                    case "outerHtml":
						return this.outerHTML;
					case "charset":
                    case "charSet":
					case "characterset":
						return this.charset;
					
                    case "parentNode":
                        if (this.___parent != null && this.___elementTagType!= CHtmlElementType.HTML)
                        {
                            return this.___parent;
                        }
                        else if (this.___elementTagType == CHtmlElementType.HTML)
                        {
                            // ===========================================
                            // if ___parent is null and HTML of first element returns document
                            // this is requeid to embed.js to be processed properly.
                            // NOTE: only for 'parentNode' ___hasInner Document
                            //           'parentElement' should be null
                            // ===========================================


                            if (this.___Document != null)
                            {
                                return this.___Document;
                            }

                        }
                        return null;
                    case "parent":
                    case "parentelement":
                    case "parentElement":
                        return this.___parent as CHtmlElement;
					case "href":
                        if(this.___attributes.ContainsKey("href") == true)
                        {
                            return commonHTML.___convertNullToEmpty(commonHTML.GetElementAttributeInString(this, "href"));
                        }
                        return commonHTML.___convertNullToEmpty(base.___href);
					case "async":
                        return this.___async;
					case "readystate":
                    case "readyState":
						return this.readyState;
					case "onreadystatechange":
					case "onreadystatuschange":
                    case "onReadyStateChange":
						return this.onreadystatechange;
					case "onload":
                    case "onLoad":
                   // case "load":
                    // =======================================================================================================
                    //  Ad hoc change
                    // =======================================================================================================
                    // some scripts look for load to ___getInner methods which ___hasInner been set by addEventListner()
                    // http://cdn.kaisergames.de/public/files/games/html5/flappy-bird/en/api1.html?kg_domain=m.spielaffe.de&kg_uid=fd5a768e47ca
                    // =======================================================================================================

						return this.onload;
					case "onunload":
                    case "onUnload":
						return this.onunload;
					case "onerror":
						return this.onerror;
                    case "onchange":
                        return this.onchange;
					case "childnodes":
                    case "childNodes":
                        return base.___childNodes;
                    case "childelementcount":
                        return base.childElementCount;
					case "children":
                        return this.___getChildrenList();// chidren and childNodes are different
					case "firstchild":
                    case "firstChild":
                    case "firstElementChild":
						if(this.___firstChildWeakReference != null)
						{
							return this.___firstChildWeakReference.Target as CHtmlElement;
						}
						return this.firstChild;
					case "lastchild":
                    case "lastChild":
                    case "lastElementChild":
						return this.lastChild;
					case "nextsibling":
                    case "nextSibling":
                    case "nextElementSibling":
						return this.nextSibling;
					case "previoussibling":
                    case "previousSibling":
                    case "previousElementSibling":
						return this.previousSibling;
					case "clientwidth":
                    case "clientWidth":
						return this.clientWidth;
					case "clientheight":
                    case "clientHeight":
						return this.clientHeight;
					case "clientleft":
                    case "clientLeft":
						return this.clientLeft;
					case "clienttop":
                    case "clientTop":
						return this.clientTop;
					case "offsetheight":
                    case "offsetHeight":
						return this.___offsetHeight;
					case "offsetwidth":
                    case "offsetWidth":
						return this.___offsetWidth;
					case "offsettop":
                    case "offsetTop":
                        // 要素が存在し、有効な状態かチェック
                        if (this.___HasElementRemoved || this.___IsDisposing)
                        {
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                            {
                                commonLog.LogEntry("offsetTop accessed on removed/disposing element: {0}", this);
                            }
                            return 0;
                        }

                        // 親要素の存在をチェック
                        if (this.___parentWeakRef != null)
                        {
                            var parent = this.___parentWeakRef.Target;
                            if (parent == null)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                {
                                    commonLog.LogEntry("offsetTop accessed but parent is null: {0}", this);
                                }
                                return 0;
                            }
                        }
                        break;
                    case "offsetleft":
                    case "offsetLeft":
						return  this.___offsetLeft;
					case "ownerdocument":
                    case "ownerDocument":
						return this.ownerDocument; // it may be document fragment so use property value.
					case "contentdocument":
                    case "contentDocument":
                    case "document":
						return this.contentDocument;
					case "lang":
					case "language":
						return this.lang;
					case "onclick":
						return this.onclick;
                    case "ondblclick":
                        return this.ondblclick;
                    case "click":
                        return this.onclick;
					case "accept":
						return this.accept;
					case "action":
						return this.action;
					case "acceptcharset":
                    case "acceptCharset":
						return this.acceptCharset;
					case "align":
                    case "Align":
						return this.align;
					case "archive":
                    case "Archive":
						return this.archive;
					case "availleft":
                    case "availLeft":
						return this.___availLeft;
					case "availtop":
                    case "availTop":
						return this.___availTop;
					case "availwidth":
                    case "availWidth":
						return this.___availWidth;
					case "availheight":
                    case "availHeight":
						return this.___availHeight;
					case "axis":
						return this.axis;
					case "auto":
						return this.auto;
					case "selected":
                    case "Selected":
						return this.selected;
					case "defaultselected":
                    case "defaultSelected":
						return this.defaultSelected;
					case "bgcolor":
                    case "BGcolor":
                    case "BGColor":
						return this.bgColor;
					case "background-color":
					case "backgroundcolor":
                    case "Backgroundcolor":
                    case "backgroundColor":
                    case "BackgroundColor":
                        return commonHTML.___convertNullToEmpty(this.___style.backgroundcolor);
                    case "fgcolor":
                    case "FGColor":
                    case "FGcolor":
                    case "foregroundcolor":
                    case "foregroundColor":
                        return commonHTML.___convertNullToEmpty(this.___style.color);
					case "caption":
						return this.caption;
					case "rel":
						return this.rel;
					case "accesskey":
                    case "accessKey":
						return this.accessKey;
					case "complete":
                        ///
                        /// Caution) complete only exists on image element
                        ///
                        
                        if(this.___elementTagType == CHtmlElementType.IMG)
                        {
                            return this.___getImageElementCompleteStatusCode();
                        }else
                        {
                            break;
                        }
               
					case "readonly":
                    case "readOnly":
						return this.readOnly;
                    case "validationMessage":
                        return this.validationMessage;
                    case "scopeName":
                        if (this.___attributes.ContainsKey("scopename") == true)
                        {
                            string strScopeName = commonHTML.GetElementAttributeInString(this, "scopename");
                            if (strScopeName.Length != 0)
                            {
                                return strScopeName;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            return null;
                        }
					case "htmlfor":
                    case "htmlFor":
					case "for":
						return this.htmlFor;
					case "media":
						return this.media;
					case "mimetype":
                    case "mimeType":
						return this.mimeType;
					case "offsetparent":
                    case "offsetParent":
						return this.offsetParent;
                    case "longdesc":
                    case "longDesc":
                        return commonHTML.GetElementAttributeInString(this, "longdesc");
                    case "location":
                        if (this.___elementTagType == CHtmlElementType.IFRAME || this.___elementTagType == CHtmlElementType.FRAME)
                        {
                            CHtmlLocationBase ___adhocLocation = new CHtmlLocationBase();
                            if (this.___srcBase != null && this.___srcBase.href.Length > 0)
                            {
                                ___adhocLocation.___setHrefDirect(this.___srcBase.href);
                                ___adhocLocation.___AnalyzeLocation();
                            }
                            ___adhocLocation.___IsAdhocLocation = true;
                            ___adhocLocation.ownerElement = this;
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                            {
                               commonLog.LogEntry("___getInner location of {0} returns : {1}", this,___adhocLocation);
                            }
                            return ___adhocLocation;
                        }
                        else
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                            {
                               commonLog.LogEntry("___getInner location of {0} returns : null", this);
                            }
                            return null;
                        }

                       
					case "contentwindow":
                    case "contentWindow":
                        return this.contentWindow;
					case "basehref":
                    case "baseHref":
						return this.basehref;
					case "disabled":
						return this.disabled;
					case "coords":
						return this.coords;
					case "scrollleft":
                    case "scrollLeft":
						return this.scrollLeft;
					case "scrolltop":
                    case "scrollTop":
						return this.scrollTop;
					case "scrollwidth":
                    case "scrollWidth":
						return this.scrollWidth;
					case "scrollheight":
                    case "scrollHeight":
						return this.scrollHeight;
					case "hidden":
						return !this.___IsElementVisible;
					case "defer":
                        return this.___defer;
					case "multiple":
						return this.multiple;
					case "method":
						return this.Method;
					case "encoding":
						return this.encoding;
					case "enctype":
                    case "encType":
						return this.enctype;
					case "onabort":
						return this.onabort;
					case "onmouseout":
						return this.onmouseout;
					case "onmouseover":
						return this.onmouseover;
					case "onmousedown":
						return this.onmousedown;
					case "onmouseup":
						return this.onmouseup;
					case "onmousewheel":
                    case "onmouseWheel":
                    case "onMouseWheel":
						return this.onmousewheel;
					case "onmove":
						return this.onmove;
					case "onmouseleave":
						return this.onmouseleave;
                    case "onmousemove":
                        return this.onmousemove;
					case "onblur":
						return this.onblur;
					case "oncellchange":
						return this.oncellchange;
					case "oncopy":
						return this.oncopy;
					case "onactivate":
						return this.onactivate;
					case "onerrorupdate":
						return this.onerrorupdate;
					case "onfocus":
						return this.onfocus;
					case "onfocusin":
						return this.onfocusin;
					case "onfocusout":
						return this.onfocusout;
					case "onkeydown":
						return this.onkeydown;
                    case "onsubmit":
                        return this.onsubmit;
                    case "ondrag":
                        return this.ondrag;
                    case "ondrop":
                        return this.ondrop;
                    case "ondragstart":
                        return this.ondragstart;
                    case "ondragend":
                        return this.ondragend;
					case "onkeyup":
						return this.onkeyup;
					case "onkeypress":
						return this.onkeypress;
					case "onresize":
						return this.onresize;
					case "onresized":
						return this.onresizeend;
                    case "ontouchstart":
                        return this.ontouchstart;
                    case "ontouchend":
                        return this.ontouchend;
                     
                    case "onresizestart":
						return this.onresizestart;
					case "onselectstart":
						return this.onselectstart;
					case "tagurn":
                    case "tagUrn":
						return this.tagUrn;
					case "readystatevalue":
						return this.readyStateValue;
					case "oncontextmenu":
						return this.oncontextmenu;
					case "onpaste":
						return this.onpaste;
					case "onbeforecut":
						return this.onbeforecut;
					case "scopename":
                        return commonHTML.___convertNullToEmpty(this.___scopename);
					case "tabindex":
                    case "tabIndex":
						return this.tabIndex;
                    case "clientrectangle":
                    case "clientRectangle":
						return this.clientRectangle;
					case "canhavechildren":
                    case "canHaveChildren":
						return true;
					case "enabled":
						return this.___enabled;
					case "checked":
						return base.___checked;
					case "target":
						return this.@target;
					case "hidefocus":
                    case "hideFocus":
						return this.hideFocus;
					case "wrap":
                    case "Wrap":
						return this.wrap;
					case "nowrap":
                    case "noWrap":
						return this.wrap;
					case "role":
						return this.role;
					case "canhavehtml":
                    case "canHaveHtml":
						return this.canHaveHTML;
					case "ismultiline":
                    case "isMultiline":
						return this.isMultiline;
					case "istextedit":
                    case "isTextedit":
                    case "isTextEdit":
                        return this.istextedit;
                    case "iscontenteditable":
                    case "isContentEditable":
						return this.isContentEditable;
					case "contentEditable":
                    case "contenteditable":
						return this.contentEditable;
					case "link":
                    case "Link":
						return this.link;
					case "vlink":
                    case "vLink":
						return this.vlink;
					case "previouselement":
                    case "previousElement":
						return this.PreviousElement;
					case "recordnumber":
                    case "recordNumber":
						return this.recordNumber;
                    case "sourceindex":
                    case "sourceIndex":
						return this.sourceIndex;
					case "bgproperties":
                    case "bgProperties":
						return this.bgProperties;
		
					case "httpequiv":
                    case "http-equiv":
						return this.httpEquiv;
					case "hasattribute":
                    case "hasAttribute":
                        if (this.___attributes.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
					case "sizcache":
                    case "sizCache":
						return this.sizcache;
					case "sizset":
						return this.sizset;
					case "innertext":
                    case "innerText":
					case "text":
					case "textContent":
						return this.innerText;
                    case "content":
                        // ====================================================
                        // Usually, element.content is for META tag <meta content='http://'>
                        // not same as textContent
                        // 'content' does not exists in attributes
                        // it should return null;
                        // =====================================================
                        CHtmlAttribute attrContent  = null;
                        if (this.___attributes.Count > 0 && this.___attributes.TryGetValue("content", out attrContent) == true)
                        {
                            if (attrContent != null)
                            {
                                return attrContent.value;
                            }
                        }
                        return null;
					case "classlist": // HTML5 
                    case "classList": // HTML5 
						return base.___classList;
					case "scroll":
						return this.scroll;
					case "selectedindex":
                    case "selectedIndex":
						return this.selectedIndex;
					case "options":
						return this.CreateOptionsListForSelectTag();
                    case "uniqueid":
                    case "uniqueID":
                    case "uniqueId":
                        return this.uniqueID;
                    case "uniquenumber":
                    case "uniqueNumber":
                        return this.uniqueNumber;
                    case "naturalwidth":
                    case "naturalWidth":
                        if (this.___elementTagType == CHtmlElementType.IMG)
                        {
                            return (double)this.___getImgTagSrcImageSizeF().Width;
                        }
                        else
                        {
                            break;
                        }
                    case "naturalheight":
                    case "naturalHeight":
                        if (this.___elementTagType == CHtmlElementType.IMG)
                        {
                            return (double)this.___getImgTagSrcImageSizeF().Height;
                        }
                        else
                        {
                            break;
                        }
					case "length":
						switch(this.___elementTagType)
						{
							case CHtmlElementType._ITEXT:
							case CHtmlElementType.SELECT:
							case CHtmlElementType.FORM:
								return this.length;

						}
						break;

					case "rows":
						if(this.___elementTagType != CHtmlElementType.TABLE)
						{
							return this.rows;
						}
						else
						{
							return this.TableRows;
						}
                    case "cols":
                        return this.cols;
					case "size":
                    case "Size":
						object __objSize = this.size;
						// Note) SELECT.Size returns Number for IE and Chrome. (0 if non defined).
						//       If it is non Select tag, it becomes string for IE.
						//       Chrome returns undefined even if 'size='1' exists
						//       We follow IE behavior.
						if(this.___elementTagType != CHtmlElementType.SELECT)
						{
							return __objSize;
						}
						else
						{
							if(__objSize == null)
							{
								return 0;
							}
							else
							{
								return commonHTML.GetIntValueFromString(commonHTML.GetStringValue( __objSize), 0);
							}
						}
					case "atomicselection":
                    case "atomicSelection":
						return this.atomicselection;
					case "autofocus":
                    case "autoFocus":
						return this.autofocus;
					case "autocomplete":
                    case "autoComplete":
						return this.autocomplete;
					case "truespeed":
                    case "trueSpeed":
						return this.trueSpeed;
                    case "autoplay":
                        return this.autoplay;
					case "dataset":
                    case "dataSet":
                    case "DataSet":
						return this.___dataset;
					case "element": // Supporse this is Form Element
						return this.GetFormElementList();
					case "translate":
						return this.translate;
					case "protocol":
					case "host":
					case "port":
					case "hostname":
                    case "hostName":
					case "pathname":
					case "origin":
					case "hash":
					case "search":
						// =============================
						// Chrome only returns value if href is defined
						// =============================
						if(this.___elementTagType != CHtmlElementType.A)
						{
							return null;
						}
						else
						{
							if(this.___hrefBase != null)
							{
								switch(___name)
								{
									case "host":
									case "hostname":
										return this.___hrefBase.Hostname;
									case "origin":
                                        return this.___hrefBase.href;
									case "protocol":
										return this.___hrefBase.Protocol;
									case "port":
										return this.___hrefBase.Port;
									case "pathname":
										return this.___hrefBase.Pathname;
									case "search":
										return this.___hrefBase.Query;
									case "hash":
										return this.___hrefBase.Hash ;
                                    case "href":
                                        return this.___hrefBase.Href;
                                    case "url":
                                        return this.___hrefBase.href;
									default:
										break;
								}
							}
							return  "";
						}
                    case "__iterator__":

                        return commonHTML.rhinoForLoopEnumratorFunction;
                    case "getApiInterface":
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 30)
                        {
                           commonLog.LogEntry("getApiInterface() is null");
                        }
                        return null;
                    case "width":
                    case "Width":
                        switch (this.___elementTagType)
                        {
                            case CHtmlElementType.CANVAS:

                                return this.___offsetWidth;
                            case CHtmlElementType.IMG:
                                if (this.___offsetWidth == 0)
                                {
                                    if (this.___style.___WidthComputedValue > 0)
                                    {
                                        this.___offsetWidth = this.___style.___WidthComputedValue;
                                        return this.___offsetWidth;
                                    }
                                    if (this.___style.___IMG_ImageWeakReference != null)
                                    {
                                        Image ___img = this.___style.___IMG_ImageWeakReference.Target as Image;
                                        if (___img != null)
                                        {
                                            this.___offsetWidth = ___img.Width;

                                        }
                                    }
                                }
                                return this.___offsetWidth;


                            default:
                                return this.___offsetWidth;
                        }
                    case "height":
                    case "Height":
                        switch (this.___elementTagType)
                        {
                            case CHtmlElementType.CANVAS:

                                return this.___offsetHeight;
                            case CHtmlElementType.IMG:
                                if(this.___offsetHeight == 0)
                                {
                                    if(this.___style.___HeightComputedValue > 0)
                                    {
                                        this.___offsetHeight = this.___style.___HeightComputedValue;
                                        return this.___offsetHeight;
                                    }
                                    if(this.___style.___IMG_ImageWeakReference != null)
                                    {
                                        Image ___img = this.___style.___IMG_ImageWeakReference.Target as Image;
                                        if(___img != null)
                                        {
                                            this.___offsetHeight = ___img.Height;
                                            
                                        }
                                    }
                                }
                                return this.___offsetHeight;
                        

                    default:
                                return this.___offsetHeight;
                        }
                    case "defaultValue":
                            CHtmlAttribute attrDefaultValue = null;
                            if (this.___attributes.TryGetValue(___name, out attrDefaultValue) == true)
                            {
                                if (attrDefaultValue != null)
                                {
                                    return attrDefaultValue.value;
                                }
                            }
                        
                        return null;
                    case "defaultView":
                        return this.defaultView;

					default:
                        if (this.___attributes != null && this.___attributes.Count > 0)
                        {
                            // Note) Element.___attibutes does not have TryGetValue 
                            //          Element may assinged null. 
                            //          in that case, we should not lookup parent scope.
                            CHtmlAttribute attr = null;
                            if (this.___attributes.TryGetValue(___name, out attr) == true)
                            {
                                if (attr != null)
                                {
                                    return attr.value;
                                }
                            }
                            
                        }
                        if (this.___elementTagType == CHtmlElementType.AUDIO || this.___elementTagType == CHtmlElementType.VIDEO)
                        {
                            break;
                        }
                        
                        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        // Lookup for Prototype
                        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        if (this.___IsPrototype == false && this.___prototypeWeakReference != null)
                        {
                            CHtmlElement ___protoElement = null;
                            ___protoElement = this.___prototypeWeakReference.Target as CHtmlElement;
                            int __ProtoLookupCont = 0;
                            while (___protoElement != null)
                            {
                                if (___protoElement.___IsPrototype == false)
                                {
                                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                                    {
                                       commonLog.LogEntry("GetPropertyValue Prototype ___hasInner not prototype objbect {0} : {1} ", this, ___protoElement);
                                    }
                                    break;
                                }
                                __ProtoLookupCont++;
                                if (__ProtoLookupCont > 10)
                                {
                                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                                    {
                                       commonLog.LogEntry("GetPropertyValue for {0} {1} Prototype lookup loop limit break!", this.GetType(), this);
                                    }
                                    break;
                                }

                                if (___protoElement.___attributes.Count > 0)
                                {
                                    CHtmlAttribute attrProto = null;
                                    if (___protoElement.___attributes.TryGetValue(___name, out attrProto))
                                    {
                                        if (attrProto != null)
                                        {
                                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                                            {
                                               commonLog.LogEntry("GetPropertyValue for {0} {1} Protototype lookup for '{2}' success : {3}", this.GetType(), this, ___name, attrProto.value);
                                            }
                                            return attrProto.value;
                                        }
                                    }

                                }
                                if (___protoElement.___elementTagType == CHtmlElementType._ELEMENT_PROTOTYPE)
                                {
                                    break;
                                }
 
                                if (___protoElement.___parentNode != null)
                                {
                                    ___protoElement = ___protoElement.___parentNode  as CHtmlElement;
                                }
                                else
                                {
                                    break;
                                }


                            }


                        }

                        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
						break;
				}

                // =========================================================================
                // In case the element is FORM, it may be element lookup. try one.
                // =========================================================================
                if (this.___elementTagType == CHtmlElementType.FORM)
                {
                    CHtmlCollection formElements = this.elements;
                    int formElementsCount = formElements.Count;
                    if (formElements != null && formElements.Count > 0)
                    {
                        for (int i = 0; i < formElementsCount; i++)
                        {
                            CHtmlElement formElem = formElements[i] as CHtmlElement;
                            if (formElem != null)
                            {
                                if (string.IsNullOrEmpty(formElem.___idLowSimple) == false)
                                {
                                    if (string.Equals(formElem.___idLowSimple, ___name, StringComparison.OrdinalIgnoreCase) == true)
                                    {
                                        return formElem;

                                    }
                                }
                                if (string.IsNullOrEmpty(formElem.___name) == false)
                                {
                                    if (string.Equals(formElem.___name, ___name, StringComparison.OrdinalIgnoreCase) == true)
                                    {
                                        return formElem;
                                    }
                                }
                            }
                        }
                    }
                    
                }
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
				{
					commonLog.LogEntry("GetPropertyValue for {0} {1} '{2}' failed",this.GetType(), this, ___name);
				}
			}			
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 5)
				{
					commonLog.LogEntry("x_GetPropertyValue", ex);
				}
			}
			return null;
		}

        public bool ___isElementPositionAbsoluteOrStatic
        {
            get
            {
                if(this.___style != null)
                {
                    if(this.___style.___cssPositionComputedValueType == CSSPositionType.absolute || ___style.___cssPositionComputedValueType == CSSPositionType.@static)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

		public virtual void ___setPropertyByName(string ___name, object val)
		{
			bool ___ValueStored = true;

			try
			{
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry($"{this.toLogString()} {this.GetType().FullName} {this.toLogString()}.set :   {___name} = {val}");
                }
              

                FunctionPreCheckDone:
                switch (___name)
				{
				
					case "type":
						string ___strType = commonHTML.GetStringValue(val);
                        // ==================================================
                        // some script assign type value as "true/text/javascript". This is workaround.
                        // ==================================================
                        if (string.IsNullOrEmpty(___strType) == false && ___strType.Length == 20)
                        {
                            if (string.Equals(___strType, "true/text/javascript", StringComparison.OrdinalIgnoreCase) == true || string.Equals(___strType, "text/javascript/true", StringComparison.OrdinalIgnoreCase) == true)
                            {
 

                                ___strType = "text/javascript";
                                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                                {
                                   commonLog.LogEntry("wrong type is assinged convert value {0} => {1}", ___strType, val);
                                }
                                this.___async = true;

                            }
                        }
                        base.type = ___strType;
						CHtmlAttribute typeAttr = new CHtmlAttribute();
						typeAttr.name = "type";
                        typeAttr.value = base.type;
                        typeAttr.setParentNode(this) ;
						this.___attributes["type"] = typeAttr;
						if(((this.___KeyAttributes & CHtmlElementDeclaredAttributeType.Type) == CHtmlElementDeclaredAttributeType.Type)== false)
						{
							this.___KeyAttributes = this.___KeyAttributes | CHtmlElementDeclaredAttributeType.Type;
						}
						goto ExitSet;
					case "id":
                    case "Id":
                    case "ID":
						// We want id alter check. to use "this.id", not "base.id"
						this.id = commonHTML.GetStringValue(val);
						this.___attributes["id"] = this.id;
						if(string.IsNullOrEmpty(this.___idLowSimple) == false && ___WillElementIDAlternationRequiresDocumentCheck)
						{
							if(this.___Document != null)
							{
								this.___Document.___registerElementIDToDocument(this);
							}
						}
						if(((this.___KeyAttributes & CHtmlElementDeclaredAttributeType.ID) == CHtmlElementDeclaredAttributeType.ID)== false)
						{
							this.___KeyAttributes = this.___KeyAttributes | CHtmlElementDeclaredAttributeType.ID;
						}
                        if (this.___isCalculateElementBoundsCalled == true)
                        {
                            if (commonHTML.elementTagTypesNeverSeachStyleSheetSortedList.ContainsKey(this.___elementTagType) == false)
                            {
                                if (this.___Document != null && this.___Document.___IsDomModeFullParseMode() == true)
                                {
                                    if (commonHTML.isElementAfterwordCSSLookupNeedsToBeEnqueued(this) == false)
                                    {
                                        this.___Document.___applyElementsStyleSheetsForRecaluculationForRootChangedElement(this);
                                    }
                                    else
                                    {
                                        if (System.Threading.Monitor.TryEnter(this.___Document.___CSSSearchDeepPendingElementList_LockingObject, 1000))
                                        {
                                            try
                                            {
                                                if (this.___Document.___CSSSearchDeepPendingElementList != null && this.___Document.___CSSSearchDeepPendingElementList.ContainsKey(this.___elementOID) == false)
                                                {
                                                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                                                    {
                                                       commonLog.LogEntry("CSS lookup needs to deep css search... enqueue now : {0}", this);
                                                    }
                                                    this.___Document.___CSSSearchDeepPendingElementList[this.___elementOID] = new WeakReference(this, false);
                                                }
                                            }
                                            finally
                                            {
                                                System.Threading.Monitor.Exit(this.___Document.___CSSSearchDeepPendingElementList_LockingObject);
                                            }
                                        }
                                    }
                                }
                            }
                        }
						goto ExitSet;
					case "innerhtml":
                    case "innerHtml":
                    case "innerHTML":
						this.innerHTML = commonHTML.GetStringValue(val);
						goto ExitSet;
                    case "outerhtml" :
                    case "outerHtml":
                    case "outerHTML":
                    case "outerxml":
                    case "outerXML":
                        this.outerHTML = commonHTML.GetStringValue(val);
                        goto ExitSet;
					case "tagName":
						this.tagName =   commonHTML.GetStringValue(val);
						goto ExitSet;
                    case "autoplay":
                        this.autoplay  = commonData.convertObjectToBoolean(val);
                        goto ExitSet;
                    case "scopeName":
                        this.scopeName = commonHTML.GetStringValue(val);
                        goto ExitSet;
					case "nodetype":
                    case "nodeType":
						if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
						{
							commonLog.LogEntry("ignoreed: nodeType is set {0}", val);
						}
						goto ExitSet;
					case "class":
					case "classname":
                    case "className":
						base.@class =   commonHTML.GetStringValue(val);
               
						this.___attributes["class"] = this.@class;
						if(((this.___KeyAttributes & CHtmlElementDeclaredAttributeType.Class) == CHtmlElementDeclaredAttributeType.Class)== false)
						{
							this.___KeyAttributes = this.___KeyAttributes | CHtmlElementDeclaredAttributeType.Class;
						}
                        if (this.___isCalculateElementBoundsCalled == true)
                        {
                            if (commonHTML.elementTagTypesNeverSeachStyleSheetSortedList.ContainsKey(this.___elementTagType) == false)
                            {
                                if (this.___Document != null && this.___Document.___IsDomModeFullParseMode() == true)
                                {
                                    if (commonHTML.isElementAfterwordCSSLookupNeedsToBeEnqueued(this) == false)
                                    {
                                        this.___Document.___applyElementsStyleSheetsForRecaluculationForRootChangedElement(this);
                                    }
                                    else
                                    {
                                        if (System.Threading.Monitor.TryEnter(this.___Document.___CSSSearchDeepPendingElementList_LockingObject, 1000))
                                        {
                                            try
                                            {
                                                if (this.___Document.___CSSSearchDeepPendingElementList != null && this.___Document.___CSSSearchDeepPendingElementList.ContainsKey(this.___elementOID) == false)
                                                {
                                                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                                                    {
                                                       commonLog.LogEntry("CSS lookup needs to deep css search... enqueue now : {0}", this);
                                                    }
                                                    this.___Document.___CSSSearchDeepPendingElementList[this.___elementOID] = new WeakReference(this, false);
                                                }
                                            }
                                            finally
                                            {
                                                System.Threading.Monitor.Exit(this.___Document.___CSSSearchDeepPendingElementList_LockingObject);
                                            }
                                        }
                                    }
                                }
                            }
                        }
						goto ExitSet;
                    case "classid":
                    case "classId":
                    case "classID":
                        this.classid = commonHTML.GetStringValue(val);
                        goto ExitSet;

					case "name":
						base.name =   commonHTML.GetStringValue(val);
                        this.SetGetAttributesByName("name", val, true);
                        if (this.___elementTagType == CHtmlElementType.IFRAME)
                        {
                            this.___setIFrameNameIfExists();
                        }
						if(((this.___KeyAttributes & CHtmlElementDeclaredAttributeType.Name) == CHtmlElementDeclaredAttributeType.Name)== false)
						{
							this.___KeyAttributes = this.___KeyAttributes | CHtmlElementDeclaredAttributeType.Name;
						}
                        if (this.___IsElementIncludedInFormCacheList == true)
                        {
                            if (this.___elementTagType == CHtmlElementType.INPUT || this.___elementTagType == CHtmlElementType.SELECT || this.___elementTagType == CHtmlElementType.BUTTON)
                            {

                                ___ClearParentFormElementCacheList();

                            }
                        }
                        if (this.___isCalculateElementBoundsCalled == true)
                        {
                            if (commonHTML.elementTagTypesNeverSeachStyleSheetSortedList.ContainsKey(this.___elementTagType) == false)
                            {
                                if (this.___Document != null && this.___Document.___IsDomModeFullParseMode() == true)
                                {
                                    if (commonHTML.isElementAfterwordCSSLookupNeedsToBeEnqueued(this) == false)
                                    {
                                        this.___Document.___applyElementsStyleSheetsForRecaluculationForRootChangedElement(this);
                                    }
                                    else
                                    {
                                        if (this.___Document.___CSSSearchDeepPendingElementList != null && this.___Document.___CSSSearchDeepPendingElementList.ContainsKey(this.___elementOID) == false)
                                        {
                                            if(System.Threading.Monitor.TryEnter(this.___Document.___CSSSearchDeepPendingElementList_LockingObject, 1000))
                                            {
                                                try
                                                {
                                                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                                                    {
                                                       commonLog.LogEntry("CSS lookup needs to deep css search... enqueue now : {0}", this);
                                                    }
                                                    this.___Document.___CSSSearchDeepPendingElementList[this.___elementOID] = new WeakReference(this, false);
                                                }
                                                finally
                                                {
                                                    System.Threading.Monitor.Exit(this.___Document.___CSSSearchDeepPendingElementList_LockingObject);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

						goto ExitSet;
                    case "longdesc":
                    case "longDesc":
                        this.SetGetAttributesByName("longdesc", val, true); 
                        goto ExitSet;
					case "checked":
						try
						{
                            if (val is bool)
                            {
                                this.@checked = (bool)val;
                            }
                            else 
                            {
                                string strChecked = commonHTML.GetStringValue(val);
                                switch (strChecked)
                                {
                                    case "checked":
                                    case "true":
                                    case "1":
                                    case "True":
                                        this.@checked = true;
                                        break;
                                    default:
                                        this.@checked = false;
                                        break;
                                }
                                goto ExitSet;
                            }
						}
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                            {
                               commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                            }
                        }
						goto ExitSet;
					case "nodevalue":
                    case "nodeValue":
					case "value":
						this.value =  val;
						goto ExitSet;
					case "src":
						this.src =  commonHTML.GetStringValue(val);
						goto ExitSet;
					case "auto":
						this.auto =  commonHTML.GetStringValue(val);
						goto ExitSet;
					case "style":
					case "stylesheet":
                    case "styleSheet":
						// ----------------------------------------------------
						// Node "styesheet" needs to return style Element
						// 'http://www.venturenow.jp/'  
						// -----------------------------------------------------
						if(val is CHtmlCSSStyleSheet)
						{
							this.___style  =  val as CHtmlCSSStyleSheet;
						}
						else if(val is string)
						{
							if(this.___style != null)
                            {
                                this.___style.cssTextSetter(val as string);
                            }
						}
						goto ExitSet;
					case "charset":
					case "characterset":
                    case "characterSet":
						this.charset =  commonHTML.GetStringValue(val);
						goto ExitSet;
					case "parent":
					case "parentnode":
                    case "parentNode":
					case "parentelement":
                    case "parentElement":
						if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
						{
							commonLog.LogEntry("Setting Parent Node {0} is prohibitted.", val);
						}
						//this.___parent = val as CHtmlBase;
						goto ExitSet;
					case "href":
						this.href = commonHTML.GetStringValue(val);
						goto ExitSet;
                    case "sheet":
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                        {
                           commonLog.LogEntry("Strange. Setting Element sheet : {0}", val);
                        }
                        goto ExitSet;
                    case "dir":
                        this.dir = commonHTML.GetStringValue(val);
                        goto ExitSet;
					case "onreadystatechange":
						this.onreadystatechange = val;
						goto ExitSet;
					case "onload":
						this.onload = val;
						goto ExitSet;
					case "onunload":
						this.onunload = val;
						goto ExitSet;
					case "onerror":
					case "error":
						this.onerror = val;
						goto ExitSet;
                    case "onchange":
                        this.onchange = val;
                        goto ExitSet;

					case "onblur":
						this.onblur = val;
						goto ExitSet;
					case "onmouseout":
						this.onmouseout = val;
						goto ExitSet;
                    case "onmousemove":
						this.onmousemove = val;
                        goto ExitSet;
                    case "onmousehover":
                        this.onmouseover = val;
                        goto ExitSet;
                    case "onmouseup":
                        this.onmouseup = val;
                        goto ExitSet;
                    case "onmousedown":
                        this.onmousedown = val;
                        goto ExitSet;
					case "onmouseover":
						this.onmouseover = val;
						goto ExitSet;
                    case "onmouseenter":
                        this.onmouseenter = val;
                        goto ExitSet;
					case "onmove":
						this.onmove  = val;
						goto ExitSet;
					case "onkeydown":
					case "keydown":
						this.onkeydown  = val;
						goto ExitSet;
					case "onkeypress":
					case "keypress":
						this.onkeypress  = val;
						goto ExitSet;
                    case "onsubmit":
                        this.onsubmit = val;
                        goto ExitSet;
                    case "ondrop":
                        this.ondrop = val;
                        goto ExitSet;
                    case "ondrag":
                        this.ondrag = val;
                        goto ExitSet;
                    case "ondragstart":
                        this.ondragstart = val;
                        goto ExitSet;
                    case "ondragend":
                        this.ondragend = val;
                        goto ExitSet;
                    case "ontouchstart":
                        this.ontouchstart = val;
                        goto ExitSet;
                    case "ontouchend":
                        this.ontouchend = val;
                        goto ExitSet;
					case "onkeyup":
					case "keyup":
						this.onkeyup  = val;
						goto ExitSet;
                    case "itemscope":
                    case "itemScope":
                        this.itemScope = commonData.convertObjectToBoolean(val);
                        goto ExitSet;
                    case "prototype":
                        this.___properties["prototype"] = val;
                        goto ExitSet;
					case "width":
                    case "Width":
						if(this.___style != null)
						{
							this.___style.___Width = commonHTML.GetStringValue(val) ;
						}
                        if (this.___elementTagType == CHtmlElementType.CANVAS)
                        {
                            double doubleWidth = commonHTML.GetDoubleValueFromString(this.___style.___Width, this.___availWidth, -1);
                            if (Math.Abs(doubleWidth - this.___offsetWidth) > 10)
                            {
                                this.___offsetWidth = (float)doubleWidth;
                                ___resetC2DBitmapImageBaseduponOffsetSize();

                            }
                            if (this.___canvasContextCurrent2D != null)
                            {
                                ___canvasContextCurrent2D.___CanvasWidth = doubleWidth;
                            }
                        }
						goto ExitSet;
					case "height":
                    case "Height":
						if(this.___style != null)
						{
							this.___style.Height =commonHTML.GetStringValue(val);
						}
                        if (this.___elementTagType == CHtmlElementType.CANVAS)
                        {
                            double doubleHeight = this.___style.___HeightComputedValue;
                            this.___offsetHeight = (float)doubleHeight;
                            ___resetC2DBitmapImageBaseduponOffsetSize();
                            if (this.___canvasContextCurrent2D != null)
                            {
                                ___canvasContextCurrent2D.___CanvasHeight = doubleHeight;
                            }
                        }
						goto ExitSet;
					case "frameborder":
                    case "frameBorder":
						this.frameBorder = commonHTML.GetStringValue(val);
						goto ExitSet;
					case "allowtransparency":
                    case "allowTransparency":
						try
						{
							this.allowtransparency = commonData.convertObjectToBoolean(val);
						}
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                            {
                               commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                            }
                        }
						goto ExitSet;
                    case "url":
                        if(this.___elementTagType == CHtmlElementType.IMG)
                        {
                            this.src = commonHTML.GetStringValue(val); 
                        }
                        goto ExitSet;

                    case "location":
                        if (val is string)
                        {
                            if (this.___elementTagType == CHtmlElementType.IFRAME || this.___elementTagType == CHtmlElementType.FRAME)
                            {
                                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                                {
                                   commonLog.LogEntry("set element {0} lcation is called. set values as src : {1}", this, val);
                                }
                                this.src = commonHTML.GetStringValue(val);
                            }
                            else
                            {
                                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                                {
                                   commonLog.LogEntry("set element {0} lcation is called but skip non frame element : {1}", this, val);
                                }
                            }
                        }
                        else
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                            {
                               commonLog.LogEntry("set element {0} lcation is called but skip : {1}", this, val);
                            }
                        }
                        goto ExitSet;
                    case "srcdoc":
                    case "srcDoc":
                        this.srcdoc = commonHTML.GetStringValue(val);
                        goto ExitSet;
					case "async":
						if(val is bool)
						{
                            this.async = commonTypeConverter.convertObjectToBoolean(val, false);
							break;
						}
						try
						{
							if(val is string)
							{
								string strValue = commonHTML.GetStringValue(val);
                                switch (strValue)
                                {
                                    case "":
                                        this.async = false;
                                        break;
                                    case "true":
                                    case "True":
                                    case "TRUE":
                                    case "1":
                                    case "Async":
                                    case "async":
                                        this.async = true;
                                        break;
                                    case "false":
                                    case "False":
                                    case "none":
                                    case "no":
                                    case "None":
                                    case "0":
                                        this.async = false;
                                        break;
                                    case "sync":
                                    case "Sync":
                                        this.async = false;
                                        break;


                                }
							}
							else
							{
								this.async = commonData.convertObjectToBoolean(val);
							}
						}
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                            {
                               commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                            }
                        }
						goto ExitSet;
					case "defer":
						try
						{
							if(val is string)
							{
								string deferValStr =  commonHTML.GetStringValue(val);
								if(string.Equals(deferValStr , "defer",StringComparison.OrdinalIgnoreCase) == true)
								{
									this.defer = true;
									goto DeferDone;
								}
                                else if (string.Equals(deferValStr, "true", StringComparison.OrdinalIgnoreCase) == true)
								{
									this.defer = true;
									goto DeferDone;
								}
                                else if (string.Equals(deferValStr, "false", StringComparison.OrdinalIgnoreCase) == true)
								{
									this.defer = false;
									goto DeferDone;
								}

							}
							
							this.defer = commonData.convertObjectToBoolean(val);
						}
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                            {
                               commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                            }
                        }
						DeferDone:
						goto ExitSet;
					case "contentEditable":
                    case "contenteditable":
						try
						{
							this.contentEditable = commonData.convertObjectToBoolean(val);
						}
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                            {
                               commonLog.LogEntry("{0} ___hasInner error {1}", this,commonData.GetExceptionAsString(ex));
                            }
                        }
						goto ExitSet;

					case "clientwidth":
                    case "clientWidth":
						this.clientWidth = commonHTML.GetIntValueFromString(val.ToString(), 0);
						goto ExitSet;
					case "clientheight":
                    case "clientHeight":
						this.clientHeight = commonHTML.GetIntValueFromString(val.ToString(), 0);
						break;
					case "alt":
                    case "Alt":
						this.alt = commonHTML.GetStringValue(val);
						goto ExitSet;
					case "lang":
					case "language":
						this.lang = commonHTML.GetStringValue(val);
						goto ExitSet;
					case "title":
						this.title = commonHTML.GetStringValue(val);
						goto ExitSet;
					case "onclick":
                    case "onClick":
						this.onclick = val;
                        goto ExitSet;
                    case "ondblclick":
                    case "ondoubleclick":
                    case "onDoubleClick":
                    case "OnDoubleClick":
                        this.ondblclick = val;
                        goto ExitSet;
                    case "click":
                        this.onclick = val;
                        goto ExitSet;
                    case "uniqueid":
                    case "uniqueId":
                    case "uniquenumber":
                    case "uniqueNumber":
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("set Element.uniqueid is prohibitted");
                        }
                        return;
                        
					case "innertext":
                    case "innerText":
					case "textcontent":
                    case "textContent":
					case "text":
                        this.innerText = commonHTML.GetStringValue(val);
						goto ExitSet;
                    case "content":
                        this.content = commonHTML.GetStringValue(val);
                        goto ExitSet;

					case "sizset":
						this.sizset = commonHTML.GetStringValue(val);
						goto ExitSet;
					case "sizcache":
						this.sizcache = commonHTML.GetStringValue(val);
						goto ExitSet;
					case "size":
						this.size = val; // it may store int value not string keep as is.
						goto ExitSet;
					case "selectedindex":
                    case "selectedIndex":
						this.selectedIndex = commonHTML.GetIntFromObject(val, 0);
						goto ExitSet;
					case "canhavehtml":
                    case "canHaveHtml":
						this.canHaveHTML = commonData.convertObjectToBoolean(val);
						goto ExitSet;
					case "multiple":
						this.multiple = commonData.convertObjectToBoolean(val);
						goto ExitSet;
					case "autofocus":
						this.autofocus = commonData.convertObjectToBoolean(val);
						goto ExitSet;
					case "selected":

                        this.selected = commonHTML.GetBooleanForSelectedAttribute(val);
                        
						goto ExitSet;
                    case "disabled":
                        this.disabled = commonData.convertObjectToBoolean(val);
                        goto ExitSet;
                    case "truespeed":
                    case "trueSpeed":
						this.trueSpeed = commonData.convertObjectToBoolean(val);
						goto ExitSet;
					case "hidden":
						this.hidden = commonData.convertObjectToBoolean(val);
						goto ExitSet;
					case "readonly":
                    case "readOnly":
						this.readOnly = commonData.convertObjectToBoolean(val);
						goto ExitSet;
					case "htmlfor":
                    case "htmlFor":
					case "for":
						this.htmlFor = commonHTML.GetStringValue(val);
						goto ExitSet;
					case "mimetype":
                    case "mimeType":
						this.mimeType = commonHTML.GetStringValue(val);
						goto ExitSet;
					case "translate":
						this.translate = commonHTML.GetStringValue(val);
						goto ExitSet;
					case "fgcolor":
					case "color":
					case "foregroundcolor":
                    case "foregroundColor":
						this.foregroundColor = commonHTML.GetStringValue(val);
						this.___style.color =commonHTML.GetStringValue(val);
						goto ExitSet;
					case "bgcolor":
					case "backgroundcolor":
                    case "backgroundColor":
						this.backgroundcolor = commonHTML.GetStringValue(val);
						this.___style.BackgroundColor = commonHTML.GetStringValue(val);
						goto ExitSet;
                    case "namespaceuri":
                    case "namespaceUri":
                    case "namespaceURI":
                        this.namespaceURI = commonHTML.GetStringValue(val);
                        goto ExitSet;
                
                    case "rows":

                        if (this.___elementTagType == CHtmlElementType.TEXTAREA)
                        {
                            this.rows = (int)commonData.GetDoubleFromObject(val, 0);
                        }
                        else
                        {
                            this.rows = commonHTML.GetStringValue(val);
                        }
                        goto ExitSet;
                    case "cols":
                        if (this.___elementTagType == CHtmlElementType.TEXTAREA)
                        {
                            this.cols = (int)commonData.GetDoubleFromObject(val, 0);
                        }
                        else
                        {
                            this.cols = commonHTML.GetStringValue(val);
                        }
                        goto ExitSet;
                    case "scrolling":
                        this.scrolling = commonHTML.GetStringValue(val);
                        goto ExitSet;
                    case "media":
                        this.media = commonHTML.GetStringValue(val);
                        goto ExitSet;


					default:

						break;
				}
				if(this.___attributes != null)
				{
					CHtmlAttribute newAttr = new CHtmlAttribute();
                    newAttr.name = ___name;
                    newAttr.setParentNode(this);
					newAttr.value = val;
                    this.___attributes[newAttr.name] = newAttr;
                    if (this.___IsPrototype == true)
                    {
                        this.___ElementPrototypeMethodPropertyCount++;
                    }

					___ValueStored = true;
				}
				else
				{
					___ValueStored = false;
				}
			}
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
				{
					commonLog.LogEntry("SetPropertyValue for {0} {1}  '{2}' = {3} ERROR: {4}",this.GetType(), this.toLogString(), ___name, val,  ex.Message );
				}
				
			}
			ExitSet:
			if(commonLog.LoggingEnabled &&commonLog.LogLevel > 10)
			{
				commonLog.LogEntry("SetPropertyValue for {0} {1}  '{2}' = {3} Success : {4}",this.GetType(), this.toLogString(), ___name, val, ___ValueStored );
			}
		}

        private void ___ClearParentFormElementCacheList()
        {
            this.___IsElementIncludedInFormCacheList = false;
            if (this.___FormElementCacheList != null)
            {
                this.___FormElementCacheList = null;
            }
            CHtmlElement formparent = this.___parent as CHtmlElement;
            int loopCount = 0;
            while (formparent != null)
            {
                if (loopCount > 5)
                {

                    break;
                }
                if (formparent.___elementTagType == CHtmlElementType.FORM)
                {
                    if (formparent.___FormElementCacheList != null)
                    {
                        formparent.___FormElementCacheList = null;
                    }
                    return;
                }
                else
                {
                    // other types may have cleated element lists
                    if (formparent.___FormElementCacheList != null)
                    {
                        formparent.___FormElementCacheList = null;
                    }
                }
                formparent = formparent.___parent as CHtmlElement;
                loopCount++;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel > 10)
            {
               commonLog.LogEntry("___ClearParentFormElementCacheList() cound not find parent at level 5  : " + this.toLogString());
            }
        }

        private uint ___ElementPropertyAccessByIndexCount = 0;
        private System.DateTime ___ElementPropertyAccessByIndexLastTime;

		/// <summary>
		/// when CHtmlElement is accessed by like document.body[1], it should return the input selement. not child nodes
		/// </summary>
		/// <param name="___index"></param>
		/// <returns></returns>
        public virtual object ___getPropertyByIndex(int ___index)
		{
            if (___ElementPropertyAccessByIndexCount < uint.MaxValue)
            {
                ___ElementPropertyAccessByIndexCount++;
            }
            // ====================================================================
            // Note) Some scripts accidentally or intentiinally access element[x], which is normaly not supported.
            // However, it may ends up with infinite loop for the scripts. To force to terminate call, we attempts throw an error.
            // ====================================================================
            if (___ElementPropertyAccessByIndexCount > 10)
            {
                TimeSpan tpSpan = DateTime.Now.Subtract(___ElementPropertyAccessByIndexLastTime);
                if (tpSpan.TotalMilliseconds < 100)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("Element ___getPropertyByName by index {0} {1} {2} will throw exception.", this.GetType(), this, ___index);
                    }
                    ___ElementPropertyAccessByIndexLastTime = DateTime.Now;
                    ___ElementPropertyAccessByIndexCount = 0;
                    throw new System.NotSupportedException("Illegal Sequential access Element index item. It is not suported. use node.children");
                }
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("Element ___getPropertyByName by index {0} {1} {2} will returns null", this.GetType(), this, ___index);
            }
            ___ElementPropertyAccessByIndexLastTime = DateTime.Now;
			return null;
		}
        public virtual void ___setPropertyByIndex(int ___index, object val)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel>= 8)
			{
				commonLog.LogEntry("SetPropertyValueIndex for {0} \'{1}\' {2} = {3} failed",this.GetType(), this, ___index, val);
			}
		}

        public virtual bool ___hasPropertyByName(string ___name)
		{

            return false;
		}
        public virtual bool ___hasPropertyByIndex(int ___index)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("TODO: ___hasPropertyByIndex {0} {1} {2} called", this.GetType(), this, ___index );
            }
            return false;
		}
        public virtual object ___common_object_clone()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("x__Clone {0} {1} called",this.GetType(), this);
			}
			return this;
		}
        public virtual void ___deleteByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}",this.GetType(), this, ___index);
			}
		}
        public virtual void ___deleteByName(string ___name)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByName {0} {1} called : {2}",this.GetType(), this, ___name);
			}

		}
        internal void ___CallAddToDocumentDynamically(CHtmlDocument __resetttingOwnerDocument)
        {
            if (__resetttingOwnerDocument != null && string.IsNullOrEmpty(this.___id) == false)
            {
                __resetttingOwnerDocument.___registerElementDocumentElementID(this);
            }
        }
       internal void ___CallAddToDocumentDynamicallyAndRecursively(CHtmlDocument __resetttingOwnerDocument, int ___stackLevel)
        {
            if (___stackLevel > 50)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("___CallAddToDocumentDynamicallyAndRecursively stack too deep abrot");
                }
                return;
            }
            if (__resetttingOwnerDocument != null && string.IsNullOrEmpty(base.___id) == false)
            {
                __resetttingOwnerDocument.___registerElementDocumentElementID(this);
            }
            int ___childCount = this.___childNodes.Count;
            for (int i = 0; i < ___childCount; i++)
            {
                CHtmlElement ___childElement = this.___childNodes[i] as CHtmlElement;
                if (___childElement != null)
                {
                    ___stackLevel++;
                    ___childElement.___CallAddToDocumentDynamicallyAndRecursively(__resetttingOwnerDocument,___stackLevel);
                    ___stackLevel--;
                }
            }
        }
        public void ___ResetOwnerDocumentAndDocumentChildElementIndexRecursively(CHtmlDocument ___resettingOwnerDocument)
        {
            if (this.___documentWeakRef  != null)
            {
                this.___documentWeakRef  = null;
            }
            this.___documentWeakRef = new WeakReference(___resettingOwnerDocument, false);

            this.___IsDynamicElement = true;
            this.___IsDynamicProcessDone = false;
            this.___isCalculateElementBoundsCalled = false;
            this.___IsAttributesMergedToInlineStyle = false;
            this.___isApplyElemenetStyleSheetCalled = false;
            int ___childCount = this.___childNodes.Count;
            for (int i = 0; i < ___childCount; i++)
            {
                CHtmlElement __childElement = this.___childNodes[i] as CHtmlElement;
                if (__childElement != null)
                {
                    __childElement.___ResetOwnerDocumentAndDocumentChildElementIndexRecursively(___resettingOwnerDocument);
                }
            }
        }
        public virtual object[] ___getByIds()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getByIds() {0} {1} called",this.GetType(), this);
			}
			return null;

		}
        public virtual string ___getClassName()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getClassName {0} {1} called",this.GetType(), this);
			}
			return this.GetType().Name;
		}
        public override string ToString()
        {
            return "[object " + base.___multiversalClassType.ToString() + "]";
        }

        public static IMutilversalObjectType ___getMultiversalObectTypeFromTagType(CHtmlElementType tagType)
        {
              switch (tagType)
                {
                    case CHtmlElementType.HTML:
                        return IMutilversalObjectType.HTMLHtmlElement;
                    case CHtmlElementType.HEAD:
                        return IMutilversalObjectType.HTMLHeadElement;
                    case CHtmlElementType.BODY:
                        return IMutilversalObjectType.HTMLBodyElement;
                    case CHtmlElementType.SCRIPT:
                        return IMutilversalObjectType.HTMLScriptElement;
                    case CHtmlElementType.META:
                        return IMutilversalObjectType.HTMLMetaElement;
                    case CHtmlElementType.LINK:
                        return IMutilversalObjectType.HTMLLinkElement;
                    case CHtmlElementType.CANVAS:
                        return IMutilversalObjectType.HTMLCanvasElement;
                     case CHtmlElementType.AREA:
                        return IMutilversalObjectType.HTMLAreaElement;
                    case CHtmlElementType.APPLET:
                        return IMutilversalObjectType.HTMLAppletElement;
                    case CHtmlElementType.TABLE:
                        return IMutilversalObjectType.HTMLTableElement;
                    case CHtmlElementType.COL:
                    case CHtmlElementType.COLGROUP:
                        return IMutilversalObjectType.HTMLTableColElement;
                    case CHtmlElementType.CAPTION:
                        return IMutilversalObjectType.HTMLTableCaptionElement;
                    case CHtmlElementType.MENU:
                        return IMutilversalObjectType.HTMLMenuElement;
                    case CHtmlElementType.DIV:
                        return IMutilversalObjectType.HTMLDivElement;
                    case CHtmlElementType.P:
                        return IMutilversalObjectType.HTMLParagraphElement;
                    case CHtmlElementType.PARAM:
                        return IMutilversalObjectType.HTMLParamElement;
                    case CHtmlElementType.OBJECT:
                        return IMutilversalObjectType.HTMLObjectElement;
                    case CHtmlElementType.EMBED:
                        return IMutilversalObjectType.HTMLEmbedElement;
                    case CHtmlElementType.LI:
                        return IMutilversalObjectType.HTMLLIElement;
                    case CHtmlElementType.UL:
                        return IMutilversalObjectType.HTMLUListElement;
                    case CHtmlElementType.OL:
                        return IMutilversalObjectType.HTMLOListElement;
                    case CHtmlElementType.DL:
                        return IMutilversalObjectType.HTMLDListElement;
                    case CHtmlElementType.TR:
                        return IMutilversalObjectType.HTMLTableRowElement;
                    case CHtmlElementType.TD:
                        return IMutilversalObjectType.HTMLTableCellElement;
                    case CHtmlElementType.SVG:
                        return IMutilversalObjectType.SVGElement;
                    case CHtmlElementType._DOCUMENT_FRAGMENT:
                        return IMutilversalObjectType.DocumentFragment;
                    case CHtmlElementType.DOCTYPE:
                        return IMutilversalObjectType.CDATASection;
                    case CHtmlElementType.SPAN:
                        return IMutilversalObjectType.HTMLSpanElement;
                    case CHtmlElementType.SELECT:
                        return IMutilversalObjectType.HTMLSelectElement;
                    case CHtmlElementType.OPTION:
                        return IMutilversalObjectType.HTMLOptionElement;
                    case CHtmlElementType.FORM:
                        return IMutilversalObjectType.HTMLFormElement;
                    case CHtmlElementType.FONT:
                        return IMutilversalObjectType.HTMLFontElement;
                    case CHtmlElementType.IFRAME:
                        return IMutilversalObjectType.HTMLIFrameElement;
                    case CHtmlElementType.IMG:
                        return IMutilversalObjectType.HTMLImageElement;
                    case CHtmlElementType.FRAME:
                        return IMutilversalObjectType.HTMLFrameElement;
                    case CHtmlElementType.FRAMESET:
                        return IMutilversalObjectType.HTMLFrameSetElement;
                    case CHtmlElementType.A:
                        return IMutilversalObjectType.HTMLAnchorElement;
                    case CHtmlElementType.BASE:
                        return IMutilversalObjectType.HTMLBaseElement;
                    case CHtmlElementType.BUTTON:
                        return IMutilversalObjectType.HTMLButtonElement;
                    case CHtmlElementType.BR:
                        return IMutilversalObjectType.HTMLBRElement;
                    case CHtmlElementType.DATALIST:
                        return IMutilversalObjectType.HTMLDataListElement;
                    case CHtmlElementType.OPTGROUP:
                        return IMutilversalObjectType.HTMLOptGroupElement;
                    case CHtmlElementType.THEAD:
                    case CHtmlElementType.TBODY:
                    case CHtmlElementType.TFOOT:
                        return IMutilversalObjectType.HTMLTableSectionElement;
                  case CHtmlElementType._ITEXT:
                        return IMutilversalObjectType.Text;
                  case CHtmlElementType.TITLE:
                        return IMutilversalObjectType.HTMLTitleElement;
                  case CHtmlElementType.H1:
                  case CHtmlElementType.H2:
                  case CHtmlElementType.H3:
                  case CHtmlElementType.H4:
                  case CHtmlElementType.H5:
                  case CHtmlElementType.H6:
                        return IMutilversalObjectType.HTMLHeadingElement;
                  case CHtmlElementType.HR:
                        return IMutilversalObjectType.HTMLHRElement;
                  case CHtmlElementType.PRE:
                        return IMutilversalObjectType.HTMLPreElement;
                  case CHtmlElementType.INPUT:
                        return IMutilversalObjectType.HTMLInputElement;
                  case CHtmlElementType.NAV:
                        return IMutilversalObjectType.HTMLElement;
                  case CHtmlElementType.FIGURE:
                  case CHtmlElementType.FIGCAPTION:
                        return IMutilversalObjectType.HTMLElement;
                  case CHtmlElementType.NOSCRIPT:
                        return IMutilversalObjectType.HTMLElement;
                  case CHtmlElementType.NOBR:
                        return IMutilversalObjectType.HTMLElement;
                  case CHtmlElementType.SECTION:
                        return IMutilversalObjectType.HTMLElement;
                  case CHtmlElementType.HEADER:
                  case CHtmlElementType.FOOTER:
                        return IMutilversalObjectType.HTMLElement;
                  case CHtmlElementType.VIDEO:
                        return IMutilversalObjectType.HTMLVideoElement;
                  case CHtmlElementType.AUDIO:
                        return IMutilversalObjectType.HTMLAudioElement;
                  case CHtmlElementType.TIME:
                        return IMutilversalObjectType.HTMLUnknownElement;
                  case CHtmlElementType.SUMMARY:
                        return IMutilversalObjectType.HTMLElement;
                  case CHtmlElementType.STYLE:
                        return IMutilversalObjectType.HTMLStyleElement;
                  case CHtmlElementType.STRONG:
                  case CHtmlElementType.STRIKE:
                  case CHtmlElementType.U:
                  case CHtmlElementType.B:
                  case CHtmlElementType.I:
                  case CHtmlElementType.SMALL:
                  case CHtmlElementType.BIG:
                  case CHtmlElementType.RUBY:
                  case CHtmlElementType.RT:
                  
                  
                        return IMutilversalObjectType.HTMLElement;
                  case CHtmlElementType.TEMPLATE:
                        return IMutilversalObjectType.HTMLTemplateElement;
                  case CHtmlElementType.DETAILS:
                        return IMutilversalObjectType.HTMLDetailsElement;
                  case CHtmlElementType.TRACK:
                        return IMutilversalObjectType.HTMLTrackElement;
                  case CHtmlElementType.DT:
                  case CHtmlElementType.DD:
                        return IMutilversalObjectType.HTMLElement;

                  case CHtmlElementType.LABEL:
                        return IMutilversalObjectType.HTMLLabelElement;
                  case CHtmlElementType.MAIN:
                  case CHtmlElementType.ARTICLE:
                        return IMutilversalObjectType.HTMLElement;
                      // MINOR
                  case CHtmlElementType.MODERNIZR:
                  case CHtmlElementType.XYZ:
                        return IMutilversalObjectType.HTMLElement;


                    #region SVG Tags
                  case CHtmlElementType.ANIMATE:
                        return IMutilversalObjectType.SVGAnimateElement;
                  case CHtmlElementType.G:
                        return IMutilversalObjectType.SVGGElement;
                  case CHtmlElementType.PATH:
                        return IMutilversalObjectType.SVGPathElement;
                  case CHtmlElementType.CLIPPATH:
                        return IMutilversalObjectType.SVGClipPathElement;
                  case CHtmlElementType.IMAGE:
                        return IMutilversalObjectType.SVGImageElement;
                  case CHtmlElementType.DEFS:
                        return IMutilversalObjectType.SVGDefsElement;
                  case CHtmlElementType.LINEARGRADIENT:
                      return IMutilversalObjectType.SVGLinearGradientElement;
                  case CHtmlElementType.RADIALGRADIENT:
                      return IMutilversalObjectType.SVGRadialGradientElement;
                  case CHtmlElementType.ELLIPSE:
                      return IMutilversalObjectType.SVGEllipseElement;
                  case CHtmlElementType.STOP:
                      return IMutilversalObjectType.SVGStopElement;
                  case CHtmlElementType.POLYGON:
                      return IMutilversalObjectType.SVGPolygonElement;
                  case CHtmlElementType.POLYLINE:
                      return IMutilversalObjectType.SVGPolylineElement;
                  case CHtmlElementType.LINE:
                      return IMutilversalObjectType.SVGLineElement;
                  case CHtmlElementType.CIRCLE:
                      return IMutilversalObjectType.SVGCircleElement;
                  
                    #endregion

                }
                return IMutilversalObjectType.HTMLElement;
            
        }
        public virtual object ___getDefaultValue()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getDefaultValue {0} {1} called",this.GetType(), this);
			}
			return null;
		}
        public virtual object ___getParentScope()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getParentScope {0} {1} called",this.GetType(), this);
			}
			return null;
		}
        public virtual void ___setParentScope(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___setParentScope {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}
		public virtual  object ___getProtoType()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getProtoType {0} {1} called",this.GetType(), this);
			}
			return null;
		}
        public virtual bool ___hasInstance(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___hasInstance {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return false;
		}
        public virtual bool ___instanceEquals(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___instanceEquals {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return object.ReferenceEquals(this, ___object);
		}
        public virtual void ___setProtoType(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___setProtoType {0} {1} called : {2}",this.GetType(), this, ___object);
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
        public static CHtmlRequestData ___createSubmitDocumentFormData(CHtmlElement _element)
        {
            CHtmlRequestData _formData = new CHtmlRequestData();
            CHtmlElement _ownerFormElement = null;
            _ownerFormElement = _element.___getParentElementByTagType(CHtmlElementType.FORM);
            if (_ownerFormElement != null)
            {
                string strMethod = _ownerFormElement.method;
                _formData.fields["method"] = strMethod;
                string strAction = _ownerFormElement.action;
                _formData.fields["action"] = strAction;
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("___createSubmitDocumentFormData called for {0} with owner form {1}", _element, _ownerFormElement);
                }
                StringBuilder _inputDataBuilder = new StringBuilder();
                commonHTML.createFormPostData(_ownerFormElement, ref _inputDataBuilder);
                if (_inputDataBuilder != null && _inputDataBuilder.Length > 0)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                    {
                        commonLog.LogEntry("___createSubmitDocumentFormData Posting Data : {0}", _inputDataBuilder.ToString());
                    }
                    _formData.fields["data"] = _inputDataBuilder.ToString();

                }
                else
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                    {
                        commonLog.LogEntry("___createSubmitDocumentFormData Posting Data is empty for {0}", _element);
                    }
                }
                string _url = strAction;
                _formData.fields["Url"] = _url;
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("___createSubmitDocumentFormData Posting URL : {0}", _url);
                }
                switch (strMethod.ToUpper())
                {
                    case "POST":

                        break;
                    case "GET":
                        if (_url.IndexOf('?') > -1)
                        {
                            _url += "&" + _inputDataBuilder.ToString();
                        }
                        else
                        {
                            _url += "?" + _inputDataBuilder.ToString();
                        }
                        break;
                }


            }
            else
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("___createSubmitDocumentFormData called for {0} but no owner form found", _element);
                }
            }

            return _formData;
        }
        /// <summary>
        /// Return Value:	A Boolean that indicates whether the browser is finished loading the image or not. Returns true if the loading is finished, otherwise it returns false
        /// </summary>
        /// <returns>true or false (boolean) </returns>
        private bool ___getImageElementCompleteStatusCode()
        {

            switch (this.___elementResourceDownloadStatus)
            {
                case CHtmlHttpResourceResultStatusType.OK:
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)

                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                        {
                           commonLog.LogEntry("{0}.complete for {1} returns {2}", this.toLogString(), this.___src, "true");
                        }

                    }
                    return true;

            }
            if(this.___style != null)
            {
                if(this.___style.___IMG_ImageWeakReference != null && this.___style.___IMG_ImageWeakReference.IsAlive == true)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)

                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                        {
                           commonLog.LogEntry("{0}.complete for {1} returns {2}", this.toLogString(), this.___src, "true");
                        }

                    }
                    return true;

                }
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.complete for {1} returns {2}", this.toLogString(), this.___src , "false");
            }
            return false;
        }
        #region MetaObject
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlElement>(parameter, this);
        }
        public object GetDynamicMember(string name)
        {
            object objValue = null;
            objValue = this.___getPropertyByName(name);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.GetDynamicMember({1} returns : {2}", this.toLogString(), name, objValue);
            }
            return objValue;
        }

        public void SetDynamicMember(string name, object value)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.SetDynamicMember({1} is called value: {2}", this, name, value);
            }
            switch (name)
            {
                case "innerHTML":
                case "checked":
                case "disabled":
                case "value":
                case "id":
                case "tagName":
                case "class":
                case "classname":
                case "className":
                case "autoPlay":
                case "classId":
                case "classid":
                case "name":
                case "nodeValue":
                case "src":
                case "auto":
                case "style":
                case "styleSheet":
                case "href":
                case "charset":
                case "characterSet":
                case "dir":
                case "type":
                case "location":
                case "async":
                case "defer":
                case "contentEditable":
                case "contenteditable":
                case "alt":
                case "lang":
                case "language":
                case "title":
                case "innerText":
                case "selected":
                case "htmlFor":
                case "htmlfor":
                case "mimetype":
                case "mimeType":
                case "width":
                case "height":
                case "crossOrigin":
                case "crossorigin":
                case "textContent":
                    this.___setPropertyByName(name, value);
                    return;

            }

            this.___properties[name] = value;
        }
        public IEnumerable<string> GetDynamicMemberNames()
        {
            List<string> members = new List<string>();
            members.AddRange(CHtmlElementProperties.Keys);
            members.AddRange(CHtmlElementMethods.Keys);
            if (this.___properties.Count > 0)
            {
                members.AddRange(this.___properties.Keys);
            }
            return members;
        }
        public  DynamicMetaObject BindInvokeMember(
 InvokeMemberBinder binder, DynamicMetaObject[] args)
        {
            StringBuilder paramInfo = new StringBuilder();
            paramInfo.AppendFormat("Calling {0}(", binder.Name);
            foreach (var item in args)
                paramInfo.AppendFormat("{0}, ", item.Value);
            paramInfo.Append(")");
            Expression[] parameters = new Expression[]
            {
 Expression.Constant(paramInfo.ToString())
            };
            DynamicMetaObject methodInfo = null;
            /*
            DynamicMetaObject methodInfo = new DynamicMetaObject(
            Expression.Call(
            Expression.Convert(Expression, LimitType),
            typeof(DynamicDictionary).GetMethod("WriteMethodInfo"),
            parameters),
            BindingRestrictions.GetTypeRestriction(Expression, LimitType));
            */
            return methodInfo;
        }
        #endregion

    }
}
