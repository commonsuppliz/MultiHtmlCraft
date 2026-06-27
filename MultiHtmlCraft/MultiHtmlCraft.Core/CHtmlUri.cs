using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// CHtmlUri is replacement for System.Uri
    /// it is faster
    /// Normal Uril; 134000 ms CHtmlUri ; 3011 ms (5000000 Loops)
    /// </summary>
    public sealed class CHtmlUri
    {
        public bool ___IsUrlActuallyContainsPortNumberInString = false;
        public bool ___DisableLocationAnalyzation = false;
        public string Protocol = null;
        public string Port = null;
        public string ___Href = null;
        public string Hostname = null;
        public string Pathname = null;
        public string PathnameExtra = null;
        public string Query = null;
        public string Hash = null;
        public CHtmlUriProtocolType ProtocolType = CHtmlUriProtocolType.None;
        public System.WeakReference ___OriginatingElementReference = null;
        public bool ___IsProtocolTypeHTTPorHTTPS()
        {
            if (this.ProtocolType == CHtmlUriProtocolType.http || this.ProtocolType == CHtmlUriProtocolType.https)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public CHtmlUri(string ___Href)
        {
            this.___Href = ___Href;
            ___AnalyzeHref();
        }
        public CHtmlUri()
        {
        }
        public string href
        {
            set
            {
                this.___Href = value;
                if (___DisableLocationAnalyzation == false)
                {
                    ___AnalyzeHref();
                }
            }
            get {return  commonHTML.___convertNullToEmpty(this.___Href); }
        }
        public string Href
        {
            set
            {
                this.___Href = value;
                if (___DisableLocationAnalyzation == false)
                {
                    ___AnalyzeHref();
                }
            }
            get {return  commonHTML.___convertNullToEmpty(this.___Href); }
        }
        private void ___AnalyzeHref()
        {
            short prefend = -1;
            if (string.IsNullOrEmpty(this.___Href) == true)
            {
                return;
            }
            if (___Href[0] == 'h')
            {
                if (___Href.StartsWith("http://", StringComparison.Ordinal) == true)
                {
                    this.Protocol = "http:";
                    this.ProtocolType = CHtmlUriProtocolType.http;
                    prefend = 7;
                }
                else if (___Href.StartsWith("https://", StringComparison.Ordinal) == true)
                {
                    this.Protocol = "https:";
                    this.ProtocolType = CHtmlUriProtocolType.https;
                    prefend = 8;
                }
            }
            else if (___Href[0] == 'f')
            {
                if (___Href.StartsWith("ftp://", StringComparison.Ordinal) == true)
                {
                    this.Protocol = "ftp:";
                    this.ProtocolType = CHtmlUriProtocolType.ftp;
                    prefend = 6;
                }
                else if (___Href.StartsWith("ftps://", StringComparison.Ordinal) == true)
                {
                    this.Protocol = "ftps:";
                    this.ProtocolType = CHtmlUriProtocolType.ftps;
                    prefend = 7;
                }
            }
            else if (___Href[0] == 'd')
            {
                if (___Href.StartsWith("data:", StringComparison.Ordinal) == true)
                {
                    this.Protocol = "data:";
                    this.ProtocolType = CHtmlUriProtocolType.data;
                    prefend = 6;
                }
            }
            else if (___Href[0] == 'a')
            {
                if (___Href.StartsWith("about:", StringComparison.Ordinal) == true)
                {
                    this.Protocol = "about:";
                    this.ProtocolType = CHtmlUriProtocolType.about;
                    prefend = 6;
                }
            }
            else if (___Href[0] == 'j')
            {
                if (___Href.StartsWith("javascript:", StringComparison.Ordinal) == true)
                {
                    this.Protocol = "javascript:";
                    this.ProtocolType = CHtmlUriProtocolType.javascript;
                    prefend = 6;
                }
            }
            else if (___Href[0] == 'm')
            {
                if (___Href.StartsWith("mailto:", StringComparison.Ordinal) == true)
                {
                    this.Protocol = "mailto:";
                    this.ProtocolType = CHtmlUriProtocolType.mailto;
                    prefend = 6;
                }
            }
            else if (___Href[0] == 'f')
            {
                if (___Href.StartsWith("file:", StringComparison.Ordinal) == true)
                {
                    this.Protocol = "file:";
                    this.ProtocolType = CHtmlUriProtocolType.file;
                    prefend = 6;
                }
            }
            else
            {
                int firstComnPos = this.___Href.IndexOf(':');
                if (firstComnPos > -1)
                {
                    this.Protocol = this.___Href.Substring(0, firstComnPos + 1);
                    goto PathNameCheck;
                }
            }
            if (prefend > -1)
            {
                int nextShash = ___Href.IndexOf('/', prefend);
                if (nextShash > -1)
                {
                    this.Hostname = this.___Href.Substring(prefend, nextShash - prefend);
                    int posQuestion = -1;
                    int posSharp = -1;
                    posQuestion = this.___Href.IndexOf('?');
                    posSharp = this.___Href.IndexOf('#');
                    if (posSharp == -1 && posQuestion == -1)
                    {
                        this.Pathname = this.___Href.Substring(nextShash);
                        this.PathnameExtra = this.Pathname;

                    }
                    else
                    {
                        if (posQuestion > -1)
                        {
                            this.PathnameExtra = this.___Href.Substring(nextShash);
                            if (posQuestion > nextShash)
                            {
                                this.Pathname = this.___Href.Substring(nextShash, posQuestion - nextShash);
                            }
                            else
                            {
                                if (commonLog.LoggingEnabled)
                                {
                                   commonLog.LogEntry("PathName will be skiped for " + this.___Href);
                                }
                            }
                            this.Query = this.___Href.Substring(posQuestion);

                        }
                        if (posSharp > -1)
                        {
                            this.PathnameExtra = this.___Href.Substring(nextShash);
                            if (posQuestion > nextShash)
                            {
                                this.Pathname = this.___Href.Substring(nextShash, posSharp - nextShash);
                            }
                            else
                            {
                                if (commonLog.LoggingEnabled)
                                {
                                   commonLog.LogEntry("PathName will be skiped for " + this.___Href);
                                }
                            }
                            this.Hash = this.___Href.Substring(posSharp);
                        }
                    }
                }
                else
                {
                    this.Hostname = ___Href.Substring(prefend);
                }
                int portColumn = -1;
                if (string.IsNullOrEmpty(this.Hostname) == false)
                {
                    this.Hostname.IndexOf(':');
                    if (portColumn > -1)
                    {
                        this.Port = this.Hostname.Substring(portColumn + 1);
                        if (string.Equals(this.Port, "80", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            ___IsUrlActuallyContainsPortNumberInString = true;
                            this.Port = "";
                        }
                        this.Hostname = this.Hostname.Substring(0, portColumn);

                    }
                }
            }
            PathNameCheck:
            if (string.IsNullOrEmpty(this.Pathname) == true)
            {
                this.Pathname = "/";
                this.PathnameExtra = "/";
            }
            return;

        }
        /// <summary>
        /// Faster Returns Host Name from Url String
        /// Normal Way             : 44000 ms
        /// GetHostFromUrlString() : 1.300 ms
        /// </summary>
        /// <param name="_Href"></param>
        /// <returns></returns>
        /// 
        public CHtmlUri CloneUri()
        {
            CHtmlUri newUri = new CHtmlUri();
            if (string.IsNullOrEmpty(this.___Href) == true)
            {
                return newUri;
            }
            else
            {
                if (string.IsNullOrEmpty(this.___Href) == false)
                {
                    newUri.___Href = string.Copy(this.___Href);
                }
                if (string.IsNullOrEmpty(this.Protocol) == false)
                {
                    newUri.Protocol = string.Copy(this.Protocol);
                }
                if (string.IsNullOrEmpty(this.Hostname) == false)
                {
                    newUri.Hostname = string.Copy(this.Hostname);
                }
                if(string.IsNullOrEmpty(this.Query) == false)
                {
                newUri.Query = string.Copy(this.Query);
                }
                if (string.IsNullOrEmpty(this.Hash) == false)
                {
                    newUri.Hash = string.Copy(this.Hash);
                }
                if (string.IsNullOrEmpty(this.Pathname) == false)
                {
                    newUri.Pathname = string.Copy(this.Pathname);
                }
                newUri.ProtocolType = this.ProtocolType;

                if (this.___OriginatingElementReference != null)
                {
                    newUri.___OriginatingElementReference = this.___OriginatingElementReference;
                }
                return newUri;

            }
        }

    }
}
