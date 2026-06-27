using Avalonia;
using Avalonia.Media;
using MultiHtmlCraft.Core;
using System.Collections.Concurrent;
using System.Globalization;
/// <summary>
/// This class provides functionality to measure the size of multi-line text strings for given font specifications using Avalonia's text rendering capabilities.
/// </summary>
public static class CHtmlMultiTextMeasurer
{
    private const int MaxCacheSize = 1000;
    private static readonly ConcurrentDictionary<TextCacheKey, SizeFSpec> _cache = new();
    private static readonly ConcurrentQueue<TextCacheKey> _history = new();


    private record TextCacheKey(string Text, string FamilyName, float Size, FontStyleSpec Style);

    public static SizeFSpec MeasureText(string text, FontSpec fontSpec)
    {
        if (string.IsNullOrEmpty(text)) return SizeFSpec.Empty;


        var key = new TextCacheKey(text, fontSpec.FamilyName, fontSpec.Size, fontSpec.Style);

        if (_cache.TryGetValue(key, out var cachedSize))
        {
            return cachedSize;
        }

    
        var (style, weight) = ConvertToAvaloniaStyle(fontSpec.Style);

        var ft = new FormattedText(
            text,
            CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            new Typeface(fontSpec.FamilyName, style, weight),
            fontSpec.Size,
            null
        );
        var size = new Size(ft.Width, ft.Height);


        if (_cache.TryAdd(key, new SizeFSpec((float)size.Width, (float)size.Height)))
        {
            _history.Enqueue(key);
            while (_history.Count > MaxCacheSize)
            {
                if (_history.TryDequeue(out var oldestKey))
                {
                    _cache.TryRemove(oldestKey, out _);
                }
            }
        }

        return new SizeFSpec((float)size.Width, (float)size.Height);
    }

    
    private static (FontStyle style, FontWeight weight) ConvertToAvaloniaStyle(FontStyleSpec spec)
    {
        return spec switch
        {
            FontStyleSpec.Regular => (FontStyle.Normal, FontWeight.Normal),
            FontStyleSpec.Bold => (FontStyle.Normal, FontWeight.Bold),
            FontStyleSpec.Italic => (FontStyle.Italic, FontWeight.Normal),
            FontStyleSpec.BoldItalic => (FontStyle.Italic, FontWeight.Bold),
            _ => (FontStyle.Normal, FontWeight.Normal)
        };
    }
}