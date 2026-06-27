using MultiHtmlCraft.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Linq.Expressions;
namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// Input Element ___hasInner select() method. this is special 
    /// </summary>
    public class CHtmlInputElement : CHtmlElement, System.IDisposable
    {
        public new void Dispose()
        {
            this.___cleanUp();
            base.Dispose();
            GC.SuppressFinalize(this);
        }
        private void ___cleanUp()
        {

        }
        public void select(string ___val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("entering {0}.select({1})", this, ___val);
            }
        }
        public void select(object ___objtext)
        {
            this.select(commonHTML.GetStringValue(___objtext));
        }
        #region IPropertBox メンバ

        public override void ___setPropertyByName(string ___name, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("entering {0}.setPropertyValue : {1} = {2}", this, ___name, val);
            }

            switch (___name)
            {

                default:
                    break;
            }
            base.___setPropertyByName(___name, val);
        }

        public override bool ___hasPropertyByName(string ___name)
        {
            return false;

        }
        public override bool ___hasPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("calling HasPropertyValueIndex for {0} {1}  {2} ", this.GetType(), this, ___index);
            }
            return true;
        }

        public override void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public override object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public override object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getInner : {0} for {1}", ___name, this.toLogString());
            }
            switch (___name)
            {

                default:
                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // Lookup for Prototype
                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    if (this.___IsPrototype == false && this.___prototypeWeakReference != null)
                    {
                        CHtmlElement ___protoElement = null;
                        ___protoElement = this.___prototypeWeakReference.Target as CHtmlElement;
                        int __ProtoLookupCont = 0;
                        while (___protoElement != null)
                        {
                            __ProtoLookupCont++;
                            if (__ProtoLookupCont > 10)
                            {
                                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                                {
                                   commonLog.LogEntry("GetPropertyValue for {0} {1} Prototype lookup loop", this.GetType(), this);
                                }
                                break;
                            }

                            object protoValue = null;
                            if (___protoElement.___properties.Count > 0 && ___protoElement.___properties.TryGetValue(___name, out protoValue))
                            {
                                return protoValue;
                            }
                            else
                            {
                                if (___protoElement.___elementTagType == CHtmlElementType._ELEMENT_PROTOTYPE)
                                {
                                    break;
                                }
                                if (___protoElement.parentNode != null)
                                {
                                    ___protoElement = ___protoElement.parentNode as CHtmlElement;
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                    }

                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    break;
            }
            object _obase = base.___getPropertyByName(___name);
            if (_obase != null)
            {
                return _obase;
            }

            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
            }
            return null;
        }
        public new IMutilversalObjectType multiversalClassType
        {
            get
            {

                return IMutilversalObjectType.HTMLInputElement;
            }
        }
        #endregion

        #region MetaObject
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlElement>(parameter, this);
        }
        public object GetDynamicMember(string name)
        {
            object objValue = null;
            this.___properties.TryGetValue(name, out objValue);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.GetDynamicMember({1} returns : {2}", this, name, objValue);
            }
            return objValue;
        }
        public void SetDynamicMember(string name, object value)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.SettDynamicMember({1} is called value: {2}", this, name, value);
            }
            switch (name)
            {
                case "innerHTML":
                case "checked":
                case "disabled":
                case "value":
                case "id":
                case "tagName":
                case "class":
                case "classname":
                case "className":
                case "autoPlay":
                case "classId":
                case "classid":
                case "name":
                case "nodeValue":
                case "src":
                case "type":
                case "auto":
                case "style":
                case "styleSheet":
                case "href":
                case "charset":
                case "characterSet":
                case "dir":
                case "location":
                case "async":
                case "defer":
                case "contentEditable":
                case "contenteditable":
                case "alt":
                case "lang":
                case "language":
                case "title":
                case "innerText":
                case "selected":
                case "htmlFor":
                case "htmlfor":
                case "mimetype":
                case "mimeType":
                case "width":
                case "height":
                case "crossOrigin":
                case "crossorigin":
                case "textContent":
                    this.___setPropertyByName(name, value);
                    return;

            }

            this.___properties[name] = value;
        }
        public IEnumerable<string> GetDynamicMemberNames()
        {
            List<string> members = new List<string>();
            members.AddRange(CHtmlElementProperties.Keys);
            members.AddRange(CHtmlElementMethods.Keys);
            if (this.___properties.Count > 0)
            {
                members.AddRange(this.___properties.Keys);
            }
            return members;
        }
        public DynamicMetaObject BindInvokeMember(
 InvokeMemberBinder binder, DynamicMetaObject[] args)
        {
            StringBuilder paramInfo = new StringBuilder();
            paramInfo.AppendFormat("Calling {0}(", binder.Name);
            foreach (var item in args)
                paramInfo.AppendFormat("{0}, ", item.Value);
            paramInfo.Append(")");
            Expression[] parameters = new Expression[]
            {
 Expression.Constant(paramInfo.ToString())
            };
            DynamicMetaObject methodInfo = null;
            /*
            DynamicMetaObject methodInfo = new DynamicMetaObject(
            Expression.Call(
            Expression.Convert(Expression, LimitType),
            typeof(DynamicDictionary).GetMethod("WriteMethodInfo"),
            parameters),
            BindingRestrictions.GetTypeRestriction(Expression, LimitType));
            */
            return methodInfo;
        }
        #endregion
    }
}
