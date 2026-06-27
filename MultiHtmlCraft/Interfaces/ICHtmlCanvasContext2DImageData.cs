using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICHtmlCanvas2DImageData
    {
       object data { get; }
       string colorSpace{ get; }
       double height { get; }
       double width { get; }


    }

}
