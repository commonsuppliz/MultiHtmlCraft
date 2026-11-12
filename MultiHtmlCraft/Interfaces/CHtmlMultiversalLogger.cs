using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHtmlCraft.Interfaces
{
    public interface CHtmlMultiversalLogger
    {
        bool LoggingEnabled { get; set; }
        int LogLevel { get; set; }
        void LogEntry(string message);
        void LogEntry(string message, int level);
        void LogEntry(string message, int level, Exception ex);
        void LogEntry(int level, Exception ex);
    }

}