
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiHtmlCraft.Core;
namespace MultiHtmlCraft.Core
{
    internal class commonParser
    {
        /// <summary>
        /// Load HTMLDocument from url
        /// </summary>
        /// <param name="url">string of url</param>
        /// <returns>HTMMLDocument</returns>
        public CHtmlDocument load(string url)
        {
            var htmldoc = new CHtmlDocument( CHtmlDomModeType.HTMLDOM);

            return htmldoc;
        }
    }
}
