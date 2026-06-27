using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiHtmlCraft.Core;

namespace MultiHtmlCraft.Core
{
    public class CHttpContentDownload
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public string? FilePath { get; set; }
        public int ContentLength { get; set; }
        public CHtmlDocument? Document;
        public float Progress { get; set; }
        public byte[]? RawData { get; set; }
        public string ContentType { get; set; }
        public string? ContentEncoding { get; set; }
        public string? ContentDisposition { get; set; }
        public string? ContentLanguage { get; set; }


    }

}