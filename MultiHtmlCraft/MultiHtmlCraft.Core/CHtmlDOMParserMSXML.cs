using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// This class represensts MSXML2.XMLDOM which will be created with 'new ActiveXObject('microsoft.xmldom')'
    /// Only Difference is it ___hasInner load() methods which accepts url to be loaded.
    /// </summary>
    public sealed class CHtmlDOMParserMSXML : CHtmlDocument
    {
        internal string ___threadBaseURL = "";
    
        public CHtmlDOMParserMSXML()
            : base(CHtmlDomModeType.XMLDOM)
        {

        }
        #region XMLDOM Methods
        public void LoadXml(object ___objXML)
        {
            base.___loadXMLString(commonHTML.GetStringValue(___objXML), this.charset, "");
        }
        public void loadxml(object ___objXML)
        {
            base.___loadXMLString(commonHTML.GetStringValue(___objXML), this.charset, "");
        }
        public void loadXML(object ___objXML)
        {
            base.___loadXMLString(commonHTML.GetStringValue(___objXML), this.charset, "");
        }
        #endregion
        public void load(object ___oURL)
        {
            this.___load_Inner(___oURL);
        }
        public void Load(object ___oURL)
        {
            this.___load_Inner(___oURL);
        }
        private void ___load_Inner(object ___oUrl)
        {
            try
            {
                if (___oUrl != null && commonHTML.IsObjectStringType(___oUrl))
                {
                    string __partUrl = commonHTML.GetStringValue(___oUrl);
                    if (__partUrl.Length > 0)
                    {
                        string ___fullURLString = "";
                        if (__partUrl.StartsWith("http://", StringComparison.Ordinal) == true || __partUrl.StartsWith("https://", StringComparison.Ordinal) == true)
                        {
                            ___fullURLString = string.Copy(__partUrl);
                            goto UrlObtained;
                        }
                        else
                        {
                            ___fullURLString = commonHTML.GetAbsoluteUri(this.___threadBaseURL, "", __partUrl);
                        }
                        if (___fullURLString.StartsWith("http://", StringComparison.Ordinal) == true || ___fullURLString.StartsWith("https://", StringComparison.Ordinal) == true)
                        {
                            goto UrlObtained;
                        }
                        else
                        {
                            throw new System.ArgumentException("Invalid URL" + ___fullURLString);
                        }

                    UrlObtained:
                        bool __IsAsync = false;
                        object oValue = this.___attributes["async"];
                        if (oValue is Boolean)
                        {
                            __IsAsync = (bool)oValue;
                        }
                        else if (oValue is CHtmlAttribute)
                        {
                            CHtmlAttribute ___asyncAttr = oValue as CHtmlAttribute;
                            if (___asyncAttr != null)
                            {
                                if (___asyncAttr.value is bool)
                                {
                                    __IsAsync = (bool)___asyncAttr.value;
                                }
                                else
                                {
                                    try
                                    {
                                        bool.TryParse(___asyncAttr.value.ToString(), out __IsAsync);
                                    }
                                    catch (Exception ex)
                                    {
                                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 7)
                                        {
                                           commonLog.LogEntry("XMLDOM parse bool error", ex);
                                        }
                                    }
                                }
                            }
                            
                        }
                        this.___URL = string.Copy(___fullURLString);
                        this.___locationBase.___DisableHrefNavigate = true;
                        this.___locationBase.___DisableLocationAnalyzation = true;
                        this.___locationBase.___setHrefDirect(___fullURLString);
                        this.___locationBase.___AnalyzeLocation();
                        this.___locationBase.___DisableHrefNavigate = false;
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 7)
                        {
                           commonLog.LogEntry("XMLDOM is start processing url: {0} async: {1}", ___fullURLString, __IsAsync);
                        }
                
                        
         
  

                    }
                    else
                    {
                        throw new System.ArgumentException("URL Is empty");
                    }
                }
                else
                {
                    throw new System.ArgumentException("URL Is empty");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void CHTMLDOMParser_AsyncReadComplete(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 7)
                {
                   commonLog.LogEntry("CHTMLDOMParser_AsyncReadComplete Exception : " , ex);
                }
            }
        }
#region CommonObjectInterface
        public override string ___getClassName()
        {
            return "XMLDOM";
        }
#endregion

    }
}
