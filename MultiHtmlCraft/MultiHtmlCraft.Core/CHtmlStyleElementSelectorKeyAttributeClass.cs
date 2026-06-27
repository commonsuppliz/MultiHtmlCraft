using System;

namespace MultiHtmlCraft.Core
{
    public enum CSSSelectorKeyOperataorType : byte
    {
        /// <summary>
        /// operator does not exists
        /// </summary>
        none=0,
        /// <summary>
        /// =
        /// </summary>
        equals=1,
        /// <summary>
        /// !=
        /// </summary>
        notEquals=2,
        /// <summary>
        /// "^=":
        /// </summary>
        beginWith=3,
        /// <summary>
        /// "$=":
        /// </summary>
        endWith=4,
        /// <summary>
        ///  "*=":
        /// </summary>
        includes=5,
        /// <summary>
        /// "~=":
        /// </summary>
        whitespaceSplitInclude=6,
        /// <summary>
        /// |=
        /// </summary>
        flangInclude=7,
        /// <summary>
        /// Other or unknown
        /// </summary>
        unknown=255
    }
	/// <summary>
	/// CHtmlStyleElementSelectorKeyAttributeClass 
	/// </summary>
	public struct  CHtmlStyleElementSelectorKeyAttributeClass
	{
		public string Name;
        public CSSSelectorKeyOperataorType OperatorType;
		public string Value;

		public bool IsValueMatches(string ___value)
		{
			switch(this.OperatorType)
			{
                case CSSSelectorKeyOperataorType.none:
					return true;
					// -------------------------------------
					// Equal
					// -------------------------------------
				case CSSSelectorKeyOperataorType.equals:

                    if (string.IsNullOrEmpty(___value) == false)
                    {

                        if (string.Equals(this.Value, ___value, StringComparison.OrdinalIgnoreCase) == true)
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
                        if (string.IsNullOrEmpty(this.Value) == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
					// -------------------------------------
					// Not Equal
					// -------------------------------------
				case CSSSelectorKeyOperataorType.notEquals:
                    if (string.IsNullOrEmpty(___value) == false)
                    {
                        if (string.Equals(this.Value, ___value, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(this.Value) == true)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
				// -------------------------------------
				// Attribute Begin Width
				// -------------------------------------
				case CSSSelectorKeyOperataorType.beginWith:
                    if (string.IsNullOrEmpty(___value) == false)
                    {
                        if (___value.StartsWith(this.Value, StringComparison.OrdinalIgnoreCase))
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }
				// --------------------------------------
				// Attribte End Width
				// ---------------------------------------
				case CSSSelectorKeyOperataorType.endWith:
                    if (string.IsNullOrEmpty(___value) == false)
                    {
                        if (___value.EndsWith(this.Value, StringComparison.OrdinalIgnoreCase))
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }
				// --------------------------------------
				// Attribte Include
				// --------------------------------------
				case CSSSelectorKeyOperataorType.includes:
                    if (string.IsNullOrEmpty(___value) == false)
                    {
                        if (___value.IndexOf(this.Value, StringComparison.OrdinalIgnoreCase) > -1)
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
				// --------------------------------------
				// Attribte Include
				// Note) This selector represents an element with the "attributename" attribute whose value
				// is a whitespace-separated list of words, one of which is exactly "val". 
				// --------------------------------------
                case CSSSelectorKeyOperataorType.whitespaceSplitInclude:
                    if (string.IsNullOrEmpty(___value) == false)
                    {
                        string[] spArray = ___value.Split(commonHTML.CharSpaceCrLfTab);
                        int spArrayLen = spArray.Length;
                        for (int i = 0; i < spArrayLen; i++)
                        {
                            if (string.Equals(spArray[i], this.Value, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                return true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        return false;
                    }
                    else
                    {
                        return false;
                    }
					// --------------------------------------
					// The following selector represents an a element for which the value of the hreflang attribute begins
					// with "en", including "en", "en-US", and "en-scouse": 
					// --------------------------------------
				case CSSSelectorKeyOperataorType.flangInclude:
                    if (string.IsNullOrEmpty(___value) == false)
                    {
                        if (___value.StartsWith(this.Value, StringComparison.OrdinalIgnoreCase))
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }
				default:
					return false;
			}
		}
		#region ICloneable ƒƒ“ƒo

		public CHtmlStyleElementSelectorKeyAttributeClass CloneCHtmlStyleElementSelectorKeyAttributeClass()
		{
			CHtmlStyleElementSelectorKeyAttributeClass _newAttr =new CHtmlStyleElementSelectorKeyAttributeClass();
			if(string.IsNullOrEmpty(this.Name) == false)
			{
				_newAttr.Name = string.Copy(this.Name);
			}
            _newAttr.OperatorType = this.OperatorType;
			if(string.IsNullOrEmpty(this.Value) == false)
			{
				_newAttr.Value = string.Copy(this.Value);
			}
			return _newAttr;
		}

		#endregion
	}
}
