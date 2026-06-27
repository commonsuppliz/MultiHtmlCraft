using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using NiL.JS.BaseLibrary;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Avalonia;

using SkiaSharp;




#if WINDOWS
using System.Drawing;
using System.Drawing.Drawing2D;
#else
using System.Drawing; // Assuming System.Drawing.Common is available
#endif


namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// This class used for Type Conversion
    /// </summary>
    public static class commonTypeConverter
    {



        public static CHtmlElement convertObjectIntoCHtmlElement(object __object)
        {
            switch (__object)
            {
                case CHtmlMediaElement __mediaElement:
                    return __mediaElement;
                case CHtmlSVGElement __svgElement: return __svgElement;
                case CHtmlTemplateElement __svgTemplateElement: return __svgTemplateElement;

                case CHtmlElement cHtmlElement:
                    return cHtmlElement;




                case string stringobj:
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                    {
                        commonLog.LogEntry("newElement is text...create one.");
                    }


                    if (string.IsNullOrEmpty(stringobj) == true || stringobj == "undefined")
                    {
                        return null;
                    }
                    CHtmlTextElement textElement = new CHtmlTextElement();
                    textElement.___IsDynamicElement = true;
                    textElement.value = stringobj;
                    return textElement;
                    break;

                case object objobject:
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                    {

                        commonLog.LogEntry("ConvertObjectIntoElement() Unknown object Type to convert!  : {0}", objobject);


                    }
                    break;
            }

            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                if (__object != null)
                {

                    commonLog.LogEntry("ConvertObjectIntoElement() Unknown object Type to convert!  : {0} Type : {1}", __object, __object.GetType());
                }
                else
                {
                    commonLog.LogEntry("ConvertObjectIntoElement() Unknown object Type to convert!  : {0}", __object);

                }
            }



            return null;
        }




        public static bool convertObjectToBoolean(object _boolObj, bool defaultBool)
        {

            switch (_boolObj)
            {
                case bool __bool:
                    return __bool;
                case string __string:
                    return ConvertStringToBoolWithSwitch(__string);
                case NiL.JS.Core.JSValue nilValue:
                    if (nilValue.Value is System.Boolean)
                    {
                        return (bool)nilValue.Value;
                    }
                    else
                    {

                        return false;
                    }
                    break;


            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("TypeConverter Unable to convert object to Boolean {0}", _boolObj);
            }

            return false;
        }
        /*
        private static bool ConvertOrgMozilaConStringToBool(object obj)
        {
            org.mozilla.javascript.ConsString conStr = (org.mozilla.javascript.ConsString)obj;
            return ConvertStringToBoolWithSwitch(conStr.toString());

        }
        */
        private static bool ConvertStringToBoolWithSwitch(string s)
        {
            switch (s)
            {
                case "T":
                case "t":
                case "Y":
                case "y":
                case "True":
                case "true":
                case "TRUE":
                case "Yes":
                case "yes":
                case "YES":
                case "always":
                case "Always":
                case "ALWAYS":
                case "1":
                case "on":
                case "On":
                case "ON":
                    return true;
                case "false":
                case "False":
                case "FALSE":
                case "0":
                case "-1":
                case "off":
                case "none":
                case "NONE":
                case "None":
                case "Never":
                case "never":
                case "NEVER":
                case "No":
                case "NO":
                case "OFF":
                case "Hidden":
                case "hidden":
                case "n":
                case "N":
                case "F":
                case "f":
                    return false;
            }
            return false;
        }


        #region ImageHanderSection
        private delegate System.Drawing.Image ImageContentTypeHander(byte[] bts, int contentLength);
        private static System.Collections.Generic.Dictionary<string, ImageContentTypeHander> imageGenereteSwitcher = createImageSwitcher();
        private static System.Collections.Generic.Dictionary<string, ImageContentTypeHander> createImageSwitcher()
        {
            System.Collections.Generic.Dictionary<string, ImageContentTypeHander> list = new System.Collections.Generic.Dictionary<string, ImageContentTypeHander>();
            list["image/png"] = new ImageContentTypeHander(___convertBytesToImageGeneric);
            list["image/gif"] = new ImageContentTypeHander(___convertBytesToImageGeneric);
            list["image/jpeg"] = new ImageContentTypeHander(___convertBytesToImageGeneric);
            list["image/jpg"] = new ImageContentTypeHander(___convertBytesToImageGeneric);
            list["image/bmp"] = new ImageContentTypeHander(___convertBytesToImageGeneric);
            list["image/svg"] = new ImageContentTypeHander(___convertBytesToSVGImage);
            list["image/svg+xml"] = new ImageContentTypeHander(___convertBytesToSVGImage);
            list["image/svgxml"] = new ImageContentTypeHander(___convertBytesToSVGImage);
            list["image/svg xml"] = new ImageContentTypeHander(___convertBytesToSVGImage);
            list["application/svg"] = new ImageContentTypeHander(___convertBytesToSVGImage);
            list["application/svg+xml"] = new ImageContentTypeHander(___convertBytesToSVGImage);
            list["image/webp"] = new ImageContentTypeHander(___convertBytesToWebpImage);
            return list;
        }

        private static System.Drawing.Image ___convertBytesToImageGeneric(byte[] bts, int ContentLength)
        {
            if (bts == null || bts.Length == 0)
            {
                return null;
            }
            System.IO.MemoryStream mStream = null;
            System.Drawing.Image img = null;
            try
            {
                mStream = new MemoryStream(bts);
                img = Image.FromStream(mStream, false, true); // image Validation is requred.
                // ============================================================
                // DO NOT DISPOSE memory stream!!! IT WILL AUTOMALLY DISPOSED When image.dispose().
                /// ============================================================
                return img;
            }
            catch (Exception exImage)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("___convertBytesToImageGeneric() Exception. return null.", exImage);
                }
            }
            return null;
        }
        private static System.Drawing.Image ___convertBytesToSVGImage(byte[] bts, int ContentLength)
        {
            Image bmp = null;
            try
            {

            }
            catch (Exception exSvg)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
                {
                    commonLog.LogEntry(string.Format("reateSVGImageFromString SVG Rendering Error", exSvg));

                }
            }
            return bmp;
        }
        private static System.Drawing.Image ___convertBytesToWebpImage(byte[] bts, int ContentLength)
        {
            Image bmp = null;
            try
            {

            }
            catch (Exception exSvg)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
                {
                    commonLog.LogEntry(string.Format("reateSVGImageFromString WebP Rendering Error", exSvg));

                }
            }
            return bmp;
        }

        // Helper to convert System.Drawing.RectangleF into SkiaSharp.SKRect
        public static SKRect convertRectangleFToSKRect(System.Drawing.RectangleF rect)
        {
            return new SKRect(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        // Helper to convert System.Drawing.RectangleF into Avalonia.Rect
        public static Avalonia.Rect convertRectangleFToAvaloniaRect(System.Drawing.RectangleF rect)
        {
            return new Avalonia.Rect(rect.Left, rect.Top, rect.Width, rect.Height);
        }

        public static System.Drawing.Image convertBytesIntoImage(byte[] bts, string contentType, int contentLength)
        {
            ImageContentTypeHander handler = null;
            try
            {
                if (imageGenereteSwitcher.TryGetValue(contentType, out handler) == true)
                {
                    return handler(bts, contentLength);
                }
                else
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel > 8)
                    {
                        commonLog.LogEntry("convertBytesIntoImage(bytes, {0}, {1}) image handler is not set", contentType, contentLength);
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 8)
                {
                    commonLog.LogEntry("convertBytesIntoImage(bytes, {0}, {1}) image exception Reason : {2}", contentType, contentLength, ex.Message);
                }
            }
            return null;
        }
        #endregion

        #region DateTimeSection


        public static DateTime convertObjectIntoDateTime(object objDate)
        {
            if (objDate != null)
            {
                try
                {
                    switch (objDate)
                    {
                        case DateTime dtTime:
                            return dtTime;

                    }
                    // ===============================================================
                    // org.mozilla.javascript.NativeDate is not public.
                    // it seems hander solution does not work this type.
                    // Therefore, use "As" to convert at first.
                    // ===============================================================

                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel > 10)
                    {
                        commonLog.LogEntry("commonTypeConverter.convertObjectIntoDateTime() Exception", ex);
                    }
                }
                return DateTime.Now;
            }
            else
            {
                return DateTime.Now;
            }
        }

        private static DateTime ___convertObjectToDateTime(object ___obj)
        {
            return (DateTime)___obj;
        }


        #endregion


        public static  PointFSpec ToPointFSpec(System.Drawing.PointF pt)
        {
            return new PointFSpec(pt.X, pt.Y);
        }
        public static Color convertColorSpecToGDIDrawingColor(ColorSpec value)
        {
            return Color.FromArgb(value.A, value.R, value.G, value.B);
        }
        public static ColorSpec convertGDIColorToColorSpec(Color value)
        {
            return new ColorSpec(value.R, value.G, value.B, value.A);
        }
        
        public static Avalonia.Media.Color convertColorSpecToAvaloniaColor(ColorSpec spec)
        {
            return Avalonia.Media.Color.FromArgb(spec.A, spec.R, spec.G, spec.B);
        }
        
        public static Avalonia.Rect convertToRectangleFToAvaloniaRect(RectangleF rectf)
        {
            return new Avalonia.Rect(rectf.X, rectf.Y, rectf.Width, rectf.Height);
        }
        public static SkiaSharp.SKRect convertToRectangleFToSkiaRect(RectangleF rectf)
        {
            return new SkiaSharp.SKRect(rectf.X, rectf.Y, rectf.X + rectf.Width, rectf.Y + rectf.Height);
        }
   
        // SizeFSpec → System.Drawing.SizeF
        public static System.Drawing.SizeF ToSizeF(SizeFSpec spec)
        {
            return new System.Drawing.SizeF(spec.Width, spec.Height);
        }
       
        // SizeSpec → System.Drawing.SizeF
        public static System.Drawing.SizeF ToSizeF(SizeSpec spec)
        {
            return new System.Drawing.SizeF(spec.Width, spec.Height);
        }
        // RectangleFSpec → System.Drawing.RectangleF
        public static System.Drawing.RectangleF ToRectangleF(RectangleFSpec spec)
        {
            return new System.Drawing.RectangleF(spec.X, spec.Y, spec.Width, spec.Height);
        }
        // RectangleSpec → System.Drawing.RectangleF
        public static System.Drawing.RectangleF ToRectangleF(RectangleSpec spec)
        {
            return new System.Drawing.RectangleF(spec.X, spec.Y, spec.Width, spec.Height);

        }
        public static RectangleFSpec ToRectangleFSpec(RectangleF spec)
        {
            return new RectangleFSpec(spec.X, spec.Y, spec.Width, spec.Height);
        }

        public static bool IsEqualRectangleFSpecValue(RectangleFSpec spec1, RectangleFSpec spec2)
        {

            return spec1.X == spec2.X && spec1.Y == spec2.Y && spec1.Width == spec2.Width && spec1.Height == spec2.Height;

        }
        public static bool IsEqualRectangleSpecValue(RectangleSpec spec1, RectangleSpec spec2)
        {
            return spec1.X == spec2.X && spec1.Y == spec2.Y && spec1.Width == spec2.Width && spec1.Height == spec2.Height;
        }


        // System.Drawing.SizeF → SizeFSpec
        public static SizeFSpec FromSizeF(System.Drawing.SizeF size)
        {
            return new SizeFSpec(size.Width, size.Height);
        }
        // System.Drawing.RectangleF → RectangleFSpec
        public static RectangleFSpec FromRectangleF(System.Drawing.RectangleF rect)
        {
            return new RectangleFSpec(rect.X, rect.Y, rect.Width, rect.Height);
        }
        // PointFSpec → System.Drawing.PointF

        public static System.Drawing.PointF ToPointF(PointFSpec spec)
        {
            return new System.Drawing.PointF(spec.X, spec.Y);
        }
        public static System.Drawing.Point ToPoint(PointFSpec spec)
        {
            return new System.Drawing.Point((int)spec.X, (int)spec.Y);
        }
        public static System.Drawing.Point ToPoint(double x, double y)
        {
            return new System.Drawing.Point((int)x, (int)y);
        }
        // System.Drawing.PointF → PointFSpec
        public static PointFSpec FromPointF(System.Drawing.PointF pt)
        {
            return new PointFSpec(pt.X, pt.Y);
        }
        // PointFSpec[] → System.Drawing.PointF[]
        public static System.Drawing.PointF[] ToPointFArray(PointFSpec[] specs)
        {
            if (specs == null) return null;
            var arr = new System.Drawing.PointF[specs.Length];
            for (int i = 0; i < specs.Length; i++)
            {
                arr[i] = ToPointF(specs[i]);
            }
            return arr;
        }
        // PointFSpec[] → System.Drawing.Point[]
        public static System.Drawing.Point[] ToPointArray(PointFSpec[] specs)
        {
            if (specs == null) return null;
            var arr = new System.Drawing.Point[specs.Length];
            for (int i = 0; i < specs.Length; i++)
            {
                arr[i] = ToPoint(specs[i]);
            }
            return arr;
        }
        #region FontScpec Convdersion
        #if WINDOWS
        public static FontSpec convertGDIFontToFontSpec(Font font)
        {

            switch(font.Style)
            {
                case FontStyle.Regular:
                    return new FontSpec(font.Name, font.Size, FontStyleSpec.Regular);
                case FontStyle.Bold:
                    return new FontSpec(font.Name, font.Size, FontStyleSpec.Bold);
                case FontStyle.Italic:
                    return new FontSpec(font.Name, font.Size, FontStyleSpec.Italic);
                case FontStyle.Bold | FontStyle.Italic:
                    return new FontSpec(font.Name, font.Size, FontStyleSpec.BoldItalic);
                default:
                    if (font == null)
                    {
                        return new FontSpec("", 12);
                    }
                    break;
            }
            return new FontSpec("", 12);

        }
    
        public static Font convertFontSpecToGDIFont(FontSpec fontspec)
        {

            switch (fontspec.Style)
            {
                case FontStyleSpec.Regular:
                    return new Font(fontspec.FamilyName, fontspec.Size, FontStyle.Regular);
                case FontStyleSpec.Bold:
                    return new Font(fontspec.FamilyName, fontspec.Size, FontStyle.Bold);
                case FontStyleSpec.Italic:
                    return new Font(fontspec.FamilyName, fontspec.Size, FontStyle.Italic);
                case FontStyleSpec.BoldItalic:
                    return new Font(fontspec.FamilyName, fontspec.Size, FontStyle.Bold | FontStyle.Italic);
                default:
                    if (fontspec == null)
                    {
                        return new Font("", 12);
                    }
                    break;
            }

            return new Font("", 12);
        }
        #endif
        #endregion







        #region ConvertNativeArrayToFloatArray

        public delegate float[] NativeArrayConvertHander(object ___arrayObject, int ____offset, int ___length);
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayConvertHander> ___nativeArrayTypeSwitcher = ___createNativeArrayConvertSwither();
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayConvertHander> ___createNativeArrayConvertSwither()
        {
            System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayConvertHander> list = new Dictionary<RuntimeTypeHandle, NativeArrayConvertHander>();
            list[typeof(System.Array).TypeHandle] = new NativeArrayConvertHander(___convertSystemArrayToFloatArray);
            list[typeof(CHtmlNativeArray).TypeHandle] = new NativeArrayConvertHander(___convertCHtmlNativeArrayToFloatArray);
            // ============================================================================================================
            // Rhino Javascript NativeTypedArray Class Conversion

            // ==============================================================================================================
            // ==============================================================================================================
            return list;
        }
        #region ConvertionUtils
        public static float[] ___convertSystemArrayToFloatArray(object ___object, int ____offset, int ___length)
        {
            float[] ___floatArray;
            System.Array ___objectArray = (System.Array)___object;

            int ___intLen = ___objectArray.Length;
            ___floatArray = new float[___intLen];
            for (int i = 0; i < ___intLen; i++)
            {
                ___floatArray[i] = (float)___objectArray.GetValue(i);
            }


            return ___floatArray;
        }
        public static float[] ___convertCHtmlNativeArrayToFloatArray(object ___object, int ____offset, int ___length)
        {
            CHtmlNativeArray ___numBase = ___object as CHtmlNativeArray;
            float[] ___floatArray;
            ___floatArray = new float[___length];
            if (___numBase.___floatArray != null)
            {
                System.Array.Copy(___numBase.___floatArray, ___floatArray, ___numBase.___floatArray.Length);
                return ___floatArray;
            }
            int ___int16ArrayLen = ___numBase.___int16Array.Length;
            if (___numBase.___int16Array != null)
            {
                for (int i = 0; i < ___int16ArrayLen; i++)
                {
                    ___floatArray[i] = (float)___numBase.___int16Array[i];
                }
                return ___floatArray;
            }
            if (___numBase.___int32Array != null)
            {
                int ___numBaseint32ArrayLength = ___numBase.___int32Array.Length;
                for (int i = 0; i < ___numBaseint32ArrayLength; i++)
                {
                    ___floatArray[i] = (float)___numBase.___int32Array[i];
                }
                return ___floatArray;
            }
            if (___numBase.___int64Array != null)
            {
                int ___numBaseint64ArrayLen = ___numBase.___int64Array.Length;
                for (int i = 0; i < ___numBaseint64ArrayLen; i++)
                {
                    ___floatArray[i] = (float)___numBase.___int64Array[i];
                }
                return ___floatArray;
            }


            return ___floatArray;
        }

        #endregion




        internal static float[] ___convertObjectIntoFloatArray(object ___object, int ___offset, int __length)
        {
            NativeArrayConvertHander handler;
            if (___object == null)
            {
                return new float[0];
            }
            if (___nativeArrayTypeSwitcher.TryGetValue(___object.GetType().TypeHandle, out handler))
            {
                return handler(___object, ___offset, ___offset);
            }
            else
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 3)
                {
                    commonLog.LogEntry("TODO Needs Type Swicher for ___convertObjectIntoFloatArray({0} , {1},  {2}) : Type {3}", ___object, ___offset, __length, ___object.GetType());
                }
                return new float[] { };
            }




            #endregion
        }

        public static Rectangle ToRectangle(RectangleFSpec rectFSpec)
        {

            return new Rectangle((int)rectFSpec.X, (int)rectFSpec.Y, (int)rectFSpec.Width, (int)rectFSpec.Height);

        }
        /*
        public static Avalonia.Media.Imaging.Bitmap convertSkiaBitmapToAvaloniaBitmap(SKBitmap bitmap)
        {



            var info = bitmap.Info;


            var ptr = bitmap.GetPixels();
            if (ptr == IntPtr.Zero)
                throw new InvalidOperationException("SKBitmap pixels pointer is null");

            // Avalonia の PixelFormat に合わせてラップ
            var size = new PixelSize(info.Width, info.Height);

            // Stride = 幅 * 4bytes
            int stride = info.RowBytes;



     

            unsafe
            {
                var length = info.Height * stride;
                var buffer = new byte[length];
                System.Runtime.InteropServices.Marshal.Copy(ptr, buffer, 0, length);

                using var ms = new MemoryStream(buffer);
                return new Avalonia.Media.Imaging.Bitmap(ms);
            }
        }
        */
        public static Avalonia.Media.Imaging.Bitmap convertSkiaBitmapToAvaloniaBitmap(SKBitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException(nameof(bitmap));

            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            if (data == null || data.Size == 0)
                throw new InvalidOperationException("Failed to encode SKBitmap to PNG.");

            using var ms = new MemoryStream();
            data.SaveTo(ms);
            ms.Position = 0;

            return new Avalonia.Media.Imaging.Bitmap(ms);
        }
    }
}
