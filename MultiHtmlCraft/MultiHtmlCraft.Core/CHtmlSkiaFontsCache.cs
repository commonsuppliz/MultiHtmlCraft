using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SkiaSharp;

namespace MultiHtmlCraft.Core
{
    public static class CHtmlSkiaFontsCache
    {
        // family name (lower) -> file paths (absolute or relative to AppContext.BaseDirectory)
        private static readonly Dictionary<string, List<string>> _map = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        // file path -> loaded SKTypeface cache
        private static readonly Dictionary<string, SKTypeface> _fileCache = new Dictionary<string, SKTypeface>(StringComparer.OrdinalIgnoreCase);
        private static readonly object _fileCacheLock = new object();

        public static SKTypeface? DefaultSkiaTypeface = null;
        // base directory to resolve relative font paths (defaults to AppContext.BaseDirectory)
        private static string? _fontsJsonBaseDirectory = null;

        public static void InitSkiaFontsCache()
        {
            try
            {
#if DEBUG
                var currentTotalMemory = GC.GetTotalMemory(true);
#endif
                var baseDir = AppContext.BaseDirectory ?? Environment.CurrentDirectory;
                var jsonPath = Path.Combine(baseDir, "fonts.json");
                if (!File.Exists(jsonPath))
                {
#if DEBUG
                    if (commonLog.LoggingEnabled)
                        commonLog.LogEntry($"fonts.json not found at '{jsonPath}'. Will try assembly directory.");
#endif
                    // try to find fonts.json next to this assembly (MultiHtmlCraft.Core) for project-reference scenarios
                    try
                    {
                        var asmLocation = typeof(CHtmlSkiaFontsCache).Assembly.Location;
                        if (!string.IsNullOrWhiteSpace(asmLocation))
                        {
                            var asmDir = Path.GetDirectoryName(asmLocation) ?? baseDir;
                            var altPath = Path.Combine(asmDir, "fonts.json");
                            if (File.Exists(altPath))
                            {
                                jsonPath = altPath;
                                _fontsJsonBaseDirectory = asmDir;
                            }
                        }
                    }
                    catch { }

                    if (!File.Exists(jsonPath))
                    {
#if DEBUG
                        if (commonLog.LoggingEnabled)
                            commonLog.LogEntry($"fonts.json not found at '{jsonPath}'. Skipping custom font registration.");
#endif
                        DefaultSkiaTypeface ??= SKTypeface.Default;
                        return;
                    }
                }
                // if not set, use AppContext base dir
                if (string.IsNullOrWhiteSpace(_fontsJsonBaseDirectory))
                    _fontsJsonBaseDirectory = AppContext.BaseDirectory ?? Environment.CurrentDirectory;

                var json = File.ReadAllText(jsonPath);
                using var doc = JsonDocument.Parse(json);

                string? defaultFamilyFromJson = null;
                if (doc.RootElement.TryGetProperty("default", out var defProp))
                {
                    defaultFamilyFromJson = defProp.GetString();
                }
                bool _isDefaultSkiaTypefaceSetFromJson = false;
                string _strDeefaultFamilyFontFromJson = string.Empty;
                int bestPriority = int.MinValue;
                SKTypeface? bestPriorityTypeface = null;
                foreach (var f in doc.RootElement.GetProperty("fonts").EnumerateArray())
                {
                    var file = f.GetProperty("file").GetString();
                    var family = f.GetProperty("family").GetString();

                    // ensure _map contains normalized family key for preferred family lookups
                    if (!string.IsNullOrWhiteSpace(family))
                    {
                        var key = family.Trim().ToLowerInvariant();
                        if (!_map.ContainsKey(key))
                            _map[key] = new List<string>();
                    }

                    if (string.IsNullOrWhiteSpace(file) || string.IsNullOrWhiteSpace(family))
                        continue;

                    var resolved = ResolvePath(file);
                    // log resolved path and existence
                    try
                    {
                        if (commonLog.LoggingEnabled)
                        {
                            commonLog.LogEntry($"CHtmlSkiaFontsCache: resolving font file for family '{family}': {resolved} (exists={System.IO.File.Exists(resolved)})");
                        }
                    }
                    catch { }

                    RegisterFontFiles(family, resolved);

                    // pre-load the typeface into cache to validate it and potentially set default
                    var skfontFace = GetOrLoad(resolved);

                    // If JSON specified a default family, prefer it (compare case-insensitively and trimmed).
                    // Also try to ensure the chosen typeface supports a sample CJK glyph when applicable.
                    if (_isDefaultSkiaTypefaceSetFromJson == false && !string.IsNullOrWhiteSpace(family) && !string.IsNullOrWhiteSpace(defaultFamilyFromJson))
                    {
                        var famTrim = family.Trim();
                        var defTrim = defaultFamilyFromJson.Trim();
                        if (string.Equals(famTrim, defTrim, StringComparison.OrdinalIgnoreCase) ||
                            famTrim.IndexOf(defTrim, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            bool supportsSample = false;
                            try
                            {
                                var candidate = skfontFace ?? SKTypeface.Default;
                                using var testFont = new SKFont(candidate, 16);
                                var glyphs = new ushort[1];
                                try { testFont.GetGlyphs("あ", glyphs); } catch { glyphs[0] = 1; }
                                supportsSample = glyphs[0] != 0;
                            }
                            catch
                            {
                                supportsSample = true; // assume ok if test fails
                            }

                            if (supportsSample)
                            {
                                DefaultSkiaTypeface = skfontFace ?? SKTypeface.Default;
                                _strDeefaultFamilyFontFromJson = family;
                                _isDefaultSkiaTypefaceSetFromJson = true;
                            }
                        }
                    }

#if DEBUG
                    if (commonLog.LoggingEnabled)
                    {
                        commonLog.LogEntry($"Registered font family '{family}' from file '{resolved}'.");
                    }
#endif
                }

                // if json did not specify a default, pick the first registered font or SKTypeface.Default
                if (DefaultSkiaTypeface == null)
                {
                    // prefer highest priority candidate if any
                    if (bestPriorityTypeface != null)
                    {
                        DefaultSkiaTypeface = bestPriorityTypeface;
                    }
                    else
                    {
                        foreach (var kv in _map)
                        {
                            var files = kv.Value;
                            if (files.Count > 0)
                            {
                                DefaultSkiaTypeface = GetOrLoad(files[0]) ?? SKTypeface.Default;
                                break;
                            }
                        }
                    }
                }

                DefaultSkiaTypeface ??= SKTypeface.Default;

#if DEBUG
                var newTotalMemory = GC.GetTotalMemory(true);
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry($"CHtmlSkiaFontsCache initialized. Memory used: {newTotalMemory - currentTotalMemory} bytes.");
                    commonLog.LogEntry($"CHtmlSkiaFontsCache DefaultFont is set to \"{_strDeefaultFamilyFontFromJson}\"");
                }
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                if (commonLog.LoggingEnabled)
                    commonLog.LogEntry($"InitSkiaFontsCache failed: {ex}");
#endif
                // ensure default always set
                DefaultSkiaTypeface ??= SKTypeface.Default;
            }
        }

        public static void RegisterFontFiles(string familyName, params string[] filePaths)
        {
            if (string.IsNullOrWhiteSpace(familyName)) throw new ArgumentNullException(nameof(familyName));
            if (filePaths == null) throw new ArgumentNullException(nameof(filePaths));

            var key = familyName.Trim().ToLowerInvariant();
            if (!_map.TryGetValue(key, out var list))
            {
                list = new List<string>();
                _map[key] = list;
            }

            foreach (var fp in filePaths)
            {
                if (string.IsNullOrWhiteSpace(fp)) continue;
                var resolved = ResolvePath(fp);
                // List<T>.Contains は comparer オーバーロードを持たないので Exists を使う
                if (!list.Exists(x => string.Equals(x, resolved, StringComparison.OrdinalIgnoreCase)))
                    list.Add(resolved);
            }
        }

        public static void ClearRegisteredFonts()
        {
            _map.Clear();
        }

        public static IEnumerable<string> GetRegisteredFamilyNames()
        {
            return _map.Keys;
        }

        public static IEnumerable<string[]> GetRegisteredFontFiles()
        {
            foreach (var v in _map.Values)
                yield return v.ToArray();
        }

        private static IEnumerable<string> GetPreferredFamilyKeysForLang(string? lang)
        {
            if (string.IsNullOrWhiteSpace(lang)) yield break;
            var l = lang.Trim().ToLowerInvariant();
            var primary = l.Split('-', '_')[0];

            // return family keys (lowercase) that we prefer for certain languages
            switch (primary)
            {
                case "ko":
                case "kor":
                    yield return "noto sans kr";
                    yield return "noto sans";
                    yield break;
                case "rus":
                    yield return "open sans";
                    yield return "noto sans";
                    yield break;
                case "ja":
                case "jpn":
                    yield return "noto sans jp";
                    yield return "noto serif jp";
                    yield break;
                case "zh":
                case "zho":
                    yield return "noto sans tc"; // try TC/SC depending on assets
                    yield return "noto sans jp";
                    yield break;
                case "hi":
                case "hin":
                    yield return "noto sans";
                    yield break;
                default:
                    yield return "open sans";
                    yield break;
            }
        }

        [Obsolete("Use GetTypeface(FontSpec, string lang) to supply language for better fallback.")]
        public static SKTypeface GetTypeface(FontSpec fontSpec)
            => GetTypeface(fontSpec, null);

        public static SKTypeface GetTypeface(FontSpec fontSpec, string? lang)
        {
            if (fontSpec == null) throw new ArgumentNullException(nameof(fontSpec));

            var famRaw = (fontSpec.FamilyName ?? string.Empty).Trim();
            // treat explicit "Default" as unspecified so language-aware selection can occur
            var fam = string.Equals(famRaw, "default", StringComparison.OrdinalIgnoreCase) ? string.Empty : famRaw;

            // language-aware sample character to prefer fonts that contain glyphs for the language
            string? sample = GetSampleForLang(lang);

            // Try preferred family names for the language (e.g. mapping 'kor' -> 'Noto Sans KR')
            foreach (var pref in GetPreferredFamilyKeysForLang(lang))
            {
                if (_map.TryGetValue(pref, out var prefFiles) && prefFiles != null)
                {
                    foreach (var f in prefFiles)
                    {
                        try
                        {
                            if (!File.Exists(f)) continue;
                            var tf = GetOrLoad(f);
                            if (tf == null) continue;
                            using var testFont = new SKFont(tf, 16);
                            var glyphs = new ushort[1];
                            try { testFont.GetGlyphs(sample, glyphs); } catch { glyphs[0] = 1; }
                            if (glyphs[0] != 0)
                                return tf;
                        }
                        catch { }
                    }
                }
            }

            // If no family requested, try to find any registered font that supports the language/sample
            if (string.IsNullOrEmpty(fam))
            {
                if (!string.IsNullOrEmpty(sample))
                {
                    foreach (var kv in _map)
                    {
                        var fileList = kv.Value;
                        foreach (var f in fileList)
                        {
                            try
                            {
                                if (!File.Exists(f)) continue;
                                var tf = GetOrLoad(f);
                                if (tf == null) continue;
                                using var testPaint = new SKPaint { Typeface = tf, TextSize = 16, IsAntialias = true };
                                if (testPaint.MeasureText(sample) > 0)
                                    return tf;
                            }
                            catch
                            {
                                // ignore
                            }
                        }
                    }
                }

                return DefaultSkiaTypeface ?? SKTypeface.Default;
            }

            // If family looks like a path to a font file (has extension), try loading it directly.
            if (Path.HasExtension(fam))
            {
                var candidate = ResolvePath(fam);
                if (File.Exists(candidate))
                {
                    return GetOrLoad(candidate);
                }
            }

            string key = fam.ToLowerInvariant();
            if (_map.TryGetValue(key, out var files) && files != null)
            {
                // First try to find a font file that actually contains glyphs for the target language/sample.
                if (!string.IsNullOrEmpty(sample))
                {
                foreach (var f in files)
                {
                    try
                    {
                        if (!File.Exists(f)) continue;
                        var tf = GetOrLoad(f);
                        if (tf == null) continue;
                        using var testFont = new SKFont(tf, 16);
                        var glyphs = new ushort[1];
                        try { testFont.GetGlyphs(sample, glyphs); } catch { glyphs[0] = 1; }
                        if (glyphs[0] != 0)
                            return tf;
                    }
                    catch
                    {
                        // ignore and continue to next file
                    }
                }
                }

                // fallback: return first existing file for family
                foreach (var f in files)
                {
                    if (File.Exists(f))
                        return GetOrLoad(f);
                }
            }

            // Try create by family name & style
            try
            {
                var style = MapStyle(fontSpec.Style);
                var tf = SKTypeface.FromFamilyName(fontSpec.FamilyName, style);
                if (tf != null)
                {
                    if (!string.IsNullOrEmpty(sample))
                    {
                        try
                        {
                            using var testFont = new SKFont(tf, 16);
                            var glyphs = new ushort[1];
                            try { testFont.GetGlyphs(sample, glyphs); } catch { glyphs[0] = 1; }
                            if (glyphs[0] != 0)
                                return tf;
                        }
                        catch
                        {
                            // ignore and accept tf if test fails
                            return tf;
                        }
                        // if the system family doesn't contain the sample, continue to fallback
                    }
                    else
                    {
                        return tf;
                    }
                }
            }
            catch
            {
                // ignored
            }

            // language-aware secondary attempt: try to find any registered font that supports the language
            if (!string.IsNullOrEmpty(sample))
            {
                foreach (var kv in _map)
                {
                    var fileList = kv.Value;
                        foreach (var f in fileList)
                        {
                            try
                            {
                                if (!File.Exists(f)) continue;
                                var tf = GetOrLoad(f);
                                if (tf == null) continue;
                                using var testFont = new SKFont(tf, 16);
                                var glyphs = new ushort[1];
                                try { testFont.GetGlyphs(sample, glyphs); } catch { glyphs[0] = 1; }
                                if (glyphs[0] != 0)
                                    return tf;
                            }
                            catch
                            {
                                // ignore
                            }
                        }
                }
            }

            // final fallback
            return DefaultSkiaTypeface ?? SKTypeface.Default;
        }

        public static SKTypeface GetOrLoad(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath));

            var candidate = ResolvePath(filePath);
            if (!File.Exists(candidate))
                return SKTypeface.Default;

            lock (_fileCacheLock)
            {
                if (_fileCache.TryGetValue(candidate, out var cached) && cached != null)
                    return cached;
            }

            try
            {
                var tf = SKTypeface.FromFile(candidate);
                if (tf == null)
                    return SKTypeface.Default;

                lock (_fileCacheLock)
                {
                    if (!_fileCache.TryGetValue(candidate, out var existing) || existing == null)
                    {
                        _fileCache[candidate] = tf;
                        return tf;
                    }
                    else
                    {
                        // someone loaded concurrently
                        tf.Dispose();
                        return existing;
                    }
                }
            }
            catch
            {
                return SKTypeface.Default;
            }
        }

        public static void ClearCachedTypefaces()
        {
            lock (_fileCacheLock)
            {
                foreach (var kv in _fileCache)
                {
                    try { kv.Value?.Dispose(); } catch { /* ignore */ }
                }
                _fileCache.Clear();
            }
        }

        private static string ResolvePath(string path)
        {
            if (Path.IsPathRooted(path)) return path;
            var baseDir = _fontsJsonBaseDirectory ?? AppContext.BaseDirectory ?? Environment.CurrentDirectory;
            return Path.Combine(baseDir, path);
        }

        private static SKFontStyle MapStyle(FontStyleSpec style)
        {
            return style switch
            {
                FontStyleSpec.Bold => new SKFontStyle(SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright),
                FontStyleSpec.Italic => new SKFontStyle(SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Italic),
                FontStyleSpec.BoldItalic => new SKFontStyle(SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Italic),
                _ => new SKFontStyle(SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright),
            };
        }

        private static string? GetSampleForLang(string? lang)
        {
            if (string.IsNullOrWhiteSpace(lang)) return null;
            var l = lang.Trim().ToLowerInvariant();

            // match primary subtag
            var primary = l.Split('-', '_')[0];

            // handle both 2-letter and common 3-letter ISO codes
            return primary switch
            {
                // Japanese
                "ja" or "jp" or "jpn" => "あ",
                // Chinese
                "zh" or "zho" or "chi" or "zh-cn" or "zh-tw" => "你",
                // Korean
                "ko" or "kor" => "가",
                // Thai
                "th" or "tha" => "ก",
                // Arabic
                "ar" or "ara" => "م",
                // Hebrew
                "he" or "heb" => "א",
                // Russian / Cyrillic
                "ru" or "rus" => "я",
                // Greek
                "el" or "ell" or "gre" => "λ",
                // Hindi / Devanagari
                "hi" or "hin" => "न",
                _ => null,
            };
        }
    }
}