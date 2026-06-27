using System;
using System.Text;
using System.Runtime.InteropServices;

namespace MultiHtmlCraft.Core
{
    public enum URISetType
    {
        None = 0,
        Reserved =1,
        Unescaped =2
    }

    public static class commonURL
    {
        public static string escape(object s)
        {
            return escape_inner(commonHTML.GetStringValue(s));
        }
        public static string encodeURIComponent(object s)
        {
            return GlobalObject_Encode(commonHTML.GetStringValue(s), URISetType.Unescaped);
        }
        public static string decodeURIComponent(object encodedURI)
        {
            return GlobalObject_Decode(commonHTML.GetStringValue(encodedURI), URISetType.None);
        }
        public static string encodeURI(object uri)
        {
            return GlobalObject_Encode(commonHTML.GetStringValue(uri), (URISetType)3);
        }
        public static string decodeURI(object encodedURI)
        {
            return GlobalObject_Decode(commonHTML.GetStringValue(encodedURI), URISetType.Reserved);
        }

        public static string unescape(object _string)
        {
            string text = commonHTML.GetStringValue(_string);
            int length = text.Length;
            StringBuilder stringBuilder = new StringBuilder(length);
            int num = -1;
            while (++num < length)
            {
                char c = text[num];
                if (c == '%')
                {
                    int num2;
                    int num3;
                    int num4;
                    int num5;
                    if (num + 5 < length && text[num + 1] == 'u' && (num2 = HexDigit(text[num + 2])) != -1 && (num3 = HexDigit(text[num + 3])) != -1 && (num4 = HexDigit(text[num + 4])) != -1 && (num5 = HexDigit(text[num + 5])) != -1)
                    {
                        c = (char)((num2 << 12) + (num3 << 8) + (num4 << 4) + num5);
                        num += 5;
                    }
                    else
                    {
                        if (num + 2 < length && (num2 = HexDigit(text[num + 1])) != -1 && (num3 = HexDigit(text[num + 2])) != -1)
                        {
                            c = (char)((num2 << 4) + num3);
                            num += 2;
                        }
                    }
                }
                stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }
        private static void AppendInHex(StringBuilder bs, int value)
        {
            bs.Append('%');
            int num = value >> 4 & 15;
            bs.Append((char)((num >= 10) ? (num - 10 + 65) : (num + 48)));
            num = (value & 15);
            bs.Append((char)((num >= 10) ? (num - 10 + 65) : (num + 48)));
        }
        private static bool InURISet(char ch, URISetType flags)
        {
            if ((flags & URISetType.Unescaped) != URISetType.None)
            {
                if ((ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z'))
                {
                    return true;
                }
                if (ch <= '.')
                {
                    if (ch != '!')
                    {
                        switch (ch)
                        {
                            case '\'':
                            case '(':
                            case ')':
                            case '*':
                            case '-':
                            case '.':
                                break;
                            case '+':
                            case ',':
                                goto IL_68;
                            default:
                                goto IL_68;
                        }
                    }
                }
                else
                {
                    if (ch != '_' && ch != '~')
                    {
                        goto IL_68;
                    }
                }
                return true;
            }
        IL_68:
            if ((flags & URISetType.Reserved) != URISetType.None)
            {
                switch (ch)
                {
                    case '#':
                    case '$':
                    case '&':
                        break;
                    case '%':
                        return false;
                    default:
                        switch (ch)
                        {
                            case '+':
                            case ',':
                            case '/':
                                break;
                            case '-':
                            case '.':
                                return false;
                            default:
                                switch (ch)
                                {
                                    case ':':
                                    case ';':
                                    case '=':
                                    case '?':
                                    case '@':
                                        break;
                                    case '<':
                                    case '>':
                                        return false;
                                    default:
                                        return false;
                                }
                                break;
                        }
                        break;
                }
                return true;
            }
            return false;
        }
        private static string GlobalObject_Decode(string encodedURI, URISetType flags)
        {
            string text = encodedURI;
            StringBuilder stringBuilder = new StringBuilder();
            int textLen = text.Length;
            for (int i = 0; i < textLen; i++)
            {
                char c = text[i];
                if (c != '%')
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    int num = i;
                    if (i + 2 >= text.Length)
                    {
                        throw new Exception("JSError.URIDecodeError");
                    }
                    byte b = HexValue(text[i + 1], text[i + 2]);
                    i += 2;
                    char c2;
                    if ((b & 128) == 0)
                    {
                        c2 = (char)b;
                    }
                    else
                    {
                        int j = 1;
                        while (((int)b << j & 128) != 0)
                        {
                            j++;
                        }
                        if (j == 1 || j > 4 || i + (j - 1) * 3 >= text.Length)
                        {
                            throw new Exception("JSError.URIDecodeError");
                        }
                        int num2 = (int)b & 255 >> j + 1;
                        while (j > 1)
                        {
                            if (text[i + 1] != '%')
                            {
                                throw new Exception("JSError.URIDecodeError");
                            }
                            b = HexValue(text[i + 2], text[i + 3]);
                            i += 3;
                            if ((b & 192) != 128)
                            {
                                throw new Exception("JSError.URIDecodeError");
                            }
                            num2 = (num2 << 6 | (int)(b & 63));
                            j--;
                        }
                        if (num2 >= 55296 && num2 < 57344)
                        {
                            throw new Exception("JSError.URIDecodeError");
                        }
                        if (num2 < 65536)
                        {
                            c2 = (char)num2;
                        }
                        else
                        {
                            if (num2 > 1114111)
                            {
                                throw new Exception("JSError.URIDecodeError");
                            }
                            stringBuilder.Append((char)((num2 - 65536 >> 10 & 1023) + 55296));
                            stringBuilder.Append((char)((num2 - 65536 & 1023) + 56320));
                            goto IL_1D4;
                        }
                    }
                    if (InURISet(c2, flags))
                    {
                        stringBuilder.Append(text, num, i - num + 1);
                    }
                    else
                    {
                        stringBuilder.Append(c2);
                    }
                }
            IL_1D4: ;
            }
            return stringBuilder.ToString();
        }

        private static string GlobalObject_Encode(string uri, URISetType flags)
        {
            string text = uri;
            StringBuilder stringBuilder = new StringBuilder();
            int textLen = text.Length;
            for (int i = 0; i < textLen; i++)
            {
                char c = text[i];
                if (InURISet(c, flags))
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    int num = (int)c;
                    if (num >= 0 && num <= 127)
                    {
                        AppendInHex(stringBuilder, num);
                    }
                    else
                    {
                        if (num >= 128 && num <= 2047)
                        {
                            AppendInHex(stringBuilder, num >> 6 | 192);
                            AppendInHex(stringBuilder, (num & 63) | 128);
                        }
                        else
                        {
                            if (num < 55296 || num > 57343)
                            {
                                AppendInHex(stringBuilder, num >> 12 | 224);
                                AppendInHex(stringBuilder, (num >> 6 & 63) | 128);
                                AppendInHex(stringBuilder, (num & 63) | 128);
                            }
                            else
                            {
                                if (num >= 56320 && num <= 57343)
                                {
                                    throw new Exception("JSError.URIEncodeError");
                                }
                                if (++i >= text.Length)
                                {
                                    throw new Exception("JSError.URIEncodeError");
                                }
                                int num2 = (int)text[i];
                                if (num2 < 56320 || num2 > 57343)
                                {
                                    throw new Exception("JSError.URIEncodeError");
                                }
                                num = (num - 55296 << 10) + num2 + 9216;
                                AppendInHex(stringBuilder, num >> 18 | 240);
                                AppendInHex(stringBuilder, (num >> 12 & 63) | 128);
                                AppendInHex(stringBuilder, (num >> 6 & 63) | 128);
                                AppendInHex(stringBuilder, (num & 63) | 128);
                            }
                        }
                    }
                }
            }
            return stringBuilder.ToString();
        }

       private static string escape_inner(string str)
        {
            string str2 = "0123456789ABCDEF";
            int length = str.Length;
            StringBuilder builder = new StringBuilder(length * 2);
            int num3 = -1;
            while (++num3 < length)
            {
                char ch = str[num3];
                int num2 = ch;
                if ((((0x41 > num2) || (num2 > 90)) &&
                     ((0x61 > num2) || (num2 > 0x7a))) &&
                     ((0x30 > num2) || (num2 > 0x39)))
                {
                    switch (ch)
                    {
                        case '@':
                        case '*':
                        case '_':
                        case '+':
                        case '-':
                        case '.':
                        case '/':
                            goto Label_0125;
                    }
                    builder.Append('%');
                    if (num2 < 0x100)
                    {
                        builder.Append(str2[num2 / 0x10]);
                        ch = str2[num2 % 0x10];
                    }
                    else
                    {
                        builder.Append('u');
                        builder.Append(str2[(num2 >> 12) % 0x10]);
                        builder.Append(str2[(num2 >> 8) % 0x10]);
                        builder.Append(str2[(num2 >> 4) % 0x10]);
                        ch = str2[num2 % 0x10];
                    }
                }
            Label_0125:
                builder.Append(ch);
            }
            return builder.ToString();
        }
        private static byte HexValue(char ch1, char ch2)
        {
            int num;
            int num2;
            if ((num = HexDigit(ch1)) < 0 || (num2 = HexDigit(ch2)) < 0)
            {
                throw new Exception("JSError.URIDecodeError");
            }
            return (byte)(num << 4 | num2);
        }
        internal static int HexDigit(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return (int)(c - '0');
            }
            if (c >= 'A' && c <= 'F')
            {
                return (int)('\n' + c - 'A');
            }
            if (c >= 'a' && c <= 'f')
            {
                return (int)('\n' + c - 'a');
            }
            return -1;
        }


    }
}
