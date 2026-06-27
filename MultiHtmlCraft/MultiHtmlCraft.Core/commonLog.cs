using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace MultiHtmlCraft.Core
{
	using System;
	using System.IO;

#if DEBUG
	using System.Diagnostics;



#endif
    /// <summary>
    /// commonLog 
    /// </summary>
#pragma warning disable IDE1006 // 命名スタイル
		public static class commonLog
#pragma warning restore IDE1006 // 命名スタイル
		{
			private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

		    public static bool LoggingEnabled
		{
			get { return NLog.LogManager.IsLoggingEnabled(); }
			set
			{
				if (value == true) { StartLogging(); } else { StopLogging(); } ;


			}
           
		}
		private static int _commonnlogLevel = 10;

        public static int LogLevel
		{
			get
			{
                return _commonnlogLevel;

            }
			set
            {
                _commonnlogLevel = value;
                switch (value)
                {
                    case int n when (n < 10):
                        Logger.Info("Log Level set to Debug");
                        break;
                    case int n when (n >= 10):
                    default:
                        Logger.Info("Log Level set to Info");
                        break;
                }
            }	
        }

			public static void LogEntry(string str, params object[] args)
			{
#if DEBUG
            try
            {
                Debug.WriteLine(string.Format(str, args));
            }
            catch { }
#endif 
			}
			public static void LogEntry(string str)
			{
 #if DEBUG
                 Debug.WriteLine(str);
#endif 
			}
			public static void LogEntry(System.Exception ex)
			{
#if DEBUG
                 Debug.WriteLine(ex);
#endif 
			}
			public static void LogEntry(string strName, Exception ex)
			{
#if DEBUG
               Debug.WriteLine(ex, strName);
#endif
			}
        public static void StartLogging()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
            var logdebugger = new NLog.Targets.ConsoleTarget("DebugSystem");

            // Rules for mapping loggers to targets
            config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Debug, logdebugger);
            //config.AddRule(CommonLogLevel.Debug, CommonLogLevel.Fatal, logfile);
           
            // Apply config
            NLog.LogManager.Configuration = config;
        }

        // Method to shut down logging configuration
        public static void StopLogging()
        {
            NLog.LogManager.Shutdown();
        }
  
    }
	}


