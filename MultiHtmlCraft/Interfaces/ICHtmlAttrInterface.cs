using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MultiHtmlCraft.Interfaces
{
    public interface ICHtmlAttrInterface
    {
        public string name { get; set; }
        public bool specified { get; set; }
        public object value { get; set; }
    }
}
