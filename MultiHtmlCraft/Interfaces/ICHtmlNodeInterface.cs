using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MultiHtmlCraft.Interfaces
{
    public interface ICHtmlNodeInterface
    {
        string baseURI { get;  }
        bool isConnected { get; }
        ICHtmlNodeInterface firstChild { get; }
        ICHtmlNodeInterface lastChild { get; }
        ICHtmlNodeInterface nextSibling { get; }
        ICHtmlNodeInterface previousSibling { get; }
        string nodeName { get; set; }
        double nodeType { get; }
        string nodeValue { get; set; }
        ICHtmlNodeInterface parentNode { get; }
        ICHtmlNodeInterface parentElement { get; }
        string textContent { get; set; }
        ICHtmlDocumentInterface ownerDocument { get; }
        public string prefix { get; }
        public string localName { get; }
        public string namespaceURI { get; }
        public object attributes { get; }
        public object childNodes { get; }
        public ICHtmlNodeInterface insertBefore(ICHtmlNodeInterface insertBeforeParam1, ICHtmlNodeInterface insertBeforeParam2);

        public ICHtmlNodeInterface appendChild(ICHtmlNodeInterface _appendNode);
        void removeChild(ICHtmlNodeInterface _removeChildParan);
        ICHtmlNodeInterface replaceChild(ICHtmlNodeInterface paramReplace1, ICHtmlNodeInterface paramReplace2);

        public ICHtmlNodeInterface cloneNode();
        bool contains(ICHtmlNodeInterface _containsNode);
        ICHtmlNodeInterface getRootNode();
        bool hasChildNodes();
        bool isDefaultNamespace(string _namesapeceparam);
        bool isEqualNode(ICHtmlNodeInterface otherNode);
        bool isSameNode(ICHtmlNodeInterface otherNodeSame);
        object lookupPrefiex(string namespaceToLookup);
        string lookupNamespaceURI(string prefixToLookup);
        void normalize();


    }
}
