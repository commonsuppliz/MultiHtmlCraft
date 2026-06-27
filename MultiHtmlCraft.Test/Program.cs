using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using MultiHtmlCraft.Core;
using MultiHtmlCraft.Interfaces;
using NiL.JS.Core;
using NilJsProcessor;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.Data;
using NiL.JS;
using System.Diagnostics.CodeAnalysis;
using NLog;
using static System.Net.WebRequestMethods;
using NLog.Targets;
using System.Windows;
namespace Core.Test
{
    internal class Program
    {
        private static bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;
 
        static async Task Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                System.Diagnostics.Debug.WriteLine($"Unhandled exception: {args.ExceptionObject}");
            };

            
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                MaxRequestContentBufferSize = 1_000_000,
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13


            };
            handler.UseProxy = false;

            var window = new MultiHtmlCraft.Core.CHtmlMultiversalWindow(null, true, IMultiversalWindowType.NormalWindow);
             HttpClient? ___httpClient = null;
            ___httpClient = new HttpClient(handler);
            ___httpClient.Timeout = new TimeSpan(10000000);
            MultiHtmlCraft.Core.CHtmlMultiversalWindow.setHttpClient(___httpClient);
            MultiHtmlCraft.Core.commonLog.LoggingEnabled = true;
            MultiHtmlCraft.Core.commonLog.LogLevel = 10;

            commonLog.LoggingEnabled = true;
            commonLog.LogLevel = 10;



            // var url = @"https://ascii.jp"; // Sort Errors but looks ok!
            // var url = @"http://localhost/jstest/DomContentetloadedtest.html";
            // var url = @"https://phoboslab.org/xtype/"; //root.InserBefore Excecption it may be google analics script bug.
            // var url = @"https://www.kevs3d.co.uk/dev/phoria/test1.html";
            // var url = @"https://flateric.uber.space/canvas/";
            // var url = @"http://rectangleworld.com/demos/MorphingCurve/MorphingCurve_LinearGradient.html";
            // var url = @"https://js13kgames.com/games/the-way-of-the-dodo";
            // var url = @"http://localhost/jstest/AsyncDefer/AsyncDeferExample1.html";
            // var url = @"https://codeincomplete.com/games/delta/";
            // var url = @"https://www.businessinsider.jp/article/2504-microsoft-cto-ai-generated-code-software-developer-job-change/";
            // var url = @"https://funhtml5games.com?embed=sonicmario";
            //var url = @"https://funhtml5games.com?embed=breakaway";
            //var url = "https://funhtml5games.com?embed=retroracer";
            // var url = @"https://lab.hakim.se/origami/";
            // var url = "http://localhost/frogger/index.html";
            // var url = "http://localhost/jstest/CreateElementTest1.html"; // looks ok
            //r url = "http://localhost/jstest/CreateElementTest3.html"; // Node instanceof Error
            // var url = "http://localhost/jstest/jqueryTest/JQuweyTest1.html"; // JQueryTest . Sucess!
            // var url = "https://dgreenheck.github.io/minecraft-threejs-clone/";
            // URLSeachParams Test
            // var url = "http://localhost/jstest/URLSeachParamsTest1.html";
            // var url = "http://localhost/jstest/URLSeachParamsTest2.html";
            // var  url = "http://localhost/jstest/URLSeachParamsTest3.html";


            // var url = "http://localhost/jstest/CHtmlElementDefinePropertytest2.html"; // Element definePropertyTest should return 42

            // var url = "http://localhost/jstest/ObjectDefinePropertytest1.html";
            // var url = "http://localhost/jstest/RemoveEventLisenterTest1.html";
            // var url = "http://localhost/jstest/GlobalJSTest.html";
            // var url = "http://localhost/canvas/example3.html";
            // var url = "http://localhost/jstest/SetIntervalTest.html";
            // var url = "https://www.nytimes.com"; // script OK!
            // var url = "http://localhost/Html5-Zelda-master/index.html"; // comile ok
            // var url = "http://localhost/jstest/newLibraryClasInstanceTest1.html";
            // var url = "http://localhost/jstest/InsertBeforeTest1.html";
            // var url = "http://localhost/jstest/AppendChildTest1.html";
            // var url = "http://localhost/jstest/ParentNodeTest.htm";
            // var url = "http://localhost/jstest/CanvasAnimationFrameTest1.html";
            // var url = "http://localhost/jstest/GlobalVariableTest1.html";
            // var url = "http://localhost/jstest/AddEventListenerExample1.html";
            // var url = "http://localhost/jstest/MorchingCurve_LinerGradienthtml.html";
            // var url = "https://www.kesiev.com/akihabara/demo/game-capman.html";

            // var url = "http://localhost/Html5_XeviousMini/index.html"; // alotof Erros.
            // var url = "http://localhost/canvas-tetris-master/index.html";
            // var url = "http://arcade.lostdecadegames.com/onslaught-arena/";
            // var url = "https://blog-tutorial-supabase.vercel.app/";// Next Js Example, OK
            // var url = "http://localhost/jquery-main/test/index.html";
            // var url = "https://lutzroeder.github.io/digger/";
            // var url = "https://codeincomplete.com/games/delta/"; 
            // var url = "http://localhost/jstest/MapSetTst1.html"; // JS Map Object set, getInner Test , Looks OK, No Dynamic Error
            // var url = "https://codeincomplete.com/games/gauntlet/"; //Gatret HTML5
            // var url = "https://funhtml5games.com/racer10k/index.php"; // JQuery $ not found
            //var url = "http://localhost/canvas/RequestAnimationFrameTest1.html"; //RequestAnimationFrame FrameTest
            //  var url = "http://localhost/canvas/CanvasFillRectTest1.html"; // Compile OK

            // root.insertBefore is not a function
            // 
            // var url = "https://www.kevs3d.co.uk/dev/warpfield/";

            // var url = "http://localhost/jstest/ElementStyleSetValueTest1.html"; // element.style set getInner test. ok!

            // var url = "http://localhost/jstest/JavascriptModernizer253Test.html";  // modernizer test docElement.appendChild is not a function erroor // timing issue extsis.
            // var url = "http://localhost/jstest/CanvasFillElementStyleTest1.html";
            // var url = "http://localhost/jstest/CanvasGetImageDataHDTest1.html"; //CanvasContextDataD2.data.letgth resturns sucessfull


            // var url = "https://mcfunkypants.com/kart/magma/"; // html5 game Compile is ok
            // var url = "https://funhtml5games.com/bubblebobble/index.html";
            // var url = "https://play.js13kgames.com/ballarena-2013k/";  // html5 compile ok!
            // var url = "https://play.js13kgames.com/theos-escape/"; // compile ok
            // var url = "http://localhost/jstest/DomContentLoadedTest.html"; // DOMContentLoaded Test
            // var url = "http://localhost/jstest/DOMaddEventLisnerLoadTest1.html";
            // var url = "https://funhtml5games.com/pixelminer/index.html"; // script type vertex exception
            // var url = "https://minecraft-freecodecamp.vercel.app/"; // MineCraft Clone. WebGL Script GetItem Exception
            // var url = "https://phoboslab.org/xibalba/"; // script error
            // var url = "https://cdn-factory.marketjs.com/en/street-fight/index.html"; // script error
            // var url = "http://localhost/jstest/JSFunctionCallWithParamsTest1.html"; // Simpe Javascript function with parameters. OK!
            // var url = "http://localhost/jstest/JSFunctionCallWithParamsTest2.html"; // call.apply test
            // var url = "http://localhost/jstest/JSFunctionCallWithParamsTest3.html"; // calling function with arguments. OK!
            // var url = "https://fhtr.org/runfield/runfield/"; // compile ok!
            // var url = "https://openhtml5games.github.io/games-mirror/dist/mariohtml5/main.html";  // Infinite Mario Bros Canvas . JQuery Compile OK
            // var url = "https://www.mit.edu"; // async script is not called.
            // var url = "https://xtech.nikkei.com/"; // infine loop
            // var url = "http://localhost/canvas/CanvasFillRectTest1.html";
            // var url = "http://localhost/canvas/CanvasMoveToExample.html";
            // var url = "http://localhost/canvas/CanvasFillRectTest2.html";
            // var url = "http://localhost/canvas/RequestAnimationFrameTest1.html";
            // var url = "http://localhost/canvas/CanvasDrawLinesTest1.html";
            // var url = "http://localhost/html/SimpleHTMLDoc.html";
            // var url = "http://localhost/csssample/importexample/LoadImportCSS.html";
            // var url = "http://localhost/jstest/DomElementStylesheetTest1.html";
            // var url = "https://www.watersheep.org/~markh/html_canvas/game.html"; // compile "ok"
            // var url = "https://funhtml5games.com/outrun/index.html"; // Script Error
            // var url = "http://localhost/canvas/RequestAnimationFrameTest2.html";
            // var url = "https://japan.zdnet.com/"; mostly ok.
            // var url = "https://funhtml5games.com?embed=mario"; //Infinite Mario
            // var url = "https://funhtml5games.com?embed=gauntlet";
            // var url = "http://localhost/jstest/ElementChildNodesTest.html"; // ChildNodes Loop Test OK!
            // var url = "http://localhost/jstest/ElementAttributeTest1.html"; // Element.attributes Test OK!
            // var url = "http://localhost/csssample/StyleTagSampleAttributeCheck1.htm";
            // var url = "https://informatics.sist.ac.jp/suganuma/JavaScript/DOM_canvas/canvas/game_shoot/game1.htm"; // compile OK
            // var url = "http://localhost/csssample/StyleTagSampleAttributeCheck1.htm";
            // var url = "http://localhost/jstest/ElementStyleDisplayPropertyTest1.html";
            // var url = "http://www.effectgames.com/demos/canvascycle/"; // Canvas bitmap castle animation errors.
            // var url = "http://localhost/jstest/ElementClassListTest1.html"; // Element.classList Test
            // var url = "http://localhost/csssample/CSSRootChildTest1.html";// querySelectorAll.  ok! Dynamic Occurs still.
            // var url = "http://localhost/jstest/ElementMatchesTest1.html"; // Element.matches() Test
            // var url = "https://topics.smt.docomo.ne.jp/article/president/bizskills/president_95537?page=1";
            // var url = "http://localhost/jstest/ElementInsertBeforeTest1.html";
            // var url = "https://www.def-logic.com/_dhtml/darkage/index.html"; // Compile OK
            // var url = "https://funhtml5games.com?embed=pixelminer"; // Minecraft ty@e of game 3d error
            // var url = "http://localhost/jstest/XMLHttpRequestTest1.html";
            // var url = "http://localhost/jstest/XMLHttpRequestStatusTest1.html";
            // var url = "http://localhost/jstest/XMLHttpRequestStatusTest2.html";
            // var url = "http://localhost/canvas/CanvasGraphTest1.html";
            var url = "http://localhost/jstest/OnloadTest1.html";

            if (commonLog.LoggingEnabled)
            {
                commonLog.LogEntry($"Requesting {url} Managed Thread ID :{System.Threading.Thread.CurrentThread.ManagedThreadId}");
            }
       
            var document = await MultiHtmlCraft.Core.CHtmlDocument.createDocument(CHtmlDomModeType.HTMLDOM, url, window);
            Console.WriteLine("App is completed");
            Console.ReadLine();
        }


 
        
    }
}
    


