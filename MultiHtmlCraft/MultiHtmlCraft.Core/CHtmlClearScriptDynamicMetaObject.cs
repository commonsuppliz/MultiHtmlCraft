using Avalonia.Media.Immutable;
using MultiHtmlCraft.Core;
using MultiHtmlCraft.Interfaces;
using NiL.JS.BaseLibrary;
using NiL.JS.Statements;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;


namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// This class is to support script engines which use DynamicObject. Since it is difficult to support DynamicObject in this project, DynamicMetaObject is used instead.
    /// Defensive: avoid throwing exceptions back into ClearScript by returning safe fallbacks.
    /// </summary>
    public class CHtmlClearScriptDynamicMetaObject<T> : DynamicMetaObject
    {
        private static readonly ConcurrentDictionary<(Type, string, Type[] parameterTypes), MethodInfo> ClearScriptMetaObjectMethodCache = new();
        private static readonly ConcurrentDictionary<(Type, string), PropertyInfo> ClearScriptMetaObjectPropertyCache = new();
      

        // Method to get MethodInfo from cache or add it if not present
        private static MethodInfo? GetCachedMethod(Type type, string methodName, Type[] parameterTypes)
        {
            var key = (type, methodName, parameterTypes);
            return ClearScriptMetaObjectMethodCache.GetOrAdd(key, _ => type.GetMethod(methodName, parameterTypes));
        }

        // Return nullable PropertyInfo to avoid throwing when property is not found
        private static PropertyInfo? GetCachedProperty(Type type, string propertyName)
        {
            var key = (type, propertyName);
            return ClearScriptMetaObjectPropertyCache.GetOrAdd(key, _ => GetPropertyIgnoreCaseSafe(type, propertyName));
        }

        public CHtmlClearScriptDynamicMetaObject(System.Linq.Expressions.Expression expression, object value)
            : base(expression, BindingRestrictions.Empty, value)
        {
        }

        // Safe case-insensitive property lookup to avoid AmbiguousMatchException from Type.GetProperty
        private static PropertyInfo? GetPropertyIgnoreCaseSafe(Type t, string name)
        {
            try
            {
                // Try standard lookup first
                var p = t.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (p != null) return p;
            }
            catch (AmbiguousMatchException)
            {
                // fall through to manual resolution
            }

            try
            {
                return t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .FirstOrDefault(pi => string.Equals(pi.Name, name, StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                return null;
            }
        }

        // Safe method lookup to avoid AmbiguousMatchException from Type.GetMethod
        private static MethodInfo? GetMethodIgnoreAmbiguous(Type t, string name, BindingFlags flags, int? paramCount = null)
        {
            try
            {
                var m = t.GetMethod(name, flags);
                if (m != null) return m;
            }
            catch (AmbiguousMatchException)
            {
                // fall through
            }

            try
            {
                return t.GetMethods(flags)
                    .Where(mi => string.Equals(mi.Name, name, StringComparison.OrdinalIgnoreCase)
                        && (!paramCount.HasValue || mi.GetParameters().Length == paramCount.Value))
                    .FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        // Helper: safely unwrap DynamicMetaObject wrappers or common script wrappers, return original if nothing to unwrap
        private static object? UnwrapValue(object? v)
        {
            if (v is null) return null;

            object? current = v;
            for (int i = 0; i < 6 && current != null; i++)
            {
                // Unwrap ClearScript/DynamicMetaObject wrapper
                if (current is DynamicMetaObject dmo)
                {
                    try { current = dmo.Value; continue; } catch { break; }
                }

                var t = current.GetType();

                // Try common wrapper property names (use safe lookup to avoid AmbiguousMatch)
                var tryProps = new[] { "Target", "UnderlyingObject", "Value", "WrappedObject", "Underlying" };
                bool unwrapped = false;
                foreach (var pn in tryProps)
                {
                    try
                    {
                        var p = GetPropertyIgnoreCaseSafe(t, pn);
                        if (p != null)
                        {
                            try
                            {
                                var extracted = p.GetValue(current);
                                if (extracted != null)
                                {
                                    current = extracted;
                                    unwrapped = true;
                                    break;
                                }
                            }
                            catch { }
                        }
                    }
                    catch { }
                }
                if (unwrapped) continue;

                // Special-case NiL.JS or ClearScript wrapper types: try common unwrapping methods/properties
                if (t.FullName != null && (t.FullName.StartsWith("NiL.JS") || t.FullName.Contains("ClearScript") || t.FullName.Contains("ScriptObject")))
                {
                    // common methods to extract host object
                    var tryMethodNames = new[] { "ToObject", "ToHostObject", "Unwrap", "GetUnderlyingObject", "GetHostObject", "GetHostItem" };
                    foreach (var mn in tryMethodNames)
                    {
                        try
                        {
                            var mm = GetMethodIgnoreAmbiguous(t, mn, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, 0);
                            if (mm != null)
                            {
                                try { var res = mm.Invoke(current, null); if (res != null) { current = res; goto CONTINUE_UNWRAP; } } catch { }
                            }
                        }
                        catch { }
                    }

                    // try properties
                    var tryPropNames = new[] { "value", "Value", "Underlying", "UnderlyingObject", "Target", "HostObject", "HostTarget", "WrappedObject" };
                    foreach (var pn in tryPropNames)
                    {
                        try
                        {
                            var p = GetPropertyIgnoreCaseSafe(t, pn);
                            if (p != null)
                            {
                                try { var ex = p.GetValue(current); if (ex != null) { current = ex; goto CONTINUE_UNWRAP; } } catch { }
                            }
                        }
                        catch { }
                    }

                    // try indexer/property "GetProperty" or "Get"
                    try
                    {
                        var getProp = GetMethodIgnoreAmbiguous(t, "GetProperty", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, 1);
                        if (getProp != null)
                        {
                            try { var ex = getProp.Invoke(current, new object[] { "value" }); if (ex != null) { current = ex; goto CONTINUE_UNWRAP; } } catch { }
                        }
                    }
                    catch { }
                }

            CONTINUE_UNWRAP:;

                break; // nothing more to unwrap
            }

            return current;
        }

        public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args)
        {
            // Log entry for diagnostics: show which member is being invoked and target type
            try
            {

                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
                {
                    commonLog.LogEntry("[BindInvokeMember] binder.Name={0}, TargetType={1}", binder?.Name, this.Value?.GetType().FullName);
                }
                

                  
                // Directly handle document.createElement/getElementById invocations to avoid ClearScript treating members as non-callable
                if (this.Value is CHtmlDocument docTarget && (string.Equals(binder.Name, "getElementById", StringComparison.OrdinalIgnoreCase) || string.Equals(binder.Name, "createElement", StringComparison.OrdinalIgnoreCase)))
                {
                    try
                    {
                        var arg0 = args != null && args.Length > 0 ? UnwrapValue(args[0].Value) ?? args[0].Value : null;
                        var s = arg0?.ToString();
                        if (string.IsNullOrEmpty(s)) return new DynamicMetaObject(Expression.Constant(null, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                        object result = null!;
                        if (string.Equals(binder.Name, "getElementById", StringComparison.OrdinalIgnoreCase)) result = docTarget.getElementById(s);
                        else result = docTarget.createElement(s);
                        return new DynamicMetaObject(Expression.Constant(result, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                    }
                    catch { return new DynamicMetaObject(Expression.Constant(null, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)); }
                }

                // Also handle direct invocation of document.addEventListener/removeEventListener (InvokeMember path)
                if (this.Value is CHtmlDocument docInvoke && (string.Equals(binder.Name, "addEventListener", StringComparison.OrdinalIgnoreCase) || string.Equals(binder.Name, "removeEventListener", StringComparison.OrdinalIgnoreCase)))
                {
                    try
                    {
                        var unwrappedArgs = args?.Select(a => UnwrapValue(a?.Value) ?? a?.Value).ToArray() ?? System.Array.Empty<object?>();
                        var name = unwrappedArgs.Length > 0 ? unwrappedArgs[0]?.ToString() ?? string.Empty : string.Empty;
                        var handler = unwrappedArgs.Length > 1 ? unwrappedArgs[1] : null;
                        var options = unwrappedArgs.Length > 2 ? unwrappedArgs[2] : null;
                        if (!string.IsNullOrEmpty(name))
                        {
                            if (string.Equals(binder.Name, "addEventListener", StringComparison.OrdinalIgnoreCase))
                            {
                                try { docInvoke.addEventListener(name, handler, options); } catch { }
                            }
                            else
                            {
                                try { docInvoke.removeEventListener(name, handler, options); } catch { }
                            }
                        }
                        return new DynamicMetaObject(Expression.Constant(null, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                    }
                    catch { return new DynamicMetaObject(Expression.Constant(null, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)); }
                }

                // Also handle direct invocation of element-level event APIs (addEventListener/removeEventListener/attachEvent/detachEvent)
                if (this.Value is CHtmlElement elemInvoke && 
                    (string.Equals(binder.Name, "addEventListener", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(binder.Name, "removeEventListener", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(binder.Name, "attachEvent", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(binder.Name, "detachEvent", StringComparison.OrdinalIgnoreCase)))
                {
                    try
                    {
                        var unwrappedArgs = args?.Select(a => UnwrapValue(a?.Value) ?? a?.Value).ToArray() ?? System.Array.Empty<object?>();
                        var name = unwrappedArgs.Length > 0 ? unwrappedArgs[0]?.ToString() ?? string.Empty : string.Empty;
                        var handler = unwrappedArgs.Length > 1 ? unwrappedArgs[1] : null;
                        var options = unwrappedArgs.Length > 2 ? unwrappedArgs[2] : null;
                        if (!string.IsNullOrEmpty(name))
                        {
                            if (string.Equals(binder.Name, "addEventListener", StringComparison.OrdinalIgnoreCase))
                            {
                                try { elemInvoke.addEventListener(name, handler, options); } catch { }
                            }
                            else if (string.Equals(binder.Name, "removeEventListener", StringComparison.OrdinalIgnoreCase))
                            {
                                try { elemInvoke.removeEventListener(name, handler, options); } catch { }
                            }
                            else if (string.Equals(binder.Name, "attachEvent", StringComparison.OrdinalIgnoreCase))
                            {
                                try { elemInvoke.attachEvent(name, handler); } catch { }
                            }
                            else if (string.Equals(binder.Name, "detachEvent", StringComparison.OrdinalIgnoreCase))
                            {
                                try { elemInvoke.detachEvent(name, handler); } catch { }
                            }
                        }
                        return new DynamicMetaObject(Expression.Constant(null, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                    }
                    catch { return new DynamicMetaObject(Expression.Constant(null, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)); }
                }

                // Handle CHtmlMediaElement-specific methods (canPlayType, play, pause, load)
                if (this.Value is CHtmlMediaElement mediaInvoke && 
                    (string.Equals(binder.Name, "canPlayType", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(binder.Name, "play", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(binder.Name, "pause", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(binder.Name, "load", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(binder.Name, "addTextTrack", StringComparison.OrdinalIgnoreCase)))
                {
                    // DEBUG: Log that we matched CHtmlMediaElement in BindInvokeMember
                    System.Diagnostics.Debug.WriteLine($"[BindInvokeMember] CHtmlMediaElement matched for method={binder.Name}, tagName={mediaInvoke?.tagName}");
                    if (commonLog.LoggingEnabled)
                    {
                        commonLog.LogEntry("[BindInvokeMember] CHtmlMediaElement matched for method={0}, tagName={1}", binder.Name, mediaInvoke?.tagName);
                    }
                    try
                    {
                        var unwrappedArgs = args?.Select(a => UnwrapValue(a?.Value) ?? a?.Value).ToArray() ?? System.Array.Empty<object?>();
                        if (string.Equals(binder.Name, "canPlayType", StringComparison.OrdinalIgnoreCase))
                        {
                            var mediaType = unwrappedArgs.Length > 0 ? unwrappedArgs[0] : null;
                            var result = mediaInvoke.canPlayType(mediaType) ?? string.Empty;
                            return new DynamicMetaObject(Expression.Constant(result, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                        }
                        else if (string.Equals(binder.Name, "play", StringComparison.OrdinalIgnoreCase))
                        {
                            try { mediaInvoke.play(); } catch { }
                            return new DynamicMetaObject(Expression.Constant(null, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                        }
                        else if (string.Equals(binder.Name, "pause", StringComparison.OrdinalIgnoreCase))
                        {
                            try { mediaInvoke.pause(); } catch { }
                            return new DynamicMetaObject(Expression.Constant(null, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                        }
                        else if (string.Equals(binder.Name, "load", StringComparison.OrdinalIgnoreCase))
                        {
                            try { mediaInvoke.load(); } catch { }
                            return new DynamicMetaObject(Expression.Constant(null, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                        }
                        else if (string.Equals(binder.Name, "addTextTrack", StringComparison.OrdinalIgnoreCase))
                        {
                            var kind = unwrappedArgs.Length > 0 ? unwrappedArgs[0] : null;
                            var label = unwrappedArgs.Length > 1 ? unwrappedArgs[1] : null;
                            var language = unwrappedArgs.Length > 2 ? unwrappedArgs[2] : null;
                            var result = mediaInvoke.addTextTrack(kind, label, language);
                            return new DynamicMetaObject(Expression.Constant(result, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                        }
                    }
                    catch { return new DynamicMetaObject(Expression.Constant(null, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)); }
                }

                // Handle window.getComputedStyle
                if (this.Value is CHtmlMultiversalWindow window && string.Equals(binder.Name, "getComputedStyle", StringComparison.OrdinalIgnoreCase))
                {
                    Func<object, object, object> del = (elementArg, pseudoArg) =>
                    {
                        try
                        {
                            var el = UnwrapValue(elementArg) as CHtmlElement;
                            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                            if (el != null)
                            {
                                try { var rect = el.getBoundingClientRect(); } catch { }
                                var disp = el.GetDynamicMember("display")?.ToString();
                                dict["display"] = string.IsNullOrEmpty(disp) ? "block" : disp!;
                                var pos = el.GetDynamicMember("position")?.ToString();
                                dict["position"] = string.IsNullOrEmpty(pos) ? "static" : pos!;
                                var color = el.GetDynamicMember("color")?.ToString(); if (!string.IsNullOrEmpty(color)) dict["color"] = color!;
                                var bg = el.GetDynamicMember("backgroundColor")?.ToString(); if (!string.IsNullOrEmpty(bg)) dict["background-color"] = bg!;
                                dict["border-top-width"] = "0px";
                                dict["border-right-width"] = "0px";
                                dict["border-bottom-width"] = "0px";
                                dict["border-left-width"] = "0px";
                                dict["width"] = dict.ContainsKey("width") ? dict["width"] : "auto";
                                dict["height"] = dict.ContainsKey("height") ? dict["height"] : "auto";
                            }

                            dynamic expando = new System.Dynamic.ExpandoObject();
                            var bag = (IDictionary<string, object?>)expando;
                            bag["getPropertyValue"] = new Func<object, object>((name) =>
                            {
                                var key = name?.ToString() ?? string.Empty;
                                if (string.IsNullOrEmpty(key)) return string.Empty;
                                return dict.TryGetValue(key, out var v) ? (object)v : string.Empty;
                            });
                            bag["setProperty"] = new Action<object, object>((name, value) =>
                            {
                                var key = name?.ToString() ?? string.Empty;
                                var val = value?.ToString() ?? string.Empty;
                                if (!string.IsNullOrEmpty(key)) dict[key] = val;
                            });
                            bag["removeProperty"] = new Action<object>((name) =>
                            {
                                var key = name?.ToString() ?? string.Empty;
                                if (!string.IsNullOrEmpty(key)) dict.Remove(key);
                            });
                            bag["toString"] = new Func<string>(() =>
                            {
                                if (dict.Count == 0) return string.Empty;
                                return string.Join("; ", dict.Select(kv => $"{kv.Key}: {kv.Value}")) + ";";
                            });
                            foreach (var kv in dict) bag[kv.Key] = kv.Value;
                            return expando;
                        }
                        catch { return new System.Dynamic.ExpandoObject(); }
                    };
                    return new DynamicMetaObject(Expression.Constant(del, typeof(Func<object, object, object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                }

                // Handle document.getComputedStyle
                if (this.Value is CHtmlDocument doc && string.Equals(binder.Name, "getComputedStyle", StringComparison.OrdinalIgnoreCase))
                {
                    Func<object, object, object> del = (elementArg, pseudoArg) =>
                    {
                        try
                        {
                            var el = UnwrapValue(elementArg) as CHtmlElement;
                            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                            if (el != null)
                            {
                                var disp = el.GetDynamicMember("display")?.ToString();
                                dict["display"] = string.IsNullOrEmpty(disp) ? "block" : disp!;
                                var pos = el.GetDynamicMember("position")?.ToString();
                                dict["position"] = string.IsNullOrEmpty(pos) ? "static" : pos!;
                                var color = el.GetDynamicMember("color")?.ToString(); if (!string.IsNullOrEmpty(color)) dict["color"] = color!;
                                var bg = el.GetDynamicMember("backgroundColor")?.ToString(); if (!string.IsNullOrEmpty(bg)) dict["background-color"] = bg!;
                                dict["width"] = dict.ContainsKey("width") ? dict["width"] : "auto";
                                dict["height"] = dict.ContainsKey("height") ? dict["height"] : "auto";
                            }

                            dynamic expando = new System.Dynamic.ExpandoObject();
                            var bag = (IDictionary<string, object?>)expando;
                            bag["getPropertyValue"] = new Func<object, object>((name) =>
                            {
                                var key = name?.ToString() ?? string.Empty;
                                if (string.IsNullOrEmpty(key)) return string.Empty;
                                return dict.TryGetValue(key, out var v) ? (object)v : string.Empty;
                            });
                            bag["setProperty"] = new Action<object, object>((name, value) =>
                            {
                                var key = name?.ToString() ?? string.Empty;
                                var val = value?.ToString() ?? string.Empty;
                                if (!string.IsNullOrEmpty(key)) dict[key] = val;
                            });
                            bag["removeProperty"] = new Action<object>((name) =>
                            {
                                var key = name?.ToString() ?? string.Empty;
                                if (!string.IsNullOrEmpty(key)) dict.Remove(key);
                            });
                            bag["toString"] = new Func<string>(() =>
                            {
                                if (dict.Count == 0) return string.Empty;
                                return string.Join("; ", dict.Select(kv => $"{kv.Key}: {kv.Value}")) + ";";
                            });
                            foreach (var kv in dict) bag[kv.Key] = kv.Value;
                            return expando;
                        }
                        catch { return new System.Dynamic.ExpandoObject(); }
                    };
                    return new DynamicMetaObject(Expression.Constant(del, typeof(Func<object, object, object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                }

                // Handle CHtmlDocument method invocations directly
                if (this.Value is CHtmlDocument document)
                {
                    var self = this.Value as CHtmlDocument;
                    switch (binder.Name)
                    {
                        /*
                        case "GetDynamicMemberNames":
                            return (DynamicMetaObject)this.GetDynamicMemberNames();
                        */

                        case "createElement":
                            {
                                var tagName = args.Length > 0 ? UnwrapValue(args[0].Value)?.ToString() ?? args[0].Value?.ToString() : null;
                                if (!string.IsNullOrEmpty(tagName))
                                {
                                    var result = document.createElement(tagName);
                                    return new DynamicMetaObject(
                                        Expression.Constant(result, typeof(object)),
                                        BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                    );
                                }
                                return new DynamicMetaObject(
                                    Expression.Constant(null, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        case "getElementById":
                            {
                                var id = args.Length > 0 ? UnwrapValue(args[0].Value)?.ToString() ?? args[0].Value?.ToString() : null;
                                if (!string.IsNullOrEmpty(id))
                                {
                                    var result = document.getElementById(id);
                                    return new DynamicMetaObject(
                                        Expression.Constant(result, typeof(object)),
                                        BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                    );
                                }
                                return new DynamicMetaObject(
                                    Expression.Constant(null, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        case "getElementsByTagName":
                            {
                                var tagName = args.Length > 0 ? UnwrapValue(args[0].Value)?.ToString() : null;
                                if (!string.IsNullOrEmpty(tagName))
                                {
                                    var result = document.getElementsByTagName(tagName);
                                    return new DynamicMetaObject(
                                        Expression.Constant(result, typeof(object)),
                                        BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                    );
                                }
                                return new DynamicMetaObject(
                                    Expression.Constant(null, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        case "addEventListener":
                            {
                                // 明示的に呼び出し可能な CLR デリゲートを返す（ClearScript が関数として扱える）
                                Action<object, object, object> addEvt = (nameArg, handlerArg, optionsArg) =>
                                {
                                    try
                                    {
                                        var nameStr = UnwrapValue(nameArg)?.ToString() ?? string.Empty;
                                        var handler = UnwrapValue(handlerArg) ?? handlerArg;
                                        // optionsArg はそのまま渡す（null 可）
                                        if (!string.IsNullOrEmpty(nameStr))
                                        {
                                            try { self.addEventListener(nameStr, handler, optionsArg); } catch { }
                                        }
                                    }
                                    catch { }
                                };
                                return new DynamicMetaObject(Expression.Constant(addEvt, typeof(Action<object, object, object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }
                        case "removeEventListener":
                            {
                                Action<object, object, object> remEvt = (nameArg, handlerArg, optionsArg) =>
                                {
                                    try
                                    {
                                        var nameStr = UnwrapValue(nameArg)?.ToString() ?? string.Empty;
                                        var handler = UnwrapValue(handlerArg) ?? handlerArg;
                                        if (!string.IsNullOrEmpty(nameStr))
                                        {
                                            try { self.removeEventListener(nameStr, handler, optionsArg); } catch { }
                                        }
                                    }
                                    catch { }
                                };
                                return new DynamicMetaObject(Expression.Constant(remEvt, typeof(Action<object, object, object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }
                        case "createEvent":
                            {
                                var methodCreateEvent = typeof(CHtmlDocument).GetMethod("createEvent", new Type[] { typeof(string) });
                                if (methodCreateEvent != null)
                                {
                                    Func<object, object> delCreateEvent = (eventType) =>
                                    {
                                        try
                                        {
                                            var unwrapped = UnwrapValue(eventType);
                                            var strValue = unwrapped?.ToString() ?? eventType?.ToString();
                                            if (!string.IsNullOrEmpty(strValue))
                                            {
                                                return methodCreateEvent.Invoke(self, new object[] { strValue });
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            try { if (commonLog.LoggingEnabled) commonLog.LogEntry("createEvent delegate exception: {0}", ex.Message); } catch { }
                                        }
                                        return null;
                                    };
                                    return new DynamicMetaObject(Expression.Constant(delCreateEvent), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                }
                                break;

                    
                            }
                    }
                }

                // Handle CHtmlElement method invocations directly (ClearScript may call BindInvokeMember instead of BindGetMember for method calls)
                if (this.Value is CHtmlElement elem)
                {
                    switch (binder.Name)
                    {
                        case "insertBefore":
                            {
                                System.Diagnostics.Debug.WriteLine($"[CHtmlElement.BindInvokeMember] insertBefore called on tagName={elem.tagName}, args.Length={args.Length}");
                                if (args.Length >= 2)
                                {
                                    var newNode = UnwrapValue(args[0].Value) as CHtmlElement ?? args[0].Value as CHtmlElement;
                                    var refNode = UnwrapValue(args[1].Value) as CHtmlElement ?? args[1].Value as CHtmlElement;
                                    try
                                    {
                                        var result = elem.insertBefore(newNode, refNode);
                                        return new DynamicMetaObject(
                                            Expression.Constant(result, typeof(object)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    }
                                    catch (Exception ex)
                                    {
                                        System.Diagnostics.Debug.WriteLine($"[CHtmlElement.BindInvokeMember] insertBefore exception: {ex.Message}");
                                    }
                                }
                                else if (args.Length == 1)
                                {
                                    var newNode = UnwrapValue(args[0].Value) as CHtmlElement ?? args[0].Value as CHtmlElement;
                                    try
                                    {
                                        var result = elem.insertBefore(newNode, null);
                                        return new DynamicMetaObject(
                                            Expression.Constant(result, typeof(object)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    }
                                    catch (Exception ex)
                                    {
                                        System.Diagnostics.Debug.WriteLine($"[CHtmlElement.BindInvokeMember] insertBefore (1 arg) exception: {ex.Message}");
                                    }
                                }
                                return new DynamicMetaObject(
                                    Expression.Constant(null, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        case "appendChild":
                            {
                                if (args.Length >= 1)
                                {
                                    var child = UnwrapValue(args[0].Value) as CHtmlElement ?? args[0].Value as CHtmlElement;
                                    try
                                    {
                                        var result = elem.appendChild(child);
                                        return new DynamicMetaObject(
                                            Expression.Constant(result, typeof(object)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    }
                                    catch { }
                                }
                                return new DynamicMetaObject(
                                    Expression.Constant(null, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        case "removeChild":
                            {
                                if (args.Length >= 1)
                                {
                                    var child = UnwrapValue(args[0].Value) as CHtmlElement ?? args[0].Value as CHtmlElement;
                                    try
                                    {
                                        var result = elem.removeChild(child);
                                        return new DynamicMetaObject(
                                            Expression.Constant(result, typeof(object)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    }
                                    catch { }
                                }
                                return new DynamicMetaObject(
                                    Expression.Constant(null, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        case "getElementsByTagName":
                            {
                                var tagName = args.Length > 0 ? UnwrapValue(args[0].Value)?.ToString() ?? args[0].Value?.ToString() : null;
                                if (!string.IsNullOrEmpty(tagName))
                                {
                                    var result = elem.getElementsByTagName(tagName);
                                    return new DynamicMetaObject(
                                        Expression.Constant(result, typeof(object)),
                                        BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                    );
                                }
                                return new DynamicMetaObject(
                                    Expression.Constant(null, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        case "getAttribute":
                            {
                                var attrName = args.Length > 0 ? UnwrapValue(args[0].Value)?.ToString() ?? args[0].Value?.ToString() : null;
                                if (!string.IsNullOrEmpty(attrName))
                                {
                                    var result = elem.getAttribute(attrName);
                                    return new DynamicMetaObject(
                                        Expression.Constant(result, typeof(object)),
                                        BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                    );
                                }
                                return new DynamicMetaObject(
                                    Expression.Constant(null, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        case "setAttribute":
                            {
                                if (args.Length >= 2)
                                {
                                    var attrName = UnwrapValue(args[0].Value)?.ToString() ?? args[0].Value?.ToString();
                                    var attrValue = UnwrapValue(args[1].Value)?.ToString() ?? args[1].Value?.ToString() ?? string.Empty;
                                    if (!string.IsNullOrEmpty(attrName))
                                    {
                                        elem.setAttribute(attrName, attrValue);
                                    }
                                }
                                return new DynamicMetaObject(
                                    Expression.Constant(null, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        case "removeAttribute":
                            {
                                var attrName = args.Length > 0 ? UnwrapValue(args[0].Value)?.ToString() ?? args[0].Value?.ToString() : null;
                                if (!string.IsNullOrEmpty(attrName))
                                {
                                    elem.removeAttribute(attrName);
                                }
                                return new DynamicMetaObject(
                                    Expression.Constant(null, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        case "cloneNode":
                            {
                                var deep = args.Length > 0 && (args[0].Value is bool b ? b : false);
                                try
                                {
                                    var result = elem.cloneNode(deep);
                                    return new DynamicMetaObject(
                                        Expression.Constant(result, typeof(object)),
                                        BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                    );
                                }
                                catch { }
                                return new DynamicMetaObject(
                                    Expression.Constant(null, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        case "addEventListener":
                            {
                                Action<object, object, object> addEvt = (nameArg, handlerArg, optionsArg) =>
                                {
                                    try
                                    {
                                        var nameStr = UnwrapValue(nameArg)?.ToString() ?? string.Empty;
                                        var handler = UnwrapValue(handlerArg) ?? handlerArg;
                                        if (!string.IsNullOrEmpty(nameStr))
                                        {
                                            try { elem.addEventListener(nameStr, handler, optionsArg); } catch { }
                                        }
                                    }
                                    catch { }
                                };
                                return new DynamicMetaObject(Expression.Constant(addEvt, typeof(Action<object, object, object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }
                        case "removeEventListener":
                            {
                                Action<object, object, object> remEvt = (nameArg, handlerArg, optionsArg) =>
                                {
                                    try
                                    {
                                        var nameStr = UnwrapValue(nameArg)?.ToString() ?? string.Empty;
                                        var handler = UnwrapValue(handlerArg) ?? handlerArg;
                                        if (!string.IsNullOrEmpty(nameStr))
                                        {
                                            try { elem.removeEventListener(nameStr, handler, optionsArg); } catch { }
                                        }
                                    }
                                    catch { }
                                };
                                return new DynamicMetaObject(Expression.Constant(remEvt, typeof(Action<object, object, object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }
                        case "attachEvent":
                            {
                                // Legacy IE-style attachEvent (used by jQuery)
                                Action<object, object> attachEvt = (nameArg, handlerArg) =>
                                {
                                    try
                                    {
                                        var nameStr = UnwrapValue(nameArg)?.ToString() ?? string.Empty;
                                        var handler = UnwrapValue(handlerArg) ?? handlerArg;
                                        if (!string.IsNullOrEmpty(nameStr))
                                        {
                                            // Convert "onclick" to "click" for addEventListener
                                            var eventName = nameStr.StartsWith("on", StringComparison.OrdinalIgnoreCase) ? nameStr.Substring(2) : nameStr;
                                            try { elem.addEventListener(eventName, handler, null); } catch { }
                                        }
                                    }
                                    catch { }
                                };
                                return new DynamicMetaObject(Expression.Constant(attachEvt, typeof(Action<object, object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }
                        case "detachEvent":
                            {
                                // Legacy IE-style detachEvent (used by jQuery)
                                Action<object, object> detachEvt = (nameArg, handlerArg) =>
                                {
                                    try
                                    {
                                        var nameStr = UnwrapValue(nameArg)?.ToString() ?? string.Empty;
                                        var handler = UnwrapValue(handlerArg) ?? handlerArg;
                                        if (!string.IsNullOrEmpty(nameStr))
                                        {
                                            var eventName = nameStr.StartsWith("on", StringComparison.OrdinalIgnoreCase) ? nameStr.Substring(2) : nameStr;
                                            try { elem.removeEventListener(eventName, handler, null); } catch { }
                                        }
                                    }
                                    catch { }
                                };
                                return new DynamicMetaObject(Expression.Constant(detachEvt, typeof(Action<object, object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }
                        case "fireEvent":
                            {
                                // Legacy IE-style fireEvent (used by jQuery for feature detection)
                                Func<object, bool> fireEvt = (nameArg) =>
                                {
                                    try
                                    {
                                        var nameStr = UnwrapValue(nameArg)?.ToString() ?? string.Empty;
                                        if (!string.IsNullOrEmpty(nameStr))
                                        {
                                            var eventName = nameStr.StartsWith("on", StringComparison.OrdinalIgnoreCase) ? nameStr.Substring(2) : nameStr;
                                            // Dispatch a simple event
                                            try { elem.dispatchEvent(eventName); return true; } catch { }
                                        }
                                    }
                                    catch { }
                                    return false;
                                };
                                return new DynamicMetaObject(Expression.Constant(fireEvt, typeof(Func<object, bool>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }
                    }
                }

                // Reflection fallback for method invocations that weren't handled above.
                // ClearScript can invoke members in a few different ways; if we didn't
                // explicitly handle a method (like insertBefore) above, try a best-effort
                // reflection invoke so methods implemented on CLR types still work.
                try
                {
                    if (this.Value != null && args != null)
                    {
                        var targetType = this.Value.GetType();
                        var candidates = targetType.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                            .Where(m => string.Equals(m.Name, binder.Name, StringComparison.OrdinalIgnoreCase) && m.GetParameters().Length == args.Length)
                            .ToArray();

                        foreach (var mi in candidates)
                        {
                            var ps = mi.GetParameters();
                            var invokeArgs = new object[ps.Length];
                            var ok = true;
                            for (int i = 0; i < ps.Length; i++)
                            {
                                var raw = UnwrapValue(args[i].Value) ?? args[i].Value;
                                if (raw == null)
                                {
                                    invokeArgs[i] = null;
                                    continue;
                                }
                                var pType = ps[i].ParameterType;
                                if (pType.IsInstanceOfType(raw))
                                {
                                    invokeArgs[i] = raw;
                                    continue;
                                }
                                try
                                {
                                    invokeArgs[i] = Convert.ChangeType(raw, pType);
                                }
                                catch
                                {
                                    // conversion failed for this candidate
                                    ok = false;
                                    break;
                                }
                            }

                            if (!ok) continue;

                            try
                            {
                                var result = mi.Invoke(this.Value, invokeArgs);
                                return new DynamicMetaObject(Expression.Constant(result, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }
                            catch (Exception ex)
                            {
                                try { commonLog.LogEntry("BindInvokeMember reflection invoke failed: {0}", ex.Message); } catch { }
                            }
                        }
                    }
                }
                catch { }

                // Intercept getContext calls to dynamically wrap results in a proxy for ClearScript
                if (binder.Name == "getContext" && this.Value is CHtmlElement element)
                {
                    // Call the original getContext method
                    var result = element.getContext(args.Select(a => a.Value).ToArray());

                    // If the resultString is a canvas context, wrap it in a proxy
                    if (result is CHtmlCanvasContext2D canvas)
                    {
                        var proxy = new CHtmlClearScriptCanvasContextHostProxy(canvas);
                        return new DynamicMetaObject(
                            Expression.Constant(proxy),
                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                        );
                    }

                    // Return the original resultString if it's not a canvas context
                    return new DynamicMetaObject(
                        Expression.Constant(result),
                        BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                    );
                }

                // Default behavior for other methods
                return base.BindInvokeMember(binder, args);
            }
            catch (Exception ex)
            {
                try
                {
                    // Always log binder and target type to locate ambiguous member, regardless of log level
                    commonLog.LogEntry("BindInvokeMember exception. Binder={0}, TargetType={1}, Message={2}", binder?.Name ?? "(null)", this.Value?.GetType().FullName ?? "(null)", ex.Message);
                }
                catch { }
                try
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                    {
                        var argsInfo = args?.Select(a => a?.LimitType?.FullName ?? "<null>").Aggregate((x, y) => x + ", " + y) ?? "<null>";
                        commonLog.LogEntry("BindInvokeMember error: {0}\nBinder: {1}\nArgs: {2}\nTargetValueType: {3}\nStack:\n{4}",
                            ex.Message,
                            binder?.Name ?? "(null)",
                            argsInfo,
                            this.Value?.GetType().FullName ?? "(null)",
                            ex.ToString());
                    }
                }
                catch { }
            }

            // Return safe fallback (null) instead of letting the runtime attempt default bind which can throw ClearScript dynamic exceptions
            return new DynamicMetaObject(Expression.Constant(null, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            try
            {
                switch (this.Value)
                {
                    case CHtmlMediaElement mediaElement:
                        {
                            // Include CHtmlMediaElement-specific methods (canPlayType, play, pause, load, stop)
                            var props = CHtmlElement.CHtmlElementProperties?.Keys ?? Enumerable.Empty<string>();
                            var methods = CHtmlElement.CHtmlElementMethods?.Keys ?? Enumerable.Empty<string>();
                            var mediaProps = new[] { "canPlayType", "play", "pause", "load", "stop", "addTextTrack", "autoplay", "buffered", "controls", "currentSrc", "currentTime", "duration", "ended", "loop", "muted", "paused", "playbackRate", "played", "preload", "readyState", "seekable", "seeking", "src", "volume" };
                            return props.Concat(methods).Concat(mediaProps);
                        }
                    case CHtmlImage imageElement:
                        {
                            var props = CHtmlElement.CHtmlElementProperties?.Keys ?? Enumerable.Empty<string>();
                            var methods = CHtmlElement.CHtmlElementMethods?.Keys ?? Enumerable.Empty<string>();
                            return props.Concat(methods);
                        }
                    case CHtmlElement element:
                        {
                            // Return both property and method names (match CHtmlElement.GetDynamicMemberNames)
                            var props = CHtmlElement.CHtmlElementProperties?.Keys ?? Enumerable.Empty<string>();
                            var methods = CHtmlElement.CHtmlElementMethods?.Keys ?? Enumerable.Empty<string>();
                            return props.Concat(methods);
                        }
                    case CHtmlDocument document:
                        {
                            // Return both property and method names (match CHtmlDocument.GetDynamicMemberNames)
                            var props = CHtmlDocument.CHtmlDocumentProperties?.Keys ?? Enumerable.Empty<string>();
                            var methods = CHtmlDocument.CHtmlDocumentMethods?.Keys ?? Enumerable.Empty<string>();
                            return props.Concat(methods);
                        }
                    case CHtmlCanvasContext2D canvas:
                        {
                            // Return both property and method names (match CHtmlCanvasContext2D.GetDynamicMemberNames)
                            var props = CHtmlCanvasContext2D.CHtmlCanvasContext2Dproperties?.Keys ?? Enumerable.Empty<string>();
                            var methods = CHtmlCanvasContext2D.CHtmlCanvasContext2Dmethods?.Keys ?? Enumerable.Empty<string>();
                            return props.Concat(methods);
                        }
                    case CHtmlConsole console:
                        return CHtmlConsole.CHtmlConsoleMethods?.Keys ?? Enumerable.Empty<string>();
                    case CHtmlTextMetrics textMetrics:
                        return CHtmlTextMetrics.CHtmlTextMetricsProperties?.Keys ?? Enumerable.Empty<string>();
                    case CHtmlWindowEvent eventWindow:
                        {
                            return CHtmlWindowEvent.CHtmlWindowEventProperties?.Keys ?? Enumerable.Empty<string>();
                        }
                        break;
                    case CHtmlCanvas2DImageData imageDaga:
                        {
                            var props = CHtmlCanvas2DImageData.CHtmlCanvas2DImageDataProperties?.Keys ?? Enumerable.Empty<string>();
                            var methods = CHtmlCanvas2DImageData.CHtmlCanvas2DImageDataMethods?.Keys ?? Enumerable.Empty<string>();
                            return props.Concat(methods);
                        }
                    case CHtmlNativeArray nativeArray:
                        {
                            var props = CHtmlNativeArray.CHtmlNativeArrayProperties?.Keys ?? Enumerable.Empty<string>(); 
                            
                            return props;
                        }
                    case CHtmlCollection chtmlCol:
                        {
                            var props = CHtmlCollection.CHtmlCollectionProperties.Keys ?? Enumerable.Empty<string>();
                            var methods = CHtmlCollection.CHtmlCollectionMethods.Keys ?? Enumerable.Empty<string>(); 
                            return props.Concat(methods);  
                            
                        }
                    default:
                        var obj = this.Value;
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                        {
                            commonLog.LogEntry($"TODO GetDynamicMemberNames fallback for type: {this.Value?.GetType().FullName}");
                        }
                        try { return ((dynamic)obj).GetDynamicMemberNames() as IEnumerable<string> ?? System.Array.Empty<string>(); } catch { }
                        break;
                }
            }
            catch (Exception getDynEx)
            {
                try { commonLog.LogEntry("GetDynamicMemberNames exception for type {0}: {1}", this.Value?.GetType().FullName ?? "(null)", getDynEx.Message); } catch { }
            }

            return System.Array.Empty<string>();
        }

        public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
        {
            try
            {
                if(commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry($"[BindGetMember ENTRY] binder.Name={binder?.Name}, ValueType={this.Value?.GetType().FullName}");
                };
  

                switch (this.Value)
                {       
                    case CHtmlMultiversalWindow window:
                        {
                            var self = window;
                           
                            if (binder.Name == "Image" || binder.Name == "Audio" || binder.Name == "Video" || 
                                binder.Name == "XMLHttpRequest" || binder.Name == "DOMParser")
                            {
                            
                                Func<object, object, object> factoryCtor = (arg1, arg2) => 
                                {
                                    try { return self.___createObject(binder.Name, arg1, arg2); }
                                    catch { return null!; }
                                };

                                return new DynamicMetaObject(
                                    Expression.Constant(factoryCtor),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }

                            // 既存のメンバ（document, console, location等）の解決
                            if (binder.Name == "document")
                            {
                                return new DynamicMetaObject(
                                    Expression.Constant(self.___document),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                            if (binder.Name == "location")
                            {
                                return new DynamicMetaObject(
                                    Expression.Constant(self.___locationBase),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }

                            // 内部辞書 ___WindowsPropertiesList からの検索
                            if (self.___WindowsPropertiesList.TryGetValue(binder.Name, out var val))
                            {
                                // V8 script objects (functions, etc.) require special handling to preserve callable nature.
                                if (val != null)
                                {
                                    var valType = val.GetType();
                                    var valTypeName = valType.FullName ?? string.Empty;
                                    // ClearScript V8 script objects have types like "Microsoft.ClearScript.V8.V8ScriptItem"
                                    // or similar ClearScript wrapper types
                                    if (valTypeName.Contains("ClearScript") || valTypeName.Contains("ScriptItem") || valTypeName.Contains("ScriptObject"))
                                    {
                                        // For V8 script objects, we need to return them in a way that ClearScript
                                        // recognizes as callable. Using the Value property of DynamicMetaObject
                                        // directly allows ClearScript to handle it properly.
                                        // The key is to NOT wrap in Expression.Constant which loses callable nature.

                                        // Return the raw V8 object - the third parameter (val) is the actual runtime value
                                        // that ClearScript will use. The expression is just a placeholder.
                                        return new DynamicMetaObject(
                                            Expression.Constant(val, typeof(object)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType),
                                            val  // This is the key - pass the actual V8 object as the value
                                        );
                                    }
                                    // For Delegate types (CLR functions), they are already callable
                                    if (val is Delegate)
                                    {
                                        return new DynamicMetaObject(
                                            Expression.Constant(val),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    }
                                }
                                // For regular CLR objects/values, wrap as constant
                                return new DynamicMetaObject(
                                    Expression.Constant(val),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        }
                        break;

                    case CHtmlMediaElement mediaElement:
                        {
                            var self = mediaElement;
                            // DEBUG: Log entry for CHtmlMediaElement
                            System.Diagnostics.Debug.WriteLine($"[CHtmlMediaElement.BindGetMember] binder.Name={binder.Name}, tagName={self?.tagName}");
                            if (commonLog.LoggingEnabled)
                            {
                                commonLog.LogEntry("[CHtmlMediaElement.BindGetMember] binder.Name={0}, tagName={1}", binder.Name, self?.tagName);
                            }
                            // Handle CHtmlMediaElement-specific methods
                            switch (binder.Name)
                            {
                                case "canPlayType":
                                    {
                                        // Return a callable delegate for canPlayType(mediaType)
                                        Func<object, object> canPlayTypeDel = (mediaTypeArg) =>
                                        {
                                            try
                                            {
                                                var unwrapped = UnwrapValue(mediaTypeArg) ?? mediaTypeArg;
                                                return self.canPlayType(unwrapped) ?? string.Empty;
                                            }
                                            catch (Exception ex)
                                            {
                                                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("canPlayType delegate exception: {0}", ex.Message); } catch { }
                                                return string.Empty;
                                            }
                                        };
                                        return new DynamicMetaObject(
                                            Expression.Constant(canPlayTypeDel, typeof(Func<object, object>)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    }
                                case "play":
                                    {
                                        Func<Task> mediaPlayDelegate = self.play;

                                        return new DynamicMetaObject(
                                            Expression.Constant(mediaPlayDelegate, typeof(Func<Task>)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    }
                                    break;
                                case "pause":
                                    {
                                        Action pauseDel = () =>
                                        {
                                            try { self.pause(); } catch { }
                                        };
                                        return new DynamicMetaObject(
                                            Expression.Constant(pauseDel, typeof(Action)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    }
                                case "load":
                                    {
                                        Action loadDel = () =>
                                        {
                                            try { self.load(); } catch { }
                                        };
                                        return new DynamicMetaObject(
                                            Expression.Constant(loadDel, typeof(Action)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    }
                                case "addTextTrack":
                                    {
                                        Func<object, object, object, object> addTextTrackDel = (kindArg, labelArg, languageArg) =>
                                        {
                                            try
                                            {
                                                var kind = UnwrapValue(kindArg) ?? kindArg;
                                                var label = UnwrapValue(labelArg) ?? labelArg;
                                                var language = UnwrapValue(languageArg) ?? languageArg;
                                                return self.addTextTrack(kind, label, language);
                                            }
                                            catch (Exception ex)
                                            {
                                                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("addTextTrack delegate exception: {0}", ex.Message); } catch { }
                                                return null!;
                                            }
                                        };
                                        return new DynamicMetaObject(
                                            Expression.Constant(addTextTrackDel, typeof(Func<object, object, object, object>)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    }
                            }
                            // For non-media-specific members, delegate to CHtmlElement's property/method handling
                            // Handle className specially
                            if (binder.Name == "className" || binder.Name == "classname" || binder.Name == "class")
                            {
                                var classNameValue = self.className ?? string.Empty;
                                return new DynamicMetaObject(
                                    Expression.Constant(classNameValue, typeof(string)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                            /*
                            // Check for known CHtmlElement properties
                            if (CHtmlElement.CHtmlElementProperties.ContainsKey(binder.Name))
                            {
                                var propertyInfo = GetCachedProperty(typeof(CHtmlElement), binder.Name) ?? GetCachedProperty(typeof(CHtmlNode), binder.Name);
                                if (propertyInfo != null)
                                {
                                    return new DynamicMetaObject(
                                        Expression.Property(Expression.Constant(self), propertyInfo),
                                        BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                    );
                                }
                            }
                            // Fallback to GetDynamicMember for other members
                            var mediaRes = self.GetDynamicMember(binder.Name);
                            return new DynamicMetaObject(Expression.Constant(mediaRes, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            */
                            break;
                        }

                    case CHtmlElement element:
                        {
                            var self = element;
                            // DEBUG: Log every BindGetMember call for CHtmlElement
                            System.Diagnostics.Debug.WriteLine($"[CHtmlElement.BindGetMember] binder.Name={binder.Name}, tagName={self?.tagName}");
                            // Special handling for className
                            if (binder.Name == "className" || binder.Name == "classname" || binder.Name == "class")
                            {
                                var classNameValue = self.className ?? string.Empty;
                                return new DynamicMetaObject(
                                    Expression.Constant(classNameValue, typeof(string)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                            if (CHtmlElement.CHtmlElementProperties.ContainsKey(binder.Name))
                            {
                                var propertyInfo = GetCachedProperty(typeof(CHtmlElement), binder.Name) ?? GetCachedProperty(typeof(CHtmlNode), binder.Name);
                                if (propertyInfo != null)
                                {
                                    return new DynamicMetaObject(
                                        Expression.Property(Expression.Constant(self), propertyInfo),
                                        BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                    );
                                }
                            }
                            MethodInfo? methodInfo = null;
                            if (CHtmlElement.CHtmlElementMethods.ContainsKey(binder.Name) == true)
                            {
                                switch (binder.Name)
                                {
                                    case "setAttribute":
                                        // Return a delegate that takes two arguments (name, value)
                                        Func<object, object, object> setAttrDel = (nameArg, valueArg) =>
                                        {
                                            try
                                            {
                                                var nameUnwrapped = UnwrapValue(nameArg) ?? nameArg;
                                                var valueUnwrapped = UnwrapValue(valueArg) ?? valueArg;
                                                var nameStr = nameUnwrapped?.ToString() ?? string.Empty;
                                                var valueStr = valueUnwrapped?.ToString() ?? string.Empty;
                                                if (!string.IsNullOrEmpty(nameStr))
                                                {
                                                    self.setAttribute(nameStr, valueStr);
                                                }
                                            }
                                            catch { }
                                            return null!;
                                        };
                                        return new DynamicMetaObject(
                                            Expression.Constant(setAttrDel, typeof(Func<object, object, object>)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    case "getAttribute":
                                        // Return a delegate that takes one argument (name)
                                        Func<object, object> getAttrDel = (nameArg) =>
                                        {
                                            try
                                            {
                                                var nameUnwrapped = UnwrapValue(nameArg) ?? nameArg;
                                                var nameStr = nameUnwrapped?.ToString() ?? string.Empty;
                                                if (!string.IsNullOrEmpty(nameStr))
                                                {
                                                    return self.getAttribute(nameStr) ?? string.Empty;
                                                }
                                            }
                                            catch { }
                                            return null!;
                                        };
                                        return new DynamicMetaObject(
                                            Expression.Constant(getAttrDel, typeof(Func<object, object>)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    case "hasAttribute":
                                        // Return a delegate that takes one argument (name)
                                        Func<object, bool> hasAttrDel = (nameArg) =>
                                        {
                                            try
                                            {
                                                var nameUnwrapped = UnwrapValue(nameArg) ?? nameArg;
                                                var nameStr = nameUnwrapped?.ToString() ?? string.Empty;
                                                if (!string.IsNullOrEmpty(nameStr))
                                                {
                                                    return self.hasAttribute(nameStr);
                                                }
                                            }
                                            catch { }
                                            return false;
                                        };
                                        return new DynamicMetaObject(
                                            Expression.Constant(hasAttrDel, typeof(Func<object, bool>)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    case "cloneNode":
                                        // Return a delegate that takes one optional argument (deep)
                                        Func<object, object> cloneNodeDel = (deepArg) =>
                                        {
                                            try
                                            {
                                                bool deep = false;
                                                if (deepArg != null)
                                                {
                                                    var deepUnwrapped = UnwrapValue(deepArg) ?? deepArg;
                                                    if (deepUnwrapped is bool b) deep = b;
                                                    else bool.TryParse(deepUnwrapped?.ToString(), out deep);
                                                }
                                                return self.cloneNode(deep);
                                            }
                                            catch { }
                                            return null!;
                                        };
                                        return new DynamicMetaObject(
                                            Expression.Constant(cloneNodeDel, typeof(Func<object, object>)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    case "removeAttribute":
                                        // Return a delegate that takes one argument (name)
                                        Func<object, object> removeAttrDel = (nameArg) =>
                                        {
                                            try
                                            {
                                                var nameUnwrapped = UnwrapValue(nameArg) ?? nameArg;
                                                var nameStr = nameUnwrapped?.ToString() ?? string.Empty;
                                                if (!string.IsNullOrEmpty(nameStr))
                                                {
                                                    self.removeAttribute(nameStr);
                                                }
                                            }
                                            catch { }
                                            return null!;
                                        };
                                        return new DynamicMetaObject(
                                            Expression.Constant(removeAttrDel, typeof(Func<object, object>)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    case "removeChild":
                                        // Return a delegate that takes one argument (child)
                                        Func<object, object> removeChildDel = (childArg) =>
                                        {
                                            try
                                            {
                                                var childUnwrapped = UnwrapValue(childArg) ?? childArg;
                                                if (childUnwrapped is CHtmlElement childEl)
                                                {
                                                    return self.removeChild(childEl);
                                                }
                                                if (childUnwrapped is ICHtmlNodeInterface node)
                                                {
                                                    return self.removeChild((CHtmlElement)node);
                                                }
                                                return SafeInvoke(self, "removeChild", new object[] { childUnwrapped ?? childArg });
                                            }
                                            catch { }
                                            return null!;
                                        };
                                        return new DynamicMetaObject(
                                            Expression.Constant(removeChildDel, typeof(Func<object, object>)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    case "insertBefore":
                                        // insertBefore takes TWO arguments: insertBefore(newNode, referenceNode)
                                        System.Diagnostics.Debug.WriteLine($"BindGetMember: insertBefore case matched for CHtmlElement {self?.tagName}");
                                        Func<object, object, object> insertBeforeDel = (object newNodeArg, object refNodeArg) =>
                                        {
                                            System.Diagnostics.Debug.WriteLine($"insertBeforeDel invoked: newNodeArg={newNodeArg?.GetType().Name}, refNodeArg={refNodeArg?.GetType().Name}");
                                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 9)
                                            {
                                                commonLog.LogEntry($"BindGetMember: insertBefore delegate invoked for CHtmlElement");
                                            }
                                            try
                                            {
                                                // Unwrap both arguments
                                                var argNew = UnwrapValue(newNodeArg) ?? newNodeArg;
                                                var argRef = UnwrapValue(refNodeArg) ?? refNodeArg;

                                                // debug log
                                                try { if (commonLog.LoggingEnabled && commonLog.LogLevel >= 9) commonLog.LogEntry("insertBeforeDel called. argNewType={0}, argRefType={1}", argNew?.GetType().FullName ?? "<null>", argRef?.GetType().FullName ?? "<null>"); } catch { }

                                                // If already native CHtmlElement, call directly (fastest)
                                                if (argNew is CHtmlElement newEl)
                                                {
                                                    if (argRef is CHtmlElement refEl)
                                                    {
                                                        return self.insertBefore(newEl, refEl);
                                                    }
                                                    if (argRef == null)
                                                    {
                                                        return self.insertBefore(newEl, null);
                                                    }
                                                }

                                                // ICHtmlNodeInterface case
                                                if (argNew is ICHtmlNodeInterface nodeNew)
                                                {
                                                    return SafeInvoke(self, "insertBefore", new object[] { nodeNew, argRef });
                                                }

                                                // Generic fallback: let SafeInvoke handle type conversion
                                                return SafeInvoke(self, "insertBefore", new object[] { argNew, argRef });
                                            }
                                            catch (Exception ex)
                                            {
                                                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("insertBeforeDel exception: {0}", ex.ToString()); } catch { }
                                                return null;
                                            }
                                        };

                                        return new DynamicMetaObject(
                                            Expression.Constant(insertBeforeDel, typeof(Func<object, object, object>)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );

                                    case "appendChild":
                                        // appendChild takes one argument: appendChild(child)
                                        Func<object, object> appendChildDel = (childArg) =>
                                        {
                                            try
                                            {
                                                var unwrapped = UnwrapValue(childArg) ?? childArg;
                                                if (unwrapped is CHtmlElement childEl)
                                                {
                                                    return self.appendChild(childEl);
                                                }
                                                if (unwrapped is ICHtmlNodeInterface node)
                                                {
                                                    return self.appendChild((CHtmlElement)node);
                                                }
                                                return SafeInvoke(self, "appendChild", new object[] { unwrapped ?? childArg });
                                            }
                                            catch (Exception ex)
                                            {
                                                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("appendChild delegate exception: {0}", ex.Message); } catch { }
                                            }
                                            return null!;
                                        };
                                        return new DynamicMetaObject(
                                            Expression.Constant(appendChildDel, typeof(Func<object, object>)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                        break;

                                    case "addEventListener":
                                        {
                                            // jQuery calls addEventListener(type, handler) with 2 args
                                            // Standard DOM allows optional 3rd arg (options/useCapture)
                                            // Use 2-arg delegate since that's what jQuery uses
                                            Action<object, object> addEl = (nameArg, handlerArg) =>
                                            {
                                                try
                                                {
                                                    var nameStr = UnwrapValue(nameArg)?.ToString() ?? string.Empty;
                                                    var handler = UnwrapValue(handlerArg) ?? handlerArg;
                                                    if (!string.IsNullOrEmpty(nameStr))
                                                    {
                                                        try { self.addEventListener(nameStr, handler); } catch { }
                                                    }
                                                }
                                                catch { }
                                            };
                                            return new DynamicMetaObject(Expression.Constant(addEl, typeof(Action<object, object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                        }
                                    case "removeEventListener":
                                        {
                                            // Use 2-arg delegate to match addEventListener pattern
                                            Action<object, object> remEl = (nameArg, handlerArg) =>
                                            {
                                                try
                                                {
                                                    var nameStr = UnwrapValue(nameArg)?.ToString() ?? string.Empty;
                                                    var handler = UnwrapValue(handlerArg) ?? handlerArg;
                                                    if (!string.IsNullOrEmpty(nameStr))
                                                    {
                                                        try { self.removeEventListener(nameStr, handler); } catch { }
                                                    }
                                                }
                                                catch { }
                                            };
                                            return new DynamicMetaObject(Expression.Constant(remEl, typeof(Action<object, object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                        }
                                    case "attachEvent":
                                        {
                                            // Legacy IE-style attachEvent (used by jQuery)
                                            Action<object, object> attachEl = (nameArg, handlerArg) =>
                                            {
                                                try
                                                {
                                                    var nameStr = UnwrapValue(nameArg)?.ToString() ?? string.Empty;
                                                    var handler = UnwrapValue(handlerArg) ?? handlerArg;
                                                    if (!string.IsNullOrEmpty(nameStr))
                                                    {
                                                        try { self.attachEvent(nameStr, handler); } catch { }
                                                    }
                                                }
                                                catch { }
                                            };
                                            return new DynamicMetaObject(Expression.Constant(attachEl, typeof(Action<object, object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                        }
                                    case "detachEvent":
                                        {
                                            // Legacy IE-style detachEvent (used by jQuery)
                                            Action<object, object> detachEl = (nameArg, handlerArg) =>
                                            {
                                                try
                                                {
                                                    var nameStr = UnwrapValue(nameArg)?.ToString() ?? string.Empty;
                                                    var handler = UnwrapValue(handlerArg) ?? handlerArg;
                                                    if (!string.IsNullOrEmpty(nameStr))
                                                    {
                                                        try { self.detachEvent(nameStr, handler); } catch { }
                                                    }
                                                }
                                                catch { }
                                            };
                                            return new DynamicMetaObject(Expression.Constant(detachEl, typeof(Action<object, object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                        }
                                    case "matches":
                                        Func<object, bool> matchesDel = (object nameArg) =>
                                        {
                                            try
                                            {
                                                var nameStr = UnwrapValue(nameArg)?.ToString() ?? string.Empty;
                                                if (!string.IsNullOrEmpty(nameStr))
                                                {
                                                    return self.matches(nameStr);
                                                }
                                            }
                                            catch { }
                                            return false;
                                        };
                                        return new DynamicMetaObject(Expression.Constant(matchesDel, typeof(Func<object, bool>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));


                                    case "getContext":
                                        // Return a stable CLR delegate that calls element.getContext and returns a ClearScript-friendly proxy when applicable
                                        Func<object, object> ctxDel = (object arg) =>
                                        {
                                            try
                                            {
                                                object[] a;
                                                if (arg == null) a = System.Array.Empty<object>();
                                                else if (arg is object[] oa) a = oa;
                                                else a = new object[] { arg };
                                                var res = self.getContext(a);
                                                try { if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("getContext delegate: raw resultString type = {0}", res?.GetType().FullName ?? "<null>"); } catch { }
                                                if (res is CHtmlCanvasContext2D canvas)
                                                {
                                                    var proxy = canvas.GetClearScriptHostProxy();
                                                    try { if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("getContext delegate: returning proxy type = {0}", proxy?.GetType().FullName ?? "<null>"); } catch (Exception) {
                                                        if(commonLog.LoggingEnabled) commonLog.LogEntry("getContext delegate: exception while logging proxy type"); 
                                                    }
                                                    return proxy;
                                                }
                                                try { if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("getContext delegate: returning raw resultString (non-canvas)"); } catch { }
                                                return res;
                                            }
                                            catch { return null; }
                                        };
                                        return new DynamicMetaObject(Expression.Constant(ctxDel), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                    case "toString":
                                        Func<string> toStringFunc = () => element.ToString();
                                        return new DynamicMetaObject(Expression.Constant(toStringFunc), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));

                                    case "getElementsByTagName":
                                        {
                                            // Return a callable delegate for getElementsByTagName(tagName)
                                            Func<object, object> getElementsByTagNameDel = (tagNameArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(tagNameArg) ?? tagNameArg;
                                                    var tagName = unwrapped?.ToString() ?? "*";
                                                    try { if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("getElementsByTagName delegate invoked: tagName={0}", tagName); } catch { }
                                                    return self.getElementsByTagName(tagName);
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("getElementsByTagName delegate exception: {0}", ex.Message); } catch { }
                                                    return new CHtmlCollection();
                                                }
                                            };
                                            try { if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("BindGetMember: returning getElementsByTagName delegate for CHtmlElement"); } catch { }
                                            return new DynamicMetaObject(
                                                Expression.Constant(getElementsByTagNameDel, typeof(Func<object, object>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "getElementsByClassName":
                                        {
                                            // Return a callable delegate for getElementsByClassName(className)
                                            Func<object, object> getElementsByClassNameDel = (classNameArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(classNameArg) ?? classNameArg;
                                                    var className = unwrapped?.ToString() ?? "";
                                                    return self.getElementsByClassName(className);
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("getElementsByClassName delegate exception: {0}", ex.Message); } catch { }
                                                    return new CHtmlCollection();
                                                }
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(getElementsByClassNameDel, typeof(Func<object, object>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "querySelectorAll":
                                        {
                                            // Return a callable delegate for querySelectorAll(selector)
                                            Func<object, object> querySelectorAllDel = (selectorArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(selectorArg) ?? selectorArg;
                                                    var selector = unwrapped?.ToString() ?? "*";
                                                    return self.querySelectorAll(selector);
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("querySelectorAll delegate exception: {0}", ex.Message); } catch { }
                                                    return new CHtmlCollection();
                                                }
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(querySelectorAllDel, typeof(Func<object, object>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "querySelector":
                                        {
                                            // Return a callable delegate for querySelector(selector)
                                            Func<object, object> querySelectorDel = (selectorArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(selectorArg) ?? selectorArg;
                                                    var selector = unwrapped?.ToString() ?? "";
                                                    return self.querySelector(selector);
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("querySelector delegate exception: {0}", ex.Message); } catch { }
                                                    return null;
                                                }
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(querySelectorDel, typeof(Func<object, object>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                } // end switch (binder.Name)
                            } // end if (CHtmlElementMethods.ContainsKey)

                            // If requested member is a known method, expose a callable delegate to script to avoid "not a function" errors
                            try
                            {
                                if (CHtmlDocument.CHtmlDocumentMethods.ContainsKey(binder.Name))
                                {
                                    Func<object[], object> methodInvoker = (object[] a) =>
                                    {
                                        try { return SafeInvoke(self, binder.Name, a ?? System.Array.Empty<object>()); } catch { return null; }
                                    };
                                    return new DynamicMetaObject(Expression.Constant(methodInvoker), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                }
                            }
                            catch { }

                            var res = self.GetDynamicMember(binder.Name);
                            return new DynamicMetaObject(Expression.Constant(res, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                        }
                        break;

                    case CHtmlDocument document:
                        {
                            var self = document;
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 9)
                            {
                                commonLog.LogEntry($"[CHtmlDocument.BindGetMember] binder.Name={binder.Name}");
                            }

                            // Explicit handling for element-returning properties (body, head, documentElement, etc.)
                            // These MUST be returned typed as IDynamicMetaObjectProvider so that ClearScript V8
                            // calls GetMetaObject() on them, enabling further DLR dispatch for member access like
                            // document.body.appendChild (which must resolve as a callable Func, not a CLR method).
                            if (binder.Name == "body" || binder.Name == "BODY")
                            {
                                var bodyEl = self.body as IDynamicMetaObjectProvider;
                                return new DynamicMetaObject(
                                    Expression.Constant(bodyEl, typeof(IDynamicMetaObjectProvider)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType),
                                    bodyEl
                                );
                            }
                            if (binder.Name == "head" || binder.Name == "HEAD")
                            {
                                var headEl = self.head as IDynamicMetaObjectProvider;
                                return new DynamicMetaObject(
                                    Expression.Constant(headEl, typeof(IDynamicMetaObjectProvider)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType),
                                    headEl
                                );
                            }
                            if (binder.Name == "documentElement")
                            {
                                var docEl = self.documentElement as IDynamicMetaObjectProvider;
                                return new DynamicMetaObject(
                                    Expression.Constant(docEl, typeof(IDynamicMetaObjectProvider)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType),
                                    docEl
                                );
                            }

                            // Return callable delegates for CHtmlDocument methods
                            if (CHtmlDocument.CHtmlDocumentMethods.ContainsKey(binder.Name))
                            {
                                switch (binder.Name)
                                {
                                    case "getElementById":
                                        {
                                            Func<object, object?> getElementByIdDel = (idArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(idArg) ?? idArg;
                                                    var id = unwrapped?.ToString() ?? string.Empty;
                                                    if (!string.IsNullOrEmpty(id))
                                                    {
                                                        return self.getElementById(id);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("getElementById delegate exception: {0}", ex.Message); } catch { }
                                                }
                                                return null;
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(getElementByIdDel, typeof(Func<object, object?>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "matches":
                                        {


                                        }
                                        break;
                                    case "createElement":
                                        {
                                            Func<object, object> createElementDel = (tagNameArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(tagNameArg) ?? tagNameArg;
                                                    var tagName = unwrapped?.ToString() ?? string.Empty;

                                                    if (!string.IsNullOrEmpty(tagName))
                                                    {
                                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                                        {
                                                            commonLog.LogEntry($"ClearScript document createElement : {tagName} is called");
                                                        }
                                                        return self.createElement(tagName);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("ZZZ createElement delegate exception: {0}", ex.Message); } catch { }
                                                }
                                                return null;
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(createElementDel, typeof(Func<object, object?>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "getElementsByTagName":
                                        {
                                            Func<object, object> getElementsByTagNameDel = (tagNameArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(tagNameArg) ?? tagNameArg;
                                                    var tagName = unwrapped?.ToString() ?? "*";
                                                    return self.getElementsByTagName(tagName);
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("getElementsByTagName delegate exception: {0}", ex.Message); } catch { }
                                                    return new CHtmlCollection();
                                                }
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(getElementsByTagNameDel, typeof(Func<object, object>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "getElementsByClassName":
                                        {
                                            Func<object, object> getElementsByClassNameDel = (classNameArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(classNameArg) ?? classNameArg;
                                                    var className = unwrapped?.ToString() ?? string.Empty;
                                                    return self.getElementsByClassName(className);
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("getElementsByClassName delegate exception: {0}", ex.Message); } catch { }
                                                    return new CHtmlCollection();
                                                }
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(getElementsByClassNameDel, typeof(Func<object, object>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "getElementsByName":
                                        {
                                            Func<object, object> getElementsByNameDel = (nameArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(nameArg) ?? nameArg;
                                                    var name = unwrapped?.ToString() ?? string.Empty;
                                                    return self.getElementsByName(name);
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("getElementsByName delegate exception: {0}", ex.Message); } catch { }
                                                    return new CHtmlCollection();
                                                }
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(getElementsByNameDel, typeof(Func<object, object>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "createTextNode":
                                        {
                                            Func<object, object?> createTextNodeDel = (textArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(textArg) ?? textArg;
                                                    var text = unwrapped?.ToString() ?? string.Empty;
                                                    return self.createTextNode(text);
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("createTextNode delegate exception: {0}", ex.Message); } catch { }
                                                }
                                                return null;
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(createTextNodeDel, typeof(Func<object, object?>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "createComment":
                                        {
                                            Func<object, object?> createCommentDel = (textArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(textArg) ?? textArg;
                                                    var text = unwrapped?.ToString() ?? string.Empty;
                                                    return self.createComment(text);
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("createComment delegate exception: {0}", ex.Message); } catch { }
                                                }
                                                return null;
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(createCommentDel, typeof(Func<object, object?>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "createDocumentFragment":
                                        {
                                            Func<object?> createDocumentFragmentDel = () =>
                                            {
                                                try
                                                {
                                                    return self.createDocumentFragment();
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("createDocumentFragment delegate exception: {0}", ex.Message); } catch { }
                                                }
                                                return null;
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(createDocumentFragmentDel, typeof(Func<object?>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "addEventListener":
                                        {
                                            var name = binder.Name;
                                            Action<object[]> addEventListenerDel = (args) =>
                                            {
                                                try
                                                {
                                                    if (args != null && args.Length >= 2)
                                                    {
                                                        string nameStr = UnwrapValue(args[0])?.ToString() ?? string.Empty;
                                                        var handler = UnwrapValue(args[1]) ?? args[1];
                                                        object optionsArg = args.Length >= 3 ? args[2] : null;
                                                        if (!string.IsNullOrEmpty(nameStr))
                                                        {
                                                            self.addEventListener((string)nameStr, handler, optionsArg);
                                                        }
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    if (commonLog.LoggingEnabled) commonLog.LogEntry("addEventListener delegate exception: {0}", ex.Message);
                                                }

                                            };

                                            return new DynamicMetaObject(
                                                Expression.Convert(
                                                    Expression.Constant(addEventListenerDel),
                                                    typeof(object)
                                                ),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "removeEventListener":
                                        {
                                            Action<object[]> remEvtDel = (args) =>
                                            {
                                                try
                                                {
                                                    if (args != null && args.Length >= 2)
                                                    {
                                                        var nameStr = UnwrapValue(args[0])?.ToString() ?? string.Empty;
                                                        var handler = UnwrapValue(args[1]) ?? args[1];
                                                        object optionsArg = args.Length >= 3 ? args[2] : null;
                                                        if (!string.IsNullOrEmpty(nameStr))
                                                        {
                                                            try { self.removeEventListener(nameStr, handler, optionsArg); } catch { }
                                                        }
                                                    }
                                                }
                                                catch { }
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(remEvtDel, typeof(Action<object[]>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "createEvent":
                                        {
                                            Func<object, object?> createEventDel = (eventTypeArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(eventTypeArg) ?? eventTypeArg;
                                                    var eventType = unwrapped?.ToString() ?? string.Empty;
                                                    if (!string.IsNullOrEmpty(eventType))
                                                    {
                                                        return self.createEvent(eventType);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("createEvent delegate exception: {0}", ex.Message); } catch { }
                                                }
                                                return null;
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(createEventDel, typeof(Func<object, object?>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                    case "querySelector":
                                        {
                                            Func<object, object?> querySelectorDel = (eventTypeArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(eventTypeArg);

                                                    return self.querySelector(unwrapped);

                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("createEvent delegate exception: {0}", ex.Message); } catch { }
                                                }
                                                return null;
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(querySelectorDel, typeof(Func<object, object?>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }

                                        break;
                                    case "querySelectorAll":
                                        {
                                            Func<object, object?> querySelectorAllDel = (eventTypeArg) =>
                                            {
                                                try
                                                {
                                                    var unwrapped = UnwrapValue(eventTypeArg);

                                                    return self.querySelectorAll(unwrapped);

                                                }
                                                catch (Exception ex)
                                                {
                                                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("createEvent delegate exception: {0}", ex.Message); } catch { }
                                                }
                                                return null;
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(querySelectorAllDel, typeof(Func<object, object?>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                        ;


                                        break;
                                    default:
                                        {
                                            // Generic fallback for other CHtmlDocument methods
                                            Func<object[], object?> methodInvoker = (object[] a) =>
                                            {
                                                try { return SafeInvoke(self, binder.Name, a ?? System.Array.Empty<object>()); } catch { return null; }
                                            };
                                            return new DynamicMetaObject(
                                                Expression.Constant(methodInvoker, typeof(Func<object[], object?>)),
                                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                            );
                                        }
                                }
                            }

                            // Handle CHtmlDocument properties
                            if (CHtmlDocument.CHtmlDocumentProperties.ContainsKey(binder.Name))
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 9)
                                {
                                    commonLog.LogEntry($"[CHtmlDocument.BindGetMember] Attempting to get property {binder.Name} via reflection");
                                }
                                var selfDoc = document;
                                var selfDocReturnObhect = selfDoc.___getPropertyByName(binder.Name);
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 9)
                                {
                                    commonLog.LogEntry($"[CHtmlDocument.BindGetMember] returns get property {binder.Name} {selfDocReturnObhect}");
                                }
                                // IMPORTANT: ClearScript V8 calls GetMetaObject() on a returned value only when
                                // its static type in the Expression is IDynamicMetaObjectProvider (or DynamicObject).
                                // If we use typeof(object) or the concrete type (e.g. CHtmlElement), ClearScript
                                // treats it as a plain CLR host object and bypasses our BindGetMember for subsequent
                                // member access like .appendChild — making typeof(document.body.appendChild) === "object".
                                // By using typeof(IDynamicMetaObjectProvider) as the Expression static type, we force
                                // ClearScript to call GetMetaObject() → our BindGetMember → returns the Func delegate.
                                if (selfDocReturnObhect is IDynamicMetaObjectProvider dynProvider)
                                {
                                    return new DynamicMetaObject(
                                        Expression.Constant(dynProvider, typeof(IDynamicMetaObjectProvider)),
                                        BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType),
                                        dynProvider
                                    );
                                }
                                return new DynamicMetaObject(Expression.Constant(selfDocReturnObhect, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)); break;
                            }

                        
                        }
                        break;

                    // Explicitly handle CHtmlCollection so properties like length are returned as CLR primitives
                    case CHtmlCollection collection:
                        {
                            var selfCol = collection;
                            switch (binder.Name)
                            {
                                case "length":
                                    return new DynamicMetaObject(
             Expression.Constant(selfCol.length, typeof(int)),
             BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
         );
                                    break;
                                case "toArray":
                                case "toDataArray":
                                    Func<object[]> del = () =>
                                    {
                                        try { return selfCol.toArray(); } catch { return System.Array.Empty<object>(); }
                                    };
                                    return new DynamicMetaObject(Expression.Constant(del), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));

                                    break;
                                case "forEach":
                                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
                                    {
                                        commonLog.LogEntry("CHtmlCollection.forEach has been called by BindGetMember");
                                    }

                                    Action<object> forEachFunc = (jsCallback) =>
                                    {
                                        if (jsCallback == null) return;

                                        for (int i = 0; i < selfCol.Count; i++)
                                        {
                                            var item = selfCol[i];

                                            try
                                            {
                                                if (jsCallback is Delegate del)
                                                {
                                                    del.DynamicInvoke(item, i, selfCol);   
                                                }
                                                else if (jsCallback is System.Dynamic.IDynamicMetaObjectProvider)
                                                {
                                                    
                                                    dynamic dyn = jsCallback;
                                                    dyn(item, i, selfCol);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                if (commonLog.LoggingEnabled)
                                                    commonLog.LogEntry($"CHtmlCollection.forEach error at [{i}]: {ex.Message}");
                                            }
                                        }
                                    };

                                    return new DynamicMetaObject(
                                        Expression.Constant(forEachFunc),
                                        BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                    );
                                    break;
                            
                     




                             

                                case "toString":
                                    break;


                            };
                            
                                 
                            


 

                            try
                            {
                                var dyn = selfCol.GetDynamicMember(binder.Name);
                                return new DynamicMetaObject(Expression.Constant(dyn, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }
                            catch { }

                            return base.BindGetMember(binder);
                        }
                    case CHtmlTextMetrics textMetrics:
                        {
                            var self = textMetrics;
                            if (string.Equals(binder.Name, "width", StringComparison.OrdinalIgnoreCase))
                            {
                                return new DynamicMetaObject(
                                    Expression.Constant(self.width, typeof(double)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                            return base.BindGetMember(binder);
                        }
                    case CHtmlWindowEvent windowEvent:
                        {
                            var self = windowEvent;
                             var name = binder.Name;
                            switch (name)
                            { 
                                case "preventDefault":
                                    return new DynamicMetaObject(Expression.Constant((Action)windowEvent.preventDefault), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)); break;
                                case "stopPropagation":
                                    return new DynamicMetaObject(Expression.Constant((Action)windowEvent.stopPropagation), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)); break;
                                case "code":
                                    return new DynamicMetaObject(Expression.Constant(windowEvent.code, typeof(string)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)); break;
                                case "keyCode":
                                    var _keyCode = self.keyCode;
                                    return new DynamicMetaObject(Expression.Constant(_keyCode, typeof(int)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType) ); break;
                                case "altKey":
                                    return new DynamicMetaObject(Expression.Constant(windowEvent.altKey, typeof(bool)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)); break;
                                case "ctrlKey":
                                    return new DynamicMetaObject(Expression.Constant(windowEvent.ctrlKey, typeof(bool)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)); break;
                                case "shiftKey":
                                    return new DynamicMetaObject(Expression.Constant(windowEvent.shiftKey, typeof(bool)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)); break;
                                case "offsetX":

                                    var dynOffsetX = self.offsetX;
                                    return new DynamicMetaObject(Expression.Constant(dynOffsetX, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));

                                case "offsetY":
                                    var dynOffsetY = self.offsetY;
                                    return new DynamicMetaObject(Expression.Constant(dynOffsetY, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "clientX":
                                    var dynClientX = self.clientX;
                                    return new DynamicMetaObject(Expression.Constant(dynClientX, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "clientY":
                                    var dynClientY = self.clientY;
                                    return new DynamicMetaObject(Expression.Constant(dynClientY, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "button":
                                    var dynButton = self.button;
                                    return new DynamicMetaObject(Expression.Constant(dynButton, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "key":
                                case "Key":
                                    var dynKey = self.key;
                                    return new DynamicMetaObject(Expression.Constant(dynKey, typeof(string)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));



                            }
                        }
                        break;
                    case CHtmlCanvas2DImageData imageData:
                        {
                            var self = imageData;
                            var name = binder.Name;
                            switch (name)
                            {
                                case "data":
                                    return new DynamicMetaObject(Expression.Constant(self.data, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "width":
                                    return new DynamicMetaObject(Expression.Constant(self.width, typeof(int)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)); 
                                case "height":
                                    return new DynamicMetaObject(Expression.Constant(self.height, typeof(int)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                    
                            }
                        }
                        break;
                    case CHtmlNativeArray nativeArray:
                        {
                            var self = nativeArray;
                            var name = binder.Name;
                        }
                        break;
                    case CHtmlClearScriptCanvasContextHostProxy proxyContext:
                        {
                            // 主要APIは直接デリゲート返却
                            var name = binder.Name;
                            switch (name)
                            {
                                case "moveTo":
                                    return new DynamicMetaObject(Expression.Constant((Action<object, object>)proxyContext.moveTo), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "lineTo":
                                    return new DynamicMetaObject(Expression.Constant((Action<object, object>)proxyContext.lineTo), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "stroke":
                                    return new DynamicMetaObject(Expression.Constant((Action)proxyContext.stroke), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "fill":
                                    return new DynamicMetaObject(Expression.Constant((Action)proxyContext.fill), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "beginPath":
                                    return new DynamicMetaObject(Expression.Constant((Action)proxyContext.beginPath), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "closePath":
                                    return new DynamicMetaObject(Expression.Constant((Action)proxyContext.closePath), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "clearRect":
                                    return new DynamicMetaObject(Expression.Constant((Action<object, object, object, object>)proxyContext.clearRect), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "fillRect":
                                    return new DynamicMetaObject(Expression.Constant((Action<object, object, object, object>)proxyContext.fillRect), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "strokeRect":
                                    return new DynamicMetaObject(Expression.Constant((Action<object, object, object, object>)proxyContext.strokeRect), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "translate":
                                    return new DynamicMetaObject(Expression.Constant((Action<object, object>)proxyContext.translate), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "rotate":
                                    return new DynamicMetaObject(Expression.Constant((Action<object>)proxyContext.rotate), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "save":
                                    return new DynamicMetaObject(Expression.Constant((Action)proxyContext.save), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "restore":
                                    return new DynamicMetaObject(Expression.Constant((Action)proxyContext.restore), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "arc":
                                    return new DynamicMetaObject(Expression.Constant((Action<object, object, object, object, object, object>)proxyContext.arc), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "createLinearGradient":
                                    return new DynamicMetaObject(Expression.Constant((Func<object, object, object, object, object, object, object?>)proxyContext.createLinearGradient), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                                case "createRadialGradient":
                                    return new DynamicMetaObject(Expression.Constant((Func<object, object, object, object, object, object, object?>)proxyContext.createRadialGradient), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }
                            // それ以外はInvokeで一元化
                            Func<object[], object> invoker = (object[] a) => proxyContext.Invoke(name, a);
                            return new DynamicMetaObject(Expression.Constant(invoker), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                        }
                    case CHtmlConsole console:
                        {
                            // Allow ClearScript to bind to CLR methods directly.
                            return base.BindGetMember(binder);
                        }

                    case CHtmlCSSStyleSheet cssStyleSheet:
                        {
                            var self = cssStyleSheet;
                            var resultString = self.___getPropertyByName(binder.Name);

                            return new DynamicMetaObject(Expression.Constant(resultString, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                        }
                    case ICHtmlCSSStyleDeclaration iCSssSyleDeclaration:
                        {
                            var self = iCSssSyleDeclaration;

                            // Provide toString as callable function
                            if (string.Equals(binder.Name, "toString", StringComparison.OrdinalIgnoreCase))
                            {
                                Func<string> delToString = () => { try { return self.ToString() ?? "[object CSSStyleDeclaration]"; } catch { return "[object CSSStyleDeclaration]"; } };
                                return new DynamicMetaObject(Expression.Constant(delToString), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }

                            // Expose getPropertyValue(name) as a delegate
                            if (string.Equals(binder.Name, "getPropertyValue", StringComparison.OrdinalIgnoreCase))
                            {
                                Func<object, object> delGetPropertyValue = (object name) =>
                                {
                                    try { return (object)(self.getPropertyValue(name?.ToString() ?? string.Empty) ?? string.Empty); } catch { return string.Empty; }
                                };
                                return new DynamicMetaObject(Expression.Constant(delGetPropertyValue), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }

                            // Expose setProperty(name, value) as a delegate
                            if (string.Equals(binder.Name, "setProperty", StringComparison.OrdinalIgnoreCase))
                            {
                                Action<object, object> delSetProperty = (object name, object value) =>
                                {
                                    try { self.setProperty(name?.ToString() ?? string.Empty, value?.ToString()); } catch { }
                                };
                                return new DynamicMetaObject(Expression.Constant(delSetProperty), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }

                            // Expose removeProperty(name) as a delegate
                            if (string.Equals(binder.Name, "removeProperty", StringComparison.OrdinalIgnoreCase))
                            {
                                Action<object> delRemoveProperty = (object name) =>
                                {
                                    try { self.removeProperty(name?.ToString() ?? string.Empty); } catch { }
                                };
                                return new DynamicMetaObject(Expression.Constant(delRemoveProperty, typeof(Action<object>)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }

                            // For any other property name, map to getPropertyValue(binder.Name)
                            try
                            {
                                var value = self.getPropertyValue(binder.Name) ?? string.Empty;
                                return new DynamicMetaObject(
                                    Expression.Constant(value, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                            catch
                            {
                                return new DynamicMetaObject(
                                    Expression.Constant(string.Empty, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    // Always log binder and target type to locate ambiguous member, regardless of log level
                    commonLog.LogEntry("BindGetMember exception. Binder={0}, TargetType={1}, Message={2}", binder?.Name ?? "(null)", this.Value?.GetType().FullName ?? "(null)", ex.Message);
                }
                catch { }
                try
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                    {
                        commonLog.LogEntry("BindGetMember error: {0}\nBinder: {1}\nTargetValueType: {2}\nStack:\n{3}", ex.Message, binder?.Name ?? "(null)", this.Value?.GetType().FullName ?? "(null)", ex.ToString());
                    }
                }
                catch { }
            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"TODO BindGetMember : {binder?.Name} on {this.Value} ({this.Value?.GetType().FullName ?? "(null)"})");
            }

            return new DynamicMetaObject(Expression.Constant(null, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
        }
        public void Add(string key, object value)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"{this}.Add is called with key {key} and value {value}");
            }
        }
        public override DynamicMetaObject BindConvert(ConvertBinder binder)
        {
            if (binder.Type == typeof(string))
            {
                var self = this.Value;
                var toStringMethod = self.GetType().GetMethod("ToString", Type.EmptyTypes);
                var callToString = Expression.Call(Expression.Constant(self), toStringMethod);
                return new DynamicMetaObject(callToString, BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
            }
            return base.BindConvert(binder);
        }

        public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"BindSetMember is called with value {binder.ToString()} : {value}");
            }

            // Conservative extraction: handle DynamicMetaObject specially then try UnwrapValue for common wrappers.
            object? actual = null;
            try
            {
                if (value is DynamicMetaObject dmoParam)
                {
                    actual = UnwrapValue(dmoParam.Value) ?? dmoParam.Value;
                }
                else
                {
                    actual = UnwrapValue(value?.Value) ?? UnwrapValue(value) ?? value?.Value;
                }
            }
            catch
            {
                // fallback to best-effort raw value
                try { actual = value?.Value; } catch { actual = null; }
            }

            // If target is core DOM types, avoid CLR property reflection entirely (prevents AmbiguousMatch for method names)
            bool _isTypeSwitchFound = false;

                try
                {
                    switch (this.Value)
                    {
                        case CHtmlDocument doc:
                            _isTypeSwitchFound = true;
                            try { 
                            doc.___setPropertyByName(binder.Name, actual); 
                        } catch (Exception ex) { if (commonLog.LoggingEnabled) commonLog.LogEntry($"Document {doc}.SetDynamicMember error: {0}", ex.Message); }
                            break;

                        case CHtmlElement el:
                            _isTypeSwitchFound = true;
                            try
                            {
                                // Preserve ClearScript/V8 script objects so they remain callable from script.
                                if (actual != null)
                                {
                                    var typeName = actual.GetType().FullName ?? string.Empty;
                                    if (typeName.Contains("ClearScript") || typeName.Contains("ScriptItem") || typeName.Contains("ScriptObject") || typeName.Contains("V8"))
                                    {
                                        el.___setPropertyByName(binder.Name, actual);
                                    }
                                    else
                                    {
                                        el.___setPropertyByName(binder.Name, UnwrapValue(actual) ?? actual);
                                    }
                                }
                                else
                                {
                                    el.___setPropertyByName(binder.Name, actual);
                                }
                            }
                            catch (Exception ex) { if (commonLog.LoggingEnabled) commonLog.LogEntry($"Element {el}.___setPropertyByName error: {0}", ex.Message); }
                            break;
                        case CHtmlDomTokenList dom:
                            _isTypeSwitchFound = true;
                            try { dom.SetDynamicMember(binder.Name, UnwrapValue(actual) ?? actual); } catch (Exception ex) { if (commonLog.LoggingEnabled) commonLog.LogEntry("DomTokenList.SetDynamicMember error: {0}", ex.Message); }
                            break;
                        case CHtmlMultiversalWindow w:
                            _isTypeSwitchFound = true;
                            try {
                                // For V8 script objects (functions), do NOT unwrap - preserve callable nature
                                var valToSet = actual;
                                if (valToSet != null)
                                {
                                    var valTypeName = valToSet.GetType().FullName ?? string.Empty;
                                    // If it's a V8 script object, use it directly without unwrapping
                                    if (valTypeName.Contains("ClearScript") || valTypeName.Contains("ScriptItem") || valTypeName.Contains("ScriptObject"))
                                    {
                                        w.SetDynamicMember(binder.Name, valToSet);
                                    }
                                    else
                                    {
                                        w.SetDynamicMember(binder.Name, UnwrapValue(valToSet) ?? valToSet);
                                    }
                                }
                                else
                                {
                                    w.SetDynamicMember(binder.Name, valToSet);
                                }
                            } catch (Exception ex) { if (commonLog.LoggingEnabled) commonLog.LogEntry("Window.SetDynamicMember error: {0}", ex.Message); }
                            break;
                    case CHtmlCSSStyleSheet _sheet:
                            _isTypeSwitchFound = true;
                            try { _sheet.SetDynamicMember(binder.Name, UnwrapValue(actual) ?? actual); } catch (Exception ex) { if (commonLog.LoggingEnabled) commonLog.LogEntry("CSS.SetDynamicMember error: {0}", ex.Message); }
                            break;
                }
                }
                catch { }
                var fb = actual ?? value?.Value;
                if (_isTypeSwitchFound)
                {
                    return new DynamicMetaObject(Expression.Constant(fb, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                }


            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"BindSetMember: target type = {binder.Name}, {this.Value} {this.Value?.GetType().FullName ?? "(null)"} isTypeSwitchFound{{_isTypeSwitchFound");
            }
            // If target has a CLR property matching binder.Name, prefer setting it via reflection to avoid dynamic wrapper issues.
            try
            {
                var target = this.Value;
                if (target != null)
                {
                    var t = target.GetType();
                    var prop = GetPropertyIgnoreCaseSafe(t, binder.Name);
                    if (prop != null && prop.CanWrite)
                    {
                        try
                        {
                            object? toAssign = actual;
                            if (toAssign != null && !prop.PropertyType.IsAssignableFrom(toAssign.GetType()))
                            {
                                try { toAssign = Convert.ChangeType(toAssign, prop.PropertyType); } catch { /* leave as-is */ }
                            }
                            prop.SetValue(target, toAssign);
                            var assignedFallback = toAssign ?? value?.Value;
                            return new DynamicMetaObject(Expression.Constant(assignedFallback, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                        }
                        catch (Exception ex)
                        {
                            try { if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5) commonLog.LogEntry("BindSetMember: failed to set CLR property {0} on {1}: {2}", binder.Name, t.FullName, ex.Message); } catch { }
                        }
                    }
                }
            }
            catch { }

            try
            {
                switch (this.Value)
                {
                    case CHtmlInputElement input:
                        try
                        {
                            if (actual != null)
                            {
                                var typeName = actual.GetType().FullName ?? string.Empty;
                                if (typeName.Contains("ClearScript") || typeName.Contains("ScriptItem") || typeName.Contains("ScriptObject") || typeName.Contains("V8"))
                                {
                                    input.SetDynamicMember(binder.Name, actual);
                                }
                                else
                                {
                                    input.SetDynamicMember(binder.Name, UnwrapValue(actual) ?? actual);
                                }
                            }
                            else
                            {
                                input.SetDynamicMember(binder.Name, actual);
                            }
                        }
                        catch (Exception ex) { if (commonLog.LoggingEnabled) commonLog.LogEntry("Input.SetDynamicMember: {0}", ex.Message); }
                        break;
                    case CHtmlElement el:
                        try
                        {
                            if (actual != null)
                            {
                                var typeName = actual.GetType().FullName ?? string.Empty;
                                if (typeName.Contains("ClearScript") || typeName.Contains("ScriptItem") || typeName.Contains("ScriptObject") || typeName.Contains("V8"))
                                {
                                    el.SetDynamicMember(binder.Name, actual);
                                }
                                else
                                {
                                    el.SetDynamicMember(binder.Name, UnwrapValue(actual) ?? actual);
                                }
                            }
                            else
                            {
                                el.SetDynamicMember(binder.Name, actual);
                            }
                        }
                        catch (Exception ex) { if (commonLog.LoggingEnabled) commonLog.LogEntry("Element.SetDynamicMember: {0}", ex.Message); }
                        break;
                    case CHtmlDomTokenList dom:
                        try { dom.SetDynamicMember(binder.Name, UnwrapValue(actual) ?? actual); } catch (Exception ex) { if (commonLog.LoggingEnabled) commonLog.LogEntry("DomTokenList.SetDynamicMember: {0}", ex.Message); }
                        break;
                    case CHtmlDocument doc:
                        try { doc.SetDynamicMember(binder.Name, UnwrapValue(actual) ?? actual); } catch (Exception ex) { if (commonLog.LoggingEnabled) commonLog.LogEntry("Document.SetDynamicMember: {0}", ex.Message); }
                        break;
                    case CHtmlMultiversalWindow w:
                        try {
                            // For V8 script objects (functions), do NOT unwrap - preserve callable nature
                            var valToSet = actual;
                            if (valToSet != null)
                            {
                                var valTypeName = valToSet.GetType().FullName ?? string.Empty;
                                // If it's a V8 script object, use it directly without unwrapping
                                if (valTypeName.Contains("ClearScript") || valTypeName.Contains("ScriptItem") || valTypeName.Contains("ScriptObject"))
                                {
                                    w.SetDynamicMember(binder.Name, valToSet);
                                }
                                else
                                {
                                    w.SetDynamicMember(binder.Name, UnwrapValue(valToSet) ?? valToSet);
                                }
                            }
                            else
                            {
                                w.SetDynamicMember(binder.Name, valToSet);
                            }
                        } catch (Exception ex) { if (commonLog.LoggingEnabled) commonLog.LogEntry("Window.SetDynamicMember: {0}", ex.Message); }
                        break;
                    case CHtmlCanvasContext2D ctx:
                        try
                        {
                            // ensure we do not pass DynamicMetaObject wrappers into the target API
                            var clean = UnwrapValue(actual) ?? actual;
                            ctx.___setPropertyByName(binder.Name, clean);
                        }
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled) commonLog.LogEntry("Canvas.___setPropertyByName: {0}", ex.Message);
                        }
                        break;
                    case CHtmlCSSStyleSheet sheet:
                        try { sheet.SetDynamicMember(binder.Name, UnwrapValue(actual) ?? actual); } catch (Exception ex) { if (commonLog.LoggingEnabled) commonLog.LogEntry("CSS.SetDynamicMember: {0}", ex.Message); }
                        break;
                    case CHtmlXMLHttpRequest xhr:
                        try { xhr.SetDynamicMember(binder.Name, UnwrapValue(actual) ?? actual); } catch (Exception ex) { if (commonLog.LoggingEnabled) commonLog.LogEntry("XHR.SetDynamicMember: {0}", ex.Message); }
                        break;
                    default:
                        // If target exposes a SetDynamicMember via reflection, try calling it with unwrapped value
                        try
                        {
                            var setMethod = GetMethodIgnoreAmbiguous(this.Value?.GetType(), "SetDynamicMember", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, 2);
                            if (setMethod != null && this.Value != null)
                            {
                                try { setMethod.Invoke(this.Value, new object[] { binder.Name, UnwrapValue(actual) ?? actual }); }
                                catch { }
                            }
                        }
                        catch { }
                        
                        break;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                    {
                        var valType = value?.Value?.GetType()?.FullName ?? "(null)";
                        commonLog.LogEntry("BindSetMember handler exception: {0}\nBinder: {1}\nValueType: {2}\nTargetValueType: {3}\nStack:\n{4}",
                            ex.Message,
                            binder?.Name ?? "(null)",
                            valType,
                            this.Value?.GetType().FullName ?? "(null)",
                            ex.ToString());
                    }
                }
                catch { }
            }

            var fallback = actual ?? value?.Value;
            return new DynamicMetaObject(Expression.Constant(fallback, typeof(object)), BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
        }

        public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry($"BindGetIndex: target type = {binder.ToString()}, {this.Value} {this.Value?.GetType().FullName ?? "(null)"}");
            }
            string strIndexArray = null;
            if (indexes != null)
            {
                foreach (var idx in indexes)
                {

                    var rawValue = UnwrapValue(idx.Value) ?? idx.Value;

                    if (rawValue != null)
                    {
                        string valString = rawValue.ToString();

                 
                        bool hasAlphabet = valString.Any(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));

                        if (hasAlphabet)
                        {
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                            {
                                commonLog.LogEntry("BindGetIndex: index value with alphabetic characters detected: {0}", valString);
                            }
                        
                            return null;
                        }

                        strIndexArray += valString + ",";
                    }
                }
            }
     
            try
            {
                if (indexes == null || indexes.Length == 0)
                {
                    return base.BindGetIndex(binder, indexes);
                }

                // Resolve first index into either int or string using helper (handles DynamicMetaObject and wrappers)
                if (!TryResolveIndex(indexes[0], out int? intIndex, out string? strIndex))
                {
                    // best-effort unwrap fallback
                    var raw = UnwrapValue(indexes[0].Value) ?? indexes[0].Value;
                    if (raw is string s) strIndex = s;
                    else
                    {
                        try { intIndex = Convert.ToInt32(raw); } catch { strIndex = raw?.ToString(); }
                    }
                }

                // Handle specific known targets
                switch (this.Value)
                {
                    case CHtmlDocument cHtmlDocument:
                        {
                            if(commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                            {
                                commonLog.LogEntry("CHtmlDocument indexer access with BindGetIndex intIndex={0}, strIndex='{1}'", intIndex.HasValue ? intIndex.Value.ToString() : "(null)", strIndex ?? "(null)");
                            }
                            var result = cHtmlDocument.___getPropertyByIndex((int)intIndex);

                            return new DynamicMetaObject(
                                Expression.Constant(result, typeof(object)),
                                BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                            );
                        }
                        break;
                    case CHtmlCSSStyleSheet cssSheet:
                        {
                            if (!string.IsNullOrEmpty(strIndex))
                            {
                                var result = cssSheet.getPropertyValue(strIndex);
                                return new DynamicMetaObject(
                                    Expression.Constant(result ?? string.Empty, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                );
                            }
                            break;
                        }

                    case CHtmlCollection collection:
                        {
                            if (intIndex.HasValue)
                            {
                                var result = collection[intIndex.Value];
                                return new DynamicMetaObject(
                                    Expression.Constant(result, typeof(object)),
                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType));
                            }

                            if (!string.IsNullOrEmpty(strIndex))
                            {
                                // Try named/indexer access via reflection (get_Item or indexer property)
                                try
                                {
                                    var mi = GetMethodIgnoreAmbiguous(collection.GetType(), "get_Item", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, 1);
                                    if (mi != null)
                                    {
                                        var res = mi.Invoke(collection, new object[] { strIndex });
                                        return new DynamicMetaObject(
                                            Expression.Constant(res, typeof(object)),
                                            BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                        );
                                    }
                                }
                                catch { /* swallow */ }
                            }

                            // If nothing matched, let base try to produce binding expression
                            return base.BindGetIndex(binder, indexes);
                        }

                    default:
                        {
                            // Fallback: try to invoke indexer via reflection on default members
                            var target = this.Value;
                            if (target != null)
                            {
                                var t = target.GetType();
                                var defaultMembers = t.GetDefaultMembers();
                                foreach (var member in defaultMembers)
                                {
                                    if (member is PropertyInfo pi)
                                    {
                                        var indexParams = pi.GetIndexParameters();
                                        if (indexParams.Length == indexes.Length)
                                        {
                                            try
                                            {
                                                var args = new object[indexes.Length];
                                                for (int i = 0; i < indexes.Length; i++)
                                                {
                                                    args[i] = UnwrapValue(indexes[i].Value) ?? indexes[i].Value;
                                                }
                                                var result = pi.GetValue(target, args);
                                                return new DynamicMetaObject(
                                                    Expression.Constant(result, typeof(object)),
                                                    BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType)
                                                );
                                            }
                                            catch { /* swallow */ }
                                        }
                                    }
                                }
                            }
                            break;
                        }

                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                    {
                        commonLog.LogEntry("BindGetIndex exception {0}", ex.ToString());
                    }
                }
                catch { }
            }

            // 必ず有効な DynamicMetaObject を返す（base にフォールバック）
            return base.BindGetIndex(binder, indexes);
        }


        // Helper invoked by bound call sites to safely invoke methods on target via reflection without causing binding exceptions
        private static object? SafeInvoke(object target, string methodName, object[] args)
        {
            if (target == null || string.IsNullOrEmpty(methodName)) return null;
            try
            {
                var methods = target.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(m => string.Equals(m.Name, methodName, StringComparison.OrdinalIgnoreCase)).ToArray();
                if (methods.Length == 0) return null;

                // Unwrap all args first
                var unwrapped = args?.Select(a => UnwrapValue(a) ?? a).ToArray() ?? System.Array.Empty<object?>();

                // try exact param count match with conversions
                foreach (var m in methods)
                {
                    var ps = m.GetParameters();
                    if (ps.Length != unwrapped.Length) continue;
                    var converted = new object?[ps.Length];
                    var ok = true;
                    for (int i = 0; i < ps.Length; i++)
                    {
                        try
                        {
                            var v = unwrapped[i];
                            object? cv;
                            if (v == null)
                            {
                                cv = ps[i].ParameterType.IsValueType ? Activator.CreateInstance(ps[i].ParameterType) : null;
                            }
                            else if (ps[i].ParameterType.IsInstanceOfType(v))
                            {
                                cv = v;
                            }
                            else
                            {
                                cv = Convert.ChangeType(v, ps[i].ParameterType);
                            }
                            converted[i] = cv;
                        }
                        catch { ok = false; break; }
                    }
                    if (!ok) continue;
                    return m.Invoke(target, converted);
                }

                // try object[] overload
                var arrayMethod = methods.FirstOrDefault(m => m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(object[]));
                if (arrayMethod != null)
                {
                    try { return arrayMethod.Invoke(target, new object[] { unwrapped }); } catch (TargetInvocationException tex) { throw tex; }
                }

                // fallback: first method, best-effort conversion
                var candidate = methods.First();
                var cparams = candidate.GetParameters();
                var cargs = new object[cparams.Length];
                for (int i = 0; i < cparams.Length; i++)
                {
                    if (i < unwrapped.Length)
                    {
                        try { cargs[i] = Convert.ChangeType(unwrapped[i], cparams[i].ParameterType); }
                        catch { cargs[i] = cparams[i].HasDefaultValue ? cparams[i].DefaultValue : (cparams[i].ParameterType.IsValueType ? Activator.CreateInstance(cparams[i].ParameterType) : null); }
                    }
                    else
                    {
                        cargs[i] = cparams[i].HasDefaultValue ? cparams[i].DefaultValue : (cparams[i].ParameterType.IsValueType ? Activator.CreateInstance(cparams[i].ParameterType) : null);
                    }
                }
                return candidate.Invoke(target, cargs);
            }
            catch (TargetInvocationException tex)
            {
                try { if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5) commonLog.LogEntry("SafeInvoke TargetInvocationException: {0}\nMethod: {1}\nTargetType: {2}", tex.InnerException?.ToString() ?? tex.ToString(), methodName, target?.GetType().FullName ?? "(null)"); } catch { }
                return null;
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5) commonLog.LogEntry("SafeInvoke exception: {0}\nMethod: {1}\nTargetType: {2}", ex.ToString(), methodName, target?.GetType().FullName ?? "(null)"); } catch { }
                return null;
            }
        }

        // BindGetIndex 内の先頭付近（既存の UnwrapValue を使える位置に挿入）
        private bool TryResolveIndex(DynamicMetaObject indexObj, out int? intIndex, out string? strIndex)
        {
            intIndex = null;
            strIndex = null;

            try
            {
                var raw = UnwrapValue(indexObj?.Value) ?? indexObj?.Value;
                if (raw == null) return false;

                switch (raw)
                {
                    case int i:
                        intIndex = i;
                        return true;
                    case long l:
                        intIndex = (int)l;
                        return true;
                    case short s:
                        intIndex = s;
                        return true;
                    case double d:
                        intIndex = Convert.ToInt32(d);
                                    return true;
                    case float f:
                        intIndex = Convert.ToInt32(f);
                        return true;
                    case decimal m:
                        intIndex = Convert.ToInt32(m);
                        return true;
                    case string sraw:
                        // "3" => index 3, "name" => named lookup
                        if (int.TryParse(sraw, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var p))
                        {
                            intIndex = p;
                        }
                        else
                        {
                            strIndex = sraw;
                        }
                        return true;
                    default:
                        // best-effort: try Convert.ToInt32 on arbitrary object (handles boxed numbers)
                        try
                        {
                            intIndex = Convert.ToInt32(raw);
                            return true;
                        }
                        catch
                        {
                            // fallback to string key if ToString is meaningful
                            var s = raw.ToString();
                            if (!string.IsNullOrEmpty(s))
                            {
                                strIndex = s;
                                return true;
                            }
                        }
                        break;
                }
            }
            catch { /* swallow */ }

            return false;
        }
        
    }
}