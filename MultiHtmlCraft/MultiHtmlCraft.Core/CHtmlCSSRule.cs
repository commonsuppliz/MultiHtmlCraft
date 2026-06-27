using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    public sealed class CHtmlCSSRule : ICommonObjectInterface 
    {
        public CSSStyleConditionType ___styleConditionType;

        internal CSSRuleType ___ruleType = CSSRuleType.Style_Rule;
        internal string ___selectorText =null;
        internal System.WeakReference ___parentCSSStylesheet = null;
        internal System.WeakReference ___parentElementReference = null;
        internal CHtmlCSSStyleSheet ___style = null;

        public enum CSSRuleType : ushort
        {
            Style_Rule = 1,
            Charset_Rule = 2,
            Import_Rule = 3,
            Media_Rule = 4,
            Font_Face_Rule = 5,
            Page_Rule = 6,
            Keyframes_Rule = 7,
            Keyframe_Rule = 8,
            Namespace_Rule = 10,
            Counter_Style_Rule = 11,
            Supports_Rule = 12,
            Document_Rule = 13,
            Font_Feature_values_Rule = 14,
            Viewport_Rule = 15,
            Region_Style_Rule = 16,
            Unkown_Style_Rule=35
        }
        public bool ___IsPrototype = false;
        public System.Collections.Generic.List<CHtmlStyleAttribute?> ___styleAttributeList = null;
        internal CHtmlElementStyleType ___StyleType;
        public CHtmlMediaQueryNode ___MediaQueryNodeInstance = null;
        public System.WeakReference ___MediaQueryNodeWeakReference = null;
        public CHtmlPseudoClassType ___PseudoClassType;
   
        public CSSHackType ___CSSHack;
        public bool IsSortedListFieldsHasCopiedToProperty;
        public bool ___HasCombinatorChar;

        /// <summary>
        /// number of pseudo class ex. :hover, :active :not etc.
        /// Currently 28 Psedo Class ___hasInner been implemented CSS3.0
        /// </summary>
   
        public int ___PseudoClassCount = 0;

   
        public int ___NumberOfColonInSelector = 0;

        public int ___UndefinedPsedoClassCount = 0;

        public bool ___HasHoverPseudoClass = false;
        public bool ___HasActivePseudoClass = false;
        public bool ___HasLinkPseudoClass = false;
        public bool ___HasFocusPseudoClass = false;
        public bool ___HasVisitedPseudoClass = false;
        /// <summary>
        /// :lang(en) :lang(jp)
        /// </summary>
        public bool ___HasLangPseudoClass = false;
        /// <summary>
        /// :dir(ltr) :dir(rtl)
        /// </summary>
        public bool ___HasDirPseudoClass = false;
        public bool ___HasFirstChildPseudoClass = false;
        public bool ___HasLastChildPseudoClass = false;
        public bool ___HasFirstLetterPseudoClass = false;
        public bool ___HasFirstLinePseudoClass = false;
        public bool ___HasTargetPseudoClass = false;
        public bool ___HasRootPseudoClass = false;
        public bool ___HasWarningPseudoClass = false;
        public bool ___HasEnabledPseudoClass = false;
        public bool ___HasDisabledPseudoClass = false;
        public bool ___HasCheckedPseudoClass = false;
        public bool ___HasRequiredPseudoClass = false;
        public bool ___HasSearchCancelButtonPseudoClass = false;
        public bool ___HasSearchDecorationPseudoClass = false;
        public bool ___HasOptionalPseudoClass = false;
        public bool ___HasReadOnlyPseudoClass = false;
        public bool ___HasReadWritePseudoClass = false;
        public bool ___HasIndeterminatePseudoClass = false;
        public bool ___HasInvalidPseudoClass = false;
        public bool ___HasValidPseudoClass = false;
        public bool ___HasEmptyPseudoClass = false;
        public bool ___HasSelectionPseudoClass = false;
        /// <summary>
        /// E:placeholder, E:-moz-placeholder
        /// </summary>
        public bool ___HasPlaceHolderPseudoClass = false;
        /// <summary>
        /// E:not(xyx)
        /// </summary>
        public bool ___HasNotConditionPseudoClass = false;
        /// <summary>
        /// E:matches(xyx)
        /// </summary>
        public bool ___HasMatchesConditionPseudoClass = false;
        /// <summary>
        /// E:nth-child(n)
        /// </summary>
        public bool ___HasNthChildPseudoClass = false;
        /// <summary>
        /// E:nth-last-child(n)
        /// </summary>
        public bool ___HasNthLastChildPseudoClass = false;

        /// <summary>
        /// E:nth-of-type(n)
        /// </summary>
        public bool ___HasNthOfTypePseudoClass = false;


        /// <summary>
        /// E:first-of-type(n)
        /// </summary>
        public bool ___HasFirstOfTypePseudoClass = false;

        /// <summary>
        /// E:last-of-type(n)
        /// </summary>
        public bool ___HasLastOfTypePseudoClass = false;

        /// <summary>
        /// E:only-of-type(n)
        /// </summary>
        public bool ___HasOnlyOfTypePseudoClass = false;


        /// <summary>
        /// E:only-child(n)
        /// </summary>
        public bool ___HasOnlyChildPseudoClass = false;

        /// <summary>
        /// E:nth-last-of-type(n)
        /// </summary>
        public bool ___HasNthLastOfTypePseudoClass = false;

        public bool ___HasAfterPseudoClass = false;
        public bool ___HasBeforePseudoClass = false;

        public bool ___HasScrollBarPseudoClass = false;
        public bool ___HasScrollBarTrackPseudoClass = false;
        public bool ___HasScrollBarTrackPiecePseudoClass = false;
        public bool ___HasScrollBarButtonPseudoClass = false;
        public bool ___HasScrollBarThumbPseudoClass = false;
        public bool ___HasVerticalPseudoClass = false;
        public bool ___HasHorizontalPseudoClass = false;
        public bool ___HasScrollBarCornerPseudoClass = false;
        public bool ___HasFullscreenPseudoClass = false;
        public bool ___HasDefaultPseudoClass = false;
        public bool ___HasClearPseudoClass = false;


        /// <summary>
        /// Flag if any stylesheet does not want be searched.
        /// </summary>
        public bool ___NonSearchableStyleSheet = false;

      


        internal CHtmlCollection ___styleCHtmlCollection = null;

        /// <summary>
        /// Contains String For Attributes
        /// This Feild is to Passing Attributes title list to document.
        /// Use KeyClass to details.
        /// </summary>
        internal System.Collections.Generic.Dictionary<string, ushort> ___AttributesBulkTitleList = null;

        /// <summary>
        /// Number of Attriubtes Lookup Count
        /// </summary>
        internal int ___AttributesItemCount = 0;


        /// <summary>
        /// List of TagTypes Which is used for lookup nth-of-type() TagTypes
        /// </summary>
        internal System.Collections.Generic.Dictionary<string, ushort> ___ListNthOfTypeTagTypes = new System.Collections.Generic.Dictionary<string, ushort>();

        /// <summary>
        /// True if it is style attribute 
        /// </summary>
        internal bool ___IsDirectStyleElement = false;



        /// <summary>
        /// Sets or retrieves the media type. 
        /// ex. screen, all, print
        /// Keep This Feild As Public
        /// </summary>
        public string ___media = null;
        internal System.Text.StringBuilder ___StyleCommentBuilder = null;

        internal bool ___disabled = false;

        //internal CHtmlWebGradation ___WebGradation = null;


        // keep this field as internal
        internal string ___SelectorID = null;
        /// <summary>
        /// Sort Key Which is used for Ground Sort. LEAVE AS 'Field'
        /// </summary>
        public string ___GroundSortKey = null;

        /// <summary>
        /// Working Selector Sorting Key
        /// </summary>
        public string ___WorkingKey = null;
        /// <summary>
        /// Working Selector Sorting Key
        /// </summary>
        public char ___WorkingKeyCombinatorChar = '\0';

        public CHtmlDomTokenList ___WorkingKeyClassList = null;

        public System.Collections.Generic.Dictionary<CHtmlPseudoClassType, CHtmlStyleElementPseudoClassValue?> ___WorkingKeyPseudoTitleList = null;

        public System.Collections.Generic.Dictionary<string, CHtmlStyleElementSelectorKeyAttributeClass?> ___WorkingKeyAttributeKeyList = null;

        public CHtmlStyleKey ___WorkingSelectorClassKey = null;
        /// <summary>
        /// Length of WorkingSelectorList Items When ___ReCreateWorkingKey() ___hasInner run last Time.
        /// </summary>
   
        public int ___LastReCreateWorkingKeyCompleteListLength = 0;

        internal bool ___IsCssTopValueDefined = false;
        internal bool ___IsCssRightValueDefined = false;
        internal bool ___IsCssLeftValueDefined = false;
        internal bool ___IsCssBottomValueDefined = false;
        /// <summary>
        /// CSS Import usage only
        /// </summary>
        internal System.WeakReference ___srcElementReference = null;

        /// <summary>
        /// Property Populated Count through  ___applyElemenetStyleSheets(CHtmlElement htmlElement, bool _ForceReset, bool SkipTagAttributes, bool SkipStylesheet) methods
        /// </summary>
        /// 
        internal int ___CSSPosition;


        internal int ___SelectorConmaCount;

        /// <summary>
        /// Working Selector Key Working List (Add/Remove)
        /// </summary>
        public System.Collections.Generic.List<CHtmlStyleKey> ___styleKeyWorkingList = null;

        /// <summary>
        /// Original Selector Key List (Readonly)
        /// </summary>
        public System.Collections.Generic.List<CHtmlStyleKey> ___styleKeyOrignalList = null;

   
        public int ___SelectorRanking = 0;

   
        public double ___SelectorMediaQueryRanking = STYLE_MEDIA_RANKING_LOWEST;
        public static double STYLE_MEDIA_RANKING_LOWEST = -99999;

        internal int ___style_unique_id;

        public string ___baseUrl = null;

        public string ___ImageUrlHint = null;

        public bool ___isFinalStyleKeyWildCardOnly;
        public bool ___isCSSRuleForThisNode;
        /// <summary>
        /// How many style information ___hasInner been moved to properties
        /// </summary>
        internal int ___PropertyMeargedCount = 0;

        /// <summary>
        /// How many font related properties ___hasInner been set (except for color)
        /// </summary>
        internal int ___FontRelatedCount = 0;
        /// <summary>
        /// Original Selector Text
        /// </summary>
        public string ___SelectorTextOriginal = null;

        /// <summary>
        /// true if you want this rule to go thru queue even though it will be put on the queue.
        /// </summary>
        public bool ___isStyleMustGoThruQueue = false;

        public CHtmlCSSRule(CHtmlElementStyleType targetType)
        {
            this.___StyleType = targetType;
            this.___styleAttributeList = new System.Collections.Generic.List<CHtmlStyleAttribute?>();

           
        }
        public void SetSelectorIDDirect(string val)
        {
            this.___SelectorID = val;

        }

        #region IPropertBox メンバ

        public void ___setPropertyByName(string name, object val)
        {
            // TODO:  CHtmlWindowScreen.___setPropertyByIndex 実装を追加します。
        }

        public bool ___hasPropertyByName(string name)
        {
            // TODO:  CHtmlWindowScreen._x__HasProperty 実装を追加します。
            return true;
        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }
        /// <summary>
        /// return type as integer value.
        /// </summary>
        public int type
        {
            get
            {
                return (int)this.___ruleType;
            }
        }
        public string SelectorID
        {
            get { return this.___SelectorID; }
            set
            {
                this.___style_unique_id = 0;

                this.___GroundSortKey = null; ;
                this.___SelectorID = value;
                if (string.IsNullOrEmpty(this.___SelectorID) == false && this.___SelectorID[0] == '@' && this.___ruleType == CSSRuleType.Style_Rule)
                {
                    if (this.___SelectorID.Length > 4)
                    {

                        switch (this.___SelectorID[1])
                        {
                            case 'F':
                            case 'f':

                                if (string.Equals(this.___SelectorID, "@font-face", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    this.___ruleType = CSSRuleType.Font_Face_Rule;
                                    this.___NonSearchableStyleSheet = true;
                                }
                                break;
                            case 'I':
                            case 'i':

                                if (string.Equals(this.___SelectorID, "@import", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    this.___ruleType = CSSRuleType.Import_Rule;
                                    this.___NonSearchableStyleSheet = true;
                                }
                                break;
                            case 'V':
                            case 'v':
                                {
                                    if (this.___SelectorID.EndsWith("viewport", StringComparison.OrdinalIgnoreCase))
                                    {
                                        this.___ruleType = CSSRuleType.Viewport_Rule;
                                        this.___NonSearchableStyleSheet = true;
                                    }

                                    break;
                                }

                        }
                    }

                }



                if (this.___styleKeyOrignalList != null && this.___styleKeyOrignalList.Count > 0)
                {
                    this.___styleKeyOrignalList.Clear();
                }
                if (this.___styleKeyWorkingList != null && this.___styleKeyWorkingList.Count > 0)
                {
                    this.___styleKeyWorkingList.Clear();
                }
                System.Collections.Generic.List<CHtmlStyleKey> arSelectorKeyClassList = null;
                if (string.IsNullOrEmpty(this.___SelectorID) == false)
                {
                    arSelectorKeyClassList = CHtmlCSSRuleGroundList.CreateCHtmlStyleKeyList(value, this);
                }
                //AfterSelector:
                if (arSelectorKeyClassList != null && arSelectorKeyClassList.Count > 0)
                {
                    // Checks Ending Style Key is wildcard or not
                    if (arSelectorKeyClassList.Count >= 1)
                    {

                        CHtmlStyleKey endingKey = null;
                        endingKey = arSelectorKeyClassList[arSelectorKeyClassList.Count - 1] as CHtmlStyleKey;
                        if (endingKey != null)
                        {
                            if (string.IsNullOrEmpty(endingKey.CssClassLowSimple) == true && string.IsNullOrEmpty(endingKey.CssIDLowSimple) == true)
                            {
                                if (string.IsNullOrEmpty(endingKey.TagName) == true || (endingKey.TagName.Length == 1 && endingKey.TagName[0] == '*'))
                                {
                                    if ((endingKey.___attributeKeyList == null || endingKey.___attributeKeyList.Count == 0))
                                    {
                                        this.___isFinalStyleKeyWildCardOnly = true;
                                    }
                                }

                            }
                        }
                    }
                    // Checks IE Hack
                    if (arSelectorKeyClassList.Count >= 2)
                    {
                        CHtmlStyleKey firstKey = null;
                        CHtmlStyleKey secondKey = null;
                        firstKey = arSelectorKeyClassList[0] as CHtmlStyleKey;
                        secondKey = arSelectorKeyClassList[1] as CHtmlStyleKey;
                        if (firstKey != null && secondKey != null)
                        {
                            switch (firstKey.___StyleSelectorKeyDataMode)
                            {
                                case CHtmlStyleSelectorKeyDataModeType.Other:
                                    {
                                        if (string.IsNullOrEmpty(firstKey.TagName) == false && firstKey.TagName.Length == 1 && firstKey.TagName[0] == '*')
                                        {
                                            if (firstKey.___pseudoTitleParamList != null && firstKey.___pseudoTitleParamList.ContainsKey(CHtmlPseudoClassType.FirstChildPseudoClass))
                                            {
                                                // IE 7 Hack
                                                this.___CSSHack = CSSHackType.IE;
                                                goto StartSet;

                                            }
                                            if (secondKey.Combinator == '+')
                                            {
                                                if (string.Equals(secondKey.TagName, "HTML", StringComparison.Ordinal) == true)
                                                {
                                                    // [* HTML] IE Hack
                                                    this.___CSSHack = CSSHackType.IE;
                                                    this.___NonSearchableStyleSheet = true;
                                                    goto StartSet;
                                                }
                                            }
                                        }
                                        break;

                                    }
                                case CHtmlStyleSelectorKeyDataModeType.TagOnly:
                                    {
                                        if (string.IsNullOrEmpty(firstKey.TagName) == false && firstKey.TagName.Length == 1 && firstKey.TagName[0] == '*')
                                        {
                                            if (string.Equals(secondKey.TagName, "HTML", StringComparison.Ordinal) == true)
                                            {
                                                // [* HTML] IE Hack
                                                this.___CSSHack = CSSHackType.IE;
                                                this.___NonSearchableStyleSheet = true;
                                                goto StartSet;
                                            }
                                        }
                                        break;
                                    }
                            }
                        }

                    }
                    else
                    {
                        if (arSelectorKeyClassList.Count == 1)
                        {
                            CHtmlStyleKey firstKey = null;
                            firstKey = arSelectorKeyClassList[0] as CHtmlStyleKey;
                            if (firstKey != null)
                            {
                                if (arSelectorKeyClassList.Count == 1)
                                {
                                    if (string.IsNullOrEmpty(firstKey.TagName) == true || (firstKey.TagName.Length == 1 && firstKey.TagName[0] == '*'))
                                    {
                                        if (this.___HasSelectionPseudoClass == true)
                                        {
                                            this.___NonSearchableStyleSheet = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                StartSet:

                    //System.Collections.ICollection ___iCollectList = arSelectorKeyClassList as ICollection;

                        this.___styleKeyWorkingList = new System.Collections.Generic.List<CHtmlStyleKey>();


                    this.___styleKeyOrignalList = new System.Collections.Generic.List<CHtmlStyleKey>();
                    if (this.___NonSearchableStyleSheet == false)
                    {
                        this.___styleKeyOrignalList.AddRange(arSelectorKeyClassList.ToArray());
                        this.___styleKeyWorkingList.AddRange(arSelectorKeyClassList.ToArray());
                    }
                

                }
                else
                {

                }

                if (this.___NonSearchableStyleSheet == false)
                {
                    CHtmlStyleKey topKey = this.___styleKeyOrignalList[0] as CHtmlStyleKey;
                    if (topKey != null)
                    {
                        this.___GroundSortKey = String.Copy(topKey.SortShortName);
                    }
                    this.___ReCreateWorkingKeyIntoCHtmlStyleElement();
                }
            }
        }
        public override string ToString()
        {
            return "CHtmlCSSRule : " + this.___SelectorID;
        }
   
        internal void ___ReCreateWorkingKeyIntoCHtmlStyleElement()
        {
            bool __IsRecreated = false;
            int __CurrentCount = this.___styleKeyWorkingList.Count;
            if (__CurrentCount == this.___LastReCreateWorkingKeyCompleteListLength)
            {
                return;
            }
            if (__CurrentCount > 0)
            {
                CHtmlStyleKey topWorkingKey = this.___styleKeyWorkingList[0] as CHtmlStyleKey;
                if (topWorkingKey != null)
                {

                    this.___WorkingKey = String.Copy(topWorkingKey.SortShortName);
                    this.___WorkingKeyCombinatorChar = topWorkingKey.Combinator;
                    this.___WorkingKeyClassList = topWorkingKey.___classList;
                    this.___WorkingKeyPseudoTitleList = topWorkingKey.___pseudoTitleParamList;
                    this.___WorkingKeyAttributeKeyList = topWorkingKey.___attributeKeyList;
                    this.___WorkingSelectorClassKey = topWorkingKey;
                    this.___LastReCreateWorkingKeyCompleteListLength = __CurrentCount;
                    __IsRecreated = true;
                    return;
                }

            }
            if (__IsRecreated == false)
            {
                this.___LastReCreateWorkingKeyCompleteListLength = 0;
                this.___WorkingKey = null; ;
                this.___WorkingKeyCombinatorChar = '\0';
                this.___WorkingKeyClassList = null;
                this.___WorkingKeyPseudoTitleList = null;
                this.___WorkingKeyAttributeKeyList = null;
                this.___WorkingSelectorClassKey = null;
            }
        }
        /// <summary>
        /// returns parentRule normally null.
        /// </summary>
        public CHtmlCSSRule parentRule
        {
            get
            {
                return null;
            }
        }
        public CHtmlCSSStyleSheet parentStyleSheet
        {
            set
            {
                this.___parentCSSStylesheet = new WeakReference(value, false);
            }
            get
            {
                if (this.___parentCSSStylesheet != null)
                {
                    return this.___parentCSSStylesheet.Target as CHtmlCSSStyleSheet;
                }
                return null;
            }
        }
        internal CHtmlStyleAttribute? ___getStyleElemenetAttributeClassByName(string _name)
        {
            try
            {

                CHtmlStyleAttribute? attr = null;
                CHtmlStyleAttribute attrVal = (CHtmlStyleAttribute)attr;
                attrVal.Name = _name;
                int pos = this.___styleAttributeList.BinarySearch(attr, new CHtmlStyleAttributeComparer());
                if (pos > -1)
                {
                    return this.___styleAttributeList[pos];
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel > 5)
                {
                   commonLog.LogEntry("CHtmlStyleElement getStyleElemenetAttributeClassByName({0}) Error : {1}", _name, ex.Message);
                }
            }
            return null;
        }
        /// <summary>
        /// Set or Get ownerElement (non Standard Property)
        /// Field is weak Refeence.
        /// </summary>
        public CHtmlElement parentElement
        {
            set
            {
                this.___parentElementReference = new WeakReference(value, false);
            }
            get
            {
                if (this.___parentElementReference != null)
                {
                    return this.___parentElementReference.Target as CHtmlElement;
                }
                return null;
            }
        }
        public CHtmlCSSRule cloneCSSRule()
        {
            CHtmlCSSRule sNew = new CHtmlCSSRule(this.___StyleType);
            try
            {
                if (this.___styleAttributeList != null && this.___styleAttributeList.Count > 0)
                {

                    sNew.___styleAttributeList.AddRange(this.___styleAttributeList);
                }
                // Checking Value is good!
                if (string.IsNullOrEmpty(this.___baseUrl) == false)
                {
                    sNew.___baseUrl = string.Copy(this.___baseUrl);
                }
                if (string.IsNullOrEmpty(this.___ImageUrlHint) == false)
                {
                    sNew.___ImageUrlHint = string.Copy(this.___ImageUrlHint);
                }
                if (string.IsNullOrEmpty(this.___SelectorID) == false)
                {
                    sNew.___SelectorID = string.Copy(this.___SelectorID);
                }

                sNew.___HasCombinatorChar = this.___HasCombinatorChar;
                sNew.___PseudoClassCount = this.___PseudoClassCount;
                sNew.___UndefinedPsedoClassCount = this.___UndefinedPsedoClassCount;
                sNew.___NumberOfColonInSelector = this.___NumberOfColonInSelector;
                sNew.___CSSHack = this.___CSSHack;
                sNew.___NonSearchableStyleSheet = this.___NonSearchableStyleSheet;
                sNew.___ruleType = this.___ruleType;
                if (this.___MediaQueryNodeInstance != null)
                {
                    sNew.___MediaQueryNodeWeakReference = new WeakReference(this.___MediaQueryNodeInstance, false);
                }
                if (this.___MediaQueryNodeWeakReference != null)
                {
                    sNew.___MediaQueryNodeWeakReference = this.___MediaQueryNodeWeakReference;
                }

                if (this.___PseudoClassCount > 0)
                {
                    sNew.___HasActivePseudoClass = this.___HasActivePseudoClass;
                    sNew.___HasAfterPseudoClass = this.___HasAfterPseudoClass;
                    sNew.___HasBeforePseudoClass = this.___HasBeforePseudoClass;
                    sNew.___HasCheckedPseudoClass = this.___HasCheckedPseudoClass;
                    sNew.___HasDisabledPseudoClass = this.___HasDisabledPseudoClass;
                    sNew.___HasEmptyPseudoClass = this.___HasEmptyPseudoClass;
                    sNew.___HasEnabledPseudoClass = this.___HasEnabledPseudoClass;
                    sNew.___HasFirstChildPseudoClass = this.___HasFirstChildPseudoClass;
                    sNew.___HasFirstLetterPseudoClass = this.___HasFirstLetterPseudoClass;
                    sNew.___HasFirstLinePseudoClass = this.___HasFirstLinePseudoClass;
                    sNew.___HasFirstOfTypePseudoClass = this.___HasFirstOfTypePseudoClass;
                    sNew.___HasFocusPseudoClass = this.___HasFocusPseudoClass;
                    sNew.___HasHoverPseudoClass = this.___HasHoverPseudoClass;
                    sNew.___HasLangPseudoClass = this.___HasLangPseudoClass;
                    sNew.___HasLastChildPseudoClass = this.___HasLastChildPseudoClass;
                    sNew.___HasLastOfTypePseudoClass = this.___HasLastOfTypePseudoClass;
                    sNew.___HasLinkPseudoClass = this.___HasLinkPseudoClass;
                    sNew.___HasNotConditionPseudoClass = this.___HasNotConditionPseudoClass;
                    sNew.___HasNthChildPseudoClass = this.___HasNthChildPseudoClass;
                    sNew.___HasNthLastChildPseudoClass = this.___HasNthLastChildPseudoClass;
                    sNew.___HasNthLastOfTypePseudoClass = this.___HasNthLastOfTypePseudoClass;
                    sNew.___HasNthOfTypePseudoClass = this.___HasNthOfTypePseudoClass;
                    sNew.___HasOnlyChildPseudoClass = this.___HasOnlyChildPseudoClass;
                    sNew.___HasOnlyOfTypePseudoClass = this.___HasOnlyOfTypePseudoClass;
                    sNew.___HasPlaceHolderPseudoClass = this.___HasPlaceHolderPseudoClass;
                    sNew.___HasRootPseudoClass = this.___HasRootPseudoClass;
                    sNew.___HasTargetPseudoClass = this.___HasTargetPseudoClass;
                    sNew.___HasVisitedPseudoClass = this.___HasVisitedPseudoClass;
                    sNew.___HasWarningPseudoClass = this.___HasWarningPseudoClass;
                    sNew.___HasIndeterminatePseudoClass = this.___HasIndeterminatePseudoClass;
                    sNew.___HasInvalidPseudoClass = this.___HasInvalidPseudoClass;
                    sNew.___HasValidPseudoClass = this.___HasValidPseudoClass;
                    sNew.___HasReadOnlyPseudoClass = this.___HasReadOnlyPseudoClass;
                    sNew.___HasReadWritePseudoClass = this.___HasReadWritePseudoClass;
                    sNew.___HasSelectionPseudoClass = this.___HasSelectionPseudoClass;
                    sNew.___HasScrollBarButtonPseudoClass = this.___HasScrollBarButtonPseudoClass;
                    sNew.___HasScrollBarPseudoClass = this.___HasScrollBarPseudoClass;
                    sNew.___HasScrollBarThumbPseudoClass = this.___HasScrollBarThumbPseudoClass;
                    sNew.___HasScrollBarTrackPiecePseudoClass = this.___HasScrollBarTrackPiecePseudoClass;
                    sNew.___HasScrollBarTrackPseudoClass = this.___HasScrollBarTrackPseudoClass;
                    sNew.___HasHorizontalPseudoClass = this.___HasHorizontalPseudoClass;
                    sNew.___HasVerticalPseudoClass = this.___HasVerticalPseudoClass;
                    sNew.___HasScrollBarCornerPseudoClass = this.___HasScrollBarCornerPseudoClass;
                    sNew.___HasFullscreenPseudoClass = this.___HasFullscreenPseudoClass;
                    sNew.___HasDefaultPseudoClass = this.___HasDefaultPseudoClass;
                    sNew.___HasClearPseudoClass = this.___HasClearPseudoClass;
                    sNew.___HasOptionalPseudoClass = this.___HasOptionalPseudoClass;
                    sNew.___HasDirPseudoClass = this.___HasDirPseudoClass;
                    sNew.___HasRequiredPseudoClass = this.___HasRequiredPseudoClass;
                    sNew.___HasSearchCancelButtonPseudoClass = this.___HasSearchCancelButtonPseudoClass;
                    sNew.___HasSearchDecorationPseudoClass = this.___HasSearchDecorationPseudoClass;
                }
                /*
                if(this.___styleKeyWorkingList.Count > 0)
                {
		
                    sNew.___styleKeyWorkingList = this.___styleKeyWorkingList.Clone() as System.Collections.ArrayList;
                }
                if(this.___styleKeyOrignalList.Count > 0)
                {
                    sNew.___styleKeyOrignalList = null;
                    sNew.___styleKeyOrignalList = this.___styleKeyOrignalList.Clone() as System.Collections.ArrayList;
                }
                */
                CloneStyleSelectorWorkingOriginalKey(sNew, this);

                sNew.___isCSSRuleForThisNode = this.___isCSSRuleForThisNode;
                // ==========================================================
                if (this.IsSortedListFieldsHasCopiedToProperty == true)
                {

                    sNew.IsSortedListFieldsHasCopiedToProperty = this.IsSortedListFieldsHasCopiedToProperty;
                }
                if (this.___StyleCommentBuilder != null)
                {
                    sNew.___StyleCommentBuilder = new StringBuilder(this.___StyleCommentBuilder.ToString());
                }

                sNew.___style_unique_id = ___style_unique_id;

                sNew.___SelectorRanking = this.___SelectorRanking;
                if (string.IsNullOrEmpty(this.___WorkingKey) == false)
                {
                    sNew.___WorkingKey = string.Copy(this.___WorkingKey);
                }
                if (string.IsNullOrEmpty(this.___GroundSortKey) == false)
                {
                    sNew.___GroundSortKey = string.Copy(this.___GroundSortKey);
                }
                sNew.___StyleType = this.___StyleType;
                if (this.___AttributesBulkTitleList != null && this.___AttributesBulkTitleList.Count > 0)
                {

                    if (sNew.___AttributesBulkTitleList == null)
                    {
                        sNew.___AttributesBulkTitleList = new System.Collections.Generic.Dictionary<string, ushort>(StringComparer.Ordinal);
                    }
                    foreach (string strAttributeKey in this.___AttributesBulkTitleList.Keys)
                    {
                        sNew.___AttributesBulkTitleList[strAttributeKey] = 1;
                    }


                }
                sNew.___AttributesItemCount = this.___AttributesItemCount;
                if (this.___ListNthOfTypeTagTypes.Count > 0)
                {
                    foreach (string strTagKey in this.___ListNthOfTypeTagTypes.Keys)
                    {
                        if (strTagKey == null)
                            continue;
                        sNew.___ListNthOfTypeTagTypes[strTagKey] = 1;
                    }
                }
                if (string.IsNullOrEmpty(this.___media) == false)
                {
                    sNew.___media = string.Copy(this.___media);
                }

                sNew.___IsDirectStyleElement = this.___IsDirectStyleElement;
                sNew.___WorkingKeyCombinatorChar = this.___WorkingKeyCombinatorChar;
                sNew.___WorkingKeyClassList = this.___WorkingKeyClassList;
                sNew.___WorkingKeyPseudoTitleList = this.___WorkingKeyPseudoTitleList;
                sNew.___WorkingKeyAttributeKeyList = this.___WorkingKeyAttributeKeyList;
                sNew.___WorkingSelectorClassKey = this.___WorkingSelectorClassKey;
                sNew.___LastReCreateWorkingKeyCompleteListLength = this.___LastReCreateWorkingKeyCompleteListLength;
                sNew.___CSSPosition = this.___CSSPosition;
                sNew.___PseudoClassType = this.___PseudoClassType;
                sNew.___FontRelatedCount = this.___FontRelatedCount;
                sNew.___isFinalStyleKeyWildCardOnly = this.___isFinalStyleKeyWildCardOnly;

                if (string.IsNullOrEmpty(this.___SelectorTextOriginal) == false)
                {
                    sNew.___SelectorTextOriginal = string.Copy(this.___SelectorTextOriginal);
                }
                sNew.___SelectorRanking = this.___SelectorRanking;
                sNew.___SelectorMediaQueryRanking = this.___SelectorMediaQueryRanking;
                sNew.___SelectorConmaCount = this.___SelectorConmaCount;
            }
            catch (Exception exStyleCopy)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel > 8)
                {
                   commonLog.LogEntry("CLoneCHtmlStyleElement Exception", exStyleCopy);
                }
            }
            return sNew;
        }
        internal static void CloneStyleSelectorWorkingOriginalKey(CHtmlCSSRule _newPart, CHtmlCSSRule _oriPart)
        {

            // int ___oriPartSelectorKeyWorkingCount = _oriPart.___styleKeyWorkingList.Count;
            /*
			for(int i = 0; i < ___oriPartSelectorKeyWorkingCount; i ++)
			{
                CHtmlStyleKey workKey = _oriPart.___styleKeyWorkingList[i] as CHtmlStyleKey;
                if (workKey != null)
                {
                    _newPart.___styleKeyWorkingList.Add(workKey.CloneKey());
                }
				//_newPart.___styleKeyOrignalList.Add(originalKey.CloneKey());
			}
             */
            //_newPart.___styleKeyWorkingList  = _oriPart.___styleKeyWorkingList.Clone() as System.Collections.ArrayList; 
            _newPart.___styleKeyWorkingList = new System.Collections.Generic.List<CHtmlStyleKey>();
            if (_oriPart.___styleKeyWorkingList != null && _oriPart.___styleKeyWorkingList.Count > 0)
            {
                _newPart.___styleKeyWorkingList.AddRange(_oriPart.___styleKeyWorkingList.ToArray());
            }

            //_newPart.___styleKeyWorkingList.AddRange(_oriPart.___styleKeyWorkingList as ICollection);
            // Due to performance reasons, we keep to original just for near future.




            //_newPart.___styleKeyOrignalList.AddRange(_oriPart.___styleKeyOrignalList as ICollection);
            //_newPart.___styleKeyOrignalList = _oriPart.___styleKeyOrignalList.Clone() as System.Collections.ArrayList;
            _newPart.___styleKeyOrignalList = new System.Collections.Generic.List<CHtmlStyleKey>();
            if (_oriPart.___styleKeyOrignalList != null && _oriPart.___styleKeyOrignalList.Count > 0)
            {
                _newPart.___styleKeyOrignalList.AddRange(_oriPart.___styleKeyOrignalList.ToArray());
            }



            // 
            //_newPart.___styleKeyOrignalList = _oriPart.___styleKeyOrignalList.Clone() as System.Collections.ArrayList;

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
               commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }
        public string cssText
        {
            get {
                if (this.___style != null)
                {
                    return this.___style.cssText;
                }
                return "";
            }
            set {
                if (this.___style != null)
                {
                    this.___style.cssText = value;
                }
            }
        }
        public object ___getPropertyByName(string ___name)
        {
            switch (commonHTML.FasterToLower(___name))
            {
                case "type":
                    return this.___ruleType;
                case "parentstylesheet":
                    return this.parentStyleSheet;
                case "parentrule":
                    return null;
                case "style":
                    return this.___style;
                case "selectortext":
                    return this.___selectorText;
                case "csstext":
                    return this.cssText;
                case "__iterator__":
                    return commonHTML.rhinoForLoopEnumratorFunction;
                default:
                    break;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
            }
            return null;
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
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.CSSRule;
            }
        }

        #endregion
    }
}
