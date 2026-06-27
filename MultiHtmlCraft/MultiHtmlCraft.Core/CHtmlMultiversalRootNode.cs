using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
    public class CHtmlMultiversalRootNode : CHtmlNode, ICommonObjectInterface 
    {
        // We should not use collections 
        // public System.Collections.Generic.SortedList<string, System.WeakReference> referenceList = new SortedList<string, WeakReference>(StringComparer.Ordinal);
        #region IPropertBox メンバ

        public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {
                case "ELEMENT_NODE":
                    return 1;
                case "ATTRIBUTE_NODE":
                    return 2;
                case "TEXT_NODE":
                    return 3;
                case "CDATA_SECTION_NODE":
                    return 4;
                case "ENTITY_REFERENCE_NODE":
                    return 5;
                case "ENTITY_NODE":
                    return 6;
                case "PROCESSING_INSTRUCTION_NODE":
                    return 7;
                case "COMMENT_NODE":
                    return 8;
                case "DOCUMENT_NODE":
                    return 9;
                case "DOCUMENT_TYPE_NODE":
                    return 10;
                case "DOCUMENT_FRAGMENT_NODE":
                    return 11;
                case "NOTATION_NODE":
                    return 12;
                case "__iterator__":
                    // return commonHTML.rhinoForLoopEnumratorFunction;
                    return null;
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


        public bool ___hasPropertyByName(string ___name)
        {
            switch (___name)
            {
                case "__iterator__":
                    return true;
            }

            return true;
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
            return "Node";
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

        public object ___getPropertyByIndex(int ___index)
        {
            throw new NotImplementedException();
        }
        #endregion
        internal System.WeakReference ___WindowPrototypeWeakReference = null;
        internal System.WeakReference ___DocumentPrototypeWeakReference = null;
        internal System.WeakReference ___WorkerPrototypeWeakReference = null;
        internal System.WeakReference ___SharedWorkerPrototypeWeakReference = null;
        internal System.WeakReference ___DOMTokenListWeakReference = null;
        internal System.WeakReference ___DOMStringMapWeakReference = null;
        internal System.WeakReference ___TimeRangesReference = null;
        internal System.WeakReference ___ActiveXObjectPrototypeWeakReference = null;
        internal System.WeakReference ___ElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLCollectionPrototypeWeakReference = null;
        internal System.WeakReference ___NodeListPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLFormElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLLinkElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLAnchorElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLScriptElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLHtmlElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLBodyElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLImageElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLTableElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLTableSectionElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLTableRowElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLTableColElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLTableCellElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLButtonElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLInputElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLIFrameElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLFrameElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLCanvasElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLAudioElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLVideoElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLMapElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLTextElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLSVGElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLObjectElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLOptionElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLOptGroupElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLSourceElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLDivElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLSpanElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLStyleElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLSelectElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLTextAreaElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLBaseElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLAreaElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLFrameSetElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLHeadElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLTemplateElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLUListElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLIElementPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLDataListPrototypeWeakReference = null;
        internal System.WeakReference ___HTMLPictureElementPrototypeWeakReference = null;
        internal System.WeakReference ___SVGElementPrototypeWeakReference = null;
        internal System.WeakReference ___EventPrototypeWeakReference = null;
        internal System.WeakReference ___MouseEventPrototypeWeakReference = null;
        internal System.WeakReference ___StyleSheetPrototypeWeakReference = null;
        internal System.WeakReference ___CSSStyleSheetPrototypeWeakReference = null;
        internal System.WeakReference ___ScreenPrototypeWeakReference = null;
        internal System.WeakReference ___ConsolePrototypeWeakReference = null;
        internal System.WeakReference ___KeyboardEventWeakReference = null;
        internal System.WeakReference ___ClipboardPrototypeWeakReference = null;
        internal System.WeakReference ___TimeRangesPrototypeWeakReference = null;
        internal System.WeakReference ___FileReaderPrototypeWeakReference = null;
        internal System.WeakReference ___HistoryPrototypeWeakReference = null;
        internal System.WeakReference ___XPathResultPrototypeWeakReference = null;
        internal System.WeakReference ___ExternalPrototypeWeakReference = null;
        internal System.WeakReference ___NavigatorPrototypeWeakReference = null;
        internal System.WeakReference ___CanvasContextPrototypeWeakReference = null;
        internal System.WeakReference ___CanvasWebGLRenderingContextPrototypeWeakReference = null;
        internal System.WeakReference ___AudioContextPrototypeWeakReference = null;
        internal System.WeakReference ___AudioBuuferSourceNodeWeakReference = null;
        internal System.WeakReference ___AudioOscillatorNodeWeakReference = null;
        internal System.WeakReference ___FilePrototypeWeakReference = null;
        internal System.WeakReference ___FileListProtoTypeWeakReference = null;
        internal System.WeakReference ___BlobPrototypeWeakReference = null;
        internal System.WeakReference ___AttrProtoTypeWeakReference = null;
        internal System.WeakReference ___ArrayBufferPrototypeWeakReference = null;
        internal System.WeakReference ___TypedArrayPrototypeWeakReference = null;
        internal System.WeakReference ___Float32ArrayPrototypeWeakReference = null;
        internal System.WeakReference ___Float64ArrayPrototypeWeakReference = null;
        internal System.WeakReference ___Int8ArrayPrototypeWeakReference = null;
        internal System.WeakReference ___Int16ArrayPrototypeWeakReference = null;
        internal System.WeakReference ___Int32ArrayPrototypeWeakReference = null;
        internal System.WeakReference ___Uint8ArrayPrototypeWeakReference = null;
        internal System.WeakReference ___Uint16ArrayPrototypeWeakReference = null;
        internal System.WeakReference ___Uint32ArrayPrototypeWeakReference = null;
        internal System.WeakReference ___WebSpeechRecognitionWeakReference = null;
        internal System.WeakReference ___WebSpeechRecognitionEventWeakReference = null;
        internal System.WeakReference ___WebSpeechGrammerListWeakReference = null;
        internal System.WeakReference ___WebSpeechSynthesisUtterranceWeakReference = null;
        internal System.WeakReference ___WebSpeechGrammarWeakReference = null;
        internal System.WeakReference ___WebSpeechGrammarListWeakReference = null;

        internal System.WeakReference ___WebSpeechRecognitionAlternativeWeakReference = null;
        internal System.WeakReference ___WebSpeechRecognitionErrorWeakReference = null;
        
        internal System.WeakReference ___WebSpeechRecognitionResultWeakReference = null;
        internal System.WeakReference ___WebSpeechRecognitionResultListWeakReference = null;
        internal System.WeakReference ___WebSpeechSynthesisWeakReference = null;
        internal System.WeakReference ___WebSpeechSynthesisErrorEventWeakReference = null;
        internal System.WeakReference ___WebSpeechSynthesisEvenWeakReferencet = null;
        internal System.WeakReference ___WebSpeechSynthesisUtteranceWeakReference = null;
        internal System.WeakReference ___WebSpeechSynthehesisVoiceWeakReference = null;
    }
}
