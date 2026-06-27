using System;
using System.Xml;
using System.Collections;
using System.Text;
using System.Drawing;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// HtmlDocument 
	/// </summary>
	public class CHtmlBase : CHtmlNode, ICHtmlNodeInterface
	{

        public CHtmlElementType ___elementTagType = CHtmlElementType._UNDEFINED;
		internal string ___tagName = null;
		
		internal string ___title = null;
		internal CHtmlDomTokenList ___classList =null;

        internal bool ___DontPerformClassListChange = false;
		
		private string ___elementLogString =null;


        private string ___elementGUIString = null;
        /// <summary>
        /// Location of base document
        /// </summary>
        internal CHtmlLocationBase ___locationBase;
		public int ___ChildNodeIndex = -1;

        internal bool ___IsDisposing = false;



		public int ___TagOpenStartPosition;
		public int ___TagOpenEndPosition;
		public int ___TagCloseStartPosition;
		public int ___TagCloseEndPosition;
		
		//public int ___DocumentElementIndex = -1;
		public int ___ParagraphIndex = -1;
		internal CHtmlNodeType ___nodeType = CHtmlNodeType.ELEMENT_NODE;
		internal string ___src = null;
		internal string ___href = null;
		internal string ___innerHTML = null;



        public int ___ElementPrototypeMethodPropertyCount = 0;

		/// <summary>
		/// If This Tag Part Rendered it parent or not
		/// </summary>
		internal bool ___IsRenderedByParent = false;
		/// <summary>
		/// If This Tag Part Rendering Parent
		/// </summary>
		internal bool ___IsRenderingParent = false;
        /// <summary>
        /// Foreground Color 
        /// </summary>
        public ColorSpec ___ForegroundSysColor = new ColorSpec(0, 0, 0);
		/// <summary>
		/// Foreground Hover Color 
		/// </summary>
		public ColorSpec ___ForegroundHoverSysColor = new ColorSpec(0, 0, 0);
        /// <summary>
        /// Foreground Active Color 
        /// </summary>
        public ColorSpec ___ForegroundActiveSysColor = new ColorSpec(0, 0, 0);
        /// <summary>
        /// Background Color 
        /// </summary>
        public ColorSpec ___BackgroundSysColor = new ColorSpec(0, 0, 0, 255);
        /// <summary>
        /// Background Hover Color 
        /// </summary>
        public ColorSpec ___BackgroundHoverSysColor = new ColorSpec(0, 0, 0, 255);
        /// <summary>
        /// Background Active Color 
        /// </summary>
        public ColorSpec ___BackgroundActiveSysColor = new ColorSpec(0, 0, 0, 255);

        public bool ___IsBackgroundColorSpecified = false;
		public bool ___IsForegroundColorSpecified = false;
		/// <summary>
		/// Child DOM Level From Root
		/// </summary>
		public int  ___DOM_Level = -1;
		private System.Text.StringBuilder _DOM_Processor = null;
	
        
        internal string ___name;
        internal string ___class;
        internal string ___type;
        internal string ___id;
        internal string ___idLowSimple;
        internal object ___value;
        internal bool ___checked = false;
        
		
        
		public CHtmlBase()
		{
			this.___locationBase = new CHtmlLocationBase();
            
			this.___classList =new CHtmlDomTokenList();
			this.___classList.parentBase = this;
            base.___multiversalClassType = IMutilversalObjectType.Element;
            /*
            this.___name = null;
            this.___class = null;
            this.___type = null;
            this.___id = null;
            this.___idLowSimple = null;
             */
            

		}
		~CHtmlBase()
		{
			this.CleanUp();
		}
		private void CleanUp()
		{
			if(this.___classList != null)
			{
				this.___classList = null;
			}
			/*
			if(this.___locationBase != null)
			{
				this.___locationBase  = null;
			}
			*/
            // Document Fragment is just dom collection. do not clear child nodes.
            if (this.___elementTagType != CHtmlElementType._DOCUMENT_FRAGMENT)
            {
                if (this.___childNodes != null)
                {
                    if (this.___childNodes.Count > 0)
                    {
                        this.___childNodes.Clear();
                    }
                    this.___childNodes = null;
                }
                
            }
			if(this._DOM_Processor != null)
			{
				this._DOM_Processor = null;
			}
			
		}

        public string type
        {
            get {
                if (this.___type != null)
                {
                    return this.___type;
                }
                else
                {
                    return "";
                }
            }
            set { this.___type = value; }
        }
        public bool @checked
        {
            get { return this.___checked; }
            set { this.___checked = value; }
        }

        public object @value
        {
            get { return this.___value; }
            set { this.___value = value; }
        }

		/// <summary>
		/// className array by splitting by spaces
		/// </summary>
		public CHtmlDomTokenList classList
		{
			get
			{
                if (this.___classList != null)
                {
                    return this.___classList;
                }
                else
                {
                    return null;
                }
			}
		}

        /* Base Element does not have children use childNodes
		public CHtmlCollection children
		{
			___getInner{return this.___childNodes;}
		}
         */

        public CHtmlCollection children
        {
            get
            {
                if (this.___childNodes != null)
                {
                    return this.___getChildrenList();
                }
                else
                {
                    return null;
                }
            }
        }
        public int childElementCount
        {
            get
            {
                if (this.___childNodes != null)
                {
                    return this.___childNodes.Count;
                }
                else
                {
                    return 0;
                }
            }
        }


        public override string ToString()
        {
            return "[object " + base.___multiversalClassType.ToString() + "]";
        }
        public new IMutilversalObjectType multiversalClassType
        {
            get {return  base.___multiversalClassType; }
        }
        private string ___getTextElementInnerLogString()
        {
            System.Text.StringBuilder sbText = new StringBuilder(commonHTML.StringBuilder_BUFFER_Size_For_CSS_Tag);
            sbText.Append("<#TEXT");
            string ___text = this.___value as string;
            if (string.IsNullOrEmpty(___text) == false)
            {

                int ___textLen = ___text.Length;
                char[] csArray = ___text.ToCharArray();
                int ___cur = 0;
                if (csArray.Length == 0)
                {
                    sbText.Append(" value=''");
                }
                else
                {
                    sbText.Append(" value='");
                    for (int i = 0; i < ___textLen; i++)
                    {
                        char c = csArray[i];
                        if (Array.IndexOf(___logInvalidhars, c) > -1)
                        {
                            sbText.Append('_');
                            ___cur++;
                        }
                        else
                        {
                            sbText.Append(c);
                            ___cur++;
                            if (___cur > 16)
                                break;
                        }

                    }
                    sbText.Append('\'');
                }
               
            }
            sbText.Append('/');
            sbText.Append('>');
            return sbText.ToString();
        }
        public string toGUIString()
        {
            if (string.IsNullOrEmpty(this.___elementGUIString) == true)
            {
                try
                {

                    switch (this.___elementTagType)
                    {
                        case CHtmlElementType._ELEMENT_AFTER:
                            this.___elementGUIString = "<:after>";
                            break;

                        case CHtmlElementType._ELEMENT_BEFORE:
                    
                        this.___elementGUIString = "<:before>";
                            break;

                        case CHtmlElementType._ITEXT:

                            this.___elementGUIString = ___getTextElementInnerLogString();

                         
                            
                            break;
                        default:

                            System.Text.StringBuilder sbText = new StringBuilder(commonHTML.StringBuilder_BUFFER_Size_For_CSS_Tag);
                            if (this.___IsPrototype == true)
                            {
                                sbText.Append("[prototype] ");
                            }
                            sbText.Append('<');
                            sbText.Append(this.___tagName);

                            if (string.IsNullOrEmpty(this.___class) == false)
                            {
                                sbText.Append(" class=");
                                sbText.Append(this.___class);
                            }
                            if (string.IsNullOrEmpty(this.___id) == false)
                            {
                                sbText.Append(" id=");
                                sbText.Append(this.___id);
                            }
                            if (string.IsNullOrEmpty(this.___name) == false)
                            {
                                sbText.Append(" name=");
                                sbText.Append(this.___name);
                            }

                            sbText.Append('>');
                            this.___elementGUIString = sbText.ToString();
                            break;
                    }

                }
                catch { }
                return this.___elementGUIString;
            }
            else
            {
                return this.___elementGUIString;
            }
        }
		public string toLogString()
		{
			if(string.IsNullOrEmpty(this.___elementLogString) == true)
			{
				try
				{
                    switch (this.___elementTagType)
                    {
                        case CHtmlElementType._ELEMENT_AFTER:
                            this.___elementLogString = "<:after>";
                            break;

                        case CHtmlElementType._ELEMENT_BEFORE:

                            this.___elementLogString = "<:before>";
                            break;

                        case CHtmlElementType._ITEXT:

                            this.___elementLogString = ___getTextElementInnerLogString();



                            break;
                        default:

                            System.Text.StringBuilder sbText = new StringBuilder(commonHTML.StringBuilder_BUFFER_Size_For_CSS_Tag);
                            if (this.___IsPrototype == true)
                            {
                                sbText.Append("[prototype] ");
                            }
                            sbText.Append('<');
                            sbText.Append(this.___tagName);

                            if (string.IsNullOrEmpty(this.___class) == false)
                            {
                                sbText.Append(" class=");
                                sbText.Append(this.___class);
                            }
                            if (string.IsNullOrEmpty(this.___id) == false)
                            {
                                sbText.Append(" id=");
                                sbText.Append(this.___id);
                            }
                            if (string.IsNullOrEmpty(this.___name) == false)
                            {
                                sbText.Append(" name=");
                                sbText.Append(this.___name);
                            }

                            sbText.Append('>');
                            this.___elementLogString = sbText.ToString();
                            break;
                    }

                }
                
				catch{}
				return this.___elementLogString;
			}
			else
			{
				return this.___elementLogString;
			}
			
			 
		}
		private static readonly char[] ___logInvalidhars =new char[]{'{', '}'};

		

		public string className
		{
			set
			{
				if(string.Equals(this.___class, value, StringComparison.OrdinalIgnoreCase) == false)
				{
					this.___class = value;
                    if (___DontPerformClassListChange == false)
                    {
                        this.CreateClassList();
                    }
					
				}
				if(string.IsNullOrEmpty(this.___elementLogString) == false)
				{
					this.___elementLogString = "";
				}
			}
			get{
                if (this.___class != null)
                {
                    return this.___class;
                }
                else
                {
                    return "";
                }
            }
		}
		public string @class
		{
			set
			{
				if(string.Equals(this.___class, value, StringComparison.OrdinalIgnoreCase) == false)
				{
					this.___class = value;
                    if (___DontPerformClassListChange == false)
                    {
                        this.CreateClassList();
                    }
					
				}
				if(string.IsNullOrEmpty(this.___elementLogString) == false)
				{
					this.___elementLogString = "";
				}
			}
			get{
                if (this.___class != null)
                {
                    return this.___class;
                }
                else
                {
                    return "";
                }
            }
		}
		public string id
		{
			set
			{
				this.___id = value;
                this.___idLowSimple = commonHTML.FasterToLower(value);
				if(string.IsNullOrEmpty(this.___elementLogString) == false)
				{
					this.___elementLogString = "";
				}
			}
            get
            {
                if (this.___id != null)
                {
                    return this.___id;
                }
                else
                {
                    return "";
                }
            }
		}
		public string name
		{
			set
			{
				this.___name = value;
				if(string.IsNullOrEmpty(this.___elementLogString) == false)
				{
					this.___elementLogString = "";
				}
			}
			get{
                if (this.___name != null)
                {
                    return this.___name;
                }
                else
                {
                    return "";
                }
            }
		}

		private void CreateClassList()
		{
			this.___classList.Clear();
			if(string.IsNullOrEmpty(this.___class) == true)
			{
				return;
			}
			System.Text.StringBuilder _sb =new System.Text.StringBuilder();

			char[] cs = this.___class.ToCharArray();
			int csLen = cs.Length;
            char c = new char();
			for(int i = 0; i < csLen; i ++)
			{
                c = cs[i];
                if (commonHTML.FasterIsWhiteSpaceLimited(c) == false && c != ',')
				{
                    if (c >= 'A' && c <= 'Z')
                    {
                        _sb.Append(commonHTML.FasterToLower(c));
                    }
                    else
                    {
                        _sb.Append(c);
                    }
				}
				else 
				{
					this.___classList.Add(_sb.ToString());
					_sb = new StringBuilder();
				}
			}
			if(_sb.Length > 0)
			{
				this.___classList.Add(_sb.ToString());
			}

		}


		/// <summary>
		/// Integer that receives one of the following values.
		/// 1 = Element node. 
		/// 3 = Text node. 
		/// </summary>
		public double nodeType
		{
			get
			{
				return (double)this.___nodeType;	
			}
		}
		/// <summary>
		/// Internal Method to set CHtmlNodeType
		/// </summary>
		/// <param name="nType"></param>
		internal void ___SetNodeType(CHtmlNodeType nType)
		{
			this.___nodeType = nType;
		}
		/// <summary>
		/// DOM Processor Comment
		/// </summary>
		public string ___DOM_Note
		{
			get
			{
				if(this._DOM_Processor == null)
				{
					return "";
				}
				else
				{
					return this._DOM_Processor.ToString();
				}
			}
		}
        /// <summary>
        /// Create Normal children list (which does not contain text nodes)
        /// </summary>
        public CHtmlCollection ___getChildrenList()
        {
            CHtmlCollection ___chidrenList = new CHtmlCollection();
            ___chidrenList.___CollectionType = CHtmlHTMLCollectionType.ElementChildren;
            ___chidrenList.___parentNode = this.___parentNode;
            int ___childCount = this.___childNodes.Count;
            for (int i = 0; i < ___childCount; i++)
            {
                CHtmlElement ___childElement = this.___childNodes[i] as CHtmlElement;
                if (___childElement != null)
                {
                    if (___childElement.___IsSystemHidden == false)
                    {
                        ___chidrenList.Add(___childElement);
                    }
                }
            }
            return ___chidrenList;
        }
		internal void X_DOM_ProcessorAdd(string s)
		{
			if(this._DOM_Processor == null)
			{
				this._DOM_Processor = new StringBuilder();
			}
			this._DOM_Processor.Append(s);
			this._DOM_Processor.Append("; ");
		}
		public string innerHTML
		{
			get{
                if (this.___innerHTML != null)
                {
                    return this.___innerHTML;
                }
                else
                {
                    return "";
                }
            }
			set{this.___innerHTML = value;}
		}
        public virtual string src
        {
            get {
                if (this.___src != null)
                {
                    return this.___src;
                }
                else
                {
                    return "";
                }
            }
            set { this.___src = value; }

        }
        public string href
        {
            get
            {
                if (this.___href != null)
                {
                    return this.___href;
                }
                else
                {
                    return "";
                }
            }
            set { this.___href = value; }
        }
        
        
		#region IDisposable ƒƒ“ƒo

		public  void Dispose()
		{
			this.CleanUp();
			//GC.SuppressFinalize(this);
		}
		/// <summary>
		/// This method is called from classList
		/// </summary>
		internal void RebuildClassNameFromClassNameValue()
		{
            int keyCount = this.___classList.___keyList.Count;
            if (keyCount  > 0)
            {
                System.Text.StringBuilder sbClass = new StringBuilder();
                
                foreach(string s in this.___classList.___keyList.Keys)
                {
                    sbClass.Append(s);
                    sbClass.Append(' ');
                }
                if (sbClass.Length > 0)
                {
                    sbClass.Remove(sbClass.Length - 1, 1);
                }
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                {
                   commonLog.LogEntry("{0} is class have changed to {1} by script", this, sbClass.ToString());
                }
                this.___class = sbClass.ToString();
            }
            else
            {
                this.___class = "";
            }
		}

		#endregion

	}
	

}
