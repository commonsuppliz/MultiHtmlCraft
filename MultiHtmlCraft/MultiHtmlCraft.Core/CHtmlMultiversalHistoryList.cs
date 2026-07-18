using MultiHtmlCraft.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHtmlCraft.Core
{


    public class CHtmlMultiversalHistoryList
    {
        public static Dictionary<DateTimeOffset, CHtmlMultiversalWebHistory> CHtmlMultiversalWebHistoryCache = new Dictionary<DateTimeOffset, CHtmlMultiversalWebHistory>();
    }
    public class CHtmlMultiversalWebHistory
    {
        public DateTimeOffset? dateTimeOffset {  get; set; }
        public string? Url { get; set; }
        public string? FileLocation { get; set; }
        public string? ContentType { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public IMultiversalWindow? Window { get; set; } = null;
        public CHtmlDocument? Document { get; set; } = null;


    }
}