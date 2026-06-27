
using System;
using System.Collections;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlUserAgentClass 
	/// </summary>
	public class CHtmlUserAgentClass
	{
		public string KeyName = "";
		public string appName = "";
		public string appCodeName = "";
		//public string appVersion = "";
		public string DisplayName = "";
		public string UserAgentString = "";
        public string versionShortName = "";
		/*
		 * The Navigator Object
This object provides detailed information about the current browser, including its name and possibly the build number and even operating system. The sample output we got from our copies of the Windows NT 4.0 version of Internet Explorer 3.01 and Netscape Navigator 3.01 are outlined in the table below:

			Caption: Navigator Object Results with Internet Explorer 3.01
			Property Value 
			appCodeName
			Mozilla 
			appName
			Microsoft Internet Explorer 
			appVersion
			2.0 (compatible; MSIE 3.01; Windows NT) 
			userAgent
			Mozilla/2.0 (compatible; MSIE 3.01; Windows NT) 


			Caption: Navigator Object Results with Netscape Navigator 3.01
			Property Value 
			appCodeName
			Mozilla 
			appName
			Netscape 
			appVersion
			3.01 (WinNT; I) 
			userAgent
			Mozilla/3.01 (WinNT; I) 
		*/
		public CHtmlUserAgentClass()
		{
		}

        public CHtmlUserAgentClass(string _KeyName, string _DisplayName, string _appName, string _appCodeName, string _UserAgentString, string _versionShortName)
        {
            this.KeyName = _KeyName;
            this.appName = _appName;
            this.appCodeName = _appCodeName;
            this.DisplayName = _DisplayName;

            this.UserAgentString = _UserAgentString;
            this.versionShortName = _versionShortName;
        }
		public CHtmlUserAgentClass Clone()
		{
			CHtmlUserAgentClass uc = new CHtmlUserAgentClass();
			uc.appCodeName = this.appCodeName;
			uc.appName = this.appName;
			uc.DisplayName = this.DisplayName;
			uc.KeyName = this.KeyName;
			uc.UserAgentString = this.UserAgentString;
            uc.versionShortName = this.versionShortName;
			return uc;
		}
		public static void InitializeUserAgentClassList(ref ArrayList sr)
		{
		
			CHtmlUserAgentClass IE50 = new CHtmlUserAgentClass("MSIE", "Microsoft Internet Explorer ver. 5.0","Microsoft Internet Explorer", "Mozilla",  "Mozilla/4.0 (compatible; MSIE 5.0; $$$)", "5.0");
			sr.Add( IE50);
			CHtmlUserAgentClass IE55 = new CHtmlUserAgentClass("MSIE", "Microsoft Internet Explorer ver. 5.5","Microsoft Internet Explorer", "Mozilla", "Mozilla/4.0 (compatible; MSIE 5.5; $$$)", "5.5");
			sr.Add( IE55);
			CHtmlUserAgentClass IE60 = new CHtmlUserAgentClass("MSIE", "Microsoft Internet Explorer ver. 6.0","Microsoft Internet Explorer", "Mozilla", "Mozilla/4.0 (compatible; MSIE 6.0; $$$)", "6.0");
			sr.Add(IE60);
            CHtmlUserAgentClass IE70 = new CHtmlUserAgentClass("MSIE", "Microsoft Internet Explorer ver. 7.0", "Microsoft Internet Explorer", "Mozilla", "Mozilla/4.0 (compatible; MSIE 7.0; $$$)", "7.0");
			sr.Add(IE70);
            CHtmlUserAgentClass IE80 = new CHtmlUserAgentClass("MSIE", "Microsoft Internet Explorer ver. 8.0", "Microsoft Internet Explorer", "Mozilla", "Mozilla/4.0 (compatible; MSIE 8.0; $$$)", "8.0");
			sr.Add(IE80);
            CHtmlUserAgentClass IE90 = new CHtmlUserAgentClass("MSIE", "Microsoft Internet Explorer ver. 9.0", "Microsoft Internet Explorer", "Mozilla", "Mozilla/5.0 (compatible; MSIE 9.0; $$$)", "9.0");
			sr.Add(IE90);
            CHtmlUserAgentClass IE100 = new CHtmlUserAgentClass("MSIE", "Microsoft Internet Explorer ver. 10.0", "Microsoft Internet Explorer", "Mozilla", "Mozilla/5.0 (compatible; MSIE 10.0; $$$; Trident/6.0)", "10.0");
			sr.Add(IE100);
            CHtmlUserAgentClass IE110 = new CHtmlUserAgentClass("MSIE", "Microsoft Internet Explorer ver. 11.0", "Microsoft Internet Explorer", "Mozilla", "Mozilla/5.0 ($$$; Trident/7.0) like Gecko", "11.0");
			sr.Add(IE110);
            CHtmlUserAgentClass IE120 = new CHtmlUserAgentClass("Edge", "Microsoft Edge ver. 12.0", "Microsoft Edge", "Mozilla", "Mozilla/5.0 ($$$) AppleWebkit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.93 Safari/537.36 Edge/12.10240", "12.0");
			sr.Add(IE120);
            CHtmlUserAgentClass IE130 = new CHtmlUserAgentClass("Edge", "Microsoft Edge ver. 13.0", "Microsoft Edge", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2486.0 Safari/537.36 Edge/13.10586", "13.0");
            sr.Add(IE130);
            CHtmlUserAgentClass IE140 = new CHtmlUserAgentClass("Edge", "Microsoft Edge ver. 14.0", "Microsoft Edge", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/14.14393 Safari/537.36 Edge/14.14393", "14.0");
            sr.Add(IE140);
            CHtmlUserAgentClass IE150 = new CHtmlUserAgentClass("Edge", "Microsoft Edge ver. 15.0", "Microsoft Edge", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.15063", "15.0");
            sr.Add(IE150);
            //"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36 Edge/16.16299"
            CHtmlUserAgentClass IE160 = new CHtmlUserAgentClass("Edge", "Microsoft Edge ver. 16.0", "Microsoft Edge", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36 Edge/16.16299", "16.0");
            sr.Add(IE160);

            CHtmlUserAgentClass N40 = new CHtmlUserAgentClass("Netscape", "Netscape Navigator ver. 4.0", "Netscape", "Mozilla", "Mozilla/4.0 (compatible; Netscape 4.0; $$$)", "4.0");
			sr.Add(N40);
            CHtmlUserAgentClass N50 = new CHtmlUserAgentClass("Netscape", "Netscape Navigator ver. 5.0", "Netcape", "Mozilla", "Mozilla/4.0 (compatible; Netscape 4.0; $$$)", "5.0");
			sr.Add( N50);
            CHtmlUserAgentClass G11 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 11.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/534.24 (KHTML, like Gecko) Chrome/11.0.696.71 Safari/534.24", "11.0");
			sr.Add(G11);
            CHtmlUserAgentClass G12 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 12.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/534.24 (KHTML, like Gecko) Chrome/12.0.696.71 Safari/534.24", "12.0");
			sr.Add(G12);
            CHtmlUserAgentClass G20 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 20.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/20.0.1132.07 Safari/537.11", "20.0");
			sr.Add(G20);
			//  Mozilla/5.0+(Windows+NT+6.2;+WOW64)+AppleWebKit/537.11+(KHTML,+like+Gecko)+Chrome/23.0.1271.97+Safari/537.11 
            CHtmlUserAgentClass G23 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 23.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.97 Safari/537.11", "23.0");
			sr.Add(G23);
            CHtmlUserAgentClass G24 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 24.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/24.0.1271.97 Safari/537.11", "24.0");
			sr.Add(G24);
            CHtmlUserAgentClass G25 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 25.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/25.0.1271.97 Safari/537.11", "25.0");
			sr.Add(G25);
			/*CHtmlUserAgentClass G26 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 25.0","Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/25.0.1271.97 Safari/537.11");*/
            CHtmlUserAgentClass G29 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 29.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/29.0.1547.76 Safari/537.36", "29.0");
			sr.Add(G29);
            CHtmlUserAgentClass G37 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 37.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.124 Safari/537.36", "37.0");
            sr.Add(G37);
            CHtmlUserAgentClass G40 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 40.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.000.000 Safari/537.36", "40.0");
            sr.Add(G40);
            CHtmlUserAgentClass G41 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 41.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36", "41.0");
            sr.Add(G41);
            CHtmlUserAgentClass G45 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 45.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.93 Safari/537.36", "45.0");
            sr.Add(G45);
            CHtmlUserAgentClass G46 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 46.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2486.0 Safari/537.36", "46.0");
            sr.Add(G46);
            CHtmlUserAgentClass G47 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 47.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.4 Safari/537.36", "47.0");
            sr.Add(G47);
            CHtmlUserAgentClass G48 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 48.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.82 Safari/537.36", "48.0");
            sr.Add(G48);
            CHtmlUserAgentClass G50 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 50.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2743.116 Safari/537.36", "50.0");
            sr.Add(G50);
            CHtmlUserAgentClass G52 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 52.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36", "52.0");
            sr.Add(G52);
            CHtmlUserAgentClass G53 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 53.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36", "53.0");
            sr.Add(G53);
            CHtmlUserAgentClass G54 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 54.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36", "54.0");
            sr.Add(G54);
            CHtmlUserAgentClass G55 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 55.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36", "55.0");
            sr.Add(G55);
            CHtmlUserAgentClass G58 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 58.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36", "58.0");
            sr.Add(G58);
            CHtmlUserAgentClass G60 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 60.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3029.110 Safari/537.36", "60.0");
            sr.Add(G60);
            //"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.119 Safari/537.36"
            CHtmlUserAgentClass G64 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 64.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.119 Safari/537.36", "64.0");
            sr.Add(G64);
            CHtmlUserAgentClass G69 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 69.0", "Chrome", "Mozilla", "Mozilla/5.0 ($$$) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36", "69.0");
            sr.Add(G69);
            CHtmlUserAgentClass G126 = new CHtmlUserAgentClass("Chrome", "Google Chrome ver. 126.0", "Chrome", "Mozilla", "Mozilla / 5.0($$$)  AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36", "126.0");
            sr.Add(G126);

            CHtmlUserAgentClass Fox40 = new CHtmlUserAgentClass("FireFox", "FireFox ver 4.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:2.0.1) Gecko/20100101 Firefox/4.0.1", "4.0");
			sr.Add(Fox40);
            CHtmlUserAgentClass Fox50 = new CHtmlUserAgentClass("FireFox", "FireFox ver 5.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:2.0.1) Gecko/20100101 Firefox/5.0.0", "5.0");
			sr.Add(Fox50);
            CHtmlUserAgentClass Fox100 = new CHtmlUserAgentClass("FireFox", "FireFox ver 10.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:2.0.1) Gecko/20121011 Firefox/10.0.0a4", "10.0");
			sr.Add(Fox100);
            CHtmlUserAgentClass Fox160 = new CHtmlUserAgentClass("FireFox", "FireFox ver 16.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:2.0.1) Gecko/20121011 Firefox/16.0.1", "16.0");
			sr.Add(Fox160);
            CHtmlUserAgentClass Fox250 = new CHtmlUserAgentClass("FireFox", "FireFox ver 25.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:23.0) Gecko/20100101 Firefox/25.0", "25.0");
			sr.Add(Fox250);
            CHtmlUserAgentClass Fox360 = new CHtmlUserAgentClass("FireFox", "FireFox ver 36.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:36.0) Gecko/20100101 Firefox/36.0", "36.0");
            sr.Add(Fox360);
            CHtmlUserAgentClass Fox480 = new CHtmlUserAgentClass("FireFox", "FireFox ver 48.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:48.0) Gecko/20100101 Firefox/48.0", "48.0");
            sr.Add(Fox480);
            CHtmlUserAgentClass Fox490 = new CHtmlUserAgentClass("FireFox", "FireFox ver 49.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:49.0) Gecko/20100101 Firefox/49.0", "49.0");
            sr.Add(Fox490);
            CHtmlUserAgentClass Fox500 = new CHtmlUserAgentClass("FireFox", "FireFox ver 50.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:50.0) Gecko/20100101 Firefox/50.0", "50.0");
            sr.Add(Fox500);
            CHtmlUserAgentClass Fox540 = new CHtmlUserAgentClass("FireFox", "FireFox ver 54.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:50.0) Gecko/20100101 Firefox/54.0", "54.0");
            sr.Add(Fox540);
            CHtmlUserAgentClass Fox550 = new CHtmlUserAgentClass("FireFox", "FireFox ver 55.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:50.0) Gecko/20100101 Firefox/55.0", "55.0");
            sr.Add(Fox550);
            //"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:58.0) Gecko/20100101 Firefox/58.0"
            CHtmlUserAgentClass Fox580 = new CHtmlUserAgentClass("FireFox", "FireFox ver 58.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:58.0) Gecko/20100101 Firefox/58.0", "58.0");
            sr.Add(Fox580);
            CHtmlUserAgentClass Fox610 = new CHtmlUserAgentClass("FireFox", "FireFox ver 61.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:61.0) Gecko/20100101 Firefox/61.0", "61.0");
            sr.Add(Fox610);
            CHtmlUserAgentClass Fox620 = new CHtmlUserAgentClass("FireFox", "FireFox ver 62.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:61.0) Gecko/20100101 Firefox/62.0", "62.0");
            sr.Add(Fox620);
            CHtmlUserAgentClass Fox700 = new CHtmlUserAgentClass("FireFox", "FireFox ver 70.0", "FireFox", "Mozilla", "Mozilla/5.0 ($$$; rv:70.0) Gecko/20100101 Firefox/70.0", "70.0");
            sr.Add(Fox620);
            // NCSA Mosaic "NCSA Mosaic/1.0 (X11;SunOS 4.1.4 sun4m)"
            CHtmlUserAgentClass NCSAMosaic10 = new CHtmlUserAgentClass("Mosaic", "NCSA Mosaic ver 1.0", "Mosaic", "Mosaic", "NCSA Mosaic/1.0 ($$$)", "1.0");
			sr.Add(NCSAMosaic10);
            CHtmlUserAgentClass NCSAMosaic20 = new CHtmlUserAgentClass("Mosaic", "NCSA Mosaic ver 2.0", "Mosaic", "Mosaic", "NCSA Mosaic/2.0 ($$$)", "2.0");
			sr.Add(NCSAMosaic20);
            CHtmlUserAgentClass NCSAMosaic30 = new CHtmlUserAgentClass("Mosaic", "NCSA Mosaic ver 3.0", "Mosaic", "Mosaic", "NCSA Mosaic/3.0 ($$$)", "3.0");
			sr.Add(NCSAMosaic30);
            CHtmlUserAgentClass NCSAMosaic40 = new CHtmlUserAgentClass("Mosaic", "NCSA Mosaic ver 4.0", "Mosaic", "Mosaic", "NCSA Mosaic/4.0 ($$$)", "4.0");
			sr.Add(NCSAMosaic40);
            CHtmlUserAgentClass NCSAMosaic50 = new CHtmlUserAgentClass("Mosaic", "NCSA Mosaic ver 5.0", "Mosaic", "Mosaic", "NCSA Mosaic/5.0 ($$$)", "5.0");
			sr.Add(NCSAMosaic50);
            CHtmlUserAgentClass NCSAMosaic60 = new CHtmlUserAgentClass("Mosaic", "NCSA Mosaic ver 6.3", "Mosaic", "Mosaic", "NCSA Mosaic/6.3 ($$$)", "6.3");
			sr.Add(NCSAMosaic60);
            CHtmlUserAgentClass NCSAMosaic70 = new CHtmlUserAgentClass("Mosaic", "NCSA Mosaic ver 7.5", "Mosaic", "Mosaic", "NCSA Mosaic/7.5 ($$$)", "7.5");
			sr.Add(NCSAMosaic70);
            /*
            CHtmlUserAgentClass NCSAMosaic100 = new CHtmlUserAgentClass("Mosaic", "NCSA Mosaic ver 10.0", "Mosaic", "Mosaic", "NCSA Mosaic/10.0 ($$$)", "10.0");
			sr.Add(NCSAMosaic100);
            */
            //            "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:58.0) Gecko/20100101 Firefox/58.0


            CHtmlUserAgentClass c1 = new CHtmlUserAgentClass("MCS", "Same as MCS UserAgent","", "" , "", "1.0");
			sr.Add(c1);
		}
	}
}
