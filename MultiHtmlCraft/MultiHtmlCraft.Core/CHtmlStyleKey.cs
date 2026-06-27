using System;
using System.Collections;
using System.Text;

namespace MultiHtmlCraft.Core
{

	
	public sealed class CHtmlStyleKey
	{
		public string CssClass = null;
		public string CssClassLowSimple = null;
	
		public string CssID = null;
		public string CssIDLowSimple = null;

		public string TagName = null;
        public CHtmlElementType ___elementTagType = CHtmlElementType._UNDEFINED;
		public string Prefix = null;
		/* suffix is moved to preudoList
		public string Sufix = "";
		public string SufixPseudo = "";
		*/
		public string SortShortName = null;
		public string AttributeString = null;

		public CHtmlSelectorKeyClassType ___SelectorKeyDefinedField = CHtmlSelectorKeyClassType.NotSet;

		private System.WeakReference ___owerCHtmlStyleElementReference = null;


		
		public CHtmlStyleSelectorKeyDataModeType ___StyleSelectorKeyDataMode = CHtmlStyleSelectorKeyDataModeType.Other;

		/// <summary>
		/// Combinator may be 
		/// 'greater' child combinator : style the content of elements contained within other specified elements.
		/// '+' direct adjacent combinator : For example, imagine you want to indent all paragraphs 
		/// in a document except for ones immediately following a sub-heading (<h2>). 
		/// The second rule below shows an h2 selector combined with a p selector using a plus sign as the combinator
		/// to indicate that the declaration applies only if p immediately follows h2: 
		/// h2 + p{text-indent: 0;} 
		/// </summary>
        public char Combinator = ' ';
        
		private bool _ResetName = true;
		/// <summary>
		/// class Name list(lowercase) it is sored with StringCompareOrdinalComparer
		/// </summary>
		public CHtmlDomTokenList ___classList = null;
        internal System.Collections.Generic.Dictionary<string, CHtmlStyleElementSelectorKeyAttributeClass?> ___attributeKeyList = null;
		/// <summary>
		/// use ___pseudoTitleParamList
		/// </summary>
		
		/* internal CHtmlCollection ___pseudoList = null; */


		/// <summary>
		/// List contains :link :hover etc. if you want to see just title use ___pseudoTitleParamList
		/// </summary>
		internal System.Collections.Generic.Dictionary<CHtmlPseudoClassType, CHtmlStyleElementPseudoClassValue?> ___pseudoTitleParamList = null;



		
		public CHtmlStyleKey()
		{
			this.___classList =new CHtmlDomTokenList();
           // this.___attributeKeyList = new System.Collections.Generic.Dictionary<string, CHtmlStyleElementSelectorKeyAttributeClass>(StringComparer.OrdinalIgnoreCase);

           // this.___pseudoTitleParamList = new System.Collections.Generic.Dictionary<CHtmlPseudoClassType, CHtmlStyleElementPseudoClassValue>();
		}
		public static string[] SplitSuffix(string _sufix)
		{
            if (_sufix.IndexOf('(') == -1)
			{
				return  _sufix.Split(':');
			}
			else
			{
				char[] graChars =  _sufix.ToCharArray();
                System.Collections.Generic.List<string> arString = new System.Collections.Generic.List<string>();
				System.Text.StringBuilder sbValue =new StringBuilder();
				char c = '\0';
				bool __IsInValue = false;
				int graChasLength = graChars.Length;
				for(int i = 0; i < graChasLength; i ++)
				{
					c = graChars[i];
					switch(c)
					{
						case ':':
							if(__IsInValue == false)
							{
                                if (sbValue.Length != 0 && (commonHTML.FasterIsWhiteSpaceLimited(sbValue[0]) || commonHTML.FasterIsWhiteSpaceLimited(sbValue[sbValue.Length - 1])))
                                {
                                    arString.Add(sbValue.ToString().Trim());
                                }
                                else
                                {
                                    arString.Add(sbValue.ToString());
                                }
								sbValue = null;
								sbValue =new StringBuilder();
								continue;
							}
							break;
						case '(':
							__IsInValue = true;
							break;
						case ')':
							__IsInValue = false;
							break;
						default:
							break;
					}
					sbValue.Append(c);
				}
				if(sbValue != null && sbValue.Length > 0)
				{
                    if (sbValue.Length != 0 && (commonHTML.FasterIsWhiteSpaceLimited(sbValue[0]) || commonHTML.FasterIsWhiteSpaceLimited(sbValue[sbValue.Length - 1])))
                    {
                        arString.Add(sbValue.ToString().Trim());
                    }
                    else
                    {
                        arString.Add(sbValue.ToString());
                    }
				}
				if(arString.Count > 0)
				{
					return arString.ToArray();
				}
				else
				{
					return new string[]{};
				}
			}
		}
        public CSSSelectorKeyOperataorType GetAttributeOperatorType(string _val)
        {
            switch (_val)
            {
                case null:
                case "":
                    return CSSSelectorKeyOperataorType.none;
                case "=":
                case "==":
                    return CSSSelectorKeyOperataorType.equals;
                case "!=":
                    return CSSSelectorKeyOperataorType.notEquals;
                case "~=":
                    return CSSSelectorKeyOperataorType.whitespaceSplitInclude;
                case "*=":
                    return CSSSelectorKeyOperataorType.includes;
                case "|=": 
                    return CSSSelectorKeyOperataorType.flangInclude;
                case "^=":
                    return CSSSelectorKeyOperataorType.beginWith;
                case "$=":
                    return CSSSelectorKeyOperataorType.endWith;

            }
            return CSSSelectorKeyOperataorType.unknown;
        }
		
		public CHtmlStyleKey(CHtmlCSSRule basestyleElement, string ___TagName, string ___CssClass, string ___CssID, string ___Prefix, string ___Sufix,string ___AttributeLookup, string ___Combinator) : this()
		{
			if(basestyleElement != null)
			{
				this.___owerCHtmlStyleElementReference  = new WeakReference(basestyleElement, false);
			}
			_ResetName = true;
			if(string.IsNullOrEmpty(___TagName) == false)
			{
				this.TagName    = ___TagName;
                if (___TagName.Length == 1 && ___TagName[0] == '*')
                {
                    this.___elementTagType = CHtmlElementType.ASTERISK;
                }
                else
                {
                    this.___elementTagType = commonHTML.GetTagNameType(___TagName);
                }
			}

            if (___Combinator.Length > 0)
            {
                char cCombinatorCharacter = ___Combinator[0];
                switch (cCombinatorCharacter)
                {
                    case '+':
                    case '>':
                    case '~':
                        this.Combinator = cCombinatorCharacter;
                        if (basestyleElement != null)
                        {
                            basestyleElement.___HasCombinatorChar = true;
                        }
                        if (basestyleElement != null)
                        {
                            // =================================================================================
                            // Combinator ___hasInner more important than others, just increment one...
                            // =================================================================================
                            basestyleElement.___SelectorRanking++;
                        }
                        break;
                    case '%':
                    case '$':
                    case '<':
                    case '=':
                    case '&':
                    case '!':
                    case '\\':
                    case '/':
                    case '^':
                    case '@':
                        // =================================================================================
                        // There charactors are not normal as combinator but accept one.
                        // =================================================================================
                        this.Combinator = cCombinatorCharacter;
                        if (basestyleElement != null)
                        {
                            basestyleElement.___HasCombinatorChar = true;
                        }
                        break;
                    default:
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                        {
                           commonLog.LogEntry("Strange Combinator in selector : {0}" , cCombinatorCharacter);
                        }
                        break;
                }
            }
			// check number of '.' count
            int firstPeriod = ___CssClass.IndexOf('.');
            int lastPeriod = -1;
            if (firstPeriod != -1)
            {
                lastPeriod = ___CssClass.LastIndexOf('.');
            }
			if(firstPeriod == -1)
			{
				if(this.___classList.Count > 0)
				{
					this.___classList.Clear();
				}
			}
			else if(firstPeriod > -1 && lastPeriod == firstPeriod)
			{
				this.SetCssClass(___CssClass);
				if(this.___classList.Count > 0)
				{
					this.___classList.Clear();
				}
				this.___classList.Add(commonHTML.FasterToLower(___CssClass.Replace(".", "")));
			}
			else // Means .aaa.bbb.ccc multiple class
			{
				if(this.___classList.Count > 0)
				{
					this.___classList.Clear();
				}
				string __CssClassLow = commonHTML.FasterToLower(___CssClass);
				string[] spClass = __CssClassLow.Split('.');
				int spClassLen = spClass.Length;
				for(int i = 0; i < spClassLen; i ++)
				{
					if(spClass[i].Length > 0)
					{
						this.___classList.Add(spClass[i]);
					}
				}

				if(this.___classList.Count > 0)
				{
                    foreach (string strFirstKey in this.___classList.___keyList.Keys)
                    {
                        this.CssClassLowSimple = strFirstKey;
                        this.CssClass = "." + this.CssClassLowSimple;
                        break;
                    }
				}
			}
			if(this.___classList.Count > 0)
			{
				if(basestyleElement != null)
				{
					// =================================================================================
					// ||              'div.col.next' should have higher ranking than 'div.col'       ||
					// =================================================================================
					basestyleElement.___SelectorRanking = basestyleElement.___SelectorRanking + (10 * this.___classList.Count);
				}
			}

			if(___CssID.Length != 0)
			{
				this.SetCssID(___CssID);
			}
			this.Prefix    = ___Prefix;
			/*this.Sufix     = ___Sufix;*/
			if(___Sufix.Length != 0)
			{
				string[] spSufix = SplitSuffix(___Sufix);
				string __eachSufix = null;
				string ___PseudoTitle = null;
                int spSuffixLength = spSufix.Length;
                for (int i = 0; i < spSuffixLength; i++)
                {
                    string s = spSufix[i];
                    if (s == null || s.Length == 0)
                        continue;
                    __eachSufix = ":" + s;

                    int _ValStartPos = __eachSufix.IndexOf('(');
                    CHtmlPseudoClassType __PseudoType = CHtmlPseudoClassType.None;
                    if (_ValStartPos > -1)
                    {
                        ___PseudoTitle = __eachSufix.Substring(0, _ValStartPos);
                        __PseudoType = commonHTML.GetPseudoClassTypeFromName(___PseudoTitle);
                        if (this.___pseudoTitleParamList == null)
                        {
                            this.___pseudoTitleParamList = this.___pseudoTitleParamList = new System.Collections.Generic.Dictionary<CHtmlPseudoClassType, CHtmlStyleElementPseudoClassValue?>();
                        }
                        this.___pseudoTitleParamList[__PseudoType] = CHtmlStyleKey.CreatePsudoValueClass(___PseudoTitle, __PseudoType, __eachSufix, _ValStartPos);
                        // Pseudo Class Lanking Increment
                        if (basestyleElement != null)
                        {
                            basestyleElement.___SelectorRanking++;
                        }
                    }
                    else
                    {
                        ___PseudoTitle = __eachSufix;
                        __PseudoType = commonHTML.GetPseudoClassTypeFromName(__eachSufix);
                        if (this.___pseudoTitleParamList == null)
                        {
                            this.___pseudoTitleParamList = this.___pseudoTitleParamList = new System.Collections.Generic.Dictionary<CHtmlPseudoClassType, CHtmlStyleElementPseudoClassValue?>();
                        }
                        this.___pseudoTitleParamList[__PseudoType] = null;
                        if (basestyleElement != null)
                        {
                            basestyleElement.___SelectorRanking++;
                        }
                    }
                    // ================================================================================================================
                    if (basestyleElement != null)
                    {
                        switch (__PseudoType)
                        {
                            case CHtmlPseudoClassType.None:
                            
                                break;
                            case CHtmlPseudoClassType.HoverPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.HoverPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.HoverPseudoClass;
                                }
                                basestyleElement.___HasHoverPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.LinkPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.LinkPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.LinkPseudoClass;
                                }
                                basestyleElement.___HasLinkPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.VisitedPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.VisitedPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.VisitedPseudoClass;
                                }
                                basestyleElement.___HasVisitedPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.AfterPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.AfterPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.AfterPseudoClass;
                                }
                                basestyleElement.___HasAfterPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.ActivePseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.ActivePseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.ActivePseudoClass;
                                }
                                basestyleElement.___HasActivePseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.BeforePseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.BeforePseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.BeforePseudoClass;
                                }
                                basestyleElement.___HasBeforePseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.FirstChildPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.FirstChildPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.FirstChildPseudoClass;
                                }
                                basestyleElement.___HasFirstChildPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.LastChildPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.LastChildPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.LastChildPseudoClass;
                                }
                                basestyleElement.___HasLastChildPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.NthChildPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.NthChildPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.NthChildPseudoClass;
                                }
                                basestyleElement.___HasNthChildPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.EmptyPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.EmptyPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.EmptyPseudoClass;
                                }
                                basestyleElement.___HasEmptyPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.CheckedPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.CheckedPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.CheckedPseudoClass;
                                }
                                basestyleElement.___HasCheckedPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.DisabledPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.DisabledPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.DisabledPseudoClass;
                                }
                                basestyleElement.___HasDisabledPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.EnabledPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.EnabledPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.EnabledPseudoClass;
                                }
                                basestyleElement.___HasEnabledPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.FirstLinePseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.FirstLinePseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.FirstLinePseudoClass;
                                }
                                basestyleElement.___HasFirstLetterPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.FirstLetterPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.FirstLetterPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.FirstLetterPseudoClass;
                                }
                                basestyleElement.___HasFirstLinePseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.FirstOfTypePseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.FirstOfTypePseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.FirstOfTypePseudoClass;
                                }
                                basestyleElement.___HasFirstOfTypePseudoClass = true;
                                if (string.IsNullOrEmpty(this.TagName) == false)
                                {
                                    basestyleElement.___ListNthOfTypeTagTypes[this.TagName] = 1;
                                }
                                break;
                            case CHtmlPseudoClassType.FocusPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.FocusPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.FocusPseudoClass;
                                }
                                basestyleElement.___HasFocusPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.IndeterminatePseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.IndeterminatePseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.IndeterminatePseudoClass;
                                }
                                basestyleElement.___HasIndeterminatePseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.LangPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.LangPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.LangPseudoClass;
                                }
                                basestyleElement.___HasLangPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.DirPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.DirPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.DirPseudoClass;
                                }
                                basestyleElement.___HasDirPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.OptionalPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.OptionalPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.OptionalPseudoClass;
                                }
                                basestyleElement.___HasOptionalPseudoClass = true;
                                break;
     

                            case CHtmlPseudoClassType.MatchesConditionPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.MatchesConditionPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.MatchesConditionPseudoClass;
                                }
                                basestyleElement.___HasMatchesConditionPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.NotConditionPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.NotConditionPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.NotConditionPseudoClass;
                                }
                                basestyleElement.___HasNotConditionPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.NthLastChildPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.NthLastChildPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.NthLastChildPseudoClass;
                                }
                                basestyleElement.___HasNthLastChildPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.LastOfTypePseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.LastOfTypePseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.LastOfTypePseudoClass;
                                }
                                basestyleElement.___HasLastOfTypePseudoClass = true;
                                if (string.IsNullOrEmpty(this.TagName) == false)
                                {
                                    basestyleElement.___ListNthOfTypeTagTypes[this.TagName] = 1;
                                }
                                break;
                            case CHtmlPseudoClassType.NthLastOfTypePseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.NthLastOfTypePseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.NthLastOfTypePseudoClass;
                                }
                                basestyleElement.___HasNthLastOfTypePseudoClass = true;
                                if (string.IsNullOrEmpty(this.TagName) == false)
                                {
                                    basestyleElement.___ListNthOfTypeTagTypes[this.TagName] = 1;
                                }
                                break;
                            case CHtmlPseudoClassType.NthOfTypePseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.NthOfTypePseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.NthOfTypePseudoClass;
                                }
                                basestyleElement.___HasNthOfTypePseudoClass = true;
                                if (string.IsNullOrEmpty(this.TagName) == false)
                                {
                                    basestyleElement.___ListNthOfTypeTagTypes[this.TagName] = 1;
                                }
                                break;
                            case CHtmlPseudoClassType.OnlyChildPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.OnlyChildPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.OnlyChildPseudoClass;
                                }
                                basestyleElement.___HasOnlyChildPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.OnlyOfTypePseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.OnlyOfTypePseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.OnlyOfTypePseudoClass;
                                }
                                basestyleElement.___HasOnlyOfTypePseudoClass = true;
                                if (string.IsNullOrEmpty(this.TagName) == false)
                                {
                                    basestyleElement.___ListNthOfTypeTagTypes[this.TagName] = 1;
                                }
                                break;
                            case CHtmlPseudoClassType.PlaceHolderPseudoClass:
     
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.PlaceHolderPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.PlaceHolderPseudoClass;
                                }
                                basestyleElement.___HasPlaceHolderPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.ReadOnlyPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.ReadOnlyPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.ReadOnlyPseudoClass;
                                }
                                basestyleElement.___HasReadOnlyPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.ReadWritePseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.ReadWritePseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.ReadWritePseudoClass;
                                }
                                basestyleElement.___HasReadWritePseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.RootPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.RootPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.RootPseudoClass;
                                }
                                basestyleElement.___HasRootPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.SelectionPseudoClass:
                           
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.SelectionPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.SelectionPseudoClass;
                                }
                                basestyleElement.___HasSelectionPseudoClass = true;
                                basestyleElement.___NonSearchableStyleSheet = true;
                                break;
                            case CHtmlPseudoClassType.TargetPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.TargetPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.TargetPseudoClass;
                                }
                                basestyleElement.___HasTargetPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.WarningPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.WarningPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.WarningPseudoClass;
                                }
                                basestyleElement.___HasWarningPseudoClass = true;
                                basestyleElement.___NonSearchableStyleSheet = true;
                                break;
                            case CHtmlPseudoClassType.RequiredPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.RequiredPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.RequiredPseudoClass;
                                }
                                basestyleElement.___HasRequiredPseudoClass = true;
                                break;

                            case CHtmlPseudoClassType.SearchCancelButton:
                                basestyleElement.___HasSearchCancelButtonPseudoClass = true;
                                break;

                            case CHtmlPseudoClassType.FullScreenPseudoClass:
                                basestyleElement.___HasFullscreenPseudoClass = true;
                                basestyleElement.___NonSearchableStyleSheet = true;
                                break;
                            case CHtmlPseudoClassType.InvalidPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.InvalidPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.InvalidPseudoClass;
                                }
                                basestyleElement.___HasInvalidPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.ValidPseudoClass:
                                if (commonHTML.IsPseudoClassTypeSet(basestyleElement.___PseudoClassType, CHtmlPseudoClassType.ValidPseudoClass) == false)
                                {
                                    basestyleElement.___PseudoClassType = basestyleElement.___PseudoClassType | CHtmlPseudoClassType.ValidPseudoClass;
                                }
                                basestyleElement.___HasValidPseudoClass = true;
                                break;
                            case CHtmlPseudoClassType.IncrementPseudoClass:
                            case CHtmlPseudoClassType.DecrementPseudoClass:
                                basestyleElement.___NonSearchableStyleSheet = true;
                                break;
                            case CHtmlPseudoClassType.UnknownPseudoClass:
                            default:

                                basestyleElement.___NonSearchableStyleSheet = true;
                                basestyleElement.___UndefinedPsedoClassCount++;
                                break;
                        }
                    }
                    // ================================================================================================================

                    // -------------------------------------------------------------------------------
                    // ___pseudoTitleParamList now contains number of pseudo titles
                    // -------------------------------------------------------------------------------
                    if (basestyleElement != null && this.___pseudoTitleParamList.Count > 0)
                    {
                        basestyleElement.___PseudoClassCount += this.___pseudoTitleParamList.Count;
                    }
                }
			}


			if(___AttributeLookup.Length != 0)
			{

				string[] ___AttributeLookupSplit = null;
				___AttributeLookupSplit = ___AttributeLookup.Split('[');
				int AttribtePos = 0;
                int ___AttributeLookupSplitCount = ___AttributeLookupSplit.Length;
                string sAttr = null;
				for(int i = 0; i < ___AttributeLookupSplitCount ; i++)
				{
					sAttr = ___AttributeLookupSplit[i];
                    
					try
					{
						if(sAttr.Length == 0)
						{
							continue;
						}
                        if (commonHTML.FasterIsWhiteSpaceLimited(sAttr[0]) || commonHTML.FasterIsWhiteSpaceLimited(sAttr[sAttr.Length - 1]))
                        {
                            sAttr = sAttr.Trim();
                        }
						if(sAttr[sAttr.Length-1] == ']')
						{
							sAttr = sAttr.Remove(sAttr.Length -1, 1);
						}
						if( AttribtePos == 0)
						{
							this.AttributeString = sAttr;
						}
						CHtmlStyleElementSelectorKeyAttributeClass attributeClass =new CHtmlStyleElementSelectorKeyAttributeClass();
                        int FirstEqual = sAttr.IndexOf('=');
						if(FirstEqual > -1)
						{
							if(FirstEqual > 1)
							{
								if(char.IsLetterOrDigit(sAttr[FirstEqual -1]) == false)
								{
                                    attributeClass.Name = sAttr.Substring(0, FirstEqual - 1);
                                    if((string.IsNullOrEmpty(attributeClass.Name) == false) && (commonHTML.FasterIsWhiteSpaceLimited(attributeClass.Name[0]) == true || commonHTML.FasterIsWhiteSpaceLimited(attributeClass.Name[attributeClass.Name.Length -1]) == true))
                                    {
                                        attributeClass.Name = attributeClass.Name.Trim();
                                    }
                                    attributeClass.OperatorType = GetAttributeOperatorType(sAttr.Substring(FirstEqual - 1, 2));

                                    string strValue = sAttr.Substring(FirstEqual + 1);
                                    if (strValue.Length > 0 && (strValue[0] == '\'' || strValue[0] == '\"'))
                                    {
                                        strValue = ___replaceQuoteChar(strValue);
                                    }
                                    if (string.IsNullOrEmpty(strValue) == false)
                                    {
                                        if (commonHTML.FasterIsWhiteSpaceLimited(strValue[0]) || commonHTML.FasterIsWhiteSpaceLimited(strValue[strValue.Length - 1]))
                                        {
                                            strValue = strValue.Trim();
                                        }
                                    }
                                    attributeClass.Value = strValue;

								}
								else
								{
                                    attributeClass.Name = sAttr.Substring(0, FirstEqual);
                                    if ((string.IsNullOrEmpty(attributeClass.Name) == false) && (commonHTML.FasterIsWhiteSpaceLimited(attributeClass.Name[0]) == true || commonHTML.FasterIsWhiteSpaceLimited(attributeClass.Name[attributeClass.Name.Length - 1]) == true))
                                    {
                                        attributeClass.Name = attributeClass.Name.Trim();
                                    }
                                    attributeClass.OperatorType = CSSSelectorKeyOperataorType.equals;
									if(sAttr.Length > FirstEqual + 1 && sAttr[FirstEqual +1] != '=')
									{
                                        string sAttrValue  = sAttr.Substring(FirstEqual +1);
                                        if (sAttrValue.Length > 0 && (sAttrValue[0] == '\'' || sAttrValue[0] == '\"'))
                                        {
                                            sAttrValue = ___replaceQuoteChar(sAttrValue);
                                        }
                                        if (string.IsNullOrEmpty(sAttrValue) == false && (commonHTML.FasterIsWhiteSpaceLimited(sAttrValue[0]) || commonHTML.FasterIsWhiteSpaceLimited(sAttrValue[sAttrValue.Length - 1])))
                                        {
                                            attributeClass.Value = sAttrValue.Trim();
                                        }
                                        else
                                        {
                                            attributeClass.Value = sAttrValue;
                                        }
									}
									else
									{
										if(sAttr.Length > FirstEqual + 2)
										{
                                            string sAttrValue = sAttr.Substring(FirstEqual + 2);
                                            if (sAttrValue.Length > 0 && (sAttrValue[0] == '\'' || sAttrValue[0] == '\"'))
                                            {
                                                sAttrValue = ___replaceQuoteChar(sAttrValue);
                                            }
                                            if (string.IsNullOrEmpty(sAttrValue) == false && (commonHTML.FasterIsWhiteSpaceLimited(sAttrValue[0]) || commonHTML.FasterIsWhiteSpaceLimited(sAttrValue[sAttrValue.Length - 1])))
                                            {
                                                attributeClass.Value = sAttrValue.Trim();
                                            }
                                            else
                                            {
                                                attributeClass.Value = sAttrValue;
                                            }
										}
										else
										{
											attributeClass.Value = "";
										}
									}
								}
							}
							else
							{
								continue;
							}
						}
						else
						{
                            attributeClass.Name = sAttr;
                            if ((string.IsNullOrEmpty(attributeClass.Name) == false) && (commonHTML.FasterIsWhiteSpaceLimited(attributeClass.Name[0]) == true || commonHTML.FasterIsWhiteSpaceLimited(attributeClass.Name[attributeClass.Name.Length - 1]) == true))
                            {
                                attributeClass.Name = attributeClass.Name.Trim();
                            }
						}
						if(string.IsNullOrEmpty(attributeClass.Value) == false)
						{
							RemoveQuoteFromAttributeClassValue(attributeClass);
						}

						//this.___attributeKeyList.Add(attributeClass);
                        if (this.___attributeKeyList == null)
                        {
                            this.___attributeKeyList = new System.Collections.Generic.Dictionary<string, CHtmlStyleElementSelectorKeyAttributeClass?>(StringComparer.OrdinalIgnoreCase); 
                        }
						this.___attributeKeyList[attributeClass.Name] = attributeClass;
						if(basestyleElement != null)
						{
                            if (basestyleElement.___AttributesBulkTitleList == null)
                            {
                                basestyleElement.___AttributesBulkTitleList = new System.Collections.Generic.Dictionary<string, ushort>(StringComparer.Ordinal);
                            }
                            if (basestyleElement.___AttributesBulkTitleList.ContainsKey(attributeClass.Name) == false)
                            {
                                basestyleElement.___AttributesBulkTitleList[attributeClass.Name] = 1;
                                basestyleElement.___AttributesItemCount++;
                            }
                            if (string.IsNullOrEmpty(attributeClass.Value) == false)
                            {
                                basestyleElement.___SelectorRanking = basestyleElement.___SelectorRanking + 13;
                            }
                            else
                            {
                                basestyleElement.___SelectorRanking = basestyleElement.___SelectorRanking + 11;
                            }
						}

						AttribtePos++;
					}
					catch(Exception ex)
					{
						commonLog.LogEntry("CHtmlStyleKey",ex);
					}
				}
			}
            if (string.IsNullOrEmpty(this.TagName) == false && this.TagName.Length == 1 &&  this.TagName[0] == '*' && string.IsNullOrEmpty(this.CssID) == true && string.IsNullOrEmpty(this.CssClass) == true)
            {
                if ((this.___SelectorKeyDefinedField & CHtmlSelectorKeyClassType.Wildcard) != CHtmlSelectorKeyClassType.Wildcard)
                {
                    this.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField | CHtmlSelectorKeyClassType.Wildcard;
                }
                if (basestyleElement != null)
                {
                    basestyleElement.___SelectorRanking = basestyleElement.___SelectorRanking + 1;
                }
            }
            else if(string.IsNullOrEmpty(this.CssID) ==true && string.IsNullOrEmpty(this.TagName) == true && string.IsNullOrEmpty(this.CssClass) == true)
			{
				this.TagName = "*";
                if ((this.___SelectorKeyDefinedField & CHtmlSelectorKeyClassType.Wildcard) != CHtmlSelectorKeyClassType.Wildcard)
                {
                    this.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField | CHtmlSelectorKeyClassType.Wildcard;
                }
				if(basestyleElement != null)
				{
					basestyleElement.___SelectorRanking = basestyleElement.___SelectorRanking + 1;
				}
			}

			//this.___SelectorKeyDefinedField = CHtmlSelectorKeyClassType.NotSet;
			if(string.IsNullOrEmpty(this.TagName) == false)
			{
				
				if(this.TagName.Length != 0 && this.TagName[0] != '*' )
				{
                    if ((this.___SelectorKeyDefinedField & CHtmlSelectorKeyClassType.Wildcard) != CHtmlSelectorKeyClassType.TagName)
                    {
                        this.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField | CHtmlSelectorKeyClassType.TagName;
                    }
					if(basestyleElement != null)
					{
						basestyleElement.___SelectorRanking = basestyleElement.___SelectorRanking + 1;
					}
				}
			}
			if(string.IsNullOrEmpty(this.CssID) == false)
			{
                if ((this.___SelectorKeyDefinedField & CHtmlSelectorKeyClassType.Wildcard) != CHtmlSelectorKeyClassType.ID)
                {
                    this.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField | CHtmlSelectorKeyClassType.ID;
                }
                if (string.IsNullOrEmpty(this.TagName) == false)
                {
                    if ((this.___SelectorKeyDefinedField & CHtmlSelectorKeyClassType.Wildcard) != CHtmlSelectorKeyClassType.TagName_ID_Combination)
                    {
                        this.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField | CHtmlSelectorKeyClassType.TagName_ID_Combination;
                    }
                }
				if(basestyleElement != null)
				{
					basestyleElement.___SelectorRanking = basestyleElement.___SelectorRanking + 250;
				}
			}
           
			if(string.IsNullOrEmpty(this.CssClassLowSimple) == false)
			{
                if ((this.___SelectorKeyDefinedField & CHtmlSelectorKeyClassType.Wildcard) != CHtmlSelectorKeyClassType.ClassName)
                {
                    this.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField | CHtmlSelectorKeyClassType.ClassName;
                }
                if (string.IsNullOrEmpty(this.TagName) == false)
                {
                    this.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField | CHtmlSelectorKeyClassType.TagName_ClassName_Combination;
                    if (string.IsNullOrEmpty(this.CssID) == false)
                    {
                        this.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField | CHtmlSelectorKeyClassType.TagName_ClassName_ID_Combination;
                        goto ClassDone;

                    }
                }
                if (string.IsNullOrEmpty(this.CssID) == false)
                {
                    this.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField | CHtmlSelectorKeyClassType.ClassName_ID_Combinaion;

                }
			}
            ClassDone:
			if(this.___attributeKeyList != null && this.___attributeKeyList.Count > 0)
			{
				this.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField | CHtmlSelectorKeyClassType.Attribute;
			}
			if(this.Prefix.Length != 0)
			{
				this.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField | CHtmlSelectorKeyClassType.Prefix;
			}
            if (this.___pseudoTitleParamList != null && this.___pseudoTitleParamList.Count > 0)
			{
				this.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField | CHtmlSelectorKeyClassType.Sufix;
			}
			// --------------------------------------------------------------------------------
			// Check SelectrKeyClass Mode
			// [TagOnly]
			//    Selector Key Class Only Lookup TagName Only
			// [ClassOnly]
			//    Selector Key Class Only Lookup ClassName Only
			// [IDOnly]
			//    Selector Key Class Only Lookup ID Only
			// --------------------------------------------------------------------------------
			if( ___Prefix.Length == 0 &&  ___Sufix.Length == 0 && ___AttributeLookup.Length == 0)
			{
				if(___TagName.Length != 0 && ___CssClass.Length == 0 && ___CssID.Length == 0)
				{
					this.___StyleSelectorKeyDataMode = CHtmlStyleSelectorKeyDataModeType.TagOnly;
				}
				else if(___TagName.Length == 0 && ___CssClass.Length != 0 && ___CssID.Length == 0)
				{
					this.___StyleSelectorKeyDataMode = CHtmlStyleSelectorKeyDataModeType.ClassOnly;

				}
				else if(___TagName.Length == 0 && ___CssClass.Length == 0 && ___CssID.Length != 0)
				{
					this.___StyleSelectorKeyDataMode = CHtmlStyleSelectorKeyDataModeType.IDOnly;
				}
			}
			this.GetSingleName();
		}
		public static void RemoveQuoteFromAttributeClassValue(CHtmlStyleElementSelectorKeyAttributeClass _attrClass)
		{

                if (string.IsNullOrEmpty(_attrClass.Value)== false)
                {
                    if (_attrClass.Value[0] == '\'')
                    {
                        _attrClass.Value = _attrClass.Value.Remove(0, 1);
                        if (_attrClass.Value[_attrClass.Value.Length - 1] == '\'')
                        {
                            _attrClass.Value = _attrClass.Value.Remove(_attrClass.Value.Length - 1, 1);
                        }
                    }
                    else
                        if (_attrClass.Value[0] == '\"')
                        {
                            _attrClass.Value = _attrClass.Value.Remove(0, 1);
                            if (_attrClass.Value[_attrClass.Value.Length - 1] == '\"')
                            {
                                _attrClass.Value = _attrClass.Value.Remove(_attrClass.Value.Length - 1, 1);
                            }
                        }
                }
			
		}
		public void SetCssClass(string value)
		{
			
			this.CssClass = value;

			if(value.Length > 0 && value[0] == '.')
			{
				this.CssClassLowSimple = commonHTML.FasterToLower(value.Remove(0,1));
			}
			else if(value.Length > 0)
			{
				this.CssClassLowSimple = commonHTML.FasterToLower(value);
			}
		}
			
	
		/*
		public CHtmlDomTokenList classList
		{
			___getInner{return this._classList;}
		}
		public CHtmlCollection attributeKeyList
		{
			___getInner{return this._attributeKeyList;}
		}
		*/
		/* CssClassSplit is move to CHTMLClaassList
		public string[] CssClassSplit
		{
			___getInner{return this._CssClassSplit;}
			set{this._CssClassSplit =value;}
		}
		*/


		public void SetCssID(string value)
		{
			
			this.CssID = value;
			if(string.IsNullOrEmpty(value) == false && value[0] == '#')
			{
				this.CssIDLowSimple = commonHTML.FasterToLower(value.Remove(0,1));
			}
			else if(value.Length > 0)
			{
                this.CssIDLowSimple = commonHTML.FasterToLower(value);
			}
		}
		/*
		public string Prefix
		{
			set
			{
				this._Prefix  = value;
				//_ResetName = true;
			}
			___getInner{return this._Prefix;}
		}
		public string Sufix
		{
			set
			{
				this._Sufix  = value;
				//_ResetName = true;
			}
			___getInner{return this._Sufix;}
		}
		public string Attribute
		{
			set{this._Attribute =value;}
			___getInner{return this._Attribute;}
		}
		*/



		public override string ToString()
		{
			if(_ResetName == true)
			{
				GetSingleName();
			}
			return  this.SortShortName;
		}
        public static string ___replaceQuoteChar(string s)
        {
            
            char charLast = s[s.Length - 1];
            if (charLast == '\'' || charLast == '\"')
            {
                return s.Substring(1, s.Length - 2);
            }
            else
            {
                int LastQuotePos = s.LastIndexOf(s[0]);
                if (LastQuotePos > 0)
                {
                    return s.Substring(1, LastQuotePos - 1);
                }
                else
                {
                    return s.Substring(1);
                }
            }
        }
		private void GetSingleName()
		{
			this.SortShortName =   TagName + CssID + CssClass;
			this._ResetName = false;
		}

        /// <summary>
        /// This method is true if all selectors classname is matches for __ClassList
        /// </summary>
        /// <param name="__element"></param>
        /// <returns></returns>
        public bool IsElementClassesMates(CHtmlDomTokenList ___ClassList)
        {
            int __MatchCount = 0;
            int ___classListCount = ___ClassList.Count;
            for (int i = 0; i < ___classListCount; i++)
            {
                string __Key = ___ClassList[i] as string;

                if (this.___classList.ContainsKey(__Key))
                {
                    __MatchCount++;
                }
                else
                {
                    break;
                }
            }
            if (__MatchCount == this.___classList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// This method is true if one of selectors classname is matches for __ClassList
        /// </summary>
        /// <param name="__element"></param>
        /// <returns></returns>
        public bool IsElementClassesMatesOneOfClassList(CHtmlDomTokenList  ___ClassList)
		{

            int ___classListCount = ___ClassList.Count;
			for(int i = 0; i < ___classListCount ; i ++)
			{
                string __Key = ___ClassList[i] as string;

				if(this.___classList.ContainsKey(__Key))
				{
                    return true;
                    
                }else 
                {
                    continue;
                }

			}

            return false;
		}



        public bool IsTagElementFormTagType(CHtmlElement tagElement)
		{
			switch(tagElement.___elementTagType)
			{
				case CHtmlElementType.FORM:
				case CHtmlElementType.INPUT:
				case CHtmlElementType.SELECT:
				case CHtmlElementType.TEXTAREA:
					return true;
			}
			return false;
		}
        private bool IsElementTagNameMathesAndNotWildCard(CHtmlElement tagElement)
        {
            if (string.IsNullOrEmpty(this.TagName) == true || (this.TagName.Length == 1 && this.TagName[0] == '*'))
            {
                // if non tagname or wild card think it is mispatch.
                return false;
            }
            if (string.Equals(this.TagName, tagElement.tagName, StringComparison.Ordinal) == false)
            {
                // nth-of-type must match tagName
                return false;


            }
            return true;
        }
        private bool IsElementMatchesCSSLastNthXAnalysis(CHtmlElement element, CHtmlPseudoClassType ___pseuduType, CHtmlStyleElementPseudoClassValue? __pseudoValueNullable)
        {
            try
            {
                CHtmlStyleElementPseudoClassValue __pseudoValue;
                CHtmlStyleElementPseudoClassValueType __pseudoValueValueType = CHtmlStyleElementPseudoClassValueType.NotSelected;
                if (__pseudoValueNullable != null)
                {
                    __pseudoValue = __pseudoValueNullable.Value;
                    __pseudoValueValueType = __pseudoValue.ValueType;
                }
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 50)
                {
                   commonLog.LogEntry("CSS last-of-x analysis enter {0} : {1} : {2}", element, ___pseuduType, __pseudoValueNullable);
                }
                bool ___IsParentDynamicElement;
                CHtmlElement ___parentElement = element.___parent as CHtmlElement;
                CHtmlCollection ___ChildList = null;
                if (___parentElement == null)
                {
                    return false;
                }
                else
                {
                    ___IsParentDynamicElement = ___parentElement.___IsDynamicElement;
                    if (___IsParentDynamicElement == true)
                    {
                        ___ChildList = ___parentElement.___childNodes;
                        goto LookupListPhase;

                    }
                    else if (___parentElement.___childNodesQuickList != null)
                    {
                        ___ChildList = ___parentElement.___childNodesQuickList;
                        goto LookupListPhase;
                    }

                }
                if (___IsParentDynamicElement == false)
                {
                    CHtmlDocument ___baseDoc = element.___Document;
                    if (___baseDoc == null || ___baseDoc.___documentDomType != CHtmlDomModeType.HTMLDOM)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                        {
                           commonLog.LogEntry("CSS analysis fails due to inappropiate document");
                        }
                        return false;
                    }
                    else
                    {

                        if (___baseDoc.___HtmlBuilder == null)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                            {
                               commonLog.LogEntry("CSS analysis fails due to inappropiate HTMLBuilder");
                            }
                            return false;

                        }
                        else
                        {
                            /*
                            ___parentElement.___childNodesQuickList = commonCreateElementChildrenQuickList(___baseDoc, ___parentElement);
                            ___ChildList = ___parentElement.___childNodesQuickList;
                            */
                            goto LookupListPhase;
                        }
                    }
                }
                LookupListPhase:
                if (___ChildList == null)
                {
                    return false;
                }
                switch (___pseuduType)
                {
                    case CHtmlPseudoClassType.LastChildPseudoClass:
                        if (___ChildList.Count <= 1)
                        {
                            return true;
                        }
                        else
                        {
                            CHtmlElement ___quickLast = ___ChildList[___ChildList.Count - 1] as CHtmlElement;
                            if (___quickLast != null)
                            {
                                if (string.Equals(___quickLast.tagName ,element.tagName, StringComparison.Ordinal) == true)
                                {
                                    if (___quickLast.___TagOpenStartPosition == element.___TagOpenStartPosition)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        break;
                    case CHtmlPseudoClassType.OnlyChildPseudoClass:
                        if (___ChildList.Count <= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case CHtmlPseudoClassType.OnlyOfTypePseudoClass:
                        if (___ChildList.Count == 0)
                        {
                            return false;
                        }
                        else if (___ChildList.Count == 1)
                        { 
                            // Only 1 child so. must be only of type
                            return true;
                        }
                        else
                        {
                            // Lookinto TagTypeList
                            if (___ChildList.___TagTypeCountList != null)
                            {
                                int TagCount = ___ChildList.___TagTypeCountList[(int)element.___elementTagType];
                                if (TagCount == 1)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }

                        }
                    case CHtmlPseudoClassType.LastOfTypePseudoClass:
                        if (___ChildList.Count == 0)
                        {
                            return false;
                        }
                        else if (___ChildList.Count == 1)
                        {
                            // Only 1 child so. must be last of type
                            return true;
                        }
                        else
                        {
                            // Lookinto TagTypeList
                            if (___ChildList.___TagTypeCountList != null   && ___ChildList.___TagTypeCountList.ContainsKey((int)element.___elementTagType) == true)
                            {
                                int TagCount = ___ChildList.___TagTypeCountList[(int)element.___elementTagType];
                                if (TagCount == element.___ElementNthOfNameType)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }

                        }
                    case CHtmlPseudoClassType.NthLastOfTypePseudoClass:
                        if (___ChildList.Count == 0)
                        {
                            return false;
                        }
                        else 
                        {

                            // Lookinto TagTypeList
                            if (___ChildList.___TagTypeCountList != null && ___ChildList.___TagTypeCountList.ContainsKey((int)element.___elementTagType) == true)
                            {
                                int TagCount = ___ChildList.___TagTypeCountList[(int)element.___elementTagType];
                                if (((int)__pseudoValueValueType >= (int)CHtmlStyleElementPseudoClassValueType.Num_0 && (int)__pseudoValueValueType <= (int)CHtmlStyleElementPseudoClassValueType.Num_36) == false)
                                {
                                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                                    {
                                       commonLog.LogEntry("TODO : nth-last-of-type analysis required");
                                    }
                                    return false;
                                }
                                if (TagCount - element.___ElementNthOfNameType == (int)__pseudoValueValueType)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }

                        }
                    case CHtmlPseudoClassType.NthLastChildPseudoClass:
                        if (___ChildList.Count == 0)
                        {
                            return false;
                        }
                        else
                        {
                            if (((int)__pseudoValueValueType >= (int)CHtmlStyleElementPseudoClassValueType.Num_0 && (int)__pseudoValueValueType <= (int)CHtmlStyleElementPseudoClassValueType.Num_36) == false)
                            {
                                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                                {
                                   commonLog.LogEntry("TODO : nth-last-child analysis required");
                                }
                                return false;
                            }
                            int TagCount = ___ChildList.Count;
                            if (TagCount - element.___ChildNodeIndex == (int)__pseudoValueValueType)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                  
                    default:
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                        {
                           commonLog.LogEntry("TODO : IsElementMatchesCSSLastNthXAnalysis required");
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                {
                   commonLog.LogEntry("IsElementMatchesCSSLastNthXAnalysis", ex);
                }

            }
            return false;
        }
		public bool IsSuffixMatchToElement(CHtmlElement tagElement)
		{
            int keyCount = this.___pseudoTitleParamList.Count;
			foreach(CHtmlPseudoClassType pseudoType in this.___pseudoTitleParamList.Keys)
			{
				CHtmlStyleElementPseudoClassValue __pseudoValue;

                switch (pseudoType)
				{
					case  CHtmlPseudoClassType.HoverPseudoClass:
						goto NextCheck;
					case  CHtmlPseudoClassType.LinkPseudoClass:
						if(tagElement.___elementTagType != CHtmlElementType.A)
						{
							return false;
						}
						goto NextCheck;
					case CHtmlPseudoClassType.ActivePseudoClass:
						if(tagElement.___elementTagType != CHtmlElementType.A)
						{
							return false;
						}
						goto NextCheck;
					case  CHtmlPseudoClassType.FirstChildPseudoClass:
						//CHtmlElement __parentElement = tagElement.parentAsElement;
						if(tagElement.___ChildNodeIndex == 0)
						{
							goto NextCheck;
						}
						else
						{
							return false;
						}
						//break;

					case CHtmlPseudoClassType.EmptyPseudoClass:
						if(tagElement.___IsTagImmediateClosed == true)
						{
							goto NextCheck;
						}
						else
						{
							return false;
						}
;
					case CHtmlPseudoClassType.RootPseudoClass:
						if(tagElement.___elementTagType == CHtmlElementType.HTML)
							goto NextCheck;
						else
							return false;
					case CHtmlPseudoClassType.IndeterminatePseudoClass:
						if(tagElement.___elementTagType != CHtmlElementType.INPUT)
							return false;
						if(tagElement.@checked == false)
						{
							goto NextCheck;
						}
						else
						{
							return false;
						}
					case CHtmlPseudoClassType.DirPseudoClass:
						if(tagElement.___Document == null)
						{
							return false;
						}
						else
						{
                            if (this.___pseudoTitleParamList != null)
                            {
                                CHtmlStyleElementPseudoClassValue? __pseudoValueNulable = this.___pseudoTitleParamList[pseudoType];
                                if (__pseudoValueNulable != null)
                                {
                                    __pseudoValue = __pseudoValueNulable.Value;
                                    if (__pseudoValue.value is string)
                                    {
                                        string strDir = __pseudoValue.value as string;
                                        if (string.Equals(tagElement.___Document.dir, strDir, StringComparison.Ordinal) == true)
                                        {
                                            goto NextCheck;
                                        }
                                    }
                                    return false;
                                }
                                else
                                {
                                    return false;
                                }
                            }
						}
                        break;
					case CHtmlPseudoClassType.LangPseudoClass:
						if(tagElement.___attributes.Count > 0)
						{
							string __langValue = "";
							if(tagElement.___attributes.ContainsKey("lang"))
							{
								__langValue = commonHTML.GetElementAttributeInString(tagElement, "lang");

							}
							else if(tagElement.___attributes.ContainsKey("html:lang"))
							{
								__langValue = commonHTML.GetElementAttributeInString(tagElement, "html:lang");

							}
							else if(tagElement.___attributes.ContainsKey("xml:lang"))
							{
								__langValue = commonHTML.GetElementAttributeInString(tagElement, "xml:lang");
							}
                            if (__langValue.Length == 0)
                            {
                                goto NextCheck;
                            }
                            if (this.___pseudoTitleParamList != null)
                            {
                                CHtmlStyleElementPseudoClassValue? __pseudoValueNulable = this.___pseudoTitleParamList[pseudoType];
                                if (__pseudoValueNulable == null)
                                {
                                    goto NextCheck;
                                }
                                else
                                {
                                    __pseudoValue = __pseudoValueNulable.Value;
                                    if (__pseudoValue.value is string)
                                    {

                                        if (string.Equals(__langValue, __pseudoValue.value as string, StringComparison.Ordinal) == true)
                                        {
                                            goto NextCheck;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        goto NextCheck;
                                    }
                                }
                            }

						}
						return false;
					case CHtmlPseudoClassType.TargetPseudoClass:
						// Target seems to complicate to process. Just do not apply
						if(tagElement.___elementTagType == CHtmlElementType.A)
						{
							return false;
						}
						else
						{
							return false;
						}
						
					case CHtmlPseudoClassType.FocusPseudoClass:

						if(IsTagElementFormTagType(tagElement) == false)
						{
							return false;
						}
						else
						{
							goto NextCheck;
						}
					case CHtmlPseudoClassType.PlaceHolderPseudoClass:
						if(IsTagElementFormTagType(tagElement) == false)
						{
							return false;
						}
						else
						{
							goto NextCheck;
						}
					case CHtmlPseudoClassType.ValidPseudoClass:
					case CHtmlPseudoClassType.InvalidPseudoClass:
						if(IsTagElementFormTagType(tagElement) == false)
						{
							return false;
						}
						else
						{
							goto NextCheck;
						}
	
					case CHtmlPseudoClassType.SearchDecorationPseudoClass:
						if(IsTagElementFormTagType(tagElement) == false)
						{
							return false;
						}
						else
						{
							goto NextCheck;
						}
					
					case  CHtmlPseudoClassType.SearchCancelButton:
						if(IsTagElementFormTagType(tagElement) == false)
						{
							return false;
						}
						else
						{
							goto NextCheck;
						}
					case CHtmlPseudoClassType.WarningPseudoClass:
						// Pseudo :waring is not normal. may be error
						return false;

					case CHtmlPseudoClassType.RequiredPseudoClass:
						if(tagElement.___elementTagType != CHtmlElementType.INPUT && tagElement.___elementTagType != CHtmlElementType.TEXTAREA)
						{
							return false;
						}
						else
						{
							if(tagElement.___attributes.ContainsKey("required") == true)
							{
								goto NextCheck;
							}
							else
							{
								return false;
							}
						}
					case CHtmlPseudoClassType.OptionalPseudoClass:
						if(tagElement.___elementTagType != CHtmlElementType.INPUT && tagElement.___elementTagType != CHtmlElementType.TEXTAREA)
						{
							return false;
						}
						else
						{
							if(tagElement.___attributes.ContainsKey("required") == true)
							{
								return false;
							}
							else
							{
								goto NextCheck;
							}
						}
                    case  CHtmlPseudoClassType.VisitedPseudoClass:
                        return false;

					case CHtmlPseudoClassType.DisabledPseudoClass:
						if(IsTagElementFormTagType(tagElement) == false)
						{
							return false;
						}
						if(tagElement.___attributes.ContainsKey("disabled"))
						{
							if(tagElement.disabled == true)
							{
								goto NextCheck;
							}
							else
							{
								return false;
							}
						}
						else
						{
							return false;
						}
					case CHtmlPseudoClassType.EnabledPseudoClass:
						if(IsTagElementFormTagType(tagElement) == false)
						{
							return false;
						}
						if(tagElement.___attributes.ContainsKey("disabled"))
						{
							if(tagElement.disabled == false)
							{
								goto NextCheck;
							}
							else
							{
								return false;
							}
						}
						else
						{
							return false;
						}
					case CHtmlPseudoClassType.ReadOnlyPseudoClass:
						if(IsTagElementFormTagType(tagElement) == false)
						{
							return false;
						}
						if(tagElement.@readonly == true)
						{
							goto NextCheck;
						}
						else
						{
							return false;
						}
					case CHtmlPseudoClassType.AfterPseudoClass:
					case CHtmlPseudoClassType.BeforePseudoClass:
						goto NextCheck;
					case CHtmlPseudoClassType.NthChildPseudoClass:
                        if (this.___pseudoTitleParamList != null)
                        {
                            CHtmlStyleElementPseudoClassValue? __pseudoValueNulable = this.___pseudoTitleParamList[pseudoType];
                            if (__pseudoValueNulable == null)
                            {
                                return false;
                            }
                            else
                            {
                                __pseudoValue = __pseudoValueNulable.Value;
                                CHtmlStyleElementPseudoClassValueType __pseudoValueValueType = __pseudoValue.ValueType;

                                int _paramValue = (int)__pseudoValueValueType;
                                if (_paramValue >= 0 && _paramValue <= 36)
                                {
                                    if (tagElement.___ChildNodeIndex + 1 == _paramValue)
                                    {
                                        goto NextCheck;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else if (__pseudoValue.ValueType == CHtmlStyleElementPseudoClassValueType.Num_Even)
                                {
                                    if (((tagElement.___ChildNodeIndex + 1) & 1) == 0)
                                    {
                                        // It's even
                                        goto NextCheck;
                                    }
                                    else
                                    {
                                        return false;
                                        // It's odd
                                    }
                                }
                                else if (__pseudoValue.ValueType == CHtmlStyleElementPseudoClassValueType.Num_Odd)
                                {
                                    if (((tagElement.___ChildNodeIndex + 1) & 1) == 0)
                                    {
                                        // It's even
                                        return false;
                                    }
                                    else
                                    {
                                        goto NextCheck;
                                        // It's odd
                                    }
                                }
                            }
                        }
						return false;
                    case  CHtmlPseudoClassType.NthLastChildPseudoClass:
                        if (tagElement.___DOM_Level <= commonHTML.Pseudo_TagPrefech_Allowed_DOM_LEVEL)
                        {
                            return false;
                        }
                        if (IsElementMatchesCSSLastNthXAnalysis(tagElement, CHtmlPseudoClassType.NthLastChildPseudoClass, this.___pseudoTitleParamList[pseudoType]) == false)
                        {
                            return false;
                        }
                        else
                        {
                            goto NextCheck;

                        }
                    case CHtmlPseudoClassType.NthLastOfTypePseudoClass:
                        if (tagElement.___DOM_Level <= commonHTML.Pseudo_TagPrefech_Allowed_DOM_LEVEL)
                        {
                            return false;
                        }
                        if (IsElementMatchesCSSLastNthXAnalysis(tagElement, CHtmlPseudoClassType.NthLastOfTypePseudoClass,  this.___pseudoTitleParamList[pseudoType]) == false)
                        {
                            return false;
                        }
                        else
                        {
                            goto NextCheck;
                        }

                    case CHtmlPseudoClassType.LastOfTypePseudoClass:
                        if (tagElement.___DOM_Level <= commonHTML.Pseudo_TagPrefech_Allowed_DOM_LEVEL)
                        {
                            return false;
                        }
                        if (IsElementMatchesCSSLastNthXAnalysis(tagElement, CHtmlPseudoClassType.LastOfTypePseudoClass,null) == false)
                        {
                            return false;
                        }
                        else
                        {
                            goto NextCheck;
                        }

                    case CHtmlPseudoClassType.OnlyOfTypePseudoClass:
                        if (IsElementMatchesCSSLastNthXAnalysis(tagElement, CHtmlPseudoClassType.OnlyOfTypePseudoClass, null) == false)
                        {
                            return false;
                        }
                        else
                        {
                            goto NextCheck;
                        }
                    case CHtmlPseudoClassType.OnlyChildPseudoClass:
                        if (IsElementMatchesCSSLastNthXAnalysis(tagElement, CHtmlPseudoClassType.OnlyChildPseudoClass, null) == false)
                        {
                            return false;
                        }
                        else
                        {
                            goto NextCheck;
                        }
                    case CHtmlPseudoClassType.LastChildPseudoClass:
                        if (tagElement.___DOM_Level <= commonHTML.Pseudo_TagPrefech_Allowed_DOM_LEVEL)
                        {
                            return false;
                        }
                        if (IsElementMatchesCSSLastNthXAnalysis(tagElement, CHtmlPseudoClassType.LastChildPseudoClass, null) == false)
                        {
                            return false;
                        }
                        else
                        {
                            goto NextCheck;
                        }
					case CHtmlPseudoClassType.FirstOfTypePseudoClass:
					case CHtmlPseudoClassType.NthOfTypePseudoClass:
					
					
                        if (IsElementTagNameMathesAndNotWildCard(tagElement) == false)
                        {
                            return false;
                        }
						else
						{

                            int __SeachType = -1;
                            if (pseudoType == CHtmlPseudoClassType.FirstOfTypePseudoClass)
                            {
                                if (tagElement.___ElementNthOfNameType == 1)
                                {
                                    goto NextCheck;
                                }
                                else
                                {
                                    return false;
                                }
                               
                            }
                            else if (pseudoType == CHtmlPseudoClassType.NthOfTypePseudoClass)
                            {
                                __SeachType = 2;
                            }
                            if (__SeachType == 2)
                            {
                                if (this.___pseudoTitleParamList != null)
                                {
                                    CHtmlStyleElementPseudoClassValue? __pseudoValueNulable = this.___pseudoTitleParamList[pseudoType];
                                    if (__pseudoValueNulable == null)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        __pseudoValue = __pseudoValueNulable.Value;


                                        int pseudoNthOfTypeNumber = (int)__pseudoValue.ValueType;
                                        if (pseudoNthOfTypeNumber >= 0 && pseudoNthOfTypeNumber <= 36)
                                        {   // Means Between Number 0 to 36
                                            if (tagElement.___ElementNthOfNameType == pseudoNthOfTypeNumber)
                                            {
                                                goto NextCheck;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                            return false;
						}
                    case CHtmlPseudoClassType.MatchesConditionPseudoClass:
                    case CHtmlPseudoClassType.NotConditionPseudoClass:
                        if (this.___pseudoTitleParamList != null)
                        {
                            CHtmlStyleElementPseudoClassValue? __pseudoValueNulable = this.___pseudoTitleParamList[pseudoType];
                            if (__pseudoValueNulable == null)
                            {
                                return false;
                            }
                            else
                            {
                                __pseudoValue = __pseudoValueNulable.Value;

                                if (__pseudoValue.SubStyleElementList != null)
                                {
                                    for (int z = __pseudoValue.SubStyleElementList.Count - 1; z >= 0; z--)
                                    {
                                        CHtmlCSSRule __subStyle = __pseudoValue.SubStyleElementList[z] as CHtmlCSSRule;
                                        if (__subStyle != null)
                                        {
                                            bool IsSubStyleMatches = commonHTML.IsStyleElementWorkingSelectorListMatchesForElement(tagElement, __subStyle.___styleKeyOrignalList);

                                            if (__subStyle.___styleConditionType == CSSStyleConditionType.PseudoMatchesCondition)
                                            {
                                                if (IsSubStyleMatches == true)
                                                {
                                                    goto NextCheck;
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                            }
                                            else if (__subStyle.___styleConditionType == CSSStyleConditionType.PseudoNotCondition)
                                            {
                                                if (IsSubStyleMatches == true)
                                                {
                                                    return false;
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                    // End of for-loop
                                    if (__pseudoValue.ValueType == CHtmlStyleElementPseudoClassValueType.Matches)
                                    {
                                        // if none of matches, it is fail.
                                        return false;
                                    }
                                    else if (__pseudoValue.ValueType == CHtmlStyleElementPseudoClassValueType.Not)
                                    {
                                        // If None of matches it is Denied status. Continue
                                        goto NextCheck;
                                    }

                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                            break;
                    case CHtmlPseudoClassType.UnknownPseudoClass:
                            return false;
                   
					default:
					{
						// Any Pseudo Not defined code above are treated as non-applyable pseudo class
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 50)
                        {
                           commonLog.LogEntry("CSS : " + pseudoType.ToString() + " pseudo class ignored...");
                        }
						return false;
					}
				}
			NextCheck:
				continue;
			}
			return true;
		}
		public CHtmlStyleKey CloneKey()
		{
			CHtmlStyleKey newKey = new CHtmlStyleKey();
            newKey.___elementTagType = this.___elementTagType;
			if(string.IsNullOrEmpty(this.TagName) == false)
			{
				newKey.TagName = string.Copy(this.TagName);
			}
			if(string.IsNullOrEmpty(this.CssClass) == false)
			{
				newKey.CssClass = string.Copy(this.CssClass);
			}
			if(string.IsNullOrEmpty(this.CssClassLowSimple)== false)
			{
				newKey.CssClassLowSimple = string.Copy(this.CssClassLowSimple);
			}
			if(string.IsNullOrEmpty(this.CssID) == false)
			{
				newKey.CssID = string.Copy(this.CssID);
			}
			if(string.IsNullOrEmpty(this.CssIDLowSimple) == false)
			{
				newKey.CssIDLowSimple = string.Copy(this.CssIDLowSimple);
			}
			if(string.IsNullOrEmpty(this.AttributeString) == false)
			{
				newKey.AttributeString = string.Copy(this.AttributeString);
			}

			if(string.IsNullOrEmpty(this.Prefix) == false)
			{
				newKey.Prefix = string.Copy(this.Prefix);
			}

		
			newKey.Combinator = this.Combinator;
			
			if(string.IsNullOrEmpty(this.SortShortName) == false)
			{
				newKey.SortShortName = string.Copy(this.SortShortName);
			}
			if(this.___classList.Count > 0)
			{

				newKey.___classList.___CopyFromClassList(this.___classList);

			}
			/*
			if(this.___pseudoList.Count  > 0)
			{
				newKey.___pseudoList.AddRange(this.___pseudoList.Clone() as ICollection);
			}
			*/
            int pseudoCount = 0;
            if (this.___pseudoTitleParamList != null)
            {
                pseudoCount = this.___pseudoTitleParamList.Count;
            }
            if (pseudoCount > 0)
			{
                newKey.___pseudoTitleParamList = new System.Collections.Generic.Dictionary<CHtmlPseudoClassType, CHtmlStyleElementPseudoClassValue?>();
                foreach(CHtmlPseudoClassType keyPseudo in this.___pseudoTitleParamList.Keys)
				{

                    CHtmlStyleElementPseudoClassValue? pseudoClassNullable = this.___pseudoTitleParamList[keyPseudo];
                    if (pseudoClassNullable == null)
                    {
                        continue;
                    }
                    newKey.___pseudoTitleParamList[keyPseudo] = pseudoClassNullable.Value;
				}
			}
            int attrCount = 0;
            if (this.___attributeKeyList != null)
            {
                attrCount = this.___attributeKeyList.Count;
            }
            if (attrCount > 0)
			{
                newKey.___attributeKeyList = new System.Collections.Generic.Dictionary<string, CHtmlStyleElementSelectorKeyAttributeClass?>(StringComparer.OrdinalIgnoreCase);
				foreach(  CHtmlStyleElementSelectorKeyAttributeClass? oriAttrNullable in this.___attributeKeyList.Values)
				{
						if(oriAttrNullable == null)
							continue;
                        CHtmlStyleElementSelectorKeyAttributeClass oriAttr = oriAttrNullable.Value;
						CHtmlStyleElementSelectorKeyAttributeClass copyAttr = oriAttr.CloneCHtmlStyleElementSelectorKeyAttributeClass();
						newKey.___attributeKeyList[copyAttr.Name] = copyAttr;
					
				}
			}
			//newKey.PseudoClassParamteterType = this.PseudoClassParamteterType;
			newKey.___StyleSelectorKeyDataMode = this.___StyleSelectorKeyDataMode;

			newKey.___SelectorKeyDefinedField = this.___SelectorKeyDefinedField;
			
			newKey._ResetName = false;
			return newKey;

		}
        internal static void CreateSubStyleSelectorKeyClass(CHtmlStyleElementPseudoClassValue pseudoClass, CSSStyleConditionType  ___pseudoType)
        {
            try
            {
                string strTitle = pseudoClass.value as string;
                if (strTitle.IndexOf("\\:", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    strTitle = strTitle.Replace("\\:", ":");
                }
                if (pseudoClass.SubStyleElementList == null)
                {
                    pseudoClass.SubStyleElementList = new ArrayList();
                }
                System.Collections.Generic.List<string> arTitle = commonHTML.GetSelectorIDSplit(strTitle);
                int arTitleCount = arTitle.Count;
                for (int pos = 0; pos < arTitleCount; pos++)
                {
                    string ElemTitle = arTitle[pos];
                    // ======Unwanted Replace Spaces ===========
                    if (commonHTML.FasterIsWhiteSpaceLimited(ElemTitle[0]) || commonHTML.FasterIsWhiteSpaceLimited(ElemTitle[ElemTitle.Length - 1]))
                    {
                        ElemTitle = ElemTitle.Trim(commonHTML.CharSpaceCrLfTabZentakuSpace);
                    }

                    System.Collections.Generic.List<CHtmlStyleKey> arSelectorKeyClassList = CHtmlCSSRuleGroundList.CreateCHtmlStyleKeyList(ElemTitle, null);
                    CHtmlCSSRule ___subStyle = new CHtmlCSSRule(CHtmlElementStyleType.None);
                    ___subStyle.___styleConditionType  = ___pseudoType;
                    ___subStyle.SetSelectorIDDirect(ElemTitle);
                    if (___subStyle.___styleKeyOrignalList == null)
                    {
                        ___subStyle.___styleKeyOrignalList = new System.Collections.Generic.List<CHtmlStyleKey>();
                    }
                    ___subStyle.___styleKeyOrignalList.AddRange(arSelectorKeyClassList.ToArray());

                    pseudoClass.SubStyleElementList.Add(___subStyle);
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                {
                   commonLog.LogEntry("CreateSubStyleSelectorKeyClass Exception : " + pseudoClass.value.ToString(), ex);
                }
            }
        }
		
#region AnalyzePseudoClassValue
		internal static CHtmlStyleElementPseudoClassValue CreatePsudoValueClass(string pseudoTitle, CHtmlPseudoClassType pseudoType, string val, int valPos)
		{
			CHtmlStyleElementPseudoClassValue _pseudoClass =new CHtmlStyleElementPseudoClassValue();
            _pseudoClass.name = pseudoTitle;
			string innerValue = "";
			try
			{
				
				int EndPos = val.LastIndexOf(')');
			
				if(valPos > -1)
				{
                    if (EndPos > -1)
                    {
                        innerValue = val.Substring(valPos + 1, EndPos - valPos - 1);
                        switch (pseudoType)
                        {

                            case CHtmlPseudoClassType.LangPseudoClass:
                            case CHtmlPseudoClassType.DirPseudoClass:
                              
                                _pseudoClass.ValueType = CHtmlStyleElementPseudoClassValueType.Other;
                                _pseudoClass.value = commonHTML.FasterTrimAndToLower(innerValue);
                                return _pseudoClass;
                            case CHtmlPseudoClassType.MatchesConditionPseudoClass:
                                _pseudoClass.ValueType = CHtmlStyleElementPseudoClassValueType.Matches;
                                _pseudoClass.value = commonHTML.FasterTrimAndToLower(innerValue);
                                CreateSubStyleSelectorKeyClass(_pseudoClass,CSSStyleConditionType.PseudoMatchesCondition);
                                return _pseudoClass;
                            case CHtmlPseudoClassType.NotConditionPseudoClass:
                                _pseudoClass.ValueType = CHtmlStyleElementPseudoClassValueType.Not;
                                _pseudoClass.value = commonHTML.FasterTrimAndToLower(innerValue);
                                CreateSubStyleSelectorKeyClass(_pseudoClass, CSSStyleConditionType.PseudoNotCondition);
                                return _pseudoClass;

                            default:
                                break;
                        }
                        if (innerValue.Length >= 3)
                        {
                            if (string.Equals(innerValue, "odd", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                _pseudoClass.ValueType = CHtmlStyleElementPseudoClassValueType.Num_Odd;
                                _pseudoClass.value = innerValue;
                                return _pseudoClass;
                            }
                            else if (string.Equals(innerValue, "even", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                _pseudoClass.ValueType = CHtmlStyleElementPseudoClassValueType.Num_Even;
                                _pseudoClass.value = innerValue;
                                return _pseudoClass;
                            }
                        }

                        char[] cs = innerValue.ToCharArray();
                        bool _ContainsNonNumber = false;
                        foreach (char c in cs)
                        {
                            if (char.IsNumber(c) == false)
                            {
                                _ContainsNonNumber = true;
                                break;
                            }
                        }
                        if (_ContainsNonNumber == false)
                        {
                            int stringValue = -1;
                            try
                            {
                                stringValue = int.Parse(innerValue);

                                if (stringValue > 0 && stringValue <= 36)
                                {
                                    _pseudoClass.ValueType = (CHtmlStyleElementPseudoClassValueType)stringValue;
                                }
                                else
                                {
                                    _pseudoClass.ValueType = CHtmlStyleElementPseudoClassValueType.Num_Over36;

                                }
                                return _pseudoClass; ;

                            }
                            catch { }

                        }
                        else
                        {
                            _pseudoClass.ValueType = CHtmlStyleElementPseudoClassValueType.Num_Equation;
                            _pseudoClass.value = commonHTML.FasterTrimAndToLower(innerValue);
                            return _pseudoClass;
                        }

                    }
				}
			}
			catch(Exception ex)
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
				{
					commonLog.LogEntry("reatePsudoValueClass Exception " + val + " Pos: " + valPos.ToString() + " Msg:" + ex.Message );
				}
			}
			_pseudoClass.ValueType = CHtmlStyleElementPseudoClassValueType.Other;
			_pseudoClass.value = innerValue;
			return _pseudoClass;
		}
#endregion
	}



}
