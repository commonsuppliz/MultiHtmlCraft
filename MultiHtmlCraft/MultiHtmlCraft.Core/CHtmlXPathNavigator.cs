using System;
using System.Collections.Generic;
using MultiHtmlCraft.Interfaces;
using System.Xml;
using System.Xml.XPath;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// XPathNavigator : provide a functionality to search elements in specified document
    /// This class extends System.Xml.XPath.XPathNavigator and ICommonObjectInterface
    /// (Caution) This is NOT window.navigator object
    /// </summary>
    public sealed class CHtmlXPathNavigator : System.Xml.XPath.XPathNavigator, ICommonObjectInterface
    {
        internal static readonly int loggingReportLevel = 5;
        internal System.Xml.NameTable ___nameTable = null;
        internal NavigatorState ___state;
        public enum NodeTypes : byte
        {
            Root = 1, Element = 2, Attribute = 3, Text = 4
        };

        #region XPathNavigator Inherits
        public override XPathNodeType NodeType
        {
            get
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= loggingReportLevel)
                {
                   commonLog.LogEntry("calling {0}.NodeType", this);
                }
                switch (___state.Node)
                {
                    case NodeTypes.Root:
                        return XPathNodeType.Root;
                    case NodeTypes.Element:
                        return XPathNodeType.Element;
                    case NodeTypes.Attribute:
                        return XPathNodeType.Attribute;
                    case NodeTypes.Text:
                        return XPathNodeType.Text;
                }
                return XPathNodeType.All;
            }
        }
        public CHtmlXPathNavigator(CHtmlDocument ___doc)
        {
            this.___nameTable = new NameTable();
            this.___state = new NavigatorState(___doc);
        }
        public CHtmlXPathNavigator(CHtmlXPathNavigator cur)
        {
            this.___nameTable = new NameTable();
            this.___state = new NavigatorState(cur.___state.___rootDocument);
        }
        public override XPathNavigator Clone()
        {
            CHtmlXPathNavigator navi = new CHtmlXPathNavigator(this.___state.___rootDocument);
            navi.___state.___currentNode = this.___state.___currentNode;
            navi.___state.___rootElement = this.___state.___rootElement;
            navi.___state.___rootDocument = this.___state.___rootDocument;
            navi.___state.Node = this.___state.Node;
            navi.___state.ElementType = this.___state.elementType;
            navi.___state.ElementIndex = this.___state.ElementIndex;
            return navi;
        }
        public override string LocalName
        {

            get
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                {
                   commonLog.LogEntry("calling {0}.LocalName", this);
                    // we should returns<bk:book> = "book"
                }
                string ___localName = null;
                switch (___state.Node)
                {
                    case NodeTypes.Text:
                        ___localName = ___state.TextValue;
                        break;
                    case NodeTypes.Attribute:
                        ___localName = ___state.AttributeText;
                        break;
                    case NodeTypes.Element:
                    case NodeTypes.Root:
                        if (this.___state.___currentNode != null)
                        {
                            CHtmlElement __currentNode = this.___state.___currentNode as CHtmlElement;
                            if (__currentNode != null && string.IsNullOrEmpty(__currentNode.___elementTagNameCaseSensitive) == false)
                            {
                                ___localName = string.Copy(__currentNode.___elementTagNameCaseSensitive);
                            }
                            else
                            {
                                ___localName = string.Copy(__currentNode.___tagNameNoNS);
                            }
                        }
                        break;
                    default:
                        ___localName = "";
                        break;

                }
                ___nameTable.Add(___localName);
                return ___localName;
            }
        }

        public override string Name
        {
            get
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                {
                   commonLog.LogEntry("calling {0}.Name", this);
                    // we should retuns <bk:book> = bk:book
                }
                switch (___state.Node)
                {
                    case NodeTypes.Text:
                        return ___state.TextValue;
                    case NodeTypes.Attribute:
                        return ___state.AttributeText;
                    case NodeTypes.Element:
                        return ___state.ElementText;
                    default:
                        return "";

                }
            }
        }
        public override string NamespaceURI
        {
            get
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                {
                   commonLog.LogEntry("calling {0}.NamespaceURI", this);
                }
                return ___nameTable.Get("");
            }
        }

        public override string Prefix
        {
            get { return ___nameTable.Get(""); }
        }
        public override string Value
        {
            get
            {
                return ___state.TextValue;
            }
        }
        public override object UnderlyingObject
        {
            get
            {
                return ___state.___currentNode;
            }

        }
        public override String BaseURI
        {
            get { return ""; }
        }
        public override bool IsEmptyElement
        {
            get
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                {
                   commonLog.LogEntry("calling {0}.IsEmptyElement", this);
                }
                if (___state.ElementType == 1)
                    return true;
                else
                    return false;
            }
        }

        public override string XmlLang
        {
            get { return "en-us"; }
        }

        public override XmlNameTable NameTable
        {
            get
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                {
                   commonLog.LogEntry("calling {0}.NameTable", this);
                }
                return ___nameTable;
            }
        }

        //Attribute Accessors

        public override bool HasAttributes
        {
            get
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                {
                   commonLog.LogEntry("calling {0}.HasAttributes", this);
                }
                if ((___state.Node != NodeTypes.Root) && (___state.Node != NodeTypes.Attribute) && (___state.Node != NodeTypes.Text))
                    return true;
                else
                    return false;
            }
        }
        public override string GetAttribute(string localName, string namespaceURI)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.GetAttribute({1}, {2})", this, localName, namespaceURI);
            }
            if (HasAttributes)
            {

            }
            return "";
        }

        public override bool MoveToAttribute(string localName, string namespaceURI)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToAttribute({1}, {2})", this, localName, namespaceURI);
            }
            if (___state.Node == NodeTypes.Attribute)
                MoveToElement();
            if (___state.Node == NodeTypes.Element)
            {
            }
            return false;
        }

        public override bool MoveToFirstAttribute()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToFirstAttribute()", this);
            }
            if (___state.Node == NodeTypes.Attribute)
                MoveToElement();
            if (AttributeCount > 0)
            {
                ___state.Attribute = 0;
                ___state.Node = NodeTypes.Attribute;
                return true;
            }
            return false;
        }
        public override bool MoveToNextAttribute()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToNextAttribute()", this);
            }

            int TempAttribute = -1;
            if (___state.Node == NodeTypes.Attribute)
            {
                TempAttribute = ___state.Attribute;
                MoveToElement();
            }
            if ((TempAttribute + 1) < AttributeCount)
            {
                ___state.Attribute = TempAttribute + 1;
                ___state.Node = NodeTypes.Attribute;
                return true;
            }
            ___state.Node = NodeTypes.Attribute;
            ___state.Attribute = TempAttribute;
            return false;
        }

        //Namespace Accesors
        public override string GetNamespace(string localname)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.GetNamespace()", this);
            }
            return "";
        }
        public override bool MoveToNamespace(string Namespace)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToNamespace()", this);
            }
            return false;
        }

        public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToFirstNamespace()", this);
            }
            return false;
        }

        public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToNextNamespace()", this);
            }
            return false;
        }

        //Tree Navigation

        public override bool MoveToNext()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToNext()", this);
            }
            int NextElement = IndexInParent + 1;
            CHtmlXPathNavigator TempState = (CHtmlXPathNavigator)this.Clone();
            if (MoveToParent())
            {
                if (MoveToChild(NextElement))
                    return true;
            }
            this.___state = new NavigatorState(TempState.___state);
            return false;
        }

        public override bool MoveToPrevious()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToPrevious()", this);
            }
            int NextElement = IndexInParent - 1;
            CHtmlXPathNavigator TempState = (CHtmlXPathNavigator)this.Clone();
            if (MoveToParent())
            {
                if (MoveToChild(NextElement))
                    return true;
            }
            this.___state = new NavigatorState(TempState.___state);
            return false;
        }

        public override bool MoveToFirst()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToFirst()", this);
            }
            CHtmlXPathNavigator TempState = (CHtmlXPathNavigator)this.Clone();
            if (MoveToParent())
            {
                if (MoveToChild(0))
                    return true;
            }
            this.___state = new NavigatorState(TempState.___state);
            return false;

        }
        public override bool MoveToFirstChild()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToFirstChild()", this);
            }
            CHtmlXPathNavigator TempState = (CHtmlXPathNavigator)this.Clone();
            if (MoveToChild(0))
                return true;
            this.___state = new NavigatorState(TempState.___state);
            return false;
        }

        public override bool MoveToParent()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToParent()", this);
            }
            switch (___state.Node)
            {
                case NodeTypes.Root:
                    return false;
                case NodeTypes.Text:
                case NodeTypes.Element:
                    if (this.___state != null && this.___state.___currentNode != null)
                    {
                        if (this.___state.___currentNode is CHtmlElement)
                        {
                            CHtmlElement __curElement = this.___state.___currentNode as CHtmlElement;
                            if (__curElement != null)
                            {
                                if (__curElement.___parent != null && __curElement.___parent is CHtmlElement)
                                {
                                    if (object.ReferenceEquals(___state.___rootElement, __curElement.___parent) == true)
                                    {
                                        this.___state.Node = NodeTypes.Root;
                                        this.___state.ElementIndex = 0;
                                        MoveToRoot();
                                        return true;
                                    }
                                    else
                                    {
                                        this.___state.Node = NodeTypes.Element;
                                    }
                                    CHtmlElement ___curElementParent = __curElement.___parentWeakRef.Target as CHtmlElement;
                                    this.___state.___currentNode = ___curElementParent;
                                    this.___state.ElementIndex = ___curElementParent.___ChildNodeIndex;
                                    return true;
                                }
                                return false;
                            }
                        }
                    }
                    return false;
                default:

                    
                    return false;

            }


        }


        public override void MoveToRoot()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToRoot()", this);
            }
            ___state.Node = NodeTypes.Root;
            ___state.___currentNode = ___state.___rootElement;
            ___state.Attribute = -1;
            ___state.ElementType = -1;
            ___state.ElementIndex = -1;
        }
        public override bool MoveTo(XPathNavigator other)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveTo()", this);
            }
            if (other is CHtmlXPathNavigator)
            {
                this.___state = new NavigatorState(((CHtmlXPathNavigator)other).___state);
                return true;
            }
            return false;
        }
        public override bool MoveToId(string ___ID)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToId({1})", this, ___ID);
            }
            return false;
        }


        public override bool IsSamePosition(XPathNavigator other)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.IsSamePosition()", this);
            }
            if (other is CHtmlXPathNavigator)
            {
                if (___state.Node == NodeTypes.Root)
                {
                    return (((CHtmlXPathNavigator)other).___state.Node == NodeTypes.Root);
                }
                else
                {
                    /*
                    return (___state.Doc.FullName == ((CHtmlXPathNavigator)other).___state.Doc.FullName);
                     */
                }
            }
            return false;


        }

        public override bool HasChildren
        {
            get
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                {
                   commonLog.LogEntry("calling {0}.HasChildren", this);
                }
                return (ChildCount > 0);
            }
        }



        /***************Helper Methods*****************************************/

        //This is a helper method. Move the XPathNavigator from an attribute 
        // to its associated element.
        public bool MoveToElement()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToElement()", this);
            }
            ___state.Attribute = -1;
            ___state.Node = NodeTypes.Element;
            if (object.ReferenceEquals(___state.___currentNode, ___state.___rootElement))
                ___state.ElementType = 0;
            else
                ___state.ElementType = 1;
            return true;
        }
        //Gets the index of this node if it is an element or the index of
        // the element node associated with the attribute.
        public int IndexInParent
        {
            get
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                {
                   commonLog.LogEntry("calling {0}.IndexInParent", this);
                }
                return ___state.ElementIndex;
            }
        }



        //Helper method. Move to child i of the current node.
        public bool MoveToChild(int i)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("calling {0}.MoveToChild({1})", this,i);
            }
            if (this.___state != null && this.___state.___currentNode != null)
            {
                if (this.___state.___currentNode is CHtmlElement)
                {
                    CHtmlElement __curElement = this.___state.___currentNode as CHtmlElement;
                    if (__curElement != null)
                    {
                        if (i >= 0 && __curElement.___childNodes.Count > 0 && i < __curElement.___childNodes.Count)
                        {
  
                            this.___state.___currentNode = __curElement.___childNodes[i] as CHtmlElement;
                            if (commonHTML.IsElemeneITextOrIDraw(this.___state.___currentNode as CHtmlElement) == false)
                            {
                                this.___state.Node = NodeTypes.Element;
                            }
                            else
                            {
                                this.___state.Node = NodeTypes.Text;
                            }
                            this.___state.ElementIndex = i;
                            return true;
                        }
                        return false;
                    }
                }
            }
            return false;
        }

        //returns the number of attributes that the current node ___hasInner
        public int AttributeCount
        {
            get
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                {
                   commonLog.LogEntry("calling {0}.AttributeCount", this);
                }
                if (this.___state.___currentNode != null && this.___state.___currentNode is CHtmlElement)
                {
                    CHtmlElement ___currentElement = this.___state.___currentNode as CHtmlElement;
                    if (___currentElement != null)
                    {
                        if (___currentElement.___elementTagType != CHtmlElementType._ITEXT)
                        {
                            return ___currentElement.___attributes.Count;
                        }
                    }
                }
                return 0;
            }
        }
        //Helper method. Returns the number of children that the current node ___hasInner.
        public int ChildCount
        {
            get
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                {
                   commonLog.LogEntry("calling {0}.ChildCount", this);
                }
                switch (___state.Node)
                {
                    case NodeTypes.Root:
                        return 1;
                    case NodeTypes.Element:
                        /*
                        if (___state.ElementType == 0)
                        {
                            return (((DirectoryInfo)___state.Doc).GetFileSystemInfos()).Length;
                        }
                         */
                        return 0;
                    default:
                        return 0;
                }
            }
        }
        #region Object Interfaces

        public void ___setPropertyByName(string ___name, object ___val)
        {
            // this.___properties[___name] = ___val;
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

            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
            }
            return null;

        }
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.Unkown;
            }
        }




        public bool ___hasPropertyByIndex(int ___index)
        {
            return false;
        }
        public object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }
        public string ___getClassName()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
            }
            return this.GetType().Name;
        }
        public object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public object ___getParentScope()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public object ___getProtoType()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
            {
               commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }

        public bool ___hasPropertyByName(string name)
        {
            throw new NotImplementedException();
        }
        #endregion

        //This class keeps track of the ___state the navigator is in.
        internal class NavigatorState
        {
            //Represents the element that the navigator is currently at.
            public CHtmlBase ___currentNode;
            public CHtmlBase ___rootElement;
            //The directory or file at the top of the tree
            public CHtmlDocument ___rootDocument;
            //The type of attribute that the current node is. -1 if the
            // navigator is not currently positioned on an attribute.
            public int attribute;
            //elementType of 0 is a directory and elementType of 1 is a file
            public int elementType;
            public int elementIndex;
            //The type of the current node
            public NodeTypes node;

            public NavigatorState(CHtmlDocument document)
            {
                this.___currentNode = document.___documentElement;
                this.___rootElement = document.___documentElement;
                this.___rootDocument = document;
                ///Root = doc.FullName;
                Node = NodeTypes.Root;
                Attribute = -1;
                ElementType = -1;
                ElementIndex = -1;

            }

            public NavigatorState(NavigatorState NavState)
            {
                this.___currentNode = NavState.___currentNode;
                this.___rootElement = NavState.___rootElement;
                this.___rootDocument = NavState.___rootDocument;
                Node = NavState.Node;
                Attribute = NavState.Attribute;
                ElementType = NavState.ElementType;
                ElementIndex = NavState.ElementIndex;

            }

            public CHtmlBase currentNode
            {
                get
                {
                    return this.___currentNode;
                }
                set
                {
                    this.___currentNode = value;
                }
            }

            public CHtmlDocument rootDocument
            {
                get
                {
                    return this.___rootDocument;
                }
                set
                {
                    this.___rootDocument = value;
                }
            }

            public int Attribute
            {
                get
                {
                    return attribute;
                }
                set
                {
                    attribute = value;
                }
            }


            public int ElementType
            {
                get
                {
                    return elementType;
                }
                set
                {
                    elementType = value;
                }
            }

            public int ElementIndex
            {
                get
                {
                    return elementIndex;
                }
                set
                {
                    elementIndex = value;
                }
            }


            public NodeTypes Node
            {
                get
                {
                    return node;
                }
                set
                {
                    node = value;
                }
            }
            //Returns the TextValue of the current node
            public String TextValue
            {
                get
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                    {
                       commonLog.LogEntry("calling {0}.TextValue", this);
                    }
                    switch (Node)
                    {
                        case NodeTypes.Root:
                            return null;
                        case NodeTypes.Element:
                            return null;
                        case NodeTypes.Attribute:
                            if (this.___currentNode != null && this.___currentNode.___elementTagType != CHtmlElementType._ITEXT)
                            {
                              CHtmlElement ___currentElement = this.___currentNode as CHtmlElement;
                                if(___currentElement != null)
                                {
                                    if (Attribute < ___currentElement.___attributes.Count && Attribute >= 0)
                                    {
                                        CHtmlAttribute ___attr = ___currentElement.___attributes.GetByIndex(Attribute) as CHtmlAttribute;
                                        if (___attr != null)
                                        {
                                            if (___attr.___value is string)
                                            {
                                                return ___attr.___value as string;
                                            }
                                            else
                                            {
                                                return commonHTML.GetStringValue(___attr.___value);
                                            }
                                        }
                                    }
                                }
                            }
                            return null;
                        case NodeTypes.Text:
                            if(this.___currentNode != null && commonHTML.IsElemeneITextOrIDraw(this.___currentNode as CHtmlElement) == true)
                            {
                                if (___currentNode.___value is string)
                                {
                                    return this.___currentNode.___value as string;
                                }
                            }
                            return "";
                    }
                    return null;
                }
            }
            //returns the value of the attribute
            public String AttributeText
            {
                get
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                    {
                       commonLog.LogEntry("calling {0}.AttributeText", this);
                    }
                    if (Node == NodeTypes.Attribute)
                    {
                        if (this.___currentNode != null && this.___currentNode is CHtmlElement)
                        {
                            CHtmlElement __currentElement = this.___currentNode as CHtmlElement;
                            if (__currentElement != null)
                            {
                                if (__currentElement.___attributes.Count > 0 && Attribute < __currentElement.___attributes.Count)
                                {
                                    return __currentElement.___attributes.GetKey(Attribute);
                                }
                                else
                                {
                                    return "";
                                }

                            }
                        }
                    }
                    return null;
                }
            }
            //Returns the name of the element.
            public String ElementText
            {
                get
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= loggingReportLevel)
                    {
                       commonLog.LogEntry("calling {0}.ElementText", this);
                    }
                    CHtmlElement __currentElement =  this.___currentNode as CHtmlElement;
                    if (__currentElement != null)
                    {
                        if (string.IsNullOrEmpty(__currentElement.___elementTagNameWithNSCaseSensitive) == false)
                        {
                            return __currentElement.___elementTagNameWithNSCaseSensitive;
                        }
                        else
                        {
                            return __currentElement.___tagName;
                        }
                    }
                    return "";
                }
               
            }


        #endregion



        }
    }
}
