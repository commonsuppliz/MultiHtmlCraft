using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Security.Authentication;

namespace MultiversalRendererWinFormsTest
{
    internal static class Program
    {
        private static bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                System.Diagnostics.Debug.WriteLine($"Unhandled exception: {args.ExceptionObject}");
            };
            Application.Run(new FormMain());
        }
    }
}