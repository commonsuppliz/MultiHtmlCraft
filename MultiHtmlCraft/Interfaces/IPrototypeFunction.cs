using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Interfaces
{
    public interface IPrototypeFunction
    {
        
        string name
        {
            get;
            set;
        }
        object multiversal_prototype_object
        {
            get;
            set;
        }
        IMutilversalObjectType  multiversalClassType
        {
            get;
            set;
        }
        
    }
  
}
