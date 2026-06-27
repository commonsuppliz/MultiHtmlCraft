using System;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// Provides methods which are not dependent on any particular DOM instances. 
    /// Document Object Model (DOM) Level 3 Core Specification, Section 1.4
	/// </summary>
    public sealed class CHtmlDOMImplementation : ICommonObjectInterface
	{

        internal System.WeakReference ___ownerDocumentWeakReference;

		public CHtmlDOMImplementation()
		{
            this.___ownerDocumentWeakReference = null;
			
		}

        /*
          createDocument (namespaceURI, qualifiedNameStr, DocumentType)	Document
          createDocumentType (qualifiedNameStr, publicId, systemId )	 	DocumentType
          createHTMLDocument ( title ) Requires Gecko 2.0	 	Document
          getFeature ( feature, version )	 	DOMObject
          hasFeature (feature, version)	 	Boolean
        */
#region DOMMethods
        public CHtmlDocument createDocument(object ___namespaceURI, object ___qualifiedName,object ___documentType)
		{
            return this.___createDocumentInner(___namespaceURI, ___qualifiedName, ___documentType);
		}
        public CHtmlDocument createDocument(object ___namespaceURI, object ___qualifiedName)
        {
            return this.___createDocumentInner(___namespaceURI, ___qualifiedName,null);
        }
        public CHtmlDocument createDocument(object ___namespaceURI)
        {
            return this.___createDocumentInner(___namespaceURI, null, null);
        }
        public CHtmlDocument createDocument()
        {
            return this.___createDocumentInner(null, null, null);
        }
        private CHtmlDocument ___createDocumentInner(object ___namespaceURI, object ___qualifiedName, object ___documentType)
        {
            string strNameSpace = commonHTML.GetStringValue(___namespaceURI);
            string strQualifiedName = commonHTML.FasterToLower(commonHTML.GetStringValue(___qualifiedName));
            string strDocumentType = commonHTML.FasterToLower(commonHTML.GetStringValue(___documentType));
            CHtmlDocument ___segmentHTMLDocument = null;
            CHtmlDomModeType targetDOMType = CHtmlDomModeType.XMLDOM;
            if (strNameSpace.Length == 0 && strQualifiedName.Length == 0)
            {
                targetDOMType = CHtmlDomModeType.XMLDOM;
                goto CreateDOM;
            }
            else
            {
                if (strQualifiedName.Length > 0)
                {
                    if (string.Equals(strQualifiedName, "html", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        targetDOMType = CHtmlDomModeType.HTML;
                        goto CreateDOM;
                    }
                }
            }
            CreateDOM:
            ___segmentHTMLDocument =  new CHtmlDocument(targetDOMType);
            if (this.___ownerDocumentWeakReference != null)
            {
                ___segmentHTMLDocument.___originDocumentWeakReference = new WeakReference(this.___ownerDocumentWeakReference.Target);
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.createDocument(\'{1}\', \'{2}\', \'{3}\') returns {4} : {5}", this, strNameSpace, strQualifiedName, strDocumentType, targetDOMType, ___segmentHTMLDocument);
            }
            return ___segmentHTMLDocument;
        }
		public CHtmlDocument createHTMLDocument(object ___title)
		{
            CHtmlDocument ___segmentHTMLDocument = new CHtmlDocument(CHtmlDomModeType.HTML);
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("{0}.createHTMLDocument(\'{1}\') returns HTMLDocument(HTML Segment).", this, ___title);
            }
            ___segmentHTMLDocument.___title = commonHTML.GetStringValue(___title);
            if (this.___ownerDocumentWeakReference != null)
            {
                ___segmentHTMLDocument.___originDocumentWeakReference = new WeakReference(this.___ownerDocumentWeakReference.Target);
            }
            return ___segmentHTMLDocument;
		}
		public object createDocumentType(object qn, object publicid, object sysid)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: {0}.createDocumentType {1}  returns null",this, qn);
            }
			return null;
		}
		public bool hasFeature(object ___p1, object ___p2)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("DOMImplementation.hasFeature({0}, {1}) returns true", ___p1 , ___p2);
            }

            return true;
		}
        public object getFeature(object ___p1, object ___p2)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("TODO: getFeature {0} {1} returns null", ___p1, ___p2);
            }
			return null;
		}
        /// <summary>
        /// DOMImplementation hasOwnProperty always returns false. becase no property.
        /// </summary>
        /// <param name="___name"></param>
        /// <returns></returns>
        public bool hasOwnProperty(object ___name)
        {

            return false;
        }
#endregion



#region IPropertBox ÉÅÉìÉo
        public void ___setPropertyByName(string name, object val)
		{
			// TODO:  CHtmlWindowScreen.___setPropertyByIndex é¿ëïÇí«â¡ÇµÇ‹Ç∑ÅB
		}
        /// <summary>
        /// HasProperty normally returns false
        /// </summary>
        /// <param name="name"></param>
        /// <returns>false</returns>
		public bool ___hasPropertyByName(string ___name)
		{

			
			return false;
		}
		public bool ___hasPropertyByIndex(int ___index)
		{
            return false;
		}

		public void ___setPropertyByIndex(int ___index, object val)		
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed",this.GetType(), this, ___index, val);
			}
		}
		public object ___getPropertyByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("___setPropertyByIndex by index {0} {1} {2} failed",this.GetType(), this, ___index);
			}
			return null;
		}

        public object ___getPropertyByName(string ___name)
		{
	
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed",this.GetType(), this, ___name);
			}
			return null;
		}
		public object ___common_object_clone()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("x__Clone {0} {1} called",this.GetType(), this);
			}
			return this;
		}
		public void ___deleteByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}",this.GetType(), this, ___index);
			}
		}
		public void ___deleteByName(string ___name)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByName {0} {1} called : {2}",this.GetType(), this, ___name);
			}

		}
		public object[] ___getByIds()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getByIds() {0} {1} called",this.GetType(), this);
			}
			return null;

		}
		public string ___getClassName()
		{
            return "DOMImplementation";
		}
		public object ___getDefaultValue()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getDefaultValue {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public object ___getParentScope()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getParentScope {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public void ___setParentScope(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___setParentScope {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}
		public object ___getProtoType()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getProtoType {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public bool ___hasInstance(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___hasInstance {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return false;
		}
		public bool ___instanceEquals(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___instanceEquals {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return object.ReferenceEquals(this, ___object);
		}
		public void ___setProtoType(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___setProtoType {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.CSSStyleDeclaration;
            }
        }

#endregion
	}
}
