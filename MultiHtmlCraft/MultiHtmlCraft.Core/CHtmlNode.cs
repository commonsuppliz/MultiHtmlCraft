using Microsoft.ClearScript;
using MultiHtmlCraft.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text;

namespace MultiHtmlCraft.Core
{
    public class CHtmlNode : ICHtmlNodeInterface, IDynamicMetaObjectProvider
    {
        public static readonly Dictionary<string, int> CHtmlNodeProperties = createCHtmNodePropertyNames();



          
        internal IMutilversalObjectType ___multiversalClassType = IMutilversalObjectType.Node;
        internal string ___multiversalClassTypeString = null;
        internal bool ___IsPrototype = false;
        public CHtmlCollection ___childNodes = null;
        internal System.Collections.Generic.Dictionary<string, object> ___properties;
        internal System.Collections.Generic.Dictionary<string, object> ___getterProperties;
        internal System.Collections.Generic.Dictionary<string, object> ___setterProperties;
        internal CHtmlNode? ___parentNode = null;
        internal System.WeakReference ___prototypeWeakReference = null;
        public CHtmlNode()
        {
            this.___childNodes = new CHtmlCollection();
            this.___childNodes.___CollectionType = CHtmlHTMLCollectionType.NodeChildNodes;
            this.___childNodes.___createObjectIDTable();
            this.___properties = new Dictionary<string, object>(StringComparer.Ordinal);
            this.___getterProperties = new Dictionary<string, object>(StringComparer.Ordinal);
            this.___setterProperties = new Dictionary<string, object>(StringComparer.Ordinal);
        }
private static Dictionary<string, int> createCHtmNodePropertyNames()
{
    Dictionary<string, int> properties = new Dictionary<string, int>();
    properties.Add("ELEMENT_NODE", 1);
    properties.Add("ATTRIBUTE_NODE", 2);
    properties.Add("TEXT_NODE", 3);
    properties.Add("CDATA_SECTION_NODE", 4);
    properties.Add("ENTITY_REFERENCE_NODE", 5);
    properties.Add("ENTITY_NODE", 6);
    properties.Add("PROCESSING_INSTRUCTION_NODE", 7);
    properties.Add("COMMENT_NODE", 8);
    properties.Add("DOCUMENT_NODE", 9);
    properties.Add("DOCUMENT_TYPE_NODE", 10);
    properties.Add("DOCUMENT_FRAGMENT_NODE", 11);
    properties.Add("NOTATION_NODE", 12);
            properties.Add("prototype", 13);
            properties.Add("baseURI", 14);
            properties.Add("childNodes", 15);
            properties.Add("firstChild", 16);
            properties.Add("isConnected", 17);
            properties.Add("lastChild", 18);
            properties.Add("nextSibling", 19);
            properties.Add("previousSibling", 20);
            properties.Add("nodeName", 21);
            properties.Add("nodeType", 22);
            properties.Add("nodeValue", 23);
            properties.Add("parentElement", 24);
            properties.Add("textContent", 25);
            properties.Add("ownerDocument", 26);

            properties.Add("attributes", 28);
            properties.Add("parentNode", 29);
            properties.Add("insertBefore", 30);
            properties.Add("appendChild", 31);
            properties.Add("removeChild", 32);
            properties.Add("replaceChild", 33);
            properties.Add("cloneNode", 34);
            properties.Add("contains", 35);
            properties.Add("getRootNode", 36);
            properties.Add("hasChildNodes", 37);
            properties.Add("isDefaultNamespace", 38);
            properties.Add("isEqualNode", 39);
            properties.Add("isSameNode", 40);
            properties.Add("lookupPrefix", 41);
            properties.Add("lookupNamespaceURI", 42);
            properties.Add("normalize", 43);
            properties.Add("multiversalClassType", 44);
            properties.Add("setParentNode", 45);
            properties.Add("getEnumerator", 46);

 
            properties.Add("prefix", 55);
            properties.Add("localName", 56);
            properties.Add("namespaceURI", 57);

            

            return properties;

}
public int ELEMENT_NODE
        {
            get
            {
                return 1;
            }
        }
        public int ATTRIBUTE_NODE
        {
            get
            {
                return 2;
            }
        }
        public int TEXT_NODE
        {
            get
            {
                return 3;
            }
        }
        public int CDATA_SECTION_NODE
        {
            get
            {
                return 4;
            }
        }
        public int ENTITY_REFERENCE_NODE
        {
            get
            {
                return 5;
            }
        }
        public int ENTITY_NODE
        {
            get
            {
                return 6;
            }
        }
        public int PROCESSING_INSTRUCTION_NODE
        {
            get
            {
                return 7;
            }
        }
        public int COMMENT_NODE
        {
            get
            {
                return 8;
            }
        }
        public int DOCUMENT_NODE
        {
            get
            {
                return 9;
            }
        }
        public int DOCUMENT_TYPE_NODe
        {
            get
            {
                return 10;
            }
        }
        public int DOCUMENT_FRAGMENT_NODE
        {
            get
            {
                return 11;
            }
        }
        public int NOTATION_NODE
        {
            get
            {
                return 12;
            }
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.___multiversalClassTypeString) == true)
            {
                this.___multiversalClassTypeString = "[object " + this.___multiversalClassType.ToString() + "]";

            }
            return this.___multiversalClassTypeString;
        }
        public CHtmlCollection childNodes
        {
            get { return this.___childNodes; }
        }
        public System.Collections.Generic.Dictionary<string, object> properties
        {
            get { return this.___properties; }
        }
        public CHtmlNode parentNode
        {
            get
            {
                return this.___parentNode;
            }
        }
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return this.___multiversalClassType;
            }
        }
        internal void setParentNode(CHtmlNode _pNode)
        {
            ___parentNode = _pNode;
        }

        ICHtmlNodeInterface ICHtmlNodeInterface.insertBefore(ICHtmlNodeInterface insertBeforeParam1, ICHtmlNodeInterface insertBeforeParam2)
        {
            throw new NotImplementedException();
        }

        ICHtmlNodeInterface ICHtmlNodeInterface.appendChild(ICHtmlNodeInterface _appendNode)
        {
            throw new NotImplementedException();
        }

        void ICHtmlNodeInterface.removeChild(ICHtmlNodeInterface _removeChildParan)
        {
            throw new NotImplementedException();
        }

        ICHtmlNodeInterface ICHtmlNodeInterface.replaceChild(ICHtmlNodeInterface paramReplace1, ICHtmlNodeInterface paramReplace2)
        {
            throw new NotImplementedException();
        }

        ICHtmlNodeInterface ICHtmlNodeInterface.cloneNode()
        {
            throw new NotImplementedException();
        }

        bool ICHtmlNodeInterface.contains(ICHtmlNodeInterface _containsNode)
        {
            throw new NotImplementedException();
        }

        ICHtmlNodeInterface ICHtmlNodeInterface.getRootNode()
        {
            throw new NotImplementedException();
        }

        bool ICHtmlNodeInterface.hasChildNodes()
        {
            throw new NotImplementedException();
        }

        bool ICHtmlNodeInterface.isDefaultNamespace(string _namesapeceparam)
        {
            throw new NotImplementedException();
        }

        bool ICHtmlNodeInterface.isEqualNode(ICHtmlNodeInterface otherNode)
        {
            throw new NotImplementedException();
        }

        bool ICHtmlNodeInterface.isSameNode(ICHtmlNodeInterface otherNodeSame)
        {
            throw new NotImplementedException();
        }

        object ICHtmlNodeInterface.lookupPrefiex(string namespaceToLookup)
        {
            throw new NotImplementedException();
        }

        string ICHtmlNodeInterface.lookupNamespaceURI(string prefixToLookup)
        {
            throw new NotImplementedException();
        }

        void ICHtmlNodeInterface.normalize()
        {
            throw new NotImplementedException();
        }
        private object _prototype = null;

        public object prototype
        {
            get
            {
                return _prototype;
            }
            set
            {
                _prototype = value;
            }
        }

        public string baseURI => throw new NotImplementedException();

        public object childNdoes => throw new NotImplementedException();

        public object firstChild => throw new NotImplementedException();

        public bool isConnected => throw new NotImplementedException();

        public object lastChild => throw new NotImplementedException();

        public object nextSibling => throw new NotImplementedException();

        public object previousSibling => throw new NotImplementedException();

        public string nodeName
        {
            get;
            set;
        }

        public object nodeType => throw new NotImplementedException();

        public object nodeValue => throw new NotImplementedException();

        public object parentElement => throw new NotImplementedException();

        public object textContent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object ownerDocument => throw new NotImplementedException();

        string ICHtmlNodeInterface.baseURI => throw new NotImplementedException();

        bool ICHtmlNodeInterface.isConnected => throw new NotImplementedException();

        ICHtmlNodeInterface ICHtmlNodeInterface.firstChild => throw new NotImplementedException();

        ICHtmlNodeInterface ICHtmlNodeInterface.lastChild => throw new NotImplementedException();

        ICHtmlNodeInterface ICHtmlNodeInterface.nextSibling => throw new NotImplementedException();

        ICHtmlNodeInterface ICHtmlNodeInterface.previousSibling => throw new NotImplementedException();

        string ICHtmlNodeInterface.nodeName { get => nodeName; set => throw new NotImplementedException(); }

        ICHtmlNodeInterface ICHtmlNodeInterface.parentNode => parentNode;

        ICHtmlNodeInterface ICHtmlNodeInterface.parentElement => throw new NotImplementedException();

        string ICHtmlNodeInterface.textContent { get => throw new NotImplementedException(); set => textContent = value; }

        ICHtmlDocumentInterface ICHtmlNodeInterface.ownerDocument => throw new NotImplementedException();

        double ICHtmlNodeInterface.nodeType => throw new NotImplementedException();

        string ICHtmlNodeInterface.nodeValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        string ICHtmlNodeInterface.prefix => throw new NotImplementedException();

        string ICHtmlNodeInterface.localName => throw new NotImplementedException();

        string ICHtmlNodeInterface.namespaceURI => throw new NotImplementedException();

        object ICHtmlNodeInterface.attributes => throw new NotImplementedException();

        object ICHtmlNodeInterface.childNodes => childNodes;
        #region IDyamicMetaObjectProvider support to get and set properties
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlNode>(parameter, this);
        }
        public object GetDynamicMember(string name)
        {
            object objValue = null;
            if (CHtmlNodeProperties.ContainsKey(name))
            {
                commonLog.LogEntry("TODO: {0}.GetDynamicMember({1} returns : {2}", this, name, objValue);
            }
            else
            {
                this.___properties.TryGetValue(name, out objValue);
            }
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.GetDynamicMember({1} returns : {2}", this, name, objValue);
            }
            return objValue;
        }
        /*
        [ScriptMember("insertBefore")]
        public object InsertBefore(object newChild, object refChild)
        {
            // 実際の DOM 操作をここに実装
            // newChild を refChild の前に挿入する処理
            
        return newChild; // 仕様どおり newChild を返す
        }
        */
        public void SetDynamicMember(string name, object value)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.SettDynamicMember({1} is called value: {2}", this, name, value);
            }
            this.___properties[name] = value;
        }
        public IEnumerable<string> GetDynamicMemberNames()
        {
            List<string> ___propertiesNames = new List<string>();
            ___propertiesNames.AddRange(this.___properties.Keys);
            ___propertiesNames.AddRange(CHtmlNode.CHtmlNodeProperties.Keys);
            return ___propertiesNames;
        }

        internal object GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
