using System;
using System.Text;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// commonEncodings 
	/// </summary>
	public class commonEncodings
	{
		public class EncodingResult
		{
			public bool bBOM, bLE, bBE;
			public int sjis, euc, utf8;

		}
		public static Encoding GetCodeFromBytes(byte[] bytes, string ___possibleCharset)
		{
            if (bytes == null)
            {
                return Encoding.Default;
            }
            if (bytes.Length >= 3)
            {
                if (commonHTML.isUTF8BytesExistsInFirst3Bytes(bytes[0], bytes[1], bytes[2]))
                {
                    // BOM
                    return Encoding.UTF8;
                }
            }
            bool ___isSpecifiedCharsetMaybeDBCS = false;
            if (string.IsNullOrEmpty(___possibleCharset) == false)
            {
                switch (commonHTML.FasterToLower(___possibleCharset))
                {
                    case "x-sjis":
                    case "sjis":
                    case "shiftjis":
                    case "s-sjis":
                    case "shift_jis":
                    case"shift-jis":
                    case "sjiftjis":
                    case "iso-2022-jp":
                    case "x-iso-2022-jp":
                    case "iso_2022_jp":
                    case "csiso2022jp":
                    case "xeucjp":
                    case "euc_jp":
                    case "euc-jp":
                    case "x-euc-jp":
                        ___isSpecifiedCharsetMaybeDBCS = true;
                        break;
                    case "us-ascii":
                    case "iso-8859-1":
                        ___isSpecifiedCharsetMaybeDBCS = false;
                        break;
                    default:
                      ___isSpecifiedCharsetMaybeDBCS = false;
                        break;

                }
            }
            if (___isSpecifiedCharsetMaybeDBCS == false && string.IsNullOrEmpty(___possibleCharset) == false)
            {
                try
                {
                    return System.Text.Encoding.GetEncoding(___possibleCharset);
                }
                catch
                {
                    if (commonLog.LoggingEnabled)
                    {
                       commonLog.LogEntry("GetCodeFromBytes failed obtain encoding from " + ___possibleCharset + ", but cont...");
                    }
                }
            }
			EncodingResult r = new EncodingResult();
			if (IsUTF16(bytes, r) == true)
			{
				if (r.bLE == true)
					return Encoding.Unicode;
                
				else if (r.bBE == true)
					return Encoding.BigEndianUnicode;
			}

			else if (IsJis(bytes,r) == true)
				return Encoding.GetEncoding(50220);

			else if (IsAscii(bytes,r) == true)
				return Encoding.ASCII;

			else
			{

                bool bUTF8 = false; 
                bool bShitJis = false; 
                bool bEUC = false;
                if (bytes != null)
                {
                    bUTF8 = IsUTF8(bytes, r);
                    bShitJis = IsShiftJis(bytes, r);
                    bEUC = IsEUC(bytes, r);
                }
				if (bUTF8 == true || bShitJis == true || bEUC == true)
				{
					if (r.euc > r.sjis && r.euc > r.utf8)
						return Encoding.GetEncoding(51932);
					else if (r.sjis > r.euc && r.sjis > r.utf8)
						return Encoding.GetEncoding(932);
					else if (r.utf8 > r.euc && r.utf8 > r.sjis)
						return Encoding.UTF8;
				}
				else
				{
					return null;
				}
			}

			return null;
		}
		public static bool IsUTF16(byte[] bytes, EncodingResult rs)      // Check for UTF-16
		{
            if (bytes == null)
                return false;
			int len = bytes.Length;
			byte b1, b2;
			rs.bLE = false; rs.bBE=false;

			if (len >= 2)
			{
				b1 = bytes[0];
				b2 = bytes[1];

				if (b1 == 0xFF && b2 == 0xFE)
				{
					rs.bLE = true;
					return true;
				}
				else if (b1 == 0xFE && b2 == 0xFF)
				{
					rs.bBE = true;
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
        
		public static bool IsJis(byte[] bytes,  EncodingResult rs)        // Check for JIS (ISO-2022-JP)
		{
            if (bytes == null)
                return false;
			int len = bytes.Length;
			byte b1, b2, b3, b4, b5, b6;

			for (int i = 0; i < len; i++)
			{
				b1 = bytes[i];

				if (b1 > 0x7F)
				{
					return false;   // Not ISO-2022-JP (0x00Å`0x7F)
				}
				else if (i < len - 2)
				{
					b2 = bytes[i + 1]; b3 = bytes[i + 2];

					if (b1 == 0x1B && b2 == 0x28 && b3 == 0x42)
						return true;    // ESC ( B  : JIS ASCII

					else if (b1 == 0x1B && b2 == 0x28 && b3 == 0x4A)
						return true;    // ESC ( J  : JIS X 0201-1976 Roman Set

					else if (b1 == 0x1B && b2 == 0x28 && b3 == 0x49)
						return true;    // ESC ( I  : JIS X 0201-1976 kana

					else if (b1 == 0x1B && b2 == 0x24 && b3 == 0x40)
						return true;    // ESC $ @  : JIS X 0208-1978(old_JIS)

					else if (b1 == 0x1B && b2 == 0x24 && b3 == 0x42)
						return true;    // ESC $ B  : JIS X 0208-1983(new_JIS)
				}
				else if (i < len - 3)
				{
					b2 = bytes[i + 1]; b3 = bytes[i + 2]; b4 = bytes[i + 3];

					if (b1 == 0x1B && b2 == 0x24 && b3 == 0x28 && b4 == 0x44)
						return true;    // ESC $ ( D  : JIS X 0212-1990ÅiJIS_hojo_kanjiÅj
				}
				else if (i < len - 5)
				{
					b2 = bytes[i + 1]; b3 = bytes[i + 2];
					b4 = bytes[i + 3]; b5 = bytes[i + 4]; b6 = bytes[i + 5];

					if (b1 == 0x1B && b2 == 0x26 && b3 == 0x40 &&
						b4 == 0x1B && b5 == 0x24 && b6 == 0x42)
					{
						return true;    // ESC & @ ESC $ B  : JIS X 0208-1990
					}
				}
			}

			return false;
		}

		public static bool IsAscii(byte[] bytes,  EncodingResult rs)      // Check for Ascii
		{
            if (bytes == null)
                return false;
			int len = bytes.Length;

			for (int i = 0; i < len; i++)
			{
				if (bytes[i] <= 0x7F)
				{
					// ASCII : 0x00Å`0x7F
					;
				}
				else
				{
					return false;
				}
			}

			return true;
		}

		public static bool IsShiftJis(byte[] bytes,  EncodingResult rs)   // Check for Shift-JIS
		{
			int len = bytes.Length;
			byte b1, b2;
			rs.sjis = 0;

			for (int i = 0; i < len; i++)
			{
				b1 = bytes[i];

				if ((b1 <= 0x7F) || (b1 >= 0xA1 && b1 <= 0xDF))
				{
					// ASCII : 0x00Å`0x7F
					// kana  : 0xA1Å`0xDF
					;
				}
				else if (i < len - 1)
				{
					b2 = bytes[i + 1];

					if (
						((b1 >= 0x81 && b1 <= 0x9F) || (b1 >= 0xE0 && b1 <= 0xFC)) &&
						((b2 >= 0x40 && b2 <= 0x7E) || (b2 >= 0x80 && b2 <= 0xFC))
						)
					{
						// kanji first byte  : 0x81Å`0x9FÅA0xE0Å`0xFC
						//       second byte : 0x40Å`0x7EÅA0x80Å`0xFC
						i++;
						rs.sjis += 2;
					}
					else
					{
						return false;
					}
				}
			}

			return true;
		}

		public static bool IsEUC(byte[] bytes,  EncodingResult rs)        // Check for euc-jp 
		{
			int len = bytes.Length;
			byte b1, b2, b3;
			rs.euc = 0;

			for (int i = 0; i < len; i++)
			{
				b1 = bytes[i];

				if (b1 <= 0x7F)
				{   //  ASCII : 0x00Å`0x7F
					;
				}
				else if (i < len - 1)
				{
					b2 = bytes[i + 1];

					if ((b1 >= 0xA1 && b1 <= 0xFE) && (b2 >= 0xA1 && b2 <= 0xFE))
					{ // kanji - first & second byte : 0xA1Å`0xFE
						i++;
						rs.euc += 2;
					}
					else if ((b1 == 0x8E) && (b2 >= 0xA1 && b2 <= 0xDF))
					{ // kana - first byte : 0x8E, second byte : 0xA1Å`0xDF
						i++;
						rs.euc += 2;
					}
					else if (i < len - 2)
					{
						b3 = bytes[i + 2];

						if ((b1 == 0x8F) &&
							(b2 >= 0xA1 && b2 <= 0xFE) && (b3 >= 0xA1 && b3 <= 0xFE))
						{ // hojo kanji - first byte : 0x8F, second & third byte : 0xA1Å`0xFE
							i += 2;
							rs.euc += 3;
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

			return true;
		}

		public static bool IsUTF8(byte[] bytes,  EncodingResult rs)       // Check for UTF-8
		{
            if (bytes == null)
                return false;
			int len = bytes.Length;
			byte b1, b2, b3, b4;
			rs.utf8 = 0; rs.bBOM = false;

			for (int i = 0; i < len; i++)
			{
				b1 = bytes[i];

				if (b1 <= 0x7F)
				{ //  ASCII : 0x00Å`0x7F
					;
				}
				else if (i < len - 1)
				{
					b2 = bytes[i + 1];

					if ((b1 >= 0xC0 && b1 <= 0xDF) &&
						(b2 >= 0x80 && b2 <= 0xBF))
					{ // 2 byte char
						i += 1;
						rs.utf8 += 2;
					}
					else if (i < len - 2)
					{
						b3 = bytes[i + 2];

						if (b1 == 0xEF && b2 == 0xBB && b3 == 0xBF)
						{ // BOM : 0xEF 0xBB 0xBF
							rs.bBOM = true;
							i += 2;
							rs.utf8 += 3;
						}
						else if ((b1 >= 0xE0 && b1 <= 0xEF) &&
							(b2 >= 0x80 && b2 <= 0xBF) &&
							(b3 >= 0x80 && b3 <= 0xBF))
						{ // 3 byte char
							i += 2;
							rs.utf8 += 3;
						}

						else if (i < len - 3)
						{
							b4 = bytes[i + 3];

							if ((b1 >= 0xF0 && b1 <= 0xF7) &&
								(b2 >= 0x80 && b2 <= 0xBF) &&
								(b3 >= 0x80 && b3 <= 0xBF) &&
								(b4 >= 0x80 && b4 <= 0xBF))
							{ // 4 byte char
								i += 3;
								rs.utf8 += 4;
							}
						}
						else
						{
							return false;
						}
					}
				}
			}

			return true;
		}
	}
}
