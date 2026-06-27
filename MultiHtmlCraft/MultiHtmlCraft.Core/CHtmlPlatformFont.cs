using System;
using System.Drawing;
using SkiaSharp;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
    public static class CHtmlPlatformFontFactory
    {
        public static ICHtmlPlatformFont CreateFromGdiFont(Font font)
        {
#if WINDOWS
            return new GdiPlatformFont(font);
#else
            var spec = new FontSpec(font?.Name ?? string.Empty, font?.Size ?? 12f, (font != null && font.Bold) ? FontStyleSpec.Bold : FontStyleSpec.Regular);
            return new SkiaPlatformFont(spec);
#endif
        }

        /// <summary>
        /// Create a Skia-based platform font from a GDI+ Font. Converts point size to pixels using provided DPI.
        /// px = pt * dpi / 72
        /// </summary>
        public static ICHtmlPlatformFont CreateSkiaFromGdiFont(Font font, float dpi = 96f)
        {
            if (font == null) throw new ArgumentNullException(nameof(font));
            float sizeInPx = font.Size * dpi / 72f;
            var style = (font.Bold) ? FontStyleSpec.Bold : FontStyleSpec.Regular;
            var spec = new FontSpec(font.Name ?? string.Empty, sizeInPx, style);
            return new SkiaPlatformFont(spec);
        }

        public static ICHtmlPlatformFont CreateFromFontSpec(FontSpec spec)
        {
#if WINDOWS
            try
            {
                var f = new Font(spec.FamilyName, spec.Size);
                return new GdiPlatformFont(f);
            }
            catch
            {
                return new SkiaPlatformFont(spec);
            }
#else
            return new SkiaPlatformFont(spec);
#endif
        }

        /// <summary>
        /// Create a Skia-based platform font from an existing FontSpec (assumed to use pixel size).
        /// </summary>
        public static ICHtmlPlatformFont CreateSkiaFromFontSpec(FontSpec spec)
        {
            if (spec == null) throw new ArgumentNullException(nameof(spec));
            return new SkiaPlatformFont(spec);
        }
    }

#if WINDOWS
    internal class GdiPlatformFont : ICHtmlPlatformFont
    {
        private Font _font;
        public GdiPlatformFont(Font f) => _font = f;
        public float GetHeight() => _font.GetHeight();
        public float Height => _font.Height;
        public void Dispose() { _font?.Dispose(); _font = null; }

        public SizeF MeasureString(string text, float maxWidth, out int charsFitted, out int linesFitted)
        {
            using var bmp = new Bitmap(1, 1);
            using var g = Graphics.FromImage(bmp);
            var sf = StringFormat.GenericTypographic;
            var size = g.MeasureString(text, _font, new SizeF(maxWidth, 100000f), sf, out charsFitted, out linesFitted);
            return size;
        }
    }
#endif

    internal class SkiaPlatformFont : ICHtmlPlatformFont
    {
        private SKTypeface? _tf;
        private SKPaint _paint;
        public SkiaPlatformFont(FontSpec spec)
        {
            try
            {
                _tf = CHtmlSkiaFontsCache.GetTypeface(spec);
            }
            catch
            {
                _tf = SKTypeface.Default;
            }
            if (_tf == null) _tf = SKTypeface.Default;
            _paint = new SKPaint { Typeface = _tf, TextSize = spec.Size, IsAntialias = true };
        }

        public float GetHeight()
        {
            var fm = _paint.FontMetrics;
            return Math.Abs(fm.Descent - fm.Ascent);
        }

        public float Height => GetHeight();

        public void Dispose()
        {
            try { _paint?.Dispose(); } catch { }
            _paint = null!;
            // Do not dispose _tf; it is managed by CHtmlSkiaFontsCache cache
            _tf = null;
        }

        public SizeF MeasureString(string text, float maxWidth, out int charsFitted, out int linesFitted)
        {
            charsFitted = 0;
            linesFitted = 0;
            if (string.IsNullOrEmpty(text)) return new SizeF(0, 0);

            float maxLineWidth = 0;
            int totalConsumed = 0;
            int idx = 0;
            while (idx < text.Length)
            {
                // SKPaint.BreakText may return a long; cast to int safely
                int consumed = (int)_paint.BreakText(text.AsSpan(idx), maxWidth);
                if (consumed <= 0) consumed = 1;
                var line = text.Substring(idx, consumed);
                var w = _paint.MeasureText(line);
                if (w > maxLineWidth) maxLineWidth = w;
                totalConsumed += consumed;
                idx += consumed;
                linesFitted++;
                if (linesFitted > 10000) break;
            }
            charsFitted = totalConsumed;
            float height = GetHeight() * Math.Max(1, linesFitted);
            return new SizeF(maxLineWidth, height);
        }
    }
}
