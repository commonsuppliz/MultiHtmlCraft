using System;

namespace MultiHtmlCraft.Core
{
    
    public enum CSSAttributeType : ushort
    {
        undefined,
        @float,
        align,
        aligncontent,
        alignitems,
        alignself,
        alignmentadjust,
        alignmentbaseline,
        all,
        anchorpoint,
        animation,
        animationdelay,
        animationdirection,
        animationduration,
        animationfillmode,
        animationiterationcount,
        animationname,
        animationplaystate,
        animationtimingfunction,
        appearance,
        azimuth,
        backfacevisibility,
        background,
        backgroundattachment,
        backgroundclip,
        backgroundcolor,
        backgroundimage,
        backgroundinlinepolicy,
        backgroundorigin,
        backgroundopacity,
        backgroundposition,
        backgroundpositionx,
        backgroundpositiony,
        backgroundrepeat,
        backgroundsize,
        baselineshift,
        behavior,
        binding,
        bleed,
        bookmarklabel,
        bookmarklevel,
        bookmarkstate,
        border,
        borderbottom,
        borderbottomcolor,
        borderbottomleftradius,
        borderbottomrightradius,
        borderbottomstyle,
        borderbottomwidth,
        bordercollapse,
        bordercolor,
        borderimage,
        borderimageoutset,
        borderimagerepeat,
        borderimageslice,
        borderimagesource,
        borderimagewidth,
        borderleft,
        borderleftcolor,
        borderleftcolors,
        bordertopcolors,
        borderbottomcolors,
        borderrightcolors,
        borderleftstyle,
        borderleftwidth,
        borderradius,
        borderradiusleft,
        borderradiusright,
        borderradiustop,
        borderradiusbottom,
        bordertoprightradius,
        bordertoplefttradius,
        bordertopbottomradius,
        borderright,
        borderrightcolor,
        borderrightstyle,
        borderrightwidth,
        borderspacing,
        borderstyle,
        bordertop,
        borderlightcolor,
        borderdarkcolor,
        bordertopright,
        bordertopleft,
        bordertopbottom,
        bordertopcolor,
        bordertopleftradius,

        bordertopstyle,
        bordertopwidth,
        borderwidth,
        bottom,
                boxalign,
        boxdirection,
        boxdecorationbreak,
        boxshadow,
        boxmodel,
        boxshadowboxshadow,
        boxsizing,
        boxreflect,
        boxorient,
        boxsnap,
        boxpack,
        boxflex,
        boxoriginalgroup,
        boxsuppress,
        breakafter,
        breakbefore,
        breakinside,
        captionside,
        chains,
        cellpadding,
        cellspacing,
        clear,
        clip,
        clippath,
        cliprule,
        color,
        colorinterpolationfilters,
        columncount,
        columnfill,
        columngap,
        columnrule,
        columnrulecolor,
        columnrulestyle,
        columnrulewidth,
        columnspan,
        columnwidth,
        columns,
        contain,
        content,
        counterincrement,
        counterreset,
        counterset,
        crop,
        cue,
        cueafter,
        cuebefore,
        cursor,
        direction,
        display,
        displayinside,
        displaylist,
        displayoutside,
        dominantbaseline,
        elevation,
        emptycells,
        filter,
        flex,
        flexbasis,
        flexdirection,
        flexflow,
        flexgrow,
        flexshrink,
        flexwrap,
        flexlinepack,
        flexorder,
        fullscreen,
       
        floatoffset,
        floodcolor,
        floodopacity,
        flowfrom,
        flowinto,
        font,
        fontfamily,
        fontkerning,
        fontfeaturesettings,
        fontlanguageoverride,
        fontsize,
        fontsizeadjust,
        fontstretch,
        fontstyle,
        fontsynthesis,
        fontsmoothing,
        fontvariant,
        fontvariantalternates,
        fontvariantcaps,
        fontvarianteastasian,
        fontvariantligatures,
        fontvariantnumeric,
        fontvariantposition,
        fontweight,
        frameborder,
        grid,
        gridarea,
        gridautocolumns,
        gridautoflow,
        gridautorows,
        gridcolumn,
        gridcolumns,
        gridcolumnend,
        gridcolumnstart,
        gridrow,
        gridrows,
        gridrowend,
        gridrowspan,
        gridrowalign,
        gridrowstart,
        gridcolumnalign,
        gridcolumnspan,
        gridtemplate,
        gridtemplateareas,
        gridtemplatecolumns,
        gridtemplaterows,
        hangingpunctuation,
        height,
        hyphens,
        hyphenatelines,
        hyphenatelimitlines,
        hyphenatelimitzone,
        highcontrastadjust,
        icon,
        ieonlyrendering,
        imagerendering,
        imageorientation,
        imageresolution,
        imemode,
        initialletters,
        inlineboxalign,
        interpolationmode,
        justifycontent,
        justifyitems,
        justifyself,
        layoutgridline,
        left,
        letterspacing,
        lightingcolor,
        lineboxcontain,
        linebreak,
        linegrid,
        lineheight,
        linesnap, 
        lineclamp,
        linestacking,
        linestackingruby,
        linestackingshift,
        linestackingstrategy,
        liststyle,
        liststyleimage,
        liststyleposition,
        liststyletype,
        margin,
        marginbottom,
        marginleft,
        marginright,
        margintop,
        marginstart,
        marginend,
        marginbefore,
        marginafter,
        marginwidth,
        marginheight,
        markeroffset,
        markerside,
        marks,
        mask,
        maskbox,
        maskboxoutset,
        maskboxrepeat,
        maskboxslice,
        maskboxsource,
        maskboxwidth,
        maskclip,
        maskimage,
        maskboximage,
        maskorigin,
        maskposition,
        maskrepeat,
        masksize,
        masksourcetype,
        masktype,
        maxheight,
        maxlines,
        maxwidth,
        minheight,
        minwidth,
        moveto,
        msolist,
        navdown,
        navindex,
        navleft,
        navright,
        navup,
        objectfit,
        objectposition,
        opacity,
        order,
        orphans,
        outline,
        outlinecolor,
        outlineoffset,
        outlinestyle,
        outlinewidth,
        outlineheight,
        overflow,
        overflowstyle,
        overflowscrolling,
        overflowwrap,
        overflowx,
        overflowy,
        padding,
        paddingbottom,
        paddingleft,
        paddingright,
        paddingtop,
        paddingstart,
        paddingend,
        page,
        pagebreakafter,
        pagebreakbefore,
        pagebreakinside,
        pagepolicy,
        pause,
        pauseafter,
        pausebefore,
        perspective,
        perspectiveorigin,
        pitch,
        pitchrange,
        playduring,
        printcoloradjust,
        position,
        pointerevents,
        presentationlevel,
        quotes,
        regionfragment,
        resize,
        relative,
        rest,
        restafter,
        restbefore,
        richness,
        right,
        rotation,
        rotationpoint,
        rubyalign,
        rubymerge,
        rubyposition,
                scrolling,
        scrollbarbasecolor,
        scrollbarhighlightcolor,
        scrollbardarkshadowcolor,
        scrollbartrackcolor,
        scrollbarfacecolor,
        scrollbararrowcolor,
        scrollbar3dlightcolor,
        scrollbarshadowcolor,
        shapeimagethreshold,
        shapeoutside,
        shapemargin,
        size,
        speak,
        speakas,
        speakheader,
        speaknumeral,
        speakpunctuation,
        speechrate,
        stress,
        stroke,
        stopcolor,
        stopopacity,
        strokewidth,
        fill,
        systemfont,
        stringset,
        tabsize,
        tabstops,
        touchaction,
        touchcallout,
        taphighlightcolor,
        tablelayout,
        textalign,
        textalignlast,
        textrendering,
        textcombineupright,
        textdecoration,
        textdecorationcolor,
        textdecorationline,
        textdecorationskip,
        textdecorationstyle,
        textemphasis,
        textemphasiscolor,
        textemphasisposition,
        textemphasisstyle,
        textheight,
        textindent,
        textstoke,
        textindex,
        textjustify,
        textjustification,
        textlinethrough,
        textorientation,
        textoverflow,
        textshadow,
        textspacecollapse,
        textsizeadjust,
        texttransform,
        textunderline,
        textunderlineposition,
        textwrap,
        top,
        transform,
        transformorigin,
        transformduration,
        transformstyle,
        transition,
        transitiondelay,
        transitionduration,
        transitionproperty,
        transitiontimingfunction,
        unicodebidi,
        userselect,
        verticalalign,
        visibility,
        voicebalance,
        voiceduration,
        voicefamily,
        voicepitch,
        voicerange,
        voicerate,
        voicestress,
        voicevolume,
        volume,
        whitespacing,
        whitespace,
        widows,
        width,
        willchange,
        wordbreak,
        wordspacing,
        wordwrap,
        wrapflow,
        wrapthrough,
        writingmode,
        zoom,
        zindex
    }
	/// <summary>
	/// StyleAttributeClass represends name and value for style properties
	/// </summary>
	
	public struct CHtmlStyleAttribute
	{
		
		public string Name;
        public CSSAttributeType attributeType;
		
		public string @value;
		
		public bool IsImportant;
		
		public bool IsValid;
   
        public bool IsNumber;
   
        public CSSHackType HackType;
        public static CSSAttributeType GetStyleAttributeType(string rName)
        {
            switch (rName)// Name is always lower
            {
                case null:
                case "":
                    return CSSAttributeType.undefined;
                case "align":
                    return CSSAttributeType.alignself;
                case "*zoom":
                case "zoom":
                    return CSSAttributeType.zoom;
                case "appearance":
                case "-appearance":
                case "mozappearance":
                case "webkitappearance":
                    return CSSAttributeType.appearance;
                case "vertical-align":
                case "verticalalign":
                case "verticla-align":
                case "*vertical-align":
                case "valign":
                case "v-align":
                case "vertical-alignment":
                    return CSSAttributeType.verticalalign;
                case "font-color":
                case "fontcolor":
                case "text-fill-color":
                    return CSSAttributeType.color;
                case "background-color":
                case "backgroud-color":
                case "backgroundcolor":
                

                   return CSSAttributeType.backgroundcolor;
                    
                case "font-size":
                case "xfont-size":
                case "ifont-size":
                case "fontsize":
                case "font_size":
                   return CSSAttributeType.fontsize;
                case "font-variant":
                case "fontvariant":
                   return CSSAttributeType.fontvariant;
                case "text-shadow":
                case "textshadow":
                   return CSSAttributeType.textshadow;
                case "outline-color":
                   return CSSAttributeType.outlinecolor;
                case "color":
                   return CSSAttributeType.color;
                case "width":
                case "*width":
                   return CSSAttributeType.width;
                case "height":
                case "*height":
                   return CSSAttributeType.height;
                case "margin":
                case "*margin":
                case "xmargin":
                case "margins":
                   return CSSAttributeType.margin;
                case "animation":
                   return CSSAttributeType.animation;
                case "pading":
                case "padding":
                case "padidng":
                case "xpadding":
                   return CSSAttributeType.padding;
                case "padding-start":
                case "paddingstart":
                case "pading-start":
                   return CSSAttributeType.paddingstart;
                case "padding-end":
                case "paddingend":
                case "pading-end":
                   return CSSAttributeType.paddingend;
                case "border":
                   return CSSAttributeType.border;
                case "display":
                case "*display":
                   return CSSAttributeType.display;
                case "font-weight":
                case "fontweight":
                   return CSSAttributeType.fontweight;
                case "word-break":
                case "wordbreak":
                   return CSSAttributeType.wordbreak;
                case "line-height":
                case "lineheight":
                   return CSSAttributeType.lineheight;
                case "clip":
                   return CSSAttributeType.clip;
                case "marker-offset":
                case "markeroffset":
                   return CSSAttributeType.markeroffset;
                case "pointer-events":
                   return CSSAttributeType.pointerevents;

                case "float":
                case "cssfloat":
                case "*cssfloat":
                case "stylefloat":
                case "*float":
                   return CSSAttributeType.@float;
                case "list-style-type":
                case "liststyletype":
                   return CSSAttributeType.liststyletype;
                case "font":
                   return CSSAttributeType.font;
                case "clear":
                   return CSSAttributeType.clear;
                case "margin-left":
                case "marginleft":
                   return CSSAttributeType.marginleft;
                case "margin-top":
                //case "margin-top":
                case "xmargin-top":
                case "margintop":
                   return CSSAttributeType.margintop;
                case "margin-right":
                case "marginright":
                   return CSSAttributeType.marginright;
                case "margin-bottom":
                //case "margin-bottom":
                case "marginbottom":
                   return CSSAttributeType.marginbottom;
                case "list-style":
                case "liststyle":
                   return CSSAttributeType.liststyle;
                case "text-size-adjust":
                case "textsizeadjust":
                case "ms-text-size-adjust":
                case "moz-text-size-adjust":
                case "webkit-text-size-adjust":
                case "-text-size-adjust":
                   return CSSAttributeType.textsizeadjust;
                case "text-decoration":
                case "textdecoration":
                case "text-decoartion":
                case "font-decoration":
                   return CSSAttributeType.textdecoration;
                case "font-style":
                case "fontstyle":
                   return CSSAttributeType.fontstyle;
                case "left":
                   return CSSAttributeType.left;
                case "top":
                   return CSSAttributeType.top;
                case "bottom":
                   return CSSAttributeType.bottom;
                case "right":
                   return CSSAttributeType.right;
                case "positon":
                case "position":
                case "xposition":
                   return CSSAttributeType.position;
                case "content":
                   return CSSAttributeType.content;
                case "visibility":
                case "visiblity":
                   return CSSAttributeType.visibility;
                case "paddingtop":
                case "padding-top":
                case "paddiing-top":
                case "padiing-top":
                case "pading-top":
                   return CSSAttributeType.paddingtop;
                   
                case "paddingright":
                case "padding-right":
                case "pading-right":
                   return CSSAttributeType.paddingright;
                case "paddingbottom":
                case "padding-bottom":
                case "paddiing-bottom":
                case "pading-bottom":
                   return CSSAttributeType.paddingbottom;
                case "paddingleft":
                case "padding-left":
                case "pading-left":
                case "padding-left-value":
                   return CSSAttributeType.paddingleft;
                case "background-image":
                case "background-mage":
                case "backgroundimage":
                case "backgrond-image": // google typo
                   return CSSAttributeType.backgroundimage;
                case "white-spacing":
                case "whitespacing":
                   return CSSAttributeType.whitespacing;
                case "text-align":
                case "textalign":
                   return CSSAttributeType.textalign;
                case "text-justification":
                case "textjustification":
                   return CSSAttributeType.textjustification;
                case "text-justify":
                case "textjustify":
                   return CSSAttributeType.textjustify;
                case "text-line-through":
                   return CSSAttributeType.textlinethrough;
                case "white-space":
                case "whitespace":
                   return CSSAttributeType.whitespace;
                case "background":
                case "xbackground":

                   return CSSAttributeType.background;
                case "-ms-zoom":
                case "-moz-zoom":
                   return CSSAttributeType.zoom;
                case "min-height":
                case "minheight":
                   return CSSAttributeType.minheight;
                case "min-width":
                case "minwidth":
                   return CSSAttributeType.minwidth;
                case "max-height":
                case "maxheight":
                case "xmax-height":
                   return CSSAttributeType.maxheight;
                case "max-width":
                case "maxwidth":
                case "xmax-width":
                   return CSSAttributeType.maxwidth;
                case "border-color":
                case "bordercolor":
                   return CSSAttributeType.bordercolor;
                case "border-top":
                case "bordertop":
                case "-border-top":
                case "backgroundtop":
                   return CSSAttributeType.bordertop;
                case "border-bottom":
                case "borderbottom":
                case "-borderbottom":
                case "backgroundbottom":
                   return CSSAttributeType.borderbottom;
                case "border-left":
                case "borderleft":
                case "-border-left":
                case "background-left":
                   return CSSAttributeType.borderleft;
                case "border-right":
                case "borderright":
                case "background-right":
                   return CSSAttributeType.borderright;
                case "border-top-right":
                case "bordertopright":
                   return CSSAttributeType.bordertopright;
                case "border-top-left":
                case "bordertopleft":
                   return CSSAttributeType.bordertopleft;
                case "background-position":
                case "backgroundposition":
                   return CSSAttributeType.backgroundposition;
                case "background-repeat":
                case "backgroundrepeat":
                   return CSSAttributeType.backgroundrepeat;
                case "overflow":
                case "*overflow":
                   return CSSAttributeType.overflow;
                case "overflowscrolling":
                case "overflow-scrolling":
                   return CSSAttributeType.overflowscrolling;
                case "z-index":
                case "zindex":
                   return CSSAttributeType.zindex;
                case "word-wrap":
                case "wordwrap":
                   return CSSAttributeType.wordwrap;
                case "text-indent":
                case "textindent":
                   return CSSAttributeType.textindent;
                case "text-index":
                case "textindex":
                   return CSSAttributeType.textindex;
                case "letter-spacing":
                case "letterspacing":
                   return CSSAttributeType.letterspacing;
                case "list-style-image":
                case "liststyleimage":
                   return CSSAttributeType.liststyleimage;
                case "list-style-position":
                case "liststyleposition":
                   return CSSAttributeType.liststyleposition;
                case "font-family":
                case "fontfamily":
                  return CSSAttributeType.fontfamily;
                case "font-kerning":
                case "fontkerning":
                  return CSSAttributeType.fontkerning;
                case "outline":
                  return CSSAttributeType.outline;
                case "overflow-y":
                case "overflowy":
                  return CSSAttributeType.overflowy;
                case "overflow-x":
                case "overflowx":
                  return CSSAttributeType.overflowx;
                case "behavior":
                  return CSSAttributeType.behavior;
                case "filter":
                case "-ms-filter":
                case "-o-filter":
                  return CSSAttributeType.filter;
                case "font-smoothing":
                case "fontsmoothing":
                case "osx-font-smoothing":
                case "osxfontsmoothing":
                  return CSSAttributeType.fontsmoothing;
                case "fill-opacity":
                case "fillopacity":
                case "opacity":
                case "mozopacity":
                case "khtmlopacity":
                  return CSSAttributeType.opacity;
                case "flexFlow":
                case "flexflow":
                case "flex-Flow":
                  return CSSAttributeType.flexflow;
                case "align-content":
                case "aligncontent":
                  return CSSAttributeType.aligncontent;
                case "flexwrap":
                  return CSSAttributeType.flexwrap;
                case "boxreflect":
                  return CSSAttributeType.boxreflect;
                case "columncount":
                  return CSSAttributeType.columncount;
                case "animationdelay":
                case "animation-delay":
                case "mozanimationdelay":
                case "webkitanimationdelay":
                  return CSSAttributeType.animationdelay;
                case "animationname":
                case "animation-name":
                case "mozanimationname":
                case "webkitanimationname":
                  return CSSAttributeType.animationname;
                case "animationplaystate":
                case "msanimationplaystate":
                case "mozanimationplaystate":
                case "oanimationplaystate":
                case "webkitanimationplaystate":
                  return CSSAttributeType.animationplaystate;
                case "rotate":
                case "webkitrotate":
                case "msrotate":
                case "orotate":
                case "mozrotate":
                  return CSSAttributeType.rotation;
                case "fullscreen":
                case "full-screen":
                case "mozfullscreen":
                case "webkitfullscreen":
                case "-webkit-full-screen":
                case "ofullscreen":
                case "msfullscreen":
                  return CSSAttributeType.fullscreen;
                case "margin-start":
                case "marginstart":
                  return CSSAttributeType.marginstart;
                case "margin-end":
                case "marginend":
                  return CSSAttributeType.marginend;
                case "orphans":
                  return CSSAttributeType.orphans;
                case "page-break-inside":
                case "pagebreakinside":
                  return CSSAttributeType.pagebreakinside;
                case "overflowstyle":
                case "overflow-style":
                  return CSSAttributeType.overflowstyle;
                case "outline-offset":
                case "outlineoffset":
                  return CSSAttributeType.outlineoffset;
                case "margin-after":
                case "marginafter":
                  return CSSAttributeType.marginafter;
                case "margin-before":
                case "marginbefore":
                  return CSSAttributeType.marginbefore;
                case "touch-action":
                case "touchaction":
                  return CSSAttributeType.touchaction;
                case "resize":
                  return CSSAttributeType.resize;
                case "border-image":
                case "borderimage":
                  return CSSAttributeType.borderimage;
                case "border-top-color":
                case "border-color-top":
                case "bordercolortop":
                case "border-left-color-value":
                  return CSSAttributeType.bordertopcolor;
                case "border-left-color":
                case "borderleftcolor":
                case "border-color-left":
                  return CSSAttributeType.borderleftcolor;
                // --------------------------------------------------------------
                // Mozilla supports multiple colors for border
                // --------------------------------------------------------------
                case "border-left-colors":
                case "borderleftcolors":
                  return CSSAttributeType.borderleftcolors;
                case "border-right-colors":
                case "borderrightcolors":
                  return CSSAttributeType.borderrightcolors;
                case "border-top-colors":
                case "bordertopcolors":
                  return CSSAttributeType.bordertopcolors;
                case "border-bottom-colors":
                case "borderbottomcolors":
                  return CSSAttributeType.borderbottomcolors;
                // -----------------------------------------------------------
                case "border-bottom-color":
                case "border-color-bottom":
                  return CSSAttributeType.borderbottomcolor;
                case "border-right-color":
                case "borderrightcolor":
                case "border-color-right":
                case "border-right-color-value":
                  return CSSAttributeType.borderrightcolor;
                case "border-light-color":
                case "borderlightcolor":
                  return CSSAttributeType.borderlightcolor;
                case "border-dark-color":
                  return CSSAttributeType.borderdarkcolor;
                case "table-layout":
                case "tablelayout":
                  return CSSAttributeType.tablelayout;
                case "mask-image":
                case "maskimage":
                  return CSSAttributeType.maskimage;
                case "mask-box-image":
                  return CSSAttributeType.maskboximage;
                case "text-stoke":
                case "textstroke":
                  return CSSAttributeType.textstoke;
                case "ime-mode":
                case "imemode":
                  return CSSAttributeType.imemode;
                case "word-spacing":
                case "wordspacing":
                  return CSSAttributeType.wordspacing;
                case "border-collapse":
                case "bordercollapse":
                  return CSSAttributeType.bordercollapse;
                case "voice-family":
                case "voicefamily":
                  return CSSAttributeType.voicefamily;
                case "border-width":
                case "borderwidth":
                  return CSSAttributeType.borderwidth;
                case "border-style":
                case "borderstyle":
                  return CSSAttributeType.borderstyle;
                case "line-break":
                case "linebreak":
                  return CSSAttributeType.linebreak;
                case "line-clamp":
                  return CSSAttributeType.lineclamp;
                case "line-snap":
                case "linesnap":
                  return CSSAttributeType.linesnap;
                case "border-bottom-style":
                case "borderbottomstyle":
                case "border-bottom-style-value":
                  return CSSAttributeType.borderbottomstyle;
                case "border-top-style":
                case "bordertopstyle":
                case "border-top-style-value":
                  return CSSAttributeType.bordertopstyle;
                case "border-left-style":
                case "border-left-style-value":
                  return CSSAttributeType.borderleftstyle;
                case "border-right-style":
                case "border-right-style-value":
                       return CSSAttributeType.borderrightstyle;
                case "outline-style":
                case "outlinestyle":
                       return CSSAttributeType.outlinestyle;

                case "border-spacing":
                       return CSSAttributeType.borderspacing;
                case "border-left-width":
                case "border-left-width-value":
                       return CSSAttributeType.borderleftwidth;
                case "border-right-width":
                case "border-right-width-value":
                       return CSSAttributeType.borderrightwidth;
                case "border-top-width":
                case "bordertopwidth":
                case "border-top-width-value":
                       return CSSAttributeType.bordertopwidth;
                case "border-bottom-width":
                case "border-bottom-width-value":
                       return CSSAttributeType.borderbottomwidth;
                case "background-attachment":
                case "backgroundattachment":
                       return CSSAttributeType.backgroundattachment;
                case "background-clip":
                case "backgroundclip":
                       return CSSAttributeType.backgroundclip;
                case "background-inline-policy":
                       return CSSAttributeType.backgroundinlinepolicy;
                case "background-origin":
                case "backgroundorigin":
                       return CSSAttributeType.backgroundorigin;
                case "empty-cells":
                case "emptycells":
                       return CSSAttributeType.emptycells;
                case "text-transform":
                case "texttransform":
                       return CSSAttributeType.texttransform;
                case "text-rendering":
                case "textrendering":
                       return CSSAttributeType.textrendering;
                case "font-stretch":
                case "fontstretch":
                       return CSSAttributeType.fontstretch;
                case "textoverflow":
                case "text-overflow":
                case "-ms-text-overflow":
                case "-o-text-overflow":
                       return CSSAttributeType.textoverflow;
                case "relative":
                       return CSSAttributeType.relative;
                case "quotes":
                       return CSSAttributeType.quotes;
                case "direction":
                       return CSSAttributeType.direction;
                case "background-position-x":
                       return CSSAttributeType.backgroundpositionx;
                case "background-position-y":
                       return CSSAttributeType.backgroundpositiony;
                case "background-size":
                case "backgroundsize":
                case "-ie-background-size":
                case "-khtml-background-size":
                       return CSSAttributeType.backgroundsize;
                case "scrollbar-highlight-color":
                case "scrollbarhighlightcolor":
                       return CSSAttributeType.scrollbarhighlightcolor;
                case "scrollbarbasecolor":
                case "scroll-bar-base-color":
                case "scrollbar-base-color":
                case "scrollbar-basecolor":
                       return CSSAttributeType.scrollbarbasecolor;
                case "scrollbar-darkshadow-color":
                case "scrollbardarkshadowcolor":
                       return CSSAttributeType.scrollbardarkshadowcolor;
                case "scrollbar-track-color":
                       return CSSAttributeType.scrollbartrackcolor;
                case "scrollbar-3dlight-color":
                       return CSSAttributeType.scrollbar3dlightcolor;
                case "cursor":
                       return CSSAttributeType.cursor;
                case "box-orient":
                       return CSSAttributeType.boxorient;
                case "mozboxshadow":
                case "boxshadow":
                case "box-shadow":
                case "-mbox-box-shadow":
                case "-mox-box-shadow":
                case "-ie-box-shadow":
                case "-ms-box-shadow":
                case "-o-box-shadow":
                case "-vendor-box-shadow":
                       return CSSAttributeType.boxshadow;
                case "boxshadowboxshadow":
                case "mozshadowboxshadow":
                case "webkitshadowboxshadow":
                case "box-shadowbox-shadow":
                       return CSSAttributeType.boxshadowboxshadow;
                case "boxsizing":
                case "box-sizing":
                case "-ms-box-sizing":
                case "-o-box-sizing":
                case "-box-sizing":
                       return CSSAttributeType.boxsizing;
                case "box-model":
                case "boxmodel":
                case "-box-model":
                       return CSSAttributeType.boxmodel;
                case "box-pack":
                       return CSSAttributeType.boxpack;
                case "box-ordinal-group":
                    return CSSAttributeType.boxoriginalgroup;
                case "box-flex":
                     return CSSAttributeType.boxflex;
                case "outline-width":
                case "outlinewidth":
                     return CSSAttributeType.outlinewidth;
                case "outline-height":
                     return CSSAttributeType.outlineheight;
                case "cellpadding":
                     return CSSAttributeType.cellpadding;
                case "cellspacing":
                     return CSSAttributeType.cellspacing;
                case "font-size-adjust":
                     return CSSAttributeType.fontsizeadjust;
                case "text-adjustify":
                case "textadjustify":
                     return CSSAttributeType.textjustify;
                case "text-underline":
                case "textunderline":
                     return CSSAttributeType.textunderline;
                case "page":
                       return CSSAttributeType.page;
                case "page-break-after":
                    return CSSAttributeType.pagebreakafter;
                case "tab-stops":
                case "tabstops":
                    return CSSAttributeType.tabstops;
                case "transform":
                case "-ms-transform":
                case "-o-transform":
                case "transformproperty":
                case "webkittransform":
                case "moztransform":
                case "mstransform":
                case "otransform":
                    return CSSAttributeType.transform;
                case "transform-origin":
                case "-ms-transform-origin":
                case "-o-transform-origin":
                    return CSSAttributeType.transformorigin;
                case "transform-duration":
                case "-ms-transform-duration":
                case "-o-transform-duration":
                    return CSSAttributeType.transformduration;
                case "transition-duration":
                case "-ms-transition-duration":
                case "-o-transition-duration":
                    return CSSAttributeType.transitionduration;
                case "transition-property":
                case "-ms-transition-property":
                case "-o-transition-property":
                    return CSSAttributeType.transitionproperty;
                case "transition-timing-function":
                    return CSSAttributeType.transitiontimingfunction;
                case "transition-delay":
                    return CSSAttributeType.transitiondelay;
                case "stroke":
                    return CSSAttributeType.stroke;
                case "stroke-width":
                case "strokewidth":
                    return CSSAttributeType.strokewidth;
                case "fill":
                    return CSSAttributeType.fill;
                case "borderradius":
                case "border-radius":
                case "-o-border-radius":
                case "mozborderradius":
                case "-moz-border-radius":
                case "-webkit-border-radius":
                case "-html-border-radius":
                case "khtml-border-radius":
                case "-border-radius":
                case "khtml-border-raidus":
                case "moz-border-radius":
                case "-ie-border-radius":
                          return CSSAttributeType.borderradius;
                case "border-top-left-radius":
                case "bordertopleftradius":
                case "top-left-border-radius":
                case "border-radius-topleft":

                          return CSSAttributeType.bordertopleftradius;
                case "border-top-right-radius":
                case "border-radius-topright":
                case "top-right-border-radius":
                       return CSSAttributeType.bordertoprightradius;
                case "border-bottom-left-radius":
                case "bottom-left-radius":
                case "borderbottomleftradius":
                case "border-radius-bottomleft":
                case "borderbottom-left-radius":
                       return CSSAttributeType.borderbottomleftradius;
                case "border-bottom-right-radius":
                case "borderbottomrightradius":
                case "bottom-right-radius":
                case "bottomrightradius":
                case "border-radius-bottomright":
                       return CSSAttributeType.borderbottomrightradius;
                case "transition":
                case "transtion":
                case "-o-transition":
                case "-ms-transition":
                case "ms-transition":
                case "webkit-transition":
                case "otransition":
                case "mstransition":
                    return CSSAttributeType.transition;
                case "-ms-interpolation-mode":
                case "ms-interpolation-mode":
                case "moz-interpolation-mode":
                case "webkit-interpolation-mode":
                case "interpolation-mode":
                case "-o-interpolation-mode":
                case "interpolationmode":
                    return CSSAttributeType.interpolationmode;
                case "widows":
                case "widow":
                    return CSSAttributeType.widows;
                case "background-opacity":
                    return CSSAttributeType.backgroundopacity;
                case "scrollbar-arrow-color":
                    return CSSAttributeType.scrollbararrowcolor;
                case "scrollbar-face-color":
                    return CSSAttributeType.scrollbarfacecolor;
                case "tap-highlight-color":
                case "taphighlightcolor":
                    return CSSAttributeType.taphighlightcolor;
                case "high-contrast-adjust":
                case "highcontrastadjust":
                    return CSSAttributeType.highcontrastadjust;
                case "system-font":
                case "system_font":
                case "systemfont":
                case "-x-system-font":
                    // int value is expected

                      return CSSAttributeType.systemfont;
                case "font-feature-settings":
                           return CSSAttributeType.fontfeaturesettings;
                case "scrollbar-shadow-color":
                return CSSAttributeType.scrollbarshadowcolor;
                case "userselect":
                case "ouserselect":
                case "mozuserselect":
                case "user-select":
                case "-ms-user-select":
                case "-o-user-select":
                    return CSSAttributeType.userselect;
                case "stop-color":
                case "stopcolor":
                    return CSSAttributeType.stopcolor;
                case "speak":
                    return CSSAttributeType.speak;
                case "hyphens":
   return CSSAttributeType.hyphens;
                case "hyphenate-lines":
                case "hyphenatelines":
   return CSSAttributeType.hyphenatelimitlines;
                case "hyphenate-limit-lines":
                case "hyphenatelimitlines":
                    return CSSAttributeType.hyphenatelimitlines;
                case "hyphenate-limit-zone":
                case "hyphenatelimitzone":
                             return CSSAttributeType.hyphenatelimitzone;
                case "msolist":
                case "mso-list":
                  return CSSAttributeType.msolist;
                case "touch-callout":
                case "touchcallout":
                          return CSSAttributeType.touchcallout;
                case "animation-duration":
                case "animationduration":
                   return CSSAttributeType.animationduration;
                case "image-rendering":
                case "imagerendering":
                    return CSSAttributeType.imagerendering;
                case "ieonlywidth":
                   return CSSAttributeType.ieonlyrendering;
                case "richness":
                                return CSSAttributeType.richness;
                case "stress":
                      return CSSAttributeType.stress;
                case "pitch":
           return CSSAttributeType.pitch;
                case "pitch-range":
                case "pitchrange":
                case "-pitch-range":
       return CSSAttributeType.pitchrange;
                case "layout-grid-line":
                case "layoutgridline":
                          return CSSAttributeType.layoutgridline;
                case "frameborder":
                          return CSSAttributeType.frameborder;
                case "scrolling":
                case "-moz-scrolling":
                       return CSSAttributeType.scrolling;
                case "backface-visiblity":
                case "backfacevisiblity":
                case "backface-visibility":
                case "backfacevisibility":
                   return CSSAttributeType.backfacevisibility;
                case "perspective":
                      return CSSAttributeType.perspective;
                case "perspectiveorigin":
                case "perspective-origin":
 return CSSAttributeType.perspectiveorigin;
                case "transform-style":
                case "transformstyle":
 return CSSAttributeType.transformorigin;
                case "column-width":
                case "columnwidth":
   return CSSAttributeType.columnwidth;
                case "column-span":
                case "columnspan":
                   return CSSAttributeType.columnspan;
                case "breakinside":
                case "break-inside":
       return CSSAttributeType.breakinside;
                case "marginwidth":
                case "margin-width":
             return CSSAttributeType.marginwidth;
                case "marginheight":
                case "margin-height":
                      return CSSAttributeType.marginheight;
                case "flex":
                         return CSSAttributeType.flex;
                case "column-gap":
                case "columngap":
                         return CSSAttributeType.columngap;
                case "column-fill":
                case "columnfill":
                         return CSSAttributeType.columnfill;
                case "column-rule":
                case "columnrule":
                         return CSSAttributeType.columnrule;
                case "column-rule-color":
                case "columnrulecolor":
                         return CSSAttributeType.columnrulecolor;
                case "column-rule-style":
                case "columnrulestyle":
                         return CSSAttributeType.columnrulestyle;
                case "flex-direction":
                case "flexdirection":
                           return CSSAttributeType.flexdirection;
                case "flex-flow":
                           return CSSAttributeType.flexflow;
                case "flex-order":
                case "flexorder":
                case "order":
                   return CSSAttributeType.flexorder;

                case "box-direction":
                case "boxdirection":
                      return CSSAttributeType.boxdirection;
                case "box-align":
                case "boxalign":
          return CSSAttributeType.boxalign;
                case "column-count":
                    return CSSAttributeType.columncount;
                case "unicode-bidi":
                case "unicodebidi":
                    return CSSAttributeType.unicodebidi;
                case "text-stroke":
                    return CSSAttributeType.textstoke;
                case "counter-increment":
                case "counterincrement":
return CSSAttributeType.counterincrement;
                case "counter-reset":
                case "counterreset":
                   return CSSAttributeType.counterreset;
                case "align-items":
                case "alignitems":
                return CSSAttributeType.alignitems;
                case "grid-template-columns":
                    return CSSAttributeType.gridtemplatecolumns;
                case "grid-template-rows":
                    return CSSAttributeType.gridtemplaterows;
                case "grid-columns":

                    return CSSAttributeType.gridcolumns;
                case "grid-column-start":
                    return CSSAttributeType.gridcolumnstart;
                case "grid-column-end":
                    return CSSAttributeType.gridcolumnend;
                case "grid-row-start":
                    return CSSAttributeType.gridrowstart;
                case "grid-row-end":
                    return CSSAttributeType.gridrowend;
                case "grid-column":
                                return CSSAttributeType.gridcolumn;
                case "grid-column-span":
             
                                        return CSSAttributeType.gridcolumnspan;
                case "grid-column-align":
                case "gridcolumnalign":
 return CSSAttributeType.gridcolumnalign;
                case "grid-rows":
                case "gridrows":
                    return CSSAttributeType.gridrows;
                case "grid-row":
                case "gridrow":
                            return CSSAttributeType.gridrow;
                case "grid-row-span":
                case "gridrowspan":
                             return CSSAttributeType.gridrowspan;
                case "grid-row-align":
                case "gridrowalign":
                                           return CSSAttributeType.gridrowalign;
                case "overflow-wrap":
                case "overflowwrap":
                     return CSSAttributeType.overflowwrap;
                case "print-color-adjust":
                 return CSSAttributeType.printcoloradjust;
            
                case "flex-line-pack":
                case "flexlinepack":
  return CSSAttributeType.flexlinepack;
                
                case "user-focus":
                case "user-drag":
                case "-ms-user-drag":
                case "-o-user-drag":
                case "-khtml-user-select":
                case "!inportant":
                case "filterstring":
                case "keywardad":
                case "border-left-color-ltr-source":
                case "border-left-color-rtl-source":
                case "border-left-width-ltr-source":
                case "border-left-style-ltr-source":
                case "border-left-style-rtl-source":
                case "border-left-width-rtl-source":
                case "hspace": // OLD Ignore
                case "vspace": // OLD Ignore
                case "!important": // some error
                case "widht": // typo
                case "heihgt": // typo
                case "hieght": // typo
                case "heigt": // typo
                case "bacground": // typo
                case "transparent": // error processing but cont...
                case "magin": // typo for margin ignore.
                case "posistion": // typo
                case "text-indetn": // typo
                case "dislpaly":
                case "margin-bototm": // typo
                case "paddint-bottom": // typo
                case "z-indez": // typo
                    return CSSAttributeType.undefined;
            }
            /*
            if (commonLog.LoggingEnabled  && commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetStyleAttributeType(" + rName + ") Failed");
            }
             */
            return CSSAttributeType.undefined;
        }
	}
}
