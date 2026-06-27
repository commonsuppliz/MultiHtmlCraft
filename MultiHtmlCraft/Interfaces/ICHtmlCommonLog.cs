using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHtmlCraft.Interfaces
{
    public interface ICHtmlCommonLog
    {   /// <summary>
        /// Base URL for the worker window
        /// </summary>
        void LogEntry(string message);
        bool LoggingEnabled { get; }
        int LogLevel { get; }

        



    }
}
