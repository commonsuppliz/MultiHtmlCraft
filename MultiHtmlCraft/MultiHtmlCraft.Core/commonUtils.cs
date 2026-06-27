using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiHtmlCraft.Interfaces;
using MultiHtmlCraft;

namespace MultiHtmlCraft.Core
{
    /// <summary>
    /// Provides a collection of common utility methods for general-purpose use.
    /// </summary>
    /// <remarks>This static class serves as a container for reusable utility methods that can be used across
    /// various applications. It is designed to simplify common programming tasks and improve code
    /// maintainability.</remarks>
    public static class commonUtils
    {
        public enum CJHtmlDOMElementLogModeType
        {
            Normal = 0,
            ElementWidthAndHeight = 1
        }
        public static void LogElementDOMTree(CHtmlElement element, string prefix, CJHtmlDOMElementLogModeType logMode)
        {
            switch(logMode)
            {
                case CJHtmlDOMElementLogModeType.Normal:
                    commonLog.LogEntry("{0} + {1} : {2}", prefix, element.toLogString(), element.___childNodes.Count);
                    break;
                case CJHtmlDOMElementLogModeType.ElementWidthAndHeight:
                    commonLog.LogEntry("{0} + {1} : {2}, W: {3} H: {4}", prefix, element.toLogString(), element.___childNodes.Count, element.___offsetWidth, element.___offsetHeight);

                    break;
                default:
                    commonLog.LogEntry("{0} + {1} : {2}", prefix, element.toLogString(), element.___childNodes.Count);
                    break;
            }
 
            int ___thisChildCount = element.___childNodes.Count;
            for (int i = 0; i < ___thisChildCount; i++)
            {
                CHtmlElement n = element.___childNodes[i] as CHtmlElement;
                if (n == null)
                {
                    continue;
                }
                if (element.___childNodes.IndexOf(n, true) == element.___childNodes.Count - 1)
                    LogElementDOMTree(n, prefix + "    ", logMode);
                else
                    LogElementDOMTree(n, prefix + "   |", logMode);
            }
        
        }
        public static void LogElementDOMTree(CHtmlElement element, string prefix)
        {
            LogElementDOMTree(element, prefix, CJHtmlDOMElementLogModeType.Normal);
        }

    }
}
