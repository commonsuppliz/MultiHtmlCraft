using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    public sealed class CHtmlPerformance : CHtmlNode , ICommonObjectInterface 
    {
        internal System.WeakReference ___ownerDocumentWeakReference = null;


        private CHtmlPerformanceTiming ___timing = new CHtmlPerformanceTiming();
        private CHtmlPerformanceNavigation ___navigation = new CHtmlPerformanceNavigation();

        public string getClassName()
        {
            return this.ToString();
        }

        #region IPropertBox メンバ
        public CHtmlPerformanceTiming timing
        {
            get
            {
                return this.___timing;
            }
        }
        public object ___getPropertyByName(string ___name)
        {
            switch (___name)
            {
                case "timing":
                    return this.___timing;
                case "navigation":
                    return this.___navigation;
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
               commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
            }
            return null;
        }
        public void mark(object ___markObj)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.mark()", this);
            }
        }
        public void clearMarks()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.clearMarks()", this);
            }
        }
        public void clearResourceTimings()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.clearResourceTimings()", this);
            }
        }
        public CHtmlPerformanceEntriesList  getEntries()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.getEntries()", this);
            }
            return this.___getEntriesByNameInner(null, null);
        }
        public void clearMeasures(object ___measureNameObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.clearMeasures()", this);
            }
        }
        public void clearMeasures()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.clearMeasures()", this);
            }
        }
        public object  getMeasures(object ___measureNameObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.getMeasures()", this);
            }
            return null;
        }
        public void  setResourceTimingBufferSize(object ___maxSize)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.setResourceTimingBufferSize()", this);
            }
        }
        public DateTime now()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling navigator.performance.now(). retuns DateTime.Now.", this);
            }
            return DateTime.Now;
        }
        public object measure(object measureName,object  startMarkName, object endMarkName)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.measure()", this);
            }
            return null;
        }
        public CHtmlPerformanceEntriesList getEntriesByName(object name, object entryType)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.getEntriesByName()", this);
            }
            return ___getEntriesByNameInner(name, entryType);
        }
        public CHtmlPerformanceEntriesList getEntriesByName(object name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("caling {0}.getEntriesByName()", this);
            }
            return ___getEntriesByNameInner(name, null);
        }
        private CHtmlPerformanceEntriesList ___getEntriesByNameInner(object ___name, object ___entryType)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO:  {0}.getEntriesByName()", this);
            }
            CHtmlPerformanceEntriesList ___entryCollection = new CHtmlPerformanceEntriesList();
            return ___entryCollection;
        }
        public CHtmlPerformanceEntriesList  getEntriesByType(object ___entryType)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.getEntriesByType()", this);
            }
            CHtmlPerformanceEntriesList ___entryCollection = new CHtmlPerformanceEntriesList();
            
            return ___entryCollection;
        }
        public void ___setPropertyByName(string ___name, object ___val)
        {
            this.___properties[___name] = ___val;
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
            if (___name == null)
                return false;

            return false;
        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("{0}.___hasPropertyByIndex({1}) called...", this, ___index);
            }
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
                return IMutilversalObjectType.Performance;
            }
        }
        #endregion
    }
}
