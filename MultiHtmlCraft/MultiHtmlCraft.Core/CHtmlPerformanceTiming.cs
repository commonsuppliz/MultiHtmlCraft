using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    public sealed class CHtmlPerformanceTiming : CHtmlNode , ICommonObjectInterface 
    {
        internal System.WeakReference ___ownerDocumentWeakReference = null;

        internal System.Collections.Generic.Dictionary<CHtmlPerformanceTimmingParameterType, double> ___timmingValueList;
        public CHtmlPerformanceTiming()
        {
            ___timmingValueList = new Dictionary<CHtmlPerformanceTimmingParameterType, double>();
        }
        public string getClassName()
        {
            return "PerformanceTiming";
        }
        internal void ___clearCounterData()
        {
            this.___timmingValueList.Clear();
        
        }
        /// <summary>
        /// If Value is not found in list dictionary this will be returned.
        /// </summary>
        internal static double Not_Assigned_Value = 100;
  

        public double domContentLoadedEventStart
        {
            get
            {
                double _val;
                if(this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domContentLoadedEventStart, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double navigationStart
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.navigationStart, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double redirectStart
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.redirectStart, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double redirectEnd
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.redirectEnd, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double fetchStart
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.fetchStart, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double domainLookupStart
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domainLookupStart, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double domainLookupEnd
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domainLookupEnd, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double connectStart
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.connectStart, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double connectEnd
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.connectEnd, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double  requestStart
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.requestStart, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double requestEnd
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.requestEnd, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double  responseStart
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.responseStart, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double  responseEnd
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.responseEnd, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double  domLoading
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domLoading, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double  domInteractive
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domInteractive, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double  domComplete
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domComplete, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double  domContentLoadedStart
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domContentLoadedStart, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double domContentLoadedEnd
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domContentLoadedEnd, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double  loadEventStart
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.loadEventStart, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double  loadEventEnd
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.loadEventEnd, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double  unloadEventStart
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.unloadEventStart, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        public double  unloadEventEnd
        {
            get
            {
                double _val;
                if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.unloadEventEnd, out _val) == true)
                {
                    return _val;
                }
                return Not_Assigned_Value;
            }
        }
        #region IPropertBox メンバ

        public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} ", this, ___name);
            }
            double _val;
            switch (___name)
            {
                case "navigationStart":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.navigationStart, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "redirectStart":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.redirectStart, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "redirectEnd":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.redirectEnd, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "fetchStart":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.fetchStart, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "domainLookupStart":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domainLookupStart, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "domainLookupEnd":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domainLookupEnd, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "connectStart":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.connectStart, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "connectEnd":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.connectEnd, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "requestStart":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.requestStart, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "requestEnd":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.requestEnd, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "responseStart":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.responseStart, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "responseEnd":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.responseEnd, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "domLoading":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domLoading, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "domInteractive":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domInteractive, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "domContentLoadedStart":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domContentLoadedEventStart, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "domContentLoadedEnd":
                case "domContentLoad":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domContentLoadedEnd, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "domComplete":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domComplete, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "loadEventStart":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.loadEventStart, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "loadEventEnd":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.loadEventEnd, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "unloadEventStart":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.unloadEventStart, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "unloadEventEnd":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.unloadEventEnd, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "domContentLoadedEventStart":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domContentLoadedEventStart, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                case "domContentLoadedEventEnd":
                    if (this.___timmingValueList.TryGetValue(CHtmlPerformanceTimmingParameterType.domContentLoadedEventEnd, out _val) == true)
                    {
                        return _val;
                    }
                    return Not_Assigned_Value;
                default:
                    break;
            }
            object propValue;
            if (___properties.TryGetValue(___name, out propValue))
            {
                return propValue;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} failed", this, ___name);
            }
            return null;
        }

        public void ___setPropertyByName(string ___name, object val)
        {
            switch (___name)
            {
                default:
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    this.___properties[___name] = val;
                    break;
            }
        }
        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValueInex for {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public bool ___hasPropertyByName(string ___name)
        {

            return false;
        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }
        public object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }
        public string ___getClassName()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
            }
            return this.GetType().Name;
        }
        public object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public object ___getParentScope()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public object ___getProtoType()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public override string ToString()
        {
            return "[object " + this.multiversalClassType.ToString() + "]";
        }
        public new IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.PerformanceTiming;
            }
        }
        /*
        internal sealed class CHtmlPerformanceTimingDataSet
        {
            internal double navigationStart;
            internal double unloadEventStart;
            internal double unloadEventEnd;
            internal double redirectStart;
            internal double redirectEnd;
            internal double fetchStart;
            internal double domainLookupStart;
            internal double domainLookupEnd;
            internal double connectStart;
            internal double connectEnd;
            internal double secureConnectionStart;
            internal double requestStart;
            internal double requestEnd;
            internal double responseStart;
            internal double responseEnd;
            internal double domLoading;
            internal double domInteractive;
            internal double domContentLoadedEventStart;
            internal double domContentLoadedEventEnd;
            internal double domComplete;
            internal double loadEventStart;
            internal double loadEventEnd = 100;
            internal double domContentLoadedStart;
            internal double domContentLoadedEnd;
        }
        */
        #endregion
    }
}
