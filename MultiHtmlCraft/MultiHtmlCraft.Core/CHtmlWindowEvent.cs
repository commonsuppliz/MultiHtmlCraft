using System;
using System.Drawing;
using System.Reflection;
using System.Collections;

using System.Runtime.InteropServices;
using MultiHtmlCraft.Interfaces;
using System.Collections.Generic;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// CHtmlWindowEvent is equivalent to IHTMLEventObj interface 
    /// </summary>
    [ComVisible(true)]
    
    public class CHtmlWindowEvent : CHtmlNode, ICommonObjectInterface
    {
        public static Dictionary<string, int> CHtmlWindowEventProperties = createHtmlWindowEventPropertiesList();
        public static Dictionary<string, int> CHtmlWindowEventMethods = createHtmlWindowEventMethodsList();
        internal static Dictionary<string, int> createHtmlWindowEventPropertiesList()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            list["origin"] = 0;
            list["code"] = 0;
            list["keyCode"]= 0;
            list["keycode"] = 0;
            list["altKey"] = 0;
            list["shiftKey"] = 0;
            list["ctrlKey"] = 0;
            list["metaKey"] = 0;
            list["keyChar"] = 0;
            list["wheelDeltaY"] = 0;
            list["wheelDeltaYX"] = 0;
            list["button"] = 0;
            list["activeElement"] = 0;
            list["x"] = 0;
            list["y"] = 0;
            list["X"] = 0;
            list["Y"] = 0;
            list["clientX"] = 0;
            list["clientY"] = 0;
            list["screenX"] = 0;
            list["screenY"] = 0;
            list["pageX"] = 0;
            list["pageY"] = 0;
            list["offsetX"] = 0;
            list["offsetY"] = 0;
            list["layerX"] = 0;
            list["layerY"] = 0;
            list["detail"] = 0;
            list["eventPhase"] = 0;
            list["which"] = 0;
            list["key"] = 0;

            return list;
        }
        internal static Dictionary<string, int> createHtmlWindowEventMethodsList()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            // Add method names and their indices here
            return list;
        }
        /// <summary>
        /// Due to rhino bug. we must returns event.type always.
        /// this string will be returned if it is emtry
        /// </summary>
        internal static string ___eventTypeAlternate = "___undefined";
        private DateTime ___timestamp = DateTime.Now;
        public bool ___IsCreateEventEvent = false;
        internal CHtmlEventDetail ____EventDetail = null;
        private System.WeakReference ___originWeakReference = null;
        internal bool ___isMultiversalMode = false;
        internal System.WeakReference ___ownerMultiversalWindowWeakReference = null;
        /// <summary>
        /// Flags this event is progress related event
        /// </summary>
        internal bool ___IsProgressEvent = false;

        /// <summary>
        /// IE Only mouseWheel For horizontal move
        /// </summary>
        public double ___wheelDeltaX = 0;

        public PointFSpec ___lastMouseScreenXYPoint = PointFSpec.Empty;
        private string ___codeString = null;

        public enum CHtmlWindowEventEventType : byte
        {
            none = 0,
            staticwindow = 1,
            prototype = 2,
            prototypeMouseEvent = 3,
            onetimeonly = 4,
            createevent = 5,
            onmessage = 6,
        }
        public CHtmlWindowEventEventType ___eventSourceType = CHtmlWindowEventEventType.none;
        /// <summary>
        /// Returns the scheme, hostname and port of the document that caused the onmessage event. default is null.
        /// </summary>
        public object origin
        {
            get {
                if (this.___originWeakReference != null)
                {
                    return this.___originWeakReference.Target;
                }
                else
                {
                    return null;
                }
            }
            set { this.___originWeakReference = new WeakReference(value, false); }
        }



        internal bool ___IsPreventDefaultCalled = false;

        public System.WeakReference ___ownerDocumentWeakReference = null;

        public double wheelDeltaX
        {
            get { return this.___wheelDeltaX; }
        }
        public double wheelDeltaY
        {
            get { return this.___wheelDelta; }
        }
        public void ___initMouseEventArgs(CHtmlMultiversalMouseEventArgsSpec e)
        {
            this._altKey = e.AltKey;
            this._button = e.Button;
            this._clientX = (int)Math.Round(e.X);
            this._clientY = (int)Math.Round(e.Y);
            this._ctrlKey = e.CtrlKey;
            this._offsetX = (int)e.X;
            this._offsetY = (int)e.Y;


        }
        public void ___initKeyboardEventArgs(CHtmlMultiversalKeyboardEventArgsSpec e)
        {
            this._altKey = e.AltKey;
            this._ctrlKey = e.CtrlKey;
            this._keyCode = e.KeyCode;

            this._shiftKey = e.ShiftKey;
        }
        public object prototype
        {
            get
            {
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
        }
   
        public bool hasOwnProperty(object _oname)
        {

            return true;

        }
        private bool _altKey = false;

        public bool altKey
        {
            get { return this._altKey; }
            set { this._altKey = value; }
        }
        private System.WeakReference ___activeElementWeakReference = null;
        public object activeElement
        {
            set
            {
                if (value == null)
                {
                    this.___activeElementWeakReference = null;
                }
                else
                {
                    this.___activeElementWeakReference = new WeakReference(value, false);
                }
            }
            get
            {
                if (this.___activeElementWeakReference == null)
                    return null;
                else
                    return this.___activeElementWeakReference.Target;
            }
        }

        private int _button = 0;
        public int button
        {
            get { return this._button; }
            set { this._button = value; }
        }
        internal string ___attrChange = null;
        public string attrChange
        {
            get { return commonHTML.___convertNullToEmpty(this.___attrChange); }
            set { this.___attrChange = value; }
        }
        internal bool _metaKey = false;
        /// <summary>
        /// Indicates whether the "meta" key was pressed when the event fired.
        /// Note: On the Macintosh, this is the Command key. On Microsoft Windows, this is the Windows key.
        /// </summary>
        public bool metakey
        {
            get { return this._metaKey; }
            set { this._metaKey = value; }
        }
        /// <summary>
        /// Sets or retrieves whether the current event should bubble up the hierarchy of event handlers. 
        /// </summary>
        private bool _cancelBubble = false;
        public bool cancelBubble
        {
            get { return this._cancelBubble; }
            set { this._cancelBubble = value; }
        }
        /// <summary>
        /// Sets or retrieves whether the current event should bubble up the hierarchy of event handlers. 
        /// </summary>
        private bool _bubbles = false;
        public bool bubbles
        {
            get { return this._bubbles; }
            set { this._bubbles = value; }
        }
        private bool _isChar = false;
        public bool isChar
        {
            get { return this._isChar; }
        }
        private string _keyChar = null;
        public string keyChar
        {
            get { return commonHTML.___convertNullToEmpty(this._keyChar); }
            set { this._keyChar = value; }
        }
        /// <summary>
        /// Retrieves the x-coordinate of the mouse pointer's position relative to the client area of the window, excluding window decorations and scroll bars.
        /// </summary>
        private int _clientX = 0;
        public int clientX
        {
            get { return this._clientX; }
            set { this._clientX = value; }
        }
        /// <summary>
        /// Retrieves the y-coordinate of the mouse pointer's position relative to the client area of the window, excluding window decorations and scroll bars
        /// </summary>
        private int _clientY = 0;
        public int clientY
        {
            get { return this._clientY; }
            set { this._clientY = value; }
        }
        /// <summary>
        /// Retrieves the state of the CTRL key. 
        /// </summary>
        private bool _ctrlKey = false;
        public bool ctrlKey
        {
            get { return this._ctrlKey; }
            set { this._ctrlKey = value; }
        }
        /// <summary>
        /// Retrieves the object from which activation or the mouse pointer is exiting during the event. 
        /// </summary>
        internal System.WeakReference ___fromElementWeakReference = null;
        public object fromElement
        {
            get {
                if (this.___fromElementWeakReference == null)
                {
                    return null;
                }
                else
                {
                    return this.___fromElementWeakReference.Target;
                }
            }
            set {
                if (value == null)
                {
                    this.___fromElementWeakReference = null;
                }
                else
                {
                    ___fromElementWeakReference = new WeakReference(value, false);
                }
            }
        }
        /// <summary>
        /// Retrieves the object from which activation or the mouse pointer is exiting during the event. 
        /// </summary>
        public System.WeakReference ___srcElementWeakReference = null;
        public object srcElement
        {
            get
            {
                if (this.___srcElementWeakReference == null)
                {
                    return null;
                }
                else
                {
                    return this.___srcElementWeakReference.Target;
                }
            }
            set
            {
                if (value == null)
                {
                    this.___srcElementWeakReference = null;
                }
                else
                {
                    ___srcElementWeakReference = new WeakReference(value, false);
                }
            }
        }
        public System.WeakReference ___currentTargetWeakReference = null;
        public object currentTarget
        {
            get
            {
                if (this.___currentTargetWeakReference != null)
                {
                    return this.___currentTargetWeakReference.Target;
                }
                else
                {
                    return null;
                }


            }
        }
        private int _keyCode = 0;
        public int keyCode
        {
            get { return this._keyCode; }
            set { this._keyCode = value; }
        }
        public string code
        {   
            get {
                return commonHTML.___convertNullToEmpty(this.___codeString);
            }
            set
            {
                ___codeString = value;
            }

        }
        public string key
        {
            get { return ___getKeyString(); }
            set { this.___codeString = value; }

        }
        public double ___movementX = 0;
        public double movementX
        {
            get
            {
                return ___movementX;
            }
        }
        public double movementx
        {
            get
            {
                return ___movementX;
            }
        }

        public double ___movementY = 0;
        public double movementY
        {
            get
            {
                return ___movementY;
            }
        }
        public double movementy
        {
            get
            {
                return ___movementY;
            }
        }
        private int _offsetX = 0;
        public int offsetX
        {
            get { return this._offsetX; }
            set { this._offsetX = value; }
        }
        private int _offsetY = 0;
        public int offsetY
        {
            get { return this._offsetY; }
            set { this._offsetY = value; }
        }
        internal string _qualifier = null;
        public string qualifier
        {
            get { return commonHTML.___convertNullToEmpty(this._qualifier); }
            set { this._qualifier = value; }
        }
        /// <summary>
        /// Retrieves the result of the data transfer for a data source object. 
        /// 0 = Data Transmitted successfully
        /// 1 = Data transfer aborted
        /// 2 = Data transferred in error
        /// </summary>
        private int _reason = 0;
        public int reason
        {
            get { return this._reason; }
            set { this._reason = value; }
        }
        private int _screenX = 0;
        public int screenX
        {
            get { return this._screenX; }
            set { this._screenX = value; }
        }
        private int _screenY = 0;
        public int screenY
        {
            get { return this._screenY; }
            set { this._screenY = value; }
        }
        public int pageY
        {
            get { return this._screenY; }
        }
        public int pageX
        {
            get { return this._screenX; }
        }
        /// <summary>
        /// Retrieves whether the onkeydown event is being repeated. 
        /// </summary>
        private int _repeat = 0;
        public int repeat
        {
            get { return this._repeat; }
            set { this._repeat = value; }
        }

        private bool _shiftKey = false;

 
        public bool shiftKey
        {
            get { return this._shiftKey; }
            set { this._shiftKey = value; }
        }




        public object target
        {
            get
            {
                if (this.___srcElementWeakReference != null)
                {
                    return this.___srcElementWeakReference.Target;
                }
                else
                {
                    switch (this._type)
                    {
                        case "mousemove":

                            break;
                    }
                    return null;
                }
            }
        }
        private object ____GetOwnerDocument()
        {
            if (this.___ownerDocumentWeakReference != null)
            {
                return this.___ownerDocumentWeakReference.Target as CHtmlDocument;
            }
            return null;
        }
        /// <summary>
        /// Retrieves a reference to the object toward which the user is moving the mouse pointer.
        /// </summary>
        public System.WeakReference ___toElementWeakReference = null;
        public object toElement
        {
            get
            {
                if (this.___toElementWeakReference == null)
                {
                    return null;
                }
                else
                {
                    return this.___toElementWeakReference.Target;
                }
            }
            set
            {
                if (value == null)
                {
                    this.___toElementWeakReference = null;
                }
                else
                {
                    this.___toElementWeakReference = new WeakReference(value, false);
                }
            }
        }

        /// <summary>
        /// Element ___hasInner prior targeted of the event such as onmouseout, onmouseleave
        /// Same as toElement
        /// </summary>
        public object relatedTarget
        {
            get { return this.toElement; }
        }
        private string __EventTitle = null;
        public string EventTitle
        {
            get { return commonHTML.___convertNullToEmpty(this.__EventTitle); }
            set { this.__EventTitle = value; }
        }


        /// <summary>
        /// Sets or retrieves a Boolean value that indicates whether the current event is canceled. IE Spec
        /// </summary>
        public bool returnValue
        {
            get { return this.___IsPreventDefaultCalled; }

        }
        private bool _cancelable = true;
        /// <summary>
        /// This event is cancelable
        /// </summary>
        public bool cancelable
        {
            get { return this._cancelable; }
        }



        /// <summary>
        /// Sets or retrieves the event name from the event object
        /// </summary>
        private string _type = null;
        /// <summary>
        /// Retrieves a string that represents the type of the event, such as "mouseout", "click", etc.       
        /// if(event.type == "mouseover") 
        /// 
        /// </summary>
        public string type
        {
            get {
                if (string.IsNullOrEmpty(this._type) == false)
                {
                    return this._type;
                }
                else
                {
                    return CHtmlWindowEvent.___eventTypeAlternate;
                }
            }


            set {
                if (commonLog.LoggingEnabled)
                {
                   commonLog.LogEntry("event.type set is not allowd use ___setEventType(). it will be ignored.");
                }
            }

        }
        public void ___set_event_type(string s)
        {
            if (s != null)
            {
                this._type = s;
            }
        }
        private int ___wheelDelta = 0;
        public int wheelDelta
        {
            get { return this.___wheelDelta; }
            set { this.___wheelDelta = value; }
        }
        internal System.WeakReference ___sourceObjectWeakReference = null;
        /// <summary>
        /// returns original object
        /// 
        /// </summary>
		public object soucre
        {
            get {
                if (this.___sourceObjectWeakReference != null && this.___sourceObjectWeakReference.IsAlive == true)
                {
                    return this.___sourceObjectWeakReference.Target;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Returns the Unicode character or key code of the key or the identifier of the mouse button that was pressed when the current event fired.
        /// </summary>
        public int which
        {
            get { return this._keyCode; }
        }

        public int charCode
        {
            get { return this._keyCode; }
        }
        private string _attrName = null;
        public string attrName
        {
            get { return commonHTML.___convertNullToEmpty(this._attrName); }
            set { this._attrName = value; }
        }
        private string _domain = null;
        public string domain
        {
            get { return commonHTML.___convertNullToEmpty(this._domain); }
        }
        public bool defaultPrevented
        {
            get { return this.___IsPreventDefaultCalled; }
        }

        public CHtmlCollection bookmarks
        {
            get {
                CHtmlCollection arBookMarks = new CHtmlCollection();
                arBookMarks.___CollectionType = CHtmlHTMLCollectionType.EventObjectBookmarkList;
                return arBookMarks;
            }
        }
        public CHtmlCollection touches
        {
            get
            {
                return ___CreateTouchListForEvent(CHtmlHTMLCollectionType.EventTouchesList, true);
            }
        }
        public CHtmlCollection changedTouches
        {
            get
            {
                return ___CreateTouchListForEvent(CHtmlHTMLCollectionType.EventChangedTouchesList, true);
            }
        }
        public CHtmlCollection targetTouches
        {
            get
            {
                return ___CreateTouchListForEvent(CHtmlHTMLCollectionType.EventTargeTouchesList, true);
            }
        }
        internal System.WeakReference ___relatedNodeWeakReference = null;
        /// <summary>
        /// Node which ___hasInner been removedNodes or created. default is null;
        /// </summary>
        public object relatedNode
        {
            get
            {
                if (this.___relatedNodeWeakReference == null)
                {
                    return null;
                }
                else
                {
                    return this.___relatedNodeWeakReference.Target;
                }
            }
        }

        private int _detail = 0;

        public int detail
        {
            get { return this._detail; }
        }
        private int _eventPhase = 2;
        /// <summary>
        /// Used to indicate which phase of event flow is currently being evaluated.
        /// 1 = caputuring phase
        /// 2 = At Target
        /// 3 = BUBBLING_PHASE
        /// </summary>
        public int eventPhase
        {
            get { return this._eventPhase; }
            set { this._eventPhase = value; }
        }
        /// <summary>
        /// string for event.data for onmessage
        /// </summary>
        internal string ___eventData = null;
        /// <summary>
        /// Returns the characters entered in case of the textInput event or the contents of the message for the onmessage event.
        /// default is "";
        /// </summary>
        public string data
        {
            get {
                return commonHTML.___convertNullToEmpty(this.___eventData);
            }
        }
        private string _dataFld = null;
        /// <summary>
        /// Sets or returns the name of the modified data column in case of the oncellchange event.
        /// </summary>
        public string dataFld
        {
            get { return commonHTML.___convertNullToEmpty(this._dataFld); }
        }
        public object _dataTransfer = null;
        public object dataTransfer
        {
            get { return this._dataTransfer; }
        }

        private int _x = 0;
        public int x
        {
            get { return this._x; }
            set { this._x = value; }
        }
        private int _y = 0;
        public int y
        {
            get { return this._y; }
            set { this._y = value; }
        }
        private int _layerX = -1;
        public int layerX
        {
            get { return this._layerX; }
        }
        private int _layerY = -1;
        public int layerY
        {
            get { return this._layerY; }
        }


        private string _region = null;
        public string region
        {
            get { return commonHTML.___convertNullToEmpty(this._region); }
        }

        public CHtmlWindowEvent()
        {
            // 
            // 
            //
        }
        public override string ToString()
        {
            if (this.___IsPrototype == false)
            {
                return string.Format("EventObject : {0} {1}  srcElement : {1} ", this._type, this.___eventSourceType, this.srcElement);
            }
            else
            {
                return string.Format("EventObject Prototype : {0} {1} {2}", this._type, this.srcElement, this.toElement);
            }
        }
        public string toString()
        {
            return this.ToString();
        }
        #region IPropertBox ƒƒ“ƒo

        public void ___setPropertyByName(string ___name, object val)
        {
            CHtmlElement ___elem = null;
            if (this.___srcElementWeakReference != null)
            {
                ___elem = this.___srcElementWeakReference.Target as CHtmlElement;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 15)
            {
               commonLog.LogEntry("calling EventObject set : {0} for {1}", ___name, this);
            }
            try
            {
                switch (___name)
                {
                    case "layerX":
                    case "layerx":
                        if (___elem != null)
                        {
                            ___elem.layerX = (float)commonData.GetDoubleFromObject(val, 0);
                        }
                        return;

                    case "layerY":
                    case "layery":
                        if (___elem != null)
                        {
                            ___elem.layerY = (float)commonData.GetDoubleFromObject(val, 0);
                        }
                        return;

                    case "pageX":
                    case "pagex":
                        if (___elem != null)
                        {
                            ___elem.___offfsetParentPoint.X = (float)commonData.GetDoubleFromObject(val, 0);
                        }
                        break;
                    case "pageY":
                    case "pagey":
                        if (___elem != null)
                        {
                            ___elem.___offfsetParentPoint.Y = (float)commonData.GetDoubleFromObject(val, 0);
                        }
                        return;
                    case "offsetX":
                    case "offsetx":
                        if (___elem != null)
                        {
                            ___elem.___offsetLeft = (float)commonData.GetDoubleFromObject(val, 0);
                        }
                        return;
                    case "offsetY":
                    case "offsety":
                        if (___elem != null)
                        {
                            ___elem.___offsetTop = (float)commonData.GetDoubleFromObject(val, 0);
                        }
                        return;
                    case "returnValue":
                        if (val != null)
                        {
                            this.___IsPreventDefaultCalled = commonData.convertObjectToBoolean(val);
                        }
                        return;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("EventObject Set Error", ex);
                }
            }

        }

        public bool ___hasPropertyByName(string ___name)
        {
            return true;

        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }

        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getInner : {0} for {1}", ___name, this);
            }


            switch (___name)
            {
                case "__noSuchMethod__":
                    return null;
                case "__iterator__":
                    return null;
                case "target":
                    return this.target;
                case "relatedNode":
                    return this.relatedNode;
                case "srcelement":
                case "srcElement":
                    return this.srcElement;
                case "toelement":
                case "toElement":
                    return this.toElement;
                case "fromelement":
                case "fromElement":
                    return this.fromElement;
                case "type":
                    return this.type;
                case "reason":
                    return this.reason;
                case "altkey":
                case "altKey":
                    return this.altKey;
                case "domain":
                    return this.domain;
                case "charcode":
                case "charCode":
                    return (double)this._keyCode;
                case "repeat":
                    return this.repeat;
                case "returnValue":
                case "returnvalue":
                    return this.___IsPreventDefaultCalled;
                case "which":
                    return this.which;
                case "activeelement":
                case "activeElement":
                    return this.activeElement;
                case "keychar":
                case "keyChar":
                    return this._keyChar;
                case "keycode":
                case "keyCode":

                    return (double)this._keyCode;
                case "key":
                    return ___getKeyString();
                case "wheeldelta":
                case "wheelDelta":
                    return this.___wheelDelta;
                case "wheelDeltaY":
                    return this.___wheelDelta; // same as wheelDelta (Y-Axis move)
                case "wheelDeltaX":
                    return this.___wheelDeltaX;
                case "detail":
                    return this._detail;
                case "data":
                    return this.data;
                case "datatransfer":
                case "dataTransfer":
                    return this._dataTransfer;
                case "datafld":
                case "dataFld":
                    return this._dataFld;
                case "offsetx":
                case "offsetX":
                    return this._offsetX;
                case "offsety":
                case "offsetY":
                    return this._offsetY;
                case "pagex":
                case "pageX":
                    return this._screenX;
                case "pagey":
                case "pageY":
                    return this._screenY;
                case "x":
                case "X":
                    return this._x;
                case "y":
                case "Y":
                    return this._y;
                case "shiftkey":
                case "shiftKey":
                    return this.shiftKey;
                case "clientx":
                case "clientX":
                    return this._clientX;
                case "clienty":
                case "clientY":
                    return this._clientY;
                case "screenx":
                case "screenX":
                    return this._screenX;
                case "screeny":
                case "screenY":
                    return this._screenY;
                case "button":
                    return this._button;
                case "timestamp":
                case "timeStamp":
                    return this.___timestamp;
                case "bubbles":
                    return this._bubbles;
                case "cancelbubble":
                case "cancelBubble":
                    return this._cancelBubble;
                case "ischar":
                case "isChar":
                    return this._isChar;
                case "cancelable":
                    return this._cancelable;
                case "eventphase":
                case "eventPhase":
                    return this._eventPhase;
                case "currenttarget":
                case "currentTarget":
                    return this.currentTarget;
                case "ctlkey":
                case "ctrlkey":
                case "ctrlKey":
                case "Ctrlkey":
                    return this._ctrlKey;
                case "attrname":
                case "attrName":
                case "Attrname":
                    return this._attrName;
                case "relatedtarget":
                case "relatedTarget":
                    return this.relatedTarget;
                case "qualifier":
                    return this._qualifier;
                case "eventtitle":
                case "eventTitle":
                    return this.__EventTitle;
                case "source":
                case "soucre":
                    return this.soucre;
                case "bookmarks":
                    return this.bookmarks;
                case "region":
                    return this._region;
                case "layerx":
                case "layerX":
                    return this._layerX;
                case "layery":
                case "layerY":
                    return this._layerY;
                case "metakey":
                case "metaKey":
                    return this._metaKey;
                case "attrchange":
                case "attrChange":
                    return this.___attrChange;
                case "movementx":
                case "movementX":
                case "mozMovementX":
                case "webkitMovementX":
                    return this.___movementX;
                case "movementY":
                case "movementy":
                case "mozMovementY":
                case "webkitMovementY":
                    return this.___movementY;

                case "origin":
                    return this.origin;
                case "defaultPrevented":
                    return this.___IsPreventDefaultCalled;

                case "view":
                    if (this.___isMultiversalMode == true)
                    {
                        if (this.___ownerMultiversalWindowWeakReference != null)
                        {
                            return this.___ownerMultiversalWindowWeakReference.Target;
                        }
                    }
                    return "self";// returns window
                // <!--                html5 touch related data  
                // http://stackoverflow.com/questions/6760430/difference-between-touches-and-targettouches
                // 
                case "touches":
                    return ___CreateTouchListForEvent(CHtmlHTMLCollectionType.EventTouchesList, true);
                case "targettouches":
                case "targetTouches":
                    return ___CreateTouchListForEvent(CHtmlHTMLCollectionType.EventTargeTouchesList, true);
                case "changedtouches":
                case "changedTouches":
                    return ___CreateTouchListForEvent(CHtmlHTMLCollectionType.EventChangedTouchesList, true);
                // -->
                case "prototype":
                case "__proto__":
                    return this.prototype;
                default:
                    if (this.___IsProgressEvent == true)
                    {
                        switch (___name)
                        {
                            case "loaded":
                            case "total":
                                if (this.___srcElementWeakReference != null)
                                {
                                    if (this.___srcElementWeakReference.Target is CHtmlMediaElement)
                                    {
                                        CHtmlMediaElement __mediaElement = this.___srcElementWeakReference.Target as CHtmlMediaElement;
                                        if (string.Equals(___name, "loaded", StringComparison.Ordinal) == true)
                                        {
                                            return __mediaElement.___rawMediaFileByteLoadedLength;
                                        }
                                        else if (string.Equals(___name, "total", StringComparison.Ordinal) == true)
                                        {
                                            return __mediaElement.___rawMediaFileByteTotalLength;
                                        }
                                    }
                                }
                                return 0;
                            case "lengthComputable":
                                return true;
                        }
                    }
                    break;
            }

            // =================================================================
            // Prototype Search.
            // =================================================================
            if (this.___IsPrototype == false && this.___prototypeWeakReference != null)
            {
                CHtmlWindowEvent ___protoEvent = this.___prototypeWeakReference.Target as CHtmlWindowEvent;
                if (___protoEvent != null)
                {
                    object ___protoObject;
                    if (___protoEvent.___properties.TryGetValue(___name, out ___protoObject))
                    {
                        return ___protoObject;
                    }
                }
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("GetPropertyValue for {0} \'{1}\' {2} failed", this.GetType(), this, ___name);
            }
            return null;
        }
        private CHtmlCollection ___CreateTouchListForEvent(CHtmlHTMLCollectionType collectionType, bool AddAdhocTouch)
        {
            CHtmlCollection touchList = new CHtmlCollection();
            touchList.___CollectionType = collectionType;
            if (AddAdhocTouch == true)
            {
                CHtmlTouch adhocTouch = new CHtmlTouch();
                adhocTouch.___clientX = this.clientX;
                adhocTouch.___clientY = this.clientY;
                adhocTouch.___force = 1;
                adhocTouch.___pageX = this.pageX;
                adhocTouch.___pageY = this.pageY;
                adhocTouch.___radiusX = 0;
                adhocTouch.___radiusY = 0;
                adhocTouch.___ratationAngle = 0;
                adhocTouch.___screenX = this.screenX;
                adhocTouch.___screenY = this.screenY;
                adhocTouch.___target = this.target;
                touchList.Add(adhocTouch);
            }
            return touchList;
        }
        public object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        /// <summary>
        /// create key string for 'key' property
        /// refer to https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent/keyCode
        /// refer to https://www.w3.org/TR/DOM-Level-3-Events/#keys
        /// </summary>
        /// <returns></returns>
        private string ___getKeyString()
        {
            switch((byte)this._keyCode)
            {
                case 0x08:
                    return "Backspace";
                case 0x0D:
                    return "Enter";

                case 0x20:
                    return "Spacebar";
                case 0x5D:
                    return "ContextMenu";
                case 0x09:
                    return "Tab";
                case 0x2E:
                    return "Delete";
                case 0x23:
                    return "End";
                case 0x2D:
                    return "Insert";
                case 0x24:
                    return "Home";
                case 0x22:
                    return "PageDown";
                case 0x21:
                    return "PageUp";
                case 0x28:
                    return "ArrowDown";
                case 0x27:
                    return "ArrowRight";
                case 0x26:
                    return "ArrowUp";
                case 0x25:
                    return "ArrowLeft";
                case 0x1B:
                    return "Escape";
                case 0x2C:
                    return "PrintScreen";
                case 0x91:
                    return "ScrollLock";
                case 0x13:
                    return "Pause";
                case 0x11:
                    return "Control";
                case 0x14:
                    return "CapsLock";
                case 0x10:
                    return "Shift";
                case 0x70:
                    return "F1";
                case 0x71:
                    return "F2";
                case 0x72:
                    return "F3";
                case 0x73:
                    return "F4";
                case 0x74:
                    return "F5";
                case 0x75:
                    return "F6";
                case 0x76:
                    return "F7";
                case 0x77:
                    return "F8";
                case 0x78:
                    return "F9";
                case 0x79:
                    return "F10";
                case 0x7A:
                    return "F11";
                case 0x7B:
                    return "F12";
                case 0x7C:
                    return "F13";
                case 0x7D:
                    return "F14";
                case 0x7E:
                    return "F15";

            }
            return this._keyChar;
        }
		public void ___deleteByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}",this.GetType(), this, ___index);
			}
		}
		public void ___deleteByName(string ___name)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByName {0} {1} called : {2}",this.GetType(), this, ___name);
			}

		}
		public object[] ___getByIds()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getByIds() {0} {1} called",this.GetType(), this);
			}
				return null;

		}
		public string ___getClassName()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getClassName {0} {1} called",this.GetType(), this);
			}
			return this.GetType().Name;
		}
		public object ___getDefaultValue()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getDefaultValue {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public object ___getParentScope()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getParentScope {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public void ___setParentScope(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___setParentScope {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}
		public object ___getProtoType()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getProtoType {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public bool ___hasInstance(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___hasInstance {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return false;
		}
		public bool ___instanceEquals(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___instanceEquals {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return object.ReferenceEquals(this, ___object);
		}
		public void ___setProtoType(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___setProtoType {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}
			#endregion

        public void initMouseEvent(object __evtNameOject, bool p1, bool p2, object p3, int p4, int p5, int p6, int p7, int p8, bool p9, bool p10, bool p11, bool p12, int p13, object p14)
        {
            // initMouseEvent("click", true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null)
            this._type = commonHTML.GetStringValue(__evtNameOject);
        }

		public void initEvent(string __evtName, bool p1, bool p2)
		{
			this._type = __evtName;
		}
        /// <summary>
        /// Initializes the event in a manner analogous to the similarly-named method in the DOM Events interfaces.
        /// </summary>
        public void initCustomEvent(object __type, object  __canBubble,object  __cancelable,object __detail)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry(" {0} {1} initCustomEvent({2}, {3}, {4}, {5})", this.GetType(), this, __type, __canBubble, __cancelable, __detail);
            }
            this._type = commonHTML.GetStringValue(_type);
            if (__canBubble != null)
            {
                this._cancelable = commonData.convertObjectToBoolean(__canBubble);
            }
            if (__cancelable != null)
            {
                this._cancelable = commonData.convertObjectToBoolean(__cancelable);
            }
            if (__detail != null)
            {
                this._detail = (int)commonData.GetDoubleFromObject(__detail, 0);
            }
        }
        /// <summary>
        /// Prevents other listeners of the same event from being called.
        /// </summary>
        public void stopImmediatePropagation()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling stopImmediatePropagation() for {0}", this);
            }

        }
        
		public void stopPropagation()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("calling stopPropagation() for {0}",   this);
			}
		}
		public void preventDefault()
		{
            this.___preventDefaultInner(null);
		}
        public void preventDefault(object ___object)
        {
            this.___preventDefaultInner(___object);
        }
        private void ___preventDefaultInner(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("preventDefault() for {0}", this);
            }
            this.___IsPreventDefaultCalled = true;
        }

        /* Event.observe is function from prototype.js comment out */
        
        /*
        /// <summary>
        /// window.Event.observe() functionality
        /// </summary>
        /// <param name="_taragetObject">targetObject. ex window. document etc.</param>
        /// <param name="_nameObject">name of event</param>
        /// <param name="_objFunction">function to process</param>
        /// <param name="_objBubbleUp">optional bubble up</param>
        public void observe(object _taragetObject, object _nameObject, object _objFunction, object _objBubbleUp)
        {

        }
        /// <summary>
        /// window.Event.observe() functionality
        /// </summary>
        /// <param name="_taragetObject">targetObject. ex window. document etc.</param>
        /// <param name="_nameObject">name of event</param>
        /// <param name="_objFunction">function to process</param>
        /// <param name="_objBubbleUp">optional bubble up</param>
        public void observe(object _taragetObject, object _nameObject, object _objFunction)
        {

        }
        */
        public void ___copyWindowEventValuesFromWindowEvent(CHtmlWindowEvent ___newEvent)
        {
            this.__EventTitle = ___newEvent.__EventTitle;
            this._type = ___newEvent._type;
            this._offsetX = ___newEvent._offsetX;
            this._offsetY = ___newEvent._offsetY;
            this._screenX = ___newEvent._screenX;
            this._screenY = ___newEvent._screenY;
            this._clientX = ___newEvent._clientX;
            this._clientY = ___newEvent._clientY;
            this._keyCode = ___newEvent._keyCode;
            this._keyChar = ___newEvent._keyChar;
            if (___newEvent.___srcElementWeakReference != null)
            {
                this.___srcElementWeakReference = ___newEvent.___srcElementWeakReference;
            }
            if (___newEvent.___toElementWeakReference != null)
            {
                this.___toElementWeakReference = ___newEvent.___toElementWeakReference;
            }
            if (___newEvent.___activeElementWeakReference != null)
            {
                this.___activeElementWeakReference = ___newEvent.___activeElementWeakReference;
            }
            if (string.IsNullOrEmpty(___newEvent.___eventData) == false)
            {
                this.___eventData = string.Copy(___newEvent.___eventData);
            }
            if (___newEvent.___currentTargetWeakReference != null)
            {
                this.___currentTargetWeakReference = ___newEvent.___currentTargetWeakReference;
            }
            this.___IsProgressEvent = ___newEvent.___IsProgressEvent;
        }
        public void ___resetToDefaults()
        {
            this.___IsProgressEvent = false;
            this._isChar = false;
            this._altKey = false;
            this._button = -1;
            this._cancelBubble = false;
            this._clientX = 0;
            this._clientY = 0;
            this._ctrlKey = false;
            this.___fromElementWeakReference  = null;
            this._keyCode = 0;
            this._offsetX = 0;
            this._offsetY = 0;
            this._qualifier = null;
            this._reason = 0;
            this.___IsPreventDefaultCalled = false;
            this._screenX = 0;
            this._screenY = 0;
            this._shiftKey = false;
            
            this.___srcElementWeakReference  = null;
            this.___toElementWeakReference = null;
            this.___activeElementWeakReference  = null;
            this._type = null;
            this._x = 0;
            this._y = 0;
            this._repeat = 0;
            this.___originWeakReference = null;
            this.___fromElementWeakReference = null;
            this.___eventData = null;
            this.____EventDetail = null;
            this.___relatedNodeWeakReference  = null;
            this._keyChar = null;
            this.___codeString = null;
            this.key = null;
            this.keyChar = null;
            
        }

        public new IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.Event;
            }
        }
	
	}
}
