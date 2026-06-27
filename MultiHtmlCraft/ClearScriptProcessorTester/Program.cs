using ClearScriptProcessor;
using System;
using System.Collections.Generic;
using MultiHtmlCraft.Interfaces;
using System.Configuration;
namespace ClearScriptProcessorTester
{
    internal class Program
    {
        public static string FILE_PATH = string.Empty;
        public static int ___optLevel = -1;
       
        public static string ___strScriptPath = null;
        public static string ___strOptLevel = null;
        public static string ___strScript = null;
   



     
        private static ClearScriptProcessorScope _scope = null;
        private static  IMultiversalScriptProcessor _clearScriptProcessor = null;
        static void Main(string[] args)
        {
            try
            {

                ___strScriptPath = ConfigurationManager.AppSettings["script_path"];

                if (string.IsNullOrEmpty(___strScriptPath) == false && System.IO.Directory.Exists(___strScriptPath))
                {
                    System.Environment.CurrentDirectory = ___strScriptPath;
                    FILE_PATH = ___strScriptPath;
                }
                else
                {
                    System.IO.DirectoryInfo dInfo = new System.IO.DirectoryInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    string strParentlPath = dInfo.Parent.Parent.Parent.Parent.FullName;
                    ___strScriptPath = System.IO.Path.Combine(strParentlPath, "sunspider-0.9.1");
                    if (System.IO.Directory.Exists(___strScriptPath) == false)
                    {
                        throw new System.InvalidOperationException();
                    }
                    FILE_PATH = ___strScriptPath;

                }
                Console.WriteLine("Curren Script Path: {0}", FILE_PATH);
                ___strOptLevel = ConfigurationManager.AppSettings["opt"];


                ___strScript = ConfigurationManager.AppSettings["script"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace.ToString());
                return;
            }
            finally
            {
                if (string.IsNullOrEmpty(___strOptLevel) == false)
                {
                    if (int.TryParse(___strOptLevel, out ___optLevel))
                    {
                        if (___optLevel < -1)
                        {
                            ___optLevel = -1;

                        }
                        else if (___optLevel > 9)
                        {
                            ___optLevel = 9;
                        }
                    }
                }
            }
            _scope = new ClearScriptProcessorScope();
            _scope.initScriptEngine();
            _clearScriptProcessor = _scope.getMultiversalScriptProcessor();
            _scope.engine.AddHostObject("load", new Action<string>(load));
            _scope.engine.AddHostObject("print", new Action<string>(print));
            try
            {
                _clearScriptProcessor.execute("load('run.js');");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace.ToString());



            }
        }
        public static void load(string str)
        {
            string strFileName = str;
            string strFilePath = System.IO.Path.Combine(FILE_PATH, strFileName);
            string strScript = System.IO.File.ReadAllText(strFilePath);
            _clearScriptProcessor.execute(strScript);
        }
        public static void print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
