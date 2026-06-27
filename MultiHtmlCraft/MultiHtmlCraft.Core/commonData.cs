using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Core
{
    internal static class commonData
    {
        internal static bool IsMonoCLR = ___getXamainMonoCLR();
        public static double GetDoubleFromObject(object obj)
        {
            switch(obj)
            {
                case int i1: return (double)i1;
                case float f1: return (double)f1;
                case double d1 : return d1;
            }
            return 0.0;
        }

        public static float[] convertObjectIntoFloatArray(object obj1, int param2 , object obj3)
        {
            throw new NotImplementedException();
        }
        public static double GetDoubleFromObject(object obj, int defaultVal)
        {
            switch (obj)
            {
                case int i1: return (double)i1;
                case float f1: return (double)f1;
                case double d1: return d1;
                case NiL.JS.Core.JSValue nilValue:
                    return (double)nilValue;
                    break;

            }
            return 0.0;
        }
        public static string GetExceptionAsString(object exobj)
        {
            StringBuilder sbError = new StringBuilder();
            switch (exobj)
            {
                case string str:
                    {
                       sbError.Append(str);
                    }
                    break;
                case NiL.JS.Core.JSException nilJsException:
                    {
                        sbError.Append("NilJS JavaScript Error: ");
                        sbError.Append(nilJsException.Message);
                        sbError.Append("\n");

                        // JSExceptionの実際のプロパティを使用
                        if (!string.IsNullOrEmpty(nilJsException.SourceCode))
                        {
                            sbError.AppendFormat("Source Code: {0}\n", nilJsException.SourceCode);
                        }



                        if (!string.IsNullOrEmpty(nilJsException.StackTrace))
                        {
                            sbError.AppendFormat("Stack Trace: {0}\n", nilJsException.StackTrace);
                        }
                    }
                    break;
                case Exception exception:
                    {
                        return exception.ToString();
                    }
                    break;
         
            }
            return sbError.ToString();
        }
        public static CHtmlElement convertObjectIntoCHtmlElement(object obj)
        {
            switch (obj)
            {
                case CHtmlElement element: return element;
            }
            return null;
        }
        public static bool convertObjectToBoolean(object obj, bool defaultValue)
        {
            switch (obj)
            {
             
                case bool b: return b;
            }
            return defaultValue;
        }
            public static bool convertObjectToBoolean(object obj)
        {
            switch(obj)
            {
                
                case bool b: return b;
            }
            return false;
        }
        public static string GetCharsetFromHTMLCharset(string charset)
        {

            charset = commonHTML.FasterToLower(charset);
    

            switch (charset)
            {
                case "x-sjis":
                    return "shift-jis";

                case "sjis":
                case "shiftjis":
                case "s-sjis":
                case "shift_jis":
                case "shift-jis":
                    return "shift_jis";
                case "iso-2022-jp":
                    return "iso-2022-jp";
                case "eucjp":
                case "euc_jp":
                case "euc-jp":
                case "x-euc-jp":
                    return "euc-jp";
                case "utf-8":
                case "utf8":
                    return "utf-8";

                case "iso-8859-1":
                    return "iso-8859-1";
                case "windows-1252":
                    return "utf-8";
                case "autodetect":
                case "auto":
                    return "utf-8";
                default:
                    break;
            }
            return "utf-8";
        }
        public static void DisposeObject(object obj)
        {
            switch (obj) {
                case IDisposable dispobj: dispobj.Dispose(); break; 
            }
            return;
        }
        internal static bool ___getXamainMonoCLR()
        {
            if (Type.GetType("Mono.Runtime") == null)
            {

                return false;
            }
            else
            {
                return true;
            }
        }
        public static string GenerateRandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);

            // Should be creating randam string here

            return sb.ToString();
        }
        internal static float[] ___convertObjectIntoFloatArray(object ___object, int ___offset, int __length)
        {
            switch(___object)
            {
                case null:
                    return new float[0];
                case float[] floatArray: return floatArray;
                default:
                    break;

            }
                
            throw new NotImplementedException();

        }
        public static object convertCHtmlCanvasInstructionMatrixToSystemDrawing2DMatrix(object  ___object)
        {
            return null;
        }
        public static object convertSystemDrawing2DMatrixToCHtmlCanvasInstructionMatrix(object ___object)
        {
            return null;
        }
        public static DateTime convertObjectIntoDateTime(object obj)
        {
            // ===============================================================
            // org.mozilla.javascript.NativeDate is not public.
            // it seems hander solution does not work this type.
            // Therefore, use "As" to convert at first.
            // ===============================================================
            // if (objDate is org.mozilla.javascript.ScriptableObject)
            //  {
            //    return ___convertRhinoDateTimeToDateTime(objDate);
            // }
            switch (obj)
            {


                case DateTime dt: return dt;
                default:
                return DateTime.Now;
            }
        }
    }
}
