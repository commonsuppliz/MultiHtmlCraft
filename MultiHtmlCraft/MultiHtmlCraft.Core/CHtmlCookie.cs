using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Core
{
    public sealed class CHtmlCookie
    {
        public string Name = null;
        public string Path = null;
        public string Domain = null;
        public string Port = null;
        public bool Secure = false;
        public bool Discard = false;
        public bool Expired = false;
        public DateTime Expires = DateTime.Now;
        public DateTime TimeStamp = DateTime.Now;
        public string Value = "";
        public string Version = null;
        public string Comment = null;
        public string CommentUri = null;
        internal string ___CookieSortKeyString = null;

        public CHtmlCookie()
        {

        }
        public CHtmlCookie(System.Net.Cookie __baseCookie)
        {
            if (__baseCookie != null)
            {
                if (string.IsNullOrEmpty(__baseCookie.Name) == false)
                {
                    this.Name = string.Copy(__baseCookie.Name);
                }
                if (string.IsNullOrEmpty(__baseCookie.Value) == false)
                {
                    this.Value = string.Copy(__baseCookie.Value);
                }
                if (string.IsNullOrEmpty(__baseCookie.Comment) == false)
                {
                    this.Comment = string.Copy(__baseCookie.Comment);
                }
                if (__baseCookie.CommentUri != null)
                {
                    this.CommentUri = __baseCookie.CommentUri.AbsoluteUri;
                }
                this.TimeStamp = __baseCookie.TimeStamp;
                this.Expires = __baseCookie.Expires;
                this.Expired = __baseCookie.Expired;

                if (string.IsNullOrEmpty(__baseCookie.Domain) == false)
                {
                    this.Domain = string.Copy(__baseCookie.Domain);
                }
                if (string.IsNullOrEmpty(__baseCookie.Path) == false)
                {
                    this.Path = string.Copy(__baseCookie.Path);
                }
                if (string.IsNullOrEmpty(__baseCookie.Port) == false)
                {
                    this.Port = string.Copy(__baseCookie.Port);
                }
            }
        }

        public override string ToString()
        {
            //return string.Format("http://{0}{1}?{2}={3}", this.Domain, this.Path, this.Name, this.Value);
            System.Text.StringBuilder sb = new StringBuilder(30);
            sb.Append("http://");
            if(string.IsNullOrEmpty(this.Domain) == false)
            {
                sb.Append(this.Domain);
            }
            if (string.IsNullOrEmpty(this.Path) == false)
            {
                sb.Append(this.Path);
            }
            sb.Append('?');
            if (string.IsNullOrEmpty(this.Name) == false)
            {
                sb.Append(this.Name);    
            }
            if (string.IsNullOrEmpty(this.Value) == false)
            {
                sb.Append('=');
                sb.Append(this.Value);
            }


            return sb.ToString();
        }
        public string ToStringComp()
        {
            if (string.IsNullOrEmpty(___CookieSortKeyString) == true)
            {
                //___CookieSortKeyString = string.Format("http://{0}{1}?{2}", this.Domain, this.Path, this.Name);
                System.Text.StringBuilder sb = new StringBuilder(30);
                sb.Append("http://");
                if (string.IsNullOrEmpty(this.Domain) == false)
                {
                    sb.Append(this.Domain);
                }
                if (string.IsNullOrEmpty(this.Path) == false)
                {
                    sb.Append(this.Path);
                }
                sb.Append('?');
                if (string.IsNullOrEmpty(this.Name) == false)
                {
                    sb.Append(this.Name);
                }

                ___CookieSortKeyString = sb.ToString();
                return ___CookieSortKeyString;
            }
            else
            {
                return ___CookieSortKeyString;
            }
        }
        public System.Net.Cookie convertoCLRCookie()
        {
            System.Net.Cookie clrCookie = new System.Net.Cookie();
            if (string.IsNullOrEmpty(this.Name) == false)
            {
                clrCookie.Name = string.Copy(this.Name);
            }
            if (string.IsNullOrEmpty(this.Path) == false)
            {
                clrCookie.Path = string.Copy(this.Path);
            }
            if (string.IsNullOrEmpty(this.Domain) == false)
            {
                clrCookie.Domain = string.Copy(this.Domain);
            }
            if (string.IsNullOrEmpty(this.Port) == false)
            {
            
             
                    clrCookie.Port = this.Port;

            }
            if (string.IsNullOrEmpty(this.Comment) == false)
            {
                clrCookie.Comment = string.Copy(this.Comment);
            }
            if (string.IsNullOrEmpty(this.CommentUri) == false)
            {
                try
                {
                    clrCookie.CommentUri = new Uri(this.CommentUri);
                }
                catch { }
            }
            clrCookie.Expired = this.Expired;
            clrCookie.Expires = this.Expires;

            clrCookie.Secure = this.Secure;
            if (string.IsNullOrEmpty(this.Version) == false)
            {
                int ver = -1;
                if (int.TryParse(this.Version, out ver) == true)
                {
                    clrCookie.Version = ver;

                }
            }
            if (string.IsNullOrEmpty(this.Version) == false)
            {
                clrCookie.Value = string.Copy(this.Value);
            }

            clrCookie.Discard = this.Discard;
            return clrCookie;
        }


    }
}
