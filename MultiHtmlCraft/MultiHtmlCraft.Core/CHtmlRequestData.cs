using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft
{
    /// <summary>
    /// This class represents the data for a HTML request.
    /// </summary>
    public class CHtmlRequestData : ICHtmlRequestData
    {
        public Dictionary<string, string> fields { get; set; } = new Dictionary<string, string>();
        public CHtmlRequestData()
        {
        }
        public CHtmlRequestData(Dictionary<string, string> fields)
        {
            this.fields = fields;
        }
    }
    
}
