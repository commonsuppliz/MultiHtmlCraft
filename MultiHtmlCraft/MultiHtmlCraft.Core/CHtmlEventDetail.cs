using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Core
{
    public class CHtmlEventDetail
    {
        public CHtmlEventDetailMouseButtons buttons;
        public int delta;
        public int clicks;
        public char KeyChar;
        public string eventname = "";
    }
    public enum CHtmlEventDetailMouseButtons
    {
        None = 0,
        Left = 1048576,
        Middle = 4194304,
        Right = 2097152,
        XButton1 = 8388608, 
        XButton2 = 16777216
    }
}
