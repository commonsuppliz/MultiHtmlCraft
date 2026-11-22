using System;
using System.Collections.Generic;
using System.Text;

namespace ClearScriptProcessor
{
    /// <summary>
    /// commonLog is a log handling class which is same methods MultiHtmlCraft.Core.commonLog class to call MultiHtmlCraft.Core.commonLog class.
    /// </summary>
    internal static class commonLog
    {
        internal static Action<string> commonLogLogger { get; set; }
        internal static Func<bool> IsEnabledCheck { get; set; }
        internal static bool LoggingEnabled { get; set; } = true;
        internal static bool DebugLoggingEnabled { get; set; } = false;
        internal static int LogLevel { get; set; } = 10;
        internal static void LogEntry(string message)
        {
            if (IsEnabledCheck != null && !IsEnabledCheck())
            {
                return;
            }
            if(commonLogLogger == null)
            {
                return;
            }

            
            commonLogLogger?.Invoke(message);
        }

    }
}
