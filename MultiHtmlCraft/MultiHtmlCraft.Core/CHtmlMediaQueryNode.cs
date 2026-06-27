using System;
using System.Collections;
using System.Text;

namespace MultiHtmlCraft.Core
{
	
    public enum CHtmlMediaQueryNodeType : byte
    {
        RootNode = 1,
        AndNode = 3,
        ORNode = 5,
        DataNode = 10
    }
	
    public class CHtmlMediaQueryTextPoint 
    {
        public int Start = 0;
        public int End = 1;
    }
	
	public enum CHtmlMediaQueryResult : byte
	{
		 None = 0,
		 OK = 1,
		 Fail = 2
	}
	
    public sealed class CHtmlMediaQueryNode
    {
        public MediaQueryOwnerElementType OwnerElementType = MediaQueryOwnerElementType.UNKNOWN;

        public System.Collections.ArrayList nodes = null;
        public CHtmlMediaQueryNodeType LogicNodeType = CHtmlMediaQueryNodeType.DataNode;
        private string _Text = null;
        public int ChildNodeIndex = 0;
        public int NodeLevel = 0;
        public string Name = null;
        public string Value = null;
        private int ConditionOrCount;
		public bool HasName = false;
		public bool HasValue = false;
		public CHtmlMediaQueryResult Result = CHtmlMediaQueryResult.None;
		public static CHtmlMediaQueryResult  DefaultUnknownParameterResult = CHtmlMediaQueryResult.OK;
        public double ValueRatio = 0;
        public bool HasValueRadio = false;
        public int MethodStackLevel = 0;

        public CHtmlMediaQueryNode(CHtmlMediaQueryNodeType logicType)
        {
            this.LogicNodeType = logicType;
            nodes = new ArrayList();
        }
		/// <summary>
		/// in comming Text should be lower cased and trimed.
		/// </summary>
        public string Text
        {
            set {
                this._Text = value.Trim();
                this.ProcessText();
            }
            get { return this._Text; }
        }
        public void PrintNode(string prefix)
        {
           commonLog.LogEntry("{0} + {1} ", prefix, this);
            foreach (CHtmlMediaQueryNode n in this.nodes)
                if (this.nodes.IndexOf(n) == this.nodes.Count - 1)
                    n.PrintNode(prefix + "    ");
                else
                    n.PrintNode(prefix + "   |");
        }

        public override string ToString()
        {
            if (this.Name.Length == 0 && this.Value.Length == 0)
            {
                return string.Format("Type : {0} NodeLevel : {1} Child {2}  Text : {3}", this.LogicNodeType.ToString(), this.NodeLevel, this.ChildNodeIndex,  this._Text);
            }
            else
            {
                return string.Format("Type : {0} NodeLevel : {1} Child {2} [\'{3}\'= \"{4}\"] Text : {5}", this.LogicNodeType.ToString(), this.NodeLevel, this.ChildNodeIndex, this.Name, this.Value, this._Text);
            }
        }
		internal CHtmlMediaQueryResult GetNodeNameValueResult()
		{
			double fValue = 0;
            if(commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry($"Calling {this.GetType().FullName}  GetNodeNameValueResult  {this.Name}...");
            }
			switch(this.Name)
			{
				case "max-device-width":
					
                    /*
					if(fValue >= 0 && fValue >= CHtmlWindowScreen.___width)
					{
						return CHtmlMediaQueryResult.OK;
					}
					else
					{
						return CHtmlMediaQueryResult.Fail;
					}
                    */
                    break;
                case "max-device-height":
                    // デバイスサイズの最大高さ。指定された値が画面より大きい場合に適用
                    fValue = commonHTML.GetDoubleValueFromString(this.Value, 0, -1);
                    if (fValue >= 0 && fValue >= CHtmlWindowScreen.___height)
                    {
                        return CHtmlMediaQueryResult.OK;
                    }
                    else
                    {
                        return CHtmlMediaQueryResult.Fail;
                    }

				case "min-device-width":
					// デバイスサイズの最小幅。このサイズより大きい場合に適用
					fValue = commonHTML.GetDoubleValueFromString(this.Value, 0, -1);
					if(fValue >= 0 && fValue <= CHtmlWindowScreen.___width)
					{
						return CHtmlMediaQueryResult.OK;
					}
					else
					{
						return CHtmlMediaQueryResult.Fail;
					}
				/* Comfirmed with Chrome and IE 2013 */
				case "max-width":
					// ビューエリアの最大幅。Should Be Greater Than Avail Width
					fValue = commonHTML.GetDoubleValueFromString(this.Value, 0, -1);
					if(fValue >= 0 && fValue >= CHtmlWindowScreen.___availWidth)
					{
						return CHtmlMediaQueryResult.OK;
					}
					else
					{
						return CHtmlMediaQueryResult.Fail;
					}
			
				/* Comfirmed with Chrome  */
				case "min-width":
					// ビューエリアの最小幅。値が availWidth より小さい場合に適用
					fValue = commonHTML.GetDoubleValueFromString(this.Value, 0, -1);
					if(fValue >= 0 && fValue <= CHtmlWindowScreen.___availWidth)
					{
                        //
                        // Get Value Ratio
                        this.HasValueRadio = true;
                        this.ValueRatio = 0 - (CHtmlWindowScreen.___availWidth / fValue);
						return CHtmlMediaQueryResult.OK;
					}
					else
					{
						return CHtmlMediaQueryResult.Fail;
					}
				case "device-width":
					/*
					 * <link rel="stylesheet" media="screen and (device-height: 600px)" />
					 * 
					 *  In the example above, the style sheet will apply only to screens that have exactly
					 *  600 vertical pixels. Note that the definition of the ‘px’ unit is the same as in
					 *  other parts of CSS.
					 * 
					 */
                    fValue = commonHTML.GetDoubleValueFromString(this.Value, 0,-1);
					if(fValue >= 0 && fValue == CHtmlWindowScreen.___width )
					{
						return CHtmlMediaQueryResult.OK;
					}
					else
					{
						return CHtmlMediaQueryResult.Fail;
					}

				case "device-height":
					/*
					 * <link rel="stylesheet" media="screen and (device-height: 600px)" />
					 * 
					 *  In the example above, the style sheet will apply only to screens that have exactly
					 *  600 vertical pixels. Note that the definition of the ‘px’ unit is the same as in
					 *  other parts of CSS.
					 * 
					 */
					fValue = commonHTML.GetDoubleValueFromString(this.Value, 0, -1);
					if(fValue >= 0 && fValue == CHtmlWindowScreen.___height )
					{
						return CHtmlMediaQueryResult.OK;
					}
					else
					{
						return CHtmlMediaQueryResult.Fail;
					}

				case "screen":
				case "only screen":
                case "screen and":
					break;
				case "only tv":
					return CHtmlMediaQueryResult.Fail;
				case "tv":
					break;
				case "all":
					break;
                case "only all":
                    return CHtmlMediaQueryResult.OK;
				case "print":
				case "only print":
				case "tty":
				case "braille":
					return CHtmlMediaQueryResult.Fail;
				case "aural":
					return CHtmlMediaQueryResult.Fail;
				case "projector":
				case "projection":
					break;
				case "handheld":
					return CHtmlMediaQueryResult.Fail;
                case "-webkit-device-pixel-ratio":
                case "device-pixel-ratio":
				case "-webkit-min-device-pixel-ratio":
				case "min-device-pixel-ratio":
				case "min--moz-device-pixel-ratio":
				case "-o-min-device-pixel-ratio":
				case "-moz-min-device-pixel-ratio":
					int posSlash = this.Value.IndexOf('/');
					if(posSlash > -1)
					{
						try
						{
							string strNum1 = this.Value.Substring(0, posSlash);
							string strNum2 = this.Value.Substring(posSlash +1 );
							fValue = float.Parse(strNum1) / float.Parse(strNum2);
						}
						catch
						{
							fValue = 1;
						}
					}
					else
					{
						fValue = commonHTML.GetDoubleValueFromString(this.Value, 0, -1);
					}
					if(fValue >= 1 && fValue <= 2)
					{
						return CHtmlMediaQueryResult.OK;
					}
					else
					{
						return CHtmlMediaQueryResult.Fail;
					}
				case "max-height":
					// ビューエリアの最大高さ。このサイズより小さい場合に適用
					 fValue = commonHTML.GetDoubleValueFromString(this.Value, 0, -1);
					if(fValue >= 0 && fValue >= CHtmlWindowScreen.___height)
					{
						return CHtmlMediaQueryResult.OK;
					}
					else
					{
						return CHtmlMediaQueryResult.Fail;
					}
					
				case "min-height":
					// ビューエリアの最小の高さ。このサイズより大きい場合に適用
					 fValue = commonHTML.GetDoubleValueFromString(this.Value, 0,-1);
					if(fValue >= 0 && fValue <= CHtmlWindowScreen.___height)
					{
						return CHtmlMediaQueryResult.OK;
					}
					else
					{
						return CHtmlMediaQueryResult.Fail;
					}
				case "max-resolution":
                    return ___IsResolutionSatisfy(this.Value, 1);
				case "min-resolution":
                    return ___IsResolutionSatisfy(this.Value, -1);
				case "resolution":
                    return ___IsResolutionSatisfy(this.Value, 0);
				case "orientation":
					if(string.Equals(this.Value,"landscape", StringComparison.OrdinalIgnoreCase) == true)
					{
						return CHtmlMediaQueryResult.OK;
					}
					else
					{
						return CHtmlMediaQueryResult.Fail;
					}
                case "height":
                case "width":
                    // =================================================
                    // IE11 and Chrome seems just ignore width and height regardless of value.
                    // =================================================
                    return CHtmlMediaQueryResult.OK;
				case "min-aspect-ratio":
					break;
				case "max-aspect-ratio":
					break;
				case "aspect-ratio":
					break;
				case "color":
					break;
				case "min-color":
					break;
				case "max-color":
					break;
				case "color-index":
					break;
				case "min-color-index":
					break;
				case "max-color-index":
					break;
				case "monochrome":
					return CHtmlMediaQueryResult.Fail;
				case "max-monochrome":
					return CHtmlMediaQueryResult.Fail;
				case "min-monochrome":
					return CHtmlMediaQueryResult.Fail;
				case "scan":
					break;
				case "grid":
					break;
				case "not all":
					return CHtmlMediaQueryResult.Fail;
				case "-moz-touch-enabled":
				case "-webkit-touch-enabled":
				case "-ms-touch-enabled":
				case "touch-enabled":
				case "-o-touch-enabled":
				case "-khtml-touch-enabled":
					return CHtmlMediaQueryResult.OK;
				case "-ms-high-contrast":
				case "high-contrast":
			    case "-moz-high-contrast":
				case "-webkit-high-contrast":
					return CHtmlMediaQueryResult.OK;
				case "and": // it may be processing Error but ignore...
					return CHtmlMediaQueryResult.OK;
				case "modernizr":
					return CHtmlMediaQueryResult.OK;
                case "-webkit-transform-3d":
                case "-moz-transform-3d":
                case "-Webkit-transform-3d":
                case "Webkit-transform-3d":
                case "transform-3d":
                case "-Moz-transform-3d":
                case "-O-transform-3d":
                case "-o-transform-3d":
                case "o-transform-3d":
                case "-ms-transform-3d":
                case "ms-transform-3d":
                case "-MS-transform-3d":
                case "-khtml-transform-3d":
                case "khtml-transform-3d":
                case "-Khtml-transform-3d":
                case "-KHTML-transform-3d":
                    return CHtmlMediaQueryResult.OK;
				default:
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
					{
						commonLog.LogEntry("Unknown Media Query Parameter Name {0} : {1} Returns : {2}", this.Name, this.Value,  DefaultUnknownParameterResult);
					}
					return DefaultUnknownParameterResult;
			}
			return CHtmlMediaQueryResult.OK;
		}
        public static CHtmlMediaQueryResult ___IsResolutionSatisfy(string ___value, int __pattern)
        {
            if (string.IsNullOrEmpty(___value) == true)
            {
                return CHtmlMediaQueryResult.OK;
            }
            else
            {
                string ___numberPart = null;
                string ___unitPart = null;
                int valueLen = ___value.Length;
                for (int i = 0; i < valueLen; i++)
                {
                    ___numberPart = null;
                    ___unitPart = null;
                    if(char.IsLetter(___value[i]))
                    {
                        ___numberPart = ___value.Substring(0, i);
                        ___unitPart = ___value.Substring(i);
                        if (string.IsNullOrEmpty(___unitPart) == false && (commonHTML.FasterIsWhiteSpaceLimited(___unitPart[0]) || commonHTML.FasterIsWhiteSpaceLimited(___unitPart[___unitPart.Length - 1])))
                        {
                            ___unitPart = ___unitPart.Trim();
                        }
                        goto JudgeMenentPart;
                    }
                }
                ___numberPart = ___value;
                ___unitPart = "";

            JudgeMenentPart:
                float ___valueFloat = 0;
            float.TryParse(___numberPart, out ___valueFloat);

            switch (__pattern)
            {
                case 0: // resolution
                    switch (___unitPart)
                    {
                        case "dpi":
                        case "DPI":
                        case "Dpi":
                            if (___valueFloat == CHtmlWindowScreen.___deviceXDPI)
                            {
                                return CHtmlMediaQueryResult.OK;
                            }
                            else
                            {
                                return CHtmlMediaQueryResult.Fail;
                            }
                        case "dpcm":
                        case "Dpcm":
                        case "DPCM":
                            if (___valueFloat == CHtmlWindowScreen.___deviceXDPI / 3)
                            {
                                return CHtmlMediaQueryResult.OK;
                            }
                            else
                            {
                                return CHtmlMediaQueryResult.Fail;
                            }
                        case "dppx":
                        case "Dppx":
                        case "DPPX":
                            break;
                        default:
                            break;
                    }
                    break;

                case 1: // max-resolutin
                    switch (___unitPart)
                    {
                        case "dpi":
                        case "Dpi":
                        case "DPI":
                            if (___valueFloat > CHtmlWindowScreen.___deviceXDPI)
                            {
                                return CHtmlMediaQueryResult.OK;
                            }
                            else
                            {
                                return CHtmlMediaQueryResult.Fail;
                            }
                            
                        case "dpcm":
                        case "Dpcm":
                        case "DPCM":
                            if (___valueFloat > CHtmlWindowScreen.___deviceXDPI / 3)
                            {
                                return CHtmlMediaQueryResult.OK;
                            }
                            else
                            {
                                return CHtmlMediaQueryResult.Fail;
                            }
                        case "dppx":
                        case "Dppx":
                        case "DPPX":
                            if (___valueFloat > 2)
                            {
                                return CHtmlMediaQueryResult.OK;
                            }
                            else
                            {
                                return CHtmlMediaQueryResult.Fail;
                            }
                        default:
                            break;
                    }
                    break;

                case -1: // min-resolution
                    switch (___unitPart)
                    {
                        case "dpi":
                        case "Dpi":
                        case "DPI":
                            if (___valueFloat <= CHtmlWindowScreen.___deviceXDPI)
                            {
                                return CHtmlMediaQueryResult.OK;
                            }
                            else
                            {
                                return CHtmlMediaQueryResult.Fail;
                            }
                        case "dpcm":
                        case "Dpcm":
                        case "DPCM":
                            if (___valueFloat <= CHtmlWindowScreen.___deviceXDPI / 3)
                            {
                                return CHtmlMediaQueryResult.OK;
                            }
                            else
                            {
                                return CHtmlMediaQueryResult.Fail;
                            }
                        case "dppx":
                        case "Dppx":
                        case "DPPX":
                            if (___valueFloat <= 2)
                            {
                                return CHtmlMediaQueryResult.OK;
                            }
                            else
                            {
                                return CHtmlMediaQueryResult.Fail;
                            }
                            
                        default:
                            break;
                    }
                    break;
            }
                return CHtmlMediaQueryResult.OK;
            }
        }
        private int GetQuoteEndPoint(int i, char[] MD)
        {
            // it may multiple quoted string
            int ___QuoteBeginCount = 0;
            bool ___QuoteEndedProperty = false;
            int ____QuoteEndPos = -1;
            for (int qe = i; qe < MD.Length; qe++)
            {
                char qec = MD[qe];
                if (qec == '(')
                {
                    ___QuoteBeginCount++;
                }
                else if (qec == ')')
                {
                    ___QuoteBeginCount--;
                    if (___QuoteBeginCount == 0)
                    {
                        // This Means qe position is last positon of quoted string
                        ____QuoteEndPos = qe;
                        ___QuoteEndedProperty = true;
                        break;
                    }
                }
            }
            if (___QuoteEndedProperty)
            {

                return ____QuoteEndPos;
            }
            else
            {
                return MD.Length;

            }
        }
        private void ProcessText()
        {
			if (this._Text.Length == 0)
			{
				goto JudgeMentSection;
			}
			if(this.LogicNodeType == CHtmlMediaQueryNodeType.RootNode)
			{
                int posMediaPos = this._Text.IndexOf("media", StringComparison.OrdinalIgnoreCase);
				if(posMediaPos > -1)
				{
                    if (this._Text[0] == '@')
                    {
                        this._Text = this._Text.Remove(0, 7);
                    }
                    else if (posMediaPos == 0)
                    {
                        this._Text = this._Text.Remove(0, 6);
                    }
				}
			}
			if(string.Equals(this._Text , "and", StringComparison.OrdinalIgnoreCase) == true)
			{
				goto JudgeMentSection;
			}
           System.Text.StringBuilder sbData = new System.Text.StringBuilder();
           char[] MD = this._Text.ToCharArray();
           char cc = '\0';
           ArrayList arORPoint = new ArrayList();
           int LastOrPoint = 0;
           int MDLen = MD.Length;
           for (int i = 0; i < MDLen; i++)
           {

               cc = MD[i];

               if (cc == ',')
               {
                   ConditionOrCount++;
                   CHtmlMediaQueryTextPoint lc = new CHtmlMediaQueryTextPoint();
                   lc.Start = LastOrPoint;
                   lc.End = i -1;
                   LastOrPoint = i + 1;
                   arORPoint.Add(lc);
               }
               if (cc == '(')
               {
                   int pos = this.GetQuoteEndPoint(i, MD);
                   if (pos > -1)
                   {
                       i = pos;
                       continue;
                   }

               }

           }

           if (arORPoint.Count > 0 && LastOrPoint < MDLen)
           {
               CHtmlMediaQueryTextPoint lc = new CHtmlMediaQueryTextPoint();
               lc.Start = LastOrPoint;
               lc.End = MDLen;
               arORPoint.Add(lc);

           }
               
          
           if (arORPoint.Count > 0)
           {
               foreach (CHtmlMediaQueryTextPoint pt in arORPoint)
               {
                   CHtmlMediaQueryNode orNode = new CHtmlMediaQueryNode(CHtmlMediaQueryNodeType.ORNode);
                   orNode.NodeLevel = this.NodeLevel + 1;
                   orNode.ChildNodeIndex = this.nodes.Add(orNode);
                   string ___OrText = "";
                   if (pt.End < MD.Length)
                   {
                       ___OrText = this._Text.Substring(pt.Start, pt.End - pt.Start + 1);
                   }else
                   {
                       ___OrText = this._Text.Substring(pt.Start, pt.End - pt.Start);
                   }
                   orNode.Text = ___OrText;
               }
               goto JudgeMentSection;
           }
          
           for (int i = 0; i < MDLen; i++)
           {
               cc = MD[i];
               if (cc == '/')
               {
                   if (i < MD.Length - 1 && MD[i + 1] == '*')
                   {
                       for (int _comPos = i + 1; _comPos < MD.Length - 1; _comPos++)
                       {
                           if (MD[_comPos] == '*')
                           {
                               if (MD[_comPos + 1] == '/')
                               {
                                   i = _comPos + 1;
                                   goto SkipNextChar;
                               }
                           }
                           continue;
                       }
                   }
               }
               if (commonHTML.FasterIsWhiteSpaceLimited(cc) == true && i + 4 < MD.Length)
               {
                   if (MD[i + 1] == 'a')
                   {
                       if (MD[i + 2] == 'n')
                       {
                           if (MD[i + 3] == 'd')
                           {
                               if (commonHTML.FasterIsWhiteSpaceLimited(MD[i + 4]) == true || MD[i + 4] == '(')
                               {
                                   i = i + 4;
                                   if (sbData.Length > 0)
                                   {
                                       CHtmlMediaQueryNode andNode = new CHtmlMediaQueryNode(CHtmlMediaQueryNodeType.AndNode);
                                       andNode.ChildNodeIndex = this.nodes.Add(andNode);
                                       andNode.NodeLevel = this.NodeLevel + 1;
                                       andNode.Text = sbData.ToString();
                                       
                                   }
                                   sbData = null;
                                   sbData = new StringBuilder();
                                   continue;
                               }
                           }
                       }
                   }
                   goto AppendData;
               }
               else if (cc == ',')
               {
                   // if [,] means it is logical [OR]
                   // 1) Create Logical OR 
                   CHtmlMediaQueryNode orNode = new CHtmlMediaQueryNode(CHtmlMediaQueryNodeType.ORNode);
                   orNode.NodeLevel = this.NodeLevel + 1;
                   if (this.nodes.Count > 0)
                   {
                       for (int priorPos = 0; priorPos < this.nodes.Count; priorPos++)
                       {
                           CHtmlMediaQueryNode priorNode = this.nodes[priorPos] as CHtmlMediaQueryNode;
                           priorNode.ChildNodeIndex = orNode.nodes.Add(priorNode);
                           priorNode.NodeLevel = orNode.NodeLevel + 1;
                           this.nodes.RemoveAt(priorPos);
                           priorPos--;
                       }
                   }
                   orNode.ChildNodeIndex = this.nodes.Add(orNode);
                  
                   orNode.Text = "";
                   
                   // 2) Create DataNode 
                   CHtmlMediaQueryNode afterNode = new CHtmlMediaQueryNode(CHtmlMediaQueryNodeType.DataNode);
                   afterNode.ChildNodeIndex = orNode.nodes.Add(afterNode);
                   afterNode.NodeLevel = orNode.NodeLevel + 1;
                   // 3) Set Remining Text to afterNode
                   if (i + 1 <= MDLen)
                   {
                       string strAfter = this._Text.Substring(i + 1);
                       afterNode.Text = strAfter;
                   }
                   

                   i = MD.Length;
                   continue;
               }
               else if (cc == '(')
               {
                   // it may multiple quoted string
                   int ___QuoteBeginCount = 1;
                   bool ___QuoteEndedProperty = false;
                   int ____QuoteEndPos = -1;
                   for (int qe = i + 1 ; qe < MDLen; qe++)
                   {
                       char qec = MD[qe];
                       if (qec == '(')
                       {
                           ___QuoteBeginCount++;
                       }
                       else if (qec == ')')
                       {
                           ___QuoteBeginCount--;
                           if (___QuoteBeginCount == 0)
                           {
                               // This Means qe position is last positon of quoted string
                               ____QuoteEndPos = qe;
                               ___QuoteEndedProperty = true;
                               break;
                           }
                       }
                   }
                   if (___QuoteEndedProperty)
                   {
                       string sChild = this._Text.Substring(i + 1, ____QuoteEndPos - i -1);
                       CHtmlMediaQueryNode lNode = new CHtmlMediaQueryNode(CHtmlMediaQueryNodeType.DataNode);
                       lNode.ChildNodeIndex = this.nodes.Add(lNode);
                       lNode.NodeLevel = this.NodeLevel + 1;
                       lNode.Text = sChild;
                       
                       i = ____QuoteEndPos;
                       continue;
                   }
                   else
                   {
                       string sChild = this._Text.Substring(i + 1);
                       CHtmlMediaQueryNode lNode = new CHtmlMediaQueryNode(CHtmlMediaQueryNodeType.DataNode);
                       lNode.ChildNodeIndex = this.nodes.Add(lNode);
                       lNode.NodeLevel = this.NodeLevel + 1;
                       lNode.Text = sChild;

                       i = ____QuoteEndPos;
                       i = MD.Length;
                       continue;
                   }

               }
           AppendData:
			   if(cc != '\0')
			   {
				   sbData.Append(cc);
			   }
           SkipNextChar:
           if (false) { ;}
           }
           if (sbData.Length > 0)
           {
			   if(sbData.Length >= 2 && sbData[0] == '\\' && sbData[1] == '0')
			   {
				   sbData.Remove(0, 2);

			   }
               int columnPos = -1;
               int sbDataLen = sbData.Length;
               for (int cpos = 0; cpos < sbDataLen; cpos++)
               {
                   if (sbData[cpos] == ':')
                   {
                       columnPos = cpos;
                       break;
                   }
                   
               }
               if (columnPos != -1)
               {
                   string sData = sbData.ToString().Trim();
                   this.Name = sData.Substring(0, columnPos).Trim();
				   this.HasName = true;
                   if (columnPos + 1 < sData.Length)
                   {
                       this.Value = sData.Substring(columnPos + 1).Trim();
					   // Some case unwanted ')' may remains at the end of string. Remove it.
					   int EndQuotePos = this.Value.LastIndexOf(')');
					   if(EndQuotePos > -1)
					   {
						   this.Value = this.Value.Substring(0, EndQuotePos);
					   }
					   this.HasValue = true;
                   }

               }
               else
               {
                   this.Name = sbData.ToString().Trim();
				   this.HasName = true;
               }
			   if(this.HasName == true)
			   {
				   this.Result = this.GetNodeNameValueResult();
			   }
           }
			JudgeMentSection:
			if(this.Result  ==  CHtmlMediaQueryResult.None)
			{
				if(this.nodes.Count == 0)
				{
					this.Result = CHtmlMediaQueryResult.OK;
				}
				else
				{
                    int thisChildCount = this.nodes.Count;
                    int orFailedCount = 0;
					for(int i= 0; i < thisChildCount; i ++)
					{
                        CHtmlMediaQueryNode cNode = this.nodes[i] as CHtmlMediaQueryNode;
						if(cNode == null)
							continue;
                        if (cNode.HasValueRadio)
                        {
                            this.HasValueRadio = true;
                            this.ValueRatio += cNode.ValueRatio;
                        }
						if(cNode.LogicNodeType == CHtmlMediaQueryNodeType.ORNode)
						{
                            if (cNode.Result == CHtmlMediaQueryResult.OK)
                            {
                               
                                this.Result = CHtmlMediaQueryResult.OK;
                                goto NodeCheckDone;
                            }
                            else
                            {
                                orFailedCount++;
                            }
						}
						else if(cNode.LogicNodeType != CHtmlMediaQueryNodeType.ORNode)
						{
							if(cNode.Result == CHtmlMediaQueryResult.Fail)
							{
								this.Result = CHtmlMediaQueryResult.Fail;
								goto NodeCheckDone;
							}

						}
					}
                    if (thisChildCount > 0 && thisChildCount == orFailedCount)
                    {
                        this.Result = CHtmlMediaQueryResult.Fail;
                    }
                    else
                    {
                        // Survivor is OK
                        this.Result = CHtmlMediaQueryResult.OK;
                    }
				NodeCheckDone:
					if(false){;}
				}
				if(this.Result  ==  CHtmlMediaQueryResult.None)
				{
					this.Result  =  CHtmlMediaQueryResult.OK;
				}
			}
        } 
    }
}
