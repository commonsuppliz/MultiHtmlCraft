using System;
using System.Collections.Generic;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// XPathResult Class
    /// </summary>
    public sealed class CHtmlXPathResult :  CHtmlNode,ICommonObjectInterface
    {
 
        internal double ___snapshotLength = 0;
        internal object ___evaluateResultObject = null;
        #region XPathResult Constants
        public int ANY_TYPE
        {
            get { return 0; }
        }
        public int NUMBER_TYPE
        {
            get { return 1; }
        }
        public int STRING_TYPE
        {
            get { return 2; }
        }
        public int BOOLEAN_TYPE
        {
            get { return 3; }
        }
        public int UNORDERED_NODE_ITERATOR_TYPE
        {
            get { return 4; }
        }
        public int ORDERED_NODE_ITERATOR_TYPE
        {
            get { return 5; }
        }
        public int UNORDERED_NODE_SNAPSHOT_TYPE
        {
            get { return 6; }
        }
        public int ORDERED_NODE_SNAPSHOT_TYPE
        {
            get { return 7; }
        }
        public int ANY_UNORDERED_NODE_TYPE
        {
            get { return 8; }
        }
        public int FIRST_ORDERED_NODE_TYPE
        {
            get { return 9; }
        }
        #endregion
        #region Object Propertyes
        public bool booleanValue
        {
            get { return true; }
        }
        public bool invalidIteratorState
        {
            get { return true; }
        }
        public double numberValue
        {
            get { return 0; }
        }
        public double resultType
        {
            get { return 0; }
        }
        public CHtmlElement singleNodeValue
        {
            get { return null; }
        }

        public string stringValue
        {
            get { return ""; }
        }
        #endregion
        #region Methods
        public object iterateNext()
        {
            object ___objectToReturn = null;
            try
            {
                if (this.___evaluateResultObject is System.Xml.XPath.XPathNodeIterator)
                {
                    System.Xml.XPath.XPathNodeIterator __iterator = this.___evaluateResultObject as System.Xml.XPath.XPathNodeIterator;
                    if (__iterator != null)
                    {

                        if (__iterator.MoveNext())
                        {
                            if (__iterator.Current.UnderlyingObject != null)
                            {
                                ___objectToReturn = __iterator.Current.UnderlyingObject;
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("CHtmlXPathResult.iterateNext() Exception. ", ex);
                }
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.iterateNext() returns {1} ", this, ___objectToReturn);
            }
            return ___objectToReturn;
        }
        public object snapshotItem(object ___objectIndex)
        {
            object ___objectToReturn = null;
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("entering {0}.snapshotItem({1}) ", this, ___objectIndex);
            }
            try
            {
                int __indexValue = commonHTML.GetIntFromObject(___objectIndex, -1);
                if (__indexValue >= 0 && __indexValue < this.___snapshotLength)
                {
                    if (this.___evaluateResultObject is System.Xml.XPath.XPathNodeIterator)
                    {
                        System.Xml.XPath.XPathNodeIterator __iterator = this.___evaluateResultObject as System.Xml.XPath.XPathNodeIterator;
                        if (__iterator != null)
                        {
                            while (__iterator.CurrentPosition != __indexValue)
                            {
                                __iterator.MoveNext();
                            }

                            if (__iterator.CurrentPosition == __indexValue)
                            {
                                if (__iterator.Current.UnderlyingObject != null)
                                {
                                    ___objectToReturn = __iterator.Current.UnderlyingObject;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                {
                   commonLog.LogEntry("CHtmlXPathResult.snapshotItem() Exception. ", ex);
                }
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.snapshotItem({1}) returns {2} ", this, ___objectIndex, ___objectToReturn );
            }
            return ___objectToReturn;
        }
        #endregion
        #region Object Interfaces

        public void ___setPropertyByName(string ___name, object ___val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: SetPropertyValueByName for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, ___val);
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
        public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling GetPropertyValue for {0} {1} {2}", this.GetType(), this, ___name);
            }
            switch (___name)
            {
                case "ANY_TYPE":
                    return this.ANY_TYPE;
                case "NUMBER_TYPE":
                    return this.NUMBER_TYPE;
                case "STRING_TYPE":
                    return this.STRING_TYPE;
                case "BOOLEAN_TYPE":
                    return this.BOOLEAN_TYPE;
                case  "UNORDERED_NODE_ITERATOR_TYPE":
                    return this.UNORDERED_NODE_ITERATOR_TYPE;
                case "ORDERED_NODE_ITERATOR_TYPE":
                    return this.ORDERED_NODE_ITERATOR_TYPE;
                case "UNORDERED_NODE_SNAPSHOT_TYPE":
                    return this.UNORDERED_NODE_SNAPSHOT_TYPE;
                case "ORDERED_NODE_SNAPSHOT_TYPE":
                    return this.ORDERED_NODE_SNAPSHOT_TYPE;
                case "ANY_UNORDERED_NODE_TYPE":
                    return this.ANY_UNORDERED_NODE_TYPE;
                case "FIRST_ORDERED_NODE_TYPE":
                    return this.FIRST_ORDERED_NODE_TYPE;
                case "snapshotLength":
                    return this.___snapshotLength;
                case "resultType":
                    return this.resultType;
                case "singleNodeValue":
                    return this.singleNodeValue;
                case "booleanValue":
                    return this.booleanValue;
                case "stringValue":
                    return this.stringValue;
                case "numberValue":
                    return this.numberValue;
                case "invalidIteratorState":
                    return this.invalidIteratorState;

            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
            }
            return null;

        }
        /// <summary>
        /// The XPathResult object represents the result of the evaluate method.
        /// The type of the result depends on the fourth parameter of the evaluate method,
        /// or, if its value is ANY_TYPE, on the expression specified by the first parameter.
        /// With the resultType property, the type of the result can be retrieved. If the value
        /// of the resultType property is UNORDERED_NODE_SNAPSHOT_TYPE or
        /// ORDERED_NODE_SNAPSHOT_TYPE, then the result contains snapshots for all
        /// nodes that match the expression.
        /// In that case, the snapshotLength property can be used to retrieve the number of matching
        /// nodes in the snapshots collection. Use the snapshotItem method to ___getInner the matching nodes
        /// from the snapshots collection by position.
        /// </summary>
        public double snapshotLength
        {
            get { return this.___snapshotLength; }
        }

        public bool ___hasPropertyByName(string ___name)
        {

            return false;
        }

        public bool ___hasPropertyByIndex(int ___index)
        {
            return false;
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
        #endregion

    }
}
