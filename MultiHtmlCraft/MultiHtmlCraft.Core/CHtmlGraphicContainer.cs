using System;
using System.Collections.Generic;
using MultiHtmlCraft.Interfaces;
#if WINDOWS
using System.Drawing;
#else
using System.Drawing;// Assuming Using System.Drawing.Common is available
#endif
using SkiaSharp;
using System.Text;
using NiL.JS.BaseLibrary;
using System.Runtime.InteropServices;
using System.Reflection.Emit;
using System.Linq;
using MultiHtmlCraft.Core;
using NiL.JS.Statements; // for RectangleFSpec

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// CHtmlGraphicContainer 
    /// </summary>
    public class CHtmlGraphicContainer : IDrawingContext, IDisposable
    {




public Graphics? CHtmlGraphicContainerGraphics = null;


        public FontSpec? FontSpec = null;
        public System.Drawing.StringFormat StandardStringFormat = null;
        private Bitmap ___bitmapForGDI = null;

        // Avalonia/SkiaSharp
        public SKCanvas SkiaCanvas = null;
        public SKPaint SkiaPaint = null;
        private SKBitmap ___skiaBitmap = null;

        public ColorSpec BackgroundColor;
        public ColorSpec ForegroundColor;
        public RectangleFSpec PaintRectangle;
        public RectangleFSpec DisplayRectangle;
        public RectangleFSpec ClientRectangle;
        public RectangleFSpec ScreenRectangle;
        public RectangleFSpec ControlBounds;
        public Image ImageNA = null;
        public int CurrentPos = -1;
        public int StartingPos = -1;
        public int EndingPos = -1;
        public float TotalOffsetLeft = 0;
        public float TotalOffsetTop = 0;
        public bool IsUIThreadPaint = false;
        public bool IsDrawLayoutPanel = false;
        public RectangleFSpec ScreenMaximunBounds = RectangleFSpec.Empty;
        public int CurrentElementDepth = 0;
        public bool IsHoverPaintMode = false;
        public CHtmlGraphicAPIType PlatformGraphicAPIType = CHtmlGraphicAPIType.Unknown;
        /// <summary>
        /// Graphics Context for Avalonia and Skia 
        /// </summary>
        public Avalonia.Media.DrawingContext? AvaloniaDrawingContext = null;
#if WINDOWS
/// <summary>Graphics object for WinForms GDI+ rendering. This is only available when the graphic API type is set to WinformsGDI.</summary>
        public System.Drawing.Graphics? Graphic =null;
#endif
        public CHtmlGraphicContainer() : this(commonHTML.GraphicApiType)
        {

        }

        public CHtmlGraphicContainer(CHtmlGraphicAPIType graphicAPIType)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("CHtmlGraphicContainer", $"Initializing with CHtmlGraphicAPIType: {graphicAPIType}");

            }

            commonHTML.GraphicApiType = graphicAPIType;
            PlatformGraphicAPIType = graphicAPIType;



            switch (commonHTML.GraphicApiType)
            {

                case CHtmlGraphicAPIType.SkiaSharp:
                    {
                        this.___skiaBitmap  =  new SKBitmap();
                        this.SkiaCanvas = new SKCanvas(this.___skiaBitmap);
                        this.SkiaPaint = new SKPaint();
                    }
                    break;
                case CHtmlGraphicAPIType.Avalonia:
                    {

                        this.FontSpec = new FontSpec(
                            "sans-serif",
                            9f,
                            FontStyleSpec.Regular);

                        this.StandardStringFormat = null;
       
                        

                        this.___skiaBitmap = new SKBitmap(1, 1);
                        this.SkiaCanvas = new SKCanvas(this.___skiaBitmap);
                        this.SkiaPaint = new SKPaint
                        {
                            IsAntialias = true
                        };

                        // Avalonia の DrawingContext は Render() から設定する。
                        this.AvaloniaDrawingContext = null;

                        // System.Drawing の SystemFonts.DefaultFont は使用しない。
                        this.FontSpec = new FontSpec(
                            "sans-serif",
                            9f,
                            FontStyleSpec.Regular);

                        // Avalonia では System.Drawing.StringFormat を使用しない。
                        this.StandardStringFormat = null;
                    }
                    break;
                case CHtmlGraphicAPIType.UnoPlatform:
                    {
                        throw new NotImplementedException();
                    }
                    break;
                case CHtmlGraphicAPIType.Maui:
                    {
                        throw new NotImplementedException();
                    }
                    break;
                case CHtmlGraphicAPIType.WPF:
                    {
                        throw new NotImplementedException();

                    }
                    break;
                case CHtmlGraphicAPIType.ETO:
                    {
                        throw new NotImplementedException();

                    }
                    break;
#if WINDOWS
                case CHtmlGraphicAPIType.WinformsGDI:
                    {
                        ___bitmapForGDI = new Bitmap(1, 1);
                        this.CHtmlGraphicContainerGraphics = Graphics.FromImage(___bitmapForGDI);
                        if (this.FontSpec == null)
                        {
                            try
                            {
                                var df = SystemFonts.DefaultFont;
                                var style = FontStyleSpec.Regular;
                                if ((df.Style & System.Drawing.FontStyle.Bold) != 0 && (df.Style & System.Drawing.FontStyle.Italic) != 0)
                                    style = FontStyleSpec.BoldItalic;
                                else if ((df.Style & System.Drawing.FontStyle.Bold) != 0)
                                    style = FontStyleSpec.Bold;
                                else if ((df.Style & System.Drawing.FontStyle.Italic) != 0)
                                    style = FontStyleSpec.Italic;
                                this.FontSpec = new FontSpec(df.FontFamily.Name, df.Size, style);
                            }
                            catch
                            {
                                this.FontSpec = new FontSpec("Segoe UI", 9f, FontStyleSpec.Regular);
                            }
                        }
                        this.StandardStringFormat = new System.Drawing.StringFormat();
                        break;
                    }
#endif
                default:
                    {




                        throw new NotImplementedException();


                    }
            }
        GUIPlatformDetected:


            return;
        }
        public CHtmlGraphicAPIType graphicApiType
        {
            get { return commonHTML.GraphicApiType; }
            set { commonHTML.GraphicApiType = value; }
        }

        #region IDisposable 
        public void Dispose()
        {
            try
            {
                if (this.___skiaBitmap != null)
                {
                    this.___skiaBitmap.Dispose();
                    this.___skiaBitmap = null;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry(
                        "CHtmlGraphicContainer SKBitmap dispose failed: {0}",
                        ex.ToString());
                }
            }
#if WINDOWS
            if (commonHTML.GraphicApiType == CHtmlGraphicAPIType.WinformsGDI)
            {
                if (this.StandardStringFormat != null)
                {
                    this.StandardStringFormat.Dispose();
                    this.StandardStringFormat = null;
                }
                // FontSpec cleanup
                this.FontSpec = null;
            }

            if (___bitmapForGDI != null)
            {
                ___bitmapForGDI.Dispose();
                ___bitmapForGDI = null;
            }

            if (this.CHtmlGraphicContainerGraphics != null)
            {
                this.CHtmlGraphicContainerGraphics.Dispose();
                this.CHtmlGraphicContainerGraphics = null;
            }

#elif LINUX
            // Linux-specific cleanup (if any)
#elif ANDROID
            // Android-specific cleanup (if any)
#elif MACOS
            // macOS-specific cleanup (if any)
#endif

            // Common cleanup for SKia and images
            try
            {
                if (this.ImageNA != null)
                {
                    this.ImageNA.Dispose();
                    this.ImageNA = null;
                }
            }
            catch { }

            try
            {
                if (this.SkiaCanvas != null)
                {
                    this.SkiaCanvas.Dispose();
                    this.SkiaCanvas = null;
                }
            }
            catch { }

            try
            {
                if (this.SkiaPaint != null)
                {
                    this.SkiaPaint.Dispose();
                    this.SkiaPaint = null;
                }
            }
            catch { }

            // Ensure CHtmlGraphicContainerGraphics is disposed if it wasn't already
            try
            {
                if (this.CHtmlGraphicContainerGraphics != null)
                {
                    this.CHtmlGraphicContainerGraphics.Dispose();
                    this.CHtmlGraphicContainerGraphics = null;
                }
            }
            catch { }

            // Clear references
            this.FontSpec = null;
            this.StandardStringFormat = null;
        }

        #endregion

        public void Clear()
        {
            switch (commonHTML.GraphicApiType)
            {
                case CHtmlGraphicAPIType.SkiaSharp:
                    SkiaCanvas?.Clear(SKColors.Transparent);
                    break;

            }

        }


        public void ResetClip()
{
    switch (commonHTML.GraphicApiType)
    {
        case CHtmlGraphicAPIType.SkiaSharp:
            SkiaCanvas?.Restore();
            break;

    }
}

#region Drawing APIs
public void DrawLine(PenSpec pen, float x1, float y1, float x2, float y2)
        {
            switch (commonHTML.GraphicApiType)
            {
                case CHtmlGraphicAPIType.SkiaSharp:
                    if (SkiaCanvas != null)
                    {
                        using var paint = new SKPaint
                        {
                            Color = new SKColor(pen.Color.R, pen.Color.G, pen.Color.B, pen.Color.A),
                            StrokeWidth = pen.Thickness,
                            IsStroke = true
                        };
                        SkiaCanvas.DrawLine(x1, y1, x2, y2, paint);
                    }
                    break;
                    
            }
        }

        public void FillRectangle(BrushSpec brush, float x, float y, float width, float height)
        {
            switch (commonHTML.GraphicApiType)
            {
                case CHtmlGraphicAPIType.SkiaSharp:
                    if (SkiaCanvas != null)
                    {
                        using var paint = new SKPaint
                        {
                            Color = new SKColor(brush.Color.R, brush.Color.G, brush.Color.B, brush.Color.A),
                            Style = SKPaintStyle.Fill
                        };
                        SkiaCanvas.DrawRect(x, y, width, height, paint);
                    }
                    break;
            }
        }

        public void DrawRectangle(PenSpec pen, float x, float y, float width, float height)
        {
            switch (commonHTML.GraphicApiType)
            {
                case CHtmlGraphicAPIType.SkiaSharp:
                    if (SkiaCanvas != null)
                    {
                        using var paint = new SKPaint
                        {
                            Color = new SKColor(pen.Color.R, pen.Color.G, pen.Color.B, pen.Color.A),
                            StrokeWidth = pen.Thickness,
                            Style = SKPaintStyle.Stroke
                        };
                        SkiaCanvas.DrawRect(x, y, width, height, paint);
                    }
                    break;
            }
        }

        public void DrawImage(object image, float x, float y, float width, float height)
        {
            switch (commonHTML.GraphicApiType)
            {
                case CHtmlGraphicAPIType.SkiaSharp:
                    if (SkiaCanvas != null && image is SKBitmap bitmap)
                    {
                        var destRect = new SKRect(x, y, x + width, y + height);
                        SkiaCanvas.DrawBitmap(bitmap, destRect);
                    }
                    break;
            }
        }

        public void DrawString(string text, FontSpec font, BrushSpec brush, float x, float y)
        {
            switch (commonHTML.GraphicApiType)
            {
                case CHtmlGraphicAPIType.SkiaSharp:
                    if (SkiaCanvas != null)
                    {
                        using var paint = new SKPaint
                        {
                            Color = new SKColor(brush.Color.R, brush.Color.G, brush.Color.B, brush.Color.A),
                            TextSize = font.Size,
                            Typeface = SKTypeface.FromFamilyName(font.FamilyName, ToSKFontStyle(font.Style))
                        };
                        SkiaCanvas.DrawText(text, x, y + paint.TextSize, paint);
                    }
                    break;
            }
        }



        public void SetClip(RectangleFSpec rect)
        {
            switch (commonHTML.GraphicApiType)
            {
                case CHtmlGraphicAPIType.SkiaSharp:
                    SkiaCanvas?.Save();
                    SkiaCanvas?.ClipRect(new SKRect(rect.Left, rect.Top, rect.Right, rect.Bottom));
                    break;
#if WINDOWS
                case CHtmlGraphicAPIType.WinformsGDI:
                    if (CHtmlGraphicContainerGraphics != null)
                    {
                        var gdiRect = commonTypeConverter.ToRectangleF(rect);
                        CHtmlGraphicContainerGraphics.SetClip(gdiRect);
                    }
                    break;
#endif
            }
        }


        private static SKFontStyle ToSKFontStyle(FontStyleSpec style)
        {
            return style switch
            {
                FontStyleSpec.Bold => SKFontStyle.Bold,
                FontStyleSpec.Italic => SKFontStyle.Italic,
                FontStyleSpec.BoldItalic => SKFontStyle.BoldItalic,
                _ => SKFontStyle.Normal
            };
        }

        #endregion
    }
}