using System;
using System.Xml;
using System.Collections;
using System.Text;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// HtmlDocument 
	/// </summary>
	public class CHtmlParagraph : CHtmlBase
	{
		private System.Collections.ArrayList _DrawingRectangleList;
		public bool ___IsElementBlock = false;
		public bool ___IsElementIsInline = false;
		internal CHtmlElement ___ownerElement = null;
		// UFont is moved to CHtmlElement
		//publicCHtmlFontInfo UFont = null;
		private string _Text = string.Empty;
		
		public string Text
		{
			set{
				this._Text = value;
			}
			get{return this._Text;}
		}
		public CHtmlParagraph()
		{

		}
		~CHtmlParagraph()
		{
			this.CleanUp();
		}

		private void CleanUp()
		{
            if (this.___ownerElement != null)
			{
                this.___ownerElement = null;
			}
			if(this._DrawingRectangleList != null)
			{
				this._DrawingRectangleList.Clear();
			}
			this._DrawingRectangleList = null;

		}

		public ArrayList DrawingRectangleList
		{
			set{this._DrawingRectangleList = value;}
			get{return this._DrawingRectangleList;}
		}
		#region ICloneable ÉÅÉìÉo

		public CHtmlParagraph Clone()
		{
			CHtmlParagraph pn = new CHtmlParagraph();
			pn.name = this.name;
			pn.className = this.className;
			pn.id = this.___id;
			pn.___tagName = this.___tagName;
			pn.___elementTagType = this.___elementTagType;
			pn.___ForegroundSysColor = this.___ForegroundSysColor;
			pn.innerHTML =this.innerHTML;
			if(this.___locationBase != null)
			{
				pn.___locationBase.href  = string.Copy(this.___locationBase.href);
			}
			pn.Text = this._Text;
			pn.___BackgroundSysColor = this.___BackgroundSysColor;
	
			pn.___IsElementBlock = this.___IsElementBlock;
			pn.___IsElementIsInline = this.___IsElementIsInline;
			pn.___IsRenderedByParent = this.___IsRenderedByParent;
			pn.___ParagraphIndex = this.___ParagraphIndex;
			pn.___TagOpenStartPosition = this.___TagOpenStartPosition;
			pn.___TagOpenEndPosition = this.___TagOpenEndPosition;
			pn.___TagCloseStartPosition = this.___TagCloseStartPosition;
			pn.___TagCloseEndPosition = this.___TagCloseEndPosition;
			pn.___title = this.___title;
            pn.___ownerElement = this.___ownerElement;
			return pn;
		}

		#endregion
	}

}
