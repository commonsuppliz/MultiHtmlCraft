using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MultiHtmlCraft.Interfaces
{
    public interface ICHtmlRequestData
    {
        public Dictionary<string, string> fields { get; set; }
    }
}
