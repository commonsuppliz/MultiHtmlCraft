using ExCSS;
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

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// CHtmlMediaElement 
    /// </summary>
    public class CHtmlMediaElement : CHtmlElement, System.IDisposable, IDynamicMetaObjectProvider
    {
        int ___audioStreamHandle = 0;
        private CHtmlTimeRanges _bufferedTimeRange = null;
        private CHtmlCollection _textTracks = null;
        internal string ___mediaType = null;
        internal byte[] ___binaryData = null;
        internal string ___mediaLocalCacheDataPatth = null;
        internal byte[]? ___audioBytes = null;
        internal byte[]? ___videoBytes = null;


        internal static Type WindowsIntegrationElementHostType = null;
   
        internal static Type WindowsMediaElementType = null;
   
        internal static CHtmlAssemblyLoadStatusType ___hostLibraryLoadStatus = CHtmlAssemblyLoadStatusType.Uninitalized;


   
        internal static Type ___MediaElementMediaStateEnumType = null;

   
        internal System.WeakReference ___ManagedMediaControlWeakReference1 = null;
   
        internal System.WeakReference ___ManagedMediaControlWeakReference2 = null;
   
        internal System.WeakReference ___ManagedMediaControlWeakReference3 = null;



        #region WPF Method Delegates
   
        internal static System.Reflection.PropertyInfo ___hostElementChildPropertyMethodInfo = null;
   
        internal static System.Reflection.PropertyInfo ___mediaElementLoadedBehaviorPropertyInfo = null;
   
        internal static System.Reflection.PropertyInfo ___mediaElementSourcePropertyInfo = null;
        internal static System.Reflection.MethodInfo ___getwpfSouceMethodInfo;
        internal static System.Reflection.MethodInfo ___setwpfSouceMethodInfo;
        public delegate System.Uri ___wpfSouceGetDelegate();
        public delegate void ___wpfSouceSetDelegate(System.Uri ___uritmp);
        public delegate void ___wpfVoidDelegate();
        internal  ___wpfSouceGetDelegate ___wpfSouceGetFunction;
        internal  ___wpfSouceSetDelegate ___wpfSouceSetFunction;
        internal ___wpfVoidDelegate ___wpfPlayFunction;
        internal ___wpfVoidDelegate ___wpfPauseFunction;
        internal ___wpfVoidDelegate ___wpfStopFunction;

        internal MediaElementReadyState ___media_readyState = MediaElementReadyState.HAVE_NOTHING;

        /// <summary>
        /// PCM / WAV format"1". This is Linear 8 or 16 bit Pulse Code Modulation. Roughly speaking, this is WAV format.
        /// This is Linear 8 or 16 bit Pulse Code Modulation.Roughly speaking, this is WAV format.
        /// </summary>
        public static bool ___isAudio_PCM_supported = false;
        /// <summary>
        /// Microsoft Windows Media Audio Standard formats."353" - Microsoft Windows Media Audio v7, v8 and v9.x Standard (WMA Standard)
        /// </summary>
        public static bool ___isAudio_WMA_353_supported = false;
        /// <summary>
        /// Microsoft Windows Media Audio Professional formats."354" - Microsoft Windows Media Audio v9.x and v10 Professional (WMA Professional)
        /// </summary>
        public static bool ___isAudio_WMA_354_supported = false;
        /// <summary>
        ///MP3 "85" -– (ISO MPEG-1 Layer III) format (MP3).
        /// </summary>
        public static bool ___isAudio_MP3_supported = false;
        /// <summary>
        /// AAC"255" - (ISO Advanced Audio Coding) (AAC)format.
        /// </summary>
        public static bool ___isAudio_ACC_255_supported = false;

        /// <summary>
        /// AMR-NB (Adaptive Multi-Rate Narrow Band) format
        /// (Note: Not suported on .NET MediaElement)
        /// </summary>
        public static bool ___isAudio_AMR_NB_supported = false;

        /// <summary>
        /// Ogg Audio Support
        /// </summary>
        public static bool ___isAudio_Ogg_supported = false;


        /// <summary>
        /// Dolby EC-3
        /// </summary>
        public static bool ___isAudio_Dolby_EC_3_supported = false;


        /// <summary>
        /// Dolby AC-3
        /// </summary>
        public static bool ___isAudio_Dolby_AC_3_supported = false;

        /// <summary>
        /// Dolby H264. AVC1
        /// </summary>
        public static bool ___isAudio_Dolby_H264_AVC1_supported = false;
        /// <summary>
        /// Dolby H264. AVC3
        /// </summary>
        public static bool ___isAudio_Dolby_H264_AVC3_supported = false;
        /// <summary>
        /// Raw Video
        /// </summary>
        public static bool ___isVideo_RawVideo_supported = false;



        /// <summary>
        /// YV12 format- YCrCb(4:2:0)
        /// Uncompressed YCrCb(4:2:0).
        /// Not supported on Windows Phone 7.
        /// </summary>
        public static bool ___isVideo_YV12_supported = false;


        /// <summary>
        /// Windows Media Video and VC-1 formatsWMV1: Windows Media Video 7
        /// Supports Simple, Main, and Advanced Profiles.
        /// Supports only progressive (non-interlaced) content.
        /// </summary>
        public static bool ___isVideo_Windows_Media_Video_VC_1_supported = false;

        /// <summary>
        /// WMV2: Windows Media Video 8
        /// </summary>
        public static bool ___isVideo_WMV2_Windows_Media_Video_8_supported = false;

        /// <summary>
        /// WMV3: Windows Media Video 9
        /// </summary>
        public static bool ___isVideo_WMV3_Windows_Media_Video_9_supported = false;

        /// <summary>
        /// Windows Media Video Advanced Profile(non-VC-1)
        /// </summary>
        public static bool ___isVideo_WMVA_supported = false;


        /// <summary>
        /// H264 (ITU-T H.264 / ISO MPEG-4 AVC) formats
        /// </summary>
        public static bool ___isVideo_H264_supported = false;

        /// <summary>
        /// H.263 format
        /// </summary>
        public static bool ___isVideo_H263_supported = false;

        /// <summary>
        /// MPEG-4 Part 2 format
        /// </summary>
        public static bool ___isVideo_MPEG4_Part2_supported = false;

        /// <summary>
        /// Ogg Video Support
        /// </summary>
        public static bool ___isVideo_Ogg_supported = false;

        /// <summary>
        /// WebM (Google Format)
        /// </summary>
        public static bool ___isVideo_WebM_supported = false;
        /// <summary>
        /// Apple Format
        /// </summary>
        public static bool ___isAudio_M4A_suppoted = false;
        

        public enum MediaElementReadyState : uint
        {
            HAVE_NOTHING = 0,
            HAVE_METADATA = 1,
            HAVE_CURRENT_DATA = 2,
            HAVE_FUTURE_DATA = 3,
            HAVE_ENOUGH_DATA = 4

        }

        #endregion

        public static void ___defineWPFAudioVideoFormmats()
        {
            // Audio Section
            
            CHtmlMediaElement.___isAudio_ACC_255_supported = true;
            CHtmlMediaElement.___isAudio_AMR_NB_supported = true;
            CHtmlMediaElement.___isAudio_MP3_supported  = true;
            CHtmlMediaElement.___isAudio_PCM_supported  = true;
            CHtmlMediaElement.___isAudio_WMA_353_supported  = true;
            CHtmlMediaElement.___isAudio_WMA_354_supported  = true;
            CHtmlMediaElement.___isAudio_M4A_suppoted = true;
            CHtmlMediaElement.___isAudio_Ogg_supported = true;
            
            // Video
            CHtmlMediaElement.___isVideo_H263_supported  = true;
            CHtmlMediaElement.___isVideo_H264_supported  = true;
            CHtmlMediaElement.___isVideo_MPEG4_Part2_supported = true;
            CHtmlMediaElement.___isVideo_Windows_Media_Video_VC_1_supported  = true;
            CHtmlMediaElement.___isVideo_WMV3_Windows_Media_Video_9_supported  = true;
            CHtmlMediaElement.___isVideo_WMVA_supported  = true;
            CHtmlMediaElement.___isVideo_MPEG4_Part2_supported  = true;
            CHtmlMediaElement.___isVideo_Ogg_supported = true;
        }

        public static void ___initMediaElementControlInterface()
        {
            switch(System.Environment.OSVersion.Platform)
            {
#if WINDOWS
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.Xbox:
                case PlatformID.WinCE:
                    ___initWindowsCHtmlMediaIntegrationElementHostType();
                    break;
#else
                case PlatformID.Unix:
                case PlatformID.MacOSX:
                

                    break;
#endif
                default:
                    ___hostLibraryLoadStatus = CHtmlAssemblyLoadStatusType.AttemptedButFaied;
                    break;
            }
        }
        private static void ___initMultiplatformCHtmlMediaIntegrationElementHostType()
        { 
            if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: Multiplatform Media Element Host MuliPlatform  initialization. Current OS Platform {0} ", System.Environment.OSVersion.Platform);
            }
        }
        private static void ___initWindowsCHtmlMediaIntegrationElementHostType()
        {
            if (System.Environment.Version.Major <= 1)
            {
                ___hostLibraryLoadStatus = CHtmlAssemblyLoadStatusType.AttemptedButFaied;
                return;
            }
            string _strWindowsIntegrationAssemblyFullName = "";
            string _strPresentationFrameworkAssemblyFullName = "";
            // ========================================================================================================
            //                Note: WindiwsIntegration Assembly publickeytoken does not match to base assembly in 
            //                        
            //                      Net 3.0 , Net 4.0 , Net 4.5
            //
            //                     MediaElement is on PresentationFramework.dll
            // ========================================================================================================
            if (System.Environment.Version.Major == 2 || System.Environment.Version.Major == 3)
            {
                _strWindowsIntegrationAssemblyFullName = "WindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35";
                _strPresentationFrameworkAssemblyFullName = "PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35";
            }
            else if (System.Environment.Version.Major >= 4)
            {
                System.Reflection.Assembly __typeBase = typeof(object).Assembly;
                System.Reflection.AssemblyName __typeBaseName = __typeBase.GetName();
                System.Version __typeBaseVersion = __typeBaseName.Version;
                string __strVersion = string.Format("{0}.{1}.{2}.{3}", __typeBaseVersion.Major, __typeBaseVersion.Minor, __typeBaseVersion.Build, __typeBaseVersion.Revision);
                _strWindowsIntegrationAssemblyFullName = "WindowsFormsIntegration, Version=" + __strVersion + ", Culture=neutral, PublicKeyToken=31bf3856ad364e35";
                _strPresentationFrameworkAssemblyFullName = "PresentationFramework, Version=" + __strVersion + ", Culture=neutral, PublicKeyToken=31bf3856ad364e35";
            }
            if (_strWindowsIntegrationAssemblyFullName.Length != 0)
            {
                System.Reflection.Assembly asmWindowsIntegration = null;
                System.Reflection.Assembly asmPresentationFramework = null;
                try
                {
                    asmWindowsIntegration = System.Reflection.Assembly.Load(_strWindowsIntegrationAssemblyFullName);
                    asmPresentationFramework = System.Reflection.Assembly.Load(_strPresentationFrameworkAssemblyFullName);

                    if (asmWindowsIntegration != null)
                    {
                   
                        WindowsIntegrationElementHostType = asmWindowsIntegration.GetType("System.Windows.Forms.Integration.ElementHost", false);

                        if (asmPresentationFramework != null)
                        {
                            WindowsMediaElementType = asmPresentationFramework.GetType("System.Windows.Controls.MediaElement", false);
                            if (WindowsIntegrationElementHostType != null)
                            {
                                ___hostElementChildPropertyMethodInfo = WindowsIntegrationElementHostType.GetProperty("Child");


                            }
                            if (WindowsMediaElementType != null)
                            {
                                ___mediaElementLoadedBehaviorPropertyInfo = WindowsMediaElementType.GetProperty("LoadedBehavior");
                                ___mediaElementSourcePropertyInfo = WindowsMediaElementType.GetProperty("Source");
                                if (___mediaElementSourcePropertyInfo != null)
                                {
                                    ___getwpfSouceMethodInfo = ___mediaElementSourcePropertyInfo.GetGetMethod();

                                    ___setwpfSouceMethodInfo = ___mediaElementSourcePropertyInfo.GetSetMethod();


                                }
                            }
                            ___MediaElementMediaStateEnumType = asmPresentationFramework.GetType("System.Windows.Controls.MediaState", false);
                        }
                        if (WindowsIntegrationElementHostType != null)
                        {
                            
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                            {
                               commonLog.LogEntry("ElementHost  Type : {0} Child : {1}", WindowsIntegrationElementHostType, ___hostElementChildPropertyMethodInfo);
                               commonLog.LogEntry("MediaElement Type :{0} MediaState: {1}", WindowsMediaElementType, ___MediaElementMediaStateEnumType);

                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 6)
                    {
                       commonLog.LogEntry("ElementHost Reflection Exception.  ", ex);

                    }
                }
            }
            try {
                if (WindowsIntegrationElementHostType == null && ___hostLibraryLoadStatus != CHtmlAssemblyLoadStatusType.Loaded)
                {
                    ___hostLibraryLoadStatus = CHtmlAssemblyLoadStatusType.AttemptedButFaied;
                }
                else
                {
                    ___defineWPFAudioVideoFormmats();
                    ___hostLibraryLoadStatus = CHtmlAssemblyLoadStatusType.Loaded;
                }
            }
            catch
            {
                ___hostLibraryLoadStatus = CHtmlAssemblyLoadStatusType.AttemptedButFaied;
            }
            return;
        }
        /// <summary>
        /// Return ture if Media Element ___hasInner created
        /// </summary>
        /// <returns></returns>
        public bool ___ismediaWPFElementObjecttLive()
        {
            if (this.___ManagedMediaControlWeakReference2 != null && this.___ManagedMediaControlWeakReference2.IsAlive == true)
            {
                return true;
            }
            return false;

        }
        /// <summary>
        /// Return___mediaWPFElementObject if it exists
        /// </summary>
        private object ___mediaWPFElementObject
        {
            get
            {
                if (this.___ManagedMediaControlWeakReference2 != null && this.___ManagedMediaControlWeakReference2.IsAlive == true)
                {
                    return this.___ManagedMediaControlWeakReference2.Target;
                }

                return null;
            }
        }
        public CHtmlMediaElement addTextTrack(object objkind, object objlabel, object objlanguage)
        {
            return this.___addTextTrack_Inner(objkind, objlabel, objlanguage);

        }
        /// <summary>
        /// Media Element Ready State should be numeric. not string.
        /// </summary>
        public new double readyState
        {
            get
            {
                return (double)this.___media_readyState;
            }
        }
        public CHtmlMediaElement addTextTrack(object objkind, object objlabel)
        {
            return this.___addTextTrack_Inner(objkind, objlabel, null);

        }
        public CHtmlMediaElement addTextTrack(object objkind)
        {
            return this.___addTextTrack_Inner(objkind, null, null);

        }
        public CHtmlMediaElement addTextTrack()
        {
            return this.___addTextTrack_Inner(null, null, null);

        }
        private CHtmlMediaElement ___addTextTrack_Inner(object objkind, object objlabel, object objlanguage)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling addTextTrack()", this);
            }
            CHtmlMediaElement ___trackElement = new CHtmlMediaElement();
            ___trackElement.___ChildNodeIndex = this.___childNodes.Add(___trackElement);
            ___trackElement.___IsDynamicElement = true;
            ___trackElement.___parentWeakRef = new WeakReference(this, false);
            ___trackElement.___IsElementVisible = false;
            ___trackElement.___SetTagNameOnly("TRACK");
            ___trackElement.___elementTagType = CHtmlElementType.TRACK;
            /// =========================================
            /// Create attributes baseupon parameters
            /// =========================================
            if (objkind != null)
            {
                string strKind = commonHTML.GetStringValue(objkind);
                CHtmlAttribute attrKind = new CHtmlAttribute();
                attrKind.name = "kind";
                attrKind.setParentNode(___trackElement);
                attrKind.value = strKind;
                ___trackElement.___attributes["kind"] = attrKind;

            }
            if (objlabel != null)
            {
                string strLabel = commonHTML.GetStringValue(objlabel);
                CHtmlAttribute attrLabel = new CHtmlAttribute();
                attrLabel.name = "label";
                attrLabel.setParentNode(___trackElement);
                attrLabel.value = strLabel;
                ___trackElement.___attributes["label"] = attrLabel;
            }
            if (objlanguage != null)
            {
                string strLanguage = commonHTML.GetStringValue(objlanguage);
                CHtmlAttribute attrLang = new CHtmlAttribute();
                attrLang.name = "language";
                attrLang.setParentNode(___trackElement);
                attrLang.value = strLanguage;
                ___trackElement.___attributes["language"] = attrLang;
            }
            return ___trackElement;
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

        /// <summary>
        /// Video , Audio , Track Tag
        /// </summary>
        public CHtmlMediaElement()
        {
            this._bufferedTimeRange = new CHtmlTimeRanges();
            this._textTracks = new CHtmlCollection();
            /*
            if (___hostLibraryLoadStatus == CHtmlAssemblyLoadStatusType.Uninitalized)
            {
                try
                {
                    GetWindowsIntegrationElementHostType();

            }
             */
        }
        public new bool autoplay
        {
            set
            {
                this.SetGetAttributesByName("autoplay", value, true);
            }
            get
            {
                return commonData.convertObjectToBoolean(this.SetGetAttributesByName("autoplay", value, false));
            }

        }
        public bool autostart
        {
            set
            {
                this.SetGetAttributesByName("autostart", value, true);
            }
            get
            {
                return commonData.convertObjectToBoolean(this.SetGetAttributesByName("autostart", value, false));
            }

        }
        public bool autobuffer
        {
            set
            {
                this.SetGetAttributesByName("autobuffer", value, true);
            }
            get
            {
                return commonData.convertObjectToBoolean(this.SetGetAttributesByName("autobuffer", value, false));
            }
        }
        public new bool loop
        {
            set
            {
                this.SetGetAttributesByName("loop", value, true);
            }
            get
            {
                return commonData.convertObjectToBoolean(this.SetGetAttributesByName("loop", value, false));
            }
        }
        public bool muted
        {
            set
            {
                this.SetGetAttributesByName("muted", value, true);
            }
            get
            {
                return commonData.convertObjectToBoolean(this.SetGetAttributesByName("muted", value, false));
            }
        }
        public bool defaultMuted
        {
            set
            {
                this.SetGetAttributesByName("defaultmuted", value, true);
            }
            get
            {
                return commonData.convertObjectToBoolean(this.SetGetAttributesByName("defaultmuted", value, false));
            }
        }
        public bool paused
        {
            set
            {
                this.SetGetAttributesByName("paused", value, true);
            }
            get
            {
                return commonData.convertObjectToBoolean(this.SetGetAttributesByName("paused", value, false));
            }
        }
        public bool ended
        {
            set
            {
                this.SetGetAttributesByName("ended", value, true);
            }
            get
            {
                return commonData.convertObjectToBoolean(this.SetGetAttributesByName("ended", value, false));
            }
        }
        public bool seeking
        {
            set
            {
                this.SetGetAttributesByName("seeking", value, true);
            }
            get
            {
                return commonData.convertObjectToBoolean(this.SetGetAttributesByName("seeking", value, false));
            }
        }
        /// <summary>
        /// The media ___hasInner control menu over video (bool)
        /// </summary>
        public bool controls
        {
            set
            {
                this.SetGetAttributesByName("controls", value, true);
            }
            get
            {
                return commonData.convertObjectToBoolean(this.SetGetAttributesByName("controls", value, false));
            }
        }
        public string poster
        {
            set
            {
                this.SetGetAttributesByName("poster", value, true);
            }
            get
            {
                return commonHTML.GetElementAttributeInString(this, "poster");
            }
        }
        public string currentSrc
        {
            set
            {
                this.SetGetAttributesByName("currentsrc", value, true);
            }
            get
            {
                return commonHTML.GetElementAttributeInString(this, "currentsrc");
            }
        }
        public static CHtmlMediaElementPreloadType ___getPreloadType(string ___preload)
        {

            switch (___preload)
            {
                case "none":
                case "None":
                case "NONE":
                case "false":
                case "False":

                    return CHtmlMediaElementPreloadType.none;

                case "auto":
                case "Auto":
                case "AUTO":
                case "True":
                case "true":
                    return CHtmlMediaElementPreloadType.auto;
                case "metadata":
                case "Metadata":
                    return CHtmlMediaElementPreloadType.metadata;
            }
            return CHtmlMediaElementPreloadType.auto;
        }

        public string preload
        {
            set
            {
                this.___preloadType = ___getPreloadType(value);
                this.SetGetAttributesByName("preload", value, true);
            }
            get
            {
                return this.___preloadType.ToString();
            }
        }
        public string codecs
        {
            set
            {
                this.SetGetAttributesByName("codes", value, true);
            }
            get
            {
                return commonHTML.GetElementAttributeInString(this, "codecs");
            }
        }
        public string kind
        {
            set
            {
                this.SetGetAttributesByName("kind", value, true);
            }
            get
            {
                return commonHTML.GetElementAttributeInString(this, "kind");
            }

        }

        public string mediaGroup
        {
            set
            {
                this.SetGetAttributesByName("mediagroup", value, true);
            }
            get
            {
                return commonHTML.GetElementAttributeInString(this, "mediagroup");
            }
        }

        public object crossOrigin
        {
            set
            {
                this.SetGetAttributesByName("crossorigin", value, true);
            }
            get
            {
                return this.SetGetAttributesByName("autobuffer", value, false);
            }

        }
        public double volume
        {
            set
            {
                this.SetGetAttributesByName("volume", value, true);
            }
            get
            {
                return commonData.GetDoubleFromObject(this.SetGetAttributesByName("volume", value, false), 0);
            }
        }
        public int networkState
        {
            set
            {
                this.SetGetAttributesByName("networkstate", value, true);
            }
            get
            {
                return commonHTML.GetIntFromObject(this.SetGetAttributesByName("networkstate", value, false), 0);
            }
        }
        /// <summary>
        /// HTML5  startOffsetTime is DateTime. Not double or int.
        /// </summary>
        public DateTime startOffsetTime
        {
            set
            {
                this.SetGetAttributesByName("startoffsettime", value, true);
            }
            get
            {
                object objValue = this.SetGetAttributesByName("startoffsettime", value, false);
                if (objValue != null)
                {
                    if (objValue is DateTime)
                    {
                        return (DateTime)objValue;
                    }
                }
                else
                {
                    try
                    {
                        return DateTime.Parse(objValue.ToString());
                    }
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                        {
                           commonLog.LogEntry("startOffsetTime ParseDate Error", ex);
                        }
                    }
                }
                return DateTime.Now;
            }
        }

        public double defaultPlaybackRate
        {
            set
            {
                this.SetGetAttributesByName("defaultplaybackrate", value, true);
            }
            get
            {
                return commonData.GetDoubleFromObject(this.SetGetAttributesByName("defaultplaybackrate", value, false), 0);
            }
        }
        public double playbackRate
        {
            set
            {
                this.SetGetAttributesByName("playbackrate", value, true);
            }
            get
            {
                return commonData.GetDoubleFromObject(this.SetGetAttributesByName("playbackrate", value, false), 0);
            }
        }
        public double currentTime
        {
            set
            {
                this.SetGetAttributesByName("currenttime", value, true);
            }
            get
            {
                return commonData.GetDoubleFromObject(this.SetGetAttributesByName("currenttime", value, false), 0);
            }
        }
        public double initialTime
        {
            set
            {
                this.SetGetAttributesByName("initialtime", value, true);
            }
            get
            {
                return commonData.GetDoubleFromObject(this.SetGetAttributesByName("initialtime", value, false), 0);
            }
        }
        public double duration
        {
            set
            {
                this.SetGetAttributesByName("duration", value, true);
            }
            get
            {
                return commonData.GetDoubleFromObject(this.SetGetAttributesByName("duration", value, false), 0);
            }
        }
        public double videoWidth
        {
            get { return this.___offsetWidth; }
        }
        public double videoHeight
        {
            get { return this.___offsetHeight; }
        }
        public CHtmlTimeRanges buffered
        {
            get
            {
                return this._bufferedTimeRange;
            }

        }
        public CHtmlTimeRanges played
        {
            get
            {
                return this._bufferedTimeRange;
            }

        }
        public CHtmlTimeRanges seekable
        {
            get
            {
                return this._bufferedTimeRange;
            }
        }
        public CHtmlCollection textTracks
        {
            get { return createTrackListInner(); }
        }
        public CHtmlCollection videoTracks
        {
            get { return createTrackListInner(); }

        }
        public CHtmlCollection audioTracks
        {
            get { return createTrackListInner(); }
        }
        private CHtmlCollection createTrackListInner()
        {
            CHtmlCollection _trackList = new CHtmlCollection();
            _trackList.___CollectionType = CHtmlHTMLCollectionType.MediaTrackList;
            for (int i = 0; i < this.___childNodes.Count; i++)
            {
                CHtmlElement _elem = this.___childNodes[i] as CHtmlElement;
                if (_elem != null)
                {
                    if (_elem.___elementTagType == CHtmlElementType.TRACK)
                    {
                        _trackList.Add(_elem);
                    }
                }
            }
            return _trackList;
        }

        #region Methods
        private static object ___mediaElementLock = new object ();

        private static bool ___mediaElementAquiredLock = false;
        public async Task play()
        {
            Monitor.TryEnter(___mediaElementLock, 10000, ref ___mediaElementAquiredLock);

            if (!___mediaElementAquiredLock)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry($"{this}.play() called. but play is currently executing");
                }
                
                return;
            }

            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"{this}.play() called. src: {this.src} currentSrc: {this.currentSrc}");
            }
            try
            {
                if (await this.load_MediaElement_src_inner())
                {
                    if (this.___ismediaWPFElementObjecttLive() == true)
                    {
                        try
                        {
                            if (___wpfPlayFunction == null)
                            {
                                ___wpfPlayFunction = (___wpfVoidDelegate)Delegate.CreateDelegate(typeof(___wpfVoidDelegate), this.___mediaWPFElementObject, this.___mediaWPFElementObject.GetType().GetMethod("Play"));
                            }
                            /*
                            this.___mediaWPFElementObject.GetType().InvokeMember("Play", System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, this.___mediaWPFElementObject, null);
                            */
                            ___wpfPlayFunction.Invoke();

                        }
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                            {
                               commonLog.LogEntry("load_MediaElement_src_inner", ex);
                            }

                        }
                    }
                    else
                    {
                        switch(commonHTML.GraphicApiType)
                        {
                            case GraphicAPIType.Avalonia:
                            case GraphicAPIType.SkiaSharp:
                                if(this.___elementTagType == CHtmlElementType.AUDIO)
                                {
                                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                                    if (string.IsNullOrEmpty(baseDir))
                                    {
                                        // 万が一上記で取れない場合の代替策
                                        baseDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                                    }

                                    // 2. まずは .exe の直下を探索パスに追加
                                    //SetDllDirectory(baseDir);
                                    if(commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                    {
                                        commonLog.LogEntry($"{this}.play() called. baseDir: {baseDir}");
                                    }


                                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8 && ___audioBytes != null)
                                    {
                                        commonLog.LogEntry($"{this}.play() called with {___audioBytes.Length}: bytes of audio data. src: {this.src} currentSrc: {this.currentSrc}");    
                                    }
                                    if(!Bass.Init())
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8 && ___audioBytes != null)
                                        {
                                            commonLog.LogEntry($"Bass.Init() failed.");
                                        }
                                        return;
                                    }
                                    ___audioStreamHandle = Bass.CreateStream(___audioBytes, 0, ___audioBytes.Length, 0);
                                    Bass.ChannelSetSync(___audioStreamHandle, SyncFlags.End, 0, BassEndSyncProc, IntPtr.Zero);
                                    if (___audioStreamHandle==0)
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                        {
                                            commonLog.LogEntry($"{this}.play() failed to create audio stream with error code {Bass.LastError}");
                                        }
                                    }
                                    else
                                    {
                                        Bass.ChannelPlay(___audioStreamHandle);
                                        
                                   
                                        
                                    }

                                }
                                else if(this.___elementTagType == CHtmlElementType.VIDEO)
                                {
                                    if(commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                    {
                                        commonLog.LogEntry($"{this}.play() called with {___videoBytes.Length}: bytes of video data. src: {this.src} currentSrc: {this.currentSrc}");    
                                    }
                                }
                                break;
                        }
                    }

                }
            }catch(Exception ex2)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("load_MediaElement_src_inner exception final stage", ex2);
                }
            }
       
            Monitor.Exit(___mediaElementLock);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"{this}.play() completed. src: {this.src} currentSrc: {this.currentSrc}");
            }
        }
        private void BassEndSyncProc(int handle, int channel, int data, IntPtr user)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"{this}.BassEndSyyncProc completed. Cleanup src: {this.src} currentSrc: {this.currentSrc}");
            }
        
               if (handle != 0)
            {
                Bass.ChannelStop(handle);
                Bass.StreamFree(handle);
                handle = 0;
            }
            Bass.Free();
        }

        // クリーンアップ処理

        public new void stop()
        {
            if (this.___ismediaWPFElementObjecttLive() == true)
            {
                try
                {
                    if (___wpfStopFunction == null)
                    {
                        ___wpfStopFunction = (___wpfVoidDelegate)Delegate.CreateDelegate(typeof(___wpfVoidDelegate), this.___mediaWPFElementObject, this.___mediaWPFElementObject.GetType().GetMethod("Stop"));
                    }
                    /*
                    this.___mediaWPFElementObject.GetType().InvokeMember("Stop", System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, this.___mediaWPFElementObject, null);
                    */
                    ___wpfStopFunction.Invoke();

                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("load_MediaElement_src_inner", ex);
                    }

                }
            }
        }
        public void pause()
        {
            if (this.___ismediaWPFElementObjecttLive() == true)
            {
                try
                {
                    /*
                    this.___mediaWPFElementObject.GetType().InvokeMember("Pause", System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, this.___mediaWPFElementObject, null);
                    */
                    if (___wpfPauseFunction == null)
                    {
                        ___wpfPauseFunction = (___wpfVoidDelegate)Delegate.CreateDelegate(typeof(___wpfVoidDelegate), this.___mediaWPFElementObject, this.___mediaWPFElementObject.GetType().GetMethod("Pause"));
                    }
                    ___wpfPauseFunction.Invoke();
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("CHtmlMediaElement pause Exception. ", ex);
                    }

                }
            }
        }
        public void load()
        {
            this.load_MediaElement_src_inner();
        }
        private async Task<bool> load_MediaElement_src_inner()
        {
            var ___mediaSoucreLoaded = false;
            try
            {
                if (this.___documentWeakRef == null)
                    ___mediaSoucreLoaded = false;

                string _srcOrigin = this.src;
                if (_srcOrigin == null || _srcOrigin.Length == 0)
                {
                    if (this.___childNodes.Count > 0)
                    {
                        for (int i = 0; i < this.___childNodes.Count; i++)
                        {
                            CHtmlElement __srcElement = this.___childNodes[i] as CHtmlElement;
                            if (__srcElement != null)
                            {
                                if (__srcElement.___elementTagType == CHtmlElementType.SOURCE)
                                {
                                    if (__srcElement.src != null && __srcElement.src.Length != 0)
                                    {
                                        _srcOrigin = __srcElement.src;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
       

                }

                if (_srcOrigin == null)
                {
                    ___mediaSoucreLoaded = false;

                }

                string _fullSrc = commonHTML.GetAbsoluteUri(this.___Document.___URL, this.___Document.___baseUrl, _srcOrigin);
                string ___currentSrc = this.currentSrc;
 
                    this.currentSrc = _fullSrc;
#if WINDOWS
                    if (this.___ismediaWPFElementObjecttLive() == true)
                    {
                        if(___wpfSouceGetFunction == null || ___wpfSouceGetFunction == null)
                        {
                            this.___bind_wpf_source_set_get_functions();
                        }
                        // this.___mediaWPFElementObjectt.GetType().InvokeMember("Source", System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, this.___mediaWPFElementObjectt, new object[] { new Uri(_fullSrc) });
                        this.___wpfSouceSetFunction.Invoke(new System.Uri(_fullSrc));
                        return true;
                        }
#else
                    // Load Auido Sorce or Viedeo Source
                    if (this.___elementTagType == CHtmlElementType.AUDIO)
                    {
                        var contentData = await CHmlMultiversalWebCache.getMultiversalContentData(_fullSrc, string.Empty);
                    if (System.IO.File.Exists(contentData.FileLocation))
                    {
                        this.___audioBytes = System.IO.File.ReadAllBytes(contentData.FileLocation);
                    }
                       
                        if(this.___audioBytes != null && this.___audioBytes.Length > 0)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                        {
                            commonLog.LogEntry($"{this}.load_MediaElement_src_inner loaded audio data with {___audioBytes.Length} bytes. src: {this.src} currentSrc: {this.currentSrc}");
                        }
                    }
                         ___mediaSoucreLoaded = true;
                        

                    }
                    else if (this.___elementTagType == CHtmlElementType.VIDEO)
                    {
                        var contentData = await CHmlMultiversalWebCache.getMultiversalContentData(_fullSrc, string.Empty);
                    
                        this.___videoBytes = contentData.RawData;
                        ___mediaSoucreLoaded = true;
                    }

#endif
                
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry($"{this}.load_MediaElement_src_inner {{ src: {this.src}, currentSrc: {this.currentSrc} }} sucess : {___mediaSoucreLoaded}");
                }

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry($"{this}.load_MediaElement_src_inner {{ src: {this.src}, currentSrc: {this.currentSrc} }} failed", ex);
            
                }
                return ___mediaSoucreLoaded;

            }
            return ___mediaSoucreLoaded;
        }
        private void ___bind_wpf_source_set_get_functions()
        {

            ___wpfSouceGetFunction = (___wpfSouceGetDelegate)Delegate.CreateDelegate(typeof(___wpfSouceGetDelegate), this.___mediaWPFElementObject, ___getwpfSouceMethodInfo);

            ___wpfSouceSetFunction = (___wpfSouceSetDelegate)Delegate.CreateDelegate(typeof(___wpfSouceSetDelegate), this.___mediaWPFElementObject, ___setwpfSouceMethodInfo);
        }
    
   
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
                    return this._bufferedTimeRange;
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
