using System;
using System.Collections;
using System.Dynamic;
using System.Runtime.InteropServices;
using MultiHtmlCraft.Interfaces;
using System.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Resources;
using System.Reflection;
using System.Diagnostics;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlDocumentNavigator = DHTML navigator object
	/// </summary>
	[ComVisible(true)]
	
	public class CHtmlNavigator: CHtmlNode, ICommonObjectInterface, IDynamicMetaObjectProvider
    {

        /// <summary>
        /// string returns for ActiveXObject getVersion
        /// </summary>
		internal static string ___FlashVersionString = "";
        /// <summary>
        /// String will be returns as navigator.plugin[0].version
        /// </summary>
        internal static string ___FlashVersionStringPeriodSeparated = "";
        internal static string ___appCodeName;
		internal static string ___appMinorVersion;
		internal static string  ___appName;
		internal static string  ___appVersion;
        internal static string  ___vendor;
        internal static string ___platform;
        internal static string ___systemLanguage;
        internal static string ___userLanguage;
        internal static string ___Language; // "en"
        internal static string ___Languages; // "en, ja_jp";
        internal static string ___browserLanguage;
        /// <summary>
        /// Internal use only
        /// </summary>
        internal static string ___browserKeyName;


        /// <summary>
        /// internal use only
        /// </summary>
        internal static string ___browserVersionShortName;

		private bool _cookieEnabled = true;
		private string _cpuClass ;
		private bool _onLine = true;
		private bool _javaEnabled = true;
		private bool _taintEnabled = false;
        internal bool ___standAlone = false;
		private string _DoNotTrack = "1";

        internal static bool ___msManipulationViewsEnabled = true;

		private bool _msManipulationViewsEnabled = false;
		private int _msMaxTouchPoints = 0;
		private bool _msPointerEnabled = true;
		private CHtmlSortedList _plugins = null;
		private CHtmlSortedList _mimeTypes = null;
        /// <summary>
        /// Case in-sensitve classid
        /// </summary>
		private CHtmlSortedList _classIDList = null;
        /// <summary>
        /// Firefox ___hasInner battery API.
        /// (To Increate Performance we shall only create this object instance it is accessed)
        /// </summary>
        private CHtmlBattery ___battery = null;
		private string _Product = "Gecko";
		private string _Version = "10.0";
		/// <summary>
		/// ---------------------------
		///		Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 1.0.3705; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E)
		/// </summary>
		internal static string ___userAgent = "Mozilla/4.0 (compatible)";

        internal static  System.Collections.Generic.SortedList<string, object> ___PluginsStaticList = new System.Collections.Generic.SortedList<string, object>(StringComparer.OrdinalIgnoreCase);
        internal static System.Collections.Generic.SortedList<string, object> ___MimeTypesStaticList = new System.Collections.Generic.SortedList<string, object>(StringComparer.OrdinalIgnoreCase);

        internal CHtmlCollection ___gamepads = new CHtmlCollection();


        internal CHtmlNavigatorGeoLocation ___geolocation = new CHtmlNavigatorGeoLocation();
        internal static bool ___is64BitProcess = (IntPtr.Size == 8);

        public CHtmlNavigator()
		{
            this.___multiversalClassType = IMutilversalObjectType.Navigator;



			bool ___IsUserAgentValueSet = false;


		   initUserAgentSring();



            if (string.IsNullOrEmpty(CHtmlNavigator.___Languages) == true)
            {



                string _strOSLangage = "";
				if (string.IsNullOrEmpty(CHtmlNavigator.___Languages) == false)
				{
					char[] csLanguages = CHtmlNavigator.___Languages.ToCharArray();
					int csLanguagesLen = csLanguages.Length;
					System.Text.StringBuilder sbLangTop = new System.Text.StringBuilder();
					for (int i = 0; i < csLanguagesLen; i++)
					{
						if (char.IsLetter(csLanguages[i]) || csLanguages[i] == '-' || csLanguages[i] == '_')
						{
							sbLangTop.Append(csLanguages[i]);
						}
						else
						{
							break;
						}
					}

					_strOSLangage = sbLangTop.ToString();
				}
                CHtmlNavigator.___browserLanguage = _strOSLangage;
                CHtmlNavigator.___userLanguage = _strOSLangage; ;
                CHtmlNavigator.___systemLanguage = _strOSLangage;
                CHtmlNavigator.___Language = _strOSLangage;
            }
			//this.browserLanguage = this.systemLanguage;
			//this._cpuClass = "x86";


			this._taintEnabled = false;
			this._onLine = true;
            CHtmlNavigator.___platform = "Win32";
			this._plugins = new CHtmlSortedList(StringComparer.OrdinalIgnoreCase);
            this._plugins.___multiversalClassType = IMutilversalObjectType.PluginArray;
			this._plugins.___CollectionType = CHtmlHTMLCollectionType.NavigatorPlugins;
			this._mimeTypes = new CHtmlSortedList(StringComparer.OrdinalIgnoreCase);
            this._mimeTypes.___multiversalClassType = IMutilversalObjectType.MimeTypeArray;
			this._mimeTypes.___CollectionType = CHtmlHTMLCollectionType.NavigatorMimeTypes;
			this._classIDList = new CHtmlSortedList(StringComparer.OrdinalIgnoreCase );
            this._classIDList.___multiversalClassType = IMutilversalObjectType.Unkown;
			this._classIDList.___CollectionType = CHtmlHTMLCollectionType.NavigatorIDList;


		}
		~CHtmlNavigator()
		{
			this.CleanUp();
		}

        private static string ___convertOSVersionIfNesserary(string ___strOSVersion)
        {
            if (___strOSVersion.StartsWith("Windows NT", StringComparison.Ordinal))
            {
                string strOSVersion = ___strOSVersion.Substring(11);

                switch (___getMajorAndMinorVersionString(strOSVersion))
                {
                    case "6.2": // Windows 6.2 should returns Windows 10.0
                        return "Windows NT 10.0";
                    default:
                        return ___strOSVersion;
                }

            }
            return ___strOSVersion;
        }
        private static string ___getMajorAndMinorVersionString(string ___strOSVersion)
        {
            char[] csVersion = ___strOSVersion.ToCharArray();
            int csLen = csVersion.Length;
            System.Text.StringBuilder sbVersionBuilder = new System.Text.StringBuilder();
            int ___periodCount = 0;
            for (int i = 0; i < csLen; i++)
            {
                if (csVersion[i] == '.')
                {
                    ___periodCount++;
                    if (___periodCount >= 2)
                    {
                        break;
                    }
                }

                sbVersionBuilder.Append(csVersion[i]);
            }
            return sbVersionBuilder.ToString();
        }
		
		public bool javaEnabled()
		{
			//commonLog.LogEntry("Navigator javaEnabled() : {0} ", this._javaEnabled);
			return this._javaEnabled;
		}
        /// <summary>
        /// The navigator.sendBeacon() method can be used to asynchronously transfer small HTTP data from the User Agent to a web server.
        /// currently Chrome only feature.
        /// </summary>
        /// <param name="___objUrl">Url To Send</param>
        /// <param name="___objData">Transfer Data</param>
        public void sendBeacon(object ___objUrl, object ___objData)
        {
            if (commonLog.LoggingEnabled)
            {
               commonLog.LogEntry("TODO: entering {0}.sendbeacon({1}, {2})", this, ___objUrl, ___objData);
            }
        }
        public CHtmlBattery battery
        {
            get { return this.____createBatteryObjectInstance(); }
        }
        /// <summary>
        /// getBattery() api will create Promise Object
        /// </summary>
        /// <returns></returns>
        public CHtmlPromisingFunctionObject  getBattery()
        {
            if (commonLog.LoggingEnabled)
            {
               commonLog.LogEntry("calling {0}.getBattery()", this);
            }
            this.____createBatteryObjectInstance();
            CHtmlPromisingFunctionObject ___promiseBattery = new CHtmlPromisingFunctionObject();
            ___promiseBattery.____functionOrigin = "battery";
            ___promiseBattery.___originalObjectWeakReference = new WeakReference(this.___battery, false);
            return ___promiseBattery;
        }

        private CHtmlBattery ____createBatteryObjectInstance()
        {
            if (this.___battery == null)
            {
                this.___battery = new CHtmlBattery();
            }
            return this.___battery;
        }

		private void vibrate_inner(object p1, object p2, object p3)
		{


		}
		public void vibrate(object p1, object p2, object p3)
		{
			this.vibrate_inner(p1, p2, p3);

		}
		public void vibrate(object p1, object p2)
		{
			this.vibrate_inner(p1, p2, null);
		}
		public void vibrate(object p1)
		{
			this.vibrate_inner(p1, null, null);
		}
		public void vibrate()
		{
			this.vibrate_inner(null, null, null);
		}
        public bool msManipulationViewsEnabled
        {
            get {return  CHtmlNavigator.___msManipulationViewsEnabled; }
        }
		private void CleanUp()
		{
			if(this._classIDList != null)
			{
				try
				{
					this._classIDList.Clear();
					this._classIDList = null;
				}
				catch{}
			}

			if(this._mimeTypes != null)
			{
				this._mimeTypes.Clear();
				this._mimeTypes = null;
			}
			if(this._plugins != null)
			{
				this._plugins.Clear();
				this._plugins = null;
			}
		}
		
		public bool hasOwnProperty(object _oname)
		{

            return false;
		}


		private static string ___multihtmlcraftAssembyVersion = ___multihtmlcraftAssembyVersionString();


        private static string ___multihtmlcraftAssembyVersionString()
        {
			var assembly = typeof(CHtmlNavigator).Assembly;

			System.Reflection.AssemblyName assemblyName = assembly.GetName();
			System.Version version = assemblyName.Version;
			return version.ToString();
        }
		/// <summary>
		/// Create User Agent String
		/// </summary>
		private static void initUserAgentSring()
		{
			string platformToken = ___buildPlatformToken();
			___userAgent = $"'Chorome/1.0 ({platformToken}) MultiHtmlCraft {___multihtmlcraftAssembyVersion}  (KHTML, like Gecko) Chorome/1.0.0.0 Safari/537.36'";
			if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
			{ 
				commonLog.LogEntry($"navigator.userAgent : {___userAgent}");
	     	}

		}
        private static string ___buildPlatformToken()
        {
            string osPart;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var ver = Environment.OSVersion.Version;
                osPart = $"Windows NT {ver.Major}.{ver.Minor}";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // UA 上は Macintosh を使うことが多い
                osPart = "Macintosh";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // 多くの UA では X11 などを表記する
                osPart = "X11";
            }
            else
            {
                osPart = RuntimeInformation.OSDescription ?? "Unknown";
            }

            string archToken = RuntimeInformation.OSArchitecture switch
            {
                Architecture.X64 => "x64",
                Architecture.X86 => "x86",
                Architecture.Arm => "arm",
                Architecture.Arm64 => "arm64",
                _ => RuntimeInformation.OSArchitecture.ToString()
            };

            // Windows の場合、64bit OS なら Win64 トークンを追加（UA の慣例）
            string win64 = "";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && Environment.Is64BitOperatingSystem)
            {
                win64 = "Win64; ";
            }

            // 例: "Windows NT 10.0; Win64; x64"
            var token = $"{osPart}; {win64}{archToken}";
            // 不要な二重セミコロンができることを防止
            return token.Replace(";  ", "; ");
        }
        /// <summary>
        /// Convert Flah Version "10,7,008,1" to "10.7 r008"
        /// </summary>
        /// <param name="__s"></param>
        /// <returns></returns>
        private string ___GetFlashVersionFromString(string __s)
		{
			string[] spValues = __s.Split(new char[]{',', '.'});
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			int __AddCount = 0;
			foreach(string es in spValues)
			{
				if(es.Length  != 0)
				{
					if(__AddCount == 1)
					{
						sb.Append(".");
					} 
					else if(__AddCount == 2)
					{
						sb.Append(" r");
					}
					sb.Append(es);
					__AddCount ++;
					if(__AddCount >= 3)
					{
						break;
					}
				}
			}
			return sb.ToString();

		}

		#region Property
        public bool pointerEnabled
        {
            get {return  this._msPointerEnabled; }
        }
        public bool msPointerEnabled
        {
            get { return this._msPointerEnabled; }
        }
		public string userAgent
		{
            get { return commonHTML.___convertNullToEmpty(CHtmlNavigator.___userAgent); }
		}
		public string appVersion
		{
			get{return commonHTML.___convertNullToEmpty(CHtmlNavigator.___appVersion);}
		}
        /// <summary>
        /// FullScreen Mode or not
        /// </summary>
        public bool standAlone
        {
            get { return this.___standAlone; }
        }
		public string appName
		{
            get { return commonHTML.___convertNullToEmpty(CHtmlNavigator.___appName); }
		}
        public CHtmlNavigatorGeoLocation geolocation
        {
            get
            {
                return this.___geolocation;
            }
        }
        public string language
        {
            get { return commonHTML.___convertNullToEmpty(CHtmlNavigator.___Language); }
        }
        public string languages
        {
            get { return commonHTML.___convertNullToEmpty(CHtmlNavigator.___Languages); }
        }

        public string systemLanguage
		{
            get { return commonHTML.___convertNullToEmpty(CHtmlNavigator.___systemLanguage); }
		}
		public string browserLanguage
		{
            get { return commonHTML.___convertNullToEmpty(CHtmlNavigator.___browserLanguage); }
		}
		public bool taintEnabled
		{
			get{return this._taintEnabled;}
		}
		public string platform
		{
            get { return commonHTML.___convertNullToEmpty(CHtmlNavigator.___platform); }
		}
        public CHtmlCollection gamepads
        {
            get { return this.___gamepads; }
        }
        public CHtmlCollection getGamepads()
        {
            return this.___gamepads;
        }
		public bool onLine
		{
			get{return this._onLine;}
		}
		public CHtmlSortedList plugins
		{
			get{return this._plugins;}
		}
		public CHtmlSortedList mimeTypes
		{
			get{return this._mimeTypes;}
		}
		/// <summary>
		/// Keys are lower case not case sensitive
		/// </summary>
		public CHtmlSortedList classIDList
		{
			get{return this._classIDList;}
		}
		#endregion
		#region IPropertBox メンバ


		public object ___getPropertyByName(string ___name)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("calling getPropertyByName for {0} {1} {2}", this.GetType(), this, ___name);
            }
            switch (___name)
			{
                case "battery":
                    return this.____createBatteryObjectInstance();
                case "standAlone":
                case "standalone":
                    return this.___standAlone;
                case "msManipulationViewsEnabled":
                    return ___msManipulationViewsEnabled;
                case "gamepads":
                case "gamePads":
                case "webkitGamepads":
                case "mozGamepads":
                case "msGamepads":
                case "khtmlGamepads":
                    return this.___gamepads;
				case "language":
					return commonHTML.___convertNullToEmpty(CHtmlNavigator.___Language);
                case "languages":
                    return commonHTML.___convertNullToEmpty(CHtmlNavigator.___Languages);
                case "version":
                case "Version":
					return commonHTML.___convertNullToEmpty(this._Version);
				case "appversion":
                case "appVersion":
                    return commonHTML.___convertNullToEmpty(CHtmlNavigator.___appVersion);
				case "appminorversion":
                case "appMinorversion":
                    return commonHTML.___convertNullToEmpty(CHtmlNavigator.___appMinorVersion);
				case "product":
					return commonHTML.___convertNullToEmpty(this._Product);
				case "msmaxtouchpoints":
                case "msMaxTouchPoints":
				case "maxtouchpoints":
                case "maxTouchPoints":
					return this._msMaxTouchPoints;
				case "donottrack":
                case "doNotTrack":
				case "msdonottrack":
					return commonHTML.___convertNullToEmpty(this._DoNotTrack);
				case "pointerenabled":
                case "pointerEnabled":
				case "mspointerenabled":
                case "msPointerEnabled":
					return this._msPointerEnabled;
				case "taintenabled":
                case "tainTenabled":
					return this._taintEnabled;
				case "cookieenabled":
                case "cookieEnabled":
					return this._cookieEnabled;
				case "platform":
					return commonHTML.___convertNullToEmpty(CHtmlNavigator.___platform);
				case "useragent":
                case "userAgent":
                    return commonHTML.___convertNullToEmpty(CHtmlNavigator.___userAgent);
				case "cpuclass":
                case "cpuClass":
					return commonHTML.___convertNullToEmpty(this._cpuClass);
				case "userlanguage":
                case "userLanguage":
				case "systemlanguage":
                case "systemLanguage":
                    return commonHTML.___convertNullToEmpty(CHtmlNavigator.___userLanguage);
				case "browserlanguage":
                case "browserLanguage":
                    return commonHTML.___convertNullToEmpty(CHtmlNavigator.___browserLanguage);
				case "appname":
                case "appName":
                    return commonHTML.___convertNullToEmpty(CHtmlNavigator.___appName);
				case "msmanipulationviewsenabled":
				case "manipulationviewsenabled":
					return _msManipulationViewsEnabled;
				case "mimetypes":
                case "mimeTypes":
					return this._mimeTypes;
				case "plugins":
					return this._plugins;
				case "vendor":
                case "Vendor":
                    return commonHTML.___convertNullToEmpty(CHtmlNavigator.___vendor);

                case "oscpu":
                case "osCpu":
                    return System.Environment.OSVersion.ToString() + ";" + "x64";

                case "loadpurpose": // this is should only in safari.
                case "loadPurpose":
                    return null;
                case "productSub":
                    return null; // IE returns null.
                case "onLine":
                case "online":
                    return this._onLine;
                case "geolocation":
                    return this.___geolocation;
				default:
					
						if(this.___properties.ContainsKey(___name))
						{
							return this.___properties[___name];
						}
					
					break;
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed",this.GetType(), this, ___name);
			}
			return null;
		}
        public void getUserMedia(object object_constraints, object object_successCallback, object object_errorCallback)
        {
            this.___getUserMedia_Inner(object_constraints, object_successCallback, object_errorCallback);
        }
        public void msGetUserMedia(object object_constraints, object object_successCallback, object object_errorCallback)
        {
            this.___getUserMedia_Inner(object_constraints, object_successCallback, object_errorCallback);
        }
        public void mozGetUserMedia(object object_constraints, object object_successCallback, object object_errorCallback)
        {
            this.___getUserMedia_Inner(object_constraints, object_successCallback, object_errorCallback);
        }
        public void webkitGetUserMedia(object object_constraints, object object_successCallback, object object_errorCallback)
        {
            this.___getUserMedia_Inner(object_constraints, object_successCallback, object_errorCallback);
        }
        internal void ___getUserMedia_Inner(object object_constraints, object object_successCallback, object object_errorCallback)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: calling {0}.getUserMedia({1}, {2}. {3})", this, object_constraints, object_successCallback, object_errorCallback);
            }
        }

		public void ___setPropertyByName(string ___name, object val)
		{
	
		}
		public void ___setPropertyByIndex(int ___index, object val)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("SetPropertyValueIndex for {0} {1} \"{2}\" = {3} failed",this.GetType(), this, ___index, val);
			}
			
		}
		public object ___getPropertyByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed",this.GetType(), this, ___index);
			}
			return null;
		}

		public bool ___hasPropertyByName(string ___name)
		{
			return true;

		}
		public bool ___hasPropertyByIndex(int ___index)
		{
			return true;
		}
		public object ___common_object_clone()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("x__Clone {0} {1} called",this.GetType(), this);
			}
			return this;
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
        public override string ToString()
        {
            return "[object " + base.___multiversalClassType.ToString() + "]";
        }
        public IMutilversalObjectType multiversalObjectType
        {
            get { return base.___multiversalClassType; }
        }

        #endregion


        #region IDyamicMetaObjectProvider support to get and set properties
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlNavigator>(parameter, this);
        }
        public object GetDynamicMember(string name)
        {
            object objValue = null;
            this.___properties.TryGetValue(name, out objValue);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.GetDynamicMember({1} returns : {2}", this, name, objValue);
            }
            return objValue;
        }
        public void SetDynamicMember(string name, object value)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.SettDynamicMember({1} is called value: {2}", this, name, value);
            }
            this.___properties[name] = value;
        }
        public IEnumerable<string> GetDynamicMemberNames()
        {
            return this.___properties.Keys;
        }
        #endregion
    }
}
