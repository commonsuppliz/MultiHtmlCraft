using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using MultiHtmlCraft.Interfaces;
using System.Linq.Expressions;
using Microsoft.ClearScript;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlConsole 
	/// console class
	/// </summary>
	
	public sealed class CHtmlConsole : CHtmlNode, ICommonObjectInterface, IDynamicMetaObjectProvider
    {
        internal static Dictionary<string, int> CHtmlConsoleMethods  = InitCHtmlConsoleMethods();
        
private static Dictionary<string, int> InitCHtmlConsoleMethods()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"log", 1},
                {"warn", 2 },
                {"error", 3},
                {"debug", 4},
                {"info", 5 },
                {"trace", 6 },
                {"dir", 7 },
                {"time", 8 },
                {"timeEnd", 9 },
                {"clear", 10 },
                {"count", 11 },
                {"countReset", 12 },
                {"profile", 13  },
                {"profileEnd", 14 },
                {"table" , 15},
                {"group", 16  },
                {"groupEnd", 17 },
                {"groupCollapsed", 18   },
                {"assert", 19 },
                {"memory", 20 },
                {"exception", 21 },
                {"stackTrace", 22   },
                {"timeLog", 23   },
                {"dirxml", 24  },
                {"createTask", 25   },
                {"markTimeline", 26    },
                {"timeStamp", 27    },
                {"clearConsole", 28    },
                {"getConsoleLogs", 29      },

            };
            return dict;
        }


        public CHtmlConsole()
		{
            this.___multiversalClassType = IMutilversalObjectType.Console;
        }

        private void ___log_inner(object obj)
        {
            string str = commonHTML.GetStringValue(obj);
            if (commonLog.LoggingEnabled || System.Diagnostics.Debugger.IsAttached)
            {
                commonLog.LogEntry(string.Concat("console.log('", str, "')"));
            }
        }

        [ScriptMember("log")]
        public void log(object arg)
        {
            this.___log_inner(arg);
        }

        public void log(params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                this.___log_inner("");
                return;
            }
            if (args.Length == 1)
            {
                this.___log_inner(args[0]);
                return;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args.Length; i++)
            {
                sb.Append(commonHTML.GetStringValue(args[i]));
                if (i < args.Length - 1)
                {
                    sb.Append(' ');
                }
            }
            this.___log_inner(sb.ToString());
        }

        #region warn
        private void ___warn_inner(string str)
        {
            if (commonLog.LoggingEnabled)
            {
               commonLog.LogEntry(string.Concat("console.warn('", str, "')"));
            }
        }

        [ScriptMember("warn")]
        public void warn(object arg)
        {
            this.___warn_inner(commonHTML.GetStringValue(arg));
        }

        public void warn(params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                this.___warn_inner("");
                return;
            }
            if (args.Length == 1)
            {
                this.___warn_inner(commonHTML.GetStringValue(args[0]));
                return;
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < args.Length; i++)
            {
                sb.Append(commonHTML.GetStringValue(args[i]));
                if (i < args.Length - 1)
                {
                    sb.Append(' ');
                }
            }
            this.___warn_inner(sb.ToString());
        }
        #endregion

        #region error
        private void ___error_inner(string str)
        {
            if (commonLog.LoggingEnabled)
            {
                commonLog.LogEntry(string.Concat("console.error('", str, "')"));
            }
        }

        [ScriptMember("error")]
        public void error(object arg)
        {
            this.___error_inner(commonHTML.GetStringValue(arg));
        }

        public void error(params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                this.___error_inner("");
                return;
            }
            if (args.Length == 1)
            {
                this.___error_inner(commonHTML.GetStringValue(args[0]));
                return;
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < args.Length; i++)
            {
                sb.Append(commonHTML.GetStringValue(args[i]));
                if (i < args.Length - 1)
                {
                    sb.Append(' ');
                }
            }
            this.___error_inner(sb.ToString());
        }
        #endregion

        #region debug
        private void ___debug_inner(string str)
        {
            if (commonLog.LoggingEnabled)
            {
               commonLog.LogEntry(string.Concat("console.debug('", str, "')"));
            }
        }

        [ScriptMember("debug")]
        public void debug(object arg)
        {
            this.___debug_inner(commonHTML.GetStringValue(arg));
        }

        public void debug(params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                this.___debug_inner("");
                return;
            }
            if (args.Length == 1)
            {
                this.___debug_inner(commonHTML.GetStringValue(args[0]));
                return;
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < args.Length; i++)
            {
                sb.Append(commonHTML.GetStringValue(args[i]));
                if (i < args.Length - 1)
                {
                    sb.Append(' ');
                }
            }
            this.___debug_inner(sb.ToString());
        }
        #endregion

        // ICommonObjectInterface implementation
        public void ___setPropertyByName(string name, object val)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___setPropertyByName needs to be implemetented");
            }
        }
        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___setPropertyByIndex needs to be implemetented");
            }
        }
        public object ___getPropertyByName(string name)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___getPropertyByName needs to be implemetented");
            }
            return null;
        }
        public object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___getPropertyByIndex needs to be implemetented");
            }
            return null;
        }
        public bool ___hasPropertyByName(string name)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___hasPropertyByName needs to be implemetented");
            }
            return false;
        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___hasPropertyByIndex needs to be implemetented");
            }
            return false;
        }
        public void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___deleteByIndex needs to be implemetented");
            }
        }
        public void ___deleteByName(string ___Name)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___deleteByName needs to be implemetented");
            }
        }
        public object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___getByIds needs to be implemetented");
            }
            return null;
        }
        public object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___getDefaultValue needs to be implemetented");
            }
            return null;
        }
        public object ___getProtoType()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___getProtoType needs to be implemetented");
            }
            return null;
        }
        public void ___setProtoType(object __object)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___setProtoType needs to be implemetented");
            }
        }
        public void ___setParentScope(object __object)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___setParentScope needs to be implemetented");
            }
        }
        public object ___getParentScope()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___getParentScope needs to be implemetented");
            }
            return null;
        }
        public string ___getClassName()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___getClassName needs to be implemetented");
            }
            return nameof(CHtmlConsole);
        }
        public bool ___hasInstance(object __object)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___hasInstance needs to be implemetented");
            }
            return false;
        }
        public bool ___instanceEquals(object __object)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___instanceEquals needs to be implemetented");
            }
            return object.ReferenceEquals(this, __object);
        }
        public object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"TODO: ___common_object_clone needs to be implemetented");
            }
            return this;
        }
        public IMutilversalObjectType multiversalClassType => this.___multiversalClassType;

        public IEnumerable<string> GetDynamicMemberNames()
        {
            // Expose no additional dynamic members for console methods to avoid ambiguity.
            // If needed, names can be provided by reflection over public instance methods.
            return Array.Empty<string>();
        }

        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlConsole>(parameter, this);
        }
    }
}
