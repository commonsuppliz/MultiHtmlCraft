using System;
using System.Linq;
using System.Reflection;

namespace MultiHtmlCraft.Core
{
    // Lightweight proxy to expose stable CLR methods to ClearScript (avoid dynamic binding paths)
    public class CHtmlClearScriptCanvasContextHostProxy
    {
        private readonly CHtmlCanvasContext2D _canvas;

        public CHtmlClearScriptCanvasContextHostProxy(CHtmlCanvasContext2D canvas)
        {
            var ___canvas = canvas;
            this._canvas = ___canvas;
            if(commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy CHtmlClearScriptCanvasContextHostProxy  is called for canvas: {0}", ___canvas != null ? ___canvas.GetType().FullName : "<null>");
            //_canvas = canvas ?? throw new ArgumentNullException(nameof(canvas));
        }

        private static object? Unwrap(object? v)
        {
            if (v == null) return null;
            try
            {
                var t = v.GetType();
                // Use manual property resolution to avoid AmbiguousMatchException
                var props = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                foreach (var pn in new[] { "Value", "value", "Target", "UnderlyingObject", "Underlying", "WrappedObject" })
                {
                    try
                    {
                        var p = props.FirstOrDefault(pi => string.Equals(pi.Name, pn, StringComparison.OrdinalIgnoreCase));
                        if (p != null)
                        {
                            try
                            {
                                var val = p.GetValue(v);
                                if (val != null) return val;
                            }
                            catch { }
                        }
                    }
                    catch { }
                }
            }
            catch { }
            return v;
        }
        public object? globalCompositeOperation
        {
            get
            {
                try { return _canvas.globalCompositeOperation; }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.globalCompositeOperation getter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                    return null;
                }
            }
            set
            {
                try { _canvas.globalCompositeOperation = value; }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.globalCompositeOperation setter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                }
            }
        }

        public object? globalAlpha
        {
            get
            {
                try { return _canvas.globalAlpha; }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.globalAlpha getter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                    return null;
                }
            }
            set
            {
                try
                {
                    // ‘¼‚Ì setter ‚Æ“¯—l‚ÉŒ^•ÏŠ·‚µ‚ÄÝ’è
                    _canvas.globalAlpha = commonHTML.GetDoubleFromObject(value, 1);
                }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.globalAlpha setter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                }
            }
        }

        private static bool TryToDouble(object? v, out double result)
        {
            result = 0.0;
            if (v == null) return false;
            var u = Unwrap(v) ?? v;
            try
            {
                if (u is double d) { result = d; return true; }
                if (u is float f) { result = f; return true; }
                if (u is int i) { result = i; return true; }
                if (u is long l) { result = l; return true; }
                if (u is short s) { result = s; return true; }
                if (u is string str && double.TryParse(str, out var p)) { result = p; return true; }
                result = Convert.ToDouble(u);
                return true;
            }
            catch { return false; }
        }

        // Use reflection to invoke canvas methods to avoid compile-time binding issues
        private object? InvokeMethod(string methodName, params object[] args)
        {
            try
            {
                var methods = _canvas.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(m => string.Equals(m.Name, methodName, StringComparison.OrdinalIgnoreCase)).ToArray();
                if (methods.Length == 0) return null;

                // unwrap arguments
                var unwrapped = args?.Select(a => Unwrap(a) ?? a).ToArray() ?? Array.Empty<object?>();

                // try exact parameter count matching with conversion
                foreach (var m in methods)
                {
                    var ps = m.GetParameters();
                    if (ps.Length != unwrapped.Length) continue;
                    var converted = new object?[ps.Length];
                    var ok = true;
                    for (int i = 0; i < ps.Length; i++)
                    {
                        var pt = ps[i].ParameterType;
                        var val = unwrapped[i];
                        if (val == null)
                        {
                            converted[i] = pt.IsValueType ? Activator.CreateInstance(pt) : null;
                            continue;
                        }
                        try
                        {
                            if (pt == typeof(double))
                            {
                                if (!TryToDouble(val, out var d)) { ok = false; break; }
                                converted[i] = d;
                            }
                            else if (pt == typeof(float))
                            {
                                if (!TryToDouble(val, out var d)) { ok = false; break; }
                                converted[i] = (float)d;
                            }
                            else if (pt.IsAssignableFrom(val.GetType()))
                            {
                                converted[i] = val;
                            }
                            else
                            {
                                converted[i] = Convert.ChangeType(val, pt);
                            }
                        }
                        catch { ok = false; break; }
                    }
                    if (!ok) continue;
                    return m.Invoke(_canvas, converted);
                }

                // try first overload with fewer params by filling defaults
                var candidate = methods.OrderBy(m => Math.Abs(m.GetParameters().Length - unwrapped.Length)).First();
                var cparams = candidate.GetParameters();
                var cargs = new object[cparams.Length];
                for (int i = 0; i < cparams.Length; i++)
                {
                    if (i < unwrapped.Length && unwrapped[i] != null)
                    {
                        try { cargs[i] = Convert.ChangeType(unwrapped[i], cparams[i].ParameterType); } catch { cargs[i] = unwrapped[i]; }
                    }
                    else
                    {
                        cargs[i] = cparams[i].HasDefaultValue ? cparams[i].DefaultValue : (cparams[i].ParameterType.IsValueType ? Activator.CreateInstance(cparams[i].ParameterType) : null);
                    }
                }
                return candidate.Invoke(_canvas, cargs);
            }
            catch (TargetInvocationException tex)
            {
                try { if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5) commonLog.LogEntry("Proxy Invoke TargetInvocationException: {0}", tex.InnerException?.ToString() ?? tex.ToString()); } catch { }
                return null;
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5) commonLog.LogEntry("Proxy Invoke exception: {0}", ex.ToString()); } catch { }
                return null;
            }
        }

        // Exposed convenience methods - implement common ones directly to avoid reflection and ClearScript dynamic helper issues
        public void moveTo(object x, object y)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("Proxy.moveTo called with ({0},{1})", x?.GetType().FullName ?? "<null>", y?.GetType().FullName ?? "<null>");
                    commonLog.LogEntry("Canvas state: Width={0}, Height={1}", _canvas.Width, _canvas.Height);
                }
                if (TryToDouble(x, out var dx) && TryToDouble(y, out var dy))
                {
                    _canvas.moveTo(dx, dy);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.moveTo exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void lineTo(object x, object y)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.lineTo called with ({0},{1})", x?.GetType().FullName ?? "<null>", y?.GetType().FullName ?? "<null>");
                if (TryToDouble(x, out var dx) && TryToDouble(y, out var dy))
                {
                    _canvas.lineTo(dx, dy);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.lineTo exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void stroke()
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.stroke called");
                _canvas.stroke();
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.stroke exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void beginPath()
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.beginPath called");
                _canvas.beginPath();
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.beginPath exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void clearRect(object x, object y, object w, object h)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.clearRect called with types ({0},{1},{2},{3})", x?.GetType().FullName ?? "<null>", y?.GetType().FullName ?? "<null>", w?.GetType().FullName ?? "<null>", h?.GetType().FullName ?? "<null>");
                if (TryToDouble(x, out var dx) && TryToDouble(y, out var dy) && TryToDouble(w, out var dw) && TryToDouble(h, out var dh))
                {
                    _canvas.clearRect(dx, dy, dw, dh);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.clearRect exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void closePath()
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.closePath called");
                _canvas.closePath();
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.closePath exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void clip()
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.clip called");
                _canvas.clip();
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.clip exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }
  

        public void fill()
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.fill called");
                _canvas.fill();
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.fill exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void putImageData(params object[] args)
        {
            if(commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.putImageData called with {0} arguments", args?.Length ?? 0);
            if (args == null || args.Length < 3)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5) commonLog.LogEntry("Proxy.putImageData called with insufficient arguments");
                return;
            }
            _canvas.putImageData(args[0], args[1], args[2]);

        }

        public object? getImageData(params object[] args)
        {
            if(commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("Proxy.getImageData is called  with arguments: " + string.Join(", ", args));
            }
            if (args == null || args.Length < 2)
                return null;
            switch(args.Length)
            {
                case 2:
                    return _canvas.getImageData(args[0], args[1], null, null);
                case 4:
                    return _canvas.getImageData(args[0], args[1], args[2], args[3]);
            }
            return null;
        }

        public object? createImageData(params object[] args)
        {
            try
            {
                double? w = null;
                double? h = null;
                bool IsImgeDataImageIsDefined = false;

                switch (args.Length)
                {

                    case 1:
                        if (args[0] != null && args[0].GetType().Name == "CHtmlImageData")
                        {
                            IsImgeDataImageIsDefined = true;
                            w = commonHTML.GetDoubleFromObject(args[0], 0);
                            h = commonHTML.GetDoubleFromObject(args[1], 0);
                        }
                        break;
                    case 2:
                        w = commonHTML.GetDoubleFromObject(args[0], 0);
                        h = commonHTML.GetDoubleFromObject(args[1], 0);
                        break;
                        { }
                    case 3:
                        w = commonHTML.GetDoubleFromObject(args[0], 0);
                        h = commonHTML.GetDoubleFromObject(args[1], 0);
                        IsImgeDataImageIsDefined = true;
                        break;
                    case 5:
                        w = commonHTML.GetDoubleFromObject(args[0], 0);
                        h = commonHTML.GetDoubleFromObject(args[1], 0);
                        IsImgeDataImageIsDefined = true;
                        break;

                    case 6:
                        w = commonHTML.GetDoubleFromObject(args[0], 0);
                        h = commonHTML.GetDoubleFromObject(args[1], 0);
                        IsImgeDataImageIsDefined = true;
                        break;
                }
        
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.createImageData called");
                return _canvas.createImageData(w, h);
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.createImageData exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
            return null;
        }
        
        public void transform(double a, double b, double c, double d, double e, double f)
        {
            _canvas.transform(a, b, c, d, e, f);
        }
        public void setTransform(double a, double b, double c, double d, double e, double f)
        { 
            _canvas.setTransform(a, b, c, d, e, f);
        }
        public void translate(object x, object y)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.translate called with ({0},{1})", x?.GetType().FullName ?? "<null>", y?.GetType().FullName ?? "<null>");
                if (TryToDouble(x, out var dx) && TryToDouble(y, out var dy))
                {
                    _canvas.translate(dx, dy);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.translate exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void rotate(object angle)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.rotate called with ({0})", angle?.GetType().FullName ?? "<null>");
                if (TryToDouble(angle, out var a))
                {
                    _canvas.rotate(a);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.rotate exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }
        public void scale(params object[] args)
        {
            if(commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("Proxy.scale called");
            }
            _canvas.scale(commonHTML.GetDoubleFromObject(args[0], 0), commonHTML.GetDoubleFromObject(args[1], 0));
        }

        // Added save / restore forwarding so ClearScript JS ctx.save() / ctx.restore() exist
        public void save()
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.save called");
                _canvas.save();
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.save exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void restore()
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.restore called");
                _canvas.restore();
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.restore exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void fillRect(object x, object y, object w, object h)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.fillRect called with types ({0},{1},{2},{3})", x?.GetType().FullName ?? "<null>", y?.GetType().FullName ?? "<null>", w?.GetType().FullName ?? "<null>", h?.GetType().FullName ?? "<null>");
                if (TryToDouble(x, out var dx) && TryToDouble(y, out var dy) && TryToDouble(w, out var dw) && TryToDouble(h, out var dh))
                {
                    _canvas.fillRect(dx, dy, dw, dh);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.fillRect exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void strokeRect(object x, object y, object w, object h)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.strokeRect called with types ({0},{1},{2},{3})", x?.GetType().FullName ?? "<null>", y?.GetType().FullName ?? "<null>", w?.GetType().FullName ?? "<null>", h?.GetType().FullName ?? "<null>");
                if (TryToDouble(x, out var dx) && TryToDouble(y, out var dy) && TryToDouble(w, out var dw) && TryToDouble(h, out var dh))
                {
                    _canvas.strokeRect(dx, dy, dw, dh);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.strokeRect exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void arc(object x, object y, object radius, object startAngle, object endAngle, object anticlockwise = null)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.arc called");
                if (TryToDouble(x, out var dx) && TryToDouble(y, out var dy) && TryToDouble(radius, out var dr) && TryToDouble(startAngle, out var ds) && TryToDouble(endAngle, out var de))
                {
                    _canvas.arc(dx, dy, dr, ds, de, anticlockwise != null && Convert.ToBoolean(anticlockwise));
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.arc exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void ellipse(object x, object y, object radiusX, object radiusY, object rotation, object startAngle, object endAngle, object anticlockwise = null)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.ellipse called");
                if (TryToDouble(x, out var dx) && TryToDouble(y, out var dy) && TryToDouble(radiusX, out var drx) && TryToDouble(radiusY, out var dry) && TryToDouble(rotation, out var drot) && TryToDouble(startAngle, out var ds) && TryToDouble(endAngle, out var de))
                {
                    _canvas.ellipse(dx, dy, drx, dry, drot, ds, de, anticlockwise != null && Convert.ToBoolean(anticlockwise));
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.ellipse exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }
        public void arcTo(object x1, object y1, object x2, object y2, object radius)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.arcTo called");
                if (TryToDouble(x1, out var dx1) && TryToDouble(y1, out var dy1) && TryToDouble(x2, out var dx2) && TryToDouble(y2, out var dy2) && TryToDouble(radius, out var dr))
                {
                   _canvas.arcTo(dx1, dy1, dx2, dy2, dr, false);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.arcTo exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        // Expose gradient creation methods so they appear as functions to ClearScript/JS
        public object? createRadialGradient(object x0, object y0, object r0, object x1, object y1, object r1)
        {
            try
            {
                if (TryToDouble(x0, out var dx0) && TryToDouble(y0, out var dy0) && TryToDouble(r0, out var dr0) && TryToDouble(x1, out var dx1) && TryToDouble(y1, out var dy1))
                {
                    if (TryToDouble(r1, out var dr1))
                    {
                        return _canvas.createRadialGradient(dx0, dy0, dr0, dx1, dy1, dr1);
                    }
                    // fallback to reflection so overloads that accept object work
                    return InvokeMethod("createRadialGradient", dx0, dy0, dr0, dx1, dy1, r1 ?? 0);
                }
                return InvokeMethod("createRadialGradient", x0 ?? 0, y0 ?? 0, r0 ?? 0, x1 ?? 0, y1 ?? 0, r1 ?? 0);
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.createRadialGradient exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                return null;
            }
        }

        public object? createLinearGradient(object x0, object y0, object x1, object y1, object p5 = null, object p6 = null)
        {
            try
            {
                if (TryToDouble(x0, out var dx0) && TryToDouble(y0, out var dy0) && TryToDouble(x1, out var dx1) && TryToDouble(y1, out var dy1))
                {
                    if (p5 == null && p6 == null)
                    {
                        return _canvas.createLinearGradient(dx0, dy0, dx1, dy1);
                    }
                    if (p5 != null && TryToDouble(p5, out var dp5) && p6 == null)
                    {
                        return _canvas.createLinearGradient(dx0, dy0, dx1, dy1, dp5);
                    }
                    if (p5 != null && p6 != null && TryToDouble(p5, out var dp5b) && TryToDouble(p6, out var dp6b))
                    {
                        return _canvas.createLinearGradient(dx0, dy0, dx1, dy1, dp5b, dp6b);
                    }
                    return InvokeMethod("createLinearGradient", dx0, dy0, dx1, dy1, p5 ?? 0, p6 ?? 0);
                }
                return InvokeMethod("createLinearGradient", x0 ?? 0, y0 ?? 0, x1 ?? 0, y1 ?? 0, p5 ?? 0, p6 ?? 0);
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.createLinearGradient exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                return null;
            }
        }

        // Fallback: reflection-based invoke for less-common methods
        public object? Invoke(string methodName, params object[] args) => InvokeMethod(methodName, args);

        public object? strokeStyle
        {
            get
            {
                try
                {
                    var prop = _canvas.GetType().GetProperty("strokeStyle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    return prop?.GetValue(_canvas);
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                        commonLog.LogEntry("Proxy.strokeStyle getter exception: {0}\n{1}", ex.Message, ex.ToString());
                    return null;
                }
            }
            set
            {
                try
                {
                    var prop = _canvas.GetType().GetProperty("strokeStyle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    if (prop != null && prop.CanWrite)
                    {
                        prop.SetValue(_canvas, value);
                    }
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                        commonLog.LogEntry("Proxy.strokeStyle setter exception: {0}\n{1}", ex.Message, ex.ToString());
                }
            }
        }

        // Added fillStyle proxy to forward assignments from JS (e.g. ctx.fillStyle = gradient)
        public object? fillStyle
        {
            get
            {
                try
                {
                    return _canvas.fillStyle;
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                        commonLog.LogEntry("Proxy.fillStyle getter exception: {0}\n{1}", ex.Message, ex.ToString());
                    return null;
                }
            }
            set
            {
                try
                {
                    _canvas.fillStyle = value;

                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                        commonLog.LogEntry("Proxy.fillStyle setter exception: {0}\n{1}", ex.Message, ex.ToString());
                }
            }
        }

        public object? lineWidth
        {
            get
            {
                try
                {
                    return _canvas.lineWidth;
                    
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                        commonLog.LogEntry("Proxy.lineWidth getter exception: {0}\n{1}", ex.Message, ex.ToString());
                    return null;
                }
            }
            set
            {
                try
                {
                    _canvas.lineWidth = commonHTML.GetDoubleFromObject(value, 0);
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                        commonLog.LogEntry("Proxy.lineWidth setter exception: {0}\n{1}", ex.Message, ex.ToString());
                }
            }
        }
        public object? lineJoin
        {
            get
            {
                try
                {
                    return _canvas.lineJoin;
                    
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                        commonLog.LogEntry("Proxy.lineJoin getter exception: {0}\n{1}", ex.Message, ex.ToString());
                    return null;
                }
            }
            set
            {
                try
                {
                    _canvas.lineJoin = value;
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                        commonLog.LogEntry("Proxy.lineJoin setter exception: {0}\n{1}", ex.Message, ex.ToString());
                }
            }
        }
        public object? lineCap
        {
            get
            {
                try
                {
                    return _canvas.lineCap;

                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                        commonLog.LogEntry("Proxy.lineCap getter exception: {0}\n{1}", ex.Message, ex.ToString());
                    return null;
                }
            }
            set
            {
                try
                {
                    _canvas.lineCap = value;
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                        commonLog.LogEntry("Proxy.lineCap Getter exception: {0}\n{1}", ex.Message, ex.ToString());
                }
            }
        }
        // --- Added missing font, textAlign, textBaseline, measureText, fillText, strokeText proxies ---
        public object? font
        {
            get
            {
                try { return _canvas.font; }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.font getter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                    return null;
                }
            }
            set
            {
                try { _canvas.font = value; }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.font setter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                }
            }
        }

        public object? textAlign
        {
            get
            {
                try { return _canvas.textAlign; }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.textAlign getter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                    return null;
                }
            }
            set
            {
                try { _canvas.textAlign = value; }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.textAlign setter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                }
            }
        }

        public object? shadowBlur
        {
            get
            {
                try { return _canvas.shadowBlur; }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.shadowBlur getter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                    return null;
                }
            }
            set
            {
                 var val =commonHTML.GetDoubleFromObject(value, 0); // validate conversion but ignore result since underlying property accepts object
                try { _canvas.shadowBlur = val; }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.shadowBlur setter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                }
            }
        }
        public object? shadowColor
        {
            get
            {
                try { return _canvas.shadowColor; }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.shadowColor getter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                    return null;
                }
            }
            set
            {
                // validate conversion but ignore result since underlying property accepts object
                try { _canvas.shadowColor = value; }
                catch (Exception ex)
                {

                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.shadowColor setter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                }
            }
        }
        public object? textBaseline
        {
            get
            {
                try { return _canvas.textBaseLine; }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.textBaseline getter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                    return null;
                }
            }
            set
            {
                try { _canvas.textBaseLine = value; }
                catch (Exception ex)
                {
                    try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.textBaseline setter exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                }
            }
        }

        public object? measureText(object text)
        {
            try
            {
                var t = Unwrap(text) ?? text;
                string s = commonHTML.GetStringValue(t);
                return _canvas.measureText(s);
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.measureText exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
                return null;
            }
        }
        
        public void bezierCurveTo(object cp1x, object cp1y, object cp2x, object cp2y, object x, object y)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("Proxy.bezierCurveTo called with types ({0},{1},{2},{3},{4},{5})",
                        cp1x?.GetType().FullName ?? "<null>", cp1y?.GetType().FullName ?? "<null>",
                        cp2x?.GetType().FullName ?? "<null>", cp2y?.GetType().FullName ?? "<null>",
                        x?.GetType().FullName ?? "<null>", y?.GetType().FullName ?? "<null>");
                }

                if (TryToDouble(cp1x, out var a) && TryToDouble(cp1y, out var b)
                    && TryToDouble(cp2x, out var c) && TryToDouble(cp2y, out var d)
                    && TryToDouble(x, out var e) && TryToDouble(y, out var f))
                {
                    _canvas.bezierCurveTo(a, b, c, d, e, f);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.bezierCurveTo exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        
        public void quadraticCurveTo(object cpx, object cpy, object x, object y)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("Proxy.quadraticCurveTo called with types ({0},{1},{2},{3})",
                        cpx?.GetType().FullName ?? "<null>", cpy?.GetType().FullName ?? "<null>",
                        x?.GetType().FullName ?? "<null>", y?.GetType().FullName ?? "<null>");
                }

                if (TryToDouble(cpx, out var a) && TryToDouble(cpy, out var b)
                    && TryToDouble(x, out var c) && TryToDouble(y, out var d))
                {
                    _canvas.quadraticCurveTo(a, b, c, d);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.quadraticCurveTo exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void fillText(object text, object x, object y, object maxWidth = null)
        {
            try
            {
                var t = Unwrap(text) ?? text;
                string s = commonHTML.GetStringValue(t);

                if (TryToDouble(x, out var dx) && TryToDouble(y, out var dy))
                {
                    if (maxWidth != null && TryToDouble(maxWidth, out var dm))
                    {
                        _canvas.fillText(s, dx, dy, dm);
                    }
                    else
                    {
                        _canvas.fillText(s, dx, dy);
                    }
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.fillText exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void strokeText(object text, object x, object y, object maxWidth = null)
        {
            try
            {
                var t = Unwrap(text) ?? text;
                string s = commonHTML.GetStringValue(t);

                if (TryToDouble(x, out var dx) && TryToDouble(y, out var dy))
                {
                    if (maxWidth != null && TryToDouble(maxWidth, out var dm))
                    {
                        _canvas.strokeText(s, dx, dy, dm);
                    }
                    else
                    {
                        _canvas.strokeText(s, dx, dy);
                    }
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.strokeText exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        // --- Added drawImage overloads to forward JS calls to underlying canvas ---
        // drawImage(image, dx, dy)
        public void drawImage(object image, object dx, object dy)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.drawImage(image, dx, dy) called");
                if (TryToDouble(dx, out var ddx) && TryToDouble(dy, out var ddy))
                {
                    var img = Unwrap(image) ?? image;
                    _canvas.drawImage(img, ddx, ddy);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.drawImage(image, dx, dy) exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        // drawImage(image, dx, dy, dw, dh) or drawImage(image, dx, dy, ow, oh) (object overload)
        public void drawImage(object image, object dx, object dy, object ow, object oh)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.drawImage(image, dx, dy, ow, oh) called");
                if (!TryToDouble(dx, out var ddx) || !TryToDouble(dy, out var ddy))
                    return;

                // if both ow/oh convertible to double -> call the (double dx,double dy,double dw,double dh) overload
                if (TryToDouble(ow, out var ddw) && TryToDouble(oh, out var ddh))
                {
                    var img = Unwrap(image) ?? image;
                    _canvas.drawImage(img, ddx, ddy, ddw, ddh);
                }
                else
                {
                    // fallback to object-typed overload on canvas
                    var img = Unwrap(image) ?? image;
                    _canvas.drawImage(img, ddx, ddy, ow, oh);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.drawImage(image, dx, dy, ow, oh) exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        // drawImage(image, ox, oy, ow, oh)  -- keep as forwarding with objects (canvas has object-typed overload)
        public void drawImage(object image, object ox, object oy, object ow, object oh, bool _dummy = false)
        {
            // This overload exists to support some JS calling conventions where all parameters are objects.
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.drawImage(image, ox, oy, ow, oh) (object forwarding) called");
                var img = Unwrap(image) ?? image;
                _canvas.drawImage(img, ox, oy, ow, oh);
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.drawImage(object) exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

        public void drawImage(object image, double dx, double dy, double dw, double dh)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("Proxy.drawImage(image, dx, dy, dw, dh) called");
                }

                var img = Unwrap(image) ?? image;
                _canvas.drawImage(img, dx, dy, dw, dh);
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.drawImage(image, dx, dy, dw, dh) exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }
        // drawImage(image, sx, sy, sw, sh, dx, dy, dw, dh)
        public void drawImage(object image, object sx, object sy, object sw, object sh, object dx, object dy, object dw, object dh)
        {
            try
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8) commonLog.LogEntry("Proxy.drawImage(image, sx, sy, sw, sh, dx, dy, dw, dh) called");
                if (TryToDouble(sx, out var ssx) && TryToDouble(sy, out var ssy) && TryToDouble(sw, out var ssw) && TryToDouble(sh, out var ssh)
                    && TryToDouble(dx, out var ddx) && TryToDouble(dy, out var ddy) && TryToDouble(dw, out var ddw) && TryToDouble(dh, out var ddh))
                {
                    var img = Unwrap(image) ?? image;
                    _canvas.drawImage(img, ssx, ssy, ssw, ssh, ddx, ddy, ddw, ddh);
                }
                else
                {
                    // fallback to reflection if some parameters are not pure numeric
                    var img = Unwrap(image) ?? image;
                    InvokeMethod("drawImage", img, sx ?? 0, sy ?? 0, sw ?? 0, sh ?? 0, dx ?? 0, dy ?? 0, dw ?? 0, dh ?? 0);
                }
            }
            catch (Exception ex)
            {
                try { if (commonLog.LoggingEnabled) commonLog.LogEntry("Proxy.drawImage(9args) exception: {0}\n{1}", ex.Message, ex.ToString()); } catch { }
            }
        }

    }
}