using System;
using System.Collections;
using System.Text;
using System.Drawing;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// CHtmlCSSRuleGroundList will store Style element in order.
    /// [Note]
    /// This class ___hasInner been Generic.List of StyleElement but there is a bug on .net, if we use generic list, comparer throws exception 
    /// frequently
    /// 
    /// [Exception Message]
    /// System.ArgumentException: Offset and length were out of bounds for the array or count is greater than 
    /// the number of elements from index to the end of the source collection.
    ///  at System.Array.BinarySearch[T](T[] array, Int32 index, Int32 length, T value, IComparer`1 comparer)
    /// 
    /// [Cause]
    /// .NET framework 2.0-4.5 ___hasInner Generic Comparer Bug which is hard to work around. 
    /// 
    /// [WorkAround]
    /// We decide convert this class back to ArrayList. It seems to be stable more. (may be slower....)
    /// Do NOT CHANGE this class to Generic List!!!!
    /// 
    /// </summary>
    public sealed class CHtmlCSSRuleGroundList : ArrayList
	{
		internal bool __IsMergeQueueCompleted = false;

        private enum CssParseModeType : byte
        {
            Name=0, Suffix=2, Prefix =3, CssClass = 4, CssID=5, AttibuteLookup=10
        };
		
		private CHtmlCSSRuleGroundKeyComparer ___compGround= null;
		//private CHtmlStyleElementClassComparer _elementStyleComparer = null;

		public bool IsFullSortCompleted = false;
		
		private readonly object ____ListLockObject = new object();

        /// <summary>
        /// SAFE Limit for styleElement can be stored to each node element.
        /// </summary>
		
		internal static readonly int STYLE_GROUND_SEARCH_NODE_ITEM_COUNT_LIMIT = 3500;

		public CHtmlCSSRuleGroundList()
		{
			// 
			// 
			//
		
			
			this.___compGround =new CHtmlCSSRuleGroundKeyComparer();
			/*
			_compTop.CompareType = CHtmlStyleElementClassComparer.ICHtmlStyleElementCompareType.WorkingListTop;
			_elementStyleComparer = new CHtmlStyleElementClassComparer();
			_elementStyleComparer.CompareType = CHtmlStyleElementClassComparer.ICHtmlStyleElementCompareType.WorkingListTop;
			*/
		}
	


		
        internal static System.Collections.Generic.List<CHtmlStyleKey> CreateCHtmlStyleKeyList(string __SelectorID, CHtmlCSSRule basestyleElement)
		{
            System.Collections.Generic.List<CHtmlStyleKey> __arSelectorKeyClassList = new System.Collections.Generic.List<CHtmlStyleKey>();
			char[] cKeyChar =  __SelectorID.ToCharArray();
			StringBuilder sbCssName = new StringBuilder();
			StringBuilder sbCssClass = new StringBuilder();
			StringBuilder sbCssID = new StringBuilder();
			StringBuilder sbPrefix = new StringBuilder();
			StringBuilder sbSufix = new StringBuilder();
			// for INPUT[type=3D'submit'] 
			StringBuilder sbAttributeLookup = new StringBuilder();
			StringBuilder sbCombinator =new StringBuilder();

			CssParseModeType pType = CssParseModeType.Name;

			bool IsParentthesisString = false; // ex : :not(xysx, dfafdsa)
		
			/*
			*/

			int SpaceCount = __SelectorID.Split(commonHTML.CharSpaceCrLfTab).Length;
			int cKeyCharLen = cKeyChar.Length;
			for(int i = 0; i < cKeyCharLen; i++)
			{
				char c = cKeyChar[i];
				switch(c)
				{
					case '(':
					case ')':
						if(pType ==  CssParseModeType.Suffix)
						{
							if(IsParentthesisString == false)
							{
								IsParentthesisString = true;
							}
							else
							{
								IsParentthesisString = false;
							}
						}
						break;
					case '[':
					{
						if(IsParentthesisString == true &&  pType == CssParseModeType.Suffix)
						{
							break;
						}
						if(pType != CssParseModeType.AttibuteLookup)
						{
							sbAttributeLookup.Append(c);
							pType = CssParseModeType.AttibuteLookup;
							continue;
						}
						break;
					}
					case ']':
					{
						if(IsParentthesisString == true &&  pType == CssParseModeType.Suffix)
						{
							break;
						}
						if(pType != CssParseModeType.Suffix)
						{
															
							if(pType ==CssParseModeType.AttibuteLookup)
							{
								sbAttributeLookup.Append(c);
								pType = CssParseModeType.Name;
								continue;
							}
						}
						break;
					}
					case ' ':
					case commonHTML.CharZenkakuSpace: // DBCS Space
					case '\t':
						if(IsParentthesisString == true &&  pType == CssParseModeType.Suffix)
						{
							break;
						}
						else if(IsParentthesisString == false &&  pType == CssParseModeType.Suffix)
						{
							// -----------------------
							// ex.  a:hover div p
							// ------------------------
							pType = CssParseModeType.Name;
						}
						if(pType != CssParseModeType.AttibuteLookup && pType != CssParseModeType.Suffix)
						{
							pType = CssParseModeType.Name;
							if(sbCssName.Length > 0 || sbCssClass.Length > 0 || sbCssID.Length > 0 || sbAttributeLookup.Length > 0 || sbSufix.Length > 0)
							{
								string __PrevCombinatorValue = sbCombinator.ToString();
								pType = CssParseModeType.Name;
								sbCombinator =new StringBuilder();
								CHtmlStyleKey eSelector = new CHtmlStyleKey(basestyleElement, sbCssName.ToString(), sbCssClass.ToString(),sbCssID.ToString(), sbPrefix.ToString(), sbSufix.ToString(), sbAttributeLookup.ToString(), __PrevCombinatorValue);
								__arSelectorKeyClassList.Add(eSelector);

							}

							sbCssName = new StringBuilder();
							sbCssClass = new StringBuilder();
							sbCssID = new StringBuilder();
							sbPrefix = new StringBuilder();
							sbSufix = new StringBuilder();
							sbAttributeLookup = new StringBuilder();
							if(i < cKeyChar.Length - 2)
							{
								for(int nc = i + 1; nc < cKeyCharLen; nc ++)
								{
									char ncc = cKeyChar[nc];
									if(ncc == '+' || ncc == '>' || ncc == '~')
									{
										if(sbCombinator.Length == 0)
										{
											sbCombinator.Append(cKeyChar[nc]);
										}
									}
                                    else if (commonHTML.FasterIsWhiteSpaceLimited(ncc))
									{
										continue;
									}
									else
									{
										i = nc -1;
										break;
									}
								}
							}
						}
						continue;
					case ':':
						if(IsParentthesisString == true &&  pType == CssParseModeType.Suffix)
						{
							break;
						}
						if(pType != CssParseModeType.AttibuteLookup)
						{
							pType = CssParseModeType.Suffix;
						}
						break;
					case '+':
					case '>':
					case '~':
						if(IsParentthesisString == true &&  pType == CssParseModeType.Suffix)
						{
							break;
						}
						if(pType != CssParseModeType.AttibuteLookup)
						{
							// + Combilder will be added to Next Selector Key
							string __PrevCombinatorValue = sbCombinator.ToString();
							pType = CssParseModeType.Name;
							sbCombinator =new StringBuilder();
							sbCombinator.Append(c);
							if(sbCssName.Length > 0 || sbCssClass.Length > 0 || sbCssID.Length > 0 || sbAttributeLookup.Length > 0 || sbSufix.Length > 0 )
							{
								CHtmlStyleKey eSelector = new CHtmlStyleKey(basestyleElement, sbCssName.ToString(), sbCssClass.ToString(),sbCssID.ToString(), sbPrefix.ToString(), sbSufix.ToString(), sbAttributeLookup.ToString(), __PrevCombinatorValue);
								//eSelector.Combinator = c.ToString();
								 __arSelectorKeyClassList.Add(eSelector);

							}
						//NextSelector:
							/*
							if(__arSelectorKeyClassList.Count > 0)
							{
								((CHtmlStyleKey)__arSelectorKeyClassList[__arSelectorKeyClassList.Count -1]).Combinator = c.ToString();
							}
							*/
							sbCssName = new StringBuilder();
							sbCssClass = new StringBuilder();
							sbCssID = new StringBuilder();
							sbPrefix = new StringBuilder();
							sbSufix = new StringBuilder();
							sbAttributeLookup =new StringBuilder();
							if(i < cKeyChar.Length -1)
							{
								for(int n = i + 1 ;n < cKeyCharLen;n++)
								{
									if(cKeyChar[n] != ' ')
									{
										i = n -1;
										break;
									}
								}
							}
                        }
                        else if (pType == CssParseModeType.AttibuteLookup)
                        {
                            break;
                        }
						continue;
					case '#':
						if(IsParentthesisString == true &&  pType == CssParseModeType.Suffix)
						{
							break;
						}
						if(pType != CssParseModeType.AttibuteLookup )
						{
							pType = CssParseModeType.CssID;
						}
						break;
					case '.':
						if(IsParentthesisString == true &&  pType == CssParseModeType.Suffix)
						{
							break;
						}
						if(pType != CssParseModeType.AttibuteLookup)
						{
							pType = CssParseModeType.CssClass;
						}
						break;
				}
				switch(pType)
				{
					case CssParseModeType.Name:
                        if (c >= 'a' && c <= 'z')
                        {
                            sbCssName.Append(commonHTML.FasterToUpper(c));
                        }
                        else
                        {
                            sbCssName.Append(c);
                        }
						break;
					case CssParseModeType.CssClass:
						sbCssClass.Append(c);
						break;
					case  CssParseModeType.CssID:
						sbCssID.Append(c);
						break;
					case  CssParseModeType.Prefix:
						sbPrefix.Append(c);
						break;
					case  CssParseModeType.Suffix:
						if(c == ':')
						{
							if(sbSufix.Length == 1 && sbSufix[0] == ':')
							{
								break;
							}
						}
						sbSufix.Append(c);
						break;
					case CssParseModeType.AttibuteLookup:
						sbAttributeLookup.Append(c);
						break;
				}
			}
			if(sbCssName.Length > 0 || sbCssClass.Length > 0 || sbCssID.Length > 0 || sbAttributeLookup.Length > 0 || sbSufix.Length > 0)
			{
				/*
				if(sbCssName.Length == 1 && char.IsLetter(sbCssName[0]) == false)
				{
					sbCssName.Remove(0,1);
					if(sbCssClass.Length == 0 || sbCssID.Length == 0)
					{
						if(__arSelectorKeyClassList.Count ==0)
						{
							return  __arSelectorKeyClassList;
						}
					}
				}
				*/
				CHtmlStyleKey eSelectorX = new CHtmlStyleKey(basestyleElement, sbCssName.ToString(), sbCssClass.ToString(),sbCssID.ToString(), sbPrefix.ToString(), sbSufix.ToString(), sbAttributeLookup.ToString(), sbCombinator.ToString());
				 __arSelectorKeyClassList.Add(eSelectorX);

			}
			/*
			if(__arSelectorKeyClassList != null && __arSelectorKeyClassList.Count >= 2)
			{
				CHtmlStyleKey topKey = __arSelectorKeyClassList[0] as CHtmlStyleKey;
				if(topKey != null)
				{
					if(string.IsNullOrEmpty(topKey.TagName) == false && topKey.TagName.Length == 1 && topKey.TagName[0] == '*')
					{
						//__arSelectorKeyClassList.RemoveAt(0);
						// ================================================================
						// CSS Selector Wildcard Scenario
						// In order to keep best performance, * at the begging is prohibitted
						// we should only allow '*' in the middle or last
						// Note)
						// *.class ___hasInner been converted into  ''.class when creation
						// [Note]
						// This is used for detect css hack at merge time. keep it now.
						// ----------------------------------------------------------------
						// * html
						// * html p a
						// "* html div p"　
						// ================================================================
						

						
						if(commonLog.LogLevel > 8)
						{
							commonLog.LogEntry("'{0}' ___hasInner * at begining. Remove 1st one", __SelectorID);
							
						}
						
					}
				}
			}
            */
			return  __arSelectorKeyClassList;
			
		}
		private static void CheckClassName(System.Text.StringBuilder sbName)
		{

		}

        public void Insert(int index, CHtmlCSSRule value)
        {
            if (value.___styleKeyOrignalList == null || value.___styleKeyOrignalList.Count == 0)
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("BUGBUG Key is zero : " + value.SelectorID);
                }
                return;

            }
            base.Insert(index, value);

        }


		/// <summary>
		/// Search for Elements appropiate styles from ground list and parent elements
		/// Resulsts are stored into element nextNodeStyle or currentNodeStyle.
		/// No returning object.
		/// </summary>
		/// <param name="__element"></param>
		public void CreateCHtmlStyleElementCandidateListIntoElement(CHtmlElement __element)
		{
      

            

             
             
             

             
			
            CHtmlStopWatch ___ListLoolupWatch = null;
            System.Collections.Generic.Dictionary<int, int> srStyleGuidList = new System.Collections.Generic.Dictionary<int, int>();
			if(commonLog.LoggingEnabled && commonLog.LogLevel >= 1)
			{
				___ListLoolupWatch = new CHtmlStopWatch();
			}

			//string[] spClass = __element.@class.Split(' ');



            int classListCount = __element.___classList.___keyList.Count;

            if (classListCount > 0)
			{
				//===========================================================
				// Only 'Class' allows multiple entry with single space
				//===========================================================
				//spClass = __element.className.Split(' ');

                foreach( string cClass in __element.___classList.___keyList.Keys)
				{
					if(cClass.Length != 0)
					{
						this.BinarySearchComposingArrayListWithString( __element,  "." + cClass,  ref srStyleGuidList);
						this.BinarySearchComposingArrayListWithString( __element, __element.tagName + "." + cClass, ref srStyleGuidList);
						//   _TagName + _CssID + _CssClass;
						if(string.IsNullOrEmpty(__element.___idLowSimple) == false)
						{
							this.BinarySearchComposingArrayListWithString(__element,  "#" + __element.___idLowSimple  + "." + cClass, ref srStyleGuidList);
							this.BinarySearchComposingArrayListWithString(__element, __element.tagName + "#" + __element.___idLowSimple  + "." + cClass,ref srStyleGuidList);

						}

					}
				}
			}
			if(string.IsNullOrEmpty(__element.___idLowSimple) == false)
			{
				this.BinarySearchComposingArrayListWithString( __element, "#" + __element.___idLowSimple,  ref srStyleGuidList);
				this.BinarySearchComposingArrayListWithString( __element, __element.tagName + "#" + __element.___idLowSimple, ref srStyleGuidList);
			}
			// =====================================================
			//                  Search By TagName
			// =====================================================
			if(string.IsNullOrEmpty(__element.___tagName) == false)
			{
				this.BinarySearchComposingArrayListWithString( __element, __element.___tagName,  ref srStyleGuidList);
			}
			// =====================================================
			//                  Search By WildCard
			// =====================================================
			this.BinarySearchComposingArrayListWithString( __element, "*",  ref srStyleGuidList);

		
			


			CHtmlElement __parentElement = __element.___parent as CHtmlElement;
			if(__parentElement != null)
			{
				CHtmlStopWatch ___CSSParentLookupWatch = null;
				if(commonLog.LoggingEnabled && commonLog.LogLevel >= 1)
				{
					___CSSParentLookupWatch = new CHtmlStopWatch();
				}


				
				if(__parentElement == null)
				{
					return;
				}
				CHtmlStyleKey searchKey = null;

				if(commonHTML.UseCSSRecursion == true)
				{
					searchKey= new CHtmlStyleKey();
					searchKey.TagName = __element.tagName;
                    searchKey.___elementTagType = __element.___elementTagType;
					
					if(__element.___classList.___keyList.Count > 0)
					{
                        foreach (string strKey in __element.___classList.___keyList.Keys)
                        {
                            searchKey.___classList.Add(strKey);
                        }

						//searchKey.CssClass = "." + __element.___classList.___keyList.Keys[__element.___classList.Count -1 ];
                        searchKey.CssClass = "." + __element.___classList.___keyList.Keys.GetEnumerator().Current;
					}
					if(string.IsNullOrEmpty(__element.___idLowSimple) == false)
					{
						searchKey.CssID = "#" + __element.___idLowSimple;
					}
					// ===============================================================================
					// Legacy support 
					// We used to be create ArrayList to store all styls first in one arraylist (regardless of hit or nextnode) and resort later.
					// It is time consuming to change old code. so leave as this.
					// ===============================================================================
					ArrayList arCandidates = new ArrayList();
					__parentElement.InvestigateParentCHtmlStyleElement(ref searchKey, ref  arCandidates, ref __element, ref srStyleGuidList);
					int arCandidatesCount = arCandidates.Count;
					for(int o = 0; o < arCandidatesCount; o ++)
					{
						CHtmlCSSRule __oStyle = arCandidates[o] as CHtmlCSSRule;
						if(__oStyle != null)
						{
							if(__oStyle.___isCSSRuleForThisNode == true)
							{
								__element.___stylesheetsForCurrentNodeList.Add(__oStyle);
							}
							else
							{
								__element.___stylesheetsForNextNodeList.Add(__oStyle);
                                if (__oStyle.___WorkingSelectorClassKey != null)
                                {
                                    __element.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType = __element.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType | __oStyle.___WorkingSelectorClassKey.___SelectorKeyDefinedField;
                                }
							}
						}
					}
				}
				else
				{
					CHtmlElement __currentParent = __parentElement;
					int __WhileLoopCount = 0;
					try
					{
					    //bool LookupAdjacentElement = false;
						while(__currentParent != null)
						{
							__WhileLoopCount++;
							if(__WhileLoopCount >= 500)
							{
								if(commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
								{
									commonLog.LogEntry("GetCHtmlStyleElementCandidateArrayList cancelled due to 500 : "  + __element.ToString());
									break;
								}
							}
							if(__currentParent.___stylesheetsForNextNodeList.Count > 0)
							{
								if(__currentParent.___stylesheetsForNextNodeListWorkingSelectorMaximumCount > 0)
								{
									try
									{

										if(string.IsNullOrEmpty(__element.___idLowSimple) == false)
										{
                                            if ((__currentParent.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType & CHtmlSelectorKeyClassType.ID) == CHtmlSelectorKeyClassType.ID)
                                            {
                                                CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __currentParent, "#" + __element.___idLowSimple, ref srStyleGuidList, false, '\0');
                                            }

if ((__currentParent.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType & CHtmlSelectorKeyClassType.TagName_ID_Combination) == CHtmlSelectorKeyClassType.TagName_ID_Combination)
{
    CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __currentParent, __element.tagName + "#" + __element.___idLowSimple, ref srStyleGuidList, false, '\0');
}
										}
                                        if (classListCount > 0 && ((__currentParent.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType & CHtmlSelectorKeyClassType.ClassName) == CHtmlSelectorKeyClassType.ClassName))
										{
                                            foreach (string cClass in  __element.___classList.___keyList.Keys)
											{
												if(string.IsNullOrEmpty(cClass) == false)
												{
                                 
                                                        CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __currentParent, "." + cClass, ref srStyleGuidList, false, '\0');
                                                    
                                                    if ((__currentParent.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType & CHtmlSelectorKeyClassType.TagName_ClassName_Combination) == CHtmlSelectorKeyClassType.TagName_ClassName_Combination)
                                                    {
                                                        CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __currentParent, __element.tagName + "." + cClass, ref srStyleGuidList, false, '\0');
                                                    }
                                                        if (string.IsNullOrEmpty(__element.___idLowSimple) == false)
                                                        {
                                                            //   _TagName + _CssID + _CssClass;
                                                            if ((__currentParent.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType & CHtmlSelectorKeyClassType.ClassName_ID_Combinaion) == CHtmlSelectorKeyClassType.ClassName_ID_Combinaion)
                                                            {
                                                                CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __currentParent, "#" + __element.___idLowSimple + "." + cClass, ref srStyleGuidList, false, '\0');
                                                            }
                                                            if ((__currentParent.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType & CHtmlSelectorKeyClassType.TagName_ClassName_ID_Combination) == CHtmlSelectorKeyClassType.TagName_ClassName_ID_Combination)
                                                            {
                                                                CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __currentParent, __element.tagName + "#" + __element.___idLowSimple + "." + cClass, ref srStyleGuidList, false, '\0');
                                                            }

                                                        }
                                                    
												}
											}
										}
										// ===========================================================================
                                        // Seach By Tag Name or Wild Card (DO NOT Check ___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType !)
										// ==========================================================================
                                        if ((__currentParent.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType & CHtmlSelectorKeyClassType.Wildcard) == CHtmlSelectorKeyClassType.Wildcard)
                                        {
                                            CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __currentParent, "*", ref srStyleGuidList, false, '\0');
                                        }
                                       
                                        if ((__currentParent.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType & CHtmlSelectorKeyClassType.TagName) == CHtmlSelectorKeyClassType.TagName )
                                        
                                        {
                                            CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __currentParent, __element.tagName, ref srStyleGuidList, false, '\0');
                                        }
									}
									catch(Exception ex)
									{
										if(commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
										{
											commonLog.LogEntry("PerformElementStyleListsBinarySearchComposingArrayListWithString for parent Element Error ", ex);
										}
									
									}

						



								}
								else
								{
									// ============================================================================================
									// Means it ___hasInner styleList > 0 but element.___stylesheetsForNextNodeListWorkingSelectorMaximumCount == 0
									// any parent should not have Working Selector alive here.
									// ============================================================================================
						
			                        /*
#if DEBUG
									int __currentParentStylesheetsForNextNodeListCount = __currentParent.___stylesheetsForNextNodeList.Count;
									for(int s = __currentParentStylesheetsForNextNodeListCount -1; s >= 0 ; s --)
									{
										CHtmlCSSStyleSheet __testStyle = __currentParent.___stylesheetsForNextNodeList[s] as CHtmlCSSStyleSheet;
										if(__testStyle != null)
										{
											if(__testStyle.___styleKeyWorkingList.Count > 0)
											{
												commonLog.LogEntry("BUGBUG!!! {0} ___hasInner Working Style Key Never Looked up from child",  __currentParent);
												break;
											}
										}
									}
									
#endif
                                     */
								}
							}
							__currentParent = __currentParent.___parent as CHtmlElement;
						}
					}
					catch(Exception ex)
					{
						commonLog.LogEntry("GetCHtmlStyleElementCandiateArrayList WhileLoop : " + __element.ToString(), ex);
					}
				}


				// CHtmlElement __prevElement = __element._x__PreviousNodeElement;
				try
				{
					if(__parentElement != null && __parentElement.___HasCSSAdjacentSiblingCombinatorInChildren == true)
					{ 
						// "+" Check
						if(__element.___ChildNodeIndex > 0)
						{
							int ___NodeIndex = __element.___ChildNodeIndex -1;
							int ___CurrentLoop = 0;
							CHtmlElement ___adjacentSiblingContainingElement = __parentElement.___childNodes[___NodeIndex] as CHtmlElement;
							while(___adjacentSiblingContainingElement != null && object.ReferenceEquals(___adjacentSiblingContainingElement, __element) == false)
							{
								___CurrentLoop ++;
								if(___CurrentLoop > 100)
								{
									if(commonLog.LoggingEnabled && commonLog.LogLevel >= 1)
									{
										commonLog.LogEntry("BUGBUG Adjacent Sibling Enters Infinite Loop");
									}
									break;
								}
								if(commonHTML.IsElemeneITextOrIDrawOrComment(___adjacentSiblingContainingElement) == false)
								{
									if(___adjacentSiblingContainingElement.___HasCSSAdjacentSiblingCombinator == false)
									{
										goto AdjacentSiblingCombinatorCheckDone;
									}
									else
									{
										//commonLog.LogEntry("{0} ___hasInner + combinator to check", ___adjacentSiblingContainingElement);
										try
										{
											CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, ___adjacentSiblingContainingElement, "*", ref srStyleGuidList, true, '+');
											CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, ___adjacentSiblingContainingElement, __element.tagName, ref srStyleGuidList, true, '+');
											if(string.IsNullOrEmpty(__element.___idLowSimple) == false)
											{
												CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, ___adjacentSiblingContainingElement, "#" + __element.___idLowSimple,  ref srStyleGuidList, true, '+');
												CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, ___adjacentSiblingContainingElement, __element.tagName + "#" + __element.___idLowSimple,  ref srStyleGuidList,  true, '+');
											}
											if(__element.___classList.Count > 0)
											{
												foreach(string cClass in  __element.___classList.___keyList.Keys)
												{
												
													if(cClass.Length != 0)
													{
														CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString( __element, ___adjacentSiblingContainingElement,  "." + cClass, ref srStyleGuidList, true, '+');
														CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString( __element, ___adjacentSiblingContainingElement, __element.tagName + "." + cClass,  ref srStyleGuidList,  true, '+');
														if(string.IsNullOrEmpty(__element.___idLowSimple) == false)
														{
															//   _TagName + _CssID + _CssClass;
															CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, ___adjacentSiblingContainingElement, "#" + __element.___idLowSimple  + "." + cClass,  ref srStyleGuidList,  true, '+');
															CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element,___adjacentSiblingContainingElement, __element.tagName + "#" + __element.___idLowSimple  + "." + cClass, ref srStyleGuidList,  true, '+');

														}
													}
												}
											}
										}
										catch(Exception ex)
										{
											if(commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
											{
												commonLog.LogEntry("PerformElementStyleListsBinarySearchComposingArrayListWithString for parent Element Error ", ex);
											}
									
										}
										goto AdjacentSiblingCombinatorCheckDone;
									}
								}
								else
								{ 
									// #Text or Comment just continue
								}
								___NodeIndex --;
								if(	___NodeIndex < 0)
								{
									break;
								}
								___adjacentSiblingContainingElement = __parentElement.___childNodes[___NodeIndex] as CHtmlElement;
							}
						}

					}
				}
				catch(Exception ex)
				{
					if(commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
					{
						commonLog.LogEntry("GetCHtmlStyleElementCandidateArrayList AdjacentSibing Error", ex);
					}
				}
			AdjacentSiblingCombinatorCheckDone:
				// ==================================================================================================
				// * -------+--- [ ]
				//          |    [~] <= Has Indirect Combinator Element
				//          |    [ ]
				//          |    [~] <= Has Indirect Combinator Element
				//          +----[ ] <== This Element
				// ==================================================================================================

				try
				{
					if(__parentElement != null && __parentElement.___HasCSSIndirectAdjacentCombinatorInChildren == true && __element.___ChildNodeIndex > 0 && __parentElement.___childNodes.Count >= 2)
					{
						int __parentElementchildNodesCount = __parentElement.___childNodes.Count;
						for(int cn = 0; cn < __parentElementchildNodesCount; cn ++)
						{
							CHtmlElement __indirectAdjacentElement = __parentElement.___childNodes[cn] as CHtmlElement;
							if(__indirectAdjacentElement == null || __indirectAdjacentElement.___HasCSSIndirectAdjacentCombinator == false)
							{
								continue;
							}
							else if(object.ReferenceEquals(__indirectAdjacentElement, __element) == true)
							{
								break;
							}
							else if(__indirectAdjacentElement.___HasCSSIndirectAdjacentCombinator == true)
							{
								try
								{
									CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __indirectAdjacentElement, "*",  ref srStyleGuidList, true, '~');
									CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __indirectAdjacentElement, __element.tagName, ref srStyleGuidList, true, '~');
									if(string.IsNullOrEmpty(__element.___idLowSimple) == false)
									{
										CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __indirectAdjacentElement, "#" + __element.___idLowSimple, ref srStyleGuidList, true, '~');
										CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __indirectAdjacentElement, __element.tagName + "#" + __element.___idLowSimple, ref srStyleGuidList,  true, '~');
									}
									if(__element.___classList.Count > 0)
									{
										foreach(string cClass in __element.___classList.___keyList.Keys)
										{
											if(cClass.Length != 0)
											{
												CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString( __element, __indirectAdjacentElement,  "." + cClass, ref srStyleGuidList, true, '~');
												CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString( __element, __indirectAdjacentElement, __element.tagName + "." + cClass,  ref srStyleGuidList,  true, '~');
												if(string.IsNullOrEmpty(__element.___idLowSimple) == false)
												{
													//   _TagName + _CssID + _CssClass;
													CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element, __indirectAdjacentElement, "#" + __element.___idLowSimple  + "." + cClass,   ref srStyleGuidList,  true, '~');
													CHtmlCSSRuleGroundList.PerformElementStyleListsBinarySearchComposingArrayListWithString(__element,__indirectAdjacentElement, __element.tagName + "#" + __element.___idLowSimple  + "." + cClass,  ref srStyleGuidList,  true, '~');

												}
											}
										}
									}
									continue;
								}
								catch(Exception ex)
								{
									if(commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
									{
										commonLog.LogEntry("PerformElementStyleListsBinarySearchComposingArrayListWithString for Indirect Ajdacent Combinator Search Error ", ex);
									}
									goto IndirectAdjacentCombinatorDone;
								}
								
							}
							else if(__indirectAdjacentElement.___ChildNodeIndex >= __element.___ChildNodeIndex)
							{ // '~' combinator should only happens in prior nodes
								goto IndirectAdjacentCombinatorDone;
							}
						}
					}
				}
				catch(Exception ex)
				{
					if(commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
					{
						commonLog.LogEntry("GetCHtmlStyleElementCandidateArrayList Indirect Adjacent Combinator Error", ex);
					}
				}
			IndirectAdjacentCombinatorDone:
				if(___CSSParentLookupWatch != null)
				{
					if(commonLog.LoggingEnabled && commonLog.LogLevel >= 1)
					{
						___CSSParentLookupWatch.Stop();
						if(__element.___documentWeakRef  != null)
						{
                            __element.___getDocument().___TotalCSSParentLookupTime += ___CSSParentLookupWatch.TotalMilliseconds;
						}
					}
					___CSSParentLookupWatch = null;
				}
			}
#if DEBUG

			commonLog.LogEntry("Element {0} found ___stylesheetsForCurrentNodeList : {1}",__element.toLogString(),__element.___stylesheetsForCurrentNodeList.Count);
#endif

			return;
		}





	
        public static void PerformElementStyleListsBinarySearchComposingArrayListWithString(CHtmlElement __element, CHtmlElement __lookupElement, string __searchString, ref System.Collections.Generic.Dictionary<int, int> srStyleGuidList, bool IsCombinatorSearch, char CombinatorChar)
		{
			CHtmlCSSRuleWorkingKeyStringComparer __compWork = new CHtmlCSSRuleWorkingKeyStringComparer();
            int pos = __lookupElement.___stylesheetsForNextNodeList.BinarySearch(createSearchStyleElementObject(ref __searchString,  false), new CHtmlWorkingCSSRuleAgainstStringComparer());
			if(pos > -1)
			{
				int found = 0;
				

				#region LookUp Upper
				int __lookupElementStylesheetsForNextNodeListCount = __lookupElement.___stylesheetsForNextNodeList.Count;
				for(int i = pos; i < __lookupElementStylesheetsForNextNodeListCount; i++)
				{
					CHtmlCSSRule oriPart = __lookupElement.___stylesheetsForNextNodeList[i];
					if(oriPart == null || oriPart.___isCSSRuleForThisNode == true)
					{
						continue;
					}
					if(IsCombinatorSearch == true && oriPart.___WorkingKeyCombinatorChar != '\0' && oriPart.___WorkingKeyCombinatorChar != CombinatorChar)
					{
						continue;
					}
					if(srStyleGuidList.ContainsKey(oriPart.GetHashCode()) == true)
					{
                        if (oriPart.___styleKeyOrignalList.Count <= 1)
                        {
                            // if original key count is less than 1, no element sub check should be occur.
                            continue;
                        }
                        // if stored key working class is equal. skip style
                        if (srStyleGuidList[oriPart.GetHashCode()] == oriPart.___styleKeyWorkingList.Count - 1)
                        {
                            continue;
                        }
					}
					if(__compWork.Compare(oriPart, __lookupElement.___stylesheetsForNextNodeList[pos]) == 0)
					{
						/* ***************************************************************************************** */
						/*                            | Element Level | Combinator   | LookUpElement                 */
						/* IsCombinatorSearch = False |    Yes        |  None or '>' | Parent or null                */
						/* IsCombinatorSearch = True  |    Yes        |  '+'  or '~' | Element (not null)            */
						/* ***************************************************************************************** */
					
						if((IsCombinatorSearch == false &&IsCHtmlStyleElementMatchesSurelyAsNormalMode(oriPart, __element,__lookupElement,  pos) || IsCombinatorSearch == true && IsCHtmlStyleElementMatchesSurelyAsCombinatorMode(oriPart, __element,__lookupElement,  pos, CombinatorChar)))
						{
							CHtmlCSSRule copyPart = oriPart.cloneCSSRule();
							int iWorkCount = copyPart.___styleKeyWorkingList.Count;
							if(iWorkCount > 0)
							{
								copyPart.___styleKeyWorkingList.RemoveAt(0);
								copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
								if(copyPart.___styleKeyWorkingList.Count == 0)
								{
									copyPart.___isCSSRuleForThisNode = true;
								}
								else
								{
									if(__element.___stylesheetsForNextNodeListWorkingSelectorMaximumCount   < copyPart.___styleKeyWorkingList.Count)
									{
										__element.___stylesheetsForNextNodeListWorkingSelectorMaximumCount  = copyPart.___styleKeyWorkingList.Count;
									}
									if(copyPart.___HasCombinatorChar == true && copyPart.___WorkingKeyCombinatorChar != '\0')
									{
										
										CHtmlElement __parentElement = __element.___parent as CHtmlElement;
										if(__element.___HasCSSIndirectAdjacentCombinator == false)
										{
											if(copyPart.___WorkingKeyCombinatorChar == '~')
											{
												__element.___HasCSSIndirectAdjacentCombinator = true;
											}
										
											if(__element.___HasCSSIndirectAdjacentCombinator == true &&  __parentElement !=null)
											{
											
												__parentElement.___HasCSSIndirectAdjacentCombinatorInChildren = true;
											}
										}
										if(__element.___HasCSSAdjacentSiblingCombinator == false)
										{
											if(copyPart.___WorkingKeyCombinatorChar == '+')
											{
												__element.___HasCSSAdjacentSiblingCombinator = true;
											}
											if(__element.___HasCSSAdjacentSiblingCombinator == true && __parentElement != null)
											{
												__parentElement.___HasCSSAdjacentSiblingCombinatorInChildren = true;
											}
										}
										
									}
								}
							} 
							else
							{
								copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
								if(commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
								{
									commonLog.LogEntry("Strange Style Selector ID '{0}'", copyPart.SelectorID);
								}
							}
                            srStyleGuidList[copyPart.GetHashCode()] = copyPart.___styleKeyWorkingList.Count;
							
							if(__element.___stylesheetsForNextNodeListOriginalSelectorMaximumCount   < copyPart.___styleKeyOrignalList.Count)
							{
								__element.___stylesheetsForNextNodeListOriginalSelectorMaximumCount   = copyPart.___styleKeyOrignalList.Count;
							}
							
							if(copyPart.___isCSSRuleForThisNode == true)
							{
								__element.___stylesheetsForCurrentNodeList.Add(copyPart);
							}
							else
							{
								__element.___stylesheetsForNextNodeList.Add(copyPart);
                                if (copyPart.___WorkingSelectorClassKey != null)
                                {
                                    __element.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType = __element.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType | copyPart.___WorkingSelectorClassKey.___SelectorKeyDefinedField;
                                }
							}
							found ++;
						}
					}
					else
					{
						break;
					}
				}
				#endregion

				#region LookUp Down
				if(pos > 0)
				{
					for(int i = pos - 1; i >= 0; i--)
					{
						CHtmlCSSRule oriPart = __lookupElement.___stylesheetsForNextNodeList[i];
						if(oriPart == null || oriPart.___isCSSRuleForThisNode == true)
						{
							continue;
						}
                        if (srStyleGuidList.ContainsKey(oriPart.GetHashCode()) == true)
                        {
                            if (oriPart.___styleKeyOrignalList.Count <= 1)
                            {
                                // if original key count is less than 1, no element sub check should be occur.
                                continue;
                            }
                            // if stored key working class is equal. skip style
                            if (srStyleGuidList[oriPart.GetHashCode()] == oriPart.___styleKeyWorkingList.Count - 1)
                            {
                                continue;
                            }
                        }
						if(IsCombinatorSearch == true && oriPart.___WorkingKeyCombinatorChar != '\0' && oriPart.___WorkingKeyCombinatorChar != CombinatorChar)
						{
							continue;
						}
						if(__compWork.Compare(oriPart, __lookupElement.___stylesheetsForNextNodeList[pos]) == 0)
						{
							/* ***************************************************************************************** */
							/*                            | Element Level | Combinator   | LookUpElement                 */
							/* IsCombinatorSearch = False |    Yes        |  None or '>' | Parent or null                */
							/* IsCombinatorSearch = True  |    Yes        |  '+'  or '~' | Element (not null)            */
							/* ***************************************************************************************** */
							if((IsCombinatorSearch == false &&IsCHtmlStyleElementMatchesSurelyAsNormalMode(oriPart, __element,__lookupElement,  pos) || IsCombinatorSearch == true && IsCHtmlStyleElementMatchesSurelyAsCombinatorMode(oriPart, __element,__lookupElement,  pos, CombinatorChar)))
							{
								CHtmlCSSRule copyPart = oriPart.cloneCSSRule();
								int iWorkCount = copyPart.___styleKeyWorkingList.Count;
								if(iWorkCount > 0)
								{
									copyPart.___styleKeyWorkingList.RemoveAt(0);
									copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
									if(copyPart.___styleKeyWorkingList.Count == 0)
									{
										copyPart.___isCSSRuleForThisNode = true;
									}
									else
									{
										if(__element.___stylesheetsForNextNodeListWorkingSelectorMaximumCount   < copyPart.___styleKeyWorkingList.Count)
										{
											__element.___stylesheetsForNextNodeListWorkingSelectorMaximumCount  = copyPart.___styleKeyWorkingList.Count;
										}
										
										if(copyPart.___HasCombinatorChar == true && copyPart.___WorkingKeyCombinatorChar != '\0')
										{
											CHtmlElement __parentElement = __element.___parent as CHtmlElement;
											if(__element.___HasCSSIndirectAdjacentCombinator == false)
											{
												if(copyPart.___WorkingKeyCombinatorChar == '~')
												{
													__element.___HasCSSIndirectAdjacentCombinator = true;
												}
												if(__element.___HasCSSIndirectAdjacentCombinator == true && __parentElement != null)
												{
													__parentElement.___HasCSSIndirectAdjacentCombinatorInChildren = true;
												}
											}
											if(__element.___HasCSSAdjacentSiblingCombinator == false)
											{
												if(copyPart.___WorkingKeyCombinatorChar == '+')
												{
													__element.___HasCSSAdjacentSiblingCombinator = true;
												}
												if(__element.___HasCSSAdjacentSiblingCombinator == true && __parentElement != null)
												{
													__parentElement.___HasCSSAdjacentSiblingCombinatorInChildren = true;
												}
											}
											
										}
										
									}
								} 
								else
								{
									copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
									if(commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
									{
										commonLog.LogEntry("Strange Style Selector ID '{0}'", copyPart.SelectorID);
									}
								}
								
								if(__element.___stylesheetsForNextNodeListOriginalSelectorMaximumCount   < copyPart.___styleKeyOrignalList.Count)
								{
									__element.___stylesheetsForNextNodeListOriginalSelectorMaximumCount   = copyPart.___styleKeyOrignalList.Count;
								}
								
								if(copyPart.___isCSSRuleForThisNode == true)
								{
									__element.___stylesheetsForCurrentNodeList.Add(copyPart);
								}
								else
								{
									__element.___stylesheetsForNextNodeList.Add(copyPart);
                                    if (copyPart.___WorkingSelectorClassKey != null)
                                    {
                                        __element.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType = __element.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType | copyPart.___WorkingSelectorClassKey.___SelectorKeyDefinedField;
                                    }
								}
								found ++;
							}
						}
						else
						{
							break;
						}
					}
				}
				#endregion
				// ================================================================================
				// Multiple Class and Sufix Test
				// ================================================================================

				// ================================================================================

			}
		}

        /// <summary>
        /// Create one instance of CHtmlCSSStyleSheet to compare Ground Key or Working key string
        /// </summary>
        /// <param name="___str"></param>
        /// <param name="___IsGround"></param>
        /// <returns></returns>
        public static CHtmlCSSRule createSearchStyleElementObject(ref string ___str, bool ___IsGround)
        {
            CHtmlCSSRule ___seachStyle = new CHtmlCSSRule(CHtmlElementStyleType.None);
            if (___str != null)
            {
                if (___IsGround == false)
                {
                    ___seachStyle.___WorkingKey = ___str;
                }
                else
                {
                    ___seachStyle.___GroundSortKey = ___str;
                }
            }
            else
            {
                // just for in case.
                ___seachStyle.___WorkingKey = "";
                ___seachStyle.___GroundSortKey = "";
            }
            return ___seachStyle;
        }


		/// <summary>
		/// Latest Implementation
		/// </summary>
		/// <param name="__element">Seach OriginElement</param>
		/// <param name="__searchString">SearchString</param>
		/// <param name="ar">Target ArrayList to store CHtmlCSSStyleSheet</param>
        public void BinarySearchComposingArrayListWithString(CHtmlElement __element, string __searchString, ref System.Collections.Generic.Dictionary<int, int> _hitList)
		{

            System.Collections.Generic.Dictionary<string, string> ___DisabledLikList = null;
            if (__element.___Document != null)
            {
                ___DisabledLikList = __element.___Document.___LinkDisabledHerfList;
            }
            else
            {
#if DEBUG
                commonLog.LogEntry("Strange ___element___document is null... but cont...");
#endif
            }
			if(__element.___stylesheetsForNextNodeList != null && __element.___stylesheetsForNextNodeList.Count > STYLE_GROUND_SEARCH_NODE_ITEM_COUNT_LIMIT)
			{
				return;
			}
            int pos = this.BinarySearch(createSearchStyleElementObject(ref __searchString, true), new CHtmlCSSRuleGroundKeyAgainstStringComparer());
			if(pos > -1)
			{
				int found = 0;
				

				#region LookUp Upper
				int ___thisCount = this.Count;
				for(int i = pos; i < ___thisCount; i++)
				{
					CHtmlCSSRule oriPart = this[i] as CHtmlCSSRule;
                    if (oriPart == null)
                    {
                        continue;
                    }

					if(this.___compGround.Compare(oriPart, this[pos] as CHtmlCSSRule) == 0)
					{
                        if (___DisabledLikList != null && ___DisabledLikList.Count > 0 && ___DisabledLikList.ContainsKey(oriPart.___baseUrl) == true)
                        {
                            continue;
                        }
                        if (_hitList != null && _hitList.ContainsKey(oriPart.GetHashCode()) == true)
                        {
                            continue;
                        }
                        if (oriPart.___AttributesItemCount != 0)
                        {
                            if (__element.___attributes.Count == 0)
                            {
                                continue;
                            }
                            else
                            {

                            }
                        }
						if(IsCHtmlStyleElementMatchesSurelyAsNormalMode(oriPart, __element, null, pos))
						{
							CHtmlCSSRule copyPart = oriPart.cloneCSSRule();
							int iWorkCount = copyPart.___styleKeyWorkingList.Count;
							if(iWorkCount > 0)
							{
								copyPart.___styleKeyWorkingList.RemoveAt(0);
								copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
								if(copyPart.___styleKeyWorkingList.Count == 0)
								{
									copyPart.___isCSSRuleForThisNode = true;
								}
								else
								{
									if(__element.___stylesheetsForNextNodeListWorkingSelectorMaximumCount   < copyPart.___styleKeyWorkingList.Count)
									{
										__element.___stylesheetsForNextNodeListWorkingSelectorMaximumCount  = copyPart.___styleKeyWorkingList.Count;
									}
									if(copyPart.___HasCombinatorChar == true && copyPart.___WorkingKeyCombinatorChar !='\0')
									{
										CHtmlElement __parentElement = __element.___parent as CHtmlElement;
										if(__element.___HasCSSIndirectAdjacentCombinator == false)
										{
											if(copyPart.___WorkingKeyCombinatorChar == '~')
											{
												__element.___HasCSSIndirectAdjacentCombinator = true;
											}
											if(__element.___HasCSSIndirectAdjacentCombinator == true && __parentElement != null)
											{
												__parentElement.___HasCSSIndirectAdjacentCombinatorInChildren = true;
											}

										}
										if(__element.___HasCSSAdjacentSiblingCombinator == false)
										{
											if(copyPart.___WorkingKeyCombinatorChar == '+')
											{
												__element.___HasCSSAdjacentSiblingCombinator = true;
											}
											if(__element.___HasCSSAdjacentSiblingCombinator == true && __parentElement != null)
											{
												__parentElement.___HasCSSAdjacentSiblingCombinatorInChildren = true;
											}
										}
									}
								}
							} 
							else
							{
								copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
								if(commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
								{
									commonLog.LogEntry("Strange Style Selector ID '{0}'", copyPart.SelectorID);
								}
							}
							if(__element.___stylesheetsForNextNodeListOriginalSelectorMaximumCount   < copyPart.___styleKeyOrignalList.Count)
							{
								__element.___stylesheetsForNextNodeListOriginalSelectorMaximumCount   = copyPart.___styleKeyOrignalList.Count;
							}
                            if (_hitList != null)
                            {
                                _hitList[copyPart.GetHashCode()] = copyPart.___styleKeyWorkingList.Count;
                            }
							if(copyPart.___isCSSRuleForThisNode == true)
							{
								__element.___stylesheetsForCurrentNodeList.Add(copyPart);
							}
							else
							{
								__element.___stylesheetsForNextNodeList.Add(copyPart);
                                if (copyPart.___WorkingSelectorClassKey != null)
                                {
                                    __element.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType = __element.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType | copyPart.___WorkingSelectorClassKey.___SelectorKeyDefinedField;
                                }
							}
							
							if(__element.___stylesheetsForNextNodeList.Count > STYLE_GROUND_SEARCH_NODE_ITEM_COUNT_LIMIT)
							{
								if(commonLog.LoggingEnabled && commonLog.LogLevel > 8)
								{
									commonLog.LogEntry("CSS Ground Search Has Found {0} items for Elment {1}. abort.", __element.___stylesheetsForNextNodeList.Count, __element);
								}
								return;
							}
							
							found ++;
						}
					}
					else
					{
						break;
					}
				}
				#endregion

				#region LookUp Down
				if(pos > 0)
				{
					for(int i = pos - 1; i >= 0; i--)
					{
						CHtmlCSSRule oriPart = this[i] as CHtmlCSSRule;
                        if (oriPart == null)
                        {
                            continue;
                        }
	
                        if (this.___compGround.Compare(oriPart, this[pos] as CHtmlCSSRule) == 0)
						{
                            if (___DisabledLikList != null && ___DisabledLikList.Count > 0 && ___DisabledLikList.ContainsKey(oriPart.___baseUrl) == true)
                            {
                                continue;
                            }
                            if (_hitList != null && _hitList.ContainsKey(oriPart.GetHashCode()) == true)
                            {
                                continue;
                            }
                            if (oriPart.___AttributesItemCount > 0)
                            {
                                if (__element.___attributes.Count == 0)
                                {
                                    continue;
                                }
                                else
                                {

                                }
                            }
							if(IsCHtmlStyleElementMatchesSurelyAsNormalMode(oriPart, __element,null, pos))
							{

								CHtmlCSSRule copyPart = oriPart.cloneCSSRule();
								int iWorkCount = copyPart.___styleKeyWorkingList.Count;
								if(iWorkCount > 0)
								{
									copyPart.___styleKeyWorkingList.RemoveAt(0);
									copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
									if(copyPart.___styleKeyWorkingList.Count == 0)
									{
										copyPart.___isCSSRuleForThisNode = true;
									}
									else
									{
										
										if(__element.___stylesheetsForNextNodeListWorkingSelectorMaximumCount   <  copyPart.___styleKeyWorkingList.Count)
										{
											__element.___stylesheetsForNextNodeListWorkingSelectorMaximumCount  = copyPart.___styleKeyWorkingList.Count;
										}
										if(copyPart.___HasCombinatorChar == true && copyPart.___WorkingKeyCombinatorChar != '0')
										{
											CHtmlElement __parentElement = __element.___parent as CHtmlElement;
										
											if(__element.___HasCSSIndirectAdjacentCombinator == false)
											{
												if(copyPart.___WorkingKeyCombinatorChar == '~')
												{
													__element.___HasCSSIndirectAdjacentCombinator = true;
												}
												if(__element.___HasCSSIndirectAdjacentCombinator == true && __parentElement != null)
												{
													__parentElement.___HasCSSIndirectAdjacentCombinatorInChildren = true;
												}

											}
											if(__element.___HasCSSAdjacentSiblingCombinator == false)
											{
												if(copyPart.___WorkingKeyCombinatorChar == '+')
												{
													__element.___HasCSSAdjacentSiblingCombinator = true;
												}
												if(__element.___HasCSSAdjacentSiblingCombinator == true && __parentElement != null)
												{
													__parentElement.___HasCSSAdjacentSiblingCombinatorInChildren = true;
												}
											}
										}
									}
								} 
								else
								{
									copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
									if(commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
									{
										commonLog.LogEntry("Strange Style Selector ID '{0}'", copyPart.SelectorID);
									}
								}
								if(__element.___stylesheetsForNextNodeListOriginalSelectorMaximumCount   < copyPart.___styleKeyOrignalList.Count)
								{
									__element.___stylesheetsForNextNodeListOriginalSelectorMaximumCount   = copyPart.___styleKeyOrignalList.Count;
								}
                                if (_hitList != null)
                                {
                                    _hitList[copyPart.GetHashCode()] = copyPart.___styleKeyWorkingList.Count;
                                }
								
				
								if(copyPart.___isCSSRuleForThisNode == true)
								{
									__element.___stylesheetsForCurrentNodeList.Add(copyPart);
								}
								else
								{
									__element.___stylesheetsForNextNodeList.Add(copyPart);
                                    if (copyPart.___WorkingSelectorClassKey != null)
                                    {
                                        __element.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType = __element.___stylesheetsForNextNodeListNextLevelTopSelectorKeyClassType | copyPart.___WorkingSelectorClassKey.___SelectorKeyDefinedField;
                                    }
								}
								if(__element.___stylesheetsForNextNodeList.Count > STYLE_GROUND_SEARCH_NODE_ITEM_COUNT_LIMIT)
								{
									if(commonLog.LoggingEnabled && commonLog.LogLevel > 5)
									{
										commonLog.LogEntry("CSS Ground Search Has Found {0} items for Elment {1}. abort.", __element.___stylesheetsForNextNodeList, __element);
									}
									return;
								}
								found ++;
							}
						}
						else
						{
							break;
						}
					}
				}
				#endregion
				// ================================================================================
				// Multiple Class and Sufix Test
				// ================================================================================

				// ================================================================================

			}
		}


		public void BinarySearchComposingArrayList(CHtmlElement __element, CHtmlCSSRule __searchPart, ref ArrayList ar)
		{
            int pos = this.BinarySearch(__searchPart, new CHtmlCSSRuleGroundKeyAgainstStringComparer());
			if(pos > -1)
			{
				int found = 0;
				
				/*
				[解説]
				
				value か、または array の各要素のいずれかが、比較に使用される IComparable 
				インターフェイスを実装する必要があります。array の要素が、 IComparable 実
				装に基づいて、昇順にまだ並べ替えられていない場合は、結果が正しくない可能性
				があります。

				重複する要素を使用できます。 Array に value と等しい要素が複数含まれている
				場合、このメソッドは 1 つの要素のインデックスしか返しませんが、必ずしも該当
				する 1 番目の要素のインデックスとは限りません。

				null 参照 (Visual Basic では Nothing) は、常に他の任意の型と比較できます。
				したがって、 null 参照 (Nothing) との比較で、例外は生成されません。並べ替
				え処理では、 null 参照 (Nothing) は、他のすべてのオブジェクトより小さいと
				見なされます。

				指定した値が Array に格納されていない場合、このメソッドは負の整数を返し
				ます。返されたこの負数にビットごとの補数演算子 (~) を適用し、指定した検
				索値よりも大きい要素がある場合は、そのうちの最初の要素のインデックスを生
				成できます。
				*/
				#region LookUp Upper
				int thisCount = this.Count;
				for(int i = pos; i < thisCount; i++)
				{
					CHtmlCSSRule oriPart = this[i] as CHtmlCSSRule;
                    if (oriPart == null)
                    {
                        continue;
                    }
                    if (this.___compGround.Compare(oriPart, this[pos] as CHtmlCSSRule) == 0)
					{
                        if (oriPart.___AttributesItemCount > 0)
                        {
                            if (__element.___attributes.Count == 0)
                            {
                                continue;
                            }
                            else
                            {

                            }
                        }
						if(IsCHtmlStyleElementMatchesSurelyAsNormalMode(oriPart, __element, null, pos))
						{
							CHtmlCSSRule copyPart = oriPart.cloneCSSRule();
							int iWorkCount = copyPart.___styleKeyWorkingList.Count;
							if(iWorkCount > 0)
							{
								copyPart.___styleKeyWorkingList.RemoveAt(0);
								copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
								if(copyPart.___styleKeyWorkingList.Count == 0)
								{
									copyPart.___isCSSRuleForThisNode = true;
								}
								else
								{
									/*
									if(__element.___MaxNumOfSelectorWorkingKeyCountInElement < iWorkCount)
									{
										__element.___MaxNumOfSelectorWorkingKeyCountInElement = iWorkCount;
									}
									*/
									if(__element.___HasCSSIndirectAdjacentCombinator == false)
									{
										__element.___HasCSSIndirectAdjacentCombinator = IsTopWorkingSelectorKeyContainsCombinator(copyPart, '~');
										if(__element.___HasCSSIndirectAdjacentCombinator == true && __element.___parentWeakRef  != null)
										{
                                            __element.___getParentElement().___HasCSSIndirectAdjacentCombinatorInChildren = true;
										}
									}
									if(__element.___HasCSSAdjacentSiblingCombinator == false)
									{
										__element.___HasCSSAdjacentSiblingCombinator = IsTopWorkingSelectorKeyContainsCombinator(copyPart, '+');
									}
								}
							} 
							else
							{
                                if (commonLog.LoggingEnabled)
                                {
                                    commonLog.LogEntry("Strange Style Selector ID '{0}'", copyPart.SelectorID);
                                }
							}
							ar.Add(copyPart);
							found ++;
						}
					}
					else
					{
						break;
					}
				}
				#endregion

				#region LookUp Down
				if(pos > 0)
				{
					for(int i = pos - 1; i >= 0; i--)
					{
						CHtmlCSSRule oriPart = this[i] as CHtmlCSSRule;
                        if (oriPart == null)
                        {
                            continue;
                        }
                        if (this.___compGround.Compare(oriPart, this[pos] as CHtmlCSSRule) == 0)
						{
                            if (oriPart.___AttributesItemCount > 0)
                            {
                                if (__element.___attributes.Count == 0)
                                {
                                    continue;
                                }
                                else
                                {

                                }
                            }
							if(IsCHtmlStyleElementMatchesSurelyAsNormalMode(oriPart, __element, null, pos))
							{
								CHtmlCSSRule copyPart = oriPart.cloneCSSRule();
								int iWorkCount = copyPart.___styleKeyWorkingList.Count;
								if(iWorkCount > 0)
								{
									copyPart.___styleKeyWorkingList.RemoveAt(0);
									copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
									if(copyPart.___styleKeyWorkingList.Count == 0)
									{
										copyPart.___isCSSRuleForThisNode = true;
									}
									else
									{
										/*
										if(__element.___MaxNumOfSelectorWorkingKeyCountInElement < iWorkCount)
										{
											__element.___MaxNumOfSelectorWorkingKeyCountInElement = iWorkCount;
										}
										*/
										if(copyPart.___HasCombinatorChar == true)
										{
											if(__element.___HasCSSIndirectAdjacentCombinator == false)
											{
												__element.___HasCSSIndirectAdjacentCombinator = IsTopWorkingSelectorKeyContainsCombinator(copyPart, '~');
												if(__element.___HasCSSIndirectAdjacentCombinator == true && __element.___parentWeakRef  != null)
												{
                                                    __element.___getParentElement().___HasCSSIndirectAdjacentCombinatorInChildren = true;
												}
											}
											if(__element.___HasCSSAdjacentSiblingCombinator == false)
											{
												__element.___HasCSSAdjacentSiblingCombinator = IsTopWorkingSelectorKeyContainsCombinator(copyPart, '+');
												if(__element.___HasCSSAdjacentSiblingCombinator == true)
												{
												}
											}
										}
									}
								} 
								else
								{
									copyPart.___ReCreateWorkingKeyIntoCHtmlStyleElement();
                                    if (commonLog.LoggingEnabled)
                                    {
                                        commonLog.LogEntry("Strange Style Selector ID '{0}'", copyPart.SelectorID);
                                    }
								}
								ar.Add(copyPart);
								found ++;
							}
						}
						else
						{
							break;
						}
					}
				}
				#endregion
				// ================================================================================
				// Multiple Class and Sufix Test
				// ================================================================================

				// ================================================================================

			}
		}
		public static bool IsTopWorkingSelectorKeyContainsCombinator(CHtmlCSSRule __style, char _combinator)
		{
			if(__style == null)
				return false;
			if(__style.___HasCombinatorChar == false || __style.___WorkingKeyCombinatorChar == '\0') // quick return
				return false;
			if(__style.___WorkingKeyCombinatorChar ==_combinator)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// Confirms CHtmlCSSStyleSheet attributes, Sufix, Combinator matches for the Element
		/// if lookupElement is set to null, means it is Ground Search
		/// </summary>
		/// <param name="_cloningPart">Checking Element</param>
		/// <param name="__element">Origin Element</param>
		/// <param name="__lookupElement">Current Lookingup Owner Node (Element Level Search Only)</param>
		/// <param name="pos"></param>
		/// <returns>True : Yes, it is matches.
		/// NO : No it does not match.
		/// </returns>
		public static bool IsCHtmlStyleElementMatchesSurelyAsCombinatorMode(CHtmlCSSRule _cloningPart, CHtmlElement __element, CHtmlElement __lookupElement, int pos, char CombinatorChar)
		{
			if(__element == null || _cloningPart == null)
				return true;


			//
			bool ___testResult = true;
			try
			{
				if(_cloningPart.___CSSHack != CSSHackType.None || _cloningPart.___NonSearchableStyleSheet == true)
				{
					return false;
				}
				if(__element.___elementTagType != CHtmlElementType.A && ( _cloningPart.___HasLinkPseudoClass == true|| _cloningPart.___HasVisitedPseudoClass == true))
				{
					return false;
				}
				if(_cloningPart.___styleKeyWorkingList.Count == 0)
				{
					return false;
				}
			
				if(_cloningPart.___styleKeyWorkingList.Count > 0)
				{
					CHtmlStyleKey _workKey = _cloningPart.___WorkingSelectorClassKey;
					if(_workKey != null)
					{
						if( _cloningPart.___PseudoClassCount > 0)
						{
                            if (_workKey.___pseudoTitleParamList != null && _workKey.___pseudoTitleParamList.Count > 0)
							{
								if(_workKey.IsSuffixMatchToElement(__element) == false)
								{
									return false;
								}
							}
						}
						if(_workKey.___classList.Count > 0)
						{
							// ================================================================
							// Okay _workingKey ___hasInner multiple class in the key
							// We cant all match for target element
							// ================================================================
							// DIV.article.section1.hogehoge
							// =================================================================
							int __ExpectClassCount = _workKey.___classList.Count;
							int __MatchClassCount = 0;
                            int __classListItemCount = __element.___classList.Count;
                            foreach (string strClass in __element.___classList.___keyList.Keys)
							{
								if(_workKey.___classList.ContainsKey(strClass))
								{
									__MatchClassCount++;
								}
							}
							if(__ExpectClassCount == __MatchClassCount)
							{
								___testResult = true;
							}
							else
							{
								___testResult = false;
								goto ReportResult;
							}
						}
                        if (___testResult == true && _workKey.___attributeKeyList != null && _workKey.___attributeKeyList.Count > 0)
						{
                            int ____workKeyAttributesCount = _workKey.___attributeKeyList.Count;
							foreach(CHtmlStyleElementSelectorKeyAttributeClass attriKey in _workKey.___attributeKeyList.Values)
							{
								if(string.Equals(attriKey.Name , "hidden", StringComparison.Ordinal) == true)
								{
									if(_workKey.TagName.Length == 0)
									{
										if(__element.___elementTagType != CHtmlElementType.INPUT)
										{
											___testResult = false;
											goto ReportResult;
										}
									}
								}
								if(__element.___attributes.ContainsKey(attriKey.Name))
								{
                                    if (attriKey.OperatorType  == CSSSelectorKeyOperataorType.none)
                                    {
                                        continue;
                                    }
									
									string __attributeValue = commonHTML.GetElementAttributeInString(__element, attriKey.Name);

                                    if (attriKey.IsValueMatches(__attributeValue) == true)
									{
										continue;
									}
									else
									{
										___testResult = false;
										goto ReportResult;
									}
								}
								else
								{
									___testResult = false;
									goto ReportResult;
								}
							}
						}
					}
				}
			}
			catch{}
			ReportResult:
				return ___testResult;
		}
		/// <summary>
		/// Confirms CHtmlCSSStyleSheet attributes, Sufix, Combinator matches for the Element
		/// if lookupElement is set to null, means it is Ground Search
		/// </summary>
		/// <param name="_cloningPart">Checking Element</param>
		/// <param name="__element">Origin Element</param>
		/// <param name="__lookupElement">Current Lookingup Owner Node (Element Level Search Only)</param>
		/// <param name="pos"></param>
		/// <returns>True : Yes, it is matches.
		/// NO : No it does not match.
		/// </returns>
		public static bool IsCHtmlStyleElementMatchesSurelyAsNormalMode(CHtmlCSSRule _cloningPart, CHtmlElement __element, CHtmlElement __lookupElement, int pos)
		{
			if(__element == null || _cloningPart == null)
				return true;
			//commonLog.LogEntry("Inspecting {0} : {1}", pos,  _cloningPart);
			bool ___testResult = true;
			try
			{
				if(_cloningPart.___CSSHack != CSSHackType.None || _cloningPart.___NonSearchableStyleSheet == true)
				{
					return false;
				}
				if(__element.___elementTagType != CHtmlElementType.A && ( _cloningPart.___HasLinkPseudoClass == true|| _cloningPart.___HasVisitedPseudoClass == true))
				{
					return false;
				}
			
				if(_cloningPart.___WorkingKeyClassList != null &&_cloningPart.___WorkingKeyClassList.Count > 0)
				{
					// ================================================================
					// Okay _workingKey ___hasInner multiple class in the key
					// We cant all match for target element
					// ================================================================
					// DIV.article.section1.hogehoge
					// =================================================================
                    int __ExpectClassCount = _cloningPart.___WorkingKeyClassList.Count;

					int __MatchClassCount = 0;
                    int __classListItemCount = __element.___classList.Count;
					foreach(string strElementClass in __element.___classList.___keyList.Keys)
                    {
                        if (_cloningPart.___WorkingKeyClassList.ContainsKey(strElementClass))
                        {
                            __MatchClassCount++;
                        }
					}
					if(__ExpectClassCount == __MatchClassCount)
					{
						___testResult = true;
					}
					else
					{
						___testResult = false;
						goto ReportResult;
					}
				}
                int ___cloningPartWorkingAttributekeyListCount = 0;
                if (_cloningPart.___WorkingKeyAttributeKeyList != null)
                {
                    ___cloningPartWorkingAttributekeyListCount = _cloningPart.___WorkingKeyAttributeKeyList.Count;
                }
                if (___testResult == true && _cloningPart.___WorkingKeyAttributeKeyList != null && ___cloningPartWorkingAttributekeyListCount > 0)
				{

					foreach( CHtmlStyleElementSelectorKeyAttributeClass? attriKeyNullable in _cloningPart.___WorkingKeyAttributeKeyList.Values)
					{
                       
						if(attriKeyNullable == null)
							continue;
                        CHtmlStyleElementSelectorKeyAttributeClass attriKey = attriKeyNullable.Value;
                        if (string.IsNullOrEmpty(attriKey.Name) == true)
                            continue;
						// ===========================================================================
						// Selector '[hidden]' only applied to Input
						// ===========================================================================
						if(string.Equals(attriKey.Name, "hidden",StringComparison.OrdinalIgnoreCase) == true)
						{
							if(_cloningPart.___WorkingSelectorClassKey != null)
							{
                                if (string.IsNullOrEmpty(_cloningPart.___WorkingSelectorClassKey.TagName) == true || (_cloningPart.___WorkingSelectorClassKey.TagName.Length == 1 && _cloningPart.___WorkingSelectorClassKey.TagName[0] == '*'))
								{
									if(__element.___elementTagType != CHtmlElementType.INPUT)
									{
										return false;
									}
								}
							}
							else if(__element.___elementTagType != CHtmlElementType.INPUT)
							{
								return false;
							}
						}
						if(__element.___attributes.ContainsKey(attriKey.Name))
						{
                            if (attriKey.OperatorType == CSSSelectorKeyOperataorType.none)
                            {
                                continue;
                            }
                            string __attributeValue = commonHTML.GetElementAttributeInString(__element, attriKey.Name);
			
									
							if(attriKey.IsValueMatches(__attributeValue) == true)
							{
								continue;
							}
							else
							{
								___testResult = false;
								goto ReportResult;
							}
						}
						else
						{
							___testResult = false;
							goto ReportResult;
						}
					}
				}
				if( _cloningPart.___WorkingKeyPseudoTitleList != null && _cloningPart.___WorkingKeyPseudoTitleList.Count   > 0)
				{
					if(_cloningPart.___WorkingSelectorClassKey != null && _cloningPart.___WorkingSelectorClassKey.IsSuffixMatchToElement(__element) == false)
					{
						return false;
					}
				
				}
				if(_cloningPart.___HasCombinatorChar == true)
				{
					if(_cloningPart.___WorkingKeyCombinatorChar == '\0')
					{
						// Other Combinator Should be failed at search level
						// Do Nothing
					}
					else if(_cloningPart.___WorkingKeyCombinatorChar == '>')
					{
						if(object.ReferenceEquals(__lookupElement, __element.___parent) == true)
						{
							goto ChildCombinatorCheckDone;
						}
						else
						{ // if __LookupElement is null it also fails
							___testResult = false;
							goto ReportResult;
						}
					}

				}
			ChildCombinatorCheckDone:
				if(false){;}


			}
			catch (Exception ex)
			{
				if(commonLog.LoggingEnabled && commonLog.LogLevel >5)
				{
					commonLog.LogEntry("IsCHtmlStyleElementMatchesSurelyAsNormalMode Error: ",ex);
				}
			}
			ReportResult:
			return ___testResult;
		}
	}
}
