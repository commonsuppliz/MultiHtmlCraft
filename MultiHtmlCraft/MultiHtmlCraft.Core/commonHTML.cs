using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using MultiHtmlCraft.Interfaces;
using System.IO;
using System.Text;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.InteropServices;
using System.Net.Http;
using NiL.JS.Expressions;
using NTextCat;
using System.Linq.Expressions;
using Microsoft.VisualBasic;
using ManagedBass;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

using System.Globalization;
using System.Data.SqlTypes;









#if DEBUG
using System.Diagnostics;
#endif

namespace MultiHtmlCraft.Core
{
    [Flags]
    public enum CSSStyleConditionType : byte
    {
        None,
        ElementStyle,
        MergedToElement,
        PseudoMatchesCondition,
        PseudoNotCondition
    }
    [Flags]

    public enum HttpDecompressionSupportType : byte
    {
        Unknow,
        Auto,
        Gzip,
        None
    }


    public enum CHtmlHighPrecisionTimerType : byte
    {

        NotTested,
        WindowsMultimediaTimer,
        DiagnosticsStopWatchThreadTimer,
        UnixSystemTimer,
        WM_Timer,
    }
    public enum CHtmmlUriProtocolType : byte
    {
        None = 0,
        http = 1,
        https = 2,
        ftp = 3,
        ftps = 4,
        mailto = 5,
        data = 6,
        file = 7,
        javascript = 8,
        about = 9,
        /// <summary>
        /// Cookie Data
        /// </summary>
        cookie,
        /// <summary>
        /// sessionStorage Data
        /// </summary>
        sstorage,
        /// <summary>
        /// localStorage Data
        /// </summary>
        lstorage,
        /// <summary>
        /// Host Storage Data
        /// </summary>
        hoststore
    }
    public enum CHtmlEnqeueStatusType : byte { UNKNOWN = 0, ProcessQueueAsync = 9, ProcessQueueDefer= 10, ProcessQueueModule = 11, Template = 12 };

    public enum CHtmlWebProxyType : byte { UseDirect = 0, UseIE = 1, UseCustom = 2 };

    public enum CHtmlFloatType : byte { Undefined = 0, Left = 1, Right = 2, Center = 3 };

    public enum CHtmlSizeModeType : byte { Undefined = 0, Width = 1, Height = 2, Both = 10 };

    public delegate void NavigatingUrlEventHandler(object sender, string _url);


    public enum CHtmlCanvasInstructionType : byte
    {
        None,
        Save,
        Restore, 
        Scale,
        Translate,
        Rotate,
        Transform,
        SetTransform,
        Clip,
        ResetTransform,
        QuadraticCurveTo
    }
    public enum CHtmlFileType : byte
    {
        Unknown = 0,
        Html = 1,
        Xml = 2,
        Text = 3,
        Jsp = 4,
        Aspx = 5,
        Asp = 6,
        JavaScript,
        Json,
        VBScript,
        GIF,
        PNG,
        JPG,
        ICO,
        BMP,
        TIFF,
        Css,
        Rss,
        Doc,
        Docx,
        Xls,
        Xlsx,
        Ppt,
        Pptx,
        PDF,
        SVG,
        MP3,
        OGG,
        WMA,
        MP4,
        AVI,
        FLV
    };


    public enum CHtmlDrawingObjectType : byte
    {
        NONE = 0, TEXT = 1, Layout = 2, ChildRectangle = 3
    };

    public enum CHtmlVersionType : byte { Version1 = 1, Version3 = 3 };

    public enum CHtmlThreadPoolQueueObjectType : byte { NotSelected = 0, Field = 1, OIL = 2, MSOffice = 3, MAP = 4, MCS = 10, CPX = 50, UrlImage = 60, UrlImagePrefetch = 61, UrlScriptPrefetch = 62, UrlVideoPrefetch = 63, UrlAudioPrefetch = 64, UrlStyleSheetPrefetch = 65, UrlContent = 70, UrlFontFace = 71, UrlStyleSheet = 75, UrlScript = 80, UrlBinaryDownloadWidthConjunction = 90, SelfDraw = 99, HTMLSUMMARY = 100, HTMLTXT = 101, HtmlDocument = 102, HTMLRectangle = 103, HTMLNON = 199, HtmlMultiversalDocuemnt };
    /// <summary>
    /// Must use following values
    /// 1,2, 4, 8, 6, 32, 64, 128, 256, 512,1024,2048,8192
    /// </summary>
    /// 


    public enum CHtmlBaseInterfaceType : byte
    {
        None = 0,
        IExpando = 32
    }

    public enum CHtmlAssemblyLoadStatusType : sbyte
    {
        Uninitalized = -1,
        AttemptedButFaied = -10,
        Loaded = 100
    }
    [Flags]

    public enum CHtmlTagReadSkipModeType : byte
    {
        none,
        skip_html,
        skip_body,
        skip_head
    }
    [Flags]

    public enum CHtmlSelectorKeyClassType : ushort
    {
        NotSet = 0,
        TagName = 1,
        ClassName = 2,
        ID = 4,
        Attribute = 32,
        Prefix = 64,
        Sufix = 128,
        Wildcard = 256,
        TagName_ClassName_Combination = 4096,
        TagName_ID_Combination = 8192,
        ClassName_ID_Combinaion = 16384,
        TagName_ClassName_ID_Combination = 32768
    }
    /// <summary>
    /// IHTMLDocument2::plugins Property
    /// Retrieves an interface pointer to a zero-based collection of 
    /// all the embed objects in an HTML document. The objects are in 
    /// the same order as they appear in the document. 
    /// </summary>
    //private CHtmlCollection _plugins = null;

    public enum DOMCSSApplyModeType : byte
    { BOF = 1, MOF = 5, EOF = 10 }
    ;



    [Flags]

    public enum CSSHackType : sbyte
    {
        None = 0,
        IE = 1,
        Chrome = 2,
        Firefox = 4,
        Opera = 32,
        Safari = 64
    }
    [Flags]

    public enum CHtmlMediaElementPreloadType : byte
    {
        /// <summary>
        /// Not Set
        /// </summary>
        unkonwn = 0,
        /// <summary>
        /// Automatically downloads
        /// </summary>
        auto = 1,
        /// <summary>
        /// Metadata Only
        /// </summary>
        metadata = 2,
        /// <summary>
        /// None or False
        /// </summary>
        none = 10
    }
    [Flags]

    public enum CHtmlHttpResourceResultStatusType : ushort
    {
        NotYet = 0,
        Queue = 9,
        OK = 200,
        NotFound = 400
    }



    public enum CSSFloatType : byte
    {
        NotSet = 0,
        Left = 1,
        Right = 2,
        Both = 4
    }


    public enum CSSElelemntFloatClearType : byte
    {
        NotSet = 0,
        Left = 1,
        Right = 2,
        Both = 4
    }

    public enum GraphicAPIType  

    {
        Unknown,
        WinformsGDI,
        WPF,
        SkiaSharp,
        Avalonia,
        Maui,
        UnoPlatform,
        ETO
    }
    public enum CSSBackgroundSizeType : byte
    {
        NotSet = 0,
        Auto = 1,
        Contain = 2,
        Cover = 3,
        NumericValue = 99
    }
    public enum CHtmlPerformanceTimmingParameterType : byte
    {
        navigationStart,
        unloadEventStart,
        unloadEventEnd,
        redirectStart,
        redirectEnd,
        fetchStart,
        domainLookupStart,
        domainLookupEnd,
        connectStart,
        connectEnd,
        secureConnectionStart,
        requestStart,
        requestEnd,
        responseStart,
        responseEnd,
        domLoading,
        domInteractive,
        domContentLoadedEventStart,
        domContentLoadedEventEnd,
        domComplete,
        loadEventStart,
        loadEventEnd = 100,
        domContentLoadedStart,
        domContentLoadedEnd
    }


    public enum CSSOverFlowType : byte
    {
        NotSet = 0,
        Visible = 1,
        Scroll = 2,
        Hidden = 3,
        Auto = 4,
        Inherit = 10
    }
    [Flags]

    /// <summary>
    /// CSS WhiteSpace Type 
    /// default  :    normal
    /// </summary>
    public enum CSSWhiteSpaceType : byte
    {
        /// <summary>
        /// Sequences of whitespace will collapse into a single whitespace. Text will wrap when necessary. This is default
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Sequences of whitespace will collapse into a single whitespace. Text will never wrap to the next line. The text continues on the same line until a <br> tag is encountered
        /// </summary>
        NoWrap = 2,
        /// <summary>
        /// Whitespace is preserved by the browser. Text will only wrap on line breaks. Acts like the <pre> tag in HTML
        /// </summary>
        Pre = 3,
        /// <summary>
        /// Sequences of whitespace will collapse into a single whitespace. Text will wrap when necessary, and on line breaks
        /// </summary>
        PreLine = 4,
        /// <summary>
        /// Whitespace is preserved by the browser. Text will wrap when necessary, and on line breaks
        /// </summary>
        PreWrap = 5,
        /// <summary>
        /// Sets this property to its default value. Read about initial
        /// </summary>
        Inital = 6,
        /// <summary>
        /// Inherits this property from its parent element. Read about inherit
        /// </summary>
        Inherit = 10
    }
    public enum CSSBorderStyleType : byte
    {
        unknown = 0,
        none = 1,
        hidden = 2,
        solid = 3,
        @double = 4,
        groove = 5,
        ridge = 6,
        inset = 7,
        outset = 8,
        dashed = 9,
        dotted = 10
    }


    public enum CHtmlUriProtocolType : byte
    {
        None = 0,
        http = 1,
        https = 2,
        ftp = 3,
        ftps = 4,
        mailto = 5,
        data = 6,
        file = 7,
        javascript = 8,
        about = 9,
        /// <summary>
        /// Cookie Data
        /// </summary>
        cookie,
        /// <summary>
        /// sessionStorage Data
        /// </summary>
        sstorage,
        /// <summary>
        /// localStorage Data
        /// </summary>
        lstorage,
        /// <summary>
        /// Host Storage Data
        /// </summary>
        hoststore
    }




    public enum CHtmlElementAlignType : byte
    {
        /// <summary>
        /// Left 
        /// </summary>
        NotSet = 0,
        Middle = 1,
        Right = 2,
        Top = 9,
        Bottom = 10
    }

    [Flags]
    public enum CSSTextDecorationType : byte { none = 0, underline = 1, overline = 2, linethrough = 4, blink = 8 }

    [Flags]
    public enum CSSFontStyleType : byte { normal = 0, italic = 1, oblique = 2 }

    [Flags]
    public enum CSSFontWeightType : ushort { normal = 0, bold = 1, bolder = 2, lighter = 4, light = 8, n100 = 16, n200 = 32, n300 = 64, n400 = 128, n500 = 256, n600 = 512, n700 = 1024, n800 = 2048, n900 = 2048 }


    public enum CHtmlHTMLCollectionType : byte
    {
        Unknown = 0,
        BadQueryList = 1,
        SearchResutSet = 2,
        QuerySelectorset = 3,
        ElementChildNodes = 10,
        ElementTextNodes = 11,
        ElementAttributes = 12,
        ElementClassList = 13,
        ElementFloatTopList = 14,
        ElementCSSQuickChildNodes = 15,
        ElementChildren = 16,
        ElementGetElementsByTagNameList = 20,
        ElementGetElementsByNameList = 21,
        ElementGetElementsByClassNameList = 22,
        ElementGetElementsByIDList = 23,
        DocumentForms = 50,
        DocumentFrames = 51,
        DocumentAnckors = 52,
        DocumentEmbeds = 53,
        DocumentLinks = 54,
        DocumentLayers = 55,
        DocumentNamespaces = 56,
        DocumentImageElements = 57,
        DocumentAllInternal = 58,
        DocumentScripts = 59,
        DocumentImageRaw = 60,
        DocumentAttributes = 61,
        DocumentChildNodes = 62,
        DocumentStyleSheets = 63,
        DocumentAllTagsList = 64,

        DocumentWindowEventAttributes = 80,
        DocumentGetElementsByTagNameList = 81,
        DocumentGetElementsByNameList = 82,
        DocumentGetElementsByClassNameList = 83,
        DocumentEvaluateList = 90,
        DocumentGetItemsResult = 91, // Microdata Result
        NavigatorPlugins = 100,
        NavigatorMimeTypes = 101,
        NavigatorSubplugins = 102,
        NavigatorIDList = 105,
        CSSRuleList = 200,
        SelectOptions = 201,
        FormElementsList,
        TextElementParentLookedupedList,
        EventObjectBookmarkList,
        EventTouchesList,
        EventTargeTouchesList,
        EventChangedTouchesList,
        WindowHistory,
        WindowFramesAsMultiversalWindow,
        LocationAncestorOriginsList,
        XMLHttpResponseHeadersList,
        CanvasContextImageByteArray,
        NodeChildNodes,
        HTMLCollectionPrototype,
        NodeListPrototype,
        MediaTrackList,
        PerformanceEntriesList
    }

    public enum CHtmlReadytStateType : byte
    {
        uninitialized = 0,
        loading = 1,
        interactive = 5,
        complete = 10,
    }


    public enum CHtmlDomModeType : byte
    {
        /// <summary>
        ///  Loads All Html, css and javascript
        /// </summary>
        HTMLDOM,
        /// <summary>
        ///  Loads All Html, css and javascript
        /// </summary>
        HTMLDOM_NoGUI, // Loads HTML CSS Not GUI
        /// <summary>
        /// Loads DOM only, no css, no script
        /// </summary>
        HTMLSegment,
        /// <summary>
        /// Loads DOM only, no css, no script
        /// </summary>
        HTMLDocumentFragment,
        /// <summary>
        /// Loads DOM only, no css, no script
        /// </summary>
        HTML, // Loads HTML DOM, no css, no script
        /// <summary>
        /// Load XML Only
        /// </summary>
        XMLDOM,  // Load XML DOM Only
        /// <summary>
        /// Load SVG DOM Only
        /// </summary>
        SVGDOM // Vector Graphics Dom
    }

    public enum CHtmlEventOriginatorType : short
    {
        UNKNOWN = -1,
        CHTMLDocument = 1,
        CHTMLWindow = 2,
    }

    public enum CHtmlEmbededObjectType : byte
    {
        NotSet = 0,
        ShockwaveFlash = 1,
        SVG = 2,
        Image = 5,
        Other = 99

    }

    public enum CHtmlGradationColorType : byte
    {
        Normal = 0,
        StopColor = 10,
        EndColor = 20
    }
    [Flags]

    public enum CHtmlElementStyleType : byte
    {
        None = 0,
        Element = 1,
        Hover = 2,
        Active = 4,
        Prototype = 5,
        InlineStyle = 6
    }
    [Flags]

    public enum CSSFontFaceFormatType : byte
    {
        NotSet,
        TrueType,
        OpenType,
        Embedded_OpenType,
        Woff10,
        Woff20,
        Svg,
        Svgz,
    }

    public enum CHtmlStyleSelectorKeyDataModeType : byte
    {
        Other = 0,
        TagOnly = 1,
        ClassOnly = 2,
        IDOnly = 4
    }

    public enum CSSPositionType : byte
    {
        relative = 0,
        absolute = 3,
        @static = 10
    }

    /*
     * 00000000  0
00000001  1
00000010  2
00000100  4
00001000  16
00010000  32
00100000  64
01000000  128
    */


    [Flags]
    public enum CHtmlPseudoClassType : long
    {

        None = 0,
        HoverPseudoClass = 1,
        ActivePseudoClass = 2,
        LinkPseudoClass = 4,
        FocusPseudoClass = 16,
        VisitedPseudoClass = 32,
        LangPseudoClass = 64,
        AfterPseudoClass = 128,
        BeforePseudoClass = 256,
        RootPseudoClass = 512,
        FirstChildPseudoClass = 1024,
        PlaceHolderPseudoClass = 2048,
        FirstLinePseudoClass = 4096,
        FirstLetterPseudoClass = 8192,
        RequiredPseudoClass = 16384,
        SelectionPseudoClass = 32768,
        DirPseudoClass = 65536,
        InvalidPseudoClass = 131072,
        ValidPseudoClass = 262144,
        ReadWritePseudoClass = 524288,
        TargetPseudoClass = 1048576,
        WarningPseudoClass = 4194304,
        IndeterminatePseudoClass = 8388608,
        ReadOnlyPseudoClass = 16777216,
        EmptyPseudoClass = 33554432,
        EnabledPseudoClass = 67108864,
        DisabledPseudoClass = 134217728,
        CheckedPseudoClass = 268435456,
        OptionalPseudoClass = 536870912,
        FirstOfTypePseudoClass = 1073741824,
        NthOfTypePseudoClass = 2147483648,
        UnknownPseudoClass = 4294967296,
        SearchDecorationPseudoClass = 8589934592,
        SearchCancelButton = 17179869184,
        ScrollBarButtonPseudoClass = 34359738368,
        FullScreenPseudoClass = 68719476736,
        ClearPseudoClass = 137438953472,
        HorizontalPseudoClass = 274877906944,
        VerticalPseudoClass = 549755813888,
        ContainsPseudoClass = 1099511627776,
        StartPseudoClass = 2199023255552,
        EndPseudoClass = 4398046511104,
        AnyLinkPseudoClass = 8796093022208,
        DefaultPseudoClass = 17592186044416,
        IncrementPseudoClass = 35184372088832,
        DecrementPseudoClass = 70368744177664,
        // Any Classes Below Disables Neiborhood Class Copy	
        LastOfTypePseudoClass = 281474976710656,
        OnlyOfTypePseudoClass = 562949953421312,
        NthLastOfTypePseudoClass = 1125899906842624,
        LastChildPseudoClass = 2251799813685248,
        OnlyChildPseudoClass = 4503599627370496,
        NthChildPseudoClass = 9007199254740992,
        NthLastChildPseudoClass = 18014398509481984,
        MatchesConditionPseudoClass = 36028797018963968,
        NotConditionPseudoClass = 72057594037927936,
        FunctionPseudoClass = (long)((double)1.4411519e+17),
    }
#if XYZ
    sample Enum
      public enum ObjType : long
    {
        [DescriptionAttribute("View Rule Group")]
        ViewRuleGroup = 1,
        [DescriptionAttribute("Add Rule Group")]
        AddRuleGroup = 2,
        [DescriptionAttribute("Edit Rule Group")]
        EditRuleGroup = 4,
        [DescriptionAttribute("Delete Rule Group")]
        DeleteRuleGroup = 8,
        [DescriptionAttribute("View Rule")]
        ViewRule = 16,
        [DescriptionAttribute("Add Rule")]
        AddRule = 32,
        [DescriptionAttribute("Edit Rule")]
        EditRule = 64,
        [DescriptionAttribute("Delete Rule")]
        DeleteRule = 128,
        [DescriptionAttribute("View Location")]
        ViewLocation = 256,
        [DescriptionAttribute("Add Location")]
        AddLocation = 512,
        [DescriptionAttribute("Edit Location")]
        EditLocation = 1024,
        [DescriptionAttribute("Delete Location")]
        DeleteLocation = 2048,
        [DescriptionAttribute("View Volume Statistics")]
        ViewVolumeStatistics = 4096,
        [DescriptionAttribute("Edit Volume Statistics")]
        EditVolumeStatistics = 8192,
        [DescriptionAttribute("Upload Volume Statistics")]
        UploadVolumeStatistics = 16384,
        [DescriptionAttribute("View Role")]
        ViewRole = 32768,
        [DescriptionAttribute("Add Role")]
        AddRole = 65536,
        [DescriptionAttribute("Edit Role")]
        EditRole = 131072,
        [DescriptionAttribute("Delete Role")]
        DeleteRole = 262144,
        [DescriptionAttribute("View User")]
        ViewUser = 524288,
        [DescriptionAttribute("Add User")]
        AddUser = 1048576,
        [DescriptionAttribute("Edit User")]
        EditUser = 2097152,
        [DescriptionAttribute("Delete User")]
        DeleteUser = 4194304,
        [DescriptionAttribute("Assign Permissions To User")]
        AssignPermissionsToUser = 8388608,
        [DescriptionAttribute("Change User Password")]
        ChangeUserPassword = 16777216,
        [DescriptionAttribute("View Audit Logs")]
        ViewAuditLogs = 33554432,
        [DescriptionAttribute("View Team")]
        ViewTeam = 67108864,
        [DescriptionAttribute("Add Team")]
        AddTeam = 134217728,
        [DescriptionAttribute("Edit Team")]
        EditTeam = 268435456,
        [DescriptionAttribute("Delete Team")]
        DeleteTeam = 536870912,
        [DescriptionAttribute("View Web Agent Reports")]
        ViewWebAgentReports = 1073741824,
        [DescriptionAttribute("View All Locations")]
        ViewAllLocations = 2147483648,
        [DescriptionAttribute("Access to My Search")]
        AccessToMySearch = 4294967296,
        [DescriptionAttribute("Access to Pespective Search")]
        AccessToPespectiveSearch = 8589934592,
        [DescriptionAttribute("Add Pespective Search")]
        AddPespectiveSearch = 17179869184,
        [DescriptionAttribute("Edit Pespective Search")]
        EditPespectiveSearch = 34359738368,
        [DescriptionAttribute("Delete Pespective Search")]
        DeletePespectiveSearch = 68719476736,
        [DescriptionAttribute("Access to Search")]
        AccessToSearch = 137438953472,
        [DescriptionAttribute("View Form Roles")]
        ViewFormRole = 274877906944,
        [DescriptionAttribute("Add / Edit Form Roles")]
        AddFormRole = 549755813888,
        [DescriptionAttribute("Delete UserFormRolesDifferenceMasks")]
        DeleteFormRole = 1099511627776,
        [DescriptionAttribute("Export Locations")]
        ExportLocations = 2199023255552,
        [DescriptionAttribute("Import Locations")]
        ImportLocations = 4398046511104,
        [DescriptionAttribute("Manage Location Levels")]
        ManageLocationLevels = 8796093022208,
        [DescriptionAttribute("View Job Title")]
        ViewJobTitle = 17592186044416,
        [DescriptionAttribute("Add Job Title")]
        AddJobTitle = 35184372088832,
        [DescriptionAttribute("Edit Job Title")]
        EditJobTitle = 70368744177664,
        [DescriptionAttribute("Delete Job Title")]
        DeleteJobTitle = 140737488355328,
        [DescriptionAttribute("View Dictionary Manager")]
        ViewDictionaryManager = 281474976710656,
        [DescriptionAttribute("Add Dictionary Manager")]
        AddDictionaryManager = 562949953421312,
        [DescriptionAttribute("Edit Dictionary Manager")]
        EditDictionaryManager = 1125899906842624,
        [DescriptionAttribute("Delete Dictionary Manager")]
        DeleteDictionaryManager = 2251799813685248,
        [DescriptionAttribute("View Choice Manager")]
        ViewChoiceManager = 4503599627370496,
        [DescriptionAttribute("Add Choice Manager")]
        AddChoiceManager = 9007199254740992,
        [DescriptionAttribute("Edit Chioce Manager")]
        EditChoiceManager = 18014398509481984,
        [DescriptionAttribute("Delete Choice Manager")]
        DeleteChoiceManager = 36028797018963968,
        [DescriptionAttribute("Import Export Choices")] //57
        ImportExportChoices = 72057594037927936
    }
#endif

    /// <summary>
    /// Types what attributes ___hasInner been defined in CHtmlElement
    /// </summary>

    [Flags]
    public enum CHtmlElementDeclaredAttributeType : byte
    {
        TagOnly = 0,
        Class = 1,
        ID = 2,
        Name = 4,
        Type = 16,
    }
    public enum CLRType : byte
    {
        UNKNOWN = 0,
        MicrosoftCLR = 1,
        MonoCLR = 2,
        Other = 3
    }
    /// <summary>
    /// Types for insertAdjst method
    /// </summary>

    public enum CHtmlHtmlAdjacentType : byte
    {
        unknown,
        beforebegin,
        afterbegin,
        beforeend,
        afterend,
    }

    /// <summary>
    /// Types what attributes ___hasInner been defined in CHtmlElement
    /// </summary>

    [Flags]
    public enum CHtmlNumericArrayType : byte
    {
        None,
        Uint8Array,
        Uint16Array,
        Uint32Array,
        Uint64Array,
        Uint128Array,
        Uint256Array,
        Int8Array,
        Int16Array,
        Int32Array,
        Int64Array,
        Int128Array,
        Int256Array,
        Float32Array,
        Float64Array,
        Float128Array,
        Float256Array,
        ArrayBuffer,
        TypedArray,
        ByteArray,
        Uint8ClampedArray
    }

    [Flags]
    public enum ActiveXTObjectType : byte
    {
        none = 0,
        XMLHttp = 1,
        XMLDOM = 2,
        ShockwaveFlash = 10,
        Unkown = 255
    }


    [Flags]
    public enum CHtmlParseModeType : byte
    {
        None = 0,
        TagName = 1,
        TagAttribute = 2,
        InnerText = 5,
        Comment = 10
    };

    public enum CHtmlCanvasContextGlobalCompositionType : byte
    {
        source_over,
        source_atop,
        source_in,
        source_out,
        destination_over,
        destination_atop,
        destination_in,
        destination_out,
        lighter,
        copy,
        xor,
    }

    public enum CHtmlElementType : ushort
    {
        _UNDEFINED = 0,
        HTML = 1,
        HEAD = 2,
        META = 3,
        LINK = 4,
        TITLE = 5,
        BASE = 6,
        STYLE = 7,
        NOSCRIPT = 8,
        SCRIPT = 9,
        BODY = 10,
        DIV = 11,
        SINAME = 12,
        HTMLCOMMENT = 13,
        DOCTYPE = 14,
        _DOCUMENT_FRAGMENT = 15,
        TABLE = 40,
        TBODY = 41,
        THEAD = 42,
        TFOOT = 43,
        CAPTION = 44,
        TR = 45,
        TD = 46,
        TH = 47,
        COLGROUP = 48,
        ROWGROUP = 49,
        COL = 50,
        ROW = 51,
        HEADER = 52,
        FOOTER = 53,
        SECTION = 54,
        P = 60,
        ASIDE = 61,
        UL = 70,
        OL = 72,
        MENU = 73,
        MENUITEM = 74,
        DIR = 75,
        LI = 79,
        DT = 80,
        DD = 81,
        DL = 82,
        MARQUEE = 83,
        HN = 84,
        FORM = 100,
        CENTER = 101,
        FIELDSET = 102,
        NOFRAME = 103,
        FRAME = 104,
        IFRAME = 105,
        OBJECT = 106,
        EMBED = 107,
        APPLET = 108,
        PARAM = 109,
        MAP = 110,
        AREA = 111,
        FRAMESET = 112,
        BLOCKQUOTE = 113,
        NAV = 115,
        SECTIONS = 116,
        CONTENT = 117,
        TEXTAREA = 118,
        NOFRAMES = 119,
        HR = 120,
        MAIN = 121,
        H1 = 201,
        H2 = 202,
        H3 = 203,
        H4 = 204,
        H5 = 205,
        H6 = 206,
        H7 = 207,
        VIDEO = 300,
        AUDIO = 301,
        TRACK = 302,
        SOURCE = 303,

        FIGURE = 310,



        NOEMBED = 311,
        LAYER = 312,
        NOLAYER = 313,
        OPTGROUP = 314,
        BASEFONT = 315,
        HGROUP = 316,
        POST = 317,
        SUMMARY = 401,
        PROGRESS = 402,
        OUTPUT = 403,
        METER = 404,
        FIGCAPTION = 407,
        DETAILS = 408,
        DATALIST = 409,
        DATA = 410,
        ILAYER = 411,
        BDI = 412,
        NOINDEX = 413,
        ASTERISK = 440,

        ARTICLE = 451, // ARTICLE Tag is block not inline
        SYSTEM_REGION = 452,



        TEMPLATE = 499, // Script Template Tag. HTML5
        XML = 500,
        XHTML = 501,
        // ---------------------------
        // SVG RELATED TAGS
        // ---------------------------
        SVG,
        CANVAS = 601,
        PATH,
        G,
        M,
        STOP,
        CIRCLE,
        POLYGON,
        LINEARGRADIENT,
        DEFS,
        COPY,
        RECT,
        TSPAN,
        SYMBOL,
        SWITCH,
        TREF,
        USE,
        DESC,
        RADIALGRADIENT,
        FILTER,
        FETURBULENCE,
        FECOLORMATRIX,
        FECOMPNENTTRANSFER,
        FEFUNCA,
        FEFUNCG,
        FEFUNCB,
        FEFUNCR,
        ANIMATEMOTION,
        MASK,
        /// <summary>
        /// Renders raster images (PNG, JPEG) or files whose MIME type is image/svg+xml.
        /// </summary>
        IMAGE,
        /// <summary>
        /// SVG Line
        /// </summary>
        LINE,
        /// <summary>
        /// SVG METADATA
        /// </summary>
        METADATA,

        POLYLINE,
        ANIMATE,
        ELLIPSE,
        CLIPPATH,
        GLYPH,
        TEXTPATH,
        MISSING_GLYPH,
        FONT_FACE,
        PATTERN,
        FEGAUSSIANBLUR,
        FESPECULARLIGHTING,
        FEDISTANTLIGHT,
        FECOMPOSITE,
        FEBLEND,



        //SPECIAL TAGS MSDN ETC
        G_PLUSONE,
        G_PLUS,
        MSHELP_ATTR = 950,
        MSHELP_LINK = 951,
        MSHELP_KTABLE = 951,
        FB_COMMENTS = 952,
        FB_COMMENTS_COUNT = 953,
        FB_LIKE = 954,
        FB_LIKE_BOX = 955,
        FB_RECOMMENDATIONS = 956,
        MODERNIZR = 957,
        XYZ = 958, // MODERNIZER Related Tag.

        ADV_HS = 970,
        ADV_OV = 971,
        BANNER = 975,


        LINKTEXT = 980,
        TWITTER = 990, // TWITTER
        BOOTSTRAP = 991,
        HEAD_DELETED = 997,
        BODY_DELETED = 998,
        UNKNOWN = 999,


        // ALL INLINE STYLE will be over 1000
        A = 1000,
        B = 1001,
        I = 1002,
        S = 1003,
        O = 1004,
        U = 1005,
        Q = 1006,
        INPUT = 1010,
        SPAN = 1011,
        SELECT = 1012,
        BUTTON = 1013,
        PICTURE = 1014,
        ABBR = 1015,
        FONT = 1016,
        STRONG = 1017,
        SMALL = 1018,
        BIG = 1019,
        OPTION = 1021,
        CITE = 1022,
        VAR = 1023,
        EM = 1024,
        ADDRESS = 1025,
        ACRONYM = 1026,
        CODE = 1027,
        LABEL = 1028,
        PLANTEXT = 1029,
        KBD = 1030,
        DFN = 1031,
        IMG = 1032,
        CUSTOM = 1033,
        DEL = 1034,
        SELECTION = 1035,
        INS = 1036,
        MARK = 1037,
        STRIKE = 1039,
        COMMENT = 1040,
        SUP = 1041,
        SUB = 1042,

        PRE = 1050,
        TT = 1051,
        SAMP = 1052,
        XMP = 1053,
        SEL = 1054,
        RUBY = 1055,
        RP = 1056,
        RT = 1057,
        RB = 1058,
        LEGEND = 1059,
        SPACER = 1060,
        TIME = 1065,
        CUFON = 1070,
        CUFONTEXT = 1071,
        O_P = 1072, // O:P 
        NEWSELEMENT = 1073, // Google News Feed
        SHADOW_ROOT = 1074, // Shadow Root
        WBR = 9997,
        NOBR = 9998, // Render text as no wrap
        BR = 9999,
        TEXT = 10000, // SVG TEXT
        _ITEXT = 10001, // HTML Text, CreateTextNode
        _IDRAW = 10002,
        _ELEMENT_BEFORE = 15000,
        _ELEMENT_AFTER = 15001,
        _ELEMENT_PROTOTYPE = 60000,
        _HTMLELEMENT_PROTOTYPE = 60001
    }






    public enum fffCHtmlElementType : ushort
    {
        _UNDEFINED = 0,
        HTML = 1,
        HEAD = 2,
        META = 3,
        LINK = 4,
        TITLE = 5,
        BASE = 6,
        STYLE = 7,
        NOSCRIPT = 8,
        SCRIPT = 9,
        BODY = 10,
        DIV = 11,
        SINAME = 12,
        HTMLCOMMENT = 13,
        DOCTYPE = 14,
        _DOCUMENT_FRAGMENT = 15,
        TABLE = 40,
        TBODY = 41,
        THEAD = 42,
        TFOOT = 43,
        CAPTION = 44,
        TR = 45,
        TD = 46,
        TH = 47,
        COLGROUP = 48,
        ROWGROUP = 49,
        COL = 50,
        ROW = 51,
        HEADER = 52,
        FOOTER = 53,
        SECTION = 54,
        P = 60,
        ASIDE = 61,
        UL = 70,
        OL = 72,
        MENU = 73,
        MENUITEM = 74,
        DIR = 75,
        LI = 79,
        DT = 80,
        DD = 81,
        DL = 82,
        MARQUEE = 83,
        HN = 84,
        FORM = 100,
        CENTER = 101,
        FIELDSET = 102,
        NOFRAME = 103,
        FRAME = 104,
        IFRAME = 105,
        OBJECT = 106,
        EMBED = 107,
        APPLET = 108,
        PARAM = 109,
        MAP = 110,
        AREA = 111,
        FRAMESET = 112,
        BLOCKQUOTE = 113,
        NAV = 115,
        SECTIONS = 116,
        CONTENT = 117,
        TEXTAREA = 118,
        NOFRAMES = 119,
        HR = 120,
        MAIN = 121,
        H1 = 201,
        H2 = 202,
        H3 = 203,
        H4 = 204,
        H5 = 205,
        H6 = 206,
        H7 = 207,
        VIDEO = 300,
        AUDIO = 301,
        TRACK = 302,
        SOURCE = 303,

        FIGURE = 310,



        NOEMBED = 311,
        LAYER = 312,
        NOLAYER = 313,
        OPTGROUP = 314,
        BASEFONT = 315,
        HGROUP = 316,
        POST = 317,
        SUMMARY = 401,
        PROGRESS = 402,
        OUTPUT = 403,
        METER = 404,
        FIGCAPTION = 407,
        DETAILS = 408,
        DATALIST = 409,
        DATA = 410,
        ILAYER = 411,
        BDI = 412,
        NOINDEX = 413,
        ASTERISK = 440,

        ARTICLE = 451, // ARTICLE Tag is block not inline
        SYSTEM_REGION = 452,




        TEMPLATE = 499, // Script Template Tag. HTML5
        XML = 500,
        XHTML = 501,
        // ---------------------------
        // SVG RELATED TAGS
        // ---------------------------
        SVG,
        CANVAS = 601,
        PATH,
        G,
        M,
        STOP,
        CIRCLE,
        POLYGON,
        LINEARGRADIENT,
        DEFS,
        COPY,
        RECT,
        TSPAN,
        SYMBOL,
        SWITCH,
        TREF,
        USE,
        DESC,
        RADIALGRADIENT,
        FILTER,
        FETURBULENCE,
        FECOLORMATRIX,
        FECOMPNENTTRANSFER,
        FEFUNCA,
        FEFUNCG,
        FEFUNCB,
        FEFUNCR,
        ANIMATEMOTION,
        MASK,
        /// <summary>
        /// Renders raster images (PNG, JPEG) or files whose MIME type is image/svg+xml.
        /// </summary>
        IMAGE,
        /// <summary>
        /// SVG Line
        /// </summary>
        LINE,
        /// <summary>
        /// SVG METADATA
        /// </summary>
        METADATA,

        POLYLINE,
        ANIMATE,
        ELLIPSE,
        CLIPPATH,
        GLYPH,
        TEXTPATH,
        MISSING_GLYPH,
        FONT_FACE,
        PATTERN,
        FEGAUSSIANBLUR,
        FESPECULARLIGHTING,
        FEDISTANTLIGHT,
        FECOMPOSITE,
        FEBLEND,



        //SPECIAL TAGS MSDN ETC
        G_PLUSONE,
        G_PLUS,
        MSHELP_ATTR = 950,
        MSHELP_LINK = 951,
        MSHELP_KTABLE = 951,
        FB_COMMENTS = 952,
        FB_COMMENTS_COUNT = 953,
        FB_LIKE = 954,
        FB_LIKE_BOX = 955,
        FB_RECOMMENDATIONS = 956,
        MODERNIZR = 957,
        XYZ = 958, // MODERNIZER Related Tag.

        ADV_HS = 970,
        ADV_OV = 971,
        BANNER = 975,


        LINKTEXT = 980,
        TWITTER = 990, // TWITTER
        BOOTSTRAP = 991,
        HEAD_DELETED = 997,
        BODY_DELETED = 998,
        UNKNOWN = 999,


        // ALL INLINE STYLE will be over 1000
        A = 1000,
        B = 1001,
        I = 1002,
        S = 1003,
        O = 1004,
        U = 1005,
        Q = 1006,
        INPUT = 1010,
        SPAN = 1011,
        SELECT = 1012,
        BUTTON = 1013,
        PICTURE = 1014,
        ABBR = 1015,
        FONT = 1016,
        STRONG = 1017,
        SMALL = 1018,
        BIG = 1019,
        OPTION = 1021,
        CITE = 1022,
        VAR = 1023,
        EM = 1024,
        ADDRESS = 1025,
        ACRONYM = 1026,
        CODE = 1027,
        LABEL = 1028,
        PLANTEXT = 1029,
        KBD = 1030,
        DFN = 1031,
        IMG = 1032,
        CUSTOM = 1033,
        DEL = 1034,
        SELECTION = 1035,
        INS = 1036,
        MARK = 1037,
        STRIKE = 1039,
        COMMENT = 1040,
        SUP = 1041,
        SUB = 1042,

        PRE = 1050,
        TT = 1051,
        SAMP = 1052,
        XMP = 1053,
        SEL = 1054,
        RUBY = 1055,
        RP = 1056,
        RT = 1057,
        RB = 1058,
        LEGEND = 1059,
        SPACER = 1060,
        TIME = 1065,
        CUFON = 1070,
        CUFONTEXT = 1071,
        O_P = 1072, // O:P 
        NEWSELEMENT = 1073, // Google News Feed
        WBR = 9997,
        NOBR = 9998, // Render text as no wrap
        BR = 9999,
        TEXT = 10000, // SVG TEXT
        _ITEXT = 10001, // HTML Text, CreateTextNode
        _IDRAW = 10002,
        _ELEMENT_BEFORE = 15000,
        _ELEMENT_AFTER = 15001,
        _ELEMENT_PROTOTYPE = 60000,
        _HTMLELEMENT_PROTOTYPE = 60001
    }

    public enum CHtmlDOMNodeExpandLevelType : byte
    {
        None = 0,
        RootOnly = 1,
        SubNodes = 2,
        ExpandAll = 3
    }


    public enum CHtmlTagClosedReasonType : byte
    {
        Open = 0,
        EndSimple = 1,
        EndDeep = 2,
        EndBackward = 3,
        EndSimpleBack = 4,
        Direct = 5,
        ForceCleanup = 6,
        ParentCleanup = 7,
        ContextCleanup = 8,
        SameLevelCleanUp = 9,
        FinalCleanUp = 10,
        BodyCleanUp = 20
    };

    public enum CHtmlNodeType : byte
    {
        ELEMENT_NODE = 1,
        ATTRIBUTE_NODE = 2,
        TEXT_NODE = 3,
        CDATA_SECTION_NODE = 4,
        ENTITY_REFERENCE_NODE = 5,
        ENTITY_NODE = 6,
        PROCESSING_INSTRUCTION_NODE = 7,
        COMMENT_NODE = 8,
        DOCUMENT_NODE = 9,
        DOCUMENT_TYPE_NODE = 10,
        DOCUMENT_FRAGMENT_NODE = 11,
        NOTATION_NODE = 12
    }


    public enum CHtmlBrowserControlType : byte
    {
        None = 0,
        WebBrowswer = 1,
        DirectSHDocVw = 2,
        SimpleHTMLRenderer = 10,
        CHtmlDocumentRenderer = 11
    };

    public enum CHtmlWebStorageType : byte
    {
        localStorage = 0,
        sessionStorage = 1
    }


    public enum CHtmlUrlSourceType : byte
    {
        Unknown = 0,
        BackgroundImage_of_DefaultStyle = 1,
        BackgroundImage_of_HoverStyle = 2,
        BackgroundImage_of_ActiveStyle = 3,
        ListStyleImage_of_DefaultStyle = 5,
        ListStyleImage_of_HoverStyle = 6,
        ListStyleImage_of_ActiveStyle = 7,
        Src = 99
    }


    public enum CSSVisibilityType : byte
    {
        UNKNOWN = 0,
        hidden = 1,
        visible = 2,
        collapse = 3,
    }


    public enum CSSDisplayType : byte
    {
        /// <summary>
        /// Elements and child won't be render
        /// </summary>
        None = 0,
        /// <summary>
        /// Element is a block box
        /// </summary>
        Block = 1,
        /// <summary>
        /// Element is one or more inline boxes
        /// </summary>
        Inline = 2,
        /// <summary>
        /// Element is displayed as list-item and it ___hasInner a buller in front of it
        /// </summary>
        ListItem = 3,

        /// <summary>
        /// Element is displayed as list-item and ___hasInner a marker in front of it
        /// </summary>
        Marker = 4,
        /// <summary>
        /// 指定要素の後にくるブロックレベル要素が、回り込み（float）または絶対配置されておらず、指定要素の内容の幅が、後にくるブロックレベル要素の左マージンの幅以下で1行で収まる場合には、その左マージン内にインラインレベルとして表示されます。それ以外の場合には、ブロックレベルで表示されます。
        /// </summary>
        Compact = 5,
        /// <summary>
        /// 	指定要素の後にくるブロックレベル要素が、回り込み（float）または絶対配置されていない場合には、その先頭にインラインレベルとして表示されます。それ以外の場合には、ブロックレベルで表示されます。
        /// </summary>
        RunIn = 6,
        /// <summary>
        /// Element is placed as linline element ( on the same line as adjacenet content), but it behaves as a block element
        /// </summary>
        InlineBlock = 7,
        /// <summary>
        /// Element is displayed as block-level flex container box. (No Clearfix required)
        /// </summary>
        Box = 8,
        /// <summary>
        /// Element is displayed as block-level flex container box (No Clearfix required)
        /// </summary>
        Flex = 9,
        /// Element is displayed as block-level flex container box (No Clearfix required)
        /// </summary>
        FlexBox = 10,
        /// <summary>
        ///
        /// </summary>
        InlineBox = 11,
        /// <summary>
        /// Inline Stack
        /// </summary>
        InlineStack = 13,
        /// <summary>
        /// Element is displayed as inline-level table
        /// </summary>
        InlineTable = 20,
        /// <summary>
        /// CSS 3.0 Grid Support
        /// </summary>
        Grid = 30,
        InlineGrid = 31,
        /// <summary>
        /// Element is displayed as Table
        /// </summary>
        Table = 50,
        TableCaption = 51,
        TableRow = 52,
        TableCell = 53,
        TableColumn = 53,
        TableRowGroup = 54,
        TableColumnGroup = 55,
        TableHeaderGroup = 56,
        TableFooterGroup = 57,

        Ruby = 60,
        RubyBase = 61,
        RubyText = 62,
        RubyBaseGroup = 63,
        RubyTextGroup = 64,

        Inherit,
        UNKNOWN
    }


    public enum CSSImageRepeatType : byte
    {
        unkown = 0,
        repeat = 1,
        repeatX = 2,
        repeatY = 3,
        norepeat = 4
    }

    public enum CSSMultipleImageDataType : byte
    {
        Unknown = 0,
        Image = 1,
        Gradation = 2
    }

    public enum CHtmlStyleElementPseudoClassValueType : sbyte
    {
        NotSelected = -100,
        Num_0 = 0,
        Num_1 = 1,
        Num_2 = 2,
        Num_3 = 3,
        Num_4 = 4,
        Num_5 = 5,
        Num_6 = 6,
        Num_7 = 7,
        Num_8 = 8,
        Num_9 = 9,
        Num_10 = 10,
        Num_11 = 11,
        Num_12 = 12,
        Num_13 = 13,
        Num_14 = 14,
        Num_15 = 15,
        Num_16 = 16,
        Num_17 = 17,
        Num_18 = 18,
        Num_19 = 19,
        Num_20 = 20,
        Num_21 = 21,
        Num_22 = 22,
        Num_23 = 23,
        Num_24 = 24,
        Num_25 = 25,
        Num_26 = 26,
        Num_27 = 27,
        Num_28 = 28,
        Num_29 = 29,
        Num_30 = 30,
        Num_31 = 31,
        Num_32 = 32,
        Num_33 = 33,
        Num_34 = 34,
        Num_35 = 35,
        Num_36 = 36,
        Num_Over36 = 37,
        Num_Odd,
        Num_Even,
        Num_Equation,
        TagType,
        Matches,
        Not,
        Other
    }

    /*
    
    public enum FrameType
    {
        Normal = 0,
        IFrame = 1,
        Popup = 2
    }
    */

    public enum CHtmlElementQueryType : byte
    {
        All,
        GetElementById,
        GetElementsByClassName,
        GetElementsByTagName,
        GetElementsByTagNameNS,
        GetElementsByName,
        All_Including_IText_Before_After
    }
    [Flags]
    public enum CanvasContextModeType : byte
    {
        None,
        Canvas2D,
        SVG,
        WebGL,
        AudioContext,
        Canvas2DPrototype,
        WebGLPrototype,
        CanvasAudioContextPrototype,
        OtherType
    }
    public enum CanvasPathInstructionType : byte
    {
        /// <summary>
        /// Unknown Commmand
        /// </summary>
        unknown,
        /// <summary>
        /// Draw an elliptical ar from the current
        /// </summary>
        A,
        /// <summary>
        /// pont to (x,y). The points are on an ellipse with x-radius rx and y-radius ry. 
        /// </summary>
        a,
        /// <summary>
        /// Move to given coordinates
        /// </summary>
        M,
        /// <summary>
        /// Move to given coordinates
        /// </summary>
        m,
        /// <summary>
        /// Draw a line(s) to x,y 
        /// </summary>
        L, // 
        /// <summary>
        /// Draw a line(s) to x,y 
        /// </summary>
        l,
        /// <summary>
        /// Close the path
        /// </summary>
        Z,
        /// <summary>
        /// Draw horizontal line to given coodinates
        /// </summary>
        H,
        /// <summary>
        /// Draw horizontal line to given coodinates
        /// </summary>
        h,
        /// <summary>
        /// Draw Vertical line to given coodinates
        /// </summary>
        V,
        /// <summary>
        /// Draw Vertical line to given coodinates
        /// </summary>
        v,
        /// <summary>
        /// Absolute. Draws a quadratic Bézier curve from the current point to (x,y) using (x1,y1) as the control point. Q (uppercase) indicates that absolute coordinates will follow; q (lowercase) indicates that relative coordinates will follow. Multiple sets of coordinates may be specified to draw a polybézier. At the end of the command, the new current point becomes the final (x,y) coordinate pair used in the polybézier.
        /// </summary>
        Q,
        /// <summary>
        /// Relative. Draws a quadratic Bézier curve from the current point to (x,y) using (x1,y1) as the control point. Q (uppercase) indicates that absolute coordinates will follow; q (lowercase) indicates that relative coordinates will follow. Multiple sets of coordinates may be specified to draw a polybézier. At the end of the command, the new current point becomes the final (x,y) coordinate pair used in the polybézier.
        /// </summary>
        q,
        /// <summary>
        /// Absolute. Draws a quadratic Bézier curve from the current point to (x,y). The control point is assumed to be the reflection of the control point on the previous command relative to the current point. (If there is no previous command or if the previous command was not a Q, q, T or t, assume the control point is coincident with the current point.) T (uppercase) indicates that absolute coordinates will follow; t (lowercase) indicates that relative coordinates will follow. At the end of the command, the new current point becomes the final (x,y) coordinate pair used in the polybézier.
        /// </summary>
        T,
        /// <summary>
        /// Relative. Draws a quadratic Bézier curve from the current point to (x,y). The control point is assumed to be the reflection of the control point on the previous command relative to the current point. (If there is no previous command or if the previous command was not a Q, q, T or t, assume the control point is coincident with the current point.) T (uppercase) indicates that absolute coordinates will follow; t (lowercase) indicates that relative coordinates will follow. At the end of the command, the new current point becomes the final (x,y) coordinate pair used in the polybézier.
        /// </summary>
        t,
        /// <summary>
        /// Draws a cubic Bézier curve from the current point to (x,y) using (x1,y1) as the control point at the beginning of the curve and (x2,y2) as the control point at the end of the curve. C (uppercase) indicates that absolute coordinates will follow; c (lowercase) indicates that relative coordinates will follow. Multiple sets of coordinates may be specified to draw a polybézier. At the end of the command, the new current point becomes the final (x,y) coordinate pair used in the polybézier.
        /// </summary>
        C,
        /// <summary>
        /// Draws a cubic Bézier curve from the current point to (x,y) using (x1,y1) as the control point at the beginning of the curve and (x2,y2) as the control point at the end of the curve. C (uppercase) indicates that absolute coordinates will follow; c (lowercase) indicates that relative coordinates will follow. Multiple sets of coordinates may be specified to draw a polybézier. At the end of the command, the new current point becomes the final (x,y) coordinate pair used in the polybézier.
        /// </summary>
        c,
        /// <summary>
        /// Draws a cubic Bézier curve from the current point to (x,y). The first control point is assumed to be the reflection of the second control point on the previous command relative to the current point. (If there is no previous command or if the previous command was not an C, c, S or s, assume the first control point is coincident with the current point.) (x2,y2) is the second control point (i.e., the control point at the end of the curve). S (uppercase) indicates that absolute coordinates will follow; s (lowercase) indicates that relative coordinates will follow. Multiple sets of coordinates may be specified to draw a polybézier. At the end of the command, the new current point becomes the final (x,y) coordinate pair used in the polybézier.
        /// </summary>
        S,
        /// <summary>
        /// Draws a cubic Bézier curve from the current point to (x,y). The first control point is assumed to be the reflection of the second control point on the previous command relative to the current point. (If there is no previous command or if the previous command was not an C, c, S or s, assume the first control point is coincident with the current point.) (x2,y2) is the second control point (i.e., the control point at the end of the curve). S (uppercase) indicates that absolute coordinates will follow; s (lowercase) indicates that relative coordinates will follow. Multiple sets of coordinates may be specified to draw a polybézier. At the end of the command, the new current point becomes the final (x,y) coordinate pair used in the polybézier.
        /// </summary>
        s,
    }

    [Flags]
    public enum CanvasExtentionObjectType : byte
    {
        UNKNOWN = 0,
        LinerGradient = 1,
        RadialGradient = 2,

        MeasureTextResult = 10,
        ImagePattern = 30,

        GetImageData = 100,
        CreateImageData = 101,
        CanvasPattern = 102,
    }

    public enum MediaQueryOwnerElementType : byte
    {
        UNKNOWN = 0,
        LinkElement = 1,
        StyleElement = 2,
        CSSInlineMedia = 3
    }




    public enum CHtmlQuerySelectorType : byte
    {
        unknown,
        element_querySelector,
        element_querySelectorAll,
        document_querySelector,
        document_querySelectorAll,
    }
    /// <summary>
    /// CHtmlStyleElementKeyClassComparerer 
    /// </summary>
    public class CHtmlElementZIndexComparer : System.Collections.Generic.IComparer<CHtmlElement>
    {

        #region IComparer 
        public int Compare(CHtmlElement elemX, CHtmlElement elemY)
        {
            if (elemX == null && elemY == null)
            {
                return 0;
            }
            if (elemX == null || elemX.___style == null)
            {
                return -1;
            }
            if (elemY == null || elemY.___style == null)
            {
                return 1;
            }
            return elemX.___style.___zIndexValue.CompareTo(elemY.___style.___zIndexValue);
        }
        #endregion
    }
    /// <summary>
    /// commonHTML 
    /// </summary>
    public static class commonHTML
    {
        internal static bool IsTextRendererDrawTextMethodExists = true;

        /// <summary>
        /// UseCSSRecursion : true  Use Recursion to seach upper node to obtain stylesheet
        ///                 : false Use WhileLoop to search uppernode stylesheet
        /// </summary>

        public static bool UseCSSRecursion = false;
        /// <summary>
        /// UsePrefetchThread  : true  Another Thread Will Parse Tag and Enqueue if possible
        ///                 : false Do not use TagPrefetch
        /// </summary>

        public static bool UsePrefetchThread = true;


        public static bool EnableScriptDownloadOnPrefetchThread = true;

        public static int PREFETCH_SCRIPT_SKIP_COUNT = 3;


        public static bool UseFontInstanceCache = true;


        /// <summary>
        /// Chrome and FireFox allows to start timer during parse before complete (IE does not)
        /// </summary>

        public static bool AllowTimerStartupBeforeComplete = true;

        public static int TIMER_INTERVAL_BEFORE_COMPLETE = 1500;

        public static int TIMER_STARTUP_BEFORE_COMPLETE = 1000;

        /// <summary>
        /// How Prebuild DOM ThreasHold
        /// -1 : Disable
        /// </summary>
        //public static int HTTP_Synchronous_Download_Threshold = -1; // 160K Default

        /// <summary>
        /// Rather than use StringBuilder(), StringBuilder(60) ___hasInner better performance.
        /// </summary>
        public const int StringBuilder_BUFFER_Size_For_CSS_Tag = 60;

        public static string[] TagNamesPrefetch = new string[] { "IMG", "SCRIPT", "LINK", "!--" };

        public const char CharZenkakuSpace = '\u3000';


        internal readonly static System.Collections.Generic.Dictionary<char, byte> CharsFirstCharacterToBePrefechDictionary = createTagNamesFirstCharacterArray(TagNamesPrefetch);
        /// <summary>
        /// UseCSSRecursion : true  Use Recursion to seach upper node to obtain stylesheet
        ///                 : false Use WhileLoop to search uppernode stylesheet
        /// </summary>

        public static bool UseStringBuilderIndexOf = false;


        public static bool convertBitmapOnCanvas = true;

        /// <summary>
        /// JPEG Image requires may headers to perform accurate image header.
        /// usually 8k-32k (specially large jpeg image).
        /// if buffer data is less than this unicus will wait to wait more data.
        /// </summary>
        public static float JPEG_IMAGE_HEADE_ANLYSIS_MINIMUM_RATIO = 0.8F;
        /// <summary>
        /// How many parent will be lookuped up for query selector search.
        /// </summary>

        public static int MAX_QUERYSELECTOR_PARENT_SEARCH_LIMIT = 100;

        public static char[] SVG_POINTS_SEPARATOR_CHARS = new char[] { ',', '\r', '\t', '\n', ' ' };

        /// <summary>
        /// Flag document.getElementsByTagname("*") should lookup child nodes, not allelements list
        /// </summary>
        public static bool DOCUMENT_GETELEMENTSBYTAGNAME_WILDCARD_LOOKUP_CHILDNODES = true;

        /// <summary>
        /// document.getElementsByTagname("tag") should lookup child nodes, not allelements list
        /// </summary>
        public static bool DOCUMENT_GETLEMENTSBYTAGNAME_WITH_TAG_SHOULD_SEARCH_FROM_DOCUMENT_ELEMMENTS = true;


        internal static System.Reflection.MethodInfo StringIndexOfMethod = null;

        internal static System.Type StringComparisionType = null;

        internal static double Text_Indent_Lowest_Value_Limit = -100;

        //internal static DynamicMethodDelegate StringIndexOfOrdinalCaseInsensitiveMethod = null;

        internal static string BrowserUserAgentString = null;
        internal static NTextCat.RankedLanguageIdentifier? _NTextCat_RankedLanguageIdentitifer = ____loadNTextCatProfile();

        internal static NTextCat.RankedLanguageIdentifier ____loadNTextCatProfile()
        {
#if WINDOWS
            return null;
#endif
            string resName = null;
            try
            {
                var factory = new NTextCat.RankedLanguageIdentifierFactory();

                // Find embedded resource name (assembly qualified) and load it safely
                var asm = typeof(commonHTML).Assembly;


                foreach (var n in asm.GetManifestResourceNames())
                {

                    if (n.IndexOf("Core14.profile.xml") > -1)
                    {

                        using (var stream = asm.GetManifestResourceStream(n))
                        {
                            if (stream == null) return null;
                            if (commonLog.LoggingEnabled)
                            {
                                commonLog.LogEntry("NTextCat Profile Resource Name : " + n);
                            }

                            return factory.Load(stream);
                        }
                    }
                }


                string[] manifestResourceNames = asm.GetManifestResourceNames();


                using (var stream = asm.GetManifestResourceStream(resName))
                {
                    if (stream == null) return null;
                    return factory.Load(stream);
                }
            }
            catch
            {
                if (_NTextCat_RankedLanguageIdentitifer != null)
                {
                    return _NTextCat_RankedLanguageIdentitifer;
                }
                return null;
            }
        }



        /// <summary>
        /// How many bytes ___isMemoryStringContainsMetaCharset() should lookup.
        /// </summary>
        internal static int CHARSET_LOOKUP_BYTES_LIMIT = 8000;
        /// <summary>
        /// if child elemnt list is deeper than this, it will perform Deep CSS Search
        /// </summary>
        internal static ushort DEEP_CSS_SEARCH_CHILD_MINIMUM_DEPTH = 2;

        /// <summary>
        /// Highest Value of CHtmlElementType
        /// </summary>
        internal static readonly int TAGTYPE_ITEM_MAX = GetTagTypeHighestValue() + 1;

        public static string httpDecompressionString = "auto";

        /// <summary>
        /// CSS FontSpec Mimimum Size 8 is minmum for Opera and FireFox
        /// </summary>
        public const float CSS_FONT_Size_Shoud_Be_GreaterThan = 8F;

        /// <summary>
        /// If createElement("script") is created, if ownerDocument is normal document
        /// the script will be download and executed in sync
        /// default : true
        /// </summary>
        public static bool isDynamicHtmlScriptElementWillBeExecutedSyncForNonDeferAttribute = true;
        public static CLRType runtimeCLRType = CLRType.UNKNOWN;
        public enum HttpAsyncDeferMode
        {
            None = 0,
            Async = 1,
            Defer = 2,

        }
        public static bool ___isMicrosoftCLR = ___getMicrosoftCLR();
        internal static bool ___getMicrosoftCLR()
        {
            if (runtimeCLRType == CLRType.UNKNOWN)
            {
                if (Type.GetType("Mono.Runtime") == null)
                {
                    runtimeCLRType = CLRType.MicrosoftCLR;
                    return true;
                }
                else
                {
                    runtimeCLRType = CLRType.MonoCLR;
                    return false;
                }
            }
            else
            {
                if (runtimeCLRType == CLRType.MicrosoftCLR)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static int GetTagTypeHighestValue()
        {
            CHtmlElementType[] values = (CHtmlElementType[])Enum.GetValues(typeof(CHtmlElementType));
            CHtmlElementType highestValue = CHtmlElementType.UNKNOWN;
            int valuesLen = values.Length;
            for (int index = 0; index < valuesLen; ++index)
            {
                if (values[index].CompareTo(highestValue) > 0)
                {
                    highestValue = values[index];
                }
            }

            return (int)highestValue;
        }

        internal static readonly string HTTP_Request_Common_Accept_Header = "text/html,application/xhtml+xml,application/xml;q=0.9, */*;q=0.80";
        internal static readonly string HTTP_Request_ALL_Accept_Header = "*/*";
        internal static readonly int StylesheetMaximumWaitMilliseconds = 30000;

        internal static object StringComparisionOrdinalIgnoreCaseOption = null;


        internal static readonly double CSSNeiborHoodCopyLimit = 281474976710656;


        internal static readonly bool CompileAsyncScriptAtDoucmentLoaded = true;

        internal static int MAXIMUM_MANUAL_PARSE_DOCUMENT_WAIT = 10000;

        internal static int MAX_ELEMENT_LOAD_CHECK_TRIAL_COUNT = 3000;

        public static string WebStrageContentType = "application/webstore";


        internal static readonly string CookieSuffix = ".cookie";

        internal static readonly string CookieContentType = "text/cookie";

        public static System.Drawing.Color HTMLEmptyColor = Color.Empty;
        //public static System.Drawing.Color HTMLEmptyColor2 = Color.Empty;

        internal static readonly char[] EndChars = new char[] { '/', ';', '=', '\"', '\'', ',', '.', '\\', ' ', '>', '<', '\'', ')', '(', '\r', '\n', '\t' };


        public static readonly string[] TagsForSentense = new string[] { "A", "P", "B", "U", "I", "BR", "NOBR", "SUP", "SMALL", "BIG", "INS", "ADDRESS", "STRONG", "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "EM", "SPAN", "S" };

        //public static readonly string[] TagsDivSinameCenter = new string[]{"DIV", "SINAME","CENTER"};	
        //public static readonly string[] TagsBodyDivSpanSpanSinameCenter = new string[]{"BODY", "DIV","SPAN", "SINAME","CENTER"};


        public static readonly string[] TagsForLayout = new string[] { "DIV", "SPAN", "TABLE", "TBODY", "TR", "TD", "TH", "DL", "OL", "UL", "FORM", "BODY", "FRAMESET", "NOFRAME", "SINAME", "FIELDSET", "LEGEND", "CENTER", "CONTENT", "SECTIONS", "CAPTION", "THEAD", "TFOOT", "NOSCRIPT", "NOBR", "SINAME" };

        public static System.Collections.Generic.Dictionary<string, string> TagsForLayoutSortedList = CreateDictionaryListFromStringArray(TagsForLayout);

        public static readonly string[] TagsForLayoutV2 = new string[] { "DIV", "TABLE", "TBODY", "TR", "TD", "TH", "DL", "OL", "UL", "FORM", "BODY", "FRAMESET", "NOFRAME", "SINAME", "FIELDSET", "LEGEND", "HTML", "BASEFONT", "CENTER", "CONTENT", "SECTIONS", "SELECT", "CAPTION", "THEAD", "TFOOT", "NOSCRIPT", "NOBR", "IFRAME", "CODE", "PRE" };


        public static readonly string[] TagsForDisplayLayoutBoundsV2 = new string[] { "DIV", "TABLE", "FORM", "BODY", "FRAMESET", "FIELDSET", "LEGEND", "CENTER", "CONTENT", "IFRAME", "CODE", "PRE" };

        //public static readonly string[] TagsWithFixedHieght = new string[]{"SELECT", "HR", "IFRAME", "INPUT", "BUTTON", "TEXTAREA"};

        public static readonly CHtmlElementType[] TagTypesWithFixedHeight = new CHtmlElementType[] { CHtmlElementType.SELECT, CHtmlElementType.HR, CHtmlElementType.IFRAME, CHtmlElementType.INPUT, CHtmlElementType.BUTTON, CHtmlElementType.TEXTAREA };

        #region rhino Related Functions and params
        public static object rhinoForLoopEnumratorFunction = null;
        public static int rhinoOptimizationLevel = -1;
        public static bool isTemplateScriptBlock(string sType)
        {
            switch (sType)
            {
                case "javascript":
                case "text/javascript":
                case "text/vbscript":
                    return false;
                case "text/x-jquery-tmpl":
                case "text/template":
                case "text/html":
                case "script/template":
                case "template":
                case "xml":
                case "prefetch":
                case "dsa-prefetch":
                case "dsa_prefetch":
                case "dsaprefetch":
                case "psa-prefetch":
                case "psa_preftech":
                    return true;
                default:
                    if (sType.IndexOf("json", StringComparison.Ordinal) > -1)
                    {
                        return true;
                    }
                    else if (sType.IndexOf("template", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        return true;
                    }
                    return false;
            }
        }
        public static void ___precheckScriptComment(ref System.Text.StringBuilder sbScript, bool StrongMode)
        {
            int HeaderRemovePattern = -1;
            try
            {
                for (int i = 0; i < sbScript.Length; i++)
                {
                    char c = sbScript[i];
                    if (char.IsLetter(c) || c == '(' || c == '$')
                    {
                        //HeaderRemovePattern = -1;
                        break;
                    }
                    else if (IsCharWhiteSpaceLimited(c))
                    {
                        if (c != '\r' && c != '\n')
                        {
                            sbScript.Remove(i, 1);
                            i--;
                        }
                    }
                    else if (c == '/')
                    {

                        if (sbScript.Length > 10 && sbScript[i + 1] == '/' && sbScript[i + 2] == '<' && sbScript[i + 3] == '!' && sbScript[i + 4] == '[' && sbScript[i + 5] == 'C' && sbScript[i + 6] == 'D' && sbScript[i + 7] == 'A' && sbScript[i + 8] == 'T' && sbScript[i + 9] == 'A' && sbScript[i + 10] == '[')
                        {
                            sbScript.Remove(i, 11);
                            i = i - 1;
                            // Pattern 1) "//<![CDATA["  -End With "//]]>""
                            HeaderRemovePattern = 1;
                            break;
                        }
                        if (sbScript.Length > 15 && sbScript[i + 1] == '*' && sbScript[i + 2] == '<' && sbScript[i + 3] == '!' && sbScript[i + 4] == '[' && sbScript[i + 5] == 'C' && sbScript[i + 6] == 'D' && sbScript[i + 7] == 'A' && sbScript[i + 8] == 'T' && sbScript[i + 9] == 'A' && sbScript[i + 10] == '[')
                        {
                            sbScript.Remove(i, 13);
                            i = i - 1;
                            // Pattern 1) "/*<![CDATA[*/"  -End With "//]]"
                            HeaderRemovePattern = 3;
                            break;
                        }

                    }
                    else if (c == '<')
                    {

                        if (sbScript.Length > 6 && sbScript[i + 1] == '!' && sbScript[i + 2] == '-' && sbScript[i + 3] == '-' && sbScript[i + 4] == '/' && sbScript[i + 5] == '/')
                        {

                            // Pattern 10) "<!--//"  -> End Width "//-->"
                            sbScript.Remove(i, 6);
                            // May be continues -->
                            if (sbScript.Length > 4 && sbScript[i] == '-' && sbScript[i + 1] == '-' && sbScript[i + 2] == '>')
                            {
                                sbScript.Remove(i, 3);
                                i = i - 1;
                                continue;
                            }

                            i = i - 1;
                            HeaderRemovePattern = 10;
                        }
                        else if (sbScript.Length > 6 && sbScript[i + 1] == '!' && sbScript[i + 2] == '[' && sbScript[i + 3] == 'C' && sbScript[i + 4] == 'D' && sbScript[i + 5] == 'A' && sbScript[i + 6] == 'T' && sbScript[i + 7] == 'A' && sbScript[i + 8] == '[')
                        {
                            sbScript.Remove(i, 9);
                            i = i - 1;
                            // Pattern 11) <!--//<![CDATA[document.MAX_ct0 ='INSERT_CLICKURL_';//]]>-->
                            if (HeaderRemovePattern == 10)
                            {
                                HeaderRemovePattern = 11;
                            }
                        }
                        else if (sbScript.Length > 5 && sbScript[i + 1] == '!' && sbScript[i + 2] == '-' && sbScript[i + 3] == '-')
                        {
                            // This pattern only remove if following is '\n' or '\r'
                            if (StrongMode == false)
                            {
                                if (sbScript[i + 4] == '\r' || sbScript[i + 4] == '\n')
                                {
                                    sbScript.Remove(i, 4);
                                    i = i - 1;
                                    HeaderRemovePattern = 30;
                                    continue;
                                }
                            }
                            else
                            {
                                sbScript.Remove(i, 4);
                                i = i - 1;
                                HeaderRemovePattern = 30;
                                continue;
                            }

                        }

                    }
                }
                for (int i = sbScript.Length - 1; i >= 0; i--)
                {
                    if (i > sbScript.Length)
                    {
                        break;
                    }
                    char c = sbScript[i];
                    if (char.IsLetter(c) || c == ';' || c == '}' || c == ')')
                    {
                        break;
                    }
                    else if (IsCharWhiteSpaceLimited(c))
                    {
                        if (c != '\r' && c != '\n')
                        {
                            sbScript.Remove(i, 1);
                            //i = i -1;
                            continue;
                        }
                    }
                    else if (c == '/')
                    {
                        if (i > 1)
                        {
                            if (sbScript[i - 1] == '*')
                            {
                                for (int cend = i - 1; cend > 1; cend--)
                                {
                                    char cendChar = sbScript[cend];
                                    if (cendChar == '*')
                                    {
                                        if (sbScript[cend - 1] == '/')
                                        {
                                            int removeLen = i - cend + 2;
                                            sbScript.Remove(cend - 1, removeLen);
                                            i = i - removeLen;
                                            break;
                                        }

                                    }

                                }
                            }
                        }
                    }
                    else if (c == '>')
                    {

                        if (sbScript[i - 1] == '-' && sbScript[i - 2] == '-' && sbScript[i - 3] == '/' && sbScript[i - 4] == '/')
                        {
                            sbScript.Remove(i - 4, 5);
                            i = i - 4;
                            continue;
                        }
                        if (sbScript[i - 1] == '-' && sbScript[i - 2] == '-')
                        {
                            sbScript.Remove(i - 2, 3);
                            i = i - 2;
                            continue;
                        }
                        int pres = -1;
                        for (int t = i; t > 0; t--)
                        {
                            if (sbScript[t] == '/')
                            {
                                if (t > 3 && sbScript[t - 1] == '/')
                                {
                                    pres = t - 1;
                                    break;
                                }

                            }
                            else if (sbScript[t] == '\r' && sbScript[t] == '\n')
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                {
                                    commonLog.LogEntry("string ___hasInner &gt; but here is cr or lf found. skip....");
                                }
                                break;
                            }
                        }
                        if (pres > -1)
                        {
                            sbScript.Remove(pres, i - pres + 1);
                            i = pres - 1;
                            continue;
                        }

                        /*
                        switch(HeaderRemovePattern)
                        {
                            case 1:
                                // should be "//]]>"
                                sbScript.Remove(i-7, 8);
                                i = i - 7;
                                break;
                            case 3: //  "//]]"
                                sbScript.Remove(i-4, 5);
                                i = i - 4;
                                break;
                            case 10:
                                sbScript.Remove(i - 4, 5);
                                i = i - 4;
                                break;
                            case 11:
                                sbScript.Remove(i - 7,8);
                                i = i - 7;
                                break;
                            default:
                                if(sbScript.Length > 3 && sbScript[i -1] == ']' && sbScript[i -2] == ']')
                                {
                                    sbScript.Remove(i - 3,4);
                                    i = i - 3;
                                }
                                break;
                        }
                        */

                    }
                    //NextEndChar:
                    if (false) {; }

                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("PreprocessScriptComment Exception ", ex);
                }
            }
        }

        #endregion


        public static readonly string[] TagsForDrawing = new string[] { "A", "P", "B", "FONT", "DIV", "SPAN", "PRE", "LABEL", "UL", "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "HR", "EM", "OPTION", "STRONG", "DD", "DT", "TABLE", "IMG", "MAP", "BLOCKQUOTE", "SUP", "I", "U", "LI", "SMALL", "FIELDSET", "LEGEND", "CODE", "TEXTAREA", "SELECT", "BASEFONT", "INS", "ADDRESS", "EMBED", "IFRAME" };

        public static readonly string[] TagsForNonSentence = new string[] { "DIV", "TABLE", "TBODY", "TR", "TD", "TH", "DL", "OL", "HEADER", "CAPTION", "UL", "LI", "FORM", "BODY", "FRAMESET", "NOFRAME", "SINAME", "HTML", "META", "AREA", "MAP", "INPUT", "TEXTAREA", "OBJECT", "EMBED", "PARAM", "CAPTION", "SCRIPT", "NOSCRIPT", "STYLE", "IFRAME", "BUTTON", "DT", "SELECT", "OPTION" };


        public static readonly string[] TagsForNoLog = new string[] { "IFRAME", "NOFRAME", "BODY", "NOSCRIPT", "STYLE", "SCRIPT", "BR", "AREA", "PARAM", "NOEMBED", "LINK", "SPACER" };
        public static readonly string[] TagsForLogBounds = new string[] { "DIV", "BODY", "TABLE", "OL", "UL", "DL", "FORM" };


        public static readonly string[] PropertyNamesDisallowsFunctionObjectNames = new string[] { "id", "class", "classname", "href", "src", "color", "bgcolor", "name", "tagname", "async", "defer", "style", "fcolor", "rel", "type", "width", "height", "media" };
        public static System.Collections.Generic.Dictionary<string, string> PropertyNamesDisallowsFunctionObjectSortedList = commonHTML.CreateDictionaryListFromStringArray(PropertyNamesDisallowsFunctionObjectNames);

        public static CHtmlHighPrecisionTimerType highPrecisionTimerType = CHtmlHighPrecisionTimerType.NotTested;
        public static HttpDecompressionSupportType httpDecompressionCapabilityType = HttpDecompressionSupportType.Auto;

        public static readonly string[] TagsPrefersZeroHeightOrWidth = new string[] { "IMG" };


        public static readonly string[] TagsSkipMeasureAndDrawChildSentences = new string[] { "IMG" };

        public static readonly string[] TagsNoBoundsReadjusting = new string[] { "TR" };
        /// <summary>
        /// IFrame, Object, Applet Tags are not included
        /// </summary>

        public static readonly string[] TagsForInputElement = new string[] { "INPUT", "TEXTAREA", "BUTTON", "SELECT" };


        public static readonly char[] FontFamilySeperationChar = new char[] { ',', '.', '\u3001' };

        internal static readonly char[] CharsSlashAndYenMarkAndQuestionAmpsand = new char[] { '\\', '/', '?', '&' };

        internal static readonly char[] ChasInvalidForShortURLName = new char[] { '{', '}', '?', '=' };

        internal static readonly string[] TagsRequiesToClose = new string[] { "/TABLE", "TR", "COLGROUP", "THEAD", "TFOOT", "TD", "/THEAD" };

        internal static System.Collections.Generic.Dictionary<string, string> TagsRequiresToCloseSortedList = commonHTML.CreateDictionaryListFromStringArray(TagsRequiesToClose);
        /// <summary>
        /// List of Color Name with Color for HTML and CSS
        /// </summary>
        internal static System.Collections.Generic.Dictionary<string, Color> CHtmlHTMLColorNamesDictionary = createCHtmlColorNamesDictionary();
        internal static System.Collections.Generic.Dictionary<string, ColorSpec> CHtmlHTMLColorSpecNamesDictionary = createCHtmlColorSpecNamesDictionary();
        internal static Type mageElementType = null;

        /// <summary>
        /// Flag to force to create DrawingElemnts to Non Text. Such as Img (If it is linline).
        /// </summary>
        internal static bool IsCreateInlineNonTextDrawingElements = true;

        internal static string[] FlashAttribitesToBeLookedup = new string[] { "flashvars", "data", "src", };
        /// <summary>
        /// If it is over this limit it throws exception
        /// </summary>
        internal static int MAX_ELEMENT_APPENDCHILD_COUNT = 1000;

        internal readonly static string[] ElementAttributesWillMeargeIntoStyle = new string[] { "onlick", "onmousedown", "href", "clear", "align", "valign", "vertical-alignment", "width", "height", "bgcolor", "background-color", "backgroundcolor", "color", "fgcolor", "fcolor", "foreground-color", "foregroundcolor", "size", "frameborder", "border", "marginheight", "marginwidth", "cellpadding", "cellspacing", "arrowtransprarency", "vscroll", "scrolling", "hscroll", "scroll", "alt", "nowrap", "face", "quality", "style", "background-image", "backgroundimage", "background", "bottommargin", "leftmargin", "topmargin", "rightmargin", "text" };


        internal static string[] WellKnownCHtmlElementAttributesArray = new string[] { "type", "class", "id", "name", "checked", "src", "href", "disabled", "async", "defer", "value", "width", "height", "style" };

        internal static System.Collections.Generic.Dictionary<string, string> WellKnownCHtmlEmementAttributesDictionary = commonHTML.CreateDictionaryListFromStringArray(WellKnownCHtmlElementAttributesArray);




        //public static readonly string[] TagsForNonSizing = new string[]{"IFRAME", "NOFRAME", "BODY","NOSCRIPT", "STYLE", "SCRIPT", "BR", "AREA", "HTML", "HEAD", "STYLE", "META", "LINK"};

        //public static readonly string[] TagsCanEndWithNoSlash = new string[]{"BR", "HR", "META", "EMBED", "PARAM" , "DD", "DT",  "IMG", "SPACER", "OPTION"};
        //public static readonly string[] TagsCanEndWithNoSlashWithoutAnyFollowingInfo = new string[]{"BR", "HR", "IMG", "SPACER", "INPUT"};

        public static readonly CHtmlElementType[] TagTypesCanEndWithNoSlashWithoutAnyFollowingInfo = { CHtmlElementType.BR, CHtmlElementType.HR, CHtmlElementType.IMG, CHtmlElementType.INPUT, CHtmlElementType.SPACER, CHtmlElementType.EMBED, CHtmlElementType.DOCTYPE, CHtmlElementType.BASE, CHtmlElementType.META, CHtmlElementType.FRAME };

        public static System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesCanEndWithNoSlashWithoutAnyFollowingInfoSortedList = CreateSortedListFromTagTypeArray(TagTypesCanEndWithNoSlashWithoutAnyFollowingInfo);


        public static readonly CHtmlElementType[] TagTypesMayCloseImmediatelyIfNoClosingTagExists = { CHtmlElementType.COL, CHtmlElementType.ROW, CHtmlElementType.SOURCE, CHtmlElementType.TRACK };

        public static System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesMayCloseImmediatelyIfNoClosingTagExistsSortedList = CreateSortedListFromTagTypeArray(TagTypesMayCloseImmediatelyIfNoClosingTagExists);

        //public static readonly string[] TagsForDownload = new string[]{"SCRIPT", "LINK", "IMG", "INPUT"};
        public static readonly CHtmlElementType[] TagTypesForDownload = new CHtmlElementType[] { CHtmlElementType.SCRIPT, CHtmlElementType.LINK, CHtmlElementType.IMG, CHtmlElementType.INPUT, CHtmlElementType.OBJECT, CHtmlElementType.AUDIO, CHtmlElementType.VIDEO };
        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesForDownloadSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesForDownload);


        internal static readonly char[] CharSpaceCrLfTab = new char[] { '\r', '\n', '\t', (char)32 };

        internal static readonly char[] CharSpaceCrLfTabZentakuSpace = new char[] { '\r', '\n', '\t', (char)32, CharZenkakuSpace };

        internal static readonly char[] CharSpaceCrLfTabZentakuSpaceComma = new char[] { '\r', '\n', '\t', (char)32, CharZenkakuSpace, ',' };

        internal static readonly char[] CharSpaceCrLfTabZentakuSpaceYenSlash = new char[] { '\r', '\n', '\t', (char)32, CharZenkakuSpace, '\\', '/' };
        internal static readonly char[] CharSpaceOrSlash = new char[] { ' ', '\\' };

        internal static readonly char[] CharCrLfTab = new char[] { '\r', '\n', '\t' };

        //public static readonly string[] TagsTRTDTH = new string[]{"TR","TD","TH"};

        public static readonly CHtmlElementType[] TagTypesTRTDTH = { CHtmlElementType.TR, CHtmlElementType.TD, CHtmlElementType.TH };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesTRTDTHSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesTRTDTH);



        public static readonly string[] TagsForTableRow = new string[] { "TR", "CAPTION" };

        public static readonly CHtmlElementType[] TagTypesTableRow = new CHtmlElementType[] { CHtmlElementType.TR, CHtmlElementType.CAPTION };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesTableRowSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesTableRow);

        public const string SVG_Canvas_String = "___svg";


        public static readonly string[] TagsForAutoFit = new string[] { "TD", "TH", "DIV" };


        public static readonly string[] SymbolQuoteStrings = new string[] { "\"", "\'" };


        public static readonly char[] SymbolQuoteChars = new char[] { '\"', '\'' };

        public const string rhino_no_such_method_string = "__noSuchMethod__";
        /// <summary>
        /// Parameter to generate node from inner if 0 always use dynamic document
        /// </summary>


        internal readonly static int InnerHTMLCreateNodeCharCountSwitch = 3000;

        internal readonly static int MAX_EVENT_RECORD_COUNT = 1000;


        internal readonly static int MAX_TIMER_COPLETE_RECORD_COUNT = 100;

        internal readonly static int MAX_DOCUMENT_TIMER_TIMEOUT_SECONDS = 50; // 50 seconds

        /// <summary>
        /// Minimun tick interval for WM_TIMER
        /// </summary>
        internal readonly static int WINDOW_WM_TIMER_MINUMUM = 15;
        /// <summary>
        /// Minimun tick interval for multimedia timer
        /// 11 = 61 fps - 58 fps (no stress)
        /// 13 = 57 fps
        /// Logically: 1FPS = 1000/60 = 0.03 (30ms
        /// </summary>
        internal readonly static int WINDOW_MULTIMEDIA_TIMER_MINUMUM = 10;
        internal readonly static int UNIX_Hiresolution_TIMER_MINUMUM = 10;


        public static readonly CHtmlElementType[] TagTypesNeedsBoundsAdjustMement = { CHtmlElementType.IMG, CHtmlElementType.CODE, CHtmlElementType.PRE };

        //public static readonly string[] TagsHonorsCrlf = new string[]{"PRE", "CODE", "XMP","TT"};

        public static readonly CHtmlElementType[] TagTypesHonorsCrlf = { CHtmlElementType.PRE, CHtmlElementType.CODE, CHtmlElementType.XMP, CHtmlElementType.TT };

        public static System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesHonorsCrlfSortedList = CreateSortedListFromTagTypeArray(TagTypesHonorsCrlf);


        public static readonly CHtmlElementType[] TagTypesSentence = { CHtmlElementType.A, CHtmlElementType.I, CHtmlElementType.B, CHtmlElementType.U, CHtmlElementType.RUBY, CHtmlElementType.EM, CHtmlElementType.FONT, CHtmlElementType.IMG, CHtmlElementType.ABBR, CHtmlElementType.LABEL, CHtmlElementType.INS, CHtmlElementType.STRONG, CHtmlElementType.STRIKE, CHtmlElementType.SMALL, CHtmlElementType.STRONG, CHtmlElementType.RB, CHtmlElementType.RT, CHtmlElementType.RP, CHtmlElementType.ACRONYM, CHtmlElementType.TT, CHtmlElementType.DFN, CHtmlElementType.SUP, CHtmlElementType.DEL, CHtmlElementType.S, CHtmlElementType.VAR, CHtmlElementType.STRIKE };
        public static System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesSentenceSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesSentence);




        public static readonly CHtmlElementType[] TagTypesDisallowsCSSBeforeAfter = new CHtmlElementType[] { CHtmlElementType.HTML, CHtmlElementType.BODY, CHtmlElementType.HEAD, CHtmlElementType.SCRIPT, CHtmlElementType.META, CHtmlElementType._ITEXT, CHtmlElementType._IDRAW, CHtmlElementType._DOCUMENT_FRAGMENT, CHtmlElementType.LINK, CHtmlElementType.SCRIPT, CHtmlElementType.NOSCRIPT, CHtmlElementType.NOFRAME, CHtmlElementType.DOCTYPE, CHtmlElementType.SOURCE, CHtmlElementType.TRACK, CHtmlElementType.TITLE, CHtmlElementType.XML, CHtmlElementType.SVG, CHtmlElementType._ELEMENT_PROTOTYPE, CHtmlElementType._ELEMENT_AFTER, CHtmlElementType._ELEMENT_BEFORE, CHtmlElementType.TD, CHtmlElementType.TR, CHtmlElementType.TBODY, CHtmlElementType.TFOOT, CHtmlElementType.COL, CHtmlElementType.COLGROUP, CHtmlElementType.THEAD, CHtmlElementType.TH, CHtmlElementType.PARAM, CHtmlElementType.OPTION, CHtmlElementType.OPTGROUP, CHtmlElementType.HR, CHtmlElementType.COMMENT, CHtmlElementType.UL, CHtmlElementType.OL, CHtmlElementType.DT, CHtmlElementType.DD, CHtmlElementType.DL, CHtmlElementType.DATALIST, CHtmlElementType.FIELDSET, CHtmlElementType.NOEMBED, CHtmlElementType.FRAMESET, CHtmlElementType.TIME, CHtmlElementType.BASEFONT, CHtmlElementType.AUDIO, CHtmlElementType.CLIPPATH, CHtmlElementType.CIRCLE, CHtmlElementType.IMAGE, CHtmlElementType.IFRAME, CHtmlElementType.NOINDEX, CHtmlElementType.BR, CHtmlElementType.OPTION, CHtmlElementType.OPTGROUP, CHtmlElementType.SMALL, CHtmlElementType.FONT, CHtmlElementType.NOSCRIPT, CHtmlElementType.B, CHtmlElementType.BASE, CHtmlElementType.BASEFONT, CHtmlElementType.AUDIO, CHtmlElementType.AREA, CHtmlElementType.COMMENT, CHtmlElementType.U, CHtmlElementType.I, CHtmlElementType.B, CHtmlElementType.FRAME, CHtmlElementType.APPLET, CHtmlElementType.KBD, CHtmlElementType.STRONG, CHtmlElementType.IMAGE, CHtmlElementType.NOEMBED, CHtmlElementType.XML };
        public static System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesDisallowsCSSBeforeAfterSortedList =
            commonHTML.CreateSortedListFromTagTypeArray(TagTypesDisallowsCSSBeforeAfter);
        //public static readonly string[] TagsPreserveWhiteSpacesAfterCrlf = new string[]{"PRE", "CODE", "XMP", "TT"};

        public static readonly CHtmlElementType[] TagTypesPreserveWhiteSpacesCrlf = { CHtmlElementType.PRE, CHtmlElementType.CODE, CHtmlElementType.XMP, CHtmlElementType.TT };
        public static System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesPreserveWhiteSpacesCrlfSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesPreserveWhiteSpacesCrlf);


        public static readonly CHtmlElementType[] TagTypesVisibleLessNoSize = { CHtmlElementType.BR, CHtmlElementType.WBR };


        //public static readonly string[] TagsNoLowerLevelInvestigation = new string[]{"HTML", "BODY", "HEAD"};


        public static readonly string[] TagsAvailableForTextEditor = new string[] { "LINK", "STYLE", "SCRIPT" };

        //public static readonly string[] TagsBodyStarts= new string[]{"BODY", "DIV", "TBODY", "TABLE"};

        public static readonly CHtmlElementType[] TagTypesBodyStarts = { CHtmlElementType.BODY, CHtmlElementType.DIV, CHtmlElementType.TABLE, CHtmlElementType.HEADER, CHtmlElementType.FRAMESET, CHtmlElementType.FORM, CHtmlElementType.NAV };

        public static System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesBodyStartsSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesBodyStarts);

        //public static readonly string[] TagsAppearsOnlyHeader = new string[]{"HTML", "META", "LINK", "HEAD", "TITLE"};

        public static readonly CHtmlElementType[] TagTypesAppearsOnlyHeader = { CHtmlElementType.HTML, CHtmlElementType.META, CHtmlElementType.LINK, CHtmlElementType.HEAD, CHtmlElementType.TITLE, CHtmlElementType.DOCTYPE, CHtmlElementType.BASE, CHtmlElementType.STYLE };
        /// <summary>
        /// TagTypes apears on HEAD Block (majority of the case)
        /// </summary>

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesAppearsOnlyHeaderSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesAppearsOnlyHeader);

        /// <summary>
        ///      // Note: NoScript may appears on head block #Text may accidentally appears on head also. 
        /// </summary>

        public static readonly CHtmlElementType[] TagTypesMostlyAppearsHeader = { CHtmlElementType.HTML, CHtmlElementType.META, CHtmlElementType.LINK, CHtmlElementType.HEAD, CHtmlElementType.TITLE, CHtmlElementType.SCRIPT, CHtmlElementType.NOSCRIPT, CHtmlElementType.DOCTYPE, CHtmlElementType.BASE, CHtmlElementType.STYLE, CHtmlElementType.NOSCRIPT, CHtmlElementType._ITEXT };
        /// <summary>
        /// TagTypes appears frequently on Head block
        /// </summary>

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesMostlyAppearsInHeaderSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesMostlyAppearsHeader);
        public static readonly CHtmlElementType[] TagTypesNoChildSizeCheckIfValuesNonExists = { CHtmlElementType.UL, CHtmlElementType.OL };


        /// <summary>
        /// List of TagTypes which should not enlarge it self (ex.height) by child element 
        /// </summary>
        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> TagTypesNoChildSizeCheckIfValuesNonExistsSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesNoChildSizeCheckIfValuesNonExists);


        public static readonly CHtmlElementType[] TagTypesNoStylesheetLookup = new CHtmlElementType[] { CHtmlElementType.XML, CHtmlElementType.HTML, CHtmlElementType.META, CHtmlElementType.LINK, CHtmlElementType.HEAD, CHtmlElementType.TITLE, CHtmlElementType.STYLE, CHtmlElementType._ITEXT, CHtmlElementType._IDRAW, CHtmlElementType.OPTION, CHtmlElementType.OPTGROUP, CHtmlElementType.DATALIST };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesNoStylesheetLookupSortedList = CreateSortedListFromTagTypeArray(TagTypesNoStylesheetLookup);


        public static readonly CHtmlElementType[] TagTypesMustBeInvisibleAndZeroSize = new CHtmlElementType[] { CHtmlElementType.XML, CHtmlElementType.HEAD, CHtmlElementType.META, CHtmlElementType.LINK, CHtmlElementType.TITLE, CHtmlElementType.SCRIPT, CHtmlElementType.LINK, CHtmlElementType.STYLE, CHtmlElementType.PARAM, CHtmlElementType.AREA, CHtmlElementType.KBD, CHtmlElementType.G_PLUSONE, CHtmlElementType.OPTION };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesMustBeInvisibleAndZeroSizeSortedList = CreateSortedListFromTagTypeArray(TagTypesMustBeInvisibleAndZeroSize);

        //public static readonly string[] TagsNoStylesheetLookupHtmlExclude = new string[]{"XML", "META", "LINK", "HEAD", "TITLE", "SCRIPT",  "STYLE"};

        public static readonly CHtmlElementType[] TagTypesNoStylesheetLookupHtmlExclude = { CHtmlElementType.XML, CHtmlElementType.META, CHtmlElementType.LINK, CHtmlElementType.HEAD, CHtmlElementType.TITLE, CHtmlElementType.SCRIPT, CHtmlElementType.STYLE, CHtmlElementType.DOCTYPE };

        public static System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesNoStylesheetLookupHtmlExcludeSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesNoStylesheetLookupHtmlExclude);


        public static readonly CHtmlElementType[] TagTypesNormallyBlock = { CHtmlElementType.XML, CHtmlElementType.META, CHtmlElementType.LINK, CHtmlElementType.HEAD, CHtmlElementType.TITLE, CHtmlElementType.SCRIPT, CHtmlElementType.STYLE, CHtmlElementType.SVG, CHtmlElementType.DOCTYPE, CHtmlElementType.UL, CHtmlElementType.OL, CHtmlElementType.DT, CHtmlElementType.TABLE, CHtmlElementType.TR, CHtmlElementType.TD, CHtmlElementType.TBODY, CHtmlElementType.TFOOT, CHtmlElementType.CAPTION, CHtmlElementType.NAV, CHtmlElementType.DIV, CHtmlElementType.ASIDE, CHtmlElementType.SELECT, CHtmlElementType.SECTION, CHtmlElementType.IFRAME };

        public static System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesNormallyBlockSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesNormallyBlock);

        private static int ___elementGeneralIncrementValue = 0;
        private static int ___cssRuleGeneralIncrementValue = 0;
        private static int ___documentTimerGeneralIncrementValue = 1;

        public static readonly char[] AlphabetCharactersL = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };


        public static readonly char[] AlphabetCharactersLPlusPercent = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '%' };


        public static readonly char[] NumericChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        /// <summary>
        /// if this true, timer should use Windows.Forms.Timer, not high precision timer.
        /// </summary>
        internal static bool useSlowTimerOnUnix = false;
        /// <summary>
        /// URL for Dyamic generated document
        /// </summary>
        public static string DOCUMENT_URL_FOR_DYNAMIC_CONTENT = "about:script_generated_document";

        public static readonly string[] TagsForPlugins = { "OBJECT", "EMBED", "APPLET" };

        internal static char[] CharsSplittingStyleString = new char[] { '.', '#', '@', '/' };
        /// <summary>
        /// Tags DisallowChildren should only applied for non innerText tags only 
        /// ex. [option] can have a children innerText Values exclude it.
        /// </summary>

        //public static readonly string[] TagsDisallowChildrenAndInnerText = {"META", "LINK", "STYLE", "SCRIPT", "PARAM",  "AREA", "IMG", "HR"};
        public static readonly CHtmlElementType[] TagTypesDisallowChildrenAndInnerText = { CHtmlElementType.META, CHtmlElementType.LINK, CHtmlElementType.STYLE, CHtmlElementType.SCRIPT, CHtmlElementType.PARAM, CHtmlElementType.AREA, CHtmlElementType.IMG, CHtmlElementType.HR };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesDisallowChildrenAndInnerTextSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesDisallowChildrenAndInnerText);

        public static readonly CHtmlElementType[] TagTypesNoClosingTags = { CHtmlElementType.META, CHtmlElementType.PARAM, CHtmlElementType.AREA, CHtmlElementType.IMG, CHtmlElementType.HR };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesNoClosingTagsSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesNoClosingTags);

        //public static readonly string[] TagsForNoChildCHtmlTreeNodeLookUp = {"OBJECT", "EMBED", "APPLET", "IFRAME", "SELECT", "OPTION", "MAP"};
        //public static readonly string[] TagsForInheritsParentBounds = {"TBODY", "DIV", "TABLE", "HR"};

        //public static readonly string[] TagsBeignWithLineFeed = {"BODY","BR", "TABLE", "TBODY", "DIV", "IFRAME", "SELECT", "H1", "H2", "H3", "H4", "H6", "H7", "FORM", "OBJECT", "EMBED", "P", "HR", "FRAMESET", "OL", "UL", "LI", "DT", "DL","DD", "PRE", "CODE", "NOFRAME", "MAP", "BLOCKQUOTE", "CENTER", "SPAN", "TR", "INPUT"};

        public static readonly CHtmlElementType[] TagTypesBeignWithLineFeed = { CHtmlElementType.BODY, CHtmlElementType.BR, CHtmlElementType.TABLE, CHtmlElementType.TBODY, CHtmlElementType.DIV, CHtmlElementType.IFRAME, CHtmlElementType.SELECT, CHtmlElementType.H1, CHtmlElementType.H2, CHtmlElementType.H3, CHtmlElementType.H4, CHtmlElementType.H6, CHtmlElementType.H7, CHtmlElementType.FORM, CHtmlElementType.OBJECT, CHtmlElementType.EMBED, CHtmlElementType.P, CHtmlElementType.HR, CHtmlElementType.FRAMESET, CHtmlElementType.OL, CHtmlElementType.UL, CHtmlElementType.LI, CHtmlElementType.DT, CHtmlElementType.DL, CHtmlElementType.DD, CHtmlElementType.PRE, CHtmlElementType.CODE, CHtmlElementType.NOFRAME, CHtmlElementType.MAP, CHtmlElementType.BLOCKQUOTE, CHtmlElementType.CENTER, CHtmlElementType.SPAN, CHtmlElementType.TR };


        //public static readonly string[] TagsEndWithLineFeed = {"P", "H1", "H2", "H3", "H4", "H6", "H7", "OL", "UL", "DT", "DL","DD", "PRE", "XMP", "CODE", "NOFRAME", "MAP", "BLOCKQUOTE", "CENTER", "TR", "INPUT"};

        //public static readonly string[] TagsNoInnerText  = {"OBJECT", "EMBED", "APPLET", "IFRAME","NOSCRIPT", "SCRIPT", "STYLE", "NOFRAME"};
        // -- Do not put NOSCRIPT 

        public static readonly CHtmlElementType[] TagTypesNoInnerText = { CHtmlElementType.OBJECT, CHtmlElementType.EMBED, CHtmlElementType.APPLET, CHtmlElementType.SCRIPT, CHtmlElementType.STYLE, CHtmlElementType.FRAME, CHtmlElementType.COMMENT };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesNoInnerTextSortedList = CreateSortedListFromTagTypeArray(TagTypesNoInnerText);

        public static readonly CHtmlElementType[] TagTypesReadThroughForInnnerText = { CHtmlElementType.OBJECT, CHtmlElementType.EMBED, CHtmlElementType.APPLET, CHtmlElementType.SCRIPT, CHtmlElementType.STYLE, CHtmlElementType.FRAME, CHtmlElementType.COMMENT, CHtmlElementType.NOSCRIPT };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesReadThroughForInnnerTextDictionary = CreateSortedListFromTagTypeArray(TagTypesReadThroughForInnnerText);


        public static readonly CHtmlElementType[] TagTypesDynamicElement1stProcessRequired = { CHtmlElementType.EMBED, CHtmlElementType.SCRIPT, CHtmlElementType.STYLE, CHtmlElementType.IMG, CHtmlElementType.LINK };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesDynamicElement1stProcessRequiredSortedList = CreateSortedListFromTagTypeArray(TagTypesDynamicElement1stProcessRequired);

        internal static uint ___TRACE_PARENT_FOR_DOCUMENT_LOOKUP_MAX = 100;



        public static readonly CHtmlElementType[] TagTypesForCreatingManagedControl = { CHtmlElementType.SELECT, CHtmlElementType.INPUT, CHtmlElementType.OBJECT, CHtmlElementType.IFRAME, CHtmlElementType.EMBED, CHtmlElementType.TEXTAREA, CHtmlElementType.BUTTON, CHtmlElementType.FRAME, CHtmlElementType.VIDEO, CHtmlElementType.AUDIO };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTypesListTypesToBeCreatePlatformBasedControl = createElementTypesListTypesToBeCreatePlatformBasedControl();

        private static Dictionary<CHtmlElementType, object> createElementTypesListTypesToBeCreatePlatformBasedControl()
        {
            Dictionary<CHtmlElementType, object> elementTypesList = new Dictionary<CHtmlElementType, object>();
            elementTypesList.Add(CHtmlElementType.SELECT, null);
            elementTypesList.Add(CHtmlElementType.INPUT, null);
            elementTypesList.Add(CHtmlElementType.BUTTON, null);
            elementTypesList.Add(CHtmlElementType.OBJECT, null);
            elementTypesList.Add(CHtmlElementType.IFRAME, null);
            elementTypesList.Add(CHtmlElementType.TEXTAREA, null);
            return elementTypesList;
        }

        public static readonly string[] TagsPTagPossilbeClosingTag = { "ADDRESS", "ARTICLE", "ASIDE", "BLOCKQUOTE", "DIR", "DIV", "FIELDSET", "FOOTER", "FORM", "H1", "H2", "H3", "H4", "H5", "H6", "HEADER", "HGROUP", "HR", "MENU", "NAV", "OL", "P", "PRE", "SECTION", "TABLE", "UL" };

        public static readonly CHtmlElementType[] TagTypesPTagPossilbeClosingTag = new CHtmlElementType[]{CHtmlElementType.ADDRESS, CHtmlElementType.ARTICLE, CHtmlElementType.ASIDE, CHtmlElementType.BLOCKQUOTE, CHtmlElementType.DIR,  CHtmlElementType.DIV,  CHtmlElementType.FIELDSET,
                                                                                                        CHtmlElementType.FOOTER,  CHtmlElementType.FORM,  CHtmlElementType.H1,  CHtmlElementType.H2,  CHtmlElementType.H3,  CHtmlElementType.H4,  CHtmlElementType.H5,  CHtmlElementType.H6,  CHtmlElementType.HEADER,  CHtmlElementType.HGROUP,  CHtmlElementType.HR,  CHtmlElementType.MENU,  CHtmlElementType.NAV,  CHtmlElementType.OL,  CHtmlElementType.P,  CHtmlElementType.PRE,  CHtmlElementType.TABLE,  CHtmlElementType.UL};

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesPTagPossilbeClosingTagSortedList = CreateSortedListFromTagTypeArray(TagTypesPTagPossilbeClosingTag);


        public static readonly string[] NoImageAttributes = { "", " ", "none", "undefined", "no", "undefine", "inital" };

        public static readonly System.Collections.Generic.Dictionary<string, string> NoImageAttributesSortedList = CreateDictionaryListFromStringArray(NoImageAttributes);


        public static readonly string[] BackgroundGradientNames = { "gradient", "linear-gradient" };
        // Note) iframe may be removed in future


        public static readonly Color TagColor = Color.Gainsboro;


        public static readonly string[] GenericFontNames = { "monospace", "serif", "sans-serif", "cursive", "fantasy" };

        public static readonly System.Collections.Generic.Dictionary<string, string> GenericFontNamesSortedList = CreateDictionaryListFromStringArray(GenericFontNames);


        public static readonly string[] LeftCenterRightString = { "left", "center", "right" };

        public static readonly System.Collections.Generic.Dictionary<string, string> LeftCenterRightStringSortedList = CreateDictionaryListFromStringArray(LeftCenterRightString);

        public static readonly string[] TopCenterBottomString = { "top", "center", "bottom" };

        public static readonly System.Collections.Generic.Dictionary<string, string> TopCenterBottomStringSortedList = commonHTML.CreateDictionaryListFromStringArray(TopCenterBottomString);



        public static readonly string[] SelectorKeyAfterBefore = { "after", "before" };

        public static readonly string[] TagsForNonCloseTagElementCheck = { "IMG", "OPTION", "PARAM", "META", "LINK", "AREA" };

        public static readonly CHtmlElementType[] TagTypesForNonCloseTagElementCheck = { CHtmlElementType.IMG, CHtmlElementType.OPTION, CHtmlElementType.PARAM, CHtmlElementType.META, CHtmlElementType.LINK, CHtmlElementType.AREA };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesForNonCloseTagElementCheckSortedList = CreateSortedListFromTagTypeArray(TagTypesForNonCloseTagElementCheck);


        public static readonly string TagsForCommentBlock = "/!-!/";

        public static readonly System.Drawing.Point ManagedControlInvisiblePoint = new Point(-5000, -5000);
        /// <summary>
        /// Tags Having Strong Meaning For Layout
        /// If these tags exists for closing parent lookup, non strong tags can not close parent over them
        /// </summary>
        //public static readonly string[] TagsForStrongLayout = {"DIV", "TABLE", "TR", "BODY", "CENTER", "HTML", "UL", "OL"};

        public static readonly CHtmlElementType[] TagTypesForStrongLayout = { CHtmlElementType.DIV, CHtmlElementType.TABLE, CHtmlElementType.TBODY, CHtmlElementType.TR, CHtmlElementType.BODY, CHtmlElementType.CENTER, CHtmlElementType.HTML, CHtmlElementType.UL, CHtmlElementType.OL, CHtmlElementType.SINAME };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesForStrongLayoutSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesForStrongLayout);


        public static readonly CHtmlElementType[] TagTypesDisallowInlineInheritance = { CHtmlElementType.DIV, CHtmlElementType.TABLE, CHtmlElementType.TBODY, CHtmlElementType.TR, CHtmlElementType.BODY, CHtmlElementType.CENTER, CHtmlElementType.HTML, CHtmlElementType.UL, CHtmlElementType.OL, CHtmlElementType.SINAME, CHtmlElementType.TR, CHtmlElementType.TD, CHtmlElementType.THEAD, CHtmlElementType.XML, CHtmlElementType.BLOCKQUOTE, CHtmlElementType.IFRAME, CHtmlElementType.COLGROUP, CHtmlElementType.COL, CHtmlElementType.TFOOT, CHtmlElementType.TH, CHtmlElementType.ROWGROUP, CHtmlElementType.OBJECT, CHtmlElementType.H1, CHtmlElementType.H2, CHtmlElementType.H3, CHtmlElementType.H4, CHtmlElementType.H5, CHtmlElementType.H6, CHtmlElementType.H7, CHtmlElementType.P, CHtmlElementType.DD, CHtmlElementType.DT, CHtmlElementType.DL, CHtmlElementType.HR, CHtmlElementType.FORM, CHtmlElementType.FRAME, CHtmlElementType.FRAMESET, CHtmlElementType.EMBED, CHtmlElementType.CANVAS };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesDisallowInlineInheritanceSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesDisallowInlineInheritance);

        public const int ELEMENT_CONTAINS_SEARCH_LOOKUP_STACK_LIMIT = 100;
        /// <summary>
        /// Special Flag for Debugging
        /// </summary>
        public static bool ___startWatching = false;
        public const string ENGINE_SHUTDOWN_STRING = "_!_END";

        /// <summary>
        /// this will log all document.evaluate query into a file
        /// </summary>
        internal static bool EnableDocumentEvaluateLogging = false;


        /// <summary>
        /// Mono httprequst automaticCompression Support enabled or not
        /// </summary>
        internal static bool disableHTTPDecompression = false;

        internal static string XPathLogFileName = "xpath_query.log";
        internal static System.Collections.Generic.Dictionary<CHtmlElementType, byte> elementTagTypesShouldIncludedAllChildList = createNonAlllNodeTagTypeList();
        public static System.Collections.Generic.Dictionary<CHtmlElementType, byte> createNonAlllNodeTagTypeList()
        {
            System.Collections.Generic.Dictionary<CHtmlElementType, byte> list = new System.Collections.Generic.Dictionary<CHtmlElementType, byte>();
            list[CHtmlElementType._ITEXT] = 1;
            list[CHtmlElementType._IDRAW] = 1;
            list[CHtmlElementType._ELEMENT_AFTER] = 1;
            list[CHtmlElementType._ELEMENT_BEFORE] = 1;
            list[CHtmlElementType._ELEMENT_PROTOTYPE] = 1;
            list[CHtmlElementType.COMMENT] = 1;

            return list;
        }


        public static readonly CHtmlElementType[] TagTypesDisallowInline = { CHtmlElementType.TABLE, CHtmlElementType.TBODY, CHtmlElementType.TR, CHtmlElementType.BODY, CHtmlElementType.CENTER, CHtmlElementType.HTML, CHtmlElementType.SINAME, CHtmlElementType.TR, CHtmlElementType.TD, CHtmlElementType.THEAD, CHtmlElementType.XML, CHtmlElementType.BLOCKQUOTE, CHtmlElementType.IFRAME, CHtmlElementType.COLGROUP, CHtmlElementType.COL, CHtmlElementType.TFOOT, CHtmlElementType.TH, CHtmlElementType.ROWGROUP, CHtmlElementType.OBJECT, CHtmlElementType.P, CHtmlElementType.DD, CHtmlElementType.DT, CHtmlElementType.DL, CHtmlElementType.HR, CHtmlElementType.FORM, CHtmlElementType.FRAME, CHtmlElementType.FRAMESET, CHtmlElementType.EMBED, CHtmlElementType.CANVAS, CHtmlElementType.UL };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesDisallowInlineSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesDisallowInline);


        public static readonly CHtmlElementType[] TagTypesNeverSeachStyleSheet = { CHtmlElementType.LINK, CHtmlElementType.STYLE, CHtmlElementType.SCRIPT, CHtmlElementType.NOSCRIPT, CHtmlElementType.PARAM, CHtmlElementType.META, CHtmlElementType.COMMENT, CHtmlElementType.TITLE, CHtmlElementType.TRACK, CHtmlElementType._ITEXT, CHtmlElementType._ELEMENT_AFTER, CHtmlElementType._ELEMENT_BEFORE, CHtmlElementType.DOCTYPE, CHtmlElementType.HEAD, CHtmlElementType.OPTGROUP, CHtmlElementType.OPTION, CHtmlElementType.DATALIST, CHtmlElementType._DOCUMENT_FRAGMENT };


        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesNeverSeachStyleSheetSortedList = commonHTML.CreateSortedListFromTagTypeArray(commonHTML.TagTypesNeverSeachStyleSheet);


        public static readonly CHtmlElementType[] TagTypesIgnoredDuringCaluclateElementBounds = { CHtmlElementType.LINK, CHtmlElementType.STYLE, CHtmlElementType.SCRIPT, CHtmlElementType.NOSCRIPT, CHtmlElementType.PARAM, CHtmlElementType.META, CHtmlElementType.COMMENT, CHtmlElementType.TITLE, CHtmlElementType.TRACK, CHtmlElementType.DOCTYPE, CHtmlElementType.HEAD };

        public static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesIgnoredDuringCaluclateElementBoundsSortedList = CreateSortedListFromTagTypeArray(commonHTML.TagTypesIgnoredDuringCaluclateElementBounds);


        private static string[] ___SVGContentTypes = { "image/svg+xml", "image/svg-xml", "application/svg+xml", "image/svg", "appliction/svg" };
        internal static System.Collections.Generic.Dictionary<string, string> SVGContentTypesSortedList = commonHTML.CreateDictionaryListFromStringArray(___SVGContentTypes);

        /// <summary>
        /// CHtmlCSSStyleSheet Selector ID represents Directly in HTML Tag
        /// </summary>

        internal static readonly string StylesheetSelectorIDDirect = "@";

        public static readonly int HTMLControlMargin = 2;


        public static readonly Size TableCellMimimumSize = new Size(30, 10);


        public static readonly Color BorderDefaultColor = Color.Black;

        public static int NA_IMAGE_PAINT_WAIT_COUNT = 15;


        public static CHtmlDocument CurrentHtmlDocument = null;

        public static float fontOneCharacterWidth = 12f;

        internal static float floatXLowerHeight = 0f;

        public static readonly PointFSpec MinusPoint = new PointFSpec(-999999, -999999);

        public static readonly PointFSpec MinusPointReg = new PointFSpec(-999999, -999999);

        /// <summary>
        /// Document ThreadSuspend Inital Suspend Time
        /// </summary>

        internal static int DOCUMENT_THREADSUSPEND_INITAL_INTERVAL = 1000;

        /// <summary>
        /// Document ThreadSuspend Decrement From Inital Time
        /// </summary>

        internal static int DOCUMENT_THREADSUSPEND_DECREMENT_PER = 250;
        /// <summary>
        /// Document Thread Suspend Minium Suspend Time 
        /// </summary>

        internal static int DOCUMENT_THREADSUSPEND_MIMIMUM = 500;

        //internal static readonly Point InvisibleElementoffsetPoint = new System.Drawing.Point(-999990, 0);

        /// <summary>
        /// TODO: Change this switch location if possible
        /// </summary>
        internal static bool EnableBrowserClientScript = true;


        internal static System.Collections.Generic.List<System.WeakReference> SafeWaitHandleWeakReferenceList = new System.Collections.Generic.List<WeakReference>();


        internal static string[] WellKnownProperties = { "id", "document", "window", "childNodes", "all", "childNodes", "elements", "name", "class", "type", "navigator", "screen", "parentNodes", "parent" };

        internal static System.Collections.Generic.Dictionary<string, string> WellKnownPropertiesSortedList = commonHTML.CreateDictionaryListFromStringArray(WellKnownProperties);


        internal static readonly CHtmlElementType[] TagTypesValidTDTHParentTagNameTypes = new CHtmlElementType[] { CHtmlElementType.TR, CHtmlElementType.THEAD, CHtmlElementType.TBODY, CHtmlElementType.TFOOT };

        internal static readonly System.Collections.Generic.Dictionary<CHtmlElementType, object> elementTagTypesValidTDTHParentTagNameTypesSortedList = commonHTML.CreateSortedListFromTagTypeArray(TagTypesValidTDTHParentTagNameTypes);


        internal static readonly char[] TrimChars = new char[] { ' ', '\r', '\n', '\t', CharZenkakuSpace/*<DBCS Space>*/};


        internal static readonly char[] ClassNameSplitChars = { ' ', '\r', '\t', '\n' };

        internal static readonly SortedList CHtmlAttributeNamesDefaultValueIsStringList = CreateCHtmlAttributesNamesDefaultValueIsString();


        internal static readonly float ListImageSizeMaxWidth = 40F;

        internal static Type ndefinedObjectType = null;

        public const uint Pseudo_TagPrefech_Allowed_DOM_LEVEL = 4;


        internal static readonly string[] WellKnownParseIntNaNString = new string[] { "micVariablePrefix", "torID", "torMigrationKey", "torMigrationServer", "torMigrationServerSecure", "Set", "torNamespace", "ieDomainPeriods", "ieLifetime", "Name", "URL", "rrer", "encyCode", "ableProvider", "nel", "er", "Type", "sactionID", "haseID", "aign", "ts", "ts2", "ucts", "Name", "Type", "extData", "tProfileID", "tStoreForSeconds", "tIncrementBy", "ieveLightProfiles", "teLightProfiles", "ieveLightData", "lution", "rDepth", "scriptVersion", "Enabled", "iesEnabled", "serWidth", "serHeight", "ectionType", "page", "ins", "stamp", "undefined", "NaN", "an", "as", "ap", "av", "aw", "bw", "bn", "bp", "al", "aw", "at", "bl", "bt", "homepage", "bx", "small", "big" };
        /// <summary>
        /// Case Sensitve comparison
        /// </summary>
        internal static readonly System.Collections.Generic.Dictionary<string, string> WellKnownParseIntNaNStringSortedList = commonHTML.CreateDictionaryListFromStringArray(WellKnownParseIntNaNString);

        internal static string[] ElementFieldsNeedsToTypeConversion = new string[] { "async", "defer", "multiple", "rows", "columns", "cells", "tablindex", "maxlength", "cells", "iscontentedit", "contenteditable", "iscontenteditable", "disabled", "isdisabled", "istextedit", "checked", "multiple", "required", "readonly", "selected", "defaultselected", "autofocus", "autoplay" };
        internal static readonly System.Collections.Generic.Dictionary<string, string> ElementFieldsNeedsToTypeConversionSortedList = commonHTML.CreateDictionaryListFromStringArray(ElementFieldsNeedsToTypeConversion);

        internal static string[] StyleElementFieldsCaseSensitveArray = new string[] { "background-image", "backgroundimage", "background", "xbackground", "list-style-image", "liststyleimage", "mask-image", "mask-box-image", "content", "text-content", "textcontent", "src" };
        internal static readonly System.Collections.Generic.Dictionary<string, string> StyleElementFieldsCaseSensitveSortedList = commonHTML.CreateDictionaryListFromStringArray(StyleElementFieldsCaseSensitveArray);



        internal static string HostDataPrefix = "hdb:";

        internal static string CookieDataPrefix = "cookie:";

        internal static string SessionStoragePrefix = "sstorage:";

        internal static string LocalStoragePrefix = "lstorage:";

        internal static string[] StyleElementFieldsNumericCheckArray = new string[] { "font-size", "width", "height", "min-width", "max-width", "min-hegiht", "max-height" };
        internal static readonly System.Collections.Generic.Dictionary<string, string> StyleElementFieldsNumericCheckSortedList = commonHTML.CreateDictionaryListFromStringArray(StyleElementFieldsNumericCheckArray);
        /*
         * <ins>
         * Text contained by the INS element is rendered underlined.
         * This element is available in HTML and script as of Internet Explorer 4.0.
         * This element is an inline element.
         * This element requires a closing tag.
         * 
         * <address>
         * Internet Explorer displays the content of an address element in italics.
         * This element is available in HTML as of Internet Explorer 3.0, and in script as of               * Internet Explorer 4.0.
         * This element is a block element.
         * This element requires a closing tag.
         * 
         * <embed>
         * The EMBED element must appear inside the BODY element of the document.
         * Users need to have an application that can view the data installed on their computer.
         *
         * This element is available in HTML as of Internet Explorer 3.0, and in 
         * script as of Internet Explorer 4.0.
         * This element is an inline element.
         * This element does not require a closing tag.
         * 
         * <param>
         * 
         * 
         * <caption>
         * The CAPTION element should be a child of the TABLE element.
         * The table object and its associated elements have a separate 
         * table object model, which utilizes different methods than the
         * general object model. For more information on the table object model
         * , see How to Build Tables Dynamically.
         * This element is available in HTML as of Internet Explorer 3.0, 
         * and in script as of Internet Explorer 4.0.
         * This element is an inline element.
         * This element requires a closing tag
         * 
         */

        /// <summary>
        /// url(data:image/gif;base64,R0lGODlhAQABAAD/ACwAAAAAAQABAAACADs=);
        /// </summary>

        internal static readonly string Base64FileImage20pxUrl = "url(data:image/gif;base64,R0lGODlhFAAUAPcAAP///+Pz/9/z/8bG39fj9+fz/+v3/+f3/87O39fv/9/v//f7//P7/7rO79vv/46awtLS4/v/////+/v7/+/3/+Pv/7LG69vf687r/77G87bC45qiwsbn/67X/9/j85Kewtvz/9/r+9/f68bK88bj/+vz/9fr/9/n9/v7++Pv+8rn/9/n87rS87rf//Pz++Pr89Lr/5aewrbb/5aa68bO/+vv+9LX487v/7bG6+vv94qawsrK377O86ay0tLn/3me0t/r966y8//7/8rK27rK79fX532OvtLb/6q+4+Pz+67C63Gm46Kmwrrj/5aexs7n/+Pj74aGqrbK66621/P3967b/77G98LK4+Pv956i89Lv/12i44KOwqauyr6+0nGKwpaiwsrO3+fr832Sxq6+26LC7/v3+4qWxqKu27rG8/f3+8rr/+/7/7rO6+/z+77C846avpqewtvf79ff99vr/8LK88Lj/7Lf/+fv/7LC38Ln/9/f756ivsbG88rj/7bG54aWwt/r86qy7//7+8bG29LS53mKwqKivuPj67LK66rb/6Kqxufr76662+/z95qevtvn+8Lf/7Lb/+fv+////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////yH5BAEAAJQALAAAAAAUABQAAAj/ACkJHEiwoEFKBBIqXJhwzgUXBFOUaUORopQ/GC0kQnJGA4WBJ1gAGDlykMlBKMwwMvJDyUAgIknKnDCBgZgxW5agcUTphBSZJBmUOEDhBaAvhrjYoLTij4SRQhYwEFqgQIlJPARlmQGBqYZBIxeUqHqgQIUAARQcoRGk64o8YCc4Sos2gAABBQQkePKmqwcyZgBMKKFAgYAAFQqjNeGnj98pZiZQyFtYQGEFiE2oqNN1zxQ1bMxetlxZAQw/nCnJ6eHIwIHCIAzLruAABok6CFR3aU1ZQYoUlVM40BIpQ+4Li3IMDZBi0qTEvxVobpHmOJMVmAukSCLAgQM6DvaSU5CRJgylC4cCFXYAoraPJ09UkIgkqUP183wCdU9gAgYGDnY00YIkVSjSgXGUDBHFIxs88ggYMcTwwQdwVAiHDnA4YR4lXuwwwIcghvghIYRcQUlAADs=)";

        internal static readonly string Base64FolderImage20pxUrl = "url(data:image/gif;base64,R0lGODlhFAAUAPcAAPf7mv////f7nufj4/f3mra2cff/mmVNPXVhIPv7nsK2tvf3uvv7mvfzmtvbtvP3mmVNOfPzlvv/mvf7tsa2tt/jovf/nvf3lvf3kvP3luvvkvv/lqaePfv3rmlNPePjovv3mrKyTa6eRffzlvvzmvv3nnVlJO/jitvftqaaPbq+dba2bff7puvrju/vhvf7lrq6dfv79/v/qrayZfP7mvf3xt/jgsrKyvPrkpqaira6cfPv73VhJNLSqt/fvu/3lmllOY55ab62Vba2lufris7KsvPzqu/3jvv7+76+efPfkrq2rmlZFJKWTfP7lsbKgq6iSfvrmv//+6amXcq+vm1VQevvqvv3stvfnrKyVe/vju/vkvfzumVJPfPbjqKmmvP3juPnnvf3puffmsrKmq6qSaqWQa6mQe/3nr62tvPvlrK2Tefrfe/zivf3+8LCeca6uvfvttfXnrKmVe/jluvfira6efPzkvPjkvv3+/f3nu/fiqKaOfv7lvf7rmlNOe/zlqqeQe/fjvvznnVlIO/jhqaWPe/bjuvvhvv7qrKuYe/r6+/zpvPfjqqiRfvnmuvvpvf3ttffmuvvjvfvuvPXjvfzpuPjnqqqTaqmQfPvkuvzhvf3977Cfca2uu/zkv///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////yH5BAEAAKAALAAAAAAUABQAAAj/AEGBIpMlRIg1mHIIXMhwYQ85BDDcuQNmypeGDR080YCoY0c2TYY4GEnSh8AZWC5VWFnh0iVJnWDIhJHkjZ0leXTU8JMokRFIkBh1uNJBjBhLYvSMAXJjRaQXAgzoeaCHQIYRJAgIAECgQSETaQpEAkCW7FZABC6UFUCgDgIFYvvQ0KOHxlqyGciC2MODgtgXUB88oCFgqwBAGY5k+FTHhKe/DLbSeACABg0GlX9k0LDHhN+nkQsnMGBVq+QIgkzAfaoVQOG5ky5ksEuDwCHVYmlrRUOjRQMAkzS4JlCJB1wuDQgQIEu5NoGpD5bj8SyWMlnLk7ds0RRhS/JDxgvEWLnQQA0gsnoA1L3zaYTy4nBWUBoUZdCWB0RstIgwAgedR3o0oIRxisyRgiEpOCLEGZkEAkUZZqSQgggi8MEEFUVU0YUHf/zhAYcfQgDiAR4cEMQiGKWYYkAAOw==)";
        internal static readonly string Base64ArrowUpImage20pxUrl = "url(data:image/gif;base64,R0lGODlhFAAUAPcAAP////v/+/v7+/f39/f79/P39+fr7/P38/v/9/v794KGgvf/+8rO1/f/9+vv787S29vf44aKhtfb49/f5+/v8+Pn6+/z8/Pz88rOyoqOiu/v79fb1/P7+/f7++Pj5/P3+5aalt/j3+fr6/f3+9vb4+/39+Pj49/f39LS2+/z7+Pn776+vtfX387S1+/z932Cfba6ttvb39fX2+vr79Lb4+fn5+fn79/j69/f48rKyoqKipaWlrq+uuPn487OztLS38bK0vPz9/v//87X2/Pz79vj4+Pn5/v7/+vz7+vv887S36quqvf3887Szt/j58bO19vf58rO28bKxsrK0uvv65Kaku/r79LX39fb3+/v63mCfcbK187O19vb2+fr89fX1+vr687X4+fn4+vr86qqqt/j49fb23l9ef///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////yH5BAEAAGgALAAAAAAUABQAAAj/ANEIHIgGjJEKFWYQXDjQhgwWMSBAgSLhyhWGAyW0wGKEShYLFmxMQMGlAkMUDJwUaMCSQIMOBC6UmQKFIIoWRgYkSEBgwAECLgkcEAHEhsAZXJwMCEogx5KlPDsMqPBA4AMSFmAClVJFAYwLDXgSKNDCZNEDHRoQ+LJDxw4FOVIAfVnkIgMNCRocCKFDAY8TOl74kNvTwMUHFgh06BFB8IULNSIoWAF0gAMWaKIEAXohxAkiOcgMKHMCjEvLF7dciOpSCogIMH5W7jBDAhogGpb2ZKuja9zKJUTEQDPFyQWpJzL47aLjTBMiUi3gcIKGRAswDRhrwXBgAOPJBVx4VpGhQSADLBoufPmSAuaBLl+MXNCAg0TD8xoKDCjA/0OBCyk44IRtBInAgAQGuOCCBSWU4IIDIkAAAUZoPKCEEWDMkKENA1JHIRozxIACCg+gIEMZGAUEADs=)";
        internal static readonly string Base64ArrowDownImage20pxUrl = "url(data:image/gif;base64,R0lGODlhFAAUAPcAAP////v/+/v7+/f79/f7+/f39+Pn6+/z8/P399/j59fX30FVfdfb3/P38/v79/Pz8/f/+9vf4/f3+77G0uvr6+/z9+fr79/f4+fn6/Pz99LX387S2+vv7+/v89fb49vb487S1+vv89LS29vf57a+zuvz832Kppqmutff4/v/9+Pj61FhinWGon2Opt/f556qujVJdefn7+vv9666yu/v70lZgt/j61FhhsrO14qWrsLG0s7O187S36auvvP7+2V1msrO2+vr74qartfX4+vr5+Pr89fS201dhvv//8LK1z1Refv3+7K+ypaetsrK0tLb3/f382l1mvP3+87O2+/z70FRfd/j4+/38+fn5zlNdff/987X39LX2+fv76KuwsbK19vb37a+ypaiurK6yjVJcaKqvk1dgvv7/5KassbK0kFReePj5zlJeefv66KuvrK6xv///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////yH5BAEAAHAALAAAAAAUABQAAAj/AOEIHNghAYMhHhIEGciQoQsRIsBccJFgxBANHxoOVABEQwQsVA4c4GAAxQ4NGhXoQBFCAoEBKQbILIBlwwaGYJygaCDz5QAHWn4OoKHBg8AQIBQ86Cmzqc8BHRjEgKOBR4wBBV6waMJzwBsWOQ7INMAAzg6lWMvcMBPmwIQfC4SIdcCh7A4wDpq6qbFgwo0FLfJiPZAADogEQQdoQZBECZksJx74LJDBBlXEP4E++LJgTAgtiSkbMDyCgJYCXkycoPHGQhgTaA68vILF8JMMWF+sJeE2yoIcDwoUKLEGjggQXQrI3Nv3r4mXBaC0GR0EBxihDyawgQFDzAEHBaSEVUhAQ6CHNAaEF6CiY8EMC8IfHFgzdSAIHBgQ6O8yo4iUDA+UgMUFGkFkQwglXIFABRWUQIEBhWkExwc8eLAGBRRggIEKaywk4UAYMKCABx6M4GFDAQEAOw==)";


        public static string namespaceUriDefault = "http://www.w3.org/1999/xhtml";

        public static string UserAgentString = "";


        public static bool HasIEProxySelected = false;

        public static bool IsMethodGetIsNetworkAvailableSeeked = false;

        public static System.Reflection.MethodInfo MethodGetIsNetworkAvailable = null;


        //public static System.Reflection.MethodInfo UrlEncodeMethod = null;
        //public static System.Reflection.MethodInfo UrlDecodeMethod = null;
        //public static System.Reflection.MethodInfo HtmlEncodeMethod = null;
        //public static System.Reflection.MethodInfo HtmlDecodeMethod = null;

        /// <summary>
        /// [CSS Number at DOM Complete] - [CSS Count at BODY]
        /// Difference to enforce css to recaluculation.
        /// </summary>
        public static int CSS_RECALUCURATION_ENFORCE_LIMIT_DIFFERENCE = 1000;

        public static bool KillGoogleShowAds = true;
        public static bool NoRecoddForProhibitScripts = true;




        public static System.Collections.Generic.Dictionary<CHtmlElementType, object> CreateSortedListFromTagTypeArray(CHtmlElementType[] ___ar)
        {
            System.Collections.Generic.Dictionary<CHtmlElementType, object> _srList = new System.Collections.Generic.Dictionary<CHtmlElementType, object>();
            foreach (CHtmlElementType _tg in ___ar)
            {
                _srList[_tg] = null;
            }
            return _srList;
        }
        public static string ReplaceWhiteSpaceCharWith(string s, string _ReplacingString)
        {
            char[] cs = s.ToCharArray();
            System.Text.StringBuilder sb = new StringBuilder();
            int csLen = cs.Length;
            char c = '\0';
            for (int i = 0; i < csLen; i++)
            {
                c = cs[i];
                if (commonHTML.FasterIsWhiteSpaceLimited(c) == false)
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append(_ReplacingString);
                }
            }
            return sb.ToString();
        }
        public static System.Collections.Generic.Dictionary<string, string> CreateDictionaryListFromStringArray(string[] ___strs)
        {
            System.Collections.Generic.Dictionary<string, string> _dicList = new System.Collections.Generic.Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (string _s in ___strs)
            {
                _dicList[_s] = "";
            }
            return _dicList;
        }
        private static System.Collections.Generic.Dictionary<string, Color> createCHtmlColorNamesDictionary()
        {
            System.Collections.Generic.Dictionary<string, Color> list = new System.Collections.Generic.Dictionary<string, Color>();
            list["black"] = Color.FromArgb(0, 0, 0);
            list["silver"] = Color.FromArgb(192, 192, 192);
            list["gray"] = Color.FromArgb(128, 128, 128);
            list["white"] = Color.FromArgb(255, 255, 255);
            list["maroon"] = Color.FromArgb(128, 0, 0);
            list["red"] = Color.FromArgb(255, 0, 0);
            list["purple"] = Color.FromArgb(128, 0, 128);
            list["fuchsia"] = Color.FromArgb(255, 0, 255);
            list["green"] = Color.FromArgb(0, 128, 0);
            list["lime"] = Color.FromArgb(0, 255, 0);
            list["olive"] = Color.FromArgb(128, 128, 0);
            list["yellow"] = Color.FromArgb(255, 255, 0);
            list["navy"] = Color.FromArgb(0, 0, 128);
            list["blue"] = Color.FromArgb(0, 0, 255);
            list["teal"] = Color.FromArgb(0, 128, 128);
            list["aqua"] = Color.FromArgb(0, 255, 255);
            list["aliceblue"] = Color.FromArgb(240, 248, 255);
            list["antiquewhite"] = Color.FromArgb(250, 235, 215);
            list["aqua"] = Color.FromArgb(0, 255, 255);
            list["aquamarine"] = Color.FromArgb(127, 255, 212);
            list["azure"] = Color.FromArgb(240, 255, 255);
            list["beige"] = Color.FromArgb(245, 245, 220);
            list["bisque"] = Color.FromArgb(255, 228, 196);
            list["black"] = Color.FromArgb(0, 0, 0);
            list["blanchedalmond"] = Color.FromArgb(255, 235, 205);
            list["blue"] = Color.FromArgb(0, 0, 255);
            list["blueviolet"] = Color.FromArgb(138, 43, 226);
            list["brown"] = Color.FromArgb(165, 42, 42);
            list["burlywood"] = Color.FromArgb(222, 184, 135);
            list["cadetblue"] = Color.FromArgb(95, 158, 160);
            list["chartreuse"] = Color.FromArgb(127, 255, 0);
            list["chocolate"] = Color.FromArgb(210, 105, 30);
            list["coral"] = Color.FromArgb(255, 127, 80);
            list["cornflowerblue"] = Color.FromArgb(100, 149, 237);
            list["cornsilk"] = Color.FromArgb(255, 248, 220);
            list["crimson"] = Color.FromArgb(220, 20, 60);
            list["cyan"] = Color.FromArgb(0, 255, 255);
            list["darkblue"] = Color.FromArgb(0, 0, 139);
            list["darkcyan"] = Color.FromArgb(0, 139, 139);
            list["darkgoldenrod"] = Color.FromArgb(184, 134, 11);
            list["darkgray"] = Color.FromArgb(169, 169, 169);
            list["darkgreen"] = Color.FromArgb(0, 100, 0);
            list["darkgrey"] = Color.FromArgb(169, 169, 169);
            list["darkkhaki"] = Color.FromArgb(189, 183, 107);
            list["darkmagenta"] = Color.FromArgb(139, 0, 139);
            list["darkolivegreen"] = Color.FromArgb(85, 107, 47);
            list["darkorange"] = Color.FromArgb(255, 140, 0);
            list["darkorchid"] = Color.FromArgb(153, 50, 204);
            list["darkred"] = Color.FromArgb(139, 0, 0);
            list["darksalmon"] = Color.FromArgb(233, 150, 122);
            list["darkseagreen"] = Color.FromArgb(143, 188, 143);
            list["darkslateblue"] = Color.FromArgb(72, 61, 139);
            list["darkslategray"] = Color.FromArgb(47, 79, 79);
            list["darkslategrey"] = Color.FromArgb(47, 79, 79);
            list["darkturquoise"] = Color.FromArgb(0, 206, 209);
            list["darkviolet"] = Color.FromArgb(148, 0, 211);
            list["deeppink"] = Color.FromArgb(255, 20, 147);
            list["deepskyblue"] = Color.FromArgb(0, 191, 255);
            list["dimgray"] = Color.FromArgb(105, 105, 105);
            list["dimgrey"] = Color.FromArgb(105, 105, 105);
            list["dodgerblue"] = Color.FromArgb(30, 144, 255);
            list["firebrick"] = Color.FromArgb(178, 34, 34);
            list["floralwhite"] = Color.FromArgb(255, 250, 240);
            list["forestgreen"] = Color.FromArgb(34, 139, 34);
            list["fuchsia"] = Color.FromArgb(255, 0, 255);
            list["gainsboro"] = Color.FromArgb(220, 220, 220);
            list["ghostwhite"] = Color.FromArgb(248, 248, 255);
            list["gold"] = Color.FromArgb(255, 215, 0);
            list["goldenrod"] = Color.FromArgb(218, 165, 32);
            list["gray"] = Color.FromArgb(128, 128, 128);
            list["green"] = Color.FromArgb(0, 128, 0);
            list["greenyellow"] = Color.FromArgb(173, 255, 47);
            list["grey"] = Color.FromArgb(128, 128, 128);
            list["honeydew"] = Color.FromArgb(240, 255, 240);
            list["hotpink"] = Color.FromArgb(255, 105, 180);
            list["indianred"] = Color.FromArgb(205, 92, 92);
            list["indigo"] = Color.FromArgb(75, 0, 130);
            list["ivory"] = Color.FromArgb(255, 255, 240);
            list["khaki"] = Color.FromArgb(240, 230, 140);
            list["lavender"] = Color.FromArgb(230, 230, 250);
            list["lavenderblush"] = Color.FromArgb(255, 240, 245);
            list["lawngreen"] = Color.FromArgb(124, 252, 0);
            list["lemonchiffon"] = Color.FromArgb(255, 250, 205);
            list["lightblue"] = Color.FromArgb(173, 216, 230);
            list["lightcoral"] = Color.FromArgb(240, 128, 128);
            list["lightcyan"] = Color.FromArgb(224, 255, 255);
            list["lightgoldenrodyellow"] = Color.FromArgb(250, 250, 210);
            list["lightgray"] = Color.FromArgb(211, 211, 211);
            list["lightgreen"] = Color.FromArgb(144, 238, 144);
            list["lightgrey"] = Color.FromArgb(211, 211, 211);
            list["lightpink"] = Color.FromArgb(255, 182, 193);
            list["lightsalmon"] = Color.FromArgb(255, 160, 122);
            list["lightseagreen"] = Color.FromArgb(32, 178, 170);
            list["lightskyblue"] = Color.FromArgb(135, 206, 250);
            list["lightslategray"] = Color.FromArgb(119, 136, 153);
            list["lightslategrey"] = Color.FromArgb(119, 136, 153);
            list["lightsteelblue"] = Color.FromArgb(176, 196, 222);
            list["lightyellow"] = Color.FromArgb(255, 255, 224);
            list["lime"] = Color.FromArgb(0, 255, 0);
            list["limegreen"] = Color.FromArgb(50, 205, 50);
            list["linen"] = Color.FromArgb(250, 240, 230);
            list["magenta"] = Color.FromArgb(255, 0, 255);
            list["maroon"] = Color.FromArgb(128, 0, 0);
            list["mediumaquamarine"] = Color.FromArgb(102, 205, 170);
            list["mediumblue"] = Color.FromArgb(0, 0, 205);
            list["mediumorchid"] = Color.FromArgb(186, 85, 211);
            list["mediumpurple"] = Color.FromArgb(147, 112, 219);
            list["mediumseagreen"] = Color.FromArgb(60, 179, 113);
            list["mediumslateblue"] = Color.FromArgb(123, 104, 238);
            list["mediumspringgreen"] = Color.FromArgb(0, 250, 154);
            list["mediumturquoise"] = Color.FromArgb(72, 209, 204);
            list["mediumvioletred"] = Color.FromArgb(199, 21, 133);
            list["midnightblue"] = Color.FromArgb(25, 25, 112);
            list["mintcream"] = Color.FromArgb(245, 255, 250);
            list["mistyrose"] = Color.FromArgb(255, 228, 225);
            list["moccasin"] = Color.FromArgb(255, 228, 181);
            list["navajowhite"] = Color.FromArgb(255, 222, 173);
            list["navy"] = Color.FromArgb(0, 0, 128);
            list["oldlace"] = Color.FromArgb(253, 245, 230);
            list["olive"] = Color.FromArgb(128, 128, 0);
            list["olivedrab"] = Color.FromArgb(107, 142, 35);
            list["orange"] = Color.FromArgb(255, 165, 0);
            list["orangered"] = Color.FromArgb(255, 69, 0);
            list["orchid"] = Color.FromArgb(218, 112, 214);
            list["palegoldenrod"] = Color.FromArgb(238, 232, 170);
            list["palegreen"] = Color.FromArgb(152, 251, 152);
            list["paleturquoise"] = Color.FromArgb(175, 238, 238);
            list["palevioletred"] = Color.FromArgb(219, 112, 147);
            list["papayawhip"] = Color.FromArgb(255, 239, 213);
            list["peachpuff"] = Color.FromArgb(255, 218, 185);
            list["peru"] = Color.FromArgb(205, 133, 63);
            list["pink"] = Color.FromArgb(255, 192, 203);
            list["plum"] = Color.FromArgb(221, 160, 221);
            list["powderblue"] = Color.FromArgb(176, 224, 230);
            list["purple"] = Color.FromArgb(128, 0, 128);
            list["red"] = Color.FromArgb(255, 0, 0);
            list["rosybrown"] = Color.FromArgb(188, 143, 143);
            list["royalblue"] = Color.FromArgb(65, 105, 225);
            list["saddlebrown"] = Color.FromArgb(139, 69, 19);
            list["salmon"] = Color.FromArgb(250, 128, 114);
            list["sandybrown"] = Color.FromArgb(244, 164, 96);
            list["seagreen"] = Color.FromArgb(46, 139, 87);
            list["seashell"] = Color.FromArgb(255, 245, 238);
            list["sienna"] = Color.FromArgb(160, 82, 45);
            list["silver"] = Color.FromArgb(192, 192, 192);
            list["skyblue"] = Color.FromArgb(135, 206, 235);
            list["slateblue"] = Color.FromArgb(106, 90, 205);
            list["slategray"] = Color.FromArgb(112, 128, 144);
            list["slategrey"] = Color.FromArgb(112, 128, 144);
            list["snow"] = Color.FromArgb(255, 250, 250);
            list["springgreen"] = Color.FromArgb(0, 255, 127);
            list["steelblue"] = Color.FromArgb(70, 130, 180);
            list["tan"] = Color.FromArgb(210, 180, 140);
            list["teal"] = Color.FromArgb(0, 128, 128);
            list["thistle"] = Color.FromArgb(216, 191, 216);
            list["tomato"] = Color.FromArgb(255, 99, 71);
            list["turquoise"] = Color.FromArgb(64, 224, 208);
            list["violet"] = Color.FromArgb(238, 130, 238);
            list["wheat"] = Color.FromArgb(245, 222, 179);
            list["white"] = Color.FromArgb(255, 255, 255);
            list["whitesmoke"] = Color.FromArgb(245, 245, 245);
            list["yellow"] = Color.FromArgb(255, 255, 0);
            list["yellowgreen"] = Color.FromArgb(154, 205, 50);
            return list;
        }
        private static System.Collections.Generic.Dictionary<string, ColorSpec> createCHtmlColorSpecNamesDictionary()
        {
            System.Collections.Generic.Dictionary<string, ColorSpec> list = new System.Collections.Generic.Dictionary<string, ColorSpec>();
            list["black"] = new ColorSpec(0, 0, 0);
            list["silver"] = new ColorSpec(192, 192, 192);
            list["gray"] = new ColorSpec(128, 128, 128);
            list["white"] = new ColorSpec(255, 255, 255);
            list["maroon"] = new ColorSpec(128, 0, 0);
            list["red"] = new ColorSpec(255, 0, 0);
            list["purple"] = new ColorSpec(128, 0, 128);
            list["fuchsia"] = new ColorSpec(255, 0, 255);
            list["green"] = new ColorSpec(0, 128, 0);
            list["lime"] = new ColorSpec(0, 255, 0);
            list["olive"] = new ColorSpec(128, 128, 0);
            list["yellow"] = new ColorSpec(255, 255, 0);
            list["navy"] = new ColorSpec(0, 0, 128);
            list["blue"] = new ColorSpec(0, 0, 255);
            list["teal"] = new ColorSpec(0, 128, 128);
            list["aqua"] = new ColorSpec(0, 255, 255);
            list["aliceblue"] = new ColorSpec(240, 248, 255);
            list["antiquewhite"] = new ColorSpec(250, 235, 215);
            list["aqua"] = new ColorSpec(0, 255, 255);
            list["aquamarine"] = new ColorSpec(127, 255, 212);
            list["azure"] = new ColorSpec(240, 255, 255);
            list["beige"] = new ColorSpec(245, 245, 220);
            list["bisque"] = new ColorSpec(255, 228, 196);
            list["black"] = new ColorSpec(0, 0, 0);
            list["blanchedalmond"] = new ColorSpec(255, 235, 205);
            list["blue"] = new ColorSpec(0, 0, 255);
            list["blueviolet"] = new ColorSpec(138, 43, 226);
            list["brown"] = new ColorSpec(165, 42, 42);
            list["burlywood"] = new ColorSpec(222, 184, 135);
            list["cadetblue"] = new ColorSpec(95, 158, 160);
            list["chartreuse"] = new ColorSpec(127, 255, 0);
            list["chocolate"] = new ColorSpec(210, 105, 30);
            list["coral"] = new ColorSpec(255, 127, 80);
            list["cornflowerblue"] = new ColorSpec(100, 149, 237);
            list["cornsilk"] = new ColorSpec(255, 248, 220);
            list["crimson"] = new ColorSpec(220, 20, 60);
            list["cyan"] = new ColorSpec(0, 255, 255);
            list["darkblue"] = new ColorSpec(0, 0, 139);
            list["darkcyan"] = new ColorSpec(0, 139, 139);
            list["darkgoldenrod"] = new ColorSpec(184, 134, 11);
            list["darkgray"] = new ColorSpec(169, 169, 169);
            list["darkgreen"] = new ColorSpec(0, 100, 0);
            list["darkgrey"] = new ColorSpec(169, 169, 169);
            list["darkkhaki"] = new ColorSpec(189, 183, 107);
            list["darkmagenta"] = new ColorSpec(139, 0, 139);
            list["darkolivegreen"] = new ColorSpec(85, 107, 47);
            list["darkorange"] = new ColorSpec(255, 140, 0);
            list["darkorchid"] = new ColorSpec(153, 50, 204);
            list["darkred"] = new ColorSpec(139, 0, 0);
            list["darksalmon"] = new ColorSpec(233, 150, 122);
            list["darkseagreen"] = new ColorSpec(143, 188, 143);
            list["darkslateblue"] = new ColorSpec(72, 61, 139);
            list["darkslategray"] = new ColorSpec(47, 79, 79);
            list["darkslategrey"] = new ColorSpec(47, 79, 79);
            list["darkturquoise"] = new ColorSpec(0, 206, 209);
            list["darkviolet"] = new ColorSpec(148, 0, 211);
            list["deeppink"] = new ColorSpec(255, 20, 147);
            list["deepskyblue"] = new ColorSpec(0, 191, 255);
            list["dimgray"] = new ColorSpec(105, 105, 105);
            list["dimgrey"] = new ColorSpec(105, 105, 105);
            list["dodgerblue"] = new ColorSpec(30, 144, 255);
            list["firebrick"] = new ColorSpec(178, 34, 34);
            list["floralwhite"] = new ColorSpec(255, 250, 240);
            list["forestgreen"] = new ColorSpec(34, 139, 34);
            list["fuchsia"] = new ColorSpec(255, 0, 255);
            list["gainsboro"] = new ColorSpec(220, 220, 220);
            list["ghostwhite"] = new ColorSpec(248, 248, 255);
            list["gold"] = new ColorSpec(255, 215, 0);
            list["goldenrod"] = new ColorSpec(218, 165, 32);
            list["gray"] = new ColorSpec(128, 128, 128);
            list["green"] = new ColorSpec(0, 128, 0);
            list["greenyellow"] = new ColorSpec(173, 255, 47);
            list["grey"] = new ColorSpec(128, 128, 128);
            list["honeydew"] = new ColorSpec(240, 255, 240);
            list["hotpink"] = new ColorSpec(255, 105, 180);
            list["indianred"] = new ColorSpec(205, 92, 92);
            list["indigo"] = new ColorSpec(75, 0, 130);
            list["ivory"] = new ColorSpec(255, 255, 240);
            list["khaki"] = new ColorSpec(240, 230, 140);
            list["lavender"] = new ColorSpec(230, 230, 250);
            list["lavenderblush"] = new ColorSpec(255, 240, 245);
            list["lawngreen"] = new ColorSpec(124, 252, 0);
            list["lemonchiffon"] = new ColorSpec(255, 250, 205);
            list["lightblue"] = new ColorSpec(173, 216, 230);
            list["lightcoral"] = new ColorSpec(240, 128, 128);
            list["lightcyan"] = new ColorSpec(224, 255, 255);
            list["lightgoldenrodyellow"] = new ColorSpec(250, 250, 210);
            list["lightgray"] = new ColorSpec(211, 211, 211);
            list["lightgreen"] = new ColorSpec(144, 238, 144);
            list["lightgrey"] = new ColorSpec(211, 211, 211);
            list["lightpink"] = new ColorSpec(255, 182, 193);
            list["lightsalmon"] = new ColorSpec(255, 160, 122);
            list["lightseagreen"] = new ColorSpec(32, 178, 170);
            list["lightskyblue"] = new ColorSpec(135, 206, 250);
            list["lightslategray"] = new ColorSpec(119, 136, 153);
            list["lightslategrey"] = new ColorSpec(119, 136, 153);
            list["lightsteelblue"] = new ColorSpec(176, 196, 222);
            list["lightyellow"] = new ColorSpec(255, 255, 224);
            list["lime"] = new ColorSpec(0, 255, 0);
            list["limegreen"] = new ColorSpec(50, 205, 50);
            list["linen"] = new ColorSpec(250, 240, 230);
            list["magenta"] = new ColorSpec(255, 0, 255);
            list["maroon"] = new ColorSpec(128, 0, 0);
            list["mediumaquamarine"] = new ColorSpec(102, 205, 170);
            list["mediumblue"] = new ColorSpec(0, 0, 205);
            list["mediumorchid"] = new ColorSpec(186, 85, 211);
            list["mediumpurple"] = new ColorSpec(147, 112, 219);
            list["mediumseagreen"] = new ColorSpec(60, 179, 113);
            list["mediumslateblue"] = new ColorSpec(123, 104, 238);
            list["mediumspringgreen"] = new ColorSpec(0, 250, 154);
            list["mediumturquoise"] = new ColorSpec(72, 209, 204);
            list["mediumvioletred"] = new ColorSpec(199, 21, 133);
            list["midnightblue"] = new ColorSpec(25, 25, 112);
            list["mintcream"] = new ColorSpec(245, 255, 250);
            list["mistyrose"] = new ColorSpec(255, 228, 225);
            list["moccasin"] = new ColorSpec(255, 228, 181);
            list["navajowhite"] = new ColorSpec(255, 222, 173);
            list["navy"] = new ColorSpec(0, 0, 128);
            list["oldlace"] = new ColorSpec(253, 245, 230);
            list["olive"] = new ColorSpec(128, 128, 0);
            list["olivedrab"] = new ColorSpec(107, 142, 35);
            list["orange"] = new ColorSpec(255, 165, 0);
            list["orangered"] = new ColorSpec(255, 69, 0);
            list["orchid"] = new ColorSpec(218, 112, 214);
            list["palegoldenrod"] = new ColorSpec(238, 232, 170);
            list["palegreen"] = new ColorSpec(152, 251, 152);
            list["paleturquoise"] = new ColorSpec(175, 238, 238);
            list["palevioletred"] = new ColorSpec(219, 112, 147);
            list["papayawhip"] = new ColorSpec(255, 239, 213);
            list["peachpuff"] = new ColorSpec(255, 218, 185);
            list["peru"] = new ColorSpec(205, 133, 63);
            list["pink"] = new ColorSpec(255, 192, 203);
            list["plum"] = new ColorSpec(221, 160, 221);
            list["powderblue"] = new ColorSpec(176, 224, 230);
            list["purple"] = new ColorSpec(128, 0, 128);
            list["red"] = new ColorSpec(255, 0, 0);
            list["rosybrown"] = new ColorSpec(188, 143, 143);
            list["royalblue"] = new ColorSpec(65, 105, 225);
            list["saddlebrown"] = new ColorSpec(139, 69, 19);
            list["salmon"] = new ColorSpec(250, 128, 114);
            list["sandybrown"] = new ColorSpec(244, 164, 96);
            list["seagreen"] = new ColorSpec(46, 139, 87);
            list["seashell"] = new ColorSpec(255, 245, 238);
            list["sienna"] = new ColorSpec(160, 82, 45);
            list["silver"] = new ColorSpec(192, 192, 192);
            list["skyblue"] = new ColorSpec(135, 206, 235);
            list["slateblue"] = new ColorSpec(106, 90, 205);
            list["slategray"] = new ColorSpec(112, 128, 144);
            list["slategrey"] = new ColorSpec(112, 128, 144);
            list["snow"] = new ColorSpec(255, 250, 250);
            list["springgreen"] = new ColorSpec(0, 255, 127);
            list["steelblue"] = new ColorSpec(70, 130, 180);
            list["tan"] = new ColorSpec(210, 180, 140);
            list["teal"] = new ColorSpec(0, 128, 128);
            list["thistle"] = new ColorSpec(216, 191, 216);
            list["tomato"] = new ColorSpec(255, 99, 71);
            list["turquoise"] = new ColorSpec(64, 224, 208);
            list["violet"] = new ColorSpec(238, 130, 238);
            list["wheat"] = new ColorSpec(245, 222, 179);
            list["white"] = new ColorSpec(255, 255, 255);
            list["whitesmoke"] = new ColorSpec(245, 245, 245);
            list["yellow"] = new ColorSpec(255, 255, 0);
            list["yellowgreen"] = new ColorSpec(154, 205, 50);
            return list;
        }
        public static SortedList CreateCHtmlAttributesNamesDefaultValueIsString()
        {
            SortedList _srList = new SortedList(StringComparer.Ordinal);
            _srList.Add("href", null);
            _srList.Add("id", null);
            _srList.Add("src", null);
            _srList.Add("class", null);
            _srList.Add("className", null);
            _srList.Add("name", null);
            _srList.Add("codebase", null);
            _srList.Add("classid", null);
            _srList.Add("style", null);
            _srList.Add("value", null);
            _srList.Add("text", null);
            _srList.Add("alt", null);
            _srList.Add("type", null);
            _srList.Add("rel", null);
            _srList.Add("title", null);
            return _srList;
        }
        public static Interfaces.IMultiversalWindow createIFrameMultiversalWindow(Interfaces.IMultiversalWindow ___parentWindow, CHtmlDocument ___doc, CHtmlElement ___ownerIframeElement)
        {
            if (___parentWindow == null)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 1)
                {
                    commonLog.LogEntry("BUBUG!!!  createIFrameMultiversalWindow entered with no parentWindow");
                }
                return null;
            }
            CHtmlMultiversalWindow multiWindow = new CHtmlMultiversalWindow(___parentWindow, false, IMultiversalWindowType.NormalWindow);
            if (___doc != null)
            {
                multiWindow.___parentDocumentWeakReference = new WeakReference(___doc, false);
            }
            if (___ownerIframeElement != null)
            {
                multiWindow.___ownerElementWeakReference = new WeakReference(___ownerIframeElement, false);
                if (string.IsNullOrEmpty(___ownerIframeElement.___id) == false)
                {
                    multiWindow.___id = string.Copy(___ownerIframeElement.___id);
                }
                if (string.IsNullOrEmpty(___ownerIframeElement.___name) == false)
                {
                    multiWindow.___name = ___ownerIframeElement.___name;
                }
            }
            if (___parentWindow != null)
            {

            }
            // create Empty document to multiwindow. some script may access this document.
            multiWindow.___document = new CHtmlDocument(CHtmlDomModeType.HTMLDOM);
            multiWindow.___document.___IsMultiversalDocument = true;
            // multiWindow.___document.___MultiversalWindow = multiWindow;
            // multiWindow.___document.___MultiversalWindowWeakReference = new WeakReference(multiWindow, false);
            return multiWindow;
        }


        private static void RemoveTagNameFromTagStack(System.Collections.Generic.List<string> tagStackList, string __CurTag)
        {
            // May be exists in stack
            int FoundPos = -1;
            for (int s = tagStackList.Count - 1; s >= 0; s--)
            {
                string ___StackTag = tagStackList[s] as string;
                if (string.Equals(___StackTag, __CurTag, StringComparison.Ordinal) == true)
                {
                    FoundPos = s;
                    break;
                }
            }
            if (FoundPos != -1)
            {
                tagStackList.RemoveRange(FoundPos, tagStackList.Count - FoundPos);
            }
        }
        /// <summary>
        /// Create Quick Children Node List (Designed for CSS Lookup)
        /// </summary>
        /// <param name="doc">Document</param>
        /// <param name="element">Static Element</param>
        /// <returns></returns>
        public static CHtmlCollection CreateElementChildrenQuickList(CHtmlDocument doc, CHtmlElement element)
        {
            CHtmlCollection quickElements = new CHtmlCollection();
            quickElements.___CollectionType = CHtmlHTMLCollectionType.ElementCSSQuickChildNodes;
            System.Text.StringBuilder sbDirectChildTags = null;
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                sbDirectChildTags = new StringBuilder();
            }
            try
            {
                string ___curHTML = doc.___HtmlBuilder.ToString();
                string ___ClosingTag = "</" + element.tagName + ">";
                string ___StartTag = "<" + element.tagName;
                int PossibleEndPos = ___curHTML.IndexOf(___ClosingTag, element.___TagOpenEndPosition, StringComparison.OrdinalIgnoreCase);

                if (PossibleEndPos == -1)
                {
                    return quickElements;
                }
                else
                {
                    System.Text.StringBuilder sbHTML = doc.___HtmlBuilder;
                    int PossibleIdenticalTagPos = ___curHTML.IndexOf(___StartTag, element.___TagOpenEndPosition, PossibleEndPos - element.___TagOpenEndPosition, StringComparison.OrdinalIgnoreCase);
                    // Possible Closing Tag Found.
                    // Now Create Child Tag List
                    char ___QuoteStartChar = '\0';
                    bool ___IsQuoting = false;
                    char c = '\0';
                    int Mode = 0;
                    System.Text.StringBuilder __sbTagName = null;
                    System.Collections.Generic.List<string> tagStackList = new System.Collections.Generic.List<string>();
                    int ___CurrentOpenCloseTagPosition = -1;
                    int ___TagNameStartPostion = -1;
                    int sbHTMLLen = sbHTML.Length;
                    for (int i = element.___TagOpenEndPosition + 1; i < sbHTMLLen; i++)
                    {
                        c = sbHTML[i];
                        switch (c)
                        {
                            case '<':
                                if (___IsQuoting == false)
                                {
                                    Mode = 1;
                                    __sbTagName = null;
                                    __sbTagName = new StringBuilder();
                                    ___CurrentOpenCloseTagPosition = i;
                                    if (i + 1 < sbHTMLLen)
                                    {
                                        if (char.IsLetterOrDigit(sbHTML[i + 1]) == true)
                                        {
                                            ___TagNameStartPostion = i;
                                        }
                                    }
                                    continue;
                                }
                                break;
                            case '>':
                                if (___IsQuoting == false)
                                {
                                    Mode = 0;
                                    if (__sbTagName != null)
                                    {
                                        int ClosingMode = -1;
                                        if (__sbTagName.Length != 0)
                                        {
                                            if (__sbTagName[0] == '/')
                                            {
                                                __sbTagName.Remove(0, 1);
                                                ClosingMode = 1; // ex. </DIV>
                                            }
                                            else
                                            {
                                                if (sbHTML[i - 1] == '/')
                                                {
                                                    ClosingMode = 2; // ex <div dsafdjashfda/>
                                                }

                                            }
                                            string __CurTag = __sbTagName.ToString();
                                            CHtmlElementType __CurTagType = GetTagNameType(__CurTag);
                                            if (ClosingMode == -1)
                                            {
                                                if (__CurTagType == CHtmlElementType.P)
                                                {
                                                    RemoveTagNameFromTagStack(tagStackList, __CurTag);
                                                    if (tagStackList.Count == 0)
                                                    {
                                                        if (sbDirectChildTags != null)
                                                        {
                                                            sbDirectChildTags.Append(__CurTag);
                                                            sbDirectChildTags.Append(',');
                                                        }
                                                    }
                                                    CHtmlElement quickNode = new CHtmlElement();
                                                    quickNode.___SetTagNameOnly(__CurTag);
                                                    quickNode.___elementTagType = __CurTagType;
                                                    quickNode.___TagOpenStartPosition = ___TagNameStartPostion;
                                                    quickNode.___TagCloseStartPosition = ___CurrentOpenCloseTagPosition;
                                                    quickNode.___TagCloseEndPosition = i;
                                                    quickNode.___IsElementCSSQuickLookup = true;
                                                    quickElements.Add(quickNode);
                                                }
                                                else
                                                {
                                                    // May be immediateClosingTag
                                                    if (elementTagTypesCanEndWithNoSlashWithoutAnyFollowingInfoSortedList.ContainsKey(__CurTagType) == true)
                                                    {
                                                        ClosingMode = 2;
                                                    }
                                                }


                                            }

                                            if (ClosingMode == -1)
                                            {
                                                tagStackList.Add(__sbTagName.ToString());
                                            }
                                            else
                                            {
                                                if (ClosingMode == 1)
                                                {
                                                    if (tagStackList.Count != 0)
                                                    {
                                                        RemoveTagNameFromTagStack(tagStackList, __CurTag);
                                                    }
                                                    else
                                                    {
                                                        goto ResultReturnPhase;
                                                    }
                                                }
                                                else if (ClosingMode == 2)
                                                {
                                                    // DO Nothing

                                                }

                                            }
                                            if (ClosingMode != -1 && tagStackList.Count == 0)
                                            {
                                                // Okay Stack is clear. it is may be top node
                                                if (sbDirectChildTags != null)
                                                {
                                                    sbDirectChildTags.Append(__CurTag);
                                                    sbDirectChildTags.Append(',');
                                                }
                                                CHtmlElement quickNode = new CHtmlElement();
                                                quickNode.___SetTagNameOnly(__CurTag);
                                                quickNode.___elementTagType = __CurTagType;
                                                quickNode.___TagOpenStartPosition = ___TagNameStartPostion;
                                                quickNode.___TagCloseStartPosition = ___CurrentOpenCloseTagPosition;
                                                quickNode.___TagCloseEndPosition = i;
                                                quickNode.___IsElementCSSQuickLookup = true;
                                                quickElements.Add(quickNode);

                                            }
                                        }
                                    }
                                    continue;
                                }
                                break;
                            case '\'':
                            case '\"':
                                if (___QuoteStartChar == '\0')
                                {
                                    ___QuoteStartChar = c;
                                    ___IsQuoting = true;
                                }
                                else if (c == ___QuoteStartChar)
                                {
                                    if (___curHTML[i - 1] != '\\')
                                    {
                                        ___QuoteStartChar = '\0';
                                        ___IsQuoting = false;
                                    }
                                }
                                break;
                            case ' ':
                            case '\t':
                            case '\v':
                            case '\r':
                            case '\n':
                                if (Mode == 1)
                                {
                                    Mode = 0;
                                    continue;
                                }
                                break;
                        }
                        if (Mode == 1)
                        {
                            if (__sbTagName != null)
                            {
                                if (c > 'a' && c < 'z')
                                {
                                    __sbTagName.Append(FasterToUpper(c));
                                }
                                else
                                {
                                    __sbTagName.Append(c);
                                }
                            }

                        }
                        if (PossibleIdenticalTagPos == -1 && i > PossibleEndPos)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("CreateElementChildrenQuickList Error", ex);
                }
            }
        ResultReturnPhase:
            if (commonLog.LoggingEnabled)
            {
                if (sbDirectChildTags == null)
                {
                    commonLog.LogEntry("CreateElementChildrenQuickList created {0} quick childrens in \'{1}\'", quickElements.Count, element);
                }
                else
                {
                    commonLog.LogEntry("CreateElementChildrenQuickList created {0} quick childrens in \'{1}\' : {2}", quickElements.Count, element, sbDirectChildTags.ToString());
                }
            }
            return quickElements;
        }
        #region IntHandler
        public delegate int IntHandler(object node, int defaultValue);
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, IntHandler> ___inetgerObjectTypeSwitcher = createIntWrapSwitcher();
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, IntHandler> createIntWrapSwitcher()
        {
            System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, IntHandler> list = new System.Collections.Generic.Dictionary<RuntimeTypeHandle, IntHandler>();


            // numeric type is below
            list[typeof(double).TypeHandle] = new IntHandler(___intNonConverter);
            // list[typeof(java.lang.Int).TypeHandle] = new  IntHandler( JavaTypeConverter.javaDouleConverter);
            list[typeof(int).TypeHandle] = new IntHandler(___intConvertFromInt);
            list[typeof(System.Int32).TypeHandle] = new IntHandler(___intConvertFromInt);
            list[typeof(uint).TypeHandle] = new IntHandler(___intConvertFromUInt);
            list[typeof(short).TypeHandle] = new IntHandler(___intConvertShort);
            list[typeof(long).TypeHandle] = new IntHandler(___intConvertLong);
            list[typeof(float).TypeHandle] = new IntHandler(___intConvertFromFloat);
            list[typeof(System.Int16).TypeHandle] = new IntHandler(___intConvertFromInt);
            list[typeof(Int32).TypeHandle] = new IntHandler(___intConvertFromInt);
            list[typeof(Int64).TypeHandle] = new IntHandler(___intConvertFromInt64);
            list[typeof(ulong).TypeHandle] = new IntHandler(___intConvertFromUInt);
            list[typeof(bool).TypeHandle] = new IntHandler(___intConvertFromBoolean);
            list[typeof(ushort).TypeHandle] = new IntHandler(___intConvertFromUshort);
            list[typeof(byte).TypeHandle] = new IntHandler(___intConvertFromByte);
            list[typeof(sbyte).TypeHandle] = new IntHandler(___intConvertFromSByte);
            //list[typeof(System.Decimal).TypeHandle] = new  IntHandler( JavaTypeConverter.decimalConverter);
            //ist[typeof(System.IntPtr).TypeHandle] = new  IntHandler( JavaTypeConverter.intPtrConverter);
            //list[typeof(System.UIntPtr).TypeHandle] = new  IntHandler( JavaTypeConverter.uIntPtrConverter);
            return list;
        }
        #endregion
        #region intConverter
        public static int ___intNonConverter(object o, int defaultValue)
        {
            return (int)commonHTML.GetDoubleFromObject(o, defaultValue);
        }
        public static int ___intConvertFromInt(object o, int defaultValue)
        {
            return (int)commonHTML.GetDoubleFromObject(o, defaultValue);
        }

        public static int ___intConvertFromFloat(object o, int defaultValue)
        {
            return (int)commonHTML.GetDoubleFromObject(o, defaultValue);
        }
        public static int ___intConvertFromUInt(object o, int defaultValue)
        {
            return (int)commonHTML.GetDoubleFromObject(o, defaultValue);
        }
        public static int ___intConvertFromInt64(object o, int defaultValue)
        {
            return (int)commonHTML.GetDoubleFromObject(o, defaultValue);
        }
        public static int ___intConvertShort(object o, int defaultValue)
        {
            return (int)commonHTML.GetDoubleFromObject(o, defaultValue);
        }
        public static int ___intConvertFromUshort(object o, int defaultValue)
        {
            return (int)commonHTML.GetDoubleFromObject(o, defaultValue);
        }
        public static int ___intConvertLong(object o, int defaultValue)
        {
            return (int)commonHTML.GetDoubleFromObject(o, defaultValue);
        }
        public static int ___intConvertFromSByte(object o, int defaultValue)
        {
            return (int)commonHTML.GetDoubleFromObject(o, defaultValue);
        }
        public static int ___intConvertFromByte(object o, int defaultValue)
        {

            return (int)commonHTML.GetDoubleFromObject(o, defaultValue);
        }

        public static int ___intConvertFromBoolean(object o, int defaultValue)
        {
            bool b = ((Boolean)o);
            if (b == true)
                return (int)1;
            else
                return (int)0;
        }
        #endregion





        public static int GetIntFromObject(object ___o, int ___defaultValue)
        {
            if (___o == null)
                return 0;
            // This Section is requried because we frequently calls rhino objects 

            int ___defaultInt = (int)___defaultValue;
            int resultInt = 0;
            IntHandler handler;
            if (___inetgerObjectTypeSwitcher.TryGetValue(___o.GetType().TypeHandle, out handler) == true)
            {
                return handler(___o, ___defaultValue);
            }
            else
            {
                try
                {

                    string strIntValue = commonHTML.GetStringValue(___o);
                    if (string.IsNullOrEmpty(strIntValue) == false)
                    {
                        resultInt = (int)GetDoubleValueFromString(strIntValue, ___defaultInt, -1);
                        return resultInt;
                    }



                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                    {
                        commonLog.LogEntry("GetIntFromObject {0} {1}", ex.Message, ___o);
                    }
                    resultInt = ___defaultInt;
                }
            }

            return resultInt;
        }
        /// <summary>
        /// Checks value is null or undefined
        /// </summary>
        /// <param name="___o"></param>
        /// <returns></returns>
        public static bool isObjectNullOrUndefined(object ___o)
        {
            if (___o == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #region doubleConverter
        public static double ___doubleNonConverter(object o)
        {
            return (double)o;
        }
        public static double ___doubleConvertFromDouble(object o)
        {
            return (double)o;
        }




        public static double ___doubleConvertFromInt(object o)
        {
            return (double)((int)o);
        }
        public static double ___doubleConvertFromFloat(object o)
        {
            return (double)((float)o);
        }
        public static double ___doubleConvertFromUInt(object o)
        {
            return (double)((uint)o);
        }
        public static double ___doubleConvertFromInt64(object o)
        {
            return (double)((int)o);
        }
        public static double ___doubleConvertShort(object o)
        {
            return (double)((short)o);
        }
        public static double ___doubleConvertFromUshort(object o)
        {
            return (double)((ushort)o);
        }
        public static double ___doubleConvertLong(object o)
        {
            return (double)((long)o);
        }
        public static double ___doubleConvertFromSByte(object o)
        {
            return (double)((sbyte)o);
        }
        public static double ___doubleConvertRhinoUndefined(object defaultValue)
        {
            return (double)defaultValue;
        }
        public static double ___doubleConvertFromByte(object o)
        {
            return (double)((byte)o);
        }

        public static double ___doubleConvertFromBoolean(object o)
        {
            bool b = ((Boolean)o);
            if (b == true)
                return (double)1;
            else
                return (double)0;
        }

        #endregion

        public static double GetDoubleFromObject(object ___o, int ___defaultValue)
        {
            if (___o == null)
                return 0;

            switch (___o)
            {

                case NiL.JS.Core.JSValue nilJsValue:
                    if (nilJsValue.ValueType == NiL.JS.Core.JSValueType.Double)
                    {
                        return (double)nilJsValue.Value;
                    }
                    else if (nilJsValue.ValueType == NiL.JS.Core.JSValueType.Function)
                    {
                        return 1000;
                    }
                    break;
                case System.Double doubleValue:
                    return doubleValue;
                case System.Int64 intValue:
                    return (double)intValue;
                case System.Int32 int32Value:
                    return (double)int32Value;
                case float floatValue:
                    return (double)floatValue;

                    break;
                case String strDoubleStr:
                    double resultValue = 0;
                    if (double.TryParse(strDoubleStr, out resultValue))
                    {
                        return resultValue;
                    }
                    break;


            }
            return ___defaultValue;

        }


        public static bool IsUrlImageData(string _Url, ref string ImageHeader, ref string DataString)
        {
            System.Text.StringBuilder sbUrl = new StringBuilder(_Url);
            if (_Url.StartsWith("url(", StringComparison.Ordinal) == true || _Url.StartsWith("data:", StringComparison.Ordinal) == true)
            {
                if (_Url.StartsWith("url(", StringComparison.Ordinal) == true)
                {
                    sbUrl.Remove(0, 4);
                }
                while (true)
                {
                    if (sbUrl[0] == ' ')
                    {
                        sbUrl.Remove(0, 1);
                    }
                    else
                    {
                        break;
                    }
                }
                while (true)
                {
                    if (sbUrl.Length > 0 && (sbUrl[sbUrl.Length - 1] == '\r' || sbUrl[sbUrl.Length - 1] == '\n' || sbUrl[sbUrl.Length - 1] == ' ' || sbUrl[sbUrl.Length - 1] == ')'))
                    {
                        sbUrl.Remove(sbUrl.Length - 1, 1);
                    }
                    else
                    {
                        break;
                    }
                }

                if (sbUrl.Length > 5 && sbUrl[0] == 'd' && sbUrl[1] == 'a' && sbUrl[2] == 't' && sbUrl[3] == 'a' && sbUrl[4] == ':')
                {
                    sbUrl.Remove(0, 5);
                    System.Text.StringBuilder sbHeader = new StringBuilder();
                    System.Text.StringBuilder sbData = new StringBuilder();
                    bool IsImageHeader = true;
                    int sbUrlLen = sbUrl.Length;
                    for (int i = 0; i < sbUrlLen; i++)
                    {
                        char c = sbUrl[i];
                        if (c == ',')
                        {
                            IsImageHeader = false;
                            continue;
                        }
                        if (IsImageHeader)
                        {
                            sbHeader.Append(c);
                        }
                        else
                        {
                            sbData.Append(c);
                        }
                    }
                    ImageHeader = sbHeader.ToString();
                    DataString = sbData.ToString();
                    return true;
                }
                else
                {

                }
            }
            return false;
        }


        public static bool IsLayoutTag(string TagName)
        {
            if (TagsForLayoutSortedList.ContainsKey(TagName) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetAbsoluteUrlFromCHtmlStyleElementUrlString(string pageUrl, string optionalUrl, string _url)
        {
            if (_url.Length == 0)
                return "";
            char cFirst = _url[0];
            int _uLenLastMinus = -1;
            if (cFirst == 'h')
            {
                if (_url.StartsWith("http:", StringComparison.Ordinal) == true || _url.StartsWith("https:", StringComparison.Ordinal) == true)
                {
                    if (_url.Length > 0 && _url[_url.Length - 1] == ')')
                    {
                        _url = _url.Remove(_url.Length - 1, 1);
                    }
                    if (IsCharWhiteSpaceLimited(_url[_url.Length - 1]))
                    {
                        _url = _url.Trim();
                    }
                    _uLenLastMinus = _url.Length - 1;
                    if (_uLenLastMinus > 0 && (_url[_uLenLastMinus] == '\'' || _url[_uLenLastMinus] == '\"'))
                    {
                        _url = _url.Substring(0, _uLenLastMinus);
                    }
                    return _url;
                }
            }
            if (cFirst == 'u' || cFirst == 'U')
            {
                if (_url.StartsWith("url(", StringComparison.OrdinalIgnoreCase) == true)
                {
                    _url = _url.Remove(0, 4);
                }
            }
            if (_url.Length > 0 && _url[_url.Length - 1] == ')')
            {
                _url = _url.Remove(_url.Length - 1, 1);
            }
            if (IsCharWhiteSpaceLimited(_url[_url.Length - 1]))
            {
                _url = _url.Trim();
            }
            _uLenLastMinus = _url.Length - 1;
            if (_uLenLastMinus > 0 && (_url[_uLenLastMinus] == '\'' || _url[_uLenLastMinus] == '\"'))
            {
                _url = _url.Substring(0, _uLenLastMinus);
            }
            return GetAbsoluteUri(pageUrl, optionalUrl, _url);
        }
        public static string GetAbsoluteUrlFromCHtmlStyleElementUrlString(Uri baseUrl, string _url)
        {

            if (_url.StartsWith("url(", StringComparison.Ordinal) == true)
            {
                _url = _url.Remove(0, 4);
            }
            if (_url.Length > 0 && _url[_url.Length - 1] == ')')
            {
                _url = _url.Remove(_url.Length - 1, 1);
            }
            return GetAbsoluteUri(baseUrl, _url);
        }

        public static string ___convertNullToEmpty(string ___value)
        {
            if (___value == null)
                return "";
            return ___value;
        }
        public static string ___convertCharToString(char ___value)
        {
            if ((int)___value < 12)
                return "";
            return ___value.ToString();
        }



        public static string GetStringFromAmpsandString(string s)
        {
            System.Text.StringBuilder sb = new StringBuilder(s);
            System.Text.StringBuilder sbNew = new StringBuilder();
            int sbLen = sb.Length;
            for (int i = 0; i < sbLen; i++)
            {
                if (sb[i] == '&')
                {
                    int _LookupCharMax = 16;
                    System.Text.StringBuilder sbSpecial = new System.Text.StringBuilder();
                    for (int _Lookup = i; _Lookup < sbLen; _Lookup++)
                    {
                        sbSpecial.Append(sb[_Lookup]);
                        if (sbSpecial.Length > 0 && sbSpecial[sbSpecial.Length - 1] == ';')
                        {
                            char indexChar = GetHTMLCharStringHTMLString(sbSpecial.ToString());
                            sbNew.Append(indexChar);
                            i = _Lookup;
                            goto NextChar;
                        }
                        if (_Lookup - i >= _LookupCharMax)
                        {
                            break;
                        }
                    }
                }
                sbNew.Append(sb[i]);
            NextChar:
                if (true) { }
                ;
            }
            return sbNew.ToString();
        }
        public static string GetNormalHtmlValueFromAmpsandStringValue(System.Text.StringBuilder sb)
        {
            System.Text.StringBuilder sbNew = new StringBuilder();
            int sbLen = sb.Length;
            try
            {
                for (int i = 0; i < sbLen; i++)
                {
                    char c = sb[i];
                    if (c != '&')
                    {
                        sbNew.Append(c);
                    }
                    else
                    {
                        System.Text.StringBuilder sbSymbol = new StringBuilder();
                        bool __IsSymbolReplaced = false;
                        try
                        {
                            for (int n = i; n < i + 15; n++)
                            {
                                if (n >= sb.Length)
                                {
                                    break;
                                }
                                char nc = sb[n];
                                if (nc == ';')
                                {
                                    sbSymbol.Append(nc);
                                    sbNew.Append(GetHTMLCharStringHTMLString(sbSymbol.ToString()));
                                    i = n;
                                    __IsSymbolReplaced = true;
                                    break;
                                }
                                else if (n > i && nc == '&' || nc == '=' || nc == ' ')
                                {
                                    i = n - 1;
                                    __IsSymbolReplaced = false;
                                    break;
                                }
                                else
                                {
                                    sbSymbol.Append(nc);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                            {
                                commonLog.LogEntry("GetNormalHtmlValueFromAmpsandStringValue", ex);
                            }
                        }
                        if (__IsSymbolReplaced == false)
                        {
                            sbNew.Append(sbSymbol.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("GetNormalHtmlValueFromAmpsandStringValue", ex);
                }
                sbNew = null;
                sbNew = new StringBuilder(sb.ToString());
            }
            return sbNew.ToString();
        }

        public static int GetIconIndexByTagName(string tagName)
        {
            switch (tagName)
            {
                case "html":
                    return 93;

                case "head":
                    return 94;
                case "body":
                    return 95;
                case "br":
                    return 11;
                case "div":
                case "span":
                    return 44;
                case "table":
                case "caption":
                case "td":
                case "tbody":
                case "tr":
                case "th":
                    return 91;
                case "dd":
                case "dt":
                    return 16;
                case "ol":
                case "ul":
                case "li":
                    return 18;
                case "meta":
                case "title":
                case "noscript":
                case "mailto":
                    return 41;
                case "link":
                case "style":
                    return 60;
                case "embed":
                case "object":
                case "applet":
                case "param":
                    return 24;
                case "img":
                    return 85;
                case "a":
                    return 86;
                case "input":
                case "button":
                    return 87;
                case "form":
                    return 88;
                case "p":
                case "pre":
                case "code":
                case "b":
                case "strong":
                case "small":
                case "font":
                case "u":
                case "i":
                    return 90;
                case "h1":
                case "h2":
                case "h3":
                case "h4":
                case "h5":
                case "h6":
                case "h7":
                case "h8":
                    return 71;
                case "iframe":
                    return 92;
                case "script":
                    return 98;
                default:
                    return 76;
            }
        }
        public static int GetIconIndexByTagType(CHtmlElementType tagType)
        {
            switch (tagType)
            {
                case CHtmlElementType.HTML:
                    return 93;
                case CHtmlElementType.HEAD:
                    return 94;
                case CHtmlElementType.BODY:
                    return 95;

                case CHtmlElementType.BR:
                    return 11;
                case CHtmlElementType.DIV:
                case CHtmlElementType.SPAN:
                    return 44;
                case CHtmlElementType.TABLE:
                case CHtmlElementType.CAPTION:
                case CHtmlElementType.TR:
                case CHtmlElementType.TD:
                case CHtmlElementType.TH:
                case CHtmlElementType.THEAD:
                case CHtmlElementType.TFOOT:
                case CHtmlElementType.TBODY:
                    return 91;
                case CHtmlElementType.DD:
                case CHtmlElementType.DT:

                    return 16;
                case CHtmlElementType.OL:
                case CHtmlElementType.UL:
                case CHtmlElementType.LI:

                    return 18;
                case CHtmlElementType.META:
                case CHtmlElementType.TITLE:
                case CHtmlElementType.NOSCRIPT:
                case CHtmlElementType.COMMENT:
                    return 41;
                case CHtmlElementType.EMBED:
                case CHtmlElementType.OBJECT:
                case CHtmlElementType.APPLET:
                case CHtmlElementType.PARAM:
                    return 24;
                case CHtmlElementType.IMG:
                case CHtmlElementType.IMAGE:
                    return 85;
                case CHtmlElementType.A:
                    return 86;
                case CHtmlElementType.INPUT:
                case CHtmlElementType.BUTTON:
                case CHtmlElementType.TEXTAREA:
                    return 87;
                case CHtmlElementType.FORM:
                    return 88;
                case CHtmlElementType.P:
                case CHtmlElementType.PRE:
                case CHtmlElementType.CODE:
                case CHtmlElementType.B:
                case CHtmlElementType.STRONG:
                case CHtmlElementType.FONT:
                case CHtmlElementType.U:
                case CHtmlElementType.I:
                case CHtmlElementType.TT:
                    return 90;
                case CHtmlElementType.H1:
                case CHtmlElementType.H2:
                case CHtmlElementType.H3:
                case CHtmlElementType.H4:
                case CHtmlElementType.H5:
                case CHtmlElementType.H6:
                case CHtmlElementType.H7:

                    return 71;
                case CHtmlElementType.IFRAME:
                    return 92;
                case CHtmlElementType.LINK:
                    return 96;
                case CHtmlElementType.STYLE:
                    return 97;
                case CHtmlElementType.SCRIPT:
                    return 99;
                case CHtmlElementType._ITEXT:
                case CHtmlElementType._IDRAW:
                    return 101;
                case CHtmlElementType.SVG:
                    return 103;
                case CHtmlElementType.CANVAS:
                    return 102;
                default:
                    return 76;
            }
        }


        /// <summary>
        /// Returns element inner Text (which is in childNodes)
        /// </summary>
        /// <param name="___element">Normal Element</param>
        /// <returns>text</returns>
        public static string GetElementInnerText(CHtmlElement ___element)
        {
            System.Text.StringBuilder sbText = new StringBuilder();
            if (IsElemeneITextOrIDraw(___element) == true)
            {
                sbText.Append(___element.value);
            }
            else
            {
                int childCount = ___element.___childNodes.Count;
                for (int i = 0; i < childCount; i++)
                {
                    CHtmlTextElement ___textElement = ___element.___childNodes[i] as CHtmlTextElement;
                    if (___textElement != null)
                    {
                        sbText.Append(___textElement.value);
                    }
                }
            }
            return sbText.ToString();
        }
        internal static bool IsLocalDriveUrl(string s)
        {
            if (string.CompareOrdinal(s, 0, "http://", 0, 7) == 0 || string.CompareOrdinal(s, 0, "https://", 0, 8) == 0 || string.CompareOrdinal(s, 0, "ftp://", 0, 6) == 0)
            {
                return false;
            }
            if (string.CompareOrdinal(s, 0, "file://", 0, 7) == 0)
            {
                return true;
            }
            int colPos = s.IndexOf(':');
            if (colPos > -1)
            {
                string headString = s.Substring(0, colPos);
                if (headString.Length == 1)
                {
                    // means windows type file path "c:\"
                    return true;
                }
            }
            return false;
        }


        public static bool IsStringUrlCSSString(string ___url)
        {
            if (string.IsNullOrEmpty(___url))
                return false;
            if (___url.StartsWith("url(", StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            else if (___url.Length > 0)
            {
                if (___url[0] == '#')
                    return false;
                if (___url[0] == '/' || ___url[0] == '.')
                {
                    return true;
                }
                else if (___url[0] == 'h')
                {
                    if (___url.StartsWith("http:", StringComparison.Ordinal) == true || ___url.StartsWith("https:", StringComparison.Ordinal))
                    {
                        return true;
                    }
                }
                else if (___url[0] == 'd')
                {
                    if (___url.StartsWith("data:", StringComparison.Ordinal) == true)
                    {
                        return true;
                    }
                }
                else if (___url[0] == 'f')
                {
                    if (___url.StartsWith("ftp:", StringComparison.Ordinal) == true || ___url.StartsWith("ftps:", StringComparison.Ordinal) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// returns true of string is gradient type of string
        /// </summary>
        /// <param name="___cssStr"></param>
        /// <returns></returns>
        public static bool isStringCSSGradient(string ___cssStr)
        {
            if (string.IsNullOrEmpty(___cssStr) == true)
            {
                return false;
            }
            if (___cssStr[0] == '#')
                return false;
            int posQuote = -1;
            if (___cssStr.Length > 30)
            {
                posQuote = ___cssStr.IndexOf('(', 0, 30);
            }
            else
            {
                posQuote = ___cssStr.IndexOf('(');
            }
            if (posQuote == -1)
            {
                return false;
            }
            else
            {
                string strPrefix = ___cssStr.Substring(0, posQuote);
                switch (strPrefix)
                {
                    case "linear-gradient":
                    case "-moz-linear-gradient":
                    case "-webkit-linear-gradient":
                    case "-webkit-gradient":
                    case "-khtml-gradient":
                    case "-ms-gradient":
                    case "-o-linear-gradient":
                    case "-ms-linear-gradient":
                    case "Linear-Gradient":
                    case "linear-Gradient":
                    case "-moz-linear-Gradient":
                        return true;
                    case "gradient":
                    case "Gradient":
                        return true;
                    default:

                        break;
                }
            }
            return false;
        }


        internal static string GetProperImageString(string rValue, CHtmlCSSStyleSheet sPart, CHtmlCSSRule collectedPart, string __downloadedURL)
        {
            string __bkImageStr = rValue;

            if (NoImageAttributesSortedList.ContainsKey(rValue) == false)
            {
                try
                {
                    if (rValue.StartsWith("http://", StringComparison.Ordinal) == true || rValue.StartsWith("https://", StringComparison.Ordinal) == true ||
                        rValue.StartsWith("ftp:", StringComparison.Ordinal) == true)
                    {
                        return rValue;
                    }
                    if (rValue.IndexOf("gradient(", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        goto SetBackgroundImage;
                    }
                    if (rValue.StartsWith("url(", StringComparison.Ordinal) == true)
                    {
                        __bkImageStr = __bkImageStr.Remove(0, 4);
                        if (__bkImageStr.Length > 0 && __bkImageStr[__bkImageStr.Length - 1] == ',')
                        {
                            __bkImageStr = __bkImageStr.Remove(__bkImageStr.Length - 1, 1);
                        }
                        if (__bkImageStr.Length > 0 && IsCharWhiteSpaceLimited(__bkImageStr[__bkImageStr.Length - 1]))
                        {
                            __bkImageStr = __bkImageStr.TrimEnd();
                        }

                        if (__bkImageStr.Length > 0 && __bkImageStr[__bkImageStr.Length - 1] == ')')
                        {
                            __bkImageStr = __bkImageStr.Remove(__bkImageStr.Length - 1, 1);
                        }
                        if (__bkImageStr.StartsWith("data:", StringComparison.Ordinal) == true)
                        {
                            //__bkImageStr = rValue;
                            goto SetBackgroundImage;
                        }
                    }
                    if (__bkImageStr[0] == '\'' || __bkImageStr[0] == '\"')
                    {
                        __bkImageStr = __bkImageStr.Remove(0, 1);
                        if ((__bkImageStr.EndsWith("\"", StringComparison.Ordinal) || __bkImageStr.EndsWith("\'", StringComparison.Ordinal)))
                        {
                            __bkImageStr = __bkImageStr.Remove(__bkImageStr.Length - 1, 1);
                        }
                    }
                    if (IsCharWhiteSpaceLimited(__bkImageStr[0]))
                    {
                        __bkImageStr = __bkImageStr.Remove(0, 1);
                    }
                    if (__bkImageStr.StartsWith("http//", StringComparison.Ordinal) == true)
                    {
                        __bkImageStr = string.Concat("http://", __bkImageStr.Remove(0, 6));
                        goto SetBackgroundImage;
                    }
                    if (__bkImageStr.StartsWith("https//", StringComparison.Ordinal) == true)
                    {
                        __bkImageStr = string.Concat("https://", __bkImageStr.Remove(0, 7));
                        goto SetBackgroundImage;
                    }


                    if (collectedPart != null && string.IsNullOrEmpty(collectedPart.___baseUrl) == false && collectedPart.___baseUrl.StartsWith(
                        "http", StringComparison.Ordinal) == true)
                    {
                        __bkImageStr = GetAbsoluteUri(collectedPart.___baseUrl, "", __bkImageStr);
                    }
                    else
                    {
                        string ___baseUrl = null;
                        if (string.IsNullOrEmpty(sPart.___ImageUrlHint) == false)
                        {
                            ___baseUrl = sPart.___ImageUrlHint;
                        }
                        else if (string.IsNullOrEmpty(sPart.___baseUrl) == false)
                        {
                            ___baseUrl = sPart.___baseUrl;
                        }
                        else
                        {
                            ___baseUrl = __downloadedURL;
                        }

                        __bkImageStr = GetAbsoluteUri(___baseUrl, "", __bkImageStr);
                    }
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                    {
                        commonLog.LogEntry("BackgroundImage", ex);
                    }
                }
            }
            else
            {
                __bkImageStr = "";
            }
        SetBackgroundImage:
            return __bkImageStr;
        }
        internal static bool isElementJustStoreCSSAttributes(CHtmlElement element)
        {
            if (element.___isSvgElement == true && element.___elementTagType == CHtmlElementType.G)
            {
                return true;
            }

            return false;
        }
        /*
		internal static void SetValuesOnlyIntoCHtmlStyleElement(CHtmlCSSStyleSheet sPart, CHtmlCSSStyleSheet collectedPart,ref SortedList sr, string __downloadedURL)
		{
			if(sr == null || sPart == null)
			{
				return;
			}
			sPart.StyleLists = null;
			sPart.StyleLists = sr.Clone();
		}
		*/
        /// <summary>
        /// Checks if this elmenent strongly must inherits owner 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        internal static bool hasMustInheritsCSSElement(CHtmlElement element)
        {
            if (element.___hasMustInheritCSSElement == true && element.___inheritCSSOwnerElementWeakReference != null)
            {
                return true;
            }
            return false;
        }
        internal static void SetValuesInCHtmlStyleElement(CHtmlCSSStyleSheet sPart, CHtmlCSSRule collectedPart, System.Collections.Generic.List<CHtmlStyleAttribute?> list, bool NoListAdd, string __downloadedURL)
        {
            if (list == null || sPart == null)
            {
                return;
            }
            string rName = null;
            string rValue = null;
            System.Collections.Generic.Dictionary<string, string> importantedName = new System.Collections.Generic.Dictionary<string, string>(StringComparer.Ordinal);
            CHtmlElement ___ownerElement = sPart.ownerElement;
            int __listCount = list.Count;
            for (int i = 0; i < __listCount; i++)
            {
                try
                {

                    CHtmlStyleAttribute? styleValueNulable = list[i];
                    if (styleValueNulable == null)
                    {
                        continue;
                    }
                    CHtmlStyleAttribute styleValue = styleValueNulable.Value;
                    if (styleValue.IsValid == false || styleValue.HackType != CSSHackType.None)
                        continue;
                    rValue = null;
                    rName = null;
                    rName = styleValue.Name;
                    if (rName.Length == 0)
                    {
                        list.RemoveAt(i);
                        __listCount = list.Count;
                        i--;
                        continue;
                    }
                    if (string.IsNullOrEmpty(styleValue.value) == true)
                    {
                        // all css attributes should have a value.
                        styleValue.IsValid = false;
                        continue;
                    }
                    rValue = styleValue.value;

                    if (NoListAdd == false)
                    {
                        /*
						if(!sPart.StyleLists.ContainsKey(rName))
						{
							sPart.StyleLists.Add(rName, rValue);
						}
						*/
                        // Folowing is faster
                        //sPart.StyleLists[rName] = rValue;
                        sPart.___AddCHtmlStyleAttributeIntoStyleLists(styleValue);
                    }
                    if (rValue.Length >= 11 && rValue[0] == 'e' && rValue[1] == 'x' && rValue.StartsWith("expression", StringComparison.Ordinal) == true)
                    {
                        char[] rValueCharArray = rValue.ToCharArray();
                        char c = '\0';
                        int rValueLen = rValue.Length;
                        for (int npos = 10; npos < rValueLen; npos++)
                        {
                            c = rValueCharArray[npos];
                            if (c == '(')
                            {
                                sPart.StyleCommentAdd("expression skip : " + rName + ":" + rValue);
                                styleValue.IsValid = false;
                                goto NextValue;
                            }
                            else if (IsCharWhiteSpaceLimited(c))
                            {
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                    }
                    sPart.___PropertyMeargedCount++;
                    // ===============================================
                    //  [!important] check
                    //  1. create Entry if it is important
                    //  2. if it is not important check the list and if exists. skip the entry.
                    // ===============================================
                    if (styleValue.IsImportant == true)
                    {
                        if (sPart.___StyleImportantKeyList != null)
                        {
                            if (sPart.___StyleImportantKeyList == null)
                            {
                                sPart.___StyleImportantKeyList = new System.Collections.Generic.Dictionary<CSSAttributeType, sbyte>();
                            }
                            sPart.___StyleImportantKeyList[styleValue.attributeType] = 1;

                        }
                    }
                    else
                    {
                        if (sPart.___StyleImportantKeyList != null)
                        {
                            if (sPart.___StyleImportantKeyList.ContainsKey(styleValue.attributeType))
                            {
                                continue;
                            }
                        }
                    }
                    try
                    {
                        if (___ownerElement != null && ___ownerElement.___isSvgElement == true && ___ownerElement.___elementTagType == CHtmlElementType.G)
                        {
                            ___ownerElement.___mustInheritAttributeList[styleValue.attributeType] = rValue;
                            continue;
                        }
                        switch (styleValue.attributeType)// Name is always lower
                        {
                            case CSSAttributeType.borderleftcolor:

                                sPart.___BorderLeftColor = rValue;
                                continue;
                            case CSSAttributeType.borderrightcolor:
                                sPart.___BorderRightColor = rValue;
                                continue;
                            case CSSAttributeType.bordertopcolor:
                                sPart.___BorderTopColor = rValue;
                                continue;
                            case CSSAttributeType.borderbottomcolor:
                                sPart.___BorderBottomColor = rValue;
                                continue;
                            case CSSAttributeType.align:

                                sPart.___Align = rValue;
                                continue;
                            case CSSAttributeType.appearance:
                                sPart.___Appearance = rValue;
                                continue;
                            case CSSAttributeType.verticalalign:
                                sPart.___VerticalAlign = rValue;
                                continue;
                            case CSSAttributeType.backgroundcolor:

                                if (rValue.Length == 11 && string.Equals(rValue, "transparent", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    continue;
                                }
                                else if (rValue.Length == 1 && rValue[0] == '#') // altual value may override good value.
                                {
                                    continue;

                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(rValue) == false)
                                    {
                                        if (rValue.Length > 16 && rValue.IndexOf("gradient(", StringComparison.OrdinalIgnoreCase) > -1)
                                        {
                                            if (string.IsNullOrEmpty(sPart.___Background) == true)
                                            {
                                                sPart.___Background = rValue;
                                            }
                                            else
                                            {
                                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                                {
                                                    commonLog.LogEntry("style.background ___hasInner invalid gradient value" + rValue + " skip for now...");
                                                }
                                            }
                                            continue;
                                        }
                                        else
                                        {
                                            sPart.BackgroundColor = rValue;
                                            continue;
                                        }
                                    }
                                    sPart.BackgroundColor = rValue;
                                    continue;
                                }
                            case CSSAttributeType.fill:
                                sPart.BackgroundColor = rValue;
                                continue;
                            case CSSAttributeType.fontsize:
                                sPart.FontSize = rValue; // should have prechecked.
                                continue;
                            case CSSAttributeType.fontvariant:
                                sPart.FontVariant = rValue;
                                continue;
                            case CSSAttributeType.textshadow:
                                sPart.___TextShadow = rValue;
                                continue;
                            case CSSAttributeType.outlinecolor:
                                sPart.___OutlineColor = rValue;
                                continue;
                            case CSSAttributeType.color:
                                if (rValue.Length == 1 && rValue[0] == '#')
                                {
                                    continue;
                                }
                                else
                                {
                                    sPart.Color = rValue;
                                }
                                continue;
                            case CSSAttributeType.width:
                                /* is should have been checked at creation time.
                                if(rValue.Length > 0 && rValue.Equals("0") == false && char.IsNumber(rValue[rValue.Length -1]) == true)
                                {
                                    sPart.StyleCommentAdd("width without units will be ignore : " + rValue);
                                    continue;
                                }
                                */
                                sPart.Width = rValue; // should have prechecked.
                                continue;
                            case CSSAttributeType.height:
                                sPart.Height = rValue; // should have prechecked.
                                continue;
                            case CSSAttributeType.margin:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.___Margin = rValue;
                                continue;
                            case CSSAttributeType.animation:
                                sPart.___Animation = rValue;
                                continue;
                            case CSSAttributeType.padding:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.___Padding = rValue;
                                continue;
                            case CSSAttributeType.paddingstart:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.___PaddingStart = rValue;
                                continue;
                            case CSSAttributeType.paddingend:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.___PaddingEnd = rValue;
                                continue;
                            case CSSAttributeType.border:
                                sPart.___Border = rValue;
                                continue;
                            case CSSAttributeType.display:
                                if (rValue.Length == 0)
                                {
                                    continue;
                                }
                                sPart.Display = rValue;
                                continue;
                            case CSSAttributeType.fontweight:
                                sPart.FontWeight = rValue;
                                continue;
                            case CSSAttributeType.wordbreak:
                                sPart.___WordBreak = rValue;
                                continue;
                            case CSSAttributeType.lineheight:
                                sPart.___LineHeight = rValue;
                                continue;
                            case CSSAttributeType.clip:
                                sPart.___Clip = rValue;
                                continue;
                            case CSSAttributeType.markeroffset:
                                sPart.___MarkerOffset = rValue;
                                continue;
                            case CSSAttributeType.pointerevents:
                                sPart.PointerEvents = rValue;
                                continue;

                            case CSSAttributeType.@float:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }

                                sPart.cssFloat = rValue;
                                continue;
                            case CSSAttributeType.liststyletype:
                                sPart.ListStyleType = rValue;
                                continue;
                            case CSSAttributeType.font:
                                sPart.Font = rValue;

                                setCSSFontStyleIntoStyleSheetOrCHtmlFontInfo(sPart, null, rValue);
                                continue;
                            case CSSAttributeType.clear:
                                sPart.Clear = rValue;
                                continue;
                            case CSSAttributeType.marginleft:
                                sPart.MarginLeft = rValue;
                                continue;
                            case CSSAttributeType.margintop:
                                //case "margin-top":

                                sPart.MarginTop = rValue;
                                continue;
                            case CSSAttributeType.marginright:
                                sPart.MarginRight = rValue;
                                continue;

                            case CSSAttributeType.marginbottom:
                                sPart.MarginBottom = rValue;
                                continue;
                            case CSSAttributeType.liststyle:
                                sPart.___ListStyle = rValue;
                                continue;
                            case CSSAttributeType.textsizeadjust:
                                sPart.___TextSizeAdjust = rValue;
                                continue;
                            case CSSAttributeType.textdecoration:


                                sPart.TextDecoration = rValue;
                                continue;
                            case CSSAttributeType.fontstyle:
                                sPart.FontStyle = rValue;
                                continue;
                            case CSSAttributeType.left:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.___Left = rValue;
                                continue;
                            case CSSAttributeType.top:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.___Top = rValue;
                                continue;
                            case CSSAttributeType.bottom:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.___Bottom = rValue;
                                continue;
                            case CSSAttributeType.right:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.___Right = rValue;
                                continue;
                            case CSSAttributeType.position:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.Position = rValue;
                                continue;
                            case CSSAttributeType.content:
                                sPart.___Content = rValue;
                                continue;
                            case CSSAttributeType.visibility:
                                sPart.Visibility = rValue;
                                continue;
                            case CSSAttributeType.paddingtop:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.___PaddingTop = rValue;
                                continue;
                            case CSSAttributeType.paddingright:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.___PaddingRight = rValue;
                                continue;
                            case CSSAttributeType.paddingbottom:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.___PaddingBottom = rValue;
                                continue;
                            case CSSAttributeType.paddingleft:
                                if (collectedPart != null && collectedPart.___isFinalStyleKeyWildCardOnly == true)
                                {
                                    continue;
                                }
                                sPart.___PaddingLeft = rValue;
                                continue;
                            case CSSAttributeType.backgroundimage:
                                if (string.IsNullOrEmpty(sPart.___Background) == false)
                                {
                                    // Erase Background Value to avoid mixture of image for CSS3
                                    sPart.___Background = null;
                                }
                                if (string.IsNullOrEmpty(__downloadedURL) == false)
                                {
                                    sPart.___ImageUrlHint = string.Copy(__downloadedURL);
                                    sPart.___BackgroundImage = rValue;
                                }
                                else
                                {
                                    sPart.___BackgroundImage = rValue;
                                }

                                continue;
                            case CSSAttributeType.whitespace:
                                sPart.WhiteSpace = rValue;
                                continue;
                            case CSSAttributeType.textalign:
                                sPart.___TextAlign = rValue;
                                continue;
                            case CSSAttributeType.textjustification:
                                sPart.___TextJustification = rValue;
                                continue;
                            case CSSAttributeType.textlinethrough:
                                sPart.___TextLineThrough = rValue;
                                continue;
                            case CSSAttributeType.background:
                                if (string.IsNullOrEmpty(sPart.___BackgroundImage) == false)
                                {
                                    // Erase Background Image string to avoid data mixture for CSS3
                                    sPart.___BackgroundImage = null;
                                }
                                if (string.IsNullOrEmpty(__downloadedURL) == false)
                                {
                                    sPart.___ImageUrlHint = string.Copy(__downloadedURL);
                                }
                                sPart.___Background = rValue;
                                sPart.___checkBackgroundStringForElement();


                                // Set afterword
                                // SetCHtmlStyleElementWithBackgoundStylesheetString(rValue, sPart);
                                // 
                                continue;
                            case CSSAttributeType.zoom:
                                sPart.___Zoom = rValue;
                                continue;
                            case CSSAttributeType.minheight:
                                sPart.MinHeight = rValue;  // should have prechecked.
                                continue;
                            case CSSAttributeType.minwidth:
                                sPart.MinWidth = rValue; // should have prechecked.
                                continue;
                            case CSSAttributeType.maxheight:
                                sPart.MaxHeight = rValue; // should have prechecked.
                                continue;
                            case CSSAttributeType.maxwidth:
                                sPart.MaxWidth = rValue; // should have prechecked.
                                continue;
                            case CSSAttributeType.bordercolor:
                                sPart.___BorderColor = rValue;
                                continue;
                            case CSSAttributeType.bordertop:
                                sPart.___BorderTop = rValue;
                                continue;
                            case CSSAttributeType.borderbottom:

                                sPart.___BorderBottom = rValue;
                                continue;
                            case CSSAttributeType.borderleft:
                                sPart.___BorderLeft = rValue;
                                continue;
                            case CSSAttributeType.borderright:
                                sPart.___BorderRight = rValue;
                                continue;
                            case CSSAttributeType.bordertopright:
                                sPart.___BorderTop = rValue;
                                sPart.___BorderRight = sPart.BorderTop;
                                continue;
                            case CSSAttributeType.bordertopleft:
                                sPart.___BorderTop = rValue;
                                sPart.___BorderLeft = sPart.BorderTop;
                                continue;
                            case CSSAttributeType.backgroundposition:
                                sPart.___BackgroundPosition = rValue;
                                continue;
                            case CSSAttributeType.backgroundrepeat:
                                sPart.___BackgroundRepeat = rValue;
                                continue;
                            case CSSAttributeType.overflow:
                                sPart.___OverFlow = rValue;
                                continue;
                            case CSSAttributeType.overflowscrolling:
                                sPart.overflowScrolling = rValue;
                                continue;
                            case CSSAttributeType.zindex:
                                sPart.zIndex = rValue;
                                continue;
                            case CSSAttributeType.wordwrap:
                                sPart.___WordWrap = rValue;
                                continue;
                            case CSSAttributeType.textindent:
                                if (rValue.Length != 0)
                                {
                                    sPart.TextIndent = rValue;
                                }
                                continue;
                            case CSSAttributeType.textindex:
                                sPart.___TextIndex = rValue;
                                continue;
                            case CSSAttributeType.letterspacing:
                                sPart.___LetterSpacing = rValue;
                                continue;
                            case CSSAttributeType.liststyleimage:
                                if (string.IsNullOrEmpty(__downloadedURL) == false)
                                {
                                    if (collectedPart != null)
                                    {
                                        sPart.___ListStyleImage = GetProperImageString(rValue, sPart, collectedPart, __downloadedURL);
                                    }
                                    else
                                    {
                                        sPart.___ListStyleImage = GetProperImageString(rValue, sPart, null, __downloadedURL);
                                    }
                                    sPart.___ImageUrlHint = __downloadedURL;
                                }
                                else
                                {
                                    sPart.___ListStyleImage = rValue;

                                    if (commonLog.LoggingEnabled)
                                    {
                                        commonLog.LogEntry("BUGBUG!!! SetValuesChtmlStytleElement null ___downloadURL");
                                    }
                                }

                                continue;
                            case CSSAttributeType.liststyleposition:
                                sPart.___ListStylePosition = rValue;
                                continue;
                            case CSSAttributeType.fontfamily:
                                sPart.FontFamily = rValue;
                                continue;
                            case CSSAttributeType.fontkerning:
                                sPart.___FontKerning = rValue;
                                continue;
                            case CSSAttributeType.outline:
                                sPart.___Outline = rValue;
                                continue;
                            case CSSAttributeType.overflowy:
                                sPart.___OverFlowY = rValue;
                                continue;
                            case CSSAttributeType.overflowx:
                                sPart.___OverFlowX = rValue;
                                continue;
                            case CSSAttributeType.behavior:
                                sPart.___Behavior = rValue;
                                continue;
                            case CSSAttributeType.filter:
                                sPart.___Filter = rValue;
                                continue;
                            case CSSAttributeType.fontsmoothing:
                                sPart.___FontSmoothing = rValue;
                                continue;
                            case CSSAttributeType.opacity:
                                sPart.Opacity = rValue;
                                continue;
                            case CSSAttributeType.flexflow:
                                sPart.___flexFlow = rValue;
                                continue;
                            case CSSAttributeType.aligncontent:
                                sPart.___alignContent = rValue;
                                continue;
                            case CSSAttributeType.flexwrap:
                                sPart.flexWrap = rValue;
                                continue;
                            case CSSAttributeType.boxreflect:
                                sPart.boxReflect = rValue;
                                continue;
                            case CSSAttributeType.columncount:
                                sPart.___ColumnCount = rValue;
                                continue;
                            case CSSAttributeType.animationdelay:
                                sPart.animationDelay = rValue;
                                continue;
                            case CSSAttributeType.animationname:
                                sPart.animationName = rValue;
                                continue;
                            case CSSAttributeType.animationplaystate:
                                sPart.animationPlayState = rValue;
                                continue;

                            case CSSAttributeType.rotation:
                                sPart.rotate = rValue;
                                continue;

                            case CSSAttributeType.fullscreen:
                                sPart.fullscreen = rValue;
                                continue;
                            case CSSAttributeType.marginstart:
                                sPart.___MarginStart = rValue;
                                continue;
                            case CSSAttributeType.marginend:
                                sPart.___MarginEnd = rValue;
                                continue;
                            case CSSAttributeType.orphans:
                                sPart.___Orphans = rValue;
                                continue;
                            case CSSAttributeType.pagebreakinside:
                                sPart.___PageBreakInside = rValue;
                                continue;
                            case CSSAttributeType.overflowstyle:
                                sPart.___OverFlowStyle = rValue;
                                continue;
                            case CSSAttributeType.outlineoffset:
                                sPart.___OutlineOffset = rValue;
                                continue;
                            case CSSAttributeType.marginafter:

                                sPart.___MarginAfter = rValue;
                                continue;
                            case CSSAttributeType.marginbefore:
                                sPart.___MarginBefore = rValue;
                                continue;
                            case CSSAttributeType.touchaction:
                                sPart.___TouchAction = rValue;
                                continue;
                            case CSSAttributeType.resize:
                                sPart.___Resize = rValue;
                                continue;
                            case CSSAttributeType.borderimage:
                                sPart.___BorderImage = rValue;
                                continue;
                            // --------------------------------------------------------------
                            // Mozilla supports multiple colors for border
                            // --------------------------------------------------------------

                            case CSSAttributeType.borderleftcolors:
                                sPart.___BorderLeftColors = rValue;
                                continue;
                            case CSSAttributeType.borderrightcolors:

                                sPart.___BorderRightColors = rValue;
                                continue;
                            case CSSAttributeType.bordertopcolors:
                                sPart.___BorderTopColors = rValue;
                                continue;
                            case CSSAttributeType.borderbottomcolors:

                                sPart.___BorderBottomColors = rValue;
                                continue;
                            // -----------------------------------------------------------


                            case CSSAttributeType.borderlightcolor:
                                sPart.___BorderLightColor = rValue;
                                continue;
                            case CSSAttributeType.borderdarkcolor:
                                sPart.___BorderDarkColor = rValue;
                                continue;
                            case CSSAttributeType.tablelayout:
                                sPart.___TableLayout = rValue;
                                continue;
                            case CSSAttributeType.maskimage:
                                sPart.___MaskImage = rValue;
                                continue;
                            case CSSAttributeType.maskboximage:
                                sPart.___MaskBoxImage = rValue;
                                continue;
                            case CSSAttributeType.textstoke:
                                sPart.___TextStroke = rValue;
                                continue;
                            case CSSAttributeType.imemode:
                                sPart.___ImeMode = rValue;
                                continue;
                            case CSSAttributeType.wordspacing:
                                sPart.___WordSpacing = rValue;
                                continue;
                            case CSSAttributeType.bordercollapse:
                                sPart.___BorderCollapse = rValue;
                                continue;
                            case CSSAttributeType.voicefamily:
                                sPart.___VoiceFamily = rValue;
                                continue;
                            case CSSAttributeType.borderwidth:
                                sPart.___BorderWidth = rValue;
                                sPart.___BorderTopWidth = sPart.BorderWidth;
                                sPart.___BorderRightWidth = sPart.BorderWidth;
                                sPart.___BorderBottomWidth = sPart.BorderWidth;
                                sPart.___BorderLeftWidth = sPart.BorderWidth;
                                continue;
                            case CSSAttributeType.borderstyle:
                                sPart.___BorderStyle = rValue;
                                sPart.___BorderTopStyle = sPart.BorderStyle;
                                sPart.___BorderRightStyle = sPart.BorderStyle;
                                sPart.___BorderBottomStyle = sPart.BorderStyle;
                                sPart.___BorderLeftStyle = sPart.BorderStyle;
                                continue;
                            case CSSAttributeType.linebreak:

                                sPart.___LineBreak = rValue;
                                continue;
                            case CSSAttributeType.lineclamp:
                                sPart.___LineClamp = rValue;
                                continue;
                            case CSSAttributeType.borderbottomstyle:
                                sPart.___BorderBottomStyle = rValue;
                                continue;
                            case CSSAttributeType.bordertopstyle:
                                sPart.___BorderTopStyle = rValue;
                                continue;
                            case CSSAttributeType.borderleftstyle:
                                sPart.___BorderLeftStyle = rValue;
                                continue;
                            case CSSAttributeType.borderrightstyle:
                                sPart.___BorderRightStyle = rValue;
                                continue;
                            case CSSAttributeType.outlinestyle:
                                sPart.___OutlineStyle = rValue;
                                continue;
                            case CSSAttributeType.borderspacing:
                                sPart.___BorderSpacing = rValue;
                                continue;
                            case CSSAttributeType.borderleftwidth:
                                sPart.___BorderLeftWidth = rValue;
                                continue;
                            case CSSAttributeType.borderrightwidth:
                                sPart.___BorderRightWidth = rValue;
                                continue;
                            case CSSAttributeType.bordertopwidth:
                                sPart.___BorderTopWidth = rValue;
                                continue;
                            case CSSAttributeType.borderbottomwidth:
                                sPart.___BorderBottomWidth = rValue;
                                continue;
                            case CSSAttributeType.backgroundattachment:
                                sPart.___BackgroundAttachment = rValue;
                                continue;
                            case CSSAttributeType.backgroundclip:
                                sPart.___BackgroundClip = rValue;
                                continue;
                            case CSSAttributeType.backgroundinlinepolicy:
                                sPart.___BackgroundInlinePolicy = rValue;
                                continue;
                            case CSSAttributeType.backgroundorigin:
                                sPart.___BackgroundOrigin = rValue;
                                continue;
                            case CSSAttributeType.emptycells:
                                sPart.___EmptyCells = rValue;
                                continue;
                            case CSSAttributeType.texttransform:
                                sPart.___TextTransform = rValue;
                                continue;
                            case CSSAttributeType.textrendering:
                                sPart.___TextRendering = rValue;
                                continue;
                            case CSSAttributeType.fontstretch:
                                sPart.___FontStretch = rValue;
                                continue;
                            case CSSAttributeType.textoverflow:
                                sPart.___TextOverFlow = rValue;
                                continue;
                            case CSSAttributeType.relative:
                                sPart.___Relative = rValue;
                                continue;
                            case CSSAttributeType.quotes:
                                sPart.___Quotes = rValue;
                                continue;
                            case CSSAttributeType.direction:
                                sPart.___Direction = rValue;
                                continue;
                            case CSSAttributeType.backgroundpositionx:
                                sPart.___BackgroundPositionX = rValue;
                                continue;
                            case CSSAttributeType.backgroundpositiony:
                                sPart.___BackgroundPositionY = rValue;
                                continue;
                            case CSSAttributeType.backgroundsize:
                                sPart.___BackgroundSize = rValue;
                                continue;
                            case CSSAttributeType.scrollbarhighlightcolor:
                                sPart.___ScrollBarHighLightColor = rValue;
                                continue;
                            case CSSAttributeType.scrollbarbasecolor:
                                sPart.___ScrollBarBaseColor = rValue;
                                continue;

                            case CSSAttributeType.scrollbardarkshadowcolor:
                                sPart.___ScrollBarDarkShadowColor = rValue;
                                continue;
                            case CSSAttributeType.scrollbartrackcolor:
                                sPart.___ScrollBarTrackColor = rValue;
                                continue;
                            case CSSAttributeType.scrollbar3dlightcolor:
                                sPart.___ScrollBar3DLightColor = rValue;
                                continue;
                            case CSSAttributeType.cursor:
                                sPart.___Cursor = rValue;
                                continue;
                            case CSSAttributeType.boxorient:
                                sPart.___BoxOrient = rValue;
                                continue;
                            case CSSAttributeType.boxshadow:
                                sPart.___BoxShadow = rValue;
                                continue;
                            case CSSAttributeType.boxshadowboxshadow:
                                sPart.___BoxShadowBoxShadow = rValue;
                                continue;
                            case CSSAttributeType.boxsizing:
                                sPart.___BoxSizing = rValue;
                                continue;
                            case CSSAttributeType.boxmodel:
                                sPart.___BoxModel = rValue;
                                continue;
                            case CSSAttributeType.boxpack:
                                sPart.___BoxPack = rValue;
                                continue;
                            case CSSAttributeType.boxoriginalgroup:
                                sPart.___BoxOrdinalGroup = rValue;
                                continue;
                            case CSSAttributeType.boxflex:
                                sPart.boxflex = rValue;
                                continue;
                            case CSSAttributeType.outlinewidth:
                                sPart.___OutlineWidth = rValue;
                                continue;
                            case CSSAttributeType.outlineheight:
                                sPart.___OutlineHeight = rValue;
                                continue;
                            case CSSAttributeType.cellpadding:
                                sPart.___CellPadding = rValue;
                                continue;
                            case CSSAttributeType.cellspacing:
                                sPart.___CellSpacing = rValue;
                                continue;
                            case CSSAttributeType.fontsizeadjust:
                                sPart.___FontSizeAdjust = rValue;
                                continue;
                            case CSSAttributeType.textjustify:
                                sPart.___TextJustify = rValue;
                                continue;
                            case CSSAttributeType.textunderline:
                                sPart.___TextUnderLine = rValue;
                                continue;
                            case CSSAttributeType.page:
                                sPart.___Page = rValue;
                                continue;
                            case CSSAttributeType.pagebreakafter:
                                sPart.___PageBreakAfter = rValue;
                                continue;
                            case CSSAttributeType.tabstops:
                                sPart.___TabStops = rValue;
                                continue;
                            case CSSAttributeType.transform:
                                sPart.___Transform = rValue;
                                continue;
                            case CSSAttributeType.transformorigin:
                                sPart.___TransformOrigin = rValue;
                                continue;
                            case CSSAttributeType.transformduration:
                                sPart.___TransformDuration = rValue;
                                continue;
                            case CSSAttributeType.transitionduration:
                                sPart.___TransitionDuration = rValue;
                                continue;
                            case CSSAttributeType.transitionproperty:
                                sPart.___TransitionProperty = rValue;
                                continue;
                            case CSSAttributeType.transitiontimingfunction:
                                sPart.___TransitionTimingFunction = rValue;
                                continue;
                            case CSSAttributeType.transitiondelay:
                                sPart.___TransitionDelay = rValue;
                                continue;
                            case CSSAttributeType.stroke:
                                sPart.___Stroke = rValue;
                                continue;
                            case CSSAttributeType.strokewidth:
                                sPart.___StrokeWidth = rValue;
                                continue;
                            case CSSAttributeType.stopopacity:
                                sPart.___StopOpacity = rValue;
                                continue;
                            case CSSAttributeType.borderradius:
                                sPart.___BorderRadius = rValue;
                                continue;
                            case CSSAttributeType.bordertopleftradius:
                                sPart.___BorderTopLeftRadius = rValue;
                                continue;
                            case CSSAttributeType.bordertoprightradius:
                                sPart.___BorderTopRightRadius = rValue;
                                continue;
                            case CSSAttributeType.borderbottomleftradius:
                                sPart.___BorderBottomLeftRadius = rValue;
                                continue;
                            case CSSAttributeType.borderbottomrightradius:
                                sPart.___BorderBottomRightRadius = rValue;
                                continue;
                            case CSSAttributeType.transition:
                                sPart.___Transition = rValue;
                                continue;
                            case CSSAttributeType.interpolationmode:
                                sPart.___InterpolationMode = rValue;
                                continue;
                            case CSSAttributeType.widows:
                                sPart.___Widows = rValue;
                                continue;
                            case CSSAttributeType.backgroundopacity:
                                sPart.___BackgroundOpacity = rValue;
                                continue;
                            case CSSAttributeType.scrollbararrowcolor:
                                sPart.___ScrollBarArrowColor = rValue;
                                continue;
                            case CSSAttributeType.scrollbarfacecolor:
                                sPart.___ScrollBarFaceColor = rValue;
                                continue;
                            case CSSAttributeType.taphighlightcolor:
                                sPart.___tapHighlightColor = rValue;
                                continue;
                            case CSSAttributeType.highcontrastadjust:
                                sPart.___highContrastAdjust = rValue;
                                continue;
                            case CSSAttributeType.systemfont:
                                // int value is expected

                                continue;
                            case CSSAttributeType.fontfeaturesettings:
                                sPart.fontFeatureSettings = rValue;
                                continue;
                            case CSSAttributeType.scrollbarshadowcolor:
                                sPart.___ScrollBarShadowColor = rValue;
                                continue;
                            case CSSAttributeType.userselect:
                                sPart.___UserSelect = rValue;
                                continue;
                            case CSSAttributeType.stopcolor:
                                sPart.___StopColor = rValue;
                                continue;
                            case CSSAttributeType.speak:
                                sPart.___Speak = rValue;
                                continue;
                            case CSSAttributeType.hyphens:
                                sPart.___Hyphens = rValue;
                                continue;
                            case CSSAttributeType.hyphenatelines:
                                sPart.___HyphenateLines = rValue;
                                continue;
                            case CSSAttributeType.hyphenatelimitlines:
                                sPart.___HyphenateLimitLines = rValue;
                                continue;
                            case CSSAttributeType.hyphenatelimitzone:
                                sPart.___HyphenateLimitZone = rValue;
                                continue;

                            case CSSAttributeType.msolist:
                                sPart.___MsoList = rValue;
                                continue;
                            case CSSAttributeType.touchcallout:
                                sPart.___TouchCallout = rValue;
                                continue;
                            case CSSAttributeType.animationduration:
                                sPart.___animationduration = rValue;
                                continue;
                            case CSSAttributeType.imagerendering:
                                sPart.___ImageRendering = rValue;
                                continue;
                            case CSSAttributeType.ieonlyrendering:
                                sPart.___IEOnlyWidth = rValue;
                                continue;
                            case CSSAttributeType.richness:
                                sPart.___Richness = rValue;
                                continue;
                            case CSSAttributeType.stress:
                                sPart.___Stress = rValue;
                                continue;
                            case CSSAttributeType.pitch:
                                sPart.___Pitch = rValue;
                                continue;
                            case CSSAttributeType.pitchrange:
                                sPart.___PitchRange = rValue;
                                continue;
                            case CSSAttributeType.layoutgridline:
                                sPart.___LayoutGridLine = rValue;
                                continue;


                            case CSSAttributeType.frameborder:
                                sPart.___FrameBorder = rValue;
                                continue;
                            case CSSAttributeType.scrolling:
                                sPart.___Scrolling = rValue;
                                continue;
                            case CSSAttributeType.backfacevisibility:
                                sPart.___BackfaceVisibility = rValue;
                                continue;
                            case CSSAttributeType.perspective:
                                sPart.___Perspective = rValue;
                                continue;
                            case CSSAttributeType.perspectiveorigin:
                                sPart.___PerspectiveOrigin = rValue;
                                continue;
                            case CSSAttributeType.transformstyle:
                                sPart.___TransformStyle = rValue;
                                continue;
                            case CSSAttributeType.columnwidth:
                                sPart.___ColumnWidth = rValue;
                                continue;
                            case CSSAttributeType.columnspan:
                                sPart.___ColumnSpan = rValue;
                                continue;
                            case CSSAttributeType.breakinside:

                                sPart.___BreakInside = rValue;
                                continue;
                            case CSSAttributeType.marginwidth:
                                sPart.___MarginWidth = rValue;
                                continue;
                            case CSSAttributeType.marginheight:
                                sPart.___MarginHeight = rValue;
                                continue;
                            case CSSAttributeType.flex:
                                sPart.___Flex = rValue;
                                continue;
                            case CSSAttributeType.flexdirection:
                                sPart.___FlexDirection = rValue;
                                continue;
                            case CSSAttributeType.flexorder:

                                sPart.___flexOrder = rValue;
                                continue;
                            case CSSAttributeType.boxdirection:
                                sPart.___BoxDirection = rValue;
                                continue;
                            case CSSAttributeType.boxalign:
                                sPart.___BoxAlign = rValue;
                                continue;
                            case CSSAttributeType.counterincrement:
                                sPart.___CounterIncrement = rValue;
                                continue;
                            case CSSAttributeType.counterreset:
                                sPart.___CounterReset = rValue;
                                continue;
                            case CSSAttributeType.alignitems:
                                sPart.___AlignItems = rValue;
                                continue;
                            case CSSAttributeType.gridcolumns:
                                sPart.___GridColumns = rValue;
                                continue;
                            case CSSAttributeType.gridcolumn:
                                sPart.___GridColumn = rValue;
                                continue;
                            case CSSAttributeType.gridcolumnspan:
                                sPart.___GridColumnSpan = rValue;
                                continue;
                            case CSSAttributeType.gridcolumnalign:
                                sPart.___GridColumnAlign = rValue;
                                continue;
                            case CSSAttributeType.gridrows:
                                sPart.___GridRows = rValue;
                                continue;
                            case CSSAttributeType.gridrow:
                                sPart.___GridRow = rValue;
                                continue;
                            case CSSAttributeType.gridrowspan:
                                sPart.___GridRowSpan = rValue;
                                continue;
                            case CSSAttributeType.gridrowalign:
                                sPart.___GridRowAlign = rValue;
                                continue;
                            case CSSAttributeType.overflowwrap:
                                sPart.___OverFlowWrap = rValue;
                                continue;
                            case CSSAttributeType.printcoloradjust:
                                sPart.___PrintColorAjdust = rValue;
                                continue;
                            case CSSAttributeType.flexlinepack:
                                sPart.___flexLinePack = rValue;
                                continue;
                            case CSSAttributeType.unicodebidi:
                                continue;
                            case CSSAttributeType.bordertopbottomradius:
                                sPart.___BorderTopRightRadius = rValue;
                                continue;

                            case CSSAttributeType.columngap:
                                sPart.___ColumnGap = rValue;
                                continue;

                            default:
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 7)
                                {
                                    if (rName.Length > 1)
                                    {

                                        commonLog.LogEntry("Style Skip [{0}:{1}] = \"{2}\"", rName, styleValue.attributeType, rValue);
                                    }
                                }
                                continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                        {
                            commonLog.LogEntry("SetValuesInInCHtmlStyleElement failed \'{0}\' = {1} {2}", rName, rValue, ex.Message);
                        }
                        continue;
                    }
                NextValue:
                    if (false) {; }
                }
                catch (Exception exStyle)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                    {
                        commonLog.LogEntry("SetValuesInInCHtmlStyleElement failed \'{0}\' = {1} Exception : {2}", rName, rValue, exStyle);
                    }
                }

            }
        }
        /// <summary>
        /// Set Styele from style.FontSpec value
        /// </summary>
        /// <param name="sPart"></param>
        /// <param name="__fontValue"></param>
        internal static void setCSSFontStyleIntoStyleSheetOrCHtmlFontInfo(CHtmlCSSStyleSheet __style, CHtmlFontInfo ___CHtmlFontInfo, string __fontValue)
        {
            if (string.IsNullOrEmpty(__fontValue) == true || (__style == null && ___CHtmlFontInfo == null))
            {
                return;
            }

            char[] __cArray = __fontValue.ToCharArray();
            bool __IsInQuote = false;
            System.Collections.Generic.List<string> __listValue = new System.Collections.Generic.List<string>();
            System.Text.StringBuilder __sb = new StringBuilder(30);
            char c = new char();
            try
            {
                int __cArrayLen = __cArray.Length;
                for (int cPos = 0; cPos < __cArrayLen; cPos++)
                {
                    c = __cArray[cPos];
                    switch (c)
                    {
                        case '\'':
                        case '\"':
                            if (__IsInQuote == false)
                            {
                                __IsInQuote = true;
                            }
                            else
                            {
                                __IsInQuote = false;
                            }
                            continue;
                        case ' ':
                            if (__IsInQuote == false)
                            {
                                if (__sb.Length > 0)
                                {
                                    __listValue.Add(__sb.ToString());
                                }
                                __sb = null;
                                __sb = new StringBuilder(30);
                                continue;
                            }
                            break;
                        case ',':
                            if (cPos >= __cArray.Length - 1)
                            {
                                goto LoopDone;
                            }
                            if (__cArray[cPos + 1] == ' ')
                            {
                                continue;
                            }
                            else
                            {
                                if (__sb.Length > 0)
                                {
                                    __listValue.Add(__sb.ToString());
                                }
                                __sb = null;
                                __sb = new StringBuilder(30);
                                continue;
                            }
                    }
                    if (c >= 'A' && c <= 'Z')
                    {
                        __sb.Append(FasterToLower(c));
                    }
                    else
                    {
                        __sb.Append(c);

                    }
                }
            LoopDone:
                if (__sb.Length > 0)
                {
                    __listValue.Add(__sb.ToString());
                }
                __sb = null;

                int __fontStyleCount = 0;
                System.Text.StringBuilder sbFontFamilyBuilder = new StringBuilder(10);
                int FontValidNumberCount = 0;
                int __arValueCount = __listValue.Count;
                string __sValue = null;
                for (int i = 0; i < __arValueCount; i++)
                {
                    __sValue = __listValue[i];
                    if (__sValue == null || __sValue.Length == 0)
                        continue;
                    switch (__sValue)
                    {
                        case "regular":
                            __fontStyleCount++;
                            if (__style != null)
                            {
                                __style.FontStyle = __sValue;
                                //__style.StyleLists["font-style"] = __sValue;
                                __style.setAttributeInner("font-style", __sValue, true, false);
                            }
                            else if (___CHtmlFontInfo != null)
                            {
                                ___CHtmlFontInfo.___isUnderline = false;
                                ___CHtmlFontInfo.___isItalic = false;
                                ___CHtmlFontInfo.___isStrikeout = false;
                                ___CHtmlFontInfo.___isBold = false;

                            }
                            continue;
                        case "italic":
                            __fontStyleCount++;
                            if (__style != null)
                            {
                                __style.FontStyle = __sValue;
                                //__style.StyleLists["font-style"] = __sValue;
                                __style.setAttributeInner("font-style", __sValue, true, false);
                            }
                            else if (___CHtmlFontInfo != null)
                            {
                                ___CHtmlFontInfo.___isUnderline = false;
                                ___CHtmlFontInfo.___isItalic = true;
                                ___CHtmlFontInfo.___isStrikeout = false;
                                ___CHtmlFontInfo.___isBold = false;

                            }
                            continue;
                        case "underline":
                            __fontStyleCount++;
                            if (__style != null)
                            {
                                __style.FontStyle = __sValue;
                                //__style.StyleLists["font-style"] = __sValue;
                                __style.setAttributeInner("font-style", __sValue, true, false);
                            }
                            else if (___CHtmlFontInfo != null)
                            {
                                ___CHtmlFontInfo.___isUnderline = true;
                                ___CHtmlFontInfo.___isItalic = false;
                                ___CHtmlFontInfo.___isStrikeout = false;
                                ___CHtmlFontInfo.___isBold = false;

                            }
                            continue;
                        case "stlikeout":
                            __fontStyleCount++;
                            if (__style != null)
                            {
                                __style.FontStyle = __sValue;
                                //__style.StyleLists["font-style"] = __sValue;
                                __style.setAttributeInner("font-style", __sValue, true, false);
                            }
                            else if (___CHtmlFontInfo != null)
                            {
                                ___CHtmlFontInfo.___isUnderline = false;
                                ___CHtmlFontInfo.___isItalic = false;
                                ___CHtmlFontInfo.___isStrikeout = true;
                                ___CHtmlFontInfo.___isBold = false;

                            }
                            continue;
                        case "oblique":
                            __fontStyleCount++;
                            if (__style != null)
                            {
                                __style.FontStyle = __sValue;
                                //__style.StyleLists["font-style"] = __sValue;
                                __style.setAttributeInner("font-style", __sValue, true, false);
                            }
                            else if (___CHtmlFontInfo != null)
                            {
                                ___CHtmlFontInfo.___isUnderline = false;
                                ___CHtmlFontInfo.___isItalic = false;
                                ___CHtmlFontInfo.___isStrikeout = false;
                                ___CHtmlFontInfo.___isBold = true;

                            }
                            continue;

                        case "normal":
                        case "small-caps":
                        case "smallcaps":
                            __fontStyleCount++;
                            if (__style != null)
                            {
                                __style.FontVariant = __sValue;
                                //__style.StyleLists["font-variant"] = __sValue;
                                __style.setAttributeInner("font-variant", __sValue, true, false);
                            }
                            else if (___CHtmlFontInfo != null)

                            {
                                ___CHtmlFontInfo.___isUnderline = false;
                                ___CHtmlFontInfo.___isItalic = false;
                                ___CHtmlFontInfo.___isStrikeout = false;
                                ___CHtmlFontInfo.___isBold = false;

                            }

                            continue;
                        case "bold":
                        case "bolder":
                        case "boldest":
                        case "light":
                        case "lighter":
                        case "lightest":
                        case "100":
                        case "200":
                        case "300":
                        case "400":
                        case "500":
                        case "600":
                        case "700":
                        case "800":
                        case "900":
                            if (__style != null)
                            {
                                __style.FontWeight = __sValue;
                                //__style.StyleLists["font-weight"] = __sValue;
                                __style.setAttributeInner("font-weight", __sValue, true, false);
                            }
                            else if (___CHtmlFontInfo != null)
                            {
                                ___CHtmlFontInfo.___isBold = true;
                            }
                            __fontStyleCount++;
                            continue;
                        case "icon":
                        case "menu":
                        case "message-box":
                        case "status-bar":
                        case "caption":
                            /*
                            if (__style != null)
                            {
                                __style.FontFamily = GenericFontNameLow;
                                //__style.StyleLists["font-family"] = __sValue;
                                __style.setAttributeInner("font-family", __sValue, true, false);
                            } else if (___CHtmlFontInfo != null)
                            {
                                ___CHtmlFontInfo.FontName = GenericFontNameLow;
                            }
                            */
                            continue;
                        case "ultra-condensed":
                        case "extra-condensed":
                        case "condensed":
                        case "semi-condensed":
                        case "expanded":
                        case "narrower":
                        case "wider":
                            if (__style != null)
                            {
                                __style.FontStretch = __sValue;
                                //_style.StyleLists["font-stretch"] = __sValue;
                                __style.setAttributeInner("font-stretch", __sValue, true, false);
                            }
                            else if (___CHtmlFontInfo != null)
                            {
                                ___CHtmlFontInfo.___isBold = true;
                            }
                            continue;
                        default:
                            {
                                /*
                                if (string.Equals(__sValue, "sans-serif", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    sbFontFamilyBuilder.Append(FasterToLower(FontFamily.GenericSansSerif.Name));
                                    continue;
                                }
                                if (commonGraphics.SystemFontsSortedList != null && commonGraphics.SystemFontsSortedGenericList.ContainsKey(__sValue) == true)
                                {
                                    sbFontFamilyBuilder.Append(__sValue);
                                    sbFontFamilyBuilder.Append(',');
                                    continue;
                                }
                                */
                                if (char.IsNumber(__sValue[0]) == false)
                                {

                                    continue;
                                }
                                else
                                {
                                    // ==========================================================
                                    //                        Is Number
                                    // ==========================================================
                                    int __slashPos = __sValue.IndexOf('/');
                                    if (__slashPos > -1)
                                    {
                                        if (__style != null)
                                        {
                                            __style.LineHeight = __sValue.Substring(__slashPos + 1);
                                            //__style.StyleLists["line-height"] = __style.LineHeight;
                                            __style.setAttributeInner("font-height", __style.LineHeight, true, false);
                                            __style.FontSize = __sValue.Substring(0, __slashPos);
                                            //__style.StyleLists["font-size"] = __style.FontSize;
                                            __style.setAttributeInner("font-size", __style.FontSize, true, false);
                                        }
                                        else if (___CHtmlFontInfo != null)
                                        {

                                            float ___fontSize = (float)GetDoubleValueFromString(__sValue.ToString(), CSS_FONT_Size_Shoud_Be_GreaterThan, CSS_FONT_Size_Shoud_Be_GreaterThan);
                                            if (___fontSize < CSS_FONT_Size_Shoud_Be_GreaterThan)
                                            {
                                                ___fontSize = CSS_FONT_Size_Shoud_Be_GreaterThan;

                                            }
                                            ___CHtmlFontInfo.FontSize = ___fontSize;
                                        }


                                    }
                                    else
                                    {
                                        FontValidNumberCount++;
                                        if (FontValidNumberCount == 1)
                                        {
                                            if (__style != null)
                                            {
                                                __style.FontSize = __sValue;
                                                __style.setAttributeInner("font-size", __style.FontSize, true, false);
                                            }
                                            else if (___CHtmlFontInfo != null)
                                            {

                                                float ___fontSize = (float)GetDoubleValueFromString(__sValue.ToString(), CSS_FONT_Size_Shoud_Be_GreaterThan, CSS_FONT_Size_Shoud_Be_GreaterThan);
                                                if (___fontSize < CSS_FONT_Size_Shoud_Be_GreaterThan)
                                                {
                                                    ___fontSize = CSS_FONT_Size_Shoud_Be_GreaterThan;

                                                }
                                                ___CHtmlFontInfo.FontSize = ___fontSize;


                                            }
                                            continue;
                                        }
                                        else
                                        {
                                            // IE and chrome ignores second or third numeric value.
                                            // Just ignore.
                                            /*
                                            __style.lineheight = __sValue;
                                            __style.StyleLists["line-height"] = __sValue;
                                            continue;
                                            */
                                            continue;
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
                if (sbFontFamilyBuilder.Length > 0)
                {
                    if (__style != null)
                    {
                        __style.FontFamily = sbFontFamilyBuilder.ToString();
                        //__style.StyleLists["font-family"] = sbFontFamilyBuilder.ToString();
                        __style.setAttributeInner("font-family", sbFontFamilyBuilder.ToString(), true, false);
                    }
                    else if (___CHtmlFontInfo != null)
                    {
                        ___CHtmlFontInfo.FontName = sbFontFamilyBuilder.ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("SetFontStyleFromStylesheetFontValue '" + __fontValue + "'", ex);
                }
            }
        }



        internal static void SetDefaultStyePropertiesByTagType(CHtmlCSSStyleSheet style, CHtmlElementType __TagType)
        {
            if (style == null)
            {
                return;
            }
            switch (__TagType)
            {
                case CHtmlElementType.CENTER:
                    style.align = "center";
                    style.Display = "block";
                    break;
                case CHtmlElementType.TITLE:
                case CHtmlElementType.META:
                case CHtmlElementType.LINK:
                    style.Visibility = "none";
                    style.Display = "none";
                    style.___Width = "0px";
                    style.___Height = "0px";
                    break;
                case CHtmlElementType.SPAN:
                    style.Display = "inline";

                    break;
                case CHtmlElementType.NOBR:
                    style.Display = "block";
                    break;
                case CHtmlElementType.BR:
                    //style.Display = "inline";
                    //style.Width = "0px";
                    break;
                case CHtmlElementType.NOEMBED:
                    style.Display = "none";
                    break;
                case CHtmlElementType.BODY:
                    //style.BackgroundColor = "#fff";
                    //style.Color = "#000";
                    style.Display = "block";

                    break;
                case CHtmlElementType.TT:
                case CHtmlElementType.XMP:
                case CHtmlElementType.PRE:
                case CHtmlElementType.CODE:
                    style.Display = "block"; // code block should be always block.
                                             //style.BackgroundColor = "";
                                             //style.PaddingBottom = "1em";
                    style.FontFamily = "monospace";
                    style.WhiteSpace = "pre";
                    break;
                case CHtmlElementType.ABBR:
                    style.TextDecoration = "underline";
                    break;
                case CHtmlElementType.ACRONYM:
                    style.Display = "hidden";
                    break;
                case CHtmlElementType.KBD:
                case CHtmlElementType.SAMP:
                    style.Display = "block";
                    style.FontFamily = "monospace";
                    break;

                case CHtmlElementType.MENU:
                case CHtmlElementType.OL:
                    style.Display = "block";
                    //style.MarginTop = "1em";
                    style.___PaddingLeft = "30px";
                    style.___ListStyleType = "decimal";
                    break;
                case CHtmlElementType.UL:
                    style.Display = "block";
                    //style.MarginTop = "1em";
                    //style.MarginBottom = "1em";
                    style.___PaddingLeft = "5px";
                    style.___ListStyleType = "disc";
                    break;
                case CHtmlElementType.LI:
                    style.Display = "block";
                    break;
                case CHtmlElementType.DL:
                    style.Display = "block";
                    //style.MarginTop = "1em";
                    //style.MarginBottom = "1em";
                    break;
                case CHtmlElementType.DT:
                    style.Display = "block";
                    break;
                case CHtmlElementType.DD:
                    style.Display = "block";

                    break;
                case CHtmlElementType.ASIDE:
                    style.Display = "block";
                    break;
                case CHtmlElementType.CITE:
                    style.Display = "inline";
                    style.FontStyle = "italic";
                    break;
                case CHtmlElementType.SMALL:
                    style.FontSize = "0.8em";
                    style.Display = "inline";
                    break;
                case CHtmlElementType.BIG:
                    style.FontSize = "1.3em";
                    style.Display = "inline";
                    break;
                case CHtmlElementType.U:
                    style.textDecoration = "underline";
                    style.Display = "inline";
                    break;
                case CHtmlElementType.STRIKE:
                case CHtmlElementType.S:
                    style.TextDecoration = "line-through";
                    style.Display = "inline";
                    break;
                case CHtmlElementType.STRONG:
                    style.FontWeight = "bold";
                    style.Display = "inline";
                    break;
                case CHtmlElementType.A:
                    style.Display = "inline";
                    style.___IsForegroundSysColorSpecified = true;
                    style.___ForegroundSysColor = ColorSpec.MidnightBlue;
                    style.textDecorationUnderline = "true";
                    break;
                case CHtmlElementType.INS:
                case CHtmlElementType.FONT:
                    style.Display = "inline";
                    break;
                case CHtmlElementType.MARK:
                    style.Display = "inline";
                    style.___IsBackgroundColorSpecified = true;
                    style.___BackgroundSysColor = ColorSpec.Yellow;
                    style.FontWeight = "bold";
                    break;
                case CHtmlElementType.EM:
                case CHtmlElementType.VAR:
                    style.Display = "inline";
                    style.FontStyle = "italic";
                    break;
                case CHtmlElementType.ADDRESS:
                    style.Display = "block";
                    break;
                case CHtmlElementType.IMG:
                    // img is inline element from W3C standard. does not require closing tag
                    style.Display = "inline";
                    break;
                case CHtmlElementType.I:
                    style.Display = "inline";
                    style.FontStyle = "italic";
                    break;
                case CHtmlElementType.B:
                    style.Display = "inline";
                    style.FontWeight = "bold";
                    break;
                case CHtmlElementType.Q:
                    style.Display = "inline";
                    style.___Content = "open-quote";
                    style.FontStyle = "italic";
                    break;
                case CHtmlElementType.DEL:
                    style.TextDecoration = "line-through";
                    break;
                case CHtmlElementType.P:
                    style.Display = "block";
                    break;
                case CHtmlElementType.LABEL:
                    style.Display = "inline";
                    break;
                case CHtmlElementType.INPUT:
                    style.Display = "inline";
                    break;
                case CHtmlElementType.TEXTAREA:
                    style.Display = "inline"; // TEXTARA is inline element defined in HTML 4 standard
                                              //style.BackgroundColor = "#fff";
                    break;
                case CHtmlElementType.BUTTON:
                case CHtmlElementType.SEL:// combobox style
                    style.Display = "inline";
                    break;
                case CHtmlElementType.H1:
                    style.FontSize = "1.6em";
                    style.MarginLeft = "10px";
                    style.FontWeight = "";
                    style.Display = "block";
                    break;
                case CHtmlElementType.H2:
                    style.FontSize = "1.3em";
                    style.MarginLeft = "10px";
                    style.FontWeight = "";
                    style.Display = "block";
                    break;
                case CHtmlElementType.H3:
                    style.FontSize = "1.15em";
                    style.MarginLeft = "10px";
                    style.FontWeight = "";
                    style.Display = "block";
                    break;
                case CHtmlElementType.H4:
                    style.FontSize = "1.00em";
                    style.MarginLeft = "10px";
                    style.FontWeight = "";
                    style.Display = "block";
                    break;
                case CHtmlElementType.H5:
                    style.FontSize = ".83em";
                    style.MarginLeft = "10px";
                    style.FontWeight = "";
                    style.Display = "block";
                    break;
                case CHtmlElementType.H6:
                    style.FontSize = ".67em";
                    style.MarginLeft = "10px";
                    style.FontWeight = "";
                    style.Display = "block";
                    break;
                case CHtmlElementType.H7:
                    style.FontSize = ".50em";
                    style.MarginLeft = "10px";
                    style.FontWeight = "";
                    style.Display = "block";
                    break;
                case CHtmlElementType.HR:
                    style.Display = "block";
                    style.___Width = "90%";
                    style.___IsForegroundSysColorSpecified = true;
                    style.___ForegroundSysColor = ColorSpec.LightGray;
                    style.Height = "30px";
                    style.___BorderWidth = "5px";
                    style.___BorderStyle = "inset";
                    break;
                case CHtmlElementType.TABLE:
                case CHtmlElementType.TR:
                case CHtmlElementType.TH:
                case CHtmlElementType.TD:
                case CHtmlElementType.TBODY:
                case CHtmlElementType.THEAD:
                case CHtmlElementType.TFOOT:
                    style.Display = "block";
                    break;
                case CHtmlElementType.BLOCKQUOTE:
                    style.Display = "block";
                    style.MarginTop = "1em";
                    style.MarginLeft = "30px";
                    style.MarginRight = "30px";
                    break;
                case CHtmlElementType.IFRAME:
                case CHtmlElementType.OBJECT:
                    style.Display = "block";
                    break;
                case CHtmlElementType.PARAM:
                case CHtmlElementType.OPTION:
                    style.Display = "none";
                    style.Visibility = "none";
                    break;
                case CHtmlElementType.SELECTION:
                case CHtmlElementType.NAV:
                case CHtmlElementType.FOOTER:
                case CHtmlElementType.DIV:
                    style.Display = "block";
                    break;
                // HTML 5 Tags
                case CHtmlElementType.RUBY:
                    style.Display = "inline";
                    break;
                case CHtmlElementType.RT:
                    //style.Display = "ruby-text";
                    break;
                case CHtmlElementType.RP:
                    style.Display = "none";
                    break;
                case CHtmlElementType.NOSCRIPT:
                case CHtmlElementType.COMMENT:

                    style.Display = "none";
                    style.Visibility = "hidden";
                    break;
                case CHtmlElementType.FRAMESET:
                    style.Width = "100%";
                    style.Height = "100%";
                    style.Display = "block";
                    // style.backgroundcolor = "#DCDCDC";
                    break;
                case CHtmlElementType.FRAME:
                    style.Width = "100%";
                    style.Height = "100%";
                    style.Display = "block";
                    break;
                case CHtmlElementType.NOFRAME:
                case CHtmlElementType.NOFRAMES:
                    style.Display = "none";
                    style.Visibility = "hidden";
                    break;
                case CHtmlElementType.SCRIPT:

                    style.Display = "none";
                    style.Visibility = "hidden";
                    break;


                case CHtmlElementType.MAP:
                case CHtmlElementType.AREA:
                    style.Display = "block";
                    style.Visibility = "hidden";
                    break;
                case CHtmlElementType.CANVAS:
                    if (string.IsNullOrEmpty(style.___Display) == true)
                    {
                        style.Display = "block";
                    }
                    /*
                    if (string.IsNullOrEmpty(style.___Width) == true)
                    {
                        style.Width = "300px";
                    }
                    if (string.IsNullOrEmpty(style.___Height) == true)
                    {
                        style.Height = "200px";
                    }
                     */
                    break;
                case CHtmlElementType.VIDEO:
                case CHtmlElementType.AUDIO:
                case CHtmlElementType.FIGURE:
                    style.Display = "block";
                    break;
                case CHtmlElementType.TEMPLATE:
                case CHtmlElementType.XHTML:
                case CHtmlElementType.XML:
                    style.Display = "block";
                    style.Visibility = "none";
                    break;
                case CHtmlElementType.TIME:
                    style.Display = "inline";
                    style.FontStyle = "italic";
                    break;

                case CHtmlElementType._ITEXT:
                    style.Display = "inline";
                    break;
                case CHtmlElementType.DATALIST:
                    style.Display = "none";
                    style.Visibility = "hidden";
                    break;
                case CHtmlElementType.TEXT:
                    style.Display = "inline";
                    break;
                case CHtmlElementType.ASTERISK:
                    style.Display = "block";
                    break;
                case CHtmlElementType.ARTICLE:
                case CHtmlElementType.SECTION:
                    style.Display = "block";
                    break;
                default:
                    if ((int)__TagType < 1000)
                    {
                        style.Display = "block";
                    }
                    else
                    {
                        style.Display = "inline";
                    }
                    break;
            }

        }




        internal static bool ___isStringBuilderContainedHTMLCompleteDocument(ref System.Text.StringBuilder sbText, ref int ___htmlTagStartHeadPos, ref int ___htmlTagEndHeadPos)
        {
            try
            {
                if (sbText == null || sbText.Length == 0)
                    return false;
                char c0 = '\0';
                char ca1 = '\0';
                int sbLen = sbText.Length;
                ___htmlTagStartHeadPos = -1;
                ___htmlTagEndHeadPos = -1;
                for (int i = 0; i < sbLen; i++)
                {
                    c0 = sbText[i];
                    if (i + 1 < sbLen)
                    {
                        ca1 = sbText[i + 1];
                    }
                    switch (c0)
                    {
                        case '<':
                            if (ca1 == 'h' || ca1 == 'H')
                            {
                                string str4Chars = null;
                                if (i + 5 < sbLen)
                                {
                                    str4Chars = sbText.ToString(i + 1, 4);
                                    if (string.Equals(str4Chars, "html", StringComparison.OrdinalIgnoreCase) == true)
                                    {
                                        ___htmlTagStartHeadPos = i;
                                        goto HTMLLookupDonePhase;
                                    }
                                }
                            }
                            break;
                    }
                    if (i > 1000)
                        break;
                }
            HTMLLookupDonePhase:
                for (int i = sbLen - 1; i >= 0; i--)
                {
                    c0 = sbText[i];
                    if (i < sbLen - 2)
                    {
                        ca1 = sbText[i + 1];
                    }
                    if (c0 == '<')
                    {
                        if (ca1 == '/')
                        {
                            string str4End = null;
                            if (i + 4 < sbLen)
                            {
                                str4End = sbText.ToString(i + 2, 4);
                                if (string.Equals(str4End, "html", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    bool IsTagCloseComplete = false;
                                    if (i < sbLen - 6)
                                    {
                                        if (sbText[i + 6] == '>')
                                        {
                                            IsTagCloseComplete = true;
                                        }
                                        else if (IsCharWhiteSpaceLimited(sbText[i + 5]) == true)
                                        {
                                            for (int endpos = i + 6; endpos < sbLen; endpos++)
                                            {
                                                char cend = sbText[endpos];
                                                if (IsCharWhiteSpaceLimited(cend) == true)
                                                    continue;
                                                else if (char.IsLetterOrDigit(cend))
                                                    break;
                                                else if (cend == '>')
                                                {
                                                    IsTagCloseComplete = true;
                                                    break;
                                                }

                                            }
                                        }
                                    }
                                    if (IsTagCloseComplete == true)
                                    {
                                        ___htmlTagEndHeadPos = i;
                                        return true;
                                    }
                                }
                            }

                        }
                    }
                    if (i < sbLen - 150)
                    {
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("___isStringBuilderContainedHTMLCompleteDocument Exception", ex);
                }
            }
            return false;
        }






        public static CSSBorderStyleType GetBorderStyle(string str)
        {
            switch (str)
            {
                case "none":
                    return CSSBorderStyleType.none;

                case "double":
                    return CSSBorderStyleType.@double;

                case "solid":
                    return CSSBorderStyleType.solid;

                case "groove":
                    return CSSBorderStyleType.groove;

                case "ridge":
                    return CSSBorderStyleType.ridge;

                case "inset":
                    return CSSBorderStyleType.inset;

                case "outset":
                    return CSSBorderStyleType.outset;

                case "dashed":
                    return CSSBorderStyleType.dashed;

                case "dotted":
                    return CSSBorderStyleType.dotted;

                default:
                    return CSSBorderStyleType.unknown;

            }

        }
        /// <summary>
        /// Parse CSS Border-Style by the corner
        /// </summary>
        /// <param name="___style"></param>
        /// <param name="styleValue"></param>
        /// <param name="CornerParam"></param>
        public static void parseBorder_Style(CHtmlCSSStyleSheet ___style, string styleValue, int CornerParam)
        {
            CSSBorderStyleType ___borderStyle = GetBorderStyle(styleValue);
            if (___borderStyle != CSSBorderStyleType.unknown)
            {
                switch (CornerParam)
                {
                    case 0:
                        ___style.___BorderTopStyleComputedValue = ___borderStyle;
                        ___style.___BorderLeftStyleComputedValue = ___borderStyle;
                        ___style.___BorderRightStyleComputedValue = ___borderStyle;
                        ___style.___BorderBottomStyleComputedValue = ___borderStyle;
                        break;
                    case 1:
                        ___style.___BorderLeftStyleComputedValue = ___borderStyle;
                        break;
                    case 2:
                        ___style.___BorderTopStyleComputedValue = ___borderStyle;
                        break;
                    case 3:
                        ___style.___BorderRightStyleComputedValue = ___borderStyle;
                        break;
                    case 4:
                        ___style.___BorderBottomStyleComputedValue = ___borderStyle;
                        break;
                }
            }
        }
        public static void parseCSSBackgroundPosition(CHtmlCSSStyleSheet ___style, string styleValue, int CornerParam, CHtmlElement ___elem)
        {
            try
            {
                int ___konmacount = 0;
                string[] spValues = SplitMultipleValuesToArray(styleValue, ref ___konmacount, true);
                if (___konmacount > 0)
                {
                    if (___konmacount + 1 == ___style.___multipleBackgroundImageDataSet.Count)
                    {
                        for (int i = 0; i < spValues.Length; i++)
                        {
                            CHtmlStyleElementMultpleImageData ___multiData = ___style.___multipleBackgroundImageDataSet[i];
                            if (___multiData != null)
                            {
                                ___multiData.backgroundPositionString = spValues[i];
                                ___multiData.___analyzeBackgroundPositionString(___elem);
                            }
                        }
                    }
                    else
                    {
                        CHtmlStyleElementMultpleImageData ___multiData = null;
                        if (___style.___multipleBackgroundImageDataSet.Count == 0)
                        {
                            ___multiData = new CHtmlStyleElementMultpleImageData();
                            ___style.___multipleBackgroundImageDataSet.Add(___multiData);
                        }
                        else
                        {
                            ___multiData = ___style.___multipleBackgroundImageDataSet[0];
                        }
                        if (___multiData != null)
                        {
                            ___multiData.backgroundPositionString = spValues[0];
                            ___multiData.___analyzeBackgroundPositionString(___elem);
                        }
                    }
                }
                else
                {
                    CHtmlStyleElementMultpleImageData ___multiData = null;
                    if (___style.___multipleBackgroundImageDataSet.Count == 0)
                    {
                        ___multiData = new CHtmlStyleElementMultpleImageData();
                        ___style.___multipleBackgroundImageDataSet.Add(___multiData);
                    }
                    else
                    {
                        ___multiData = ___style.___multipleBackgroundImageDataSet[0];
                    }
                    if (___multiData != null)
                    {
                        ___multiData.backgroundPositionString = styleValue;
                        if (spValues.Length > 0)
                        {
                            ___multiData.backgroundPosition_X_String = spValues[0];
                        }
                        if (spValues.Length == 2)
                        {
                            ___multiData.backgroundPosition_Y_String = spValues[1];
                        }
                        ___multiData.___analyzeBackgroundPositionString(___elem);
                    }
                }

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("Parse backgroundPosition Exception", ex);
                }
            }
        }
        public static void parseCSSBackgroundRepeat(CHtmlCSSStyleSheet ___style, string styleValue, int CornerParam)
        {
            try
            {
                int ___konmacount = 0;
                string[] spValues = SplitMultipleValuesToArray(styleValue, ref ___konmacount, true);
                if (___konmacount + 1 == ___style.___multipleBackgroundImageDataSet.Count)
                {
                    for (int i = 0; i < spValues.Length; i++)
                    {
                        CHtmlStyleElementMultpleImageData ___multiData = ___style.___multipleBackgroundImageDataSet[i];
                        if (___multiData != null)
                        {
                            ___multiData.backgroundRepeatString = spValues[i];
                            ___multiData.___analyzeBackgroundRepeatString();
                        }
                    }
                }
                else
                {
                    CHtmlStyleElementMultpleImageData ___multiData = null;
                    bool ___NeedsSetMultipleDataSetAlso = false;
                    if (___style.___multipleBackgroundImageDataSet.Count == 0)
                    {
                        ___multiData = new CHtmlStyleElementMultpleImageData();
                        ___style.___multipleBackgroundImageDataSet.Add(___multiData);
                    }
                    else
                    {
                        ___multiData = ___style.___multipleBackgroundImageDataSet[0];
                        if (___style.___multipleBackgroundImageDataSet.Count >= 2)
                        {
                            ___NeedsSetMultipleDataSetAlso = true;
                        }
                    }
                    if (___multiData != null)
                    {
                        ___multiData.backgroundRepeatString = spValues[0];
                        ___multiData.___analyzeBackgroundRepeatString();
                    }
                    if (___NeedsSetMultipleDataSetAlso == true)
                    {
                        for (int m = 2; m < ___style.___multipleBackgroundImageDataSet.Count; m++)
                        {
                            CHtmlStyleElementMultpleImageData ___extraData = ___style.___multipleBackgroundImageDataSet[m];
                            if (___extraData != null)
                            {
                                ___extraData.backgroundRepeatString = spValues[0];
                                ___multiData.___analyzeBackgroundRepeatString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("Parse backgroundRepeat Exception", ex);
                }
            }
        }
        public static void parseBorder_Color(CHtmlCSSStyleSheet ___style, string styleValue, int CornerParam)
        {
            try
            {
                if (CornerParam != 0)
                {
                    System.Drawing.Color ___borderColor = Color.Empty;
                    // ========================================================
                    //  Some Case it may ___hasInner multiple colors in check it. it it is multiple values ___getInner first one.
                    // ========================================================
                    string[] spColors = null;
                    if (styleValue.IndexOf('(') > -1)
                    {
                        int posFirstEndQuote = -1;
                        int posLastEndQuote = -1;
                        posFirstEndQuote = styleValue.IndexOf(')');
                        posLastEndQuote = styleValue.LastIndexOf(')');
                        if (posFirstEndQuote == posLastEndQuote)
                        {
                            if (styleValue.StartsWith("rgb(", StringComparison.OrdinalIgnoreCase) == true || styleValue.StartsWith("rgba(", StringComparison.OrdinalIgnoreCase) == true || styleValue.StartsWith("hsl(", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                spColors = new string[] { styleValue };
                                goto SplitDonePhase;
                            }
                        }
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                        {
                            commonLog.LogEntry("TODO: Manual Parse Color Values requred : {0}", styleValue);
                        }
                        return;
                    }
                    else
                    {
                        spColors = styleValue.Split(CharSpaceCrLfTabZentakuSpace);
                    }
                SplitDonePhase:
                    if (spColors.Length <= 1)
                    {
                        ___borderColor = GetColorFromHTMLColorExtend(styleValue);
                    }
                    else
                    {
                        ___borderColor = GetColorFromHTMLColorExtend(spColors[0]);
                    }
                    switch (CornerParam)
                    {
                        case 0:
                            ___style.___BorderTopColorComputedValue = ___borderColor;
                            ___style.___BorderLeftColorComputedValue = ___borderColor;
                            ___style.___BorderRightColorComputedValue = ___borderColor;
                            ___style.___BorderBottomColorComputedValue = ___borderColor;
                            ___style.___BorderLeftColorComputedValueSpecified = true;
                            ___style.___BorderTopColorComputedValueSpecified = true;
                            ___style.___BorderRightColorComputedValueSpecified = true;
                            ___style.___BorderBottomColorComputedValueSpecified = true;
                            break;
                        case 1:
                            ___style.___BorderLeftColorComputedValue = ___borderColor;
                            ___style.___BorderLeftColorComputedValueSpecified = true;
                            break;
                        case 2:
                            ___style.___BorderTopColorComputedValue = ___borderColor;
                            ___style.___BorderTopColorComputedValueSpecified = true;
                            break;
                        case 3:
                            ___style.___BorderRightColorComputedValue = ___borderColor;
                            ___style.___BorderRightColorComputedValueSpecified = true;
                            break;
                        case 4:
                            ___style.___BorderBottomColorComputedValue = ___borderColor;
                            ___style.___BorderBottomColorComputedValueSpecified = true;
                            break;
                    }
                }
                else
                {
                    int ___properConmaCount = 0;
                    string[] spColors = SplitMultipleValuesToArray(styleValue, ref ___properConmaCount, false);
                    if (spColors.Length != 0)
                    {
                        int ColorPosition = 0;
                        for (int i = 0; i < spColors.Length; i++)
                        {
                            System.Drawing.Color ___borderColor = GetColorFromHTMLColorExtend(spColors[i]);
                            ColorPosition++;
                            switch (ColorPosition)
                            {
                                case 1:
                                    ___style.___BorderLeftColorComputedValue = ___borderColor;
                                    ___style.___BorderLeftColorComputedValueSpecified = true;
                                    break;
                                case 2:
                                    ___style.___BorderTopColorComputedValue = ___borderColor;
                                    ___style.___BorderTopColorComputedValueSpecified = true;
                                    break;
                                case 3:
                                    ___style.___BorderRightColorComputedValue = ___borderColor;
                                    ___style.___BorderRightColorComputedValueSpecified = true;
                                    break;
                                case 4:
                                    ___style.___BorderBottomColorComputedValue = ___borderColor;
                                    ___style.___BorderBottomColorComputedValueSpecified = true;
                                    break;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("Parse Border_Color", ex);
                }
            }
        }


        public static void parseBorder_Width(CHtmlCSSStyleSheet ___style, string styleValue, int CornerParam, double ___remSize)
        {

            string[] spValues = styleValue.Split(CharSpaceCrLfTabZentakuSpace);
            int valueCount = 0;
            int valuePosition = 0;
            int spValuesLen = spValues.Length;
            for (int i = 0; i < spValuesLen; i++)
            {
                if (string.IsNullOrEmpty(spValues[i]) == false)
                {
                    valueCount++;
                }
            }
            for (int i = 0; i < spValuesLen; i++)
            {
                if (string.IsNullOrEmpty(spValues[i]) == false)
                {
                    valuePosition++;
                    /*
                        border-width: 2px; … ［上下左右］ を指定
                        border-width: 2px 4px; … ［上下］ と ［左右］ を指定
                        border-width: 2px 4px 6px; … ［上］ と ［左右］ と ［下］ を指定
                        border-width: 2px 4px 6px 8px; … ［上］ と ［右］ と ［下］ と ［左］ を指定
                    */
                    double ___borderWidth = 0;
                    if (char.IsNumber(spValues[i][0]) == true)
                    {
                        ___borderWidth = GetDoubleValueFromString(spValues[i], 0, ___remSize);
                    }
                    else
                    {
                        if (string.Equals(spValues[i], "thin", StringComparison.OrdinalIgnoreCase) == true)
                        {

                            ___borderWidth = 1;
                        }
                        else if (string.Equals(spValues[i], "medium", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            ___borderWidth = 2;
                        }
                        else if (string.Equals(spValues[i], "thick", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            ___borderWidth = 3;

                        }
                    }
                    if (___borderWidth >= 100)
                    {
                        ___borderWidth = 1;
                    }

                    if (___borderWidth > 0)
                    {
                        switch (CornerParam)
                        {
                            case 0:
                                switch (valueCount)
                                {
                                    case 1:
                                        {
                                            ___style.___BorderTopWidthComputedValue = ___borderWidth;
                                            ___style.___BorderLeftWidthComputedValue = ___borderWidth;
                                            ___style.___BorderRightWidthComputedValue = ___borderWidth;
                                            ___style.___BorderBottomWidthComputedValue = ___borderWidth;
                                        }
                                        break;
                                    case 2:
                                        {
                                            switch (valuePosition)
                                            {
                                                case 1:
                                                    ___style.___BorderTopWidthComputedValue = ___borderWidth;
                                                    ___style.___BorderBottomWidthComputedValue = ___borderWidth;
                                                    break;
                                                case 2:
                                                    ___style.___BorderLeftWidthComputedValue = ___borderWidth;
                                                    ___style.___BorderRightWidthComputedValue = ___borderWidth;
                                                    break;
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            switch (valuePosition)
                                            {
                                                case 1:
                                                    ___style.___BorderTopWidthComputedValue = ___borderWidth;

                                                    break;
                                                case 2:
                                                    ___style.___BorderLeftWidthComputedValue = ___borderWidth;
                                                    ___style.___BorderRightWidthComputedValue = ___borderWidth;
                                                    break;
                                                case 3:
                                                    ___style.___BorderBottomWidthComputedValue = ___borderWidth;
                                                    break;

                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            switch (valuePosition)
                                            {
                                                case 1:
                                                    ___style.___BorderTopWidthComputedValue = ___borderWidth;

                                                    break;
                                                case 2:
                                                    ___style.___BorderLeftWidthComputedValue = ___borderWidth;
                                                    break;
                                                case 3:
                                                    ___style.___BorderRightWidthComputedValue = ___borderWidth;
                                                    break;
                                                case 4:
                                                    ___style.___BorderBottomWidthComputedValue = ___borderWidth;
                                                    break;
                                            }
                                            break;
                                        }

                                }
                                break;
                            case 1:
                                ___style.___BorderLeftWidthComputedValue = ___borderWidth;
                                break;
                            case 2:
                                ___style.___BorderTopWidthComputedValue = ___borderWidth;
                                break;
                            case 3:
                                ___style.___BorderRightWidthComputedValue = ___borderWidth;
                                break;
                            case 4:
                                ___style.___BorderBottomWidthComputedValue = ___borderWidth;
                                break;
                        }
                    }
                }
            }
        }


        #region SetCHTMLElementStyleSheet4NameAnd4Value
        public static void SetCHTMLElementBorderStyle(CHtmlElement htmlControl, string __name, string __value, double ___remSize)
        {
            string[] spValues = __value.Split(' ');
            string __borderStyle = "";
            string __borderWidth = "";
            string __borderColor = "";
            int spValuesCount = spValues.Length;
            for (int i = 0; i < spValuesCount; i++)
            {
                string s = spValues[i];
                switch (s)
                {
                    case "":
                        break;
                    case "solid":
                    case "inset":
                    case "dotted":
                    case "double":
                    case "ridge":
                    case "outset":
                    case "dashed":
                    case "none":
                        __borderStyle = s;
                        break;
                    case "0":
                    case "0px":
                        __borderWidth = "0px";
                        break;
                    case "1":
                    case "1px":
                    case "thin":
                        __borderWidth = "1px";
                        break;
                    case "2":
                    case "2px":
                    case "medium":
                        __borderWidth = "2px";
                        break;
                    case "3":
                    case "3px":
                    case "thick":
                        __borderWidth = "3px";
                        break;
                    case "4":
                    case "4px":
                        __borderWidth = "4px";
                        break;
                    case "5":
                    case "5px":
                        __borderWidth = "5px";
                        break;
                    case "6":
                    case "6px":
                        __borderWidth = "6px";
                        break;
                    case "7":
                    case "7px":
                        __borderWidth = "7px";
                        break;
                    case "8":
                    case "8px":
                        __borderWidth = "8px";
                        break;
                    case "9":
                    case "9px":
                        __borderWidth = "9px";
                        break;
                    default:
                        if (s.Length > 0 && s[0] == '#')
                        {
                            __borderColor = s;
                            continue;
                        }
                        if (commonHTML.CHtmlHTMLColorNamesDictionary.ContainsKey(s))
                        {
                            __borderColor = s;
                            continue;
                        }
                        break;
                }
            }
            switch (__name)
            {
                case "border-bottom":
                    htmlControl.___style.BorderBottomColor = __borderColor;
                    htmlControl.___style.BorderBottomWidth = __borderWidth;
                    htmlControl.___style.BorderBottomStyle = __borderStyle;
                    break;
                case "border-left":
                    htmlControl.___style.BorderLeftColor = __borderColor;
                    htmlControl.___style.BorderLeftWidth = __borderWidth;
                    htmlControl.___style.BorderLeftStyle = __borderStyle;
                    break;
                case "border-right":
                    htmlControl.___style.BorderRightColor = __borderColor;
                    htmlControl.___style.BorderRightWidth = __borderWidth;
                    htmlControl.___style.BorderRightStyle = __borderStyle;
                    break;
                case "border-top":
                    htmlControl.___style.BorderTopColor = __borderColor;
                    htmlControl.___style.BorderTopWidth = __borderWidth;
                    htmlControl.___style.BorderTopStyle = __borderStyle;
                    break;
            }
        }
        #endregion

        public static void ___parseCSSBackgroundSizePhase2(CHtmlStyleElementMultpleImageData ___multidata, string[] spValues, CHtmlElement ___elem)
        {
            // =====================================
            // There is possible multiple valures in splited Values 
            // =====================================
            System.Collections.Generic.List<string> spCheckedList = new System.Collections.Generic.List<string>();
            foreach (string s in spValues)
            {
                if (string.IsNullOrEmpty(s) == false)
                {
                    if (s.IndexOfAny(CharSpaceCrLfTabZentakuSpaceComma) > -1)
                    {
                        spCheckedList.AddRange(s.Split(CharSpaceCrLfTabZentakuSpaceComma));
                    }
                    else
                    {
                        spCheckedList.Add(s);
                    }
                }
            }

            // =====================================
            int spLen = spCheckedList.Count;
            string strValue = null;
            int valuePosition = 0;
            for (int i = 0; i < spLen; i++)
            {
                strValue = spCheckedList[i];
                if (strValue.Length != 0)
                {
                    valuePosition++;
                    if (char.IsNumber(strValue[0]) == true)
                    {
                        double ___criteriaValue = 0;
                        if (strValue[strValue.Length - 1] == '%')
                        {
                            double strPercent = 0;
                            if (double.TryParse(strValue.Substring(0, strValue.Length - 1), out strPercent) == true)
                            {
                                if (valuePosition == 1)
                                {
                                    ___multidata.backgroundSize_X_ComputedValue = strPercent / 100f;
                                    ___multidata.backgroundSizeWidthComputedType = CSSBackgroundSizeType.NumericValue;
                                }
                                else
                                {
                                    ___multidata.backgroundSize_Y_ComputedValue = strPercent / 100f;
                                    ___multidata.backgroundSizeHeightComputedType = CSSBackgroundSizeType.NumericValue;
                                }
                            }

                            continue;
                        }
                        double doubleValue = GetDoubleValueFromString(strValue, ___criteriaValue, ___elem.___HTMLTagRemUnitSize);
                        if (doubleValue > 0)
                        {
                            if (valuePosition == 1)
                            {
                                ___multidata.backgroundSizeWidthComputedType = CSSBackgroundSizeType.NumericValue;
                                ___multidata.backgroundSize_X_ComputedValue = (int)doubleValue;
                            }
                            else
                            {
                                ___multidata.backgroundSizeHeightComputedType = CSSBackgroundSizeType.NumericValue;
                                ___multidata.backgroundSize_Y_ComputedValue = (int)doubleValue;
                            }
                        }
                    }
                    else
                    {
                        switch (strValue)
                        {
                            case "auto":
                                if (valuePosition == 1)
                                {
                                    ___multidata.backgroundSizeWidthComputedType = CSSBackgroundSizeType.Auto;
                                }
                                else
                                {
                                    ___multidata.backgroundSizeHeightComputedType = CSSBackgroundSizeType.Cover;
                                }
                                break;
                            case "contain":
                                if (valuePosition == 1)
                                {
                                    ___multidata.backgroundSizeWidthComputedType = CSSBackgroundSizeType.Contain;
                                }
                                else
                                {
                                    ___multidata.backgroundSizeHeightComputedType = CSSBackgroundSizeType.Cover;
                                }
                                break;
                            case "cover":
                                if (valuePosition == 1)
                                {
                                    ___multidata.backgroundSizeWidthComputedType = CSSBackgroundSizeType.Cover;
                                }
                                else
                                {
                                    ___multidata.backgroundSizeHeightComputedType = CSSBackgroundSizeType.Cover;
                                }
                                break;
                        }
                    }
                }
            }
        }
        public static void parseCSSBackgroundSize(CHtmlCSSStyleSheet ___style, string styleValue, double ___remSize, CHtmlElement ___elem)
        {
            try
            {
                if (string.IsNullOrEmpty(___style.___BackgroundSize) == true)
                {

                    return;
                }
                else
                {
                    int ___properKonmaCount = 0;
                    string[] spValues = SplitMultipleValuesToArray(styleValue, ref ___properKonmaCount, true);
                    if (___properKonmaCount + 1 > ___style.___multipleBackgroundImageDataSet.Count)
                    {
                        CHtmlStyleElementMultpleImageData ___multiData = null;
                        for (int p = 0; p < spValues.Length; p++)
                        {
                            string[] spValuesSecond = SplitMultipleValuesToArray(spValues[p], ref ___properKonmaCount, false);
                            if (___style.___multipleBackgroundImageDataSet.Count > p)
                            {
                                ___multiData = ___style.___multipleBackgroundImageDataSet[p];
                            }
                            if (___multiData != null)
                            {
                                ___parseCSSBackgroundSizePhase2(___multiData, spValuesSecond, ___elem);
                            }
                        }

                    }
                    else
                    {
                        CHtmlStyleElementMultpleImageData ___multiData = null;
                        if (___style.___multipleBackgroundImageDataSet.Count == 0)
                        {
                            ___multiData = new CHtmlStyleElementMultpleImageData();
                            ___style.___multipleBackgroundImageDataSet.Add(___multiData);
                        }
                        else
                        {
                            ___multiData = ___style.___multipleBackgroundImageDataSet[0];
                        }
                        if (___multiData != null)
                        {
                            ___multiData.backgroundSizeString = string.Copy(styleValue);
                            ___parseCSSBackgroundSizePhase2(___multiData, spValues, ___elem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("parseCSSBorderBackgroundSize Error ", ex);
                }
            }

        }
        public static void parseCSSOverFlowString(CHtmlCSSStyleSheet ___style, string styleValue, int ValueParam)
        {
            switch (styleValue)
            {
                case "auto":
                case "Auto":
                case "AUTO":
                    switch (ValueParam)
                    {
                        case 0:
                            ___style.___OverFlowXComputedType = CSSOverFlowType.Auto;
                            ___style.___OverFlowYComputedType = CSSOverFlowType.Auto;
                            break;
                        case 1:
                            ___style.___OverFlowXComputedType = CSSOverFlowType.Auto;
                            break;
                        case 2:
                            ___style.___OverFlowYComputedType = CSSOverFlowType.Auto;
                            break;
                    }
                    break;
                case "hidden":
                case "Hidden":
                case "HIDDEN":
                    switch (ValueParam)
                    {
                        case 0:
                            if (___style.___styleSizeMode == CHtmlSizeModeType.Width || ___style.___styleSizeMode == CHtmlSizeModeType.Both)
                            {
                                ___style.___OverFlowXComputedType = CSSOverFlowType.Hidden;
                            }
                            else
                            {
                                ___style.___OverFlowXComputedType = CSSOverFlowType.Visible;
                            }
                            if (___style.___styleSizeMode == CHtmlSizeModeType.Height || ___style.___styleSizeMode == CHtmlSizeModeType.Both)
                            {
                                ___style.___OverFlowYComputedType = CSSOverFlowType.Hidden;
                            }
                            else
                            {
                                ___style.___OverFlowYComputedType = CSSOverFlowType.Visible;
                            }
                            return;
                        case 1:
                            if (___style.___styleSizeMode == CHtmlSizeModeType.Width || ___style.___styleSizeMode == CHtmlSizeModeType.Both)
                            {
                                ___style.___OverFlowXComputedType = CSSOverFlowType.Hidden;
                            }
                            else
                            {
                                ___style.___OverFlowXComputedType = CSSOverFlowType.Visible;
                            }
                            return;
                        case 2:
                            if (___style.___styleSizeMode == CHtmlSizeModeType.Height || ___style.___styleSizeMode == CHtmlSizeModeType.Both)
                            {
                                ___style.___OverFlowYComputedType = CSSOverFlowType.Hidden;
                            }
                            else
                            {
                                ___style.___OverFlowYComputedType = CSSOverFlowType.Visible;
                            }
                            return;
                    }
                    return;
                case "scroll":
                case "Scroll":
                case "SCROLL":
                    switch (ValueParam)
                    {
                        case 0:
                            if (___style.___styleSizeMode == CHtmlSizeModeType.Width || ___style.___styleSizeMode == CHtmlSizeModeType.Both)
                            {
                                ___style.___OverFlowXComputedType = CSSOverFlowType.Scroll;
                            }
                            else
                            {
                                ___style.___OverFlowXComputedType = CSSOverFlowType.Visible;
                            }
                            if (___style.___styleSizeMode == CHtmlSizeModeType.Height || ___style.___styleSizeMode == CHtmlSizeModeType.Both)
                            {
                                ___style.___OverFlowYComputedType = CSSOverFlowType.Scroll;
                            }
                            else
                            {
                                ___style.___OverFlowYComputedType = CSSOverFlowType.Visible;
                            }
                            break;
                        case 1:
                            if (___style.___styleSizeMode == CHtmlSizeModeType.Width || ___style.___styleSizeMode == CHtmlSizeModeType.Both)
                            {
                                ___style.___OverFlowXComputedType = CSSOverFlowType.Scroll;
                            }
                            else
                            {
                                ___style.___OverFlowXComputedType = CSSOverFlowType.Visible;
                            }
                            break;
                        case 2:
                            if (___style.___styleSizeMode == CHtmlSizeModeType.Height || ___style.___styleSizeMode == CHtmlSizeModeType.Both)
                            {
                                ___style.___OverFlowYComputedType = CSSOverFlowType.Scroll;
                            }
                            else
                            {
                                ___style.___OverFlowYComputedType = CSSOverFlowType.Visible;
                            }
                            break;
                    }
                    break;
                case "visible":
                case "Visible":
                case "VISIBLE":
                    switch (ValueParam)
                    {
                        case 0:
                            ___style.___OverFlowXComputedType = CSSOverFlowType.Visible;
                            ___style.___OverFlowYComputedType = CSSOverFlowType.Visible;
                            break;
                        case 1:
                            ___style.___OverFlowXComputedType = CSSOverFlowType.Visible;
                            break;
                        case 2:
                            ___style.___OverFlowYComputedType = CSSOverFlowType.Visible;
                            break;
                    }
                    break;

            }
        }
        #region parseCSSBorderString
        public static void parseCSSBorderString(CHtmlCSSStyleSheet ___style, string styleValue, int CornerParam)
        {
            try
            {
                int ___properConmaCount = 0;
                string[] spValues = SplitMultipleValuesToArray(styleValue, ref ___properConmaCount, false);
                int spLen = spValues.Length;
                string strValue = "";
                int valuePosition = 0;
                bool IsValueStyle = false;
                for (int i = 0; i < spLen; i++)
                {
                    IsValueStyle = false;
                    strValue = spValues[i];
                    if (strValue.Length != 0)
                    {
                        valuePosition++;
                        if (char.IsNumber(strValue[0]) || strValue[0] == '-')
                        {
                            double ___borderWidth = commonData.GetDoubleFromObject(strValue, 0);
                            switch (CornerParam)
                            {
                                case 0:
                                    ___style.___BorderLeftWidthComputedValue = ___borderWidth;
                                    ___style.___BorderRightWidthComputedValue = ___borderWidth;
                                    ___style.___BorderTopWidthComputedValue = ___borderWidth;
                                    ___style.___BorderBottomWidthComputedValue = ___borderWidth;
                                    break;
                                case 1:
                                    ___style.___BorderLeftWidthComputedValue = ___borderWidth;
                                    break;
                                case 2:
                                    ___style.___BorderTopWidthComputedValue = ___borderWidth;
                                    break;
                                case 3:
                                    ___style.___BorderRightWidthComputedValue = ___borderWidth;
                                    break;
                                case 4:
                                    ___style.___BorderBottomWidthComputedValue = ___borderWidth;
                                    break;
                            }
                        }

                        switch (strValue)
                        {
                            case "solid":
                            case "inset":
                            case "outset":
                            case "auto":
                            case "groove":
                            case "double":
                            case "hidden":
                            case "dotted":
                            case "doted":
                            case "none":
                            case "dashed":
                                IsValueStyle = true;
                                break;
                        }
                        if (IsValueStyle == true)
                        {
                            CSSBorderStyleType ___borderStyle = CSSBorderStyleType.unknown;
                            ___borderStyle = GetBorderStyle(strValue);
                            if (___borderStyle != CSSBorderStyleType.unknown)
                            {
                                switch (CornerParam)
                                {
                                    case 0:
                                        ___style.___BorderLeftStyleComputedValue = ___borderStyle;
                                        ___style.___BorderRightStyleComputedValue = ___borderStyle;
                                        ___style.___BorderTopStyleComputedValue = ___borderStyle;
                                        ___style.___BorderBottomStyleComputedValue = ___borderStyle;
                                        break;
                                    case 1:
                                        ___style.___BorderLeftStyleComputedValue = ___borderStyle;
                                        break;
                                    case 2:
                                        ___style.___BorderTopStyleComputedValue = ___borderStyle;
                                        break;
                                    case 3:
                                        ___style.___BorderRightStyleComputedValue = ___borderStyle;
                                        break;
                                    case 4:
                                        ___style.___BorderBottomStyleComputedValue = ___borderStyle;
                                        break;
                                }
                            }
                        }
                        else if (strValue[0] == '#' || CHtmlHTMLColorNamesDictionary.ContainsKey(strValue) == true || strValue.StartsWith("rgb(", StringComparison.OrdinalIgnoreCase) || strValue.StartsWith("rgba(", StringComparison.OrdinalIgnoreCase))
                        {
                            System.Drawing.Color ___colorValue = GetColorFromHTMLColorExtend(strValue);
                            switch (CornerParam)
                            {
                                case 0:
                                    ___style.___BorderLeftColorComputedValue = ___colorValue;
                                    ___style.___BorderRightColorComputedValue = ___colorValue;
                                    ___style.___BorderTopColorComputedValue = ___colorValue;
                                    ___style.___BorderBottomColorComputedValue = ___colorValue;
                                    ___style.___BorderLeftColorComputedValueSpecified = true;
                                    ___style.___BorderRightColorComputedValueSpecified = true;
                                    ___style.___BorderTopColorComputedValueSpecified = true;
                                    ___style.___BorderBottomColorComputedValueSpecified = true;
                                    break;
                                case 1:
                                    ___style.___BorderLeftColorComputedValue = ___colorValue;
                                    ___style.___BorderLeftColorComputedValueSpecified = true;
                                    break;
                                case 2:
                                    ___style.___BorderTopColorComputedValue = ___colorValue;
                                    ___style.___BorderTopColorComputedValueSpecified = true;
                                    break;
                                case 3:
                                    ___style.___BorderRightColorComputedValue = ___colorValue;
                                    ___style.___BorderRightColorComputedValueSpecified = true;
                                    break;
                                case 4:
                                    ___style.___BorderBottomColorComputedValue = ___colorValue;
                                    ___style.___BorderBottomColorComputedValueSpecified = true;
                                    break;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("parseCSSBorderStyle Error ", ex);
                }
            }
        }


        #endregion
        #region SetCHTMLElementStyleSheet4NameAnd4Value
        public static void SetCHTMLElementStyleSheet4NameAnd4Value(CHtmlElement htmlControl, string __name, string __value)
        {
            if (htmlControl == null || htmlControl.___style == null)
                return;
            try
            {
                string[] __valueSp = new string[1];
                int ElementCount = 0;
                switch (__value)
                {
                    case null:
                    case "":
                    case " ":
                    case "none":
                    case "auto":
                    case "0":
                    case "0px":
                    case "0pt":
                    case "0mm":
                    case "0cm":
                    case "0in":
                    case "0pc":
                    case "0ex":
                    case "0em":
                    case "#initial":
                    case "initial":
                        switch (__name)
                        {
                            case "margin":
                                return;
                            case "padding":
                                return;
                        }
                        __valueSp = new string[] { __value };
                        ElementCount = 0;
                        goto SetStage;
                    default:
                        break;
                }
                if (string.IsNullOrEmpty(__value) == false && (IsCharWhiteSpaceLimited(__value[0]) == true || IsCharWhiteSpaceLimited(__value[__value.Length - 1]) == true))
                {
                    __value = __value.Trim();
                }
                __valueSp = __value.Split(CharSpaceCrLfTab);
                ElementCount = __valueSp.Length;
            SetStage:
                switch (__name)
                {
                    case "margin":
                        switch (ElementCount)
                        {
                            case 0:
                            case 1:
                                htmlControl.___style.Margin = __valueSp[0];
                                break;
                            case 2:
                                htmlControl.___style.MarginTop = __valueSp[0];
                                htmlControl.___style.MarginBottom = __valueSp[0];
                                htmlControl.___style.MarginLeft = __valueSp[1];
                                htmlControl.___style.MarginRight = __valueSp[1];
                                break;
                            case 3:
                                htmlControl.___style.MarginTop = __valueSp[0];
                                htmlControl.___style.MarginRight = __valueSp[1];
                                htmlControl.___style.MarginLeft = __valueSp[1];
                                htmlControl.___style.MarginBottom = __valueSp[2];
                                break;
                            case 4:
                                htmlControl.___style.MarginTop = __valueSp[0];
                                htmlControl.___style.MarginRight = __valueSp[1];
                                htmlControl.___style.MarginBottom = __valueSp[2];
                                htmlControl.___style.MarginLeft = __valueSp[3];
                                break;
                        }
                        break;
                    case "padding":
                        switch (ElementCount)
                        {
                            case 0:
                            case 1:
                                htmlControl.___style.PaddingTop = __valueSp[0];
                                htmlControl.___style.PaddingRight = __valueSp[0];
                                htmlControl.___style.PaddingLeft = __valueSp[0];
                                htmlControl.___style.PaddingBottom = __valueSp[0];
                                break;
                            case 2:
                                htmlControl.___style.PaddingTop = __valueSp[0];
                                htmlControl.___style.PaddingBottom = __valueSp[0];
                                htmlControl.___style.PaddingLeft = __valueSp[1];
                                htmlControl.___style.PaddingRight = __valueSp[1];
                                break;
                            case 3:
                                htmlControl.___style.PaddingTop = __valueSp[0];
                                htmlControl.___style.PaddingRight = __valueSp[1];
                                htmlControl.___style.PaddingLeft = __valueSp[1];
                                htmlControl.___style.PaddingBottom = __valueSp[2];
                                break;
                            case 4:
                                htmlControl.___style.PaddingTop = __valueSp[0];
                                htmlControl.___style.PaddingRight = __valueSp[1];
                                htmlControl.___style.PaddingBottom = __valueSp[2];
                                htmlControl.___style.PaddingLeft = __valueSp[3];
                                break;
                        }
                        break;
                    case "border-width":
                        switch (ElementCount)
                        {
                            case 0:
                            case 1:
                                htmlControl.___style.BorderTopWidth = __valueSp[0];
                                htmlControl.___style.BorderBottomWidth = __valueSp[0];
                                htmlControl.___style.BorderLeftWidth = __valueSp[0];
                                htmlControl.___style.BorderRightWidth = __valueSp[0];
                                break;
                            case 2:
                                htmlControl.___style.BorderTopWidth = __valueSp[0];
                                htmlControl.___style.BorderBottomWidth = __valueSp[0];
                                htmlControl.___style.BorderLeftWidth = __valueSp[1];
                                htmlControl.___style.BorderRightWidth = __valueSp[1];
                                break;
                            case 3:
                                htmlControl.___style.BorderTopWidth = __valueSp[0];
                                htmlControl.___style.BorderRightWidth = __valueSp[1];
                                htmlControl.___style.BorderLeftWidth = __valueSp[1];
                                htmlControl.___style.BorderBottomWidth = __valueSp[2];
                                break;
                            case 4:
                                htmlControl.___style.BorderTopWidth = __valueSp[0];
                                htmlControl.___style.BorderRightWidth = __valueSp[1];
                                htmlControl.___style.BorderBottomWidth = __valueSp[2];
                                htmlControl.___style.BorderLeftWidth = __valueSp[3];
                                break;
                        }
                        break;
                    case "border-color":
                        switch (ElementCount)
                        {
                            case 0:
                            case 1:
                                htmlControl.___style.BorderTopColor = __valueSp[0];
                                htmlControl.___style.BorderBottomColor = __valueSp[0];
                                htmlControl.___style.BorderLeftColor = __valueSp[0];
                                htmlControl.___style.BorderRightColor = __valueSp[0];
                                break;
                            case 2:

                                htmlControl.___style.BorderTopColor = __valueSp[0];
                                htmlControl.___style.BorderBottomColor = __valueSp[0];
                                htmlControl.___style.BorderLeftColor = __valueSp[1];
                                htmlControl.___style.BorderRightColor = __valueSp[1];
                                break;
                            case 3:

                                htmlControl.___style.BorderTopColor = __valueSp[0];
                                htmlControl.___style.BorderRightColor = __valueSp[1];
                                htmlControl.___style.BorderLeftColor = __valueSp[1];
                                htmlControl.___style.BorderBottomColor = __valueSp[2];
                                break;
                            case 4:

                                htmlControl.___style.BorderTopColor = __valueSp[0];
                                htmlControl.___style.BorderRightColor = __valueSp[1];
                                htmlControl.___style.BorderBottomColor = __valueSp[2];
                                htmlControl.___style.BorderLeftColor = __valueSp[3];
                                break;
                        }
                        break;
                    case "border-style":
                        switch (ElementCount)
                        {
                            case 0:
                            case 1:
                                htmlControl.___style.BorderTopStyle = __valueSp[0];
                                htmlControl.___style.BorderBottomStyle = __valueSp[0];
                                htmlControl.___style.BorderLeftStyle = __valueSp[0];
                                htmlControl.___style.BorderRightStyle = __valueSp[0];
                                break;
                            case 2:

                                htmlControl.___style.BorderTopStyle = __valueSp[0];
                                htmlControl.___style.BorderBottomStyle = __valueSp[0];
                                htmlControl.___style.BorderLeftStyle = __valueSp[1];
                                htmlControl.___style.BorderRightStyle = __valueSp[1];
                                break;
                            case 3:

                                htmlControl.___style.BorderTopStyle = __valueSp[0];
                                htmlControl.___style.BorderRightStyle = __valueSp[1];
                                htmlControl.___style.BorderLeftStyle = __valueSp[1];
                                htmlControl.___style.BorderBottomStyle = __valueSp[2];
                                break;
                            case 4:

                                htmlControl.___style.BorderTopStyle = __valueSp[0];
                                htmlControl.___style.BorderRightStyle = __valueSp[1];
                                htmlControl.___style.BorderBottomStyle = __valueSp[2];
                                htmlControl.___style.BorderLeftStyle = __valueSp[3];
                                break;
                        }
                        break;
                    case "background-position":
                        switch (ElementCount)
                        {
                            case 0:
                            case 1:
                                if (string.Equals(__valueSp[0], "top", StringComparison.OrdinalIgnoreCase) == true || string.Equals(__valueSp[0], "bottom", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    htmlControl.___style.BackgroundPositionY = __valueSp[0];
                                }
                                else if (string.Equals(__valueSp[0], "left", StringComparison.OrdinalIgnoreCase) == true || string.Equals(__valueSp[0], "right", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    htmlControl.___style.BackgroundPositionX = __valueSp[0];
                                }
                                else
                                {
                                    htmlControl.___style.BackgroundPositionX = __valueSp[0];
                                }
                                break;
                            case 2:
                                htmlControl.___style.BackgroundPositionX = __valueSp[0];
                                htmlControl.___style.BackgroundPositionY = __valueSp[1];
                                bool ___IsBackgroundPositionSwapNeed = false;
                                if (string.Equals(htmlControl.___style.BackgroundPositionX, "top", StringComparison.OrdinalIgnoreCase) == true || string.Equals(htmlControl.___style.BackgroundPositionX, "bottom", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    ___IsBackgroundPositionSwapNeed = true;

                                }
                                else if (string.Equals(htmlControl.___style.BackgroundPositionY, "left", StringComparison.OrdinalIgnoreCase) == true || string.Equals(htmlControl.___style.BackgroundPositionY, "right", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    ___IsBackgroundPositionSwapNeed = true;
                                }
                                if (___IsBackgroundPositionSwapNeed == true)
                                {
                                    string ___curX = htmlControl.___style.BackgroundPositionX;
                                    string ___curY = htmlControl.___style.BackgroundPositionY;
                                    htmlControl.___style.BackgroundPositionY = ___curX;
                                    htmlControl.___style.BackgroundPositionX = ___curY;
                                }

                                break;
                        }
                        break;
                    case "margin-left":
                    case "marginleft":
                    case "-margin-left":
                        htmlControl.___style.MarginLeft = __valueSp[0];
                        break;
                    case "margin-right":
                    case "marginright":
                    case "-margin-right":
                        htmlControl.___style.MarginRight = __valueSp[0];
                        break;
                    case "margin-top":
                    case "margintop":
                    case "-margin-top":
                        htmlControl.___style.MarginTop = __valueSp[0];
                        break;
                    case "margin-bottom":
                    case "marginbottom":
                    case "-margin-bottom":
                        htmlControl.___style.MarginBottom = __valueSp[0];
                        break;
                    case "padding-left":
                    case "paddingleft":
                        htmlControl.___style.PaddingLeft = __valueSp[0];
                        break;
                    case "padding-right":
                    case "paddingright":
                        htmlControl.___style.PaddingRight = __valueSp[0];
                        break;
                    case "padding-top":
                    case "paddingtop":
                        htmlControl.___style.PaddingTop = __valueSp[0];
                        break;
                    case "padding-bottom":
                    case "paddingbottom":
                        htmlControl.___style.PaddingBottom = __valueSp[0];
                        break;
                    case "border-top-width":
                    case "bordertopwidth":
                        htmlControl.___style.BorderTop = __valueSp[0];
                        break;
                    case "border-left-width":
                    case "borderleftwidth":
                        htmlControl.___style.BorderLeft = __valueSp[0];
                        break;
                    case "border-right-width":
                    case "borderrightwidth":
                        htmlControl.___style.BorderRight = __valueSp[0];
                        break;
                    case "border-bottom-width":
                    case "borderbottomwidth":
                        htmlControl.___style.BorderBottom = __valueSp[0];
                        break;
                    case "border-top-color":
                    case "bordertopcolor":
                        htmlControl.___style.BorderTopColor = __valueSp[0];
                        break;
                    case "border-left-color":
                    case "borderleftcolor":
                        htmlControl.___style.BorderLeftColor = __valueSp[0];
                        break;
                    case "border-right-color":
                    case "borderrightcolor":
                        htmlControl.___style.BorderRightColor = __valueSp[0];
                        break;
                    case "border-bottom-color":
                    case "borderbottomcolor":
                        htmlControl.___style.BorderBottomColor = __valueSp[0];
                        break;
                }
            }
            catch
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("SetCHTMLElementStyleSheet4NameAnd4Value Parse {0} \"{1}\"", __name, __value);
                }
            }
        }

        #endregion








        public static bool ___IsCurrentScriptEndBlockValid(int _test, int StaringPoint, System.Text.StringBuilder __sbText)
        {
            int __sbTextLen = __sbText.Length;
            try
            {

                if (_test < __sbText.Length)
                {
                    int ___CheckCount = 0;

                    // Look Back First
                    for (int i = _test + 9; i < __sbTextLen; i++)
                    {
                        char c = __sbText[i];
                        if (c == '<')
                            return true;
                        if (c == '\'' || c == '\"' || c == '\\')
                        {
                            return false;
                        }

                        ___CheckCount++;
                        if (___CheckCount > 7)
                        {
                            break;
                        }
                    }
                    // If Ok look forwad
                    for (int i = _test; i > _test - 1; i--)
                    {
                        if (i <= 0)
                            break;
                        char c = __sbText[i];
                        if (c == '\'' || c == '\"' || c == '\\')
                        {
                            return false;
                        }
                        if (c == ';' || c == ')' || c == '}') // Possible Script End Char
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("___IsCurrentScriptEndBlockValid", ex);
                }
            }
            return true;
        }

        internal static System.Collections.Generic.List<CHtmlStyleAttribute?> GetProcessStyleSheetStringIntoCHtmlCollection(string s)
        {
            System.Collections.Generic.List<CHtmlStyleAttribute?> arResult = new System.Collections.Generic.List<CHtmlStyleAttribute?>();
            try
            {
                if (s == null || s.Length == 0)
                    return arResult;
                char[] sc = s.ToCharArray();

                bool NameMode = true;
                bool ValueMode = false;
                System.Text.StringBuilder sbName = new System.Text.StringBuilder();
                System.Text.StringBuilder sbValue = new System.Text.StringBuilder();
                char c = '\0';
                bool IsQuoteMode = false;
                char QuoteStartChar = '\0';
                int csLen = sc.Length;
                for (int i = 0; i < csLen; i++)
                {
                    c = sc[i];
                    switch (c)
                    {
                        case '\'':
                            if (IsQuoteMode == false)
                            {
                                QuoteStartChar = '\'';
                                IsQuoteMode = true;
                            }
                            else
                            {
                                if (i < sc.Length && sc[i - 1] != '\\' && c == QuoteStartChar)
                                {
                                    QuoteStartChar = '\0';
                                    IsQuoteMode = false;
                                }
                            }
                            break;
                        case '\"':
                            if (IsQuoteMode == false)
                            {
                                QuoteStartChar = '\"';
                                IsQuoteMode = true;
                            }
                            else
                            {
                                if (i < sc.Length && sc[i - 1] != '\\' && c == QuoteStartChar)
                                {
                                    QuoteStartChar = '\0';
                                    IsQuoteMode = false;
                                }
                            }
                            break;
                        case ':':
                            if (IsQuoteMode == true)
                            {
                                goto SetValueByMode;
                            }
                            if (ValueMode == true)
                            {
                                if (sbValue.Length != 0 && sbValue.ToString().StartsWith("url(", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    int scLen = sc.Length;
                                    for (int nc = i; nc < scLen; nc++)
                                    {
                                        if (sc[nc] == ';')
                                        {
                                            i = nc - 1;
                                            goto NextCharacter;
                                        }
                                        else
                                        {
                                            sbValue.Append(sc[nc]);
                                        }
                                    }
                                }
                            }
                            ValueMode = true;
                            NameMode = false;
                            continue;
                        case ';':
                            if (IsQuoteMode == true)
                            {
                                goto SetValueByMode;
                            }
                            bool ___isImportant = false;
                            VerifyStyleNameAndValue(ref sbName, ref sbValue, ref ___isImportant);
                            ValueMode = false;
                            NameMode = true;
                            try
                            {
                                CreateStyleValueEntry(sbName.ToString(), sbValue.ToString(), arResult, ___isImportant);
                            }
                            catch (Exception ex1)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                {
                                    commonLog.LogEntry("GetProcessStyleSheetStringIntoCHtmlCollection ___hasInner error {0}", commonData.GetExceptionAsString(ex1));
                                }
                            }
                            sbName = new System.Text.StringBuilder();
                            sbValue = new System.Text.StringBuilder();
                            continue;

                    }
                SetValueByMode:
                    if (NameMode)
                    {
                        if (IsCharWhiteSpaceLimited(c) == false)
                        {
                            if (c >= 'A' && c <= 'Z')
                            {
                                sbName.Append(FasterToLower(c));
                            }
                            else
                            {
                                sbName.Append(c);
                            }
                        }
                    }
                    else if (ValueMode)
                    {
                        if (IsCharWhiteSpaceLimited(c))
                        {
                            sbValue.Append(' ');
                        }
                        else
                        {
                            sbValue.Append(c);
                        }
                    }
                    if (i == csLen - 1)
                    {
                        if (sbName.Length > 0 && sbName[0] != '}' && sbValue.Length > 0)
                        {
                            bool ___isImportant = false;
                            VerifyStyleNameAndValue(ref sbName, ref sbValue, ref ___isImportant);
                            string sbNameString = sbName.ToString();
                            if (sbNameString.Length > 0)
                            {
                                try
                                {

                                    CreateStyleValueEntry(sbName.ToString(), sbValue.ToString(), arResult, ___isImportant);
                                }
                                catch (Exception ex1)
                                {
                                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                    {
                                        commonLog.LogEntry("GetProcessStyleSheetStringIntoCHtmlCollection ___hasInner error {0}", commonData.GetExceptionAsString(ex1));
                                    }
                                }
                                break;
                            }
                        }
                    }
                NextCharacter:
                    if (false) {; }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("GetProcessStyleSheetStringIntoSortedList", ex);
                }
            }
            return arResult;
        }



        public static void GetMaxBounds(Rectangle _childBounds, ref Rectangle _OwerRectangle)
        {
            if (_childBounds.Width > _OwerRectangle.Width)
            {
                _OwerRectangle.Width = _childBounds.Width;
            }

        }
        public static string ReplaceAsmpdandString(string _str)
        {
            return ReplaceAsmpdandString(new System.Text.StringBuilder(_str));
        }
        public static string ReplaceAsmpdandString(System.Text.StringBuilder _strBuilder)
        {
            System.Text.StringBuilder sb = _strBuilder;
            int sbLen = sb.Length;
            try
            {
                for (int i = 0; i < sbLen; i++)
                {
                    if (sb[i] == '&')
                    {
                        System.Text.StringBuilder sbSymbol = new StringBuilder();
                        sbSymbol.Append('&');
                        for (int semipos = i + 1; semipos < i + 16; semipos++)
                        {
                            if (semipos >= sb.Length)
                                break;
                            char sc = sb[semipos];
                            if (sc == '=' || sc == '.' || sc == '-' || sc == '&')
                            {
                                goto NextChar;
                            }

                            sbSymbol.Append(sc);
                            if (sb[semipos] == ';')
                            {
                                char c = GetHTMLCharStringHTMLString(sbSymbol.ToString(), '\0');
                                if (c != '\0')
                                {
                                    sb[i] = c;
                                    int _Deff = semipos - i;
                                    for (int rev = i + 1; rev <= i + _Deff; rev++)
                                    {
                                        sb.Remove(i + 1, 1);
                                        sbLen = sb.Length;
                                    }
                                    goto NextChar;
                                }
                                else
                                {
                                    goto NextChar;
                                }
                            }

                        }
                    }
                NextChar:
                    if (false) {; }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("ReplaceAsmpdandString", ex);
                }
            }
            return sb.ToString();
        }

        public static GraphicAPIType GraphicApiType = detectGraphicAPIType();
        private static GraphicAPIType detectGraphicAPIType()
        {
            GraphicAPIType guiGrapicApiType = GraphicAPIType.Unknown;
            if (GraphicApiType != GraphicAPIType.Unknown)
            {
                guiGrapicApiType = GraphicApiType;
                goto GuiAPIDetected;
            }
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // Avalonia
            if (assemblies.Any(a => a.GetName().Name?.StartsWith("Avalonia", StringComparison.OrdinalIgnoreCase) == true))
            {
                guiGrapicApiType = GraphicAPIType.Avalonia;
                goto GuiAPIDetected;
            }

            // UnoPlatform
            if (assemblies.Any(a => a.GetName().Name?.StartsWith("Uno.", StringComparison.OrdinalIgnoreCase) == true))
            {
                guiGrapicApiType = GraphicAPIType.UnoPlatform;
                goto GuiAPIDetected;
            }

            // MAUI
            if (assemblies.Any(a => a.GetName().Name?.StartsWith("Microsoft.Maui", StringComparison.OrdinalIgnoreCase) == true))
            {
                guiGrapicApiType = GraphicAPIType.Maui;
                goto GuiAPIDetected;
            }
            // WinForms GDI
            if (assemblies.Any(a => a.GetName().Name?.StartsWith("System.Windows.Forms") == true))
            {
                guiGrapicApiType = GraphicAPIType.WinformsGDI;
                goto GuiAPIDetected;
            }

            // SkiaSharp
            if (assemblies.Any(a => a.GetName().Name?.StartsWith("SkiaSharp", StringComparison.OrdinalIgnoreCase) == true))
            {
                guiGrapicApiType = GraphicAPIType.SkiaSharp;
                goto GuiAPIDetected;
            }

            // Windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {

                guiGrapicApiType = GraphicAPIType.WinformsGDI;
                goto GuiAPIDetected;
            }

            // Linux, Mac
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                guiGrapicApiType = GraphicAPIType.SkiaSharp;
                goto GuiAPIDetected;
            }
        GuiAPIDetected:
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("Platform Graphic API is set : \"{0}\"", guiGrapicApiType);
            }
            return guiGrapicApiType;
        }



        public static string GetAbsoluteUri(Uri BaseUri, string PartUri)
        {
            return GetAbsoluteUri(BaseUri.AbsoluteUri.ToString(), "", PartUri);

        }

        public static string GetAbsoluteUri(string DocUrl, string BaseUrl, string PartUri)
        {
            try
            {
                if (string.IsNullOrEmpty(DocUrl) == true)
                {
                    if (BaseUrl == null || BaseUrl.Length == 0)
                    {
                        return "";
                    }
                }
                if (PartUri == null || PartUri.Length == 0)
                {
                    return "";
                }
                if (PartUri.Length > 0)
                {
                    if (PartUri[0] == '\'' || PartUri[0] == '\"')
                    {
                        PartUri = PartUri.Remove(0, 1);
                    }
                    if (PartUri.Length > 0)
                    {
                        if (PartUri[PartUri.Length - 1] == '\"' || PartUri[PartUri.Length - 1] == '\'')
                        {
                            PartUri = PartUri.Remove(PartUri.Length - 1, 1);
                        }
                    }
                }

                // Check White Space From Head
                if (PartUri.Length > 0 && IsCharWhiteSpaceLimited(PartUri[0]))
                {
                    PartUri = PartUri.TrimStart(CharSpaceCrLfTabZentakuSpace);
                }
                // Check White Space From Head
                if (PartUri.Length > 1 && IsCharWhiteSpaceLimited(PartUri[PartUri.Length - 1]))
                {
                    PartUri = PartUri.TrimEnd(CharSpaceCrLfTabZentakuSpace);
                }

                if (PartUri.IndexOf('&') > -1 && PartUri.IndexOf(';') > -1)
                {
                    PartUri = ReplaceAsmpdandString(PartUri);
                }
                // =================================================================================
                // Note) Following code will replace '+' to ' ' which result in HTTP 400
                //       Removed 2013/08/14
                // ------------------------------------------------------------------
                //PartUri = commonUrlDecode(PartUri);
                // ------------------------------------------------------------------
                // =================================================================================

                if (PartUri.Length > 0)
                {
                    char cFirst = PartUri[0];
                    if (char.IsLetter(cFirst) == false)
                    {
                        goto JumpForAbsolutePath;
                    }
                }
                string __PartScheme = "";
                int posScheme = PartUri.IndexOf(':');
                if (posScheme > 1 && posScheme < 14)
                {
                    __PartScheme = PartUri.Substring(0, posScheme + 1);

                }
                if (__PartScheme.Length != 0)
                {
                    switch (__PartScheme)
                    {
                        case "https:":
                        case "http:":
                        case "ftp:":
                        case "file:":
                        case "about:":
                        case "mailto:":
                        case "javascript:":
                        case "data:":
                            return PartUri;
                        default:
                            break;
                    }
                }




            JumpForAbsolutePath:
                System.Uri ____uriLeftPart;
                if (BaseUrl != null && BaseUrl.Length > 6)
                {
                    ____uriLeftPart = new Uri(BaseUrl);
                }
                else
                {
                    ____uriLeftPart = new Uri(DocUrl);
                }

                if (PartUri[0] == '/' && PartUri.StartsWith("//", StringComparison.Ordinal))
                {
                    // ========================================================================================
                    // [PartUri] 	"//images/stories/News/2013/Nov/A/Resized/Windows31_220x178.jpg"	
                    // [BaseUri]    "http://www.i-programmer.info/news/82-heritage/6555-windows-101-30-and-mac-7-in-a-browser.html"	
                    // [TargetUri]  "http://www.i-programmer.info/images/stories/News/2013/Nov/A/Resized/Windows31_220x178.jpg"	
                    // ========================================================================================
                    string PartUriSegment = PartUri.Remove(0, 1);
                    bool IsFirstSegmentContainsDot = false;
                    int posSlash = PartUriSegment.IndexOf('/', 1);
                    if (posSlash > -1)
                    {
                        string __FirstSegment = PartUriSegment.Substring(1, posSlash - 1);
                        if (__FirstSegment.IndexOf('.') > -1)
                        {
                            IsFirstSegmentContainsDot = true;
                        }

                    }
                    if (IsFirstSegmentContainsDot == false)
                    {
                        //return string.Concat(____uriLeftPart.Scheme , "://",____uriLeftPart.Host, PartUriSegment);
                        System.Text.StringBuilder sb = new StringBuilder(1000);
                        sb.Append(____uriLeftPart.Scheme);
                        sb.Append("://");
                        sb.Append(____uriLeftPart.Host);
                        sb.Append(PartUriSegment);
                        return sb.ToString();
                    }
                    else
                    {
                        //return string.Concat(____uriLeftPart.Scheme , ":", PartUri);
                        System.Text.StringBuilder sb = new StringBuilder(100);
                        sb.Append(____uriLeftPart.Scheme);
                        sb.Append(':');
                        sb.Append(PartUri);
                        return sb.ToString();
                    }
                }


                System.Uri uriRelative = new Uri(____uriLeftPart, PartUri, false);
                return uriRelative.AbsoluteUri.ToString();
            }
            catch
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 1)
                {
                    commonLog.LogEntry("Absolute URl2 faied \"{0}\"  \"{1}\"  : \"{2}\"", DocUrl, BaseUrl, PartUri);
                }
                return "";
            }
        }
        public static bool IsContentTypeProcessedAsNormalDocument(string ___contentType)
        {
            switch (___contentType)
            {
                case "text/html":
                case "image/gif":
                case "image/png":
                case "image/svg":
                case "image/bmp":
                case "image/webp":
                case "image/svg+xml":
                case "text/xml":
                case "text/plain":
                case "application/xhtml+xml":
                case "application/xhtml":
                case "application/xml":
                case "application/svg":
                case "application/svg+xml":
                    return true;
            }
            return false;
        }
        public static bool IsContentTypeRequriesAutomatcHTMLDocument(string ___contentType, out string mimeHead, out string mimeTail)
        {
            int posShash = ___contentType.IndexOf('/');
            if (posShash > -1)
            {
                mimeHead = ___contentType.Substring(0, posShash);
                mimeTail = ___contentType.Substring(posShash + 1);
                switch (mimeHead)
                {
                    case "image":
                    case "audo":
                    case "video":
                        if (mimeTail == "svg" || mimeTail == "svg+xml")
                        {
                            return false;
                        }
                        return true;
                    case "text":
                        if (mimeTail == "plain")
                        {
                            return true;
                        }
                        break;
                }
            }
            mimeHead = "";
            mimeTail = "";
            return false;
        }
        /// <summary>
        /// General Purpose To Specified Method Counter
        /// Default is zero, it should increment to int.Max
        /// if it reached it is decreased to half of int.Max
        /// </summary>
        /// <param name="counter"></param>
        public static void incrementMethodEnteredCounter(ref int counter)
        {
            if (counter >= int.MaxValue)
            {
                counter = int.MaxValue / 2;
            }
            counter++;
        }


        public static byte[] convertBase64IntoBytesArray(string strBinary64, ref string formatinfo)
        {
            try
            {
                if (string.IsNullOrEmpty(strBinary64) == true)
                {
                    return null;
                }
                if (strBinary64.StartsWith("data:", StringComparison.OrdinalIgnoreCase) == true)
                {
                    int posConma = strBinary64.IndexOf(',');
                    if (posConma > -1 && posConma < strBinary64.Length - 1)
                    {
                        int posSemi = strBinary64.IndexOf(';');
                        //data:audio/wav;base64,
                        formatinfo = strBinary64.Substring(5, posSemi - 5);
                        string strNew = strBinary64.Substring(posConma + 1);
                        byte[] bts = Convert.FromBase64String(strNew);
                        return bts;
                    }
                }

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 1)
                {
                    commonLog.LogEntry("convertBase64IntoBytesArray Error : ", ex);
                }
                formatinfo = "";
            }
            return null;
        }
        public static double GetCompressionRatio(long _ActualLength, long HeaderLength, string _Url, string __ContentEncoding)
        {
            double d = HeaderLength / _ActualLength;
            //if(d > 0 && d < 1.0)
            //{
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("'{0}' is compressed with {1} at {2}", _Url, __ContentEncoding, d.ToString("P"));
            }
            //}
            return d;
        }
        public static CHtmlElementType[] GetPossibleClosingChildTagName(CHtmlElementType _tagType)
        {
            CHtmlElementType[] __possibleParent = null;
            switch (_tagType)
            {
                case CHtmlElementType.P:
                    __possibleParent = new CHtmlElementType[] { CHtmlElementType.P };
                    break;
                default:
                    break;

            }
            return __possibleParent;
        }
        public static CHtmlElementType[] GetPossibleParentTagName(CHtmlElementType _tagType)
        {
            CHtmlElementType[] _parents = null;
            switch (_tagType)
            {
                case CHtmlElementType.OPTION:
                    _parents = new CHtmlElementType[] { CHtmlElementType.SELECT, CHtmlElementType.DATALIST, CHtmlElementType.OPTGROUP };
                    break;
                case CHtmlElementType.LI:
                    _parents = new CHtmlElementType[] { CHtmlElementType.UL, CHtmlElementType.OL, CHtmlElementType.DIR, CHtmlElementType.MENU, CHtmlElementType.DIV };
                    break;
                case CHtmlElementType.INPUT:
                    // input may not have form always
                    _parents = null;
                    break;
                /*
                case "dd":
                    _parents = new string[]{"dt"};
                    break;
                case "dt":
                    _parents = new string[]{"dl"};
                    break;
                */
                case CHtmlElementType.TH:
                case CHtmlElementType.TD:
                    _parents = new CHtmlElementType[] { CHtmlElementType.TR };
                    break;

                case CHtmlElementType.DT:
                    _parents = new CHtmlElementType[] { CHtmlElementType.DL };
                    break;
                case CHtmlElementType.PARAM:
                    _parents = new CHtmlElementType[] { CHtmlElementType.APPLET, CHtmlElementType.EMBED, CHtmlElementType.OBJECT };
                    break;
                case CHtmlElementType.AREA:
                    _parents = new CHtmlElementType[] { CHtmlElementType.MAP };
                    break;
                case CHtmlElementType.NOFRAMES:
                case CHtmlElementType.FRAME:
                    _parents = new CHtmlElementType[] { CHtmlElementType.FRAMESET, CHtmlElementType.BODY };
                    break;
                default:
                    _parents = null;
                    break;
            }
            return _parents;
        }
        #region getStandardObjectFromWeakReferene
        public static CHtmlCSSStyleSheet getStyleElementFromWeakReference(System.WeakReference weakref)
        {
            if (weakref != null)
            {
                return weakref.Target as CHtmlCSSStyleSheet;
            }
            return null;
        }
        public static CHtmlElement getElementFromWeakReference(System.WeakReference weakref)
        {
            if (weakref != null)
            {
                return weakref.Target as CHtmlElement;
            }
            return null;
        }

        public static CHtmlTextElement getTextElementFromWeakReference(System.WeakReference weakref)
        {
            if (weakref != null)
            {
                return weakref.Target as CHtmlTextElement;
            }
            return null;
        }
        public static CHtmlDocument getDocumentFromWeakReference(System.WeakReference weakref)
        {
            if (weakref != null)
            {
                return weakref.Target as CHtmlDocument;
            }
            return null;
        }
        public static CHtmlMultiversalWindow getMultiversalWindowObjectFromWeakReference(System.WeakReference weakref)
        {
            if (weakref != null)
            {
                return weakref.Target as CHtmlMultiversalWindow;
            }
            return null;
        }
        #endregion
        /// <summary>
        /// Spilit General Style Multile Values appropriately
        /// specially for style.background values
        /// Rule 1) QuotedInnterValue honored properly '('
        /// Rule 2) Space is value separator except for quoted or "()"
        /// Rule 3) ' or " is honored.
        /// </summary>
        /// <param name="___text"></param>
        /// <returns></returns>

        internal static string[] SplitMultipleValuesToArray(string ___text, ref int ___properConmaCount, bool notSplitIfConmaExists)
        {
            if (___text.Length == 0)
            {
                return new string[] { };
            }
            int ___lastKonmaItemsCount = -1;
            System.Collections.Generic.List<string> listText = new System.Collections.Generic.List<string>();
            char[] cs = ___text.ToCharArray();
            char c0 = '\0';
            char c_b1 = '\0';
            System.Text.StringBuilder sbValue = new StringBuilder();
            int QuoteBeginCount = 0;
            char ___StringQuoteStartChar = '0';
            bool ___IsStringQuoteBegin = false;
            bool ___ValueContainsValidValue = false;
            int csLen = cs.Length;

            try
            {
                for (int i = 0; i < csLen; i++)
                {
                    c0 = cs[i];
                    if (i > 0)
                    {
                        c_b1 = cs[i - 1];
                    }
                    switch (c0)
                    {
                        case '\r':
                        case '\n':
                        case ' ':
                        case '\t':
                        case '\v':
                        case '\b':
                        case (char)8192:
                        case (char)8193:
                        case (char)8194:
                        case (char)8195:
                        case (char)8196:
                        case (char)8197:
                        case (char)8198:
                        case (char)8199:
                        case (char)8200:
                        case (char)8201:
                        case (char)8202:
                        case (char)8203:
                        case (char)8232: // line separator
                        case (char)8233: // paragraph separator
                        case (char)8239: // narrow no-break space
                        case (char)8287: // Separator, space
                        case (char)12288: // Separator, space (Zenkaku Space)
                            if (___IsStringQuoteBegin == false && QuoteBeginCount == 0)
                            {
                                if (___ValueContainsValidValue == true)
                                {
                                    if (sbValue.Length > 0)
                                    {
                                        if (IsCharWhiteSpaceLimited(sbValue[sbValue.Length - 1]) == true)
                                        {
                                            listText.Add(sbValue.ToString().Trim());
                                        }
                                        else
                                        {
                                            listText.Add(sbValue.ToString());

                                        }
                                    }
                                    sbValue = new System.Text.StringBuilder();
                                    ___ValueContainsValidValue = false;
                                    continue;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                c0 = ' ';
                            }
                            break;
                        case '\'':
                            if (___IsStringQuoteBegin == false)
                            {
                                ___StringQuoteStartChar = '\'';
                                ___IsStringQuoteBegin = true;
                                break;
                            }
                            else
                            {
                                if (c0 == ___StringQuoteStartChar)
                                {
                                    if (c_b1 != '\\')
                                    {
                                        ___IsStringQuoteBegin = false;
                                    }

                                }
                                break;
                            }

                        case '\"':
                            if (___IsStringQuoteBegin == false)
                            {
                                ___StringQuoteStartChar = '\"';
                                ___IsStringQuoteBegin = true;
                                break;
                            }
                            else
                            {
                                if (c0 == ___StringQuoteStartChar)
                                {
                                    if (c_b1 != '\\')
                                    {
                                        ___IsStringQuoteBegin = false;
                                    }
                                }
                                break;
                            }

                        case '(':
                            if (___IsStringQuoteBegin == false)
                            {
                                QuoteBeginCount++;
                            }
                            break;
                        case ')':
                            if (___IsStringQuoteBegin == false)
                            {
                                QuoteBeginCount--;
                            }
                            break;
                        default:
                            break;
                    }
                    if (___ValueContainsValidValue == false)
                    {
                        if (char.IsLetterOrDigit(c0) || char.IsSymbol(c0))
                        {
                            ___ValueContainsValidValue = true;
                        }
                    }
                    if (sbValue != null)
                    {
                        if (___ValueContainsValidValue == false && IsCharWhiteSpaceLimited(c0))
                        {
                            continue;
                        }
                        if (c0 == ',')
                        {
                            if (___IsStringQuoteBegin == false)
                            {
                                if (QuoteBeginCount == 0)
                                {
                                    if (notSplitIfConmaExists == true)
                                    {
                                        System.Text.StringBuilder sbConcat = new StringBuilder();
                                        if (___lastKonmaItemsCount <= 0)
                                        {
                                            int listTextCount = listText.Count;
                                            for (int z = 0; z < listTextCount; z++)
                                            {
                                                sbConcat.Append(listText[z]);
                                                sbConcat.Append(' ');
                                                if (sbValue != null)
                                                {
                                                    sbConcat.Append(sbValue.ToString());
                                                    sbValue = new StringBuilder();
                                                }
                                            }
                                            listText = new System.Collections.Generic.List<string>();
                                            if (sbConcat.Length > 0)
                                            {
                                                listText.Add(sbConcat.ToString());
                                            }
                                            ___lastKonmaItemsCount = listText.Count;
                                        }
                                        else
                                        {
                                            int listTextCount = listText.Count;
                                            for (int z = ___lastKonmaItemsCount; z < listTextCount; z++)
                                            {
                                                if (z >= listText.Count)
                                                    break;

                                                sbConcat.Append(listText[z]);
                                                sbConcat.Append(' ');
                                                listText.RemoveAt(z);
                                                z--;
                                            }
                                            if (sbValue != null)
                                            {
                                                sbConcat.Append(sbValue.ToString());
                                                sbValue = new StringBuilder();
                                            }
                                            if (sbConcat.Length > 0)
                                            {
                                                listText.Add(sbConcat.ToString());
                                            }
                                            ___lastKonmaItemsCount = listText.Count;
                                        }
                                    }
                                    ___properConmaCount++;
                                    continue;

                                }
                            }
                        }
                        sbValue.Append(c0);
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("SplitMultipleValuesToArray Failed", ex);
                }
            }
            if (sbValue != null && sbValue.Length > 0)
            {
                if (IsCharWhiteSpaceLimited(sbValue[sbValue.Length - 1]) == true)
                {
                    listText.Add(sbValue.ToString().Trim());
                }
                else
                {
                    listText.Add(sbValue.ToString());
                }
                sbValue = null;
            }
            if (notSplitIfConmaExists == true)
            {
                if (___lastKonmaItemsCount >= 1 && ___lastKonmaItemsCount < listText.Count)
                {
                    System.Text.StringBuilder sbConcat = new StringBuilder();
                    int listTextCount = listText.Count;
                    for (int z = ___lastKonmaItemsCount; z < listTextCount; z++)
                    {
                        if (z >= listText.Count)
                            break;

                        sbConcat.Append(listText[z]);
                        sbConcat.Append(' ');
                        listText.RemoveAt(z);
                        z--;
                    }
                    if (sbValue != null)
                    {
                        sbConcat.Append(sbValue.ToString());
                        sbValue = new StringBuilder();
                    }
                    listText.Add(sbConcat.ToString());
                }
            }

            return listText.ToArray();
        }

        private static char[] CharsSplittingBackground = new char[] { ' ', ';', ',' };
        public static void parseCSSBackgroundString(string _s, CHtmlCSSStyleSheet stylePart)
        {
            try
            {
                int ___properComnaCount = 0;
                if (stylePart.___multipleBackgroundImageDataSet == null)
                {
                    stylePart.___multipleBackgroundImageDataSet = new System.Collections.Generic.List<CHtmlStyleElementMultpleImageData>();
                }
                string[] spLeft = SplitMultipleValuesToArray(_s, ref ___properComnaCount, true);
                if (___properComnaCount > 0)
                {

                    for (int i = 0; i < spLeft.Length; i++)
                    {

                        CHtmlStyleElementMultpleImageData ___multiData = null;
                        if (i < stylePart.___multipleBackgroundImageDataSet.Count)
                        {
                            ___multiData = stylePart.___multipleBackgroundImageDataSet[i];
                        }
                        else
                        {
                            ___multiData = new CHtmlStyleElementMultpleImageData();
                            stylePart.___multipleBackgroundImageDataSet.Add(___multiData);
                        }
                        ___multiData.background_image_origin = spLeft[i];
                        stylePart.___multipleBackgroundImageDataSet.Add(___multiData);
                        int ___properComnaCountSecond = 0;
                        string[] spSecondPhase = SplitMultipleValuesToArray(_s, ref ___properComnaCountSecond, false);
                        ___multiData.___bindMultipleImageDataFromSplitString(ref spSecondPhase, stylePart);
                    }
                }
                else
                {
                    if (stylePart.___multipleBackgroundImageDataSet.Count == 0)
                    {
                        CHtmlStyleElementMultpleImageData ___multiData = new CHtmlStyleElementMultpleImageData();
                        ___multiData.background_image_origin = _s;
                        stylePart.___multipleBackgroundImageDataSet.Add(___multiData);
                        ___multiData.___bindMultipleImageDataFromSplitString(ref spLeft, stylePart);

                        if (___multiData.isBackgroundColorSpecified == true && stylePart.___StyleType == CHtmlElementStyleType.Element)
                        {

                            stylePart.___IsBackgroundColorSpecified = true;
                            stylePart.___BackgroundSysColor = ___multiData.backgroundColorComputedValue;
                        }
                    }
                    else
                    {
                        CHtmlStyleElementMultpleImageData ___multiData = stylePart.___multipleBackgroundImageDataSet[0];
                        ___multiData.background_image_origin = _s;
                        ___multiData.___bindMultipleImageDataFromSplitString(ref spLeft, stylePart);

                    }


                }
            }
            catch (Exception exStyle)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("SetHTMLStyleElementBackgrundStyleString() Error. ", exStyle);
                }
            }
        }
        /// <summary>


        public static bool IsLinkElementDisabledAttributTrue(CHtmlElement ___element)
        {
            CHtmlAttribute attr = null;
            if (___element.___attributes.TryGetValue("disabled", out attr))
            {
                if (attr != null)
                {
                    if (attr.value == null)
                    {
                        return true;
                    }
                    if (attr.value is bool)
                    {
                        if (((bool)attr.value) == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }


        public static char GetHTMLCharStringHTMLString(string s)
        {
            return GetHTMLCharStringHTMLString(s, '?');
        }

        public static char GetHTMLCharStringHTMLString(string s, char failedChar)
        {

            if (s.Length > 2 && s[0] == '&')
            {
                if (s[1] == '#' && (s[2] == 'x' || s[2] == 'X'))
                { //'.ToString().StartsWith("&#x",StringComparison.OrdinalIgnoreCase) == true)
                    try
                    {
                        s = s.Remove(0, 3);
                        if (s[s.Length - 1] == ';')
                        {
                            s = s.Remove(s.Length - 1, 1);
                        }
                        return (char)Convert.ToInt32(s.ToString(), 16);
                    }
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                        {
                            commonLog.LogEntry("BUG! HTML Hex Parse {0} {1} ", s, ex.Message);
                        }
                        return failedChar;
                    }
                }
                else if (s[1] == '#')
                {
                    try
                    {

                        s = s.Remove(0, 2);
                        if (s[s.Length - 1] == ';')
                        {
                            s = s.Remove(s.Length - 1, 1);
                        }
                        int charParse;
                        int.TryParse(s, out charParse);
                        return (char)charParse;
                    }
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                        {
                            commonLog.LogEntry("BUG! HTML Parse {0} {1} ", s, ex.Message);
                        }
                        return failedChar;
                    }
                }
            }
            switch (s)
            {
                case "&amp;":
                    return '&';
                case "&gt;":
                    return '>';
                case "&lt;":
                    return '<';
                case "&nbsp;":
                    return ' ';
                case "&quot;":
                    return '\"';
                case "&apos;":
                    return (char)39;
                case "&tilde;":
                    return (char)126;
                case "&sbquo;":
                    return (char)130;
                case "&dbquo;":
                    return (char)132;
                case "&dagger;":
                    return (char)134;
                case "&Dagger;":
                    return (char)135;
                case "&eacute;":
                    return (char)136;
                case "&Ecirc;":
                    return (char)202;
                case "&Euml;":
                    return (char)203;
                case "&Igrave;":
                    return (char)204;
                case "&Iacute;":
                    return (char)205;
                case "&Icirc;":
                    return (char)206;
                case "&Iuml;":
                    return (char)207;
                case "&permil;":
                    return (char)137;
                case "&lsaquo;":
                    return (char)139;
                case "&lsquo;":
                    return (char)145;
                case "&rsquo;":
                    return (char)146;
                case "&ldquo;":
                    return (char)147;
                case "&rdquo;":
                    return (char)148;
                case "&ndash;":
                    return (char)150;
                case "&mdash;":
                    return (char)151;
                case "&tilde":
                    return (char)152;
                case "&trade;":
                    return (char)153;
                case "&rsaquo;":
                    return (char)155;
                case "&Yuml;":
                    return (char)159;
                case "&iexcl;":
                    return (char)161;
                case "&cent;":
                    return (char)162;
                case "&pound;":
                    return (char)163;
                case "&curren;":
                    return (char)164;
                case "&yen;":
                    return (char)165;
                case "&brvbar;":
                    return (char)166;
                case "&sect;":
                    return (char)167;
                case "&uml;":
                    return (char)168;
                case "&copy;":
                    return (char)169;
                case "&ordf;":
                    return (char)170;
                case "&laquo;":
                    return (char)171;
                case "&not;":
                    return (char)172;
                case "&shy;":
                    return (char)173;
                case "&reg;":
                    return (char)174;
                case "&macr;":
                    return (char)175;
                case "&deg;":
                    return (char)176;
                case "&plusmn;":
                    return (char)177;
                case "&sup2;":
                    return (char)178;
                case "&sup3;":
                    return (char)179;
                case "&acute;":
                    return (char)180;
                case "&micro;":
                    return (char)181;
                case "&para;":
                    return (char)182;
                case "&middot;":
                    return (char)183;
                case "&cedil;":
                    return (char)184;
                case "&sup1;":
                    return (char)185;
                case "&ordm;":
                    return (char)186;
                case "&raquo;":
                    return (char)187;
                case "&frac14;":
                    return (char)188;
                case "&frac12;":
                    return (char)189;
                case "&frac34;":
                    return (char)190;
                case "&iquest;":
                    return (char)191;
                case "&Agrave;":
                    return (char)192;
                case "&Aacute;":
                    return (char)193;
                case "&Acirc;":
                    return (char)194;
                case "&Atilde;":
                    return (char)195;
                case "&Auml;":
                    return (char)196;
                case "&Aring;":
                    return (char)197;
                case "&AElig;":
                    return (char)198;
                case "&Ccedil;":
                    return (char)199;
                case "&Egrave;":
                    return (char)200;
                case "&Eacute;":
                    return (char)201;
                case "&ETH;":
                    return (char)208;
                case "&Ntilde;":
                    return (char)209;
                case "&Ograve;":
                    return (char)210;
                case "&Oacute;":
                    return (char)211;
                case "&Ocirc;":
                    return (char)212;
                case "&Otilde;":
                    return (char)213;
                case "&Ouml;":
                    return (char)214;
                case "&Oslash;":
                    return (char)216;
                case "&Ugrave;":
                    return (char)217;
                case "&Uacute;":
                    return (char)218;
                case "&Ucirc;":
                    return (char)219;
                case "&Uuml;":
                    return (char)220;
                case "&Yacute;":
                    return (char)221;
                case "&THORN;":
                    return (char)222;
                case "&szlig;":
                    return (char)223;
                case "&agrave;":
                    return (char)224;
                case "&aacute;":
                    return (char)225;
                case "&acirc;":
                    return (char)226;
                case "&atilde;":
                    return (char)227;
                case "&auml;":
                    return (char)228;
                case "&aring;":
                    return (char)229;
                case "&aelig;":
                    return (char)230;
                case "&ccedil;":
                    return (char)231;
                case "&egrave;":
                    return (char)232;
                case "&ecirc;":
                    return (char)234;
                case "&euml;":
                    return (char)235;
                case "&igrave;":
                    return (char)236;
                case "&iacute;":
                    return (char)237;
                case "&icirc;":
                    return (char)238;
                case "&iuml;":
                    return (char)239;

                case "&eth;":
                    return (char)240;
                case "&ntilde;":
                    return (char)241;
                case "&ograve;":
                    return (char)242;
                case "&oacute;":
                    return (char)243;
                case "&ocirc;":
                    return (char)244;
                case "&otilde;":
                    return (char)245;
                case "&ouml;":
                    return (char)246;
                case "&divide;":
                    return (char)247;
                case "&oslash;":
                    return (char)248;
                case "&ugrave;":
                    return (char)249;
                case "&uacute;":
                    return (char)250;
                case "&ucirc;":
                    return (char)251;
                case "&uuml;":
                    return (char)252;
                case "&yacute;":
                    return (char)253;
                case "&thorn;":
                    return (char)254;
                case "&yuml;":
                    return (char)255;
                case "&OElig;":
                    return (char)338;
                case "&oelig;":
                    return (char)339;
                case "&Scaron;":
                    return (char)352;

                case "&scaron;":
                    return (char)353;




                /* case 200 - 255 is Greeks -*/
                case "&fnof;":
                    return (char)402;

                case "&circ;":
                    return (char)701;



                case "&Alpha;":
                    return (char)913;
                case "&Beta;":
                    return (char)914;
                case "&Gamma;":
                    return (char)915;
                case "&Delta;":
                    return (char)916;
                case "&Epsilon;":
                    return (char)917;
                case "&Zeta;":
                    return (char)918;
                case "&Eta;":
                    return (char)919;
                case "&Theta;":
                    return (char)920;
                case "&Iota;":
                    return (char)921;
                case "&Kappa;":
                    return (char)922;
                case "&Lambda;":
                    return (char)923;
                case "&Mu;":
                    return (char)924;
                case "&Nu;":
                    return (char)925;
                case "&Xi;":
                    return (char)926;
                case "&Omicron;":
                    return (char)927;
                case "&Pi;":
                    return (char)928;
                case "&Rho;":
                    return (char)929;
                case "&Sigma;":
                    return (char)931;
                case "&Tau;":
                    return (char)932;
                case "&Upsilon;":
                    return (char)933;
                case "&Phi;":
                    return (char)934;
                case "&Chi;":
                    return (char)935;
                case "&Psi;":
                    return (char)936;
                case "&Omega;":
                    return (char)937;
                case "&alpha;":
                    return (char)945;
                case "&beta;":
                    return (char)946;
                case "&gamma;":
                    return (char)947;
                case "&delta;":
                    return (char)948;
                case "&epsilon;":
                    return (char)949;
                case "&zeta;":
                    return (char)950;
                case "&eta;":
                    return (char)951;
                case "&theta;":
                    return (char)952;
                case "&iota;":
                    return (char)953;
                case "&kappa;":
                    return (char)954;
                case "&lambda;":
                    return (char)955;
                case "&mu;":
                    return (char)956;
                case "&nu;":
                    return (char)957;
                case "&xi;":
                    return (char)958;
                case "&omicron;":
                    return (char)959;
                case "&pi;":
                    return (char)960;
                case "&rho;":
                    return (char)961;
                case "&sigmaf;":
                    return (char)962;
                case "&sigma;":
                    return (char)963;
                case "&tau;":
                    return (char)964;
                case "&upsilon;":
                    return (char)965;
                case "&phi;":
                    return (char)966;
                case "&chi;":
                    return (char)967;
                case "&psi;":
                    return (char)968;
                case "&omega;":
                    return (char)969;
                case "&thetasym;":
                    return (char)977;
                case "&upsih;":
                    return (char)978;
                case "&piv;":
                    return (char)982;
                case "&ensp;":
                    return (char)8194;
                case "&emsp;":
                    return (char)8195;
                case "&thinsp;":
                    return (char)8201;
                case "&zwnj;":
                    return (char)8204;
                case "&zwj;":
                    return (char)8205;
                case "&bull;":
                    return (char)8226;// black o
                case "&hellip;":
                    return (char)8230;
                case "&prime;":
                    return (char)8242;
                case "&Prime;":
                    return (char)8243;
                case "&euro;":
                    return (char)8364;
                case "&oline;":
                    return (char)8254;
                case "&frasl;":
                    return (char)8260;
                case "&weierp;":
                    return (char)8472;
                case "&image;":
                    return (char)8485;
                case "&real;":
                    return (char)8476;
                case "&alefsym;":
                    return (char)8501;
                case "&larr;":
                    return (char)8592;
                case "&uarr;":
                    return (char)8593;
                case "&rarr;":
                    return (char)8594;
                case "&darr;":
                    return (char)8595;
                case "&harr;":
                    return (char)8596;
                case "&crarr;":
                    return (char)8629;
                case "&lArr;":
                    return (char)8656;
                case "&uArr;":
                    return (char)8657;
                case "&rArr;":
                    return (char)8658;
                case "&dArr;":
                    return (char)8659;
                case "&hArr;":
                    return (char)8660;
                case "&forall;":
                    return (char)8704;
                case "&part;":
                    return (char)8706;
                case "&exist;":
                    return (char)8707;
                case "&empty;":
                    return (char)8709;
                case "&nabla;":
                    return (char)8711;
                case "&isin;":
                    return (char)8712;
                case "&notin;":
                    return (char)8713;
                case "&ni;":
                    return (char)8715;
                case "&prod;":
                    return (char)8719;

                case "&lrm;":
                    return (char)8206;
                case "&rlm;":
                    return (char)8207;
                case "&bdquo;":
                    return (char)8222;

                case "&le;":
                    return (char)8804;
                case "&ge;":
                    return (char)8805;
                case "&sub;":
                    return (char)8834;
                case "&sup;":
                    return (char)8835;
                case "&nsub;":
                    return (char)8836;
                case "&sube;":
                    return (char)8838;
                case "&supe;":
                    return (char)8839;

                case "&oplus;":
                    return (char)8853;
                case "&otimes;":
                    return (char)8854;
                case "&perp;":
                    return (char)8869;
                case "&sdot;":
                    return (char)8901;
                case "&lceil;":
                    return (char)8968;
                case "&rceil;":
                    return (char)8969;
                case "&lfloor;":
                    return (char)8970;
                case "&rfloor;":
                    return (char)8971;
                case "&lang;":
                    return (char)9001;
                case "&rang;":
                    return (char)9002;
                case "&loz;":
                    return (char)9003;
                case "&spades;":
                    return (char)9824;
                case "&clubs;":
                    return (char)9827;
                case "&hearts;":
                    return (char)9829;

                case "&diams;":
                    return (char)9830;
                case "&times;":
                    return (char)215;
                case "&infin;":
                    return (char)8734;
                case "&ne;":
                    return (char)8800;
                case "&sum;":
                    return (char)8721;
                case "&minus;":
                    return (char)8722;
                case "&lowast;":
                    return (char)8727;
                case "&radic;":
                    return (char)8730;
                case "&prop;":
                    return (char)8733;
                case "&ang;":
                    return (char)8736;
                case "&and;":
                    return (char)8743;
                case "&or;":
                    return (char)8744;
                case "&cap;":
                    return (char)8745;
                case "&cup;":
                    return (char)8746;
                case "&int;":
                    return (char)8747;
                case "&there4;":
                    return (char)8756;
                case "&sim;":
                    return (char)8764;
                case "&cong;":
                    return (char)8773;
                case "&asymp;":
                    return (char)8776;
                case "&equiv;":
                    return (char)8801;

                default:
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                    {
                        commonLog.LogEntry("BUG! HTML Symbol Parse {0} ", s);
                    }
                    return failedChar;
            }
        }

        internal static string RepleaceHTMLStringFromString(string s)
        {
            string _s = s.Clone() as String;
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex("&");
            System.Text.RegularExpressions.MatchCollection mcol = regEx.Matches(s);
            for (int p = mcol.Count - 1; p >= 0; p--)
            {
                System.Text.RegularExpressions.Match mch = mcol[p];
                int EndPos = _s.IndexOf(';', mch.Index);
                if (EndPos > -1 && EndPos - mch.Index < 9)
                {
                    string _instr = _s.Substring(mch.Index, EndPos - mch.Index + 1);
                    char c = GetHTMLCharStringHTMLString(_instr);
                    if (c != (char)0)
                    {
                        _s = _s.Remove(mch.Index, EndPos - mch.Index + 1);
                        _s = _s.Insert(mch.Index, c.ToString());
                    }
                }
            }
            return _s;
        }
        internal static void ReplaceHTMLStringWithStringBuilderAtEnd(ref System.Text.StringBuilder sb)
        {
            // =======================================================================================
            // This is only occurs when ';' encounters
            // =======================================================================================
            if (sb.Length < 4)
            {
                return;
            }
            int sbLen = sb.Length;
            int StartPos = -1;
            System.Text.StringBuilder sbEnd = new System.Text.StringBuilder();
            for (int i = sbLen - 1; i > -1; i--)
            {
                sbEnd.Append(sb[i]);
                if (sb[i] == '&')
                {
                    StartPos = i;
                    break;
                }
                if (sbLen - i > 15)
                {
                    break;
                }

            }
            if (StartPos != -1)
            {
                char[] endChars = sbEnd.ToString().ToCharArray();
                Array.Reverse(endChars);
                System.Text.StringBuilder sbNew = new System.Text.StringBuilder();
                sbNew.Append(endChars);
                string strReplace = sbNew.ToString();

                char repc = GetHTMLCharStringHTMLString(strReplace);
                if (repc != (char)0)
                {
                    sb.Remove(StartPos, strReplace.Length);
                    sb.Append(repc);
                }
            }
            sbEnd = null;
        }
        internal static string ReplaceInvalidCharacters(string __Value, bool DoLower, bool DoTrim)
        {
            if (__Value == null || __Value.Length == 0)
                return "";
            if (DoLower == false)
            {
                char ___fistChar = __Value[0];
                if (DoTrim)
                {
                    if (IsCharWhiteSpaceLimited(___fistChar))
                    {
                        goto NormalStage;
                    }
                }
                if (char.IsLetterOrDigit(___fistChar) || ___fistChar == '#' || ___fistChar == '-')
                {
                    char ___lastChar = __Value[__Value.Length - 1];
                    if (IsCharWhiteSpaceLimited(___lastChar))
                    {
                        goto NormalStage;
                    }
                    if (char.IsLetterOrDigit(___lastChar) || ___lastChar == ')' || ___lastChar == '%')
                    {
                        return __Value;
                    }
                }
            }
        NormalStage:
            System.Text.StringBuilder sb = new StringBuilder();
            char[] cSp = __Value.ToCharArray();
            bool ___IsFirstValidCharFound = false;
            int cSpLen = cSp.Length;
            char c = '\0';
            for (int i = 0; i < cSpLen; i++)
            {
                c = cSp[i];
                switch (c)
                {
                    case '\r':
                    case '\n':
                    case '\t':
                    case '\0':
                        continue;
                    default:
                        if (___IsFirstValidCharFound == false)
                        {
                            if (IsCharWhiteSpaceLimited(c) == false)
                            {
                                ___IsFirstValidCharFound = true;
                            }
                            else
                            {
                                if (DoTrim == true)
                                {
                                    continue;
                                }
                            }
                        }
                        // DBCS Alphabet to SBCS Alphabet
                        if (DoLower)
                        {
                            if (c >= 'A' && c <= 'Z')
                            {
                                sb.Append(FasterToLower(c));
                            }
                            else
                            {
                                sb.Append(c);
                            }
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            if (DoTrim)
            {

                if (sb.Length > 0)
                {
                    char ___TrimEndChar = sb[sb.Length - 1];
                    if (IsCharWhiteSpaceLimited(___TrimEndChar) == true)
                    {
                        for (int __e = sb.Length - 1; __e >= 0; __e--)
                        {
                            if (IsCharWhiteSpaceLimited(sb[__e]))
                            {
                                sb.Remove(__e, 1);
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return sb.ToString();
        }

        internal static int GetIntValueFromString(string _HTMLValue, int _criteria)
        {
            return (int)GetDoubleValueFromString(_HTMLValue, (double)_criteria, -1);
        }
        internal static readonly System.Globalization.NumberStyles ___ParseFloatNumStyle = System.Globalization.NumberStyles.Number;
        internal static readonly System.Globalization.CultureInfo ___ParseFloatCulture = System.Globalization.CultureInfo.InvariantCulture;
        internal static double GetDoubleValueFromString(string _HTMLValue, double _criteria, double ___remValue)
        {
            if (_HTMLValue == null || _HTMLValue.Length == 0)
                return 0F;
            string _OriginalValue = _HTMLValue as String;
            char firstChar = _HTMLValue[0];
            if (firstChar == '=')
            {
                _HTMLValue = _HTMLValue.Remove(0, 1);
            }
            if ((firstChar >= '0' && firstChar <= '9') || firstChar == '-' || firstChar == '.')
            {
                goto SwithBlockDone;
            }

            switch (_HTMLValue)
            {
                case "thin":
                    return 1;
                case "tall":
                    return 20;
                case "xx-small":
                    return ((float)_criteria * 0.5F);
                case "x-small":
                    return ((float)_criteria * 0.6F);
                case "smaller":
                case "small":
                    return ((float)_criteria * 0.8F);
                case "medium":
                    return ((float)_criteria * 1F);
                case "larger":
                case "large":
                    return ((float)_criteria * 1.2F);
                case "x-large":
                    return ((float)_criteria * 1.5F);
                case "xx-large":
                    return ((float)_criteria * 2.0F);
                case null:
                case "NaN":
                case "NaNpx":
                case "none":
                case "no":
                case "":
                    return 0F;
                case "inherit":
                case "auto":
                case "initial":
                    return 0; // Most of the case, auto is used for margin, padding etc. use 0 to adjust aotomatic by code
                case "normal":
                    return _criteria;
                case "undefinedpx":
                case "undefined":
                    return 0;
                default:
                    break;
            }

        SwithBlockDone:
            string strParse = null;
            string strUnit = null;


            // --------------------------------------------------------------------------------
            // IndexofAny is slow 
            //int aPos = _HTMLValue.IndexOfAny(commonAlphabetCharactersLPlusPercent);
            // --------------------------------------------------------------------------------
            // 70% Faster than above code
            int aPos = -1;
            char seekc = '\0';
            int _HTMLValueLen = _HTMLValue.Length;
            for (int cpos = 0; cpos < _HTMLValueLen; cpos++)
            {
                seekc = _HTMLValue[cpos];
                if ((seekc >= 'a' && seekc <= 'z') || seekc == '%')
                {
                    aPos = cpos;
                    break;
                }
            }
            // --------------------------------------------------------------------------------
            if (aPos > -1)
            {
                strParse = _HTMLValue.Substring(0, aPos);
                if (string.IsNullOrEmpty(strParse) == false && (IsCharWhiteSpaceLimited(strParse[0]) == true || IsCharWhiteSpaceLimited(strParse[strParse.Length - 1]) == true))
                {
                    strParse = strParse.Trim();
                }
                strUnit = _HTMLValue.Substring(aPos);
                if (string.IsNullOrEmpty(strUnit) == false && (IsCharWhiteSpaceLimited(strUnit[0]) == true || IsCharWhiteSpaceLimited(strUnit[strUnit.Length - 1]) == true))
                {
                    strUnit = strUnit.Trim();
                }

                int posWhiteSpace = -1;
                if (strUnit != null && strUnit.Length != 0 && strUnit[strUnit.Length - 1] == ';')
                {
                    strUnit = strUnit.Substring(0, strUnit.Length - 1);
                }
                if (strUnit != null && strUnit.Length > 3)
                {

                    posWhiteSpace = strUnit.IndexOfAny(CharSpaceCrLfTabZentakuSpaceYenSlash, 0);
                    if (posWhiteSpace > -1)
                    {
                        string strUnitTemp = strUnit.Substring(0, posWhiteSpace);
                        if (strUnitTemp.Length != 0)
                        {
                            switch (strUnitTemp)
                            {
                                case "px":
                                case "in":
                                case "%":
                                case "mm":
                                case "cm":
                                case "pc":
                                case "rem":
                                case "em":
                                case "ex":
                                case "pt":
                                case "dpi":
                                case "dppx":
                                case "dpcm":
                                case "vh":
                                case "vw":
                                case "vmin":
                                case "vmax":
                                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
                                    {
                                        commonLog.LogEntry("Unit ___hasInner trimed to \'{0}\' from \'{1}\'", strUnitTemp, strUnit);
                                    }
                                    strUnit = string.Copy(strUnitTemp);
                                    break;
                                default:
                                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
                                    {
                                        commonLog.LogEntry("Unit ___hasInner invalid value trimed to \'px\' from \'{1}\'", strUnit);
                                    }
                                    strUnit = "px";
                                    break;
                            }
                        }
                    }
                }
            }
            else
            {
                if (_HTMLValue.Length > 1)
                {
                    int SpacePos = _HTMLValue.IndexOfAny(CharSpaceOrSlash);
                    if (SpacePos > 0)
                    {
                        int NumberCharCount = 0;
                        for (int cp = 0; cp < SpacePos; cp++)
                        {
                            if (char.IsNumber(_HTMLValue[cp]) == true)
                            {
                                NumberCharCount++;
                            }
                        }
                        if (NumberCharCount == SpacePos)
                        {
                            // Means All Character Before Space Or Yen Mark is numeric
                            strParse = _HTMLValue.Substring(0, SpacePos);
                            goto ParsePhase;
                        }
                    }
                }
                strParse = _HTMLValue;
            }
        ParsePhase:
            try
            {
                double dValue = 0;
                if (string.IsNullOrEmpty(strParse) == false)
                {
                    //dValue = float.Parse(strParse,System.Globalization.NumberStyles.Number);
                    bool __parseSuccess = double.TryParse(strParse, ___ParseFloatNumStyle, ___ParseFloatCulture, out dValue);
                    if (__parseSuccess == false)
                    {
                        string[] spTrialSplit = strParse.Split(CharSpaceCrLfTabZentakuSpaceComma);
                        if (spTrialSplit.Length > 0)
                        {
                            int spTrialSplitLen = spTrialSplit.Length;
                            string strFirstValue = null;
                            for (int t = 0; t < spTrialSplitLen; t++)
                            {
                                strFirstValue = spTrialSplit[t];
                                if (strFirstValue.Length != 0)
                                {
                                    if (double.TryParse(strFirstValue, ___ParseFloatNumStyle, ___ParseFloatCulture, out dValue))
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                        {
                                            commonLog.LogEntry("float.tryparse(\'{0}\' unsucessfull. parse '{1}'", strParse, strFirstValue);
                                        }
                                        return dValue;
                                    }
                                }
                            }
                        }
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                        {
                            commonLog.LogEntry("float.tryparse(\'{0}\' unsucessfull. return 0.", strParse);
                        }
                        return 0;
                    }

                }
                else
                {
                    dValue = 0;
                }
                int __CheckValueCount = 0;
            CheckValue:
                __CheckValueCount++;
                switch (strUnit)
                {
                    case null:
                    case "":
                        return dValue; // same as no unit
                    case "px":
                    case "dpi":
                    case "dpcm":
                    case "dppx":
                        return dValue; // same as no unit
                    case "pt":
                        return (dValue * 1.25F);
                    case "em":
                        // 1em = width of one character
                        // Note) FontSpec EM Size will be handled differently. 2014/10/10
                        return (dValue * fontOneCharacterWidth);
                    case "rem":
                        // ad hoc value
                        if (___remValue == -1)
                        {
                            return (dValue * 10.13F);
                        }
                        else
                        {
                            return (dValue * ___remValue);
                        }
                    case "ex":
                        // 1ex = height of lower 'x'
                        return (dValue * floatXLowerHeight * 1.00F);
                    case "in":
                        // 1in = 25mm
                        return (dValue * 80.0F);
                    case "pc":
                        // 1pc = 12pt
                        return (dValue * 12.0F);
                    case "cm":
                        return (dValue * 38.0F);
                    case "mm":
                        return (dValue * 3.8F);
                    case "%":
                        return (dValue / 100F * (double)_criteria);
                    case "vw":
                        return 0;
                    case "vh":
                        return 0;
                    case "vmax":
                        return 0;
                    case "vmin":
                        return 0;


                    default:
                        if (__CheckValueCount < 3)
                        {
                            if (strUnit.Length > 1)
                            {
                                if (strUnit[0] == '%')
                                {
                                    strUnit = "%";
                                    goto CheckValue;
                                }
                                // Some ___hasInner '2px0'
                                if (strUnit[strUnit.Length - 1] == '0')
                                {
                                    strUnit = strUnit.Remove(strUnit.Length - 1, 1);
                                    switch (strUnit)
                                    {
                                        case "px":
                                        case "%":
                                        case "em":
                                        case "pt":
                                        case "in":
                                        case "rem":
                                        case "mm":
                                        case "ex":
                                        case "pc":
                                        case "cm":
                                        case "dpi":
                                        case "dpcm":
                                        case "dppx":
                                            goto CheckValue;
                                        default:
                                            break;
                                    }
                                }
                                if (strUnit.Length >= 8)
                                {
                                    int posImp = strUnit.IndexOf("!impo", StringComparison.OrdinalIgnoreCase);
                                    if (posImp > 2)
                                    {
                                        strUnit = strUnit.Substring(0, posImp);
                                        if (string.IsNullOrEmpty(strUnit) == false && (IsCharWhiteSpaceLimited(strUnit[0]) == true || IsCharWhiteSpaceLimited(strUnit[strUnit.Length - 1]) == true))
                                        {
                                            strUnit = strUnit.Trim();
                                        }

                                        goto CheckValue;
                                    }
                                }

                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                {
                                    commonLog.LogEntry("Unknown Unit Original : \'{0}\' Unit : \'{1}\'", _HTMLValue, strUnit);
                                }
                                return 0;
                            }
                        }
                        return dValue;
                }
            }
            catch
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("Get Float Value Failed \"{0}\" : {1} {2}", _OriginalValue, strParse, strUnit);
                }
                return 0;
            }
        }
        public static CHtmlFileType GetHTMLFileTypeFromContentType(string __contenttype)
        {
            int pos = __contenttype.IndexOf(';');
            if (pos > -1)
            {
                __contenttype = __contenttype.Substring(0, pos);
            }
            switch (__contenttype)
            {
                case "image/jpeg":
                case "image/jpg":
                    return CHtmlFileType.JPG;
                case "image/png":
                    return CHtmlFileType.PNG;
                case "image/gif":
                    return CHtmlFileType.GIF;
                case "image/svg+xml":
                    return CHtmlFileType.SVG;

            }
            return CHtmlFileType.Unknown;
        }

        public static bool IsURLLooksLikeCSSUrl(string strUrl)
        {
            if (string.IsNullOrEmpty(strUrl) == true)
            {
                return false;
            }
            if (strUrl.IndexOf(".css", StringComparison.OrdinalIgnoreCase) > -1)
            {
                return true;
            }
            return false;
        }
        #region QuerySelectorMatesSelector

        internal static CHtmlCollection ___getQuerySelectorListProcessorInner(object element, string query, CHtmlQuerySelectorType ___querySelectorType)
        {

            CHtmlCollection result = new CHtmlCollection();
            if (___querySelectorType == CHtmlQuerySelectorType.unknown)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("BUGUBUG!!! __getQuerySelectorListProcessorInner() is called unkown queryType {1}", ___querySelectorType);
                }
                return result;
            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry($"___getQuerySelectorListProcessorInner {element} {query}, {___querySelectorType}");
            }
            result.___CollectionType = CHtmlHTMLCollectionType.QuerySelectorset;
            CHtmlCollection __baseLookupElementList = null;
            result.___createObjectIDTable();
            DateTime dtStart = DateTime.Now;

            char[] queryChars = query.ToCharArray();
            System.Text.StringBuilder sbSelector = new StringBuilder();
            SortedList srKeyClassBaseList = new SortedList(StringComparer.OrdinalIgnoreCase);
            bool ___isSingleElementQuery = false;
            bool _DoNotClearList = true;
            if (___querySelectorType == CHtmlQuerySelectorType.document_querySelector || ___querySelectorType == CHtmlQuerySelectorType.document_querySelectorAll)
            {
                _DoNotClearList = true;
                CHtmlDocument _doc = element as CHtmlDocument;
                _doc.___createAllElementListFromDocumentElement();
                __baseLookupElementList = _doc.___getElementsByTagNameWildCardSearchLastResult;
            }
            else if (___querySelectorType == CHtmlQuerySelectorType.element_querySelector || ___querySelectorType == CHtmlQuerySelectorType.element_querySelectorAll)
            {
                _DoNotClearList = false;
                __baseLookupElementList = new CHtmlCollection();
                __baseLookupElementList.Add(element);
                CHtmlElement __element = element as CHtmlElement;
                __element.___createChildElementListWithEnqueueDequeue(__baseLookupElementList, CHtmlElementQueryType.All, "");
            }
            if (___querySelectorType == CHtmlQuerySelectorType.element_querySelector || ___querySelectorType == CHtmlQuerySelectorType.document_querySelector)
            {
                ___isSingleElementQuery = true;
            }
            try
            {

                int sbQueryLen = queryChars.Length;
                for (int i = 0; i < sbQueryLen; i++)
                {
                    char c = queryChars[i];
                    switch (c)
                    {
                        case ',':
                            srKeyClassBaseList[sbSelector.ToString()] = CHtmlCSSRuleGroundList.CreateCHtmlStyleKeyList(sbSelector.ToString(), null);
                            sbSelector = null;
                            sbSelector = new StringBuilder();
                            break;
                        default:
                            sbSelector.Append(c);
                            continue;
                    }
                }
                if (sbSelector.Length > 0)
                {
                    srKeyClassBaseList[sbSelector.ToString()] = CHtmlCSSRuleGroundList.CreateCHtmlStyleKeyList(sbSelector.ToString(), null);
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 0)
                {
                    commonLog.LogEntry("BUGUBUG!!! querySelectorProcessorInner().CreateCHtmlStyleKeyList() Exception", ex);
                }
            }
            // =============================================================
            // if Query is just 1 length and for document. quick return may be performed.
            if (___querySelectorType == CHtmlQuerySelectorType.document_querySelector || ___querySelectorType == CHtmlQuerySelectorType.document_querySelectorAll)
            {
                if (srKeyClassBaseList.Count == 1)
                {
                    System.Collections.Generic.List<CHtmlStyleKey> arKeys = srKeyClassBaseList.GetByIndex(0) as System.Collections.Generic.List<CHtmlStyleKey>;
                    if (arKeys != null && arKeys.Count == 1)
                    {
                        CHtmlStyleKey firstTopKeyClass = arKeys[0] as CHtmlStyleKey;
                        if (firstTopKeyClass != null)
                        {
                            if (firstTopKeyClass.___StyleSelectorKeyDataMode == CHtmlStyleSelectorKeyDataModeType.Other)
                            {
                                goto FirstKeyCheckDone;
                            }
                            if (firstTopKeyClass.___attributeKeyList != null && firstTopKeyClass.___attributeKeyList.Count > 0)
                            {
                                goto FirstKeyCheckDone;
                            }
                            if (firstTopKeyClass.___pseudoTitleParamList != null && firstTopKeyClass.___pseudoTitleParamList.Count > 0)
                            {
                                goto FirstKeyCheckDone;
                            }
                            CHtmlDocument ___docLookup = element as CHtmlDocument;
                            switch (firstTopKeyClass.___StyleSelectorKeyDataMode)
                            {
                                case CHtmlStyleSelectorKeyDataModeType.IDOnly:
                                    // Assuming there is only one element for id per document.
                                    CHtmlElement elementByID = ___docLookup.getElementById(firstTopKeyClass.CssIDLowSimple);
                                    if (elementByID != null)
                                    {
                                        result.Add(elementByID);

                                    }

                                    goto QueryProcessComplete;

                                case CHtmlStyleSelectorKeyDataModeType.TagOnly:
                                    int allInternalCount = __baseLookupElementList.Count;
                                    bool ___IsAllAdd = false;
                                    if (firstTopKeyClass.___elementTagType != CHtmlElementType._UNDEFINED && firstTopKeyClass.___elementTagType == CHtmlElementType.ASTERISK)
                                    {
                                        ___IsAllAdd = true;
                                        if (___docLookup.___getElementsByTagNameWildCardSearchLastResult != null && ___docLookup.___getElementsByTagNameWildCardSearchLastResult_ALL_COUNT == __baseLookupElementList.Count)
                                        {
                                            result.AddRange(___docLookup.___getElementsByTagNameWildCardSearchLastResult as ICollection);
                                            goto QueryProcessComplete;
                                        }
                                        else
                                        {
                                            result.AddRange(__baseLookupElementList as ICollection);
                                            goto QueryProcessComplete;
                                        }
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(firstTopKeyClass.TagName) == false && firstTopKeyClass.TagName.Length == 1 && firstTopKeyClass.TagName[0] == '*')
                                        {
                                            ___IsAllAdd = true;
                                        }
                                    }
                                    for (int i = 0; i < allInternalCount; i++)
                                    {
                                        CHtmlElement ___elmentToLookup = __baseLookupElementList[i] as CHtmlElement;
                                        if (___elmentToLookup == null || ___elmentToLookup.___IsSystemHidden == true || ___elmentToLookup.___parentWeakRef == null)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            if (___IsAllAdd == true)
                                            {
                                                result.Add(___elmentToLookup);
                                                if (___isSingleElementQuery == true)
                                                {
                                                    goto QueryProcessComplete;
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                if (firstTopKeyClass.___elementTagType != CHtmlElementType._UNDEFINED && firstTopKeyClass.___elementTagType != CHtmlElementType.UNKNOWN && firstTopKeyClass.___elementTagType == ___elmentToLookup.___elementTagType)
                                                {
                                                    result.Add(___elmentToLookup);
                                                    if (___isSingleElementQuery == true)
                                                    {
                                                        goto QueryProcessComplete;
                                                    }
                                                    else
                                                    {
                                                        continue;
                                                    }
                                                }
                                                else if (string.Equals(___elmentToLookup.tagNameNoNS, firstTopKeyClass.TagName, StringComparison.Ordinal) == true)
                                                {
                                                    result.Add(___elmentToLookup);
                                                    if (___isSingleElementQuery == true)
                                                    {
                                                        goto QueryProcessComplete;
                                                    }
                                                    else
                                                    {
                                                        continue;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    goto QueryProcessComplete;
                                case CHtmlStyleSelectorKeyDataModeType.ClassOnly:
                                    int allInternalCount2 = __baseLookupElementList.Count;
                                    for (int i = 0; i < allInternalCount2; i++)
                                    {
                                        CHtmlElement ___elmentToLookup = __baseLookupElementList[i] as CHtmlElement;
                                        if (___elmentToLookup == null || ___elmentToLookup.___IsSystemHidden == true)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(___elmentToLookup.___class) == true)
                                            {
                                                continue;
                                            }
                                            if (firstTopKeyClass.IsElementClassesMatesOneOfClassList(___elmentToLookup.___classList))
                                            {
                                                result.Add(___elmentToLookup);
                                                if (___isSingleElementQuery == true)
                                                {
                                                    goto QueryProcessComplete;
                                                }
                                                else
                                                {
                                                    continue;
                                                }

                                            }
                                        }
                                    }
                                    goto QueryProcessComplete;
                            }
                        }
                    }

                }
            }
        FirstKeyCheckDone:

            // =============================================================


            try
            {

                if (__baseLookupElementList != null && __baseLookupElementList.Count > 0 && srKeyClassBaseList.Count > 0)
                {
                    int __baseLookupElementListCount = __baseLookupElementList.Count;
                    for (int i = 0; i < __baseLookupElementListCount; i++)
                    {
                        if (___isSingleElementQuery == true && result.Count > 0)
                        {
                            break;
                        }
                        CHtmlElement node = __baseLookupElementList[i] as CHtmlElement;
                        if (node != null)
                        {
                            switch (node.___elementTagType)
                            {
                                case CHtmlElementType._ITEXT:
                                case CHtmlElementType._IDRAW:
                                case CHtmlElementType.COMMENT:
                                case CHtmlElementType._ELEMENT_AFTER:
                                case CHtmlElementType._ELEMENT_BEFORE:
                                    continue;
                            }
                            //  string __SelectorSegment = null;
                            System.Collections.Generic.List<CHtmlStyleKey> arKeyClass = null;
                            int srKeyClassBaseListCount = srKeyClassBaseList.Count;
                            for (int keyClassBaseListPos = 0; keyClassBaseListPos < srKeyClassBaseListCount; keyClassBaseListPos++)
                            {
                                //__SelectorSegment = null;
                                arKeyClass = null;
                                //__SelectorSegment = srKeyClassBaseList.GetKey(keyClassBaseListPos) as String;

                                arKeyClass = srKeyClassBaseList.GetByIndex(keyClassBaseListPos) as System.Collections.Generic.List<CHtmlStyleKey>;

                                if (arKeyClass == null)
                                    continue;
                                int arKeyClassItemCount = arKeyClass.Count;
                                if (arKeyClassItemCount == 0)
                                {
                                    continue;
                                }

                                CHtmlStyleKey lookupKeyClass = arKeyClass[arKeyClassItemCount - 1] as CHtmlStyleKey;
                                if (lookupKeyClass != null)
                                {
                                    if (lookupKeyClass.___elementTagType != CHtmlElementType._UNDEFINED && lookupKeyClass.___elementTagType != CHtmlElementType.UNKNOWN)
                                    {
                                        if (lookupKeyClass.___elementTagType == CHtmlElementType.ASTERISK)
                                        {
                                            goto TagCheckDone;
                                        }
                                        if (node.___elementTagType != lookupKeyClass.___elementTagType)
                                        {
                                            goto NextElement;
                                        }
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(lookupKeyClass.TagName) == false)
                                        {
                                            if (string.Equals(node.___tagName, lookupKeyClass.TagName, StringComparison.Ordinal) == false)
                                            {
                                                goto NextElement;
                                            }
                                        }
                                        else
                                        {
                                            goto TagCheckDone;
                                        }
                                    }
                                TagCheckDone:
                                    if (string.IsNullOrEmpty(lookupKeyClass.CssIDLowSimple) == false)
                                    {

                                        if (string.Equals(node.___idLowSimple, lookupKeyClass.CssIDLowSimple, StringComparison.Ordinal) == false)
                                        {
                                            goto NextElement;
                                        }
                                    }
                                    if (lookupKeyClass.___classList.Count > 0)
                                    {
                                        if (string.IsNullOrEmpty(node.___class) == true)
                                        {
                                            goto NextElement;
                                        }
                                        if (lookupKeyClass.IsElementClassesMates(node.___classList) == false)
                                        {
                                            goto NextElement;
                                        }
                                    }
                                    if (lookupKeyClass.___attributeKeyList != null && lookupKeyClass.___attributeKeyList.Count > 0)
                                    {
                                        foreach (CHtmlStyleElementSelectorKeyAttributeClass? __curKeyAttrNullable in lookupKeyClass.___attributeKeyList.Values)
                                        {
                                            if (__curKeyAttrNullable != null)
                                            {
                                                CHtmlStyleElementSelectorKeyAttributeClass __curKeyAttr = __curKeyAttrNullable.Value;
                                                if (node.___attributes.ContainsKey(__curKeyAttr.Name) == false)
                                                {
                                                    goto NextKeyClass;
                                                }
                                                else
                                                {
                                                    if (__curKeyAttr.OperatorType == CSSSelectorKeyOperataorType.none)
                                                    {
                                                        goto StageHitted;
                                                    }
                                                    string ___attrValue = GetElementAttributeInString(node, __curKeyAttr.Name);
                                                    if (__curKeyAttr.IsValueMatches(___attrValue) == true)
                                                    {
                                                        goto StageHitted;
                                                    }
                                                    else
                                                    {
                                                        goto NextKeyClass;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                StageHitted:
                                    // =================================================
                                    // HIT!!! 
                                    // =================================================
                                    // At this point we only lookup the 1 level search
                                    // ------------------------------------------------
                                    if (arKeyClassItemCount == 1)
                                    {
                                        result.Add(node);
                                        goto NextElement;
                                    }
                                    else if (arKeyClassItemCount > 1)
                                    {

                                        if (IsParentSelectorMathes(node, arKeyClass, arKeyClassItemCount - 2) == true)
                                        {
                                            result.Add(node);
                                            goto NextElement;
                                        }
                                        else
                                        {
                                            goto NextElement;
                                        }
                                    }
                                    // =================================================
                                }
                            NextKeyClass:
                                if (false) {; }
                            }
                        }
                    NextElement:
                        if (false) {; }
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry(" querySelectorProcessorInner Stage 2) " + query, ex);
                }
            }
        QueryProcessComplete:
            result.QueryString = ___querySelectorType.ToString() + " " + query;

            if (__baseLookupElementList != null)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    TimeSpan tpSpan = DateTime.Now.Subtract(dtStart);
                    int ___baseLookupListCount = -1;
                    if (__baseLookupElementList != null)
                    {
                        ___baseLookupListCount = __baseLookupElementList.Count;
                    }
                    commonLog.LogEntry("querySelectorProcessorInner('{0}' \"{1}\" {2} {3}/{4} in {5} ms.", element, query, ___querySelectorType, result.Count, ___baseLookupListCount, tpSpan.TotalMilliseconds);
                }
            }
            if (_DoNotClearList == false)
            {

                __baseLookupElementList = null;
            }
            return result;
        }
        public static bool IsParentSelectorMathes(CHtmlElement __bottomElement, System.Collections.Generic.List<CHtmlStyleKey> arSelectors, int _SelectorStartPos)
        {
            int ExpectedMatchCount = _SelectorStartPos + 1;
            int __ParentMatchCount = 0;

            try
            {

                for (int selectorPos = _SelectorStartPos; selectorPos >= 0; selectorPos--)
                {
                    CHtmlStyleKey _selectorKey = arSelectors[selectorPos] as CHtmlStyleKey;
                    if (_selectorKey != null)
                    {

                        CHtmlElement __parent = __bottomElement.___parent as CHtmlElement;
                        bool __IsParentFound = false;
                        int ParentMoveCount = 0;
                        while (__parent != null)
                        {
                            if (_selectorKey.___elementTagType != CHtmlElementType._UNDEFINED)
                            {
                                if (_selectorKey.___elementTagType == CHtmlElementType.ASTERISK)
                                {
                                    goto TagLookupDone;
                                }
                                else if (_selectorKey.___elementTagType != __parent.___elementTagType)
                                {
                                    goto LookupForParent;
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(_selectorKey.TagName) == false)
                                {
                                    if (_selectorKey.TagName.Length == 1 && _selectorKey.TagName[0] == '*')
                                    {
                                        goto TagLookupDone;
                                    }
                                    if (string.Equals(__parent.___tagName, _selectorKey.TagName, StringComparison.Ordinal) == false)
                                    {
                                        goto LookupForParent;
                                    }

                                }
                            }
                        TagLookupDone:
                            if (_selectorKey.___classList.Count > 0)
                            {
                                if (!_selectorKey.IsElementClassesMates(__parent.___classList))
                                {
                                    goto LookupForParent;
                                }
                            }
                            int ___attributeKeyListCount = 0;
                            if (_selectorKey.___attributeKeyList != null)
                            {
                                ___attributeKeyListCount = _selectorKey.___attributeKeyList.Count;

                                foreach (CHtmlStyleElementSelectorKeyAttributeClass? __curKeyAttrNullable in _selectorKey.___attributeKeyList.Values)
                                {

                                    if (__curKeyAttrNullable != null)
                                    {
                                        CHtmlStyleElementSelectorKeyAttributeClass __curKeyAttr = __curKeyAttrNullable.Value;
                                        if (__parent.___attributes.ContainsKey(__curKeyAttr.Name) == false)
                                        {
                                            goto LookupForParent;
                                        }
                                        else
                                        {
                                            if (__curKeyAttr.OperatorType == CSSSelectorKeyOperataorType.none)
                                            {
                                                // There is no operator means it is any
                                                continue;
                                            }
                                            string ___attrValue = GetElementAttributeInString(__parent, __curKeyAttr.Name);
                                            if (__curKeyAttr.IsValueMatches(___attrValue) == false)
                                            {
                                                goto LookupForParent;
                                            }
                                        }
                                    }
                                }
                            }
                            //StageHitted:
                            __IsParentFound = true;
                            break;
                        LookupForParent:
                            __parent = __parent.___parent as CHtmlElement;
                            ParentMoveCount++;
                            if (MAX_QUERYSELECTOR_PARENT_SEARCH_LIMIT < ParentMoveCount)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                {
                                    commonLog.LogEntry("PerformQuerySelector IsparentSelectorMatches over limit : {0}...", MAX_QUERYSELECTOR_PARENT_SEARCH_LIMIT);
                                }
                                goto ReportSection;
                            }
                        }
                        if (__IsParentFound == false)
                        {
                            goto ReportSection;
                        }
                        else
                        {
                            __ParentMatchCount++;
                        }
                    }
                }
            }
            catch (Exception ex2)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("{0} ___hasInner error {1}", ex2.Message, commonData.GetExceptionAsString(ex2));
                }
            }
        ReportSection:
            if (ExpectedMatchCount > 0 && ExpectedMatchCount == __ParentMatchCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static ColorSpec GetParentColorDefined(CHtmlElement ___element, bool IsBackground, ref bool IsFound)
        {
            CHtmlElement lookupElement = ___element;
            while (lookupElement != null)
            {
                if (IsBackground == true)
                {
                    if (lookupElement.___style.___IsBackgroundColorSpecified == true)
                    {
                        IsFound = true;
                        return lookupElement.___style.___BackgroundSysColor;
                    }
                }
                else
                {
                    if (lookupElement.___style.___IsForegroundSysColorSpecified == true)
                    {
                        IsFound = true;
                        return lookupElement.___style.___ForegroundSysColor;
                    }

                }
                lookupElement = lookupElement.___parent as CHtmlElement;

            }
            IsFound = false;
            return new ColorSpec(0, 0, 0, 255);
        }

        public static bool matchesSelector(CHtmlDocument doc, CHtmlElement node, string test)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
            {
                commonLog.LogEntry("mathesSelector({0}, {1}", node, test);
            }
            return true;
        }
        #endregion


        public static string GetBoolToString(bool b)
        {
            if (b)
                return "*";
            else
                return "-";
        }
        public static string GetBoolToString(bool b, string _TrueString, string _FalseString)
        {
            if (b)
                return _TrueString;
            else
                return _FalseString;
        }

        public static bool IsStringValueZero(string __value)
        {
            switch (__value)
            {
                case null:
                case "":
                case "0":
                case "0px":
                case "0 px":
                case "0 pt":
                case "0pt":
                case ".0em":
                case "0in":
                case "0mm":
                case "0cm":
                case "0em":
                case "none":
                case "0pc":
                    return true;
            }
            return false;
        }

        public static CHtmlFileType GetHTMLFileType(string _Url, ref string _FileName, ref bool _IsForDownload)
        {
            return GetHTMLFileType("", null, _Url, ref _FileName, ref _IsForDownload, null);
        }

        public static CHtmlFileType GetHTMLFileType(CHtmlAttributeList Attributes, ref string _Filename, ref bool _IsForDownload)
        {
            return GetHTMLFileType("", Attributes, "", ref _Filename, ref _IsForDownload, null);
        }

        public static bool SwapHostUrlToIPUrl(ref System.Uri ___Uri)
        {
            try
            {
                string _sScheme = ___Uri.Scheme;
                string _sPathAndQuery = ___Uri.PathAndQuery;
                string _sHost = ___Uri.Host;
                int _iPort = ___Uri.Port;
                string _sIpHost = "";
                if (System.Environment.Version.Major < 2)
                {
                    System.Net.IPHostEntry ipHostEntry = System.Net.Dns.GetHostByName(___Uri.Host);
                    foreach (System.Net.IPAddress ipAddr in ipHostEntry.AddressList)
                    {
                        if (_sIpHost.Length == 0)
                        {
                            _sIpHost = ipAddr.ToString();
                            break;
                        }

                    }
                }
                else
                {
                    Type typeDNS = null;
                    typeDNS = typeof(System.Net.HttpWebRequest).Assembly.GetType("System.Net.Dns");
                    if (typeDNS == null)
                    {
                        Type[] typesNet = typeof(System.Net.HttpWebRequest).Assembly.GetTypes();

                        foreach (System.Type tp in typesNet)
                        {
                            if (string.Equals(tp.Name, "Dns", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                typeDNS = tp;
                                break;
                            }
                        }
                    }
                    if (typeDNS != null)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                        {
                            commonLog.LogEntry("{0} found", typeDNS);
                        }
                        System.Net.IPAddress[] ipAddrs = typeDNS.InvokeMember("GetHostAddresses", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.InvokeMethod, null, typeDNS, new object[] { ___Uri.Host }) as System.Net.IPAddress[];
                        Random rd = new Random(DateTime.Now.Millisecond);
                        foreach (System.Net.IPAddress ipAddr in ipAddrs)
                        {

                            if (_sIpHost.Length == 0)
                            {
                                _sIpHost = ipAddr.ToString();
                                if (rd.Next(10) == 5)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                        {
                            commonLog.LogEntry("Type DNS not obtained...");
                        }
                    }
                }
                if (_sIpHost.Length != 0)
                {
                    if (_iPort == 80)
                    {

                        ___Uri = new Uri(_sScheme + "://" + _sIpHost + _sPathAndQuery);


                    }
                    else
                    {

                        ___Uri = new Uri(_sScheme + "://" + _sIpHost + ":" + _iPort + _sPathAndQuery);


                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("DNS Prefetch : {0}", ex.Message);
                }
                return false;
            }

        }
        public static bool isContentTypePlainText(string _contenttype)
        {
            if (string.IsNullOrEmpty(_contenttype) || _contenttype.Length == 0)
            {
                return false;
            }
            int __indexOfSemicolon = _contenttype.IndexOf(';');
            if (__indexOfSemicolon > -1)
            {
                _contenttype = _contenttype.Substring(0, __indexOfSemicolon).Trim();
            }
            switch (_contenttype)
            {
                case "text/plain":
                case "text/html":
                case "text/xml":
                case "text/css":
                case "text/javascript":
                case "application/javascript":
                case "application/json":
                case "text/json":
                case "text/x-json":
                case "text/x-javascript":
                case "text/x-js":
                case "text/python":
                case "text/x-python":
                    return true;
                default:
                    return false;
            }
        }
        public static CHtmlFileType GetHTMLFileType(string tagName, CHtmlAttributeList Attributes, string OriginalUrl, ref string _Filename, ref bool _IsForDownload, CHtmlElement _chtmlelement)
        {

            /*
			if(Attributes == null && OriginalUrl.Length != 0)
			{
				//_Filename = OriginalUrl;
			}
			*/

            CHtmlFileType _fileType = CHtmlFileType.Unknown;
            try
            {
                string __Rel = "";
                string __Type = "";
                string __Media = "";
                bool __IsRelDownloadNegative = false;
                //bool __IsRelMediaNegative = false;

                if (_chtmlelement.___attributes.ContainsKey("rel") == true)
                {
                    string _Value = FasterToLower(GetElementAttributeInString(_chtmlelement, "rel"));
                    switch (_Value)
                    {
                        case "stylesheet":
                            _IsForDownload = true;
                            _fileType = CHtmlFileType.Css;
                            break;
                        case "icon":
                        case "ico":
                        case "shortcut icon":
                        case "shotcut icon":
                        case "apple-touch-icon":
                        case "apple touch icon":
                        case "cut icon":
                            _IsForDownload = false;
                            __IsRelDownloadNegative = true;
                            _fileType = CHtmlFileType.ICO;
                            break;
                        default:
                            if (_Value.IndexOf("alternate", StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                _IsForDownload = false;
                                __IsRelDownloadNegative = true;
                            }
                            break;

                    }
                    __Rel = _Value;
                }
                if (_chtmlelement.___attributes.ContainsKey("type") == true)
                {
                    string _Value = GetElementAttributeInString(_chtmlelement, "type");
                    switch (FasterToLower(_Value))
                    {
                        case "text/css":
                        case "styleseet": //illegular but just in case
                            _IsForDownload = true;
                            _fileType = CHtmlFileType.Css;
                            break;
                        case "javascript":
                        case "text/javascript":
                            _IsForDownload = true;
                            _fileType = CHtmlFileType.JavaScript;
                            break;
                        case "application/rss+xml":
                        case "application/rdf+xml":
                            _IsForDownload = false;
                            _fileType = CHtmlFileType.Rss;
                            break;
                        case "application/json":
                        case "application/x-json":
                        case "text/json":
                            _IsForDownload = true;
                            _fileType = CHtmlFileType.Json;
                            break;
                        case "image/jpeg":
                        case "image/jpg":
                        case "image/jfif":
                        case "image/jfi":
                            _IsForDownload = true;
                            _fileType = CHtmlFileType.JPG;
                            break;
                        case "image/gif":
                            _IsForDownload = true;
                            _fileType = CHtmlFileType.GIF;
                            break;
                        case "image/png":
                            _IsForDownload = true;
                            _fileType = CHtmlFileType.PNG;
                            break;
                        case "image/x-bmp":
                        case "image/x-ms-bmp":
                        case "image/x-bitmap":
                        case "image/x-xpixmap":
                            _IsForDownload = true;
                            _fileType = CHtmlFileType.BMP;
                            break;
                        case "image/svg":
                            _IsForDownload = true;
                            _fileType = CHtmlFileType.SVG;
                            break;
                        case "image":
                            _IsForDownload = true;
                            _fileType = CHtmlFileType.Unknown;
                            break;
                    }
                    __Type = _Value;

                }
                if (_chtmlelement.___attributes.ContainsKey("language") == true)
                {

                    string _sLang = GetElementAttributeInString(_chtmlelement, "language");
                    if (_sLang.Length > 0)
                    {
                        string _sLangAfter = FasterToLower(_sLang).Replace("text/", "");
                        if (_sLangAfter.Length > 0)
                        {
                            char ___firstChar = _sLangAfter[0];
                            if (___firstChar >= 'A' && ___firstChar <= 'Z')
                            {
                                ___firstChar = FasterToLower(___firstChar);
                            }
                            switch (___firstChar)
                            {
                                case 'j':

                                    if (_sLang.IndexOf("javascript", StringComparison.OrdinalIgnoreCase) > -1)
                                    {
                                        _IsForDownload = true;
                                        _fileType = CHtmlFileType.JavaScript;

                                    }
                                    else if (_sLang.IndexOf("json", StringComparison.OrdinalIgnoreCase) > -1)
                                    {
                                        _IsForDownload = true;
                                        _fileType = CHtmlFileType.Json;
                                    }
                                    break;
                                case 'v':
                                    if (_sLang.IndexOf("vbscript", StringComparison.OrdinalIgnoreCase) > -1)
                                    {
                                        _IsForDownload = true;
                                        _fileType = CHtmlFileType.VBScript;

                                    }
                                    break;
                            }
                        }
                    }
                }






                if (_chtmlelement.src.Length != 0)
                {

                    if (_chtmlelement == null)
                    {
                        _Filename = _chtmlelement.src;
                    }
                    else
                    {
                        if (_chtmlelement.___srcBase != null)
                        {
                            _Filename = string.Copy(_chtmlelement.___srcBase.href);
                        }
                    }
                }
                if (_chtmlelement.___attributes.ContainsKey("href") == true)
                {
                    string _Value = GetElementAttributeInString(_chtmlelement, "href");
                    if (_chtmlelement == null)
                    {
                        _Filename = _Value;
                    }
                    else
                    {
                        if (_chtmlelement.___hrefBase != null)
                        {
                            _Filename = string.Copy(_chtmlelement.___hrefBase.href);
                        }
                    }
                }
                if (_chtmlelement.___attributes.ContainsKey("media") == true)
                {
                    __Media = FasterTrimAndToLower(GetElementAttributeInString(_chtmlelement, "media"));

                }





                if (_fileType == CHtmlFileType.Css)
                {
                    _IsForDownload = true;
                    if (__Rel.IndexOf("alternate", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        _IsForDownload = false;
                        return _fileType;
                    }
                    else
                    {
                        if (__Media.Length > 0)
                        {
                            _chtmlelement.___MediaQueryNode = new CHtmlMediaQueryNode(CHtmlMediaQueryNodeType.RootNode);
                            try
                            {
                                _chtmlelement.___MediaQueryNode.OwnerElementType = MediaQueryOwnerElementType.LinkElement;
                                _chtmlelement.___MediaQueryNode.Text = __Media;
                                if (_chtmlelement.___MediaQueryNode.Result == CHtmlMediaQueryResult.Fail)
                                {
                                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                    {
                                        commonLog.LogEntry("[MediaQuery] {0} css download will be skip MediaQueries", __Media);
                                    }
                                    _IsForDownload = false;
                                    return _fileType;
                                }

                            }
                            catch (Exception ex)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                {
                                    commonLog.LogEntry("MediaQueryNode.Text", ex);
                                }
                            }
                        }
                    }
                    _IsForDownload = true;
                    return _fileType;

                }




                if (_fileType == CHtmlFileType.Unknown)
                {
                    int period = _Filename.LastIndexOf('.');
                    if (period > 0)
                    {
                        string strExt = _Filename.Substring(period + 1);
                        switch (FasterToLower(strExt))
                        {
                            case "gif":
                                if (string.Equals(tagName, "IMG", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    _IsForDownload = true;
                                }
                                return CHtmlFileType.GIF;
                            case "png":
                                if (string.Equals(tagName, "IMG", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    _IsForDownload = true;
                                }
                                return CHtmlFileType.PNG;
                            case "css":
                                if (string.Equals(tagName, "LINK", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    if (__IsRelDownloadNegative == false)
                                    {
                                        _IsForDownload = true;
                                    }
                                }
                                else
                                {
                                    _IsForDownload = false;
                                }
                                return CHtmlFileType.Css;
                            case "jpg":
                                if (string.Equals(tagName, "IMG", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    _IsForDownload = true;
                                }
                                return CHtmlFileType.JPG;
                            case "bmp":
                                _IsForDownload = false;
                                return CHtmlFileType.BMP;
                            case "js":
                                _IsForDownload = true;
                                return CHtmlFileType.JavaScript;
                            case "json":
                                if (string.Equals(tagName, "SCRIPT", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    _IsForDownload = true;
                                }
                                return CHtmlFileType.Json;
                            case "vbs":
                                _IsForDownload = true;
                                return CHtmlFileType.VBScript;
                            case "txt":
                                _IsForDownload = false;
                                return CHtmlFileType.Text;
                            case "html":
                            case "htm":
                                _IsForDownload = false;
                                return CHtmlFileType.Html;
                            case "ico":
                                _IsForDownload = false;
                                return CHtmlFileType.ICO;
                            case "aspx":
                                if (string.Equals(tagName, "IMG", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    _IsForDownload = true;
                                }
                                return CHtmlFileType.Aspx;

                            case "asp":
                                _IsForDownload = false;
                                return CHtmlFileType.Asp;
                            default:
                                if (string.Equals(tagName, "IMG", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    _IsForDownload = true;
                                }

                                _fileType = CHtmlFileType.Unknown;
                                break;

                        }
                    }
                    if (_fileType == CHtmlFileType.Unknown)
                    {
                        if (string.Equals(tagName, "IMG", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (_Filename.Length != 0)
                            {
                                _IsForDownload = true;
                                _fileType = CHtmlFileType.GIF;
                            }
                        }
                    }
                    else if (_fileType == CHtmlFileType.Unknown)
                    {
                        if (string.Equals(tagName, "SCRIPT", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (_Filename.Length != 0)
                            {
                                _IsForDownload = true;
                                _fileType = CHtmlFileType.JavaScript;
                            }
                        }
                    }

                }
                return _fileType;
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("GetHTMLFileType", ex);
                }
                return CHtmlFileType.Unknown;
            }
        }

        public static string GetCharsetFromCSSBytes(byte[] bts)
        {
            if (bts == null)
                return "";
            try
            {
                int btsLen = bts.Length;
                int ci = 0;
                for (int i = 0; i < btsLen; i++)
                {
                    ci = bts[i];
                    switch (ci) // '@'
                    {
                        case 64:
                            if (i < bts.Length - 8)
                            {
                                if (bts[i + 1] == 99 && bts[i + 2] == 104 && bts[i + 3] == 97 && bts[i + 4] == 114 && bts[i + 5] == 115 && bts[i + 6] == 101 && bts[i + 7] == 116) // "charset"
                                {
                                    System.Text.StringBuilder sbChars = new StringBuilder();
                                    char c = '\0';

                                    for (int z = i + 9; z < btsLen; z++)
                                    {
                                        c = (char)bts[z];
                                        if (IsCharWhiteSpaceLimited(c))
                                        {
                                            if (sbChars.Length > 0)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                        else if (c == ';')
                                        {
                                            break;
                                        }
                                        else if (c == '\r' || c == '\n')
                                        {
                                            if (sbChars.Length > 0)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                        else if (c == '\'' || c == '\"')
                                        {
                                            continue;
                                        }
                                        if (c >= 'A' && c <= 'Z')
                                        {
                                            sbChars.Append(FasterToLower(c));
                                        }
                                        else
                                        {
                                            sbChars.Append(c);
                                        }
                                    }
                                    return sbChars.ToString();
                                }
                            }


                            break;
                        case 47:
                            {
                                if (i < bts.Length - 1)
                                {
                                    char cAfter = '\0';
                                    if (bts[i + 1] == 47) // /
                                    {
                                        cAfter = '\r';
                                    }
                                    else if (bts[i + 1] == 42)
                                    {
                                        cAfter = '*';

                                    }
                                    if (cAfter != '\0')
                                    {
                                        for (int z = i + 2; z < btsLen; z++)
                                        {
                                            switch ((char)bts[z])
                                            {
                                                case '/':
                                                    if (cAfter == '*')
                                                    {
                                                        if (bts[z - 1] == cAfter)
                                                        {
                                                            i = z;
                                                            goto NextChar;
                                                        }
                                                    }
                                                    break;
                                                case '\r':
                                                case '\n':
                                                    if (cAfter == '\r')
                                                    {
                                                        i = z;
                                                        goto NextChar;
                                                    }
                                                    break;

                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case 46: // '.'
                        case 35: // '#':
                        case 123: // '{'
                                  // normal css selector ___hasInner started
                                  // return ""
                            return "";
                    }
                NextChar:
                    if (i > 1024)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("GetCharsetFromCSSBytes", ex);
                }
            }
            return "";
        }
        public static string GetElementAttributeInString(CHtmlElement element, string _name)
        {
            if (element == null || _name.Length == 0)
                return "";
            if (element.___attributes.Count == 0)
                return "";
            CHtmlAttribute attr = null;

            if (element.___attributes.TryGetValue(_name, out attr) == true)
            {
                if (attr == null)
                    return "";
                else
                {

                    return commonHTML.GetStringValue(attr.value);
                }

            }
            return "";
        }
        public static bool GetElementAttributeInBoolean(CHtmlElement element, string _name)
        {
            if (element == null || _name.Length == 0)
                return false;
            if (element.___attributes.Count == 0)
                return false;
            CHtmlAttribute attr = null;
            if (element.___attributes.TryGetValue(_name, out attr) == true)
            {
                if (attr == null)
                    return false;
                else
                {
                    if (attr.value is bool)
                    {
                        return (System.Boolean)attr.value;
                    }
                    else
                    {
                        return commonData.convertObjectToBoolean(attr.value);
                    }
                }
            }
            return false;
        }


        public static bool IsImageContentType(string sContentType)
        {
            switch (sContentType)
            {
                case "image/gif":
                case "image/jpeg":
                case "image/jpg":
                case "image/png":
                case "image/bmp":
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsImageSVGContentType(string sContentType)
        {
            switch (sContentType)
            {
                case "image/svg":
                case "image/svg+xml":
                case "image/svgxml":
                case "image/svg xml":
                    return true;
                default:
                    return false;
            }
        }



        internal static object ___StringColorMapLockiingObject = new object();
        internal const int ___StringColorMapMaximumEntries = 240000; // 240000 entries =<> 32 Megabites 

        public static ColorSpec GetColorSpecFromHTMLColorExtend(string _ColorValue)
        {

            string _originalColorString = null;
            ColorSpec ___colorResult = new ColorSpec(0, 0, 0, 255);
            char[] _ColorValueArray;

            bool ___IsColorHeaderRBGPass = false;
            bool ___IsColorHeaderRBGAPass = false;
            bool ___IsColorHeaderHSLPass = false;
            bool ___IsColorHeaderHSLAPass = false;
            int _ColorValueArrayLen = 0;
            try
            {
                if (_ColorValue == null || _ColorValue.Length == 0)
                {

                    return ColorSpec.Transparent;
                }
                else
                {
                    _ColorValueArray = _ColorValue.ToCharArray();
                    _ColorValueArrayLen = _ColorValueArray.Length;
                    _originalColorString = _ColorValue;



                    if (_ColorValueArray[0] == '#')
                    {
                        goto SharpSection;
                    }


                }
                if (_ColorValueArrayLen > 5)
                {
                    if (_ColorValueArray[0] == 'r' || _ColorValueArray[0] == 'h')
                    {

                        if (_ColorValueArray[1] == 'g' || _ColorValueArray[1] == 's')
                        {
                            if (_ColorValueArray[2] == 'b')
                            {
                                if (_ColorValue[3] == '(')
                                {
                                    ___IsColorHeaderRBGPass = true;
                                    goto RGBSection;

                                }
                                else if (_ColorValueArray[4] == '(')
                                {
                                    ___IsColorHeaderRBGAPass = true;
                                    goto RGBSection;

                                }

                            }
                            else if (_ColorValueArray[2] == 'l')
                            {
                                if (_ColorValueArray[3] == '(')
                                {
                                    ___IsColorHeaderHSLPass = true;
                                    goto HSLSection;

                                }
                                else if (_ColorValueArray[4] == '(')
                                {
                                    ___IsColorHeaderHSLAPass = true;
                                    goto HSLSection;
                                }
                            }
                        }

                    }
                }
                int posWhiteSpaceOrNull = -1;
                if (_ColorValue.Length > 2)
                {
                    posWhiteSpaceOrNull = _ColorValue.IndexOfAny(CharSpaceCrLfTabZentakuSpaceYenSlash, 1);
                }
                if (posWhiteSpaceOrNull > -1)
                {
                    // Note rgb() or rbga() or hsl() can contains space but it should have blocked in this section.
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                        commonLog.LogEntry("GetColorFromHTML ___hasInner space or null in value {0} at {1}", _ColorValue, posWhiteSpaceOrNull);
                    }
                    _ColorValue = _ColorValue.Substring(0, posWhiteSpaceOrNull);


                }
                goto KnownColorSection;
                /*
                switch (_ColorValue)
                {
                    case null:
                    case "":
                        return Color.Transparent;
                    case "initial":
                    case "INITAL":
                    case "inital":
                    case "none":
                    case "None":
                    case "NONE":
                    case "no":
                    case "NO":
                        return Color.Transparent;
                    case "inherit":
                        return Color.Transparent;
                    default:
                        // HSL and RGB and RBA Section should ___hasInner been jumped 
                        goto KnownColorSection;
                }
                */
            SharpSection:
                if (_ColorValueArray[0] == '#')
                {
                    if (_ColorValueArrayLen == 1)
                    {
                        // '#' only
                        return new ColorSpec(0, 0, 0, 255);
                    }

                    if (_ColorValueArrayLen > 3 && IsCharWhiteSpaceLimited(_ColorValueArray[1]) == true)
                    {
                        // it may be '# ffff' // whitepaced irregular css value, but handle now.
                        for (int wpos = 2; wpos < _ColorValueArrayLen; wpos++)
                        {
                            if (char.IsLetterOrDigit(_ColorValue[wpos]) == true)
                            {
                                _ColorValue = string.Concat('#', _ColorValue.Substring(wpos));
                                _ColorValueArrayLen = _ColorValue.Length;
                                break;
                            }
                        }
                    }
                    if (_ColorValueArrayLen > 12)
                    {
                        // some ___hasInner "#333333 ! important" buggy description fix it 
                        int ___importantIndex = _ColorValue.LastIndexOf("important", StringComparison.Ordinal);
                        if (___importantIndex > -1)
                        {
                            _ColorValue = _ColorValue.Substring(0, ___importantIndex);
                            while (IsCharWhiteSpaceLimited(_ColorValue[_ColorValue.Length - 1]) == true)
                            {
                                _ColorValue = _ColorValue.Substring(0, _ColorValue.Length - 1);
                            }
                            if (_ColorValue[_ColorValue.Length - 1] == '!')
                            {
                                _ColorValue = _ColorValue.Substring(0, _ColorValue.Length - 1);
                            }
                            if (_ColorValue[_ColorValue.Length - 1] == '!')
                            {
                                _ColorValue = _ColorValue.Substring(0, _ColorValue.Length - 1);
                            }

                        }
                    }


                    Color hexColor = getColorFromHexHtmlFaster(_ColorValueArray);
                    return new ColorSpec(hexColor.R, hexColor.G, hexColor.B);
                }

            HSLSection:
                float __hsv_h; float __hsv_s; float __hsv_v;
                int _r; int _g; int _b;
                if (___IsColorHeaderHSLPass == true || ___IsColorHeaderHSLAPass == true)
                {

                    string __hslintext = GetQuotedInnerString(_ColorValue, '(', ')');
                    System.Text.StringBuilder sbHSL = new StringBuilder(10);
                    int hslpos = 0;
                    int hslColorPos = 0;

                    char[] _hslintextArray = __hslintext.ToCharArray();
                    int _hslintextArrayLen = _hslintextArray.Length;
                    float ___hsla_alpha = -1;
                    float _hue = 0;
                    float _satu = 0;
                    float _lumina = 0;
                    for (int i = 0; i < _hslintextArrayLen; i++)
                    {
                        char hslc = _hslintextArray[i];
                        hslpos++;
                        if (char.IsNumber(hslc) || hslc == '%' || hslc == '.')
                        {
                            sbHSL.Append(hslc);
                        }

                        if (hslc == ',' || hslpos == __hslintext.Length)
                        {
                            switch (hslColorPos)
                            {
                                case 0:
                                    _hue = (float)GetDoubleValueFromString(sbHSL.ToString(), 360, -1);
                                    hslColorPos = 1;
                                    break;
                                case 1:
                                    _satu = (float)GetDoubleValueFromString(sbHSL.ToString(), 1.0F, -1);
                                    hslColorPos = 2;
                                    break;
                                case 2:
                                    _lumina = (float)GetDoubleValueFromString(sbHSL.ToString(), 1.0F, -1);
                                    hslColorPos = 3;
                                    break;
                                case 3:
                                    ___hsla_alpha = (float)GetDoubleValueFromString(sbHSL.ToString(), 1.0F, 1);
                                    hslColorPos = 4;
                                    goto AlphaObtained;
                                default:
                                    _lumina = (float)GetDoubleValueFromString(sbHSL.ToString(), 1.0F, -1);
                                    break;

                            }

                            sbHSL = new StringBuilder(10);
                        }

                    }
                AlphaObtained:
                    if (___hsla_alpha == -1)
                    {

                        convert_hsl_2_hsv(_hue, _satu, _lumina, out __hsv_h, out __hsv_s, out __hsv_v);
                        // TODO : HSLColor.HsvToRgb(__hsv_h, __hsv_s, __hsv_v, out _r, out _g, out _b);

                        // TODO : ___colorResult = Color.FromArgb(_r, _g, _b);



                        //___storeColorIntoColorList(_ColorValue, ___colorResult);
                        return ___colorResult;

                    }
                    else
                    {
                        if (___hsla_alpha < 0)
                        {

                            convert_hsl_2_hsv(_hue, _satu, _lumina, out __hsv_h, out __hsv_s, out __hsv_v);
                            // TODO : HSLColor.HsvToRgb(__hsv_h, __hsv_s, __hsv_v, out _r, out _g, out _b);

                            return ___colorResult;
                        }
                        if (___hsla_alpha > 1)
                        {
                            ___hsla_alpha = 1F;
                        }

                        convert_hsl_2_hsv(_hue, _satu, _lumina, out __hsv_h, out __hsv_s, out __hsv_v);
                        // TODO: HSLColor.HsvToRgb(__hsv_h, __hsv_s, __hsv_v, out _r, out _g, out _b);
                        // TODO : ___colorResult = Color.FromArgb((int)(255.0F * ___hsla_alpha), _r, _g, _b);
                        //  ___storeColorIntoColorList(_originalColorString, ___colorResult);
                        return ___colorResult;
                    }

                }
            RGBSection:
                if (___IsColorHeaderRBGPass == true || ___IsColorHeaderRBGAPass == true)
                {

                    int rgbQuoteStartPos = -1;
                    int rgbQuoteEndPos = -1;
                    if (_ColorValue[3] == '(')
                    {
                        rgbQuoteStartPos = 3;
                    }
                    else if (_ColorValue[4] == '(')
                    {
                        rgbQuoteStartPos = 4;
                    }
                    if (_ColorValue[_ColorValue.Length - 1] == ')')
                    {
                        rgbQuoteEndPos = _ColorValue.Length - 1;
                    }
                    else
                    {
                        rgbQuoteEndPos = _ColorValue.IndexOf(')');
                    }
                    if (rgbQuoteStartPos != -1 || rgbQuoteEndPos != -1)
                    {
                        if (rgbQuoteEndPos != -1)
                        {
                            _ColorValue = _ColorValue.Substring(rgbQuoteStartPos + 1, rgbQuoteEndPos - rgbQuoteStartPos - 1);
                        }
                        else
                        {
                            _ColorValue = _ColorValue.Substring(rgbQuoteStartPos + 1);
                        }
                    }


                    string[] rgbSP = _ColorValue.Split(',');
                    string stringSPFirst = rgbSP[0];
                    if (string.IsNullOrEmpty(stringSPFirst) == false && (IsCharWhiteSpaceLimited(stringSPFirst[0]) || IsCharWhiteSpaceLimited(stringSPFirst[stringSPFirst.Length - 1])))
                    {
                        stringSPFirst = stringSPFirst.Trim();
                    }
                    if (stringSPFirst[stringSPFirst.Length - 1] != '%')
                    {
                        int iR;
                        int iG;
                        int iB;
                        if (int.TryParse(rgbSP[0], out iR) == true)
                        {
                            if (iR > 255)
                            {
                                iR = 255;
                            }
                            if (iR < 0)
                            {
                                iR = 0;
                            }
                        }

                        if (int.TryParse(rgbSP[1], out iG) == true)
                        {
                            if (iG > 255)
                            {
                                iG = 255;
                            }
                            if (iG < 0)
                            {
                                iG = 0;
                            }
                        }
                        if (int.TryParse(rgbSP[2], out iB) == true)
                        {
                            if (iB > 255)
                            {
                                iB = 255;
                            }
                            if (iB < 0)
                            {
                                iB = 0;
                            }
                        }
                        int iA = -1;
                        if (rgbSP.Length > 3)
                        {
                            try
                            {
                                double alphaValue;
                                if (double.TryParse(rgbSP[3], out alphaValue))
                                {
                                    if (alphaValue > 1)
                                    {
                                        iA = (int)alphaValue;
                                    }
                                    else if (alphaValue >= 0 && alphaValue < 1)
                                    {
                                        iA = (int)(255.0F * alphaValue);
                                    }
                                }

                                if (iA > 255)
                                {
                                    iA = 255;
                                }
                            }
                            catch (Exception ex1)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                {
                                    commonLog.LogEntry("{0} ___hasInner error {1}", ex1.Message, commonData.GetExceptionAsString(ex1));
                                }
                            }
                        }
                        if (iA != -1)
                        {
                            ___colorResult = new ColorSpec((byte)iR, (byte)iG, (byte)iB, (byte)iA);
                            //   ___storeColorIntoColorList(_originalColorString, ___colorResult);
                            return ___colorResult;
                        }
                        else
                        {
                            ___colorResult = new ColorSpec((byte)iR, (byte)iG, (byte)iB);
                            // ___storeColorIntoColorList(_originalColorString, ___colorResult);
                            return ___colorResult;
                        }
                    }
                    else
                    {

                        double dR;
                        string strR = rgbSP[0].Replace("%", "");
                        double.TryParse(strR, out dR);
                        string strG = rgbSP[1].Replace("%", "");
                        double dG;

                        double.TryParse(strG, out dG);
                        double dB;
                        string strB = rgbSP[2].Replace("%", "");
                        double.TryParse(strB, out dB);

                        double dA = 255;
                        if (rgbSP.Length > 2)
                        {
                            string strA = rgbSP[3].Replace("%", "");
                            double.TryParse(strA, out dA);
                        }


                        // ___colorResult = System.Drawing.Color.FromArgb((int)(dA * 255), (int)(dR * 255), (int)(dG * 255), (int)(dB * 255));
                        ___colorResult = new ColorSpec((byte)(dR * 255), (byte)(dG * 255), (byte)(dB * 255), (byte)(dA * 255));
                        // ___storeColorIntoColorList(_originalColorString, ___colorResult);
                        return ___colorResult;
                    }
                }
            KnownColorSection:

                if (CHtmlHTMLColorSpecNamesDictionary.TryGetValue(_ColorValue, out ___colorResult) == true)
                {
                    // ___storeColorIntoColorList(_ColorValue, ___colorResult);
                    return ___colorResult;
                }
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("ColorTranslator.FromHTML({0})", _ColorValue);
                }
                /*
                using Color = System.Drawing.Color;
                ___colorResult = System.Drawing.ColorTranslator.FromHtml(_ColorValue);
                */
                return ___colorResult;
            }
            catch
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("Invalid Color String \"{0}\"", _ColorValue);
                }
                return new ColorSpec(0, 0, 0, 255);
            }
        }

        public static Color GetColorFromHTMLColorExtend(string _ColorValue)
        {
            if (string.IsNullOrEmpty(_ColorValue))
            {
                return Color.Transparent;
            }
            //string _ColorValueLow ="";
            string _originalColorString = null;
            System.Drawing.Color ___colorResult = Color.Empty;
            char[] _ColorValueArray;

            bool ___IsColorHeaderRBGPass = false;
            bool ___IsColorHeaderRBGAPass = false;
            bool ___IsColorHeaderHSLPass = false;
            bool ___IsColorHeaderHSLAPass = false;
            int _ColorValueArrayLen = 0;
            try
            {
                if (_ColorValue == null || _ColorValue.Length == 0)
                {

                    return Color.Transparent;
                }
                else
                {
                    _ColorValueArray = _ColorValue.ToCharArray();
                    _ColorValueArrayLen = _ColorValueArray.Length;
                    _originalColorString = _ColorValue;



                    if (_ColorValueArray[0] == '#')
                    {
                        goto SharpSection;
                    }
                    /*
                    if (commonGraphics.CHtmlHTMLColorNamesDictionary.TryGetValue(_ColorValue, out ___colorResult) == true)
                    {
                        return ___colorResult;
                    }
                    */
                    /*
                    if (___StringColorMap.TryGetValue(_originalColorString, out ___colorResult) == true)
                    {
                        return ___colorResult;
                    }
                    */


                    //_ColorValueLow = commonFasterTrimAndToLower(_ColorValue);

                }
                if (_ColorValueArrayLen > 5)
                {
                    if (_ColorValueArray[0] == 'r' || _ColorValueArray[0] == 'h')
                    {

                        if (_ColorValueArray[1] == 'g' || _ColorValueArray[1] == 's')
                        {
                            if (_ColorValueArray[2] == 'b')
                            {
                                if (_ColorValue[3] == '(')
                                {
                                    ___IsColorHeaderRBGPass = true;
                                    goto RGBSection;

                                }
                                else if (_ColorValueArray[4] == '(')
                                {
                                    ___IsColorHeaderRBGAPass = true;
                                    goto RGBSection;

                                }

                            }
                            else if (_ColorValueArray[2] == 'l')
                            {
                                if (_ColorValueArray[3] == '(')
                                {
                                    ___IsColorHeaderHSLPass = true;
                                    goto HSLSection;

                                }
                                else if (_ColorValueArray[4] == '(')
                                {
                                    ___IsColorHeaderHSLAPass = true;
                                    goto HSLSection;
                                }
                            }
                        }

                    }
                }
                int posWhiteSpaceOrNull = -1;
                if (_ColorValue.Length > 2)
                {
                    posWhiteSpaceOrNull = _ColorValue.IndexOfAny(CharSpaceCrLfTabZentakuSpaceYenSlash, 1);
                }
                if (posWhiteSpaceOrNull > -1)
                {
                    // Note rgb() or rbga() or hsl() can contains space but it should have blocked in this section.
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                        commonLog.LogEntry("GetColorFromHTML ___hasInner space or null in value {0} at {1}", _ColorValue, posWhiteSpaceOrNull);
                    }
                    _ColorValue = _ColorValue.Substring(0, posWhiteSpaceOrNull);


                }
                goto KnownColorSection;
                /*
                switch (_ColorValue)
                {
                    case null:
                    case "":
                        return Color.Transparent;
                    case "initial":
                    case "INITAL":
                    case "inital":
                    case "none":
                    case "None":
                    case "NONE":
                    case "no":
                    case "NO":
                        return Color.Transparent;
                    case "inherit":
                        return Color.Transparent;
                    default:
                        // HSL and RGB and RBA Section should ___hasInner been jumped 
                        goto KnownColorSection;
                }
                */
            SharpSection:
                if (_ColorValueArray[0] == '#')
                {
                    if (_ColorValueArrayLen == 1)
                    {
                        // '#' only
                        return Color.Transparent;
                    }

                    if (_ColorValueArrayLen > 3 && IsCharWhiteSpaceLimited(_ColorValueArray[1]) == true)
                    {
                        // it may be '# ffff' // whitepaced irregular css value, but handle now.
                        for (int wpos = 2; wpos < _ColorValueArrayLen; wpos++)
                        {
                            if (char.IsLetterOrDigit(_ColorValue[wpos]) == true)
                            {
                                _ColorValue = string.Concat('#', _ColorValue.Substring(wpos));
                                _ColorValueArrayLen = _ColorValue.Length;
                                break;
                            }
                        }
                    }
                    if (_ColorValueArrayLen > 12)
                    {
                        // some ___hasInner "#333333 ! important" buggy description fix it 
                        int ___importantIndex = _ColorValue.LastIndexOf("important", StringComparison.Ordinal);
                        if (___importantIndex > -1)
                        {
                            _ColorValue = _ColorValue.Substring(0, ___importantIndex);
                            while (IsCharWhiteSpaceLimited(_ColorValue[_ColorValue.Length - 1]) == true)
                            {
                                _ColorValue = _ColorValue.Substring(0, _ColorValue.Length - 1);
                            }
                            if (_ColorValue[_ColorValue.Length - 1] == '!')
                            {
                                _ColorValue = _ColorValue.Substring(0, _ColorValue.Length - 1);
                            }
                            if (_ColorValue[_ColorValue.Length - 1] == '!')
                            {
                                _ColorValue = _ColorValue.Substring(0, _ColorValue.Length - 1);
                            }

                        }
                    }


                    return getColorFromHexHtmlFaster(_ColorValueArray);
                }

            HSLSection:

                float __hsv_h; float __hsv_s; float __hsv_v;
                int _r; int _g; int _b;
                if (___IsColorHeaderHSLPass == true || ___IsColorHeaderHSLAPass == true)
                {

                    string __hslintext = GetQuotedInnerString(_ColorValue, '(', ')');
                    System.Text.StringBuilder sbHSL = new StringBuilder(10);
                    int hslpos = 0;
                    int hslColorPos = 0;

                    char[] _hslintextArray = __hslintext.ToCharArray();
                    int _hslintextArrayLen = _hslintextArray.Length;
                    float ___hsla_alpha = -1;
                    float _hue = 0;
                    float _satu = 0;
                    float _lumina = 0;
                    for (int i = 0; i < _hslintextArrayLen; i++)
                    {
                        char hslc = _hslintextArray[i];
                        hslpos++;
                        if (char.IsNumber(hslc) || hslc == '%' || hslc == '.')
                        {
                            sbHSL.Append(hslc);
                        }

                        if (hslc == ',' || hslpos == __hslintext.Length)
                        {
                            switch (hslColorPos)
                            {
                                case 0:
                                    _hue = (float)GetDoubleValueFromString(sbHSL.ToString(), 360, -1);
                                    hslColorPos = 1;
                                    break;
                                case 1:
                                    _satu = (float)GetDoubleValueFromString(sbHSL.ToString(), 1.0F, -1);
                                    hslColorPos = 2;
                                    break;
                                case 2:
                                    _lumina = (float)GetDoubleValueFromString(sbHSL.ToString(), 1.0F, -1);
                                    hslColorPos = 3;
                                    break;
                                case 3:
                                    ___hsla_alpha = (float)GetDoubleValueFromString(sbHSL.ToString(), 1.0F, 1);
                                    hslColorPos = 4;
                                    goto AlphaObtained;
                                default:
                                    _lumina = (float)GetDoubleValueFromString(sbHSL.ToString(), 1.0F, -1);
                                    break;

                            }

                            sbHSL = new StringBuilder(10);
                        }

                    }
                AlphaObtained:
                    if (___hsla_alpha == -1)
                    {

                        convert_hsl_2_hsv(_hue, _satu, _lumina, out __hsv_h, out __hsv_s, out __hsv_v);
                        if (___hsla_alpha >= 0 && ___hsla_alpha <= 1)
                        {

                            HslToRgb(_hue, _satu, _lumina, out int r, out int g, out int b);
                            return Color.FromArgb((int)(255.0F * ___hsla_alpha), r, g, b);
                        }
                        else
                        {

                            HslToRgb(_hue, _satu, _lumina, out int r, out int g, out int b);
                            return Color.FromArgb(255, r, g, b);
                        }




                        //___storeColorIntoColorList(_ColorValue, ___colorResult);
                        return ___colorResult;

                    }
                    else
                    {
                        if (___hsla_alpha < 0)
                        {

                            convert_hsl_2_hsv(_hue, _satu, _lumina, out __hsv_h, out __hsv_s, out __hsv_v);
                            if (___hsla_alpha >= 0 && ___hsla_alpha <= 1)
                            {

                                HslToRgb(_hue, _satu, _lumina, out int r, out int g, out int b);
                                return Color.FromArgb((int)(255.0F * ___hsla_alpha), r, g, b);
                            }

                            return ___colorResult;
                        }
                        if (___hsla_alpha > 1)
                        {
                            ___hsla_alpha = 1F;
                        }

                        convert_hsl_2_hsv(_hue, _satu, _lumina, out __hsv_h, out __hsv_s, out __hsv_v);
                        if (___hsla_alpha >= 0 && ___hsla_alpha <= 1)
                        {

                            HslToRgb(_hue, _satu, _lumina, out int r, out int g, out int b);
                            return Color.FromArgb((int)(255.0F * ___hsla_alpha), r, g, b);
                        }
                        if (___hsla_alpha >= 0 && ___hsla_alpha <= 1)
                        {
                            return Color.FromArgb((int)(255.0F * ___hsla_alpha), (int)__hsv_h, (int)__hsv_s, (int)__hsv_v);
                        }

                        return ___colorResult;
                    }

                }
            RGBSection:
                if (___IsColorHeaderRBGPass == true || ___IsColorHeaderRBGAPass == true)
                {

                    int rgbQuoteStartPos = -1;
                    int rgbQuoteEndPos = -1;
                    if (_ColorValue[3] == '(')
                    {
                        rgbQuoteStartPos = 3;
                    }
                    else if (_ColorValue[4] == '(')
                    {
                        rgbQuoteStartPos = 4;
                    }
                    if (_ColorValue[_ColorValue.Length - 1] == ')')
                    {
                        rgbQuoteEndPos = _ColorValue.Length - 1;
                    }
                    else
                    {
                        rgbQuoteEndPos = _ColorValue.IndexOf(')');
                    }
                    if (rgbQuoteStartPos != -1 || rgbQuoteEndPos != -1)
                    {
                        if (rgbQuoteEndPos != -1)
                        {
                            _ColorValue = _ColorValue.Substring(rgbQuoteStartPos + 1, rgbQuoteEndPos - rgbQuoteStartPos - 1);
                        }
                        else
                        {
                            _ColorValue = _ColorValue.Substring(rgbQuoteStartPos + 1);
                        }
                    }


                    string[] rgbSP = _ColorValue.Split(',');
                    string stringSPFirst = rgbSP[0];
                    if (string.IsNullOrEmpty(stringSPFirst) == false && (IsCharWhiteSpaceLimited(stringSPFirst[0]) || IsCharWhiteSpaceLimited(stringSPFirst[stringSPFirst.Length - 1])))
                    {
                        stringSPFirst = stringSPFirst.Trim();
                    }
                    if (stringSPFirst[stringSPFirst.Length - 1] != '%')
                    {
                        int iR;
                        int iG;
                        int iB;
                        if (int.TryParse(rgbSP[0], out iR) == true)
                        {
                            if (iR > 255)
                            {
                                iR = 255;
                            }
                            if (iR < 0)
                            {
                                iR = 0;
                            }
                        }

                        if (int.TryParse(rgbSP[1], out iG) == true)
                        {
                            if (iG > 255)
                            {
                                iG = 255;
                            }
                            if (iG < 0)
                            {
                                iG = 0;
                            }
                        }
                        if (int.TryParse(rgbSP[2], out iB) == true)
                        {
                            if (iB > 255)
                            {
                                iB = 255;
                            }
                            if (iB < 0)
                            {
                                iB = 0;
                            }
                        }
                        int iA = -1;
                        if (rgbSP.Length > 3)
                        {
                            try
                            {
                                double alphaValue;
                                if (double.TryParse(rgbSP[3], out alphaValue))
                                {
                                    if (alphaValue > 1)
                                    {
                                        iA = (int)alphaValue;
                                    }
                                    else if (alphaValue >= 0 && alphaValue < 1)
                                    {
                                        iA = (int)(255.0F * alphaValue);
                                    }
                                }

                                if (iA > 255)
                                {
                                    iA = 255;
                                }
                            }
                            catch (Exception ex1)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                {
                                    commonLog.LogEntry("{0} ___hasInner error {1}", ex1.Message, commonData.GetExceptionAsString(ex1));
                                }
                            }
                        }
                        if (iA != -1)
                        {
                            ___colorResult = System.Drawing.Color.FromArgb(iA, iR, iG, iB);
                            //   ___storeColorIntoColorList(_originalColorString, ___colorResult);
                            return ___colorResult;
                        }
                        else
                        {
                            ___colorResult = System.Drawing.Color.FromArgb(iR, iG, iB);
                            // ___storeColorIntoColorList(_originalColorString, ___colorResult);
                            return ___colorResult;
                        }
                    }
                    else
                    {

                        double dR;
                        string strR = rgbSP[0].Replace("%", "");
                        double.TryParse(strR, out dR);
                        string strG = rgbSP[1].Replace("%", "");
                        double dG;

                        double.TryParse(strG, out dG);
                        double dB;
                        string strB = rgbSP[2].Replace("%", "");
                        double.TryParse(strB, out dB);

                        double dA = 255;
                        if (rgbSP.Length > 2)
                        {
                            string strA = rgbSP[3].Replace("%", "");
                            double.TryParse(strA, out dA);
                        }


                        ___colorResult = System.Drawing.Color.FromArgb((int)(dA * 255), (int)(dR * 255), (int)(dG * 255), (int)(dB * 255));
                        // ___storeColorIntoColorList(_originalColorString, ___colorResult);
                        return ___colorResult;
                    }
                }
            KnownColorSection:

                if (CHtmlHTMLColorNamesDictionary.TryGetValue(_ColorValue, out ___colorResult) == true)
                {
                    // ___storeColorIntoColorList(_ColorValue, ___colorResult);
                    return ___colorResult;
                }
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("ColorTranslator.FromHTML({0})", _ColorValue);
                }
                /*
                using Color = System.Drawing.Color;
                ___colorResult = System.Drawing.ColorTranslator.FromHtml(_ColorValue);
                */
                return ___colorResult;
            }
            catch
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("Invalid Color String \"{0}\"", _ColorValue);
                }
                return Color.Transparent;
            }
        }

        public static string GetFontSizeInPixelFromHTMLSize(string __sizeValue)
        {
            /*
# f0{font-size:10px;}
# f1{font-size:11px;}
# f2{font-size:12px;}
# f3{font-size:13px;}	
# f4{font-size:16px;}
# f5{font-size:24px;}
# f6{font-size:28px;}
# f7{font-size:40px;}
# f8{font-size:44px;}
# f9{font-size:45px;}
# f10{font-size:50px;}
# f11{font-size:21px;}
# f12{font-size:22px;}
			*/
            switch (__sizeValue)
            {
                case "0":
                case "０":
                    return "10px";
                case "1":
                case "１":
                    return "11px";
                case "2":
                case "２":
                    return "12px";
                case "3":
                case "３":
                    return "13px";
                case "4":
                case "４":
                    return "16px";
                case "5":
                case "５":
                    return "24px";
                case "6":
                case "６":
                    return "28px";
                case "7":
                case "７":
                    return "40px";
                case "8":
                case "８":
                    return "44px";
                case "9":
                case "９":
                    return "45px";
                case "10":
                case "１０":
                    return "50px";
                default:
                    return "13px";
            }
        }

        public static System.Drawing.Color getColorFromHexHtmlFaster(char[] cs)
        {

            int cslen = cs.Length;
            if (cs[0] == '#')
            {
                switch (cslen)
                {
                    case 4:
                        // Note) ARGB is A = 255 is zero transparent
                        return System.Drawing.Color.FromArgb(255, convertHexcharsToInt32(cs[1], cs[1]), convertHexcharsToInt32(cs[2], cs[2]), convertHexcharsToInt32(cs[3], cs[3]));
                    case 7:
                        /*
                        //ColorTranslator.fromHTML() #FF6347 took 175 ms

                        return System.Drawing.Color.FromArgb(255, Convert.ToInt32(str.Substring(1, 2), 0x10), Convert.ToInt32(str.Substring(3, 2), 0x10), Convert.ToInt32(str.Substring(5, 2), 0x10));
                        */
                        return System.Drawing.Color.FromArgb(255, convertHexcharsToInt32(cs[1], cs[2]), convertHexcharsToInt32(cs[3], cs[4]), convertHexcharsToInt32(cs[5], cs[6]));

                    default:
                        return System.Drawing.Color.Transparent;
                }

            }
            else
            {
                return Color.Transparent;
            }
        }
        internal static int convertHexcharsToInt32(char c1, char c2)
        {

            return (getHexCharToInt(c1) * 16) + getHexCharToInt(c2);
        }

        internal static int getHexCharToInt(char c)
        {

            switch (c)
            {
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'A':
                case 'a':
                    return 0xa;
                case 'B':
                case 'b':
                    return 0xb;
                case 'C':
                case 'c':
                    return 0xc;
                case 'D':
                case 'd':
                    return 0xd;
                case 'E':
                case 'e':
                    return 0xe;
                case 'F':
                case 'f':
                    return 0xf;
                case '0':
                default:
                    return 0;
            }

        }

        public static void convert_hsl_2_hsv(float h, float s, float l, out float h2, out float s2, out float v2)
        {
            /*
            h2 = h;
            s2 = s;
            v2 = l;
            var t = s * (l < 0.5 ? l : 1 - l);
            v2 = l + t;
            s2 = l > 0 ? 2 * t / v2 : s;
            */



            h2 = h;
            var min_val = l < 0.5f ? l : 1f - l;
            var t = s * min_val;
            v2 = l + t;
            s2 = (v2 > 0f) ? (2f * t / v2) : 0f;


            /*
            h2 = h; // 色相は変わらない

            // HSL から HSV への変換式
            v2 = l + s * Math.Min(l, 1 - l);
            s2 = v2 == 0 ? 0 : 2 * (1 - l / v2);
            */
        }
        private static int Clamp255(int v)
        {
            if (v < 0) return 0;
            if (v > 255) return 255;
            return v;
        }

        public static void HslToRgb(float h, float s, float l, out int r, out int g, out int b)
        {

            float c = (1f - Math.Abs(2f * l - 1f)) * s;
            float hh = (h % 360f) / 60f;
            if (hh < 0) hh += 6f;
            float x = c * (1f - Math.Abs(hh % 2f - 1f));
            float r1 = 0f, g1 = 0f, b1 = 0f;

            if (0f <= hh && hh < 1f) { r1 = c; g1 = x; b1 = 0f; }
            else if (1f <= hh && hh < 2f) { r1 = x; g1 = c; b1 = 0f; }
            else if (2f <= hh && hh < 3f) { r1 = 0f; g1 = c; b1 = x; }
            else if (3f <= hh && hh < 4f) { r1 = 0f; g1 = x; b1 = c; }
            else if (4f <= hh && hh < 5f) { r1 = x; g1 = 0f; b1 = c; }
            else /*5..6*/ { r1 = c; g1 = 0f; b1 = x; }

            float m = l - c / 2f;
            r = Clamp255((int)Math.Round((r1 + m) * 255f));
            g = Clamp255((int)Math.Round((g1 + m) * 255f));
            b = Clamp255((int)Math.Round((b1 + m) * 255f));
        }


        internal static void CreateFundermentalHTMLElementsIntoDocument(CHtmlDocument _doc)
        {
            if (_doc != null)
            {
                CHtmlElement elemTop = new CHtmlElement();
                elemTop.tagName = "HTML";
                _doc.___addToCurrentParentElement(elemTop);
                CHtmlElement elemHead = new CHtmlElement();
                elemHead.tagName = "HEAD";
                _doc.___addToCurrentParentElement(elemHead);
                _doc.___IsHtmlBodyTagPassed = true;
                elemHead.___isApplyElemenetStyleSheetCalled = true;
                elemHead.___isCalculateElementBoundsCalled = true;
                elemHead.___ClosedReson = CHtmlTagClosedReasonType.Direct;
                CHtmlElement elemBody = new CHtmlElement();
                elemBody.tagName = "BODY";
                _doc.___addToCurrentParentElement(elemBody);
                elemBody.___isApplyElemenetStyleSheetCalled = true;
                elemBody.___isCalculateElementBoundsCalled = true;
                elemBody.___ClosedReson = CHtmlTagClosedReasonType.Direct;
                elemTop.___isApplyElemenetStyleSheetCalled = true;
                elemTop.___isCalculateElementBoundsCalled = true;
                elemTop.___ClosedReson = CHtmlTagClosedReasonType.Direct;
            }
            _doc.___IsHtmlParseCompleted = true;
            _doc.___IsHtmlResponseCompleted = true;
        }
        /// <summary>
        /// Convert TagName (UpperCase) into CHtmlElementType 
        /// </summary>
        /// <param name="_NameUpper">Upper Trimed String</param>
        /// <returns>CHtmlElementType</returns>
        public static CHtmlElementType GetTagNameType(string _NameUpper)
        {
            switch (_NameUpper)
            {
                case "!DOCTYPE":
                case "DOCTYPE":
                    return CHtmlElementType.DOCTYPE;
                case "HTML":
                    return CHtmlElementType.HTML;
                case "#DOCUMENT-FRAGMENT":
                    return CHtmlElementType._DOCUMENT_FRAGMENT;
                case "#AFTER":
                    return CHtmlElementType._ELEMENT_AFTER;
                case "#BEFORE":
                    return CHtmlElementType._ELEMENT_BEFORE;
                case "#PROTOTYPE":
                    return CHtmlElementType._ELEMENT_PROTOTYPE;
                case "SYSTEM-REGION":
                    return CHtmlElementType.SYSTEM_REGION;
                case "HEAD":
                    return CHtmlElementType.HEAD;
                case "META":
                    return CHtmlElementType.META;
                case "LINK":
                    return CHtmlElementType.LINK;
                case "SCRIPT":
                    return CHtmlElementType.SCRIPT;
                case "TEMPLATE":
                    return CHtmlElementType.TEMPLATE;
                case "STYLE":
                    return CHtmlElementType.STYLE;
                case "BODY":
                    return CHtmlElementType.BODY;
                case "DIV":
                    return CHtmlElementType.DIV;
                case "SPAN":
                    return CHtmlElementType.SPAN;
                case "H1":
                    return CHtmlElementType.H1;
                case "H2":
                    return CHtmlElementType.H2;
                case "H3":
                    return CHtmlElementType.H3;
                case "H4":
                    return CHtmlElementType.H4;
                case "H5":
                    return CHtmlElementType.H5;
                case "H6":
                    return CHtmlElementType.H6;
                case "H7":
                    return CHtmlElementType.H7;
                case "I":
                    return CHtmlElementType.I;
                case "P":
                    return CHtmlElementType.P;
                case "A":
                    return CHtmlElementType.A;
                case "S":
                    return CHtmlElementType.S;
                case "B":
                    return CHtmlElementType.B;
                case "U":
                    return CHtmlElementType.U;
                case "INPUT":
                    return CHtmlElementType.INPUT;
                case "FORM":
                    return CHtmlElementType.FORM;
                case "OBJECT":
                    return CHtmlElementType.OBJECT;
                case "EMBED":
                    return CHtmlElementType.EMBED;
                case "PRE":
                    return CHtmlElementType.PRE;
                case "XMP":
                    return CHtmlElementType.XMP;
                case "TT":
                    return CHtmlElementType.TT;
                case "TEXTAREA":
                    return CHtmlElementType.TEXTAREA;
                case "BUTTON":
                    return CHtmlElementType.BUTTON;
                case "SELECT":
                    return CHtmlElementType.SELECT;
                case "OPTION":
                    return CHtmlElementType.OPTION;
                case "LI":
                    return CHtmlElementType.LI;
                case "OL":
                    return CHtmlElementType.OL;
                case "DIR":
                    return CHtmlElementType.DIR;
                case "DT":
                    return CHtmlElementType.DT;
                case "DD":
                    return CHtmlElementType.DD;
                case "DL":
                    return CHtmlElementType.DL;
                case "FIELDSET":
                    return CHtmlElementType.FIELDSET;
                case "FONT":
                    return CHtmlElementType.FONT;
                case "HN":
                    return CHtmlElementType.HN;
                case "IFRAME":
                    return CHtmlElementType.IFRAME;
                case "IMG":
                    return CHtmlElementType.IMG;
                case "KBD":
                    return CHtmlElementType.KBD;
                case "MAP":
                    return CHtmlElementType.MAP;
                case "AREA":
                    return CHtmlElementType.AREA;
                case "BR":
                    return CHtmlElementType.BR;
                case "NOBR":
                    return CHtmlElementType.NOBR;
                case "WBR":
                    return CHtmlElementType.WBR;
                case "SAMP":
                    return CHtmlElementType.SAMP;
                case "TABLE":
                    return CHtmlElementType.TABLE;
                case "TBODY":
                    return CHtmlElementType.TBODY;
                case "THEAD":
                    return CHtmlElementType.THEAD;
                case "TFOOT":
                    return CHtmlElementType.TFOOT;
                case "TH":
                    return CHtmlElementType.TH;
                case "TR":
                    return CHtmlElementType.TR;
                case "TD":
                    return CHtmlElementType.TD;
                case "CAPTION":
                    return CHtmlElementType.CAPTION;
                case "BASE":
                    return CHtmlElementType.BASE;
                case "TITLE":
                    return CHtmlElementType.TITLE;
                case "CENTER":
                    return CHtmlElementType.CENTER;
                case "BLOCKQUOTE":
                    return CHtmlElementType.BLOCKQUOTE;
                case "PARAM":
                    return CHtmlElementType.PARAM;
                case "HR":
                    return CHtmlElementType.HR;
                case "CODE":
                    return CHtmlElementType.CODE;
                case "MARQUEE":
                    return CHtmlElementType.MARQUEE;
                case "BIG":
                    return CHtmlElementType.BIG;
                case "STRONG":
                    return CHtmlElementType.STRONG;
                case "SINAME":
                    return CHtmlElementType.SINAME;
                case "APPLET":
                    return CHtmlElementType.APPLET;
                case "NOSCRIPT":
                    return CHtmlElementType.NOSCRIPT;
                case "UL":
                    return CHtmlElementType.UL;
                case "SMALL":
                    return CHtmlElementType.SMALL;
                case "NOFRAME":
                    return CHtmlElementType.NOFRAME;
                case "NOFRAMES":
                    return CHtmlElementType.NOFRAMES;
                case "VAR":
                    return CHtmlElementType.VAR;
                case "COMMENT":
                    return CHtmlElementType.COMMENT;
                case "INS":
                    return CHtmlElementType.INS;
                case "EM":
                    return CHtmlElementType.EM;
                case "NOEMBED":
                    return CHtmlElementType.NOEMBED;
                case "LABEL":
                    return CHtmlElementType.LABEL;
                case "LEGEND":
                    return CHtmlElementType.LEGEND;
                case "SPACER":
                    return CHtmlElementType.SPACER;
                case "O:P":
                    return CHtmlElementType.O_P; // O:P // MS
                case "LAYER":
                    return CHtmlElementType.LAYER;
                case "ILAYER":
                    return CHtmlElementType.ILAYER;
                case "CITE":
                    return CHtmlElementType.CITE;
                case "ADDRESS":
                    return CHtmlElementType.ADDRESS;
                case "SUP":
                    return CHtmlElementType.SUP;
                case "SUB":
                    return CHtmlElementType.SUB;
                case "XML":
                    return CHtmlElementType.XML;
                case "XHTML":
                    return CHtmlElementType.XHTML;
                case "COL":
                    return CHtmlElementType.COL;
                case "ROW":
                    return CHtmlElementType.ROW;
                case "COLGROUP":
                    return CHtmlElementType.COLGROUP;
                case "DFN":
                    return CHtmlElementType.DFN;
                case "NOLAYER":
                    return CHtmlElementType.NOLAYER;
                case "SECTIONS":
                    return CHtmlElementType.SECTIONS;
                case "ABBR":
                    return CHtmlElementType.ABBR;
                case "MSHELP:ATTR":
                    return CHtmlElementType.MSHELP_ATTR;
                case "MSHELP:LINK":
                    return CHtmlElementType.MSHELP_LINK;
                case "MSHELP:KTABLE":
                    return CHtmlElementType.MSHELP_KTABLE;
                case "G:PLUSONE":
                    return CHtmlElementType.G_PLUSONE;
                case "G:PLUS":
                    return CHtmlElementType.G_PLUS;
                case "FB:COMMENTS":
                    return CHtmlElementType.FB_COMMENTS;
                case "FB:LIKE":
                    return CHtmlElementType.FB_LIKE;
                case "FB:LIKE-BOX":
                    return CHtmlElementType.FB_LIKE_BOX;
                case "FB:COMMENTS-COUNT":
                    return CHtmlElementType.FB_COMMENTS_COUNT;
                case "FB:RECOMMENDATIONS":
                    return CHtmlElementType.FB_RECOMMENDATIONS;
                case "LINKTEXT":
                    return CHtmlElementType.LINKTEXT;
                case "CONTENT":
                    return CHtmlElementType.CONTENT;
                // --------------------------------- SVG START----------------------------
                case "SVG":
                    return CHtmlElementType.SVG;
                case "CANVAS":
                    return CHtmlElementType.CANVAS;
                case "CIRCLE":
                    return CHtmlElementType.CIRCLE;
                case "DEFS":
                    return CHtmlElementType.DEFS;
                case "DESC":
                    return CHtmlElementType.DESC;
                case "ELLIPSE":
                    return CHtmlElementType.ELLIPSE;
                case "G":
                    return CHtmlElementType.G;
                case "IMAGE":
                    return CHtmlElementType.IMAGE;
                case "LINE":
                    return CHtmlElementType.LINE;
                case "LINEARGRADIENT":
                    return CHtmlElementType.LINEARGRADIENT;
                case "RADIALGRADIENT":
                    return CHtmlElementType.RADIALGRADIENT;
                case "METADATA":
                    return CHtmlElementType.METADATA;
                case "PATH":
                    return CHtmlElementType.PATH;
                case "POLYLINE":
                    return CHtmlElementType.POLYLINE;
                case "POLYGON":
                    return CHtmlElementType.POLYGON;
                case "RECT":
                    return CHtmlElementType.RECT;
                case "STOP":
                    return CHtmlElementType.STOP;
                case "SWITCH":
                    return CHtmlElementType.SWITCH;
                case "SYMBOL":
                    return CHtmlElementType.SYMBOL;
                case "TREF":
                    return CHtmlElementType.TREF;
                case "TSPAN":
                    return CHtmlElementType.TSPAN;
                case "USE":
                    return CHtmlElementType.USE;
                case "ANIMATE":
                    return CHtmlElementType.ANIMATE;
                case "CLIPPATH":
                    return CHtmlElementType.CLIPPATH;
                case "GLYPH":
                    return CHtmlElementType.GLYPH;
                case "TEXTPATH":
                    return CHtmlElementType.TEXTPATH;
                case "MISSING-GLYPH":
                    return CHtmlElementType.MISSING_GLYPH;
                case "FONT-FACE":
                    return CHtmlElementType.FONT_FACE;
                case "FILTER":
                    return CHtmlElementType.FILTER;
                case "PATTERN":
                    return CHtmlElementType.PATTERN;
                case "FEGAUSSIANBLUR":
                    return CHtmlElementType.FEGAUSSIANBLUR;
                case "FESPECULARLIGHTING":
                    return CHtmlElementType.FESPECULARLIGHTING;
                case "FEDISTANTLIGHT":
                    return CHtmlElementType.FEDISTANTLIGHT;
                case "FEBLEND":
                    return CHtmlElementType.FEBLEND;
                case "FECOMPOSITE":
                    return CHtmlElementType.FECOMPOSITE;
                case "MASK":
                    return CHtmlElementType.MASK;
                case "FEFUNCA":
                    return CHtmlElementType.FEFUNCA;
                case "FEFUNCG":
                    return CHtmlElementType.FEFUNCG;
                case "FEFUNCR":
                    return CHtmlElementType.FEFUNCR;
                case "FEFUNCB":
                    return CHtmlElementType.FEFUNCB;
                case "FECOLORMATRIX":
                    return CHtmlElementType.FECOLORMATRIX;
                case "FECOMPONENTTRANSFER":
                    return CHtmlElementType.FECOMPNENTTRANSFER;
                case "FETURBULENCE":
                    return CHtmlElementType.FETURBULENCE;
                case "ANIMATEMOTION":
                    return CHtmlElementType.ANIMATEMOTION;
                // --------------------------------- SVG END ----------------------------
                case "M":
                    return CHtmlElementType.M;
                case "ASIDE":
                    return CHtmlElementType.ASIDE;
                case "DEL":
                    return CHtmlElementType.DEL;
                case "OPTGROUP":
                    return CHtmlElementType.OPTGROUP;
                case "HEADER":
                    return CHtmlElementType.HEADER;
                case "FOOTER":
                    return CHtmlElementType.FOOTER;
                case "NAV":
                    return CHtmlElementType.NAV;
                case "SECTION":
                    return CHtmlElementType.SECTION;
                case "ARTICLE":
                    return CHtmlElementType.ARTICLE;
                case "TEXT": // THIS IS NORMAL TEXT TAG like SVG
                    return CHtmlElementType.TEXT;
                case "#TEXT": // THIS IS INNERTEXT TEXT
                    return CHtmlElementType._ITEXT;
                case "CUFON":
                    return CHtmlElementType.CUFON;
                case "CUFONTEXT":
                    return CHtmlElementType.CUFONTEXT;
                case "TIME":
                    return CHtmlElementType.TIME;
                case "BASEFONT":
                    return CHtmlElementType.BASEFONT;
                case "FRAME":
                    return CHtmlElementType.FRAME;
                case "FRAMESET":
                    return CHtmlElementType.FRAMESET;
                case "HGROUP":
                    return CHtmlElementType.HGROUP;
                case "MENU":
                    return CHtmlElementType.MENU;
                case "MENUITEM":
                    return CHtmlElementType.MENUITEM;
                case "STRIKE":
                    return CHtmlElementType.STRIKE;
                case "VIDEO":
                    return CHtmlElementType.VIDEO;
                case "AUDIO":
                    return CHtmlElementType.AUDIO;
                case "TRACK":
                    return CHtmlElementType.TRACK;
                case "SOURCE":
                    return CHtmlElementType.SOURCE;
                case "SUMMARY":
                    return CHtmlElementType.SUMMARY;
                case "PROGRESS":
                    return CHtmlElementType.PROGRESS;
                case "OUTPUT":
                    return CHtmlElementType.OUTPUT;
                case "METER":
                    return CHtmlElementType.METER;
                case "MARK":
                    return CHtmlElementType.MARK;
                case "FIGURE":
                    return CHtmlElementType.FIGURE;
                case "FIGCAPTION":
                    return CHtmlElementType.FIGCAPTION;
                case "DETAILS":
                    return CHtmlElementType.DETAILS;
                case "DATALIST":
                    return CHtmlElementType.DATALIST;
                case "DATA":
                    return CHtmlElementType.DATA;
                case "BDI":
                    return CHtmlElementType.BDI;
                case "/!-!/":
                    return CHtmlElementType.COMMENT;
                case "TWITTER":
                    return CHtmlElementType.TWITTER;
                case "BOOTSTRAP":
                    return CHtmlElementType.BOOTSTRAP;
                case "*":
                case "ASTERISK":
                    return CHtmlElementType.ASTERISK;
                case "ACRONYM":
                    return CHtmlElementType.ACRONYM;
                case "Q":
                    return CHtmlElementType.Q;
                case "COPY":
                    return CHtmlElementType.COPY;
                case "NEWSELEMENT":
                    return CHtmlElementType.NEWSELEMENT;
                case "RUBY":
                    return CHtmlElementType.RUBY;
                case "RP":
                    return CHtmlElementType.RP;
                case "RT":
                    return CHtmlElementType.RT;
                case "RB":
                    return CHtmlElementType.RB;
                case "ADV:HS":
                    return CHtmlElementType.ADV_HS;
                case "ADV:OV":
                    return CHtmlElementType.ADV_OV;
                case "NOINDEX":
                    return CHtmlElementType.NOINDEX;
                case "MAIN":
                    return CHtmlElementType.MAIN;
                case "PICTURE":
                    return CHtmlElementType.PICTURE;

                case "MODERNIZR":
                    return CHtmlElementType.MODERNIZR;
                case "XYZ":
                    return CHtmlElementType.XYZ;
                case "POST":
                    return CHtmlElementType.POST;
                case "BANNER":
                    return CHtmlElementType.BANNER;
            }




            return CHtmlElementType.UNKNOWN;
        }



        public static string GetHostNameStringFromUrlString(string __url)
        {
            int pos = __url.IndexOf("://", StringComparison.OrdinalIgnoreCase);
            if (pos > -1)
            {
                int posNextSlash = __url.IndexOf('/', pos + 3);
                if (posNextSlash == -1)
                {
                    return __url.Substring(pos + 3);
                }
                return __url.Substring(pos + 3, posNextSlash - (pos + 3));

            }
            else
            {
                return "";
            }
        }

        public static bool IsCharacterNonEqAndNonQuoteChar(char c)
        {
            switch (c)
            {
                case '\'':
                case '\"':
                case '=':
                    return false;
                default:
                    if (IsCharWhiteSpaceLimited(c) == true)
                        return false;
                    break;
            }

            return true;
        }






        public static bool IsCHtmlStyleElementKeyClassEqual(CHtmlStyleKey tagKey, CHtmlStyleKey styleSheetKey)
        {
            if (styleSheetKey.TagName.Length == 0)
            {
                if (styleSheetKey.CssID.Length != 0)
                {
                    if (string.Equals(styleSheetKey.CssID, tagKey.CssID, StringComparison.Ordinal) == true)
                        return true;
                    else
                        return false;
                }

                if (tagKey.___classList.Count <= 1 && styleSheetKey.___classList.Count <= 1)
                {
                    if (string.Equals(tagKey.CssClass, styleSheetKey.CssClass, StringComparison.Ordinal) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (styleSheetKey.___classList.Count == 1)
                    {
                        if (tagKey.___classList.ContainsKey(styleSheetKey.CssClassLowSimple) == false)
                        {
                            return false;
                        }
                    }
                    return true;
                }

            }
            else
            {
                /*
				if(tagKey.CssClass.Length == 0 && tagKey.CssID.Length == 0)
				{
					if(string.Equals(tagKey.TagName, styleSheetKey.TagName,StringComparison.Ordinal) == true)
						return true;
					else
						return false;
				}
				else
				{
					if(string.Equals(tagKey.TagName, styleSheetKey.TagName, StringComparison.Ordinal) == true)
					{
						return true;
					}
					else
					{
						return false;
					}	
				}
                 * */
                if (tagKey.___elementTagType != CHtmlElementType._UNDEFINED)
                {
                    if (tagKey.___elementTagType == CHtmlElementType.ASTERISK)
                    {
                        return true;
                    }
                    if (tagKey.___elementTagType == styleSheetKey.___elementTagType)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (string.Equals(tagKey.TagName, styleSheetKey.TagName, StringComparison.Ordinal) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }
        public static bool IsDownloadableContentType(string s)
        {
            try
            {
                if (s != null && s.Length != 0)
                {
                    string lContentType = FasterToLower(s);
                    int pos = lContentType.IndexOf('/');
                    if (pos == -1)
                    {
                        return false;
                    }
                    string lContentTypePrefix = lContentType.Substring(0, pos);
                    string lContentTypeAfter = lContentType.Substring(pos + 1);
                    int posAfterConma = -1;
                    posAfterConma = lContentTypeAfter.IndexOf(';');
                    if (posAfterConma > -1)
                    {
                        lContentTypeAfter = lContentTypeAfter.Substring(0, posAfterConma);
                    }


                    switch (lContentTypePrefix)
                    {
                        case "application":
                            switch (lContentTypeAfter)
                            {
                                case "html":
                                case "xhtml":
                                case "xhtml+xml":
                                case "xml":
                                    return false;

                            }
                            return true;
                        case "audio":
                        case "video":
                        case "model":
                        case "multipart":
                        case "message":
                            return true;
                        case "text":
                            {
                                switch (lContentTypeAfter)
                                {
                                    case "calendar":
                                    case "css":
                                    case "richtext":
                                    case "rtf":
                                    case "sgml":
                                        //case "xml":
                                        return true;
                                    default:
                                        break;
                                }
                                break;
                            }
                        case "image":
                            {
                                switch (lContentTypeAfter)
                                {
                                    case "cgm":
                                    case "g3fax":
                                    case "ief":
                                    case "tiff":
                                    case "vnd.dwg":
                                    case "vnd.dxf":
                                    case "vnd.fastbidsheet":
                                    case "vnd.fpx":
                                    case "vnd.svf":
                                    case "vnd.xiff":
                                        return true;
                                }
                                break;
                            }
                    }

                }
                return false;
            }
            catch
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("IsDowloadContentType Error : " + s);
                }
                return false;
            }
        }
        /// <summary>
        /// Returns true if string is "file://" or "c:\"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsUrlLocalFileUrl(string s)
        {
            if (string.IsNullOrEmpty(s) == true || s.Length < 3)
            {
                return false;
            }
            if (s.StartsWith("file:", StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            else
            {
                char c0 = s[0];
                char c1 = s[1];
                if (c1 == ':')
                {
                    if (char.IsLetter(c0) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool IsUrlLocalPath(ref string s)
        {
            if (s.StartsWith("http://localhost", StringComparison.Ordinal) == true)
            {
                return true;
            }
            else if (s.StartsWith("http://127.0.0.1", StringComparison.Ordinal) == true)
            {
                return true;
            }
            return false;
        }
        internal static string[] CSSMaxDeviceParameters = new string[] { "max-device-width", "max-width" };
        /// <summary>
        /// Returns HTML or CSS media attribute media-max width value
        /// </summary>
        /// <param name="sValueMedia"></param>
        /// <returns></returns>
        public static int GetMediaMaxWidth(string sValueMedia)
        {
            string _maxDeviceWidth = "";
            int _maxDeviceWidthInt = -1;
            try
            {
                int ___CSSMaxDeviceParametersCount = CSSMaxDeviceParameters.Length;
                for (int i = 0; i < ___CSSMaxDeviceParametersCount; i++)
                {
                    string _ParameterName = CSSMaxDeviceParameters[i];
                    int pos = -1;
                    pos = sValueMedia.IndexOf(_ParameterName, StringComparison.OrdinalIgnoreCase);
                    if (pos > -1)
                    {
                        _maxDeviceWidth = sValueMedia.Substring(pos + _ParameterName.Length + 1);

                    }
                    else
                    {
                        continue;
                    }

                    if (_maxDeviceWidth.Length > 0)
                    {
                        if (_maxDeviceWidth.IndexOf(')') > -1)
                        {
                            _maxDeviceWidth = _maxDeviceWidth.Substring(0, _maxDeviceWidth.IndexOf(')'));
                        }

                        _maxDeviceWidth = _maxDeviceWidth.Replace(" ", "");
                        _maxDeviceWidth = _maxDeviceWidth.Replace(")", "");
                        if (_maxDeviceWidth.Length > 0 && _maxDeviceWidth[0] == ':')
                        {
                            _maxDeviceWidth = _maxDeviceWidth.Remove(0, 1);
                        }
                        _maxDeviceWidthInt = GetIntValueFromString(_maxDeviceWidth, 0);
                        return _maxDeviceWidthInt;
                    }
                }

            }
            catch (Exception ex1)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("GetMediaMaxWidth ___hasInner error {0}", commonData.GetExceptionAsString(ex1));
                }
            }

            return -1;
        }
        private static int GetQuoteEndPosition(int __Cur, char[] _Chars)
        {
            int StartSegmentPoint = -1;
            int EndSegmentPoint = -1;
            System.Collections.Stack _QuoteStack = new Stack();
            // ------------------------------------------------------
            // Node i is '{' to start with
            // ------------------------------------------------------
            char nx = '\0';
            int _CharsLen = _Chars.Length;
            for (int p = __Cur + 6; p < _CharsLen; p++)
            {
                nx = _Chars[p];
                switch (nx)
                {
                    case '{':
                        {
                            StartSegmentPoint = p;
                            _QuoteStack.Push('{');
                        }
                        break;

                    case '}':
                        {
                            EndSegmentPoint = p;
                            if (_QuoteStack.Count > 0)
                            {
                                _QuoteStack.Pop();
                            }
                            if (_QuoteStack.Count == 0)
                            {
                                return p;
                            }
                        }
                        break;
                    case '/':
                        if (p + 3 < _CharsLen)
                        {
                            if (_Chars[p + 1] == '*')
                            {
                                if (_Chars[p + 2] == '/')
                                {
                                    p = p + 2;
                                    goto NextChar;
                                }
                                else
                                {
                                    // We will Seek for Coment End Point
                                    int QeStart = p + 2;
                                    for (; QeStart < _CharsLen - 1; QeStart++)
                                    {
                                        if (_Chars[QeStart] == '*' && _Chars[QeStart + 1] == '/')
                                        {
                                            p = QeStart + 1;
                                            goto NextChar;
                                        }

                                    }
                                }

                            }
                        }
                        break;
                    default:
                        break;
                }
            NextChar:
                continue;
            }
            return -1;

        }
        #region  CreateCSSRuleCollectionFromStyleSheetString
        public static System.Collections.Generic.List<CHtmlCSSRule> CreateCSSRuleCollectionFromStyleSheetString(string s, string _downloadUrl, string sValueAttribute)
        {
            return CreateCSSRuleCollectionFromStyleSheetString(s, _downloadUrl, "", null, null, null, null, null);
        }


        public static System.Collections.Generic.List<CHtmlCSSRule> CreateCSSRuleCollectionFromStyleSheetString(string s, string _downloadUrl, string _media, CHtmlMediaQueryNode ___mediaQueryNode, List<CHtmlCSSRule> ___ruleList, System.Collections.Generic.List<CHtmlCSSRule> ___styleQueue, System.Collections.Generic.List<CHtmlCSSRule> ___cssRuleBlackList,
            CHtmlElement ___rootElement)
        {
            string ___mediaStringOriginal = null;
            if (string.IsNullOrEmpty(_media) == false)
            {
                ___mediaStringOriginal = string.Copy(_media);
            }
            string ___downloadUrlOriginal = null;
            if (string.IsNullOrEmpty(_downloadUrl) == false)
            {
                ___downloadUrlOriginal = string.Copy(_downloadUrl);
            }
            else
            {
                ___downloadUrlOriginal = "";
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("Stange...CreateCSSRuleCollectionFromStyleSheetString() does not have baseURL, but cont...");
                }
            }


            List<CHtmlCSSRule> ___resultRuleList = new List<CHtmlCSSRule>();

            char[] _Chars = s.ToCharArray();
            char c = new char();
            int _Mode = 1; // None = 0;Title =1, Name =2, Value=3
            System.Text.StringBuilder sbTitle = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
            System.Text.StringBuilder sbName = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
            System.Text.StringBuilder sbValue = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
            System.Collections.Generic.List<CHtmlStyleAttribute?> arList = new System.Collections.Generic.List<CHtmlStyleAttribute?>();
            System.Collections.Generic.List<string> arTitle = null;
            bool IsInvalidMedia = false;
            int _CurrentI = 0;
            bool ___NeedsPerformPreiousCheck = false;
            char __QuoteStartChar = '\0';
            int _CharsLen = _Chars.Length;
            CHtmlCSSRule.CSSRuleType ____currentRuleType = CHtmlCSSRule.CSSRuleType.Style_Rule;
            for (int i = 0; i < _CharsLen; i++)
            {
                _CurrentI = i;
                c = _Chars[i];
                if (c == '@')
                {
                    if ((_Mode == 0 || _Mode == 1) && __QuoteStartChar != '\0')
                    {
                        goto SwithBlock;
                    }
                    StringBuilder sbTemp = new StringBuilder();
                    for (int z = i; z < i + 3000; z++)
                    {
                        if (z >= _CharsLen)
                            break;
                        sbTemp.Append(_Chars[z]);
                        if (_Chars[z] == ';' || _Chars[z] == '{')
                        {
                            string sHeader = sbTemp.ToString();
                            if (string.IsNullOrEmpty(sHeader) == false && (IsCharWhiteSpaceLimited(sHeader[0]) == true || IsCharWhiteSpaceLimited(sHeader[sHeader.Length - 1]) == true))
                            {
                                sHeader = sHeader.Trim();
                            }
                            string sHeaderL = FasterToLower(sHeader);
                            if (sHeaderL[0] == '@')
                            {
                                if (sHeaderL.StartsWith("@charset", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    i = z;
                                    _Mode = 1;
                                    goto NextLine;
                                }
                                else if (sHeaderL.StartsWith("@import", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    int urlPos = sHeaderL.IndexOf("url(", StringComparison.OrdinalIgnoreCase);
                                    string cssUrl = "";
                                    sHeader = sHeader.Replace("@import", "");
                                    if (string.IsNullOrEmpty(sHeader) == false && (IsCharWhiteSpaceLimited(sHeader[0]) == true || IsCharWhiteSpaceLimited(sHeader[sHeader.Length - 1]) == true))
                                    {
                                        sHeader = sHeader.Trim();
                                    }
                                    if (sHeader.StartsWith("url(", StringComparison.OrdinalIgnoreCase) == true)
                                    {
                                        sHeader = sHeader.Remove(0, 4);
                                    }
                                    if (sHeader.EndsWith(");", StringComparison.Ordinal))
                                    {
                                        sHeader = sHeader.Remove(sHeader.Length - 2, 2);
                                    }
                                    if (sHeader.EndsWith(")", StringComparison.Ordinal))
                                    {
                                        sHeader = sHeader.Remove(sHeader.Length - 1, 1);
                                    }

                                    bool IsUrlObtained = false;
                                    int ___Start = sHeader.IndexOf('\"');
                                    string QuoteChar = "\"";
                                    if (___Start > -1)
                                    {
                                        QuoteChar = "\"";
                                    }
                                    else
                                    {
                                        ___Start = sHeader.IndexOf('\'');
                                        if (___Start > -1)
                                        {
                                            QuoteChar = "'";
                                        }
                                    }
                                    int ___End = -1;
                                    ___End = sHeader.LastIndexOf(QuoteChar);
                                    try
                                    {
                                        if (___Start == -1)
                                        {
                                            ___Start = sHeader.IndexOf("http", StringComparison.OrdinalIgnoreCase);
                                            if (___Start == -1)
                                            {
                                                if (___End == -1)
                                                {
                                                    cssUrl = sHeader;
                                                    if (string.IsNullOrEmpty(cssUrl) == false && (IsCharWhiteSpaceLimited(cssUrl[0]) == true || IsCharWhiteSpaceLimited(cssUrl[cssUrl.Length - 1]) == true))
                                                    {
                                                        cssUrl = cssUrl.Trim();
                                                    }
                                                    goto DoneUrl;
                                                }
                                                ___Start = sHeader.IndexOf('/');
                                            }
                                            ___End = sHeader.Length;
                                        }
                                        if (___Start > -1 && ___End > -1)
                                        {
                                            cssUrl = sHeader.Substring(___Start, ___End - ___Start);
                                            if (string.IsNullOrEmpty(cssUrl) == false && (IsCharWhiteSpaceLimited(cssUrl[0]) == true || IsCharWhiteSpaceLimited(cssUrl[cssUrl.Length - 1]) == true))
                                            {
                                                cssUrl = cssUrl.Trim();
                                            }
                                            if (cssUrl[0] == '\"')
                                            {
                                                cssUrl = cssUrl.Substring(1);
                                            }
                                            else if (cssUrl[0] == '\'')
                                            {
                                                cssUrl = cssUrl.Substring(1);
                                            }
                                        }
                                        else if (___Start > -1 && ___End == -1)
                                        {
                                            cssUrl = sHeader.Substring(___Start);
                                            if (string.IsNullOrEmpty(cssUrl) == false && (IsCharWhiteSpaceLimited(cssUrl[0]) == true || IsCharWhiteSpaceLimited(cssUrl[cssUrl.Length - 1]) == true))
                                            {
                                                cssUrl = cssUrl.Trim();
                                            }
                                        }
                                        else
                                        {
                                            cssUrl = sHeader;
                                        }
                                    DoneUrl:
                                        IsUrlObtained = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                        {
                                            commonLog.LogEntry("Ananylzing @Import {0}", sHeader, commonData.GetExceptionAsString(ex));
                                        }
                                        IsUrlObtained = false;
                                    }
                                    if (IsUrlObtained == false)
                                    {
                                        i = z + 1;
                                        _Mode = 1;
                                        goto NextLine;
                                    }
                                    string __url = null;
                                    try
                                    {


                                        __url = GetAbsoluteUri(_downloadUrl, "", cssUrl);
                                    }
                                    catch (Exception ex)
                                    {

                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                        {
                                            commonLog.LogEntry("Unable to ___getInner correct CSS path. ", ex);
                                        }
                                    }
                                    if (__url.Length != 0)
                                    {
                                        CHtmlCSSRule importPart = new CHtmlCSSRule(CHtmlElementStyleType.None);
                                        importPart.___CSSPosition = i;
                                        importPart.___baseUrl = __url;
                                        importPart.___ruleType = CHtmlCSSRule.CSSRuleType.Import_Rule;
                                        importPart.SelectorID = "@import";
                                        importPart.___NonSearchableStyleSheet = true;

                                        importPart.___isStyleMustGoThruQueue = true;

                                        if (___rootElement != null)
                                        {
                                            importPart.___srcElementReference = new WeakReference(___rootElement, false);
                                        }
                                        if (___resultRuleList != null)
                                        {
                                            ___resultRuleList.Add(importPart);
                                        }


                                    }
                                    i = z;
                                    _Mode = 1;
                                    goto NextLine;
                                }

                                {
                                    int _sHeaderSpacePos = sHeader.IndexOfAny(CharSpaceCrLfTabZentakuSpace);
                                    string _strAppoHeaderName = "";
                                    if (_sHeaderSpacePos > -1)
                                    {
                                        _strAppoHeaderName = sHeader.Substring(0, _sHeaderSpacePos);
                                    }
                                    else
                                    {
                                        _strAppoHeaderName = sHeader;
                                    }
                                    if (_strAppoHeaderName.Length != 0)
                                    {
                                        // '{' appears before ';' ?
                                        bool IsLeftCurlyBracketAppearsBeforesSemicolon = false;
                                        char posC = '\0';
                                        for (int posBacket = i + 3; posBacket < _CharsLen; posBacket++)
                                        {
                                            posC = _Chars[posBacket];
                                            if (posC == '{')
                                            {
                                                IsLeftCurlyBracketAppearsBeforesSemicolon = true;
                                                break;
                                            }
                                            else if (posC == ';')
                                            {
                                                IsLeftCurlyBracketAppearsBeforesSemicolon = false;
                                                break;
                                            }
                                        }
                                        int posApos = _strAppoHeaderName.IndexOf('{');

                                        if (posApos > -1)
                                        {
                                            _strAppoHeaderName = _strAppoHeaderName.Substring(0, posApos);
                                        }
                                        int posQuoteBegin1 = _strAppoHeaderName.IndexOf('(');
                                        if (posQuoteBegin1 > -1)
                                        {
                                            _strAppoHeaderName = _strAppoHeaderName.Substring(0, posQuoteBegin1);
                                        }

                                        int QuoteEnd = -1;
                                        ____currentRuleType = getCSSRuleTypeFromString(_strAppoHeaderName);
                                        switch (____currentRuleType)
                                        {
                                            case CHtmlCSSRule.CSSRuleType.Media_Rule:
                                            case CHtmlCSSRule.CSSRuleType.Keyframes_Rule:
                                            case CHtmlCSSRule.CSSRuleType.Keyframe_Rule:

                                            case CHtmlCSSRule.CSSRuleType.Page_Rule:
                                            case CHtmlCSSRule.CSSRuleType.Document_Rule: // Mozilla Specific
                                                bool __WillSkipBlock = true;
                                                bool __WillGenerateStringBuilderOnkippingBlock = false;
                                                bool __WillGenerateCHtmlStyleElementListOnSkippingBlock = false;
                                                bool __IsMediaQueriesSuccess = false;
                                                if (__WillGenerateCHtmlStyleElementListOnSkippingBlock == true) {; }
                                                if (__IsMediaQueriesSuccess == false) {; }
                                                string sValueAttribute = "";
                                                try
                                                {
                                                    sValueAttribute = FasterToLower(sHeader.Remove(0, _strAppoHeaderName.Length));
                                                    int ___QuoteEnd1 = sValueAttribute.LastIndexOf('{');
                                                    if (___QuoteEnd1 > -1)
                                                    {
                                                        sValueAttribute = sValueAttribute.Substring(0, ___QuoteEnd1);
                                                    }
                                                    if (string.IsNullOrEmpty(sValueAttribute) == false && (IsCharWhiteSpaceLimited(sValueAttribute[0]) == true || IsCharWhiteSpaceLimited(sValueAttribute[sValueAttribute.Length - 1]) == true))
                                                    {
                                                        sValueAttribute = sValueAttribute.Trim();
                                                    }
                                                }
                                                catch (Exception ex1)
                                                {
                                                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                                    {
                                                        commonLog.LogEntry("{0} ___hasInner error {1}", ex1.Message, commonData.GetExceptionAsString(ex1));
                                                    }
                                                }
                                                CHtmlMediaQueryNode mediaNode = null;
                                                if (sValueAttribute.Length != 0 && ____currentRuleType == CHtmlCSSRule.CSSRuleType.Media_Rule)
                                                {
                                                    try
                                                    {
                                                        mediaNode = new CHtmlMediaQueryNode(CHtmlMediaQueryNodeType.RootNode);
                                                        mediaNode.OwnerElementType = MediaQueryOwnerElementType.CSSInlineMedia;
                                                        mediaNode.Text = sValueAttribute;
                                                        if (___mediaQueryNode != null)
                                                        {
                                                            mediaNode.MethodStackLevel = ___mediaQueryNode.MethodStackLevel + 1;
                                                        }
                                                        else
                                                        {
                                                            mediaNode.MethodStackLevel++;
                                                        }
                                                        if (mediaNode.MethodStackLevel >= 5)
                                                        {
                                                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                                            {
                                                                commonLog.LogEntry("Media Query Is Over Stack. Force to Fail : " + sValueAttribute);
                                                            }
                                                            mediaNode.Result = CHtmlMediaQueryResult.Fail;
                                                        }

                                                        if (mediaNode.Result == CHtmlMediaQueryResult.Fail)
                                                        {
                                                            __IsMediaQueriesSuccess = false;
                                                            __WillGenerateCHtmlStyleElementListOnSkippingBlock = false;
                                                            __WillGenerateStringBuilderOnkippingBlock = false;
                                                            goto JustBeforeWillSkipBlock;
                                                        }
                                                        else if (mediaNode.Result == CHtmlMediaQueryResult.OK)
                                                        {
                                                            __IsMediaQueriesSuccess = true;
                                                            __WillGenerateCHtmlStyleElementListOnSkippingBlock = true;
                                                            __WillGenerateStringBuilderOnkippingBlock = true;
                                                            goto JustBeforeWillSkipBlock;
                                                        }
                                                    }
                                                    catch (Exception mediaEx)
                                                    {
                                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                                        {
                                                            commonLog.LogEntry("MediaQueryNode", mediaEx);
                                                        }
                                                        __WillGenerateCHtmlStyleElementListOnSkippingBlock = false;
                                                        __IsMediaQueriesSuccess = false;
                                                    }
                                                }
                                            JustBeforeWillSkipBlock:
                                                if (__WillSkipBlock == true)
                                                {
                                                    QuoteEnd = GetQuoteEndPosition(i + 3, _Chars);
                                                    if (QuoteEnd > -1)
                                                    {
                                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                                        {
                                                            if (string.Equals(_strAppoHeaderName, "@media", StringComparison.OrdinalIgnoreCase) == false)
                                                            {
                                                                commonLog.LogEntry("CSS@Rule \'" + _strAppoHeaderName + "\' will be skipped to " + QuoteEnd.ToString());
                                                            }
                                                            else
                                                            {
                                                                commonLog.LogEntry("[MediaQueies] \'@media\' \'" + sValueAttribute + "\' Sucess : (" + __IsMediaQueriesSuccess.ToString() + ") QuoteEnd : " + QuoteEnd.ToString());

                                                            }
                                                        }
                                                        arList = new System.Collections.Generic.List<CHtmlStyleAttribute?>();
                                                        sbTitle = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                        sbName = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                        sbValue = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                        if (__WillGenerateStringBuilderOnkippingBlock)
                                                        {
                                                            System.Text.StringBuilder __sbSkipText = new StringBuilder(QuoteEnd - i);
                                                            int posS = -1;
                                                            if (z > 0)
                                                            {
                                                                posS = z + 1;
                                                            }
                                                            else
                                                            {
                                                                posS = i;
                                                            }
                                                            for (; posS < QuoteEnd; posS++)
                                                            {
                                                                __sbSkipText.Append(_Chars[posS]);

                                                            }
                                                            if (__sbSkipText.Length != 0)
                                                            {
                                                                switch (_strAppoHeaderName)
                                                                {
                                                                    case "@media":
                                                                        List<CHtmlCSSRule> listRulesInner = null;
                                                                        bool ___DoNorMergeList = false;
                                                                        if (___styleQueue != null)
                                                                        {
                                                                            ___DoNorMergeList = true;
                                                                        }
                                                                        try
                                                                        {
                                                                            if (___styleQueue != null)
                                                                            {
                                                                                /*
                                                                                commonDelegateCreateStyleCHtmlCollectionFromStyleSheetString delCreateDelegate = new commonDelegateCreateStyleCHtmlCollectionFromStyleSheetString(CreateCSSRuleCollectionFromStyleSheetString);
                                                                                delCreateDelegate.BeginInvoke(__sbSkipText.ToString(), string.Copy(___downloadUrlOriginal), sValueAttribute, mediaNode, ___resultRuleList, ___styleQueue, ___cssRuleBlackList, ___rootElement, null, null);
                                                                                */
                                                                            }
                                                                            else
                                                                            {
                                                                                // =====================================================
                                                                                //             Sync Mode
                                                                                // =====================================================
                                                                                if (IsNotNull(___resultRuleList) == true)
                                                                                {
                                                                                    listRulesInner = CreateCSSRuleCollectionFromStyleSheetString(__sbSkipText.ToString(), string.Copy(___downloadUrlOriginal), sValueAttribute, mediaNode, ___resultRuleList, ___styleQueue, ___cssRuleBlackList, ___rootElement);
                                                                                }


                                                                                // =====================================================
                                                                            }
                                                                        }
                                                                        catch (Exception ex1)
                                                                        {
                                                                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                                                            {
                                                                                commonLog.LogEntry("{0} ___hasInner error {1}", ex1.Message, commonData.GetExceptionAsString(ex1));
                                                                            }
                                                                        }
                                                                        if (___DoNorMergeList == false)
                                                                        {
                                                                            if (___resultRuleList != null && listRulesInner != null && listRulesInner.Count > 0)
                                                                            {
                                                                                ___resultRuleList.AddRange(listRulesInner);
                                                                            }
                                                                        }

                                                                        break;
                                                                    default:
                                                                        break;
                                                                }

                                                            }
                                                        }
                                                        i = QuoteEnd;
                                                        goto NextLine;
                                                    }
                                                }
                                                else
                                                {
                                                    arList = new System.Collections.Generic.List<CHtmlStyleAttribute?>();
                                                    sbTitle = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                    //sbTitle.Append('@');
                                                    sbName = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                    sbValue = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                    ____currentRuleType = CHtmlCSSRule.CSSRuleType.Style_Rule;
                                                    goto NextLine;
                                                }
                                                break;
                                            case CHtmlCSSRule.CSSRuleType.Font_Face_Rule:
                                            case CHtmlCSSRule.CSSRuleType.Viewport_Rule:

                                                // @font-face and @view-port is normal parse

                                                arList = new System.Collections.Generic.List<CHtmlStyleAttribute?>();
                                                sbTitle = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                sbTitle.Append('@');
                                                sbName = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                sbValue = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);

                                                goto NextLine;

                                            default:
                                                if (IsLeftCurlyBracketAppearsBeforesSemicolon == true)
                                                {
                                                    QuoteEnd = GetQuoteEndPosition(i + 3, _Chars);
                                                    if (QuoteEnd > -1)
                                                    {
                                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                                        {
                                                            commonLog.LogEntry(_strAppoHeaderName + " CSS Unknown Title but will be skipped to " + QuoteEnd.ToString());
                                                        }
                                                        ____currentRuleType = CHtmlCSSRule.CSSRuleType.Style_Rule;
                                                        arList = new System.Collections.Generic.List<CHtmlStyleAttribute?>();
                                                        sbTitle = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                        sbName = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                        sbValue = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                        i = QuoteEnd;
                                                        goto NextLine;
                                                    }
                                                }

                                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                                {
                                                    commonLog.LogEntry("CSS @ Unknown Title {0}", _strAppoHeaderName);
                                                }


                                                break;
                                        }
                                    }

                                    if (sbTitle != null)
                                    {
                                        sbTitle.Append('@');
                                    }
                                }
                                goto NextLine;
                            }
                        }
                    }
                }
                if (i < _CharsLen - 1)
                {
                    if ((_Mode == 0 || _Mode == 1) && __QuoteStartChar != '\0')
                    {
                        goto SwithBlock;
                    }
                    if (c == '/')
                    {
                        char _cb1 = _Chars[i + 1];
                        if ((c == '/' && ((_cb1 == '*') || (_cb1 == '\uff0a'))))
                        {
                            if (i < _CharsLen - 2)
                            {
                                if (_Chars[i + 2] == '/')
                                {
                                    // ========================================================
                                    // This Check is for  type of comment
                                    // ========================================================
                                    if (i < _CharsLen - 3 && _Chars[i + 3] == '*')
                                    {
                                        goto EndCommentLookup;
                                    }
                                    i = i + 2;
                                    goto NextLine;

                                }
                            }
                        EndCommentLookup:
                            for (int z = i + 2; z < _CharsLen - 1; z++)
                            {
                                if (((_Chars[z] == '*') || (_Chars[z] == '\uff0a')) && (_Chars[z + 1] == '/'))
                                {
                                    i = z + 1;
                                    goto NextLine;
                                }
                            }
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                            {
                                commonLog.LogEntry("{0} ___hasInner unterminated comment {1}", _downloadUrl, i);
                            }
                        }
                        else if ((c == '/' && _Chars[i + 1] == '/'))
                        {
                            // MS DOS CRLF, UNIX LF MAC CR We need check both
                            for (int z = i + 2; z < _CharsLen; z++)
                            {
                                if ((_Chars[z] == '\r') || (_Chars[z] == '\n'))
                                {

                                    i = z;
                                    if (z + 1 < _CharsLen)
                                    {
                                        if (_Chars[z + 1] == '\r' || _Chars[z + 1] == '\n')
                                        {
                                            i++;
                                        }
                                    }
                                    goto NextLine;

                                }
                                else if (_Chars[z] == '}' || _Chars[z] == '{' || _Chars[z] == ';')
                                {
                                    /* =============================================
                                     * Irregular comment is normally end with line feed
                                     * some does not use line feed.
                                     * If any character found after line comment, comment is terminated.
                                     *                                                        2014/07/15
                                     * =============================================
                                     * ---------------------------------- [ CSS Sample ] ------------------------------
                                     * .entry-date {    color: #b80002;    font-style: italic;   // display: none;}.widget {    margin-bottom: 30px;}.widget > ul > p {width:10px}
                                     * -----------------------------------------------------------------------------------
                                     */
                                    i = z;
                                    goto NextLine;
                                }
                            }
                        }
                    }
                }
            SwithBlock:
                if (__QuoteStartChar != '\0')
                {
                    goto EndOfSwithBlock;
                }
                switch (c)
                {
                    // Mode None = 0;Title =1, Name =2, Value=3
                    case '{':
                        _Mode = 2;
                        ___NeedsPerformPreiousCheck = false;
                        goto NextLine;
                    case '}':
                        _Mode = 1;
                        bool ___isImportant = false;
                        VerifyStyleNameAndValue(ref sbName, ref sbValue, ref ___isImportant);
                        string strNameQ = sbName.ToString();
                        if (strNameQ.Length > 0)
                        {

                            if (IsInvalidMedia == false)
                            {
                                //srList[strNameQ] = sbValue.ToString();
                                CreateStyleValueEntry(strNameQ, sbValue.ToString(), arList, ___isImportant);
                            }

                        }
                        string strTitle = null;
                        try
                        {
                            if (IsInvalidMedia == false)
                            {
                                strTitle = sbTitle.ToString();
                                if (strTitle.IndexOf("\\:", StringComparison.Ordinal) > -1)
                                {
                                    strTitle = strTitle.Replace("\\:", ":");
                                }
                                arTitle = null;
                                arTitle = GetSelectorIDSplit(strTitle);
                                int arTitleCount = arTitle.Count;
                                string ElemTitle = null;
                                for (int pos = 0; pos < arTitleCount; pos++)
                                {
                                    string strElemTitle = arTitle[pos];
                                    // ======Unwanted Replace Spaces ===========
                                    if (strElemTitle.Length > 0)
                                    {
                                        if (IsCharWhiteSpaceLimited(strElemTitle[0]) == true || IsCharWhiteSpaceLimited(strElemTitle[strElemTitle.Length - 1]) == true)
                                        {
                                            ElemTitle = strElemTitle.Trim();
                                        }
                                        else
                                        {
                                            ElemTitle = strElemTitle;
                                        }
                                    }
                                    // ========================================
                                    if (string.IsNullOrEmpty(ElemTitle) == false)
                                    {
                                        CHtmlCSSRule ___rule = new CHtmlCSSRule(CHtmlElementStyleType.None);
                                        ___rule.___CSSPosition = i;
                                        ___rule.___SelectorConmaCount = arList.Count;
                                        if (___downloadUrlOriginal.Length != 0)
                                        {
                                            ___rule.___baseUrl = string.Copy(___downloadUrlOriginal);
                                        }
                                        ___rule.___ruleType = ____currentRuleType;
                                        switch (___rule.___ruleType)
                                        {
                                            case CHtmlCSSRule.CSSRuleType.Import_Rule:
                                            case CHtmlCSSRule.CSSRuleType.Font_Face_Rule:
                                                ___rule.___isStyleMustGoThruQueue = true;
                                                ___rule.___NonSearchableStyleSheet = true;
                                                break;
                                            case CHtmlCSSRule.CSSRuleType.Style_Rule:
                                                break;
                                            default:
                                                ___rule.___NonSearchableStyleSheet = true;
                                                break;
                                        }

                                        ___rule.___SelectorTextOriginal = strTitle;
                                        ___rule.SelectorID = ElemTitle;
                                        if (___mediaQueryNode != null)
                                        {
                                            if (___mediaQueryNode.HasValueRadio == true)
                                            {
                                                ___rule.___SelectorMediaQueryRanking = ___mediaQueryNode.ValueRatio;
                                            }
                                            else
                                            {
                                                ___rule.___SelectorMediaQueryRanking = CHtmlCSSStyleSheet.STYLE_MEDIA_RANKING_LOWEST;
                                            }
                                        }
                                        if (string.IsNullOrEmpty(___mediaStringOriginal) == false)
                                        {
                                            ___rule.___media = ___mediaStringOriginal;
                                        }
                                        else
                                        {

                                        }
                                        if (___mediaQueryNode != null)
                                        {
                                            // if it is inline media it does not have any strong reference from owner.
                                            if (___mediaQueryNode.OwnerElementType == MediaQueryOwnerElementType.CSSInlineMedia)
                                            {
                                                ___rule.___MediaQueryNodeInstance = ___mediaQueryNode;
                                            }
                                            else
                                            {
                                                ___rule.___MediaQueryNodeWeakReference = new WeakReference(___mediaQueryNode, false);
                                            }
                                        }



                                        // ==============================================================
                                        // Merging into CHtmlCSSStyleSheet is not reuired
                                        // ==============================================================

                                        if (arList.Count > 0)
                                        {
                                            if (___rule.___styleAttributeList == null)
                                            {
                                                ___rule.___styleAttributeList = new System.Collections.Generic.List<CHtmlStyleAttribute?>();
                                            }
                                            if (___rule.___styleAttributeList.Count > 0)
                                            {
                                                ___rule.___styleAttributeList = new System.Collections.Generic.List<CHtmlStyleAttribute?>();
                                            }
                                            ___rule.___styleAttributeList.AddRange(arList);
                                        }



                                        if (___resultRuleList != null)
                                        {
                                            ___resultRuleList.Add(___rule);
                                        }
                                        if (___rule.___NonSearchableStyleSheet == false)
                                        {
                                            if (___styleQueue != null)
                                            {
                                                ___styleQueue.Add(___rule);
                                            }
                                        }
                                        else if (___rule.___isStyleMustGoThruQueue == true)
                                        {
                                            if (___styleQueue != null)
                                            {
                                                ___styleQueue.Add(___rule);
                                            }
                                        }
                                        else
                                        {
                                            if (___cssRuleBlackList != null)
                                            {
                                                if (System.Threading.Monitor.TryEnter(___cssRuleBlackList, 500))
                                                {
                                                    try
                                                    {
                                                        ___cssRuleBlackList.Add(___rule);
                                                    }
                                                    finally
                                                    {
                                                        System.Threading.Monitor.Exit(___cssRuleBlackList);
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                            {
                                commonLog.LogEntry(strTitle, ex);
                            }
                        }
                        arList = new System.Collections.Generic.List<CHtmlStyleAttribute?>();
                        sbTitle = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                        sbName = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                        sbValue = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                        ____currentRuleType = CHtmlCSSRule.CSSRuleType.Style_Rule;
                        for (int p = i + 1; p < _CharsLen; p++)
                        {
                            if (_Chars[p] == '}')
                            {
                                if (IsInvalidMedia == true)
                                {
                                    IsInvalidMedia = false;
                                }
                                i = p;
                                goto NextLine;
                            }
                            else if (char.IsLetter(_Chars[p]) == true)
                            {
                                goto NextLine;
                            }
                        }
                        goto NextLine;
                    case ':':
                        if (_Mode == 1)
                            break;
                        if (___NeedsPerformPreiousCheck == true)
                        {
                            for (int pg = i; pg > 0; pg--)
                            {
                                if (_Chars[pg] == '{' || _Chars[pg] == ';')
                                    break;
                                else if (_Chars[pg] == '[' || _Chars[pg] == ']')
                                {

                                    for (int safep = i; safep < _CharsLen; safep++)
                                    {
                                        if (_Chars[safep] == ']' || _Chars[safep] == '\r' || _Chars[safep] == '\n')
                                        {
                                            i = safep;
                                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                            {
                                                // ===================================================================
                                                // to avoid yahoo unsafe block
                                                // ===================================================================
                                                // .div[background-color:#b8c9d9;width:300px;height:300px;] 
                                                commonLog.LogEntry("Yahoo Unsafe block found. Skip to Safe Point to {0}...", safep);
                                            }
                                            arList = new System.Collections.Generic.List<CHtmlStyleAttribute?>();
                                            sbTitle = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                            sbName = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                            sbValue = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                            _Mode = 1;
                                            ___NeedsPerformPreiousCheck = false;
                                            goto NextLine;
                                        }
                                    }
                                }
                            }
                        }
                        sbValue = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                        System.Collections.Generic.List<char> arSym = new System.Collections.Generic.List<char>();
                        bool __ValueHasAnyValue = false;
                        for (int z = i + 1; z < _CharsLen; z++)
                        {
                            char cz = _Chars[z];
                            switch (cz)
                            {
                                case '(':
                                    arSym.Add('(');
                                    break;
                                case ')':
                                    removeLastCharFromList(ref arSym, '(');
                                    break;
                                case '{':
                                    arSym.Add('{');
                                    break;
                                case '}':
                                    if (arSym.Count == 0)
                                    {
                                        i = z - 1;
                                        _Mode = 3;
                                        goto NextLine;
                                    }
                                    else
                                    {
                                        removeLastCharFromList(ref arSym, '{');
                                    }
                                    break;
                                case ';':
                                case ':':
                                    if (arSym.Count == 0)
                                    {
                                        i = z - 1;
                                        _Mode = 3;
                                        goto NextLine;
                                    }
                                    break;
                                case '/':
                                    if (z < _CharsLen - 2)
                                    {
                                        if (_Chars[z + 1] == '*')
                                        {
                                            if (z < _CharsLen - 1 && _Chars[z + 2] == '/')
                                            {
                                                z = z + 2;
                                                goto NextValueChar;
                                            }
                                            for (int _endPos = z + 2; _endPos < _CharsLen - 1; _endPos++)
                                            {
                                                if (_Chars[_endPos] == '*' && _Chars[_endPos + 1] == '/')
                                                {
                                                    z = _endPos + 1;
                                                    goto NextValueChar;
                                                }

                                            }
                                        }
                                    }
                                    break;
                                case '\'':
                                case '\"':
                                    if (__ValueHasAnyValue == false)
                                    { // ---- Value Can be ------
                                      // voice-family: "\"}\"";
                                      // ------------------------

                                        char _QuoteStartChar = cz;
                                        for (int ni = z + 1; ni < _CharsLen; ni++)
                                        {
                                            if (_Chars[ni] == _QuoteStartChar)
                                            {
                                                if (_Chars[ni - 1] != '\\')
                                                {
                                                    z = ni;
                                                    goto NextValueChar;
                                                }
                                            }
                                            if (IsCharWhiteSpaceLimited(_Chars[ni]) == true)
                                            {
                                                sbValue.Append(' ');
                                            }
                                            else
                                            {
                                                sbValue.Append(_Chars[ni]);
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                            if (char.IsLetterOrDigit(cz))
                            {
                                __ValueHasAnyValue = true;
                            }
                            if (IsCharWhiteSpaceLimited(cz) == true)
                            {
                                sbValue.Append(' ');
                            }
                            else
                            {
                                sbValue.Append(cz);
                            }
                        NextValueChar:
                            if (false) {; }
                        }
                        if (_Mode == 2)
                        {
                            _Mode = 3;
                            goto NextLine;
                        }
                        break;
                    case ';':
                        _Mode = 2;
                        ___isImportant = false;
                        VerifyStyleNameAndValue(ref sbName, ref sbValue, ref ___isImportant);
                        string strName = sbName.ToString();
                        if (strName.Length > 0)
                        {
                            if (IsInvalidMedia == false)
                            {

                                CreateStyleValueEntry(strName, sbValue.ToString(), arList, ___isImportant);

                            }
                        }
                        sbName = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                        sbValue = new System.Text.StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                        goto NextLine;


                }
            EndOfSwithBlock:
                if (c == '\'' || c == '\"')
                {
                    if (i > 0 && _Chars[i - 1] != '\\')
                    {
                        if (__QuoteStartChar == '\0')
                        {
                            __QuoteStartChar = c; // Quote Start
                        }
                        else if (c == __QuoteStartChar)
                        {
                            __QuoteStartChar = '\0'; // Quote End
                        }
                    }
                }
                if (IsCharWhiteSpaceLimited(c))
                {

                    if (c == '\n' && i > 0 && _Chars[i - 1] == '\r')
                    {
                        continue;
                    }

                    c = ' ';
                }
                if (___NeedsPerformPreiousCheck == false && c == '[')
                {
                    ___NeedsPerformPreiousCheck = true;
                }
                switch (_Mode)
                {
                    case 0:
                    case 1:
                        if (IsCharWhiteSpaceLimited(c))
                        {
                            if (sbTitle.Length == 0)
                            {
                                continue;
                            }
                        }
                        if (c >= 'A' && c <= 'Z')
                        {
                            sbTitle.Append(FasterToLower(c));
                        }
                        else
                        {
                            sbTitle.Append(c);
                        }
                        break;
                    case 2:
                        if (IsCharWhiteSpaceLimited(c) == false)
                        {
                            if (c >= 'A' && c <= 'Z')
                            {
                                sbName.Append(FasterToLower(c));
                            }
                            else
                            {
                                if (IsHyphenChar(c) == false)
                                {
                                    sbName.Append(c);
                                }
                                else
                                {
                                    sbName.Append('-');
                                }

                            }
                        }
                        break;
                    case 3:
                        sbValue.Append(c);
                        break;

                }
            NextLine:
                c = '\0';
            }

            return ___resultRuleList;

        }
        #endregion
        const int MaxCSSRuleLookupLength = 16;
        public static List<CHtmlCSSRule> CreateCSSRulesCollectionFromImportStyleSheet(List<CHtmlCSSRule> csscol, string cssurl)
        {
            if (csscol == null || string.IsNullOrEmpty(cssurl) == true)
            {
                return null;
            }
            if (csscol.Count == 0)
            {
                return null;
            }
            List<CHtmlCSSRule> result = new List<CHtmlCSSRule>();
            int csscolCount = csscol.Count;
            int currentPos = 0;
            foreach (CHtmlCSSRule eachrule in csscol)
            {
                currentPos++;
                if (currentPos > MaxCSSRuleLookupLength)
                {
                    break;
                }
                if (eachrule == null)
                {
                    continue;
                }
                if (eachrule.___ruleType == CHtmlCSSRule.CSSRuleType.Import_Rule)
                {
                    if (string.IsNullOrEmpty(eachrule.___baseUrl) == false)
                    {
                        string newUrl = GetAbsoluteUri(cssurl, "", eachrule.___baseUrl);
                        if (string.IsNullOrEmpty(newUrl) == false)
                        {
                            eachrule.___baseUrl = newUrl;
                        }
                    }
                    result.Add(eachrule);
                }
            }
            return result;
        }

        private const int Font_Face_Whitespace_Margin = 50;
        public static System.Collections.Generic.Dictionary<CSSFontFaceFormatType, string> getCSSRuleFontFaceDownloadableList(CHtmlCSSRule ___rule, string ___baseUrl, out string fontFamilyName)
        {
            fontFamilyName = null;
            System.Collections.Generic.Dictionary<CSSFontFaceFormatType, string> result = new System.Collections.Generic.Dictionary<CSSFontFaceFormatType, string>();
            if (___rule == null || ___rule.___styleAttributeList == null || ___rule.___styleAttributeList.Count == 0)
            {
                return result;
            }
            int __attrCount = ___rule.___styleAttributeList.Count;
            try
            {
                for (int i = 0; i < __attrCount; i++)
                {
                    CHtmlStyleAttribute? ___styleAttrNullable = ___rule.___styleAttributeList[i];
                    if (___styleAttrNullable.HasValue == true)
                    {

                        switch (___styleAttrNullable.Value.Name)
                        {
                            case "src":
                                {
                                    string strSrcValue = null;
                                    if (___styleAttrNullable.Value.value != null)
                                    {
                                        strSrcValue = ___styleAttrNullable.Value.value;
                                    }
                                    if (string.IsNullOrEmpty(strSrcValue) == false)
                                    {
                                        char[] srcArray = strSrcValue.ToCharArray();
                                        int srcLen = srcArray.Length;
                                        CHtmlParseModeType ___mode = CHtmlParseModeType.TagName;
                                        System.Text.StringBuilder sbPrefix = new StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                        System.Text.StringBuilder sbValue = new StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                        string currentPrefix = null;
                                        System.Collections.Generic.Dictionary<string, string> ___valueDictionary = new System.Collections.Generic.Dictionary<string, string>();
                                        for (int s = 0; s < srcLen; s++)
                                        {
                                            char c = srcArray[s];
                                            switch (c)
                                            {
                                                case '(':
                                                    ___mode = CHtmlParseModeType.InnerText;
                                                    if (sbPrefix.Length > 0)
                                                    {
                                                        currentPrefix = sbPrefix.ToString();
                                                        if (IsCharWhiteSpaceLimited(currentPrefix[0]) == true || IsCharWhiteSpaceLimited(currentPrefix[currentPrefix.Length - 1]) == true)
                                                        {
                                                            currentPrefix = currentPrefix.Trim();
                                                        }
                                                    }
                                                    break;
                                                case ',': // Means multipe entry

                                                    ___mode = CHtmlParseModeType.TagName;
                                                    sbPrefix = new StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                    sbValue = new StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                    currentPrefix = null;
                                                    break;
                                                case ';':
                                                    ___mode = CHtmlParseModeType.TagName;
                                                    if (___valueDictionary.Count > 0)
                                                    {
                                                        ___createCSSFontFaceListEntry(result, ___valueDictionary, ___baseUrl);
                                                        ___valueDictionary = new System.Collections.Generic.Dictionary<string, string>();
                                                    }
                                                    sbPrefix = new StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                    sbValue = new StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                    currentPrefix = null;
                                                    break;
                                                case ')':

                                                    ___mode = CHtmlParseModeType.TagName;
                                                    if (string.IsNullOrEmpty(currentPrefix) == false)
                                                    {
                                                        ___valueDictionary[currentPrefix] = sbValue.ToString();
                                                    }
                                                    bool ___lastString = true;
                                                    if (s == srcLen - 1)
                                                    {
                                                        ___lastString = true;
                                                    }
                                                    else
                                                        if (s + Font_Face_Whitespace_Margin > srcLen)
                                                        {

                                                            for (int test = s + 1; test < srcLen; test++)
                                                            {
                                                                char ctest = srcArray[test];
                                                                if (IsCharWhiteSpaceLimited(ctest) == true)
                                                                {
                                                                    continue;
                                                                }
                                                                else if (ctest == ';')
                                                                {
                                                                    ___lastString = true;
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    ___lastString = false;
                                                                    break;
                                                                }

                                                            }

                                                        }
                                                        else
                                                        {
                                                            ___lastString = false;
                                                        }
                                                    if (___lastString == true)
                                                    {
                                                        if (___valueDictionary.Count > 0)
                                                        {
                                                            ___createCSSFontFaceListEntry(result, ___valueDictionary, ___baseUrl);
                                                        }
                                                        ___valueDictionary = new System.Collections.Generic.Dictionary<string, string>();
                                                    }
                                                    currentPrefix = null;
                                                    sbPrefix = new StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                    sbValue = new StringBuilder(StringBuilder_BUFFER_Size_For_CSS_Tag);
                                                    break;
                                                default:
                                                    if (___mode == CHtmlParseModeType.TagName)
                                                    {
                                                        sbPrefix.Append(c);
                                                    }
                                                    else
                                                    {
                                                        sbValue.Append(c);
                                                    }
                                                    break;
                                            }

                                        }
                                    }
                                }
                                break;
                            case "font-family":
                                {
                                    fontFamilyName = string.Copy(___styleAttrNullable.Value.value);
                                }
                                break;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {

                    commonLog.LogEntry("getCSSRuleFontFaceDownloadableList() Exception. ", ex);

                }
            }
            return result;
        }
        public static bool IsCharWhiteSpaceLimited(char c)
        {

            switch (c)
            {
                case (char)0:
                case (char)9:
                case (char)10:
                case (char)11:
                case (char)12:
                case (char)13:
                case (char)28:
                case (char)29:
                case (char)30:
                case (char)31:
                case (char)32:
                case (char)133:
                case (char)160:
                case (char)8192:
                case (char)8193:
                case (char)8194:
                case (char)8195:
                case (char)8196:
                case (char)8197:
                case (char)8198:
                case (char)8199:
                case (char)8200:
                case (char)8201:
                case (char)8202:
                case (char)8203:
                case (char)8232: // line separator
                case (char)8233: // paragraph separator
                case (char)8239: // narrow no-break space
                case (char)8287: // Separator, space
                case (char)12288: // Separator, space (Zenkaku Space)
                    return true;
            }
            return false;
        }
        private static void ___createCSSFontFaceListEntry(System.Collections.Generic.Dictionary<CSSFontFaceFormatType, string> result, System.Collections.Generic.Dictionary<string, string> dict, string ___baseUrl)
        {
            string strUrl = null;
            dict.TryGetValue("url", out strUrl);
            string strFontFormat = null;
            dict.TryGetValue("format", out strFontFormat);
            CSSFontFaceFormatType ___formatType = CSSFontFaceFormatType.NotSet;
            ___formatType = ___getCSSFormatTypeFromString(strFontFormat);
            if (___formatType == CSSFontFaceFormatType.NotSet)
            {
                try
                {
                    if (string.IsNullOrEmpty(strUrl) == false)
                    {
                        // Just guess format style from url string.
                        int lastConma = strUrl.LastIndexOf('.');
                        int urlLen = strUrl.Length;
                        if (lastConma != -1 && lastConma + 100 > urlLen)
                        {
                            string strExtention = null;
                            System.Text.StringBuilder sbExt = new StringBuilder(10);
                            char[] chrUrl = strUrl.ToCharArray();

                            for (int last = lastConma; last < urlLen; last++)
                            {
                                char charLast = chrUrl[last];
                                if (IsCharWhiteSpaceLimited(charLast) == false)
                                {
                                    if (charLast == '?' || charLast == '#')
                                    {
                                        break;
                                    }
                                    if (charLast != '\'' && charLast != '\"')
                                    {

                                        if (charLast <= 'A' && charLast >= 'Z')
                                        {
                                            sbExt.Append(FasterToLower(charLast));
                                        }
                                        else
                                        {
                                            sbExt.Append(charLast);
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            if (sbExt.Length > 0)
                            {
                                strExtention = sbExt.ToString();
                                switch (strExtention)
                                {
                                    case ".ttf":
                                        ___formatType = CSSFontFaceFormatType.TrueType;
                                        break;
                                    case ".eot":
                                        ___formatType = CSSFontFaceFormatType.Embedded_OpenType;
                                        break;
                                    case ".otf":
                                        ___formatType = CSSFontFaceFormatType.OpenType;
                                        break;
                                    case ".woff":
                                        ___formatType = CSSFontFaceFormatType.Woff10;
                                        break;
                                    case ".woff2":
                                        ___formatType = CSSFontFaceFormatType.Woff20;
                                        break;
                                    case ".svg":
                                        ___formatType = CSSFontFaceFormatType.Svg;
                                        break;
                                    case ".svgz":
                                        ___formatType = CSSFontFaceFormatType.Svgz;
                                        break;
                                    default:
                                        ___formatType = CSSFontFaceFormatType.NotSet;
                                        break;




                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {

                        commonLog.LogEntry("___createCSSFontFaceListEntry() Exception", ex);

                    }
                }


                if (string.IsNullOrEmpty(strUrl) == false)
                {
                    int innerStartPos = 0;
                    int subLen = 0;
                    if (strUrl[0] == '\'' || strUrl[0] == '\"')
                    {
                        innerStartPos = 1;
                    }
                    else if (strUrl[0] == 'u' && strUrl[1] == 'r' && strUrl[2] == 'l')
                    {
                        innerStartPos = 4;
                    }
                    if (strUrl[strUrl.Length - 1] == '\'' || strUrl[strUrl.Length - 1] == '\"')
                    {
                        subLen = strUrl.Length - 2;
                    }
                    strUrl = strUrl.Substring(innerStartPos, subLen);
                    if (strUrl.StartsWith("http:", StringComparison.Ordinal) == false && strUrl.StartsWith("https:", StringComparison.Ordinal) == false)
                    {
                        strUrl = GetAbsoluteUri(___baseUrl, "", strUrl);
                    }

                    result[___formatType] = strUrl;
                }
            }

        }
        public static CSSFontFaceFormatType ___getCSSFormatTypeFromString(string format)
        {
            switch (format)
            {
                case "truetype":
                case "TrueType":
                case "true-type":
                    return CSSFontFaceFormatType.TrueType;
                case "woff":
                case "Woff":
                case "WOFF":
                    return CSSFontFaceFormatType.Woff10;
                case "woff2":
                case "Woff2":
                case "WOFF2":
                case "woff20":
                case "Woff20":
                case "WOFF20":
                    return CSSFontFaceFormatType.Woff20;
                case "embedded-opentype":
                    return CSSFontFaceFormatType.Embedded_OpenType;
                case "opentype":
                    return CSSFontFaceFormatType.OpenType;
                case "eot":
                    return CSSFontFaceFormatType.Embedded_OpenType;
                case "svg":
                case "Svg":
                case "SVG":
                    return CSSFontFaceFormatType.Svg;
                case "svgz":
                case "Svgz":
                case "SVGZ":
                    return CSSFontFaceFormatType.Svgz;
            }
            return CSSFontFaceFormatType.NotSet;
        }

        public static CHtmlCSSRule.CSSRuleType getCSSRuleTypeFromString(string str)
        {
            switch (str)
            {
                case "":
                    return CHtmlCSSRule.CSSRuleType.Style_Rule;
                case "@import":
                case "@Import":
                case "@IMPORT":
                case "@IMport":
                    return CHtmlCSSRule.CSSRuleType.Import_Rule;
                case "@font-face":
                case "@FontSpec-Face":
                case "@FONT-FACE":
                case "@FONT-Face":
                    return CHtmlCSSRule.CSSRuleType.Font_Face_Rule;
                case "@view-port":
                case "@View-port":
                case "@View-Port":
                case "@VIEW-PORT":
                case "@viewport":
                case "@-ms-viewport":
                case "@-o-viewport":
                case "@-webkit-viewport":
                case "@-moz-viewport":
                case "@ms-viewport":
                case "@o-viewport":
                case "@webkit-viewport":
                case "@moz-viewport":
                    return CHtmlCSSRule.CSSRuleType.Viewport_Rule;
                case "@region":
                case "@Region":
                case "@REGION":
                    return CHtmlCSSRule.CSSRuleType.Region_Style_Rule;

                case "@Keyframe":
                case "@keyframe":
                case "@KEYFRAME":
                case "@-o-keyframe":
                case "@-ms-keyframe":
                case "@-webkit-keyframe":
                case "@-Webkit-keyframe":
                case "@-moz-keyframe":
                    return CHtmlCSSRule.CSSRuleType.Keyframe_Rule;
                case "@keyframes":
                case "@Keyframes":
                case "@KEYFRAMES":
                case "@-o-keyframes":
                case "@-ms-keyframes":
                case "@-webkit-keyframes":
                case "@-Webkit-keyframes":
                case "@-moz-keyframes":
                    return CHtmlCSSRule.CSSRuleType.Keyframes_Rule;
                case "@Page":
                case "@PAGE":
                case "@page":
                    return CHtmlCSSRule.CSSRuleType.Page_Rule;
                case "@supports":
                case "@Supports":
                case "@SUPPORTS":
                    return CHtmlCSSRule.CSSRuleType.Supports_Rule;
                case "@namespace":
                case "@Namespace":
                case "@NAMESPACE":
                    return CHtmlCSSRule.CSSRuleType.Namespace_Rule;
                case "@media":
                case "@Media":
                case "@MEDIA":
                    return CHtmlCSSRule.CSSRuleType.Media_Rule;
                case "@document":
                case "@Document":
                case "@DOCUMENT":
                case "@-moz-document":
                case "@-ms-document":
                case "@-webkit-document":
                case "@-o-document":
                    return CHtmlCSSRule.CSSRuleType.Document_Rule;
                case "@counter":
                case "@Counter":
                case "@COUNTER":
                    return CHtmlCSSRule.CSSRuleType.Counter_Style_Rule;
                case "@CHARSET":
                case "@charset":
                case "@Charset":
                    return CHtmlCSSRule.CSSRuleType.Charset_Rule;

            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                if (string.IsNullOrEmpty(str) == false)
                {
                    commonLog.LogEntry("Unknown CSS Header Type: {0}", str);
                }
            }
            return CHtmlCSSRule.CSSRuleType.Style_Rule;
        }

        public static void CreateStyleValueEntry(string _key, string _value, System.Collections.Generic.List<CHtmlStyleAttribute?> arList, bool ___isImportant)
        {
            CHtmlStyleAttribute styleValue = new CHtmlStyleAttribute();
            styleValue.IsImportant = ___isImportant;
            styleValue.IsValid = true;
            styleValue.Name = _key;
            styleValue.attributeType = CHtmlStyleAttribute.GetStyleAttributeType(_key);
            bool __MakeValueLow = false;
            if (StyleElementFieldsCaseSensitveSortedList.ContainsKey(_key) == false)
            {
                __MakeValueLow = true;
            }
            //int __valueHack = -1;
            int valueLen = _value.Length;
            if (valueLen >= 3 && _value[valueLen - 1] == '/')
            {
                if (_value[valueLen - 2] == '0')
                {
                    if (_value[valueLen - 3] == '\\')
                    {
                        _value = _value.Substring(0, valueLen - 3);
                    }
                    if (_value.Length != 0)
                    {
                        if (IsCharWhiteSpaceLimited(_value[_value.Length - 1]) == true)
                        {
                            int wend = -1;
                            for (int wpos = _value.Length - 1; wpos >= 0; wpos--)
                            {
                                if (IsCharWhiteSpaceLimited(_value[wpos]) == true)
                                {
                                    wend = wpos;
                                    continue;

                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (wend != -1)
                            {
                                _value = _value.Substring(0, wend);
                            }
                        }
                    }
                }
                // __valueHack = _value.LastIndexOf("\\0/", StringComparison.OrdinalIgnoreCase);
            }
            /*
			if(__valueHack > -1)
			{
				// there is some case "margin-bottom:5px\0/;"
				_value = _value.Substring(0, __valueHack);
				if(_value.Length == 0)
					return;
			}
             */
            if (StyleElementFieldsNumericCheckSortedList.ContainsKey(_key) == true)
            {
                __MakeValueLow = true;
                // numeric value must have unit assigned. If not, it invalid.
                if (_value.Length == 0)
                {
                    styleValue.IsValid = false;
                }
                else
                {
                    char c0 = _value[0];
                    char clast = _value[_value.Length - 1];

                    if ((c0 >= '0' && c0 <= '9') || c0 == '-' || c0 == '.')
                    {
                        styleValue.IsNumber = true;
                        if (char.IsLetter(clast) == false && clast != '%')
                        {
                            styleValue.IsValid = false;
                        }
                    }
                    else
                    {
                        styleValue.IsNumber = false;
                    }
                }
            }
            else
            {

                if (_key.Length > 0)
                {
                    char c0 = _key[0];
                    switch (c0)
                    {
                        case '*':
                        case '_':
                            styleValue.HackType = CSSHackType.IE;
                            break;
                        case '#':
                            styleValue.HackType = CSSHackType.Firefox;
                            break;
                    }

                }

            }
            if (__MakeValueLow == false)
            {
                styleValue.value = _value;
            }
            else
            {
                styleValue.value = FasterToLower(_value);
            }
            arList.Add(styleValue);
        }
        public static System.Collections.Generic.List<string> GetSelectorIDSplit(string _s)
        {
            System.Collections.Generic.List<string> arList = new System.Collections.Generic.List<string>();
            System.Text.StringBuilder sbSelector = new StringBuilder();
            char[] _cs = _s.ToCharArray();
            bool _IsQuotedMark = false;
            int _csLen = _cs.Length;
            char c = '\0';
            for (int i = 0; i < _csLen; i++)
            {
                c = _cs[i];
                switch (c)
                {
                    case ',':
                        if (_IsQuotedMark == false)
                        {
                            arList.Add(sbSelector.ToString());
                            sbSelector = null;
                            sbSelector = new StringBuilder();
                        }
                        else
                        {
                            sbSelector.Append(c);
                        }
                        break;
                    case '(':
                    case ')':
                        _IsQuotedMark = !_IsQuotedMark;
                        sbSelector.Append(c);
                        break;
                    default:
                        sbSelector.Append(c);
                        break;
                }
            }
            if (sbSelector != null && sbSelector.Length > 0)
            {
                arList.Add(sbSelector.ToString());
            }
            return arList;
        }
        public static string GetYFromBool(bool b)
        {
            if (b)
            {
                return "Y";
            }
            return "-";
        }
        public static void VerifyStyleNameAndValue(ref System.Text.StringBuilder sbName, ref System.Text.StringBuilder sbValue, ref bool IsImportant)
        {
            IsImportant = false;
            if (sbName.Length == 0)
                return;
            try
            {
                if (char.IsLetter(sbName[0]) == false)
                {
                    while (true)
                    {
                        if (sbName.Length > 0 && (Array.IndexOf(TrimChars, sbName[0]) > -1))
                        {
                            sbName.Remove(0, 1);
                        }
                        else
                        {
                            if (sbName.Length > 0 && sbName[0] == '/')
                            {
                                sbName.Remove(0, 1);
                                if (sbName.Length > 0 && sbName[0] == '/')
                                {
                                    sbName.Remove(0, 1);
                                }
                            }
                            break;
                        }
                    }
                }
                if (sbName.Length == 0)
                    return;
                char nameC0 = sbName[0];

                switch (nameC0)
                {
                    case '-':
                        string rName = sbName.ToString();
                        char nameC1 = '\0';
                        if (sbName.Length > 0)
                        {
                            nameC1 = sbName[1];
                        }
                        switch (nameC1)
                        {
                            case 'm':
                                if (rName.StartsWith("-moz-", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    sbName.Remove(0, 5);
                                }
                                else if (rName.StartsWith("-ms-", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    sbName.Remove(0, 4);
                                }
                                break;
                            case 'o':
                                if (rName.StartsWith("-o-", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    sbName.Remove(0, 3);
                                }
                                break;
                            case 'w':
                                if (rName.StartsWith("-webkit-", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    sbName.Remove(0, 8);
                                }
                                break;
                            case 'k':
                                if (rName.StartsWith("-khtml-", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    sbName.Remove(0, 7);
                                }
                                break;
                        }
                        break;

                    // IE Hack will be kept as is.
                    //	case '*':
                    //	case '#':
                    //	case '_':
                    //		sbName.Remove(0,1);
                    //		break;
                    default:

                        if (sbName.Length > 6 && sbName[0] == 'w')
                        {
                            string wName = sbName.ToString();
                            if (wName.StartsWith("webkit", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                sbName.Remove(0, 6);
                            }
                        }
                        break;
                }
                if (sbValue.Length == 0)
                    return;
                if (char.IsLetter(sbValue[0]) == false)
                {
                    while (sbValue.Length > 0 && (Array.IndexOf(TrimChars, sbValue[0]) > -1))
                    {
                        sbValue.Remove(0, 1);
                    }
                    if (sbValue.Length == 0)
                    {
                        return;
                    }
                }
                char valueC0 = sbValue[0];
                switch (valueC0)
                {
                    case '-':
                        string rValue = sbValue.ToString();
                        char valueC1 = '\0';
                        if (sbValue.Length > 2)
                        {
                            valueC1 = sbValue[1];
                        }
                        switch (valueC1)
                        {
                            case 'm':
                                if (rValue.StartsWith("-moz-", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    sbValue.Remove(0, 5);
                                }
                                else if (rValue.StartsWith("-ms-", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    sbValue.Remove(0, 4);
                                }
                                break;
                            case 'o':
                                if (rValue.StartsWith("-o-", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    sbValue.Remove(0, 3);
                                }
                                break;

                            case 'w':
                                if (rValue.StartsWith("-webkit-", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    sbValue.Remove(0, 8);
                                }
                                break;
                            case 'k':
                                if (rValue.StartsWith("-khtml-", StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    sbValue.Remove(0, 7);
                                }
                                break;
                        }
                        break;
                    default:
                        break;
                }
                // 'remove !important 
                int sbValueNen2 = sbValue.Length;
                for (int i = 0; i < sbValueNen2; i++)
                {
                    if (sbValue[i] == '!')
                    {


                        if (i < sbValueNen2 - 2)
                        {
                            char charAfter1 = sbValue[i + 1];
                            char charAfter2 = sbValue[i + 2];
                            if (charAfter1 >= 'A' && charAfter1 <= 'Z')
                            {
                                charAfter1 = FasterToLower(charAfter1);
                            }
                            if (charAfter2 >= 'A' && charAfter2 <= 'Z')
                            {
                                charAfter2 = FasterToLower(charAfter2);
                            }
                            if (i < sbValueNen2 - 3)
                            {
                                if (charAfter1 == 'i' && charAfter2 == 'm' && char.ToLower(sbValue[i + 3]) == 'p')
                                {
                                    IsImportant = true;
                                    sbValue.Remove(i, sbValue.Length - i);
                                    break;
                                }
                            }
                            else if (i < sbValueNen2 - 2)
                            {
                                if (charAfter1 == 'i' && charAfter2 == 'e')
                                {
                                    sbValue.Remove(i, sbValue.Length - i);
                                    break;
                                }

                            }
                        }

                    }
                }
                sbValueNen2 = sbValue.Length;
            RemoveEndingWhiteSpace:
                while (true)
                {
                    if (sbValue.Length > 0 && (Array.IndexOf(TrimChars, sbValue[sbValue.Length - 1]) > -1))
                    {
                        sbValue.Remove(sbValue.Length - 1, 1);
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                if (sbValue.Length > 1 && sbValue[sbValue.Length - 2] == '\\' && sbValue[sbValue.Length - 1] == '9')
                {
                    // Note) Important
                    // Some Style Sheet can be end with \9
                    // ex. html>/**/body {font-size /*\**/: small\9 }
                    sbValue.Remove(sbValue.Length - 2, 2);
                    goto RemoveEndingWhiteSpace;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("VerifyStyleNameAndValue", ex);
                }
            }
        }

        public static bool IsNameResolutionFailureException(System.Exception ex)
        {
            if (ex is System.Net.WebException)
            {
                System.Net.WebException webex = ex as System.Net.WebException;
                switch (webex.Status.ToString())
                {
                    case "NameResolutionFailure":
                        return true;
                }
            }
            return false;
        }





        internal static System.Threading.AutoResetEvent CreateRegisterResetEvent(bool __initialState)
        {
            System.Threading.AutoResetEvent evt = new System.Threading.AutoResetEvent(__initialState);

            if (System.Environment.Version.Major >= 2)
            {
                object ___LockingObject = new object();

                try
                {
                    Microsoft.Win32.SafeHandles.SafeWaitHandle __objSafeHandle = null;

                    __objSafeHandle = evt.SafeWaitHandle;

                    if (__objSafeHandle != null)
                    {
                        bool _enter = false;
                        if (System.Threading.Monitor.TryEnter(___LockingObject, 1000))
                        {
                            _enter = true;
                            try
                            {
                                SafeWaitHandleWeakReferenceList.Add(new System.WeakReference(__objSafeHandle));
                            }
                            finally
                            {
                                if (_enter == true)
                                {

                                    System.Threading.Monitor.Exit(___LockingObject);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                        commonLog.LogEntry("Unable to obtain SafeWaitHandle", ex);
                    }
                }

            }
            if (evt != null)
            {
                //commonSafeManualRetEventList.Add(evt);
            }

            return evt;
        }

        public static void ReleaseSafeWaitHandleFromList()
        {
            if (System.Environment.Version.Major < 2)
                return;
            int ___CurrentSafeWaitHandleCount = SafeWaitHandleWeakReferenceList.Count;
            int ___InvalidCount = 0;
            int ___OpenCount = 0;
            int ___DisposedCount = 0;
            int ___RemovedCount = 0;
            System.IntPtr ___actualHandle = IntPtr.Zero;
            object ___LockingObject = new object();
            bool ___IsLocked = false;
            if (System.Threading.Monitor.TryEnter(___LockingObject, 1000))
            {
                ___IsLocked = true;
                try
                {
                    Microsoft.Win32.SafeHandles.SafeWaitHandle __objSafeHandle = null;

                    for (int i = ___CurrentSafeWaitHandleCount - 1; i >= 0; i--)
                    {
                        WeakReference __objectSafeWeakRefence = SafeWaitHandleWeakReferenceList[i];

                        try
                        {
                            if (__objectSafeWeakRefence != null)
                            {
                                __objSafeHandle = __objectSafeWeakRefence.Target as Microsoft.Win32.SafeHandles.SafeWaitHandle;

                                // 概要:
                                //     ハンドルが無効かどうかを示す値を取得します。
                                //
                                // 戻り値:
                                //     ハンドルが無効な場合は true。それ以外の場合は false。
                                bool ___IsInvalid = __objSafeHandle.IsInvalid;
                                if (___IsInvalid)
                                {
                                    ___InvalidCount++;
                                }
                                bool ___IsClosed = __objSafeHandle.IsClosed;
                                {
                                    ___OpenCount++;
                                }
                                ___actualHandle = IntPtr.Zero;
                                /*
                                ___actualHandle = (System.IntPtr)__objSafeHandle.GetType().InvokeMember("DangerousGetHandle",  System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.InvokeMethod| System.Reflection.BindingFlags.Instance, null, __objSafeHandle,null);
                                */

                                int ___hash = __objSafeHandle.GetHashCode();
                                if (___IsInvalid == false)
                                {


                                    if (___IsClosed == false)
                                    {
                                        __objSafeHandle.Close();
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                        {
                                            commonLog.LogEntry("SafeWaitHandle {0} Closed  at {1}...", ___hash, i);
                                        }

                                    }


                                    __objSafeHandle.Dispose();

                                    //__objSafeHandle.GetType().InvokeMember("SetHandleAsInvalid",  System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.InvokeMethod| System.Reflection.BindingFlags.Instance, null, __objSafeHandle,null);
                                    __objSafeHandle.SetHandleAsInvalid();

                                    //commonSafeWaitHandleList.RemoveAt(i);
                                    if (___IsClosed == true)
                                    {

                                    }
                                    ___DisposedCount++;
                                    // =======================================================
                                    // To Make sure to be invalid. do not remove now.
                                    // =======================================================
                                    if (___IsClosed == false)
                                    {
                                        //commonSafeWaitHandleWeakReferenceList[i] = __objSafeHandle;
                                    }
                                    else
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                        {
                                            commonLog.LogEntry("SafeWaitHandle {0} Disposed and Removed at {1}...", ___hash, i);
                                        }

                                        if (__objSafeHandle != null)
                                        {
                                            __objSafeHandle = null;
                                        }
                                        SafeWaitHandleWeakReferenceList.RemoveAt(i);
                                    }

                                }
                                else
                                {
                                    if (__objSafeHandle != null)
                                    {
                                        __objSafeHandle = null;
                                    }
                                    SafeWaitHandleWeakReferenceList.RemoveAt(i);
                                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                    {
                                        commonLog.LogEntry("SafeWaitHandle {0} is Invalid, Removed at {1}...", ___hash, i);
                                    }

                                    ___RemovedCount++;

                                }


                            }
                            else
                            {

                                ___RemovedCount++;
                                SafeWaitHandleWeakReferenceList.RemoveAt(i);
                            }
                        }
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                            {
                                commonLog.LogEntry("ReleaseSafeWaitHandle Error : " + i.ToString(), ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                        commonLog.LogEntry("ReleaseSafeWaitHandle Error : ", ex);
                    }
                }
                finally
                {
                    if (___IsLocked)
                    {
                        System.Threading.Monitor.Exit(___LockingObject);
                    }
                }
            }
            if (___CurrentSafeWaitHandleCount > -1)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("ReleaseSafeWaitHandleFromList Disposed : {0} Removed : {1} Out Of (I:{2} O: {3} ALL:{4})", ___DisposedCount, ___RemovedCount, ___InvalidCount, ___OpenCount, ___CurrentSafeWaitHandleCount);
                }
            }
        }
        public static string GetHtmlStaticCharsetInMemorySteam(System.IO.MemoryStream ___memoryStream)
        {
            DateTime __dtStart = DateTime.Now;
            ___memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
            byte[] byteHead = new byte[___memoryStream.Length];
            int read = ___memoryStream.Read(byteHead, 0, (int)___memoryStream.Length);
            string _charset = "";
            int byteHeadLen = byteHead.Length;
            for (int i = 0; i < byteHeadLen - 5; i++)
            {
                try
                {
                    byte b = byteHead[i];
                    if (b == 0x3c)
                    {
                        char c1 = (char)byteHead[i + 1];
                        char c2 = (char)byteHead[i + 2];
                        char c3 = (char)byteHead[i + 3];
                        char c4 = (char)byteHead[i + 4];
                        if (c1 >= 'A' && c1 <= 'Z')
                        {
                            c1 = FasterToLower(c1);
                        }
                        if (c2 >= 'A' && c2 <= 'Z')
                        {
                            c2 = FasterToLower(c2);
                        }
                        if (c3 >= 'A' && c3 <= 'Z')
                        {
                            c3 = FasterToLower(c3);
                        }
                        if (c4 >= 'A' && c4 <= 'Z')
                        {
                            c4 = FasterToLower(c4);
                        }
                        if (c1 == 'm' && c2 == 'e' && c3 == 't' && c4 == 'a')
                        {
                            System.Text.StringBuilder __sbLine = new StringBuilder();
                            for (int w = i + 6; w < byteHeadLen - 5; w++)
                            {
                                byte eb = (byte)byteHead[w];
                                if (eb == 0x3e)
                                {
                                    __sbLine.Replace("\r", " ");
                                    __sbLine.Replace("\n", " ");

                                    string sLine = FasterToLower(__sbLine.ToString());
                                    int icharset = sLine.IndexOf("charset", StringComparison.OrdinalIgnoreCase);
                                    if (icharset > -1)
                                    {
                                        string _charsetLine = sLine.Substring(icharset + 7);
                                        char[] cpCharset = _charsetLine.ToCharArray();
                                        System.Text.StringBuilder sbCharset = new StringBuilder();
                                        int cpCharsetLength = cpCharset.Length;
                                        for (int ci = 0; ci < cpCharsetLength; ci++)
                                        {
                                            char c = cpCharset[ci];
                                            if (c != ' ' && c != '\"')
                                            {
                                                if (c != '=')
                                                {
                                                    sbCharset.Append(c);
                                                }
                                            }
                                            else
                                            {
                                                if (sbCharset.Length > 2)
                                                {
                                                    break;
                                                }
                                            }
                                        }

                                        //"charset=utf-8\" http-equiv=\"content-type\"/"
                                        _charset = commonData.GetCharsetFromHTMLCharset(sbCharset.ToString());
                                        goto MergeMemoryStreamIntoHtmlBuilder;



                                    }
                                    else
                                    {
                                        __sbLine = null;
                                        goto NextLine;
                                    }

                                }
                                else
                                {
                                    __sbLine.Append((char)eb);
                                }
                            }


                        }

                    }
                NextLine:
                    if (true) { }
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                        commonLog.LogEntry("DetectCharsetInMemoryStream()", ex);
                    }
                }
            }
        MergeMemoryStreamIntoHtmlBuilder:




            return _charset;
        }
        internal static string EasyEscape(string s, System.Text.Encoding enc)
        {
            StringBuilder rt = new StringBuilder();
            foreach (byte i in enc.GetBytes(s))
                if (i == 0x20)
                {
                    rt.Append('%'); rt.Append("20");
                }
                else if (i >= 0x30 && i <= 0x39 || i >= 0x41 && i <= 0x5a || i >= 0x61 && i <= 0x7a)
                    rt.Append((char)i);
                else
                    rt.Append("%" + i.ToString("X2"));
            return rt.ToString();
        }
        internal static string EasyUnescape(string str, System.Text.Encoding enc)
        {
            if (str == null)
                return "";

            StringBuilder sb = new StringBuilder();
            int len = str.Length;
            int i = 0;
            while (i != len)
            {
                if (Uri.IsHexEncoding(str, i))
                    sb.Append(Uri.HexUnescape(str, ref i));
                else
                    sb.Append(str[i++]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// check if element can generate CSSStyleheet object
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        internal static bool isElementCanGenerateCSSStylesheetObject(CHtmlElement elem)
        {
            if (elem.___elementTagType == CHtmlElementType.STYLE)
            {
                return true;
            }
            else if (elem.___elementTagType == CHtmlElementType.LINK)
            {
                bool isTypeCorrect = false;
                bool isRelStyleSheet = false;
                if (string.IsNullOrEmpty(elem.___type) == false && string.Equals(elem.___type, "text/css", StringComparison.OrdinalIgnoreCase) == true)
                {
                    isTypeCorrect = true;
                }
                if (elem.___attributes.ContainsKey("rel"))
                {
                    string strRel = GetElementAttributeInString(elem, "rel");
                    if (strRel.Length != 0)
                    {
                        if (string.Equals(strRel, "stylesheet", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            isRelStyleSheet = true;
                        }
                        else if (string.Equals(strRel, "alternate", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            isRelStyleSheet = false;
                        }
                    }
                }
                if (isRelStyleSheet == true && isTypeCorrect)
                {
                    return true;
                }
            }

            return false;
        }
        public static bool IsScriptUrl(string _urlString)
        {

            if (_urlString.StartsWith("javascript:", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (_urlString.IndexOf('(') > 0 && _urlString.IndexOf(')') > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsEqualColor(ref System.Drawing.Color c1, ref System.Drawing.Color c2)
        {
            if (c1.R != c2.R)
                return false;
            if (c1.G != c2.G)
            {
                return false;
            }
            if (c1.B != c2.B)
            {
                return false;
            }
            if (c1.A != c2.A)
            {
                return false;
            }
            return true;
        }
        public static bool IsEqualColor(ColorSpec c1, ColorSpec c2)
        {
            if (c1.R != c2.R)
                return false;
            if (c1.G != c2.G)
            {
                return false;
            }
            if (c1.B != c2.B)
            {
                return false;
            }
            if (c1.A != c2.A)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Create Object Name List. Case Sensitive
        /// </summary>
        /// <param name="__objectType"></param>
        /// <returns></returns>
        internal static System.Collections.Generic.Dictionary<string, int> GetObjectPropertyAndMethods(Type __objectType)
        {
            System.Collections.Generic.Dictionary<string, int> _sr = new System.Collections.Generic.Dictionary<string, int>(StringComparer.Ordinal);
            if (__objectType != null)
            {
                foreach (System.Reflection.PropertyInfo pInfo in __objectType.GetProperties())
                {
                    _sr[pInfo.Name] = 1;
                }
                foreach (System.Reflection.MethodInfo mInfo in __objectType.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
                {
                    if (mInfo.IsSpecialName == false)
                    {
                        _sr[mInfo.Name] = 1;
                    }
                }
                foreach (System.Reflection.FieldInfo fInfo in __objectType.GetFields())
                {
                    if (fInfo.Name.Length > 0 && fInfo.Name[0] == '_')
                    {
                        continue;
                    }
                    if (commonLog.LoggingEnabled && commonLog.LogLevel > 30)
                    {
                        commonLog.LogEntry("Object({0}) ___hasInner public Field of {1} Type : {2}. is t ok?", __objectType, fInfo.Name, fInfo.FieldType);

                    }
                    _sr[fInfo.Name] = 1;
                }
            }

            return _sr;
        }
        internal static System.Collections.Generic.Dictionary<string, int> GetObjectPropertyNames(Type __objectType)
        {
            System.Collections.Generic.Dictionary<string, int> _sr = new System.Collections.Generic.Dictionary<string, int>(StringComparer.Ordinal);
            if (__objectType != null)
            {
                foreach (System.Reflection.PropertyInfo pInfo in __objectType.GetProperties())
                {
                    _sr[pInfo.Name] = 1;
                }

                foreach (System.Reflection.FieldInfo fInfo in __objectType.GetFields())
                {
                    if (fInfo.Name.Length > 0 && fInfo.Name[0] == '_')
                    {
                        continue;
                    }
                    if (commonLog.LoggingEnabled && commonLog.LogLevel > 30)
                    {
                        commonLog.LogEntry("Object({0}) ___hasInner public Field of {1} Type : {2}. is t ok?", __objectType, fInfo.Name, fInfo.FieldType);

                    }
                    _sr[fInfo.Name] = 1;
                }
            }

            return _sr;
        }
        public static bool IsEqualColor(System.Drawing.Color c1, System.Drawing.Color c2)
        {
            if (c1.R != c2.R)
                return false;
            if (c1.G != c2.G)
            {
                return false;
            }
            if (c1.B != c2.B)
            {
                return false;
            }
            if (c1.A != c2.A)
            {
                return false;
            }
            return true;
        }
        public static string GetScriptVerbRemovingJavaScriptString(string _originalScript)
        {

            if (_originalScript.Length > 10 && _originalScript.StartsWith("javascript:", StringComparison.OrdinalIgnoreCase))
            {
                _originalScript = _originalScript.Remove(0, 11);
            }
            return _originalScript.TrimEnd(null);
        }
        public static bool IsChildrenElementContainsFloatOrClear(CHtmlElement parentElement)
        {
            if (parentElement == null)
                return false;
            int parentElementChildNodesCount = parentElement.___childNodes.Count;
            for (int i = 0; i < parentElementChildNodesCount; i++)
            {
                CHtmlElement cElement = parentElement.___childNodes[i] as CHtmlElement;
                if (cElement != null)
                {
                    if (cElement.___IsElementClear == true)
                    {
                        return true;
                    }
                    if (cElement.___IsElementFloat == true)
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        public static bool IsBlockElement(CHtmlElement element)
        {
            if (element.___style != null)
            {
                if (string.Equals(element.___style.___Display, "inherit", StringComparison.OrdinalIgnoreCase) == true)
                {
                    if (element.___parentWeakRef != null)
                    {

                        element.___style.___Display = element.___getParentElement().___style.___Display;
                    }
                    else
                    {
                        element.___style.___Display = "";
                    }
                }
                switch (element.___style.___Display)
                {
                    case "":
                    case "none":
                        break;
                    case "inline":
                        return false;
                    /* Inlie-box is block element*/
                    case "-moz-inline-box":
                    case "-ms-inline-box":
                    case "inline-box":
                    case "inlinebox":
                    case "-inline-box":
                        return true;
                    case "block":
                    case "list-item":
                        return true;
                    case "inline-block":
                    case "inline-stack":
                        // inline-block should treat elements as block element
                        return true;
                    case "inline-table":
                    case "table":
                    case "table-cell":
                        return true;
                    case "box":
                    case "flex":
                    case "flex-box":
                        return true;
                    case "ruby-text":
                        return false;
                    case "table-row":
                    case "grid":
                    case "inline-grid":
                        return true;
                    default:
                        if (commonLog.LogLevel >= 3)
                        {
                            if (string.IsNullOrEmpty(element.___style.___Display) == false)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                {
                                    commonLog.LogEntry("{0} ___hasInner unknown inline type : {1}", element, element.___style.Display);
                                }
                            }
                        }
                        break;
                }
            }
            if ((int)element.___elementTagType < 1000)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static void StringBuilderTrim(ref System.Text.StringBuilder sb)
        {
            if (sb.Length == 0)
                return;
            int sbLen = sb.Length;

            try
            {
                for (int i = 0; i < sbLen; i++)
                {
                    if (Array.IndexOf(TrimChars, sb[i]) > -1)
                    {
                        sb.Remove(i, 1);
                        sbLen = sb.Length;
                        i = i - 1;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                if (sbLen > 0)
                {

                    for (int i = sbLen - 1; i > Math.Max(sbLen - 30, 0); i--)
                    {
                        if (Array.IndexOf(TrimChars, sb[i]) > -1)
                        {
                            sb.Remove(i, 1);
                            sbLen = sb.Length;
                            //i = i + 1;
                            continue;
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 1)
                {
                    commonLog.LogEntry("StringBuilderTrim : " + sb.ToString(), ex);
                }
            }
        }
        public static bool IsStringBuilderStartWith(ref System.Text.StringBuilder sb, string _Text, bool RemoveAlso)
        {
            if (sb.Length == 0 || _Text.Length == 0)
            {
                return false;
            }
            try
            {
                char[] cs = _Text.ToCharArray();
                int csLen = cs.Length;
                int _HitCount = 0;
                for (int i = 0; i < csLen; i++)
                {
                    if (sb[i] == cs[i])
                    {
                        _HitCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (_HitCount == cs.Length)
                {
                    if (RemoveAlso)
                    {
                        sb.Remove(0, csLen);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("IsStringBuilderStartWith : " + sb.ToString() + " : " + _Text, ex);
                }
            }
            return false;
        }
        public static bool IsStringBuilderEndWith(ref System.Text.StringBuilder sb, string _Text, bool RemoveAlso)
        {
            if (sb.Length == 0 || _Text.Length == 0)
            {
                return false;
            }
            try
            {
                char[] cs = _Text.ToCharArray();
                int _HitCount = 0;
                int _csPos = 0;
                int sbLen = sb.Length;
                for (int i = sb.Length - cs.Length; i < sbLen; i++)
                {
                    if (sb[i] == cs[_csPos])
                    {
                        _HitCount++;
                    }
                    else
                    {
                        break;
                    }
                    _csPos++;
                }
                if (_HitCount == cs.Length)
                {
                    if (RemoveAlso)
                    {
                        sb.Remove(sb.Length - cs.Length, cs.Length);
                        sbLen = sb.Length;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("IsStringBuilderStartWith : " + sb.ToString() + " : " + _Text, ex);
                }
            }
            return false;
        }


        /// <summary>
        /// Replace CR [\r] only string to [\r\n] for JINT etc
        /// </summary>
        /// <param name="_s"></param>
        /// <returns></returns>
        public static string GetCRStringToCRLF(string _s)
        {
            System.Text.StringBuilder sb = new StringBuilder(_s);
            return GetCRStringToCRLF(ref sb);
        }
        public static string GetCRStringToCRLF(ref System.Text.StringBuilder sb)
        {
            char[] AtvXCs = new char[] { 'n', 'e', 'w', ' ', 'a', 'c', 't', 'i', 'v', 'e', 'x', 'o', 'b', 'j', 'e', 'c', 't' };
            char[] NewXCs = new char[] { 'M', 'S', 'F', 'T', 'A', 'c', 't', 'i', 'v', 'e', 'X', 'O', 'b', 'j', 'e', 'c', 't' };
            try
            {
                bool IsAjaxSupport = false;
                bool IsStrArea = false;
                char CommentStartChar = ' ';
                int PreviousLineSep = -1;
                /*
                if (commonMCS.MCSGeneralFdr != null)
                {
                    IsAjaxSupport = commonMCS.MCSGeneralFdr.EnableAJAXSupport;
                }
                */
                int sbLen = sb.Length;
                for (int i = 0; i < sbLen; i++)
                {
                    char c = sb[i];
                    if (c == ';')
                    {
                        PreviousLineSep = i;
                    }
                    else if (c == '/')
                    {
                        if (i < sb.Length - 2)
                        {
                            if (sb[i + 1] == '/')
                            {

                            }
                        }
                    }
                    else if (c == '\'' || c == '\"')
                    {
                        if (IsStrArea == false)
                        {
                            CommentStartChar = c;
                        }
                        else if (c == CommentStartChar)
                        {
                            IsStrArea = false;
                            CommentStartChar = ' ';
                        }
                    }
                    else if (c == '\r')
                    {
                        if (i < sb.Length - 1)
                        {
                            if (sb[i + 1] != '\n')
                            {
                                sb.Insert(i + 1, '\n');
                                i = i + 1;
                                continue;
                            }
                            else
                            {
                                /*
								// Immediate return original string
								if(IsAjaxSupport == false)
								{
									return _s;
								}
								*/
                            }
                        }
                    }
                    else if (c == '<' && IsStrArea == false)
                    {
                        int AllowCR = 3;
                        int CRCount = 0;
                        if (i > -1 && i + 6 < sb.Length)
                        {
                            if ((sb[i + 1] == '!') && (sb[i + 2] == '-') && (sb[i + 3] == '-'))
                            {
                                int sbLen3 = sb.Length;
                                for (int n = i + 4; n < sbLen3 - 3; n++)
                                {
                                    if ((sb[n] == '-') && (sb[n + 1] == '-') && (sb[n + 2] == '>'))
                                    {
                                        // the section may be in comment area?
                                        sb.Remove(i, n + 3 - i);
                                        i = n + 3;
                                        break;
                                    }
                                    if (sb[n] == '\r')
                                    {
                                        CRCount++;
                                        if (CRCount > AllowCR)
                                        {
                                            break;
                                        }
                                    }

                                }

                            }
                        }
                    }
                    else if (IsAjaxSupport && c == '(')
                    {
                        if (i >= AtvXCs.Length)
                        {
                            int BackPos = AtvXCs.Length - 1;
                            int HitCharCount = 0;
                            int iAtvCSLen1 = i - AtvXCs.Length - 1;
                            for (int a = i - 1; a > iAtvCSLen1; a--)
                            {
                                char bc = sb[a];
                                if (char.ToLower(bc) == AtvXCs[BackPos])
                                {
                                    HitCharCount++;
                                    if (BackPos == 0)
                                    {
                                        for (int r = a; r <= i - 1; r++)
                                        {
                                            sb[r] = NewXCs[r - a];
                                        }
                                        break;
                                    }
                                    BackPos--;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("GetCRStringToCRLF", ex);
                }
                return sb.ToString();
            }
        }

        public static bool IsUTF8BOM(byte b1, byte b2, byte b3)
        {


            if (b1 == 239 && b2 == 187 && b3 == 191)
            {
                return true;
            }

            return false;
        }
        public static string GetElementScriptLanguageLowerName(CHtmlElement element)
        {
            string scriptType = null;
            if (element == null)
            {
                return "";
            }
            if (element.___attributes.ContainsKey("type"))
            {
                scriptType = GetElementAttributeInString(element, "type");
            }
            if (string.IsNullOrEmpty(scriptType) == true)
            {
                scriptType = element.language;
            }
            if (string.IsNullOrEmpty(scriptType) == true)
            {
                scriptType = "";
            }
            if (scriptType.StartsWith("text/", StringComparison.OrdinalIgnoreCase) == true)
            {
                scriptType = scriptType.Remove(0, 5);
            }
            else if (scriptType.Length > 12 && scriptType.StartsWith("application/", StringComparison.OrdinalIgnoreCase) == true)
            {
                scriptType = scriptType.Remove(0, 12);
            }


            if (string.IsNullOrEmpty(scriptType) == true)
            {
                scriptType = "javascript";
            }
            if (element.___attributes.ContainsKey("language"))
            {
                scriptType = FasterToLower(GetElementAttributeInString(element, "language"));
            }
            // Drop Javascript Version number
            if (scriptType.Length >= 11 && scriptType.StartsWith("javascript", StringComparison.OrdinalIgnoreCase) == true)
            {
                scriptType = "javascript";
            }
            return scriptType;
        }


        /*
		internal static void CreateCHtmlParagraphForCHtmlElement( CHtmlElement element, System.Text.StringBuilder sb, int StartPos, int EndPos)
		{
			if(element == null)
				return;
			CHtmlParagraph para =new CHtmlParagraph();
			para.Text = sb.ToString();
			para.tagName = element.tagName;
			para.___elementTagType = element.___elementTagType;
			para.TagOpenStartPosition  = StartPos;
			para.TagOpenEndPosition = StartPos;
			para.TagCloseEndPosition = EndPos;
			para.TagCloseStartPosition = EndPos;
			element.InnerParagraphList.Add(para);
		}
		*/

        internal static string GetXMLEncodingStringFromBytes(byte[] bts)
        {
            int READ_LIMIT = 500;
            if (bts != null && bts.Length > 0)
            {
                for (int i = 0; i < READ_LIMIT; i++)
                {
                    if (i >= bts.Length)
                        break;
                    if (bts[i] == 0x65 || bts[i] == 0x45) // E or e
                    {
                        if (bts.Length > i + 8)
                        {
                            if (bts[i + 1] == 0x6e && bts[i + 2] == 0x63 && bts[i + 3] == 0x6f && bts[i + 4] == 0x64 && bts[i + 5] == 0x69 && bts[i + 6] == 0x6e && bts[i + 7] == 0x67)
                            {
                                // encoding is found ___getInner charset
                                string strCharset = null;
                                if (bts.Length > i + 24)
                                {
                                    strCharset = System.Text.Encoding.UTF8.GetString(bts, i + 8, 16);
                                }
                                else
                                {
                                    strCharset = System.Text.Encoding.UTF8.GetString(bts, i + 8, bts.Length - i - 8);
                                }
                                if (string.IsNullOrEmpty(strCharset) == false)
                                {
                                    char[] cs = strCharset.ToCharArray();
                                    int csLen = cs.Length;
                                    bool __isLetterOrDigitStarted = false;
                                    bool __isCharsetQuoted = false;
                                    System.Text.StringBuilder sbCharSet = new StringBuilder();
                                    for (int x = 0; x < csLen; x++)
                                    {
                                        char cc = cs[x];
                                        if (char.IsLetterOrDigit(cc) == true || cc == '-' || cc == '_')
                                        {
                                            if (__isLetterOrDigitStarted == false)
                                            {
                                                __isLetterOrDigitStarted = true;
                                            }
                                            sbCharSet.Append(cc);
                                        }
                                        else if (cc == '\'' || cc == '\"')
                                        {
                                            if (__isCharsetQuoted == false)
                                            {
                                                __isCharsetQuoted = true;
                                                continue;
                                            }
                                            if (sbCharSet.Length > 0)
                                            {
                                                break;
                                            }
                                        }
                                        else if (IsCharWhiteSpaceLimited(cc))
                                        {
                                            if (sbCharSet.Length > 0)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    return sbCharSet.ToString();
                                }
                            }
                        }
                    }
                }
            }
            return "";
        }
        internal static Type GetObjectType(ref object o)
        {
            if (o == null)
            {
                return null;
            }
            else
            {
                return o.GetType();
            }

        }
        internal static CHtmlFileType GetScriptTypeFromTypeString(string __scriptTypeString)
        {
            string sType = __scriptTypeString;
            switch (sType)
            {
                case "":
                case "javascript":
                case "jscript":
                case "text/javascript":
                case "text/jscript":
                    return CHtmlFileType.JavaScript;
                case "text/json":
                    return CHtmlFileType.Json;
                case "text/vbscript":
                case "vbscript":
                    return CHtmlFileType.VBScript;
                case "test/css":
                    return CHtmlFileType.Css;

            }
            return CHtmlFileType.JavaScript;
        }

        public static CHtmlCollection CreateCHtmlElementsFromHTML(string ___html)
        {

            CHtmlCollection rstElements = new CHtmlCollection();
            if (___html == null)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("CreateCHtmlElementsFromHTML SourceHTML was null");
                }
                return rstElements;
            }
            System.Text.StringBuilder sbHTML = new StringBuilder(___html);
            char cb2, cb1, c0, ca1, ca2, ca3;
            System.Text.StringBuilder sbName = null;
            System.Text.StringBuilder sbNameCaseSensitive = null;
            System.Text.StringBuilder sbAttribute = null;
            System.Text.StringBuilder sbText = new StringBuilder();
            CHtmlParseModeType curMode = CHtmlParseModeType.InnerText;
            CHtmlElement currentParent = null;
            int i = 0;
            int innerTextStartPos = 0;
            int ___TotalElements = 0;
            char QuoteStartChar = '\'';
            char QuoteStartEnd = '\'';
            if (QuoteStartEnd != '\0') {; }
            bool IsQuoting = false;
            int sbHTMLLen = sbHTML.Length;
            string __sbValue = null;
            for (i = 0; i < sbHTMLLen; i++)
            {
                cb2 = '\0';
                cb1 = '\0';
                ca1 = '\0';
                ca2 = '\0';
                ca3 = '\0';
                c0 = sbHTML[i];
                try
                {
                    if (i > 0)
                    {
                        cb1 = sbHTML[i - 1];
                    }
                    if (i > 1)
                    {
                        cb2 = sbHTML[i - 2];
                    }
                    if (i < sbHTML.Length - 1)
                    {
                        ca1 = sbHTML[i + 1];
                    }
                    if (i < sbHTML.Length - 2)
                    {
                        ca2 = sbHTML[i + 2];
                    }
                    if (i < sbHTML.Length - 3)
                    {
                        ca3 = sbHTML[i + 3];
                    }
                    switch (c0)
                    {
                        case '\'':
                        case '\"':
                            if (IsQuoting == false)
                            {
                                QuoteStartChar = c0;
                                IsQuoting = true;
                            }
                            else
                            {
                                if (c0 == QuoteStartChar && cb1 != '\\')
                                {
                                    IsQuoting = false;
                                }
                            }
                            break;
                        case '<':
                            if (IsQuoting == true)
                            {
                                break;
                            }
                            if (char.IsLetter(ca1) || ca1 == '/')
                            {
                                __sbValue = null;
                                if (sbText != null && sbText.Length > 0)
                                {
                                    if (IsCharWhiteSpaceLimited(sbText[0]) == true || IsCharWhiteSpaceLimited(sbText[sbText.Length - 1]) == true)
                                    {
                                        __sbValue = sbText.ToString().Trim();
                                    }
                                    else
                                    {
                                        __sbValue = sbText.ToString();
                                    }
                                    if (__sbValue.Length == 0)
                                    {
                                        goto InnerTextDone;
                                    }
                                    CHtmlTextElement tRange = new CHtmlTextElement();
                                    tRange.___SetTagNameOnly("#TEXT");

                                    tRange.value = __sbValue;
                                    tRange.___IsDynamicElement = true;
                                    if (currentParent != null)
                                    {
                                        tRange.parent = currentParent;
                                        tRange.___ChildNodeIndex = currentParent.___childNodes.Add(tRange);
                                    }
                                    else
                                    {
                                        rstElements.Add(tRange);
                                    }
                                }
                            InnerTextDone:


                                sbName = new StringBuilder();


                                sbNameCaseSensitive = new StringBuilder();
                                curMode = CHtmlParseModeType.TagName;
                                sbText = new StringBuilder();
                                continue;
                            }
                            else if (ca1 == '!' && ca2 == '-' && ca3 == '-')
                            {
                                int nextEnd = StringBuilderIndexOf(sbHTML, "-->", i, true, sbHTML.ToString());
                                if (nextEnd != -1)
                                {

                                    if (sbName != null)
                                    {
                                        string sTagName = sbName.ToString();
                                        switch (sTagName)
                                        {
                                            case "SCRIPT":
                                            case "STYLE":
                                                if (sbText == null)
                                                {
                                                    sbText = new StringBuilder();
                                                }
                                                // In This case Append Script Block in sbText
                                                for (int si = i + 4; si < nextEnd; si++)
                                                {
                                                    sbText.Append(sbHTML[si]);
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        // it seems normal comment
                                        CHtmlTextElement tRange = new CHtmlTextElement();
                                        tRange.___SetTagNameOnly("COMMENT");
                                        tRange.___elementTagType = CHtmlElementType.COMMENT;
                                        tRange.___IsElementVisible = false;
                                        tRange.___IsSystemHidden = true;
                                        tRange.value = GetStringOutofStringBuilder(sbHTML, i, nextEnd + 1);
                                        tRange.___IsDynamicElement = true;
                                        if (currentParent != null)
                                        {
                                            tRange.parent = currentParent;
                                            currentParent.___childNodes.Add(tRange);
                                        }
                                        else
                                        {
                                            rstElements.Add(tRange);
                                        }

                                    }
                                    i = nextEnd + 2;
                                    continue;
                                }
                            }
                            else if (ca1 == '!' || ca1 == '?')
                            {
                                if (ca1 == '?')
                                {
                                    int nextEnd = StringBuilderIndexOf(sbHTML, "?>", i, true, sbHTML.ToString());
                                    if (nextEnd != -1)
                                    {
                                        i = nextEnd + 1;
                                        continue;
                                    }

                                }
                                else
                                {
                                    int nextEnd = StringBuilderIndexOf(sbHTML, ">", i, true, sbHTML.ToString());
                                    i = nextEnd;
                                    continue;
                                }
                            }


                            continue;
                        case '>':
                            {
                                if (IsQuoting)
                                {
                                    break;
                                }
                                bool IsImmediateClose = false;
                                bool IsClose4Parent = false;
                                if (cb1 == '/' || (cb1 == ' ' && cb2 == '/'))
                                {
                                    // Immediate close
                                    IsImmediateClose = true;
                                }
                                else
                                {   // Normal Begin Tag Close
                                    IsImmediateClose = false;
                                }
                                if (sbName != null && sbName.Length > 0)
                                {
                                    if (sbName[sbName.Length - 1] == '/')
                                    {
                                        sbName.Remove(sbName.Length - 1, 1);
                                        sbNameCaseSensitive.Remove(sbNameCaseSensitive.Length - 1, 1);
                                        IsImmediateClose = true;
                                    }
                                    else if (sbName[0] == '/')
                                    {
                                        sbName.Remove(0, 1);
                                        sbNameCaseSensitive.Remove(0, 1);
                                        IsClose4Parent = true;
                                    }
                                }
                                CHtmlElement newElement = null;
                                if (IsClose4Parent == false)
                                {
                                    string ___tagNameUp = null;
                                    if (sbName != null)
                                    {
                                        ___tagNameUp = sbName.ToString();
                                    }
                                    else
                                    {
                                        ___tagNameUp = "DIV";
                                    }
                                    newElement = CHtmlDocument.createCHtmlElementWithDomType(___tagNameUp, CHtmlDomModeType.HTMLDOM, null);
                                    ___TotalElements++;
                                    newElement.___IsDynamicElement = true;
                                    newElement.tagName = ___tagNameUp;
                                    /*
                                    newElement.___elementTagType = commonGetTagNameType(newElement.tagName);
                                    */
                                    if (IsImmediateClose == false)
                                    {
                                        if (elementTagTypesCanEndWithNoSlashWithoutAnyFollowingInfoSortedList.ContainsKey(newElement.___elementTagType))
                                        {
                                            IsClose4Parent = false;
                                            IsImmediateClose = true;
                                        }
                                        if (IsImmediateClose == false)
                                        {
                                            // --------------------------------------------
                                            // Put Immediate Closing Tags
                                            // --------------------------------------------
                                            switch (newElement.___elementTagType)
                                            {
                                                case CHtmlElementType.IMG:
                                                case CHtmlElementType.PARAM:
                                                    IsClose4Parent = false;
                                                    IsImmediateClose = true;
                                                    break;
                                                case CHtmlElementType.STYLE:
                                                case CHtmlElementType.SCRIPT:
                                                    if (IsClose4Parent == false)
                                                    {
                                                        try
                                                        {
                                                            int __tagEndPos = ___html.IndexOf("</" + newElement.tagName, i + 1, StringComparison.OrdinalIgnoreCase);
                                                            if (__tagEndPos != -1)
                                                            {
                                                                // ok end postion found
                                                                // create 
                                                                CHtmlTextElement __textElement = new CHtmlTextElement();
                                                                __textElement.___IsDynamicElement = true;



                                                                string sInnerText = ___html.Substring(i + 1, __tagEndPos - i - 1);
                                                                __textElement.___parentWeakRef = new WeakReference(newElement, false);

                                                                __textElement.value = sInnerText;
                                                                __textElement.___ChildNodeIndex = newElement.___childNodes.Add(__textElement);
                                                                SetTextElementVisibilityForParentNode(__textElement, newElement);
                                                                IsClose4Parent = false;
                                                                IsImmediateClose = true;
                                                                int _EndingTagLen = 2 + newElement.tagName.Length;
                                                                i = __tagEndPos + _EndingTagLen;
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                                                            {
                                                                commonLog.LogEntry("CreateCHtmlElementsFromHTML parse InnerHTML", ex);

                                                            }
                                                        }
                                                    }
                                                    break;

                                            }
                                        }
                                    }

                                }
                                if (IsImmediateClose)
                                {
                                    newElement.___ClosedReson = CHtmlTagClosedReasonType.Direct;
                                }

                                if (newElement != null && sbAttribute != null && sbAttribute.Length > 0)
                                {
                                    try
                                    {
                                        newElement.___createElementAttributesFromString(ref sbAttribute);
                                    }
                                    catch (Exception ex)
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                        {
                                            commonLog.LogEntry("CreateAttributes", ex);
                                        }
                                    }
                                }
                                if (newElement != null && sbNameCaseSensitive != null && sbNameCaseSensitive.Length > 0)
                                {
                                    newElement.___createCaseSensitiveElementNames(sbNameCaseSensitive.ToString());
                                }
                                if (IsClose4Parent == false)
                                {
                                    if (currentParent == null)
                                    {
                                        if (IsImmediateClose == false)
                                        {
                                            currentParent = newElement;
                                            rstElements.Add(newElement);
                                        }
                                        else
                                        {
                                            rstElements.Add(newElement);
                                        }
                                        sbName = null;
                                        sbNameCaseSensitive = null;
                                        sbAttribute = null;
                                        curMode = CHtmlParseModeType.InnerText;
                                        sbText = null;
                                        sbText = new StringBuilder();
                                        innerTextStartPos = i;
                                        goto NextChar;
                                    }
                                    // ==============================================
                                    // Create parent child relationship
                                    // ==============================================
                                    newElement.parent = currentParent;
                                    // ==============================================
                                    newElement.___ChildNodeIndex = currentParent.___childNodes.Add(newElement);
                                    if (IsImmediateClose)
                                    {
                                        newElement.___ClosedReson = CHtmlTagClosedReasonType.EndSimple;
                                    }
                                }
                                else
                                {
                                    CHtmlElement LookUpElement = currentParent;
                                    bool IsParentTagFound = false;
                                    while (LookUpElement != null)
                                    {
                                        if (LookUpElement.tagName == sbName.ToString())
                                        {
                                            IsParentTagFound = true;
                                            break;
                                        }
                                        LookUpElement = LookUpElement.___getParentElement();
                                    }
                                    if (IsParentTagFound)
                                    {
                                        LookUpElement.___ClosedReson = CHtmlTagClosedReasonType.EndDeep;
                                        if (LookUpElement.parent != null)
                                        {
                                            currentParent = LookUpElement.___getParentElement();
                                        }
                                        else
                                        {
                                            if (sbText != null && sbText.Length > 0)
                                            {
                                                __sbValue = null;
                                                if (IsCharWhiteSpaceLimited(sbText[0]) == true || IsCharWhiteSpaceLimited(sbText[sbText.Length - 1]) == true)
                                                {
                                                    __sbValue = sbText.ToString().Trim();
                                                }
                                                else
                                                {
                                                    __sbValue = sbText.ToString();
                                                }
                                                if (string.IsNullOrEmpty(__sbValue) == true)
                                                {
                                                    goto InnerTextDone2;
                                                }
                                                CHtmlTextElement tRange = new CHtmlTextElement();
                                                tRange.___SetTagNameOnly("#TEXT");
                                                tRange.value = __sbValue;
                                                tRange.___IsDynamicElement = true;
                                                if (currentParent != null)
                                                {
                                                    tRange.parent = LookUpElement;
                                                    tRange.___ChildNodeIndex = LookUpElement.___childNodes.Add(tRange);
                                                    SetTextElementVisibilityForParentNode(tRange, LookUpElement);
                                                }
                                            }
                                        InnerTextDone2:
                                            currentParent = null;
                                            if (IsParentTagFound == false)
                                            {
                                                rstElements.Add(LookUpElement);
                                            }
                                        }
                                    }
                                }
                                if (IsImmediateClose == false)
                                {
                                    if (newElement != null && (newElement.___elementTagType == CHtmlElementType.SCRIPT || newElement.___elementTagType == CHtmlElementType.STYLE))
                                    {
                                        // Means Script or Style ___hasInner inner HTML
                                        // create inner Value at this point
                                        int tagEndPos = StringBuilderIndexOf(sbHTML, "</" + newElement.tagName + ">", i, true, ___html);
                                        if (tagEndPos > -1)
                                        {
                                            newElement.value = sbHTML.ToString(i + 1, tagEndPos - i - 1);
                                            i = tagEndPos + newElement.tagName.Length + 2;
                                            goto NextElement;
                                        }

                                    }
                                }
                                if (IsClose4Parent == false && IsImmediateClose == false)
                                {
                                    currentParent = newElement;
                                }
                            NextElement:
                                sbName = null;
                                sbNameCaseSensitive = null;
                                sbAttribute = null;
                                curMode = CHtmlParseModeType.InnerText;
                                sbText = null;
                                sbText = new StringBuilder();
                                innerTextStartPos = i;
                                continue;
                            }
                        case '&':
                            System.Text.StringBuilder sbSpecial = new StringBuilder();
                            sbSpecial.Append("&");
                            for (int ampnpos = i + 1; ampnpos < i + 16; ampnpos++)
                            {
                                if (ampnpos >= sbHTML.Length)
                                {
                                    break;
                                }
                                char ampnc = sbHTML[ampnpos];
                                if (ampnc == ' ' || ampnc == '&' || ampnc == '?' || ampnc == '=')
                                {
                                    break;
                                }
                                else if (ampnc == ';')
                                {
                                    sbSpecial.Append(ampnc);
                                    char resultc = GetHTMLCharStringHTMLString(sbSpecial.ToString(), '\0');
                                    if (resultc != '\0')
                                    {
                                        c0 = resultc;
                                        i = ampnpos;
                                        goto SwitchSection;
                                    }
                                    else
                                    {
                                        // Conversion fails just keep on
                                        goto SwitchSection;

                                    }

                                }
                                else
                                {
                                    sbSpecial.Append(ampnc);
                                }

                            }
                            break;
                        default:
                            break;
                    }
                SwitchSection:

                    switch (curMode)
                    {
                        case CHtmlParseModeType.TagName:
                            if (sbName != null)
                            {
                                if (IsCharWhiteSpaceLimited(c0))
                                {
                                    curMode = CHtmlParseModeType.TagAttribute;
                                    sbAttribute = null;
                                    sbAttribute = new StringBuilder();
                                    continue;
                                }
                                sbNameCaseSensitive.Append(c0);
                                if (c0 >= 'a' && c0 <= 'z')
                                {
                                    sbName.Append(FasterToUpper(c0));
                                }
                                else
                                {
                                    sbName.Append(c0);
                                }
                            }
                            break;
                        case CHtmlParseModeType.TagAttribute:
                            if (sbAttribute != null)
                            {
                                if (IsCharWhiteSpaceLimited(c0))
                                {
                                    c0 = ' ';
                                }
                                sbAttribute.Append(c0);
                            }
                            break;
                        case CHtmlParseModeType.InnerText:
                            if (sbText != null)
                            {
                                sbText.Append(c0);
                            }
                            break;
                    }
                NextChar:
                    if (true) { }
                    ;
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 1)
                    {
                        commonLog.LogEntry("CreateCHtmlElementsFromHTML Exception for processing \"" + ___html + "\"", ex);
                    }
                }
            }
            if (sbText != null && sbText.Length > 0)
            {
                string _TextContent = null;
                if (IsCharWhiteSpaceLimited(sbText[0]) == true || IsCharWhiteSpaceLimited(sbText[sbText.Length - 1]) == true)
                {
                    _TextContent = sbText.ToString().Trim();
                }
                else
                {
                    _TextContent = sbText.ToString();
                }
                if (_TextContent.Length != 0)
                {
                    CHtmlTextElement tRange = new CHtmlTextElement();
                    tRange.___SetTagNameOnly("#TEXT");
                    tRange.value = _TextContent;
                    tRange.___IsDynamicElement = true;
                    // We can"t judge if this text element should be visible or not at add time. so
                    // leave as is.
                    tRange.___IsElementVisible = true;
                    rstElements.Add(tRange);
                }
            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("CreateCHtmlElementsFromHTML {0} nodes created from \"{1}\"", ___TotalElements, ___html);
            }
            return rstElements;
        }
        public static void SetTextElementVisibilityForParentNode(CHtmlTextElement ___textElement, CHtmlElement ___parentElement)
        {
            if (___parentElement != null)

            {
                if (elementTagTypesNoInnerTextSortedList.ContainsKey(___parentElement.___elementTagType) == true)
                {
                    ___textElement.___IsElementVisible = false;
                }
                else
                {
                    ___textElement.___IsElementVisible = true;
                }
            }

        }
        /// <summary>
        /// Checks Element Can Trace up to root HTML element
        /// </summary>
        /// <param name="___element"></param>
        /// <returns></returns>
        public static bool IsElementParentChainConnectionIsHealty(CHtmlElement ___element)
        {
            if (___element == null || ___element.___parentWeakRef == null)
            {
                return false;
            }
            CHtmlElement ___parentElement = null;
            try
            {
                ___parentElement = ___element.___parent as CHtmlElement;
                while (___parentElement != null)
                {
                    if (___parentElement.___elementTagType == CHtmlElementType.HTML)
                    {
                        return true;
                    }
                    ___parentElement = ___parentElement.___parent as CHtmlElement;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("IsElementParentChainConnectionIsHealty", ex);
                }
            }
            if (___parentElement != null)
            {
                if (___parentElement.___elementTagType == CHtmlElementType.BODY)
                {
                    return true;
                }
            }
            return false;
        }

        internal static string GetStringOutofStringBuilder(System.Text.StringBuilder sb, int StartPos, int EndPos)
        {
            try
            {
                if (StartPos > sb.Length)
                    return "";
                if (EndPos < sb.Length)
                    return "";
                System.Text.StringBuilder sbOut = new StringBuilder();

                for (int i = StartPos; i < EndPos; i++)
                {
                    sbOut.Append(sb[i]);
                }

                return sbOut.ToString();

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("GetStringOutofStringBuilder", ex);
                }
            }
            return "";
        }
        /// <summary>
        /// This Methods does not wait to be fullfilled
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="__value"></param>
        /// <param name="startIndex"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>

        public static int StringBuilderIndexOf(StringBuilder sb, string __value, int startIndex, bool ignoreCase, string ___comleteText)
        {
            if (sb == null)
                return -1;

            string ___valueLow = "";
            if (ignoreCase)
            {
                ___valueLow = FasterToLower(__value);
            }
            try
            {
                /*
				if(commonUseStringBuilderIndexOf == true)
				{
					if(startIndex < 0)
					{
						startIndex = 0;
					}
					else if(startIndex >= sb.Length)
					{
						startIndex = 0;
					}
					if(ignoreCase)
					{
						//return (int)commonStringIndexOfMethod.Invoke(sb.ToString(), new object[]{__value, startIndex, sb.Length - startIndex, Enum.ToObject(commonStringComparisionType, 3)});
                        return sb.ToString().IndexOf(__value, startIndex, sb.Length - startIndex, StringComparison.OrdinalIgnoreCase);
					}
					else
					{
						//return (int)commonStringIndexOfMethod.Invoke(sb.ToString(), new object[]{__value, startIndex, sb.Length - startIndex, Enum.ToObject(commonStringComparisionType, 2)});
                        return sb.ToString().IndexOf(__value, startIndex, sb.Length - startIndex, StringComparison.Ordinal);

					}
				}
                 */

                int index;
                int length = __value.Length;
                int maxSearchLength = (sb.Length - length) + 1;
                if (startIndex > sb.Length || maxSearchLength > sb.Length)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 1)
                    {
                        commonLog.LogEntry("StringBuilderIndexOf(\'{0}\', {1}/{2}, {3}) Out of Bounds", __value, startIndex, sb.Length, ignoreCase);
                    }
                    return -1;
                }

                if (ignoreCase)
                {
                    for (int i = startIndex; i < maxSearchLength; ++i)
                    {
                        char sb0Char = sb[i];
                        if (sb0Char >= 'A' && sb0Char <= 'Z')
                        {
                            sb0Char = FasterToLower(sb0Char);
                        }
                        if (sb0Char == ___valueLow[0])
                        {
                            index = 1;
                            char sb1Char = '\0';
                            while ((index < length) && (Char.ToLower(sb[i + index]) == ___valueLow[index]))
                            {
                                sb1Char = sb[i + index];
                                if (sb1Char >= 'A' && sb1Char <= 'Z')
                                {
                                    sb1Char = FasterToLower(sb1Char);
                                }
                                if (sb1Char == ___valueLow[index])
                                {
                                    ++index;
                                }
                            }

                            if (index == length)
                                return i;
                        }
                    }

                    return -1;
                }

                for (int i = startIndex; i < maxSearchLength; ++i)
                {
                    if (sb[i] == __value[0])
                    {
                        index = 1;
                        while ((index < length) && (sb[i + index] == __value[index]))
                            ++index;

                        if (index == length)
                            return i;
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 1)
                {
                    commonLog.LogEntry("StringBuilderIndexOf(\'{0}\', {1}/{2}, {3}) Error {4}", __value, startIndex, sb.Length, ignoreCase, ex.Message);
                }
            }

            return -1;
        }

        internal static double confirmElementWidthAgainstMinWidthAndMaxWidth(double ___width, CHtmlElement ___curElement)
        {
            if (___curElement == null || ___curElement.___style == null)
                return ___width;
            if (string.IsNullOrEmpty(___curElement.___style.___MaxWidth) == false)
            {
                if (___curElement.___style.___MaxWidthComputedValue > 0)
                {
                    if (___width > ___curElement.___style.___MaxWidthComputedValue)
                    {
                        ___width = ___curElement.___style.___MaxWidthComputedValue;
                    }
                }
            }
            if (string.IsNullOrEmpty(___curElement.___style.___MinWidth) == false)
            {
                if (___curElement.___style.___MinWidthComputedValue > 0)
                {
                    if (___width < ___curElement.___style.___MinWidthComputedValue)
                    {
                        ___width = ___curElement.___style.___MinWidthComputedValue;
                    }
                }
            }
            return ___width;
        }
        internal static int MAX_ParentNodeLoolupLimit = 16;
        const char empty_Character = '\0';

        internal static void createChildNodesListFromInnerHTML(CHtmlElement element)
        {
            if (element == null)
                return;
            if (element.___childNodes != null)
            {

                element.___childNodes = null;
            }


            if (element.___drawingObjectList != null)
            {
                element.___drawingObjectList = null;
            }


            CHtmlDocument ___ownerDocument = null;
            CHtmlDomModeType ___ownerDOMType = CHtmlDomModeType.HTMLSegment;
            if (element.___documentWeakRef != null)
            {
                ___ownerDocument = element.___documentWeakRef.Target as CHtmlDocument;
                ___ownerDOMType = ___ownerDocument.___documentDomType;
            }
            System.Text.StringBuilder sbHTML = new StringBuilder(element.innerHTML);
            char cb2, cb1, c0, ca1, ca2;
            System.Text.StringBuilder sbName = null;
            System.Text.StringBuilder sbAttribute = null;
            System.Text.StringBuilder sbText = new StringBuilder();
            CHtmlParseModeType curMode = CHtmlParseModeType.InnerText;
            CHtmlElement currentParent = element;
            int i = 0;
            int innerTextStartPos = 0;
            int sbHTMLLen = sbHTML.Length;
            cb2 = '\0';

            for (i = 0; i < sbHTMLLen; i++)
            {
                cb2 = empty_Character;
                cb1 = empty_Character;
                ca1 = empty_Character;
                ca2 = empty_Character;
                c0 = sbHTML[i];
                try
                {
                    if (i > 0)
                    {
                        cb1 = sbHTML[i - 1];
                    }
                    if (i > 1)
                    {
                        cb2 = sbHTML[i - 2];
                    }
                    if (i < sbHTML.Length - 1)
                    {
                        ca1 = sbHTML[i + 1];
                    }
                    if (i < sbHTML.Length - 2)
                    {
                        ca2 = sbHTML[i + 2];
                    }
                    switch (c0)
                    {
                        case '<':
                            if (char.IsLetter(ca1) || ca1 == '/')
                            {
                                if (sbText != null && sbText.Length > 0)
                                {
                                    //CreateCHtmlParagraphForCHtmlElement(currentParent, sbText, innerTextStartPos , i);
                                }
                                sbText = null;
                                sbName = null;
                                sbName = new StringBuilder();
                                curMode = CHtmlParseModeType.TagName;
                                continue;
                            }
                            break;
                        case '>':
                            {
                                bool IsImmediateClose = false;
                                bool IsClose4Parent = false;
                                if (cb1 == '/' || (cb1 == ' ' && cb2 == '/'))
                                {
                                    // Immediate close
                                    IsImmediateClose = true;
                                }
                                else
                                {   // Normal Begin Tag Close
                                    IsImmediateClose = false;
                                }
                                if (sbName.Length > 0)
                                {
                                    if (sbName[sbName.Length - 1] == '/')
                                    {
                                        sbName.Remove(sbName.Length - 1, 1);
                                        IsImmediateClose = true;
                                    }
                                    else if (sbName[0] == '/')
                                    {
                                        sbName.Remove(0, 1);
                                        IsClose4Parent = true;
                                    }
                                }
                                string __tagNameUp = null;
                                if (IsCharWhiteSpaceLimited(sbName[0]) == true || IsCharWhiteSpaceLimited(sbName[sbName.Length - 1]) == true)
                                {
                                    __tagNameUp = sbName.ToString().Trim();
                                }
                                else
                                {
                                    __tagNameUp = sbName.ToString();
                                }

                                CHtmlElement newElement = CHtmlDocument.createCHtmlElementWithDomType(__tagNameUp, ___ownerDOMType, null);


                                if (___ownerDocument != null && ___ownerDocument.___IsDisposing == false)
                                {
                                    newElement.___documentWeakRef = new WeakReference(___ownerDocument, false);
                                }
                                newElement.___IsDynamicElement = true;
                                newElement.tagName = __tagNameUp;
                                //newElement.___elementTagType = commonGetTagNameType(newElement.tagName);

                                if (sbAttribute != null && sbAttribute.Length > 0)
                                {
                                    newElement.___createElementAttributesFromString(ref sbAttribute);
                                }
                                if (IsClose4Parent == false)
                                {
                                    // ==============================================
                                    // Create parent child relationship
                                    // ==============================================
                                    newElement.parent = currentParent;
                                    // ==============================================
                                    currentParent.___childNodes.Add(newElement);
                                    if (IsImmediateClose)
                                    {
                                        newElement.___ClosedReson = CHtmlTagClosedReasonType.EndSimple;
                                    }
                                }
                                else
                                {
                                    CHtmlElement LookUpElement = currentParent;
                                    bool IsParentTagFound = false;
                                    int ___lookupCount = 0;
                                    while (LookUpElement != null)
                                    {
                                        ___lookupCount++;
                                        if (LookUpElement.tagName == newElement.tagName)
                                        {
                                            IsParentTagFound = true;
                                            break;
                                        }
                                        LookUpElement = LookUpElement.___getParentElement();
                                        if (___lookupCount > MAX_ParentNodeLoolupLimit)
                                        {
                                            break;
                                        }
                                    }
                                    if (IsParentTagFound)
                                    {
                                        LookUpElement.___ClosedReson = CHtmlTagClosedReasonType.EndDeep;
                                        if (LookUpElement.parent != null)
                                        {
                                            currentParent = LookUpElement.___getParentElement();
                                        }
                                        else
                                        {
                                            currentParent = element;
                                        }
                                    }
                                }
                                if (IsClose4Parent == false && IsImmediateClose == false)
                                {
                                    currentParent = newElement;
                                }
                                sbName = null;
                                sbAttribute = null;
                                curMode = CHtmlParseModeType.InnerText;
                                sbText = null;
                                sbText = new StringBuilder();
                                innerTextStartPos = i;
                                continue;
                            }
                        default:
                            {
                                switch (curMode)
                                {
                                    case CHtmlParseModeType.TagName:
                                        if (sbName != null)
                                        {
                                            if (IsCharWhiteSpaceLimited(c0))
                                            {
                                                curMode = CHtmlParseModeType.TagAttribute;
                                                sbAttribute = null;
                                                sbAttribute = new StringBuilder();
                                                continue;
                                            }
                                            if (c0 >= 'a' && c0 <= 'z')
                                            {
                                                sbName.Append(FasterToUpper(c0));
                                            }
                                            else
                                            {
                                                sbName.Append(c0);
                                            }
                                        }
                                        break;
                                    case CHtmlParseModeType.TagAttribute:
                                        if (sbAttribute != null)
                                        {
                                            if (IsCharWhiteSpaceLimited(c0))
                                            {
                                                c0 = ' ';
                                            }
                                            sbAttribute.Append(c0);
                                        }
                                        break;
                                    case CHtmlParseModeType.InnerText:
                                        if (sbText != null)
                                        {
                                            sbText.Append(c0);
                                        }
                                        break;
                                }
                                break;
                            }

                    }
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                    {
                        commonLog.LogEntry("CreateChildNodesFromInnerHTML", ex);
                    }
                }
            }
            if (sbText != null && sbText.Length > 0)
            {
                //CreateCHtmlParagraphForCHtmlElement(currentParent, sbText, innerTextStartPos , i);
            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
            {
                commonLog.LogEntry("CreateChildNodesFromInnerHTML {0} created {1} children", element, element.___childNodes.Count);
            }
        }
        /// <summary>
        /// some web site ___hasInner 'async' and 'defer' both flag on.
        /// we choose async flag only
        /// </summary>
        /// <param name="___element"></param>
        public static void checkHTMLScriptElementAsycAndDefer(CHtmlElement ___element)
        {
            if (___element.___defer == true && ___element.___async == true)
            {
                ___element.___defer = false;


                if (___element.___attributes.ContainsKey("defer") == true)
                {
                    ___element.___attributes.Remove("defer");
                }


                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("warning: checkHTMLScriptElementAsycAndDefer({0}) src: '{1}' ___hasInner both async and defer flag... selecting async only...", ___element.toLogString(), ___element.___src);
                }
            }
        }


        public static string GetUrlQuotedUrlToNormalUrl(string __bkImageStr, string _referUrl)
        {

            System.Text.StringBuilder sbImage = new StringBuilder(__bkImageStr);
            if (__bkImageStr.Length != 0 && string.Equals(__bkImageStr, "none", StringComparison.OrdinalIgnoreCase) == false)
            {
                try
                {
                    if (true)
                    {
                        if (__bkImageStr.Length > 7 && __bkImageStr.StartsWith("http://", StringComparison.Ordinal) == true || __bkImageStr.StartsWith("https://", StringComparison.Ordinal) == true)
                        {
                            goto ValueObtained;
                        }
                        if (__bkImageStr.StartsWith("url(", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            sbImage.Remove(0, 4);

                            int posQuoteEnd = sbImage.ToString().LastIndexOf(')', sbImage.Length - 1, 5);
                            if (posQuoteEnd > -1)
                            {
                                sbImage.Remove(posQuoteEnd, sbImage.Length - posQuoteEnd);
                            }

                        }

                        if (IsCharWhiteSpaceLimited(sbImage[0]) == true || IsCharWhiteSpaceLimited(sbImage[sbImage.Length - 1]) == true)
                        {
                            string sTrimedUrl = sbImage.ToString().Trim();
                            sbImage = null;
                            sbImage = new StringBuilder(sTrimedUrl);
                        }

                        if (sbImage.Length > 0 && (sbImage[0] == '\'' || sbImage[0] == '\"'))
                        {
                            sbImage.Remove(0, 1);

                        }
                        if (sbImage.Length > 1 && (sbImage[sbImage.Length - 1] == '\'' || sbImage[sbImage.Length - 1] == '\"'))
                        {
                            sbImage.Remove(sbImage.Length - 1, 1);
                        }
                        string sLow = "";
                        if (sbImage.Length > 6)
                        {
                            if (sbImage[0] == 'h' && (sbImage[4] != ':' && sbImage[5] != ':'))
                            {
                                sLow = sbImage.ToString(0, 6);
                                if (string.Equals(sLow, "http//", StringComparison.Ordinal) == true)
                                {
                                    sbImage.Insert(4, ':');
                                    goto ValueObtained;
                                }
                                if (string.Equals(sLow, "https/", StringComparison.Ordinal) == true)
                                {
                                    sbImage.Insert(5, ':');
                                    goto ValueObtained;
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(_referUrl) == false)
                        {
                            return GetAbsoluteUri(_referUrl, "", sbImage.ToString());
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                    {
                        commonLog.LogEntry("BackgroundImage", ex);
                    }
                }
            }
        ValueObtained:
            return sbImage.ToString();
        }
        public static RectangleSpec RectangleFToRectangle(RectangleFSpec rectF)
        {
            return new RectangleSpec((int)rectF.X, (int)rectF.Y, (int)rectF.Width, (int)rectF.Height);

        }

        public static double SearchParentWiderAvailWidth(CHtmlElement element, float ___DocumentMaxSize)
        {
            double ___baseWidth = element.___offsetWidth;
            CHtmlElement ___parent = element.___parent as CHtmlElement;
            try
            {
                while (___parent != null)
                {
                    if (___parent.___availWidth > ___baseWidth && ___parent.___availWidth > 20)
                    {
                        if (element.___style != null)
                        {
                            element.___style.StyleCommentAdd("Avaiable ___hasInner been searched by parent;");
                        }
                        return ___parent.___availWidth;
                    }
                    ___parent = ___parent.___parent as CHtmlElement;
                }
            }
            catch
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("SearchParentWiderAvailWidth Error");
                }
            }
            return ___DocumentMaxSize;
        }


        public static bool IsSizeSmaller(SizeF baseSize, int referSizeWidth, int referSizeHeight)
        {
            if (baseSize.Width < referSizeWidth)
            {
                return true;
            }
            if (baseSize.Height < referSizeHeight)
            {
                return true;
            }

            return false;
        }

        public static bool IsSizeSmaller(SizeF baseSize, SizeF referSize)
        {
            if (baseSize.Width < referSize.Width)
            {
                return true;
            }
            if (baseSize.Height < referSize.Height)
            {
                return true;
            }

            return false;
        }

        public static double compareDocumentPositionInner(CHtmlElement thisNode, CHtmlElement otherNode)
        {
            if (otherNode == null)
            {
                return 1;
            }
            if (thisNode == null)
            {
                return 1;
            }
            if (otherNode.___documentWeakRef == null)
                return 1;
            if (thisNode.___documentWeakRef == null)
                return 1;

            try
            {
                /*
				 * BODY
				 *｜
				 *├―― P1　　←node
				 *｜
				 *└―― P2　　←otherNode
				 *
				 * DOCUMENT_POSITION_PRECEDING
				 * otherはnodeより前にあります。 (2)
				 * DOCUMENT_POSITION_FOLLOWING
				 * otherはnodeより後にあります。 (4)
				 * DOCUMENT_POSITION_CONTAINS
				 * otherはnodeを含んでいます。 (8)
				 * DOCUMENT_POSITION_CONTAINED_BY
				 * otherはnodeに含まれています。 (16)
				 * DOCUMENT_POSITION_DISCONNECTED
				 * otherとnodeは、同じ木構造にありません。 (1)
				 * DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC
				 * 位置関係は実装依存です。 (32) 
				 */
                if (thisNode.___childNodes.Contains(otherNode) == true)
                {
                    return 16;
                }
                if (otherNode.___childNodes.Contains(thisNode) == true)
                {
                    return 8;
                }
                if (thisNode.parent != null && otherNode.parent == thisNode.parent)
                {
                    int posThis = thisNode.parent.___childNodes.IndexOf(thisNode);
                    int posOther = thisNode.parent.___childNodes.IndexOf(otherNode);
                    if (posThis > -1 && posOther > -1)
                    {
                        if (posThis > posOther)
                        {
                            return 2;
                        }
                        else
                        {
                            return 44;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("compareDocumentPostion", ex);
                }
            }
            return 1;
        }
        public static bool IsObjectContainsProperty(string ___name, object obj, ref SortedList _propList)
        {
            if (obj == null)
                return false;
            if (obj.GetType().GetProperty(___name) != null)
            {
                return true;
            }
            if (_propList != null && _propList.ContainsKey(___name))
            {
                return true;
            }
            return false;
        }

        public static Rectangle GetRectangleFromStringValue(string strRect)
        {
            if (strRect.Length < 4)
            {
                return new Rectangle(-1, -1, -1, -1);
            }
            int posQuote = strRect.IndexOf('(');
            int posQuoteEnd = strRect.LastIndexOf(')');
            string strMid = "";
            if (posQuote == -1)
            {
                posQuote = 0;
            }
            if (posQuoteEnd == -1)
            {
                posQuoteEnd = strRect.Length;
            }
            strMid = strRect.Substring(posQuote + 1, posQuoteEnd - posQuote - 1);
            if (strMid.Length > 0)
            {
                int[] vPoint = new int[] { 0, 0, 0, 0 };
                string[] spRect = strMid.Split(CharsRectangeSplit);
                int p = 0;
                int valuePosition = 0;
                for (int spi = 0; spi < spRect.Length; spi++)
                {
                    try
                    {
                        string strRectValue = spRect[spi];
                        if (strRectValue.Length != 0)
                        {
                            valuePosition++;
                            vPoint[valuePosition] = GetIntValueFromString(strRectValue, 100);
                            if (valuePosition == 3)
                            {
                                break;
                            }
                        }
                    }
                    catch (Exception ex1)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                        {
                            commonLog.LogEntry("GetRectangelFromStringValue() ___hasInner Error.", ex1);
                        }
                    }
                    p++;
                }
                // CSS2.1 Rect(Top, right, Bottom, left)
                return new Rectangle(vPoint[3], vPoint[0], vPoint[2], vPoint[1]);
            }
            else
            {
                return new Rectangle(-1, -1, -1, -1);
            }
        }
        private static char[] CharsRectangeSplit = new char[] { ' ', ',' };

        public static CHtmlDocument createSVGDocumentFromString(string ___svg, string __charset, string ___URL)
        {
            CHtmlDocument svgDoc = null;

            svgDoc = new CHtmlDocument(CHtmlDomModeType.SVGDOM);

            if (string.IsNullOrEmpty(___URL) == true)
            {
                svgDoc.___URL = "about:svg";
            }
            else
            {
                svgDoc.___URL = ___URL;
            }
            svgDoc.___HtmlBuilder.Append(___svg);
            svgDoc.___charset = __charset;
            svgDoc.___IsHtmlCharSetDetectionCompleted = true;
            svgDoc.___IsHtmlResponseCompleted = true;
            return svgDoc;
        }
        /// <summary>
        /// Returns full URL for element from 'src' or 'data' attributes
        /// </summary>
        /// <param name="__objectElement"></param>
        /// <returns></returns>
        public static string GetCHtmlObjectElementFullSrcURL(CHtmlElement __objectElement)
        {
            try
            {
                if (__objectElement == null || __objectElement.___documentWeakRef == null)
                {
                    return "";
                }
                string srcURL = null;
                CHtmlAttribute objAttrSrc = null;
                if (__objectElement.___attributes.TryGetValue("src", out objAttrSrc) == true)
                {
                    if (objAttrSrc.___value != null)
                    {
                        srcURL = objAttrSrc.___value.ToString();
                    }
                }
                else
                {
                    srcURL = GetElementAttributeInString(__objectElement, "data");
                }
                if (string.IsNullOrEmpty(srcURL))
                {
                    return "";
                }
                return GetAbsoluteUri(__objectElement.___getDocument().___URL, __objectElement.___getDocument().___baseUrl, srcURL);
            }
            catch (Exception ex1)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("{0} ___hasInner error {1}", ex1.Message, commonData.GetExceptionAsString(ex1));
                }
            }
            return "";
        }

        /// <summary>
        /// Returns Quoted Inner String
        /// </summary>
        /// <param name="__str">InnerString</param>
        /// <param name="qBegin">Quote Begin</param>
        /// <param name="qEnd">Quote End</param>
        /// <returns></returns>
        public static string GetQuotedInnerString(string __str, char qBegin, char qEnd)
        {
            string _s = __str;
            int posGradient = _s.IndexOf(qBegin);
            if (posGradient > -1)
            {
                try
                {

                    int QuoteBeginCount = 0;
                    int pStart = posGradient;
                    char c = '\0';
                    int sLen = _s.Length;
                    for (int p = pStart; p < sLen; p++)
                    {
                        c = _s[p];

                        if (c == qBegin)
                        {
                            QuoteBeginCount++;
                        }
                        else if (c == qEnd)
                        {
                            QuoteBeginCount--;
                            if (QuoteBeginCount == 0)
                            {
                                int prevHeaderLen = 0;
                                string __innerString = _s.Substring(posGradient + 1, p - posGradient + 1 + prevHeaderLen - 2);
                                return __innerString;


                            }
                        }

                    }
                }
                catch
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                    {
                        commonLog.LogEntry("GetQuotedInnerString failed : " + __str);
                    }
                }
            }
            return "";

        }
        public static CHtmlWebGradation CreateGradationData(string __data, double ___remSize)
        {
            CHtmlWebGradation grad = new CHtmlWebGradation();
            grad.text = string.Copy(__data);
            string sInner = GetQuotedInnerString(__data, '(', ')');
            if (sInner.Length != 0)
            {
                int QuoteCount = 0;
                System.Text.StringBuilder sbParam = new StringBuilder();
                int sInnerLen = sInner.Length;
                for (int i = 0; i < sInnerLen; i++)
                {
                    char c = sInner[i];
                    if (c == '(')
                    {
                        QuoteCount++;
                    }
                    else if (c == ')')
                    {
                        QuoteCount--;
                    }
                    if (c == ',' && QuoteCount <= 0)
                    {
                        if (sbParam.Length > 0)
                        {
                            SetGradientDataByParam(sbParam.ToString(), ref grad, ___remSize);
                        }
                        sbParam = null;
                        sbParam = new System.Text.StringBuilder();
                    }
                    else
                    {
                        if (IsCharWhiteSpaceLimited(c) && sbParam.Length == 0)
                            continue;
                        sbParam.Append(c);
                    }
                }
                if (sbParam.Length > 0)
                {
                    SetGradientDataByParam(sbParam.ToString(), ref grad, ___remSize);
                }
            }
            return grad;
        }
        private static string COLOR_STOP_STRING = "color-stop(";
        private static void SetGradientDataByParam(string sGra, ref CHtmlWebGradation _grad, double ___remSize)
        {
            try
            {
                if (sGra.Length == 0)
                {
                    return;
                }
                int posGradQuote = sGra.IndexOf(COLOR_STOP_STRING, StringComparison.Ordinal);
                if (posGradQuote > -1)
                {
                    int StringQuoteAfterStart = posGradQuote + COLOR_STOP_STRING.Length;
                    string __colorStopInner;
                    if (sGra[sGra.Length - 1] == ')')
                    {
                        __colorStopInner = sGra.Substring(StringQuoteAfterStart, sGra.Length - StringQuoteAfterStart - 1);
                    }
                    else
                    {
                        __colorStopInner = sGra.Substring(StringQuoteAfterStart);
                    }
                    string[] __colorStopSp = SplitGradientInnerValues(__colorStopInner);
                    bool ColorStopColorFound = false;
                    bool ColorStopRatioFound = false;
                    Color ColorStopColor = Color.Empty;
                    float ColorStopRatio = 0;
                    int __colorStopLength = __colorStopSp.Length;
                    for (int sPos = 0; sPos < __colorStopLength; sPos++)
                    {
                        string stopSP = __colorStopSp[sPos];
                        if (stopSP.Length == 0)
                            continue;
                        Color tmpColor;
                        if (CHtmlHTMLColorNamesDictionary.TryGetValue(stopSP, out tmpColor) == true)
                        {
                            ColorStopColor = tmpColor;
                            ColorStopColorFound = true;
                        }
                        if (stopSP[0] == '#' || stopSP.StartsWith("rgb(", StringComparison.OrdinalIgnoreCase) || stopSP.StartsWith("rgba(", StringComparison.OrdinalIgnoreCase))
                        {
                            ColorStopColor = GetColorFromHTMLColorExtend(stopSP);
                            ColorStopColorFound = true;
                        }
                        else if (char.IsNumber(stopSP[0]) || stopSP[0] == '-')
                        {
                            ColorStopRatio = (int)GetDoubleValueFromString(stopSP, 0, ___remSize);
                            ColorStopRatioFound = true;
                        }

                    }
                    if (ColorStopColorFound)
                    {
                        CHtmlWebGradationColor colorInfo = new CHtmlWebGradationColor();
                        colorInfo.GradationColor = ColorStopColor;
                        if (ColorStopRatioFound)
                        {
                            colorInfo.Ratio = ColorStopRatio;
                        }
                        colorInfo.ColorType = CHtmlGradationColorType.StopColor;
                        _grad.ColorList.Add(colorInfo);

                    }

                    return;
                }
                switch (sGra)
                {
                    case "linear":
                        _grad.type = sGra;
                        break;
                    case "radical":
                        _grad.type = sGra;
                        break;
                    case "circle":
                        _grad.type = sGra;
                        break;
                    case "top":
                        _grad.Degree = 0;
                        break;
                    case "to top":
                        _grad.Degree = 0;
                        break;
                    case "left":
                        _grad.Degree = 90;
                        break;
                    case "to left":
                        _grad.Degree = 90;
                        break;
                    case "top left":
                        _grad.Degree = 315;
                        break;
                    case "bottom":
                        _grad.Degree = 180;
                        break;
                    case "to bottom":
                        _grad.Degree = 180;
                        break;
                    case "right":
                        _grad.Degree = 270;
                        break;
                    case "to right":
                        _grad.Degree = 270;
                        break;
                    case "bottom left":
                        _grad.Degree = 230;
                        break;
                    case "to left bottom":
                        _grad.Degree = 135;
                        break;
                    case "center":
                        break;
                    default:
                        if (sGra.IndexOfAny(CharSpaceCrLfTabZentakuSpace) == -1)
                        {
                            SetGradientDataByParamInner(sGra, ref _grad);
                        }
                        else
                        {
                            string[] spValues = sGra.Split(GradationSplitChars);
                            int spLen = spValues.Length;
                            for (int spPos = 0; spPos < spLen; spPos++)
                            {
                                string sVal = spValues[spPos];
                                if (sVal.Length != 0)
                                {
                                    SetGradientDataByParamInner(sVal, ref _grad);
                                }
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("SetGradientDataByParam", ex);
                }
            }

        }


        /* FasterEndWidth is little slowser than EndWidth(StringComparision.Ordinal or OrdinalIgnoreCase
         * Use EndWith(StringComparison).
		/// <summary>
		/// Faster Method of string.EndsWith
		/// </summary>
		/// <param name="a"></param>
		/// <param name="findstr"></param>
		/// <returns></returns>
		
		internal static bool FasterEndsWith(string a, string findstr, bool IgnoreCase)
		{
			if(a == null || findstr == null)
				return false;
			int blen = findstr.Length;
			int alen = a.Length;
			if (alen < blen)
				return false;
			if(blen == 0)
				return false;
			char lc = findstr[0];
            if (IgnoreCase)
            {
                if (lc >= 'A' && lc <= 'Z')
                {
                    lc = commonHTML.FasterToLower(lc);
                }
            }

			int pos = alen - blen;
			char c = a[pos];
            if (IgnoreCase)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    c = commonHTML.FasterToLower(c);
                }
            }
			if (c != lc)
			{
				return false;
			}
			else
			{
				if(blen == 1)
					return true;
       
				int bNextPos = 0;
				char cx = '\0';
                char fc = '\0';
				for (int posx = pos + 1; posx < alen; posx++)
				{
					bNextPos++;
					cx = a[posx];
                    if (IgnoreCase == false)
                    {
                        if (cx == findstr[bNextPos])
                        {
                            continue;
                        }
                        else
                        {

                            return false;
                        }
                    }
                    else
                    {
                        if (cx >= 'A' && cx <= 'Z')
                        {
                            cx = commonHTML.FasterToLower(cx);
                        }
                        fc = findstr[bNextPos];
                        if (fc >= 'A' && fc <= 'Z')
                        {
                            fc = commonHTML.FasterToLower(fc);
                        }
                        
                        if(cx == fc)
                        {
                            continue;
                        }else{
                            return false;
                        }
                    }

				}
				return true;

			}
		}
         */
        private static char[] GradationSplitChars = new char[] { ' ', '\t', '\n', '\r' };

        private static string[] SplitGradientInnerValues(string _gradientString)
        {
            if (_gradientString.IndexOf('(') == -1)
            {
                return _gradientString.Split(',');
            }
            else
            {
                char[] graChars = _gradientString.ToCharArray();
                System.Collections.ArrayList arString = new ArrayList();
                System.Text.StringBuilder sbValue = new StringBuilder();
                char c = '\0';
                bool __IsInValue = false;
                int graCharLen = graChars.Length;
                for (int i = 0; i < graCharLen; i++)
                {
                    c = graChars[i];
                    switch (c)
                    {
                        case ',':
                        case '\u3001':
                            if (__IsInValue == false)
                            {
                                if (sbValue.Length > 0 && (IsCharWhiteSpaceLimited(sbValue[0]) == true) || IsCharWhiteSpaceLimited(sbValue[sbValue.Length - 1]) == true)
                                {
                                    arString.Add(sbValue.ToString().Trim());
                                }
                                else
                                {
                                    arString.Add(sbValue.ToString());
                                }
                                sbValue = null;
                                sbValue = new StringBuilder();
                                continue;
                            }
                            break;
                        case '(':
                            __IsInValue = true;
                            break;
                        case ')':
                            __IsInValue = false;
                            break;
                        default:
                            break;
                    }
                    sbValue.Append(c);
                }
                if (sbValue != null && sbValue.Length > 0)
                {
                    if (IsCharWhiteSpaceLimited(sbValue[0]) == true || IsCharWhiteSpaceLimited(sbValue[sbValue.Length - 1]) == true)
                    {
                        arString.Add(sbValue.ToString().Trim());
                    }
                    else
                    {
                        arString.Add(sbValue.ToString());
                    }
                }
                if (arString.Count > 0)
                {
                    return arString.ToArray(typeof(string)) as string[];
                }
                else
                {
                    return new string[] { };
                }
            }
        }
        private static readonly char[] CharLowerList = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        /// <summary>
        /// This methods 65% - 70 % faster than char.ToLower()
        /// </summary>
        /// <param name="c">UpperCase Car (Only 'A'-'Z')</param>
        /// <returns>LowerCase Char</returns>

        public static char FasterToLower(char c)
        {
            return CharLowerList[c - 65];
        }
        private static char[] CharUpperList = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        /// <summary>
        /// Faster Version of Char To Upper
        /// [Normal Performance Test]
        /// Do Nothing    :  4154 ms
        /// char.ToUpper  : 13094 ms
        /// FasterToUpper :  5104 ms
        /// </summary>
        /// <param name="c">char Only ('a' to 'z') allowed</param>
        /// <returns>Upper Char</returns>

        public static char FasterToUpper(char c)
        {
            return CharUpperList[c - 97];

        }
        public static string FasterToUpper(string __text)
        {
            char[] __charArray = null;
            bool IsArrayCreated = false;
            if (__text == null)
            {
                return "";
            }
            char c = '\0';
            int __textLen = __text.Length;
            for (int i = 0; i < __textLen; i++)
            {
                c = __text[i];
                if (c >= 'a' && c <= 'z')
                {
                    if (IsArrayCreated == false)
                    {
                        __charArray = __text.ToCharArray();
                        IsArrayCreated = true;
                    }

                    __charArray[i] = CharUpperList[c - 97];
                }
            }
            if (IsArrayCreated == true)
            {
                return new string(__charArray);
            }
            else
            {
                return __text;
            }
        }
        /// ToLower Faster 
        /// Normal ToLower() : 3300 ms
        /// ToLowerFast()   :  2170 ms
        /// </summary>
        /// <param name="__text"></param>
        /// <returns></returns>

        public static string FasterToLower(string __text)
        {
            if (__text == null)
            {
                return "";
            }
            char[] __charArray = null;
            bool IsArrayCreated = false;

            char c = '\0';
            int __textLen = __text.Length;
            for (int i = 0; i < __textLen; i++)
            {
                c = __text[i];
                if (c <= 'Z' && c >= 'A')
                {
                    if (IsArrayCreated == false)
                    {
                        __charArray = __text.ToCharArray();
                        IsArrayCreated = true;
                    }

                    __charArray[i] = CharLowerList[c - 65];
                }
            }
            if (IsArrayCreated == true)
            {
                return new string(__charArray);
            }
            else
            {
                return __text;
            }
        }
        /// <summary>
        /// Faster Trim().ToLower()
        /// Normal Trim().ToLower() : 6395 ms
        /// This Version            : 2100 ms
        /// </summary>
        /// <param name="__text"></param>
        /// <returns></returns>

        public static string FasterTrimAndToUpper(string __text)
        {
            if (__text == null || __text.Length == 0)
            {
                return "";
            }
            char[] __charArray = null;
            bool IsArrayCreated = false;

            char c = '\0';
            int FastValidCharPos = -1;
            int EndValidCharPos = -1;
            int __textLen = __text.Length;
            for (int i = 0; i < __textLen; i++)
            {
                c = __text[i];
                if (FastValidCharPos == -1)
                {
                    if (c == ' ' || c == '\r' || c == '\n' || c == '\t' || c == '\v')
                    {
                        continue;
                    }

                    FastValidCharPos = i;
                }
                if (c >= 'a' && c <= 'z')
                {

                    if (IsArrayCreated == false)
                    {
                        __charArray = __text.ToCharArray();
                        IsArrayCreated = true;
                    }

                    __charArray[i] = CharUpperList[c - 97];
                }
            }
            // Now Loop Done
            for (int eP = __text.Length - 1; eP >= 0; eP--)
            {
                c = __text[eP];
                if (c == ' ' || c == '\r' || c == '\n' || c == '\t' || c == '\v')
                {
                    EndValidCharPos = eP;
                    continue;
                }
                else
                {
                    break;
                }

            }
            if (FastValidCharPos == -1 && EndValidCharPos == -1)
            {
                if (IsArrayCreated == true)
                {
                    return new string(__charArray);
                }
                else
                {
                    return __text;
                }
            }
            else
            {
                if (IsArrayCreated == true)
                {
                    if (EndValidCharPos != -1)
                    {
                        return new string(__charArray, FastValidCharPos, EndValidCharPos - FastValidCharPos);
                    }
                    else
                    {
                        return new string(__charArray, FastValidCharPos, __charArray.Length - FastValidCharPos);
                    }
                }
                else
                {
                    if (EndValidCharPos != -1)
                    {
                        return __text.Substring(FastValidCharPos, EndValidCharPos - FastValidCharPos);
                    }
                    else
                    {
                        return __text.Substring(FastValidCharPos);
                    }
                }

            }
        }
        public static bool compareDoubleDiff(double ___val1, double ___val2, double ____criteria)
        {
            double ___diff = ___val1 - ___val2;
            if (Math.Abs(___diff) > ____criteria)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Faster Trim().ToLower()
        /// Normal Trim().ToLower() : 6395 ms
        /// This Version            : 2100 ms
        /// </summary>
        /// <param name="__text"></param>
        /// <returns></returns>

        public static string FasterTrimAndToLower(string __text)
        {
            if (__text == null || __text.Length == 0)
            {
                return "";
            }
            char[] __charArray = null;
            bool IsArrayCreated = false;

            char c = '\0';
            int FastValidCharPos = -1;
            int EndValidCharPos = -1;
            int __textLen = __text.Length;
            for (int i = 0; i < __textLen; i++)
            {
                c = __text[i];
                if (FastValidCharPos == -1)
                {
                    if (c == ' ' || c == '\r' || c == '\n' || c == '\t' || c == '\v')
                    {
                        continue;
                    }

                    FastValidCharPos = i;
                }
                if (c <= 'Z' && c >= 'A')
                {

                    if (IsArrayCreated == false)
                    {
                        __charArray = __text.ToCharArray();
                        IsArrayCreated = true;
                    }

                    __charArray[i] = CharLowerList[c - 65];
                }
            }
            // Now Loop Done
            for (int eP = __textLen - 1; eP >= 0; eP--)
            {
                c = __text[eP];
                if (c == ' ' || c == '\r' || c == '\n' || c == '\t' || c == '\v')
                {
                    EndValidCharPos = eP;
                    continue;
                }
                else
                {
                    break;
                }

            }
            if (FastValidCharPos == -1 && EndValidCharPos == -1)
            {
                if (IsArrayCreated == true)
                {
                    return new string(__charArray);
                }
                else
                {
                    return __text;
                }
            }
            else
            {
                if (IsArrayCreated == true)
                {
                    if (EndValidCharPos != -1)
                    {
                        return new string(__charArray, FastValidCharPos, EndValidCharPos - FastValidCharPos);
                    }
                    else
                    {
                        return new string(__charArray, FastValidCharPos, __charArray.Length - FastValidCharPos);
                    }
                }
                else
                {
                    if (EndValidCharPos != -1)
                    {
                        return __text.Substring(FastValidCharPos, EndValidCharPos - FastValidCharPos);
                    }
                    else
                    {
                        return __text.Substring(FastValidCharPos);
                    }
                }

            }
        }

        public static bool IsDBCSWhitespace(char c)
        {
            return c == 12288;
        }
        /// <summary>
        /// Only Checks char is tab, Feed, Cr, and 160.
        /// Any above 160 is treated as Non-WhiteSpace
        /// It is 60 % - 70 % faster than CLR IsWhiteSpace()
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>


        public static bool FasterIsWhiteSpaceLimited(char c)
        {

            switch (c)
            {
                case (char)0:
                case (char)9:
                case (char)10:
                case (char)11:
                case (char)12:
                case (char)13:
                case (char)28:
                case (char)29:
                case (char)30:
                case (char)31:
                case (char)32:
                case (char)133:
                case (char)160:
                case (char)8192:
                case (char)8193:
                case (char)8194:
                case (char)8195:
                case (char)8196:
                case (char)8197:
                case (char)8198:
                case (char)8199:
                case (char)8200:
                case (char)8201:
                case (char)8202:
                case (char)8203:
                case (char)8232: // line separator
                case (char)8233: // paragraph separator
                case (char)8239: // narrow no-break space
                case (char)8287: // Separator, space
                case (char)12288: // Separator, space (Zenkaku Space)
                    return true;
            }
            return false;
        }




        private static void ReplaceToLower(ref char[] cs)
        {
            char c = '\0';
            int csLen = cs.Length;
            for (int i = 0; i < csLen; i++)
            {
                c = cs[i];
                if (c >= 65 && c <= 90)
                {
                    cs[i] = (char)(c + 0x20);
                }

            }
        }
        private static void SetGradientDataByParamInner(string sGra, ref CHtmlWebGradation _grad)
        {
            try
            {
                if (sGra.StartsWith("from(", StringComparison.OrdinalIgnoreCase) || sGra.StartsWith("to(", StringComparison.OrdinalIgnoreCase))
                {
                    sGra = GetQuotedInnerString(sGra, '(', ')');
                }
                if (sGra.Length == 0)
                    return;
                Color tmpColor;
                if (sGra[0] == '#' || sGra.StartsWith("rbg(", StringComparison.OrdinalIgnoreCase) || sGra.StartsWith("rgba(", StringComparison.OrdinalIgnoreCase))
                {
                    Color __color = GetColorFromHTMLColorExtend(sGra);
                    CHtmlWebGradationColor colorInfo = new CHtmlWebGradationColor();
                    colorInfo.GradationColor = __color;
                    _grad.ColorList.Add(colorInfo);
                }
                else if (commonHTML.CHtmlHTMLColorNamesDictionary.TryGetValue(sGra, out tmpColor) == true)
                {
                    CHtmlWebGradationColor colorInfo = new CHtmlWebGradationColor();
                    colorInfo.GradationColor = tmpColor;
                    _grad.ColorList.Add(colorInfo);
                }
                else if ((char.IsNumber(sGra[0]) || sGra[0] == '-'))
                {
                    int posGra = sGra.IndexOf("deg", StringComparison.OrdinalIgnoreCase);
                    if (posGra > -1)
                    {
                        string degStr = sGra;
                        degStr = degStr.Substring(0, posGra);
                        try
                        {
                            float tmpFloat;
                            if (float.TryParse(degStr, out tmpFloat))
                            {
                                _grad.Degree = tmpFloat;
                            }
                        }
                        catch { }

                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("SetGradientDataByParamInner", ex);
                }
            }
        }
        public static bool IsCharsetOnlyAcceptsSingleByteCharater(string ___charset)
        {
            switch (___charset)
            {
                case "us-ascii":
                case "usascii":
                    return true;
            }
            return false;
        }
        public static bool isByteArrayContainsHigerThan125Character(ref byte[] ___bytes)
        {
            if (___bytes == null)
                return false;
            int __byteLen = ___bytes.Length;
            for (int i = 0; i < __byteLen; i++)
            {
                if (___bytes[i] > 125)
                {
                    return true;
                }
            }
            return false;
        }

        private static int HexToInt(char h)
        {
            if (h >= '0' && h <= '9')
            {
                return (int)(h - '0');
            }
            if (h >= 'a' && h <= 'f')
            {
                return (int)(h - 'a' + '\n');
            }
            if (h < 'A' || h > 'F')
            {
                return -1;
            }
            return (int)(h - 'A' + '\n');
        }






        /// <summary>
        /// UrlEncode (Following Code is disasssembled from NDP 4.5)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static string UrlEncode(string value)
        {
            if (value == null)
            {
                return null;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Encoding.UTF8.GetString(UrlEncode(bytes, 0, bytes.Length, false));
        }

        // System.Net.WebUtility

        private static byte[] UrlEncode(byte[] bytes, int offset, int count, bool alwaysCreateNewReturnValue)
        {
            byte[] array = UrlEncode(bytes, offset, count);
            if (!alwaysCreateNewReturnValue || array == null || array != bytes)
            {
                return array;
            }
            return (byte[])array.Clone();
        }
        // System.Net.WebUtility

        private static bool IsUrlSafeChar(char ch)
        {
            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9'))
            {
                return true;
            }
            if (ch != '!')
            {
                switch (ch)
                {
                    case '(':
                    case ')':
                    case '*':
                    case '-':
                    case '.':
                        return true;
                    case '+':
                    case ',':
                        break;
                    default:
                        if (ch == '_')
                        {
                            return true;
                        }
                        break;
                }
                return false;
            }
            return true;
        }


        // System.Net.WebUtility

        private static byte[] UrlEncode(byte[] bytes, int offset, int count)
        {

            int num = 0;
            int num2 = 0;
            for (int i = 0; i < count; i++)
            {
                char c = (char)bytes[offset + i];
                if (c == ' ')
                {
                    num++;
                }
                else
                {
                    if (!IsUrlSafeChar(c))
                    {
                        num2++;
                    }
                }
            }
            if (num == 0 && num2 == 0)
            {
                return bytes;
            }
            byte[] array = new byte[count + num2 * 2];
            int num3 = 0;
            for (int j = 0; j < count; j++)
            {
                byte b = bytes[offset + j];
                char c2 = (char)b;
                if (IsUrlSafeChar(c2))
                {
                    array[num3++] = b;
                }
                else
                {
                    if (c2 == ' ')
                    {
                        array[num3++] = 43;
                    }
                    else
                    {
                        array[num3++] = 37;
                        array[num3++] = (byte)IntToHex(b >> 4 & 15);
                        array[num3++] = (byte)IntToHex((int)(b & 15));
                    }
                }
            }
            return array;
        }

        private static char IntToHex(int n)
        {
            if (n <= 9)
            {
                return (char)(n + 48);
            }
            return (char)(n - 10 + 65);
        }

        internal readonly static char[] Base32CharTable = new char[] {
                                                               '0','1','2','3','4','5','6','7',
                                                               '8','9','a','b','c','d','e','f',
                                                               'g','h','i','j','k','l','m','n',
                                                               'o','p','q','r','s','t','u','v'
                                                           };

        internal static long ConvertBase32ToLong(string base32number)
        {

            long n = 0;

            foreach (char d in FasterToLower(base32number).ToCharArray())
            {
                n = n << 5;
                int idx = Array.IndexOf(Base32CharTable, d);

                if (idx == -1)
                    throw new Exception("Provided number contains invalid characters");

                n += idx;
            }

            return n;
        }
        private const string CLRTrueString = "true";
        private const string CLRFalseString = "false";

        public static bool IsObjectStringType(object __objString)
        {
            switch (__objString)
            {
                case String str:
                    return true;
                case NiL.JS.Core.JSValue jsVal:
                    if (jsVal.Value is string)
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;

            }


        }

        /// <summary>
        /// Convert 1 length string value to string True or False(string Must Be 1 Length)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string convertOneStringValueToBoolString(string s)
        {
            char c = s[0];
            if (c == 't' || c == '1')
                return "true";
            return "false";
        }
        public delegate string StringTypeHandler(object node);
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, StringTypeHandler> ___StringObjectTypeSwitcher = createStringWrapSwitcher();
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, StringTypeHandler> createStringWrapSwitcher()
        {
            System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, StringTypeHandler> list = new System.Collections.Generic.Dictionary<RuntimeTypeHandle, StringTypeHandler>();
            list[typeof(string).GetType().TypeHandle] = new StringTypeHandler(____stringConverter);

            list[typeof(double).GetType().TypeHandle] = new StringTypeHandler(____stringDoubleConverter);
            list[typeof(System.Double).GetType().TypeHandle] = new StringTypeHandler(____stringDoubleConverter);
            list[typeof(float).GetType().TypeHandle] = new StringTypeHandler(____stringFloatConverter);
            list[typeof(int).GetType().TypeHandle] = new StringTypeHandler(____stringIntConverter);
            list[typeof(short).GetType().TypeHandle] = new StringTypeHandler(____stringIntConverter);
            list[typeof(sbyte).GetType().TypeHandle] = new StringTypeHandler(____stringIntConverter);
            list[typeof(byte).GetType().TypeHandle] = new StringTypeHandler(____stringIntConverter);

            list[typeof(CHtmlElement).GetType().TypeHandle] = new StringTypeHandler(___stringCHtmlElementConverter);
            return list;
        }

        public static string ____stringConverter(object node)
        {
            return node as string;
        }
        public static string ____stringUndedefinedConverter(object node)
        {
            return "";
        }
        public static string ____stringBoolConverter(object node)
        {
            bool val = (bool)node;
            return val.ToString();
        }

        public static string ____stringDoubleConverter(object node)
        {
            double val = (double)node;
            return val.ToString();
        }
        public static string ____stringFloatConverter(object node)
        {
            float val = (float)node;
            return val.ToString();
        }
        public static string ____stringIntConverter(object node)
        {
            int val = (int)node;
            return val.ToString();
        }


        public static string ___javaLangStringConverter(object node)
        {
            // We can not use java.lang.String 
            return node.ToString();
        }
        public static string ___stringJavaFunctionConverter(object node)
        {
            return "";
        }
        public static string ___stringCHtmlElementConverter(object node)
        {
            CHtmlElement ___elem = node as CHtmlElement;
            return ___elem.ToString();
        }

        public static string GetStringValue(object __objString)
        {
            // null セーフ
            if (__objString is null)
                return string.Empty;

            // 文字列はそのまま
            if (__objString is string s)
                return s;

            // NiL.JS の値は型に応じて安全に文字列化
            if (__objString is NiL.JS.Core.JSValue jsv)
            {
                switch (jsv.ValueType)
                {
                    case NiL.JS.Core.JSValueType.Undefined:
                    case NiL.JS.Core.JSValueType.NotExists:
                    case NiL.JS.Core.JSValueType.NotExistsInObject:
                        return "null";
                    default:
                        // ToString() は JS の仕様に準拠した文字列へ
                        var str = jsv.ToString();
                        return str ?? string.Empty;
                }
            }

            // その他は Convert.ToString 経由で安全に
            try
            {
                return Convert.ToString(__objString) ?? string.Empty;
            }
            catch
            {
                return __objString.ToString() ?? string.Empty;
            }
        }
        /// <summary>
        /// Convert unknown Type array to Generic.List 
        /// </summary>
        /// <param name="___arrayobject"></param>
        /// <returns></returns>
        public static System.Collections.Generic.List<object> ConvertUnknownTypeArrayToGenericList(object ___arrayobject, string ___targetType)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel > -7)
            {
                commonLog.LogEntry("Creating Blob Array from {0} as {1}", ___arrayobject, ___targetType);
            }
            System.Collections.Generic.List<object> __list = new System.Collections.Generic.List<object>();

            if (___arrayobject is System.Array)
            {
                System.Array ___nativeArray = ___arrayobject as System.Array;
                foreach (object ___obj in ___nativeArray)
                {
                    __list.Add(___obj);
                }
            }
            return __list;
        }
        public static void ___convertNativeTypedArrayViewIntoGenericArrayList(object ___arrayView, System.Collections.Generic.List<object> ___list, string ___targetType)
        {
            try
            {





            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("___convertNativeTypedArrayViewIntoGenericArrayList() exception.", ex);
                }

            }
        }
        public static void removeLastCharFromList(ref System.Collections.Generic.List<char> ___charList, char c)
        {
            int len = ___charList.Count;
            for (int i = len - 1; i >= 0; i--)
            {
                if (___charList[i] == c)
                {
                    ___charList.RemoveAt(i);
                    return;
                }
            }
            return;
        }

        public static bool GetBooleanForSelectedAttribute(object _boolObj)
        {
            if (_boolObj is bool)
            {
                return commonData.convertObjectToBoolean(_boolObj);
            }
            else
            {
                string strBoolean = commonHTML.GetStringValue(_boolObj);
                switch (strBoolean)
                {
                    case "":
                    case "true":
                    case "True":
                    case "yes":
                    case "selected":
                    case "Selected":
                    case "SELECTED":
                        return true;
                    case "no":
                    case "false":
                    case "False":
                    case "No":
                        return false;
                }
            }
            return false;
        }
        public static bool isUTF8BytesExistsInFirst3Bytes(byte b1, byte b2, byte b3)
        {
            if (b1 == 239 && b2 == 187 && b3 == 191)
            {
                return true;
            }
            return false;
        }

        public static bool isElementAdHocNumberIsEqualToCurrent(int val)
        {
            if (___elementGeneralIncrementValue == val)
            {
                return true;
            }
            return false;
        }
        public static bool isCssRuleAdHocNumberIsEqualToCurrent(int val)
        {
            if (___cssRuleGeneralIncrementValue == val)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Returns Number which is increment By Interlocked.Increment
        /// Range is 1 to  2,147,483,647
        /// This is 100x more faster than Random.Next()
        /// 1,500 ms per 100,000,000 calls
        /// </summary>
        /// <returns></returns>

        public static int getElementAdhocRandomNumber()
        {
            if (___elementGeneralIncrementValue >= int.MaxValue)
            {
                ___elementGeneralIncrementValue = 1;
            }
            return System.Threading.Interlocked.Increment(ref ___elementGeneralIncrementValue);
        }
        /// <summary>
        /// Returns Number which is increment By Interlocked.Increment
        /// Range is 1 to  2,147,483,647
        /// This is 100x more faster than Random.Next()
        /// 1,500 ms per 100,000,000 calls
        /// </summary>
        /// <returns></returns>

        public static int getCssRuleAdhocRandomNumber()
        {
            if (___cssRuleGeneralIncrementValue >= int.MaxValue)
            {
                ___cssRuleGeneralIncrementValue = 1;
            }
            return System.Threading.Interlocked.Increment(ref ___cssRuleGeneralIncrementValue);
        }
        public static int getDocumentTimerAdhocRandomNumber()
        {
            if (___documentTimerGeneralIncrementValue >= int.MaxValue)
            {
                ___documentTimerGeneralIncrementValue = 1;
            }
            return System.Threading.Interlocked.Increment(ref ___documentTimerGeneralIncrementValue);
        }


        internal static void preprocessScriptCommentStringBuilder(ref System.Text.StringBuilder sbScript, bool StrongMode)
        {
            int HeaderRemovePattern = -1;
            try
            {
                for (int i = 0; i < sbScript.Length; i++)
                {
                    char c = sbScript[i];
                    if (char.IsLetter(c) || c == '(' || c == '$')
                    {
                        //HeaderRemovePattern = -1;
                        break;
                    }
                    else if (IsCharWhiteSpaceLimited(c))
                    {
                        if (c != '\r' && c != '\n')
                        {
                            sbScript.Remove(i, 1);
                            i--;
                        }
                    }
                    else if (c == '/')
                    {

                        if (sbScript.Length > 10 && sbScript[i + 1] == '/' && sbScript[i + 2] == '<' && sbScript[i + 3] == '!' && sbScript[i + 4] == '[' && sbScript[i + 5] == 'C' && sbScript[i + 6] == 'D' && sbScript[i + 7] == 'A' && sbScript[i + 8] == 'T' && sbScript[i + 9] == 'A' && sbScript[i + 10] == '[')
                        {
                            sbScript.Remove(i, 11);
                            i = i - 1;
                            // Pattern 1) "//<![CDATA["  -End With "//]]>""
                            HeaderRemovePattern = 1;
                            break;
                        }
                        if (sbScript.Length > 15 && sbScript[i + 1] == '*' && sbScript[i + 2] == '<' && sbScript[i + 3] == '!' && sbScript[i + 4] == '[' && sbScript[i + 5] == 'C' && sbScript[i + 6] == 'D' && sbScript[i + 7] == 'A' && sbScript[i + 8] == 'T' && sbScript[i + 9] == 'A' && sbScript[i + 10] == '[')
                        {
                            sbScript.Remove(i, 13);
                            i = i - 1;
                            // Pattern 1) "/*<![CDATA[*/"  -End With "//]]"
                            HeaderRemovePattern = 3;
                            break;
                        }

                    }
                    else if (c == '<')
                    {

                        if (sbScript.Length > 6 && sbScript[i + 1] == '!' && sbScript[i + 2] == '-' && sbScript[i + 3] == '-' && sbScript[i + 4] == '/' && sbScript[i + 5] == '/')
                        {

                            // Pattern 10) "<!--//"  -> End Width "//-->"
                            sbScript.Remove(i, 6);
                            // May be continues -->
                            if (sbScript.Length > 4 && sbScript[i] == '-' && sbScript[i + 1] == '-' && sbScript[i + 2] == '>')
                            {
                                sbScript.Remove(i, 3);
                                i = i - 1;
                                continue;
                            }

                            i = i - 1;
                            HeaderRemovePattern = 10;
                        }
                        else if (sbScript.Length > 6 && sbScript[i + 1] == '!' && sbScript[i + 2] == '[' && sbScript[i + 3] == 'C' && sbScript[i + 4] == 'D' && sbScript[i + 5] == 'A' && sbScript[i + 6] == 'T' && sbScript[i + 7] == 'A' && sbScript[i + 8] == '[')
                        {
                            sbScript.Remove(i, 9);
                            i = i - 1;
                            // Pattern 11) <!--//<![CDATA[document.MAX_ct0 ='INSERT_CLICKURL_';//]]>-->
                            if (HeaderRemovePattern == 10)
                            {
                                HeaderRemovePattern = 11;
                            }
                        }
                        else if (sbScript.Length > 5 && sbScript[i + 1] == '!' && sbScript[i + 2] == '-' && sbScript[i + 3] == '-')
                        {
                            // This pattern only remove if following is '\n' or '\r'
                            if (StrongMode == false)
                            {
                                if (sbScript[i + 4] == '\r' || sbScript[i + 4] == '\n')
                                {
                                    sbScript.Remove(i, 4);
                                    i = i - 1;
                                    HeaderRemovePattern = 30;
                                    continue;
                                }
                            }
                            else
                            {
                                sbScript.Remove(i, 4);
                                i = i - 1;
                                HeaderRemovePattern = 30;
                                continue;
                            }

                        }

                    }
                }
                for (int i = sbScript.Length - 1; i >= 0; i--)
                {
                    if (i > sbScript.Length)
                    {
                        break;
                    }
                    char c = sbScript[i];
                    if (char.IsLetter(c) || c == ';' || c == '}' || c == ')')
                    {
                        break;
                    }
                    else if (IsCharWhiteSpaceLimited(c))
                    {
                        if (c != '\r' && c != '\n')
                        {
                            sbScript.Remove(i, 1);
                            //i = i -1;
                            continue;
                        }
                    }
                    else if (c == '/')
                    {
                        if (i > 1)
                        {
                            if (sbScript[i - 1] == '*')
                            {
                                for (int cend = i - 1; cend > 1; cend--)
                                {
                                    char cendChar = sbScript[cend];
                                    if (cendChar == '*')
                                    {
                                        if (sbScript[cend - 1] == '/')
                                        {
                                            int removeLen = i - cend + 2;
                                            sbScript.Remove(cend - 1, removeLen);
                                            i = i - removeLen;
                                            break;
                                        }

                                    }

                                }
                            }
                        }
                    }
                    else if (c == '>')
                    {

                        if (sbScript[i - 1] == '-' && sbScript[i - 2] == '-' && sbScript[i - 3] == '/' && sbScript[i - 4] == '/')
                        {
                            sbScript.Remove(i - 4, 5);
                            i = i - 4;
                            continue;
                        }
                        if (sbScript[i - 1] == '-' && sbScript[i - 2] == '-')
                        {
                            sbScript.Remove(i - 2, 3);
                            i = i - 2;
                            continue;
                        }
                        int pres = -1;
                        for (int t = i; t > 0; t--)
                        {
                            if (sbScript[t] == '/')
                            {
                                if (t > 3 && sbScript[t - 1] == '/')
                                {
                                    pres = t - 1;
                                    break;
                                }

                            }
                            else if (sbScript[t] == '\r' && sbScript[t] == '\n')
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                                {
                                    commonLog.LogEntry("string ___hasInner &gt; but here is cr or lf found. skip....");
                                }
                                break;
                            }
                        }
                        if (pres > -1)
                        {
                            sbScript.Remove(pres, i - pres + 1);
                            i = pres - 1;
                            continue;
                        }

                        /*
                        switch(HeaderRemovePattern)
                        {
                            case 1:
                                // should be "//]]>"
                                sbScript.Remove(i-7, 8);
                                i = i - 7;
                                break;
                            case 3: //  "//]]"
                                sbScript.Remove(i-4, 5);
                                i = i - 4;
                                break;
                            case 10:
                                sbScript.Remove(i - 4, 5);
                                i = i - 4;
                                break;
                            case 11:
                                sbScript.Remove(i - 7,8);
                                i = i - 7;
                                break;
                            default:
                                if(sbScript.Length > 3 && sbScript[i -1] == ']' && sbScript[i -2] == ']')
                                {
                                    sbScript.Remove(i - 3,4);
                                    i = i - 3;
                                }
                                break;
                        }
                        */

                    }
                    //NextEndChar:
                    if (false) {; }

                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("PreprocessScriptComment Exception ", ex);
                }
            }
        }




        /// <summary>
        /// Checks Element type attributes to determine the script is executable or not
        /// </summary>
        /// <param name="___tagElement">Element to check</param>
        /// <returns>true or false</returns>
        public static bool isElementAttributeTypeExecutableScript(CHtmlElement ___tagElement)
        {
            if (___tagElement == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(___tagElement.___type) == false)
            {
                switch (___tagElement.___type)
                {
                    case "text/javascript":
                    case "application/javascript":
                    case "application/x-javascript":
                    case "text/x-javasript":
                    case "text/ecmascript":
                    case "application/ecmascript":
                    case "text/x-ecmascript":
                        return true;
                    default:
                        break;
                }

            }
            return false;
        }


        public static CHtmlElement[,] ResizeTableCells(int newCoNum, int newRoNum, int SkipRow, CHtmlElement[,] original)
        {
            CHtmlElement[,] newArray = new CHtmlElement[newRoNum, newCoNum];
            int _cRow = 0;
            int _cCol = 0;
            int minCols = 0;
            int minRows = 0;
            /*
			int columnCount = original.GetLength(1);
			int columnCount2 = newRoNum;
			int columns = original.GetUpperBound(0);
			try
			{
				for (int co = 0; co <= columns; co++)
				{
					Array.Copy(original, co * columnCount, newArray, co * columnCount2, columnCount);
				}
			}
			*/
            try
            {

                minCols = Math.Min(newCoNum, original.GetLength(1));
                minRows = Math.Min(newRoNum, original.GetLength(0));
                int skipRowInc = 0;
                for (_cRow = 0; _cRow < minRows; _cRow++)
                {
                    if (SkipRow >= 0 && SkipRow == _cRow)
                    {
                        skipRowInc = 1;
                    }
                    if (skipRowInc == 1 && _cRow >= newRoNum - 1)
                    {
                        break;
                    }
                    for (_cCol = 0; _cCol < minCols; _cCol++)
                    {
                        newArray[_cRow + skipRowInc, _cCol] = original[_cRow, _cCol];
                    }
                    _cCol = 0;

                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("ResizeTableCells", ex);
                }
            }
            return newArray;
        }
        public static string GetCHtmlPseudoClassTypeString(CHtmlPseudoClassType o)
        {
            System.Text.StringBuilder sbText = new StringBuilder();
            CHtmlPseudoClassType[] result = (CHtmlPseudoClassType[])Enum.GetValues(typeof(CHtmlPseudoClassType));
            foreach (CHtmlPseudoClassType eachEnum in result)
            {
                if (eachEnum == CHtmlPseudoClassType.None)
                {
                    continue;
                }
                if (IsPseudoClassTypeSet(o, eachEnum))
                {
                    sbText.Append(eachEnum.ToString());
                    sbText.Append(',');
                }
            }
            return sbText.ToString();
        }

        public static CHtmlElement[] ResizeTableRow(int newRoNum, int SkipRow, CHtmlElement[] originalRow)
        {
            CHtmlElement[] newArray = new CHtmlElement[newRoNum];
            int _cRow = 0;
            int minRows = 0;
            /*
			int columnCount = original.GetLength(1);
			int columnCount2 = newRoNum;
			int columns = original.GetUpperBound(0);
			try
			{
				for (int co = 0; co <= columns; co++)
				{
					Array.Copy(original, co * columnCount, newArray, co * columnCount2, columnCount);
				}
			}
			*/
            try
            {


                minRows = Math.Min(newRoNum, originalRow.Length);
                int skipRowInc = 0;
                for (_cRow = 0; _cRow < minRows; _cRow++)
                {
                    if (SkipRow >= 0 && SkipRow == _cRow)
                    {
                        skipRowInc = 1;
                    }
                    if (skipRowInc == 1 && _cRow >= newRoNum - 1)
                    {
                        break;
                    }

                    newArray[_cRow + skipRowInc] = originalRow[_cRow];


                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("ResizeTableRow", ex);
                }
            }
            return newArray;
        }
        public static void ResetCHtmlElementChildIndex(CHtmlElement element, int __StartPos)
        {
            if (element != null)
            {
                int z = 0;
                if (__StartPos > 0)
                {
                    z = __StartPos;
                }
                if (z >= element.___childNodes.Count)
                {
                    return;
                }
                int ___childNodesCount = element.___childNodes.Count;
                for (int i = z; i < ___childNodesCount; i++)
                {

                    CHtmlElement childElement = element.___childNodes[i] as CHtmlElement;
                    if (childElement == null)
                    {
                        element.___childNodes.RemoveAt(i);
                        i--;
                        continue;
                    }
                    childElement.___ChildNodeIndex = i;
                }
            }
        }
        /// <summary>
        /// Faster Methods to Read All Bytes From File (Does Not Throw Error)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static byte[] ReadAllBytes(string fileName)
        {
            byte[] buffer = null;

            using (FileStream fs = new FileStream(fileName,
                       FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;
        }

        internal static bool IsPseudoClassTypeSet(CHtmlPseudoClassType __stored, CHtmlPseudoClassType checkType)
        {
            return (__stored & checkType) == checkType;
        }

        /// <summary>
        /// Convert Attributes stored value to appropriate data type.
        /// </summary>
        /// <param name="newAttr"></param>
        public static void ConvertAttributeValueByNameIfNessesary(CHtmlAttribute newAttr)
        {

            if (newAttr == null)
            {
                return;
            }
            if (newAttr.value is bool || isClrNumeric(newAttr.___value))
            {
                return;
            }
            switch (newAttr.name)
            {
                case "tabindex":
                case "cols":
                case "cells":
                case "rows":
                case "maxlength":
                    if (isClrNumeric(newAttr.___value))
                    {
                        return;
                    }
                    try
                    {
                        if (string.Equals(newAttr.name, "rows", StringComparison.OrdinalIgnoreCase) == true || string.Equals(newAttr.name, "cols", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (newAttr.parentNode != null)
                            {
                                CHtmlElement ___parentElement = newAttr.parentNode as CHtmlElement;
                                if (___parentElement != null && ___parentElement.___elementTagType != CHtmlElementType.TEXTAREA)
                                {
                                    return;
                                }
                            }
                            return;
                        }
                        newAttr.value = int.Parse(commonHTML.GetStringValue(newAttr.value));
                        newAttr.value = int.Parse(commonHTML.GetStringValue(newAttr.value));
                    }
                    catch
                    {
                        newAttr.value = 0;
                    }
                    break;
                case "checked":
                    if (newAttr.___value is bool)
                    {
                        return;
                    }
                    try
                    {
                        if (newAttr.___value is string)
                        {
                            if (string.Equals(newAttr.___value as string, "checked", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                newAttr.___value = true;
                                return;
                            }
                            else if (string.Equals(newAttr.___value as string, "unchecked", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                newAttr.___value = false;
                                return;
                            }
                        }
                        // ************ [ Default is FALSE] *****************
                        newAttr.value = bool.Parse(commonHTML.GetStringValue(newAttr.value));
                    }
                    catch
                    {
                        newAttr.value = false;
                    }
                    break;
                case "iscontentedit":
                case "contenteditable":
                case "iscontenteditable":
                case "disabled":
                case "isdisabled":
                case "istextedit":

                case "multiple":
                    if (newAttr.___value is bool)
                    {
                        return;
                    }
                    try
                    {
                        // ************ [ Default is FALSE] *****************
                        newAttr.value = bool.Parse(commonHTML.GetStringValue(newAttr.___value));
                    }
                    catch
                    {
                        newAttr.value = false;
                    }
                    break;
                case "selected":
                    newAttr.value = GetBooleanForSelectedAttribute(newAttr.___value);
                    return;
                case "required":
                case "readonly":

                case "defaultselected":
                case "autofocus":
                    if (newAttr.___value is bool)
                    {
                        return;
                    }
                    try
                    {
                        // ************ [ Default is TRUE] *****************
                        if (newAttr == null)
                        {
                            newAttr.value = true;
                        }
                        string ___strBool = commonHTML.GetStringValue(newAttr.value);
                        if (string.IsNullOrEmpty(___strBool) == true)
                        {
                            newAttr.value = true;
                        }
                        else
                        {
                            newAttr.value = bool.Parse(commonHTML.GetStringValue(newAttr.___value));
                        }
                    }
                    catch
                    {
                        newAttr.value = true;
                    }
                    break;
                case "async":
                case "defer":
                case "autoplay":
                    if (newAttr.value is bool)
                    {
                        return;
                    }
                    try
                    {
                        string sBool = commonHTML.GetStringValue(newAttr.value);
                        if (sBool != null && sBool.Length == 1)
                        {
                            sBool = convertOneStringValueToBoolString(sBool);
                        }
                        if (string.Equals(sBool, "async", StringComparison.OrdinalIgnoreCase) == true || string.Equals(sBool, "defer", StringComparison.OrdinalIgnoreCase) == true || string.Equals(sBool, "true", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            newAttr.value = true;
                            return;
                        }
                        else if (string.Equals(sBool, "false", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            newAttr.value = false;
                        }
                        else
                        {
                            // defult.
                            newAttr.value = true;
                        }
                        // ************ [ Default is TRUE] *****************
                        //newAttr.value = bool.Parse(sBool);
                    }
                    catch
                    {
                        newAttr.value = true;
                    }
                    break;
                default:
                    // DO NOTHING
                    break;
            }
            return;
        }


        public static bool IsNoScriptModuleException(Exception ex)
        {
            if (ex == null)
                return false;
            if (ex is System.NullReferenceException)
            {
                if (ex.Message.Equals("No Module"))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns innerHTML by creating all property and values
        /// it ___hasInner limit of 5 level
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public static string CreateElementInnerHTML(CHtmlElement elem)
        {
            try
            {
                var sb = new System.Text.StringBuilder();

                // 修正: インデックスベースのループを使用
                int childCount = elem.___childNodes.Count;
                for (int i = 0; i < childCount; i++)
                {
                    var node = elem.___childNodes[i];

                    // 安全な型チェックとキャスト
                    if (node is CHtmlElement childElement)
                    {
                        CreateElementInnerHTMLStringStartPart(childElement, ref sb);
                        // 再帰処理
                        sb.Append(CreateElementInnerHTML(childElement));
                        CreateElementInnerHTMLStringEndPart(childElement, ref sb);
                    }
                    else if (node is CHtmlTextElement textElement)
                    {
                        // テキストノードの処理
                        sb.Append(textElement.innerText);
                    }
                }
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                {
                    commonLog.LogEntry("CreateElementInnerHTML: {0} - {1}", elem.toLogString(), sb.ToString());
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("CreateElementInnerHTML Exception: {0}", ex.Message);
                }
                return string.Empty;
            }
        }
        private static void CreateElementInnerHTMLStringStartPart(CHtmlElement node, ref System.Text.StringBuilder sb)
        {
            if (IsElemeneITextOrIDraw(node) == false && node.___elementTagType != CHtmlElementType.COMMENT && node.tagName.Length != 0)
            {
                sb.Append("<");
                sb.Append(node.tagName);
                sb.Append(" ");

                foreach (CHtmlAttribute attr in node.___attributes.Values)
                {
                    if (attr != null)
                    {
                        sb.Append(attr.name);
                        sb.Append("=");
                        sb.Append("'");
                        sb.Append(attr.value);
                        sb.Append("'");
                    }
                }
                sb.Append(" ");
                sb.Append(">");
            }
            else if (IsElemeneITextOrIDraw(node) == true)
            {
                sb.Append(node.value);
            }
        }
        private static void CreateElementInnerHTMLStringEndPart(CHtmlElement node, ref System.Text.StringBuilder sb)
        {
            if (IsElemeneITextOrIDrawOrComment(node) == false && node.tagName.Length != 0)
            {
                sb.Append("</");
                sb.Append(node.tagName);
                sb.Append(">");
            }
        }
        public static string ReplaceMultipleString(string _original, char[] replacingCharArray, string _target)
        {
            System.Text.StringBuilder charList = new StringBuilder();
            char[] _orginalCharArray = _original.ToCharArray();
            int _orignalLength = _orginalCharArray.Length;
            int _replaceingCharLength = replacingCharArray.Length;
            int _repPos = 0;
            char[] ___targetCharArray = null;
            if (string.IsNullOrEmpty(_target) == false)
            {
                ___targetCharArray = _target.ToCharArray();
            }
            for (int i = 0; i < _orignalLength; i++)
            {
                char c = _orginalCharArray[i];
                for (_repPos = 0; _repPos < _replaceingCharLength; _repPos++)
                {
                    if (replacingCharArray[_repPos] == c)
                    {
                        if (___targetCharArray == null)
                        {
                            goto ___NextCharPhase;
                        }
                        else
                        {
                            charList.Append(___targetCharArray);
                            goto ___NextCharPhase;
                        }
                    }
                }
                charList.Append(c);
            ___NextCharPhase:
                if (false) {; }
            }
            return charList.ToString();
        }
        public static string ReplaceMultipleString(string _original, string[] strArray, string _target)
        {
            System.Text.StringBuilder sb = new StringBuilder(_original);
            int strArrayLen = strArray.Length;
            string s = null;
            for (int i = 0; i < strArrayLen; i++)
            {
                s = strArray[i];
                if (s != null)
                {
                    sb.Replace(s, _target);
                }
            }
            return sb.ToString();
        }
        /*
		internal static bool IsMediaValueValid(string _mediastring)
		{
			string _mediastringLow = _mediastring;
			if(commonFasterIndexOf(_mediastringLow,",", true) == -1)
			{
				switch( _mediastringLow)
				{
					case "":
						return true;
					case "screen":
					case "only screen":
					case "screen only":
						return true;
					case "projection":
						return true;
					case "all":
						return true;
					case "print":
					case "speech":
					case "tty":
					case "braille":
					case "embossed":
						return false;
					default:
						return false;
				
				}
			}
			else
			{
				// media ___hasInner multiple
				if(commonFasterIndexOf(_mediastringLow,"screen", true) > -1)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		*/



        /// <summary>
        /// Returns ture if value is "auto" or "inherit"
        /// </summary>
        /// <param name="_s"></param>
        /// <returns></returns>
        public static bool IsStringAutoOrInherit(string _s)
        {
            bool _result = false;
            if (_s == null)
                return true;
            if (_s.Length == 4)
            {
                if (string.Equals(_s, "auto", StringComparison.Ordinal) == true)
                {

                    return true;
                }
                return false;
            }
            else if (_s.Length == 7)
            {
                if (string.Equals(_s, "inherit", StringComparison.OrdinalIgnoreCase) == true)
                {

                    return true;
                }
                return false;
            }
            return _result;
        }
        /// <summary>
        /// Returns ture if value is "auto" or "inherit" or "0"
        /// </summary>
        /// <param name="_s"></param>
        /// <returns></returns>
        public static bool IsStringAutoOrInheritOrZero(string _s)
        {
            bool _result = false;
            if (_s.Length == 1)
            {
                if (string.Equals(_s, "0", StringComparison.Ordinal) == true)
                {
                    return true;
                }
                return false;
            }
            if (_s.Length == 4)
            {
                if (string.Equals(_s, "auto", StringComparison.Ordinal) == true)
                {

                    return true;
                }
                return false;
            }
            else if (_s.Length == 7)
            {
                if (string.Equals(_s, "inherit", StringComparison.Ordinal) == true)
                {

                    return true;
                }
                return false;
            }

            return _result;
        }
        public static void checkScriptGlobalObjectIntance(IMultiversalScriptProcessor _processor)
        {
            if (_processor == null)
            { }
            else
            {
                string strCheckInstance =
              "(function(g){var root=g;var _this=this;try{if(typeof g.window==='undefined')g.window=root;}catch(e){}try{if(typeof g.self==='undefined')g.self=root;}catch(e){}var same=(typeof g.window!=='undefined'&&g.window===root&&typeof g.self!=='undefined'&&g.self===root&&typeof g.globalThis!=='undefined'&&g.globalThis===root);if(!same){try{g.window=root;g.self=root;if(typeof g.globalThis!=='undefined')g.globalThis=root;}catch(e){}same=true;}if(same){var info={windowEquals:(typeof window!=='undefined'&&window===root),selfEquals:(typeof self!=='undefined'&&self===root),globalThisEquals:(typeof globalThis!=='undefined'?globalThis===root:null),thisEquals:_this===root};try{if(typeof console!=='undefined'&&console&&typeof console.log==='function'){console.log('[MultiHtmlCraft] global unify ok '+JSON.stringify(info));}}catch(e){}}})(typeof globalThis!=='undefined'?globalThis:(typeof window!=='undefined'?window:{}));";

                _processor.execute(strCheckInstance);
            }
        }
        /// <summary>
        /// Returns ture if value is "auto" or "inherit" or "0" or "none"
        /// </summary>
        /// <param name="_s"></param>
        /// <returns></returns>
        public static bool IsStringAutoOrInheritOrZeroOrNone(string _s)
        {
            bool _result = false;
            if (_s.Length == 1)
            {
                if (string.Equals(_s, "0", StringComparison.Ordinal) == true)
                {
                    return true;
                }
                return false;
            }
            if (_s.Length == 4)
            {
                if (string.Equals(_s, "auto", StringComparison.Ordinal) == true)
                {

                    return true;
                }
                else if (string.Equals(_s, "none", StringComparison.Ordinal) == true)
                {
                    return true;
                }
                return false;
            }
            else if (_s.Length == 7)
            {
                if (string.Equals(_s, "inherit", StringComparison.Ordinal) == true)
                {

                    return true;
                }
                return false;
            }

            return _result;
        }
        /// <summary>
        /// Return true if Element is #Text, #Comment, #after, #before, doctype
        /// </summary>
        /// <param name="__tagType"></param>
        /// <returns></returns>
        public static bool IsSystemHiddenElement(CHtmlElementType __tagType)
        {
            switch (__tagType)
            {
                case CHtmlElementType._ITEXT:
                case CHtmlElementType._IDRAW:
                case CHtmlElementType._ELEMENT_BEFORE:
                case CHtmlElementType._ELEMENT_AFTER:
                case CHtmlElementType.COMMENT:
                case CHtmlElementType.DOCTYPE:
                    return true;
            }
            return false;
        }
        private static System.Collections.Generic.Dictionary<char, byte> createTagNamesFirstCharacterArray(string[] __TagNames)
        {
            System.Collections.Generic.Dictionary<char, byte> list = new System.Collections.Generic.Dictionary<char, byte>();

            int tagLen = __TagNames.Length;
            for (int i = 0; i < tagLen; i++)
            {
                list[__TagNames[i][0]] = 1;

            }
            return list;
        }
        /// <summary>
        /// Checks Selector Key matches for the element
        /// Designed Specially for :matches, :not
        /// </summary>
        /// <param name="element"></param>
        /// <param name="arSelectorKeyClassList"></param>
        /// <returns></returns>
        public static bool IsStyleElementWorkingSelectorListMatchesForElement(CHtmlElement element, System.Collections.Generic.List<CHtmlStyleKey> arSelectorKeyClassList)
        {
            if (arSelectorKeyClassList == null || arSelectorKeyClassList.Count == 0)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("IsStyleElementWorkingSelectorListMatchesForElement gets empty list.");
                }
                return false;
            }
            else
            {
                int ___SelectorKeyClassSuccessCount = 0;
                int arSelectorKeyClassListCount = arSelectorKeyClassList.Count;
                for (int i = 0; i < arSelectorKeyClassListCount; i++)
                {
                    CHtmlStyleKey lookupKeyClass = arSelectorKeyClassList[i] as CHtmlStyleKey;
                    if (lookupKeyClass != null)
                    {
                        if ((lookupKeyClass.___SelectorKeyDefinedField & CHtmlSelectorKeyClassType.TagName) == CHtmlSelectorKeyClassType.TagName)
                        {
                            if (string.Equals(lookupKeyClass.TagName, element.tagName, StringComparison.OrdinalIgnoreCase) == false)
                            {
                                return false;
                            }
                        }
                        if ((lookupKeyClass.___SelectorKeyDefinedField & CHtmlSelectorKeyClassType.ID) == CHtmlSelectorKeyClassType.ID)
                        {
                            if (string.Equals(lookupKeyClass.CssIDLowSimple, element.___idLowSimple, StringComparison.OrdinalIgnoreCase) == false)
                            {
                                return false;
                            }
                        }
                        if ((lookupKeyClass.___SelectorKeyDefinedField & CHtmlSelectorKeyClassType.ClassName) == CHtmlSelectorKeyClassType.ClassName)
                        {
                            if (lookupKeyClass.IsElementClassesMates(element.___classList) == false)
                            {
                                return false;
                            }

                        }
                        if (lookupKeyClass.___attributeKeyList != null && lookupKeyClass.___attributeKeyList.Count > 0)
                        {
                            foreach (CHtmlStyleElementSelectorKeyAttributeClass? __curKeyAttrNullable in lookupKeyClass.___attributeKeyList.Values)
                            {
                                if (__curKeyAttrNullable != null)
                                {
                                    CHtmlStyleElementSelectorKeyAttributeClass __curKeyAttr = __curKeyAttrNullable.Value;
                                    if (element.___attributes.ContainsKey(__curKeyAttr.Name) == false)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        if (__curKeyAttr.OperatorType == CSSSelectorKeyOperataorType.none)
                                        {
                                            continue;
                                        }
                                        string ___attrValue = GetElementAttributeInString(element, __curKeyAttr.Name);
                                        if (__curKeyAttr.IsValueMatches(___attrValue) == true)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                        ___SelectorKeyClassSuccessCount++;
                    }
                }
                if (___SelectorKeyClassSuccessCount == arSelectorKeyClassListCount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Check Attribut Value can be considered as true (ex.Attribute selected)
        /// </summary>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static bool isCHtmlAttributeValueTreatedAsTrue(CHtmlAttribute attr)
        {
            if (attr == null)
                return false;

            if (attr.___value is bool)
            {
                return (bool)attr.___value;
            }

            string strValue = commonHTML.GetStringValue(attr.___value);

            switch (strValue)
            {
                case "":
                    return true;
                case "true":
                case "True":
                case "TRUE":
                case "1":
                case "T":
                case "t":
                case "yes":
                case "Yes":
                case "YES":
                case "y":
                case "Y":
                    return true;
                case "false":
                case "False":
                case "FALSE":
                case "F":
                case "f":
                case "no":
                case "No":
                case "NO":
                case "n":
                case "N":
                case "0":
                case "-1":
                    return false;
            }

            return false;
        }

        /// <summary>
        /// Check If Elemenet's tagType is IText or IDraw
        /// </summary>
        /// <param name="element">Element to check</param>
        /// <returns>true if it is IText or IDraw</returns>

        public static bool IsElemeneITextOrIDraw(CHtmlElement element)
        {
            if (element == null)
                return false;
            if (element.___elementTagType == CHtmlElementType._ITEXT || element.___elementTagType == CHtmlElementType._IDRAW)
            {
                return true;
            }
            return false;
        }
        public static bool IsElemeneITextOrIDrawOrComment(CHtmlElement element)
        {
            if (element.___elementTagType == CHtmlElementType._ITEXT || element.___elementTagType == CHtmlElementType._IDRAW || element.___elementTagType == CHtmlElementType.COMMENT)
            {
                return true;
            }
            return false;
        }

        public static Color GetColor4ManagedControl(Color refColor)
        {
            System.Drawing.Color __targetColor = Color.FromArgb(refColor.R, refColor.G, refColor.B);
            return __targetColor;
        }
        public static double[] ConvertFrameSetRowsColsStringIntoDouble(string __rolscols)
        {
            if (__rolscols == null || __rolscols.Length == 0)
            {
                return null;
            }
            else
            {
                string[] sp = __rolscols.Split(',');
                int ___WildCardCount = 0;
                System.Collections.Generic.List<double> doubleList = new System.Collections.Generic.List<double>();
                for (int i = 0; i < sp.Length; i++)
                {
                    string strCur = sp[i];
                    if (strCur.Length > 0)
                    {
                        if (IsCharWhiteSpaceLimited(strCur[0]) == true || IsCharWhiteSpaceLimited(strCur[strCur.Length - 1]) == true)
                        {
                            strCur = strCur.Trim();
                        }
                        if (string.Equals(strCur, "*", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            ___WildCardCount++;
                            doubleList.Add(-1);
                        }
                        else
                        {
                            doubleList.Add(GetDoubleValueFromString(strCur, 1, -1));
                        }
                    }

                }
                return doubleList.ToArray();
            }

        }
        private const int bytesPerPixel = 4;


        public static bool isElementAfterwordCSSLookupNeedsToBeEnqueued(CHtmlElement ___element)
        {
            if (___element == null)
                return false;
            if (___element.___elementTagType == CHtmlElementType.HTML || ___element.___elementTagType == CHtmlElementType.BODY)
            {
                return true;
            }
            else
            {
                if (___element.___childNodes.Count > 0)
                {
                    int iChildLength = ___element.___childNodes.Count;
                    int ___NormalElementCount = 0;
                    int ___TextElementCount = 0;
                    for (int i = 0; i < iChildLength; i++)
                    {
                        CHtmlElement ___childElement = ___element.___childNodes[i] as CHtmlElement;
                        if (___childElement == null)
                            continue;

                        if (IsElemeneITextOrIDraw(___childElement) == true)
                        {
                            ___TextElementCount++;
                            continue;
                        }
                        if (elementTagTypesNeverSeachStyleSheetSortedList.ContainsKey(___childElement.___elementTagType) == true)
                        {
                            continue;
                        }
                        ___NormalElementCount++;
                        if (___childElement.___childNodes.Count > 0)
                        {
                            return true;
                        }
                        if (___NormalElementCount >= 5)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        #region ThreadReporter
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle,
           uint dwThreadId);
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);
        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }
        public enum ThreadInfoClass : int
        {
            ThreadQuerySetWin32StartAddress = 9
        }


        #endregion
        public static CHtmlHtmlAdjacentType GetAdjacentType(string ___s)
        {
            switch (___s)
            {
                case "beforebegin":
                case "BEFOREBegin":
                case "BEFORE-Begin":
                case "BEFORE-BEGIN":
                case "BeforeBegin":
                case "Beforebegin":
                case "beforeBegin":
                    return CHtmlHtmlAdjacentType.beforebegin;
                case "Afterbegin":
                case "AFTERBegin":
                case "AFTER-Begin":
                case "AFTER-BEGIN":
                case "AfterBegin":
                case "afterbegin":
                    return CHtmlHtmlAdjacentType.afterbegin;
                case "beforeend":
                case "BEFOREEND":
                case "BEFOR-EEND":
                case "BeforeEnd":
                case "Beforeend":
                    return CHtmlHtmlAdjacentType.beforeend;
                case "afterend":
                case "Afterend":
                case "AFTEREND":
                case "AfterEnd":
                case "After-end":
                case "After_End":
                    return CHtmlHtmlAdjacentType.afterend;

            }
            return CHtmlHtmlAdjacentType.afterend;
        }



        public static CHtmlPseudoClassType GetPseudoClassTypeFromName(string _pseudoName)
        {
            switch (_pseudoName)
            {
                case "":
                case null:
                    return CHtmlPseudoClassType.None;
                case ":hover":
                    return CHtmlPseudoClassType.HoverPseudoClass;
                case ":link":
                    return CHtmlPseudoClassType.LinkPseudoClass;
                case ":visited":
                case ":visit":
                    return CHtmlPseudoClassType.VisitedPseudoClass;
                case ":checked":
                    return CHtmlPseudoClassType.CheckedPseudoClass;
                case ":active":
                    return CHtmlPseudoClassType.ActivePseudoClass;
                case ":after":
                    return CHtmlPseudoClassType.AfterPseudoClass;
                case ":lang":
                    return CHtmlPseudoClassType.LangPseudoClass;
                case ":before":
                    return CHtmlPseudoClassType.BeforePseudoClass;
                case ":root":
                    return CHtmlPseudoClassType.RootPseudoClass;
                case ":placeholder":
                case "::placeholder":
                case ":-webkit-input-placeholder":
                case ":-moz-input-placeholder":
                case ":-moz-placeholder":
                case ":-ms-input-placeholder":
                case ":moz-placeholder":
                    return CHtmlPseudoClassType.PlaceHolderPseudoClass;
                case ":focus":
                case ":-moz-focus-inner":
                case ":-webkit-focus-inner":
                case ":-ms-focus-inner":
                case ":moz-focus-inner":
                    return CHtmlPseudoClassType.FocusPseudoClass;
                case ":first-line":
                case ":firstline":
                    return CHtmlPseudoClassType.FirstLinePseudoClass;
                case ":first-letter":
                case ":firstletter":
                    return CHtmlPseudoClassType.FirstLetterPseudoClass;
                case ":first-child":
                case ":first":
                case ":firstchild":
                    return CHtmlPseudoClassType.FirstChildPseudoClass;
                case ":required":
                    return CHtmlPseudoClassType.RequiredPseudoClass;
                case ":selection":
                case ":-moz-selection":
                case ":-webkit-selection":
                case "::-webkit-selection":
                    return CHtmlPseudoClassType.SelectionPseudoClass;
                case ":dir":
                    return CHtmlPseudoClassType.DirPseudoClass;
                case ":empty":
                    return CHtmlPseudoClassType.EmptyPseudoClass;
                case ":target":
                    return CHtmlPseudoClassType.TargetPseudoClass;
                case ":valid":
                    return CHtmlPseudoClassType.ValidPseudoClass;
                case ":invalid":
                    return CHtmlPseudoClassType.InvalidPseudoClass;
                case ":enabled":
                    return CHtmlPseudoClassType.EnabledPseudoClass;
                case ":disabled":
                    return CHtmlPseudoClassType.DisabledPseudoClass;
                case ":optional":
                    return CHtmlPseudoClassType.OptionalPseudoClass;
                case ":first-of-type":
                    return CHtmlPseudoClassType.FirstOfTypePseudoClass;
                case ":nth-of-type":
                    return CHtmlPseudoClassType.NthOfTypePseudoClass;
                case ":nth-of-child":
                case ":nth-child":
                    return CHtmlPseudoClassType.NthChildPseudoClass;
                case ":nth-of-last-child":
                case ":nth-last-child":
                    return CHtmlPseudoClassType.NthLastChildPseudoClass;
                case ":nth-of-last-type":
                case ":nth-last-of-type":

                    return CHtmlPseudoClassType.NthLastOfTypePseudoClass;
                case ":match":
                case ":matches":
                    return CHtmlPseudoClassType.MatchesConditionPseudoClass;
                case ":not":
                    return CHtmlPseudoClassType.NotConditionPseudoClass;
                case ":last-child":
                case ":lastchild":
                case ":last":
                    return CHtmlPseudoClassType.LastChildPseudoClass;
                case ":last-of-type":
                    return CHtmlPseudoClassType.LastOfTypePseudoClass;
                case ":-moz-full-screen":
                case ":full-screen":
                case ":-webkit-full-screen":
                    return CHtmlPseudoClassType.FullScreenPseudoClass;
                case ":scrollbar-button":
                case ":-webkit-scrollbar-button":
                    return CHtmlPseudoClassType.ScrollBarButtonPseudoClass;
                case ":clear":
                case ":-ms-clear":
                    return CHtmlPseudoClassType.ClearPseudoClass;
                case ":vertical":
                    return CHtmlPseudoClassType.VerticalPseudoClass;
                case ":horizontal":
                    return CHtmlPseudoClassType.HorizontalPseudoClass;
                case ":only-child":
                    return CHtmlPseudoClassType.OnlyChildPseudoClass;
                case ":only-of-type":
                    return CHtmlPseudoClassType.OnlyOfTypePseudoClass;
                case ":indeterminate":
                    return CHtmlPseudoClassType.IndeterminatePseudoClass;
                case ":contains":
                    return CHtmlPseudoClassType.ContainsPseudoClass;
                case ":start":
                    return CHtmlPseudoClassType.StartPseudoClass;
                case ":end":
                    return CHtmlPseudoClassType.EndPseudoClass;
                case ":anylink":
                case ":any-link":
                case ":-moz-any-link":
                case ":-webkit-any-link":
                case ":-ms-any-link":
                case ":-khtml-any-link":
                    return CHtmlPseudoClassType.AnyLinkPseudoClass;
                case ":default":
                    return CHtmlPseudoClassType.DefaultPseudoClass;
                case ":increment":
                    return CHtmlPseudoClassType.IncrementPseudoClass;
                case ":decrement":
                    return CHtmlPseudoClassType.DecrementPseudoClass;

                case ":function":
                case ":-webkit-scrollbar-track":
                case ":scrollbar-track":
                case ":-webkit-scrollbar-corner":
                case ":-webkit-scrollbar":
                case ":-webkit-scrollbar-thumb":
                case ":-webkit-scrollbar-track-piece":
                case ":-o-prefocus":
                case ":button":
                case ":-webkit-search-decoration":
                case ":-moz-search-decoration":
                case ":search-decoration":
                case ":eq":
                case ":left":
                case ":-webkit-search-cancel-button":
                case ":-moz-handler-blocked":
                case ":-webkit-outer-spin-button":
                case ":-webkit-inner-spin-button":
                    return CHtmlPseudoClassType.UnknownPseudoClass;
            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel < 3)
            {
                commonLog.LogEntry("Unknown CSS Pseudo Name : {0}", _pseudoName);
            }
            return CHtmlPseudoClassType.UnknownPseudoClass;
        }

        public static int GetNextCharacterPositionFromStringBuilder(char findc, int startPos, ref System.Text.StringBuilder sb, bool IsSearchCharaterWhiteSpace)
        {
            int i = 0;
            char c = '\0';
            int sbLen = sb.Length;
            for (i = startPos + 1; i < sbLen; i++)
            {
                c = sb[i];
                if (c == findc || (IsSearchCharaterWhiteSpace == true && IsCharWhiteSpaceLimited(c) == true))
                {
                    if (i > 0)
                    {
                        if (findc == '\"' || findc == '\'')
                        {
                            // One character before searching character is \\ it may be comment block. ignore one...
                            if (sb[i - 1] == '\\')
                            {
                                continue;
                            }
                        }
                    }
                    return i;
                }
                else if (c == '\'' || c == '\"')
                {
                    // The Attributes may contains quoted block search to end part
                    // onclick=\"call ('<?XML ID=\"utf-8\"?>')\"
                    if (c != findc && i < sbLen)
                    {
                        for (int nq = i + 1; nq < sbLen; nq++)
                        {
                            char nqc = sb[nq];
                            if (nqc == c)
                            {
                                i = nq;
                                goto NextChar;
                            }
                            else if (nqc == findc)
                            {
                                if (nq > 0 && sb[nq - 1] != '\\')
                                {
                                    return nq;
                                }
                            }
                        }

                    }
                }
            NextChar:
                if (false) {; }
            }
            return i;
        }
        /// <summary>
        /// Conver Gziped Bytes into Ungziped Bytes
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] GetUnGzipBytes(byte[] data)
        {
            using (MemoryStream input = new MemoryStream(data.Length))
            {
                input.Write(data, 0, data.Length);
                input.Position = 0;
                /*
				using (ICSharpCode.SharpZipLib.GZip.GZipInputStream gzip = new ICSharpCode.SharpZipLib.GZip.GZipInputStream(input))
				{	
					using (MemoryStream output = new MemoryStream())
					{
						byte[] buff = new byte[64];
						int read = -1;
						read = gzip.Read(buff, 0, buff.Length);
						while (read > 0)
						{
							output.Write(buff, 0, read);
							read = gzip.Read(buff, 0, buff.Length);
						}
						gzip.Close();
						return output.ToArray();
					}
				}
                 */
                return new byte[0];
            }
        }
        /// <summary>
        /// Function always returns true
        /// </summary>
        /// <returns>always true</returns>
        public static bool GetTrue()
        {
            return true;
        }
        /// <summary>
        /// Faster Returns Host Name from Url String
        /// Normal Way             : 44000 ms
        /// GetHostFromUrlString() : 1.300 ms
        /// 10000000 loop
        /// </summary>
        /// <param name="__url"></param>
        /// <returns></returns>
        public static string GetHostFromUrlString(string __url)
        {
            short prefend = -1;
            if (__url.Length == 0)
            {
                return "";
            }
            if (__url[0] == 'h')
            {
                if (__url.StartsWith("http://", StringComparison.Ordinal) == true)
                {
                    prefend = 7;
                }
                else if (__url.StartsWith("https://", StringComparison.Ordinal) == true)
                {
                    prefend = 8;
                }
            }
            else if (__url[0] == 'f')
            {
                if (__url.StartsWith("ftp://", StringComparison.Ordinal) == true)
                {
                    prefend = 6;
                }
                else if (__url.StartsWith("ftps://", StringComparison.Ordinal) == true)
                {
                    prefend = 7;
                }

            }
            if (prefend > -1)
            {
                int nextShash = __url.IndexOf('/', prefend);
                if (nextShash > -1)
                {
                    return __url.Substring(prefend, nextShash - prefend);
                }
                else
                {
                    return __url.Substring(prefend);
                }
            }
            return "";
        }





        /// <summary>
        /// if content type is webP ContentType
        /// </summary>
        /// <param name="___strContentType"></param>
        /// <returns></returns>
        public static bool isContentTypeGoogleWebPImage(string ___strContentType)
        {
            switch (___strContentType)
            {
                case "image/webp":
                case "image/Webp":
                    return true;
            }
            return false;
        }
        internal static CHtmlFontInfo GetCHtmlFontInfoFromTagElementStyle(CHtmlElement tagElement, CHtmlCSSStyleSheet ___style, CHtmlDocument ___document, CHtmlFontInfo __baseUserFont)
        {
            float _FontSize = 10F;
            string _FontName = null;
            string _SizeString = null;
            bool IsBold = false;
            bool IsItalic = false;
            bool IsUnderLine = false;
            bool IsStrikeout = false;

            System.Drawing.FontStyle fntStyle = FontStyle.Regular;


            if (__baseUserFont != null)
            {
                _FontSize = __baseUserFont.FontSize;
                _FontName = __baseUserFont.FontName;
                _SizeString = __baseUserFont.SizeString;
                if (__baseUserFont.FontStyle != 0)
                {
                    System.Drawing.FontStyle __baseFontStyle = (System.Drawing.FontStyle)__baseUserFont.FontStyle;
                    if ((__baseFontStyle & FontStyle.Bold) == FontStyle.Bold)
                    {
                        IsBold = true;
                    }
                    if ((__baseFontStyle & FontStyle.Italic) == FontStyle.Italic)
                    {
                        IsItalic = true;
                    }
                    if ((__baseFontStyle & FontStyle.Underline) == FontStyle.Underline)
                    {
                        IsUnderLine = true;
                    }
                    if ((__baseFontStyle & FontStyle.Strikeout) == FontStyle.Strikeout)
                    {
                        IsStrikeout = true;
                    }

                }
            }

            if (tagElement != null)
            {
                switch (tagElement.___elementTagType)
                {

                    /* --- ABSOLUTE ---
                    * SHOULD COME FROM Style
                    case "h1":
                        _FontSize = 20;
                        IsBold = true;
                        break;
                    case "h2":
                        _FontSize = 18;
                        IsBold = true;
                        break;
                    case "h3":
                        _FontSize = 16;
                        IsBold = true;
                        break;
                    case "h4":
                        _FontSize = 14;
                        IsBold = true;
                        break;
                    case "h5":
                        _FontSize = 12;
                        IsBold = true;
                        break;
                    */
                    case CHtmlElementType.SMALL:
                        IsBold = false;
                        break;
                    case CHtmlElementType.STRONG:
                    case CHtmlElementType.B:
                    case CHtmlElementType.BIG:
                        IsBold = true;
                        break;
                    case CHtmlElementType.Q:
                        IsItalic = true;
                        IsBold = true;
                        break;
                    case CHtmlElementType.I:
                    case CHtmlElementType.CITE:
                    case CHtmlElementType.EM:
                    case CHtmlElementType.VAR:
                    case CHtmlElementType.ADDRESS:
                        IsItalic = true;
                        break;
                    case CHtmlElementType.STRIKE:
                    case CHtmlElementType.S:
                        IsStrikeout = true;
                        break;
                    case CHtmlElementType.U:
                        IsUnderLine = true;
                        break;
                }
            }
            if (___style == null && tagElement != null && tagElement.___style != null)
            {
                ___style = tagElement.___style;
            }
            if (___style != null)
            {

                if (string.IsNullOrEmpty(___style.FontSize) == false)
                {
                    _SizeString = ___style.FontSize;
                    switch (_SizeString)
                    {
                        /* 1-10 should have been converted into pixel by this stage*/
                        case "1":
                            _FontSize = 8;
                            break;
                        case "2":
                            _FontSize = 9;
                            break;
                        case "3":
                        case "auto":
                            _FontSize = 10;
                            break;
                        case "4":
                            _FontSize = 13;
                            break;
                        case "5":
                            _FontSize = 16;
                            break;
                        case "6":
                            _FontSize = 20;
                            break;
                        case "7":
                            _FontSize = 25;
                            break;
                        case "+1":
                            _FontSize = _FontSize + 1;
                            break;
                        case "-1":
                        case "small":
                            _FontSize = _FontSize - 1;
                            break;
                        case "+2":
                            _FontSize = _FontSize + 2;
                            break;
                        case "-2":
                        case "smaller":
                            _FontSize = _FontSize - 2;
                            break;
                        case "tall":
                            _FontSize = 20;
                            break;
                        default:
                            // Some Incoming "font-size:97% arial;" may cause trouble.
                            // To Fix it, Remove string after '%'.
                            int percentPos = _SizeString.LastIndexOf('%');
                            if (percentPos > -1 && percentPos < _SizeString.Length - 1)
                            {
                                ___style.FontSize = _SizeString.Substring(0, percentPos + 1);
                                _SizeString = ___style.FontSize;

                            }


                            bool boolUnitsPixcel = _SizeString.EndsWith("px", StringComparison.OrdinalIgnoreCase);
                            bool boolUnitsEM = _SizeString.EndsWith("em", StringComparison.OrdinalIgnoreCase);
                            if (boolUnitsEM == true)
                            {
                                if (_SizeString.Length <= 2)
                                {
                                    boolUnitsEM = false;
                                }
                                else
                                {
                                    if (char.IsNumber(_SizeString[_SizeString.Length - 3]) == false)
                                    {
                                        boolUnitsEM = false;
                                    }
                                }
                            }
                            if (boolUnitsEM == true)
                            {
                                // FontSpec Size EM is delicate size so we handeles differently as normal one...
                                string strEMNum = _SizeString.Substring(0, _SizeString.Length - 2);
                                float emFontSize = 0;
                                if (float.TryParse(strEMNum, out emFontSize) == true)
                                {
                                    if (emFontSize > 0)
                                    {
                                        _FontSize = 10f * emFontSize * 0.625f;
                                    }
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(_SizeString) == false)
                                {
                                    if (tagElement != null)
                                    {
                                        _FontSize = (float)commonHTML.GetDoubleValueFromString(_SizeString, _FontSize, tagElement.___HTMLTagRemUnitSize);
                                    }
                                    else
                                    {
                                        _FontSize = (float)commonHTML.GetDoubleValueFromString(_SizeString, _FontSize, -1);
                                    }
                                }
                            }
                            if (_FontSize >= 100)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
                                {
                                    commonLog.LogEntry("{1} Style FontSize {0} was too big, change to fix value", ___style.FontSize, tagElement);
                                }
                                _FontSize = 10;
                            }
                            if (boolUnitsPixcel == true)
                            {
                                _FontSize = _FontSize * 0.75F;
                            }

                            break;
                    }

                }

                switch (___style.___FontStyleComputedValueType)
                {
                    case CSSFontStyleType.normal:
                        IsUnderLine = false;
                        IsItalic = false;
                        break;
                    case CSSFontStyleType.italic:
                    case CSSFontStyleType.oblique:
                        IsItalic = true;
                        break;
                }

                if (___style.___TextDecorationComputedValueType != CSSTextDecorationType.none)
                {
                    switch (___style.___TextDecorationComputedValueType)
                    {
                        case CSSTextDecorationType.none:
                            IsBold = false; IsItalic = false; IsStrikeout = false; IsUnderLine = false;
                            break;
                        case CSSTextDecorationType.underline:
                            IsUnderLine = true;
                            break;
                        case CSSTextDecorationType.overline:
                            IsStrikeout = true;
                            break;
                        case CSSTextDecorationType.linethrough:
                            IsStrikeout = true;
                            break;
                        case CSSTextDecorationType.blink:
                            IsItalic = true; IsStrikeout = false; IsUnderLine = false;
                            break;
                    }
                }
                if (___style.___FontWeightComputedValueType != CSSFontWeightType.normal)
                {
                    switch (___style.___FontWeightComputedValueType)
                    {

                        case CSSFontWeightType.normal:
                            IsBold = false;
                            break;
                        default:
                            IsBold = true;
                            break;

                    }
                }

            }
        FontProcessDone:

            if (IsBold)
            {
                fntStyle |= FontStyle.Bold;
            }
            if (IsItalic)
            {
                fntStyle |= FontStyle.Italic;
            }
            if (IsUnderLine)
            {
                fntStyle |= FontStyle.Underline;
            }
            if (IsStrikeout)
            {
                fntStyle |= FontStyle.Strikeout;
            }
            if (_FontSize < commonHTML.CSS_FONT_Size_Shoud_Be_GreaterThan)
            {
                if (___style != null)
                {
                    ___style.StyleCommentAdd("FontSpec Size is too small. ");
                }
                _FontSize = commonHTML.CSS_FONT_Size_Shoud_Be_GreaterThan;
                _SizeString = commonHTML.CSS_FONT_Size_Shoud_Be_GreaterThan.ToString();
            }
            CHtmlFontInfo newFont = new CHtmlFontInfo(_FontName, _FontSize);
            newFont.SizeString = _SizeString;


            return newFont;
        }
        public static CHtmlElement? GetParentElementFromElement(CHtmlElement ___currentElement, CHtmlElementType parentTagType, int lookupDepth)
        {
            if (___currentElement == null)
            {
                return null;
            } else
            {
                if (lookupDepth < 0)
                {
                    lookupDepth = 16;
                }
                int i = 0;
                CHtmlElement ___parentElement = ___currentElement.___getParentElement();
                while (___parentElement != null && i < lookupDepth)
                {
                    if (i > lookupDepth)
                    {
                        break;
                    }


                    if (___parentElement.___elementTagType == parentTagType)
                    {
                        return ___parentElement;
                    }


                    ___parentElement = ___parentElement.___getParentElement();
                    i++;
                }
            }
            return null;
        }


        public static List<CHtmlElement> createChildInputElementList(CHtmlElement ownerFormElement)
        {
            List<CHtmlElement> list = new List<CHtmlElement>();
            foreach (CHtmlNode childNode in ownerFormElement.___childNodes)
            {
                if (childNode is CHtmlElement childElement)
                {
                    if (childElement.___elementTagType == CHtmlElementType.INPUT || childElement.___elementTagType == CHtmlElementType.SELECT || childElement.___elementTagType == CHtmlElementType.TEXTAREA || childElement.___elementTagType == CHtmlElementType.BUTTON)
                    {
                        list.Add(childElement);
                    }
                    else
                    {
                        List<CHtmlElement> subList = createChildInputElementList(childElement);
                        if (subList.Count > 0)
                        {
                            list.AddRange(subList);
                        }
                    }
                }
            }
            return list;
        }


        public static bool IsProhibittedScriptUrl(string ___url)
        {
            if (___url.IndexOf("googlesyndication.com", StringComparison.Ordinal) > -1)
            {
                return true;
            }
            else if (___url.EndsWith(".js", StringComparison.Ordinal) == true)
            {
                if (___url.EndsWith("show_ads.js", StringComparison.Ordinal) == true)
                {
                    return true;
                }
                if (___url.EndsWith("ods.js", StringComparison.Ordinal) == true)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsHyphenChar(char _char)
        {

            if (_char >= 46 && _char <= 127)
            {
                return false;
            }
            else if (_char == 45)
            {
                return true;
            }

            switch ((int)_char)
            {
                case 45:
                case 173:
                case 1418:
                case 1470:
                case 5120:
                case 6150:
                case 8208:
                case 8209:
                case 8210:
                case 8211:
                case 8212:
                case 8213:
                case 8275:
                case 8315:
                case 8331:
                case 8722:
                case 65123:
                case 65293:
                    return true;
            }
            return false;
        }



        /// <summary>
        /// 0 : Not Tested
        /// 1 : Success
        /// 2 : Failed
        /// </summary>
        public static byte ___HighResolutionTimerOnWindowsTestResult = 0;



        /// <summary>
        /// Test Prototype of object is owner of ___owner object
        /// </summary>
        /// <param name="___owner">owner object </param>
        /// <param name="___prototypeObject">test prorotype</param>
        /// <returns>0: further test is required
        ///                 1: success
        ///                 2: faied
        /// </returns>
        internal static int isPrototypeOf_precheck(object ___owner, object ___protoObject)
        {
            if (___protoObject == null)
            {
                return 2;
            }
            else if (object.Equals(___protoObject, "undefined") == true)
            {
                return 2;
            }
            return 0;
        }
        /*
        /// <summary>
        /// Checks if DOM Element build is required or not
        /// </summary>
        /// <param name="___contentLength">content length</param>
        /// <returns>true : preload false : normal </returns>
        internal static bool isDOMDocumentPreLoadBuildMode(long ___contentLength)
        {
            if(commonHTTP_Synchronous_Download_Threshold < 0 || ___contentLength < 0)
            {
                return false;
            }else
            {
                if(commonHTTP_Synchronous_Download_Threshold > ___contentLength )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        */

        public static bool isBrowserClassicMSIE(string keyName, string ___version)
        {
            if (string.Equals(keyName, "MSIE", StringComparison.Ordinal) == false)
            {
                return false;
            }
            int pos = ___version.IndexOf('.');
            string MajorStr = null;
            if (pos != -1)
            {
                MajorStr = ___version.Substring(0, pos);
            }
            else
            {
                MajorStr = ___version;
            }
            if (string.IsNullOrEmpty(MajorStr) == false)
            {
                int verNum = -1;
                if (int.TryParse(MajorStr, out verNum) == true)
                {
                    if (verNum >= 4 && verNum <= 11)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// Faster CLR numeric type check
        /// only checks CLR numeric type
        /// </summary>
        /// <param name="___obj"></param>
        /// <returns></returns>
        public static bool isClrNumeric(object ___obj)
        {
            switch (___obj)
            {
                case int i: return true;
                case double d: return true;
                case short s: return true;
                case float f: return true;
                case decimal dc: return true;
                case uint ui: return true;
                case long l: return true;
            }
            return false;
        }
        public static string convertBlobToDataURL(CHtmlBlob blob)
        {

            string strBase64 = string.Empty;
            string mimeType = string.Empty;
            try
            {

                if (blob != null)
                {
                    CHtmlNativeArray ___nativeArray = blob.___blobArray as CHtmlNativeArray;
                    if (___nativeArray.___byteArray != null)
                    {
                        strBase64 = Convert.ToBase64String(___nativeArray.___byteArray);
                    }
                    else if (___nativeArray.___int16Array != null)
                    {
                        byte[] bts = new byte[___nativeArray.___int16Array.Length];
                        Buffer.BlockCopy(___nativeArray.___int16Array, 0, bts, 0, ___nativeArray.___int16Array.Length - 1);
                        strBase64 = Convert.ToBase64String(bts);
                    }
                    else if (___nativeArray.___int32Array != null)
                    {
                        byte[] bts = new byte[___nativeArray.___int32Array.Length];
                        Buffer.BlockCopy(___nativeArray.___int32Array, 0, bts, 0, ___nativeArray.___int32Array.Length - 1);
                        strBase64 = Convert.ToBase64String(bts);
                    }
                    else if (___nativeArray.___floatArray != null)
                    {
                        byte[] bts = new byte[___nativeArray.___floatArray.Length];
                        Buffer.BlockCopy(___nativeArray.___int16Array, 0, bts, 0, ___nativeArray.___floatArray.Length - 1);
                        strBase64 = Convert.ToBase64String(bts);
                    }
                    else if (___nativeArray.___doubleArray != null)
                    {
                        byte[] bts = new byte[___nativeArray.___doubleArray.Length];
                        Buffer.BlockCopy(___nativeArray.___int16Array, 0, bts, 0, ___nativeArray.___doubleArray.Length - 1);
                        strBase64 = Convert.ToBase64String(bts);
                    }
                    else
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                        {
                            commonLog.LogEntry("BUGBUG!! CHtmlFileReader.readAsDataURL() Could not covert to bytes array : {0}", ___nativeArray.___arrayType);

                        }
                    }
                    mimeType = blob.___type;

                }


            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("CHtmlFileReader.readAsDataURL() Exception...", ex);

                }
            }
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("data:");
            sb.Append(mimeType.Trim());
            sb.Append(";base64,");
            sb.Append(strBase64);
            return sb.ToString();
        }
        readonly static DateTime ___unix1970date = new DateTime(1970, 1, 1, 0, 0, 0);
        public static long convertDateTimeToUnix(DateTime d)
        {
            TimeSpan timeSpan = d - ___unix1970date;

            return (long)timeSpan.TotalSeconds;
        }
        public static DateTime convertUnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixtime).ToLocalTime();
            return dtDateTime;
        }
        /// <summary>
        /// This method is temporarily implemented for project migraration. Should not be used.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="param"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetTextAreaColsRowsWith(CHtmlElement elem, int param, System.Drawing.Font obj)
        {
            return 100;
        }
        /// <summary>
        ///  This method is temporarily implemented for project migraration. Should not be used.
        /// </summary>
        public static object ConvertIBase64ImageToImage(string ___url)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetStyle"></param>
        /// <param name="___attrNameType">0 :BackgorundImage, 1: ListStyleImage</param>
#pragma warning disable IDE1006 // 命名スタイル
        internal static void parseCSSBackgroundImageIntoMultipleImageData(CHtmlCSSStyleSheet targetStyle, int ___attrNameType)
#pragma warning restore IDE1006 // 命名スタイル
        {
            string backImg = null;
            switch (___attrNameType)
            {
                case 0:
                    backImg = targetStyle.___BackgroundImage;
                    break;
                case 1:
                    backImg = targetStyle.___ListStyleImage;
                    break;
            }
            if (string.IsNullOrEmpty(backImg) == true)
            {
                return;
            }
            int ___properConmaCunt = 0;
            string[] spString = commonHTML.SplitMultipleValuesToArray(backImg, ref ___properConmaCunt, true);
            if (___properConmaCunt == 0)
            {
                if (targetStyle.___multipleBackgroundImageDataSet.Count == 0)
                {
                    // Data is no Multi Data exists. create now.
                    CHtmlStyleElementMultpleImageData __mulidata = new CHtmlStyleElementMultpleImageData();
                    targetStyle.___multipleBackgroundImageDataSet.Add(__mulidata);
                    if (spString.Length > 0)
                    {
                        if (___attrNameType == 0)
                        {
                            __mulidata.background_image_origin = spString[0];
                            if (commonHTML.IsStringUrlCSSString(__mulidata.background_image_origin) == true)
                            {
                                __mulidata.background_image_fullUrl = commonHTML.GetProperImageString(spString[0], targetStyle, null, targetStyle.___ImageUrlHint);
                            }
                            else if (commonHTML.isStringCSSGradient(__mulidata.background_image_origin) == true)
                            {
                                __mulidata.Gradation = commonHTML.CreateGradationData(__mulidata.background_image_origin, (double)targetStyle.___styleSizeMode);
                            }
                        }
                        else
                        {
                            __mulidata.liststyle_image_origin = spString[0];
                            if (commonHTML.IsStringUrlCSSString(__mulidata.liststyle_image_origin) == true)
                            {
                                __mulidata.liststyle_image_fullUrl = commonHTML.GetProperImageString(spString[0], targetStyle, null, targetStyle.___ImageUrlHint);
                            }
                            else if (commonHTML.isStringCSSGradient(__mulidata.liststyle_image_origin) == true)
                            {
                                __mulidata.Gradation = commonHTML.CreateGradationData(__mulidata.liststyle_image_origin, (double)targetStyle.___styleSizeMode);
                            }
                        }
                    }
                }
                else
                {
                    // set top multi data
                    CHtmlStyleElementMultpleImageData __mulidata = targetStyle.___multipleBackgroundImageDataSet[0];
                    if (spString.Length > 0)
                    {
                        if (___attrNameType == 0)
                        {
                            __mulidata.background_image_origin = spString[0];
                            if (commonHTML.IsStringUrlCSSString(__mulidata.background_image_origin) == true)
                            {
                                __mulidata.background_image_fullUrl = commonHTML.GetProperImageString(spString[0], targetStyle, null, targetStyle.___baseUrl);
                                __mulidata.ImageType = CSSMultipleImageDataType.Image;
                            }
                            else if (commonHTML.isStringCSSGradient(__mulidata.background_image_origin) == true)
                            {
                                __mulidata.Gradation = commonHTML.CreateGradationData(__mulidata.background_image_origin, (double)targetStyle.___styleSizeMode);
                                __mulidata.ImageType = CSSMultipleImageDataType.Gradation;
                            }
                        }
                        else
                        {
                            __mulidata.liststyle_image_origin = spString[0];
                            if (commonHTML.IsStringUrlCSSString(__mulidata.liststyle_image_origin) == true)
                            {
                                __mulidata.liststyle_image_fullUrl = commonHTML.GetProperImageString(spString[0], targetStyle, null, targetStyle.___baseUrl);
                                __mulidata.ImageType = CSSMultipleImageDataType.Image;
                            }
                            else if (commonHTML.isStringCSSGradient(__mulidata.liststyle_image_origin) == true)
                            {
                                __mulidata.Gradation = commonHTML.CreateGradationData(__mulidata.liststyle_image_origin, (double)targetStyle.___styleSizeMode);
                                __mulidata.ImageType = CSSMultipleImageDataType.Gradation;
                            }
                        }
                    }

                }
            }
            else
            {
                if (targetStyle.___multipleBackgroundImageDataSet.Count == 0)
                {
                    foreach (string s in spString)
                    {
                        CHtmlStyleElementMultpleImageData __multiData = new CHtmlStyleElementMultpleImageData();
                        targetStyle.___multipleBackgroundImageDataSet.Add(__multiData);

                        if (___attrNameType == 0)
                        {
                            __multiData.background_image_origin = s;
                            if (commonHTML.IsStringUrlCSSString(__multiData.background_image_origin) == true)
                            {
                                __multiData.background_image_fullUrl = commonHTML.GetProperImageString(s, targetStyle, null, targetStyle.___baseUrl);
                                __multiData.ImageType = CSSMultipleImageDataType.Image;
                            }
                            else if (commonHTML.isStringCSSGradient(__multiData.background_image_origin) == true)
                            {
                                __multiData.Gradation = commonHTML.CreateGradationData(__multiData.background_image_origin, (double)targetStyle.___styleSizeMode);
                                __multiData.ImageType = CSSMultipleImageDataType.Gradation;
                            }
                        }
                        else
                        {
                            __multiData.liststyle_image_origin = s;
                            if (commonHTML.IsStringUrlCSSString(__multiData.liststyle_image_origin) == true)
                            {
                                __multiData.liststyle_image_fullUrl = commonHTML.GetProperImageString(s, targetStyle, null, targetStyle.___baseUrl);
                                __multiData.ImageType = CSSMultipleImageDataType.Image;
                            }
                            else if (commonHTML.isStringCSSGradient(__multiData.liststyle_image_origin) == true)
                            {
                                __multiData.Gradation = commonHTML.CreateGradationData(__multiData.liststyle_image_origin, (double)targetStyle.___styleSizeMode);
                                __multiData.ImageType = CSSMultipleImageDataType.Gradation;
                            }
                        }

                    }
                }
                else
                {
                    int spStringLen = spString.Length;
                    for (int i = 0; i < spStringLen; i++)
                    {
                        CHtmlStyleElementMultpleImageData __multiData = null;
                        if (i < targetStyle.___multipleBackgroundImageDataSet.Count)
                        {
                            __multiData = targetStyle.___multipleBackgroundImageDataSet[i];
                        }
                        else
                        {
                            __multiData = new CHtmlStyleElementMultpleImageData();
                            targetStyle.___multipleBackgroundImageDataSet.Add(__multiData);
                        }
                        if (__multiData != null)
                        {
                            if (___attrNameType == 0)
                            {
                                __multiData.background_image_origin = spString[i];
                                if (commonHTML.IsStringUrlCSSString(__multiData.background_image_origin) == true)
                                {
                                    __multiData.background_image_fullUrl = commonHTML.GetProperImageString(spString[i], targetStyle, null, targetStyle.___baseUrl);
                                    __multiData.ImageType = CSSMultipleImageDataType.Image;
                                }
                                else if (commonHTML.isStringCSSGradient(__multiData.background_image_origin) == true)
                                {
                                    __multiData.Gradation = commonHTML.CreateGradationData(__multiData.background_image_origin, (double)targetStyle.___styleSizeMode);
                                    __multiData.ImageType = CSSMultipleImageDataType.Gradation;
                                }
                            }
                            else
                            {
                                __multiData.liststyle_image_origin = spString[i];
                                if (commonHTML.IsStringUrlCSSString(__multiData.liststyle_image_origin) == true)
                                {
                                    __multiData.liststyle_image_fullUrl = commonHTML.GetProperImageString(spString[i], targetStyle, null, targetStyle.___baseUrl);
                                    __multiData.ImageType = CSSMultipleImageDataType.Image;
                                }
                                else if (commonHTML.isStringCSSGradient(__multiData.liststyle_image_origin) == true)
                                {
                                    __multiData.Gradation = commonHTML.CreateGradationData(__multiData.liststyle_image_origin, (double)targetStyle.___styleSizeMode);
                                    __multiData.ImageType = CSSMultipleImageDataType.Gradation;
                                }
                            }
                        }
                    }
                }
            }

            return;
        }
        public static bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;
        internal static bool isRegisterCodePagesEncodingProviderCalled = commonHTML.registerCodePagesEncodingProvider();
        /// <summary>
        /// Dotnet Core needs to install a language provider which is not default language provider in order to decode bytes. This method is called automatically at startup.
        /// </summary>
        /// <returns></returns>
        internal static bool registerCodePagesEncodingProvider()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            return true;
        }
        public static string convertKeyCodeIntToHtml5CodeString(int keyCode)
        {
            // A-Z -> KeyA .. KeyZ (65-90)
            if (keyCode >= 65 && keyCode <= 90)
            {
                return "Key" + (char)keyCode;
            }

            // Digits top row 0-9 -> Digit0 .. Digit9 (48-57)
            if (keyCode >= 48 && keyCode <= 57)
            {
                return "Digit" + (char)keyCode;
            }

            // Numpad 0-9 -> Numpad0 .. Numpad9 (96-105)
            if (keyCode >= 96 && keyCode <= 105)
            {
                return "Numpad" + (keyCode - 96).ToString();
            }

            // Function keys F1..F12 (112-123)
            if (keyCode >= 112 && keyCode <= 123)
            {
                return "F" + (keyCode - 111).ToString(); // 112 -> F1
            }

            switch (keyCode)
            {
                // Whitespace / control
                case 8: return "Backspace";
                case 9: return "Tab";
                case 13: return "Enter";
                case 16: return "Shift";      // 左右区別不可（keyCode では区別できない）
                case 17: return "Control";
                case 18: return "Alt";
                case 20: return "CapsLock";
                case 27: return "Escape";
                case 32: return "Space";
                case 33: return "PageUp";
                case 34: return "PageDown";
                case 35: return "End";
                case 36: return "Home";
                case 37: return "ArrowLeft";
                case 38: return "ArrowUp";
                case 39: return "ArrowRight";
                case 40: return "ArrowDown";
                case 45: return "Insert";
                case 46: return "Delete";

                // Meta / Windows / Command keys
                case 91: return "MetaLeft";
                case 92: return "MetaRight";
                case 93: return "ContextMenu";

                // Print/Scroll/Pause
                case 44: return "PrintScreen";
                case 19: return "Pause";
                case 144: return "NumLock";
                case 145: return "ScrollLock";

                // Numpad operators
                case 106: return "NumpadMultiply";
                case 107: return "NumpadAdd";
                case 109: return "NumpadSubtract";
                case 110: return "NumpadDecimal";
                case 111: return "NumpadDivide";

                // Punctuation / OEM keys (一般的なブラウザの code 名に対応)
                case 186: return "Semicolon";      // ; :
                case 187: return "Equal";          // = +
                case 188: return "Comma";          // , <
                case 189: return "Minus";          // - _
                case 190: return "Period";         // . >
                case 191: return "Slash";          // / ?
                case 192: return "Backquote";      // ` ~
                case 219: return "BracketLeft";    // [ {
                case 220: return "Backslash";      // \ |
                case 221: return "BracketRight";   // ] }
                case 222: return "Quote";          // ' "


            }

            return string.Empty;
        }
        public static GraphicAPIType GetySystemGUType()
        {
            // WinformsGDI
            if (Type.GetType("System.Windows.Forms.Form, System.Windows.Forms") != null)
                return GraphicAPIType.WinformsGDI;

            // WPF
            if (Type.GetType("System.Windows.Application, PresentationFramework") != null)
                return GraphicAPIType.WPF;

            // Avalonia
            if (Type.GetType("Avalonia.Application, Avalonia") != null)
                return GraphicAPIType.Avalonia;

            // Uno Platform
            if (Type.GetType("Windows.UI.Xaml.Application, Uno.UI") != null)
                return GraphicAPIType.UnoPlatform;

            // MAUI
            if (Type.GetType("Microsoft.Maui.Controls.Application, Microsoft.Maui.Controls") != null)
                return GraphicAPIType.Maui;

            // SkiaSharp（SkiaSharp自体はGUIではないが、SkiaSharp.Viewsなどで判別可）
            if (Type.GetType("SkiaSharp.Views.Desktop.SKGLControl, SkiaSharp.Views.Desktop") != null)
                return GraphicAPIType.SkiaSharp;

            // ETO.Forms
            if (Type.GetType("Eto.Forms.Application, Eto") != null)
                return GraphicAPIType.ETO;

            return GraphicAPIType.Unknown;
        }
        public static bool IsContentTypeValidWinFormsImage(string _contentType)
        {
            switch (_contentType)
            {
                case "image/png":
                case "image/jpeg":
                case "image/jpg":
                case "image/bmp":
                case "image/gif":
                    return true;

            }
            return false;
        }
        public static bool IsContentTypeSVG(string _contentType)
        {
            switch (_contentType)
            {
                case "image/svg+xml":
                    return true;
            }
            return false;
        }
        public static void createFormPostData(CHtmlElement _currentIFormElement, ref StringBuilder _inputDataBuilder)
        {

            if (_currentIFormElement == null)
                return;
            if (_currentIFormElement.___elementTagType == CHtmlElementType.INPUT || _currentIFormElement.___elementTagType == CHtmlElementType.TEXTAREA || _currentIFormElement.___elementTagType == CHtmlElementType.SELECT)
            {

                _inputDataBuilder.Append(_currentIFormElement.id);
                _inputDataBuilder.Append("=");
                _inputDataBuilder.Append(_currentIFormElement.value);
                _inputDataBuilder.Append("&");
                return;
            }

            if (_currentIFormElement.___childNodes != null && _currentIFormElement.___childNodes.Count > 0)
            {
                int _childLength = _currentIFormElement.___childNodes.Count;
                for (int i = 0; i < _childLength; i++)
                {
                    CHtmlElement childInput = _currentIFormElement.___childNodes[i] as CHtmlElement;
                    if (childInput.___elementTagType == CHtmlElementType.INPUT || childInput.___elementTagType == CHtmlElementType.TEXTAREA || childInput.___elementTagType == CHtmlElementType.SELECT)
                    {
                        if (!string.IsNullOrEmpty(childInput.name) && childInput.type != "submit")
                        {
                            _inputDataBuilder.Append(childInput.name);
                            _inputDataBuilder.Append("=");
                            _inputDataBuilder.Append(childInput.value);
                            _inputDataBuilder.Append("&");
                        }
                    }
                    else
                    {
                        if (childInput.___childNodes.Count > 0)
                        {
                            int _subChildLength = childInput.___childNodes.Count;
                            for (int x = 0; x < _subChildLength; x++)
                            {
                                CHtmlElement subchildInput = childInput.___childNodes[x] as CHtmlElement;
                                if (subchildInput != null)
                                {
                                    createFormPostData(subchildInput, ref _inputDataBuilder);
                                }
                            }

                        }
                    }
                }
            }


            return;
        }
        public static void setHttpClientDefalutRequestHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8");
            client.DefaultRequestHeaders.AcceptLanguage.ParseAdd("ja,en-US;q=0.9,en;q=0.8");
            client.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate, br");
            client.DefaultRequestHeaders.Connection.ParseAdd("keep-alive");
            client.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue() { MaxAge = TimeSpan.Zero };
            /*
            client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"124\", \"Google Chrome\";v=\"124\", \"Not:A-Brand\";v=\"99\"");
            client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0"); 
            client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "Windows");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
            client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
            */
        }
        #region NTextLang
        public static string getNTextDetectLanguageFromText(string text)
        {
            if (_NTextCat_RankedLanguageIdentitifer == null) return "unknown";
            var languages = _NTextCat_RankedLanguageIdentitifer.Identify(text);
            var mostCertainLanguage = languages.FirstOrDefault();
            if (mostCertainLanguage != null)
            {
                return mostCertainLanguage.Item1.Iso639_3;
            }
            return "unknown";
        }

        internal static Dictionary<string, string[]> ___preferLanguangeFont = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
    {
        {"jpn", new[] {"Noto Sans JP","Noto Serif JP","Zen Kaku Gothic New"}},
        { "kor", new[] { "Noto Sans KR" }},
        { "zho", new[] { "Noto Sans TC", "Noto Sans" }},
        { "eng", new[] { "Noto Sans", "Open Sans", "Google Sans Code" }},
        { "fra", new[] { "Noto Sans", "Open Sans" }},
        { "deu", new[] { "Noto Sans", "Open Sans" }},
        { "ita", new[] { "Noto Sans", "Open Sans" }},
        { "spa", new[] { "Noto Sans", "Open Sans" }},
        { "por", new[] { "Noto Sans", "Open Sans" }},
        { "nld", new[] { "Noto Sans", "Open Sans" }},
        { "nor", new[] { "Noto Sans", "Open Sans" }},
        { "dan", new[] { "Noto Sans", "Open Sans" }},
        { "swe", new[] { "Noto Sans", "Open Sans" }},
        { "rus", new[] { "Noto Sans", "Open Sans" }}
    };
        internal static Dictionary<string, string> ___iso2toISO6939_3 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        {"ja","jpn"},{"ko","kor"},{"zh","zho"},{"en","eng"},
        {"de","deu"},{"fr","fra"},{"it","ita"},{"es","spa"},{"pt","por"},{"ru","rus"}
    };
        public static object getProperFontFromStringLangage(string lang)
        {
            var families = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            string defaultFamily = null;
            try
            {
                var searchPaths = new[]
                {
            Path.Combine(AppContext.BaseDirectory, "fonts.json"),
            Path.Combine(AppContext.BaseDirectory, "MultiHtmlCraft.Core", "fonts.json"),
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", "fonts.json")
        };
                foreach (var p in searchPaths)
                {
                    if (!File.Exists(p)) continue;
                    using var fs = File.OpenRead(p);
                    using var doc = System.Text.Json.JsonDocument.Parse(fs);
                    if (doc.RootElement.TryGetProperty("default", out var def)) defaultFamily = def.GetString();
                    if (doc.RootElement.TryGetProperty("fonts", out var fonts))
                    {
                        foreach (var fe in fonts.EnumerateArray())
                        {
                            if (fe.TryGetProperty("family", out var fam) && !string.IsNullOrEmpty(fam.GetString()))
                                families.Add(fam.GetString());
                        }
                    }
                    break;
                }
            }
            catch
            {
                // 読み込み失敗は無視してフォールバックへ
            }

            if (___preferLanguangeFont.TryGetValue(lang, out var cands))
            {
                foreach (var f in cands)
                    if (families.Contains(f)) return f;
            }
            foreach (var f in families)
            {
                if (f.IndexOf(lang, StringComparison.OrdinalIgnoreCase) >= 0) return f;
            }

            return null;
        }
        public static string getProperFontFamilyFromLanguage(string lang)
        {
            var font = getProperFontFromStringLangage(lang);
            if (font != null) return font.ToString();
            return "Noto Sans";
        }
        
        public static SkiaSharp.SKTypeface getProperSkiaFontFromLanguage(string lang)
        {
            var font = getProperFontFromStringLangage(lang);
            if (font != null)
            {
                return SkiaSharp.SKTypeface.FromFamilyName(font.ToString());
            }
            return SkiaSharp.SKTypeface.FromFamilyName("Noto Sans");
        }
        public static bool IsContentTypeValidSkiaBitmap(string _contentType) {
            {
                switch (_contentType)
                {
                    case "image/png":
                    case "image/jpeg":
                    case "image/jpg":
                    case "image/bmp":
                    case "image/gif":
                    case "image/webp":
                        return true;
                }
                return false;
            }
        }
        

        /// <summary>
        /// Converts CSS color string to ColorSpec
        /// </summary>
        /// <param name="colorString">CSS color string (e.g., "black", "#000000", "rgb(0,0,0)")</param>
        /// <returns>ColorSpec representing the color</returns>
        public static ColorSpec GetColorSpecFromString(string colorString)
        {
            if (string.IsNullOrWhiteSpace(colorString))
                return new ColorSpec(0, 0, 0, 0);

            colorString = colorString.Trim().ToLowerInvariant();

            // Handle named colors
            switch (colorString)
            {
                case "black": return new ColorSpec(0, 0, 0, 255);
                case "white": return new ColorSpec(255, 255, 255, 255);
                case "red": return new ColorSpec(255, 0, 0, 255);
                case "green": return new ColorSpec(0, 128, 0, 255);
                case "blue": return new ColorSpec(0, 0, 255, 255);
                case "yellow": return new ColorSpec(255, 255, 0, 255);
                case "cyan": return new ColorSpec(0, 255, 255, 255);
                case "magenta": return new ColorSpec(255, 0, 255, 255);
                case "gray": 
                case "grey": return new ColorSpec(128, 128, 128, 255);
                case "darkgray": 
                case "darkgrey": return new ColorSpec(169, 169, 169, 255);
                case "lightgray": 
                case "lightgrey": return new ColorSpec(211, 211, 211, 255);
                case "transparent": return new ColorSpec(0, 0, 0, 0);
            }

            // Handle hex colors
            if (colorString.StartsWith("#"))
            {
                return ParseHexColor(colorString);
            }

            // Handle rgb() and rgba() colors
            if (colorString.StartsWith("rgba"))
            {
                return ParseRgbColor(colorString);
            }
            else if (colorString.StartsWith("rgb"))
            {
                return ParseRgbColor(colorString);
            }
            else if (colorString.StartsWith("hsla"))
            {
                var (r, g, b, a) = ParseHsl(colorString);
                return new ColorSpec(r, g, b, a);
            }
            else if (colorString.StartsWith("hsl"))
            {
                var (r, g, b, a) = ParseHsl(colorString);
                return new ColorSpec(r, g, b, a);

            }

            // If not recognized, return black
            return new ColorSpec(0, 0, 0, 255);
        }
        public static (byte R, byte G, byte B, byte A) ParseHsl(string hslString)
        {
            if (string.IsNullOrWhiteSpace(hslString))
                throw new ArgumentException("色文字列が空です");

            // 正規表現で hsl / hsla を抽出
            var match = Regex.Match(
                hslString.Trim(),
                @"^hsla?\(\s*([+-]?\d*\.?\d+)\s*,\s*([+-]?\d*\.?\d+)%\s*,\s*([+-]?\d*\.?\d+)%(?:\s*,\s*([+-]?\d*\.?\d+%?))?\s*\)$",
                RegexOptions.IgnoreCase);

            if (!match.Success)
                throw new FormatException($"不正な HSL/HSLA 文字列です: {hslString}");

            // 値の取得
            double h = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
            double s = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture) / 100.0;
            double l = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture) / 100.0;

            // アルファ（指定がなければ 1.0）
            double a = 1.0;
            if (match.Groups[4].Success)
            {
                string alphaStr = match.Groups[4].Value;
                if (alphaStr.EndsWith("%"))
                    a = double.Parse(alphaStr.TrimEnd('%'), CultureInfo.InvariantCulture) / 100.0;
                else
                    a = double.Parse(alphaStr, CultureInfo.InvariantCulture);
            }

            // 範囲を正規化
            h = ((h % 360) + 360) % 360;          // 0〜360
            s = Math.Clamp(s, 0.0, 1.0);
            l = Math.Clamp(l, 0.0, 1.0);
            a = Math.Clamp(a, 0.0, 1.0);

            // HSL → RGB 変換
            var (r, g, b) = HslToRgb(h, s, l);

            return (
                (byte)Math.Round(r * 255),
                (byte)Math.Round(g * 255),
                (byte)Math.Round(b * 255),
                (byte)Math.Round(a * 255)
            );
        }

        private static (double R, double G, double B) HslToRgb(double h, double s, double l)
        {
            if (s == 0.0)
                return (l, l, l);   // グレースケール

            double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
            double p = 2 * l - q;

            double hk = h / 360.0;

            double r = HueToRgb(p, q, hk + 1.0 / 3.0);
            double g = HueToRgb(p, q, hk);
            double b = HueToRgb(p, q, hk - 1.0 / 3.0);

            return (r, g, b);
        }

        private static double HueToRgb(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;

            if (t < 1.0 / 6.0) return p + (q - p) * 6 * t;
            if (t < 1.0 / 2.0) return q;
            if (t < 2.0 / 3.0) return p + (q - p) * (2.0 / 3.0 - t) * 6;
            return p;
        }
        public static string? getExceptionAsString(Exception ex)
        {
    
            StringBuilder sbException = new StringBuilder();

            try
            {
                sbException.AppendLine(ex.Message);
                sbException.AppendLine(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    sbException.AppendLine("Inner Exception:");
                    sbException.AppendLine(ex.InnerException.Message);
                    sbException.AppendLine(ex.InnerException.StackTrace);
                }

            }
            catch
            {
               sbException.Append("Exception ToString() failed");
            }
            return sbException.ToString();
        }

        private static ColorSpec ParseHexColor(string hex)
        {
            hex = hex.Substring(1); // Remove #

            if (hex.Length == 3)
            {
                // Convert #RGB to #RRGGBB
                hex = $"{hex[0]}{hex[0]}{hex[1]}{hex[1]}{hex[2]}{hex[2]}";
            }

            if (hex.Length == 6)
            {
                if (int.TryParse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber, null, out int r) &&
                    int.TryParse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, null, out int g) &&
                    int.TryParse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber, null, out int b))
                {
                    return new ColorSpec((byte)r, (byte)g, (byte)b, 255);
                }
            }

            return new ColorSpec(0, 0, 0, 255); // Default to black
        }

        private static ColorSpec ParseRgbColor(string rgb)
        {
            try
            {
                int startIndex = rgb.IndexOf('(');
                int endIndex = rgb.LastIndexOf(')');
                
                if (startIndex == -1 || endIndex == -1)
                    return new ColorSpec(0, 0, 0, 255);

                string values = rgb.Substring(startIndex + 1, endIndex - startIndex - 1);
                string[] parts = values.Split(',');

                if (parts.Length >= 3)
                {
                    if (int.TryParse(parts[0].Trim(), out int r) &&
                        int.TryParse(parts[1].Trim(), out int g) &&
                        int.TryParse(parts[2].Trim(), out int b))
                    {
                        int a = 255;
                        if (parts.Length >= 4 && double.TryParse(parts[3].Trim(), out double alpha))
                        {
                            a = (int)(alpha * 255);
                        }

                        return new ColorSpec((byte)Math.Max(0, Math.Min(255, r)),
                                           (byte)Math.Max(0, Math.Min(255, g)),
                                           (byte)Math.Max(0, Math.Min(255, b)),
                                           (byte)Math.Max(0, Math.Min(255, a)));
                    }
                }
            }
            catch
            {
                // Parse failed, return black
            }

            return new ColorSpec(0, 0, 0, 255);
        }

        #endregion 
    }
}
