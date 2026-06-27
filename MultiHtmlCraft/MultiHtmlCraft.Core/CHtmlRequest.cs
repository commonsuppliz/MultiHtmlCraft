using System;
using System.Collections.Generic;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// Implementation of ICHtmlRequestInterface based on W3C Fetch API Request.
    /// </summary>
    public class CHtmlRequest : ICHtmlRequestInterface
    {
        public string Method { get; private set; }
        public Uri Url { get; private set; }
        public IDictionary<string, string> Headers { get; private set; }
        public object? Body { get; private set; }
        public string? Mode { get; private set; }
        public string? Credentials { get; private set; }
        public string? Cache { get; private set; }
        public string? Redirect { get; private set; }
        public string? Referrer { get; private set; }
        public string? ReferrerPolicy { get; private set; }
        public string? Integrity { get; private set; }
        public string? Destination { get; private set; }
        public bool? Keepalive { get; private set; }
        public object? Signal { get; private set; }
        private object ___paramsObject;
        public object ParamsObject
        {
            get { return ___paramsObject; }
            set { ___paramsObject = value; }
        }

        public CHtmlRequest(params object[] args)
        {
            // 安全な引数チェックとUri生成
            string method = "GET";
            Uri url = null;
            var headers = new Dictionary<string, string>();

   

            if (args != null && args.Length > 0 && args[0] != null)
            {
                if (!Uri.TryCreate(args[0].ToString(), UriKind.Absolute, out url))
                {
                    // 無効なURLの場合は空のUriをセット（またはnullで例外回避）
                    url = new Uri("about:blank");
                }
            }
            else
            {
                url = new Uri("about:blank");
            }
            if (args != null && args.Length > 1 && args[1] != null)
            {
                switch(args[1])
                {
                    case string strMethod when strMethod.Equals("GET", StringComparison.OrdinalIgnoreCase):
                        method = "GET";
                        break;
                    case Microsoft.ClearScript.ScriptObject objParams :
                        {
                            Dictionary<string, object> paramsDictionary = SerializeV8ScriptObjectWithoutFuncs(objParams);
                            foreach (string strParam in paramsDictionary.Keys)
                            {
                                {
                                    if (paramsDictionary[strParam] is string strValue)
                                    {
                                        headers[strParam] = strValue;
                                    }
                                    else if (paramsDictionary[strParam] is int intValue)
                                    {
                                        headers[strParam] = intValue.ToString();
                                    }
                                    else if (paramsDictionary[strParam] is bool boolValue)
                                    {
                                        headers[strParam] = boolValue.ToString();
                                    }
                                    else
                                    {
                                        headers[strParam] = paramsDictionary[strParam]?.ToString() ?? string.Empty;
                                    }
                                }
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                {
                                    commonLog.LogEntry($"Request Params has list length: {paramsDictionary.Count}");
                                }

                            }
                        } break;
                }
            }

                // ヘッダーや追加パラメータのパース（必要に応じて拡張）
                // 例: new CHtmlRequest("GET", "http://example.com", "Content-Type", "application/json")
                if (args != null && args.Length > 2)
            {
                for (int i = 2; i + 1 < args.Length; i += 2)
                {
                    string key = args[i]?.ToString() ?? string.Empty;
                    string value = args[i + 1]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(key))
                        headers[key] = value;
                }
            }

            Method = method;
            Url = url;
            Headers = headers;
            // 他のプロパティはデフォルト値
        }

        public static Dictionary<string, object> SerializeV8ScriptObjectWithoutFuncs(Microsoft.ClearScript.ScriptObject v8Obj)
        {
            var dict = new Dictionary<string, object>();
            foreach (var prop in v8Obj.PropertyNames)
            {
                var value = v8Obj.GetProperty(prop);
                // デリゲート（関数）を除外
                if (value is Delegate) continue;
                if (value is Microsoft.ClearScript.ScriptObject)
                {
                    Dictionary<string, object> childDict = SerializeV8ScriptObjectWithoutFuncs(value as Microsoft.ClearScript.ScriptObject);
                    dict.Add(prop, childDict);
                    continue;
                }
                dict[prop] = value;
            }
            return dict;
        }


    }
}
