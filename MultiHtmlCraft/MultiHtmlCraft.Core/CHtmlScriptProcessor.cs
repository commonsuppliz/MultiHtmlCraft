using System;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlScriptProcessor 
	/// </summary>
	public class CHtmlScriptProcessor
	{
		private string _charset = "";
		private  CHtmlFileType _scriptType;
		public CHtmlScriptProcessor(CHtmlFileType scriptType)
		{
			// 
			// 
			//
			this._scriptType = scriptType;
		}
		public string charset
		{
			set{this._charset = value;}
			get{return this._charset;}
		}
		public  CHtmlFileType ScriptType
		{
			set{this._scriptType = value;}
			get{return this._scriptType;}
		}
        public static CHtmlScriptResult createCHtmlScriptResultElement(byte[] bts, string ___charset)
        {
            CHtmlScriptResult scriptElement = new CHtmlScriptResult();
            if (bts == null)
            {
                return scriptElement;
            }
            System.Text.Encoding enc = null;
            if (bts != null)
            {
                try
                {
                    enc = commonEncodings.GetCodeFromBytes(bts, ___charset);
                }
                catch (Exception exEnc)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("CreateChtmlScriptResultElement Detet charset Exception", exEnc);
                    }
                }
            }

            if (enc == null)
            {
                enc = System.Text.Encoding.UTF8;
            }
            System.Text.StringBuilder sbScript = new System.Text.StringBuilder(enc.GetString(bts, 0, bts.Length));
            /* The script may be jint so it is not appropriate
            commonProcessScriptStringBuilderBeginEndPart(ref sbScript);
            scriptElement.text = commonGetCRStringToCRLF(ref sbScript);
            */
            commonHTML.preprocessScriptCommentStringBuilder(ref sbScript, false);
            scriptElement.text = sbScript.ToString();
            return scriptElement;
        }

	}
}
