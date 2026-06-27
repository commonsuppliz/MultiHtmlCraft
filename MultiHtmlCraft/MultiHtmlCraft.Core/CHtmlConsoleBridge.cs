using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHtmlCraft.Core
{
    public class CHtmlConsoleBridge
    {
        public void log(params object[] args)
        {
            var argstr = string.Join(" ", args);
            Console.WriteLine(argstr);
            System.Diagnostics.Debug.WriteLine(argstr);
        }
    }
}
