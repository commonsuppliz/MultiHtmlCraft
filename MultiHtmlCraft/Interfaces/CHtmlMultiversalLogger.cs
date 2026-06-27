using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHtmlCraft.Interfaces
{
    internal interface CHtmlMultiversalLogger
    {
        void LogEntry(string message);
        void LogEntry(string message, int level);
        void LogEntry(string message, int level, Exception ex);
        void LogEntry(int level, Exception ex);
    }

}