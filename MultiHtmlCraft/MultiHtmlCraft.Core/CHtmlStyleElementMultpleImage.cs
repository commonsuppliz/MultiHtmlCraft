using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// This class stores image informatin (ex, url, background-position, background-align etc) for CSS3
    /// </summary>
    public sealed class CHtmlStyleElementMultpleImageData
    {
        public CSSMultipleImageDataType ImageType = CSSMultipleImageDataType.Image;
        /// <summary>
        /// Background Image String from CSS
        /// </summary>
        public string background_image_origin =null;
        /// <summary>
        /// Composed Full Url for background Image
        /// </summary>
        public string background_image_fullUrl = null;

        /// <summary>
        /// Weak Reference for System.Drawing.Image object of Background Image
        /// </summary>
        public System.WeakReference backgroundImage_WeakReference = null;
        /// <summary>
        /// ListStyle String from CSS
        /// </summary>
        public string liststyle_image_origin = null;
        /// <summary>
        /// Composed Full Url
        /// </summary>
        public string liststyle_image_fullUrl = null;
        /// <summary>
        /// Weak Reference for System.Drawing.Image object of List Style Image
        /// </summary>
        public System.WeakReference liststyleImage_WeakReference = null;
        /// <summary>
        /// Image Gradation Class if any
        /// </summary>
        public CHtmlWebGradation Gradation = null;

        /// <summary>
        /// Image Repeat Type
        /// </summary>
        public CSSImageRepeatType ImageRepeatType = CSSImageRepeatType.unkown;

        public string backgroundRepeatString = null;

        public string backgroundPositionString = null;

        public string backgroundPosition_X_String = null;

        public string backgroundPosition_Y_String = null;



        /// <summary>
        /// Computed Value for Position X (0.0 - 1.0) represented by percentage. Default 0. if it is percentage
        /// or it may be actual value.
        /// </summary>
        public double backgroundPosition_X_ComputedValue = 0;

        public bool isBackgroundPosition_X_ValuePerentage = false;

        /// <summary>
        /// Computed Value for Position Y (0.0 - 1.0) represented by percentage. Default 0.
        /// Default 0. if it is percentage or it may be actual value.
        /// </summary>
        public double backgroundPosition_Y_ComputedValue = 0;

        public bool isBackgroundPosition_Y_ValuePerentage = false;

        public string backgroundColorString = null;
        public ColorSpec backgroundColorComputedValue = new ColorSpec(0, 0, 0, 255);

        /// <summary>
        /// Flag to draw background Color other than first applears.
        /// </summary>
        public bool EnableDrawBackgroundColorAlways = false;

        public string backgroundAttatchmentString = null;

        public string backgroundSizeString = null;

        public string backgroundSize_X_String = null;

        public string backgroundSize_Y_String = null;

        public double backgroundSize_X_ComputedValue = 0;

        public double backgroundSize_Y_ComputedValue = 0;
        public CSSBackgroundSizeType backgroundSizeWidthComputedType = CSSBackgroundSizeType.NotSet;
        public CSSBackgroundSizeType backgroundSizeHeightComputedType = CSSBackgroundSizeType.NotSet;
        
        public bool isBackgroundSize_X_ValuePercentage = false;

        public bool isBackgroundSize_Y_ValuePercentage = false;
        public bool isBackgroundColorSpecified = false;

        public void ___bindMultipleImageDataFromSplitString(ref string[] spLeft, CHtmlCSSStyleSheet stylePart)
        {
            int _NumberCount = 0;
            string el = null;
			int spLeftLen = spLeft.Length;
            for (int i = 0; i < spLeftLen; i++)
            {
                el = spLeft[i];

                if (el != null && el.Length != 0)
                {
                    if (el[0] == '#')
                    {

                        this.backgroundColorString = el;
                        this.backgroundColorComputedValue = commonHTML.GetColorSpecFromHTMLColorExtend(el);
                        this.isBackgroundColorSpecified = true;
                        //stylePart.StyleLists["background-color"] = el;
                        //stylePart.setAttributeInner("background-color", el, true, true);
                        continue;
                    }
                    if (el.StartsWith("url(", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        string _url = null;
                        if (string.IsNullOrEmpty(stylePart.___ImageUrlHint) == false)
                        {
                            _url = commonHTML.GetUrlQuotedUrlToNormalUrl(el, stylePart.___ImageUrlHint);
                        }
                        else
                        {
                            string strBaseUrlInstread = null;
                            if (stylePart.___ownerElementWeakReference != null)
                            {
                                CHtmlElement __ownerElement = stylePart.___ownerElementWeakReference.Target as CHtmlElement;
                                if (__ownerElement != null && __ownerElement.___Document != null)
                                {
                                    if (string.IsNullOrEmpty(__ownerElement.___Document.___baseUrl) == false)
                                    {
                                        strBaseUrlInstread = string.Copy(__ownerElement.___Document.___baseUrl);
                                    }
                                    else if (string.IsNullOrEmpty(__ownerElement.___Document.___URL) == false)
                                    {
                                        strBaseUrlInstread = string.Copy(__ownerElement.___Document.___URL);
                                    }
                                }
                            }
                            _url = commonHTML.GetUrlQuotedUrlToNormalUrl(el, strBaseUrlInstread);
                        }

                        this.background_image_fullUrl = _url;
                        this.ImageType = CSSMultipleImageDataType.Image;
                        continue;
                    }
                    int gradationPos = -1;
                    if (el.Length > 12)
                    {
                        if (el.Length > 30)
                        {
                            gradationPos = el.IndexOf("gradient(", 0, 30, StringComparison.OrdinalIgnoreCase);
                        }
                        else
                        {
                            gradationPos = el.IndexOf("gradient(", StringComparison.OrdinalIgnoreCase);
                        }
                    }
                    if (gradationPos > -1)
                    {

                        this.Gradation = commonHTML.CreateGradationData(el, stylePart.___HTMLTagRemUnitSize);
                        this.ImageType = CSSMultipleImageDataType.Gradation;
                        continue;
                    }
                    if (el[0] == 'r' || el[0] == 'h')
                    {
                        if ((string.CompareOrdinal(el, 0, "rgb(", 0, 4) == 0) || (string.CompareOrdinal(el, 0, "rgba(", 0, 5) == 0) || (string.CompareOrdinal(el, 0, "hsl(", 0, 4) == 0) || (string.CompareOrdinal(el, 0, "hsla(", 0, 5) == 0) || el.StartsWith("rrggbb(", StringComparison.Ordinal))
                        {
                            this.backgroundColorString = el;
                            this.backgroundColorComputedValue = commonHTML.GetColorSpecFromHTMLColorExtend(el);
                            this.isBackgroundColorSpecified = true;
                            continue;
                        }
                    }

                    if (el.IndexOf('%') > -1 || char.IsNumber(el[0]) || el[0] == '-')
                    {
                        _NumberCount++;
                        if (_NumberCount == 1)
                        {
                            this.backgroundPosition_X_String = el;
                        }
                        else if (_NumberCount == 2)
                        {
                            this.backgroundPosition_Y_String = el;
                        }
                        continue;
                    }
                    else if (commonHTML.CHtmlHTMLColorNamesDictionary.ContainsKey(el) == true)
                    {
                        // ----------------------------------------------------------------
                        // [NASA CSS Workaround]
                        // background: #555 url("adfafdasfadfas") white
                        // we like to choose #555. avoid override the good color.
                        // ----------------------------------------------------------------
                        if (string.Equals(el,"transparent", StringComparison.InvariantCultureIgnoreCase) == true || string.Equals(el,"inherit", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            continue;
                        }
                        this.backgroundColorString = el;
                        ColorSpec namedColor = ColorSpec.Transparent;
                        if (commonHTML.CHtmlHTMLColorSpecNamesDictionary.TryGetValue(el, out namedColor) == true)
                        {

                            this.backgroundColorComputedValue = namedColor;
                            this.isBackgroundColorSpecified = true;
                        }
                        else
                        {
                            this.backgroundColorComputedValue = commonHTML.GetColorSpecFromHTMLColorExtend(el);
                            this.isBackgroundColorSpecified = true;
                        }
                        //stylePart.BackgroundColor = el;
                        //stylePart.StyleLists["background-color"] = el;

                        continue;
                    }
                    else if (el.Length > 1 && el[0] == '#') // no "#"(1 char)
                    {
                        this.backgroundColorString = el;
                        this.backgroundColorComputedValue = commonHTML.GetColorSpecFromHTMLColorExtend(el);
                        this.isBackgroundColorSpecified = true;
                        continue;
                    }


                    if (el.IndexOf('.') > -1 || el.IndexOf('/') > -1)
                    {
                        this.background_image_origin = el;

                        continue;
                    }
                    switch (el)
                    {
                        case "scroll":
                        case "fixed":
                        case "fix":
                            this.backgroundAttatchmentString = el;
                            //stylePart.StyleLists["background-attachment"] = elLow;

                            continue;
                        case "none":
                        case "None":
                            {
                                if (i == 0)
                                {
                                    this.background_image_origin = null;
                                    this.background_image_fullUrl = null;
                                }
                                else
                                {
                                    this.background_image_origin = null;
                                    this.background_image_fullUrl = null;
                                    this.backgroundRepeatString = "no-repeat";
                                    this.___analyzeBackgroundRepeatString();
                                }
                                continue;
                            }
                        case "no-repeat":
                        case "No-Repeat":
                        case "repeat":
                        case "Repeat":
                        case "repeat-x":
                        case "repeat-X":
                        case "repeat-y":
                        case "repeat-Y":
                        case "repeatx":
                        case "repeaty":
                            {
                                this.backgroundRepeatString = el;
                                //stylePart.StyleLists["background-repeat"] = elLow;
                                this.___analyzeBackgroundRepeatString();

                                continue;
                            }
                        case "center":
                            _NumberCount++;
                            if (_NumberCount == 1)
                            {
                                this.backgroundPosition_X_String = el;
                                //stylePart.StyleLists["background-position-x"] = elLow;

                            }
                            else
                            {
                                this.backgroundPosition_Y_String = el;

                            }
                            continue;
                        case "left":
                            this.backgroundPosition_X_String = "left";

                            _NumberCount = 1;
                            continue;
                        case "top":
                            this.backgroundPosition_Y_String = "top";
                            //stylePart.StyleLists["background-position-y"] = "top";

                            continue;
                        case "bottom":
                            this.backgroundPosition_Y_String = "bottom";
                            //stylePart.StyleLists["background-position-y"] = "bottom";

                            continue;
                        case "right":
                            this.backgroundPosition_X_String = "right";

                            _NumberCount = 1;
                            continue;
                    }
                    //commonLog.LogEntry("Do not know how to set {0}", el);
                }
            }


        }
        internal void ___analyzeBackgroundRepeatString()
        {
            if (string.IsNullOrEmpty(this.backgroundRepeatString) == false)
            {
                switch (this.backgroundRepeatString)
                {
                    case "repeat":
                    case "Repeat":
                        this.ImageRepeatType = CSSImageRepeatType.repeat;
                        break;
                    case "repeat-x":
                    case "repeat-X":
                    case "repeatX":
                    case "repeatx":
                        this.ImageRepeatType = CSSImageRepeatType.repeatX;
                        break;
                    case "repeat-y":
                    case "repeat-Y" :
                    case "repeatY":
                    case "repeaty":
                        this.ImageRepeatType = CSSImageRepeatType.repeatY;
                        break;
                    case "none":
                    case "repeat-none":
                    case "repeat-no":
                    case "no-repeat":
                    case "norepeat":
                    case "non-repeat":
                        this.ImageRepeatType = CSSImageRepeatType.norepeat;
                        break;
                    default:
                        this.ImageRepeatType = CSSImageRepeatType.norepeat;
                        break;
                }
            }
            else
            {
                this.ImageRepeatType = CSSImageRepeatType.norepeat;
            }
        }
        internal void ___analyzeBackgroundPositionString(CHtmlElement ___elem)
        {
            int ___ExistsXYCount = 0;
            if (string.IsNullOrEmpty(this.backgroundPosition_X_String) == false)
            {
                this.___analyzeBackgroundPositionXYString(this.backgroundPosition_X_String, ___elem, true);
                ___ExistsXYCount++;
            }
            if (string.IsNullOrEmpty(this.backgroundPosition_Y_String) == false)
            {
                this.___analyzeBackgroundPositionXYString(this.backgroundPosition_Y_String, ___elem, false);
                ___ExistsXYCount++;
            }
            if (___ExistsXYCount == 2)
            {
                return;

            }
            if (string.IsNullOrEmpty(this.backgroundPositionString) == false)
            {
                string[] strValue = new string[2];

                int pos = this.backgroundPositionString.IndexOfAny(commonHTML.CharSpaceCrLfTabZentakuSpace);
                int ValueCount = 0;
                if (pos > -1)
                {
                    strValue[0] = this.backgroundPositionString.Substring(0, pos);
                    strValue[1] = this.backgroundPositionString.Substring(pos);
                    ValueCount = 2;
                }
                else
                {
                    strValue[0] = this.backgroundPositionString;
                    ValueCount = 1;
                }
                for (int i = 0; i < ValueCount; i++)
                {
                    string s = strValue[i];
                    switch (s)
                    {
                        case "bottom":
                            this.backgroundPosition_Y_String = s;
                            break;
                        case "top":
                            this.backgroundPosition_Y_String = s;
                            break;
                        case "left":
                            this.backgroundPosition_X_String = s;
                            break;
                        case "right":
                            this.backgroundPosition_X_String = s;
                            break;
                        case "middle":
                        case "center":
                            if (string.IsNullOrEmpty(this.backgroundPosition_X_String) == true)
                            {
                                this.backgroundPosition_X_String = s;
                                this.___analyzeBackgroundPositionXYString(this.backgroundPosition_X_String, ___elem, true);
                            }
                            else if (string.IsNullOrEmpty(this.backgroundPosition_Y_String) == true)
                            {
                                this.backgroundPosition_Y_String = s;
                                this.___analyzeBackgroundPositionXYString(this.backgroundPosition_Y_String, ___elem,false);
                            }
                            break;
                        default:
                            if (string.IsNullOrEmpty(this.backgroundPosition_X_String) == true)
                            {
                                this.backgroundPosition_X_String = s;
                                this.___analyzeBackgroundPositionXYString(this.backgroundPosition_X_String, ___elem, true);
                            }
                            else if (string.IsNullOrEmpty(this.backgroundPosition_Y_String) == true)
                            {
                                this.backgroundPosition_Y_String = s;
                                this.___analyzeBackgroundPositionXYString(this.backgroundPosition_Y_String, ___elem, false);
                            }
                            break;
                    }
                }
            }
            else
            {
                this.backgroundPosition_Y_String = null;
                this.backgroundPosition_X_String = null;
            }
        }
        public void ___analyzeBackgroundPositionXYString(string s, CHtmlElement ___elem, bool IsX)
        {
            switch (s)
            {
                case "top":
                    this.backgroundPosition_X_ComputedValue = 0;
                    this.isBackgroundPosition_X_ValuePerentage = false;
                    return;
                case "bottom":
                    this.backgroundPosition_Y_ComputedValue = 1;
                    this.isBackgroundPosition_Y_ValuePerentage = true;
                    return;
                case "right":
                    this.backgroundPosition_X_ComputedValue = 1;
                    this.isBackgroundPosition_X_ValuePerentage = true;
                    return;
                case "left":
                    this.backgroundPosition_X_ComputedValue = 0;
                    this.isBackgroundPosition_X_ValuePerentage = false;
                    return;
                case "center":
                case "middle":
                    if (IsX == true)
                    {
                        this.backgroundPosition_X_ComputedValue = (double)0.5F;
                        this.isBackgroundPosition_X_ValuePerentage = true;
                    }
                    else
                    {
                        this.backgroundPosition_Y_ComputedValue = (double)0.5F;
                        this.isBackgroundPosition_Y_ValuePerentage = true;
                    }
                    return;
                default:
                    if (string.IsNullOrEmpty(s) == false)
                    {
                        if(char.IsNumber(s[0]) == true || s[0] == '-')
                        {
                            int posPercent = s.IndexOf('%');
                            if (posPercent > -1)
                            {
                                float floatStr = 0;
                                if (float.TryParse(s.Substring(0, posPercent), out floatStr) == true)
                                {
                                    if (IsX == true)
                                    {
                                        this.backgroundPosition_X_ComputedValue = (double)(floatStr / 100);
                                        this.isBackgroundPosition_X_ValuePerentage = true;
                                    }
                                    else
                                    {
                                        this.backgroundPosition_Y_ComputedValue = (double)(floatStr / 100);
                                        this.isBackgroundPosition_Y_ValuePerentage = true;
                                    }
                                }
                            }
                            else
                            {
                                if (IsX == true)
                                {
                                    this.backgroundPosition_X_ComputedValue = commonHTML.GetDoubleValueFromString(s, 0, ___elem.___HTMLTagRemUnitSize);
                                    this.isBackgroundPosition_X_ValuePerentage = false;
                                }
                                else
                                {
                                    this.backgroundPosition_Y_ComputedValue = commonHTML.GetDoubleValueFromString(s, 0, ___elem.___HTMLTagRemUnitSize);
                                    this.isBackgroundPosition_Y_ValuePerentage = false;
                                }
                            }
                        }
                    }
                    return;

            }
        }


    }
}
