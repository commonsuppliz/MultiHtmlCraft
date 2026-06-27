using System;
using System.Runtime.InteropServices;
using MultiHtmlCraft.Interfaces;


namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// CHtmlWindowScreen represents Screen Infomation to be drawn.
    /// </summary>
    public class CHtmlWindowScreen : CHtmlNode, ICommonObjectInterface
    {


        public CHtmlWindowScreen()
        {

            if (CHtmlWindowScreen.___IsScreenDefaultParameterAssinged == false)
            {
                try
                {
                    /*
                    CHtmlWindowScreen.___availHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                    CHtmlWindowScreen.___availWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
                    CHtmlWindowScreen.___updateInterval = 30;
                    CHtmlWindowScreen.___fontSmoothingEnabled = true;
                    CHtmlWindowScreen.___width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                    CHtmlWindowScreen.___height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                    CHtmlWindowScreen.___pixelDepth = 32;
                    CHtmlWindowScreen.___colorDepth = 32;
                    CHtmlWindowScreen.___bufferDepth = 32;
                    CHtmlWindowScreen.___logicalXDPI = 96;
                    CHtmlWindowScreen.___logicalYDPI = 96;
                    CHtmlWindowScreen.___deviceXDPI = 96;
                    CHtmlWindowScreen.___deviceYDPI = 96;
                    CHtmlWindowScreen.___systemXDPI = 96;
                    CHtmlWindowScreen.___systemYDPI = 96;
                    */

                }
                catch { }
                CHtmlWindowScreen.___IsScreenDefaultParameterAssinged = true;
                this.___screenOrientation = new CHtmlWindowScreenOrientation();


            }

        }
        internal static bool ___IsScreenDefaultParameterAssinged = false;
        internal CHtmlWindowScreenOrientation ___screenOrientation = null;
        public CHtmlWindowScreenOrientation orientation
        {
            get { return ___screenOrientation; }
        }
        public CHtmlWindowScreenOrientation mozOrientation
        {
            get { return ___screenOrientation; }
        }
        public CHtmlWindowScreenOrientation msOrientation
        {
            get { return ___screenOrientation; }
        }
        public CHtmlWindowScreenOrientation webkitOrientation
        {
            get { return ___screenOrientation; }
        }
        /// <summary>
        /// Retrieves the height of the working area of the system's screen, excluding the MicrosoftR WindowsR taskbar.
        /// </summary>
        internal static double ___availHeight;
        public double availHeight
        {
            get { return CHtmlWindowScreen.___availHeight; }

        }
        /// <summary>
        /// Retrieves the width of the working area of the system's screen, excluding the Windows taskbar. 
        /// </summary>
        internal static double ___availWidth;
        public double availWidth
        {
            get { return CHtmlWindowScreen.___availWidth; }

        }
        /// <summary>
        /// Sets or retrieves the number of bits per pixel used for colors in the off-screen bitmap buffer. 
        /// </summary>
        internal static double ___bufferDepth;
        public double bufferDepth
        {
            get { return CHtmlWindowScreen.___bufferDepth; }

        }
        /// <summary>
        /// Retrieves the number of bits per pixel used for colors on the destination device or buffer. 
        /// </summary>
        internal static double ___colorDepth;
        public double colorDepth
        {
            get { return CHtmlWindowScreen.___colorDepth; }

        }
        /// <summary>
        /// Retrieves the actual number of horizontal dots per inch (DPI) of the system's screen.
        /// </summary>
        internal static double ___deviceXDPI;
        public double deviceXDPI
        {
            get
            {
                return CHtmlWindowScreen.___deviceXDPI;
            }

        }
        /// <summary>
        /// Retrieves the actual number of vertical dots per inch (DPI) of the system's screen.
        /// </summary>
        internal static double ___deviceYDPI;
        public double deviceYDPI
        {
            get { return CHtmlWindowScreen.___deviceYDPI; }

        }
        /// <summary>
        /// Retrieves the actual number of vertical dots per inch (DPI) of the system's screen.
        /// </summary>
        internal static double ___systemYDPI;
        public double systemYDPI
        {
            get { return CHtmlWindowScreen.___systemYDPI; }

        }
        /// <summary>
        /// Retrieves the actual number of horizontal dots per inch (DPI) of the system's screen.
        /// </summary>
        internal static double ___systemXDPI;
        public double systemXDPI
        {
            get
            {
                return CHtmlWindowScreen.___systemXDPI;
            }

        }


        /// <summary>
        /// Retrieves whether the user ___hasInner enabled font smoothing in the Display control panel.
        /// </summary>
        internal static bool ___fontSmoothingEnabled = false;
        public bool fontSmoothingEnabled
        {
            get { return CHtmlWindowScreen.___fontSmoothingEnabled; }

        }
        /// <summary>
        /// Retrieves the vertical resolution of the screen.
        /// </summary>
        internal static double ___height;
        public double height
        {
            get { return CHtmlWindowScreen.___height; }

        }
        /// <summary>
        /// Retrieves the normal number of horizontal dots per inch (DPI) of the system's screen.
        /// </summary>
        internal static double ___logicalXDPI;
        public double logicalXDPI
        {
            get { return CHtmlWindowScreen.___logicalXDPI; }

        }

        /// <summary>
        /// Retrieves the normal number of vertical dots per inch (DPI) of the system's screen.
        /// </summary>
        internal static double ___logicalYDPI;
        public double logicalYDPI
        {
            get { return CHtmlWindowScreen.___logicalYDPI; }

        }

        /// <summary>
        /// Sets or retrieves the update interval for the screen. 
        /// </summary>
        internal static double ___updateInterval;
        public double updateInterval
        {
            get { return ___updateInterval; }

        }
        /// <summary>
        /// Retrieves the horizontal resolution of the screen.
        /// </summary>
        internal static double ___width;
        public double width
        {
            get { return ___width; }

        }
        internal static double ___pixelDepth;
        public double pixelDepth
        {
            get { return ___pixelDepth; }
        }


        public bool hasOwnProperty(object _oname)
        {

            return false;
        }

        #region IPropertBox メンバ

        public void ___setPropertyByName(string ___name, object ___val)
        {

            this.___properties[___name] = ___val;
        }

        public bool ___hasPropertyByName(string ___name)
        {

            return false;

        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }

        public void ___setPropertyByIndex(int ___index, object val)
        {

        }
        public object ___getPropertyByIndex(int ___index)
        {

            return null;
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

        public object ___getPropertyByName(string ___name)
        {
            switch (___name)
            {
                case "orientation":
                case "mozOrientation":
                case "msOrientation":
                case "webkitOrientation":
                    return this.___screenOrientation;

                case "width":
                    return ___width;
                case "height":
                    return ___height;
                case "logicalxdpi":
                case "logicalXDPI":
                    return ___logicalXDPI;
                case "logicalydpi":
                case "logicalYDPI":
                    return ___logicalYDPI;
                case "updateinterval":
                case "updateInterval":
                    return ___updateInterval;
                case "colordepth":
                case "colorDepth":
                    return ___colorDepth;
                case "availwidth":
                case "availWidth":
                    return ___availWidth;
                case "availheight":
                case "availHeight":
                    return ___availHeight;
                case "bufferdepth":
                case "bufferDepth":
                    return ___bufferDepth;
                case "fontsmoothingenabled":
                case "fontSmoothingEnabled":
                    return ___fontSmoothingEnabled;
                case "pixeldepth":
                case "pixelDepth":
                    return ___pixelDepth;
                case "devicexdpi":
                case "deviceXDPI":
                    return ___deviceXDPI;
                case "deviceydpi":
                case "deviceYDPI":
                    return ___deviceXDPI;
                case "systemxdpi":
                case "systemXDPI":
                    return ___systemXDPI;
                case "systemydpi":
                case "systemYDPI":
                    return ___systemXDPI;
                case "left":
                case "availleft":
                case "availLeft":
                    return (double)0;
                case "top":
                case "availtop":
                case "availTop":
                    return (double)0;
                case "prototype":
                case "__proto__":
                    return this.prototype;
                default:
                    break;
            }
            object objProp = null;
            if (this.___properties.TryGetValue(___name, out objProp) == true)
            {
                return objProp;
            }

            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
            }

            return null;
        }
        public object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public void ___deleteByIndex(int ___index)
        {

        }
        public void ___deleteByName(string ___name)
        {


        }
        public object[] ___getByIds()
        {

            return null;

        }
        public string ___getClassName()
        {

            return "Screen";
        }
        public object ___getDefaultValue()
        {

            return null;
        }
        public object ___getParentScope()
        {

            return null;
        }
        public void ___setParentScope(object ___object)
        {

        }
        public object ___getProtoType()
        {
            return null;

        }
        public bool ___hasInstance(object ___object)
        {

            return false;
        }
        public bool ___instanceEquals(object ___object)
        {
            return false;

        }
        public void ___setProtoType(object ___object)
        {

        }




        #endregion
    }
}
