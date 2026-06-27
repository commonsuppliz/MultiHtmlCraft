using System;
using System.Collections.Generic;
using System.Text;

namespace MultiHtmlCraft.Interfaces
{
    public interface ICHtmlElementInterface
    {
        string name { get; set; }
        string id { get; set; }
        string className { get; set; }
        string tagName { get; }
        string title { get; set; }
        string localName { get; }
        string baseUri { get; }
        object nodeValue { get; set; }

        string text { get; set; }
        string type { get; set; }
        object @value { get; set; }
        string innerHTML { get; set; }
        ICHtmlCollectionInterface childNodes { get; }
        double offsetTop { get; }
        double offsetLeft { get; }
        double offsetWidth { get; }
        double offsetHeight { get; }





    }
}
