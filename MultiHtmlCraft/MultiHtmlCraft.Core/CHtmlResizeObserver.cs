using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using Microsoft.ClearScript;
using System.Dynamic;

namespace MultiHtmlCraft.Core
{
    public class CHtmlResizeRecord
    {
        public CHtmlNode? Target { get; init; }
        public RectangleF? ContentRect { get; init; }
    }

    public delegate void CHtmlResizeCallback(IReadOnlyList<CHtmlResizeRecord> records, CHtmlResizeObserver observer);

    public class CHtmlResizeObserver
    {
        public bool ___IsPrototype { get; set; }
        public WeakReference? ___ownerDocumentWeakReference { get; set; }

        private readonly List<CHtmlResizeRecord> _queue = new();
        private readonly object _queueLock = new();
        private readonly List<CHtmlElement> _targets = new();
        private readonly CHtmlResizeCallback _callback;
        private ScriptObject? _scriptCallback;

        public CHtmlResizeObserver(params object[] args)
        {
            if (args != null && args.Length > 0 && args[0] is ScriptObject so)
            {
                _scriptCallback = so;
            }
            _callback = DeliverToScriptCallback;
        }

        internal CHtmlResizeObserver(CHtmlResizeCallback callback)
        {
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        }

        private static object ConvertRecordToJs(CHtmlResizeRecord r)
        {
            IDictionary<string, object?> exp = new ExpandoObject();
            exp["target"] = r.Target;
            if (r.ContentRect.HasValue)
            {
                var rect = r.ContentRect.Value;
                IDictionary<string, object?> rj = new ExpandoObject();
                rj["x"] = rect.X;
                rj["y"] = rect.Y;
                rj["width"] = rect.Width;
                rj["height"] = rect.Height;
                exp["contentRect"] = rj;
            }
            else
            {
                exp["contentRect"] = null;
            }
            return exp;
        }

        private void DeliverToScriptCallback(IReadOnlyList<CHtmlResizeRecord> records, CHtmlResizeObserver observer)
        {
            if (_scriptCallback == null) return;
            try
            {
                var jsArray = records.Select(ConvertRecordToJs).ToArray();
                _scriptCallback.Invoke(false, jsArray, observer);
            }
            catch { }
        }

        public void Observe(CHtmlElement target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            lock (_targets) { if (!_targets.Contains(target)) _targets.Add(target); }
            CHtmlResizeObserverDispatcher.Register(target, this);
        }

        public void observe(object target)
        {
            if (target is CHtmlElement el) Observe(el);
        }

        public void Disconnect()
        {
            lock (_targets)
            {
                foreach (var t in _targets) CHtmlResizeObserverDispatcher.Unregister(t, this);
                _targets.Clear();
            }
            lock (_queueLock) _queue.Clear();
        }

        public object disconnect() { Disconnect(); return null; }

        public List<CHtmlResizeRecord> TakeRecords()
        {
            lock (_queueLock)
            {
                var list = new List<CHtmlResizeRecord>(_queue);
                _queue.Clear();
                return list;
            }
        }

        public object takeRecords() => TakeRecords().Select(ConvertRecordToJs).ToArray();

        internal void Enqueue(CHtmlResizeRecord r)
        {
            lock (_queueLock) { _queue.Add(r); }
        }

        internal void DeliverQueued()
        {
            List<CHtmlResizeRecord> deliver;
            lock (_queueLock)
            {
                if (_queue.Count == 0) return;
                deliver = new List<CHtmlResizeRecord>(_queue);
                _queue.Clear();
            }
            try { _callback(deliver, this); } catch { }
        }
    }

    internal static class CHtmlResizeObserverDispatcher
    {
        private class Reg
        {
            public WeakReference<CHtmlResizeObserver> Observer { get; }
            public Reg(CHtmlResizeObserver obs) { Observer = new WeakReference<CHtmlResizeObserver>(obs); }
        }

        private static readonly ConcurrentDictionary<CHtmlElement, List<Reg>> _map = new();
        private static System.Threading.Timer? _pollTimer;
        private static readonly object _lock = new object();

        internal static void Register(CHtmlElement target, CHtmlResizeObserver obs)
        {
            var list = _map.GetOrAdd(target, _ => new List<Reg>());
            lock (list) { list.Add(new Reg(obs)); }
            EnsureTimer();
        }

        internal static void Unregister(CHtmlElement target, CHtmlResizeObserver obs)
        {
            if (!_map.TryGetValue(target, out var list)) return;
            lock (list)
            {
                list.RemoveAll(r => !r.Observer.TryGetTarget(out var o) || o == obs);
                if (list.Count == 0) _map.TryRemove(target, out _);
            }
        }

        private static void EnsureTimer()
        {
            lock (_lock)
            {
                if (_pollTimer == null)
                {
                    _pollTimer = new System.Threading.Timer(_ => { try { Poll(); } catch { } }, null, 100, 100);
                }
            }
        }

        private static void Poll()
        {
            foreach (var kv in _map)
            {
                var el = kv.Key;
                var list = kv.Value;
                RectangleF bounds;
                try
                {
                    var rectSpec = el.GetElementBoundsOnScreen();
                    bounds = new RectangleF(rectSpec.Left, rectSpec.Top, rectSpec.Width, rectSpec.Height);
                }
                catch { continue; }

                lock (list)
                {
                    foreach (var reg in list)
                    {
                        if (!reg.Observer.TryGetTarget(out var obs)) continue;
                        // For simplicity, enqueue every poll as a resize record. Real impl should compare prev size.
                        var record = new CHtmlResizeRecord { Target = el, ContentRect = bounds };
                        obs.Enqueue(record);
                    }
                }
            }
            // deliver queued
            foreach (var kv in _map)
            {
                var list = kv.Value;
                lock (list)
                {
                    foreach (var reg in list)
                    {
                        if (!reg.Observer.TryGetTarget(out var obs)) continue;
                        obs.DeliverQueued();
                    }
                }
            }
        }
    }
}
