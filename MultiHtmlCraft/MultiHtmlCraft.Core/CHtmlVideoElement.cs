
using MultiHtmlCraft.Interfaces;
using System;
using System.Collections;
using System.Dynamic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using MultiHtmlCraft.Core;
using System.Security.Cryptography;
using ManagedBass;
using System.Collections.Generic;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// CHtmlMediaElement 
    /// </summary>
    public class CHtmlVideoElement:  CHtmlMediaElement,  System.IDisposable, IDynamicMetaObjectProvider
    {

        public static Dictionary<string, int> CHtmlVideoElementProperties = createCHtmlVideoElementProperties();
        public static Dictionary<string, int> CHtmlVideoElementMethods = createCHtmlVideoElementMethods();
        private static Dictionary<string, int> createCHtmlVideoElementProperties()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            list["prototype"] = 0;
            list["disablePictureInPicture"] = 0;
            list["height"] = 1;
            list["poster"] = 2;
            list["videoHeight"] = 3;
            list["videoWidth"] = 4;
            list["width"] = 5;
            
            return list;

        }
        private static Dictionary<string, int> createCHtmlVideoElementMethods()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            list["cancelVideoFrameCallback"] = 0;
            list["requestPictureInPicture"] = 1;
            list["getVideoPlaybackQuality"] = 2;
            list["requestVideoFrameCallback"] = 3;
            return list;

        }
        public CHtmlVideoElement(): base()
        {
            if(commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"{this}.ctr is called");
            }
            base.tagName = "VIDEO";
            this.___multiversalClassType = IMutilversalObjectType.HTMLVideoElement;
        }
        

        public CHtmlVideoElement(string strTagName, string strTagType) : base()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"{this}.ctr is called with params");
            }
            base.tagName = strTagName;
            this.___multiversalClassType = IMutilversalObjectType.HTMLVideoElement;



        }



        public double requestVideoFrameCallback(object callback)
        {
            if(commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"TODO {this},requestVideoFrameCallBack is called with {callback}");
            }
            return 0; 
        }

        public void requestPictureInPicture()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"TODO {this},requsstPictureInPicture is called");
            }

        }
        public object getVideoPlaybackQuality()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"TODO {this},getVideoPlaybackQuality is called");
            }
            return null;
        }
        public object cancelVideoFrameCallback(object objid)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"TODO {this},cancelVideoFrameCallBack is called");
            }
            return null;
        }





        public new void Dispose()
        {
            this.___cleanUp();
            base.Dispose();
            GC.SuppressFinalize(this);
        }
        private void ___cleanUp()
        {
            try
            {
                if (this.___ManagedMediaControlWeakReference2 != null)
                {

                    object objRef2 = this.___ManagedMediaControlWeakReference2.Target;
                    if (objRef2 != null)
                    {
                       commonData.DisposeObject(objRef2);
                    }

                    this.___ManagedMediaControlWeakReference2 = null;
                }
                if (this.___ManagedMediaControlWeakReference1 != null)
                {

                    object objRef1 = this.___ManagedMediaControlWeakReference1.Target;
                    if (objRef1 != null)
                    {
                        try
                        {
                            ___hostElementChildPropertyMethodInfo.SetValue(objRef1, null, null);
                        }
                        catch { }
                       commonData.DisposeObject(objRef1);
                    }

                    this.___ManagedMediaControlWeakReference1 = null;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("MediaElement Dispose", ex);
                }
            }
        }
        /* DO NOT USE addEventListener to override. Rhino will ignore those functions.
   
        public new void addEventListener(string __Name, object ___function, object boolObj)
        {
            ___RegisterMediaElementEventListner(__Name, ___function);
            base.addEventListener(__Name, ___function, boolObj);
        }
   
        public new void addEventListener(string __Name, object ___function, bool ___bool)
        {
            ___RegisterMediaElementEventListner(__Name, ___function);
            base.addEventListener(__Name, ___function, ___bool);
        }
   
        public new void addEventListener(string __Name, object ___function)
        {
            ___RegisterMediaElementEventListner(__Name, ___function);
            base.addEventListener(__Name, ___function);
        }
         * */














        #region Methods



        // クリーンアップ処理

     
   


    
   
        public object onloadeddata
        {
            get
            {
                return base.___getEventInfo("onloadeddata");
            }
            set
            {
                base.___addEventListenerInner("onloadeddata", value, false);
            }
        }
   
        public object onloadedmetadata
        {
            get
            {
                return base.___getEventInfo("onloadedmetadata");
            }
            set
            {
                base.___addEventListenerInner("onloadedmetadata", value, false);
            }
        }
   
        public object onloadstart
        {
            get
            {
                return base.___getEventInfo("onloadstart");
            }
            set
            {
                base.___addEventListenerInner("onloadstart", value, false);
            }
        }
   
        public object onpause
        {
            get
            {
                return base.___getEventInfo("onpause");
            }
            set
            {
                base.___addEventListenerInner("onpause", value, false);
            }
        }
   
        public object onsuspend
        {
            get
            {
                return base.___getEventInfo("onsuspend");
            }
            set
            {
                base.___addEventListenerInner("onsuspend", value, false);
            }
        }
   
        public object onplay
        {
            get
            {
                return base.___getEventInfo("onplay");
            }
            set
            {
                base.___addEventListenerInner("onplay", value, false);
            }
        }
   
        public object onvolumechange
        {
            get
            {
                return base.___getEventInfo("onvolumechange");
            }
            set
            {
                base.___addEventListenerInner("onvolumechange", value, false);
            }
        }
   
        public object ondurationchange
        {
            get
            {
                return base.___getEventInfo("ondurationchange");
            }
            set
            {
                base.___addEventListenerInner("ondurationchange", value, false);
            }
        }
   
        public object onended
        {
            get
            {
                return base.___getEventInfo("onended");
            }
            set
            {
                base.___addEventListenerInner("onended", value, false);
            }
        }
   
        public object ontoggle
        {
            get
            {
                return base.___getEventInfo("ontoggle");
            }
            set
            {
                base.___addEventListenerInner("ontoggle", value, false);
            }
        }
   
        public object onplaying
        {
            get
            {
                return base.___getEventInfo("onplaying");
            }
            set
            {
                base.___addEventListenerInner("onplaying", value, false);
            }
        }
   
        public object onreset
        {
            get
            {
                return base.___getEventInfo("onreset");
            }
            set
            {
                base.___addEventListenerInner("onreset", value, false);
            }
        }
   
        public object onprogress
        {
            get
            {
                return base.___getEventInfo("onprogress");
            }
            set
            {
                base.___addEventListenerInner("onprogress", value, false);
            }
        }
   
        public object onwaiting
        {
            get
            {
                return base.___getEventInfo("onwaiting");
            }
            set
            {
                base.___addEventListenerInner("onwaiting", value, false);
            }
        }
   
        public object onratechange
        {
            get
            {
                return base.___getEventInfo("onratechange");
            }
            set
            {
                base.___addEventListenerInner("onratechange", value, false);
            }
        }
   
        public object onshow
        {
            get
            {
                return base.___getEventInfo("onshow");
            }
            set
            {
                base.___addEventListenerInner("onshow", value, false);
            }
        }
   
        public object onsort
        {
            get
            {
                return base.___getEventInfo("onsort");
            }
            set
            {
                base.___addEventListenerInner("onsort", value, false);
            }
        }
   
        public object onseeked
        {
            get
            {
                return base.___getEventInfo("onseeked");
            }
            set
            {
                base.___addEventListenerInner("onseeked", value, false);
            }
        }
   
        public object onseeking
        {
            get
            {
                return base.___getEventInfo("onseeking");
            }
            set
            {
                base.___addEventListenerInner("onseeking", value, false);
            }
        }
   
        public object ontimeupdate
        {
            get
            {
                return base.___getEventInfo("ontimeupdate");
            }
            set
            {
                base.___addEventListenerInner("ontimeupdate", value, false);
            }
        }
   
        public object oncanplay
        {
            get
            {
                return base.___getEventInfo("oncanplay");
            }
            set
            {
                base.___addEventListenerInner("oncanplay", value, false);
            }
        }
   
        public object oncanplaythrough
        {
            get
            {
                return base.___getEventInfo("oncanplaythrough");
            }
            set
            {
                base.___addEventListenerInner("oncanplaythrough", value, false);
            }
        }
        //public void addTrack("descriptions", "Descriptions - en", "en")
        public void addTrack(string _desc1, string _desc2, string _lang3)
        {
        }
        public bool canPlayTime(string ___type)
        {
            return true;
        }
        /// <summary>
        /// Video and Audio Tag Methods
        /// </summary>
        /// <param name="__type">Type</param>
        /// <returns>maybe, probably , ""</returns>
        public string canPlayType(object __mediatype)
        {
            string __resultValue = null;
            string _mimeType = null;
            string _codecType = null;
            if(___hostLibraryLoadStatus == CHtmlAssemblyLoadStatusType.Uninitalized)
            {
                ___initMediaElementControlInterface();
            }

            if (this.___elementTagType != CHtmlElementType.VIDEO && this.___elementTagType != CHtmlElementType.AUDIO)
            {
                
                __resultValue = "";
            }
            else
            {
                string _typeStr = commonHTML.GetStringValue(__mediatype);

                int ___pos = -1;
                if (string.IsNullOrEmpty(_typeStr) == false)
                {
                    ___pos = _typeStr.IndexOf(';');
                    if (___pos == -1)
                    {
                        _mimeType = _typeStr;
                        if (string.IsNullOrEmpty(_mimeType) == false && (commonHTML.FasterIsWhiteSpaceLimited(_mimeType[0]) == true || commonHTML.FasterIsWhiteSpaceLimited(_mimeType[_mimeType.Length - 1]) == true))
                        {
                            _mimeType = _mimeType.Trim();
                        }
                    }
                    else
                    {
                        _mimeType = _typeStr.Substring(0, ___pos);
                        if (string.IsNullOrEmpty(_mimeType) == false && (commonHTML.FasterIsWhiteSpaceLimited(_mimeType[0]) == true || commonHTML.FasterIsWhiteSpaceLimited(_mimeType[_mimeType.Length - 1]) == true))
                        {
                            _mimeType = _mimeType.Trim();
                        }
                        _codecType = _typeStr.Substring(___pos + 1);
                        if (string.IsNullOrEmpty(_codecType) == false && (commonHTML.FasterIsWhiteSpaceLimited(_codecType[0]) == true || commonHTML.FasterIsWhiteSpaceLimited(_codecType[_codecType.Length - 1]) == true))
                        {
                            _codecType = _codecType.Trim();
                        }
                        if (_codecType.Length != 0)
                        {
                            int cPos = _codecType.IndexOf('=');
                            // remove 'codec='
                            if (cPos >= 1)
                            {
                                _codecType = _codecType.Substring(cPos + 1);
                            }
                        }
                    }
                }
                switch (_mimeType)
                {
                    case "video/ogg":
                        if (CHtmlMediaElement.___isVideo_Ogg_supported)
                        {
                            __resultValue = "probably";
                        }
                        else
                        {
                            __resultValue = "";
                        }
                        break;
                    case "audio/ogg":
                        if(CHtmlMediaElement.___isAudio_Ogg_supported)
                        {
                            __resultValue = "probably";
                        }
                        else
                        {
                            __resultValue = "";
                        }
                        break;
                    case "audio/mpeg":
                    case "audio/mp3":
                    case "audio/x-mp3":
                        if (CHtmlMediaElement.___isAudio_MP3_supported)
                        {
                            __resultValue = "probably";
                        }
                        else
                        {
                            __resultValue = "";
                        }
                        break;
                    case "audio/x-m4a":
                    case "audio/m4a":
                        if (CHtmlMediaElement.___isAudio_M4A_suppoted)
                        {

                            __resultValue = "probably";
                        }else
                        {
                            __resultValue = "";
                        }
                        break;
                    case "audio/x-mp4":
                    case "audio/mp4":
                        if (CHtmlMediaElement.___isAudio_ACC_255_supported)
                        {
                            __resultValue = "probably";
                        }
                        else
                        {
                            __resultValue = "";
                        }
                        break;
                    case "audio/wav":
                        if (CHtmlMediaElement.___isAudio_PCM_supported)
                        {
                            __resultValue = "probably";
                        }
                        else
                        {
                            __resultValue = "";
                        }
                        break;
                    case "video/quicktime":
                        __resultValue = "";
                        break;
                    case "application/x-mpegurl":
                    case "application/apple.vnd.mpegurl":
                        __resultValue = "";
                        break;
                    case "text/html":
                    case "text/xml":
                    case "application/octet-stream":
                        __resultValue = "";
                        break;
                    case "video/mp4":
                        if (CHtmlMediaElement.___isVideo_MPEG4_Part2_supported)
                        {
                            __resultValue = "probably";
                        }
                        else
                        {
                            __resultValue = "";
                        }
                        break;
                    case "video/webm":
                    case "video/webM":
                    case "video/WebM":
                   
                        if (CHtmlMediaElement.___isVideo_WebM_supported)
                        {
                            __resultValue = "probably";
                        }
                        else
                        {
                            __resultValue = "";
                        }
                        break;

                    default:
                        __resultValue = "";
                        break;

                }
            }
            if(__resultValue == null)
            {
                __resultValue = "";
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0} canPlayType '{1}' : '{2}' = '{3}'", this.toLogString(), _mimeType, _codecType, __resultValue);
            }
            return __resultValue;

        }
#endregion
#region IPropertBox メンバ

        public override void ___setPropertyByName(string ___name, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("entering {0}.setPropertyValue : {1} = {2}", this, ___name, val);
            }

            switch (___name)
            {

                case "videowidth":
                case "videoWidth":
                case "width":
                case "Width":
                    base.___style.Width = commonHTML.GetStringValue(val);
                    return;
                case "height":
                case "videoheight":
                case "videoHeight":
                    base.___style.Height = commonHTML.GetStringValue(val);
                    return;
                case "currentsrc":
                case "currentSrc":
                    this.currentSrc = commonHTML.GetStringValue(val);
                    return;
                case "src":
                    base.src = commonHTML.GetStringValue(val);
                    return;
                case "codecs":
                    this.codecs = commonHTML.GetStringValue(val);
                    return;
                case "kind":
                    this.kind = commonHTML.GetStringValue(val);
                    return;
                case "type":
                    base.type = commonHTML.GetStringValue(val);
                    return;
                case "mimetype":
                case "mimeType":
                    base.mimeType = commonHTML.GetStringValue(val);
                    return;
                case "autoplay":
                    this.autoplay = commonData.convertObjectToBoolean(val);
                    return;
                case "loop":
                    this.loop = commonData.convertObjectToBoolean(val);
                    return;
                case "volume":
                    this.volume = commonData.GetDoubleFromObject(val, 0);
                    return;
                case "muted":
                    this.muted = commonData.convertObjectToBoolean(val);
                    return;
                case "preload":
                    this.preload = commonHTML.GetStringValue(val);
                    return;
                case "controls":
                    this.controls = commonData.convertObjectToBoolean(val);
                    return;
                case "onloadeddata":
                    this.onloadeddata = val;
                    return;
             case "onloadedmetadata":
                    this.onloadedmetadata = val;
                    return;
                case "oncanplay":
                    this.oncanplay = val;
                    return;
                case "oncanplaythrough":
                    this.oncanplaythrough = val;
                    return;
                case "onchange":
                    this.onchange = val;
                    return;
                case "onplay":
                    this.onplay = val;
                    return;
                case "onplaying":
                    this.onplaying = val;
                    return;
                case "onvolumechange":
                    this.onvolumechange = val;
                    return;
                case "ontoggle":
                    this.ontoggle = val;
                    return;
                case "ontimeupdate":
                    this.ontimeupdate = val;
                    return;
                case "onratechange":
                    this.onratechange = val;
                    return;
                case "onwating":
                    this.onwaiting  = val;
                    return;
                case "onreset":
                    this.onreset = val;
                    return;
                case "onseeking":
                    this.onseeking = val;
                    return;
                case "onseeked":
                    this.onseeked = val;
                    return;
                case "onshow":
                    this.onshow = val;
                    return;
                case "onsort":
                    this.onsort = val;
                    return;
                case "onpause":
                    this.onpause = val;
                    return;
                case "currentTime":
                    this.currentTime = commonData.GetDoubleFromObject(val, 0);
                    return;
                default:
                    break;
            }
            base.___setPropertyByName(___name, val);
        }

        public override bool ___hasPropertyByName(string ___name)
        {
            return true;

        }
        public override bool ___hasPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("calling HasPropertyValueIndex for {0} {1}  {2} ", this.GetType(), this, ___index);
            }
            return true;
        }

        public override void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public override object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public override object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getInner : {0} for {1}", ___name, this.toLogString());
            }
            switch (___name)
            {
                case "attributes":
                    return base.___attributes;
                case "prototype":
                case "__proto__":
                    return this.prototype;
                case "__iterator__":
                    return commonHTML.rhinoForLoopEnumratorFunction;
                case "tagName":
                    return base.tagName;
                case "id":
                    return base.id;
                case "name":
                    return base.name;
                case "class":
                case "classname":
                case "className":
                    return base.className;
                case "type":
                    return base.type;
                case "mimetype":
                case "mimeType":
                    return base.mimeType;
                case "src":
                    return base.src;
                case "href":
                    return base.href;
                case "title":
                    return base.___title;
                case "label":
                    return base.label;
                case "lang":
                case "language":
                    return base.label;
                case "currentsrc":
                case "currentSrc":
                    return this.currentSrc;
                case "codecs":
                    return this.codecs;
                case "buffered":
                case "played":
                case "seekable":
                    return base.___getPropertyByName(___name);
                case "networkstate":
                case "networkState":
                    return this.networkState;
                case "currenttime":
                case "currentTime":
                    return this.currentTime;
                case "initialtime":
                case "initialTime":
                    return this.initialTime;
                case "paused":
                    return this.paused;
                case "style":
                    return this.___style;
                case "autoplay":
                    return this.autoplay;
                case "loop":
                    return this.loop;
                case "ended":
                    return this.ended;
                case "controls":
                    return this.controls;
                case "muted":
                    return this.muted;
                case "volume":
                    return this.volume;
                case "startoffsettime":
                case "startOffsetTime":
                    return this.startOffsetTime;
                case "defaultmuted":
                case "defaultMuted":
                    return this.defaultMuted;
                case "defaultplaybackrate":
                case "defaultPlaybackRate":
                    return this.defaultPlaybackRate;
                case "playbackrate":
                case "playbackRate":
                    return this.playbackRate;
                case "preload":
                    return this.preload;
                case "autobuffer":
                    return this.autobuffer;
                case "crossorigin":
                case "crossOrigin":
                    return this.crossOrigin;
                case "videowidth":
                case "videoWidth":
                    return this.videoWidth;
                case "videoheight":
                case "videoHeight":
                    return this.videoHeight;
                case "kind":
                    return this.kind;
                case "mediagroup":
                case "mediaGroup":
                    return this.mediaGroup;
                case "seeking":
                    return this.seeking;
                case "duration":
                    return this.duration;
                case "onchange":
                    return onchange;
                case "oncanplay":
                    return this.oncanplay;
                case "oncanplaythrough":
                    return this.oncanplaythrough;
                case "ondurationchange":
                    return this.ondurationchange;
                case "onended":
                    return this.onended;
                case "onloadeddata":
                    return this.onloadeddata;
                case "onloadedmetadata":
                    return this.onloadedmetadata;
                case "onloadstart":
                    return this.onloadstart;
                case "onplay":
                    return this.onplay;
                case "onplaying":
                    return this.onplaying;
                case "onvolumechange":
                    return this.onvolumechange;
                case "onratechange":
                    return this.onratechange;
                case "onwating":
                    return this.onwaiting;
                case "onpause":
                    return this.onpause;
                case "onsuspend":
                    return this.onsuspend;
                case "onshow":
                    return this.onshow;
                case "onseeked":
                    return this.onseeked;
                case "onseeking":
                    return this.onseeking;
                case "onprogress":
                    return this.onprogress;
                case "onreset":
                    return this.onreset;
                case "readyState":
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                    {
                       commonLog.LogEntry("TODO: MediaElement readyState always returns ready to play");
                    }
                    return (double)4;
                // Media element methods - return callable delegates for JavaScript invocation
                case "canPlayType":
                    return new Func<object, string>(this.canPlayType);
                case "play":
                    return new Func<Task>(this.play);
                case "pause":
                    return new Action(this.pause);
                case "load":
                    return new Action(this.load);
                case "stop":
                    return new Action(this.stop);
                case "addTextTrack":
                    return new Func<object, object, object, CHtmlMediaElement>(this.addTextTrack);
                default:
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
                            __ProtoLookupCont++;
                            if (__ProtoLookupCont > 10)
                            {
                                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                                {
                                   commonLog.LogEntry("GetPropertyValue for {0} {1} Prototype lookup loop", this.GetType(), this);
                                }
                                break;
                            }

                            object protoValue = null;
                            if (___protoElement.___properties.Count > 0 && ___protoElement.___properties.TryGetValue(___name, out protoValue))
                            {
                                return protoValue;
                            }
                            else
                            {
                                if (___protoElement.___elementTagType == CHtmlElementType._ELEMENT_PROTOTYPE)
                                {
                                    break;
                                }
                                if (___protoElement.parentNode != null)
                                {
                                    ___protoElement = ___protoElement.parentNode as CHtmlElement;
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                    }

                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    break;
            }
            object _obase = base.___getPropertyByName(___name);
            if (_obase != null)
            {
                return _obase;
            }

            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
            }
            return null;
        }
        public new IMutilversalObjectType multiversalClassType
        {
            get
            {
                switch (this.___elementTagType)
                {
                    case CHtmlElementType.AUDIO:
                        return IMutilversalObjectType.HTMLAudioElement;
                    case CHtmlElementType.VIDEO:
                        return IMutilversalObjectType.HTMLVideoElement;
                }
                return IMutilversalObjectType.HTMLVideoElement;
            }
        }

        /// <summary>
        /// Explicit interface implementation of GetMetaObject to return CHtmlClearScriptDynamicMetaObject with CHtmlMediaElement type
        /// so ClearScript properly routes through BindGetMember/BindInvokeMember for media element methods.
        /// </summary>
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlMediaElement>(parameter, this);
        }
#endregion
    }
}
