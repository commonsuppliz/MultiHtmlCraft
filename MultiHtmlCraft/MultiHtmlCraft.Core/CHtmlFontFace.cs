using MultiHtmlCraft.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MultiHtmlCraft.Core
{
    public class CHtmlFontFace :  IDynamicMetaObjectProvider, ICommonObjectInterface
    {
        internal Type ___multiversalClassType = typeof(CHtmlFontFace);
        internal static Dictionary<string, int> CHtmlFontFaceProperties = createCHtmlFontFaceProperties();

        // font-family: FontSpec family name
        public string fontFamily { get; set; }
        // src: FontSpec file URL or local path
        public string src { get; set; }
        // font-weight: e.g. normal, bold, 100-900
        public string fontWeight { get; set; }
        // font-style: e.g. normal, italic, oblique
        public string fontStyle { get; set; }
        // font-stretch: e.g. normal, condensed, expanded
        public string fontStretch { get; set; }
        // unicode-range: Target Unicode range
        public string unicodeRange { get; set; }
        // ascent-override, descent-override, line-gap-override as needed
        public string ascentOverride { get; set; }
        public string descentOverride { get; set; }
        public string lineGapOverride { get; set; }
        // loaded: Whether the font is loaded
        public bool loaded { get; set; }
        // status: FontSpec loading status (e.g. unloaded, loading, loaded, error)
        public string status { get; set; }
        // style: Additional style information
        public string style { get; set; }
        public string source { get; set; }

        public CHtmlFontFace(string family, string strSource)
        {
            // Set default values
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("enter CHtmlFontFace constructor called for font: {0}", family);
            }
            try
            {
                fontFamily = family ?? throw new ArgumentNullException(nameof(family));
                src = string.Empty;
                fontWeight = "normal";
                fontStyle = "normal";
                fontStretch = "normal";
                unicodeRange = string.Empty;
                ascentOverride = string.Empty;
                descentOverride = string.Empty;
                lineGapOverride = string.Empty;
                loaded = false;
                status = "unloaded";
                style = string.Empty;
                source = strSource ?? throw new ArgumentNullException(nameof(strSource));
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 1)
                {
                    commonLog.LogEntry("Error in CHtmlFontFace constructor: {0}", ex.Message);
                }
                throw ex;
            }
            
        }

        // Asynchronously load the font. Returns a Task as a Promise-like object.
        public Task<CHtmlFontFace> load()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("enter CHtmlFontFace.load() called for font: {0}", fontFamily);
            }
            return Task.Run(async () =>
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("TODO; enter CHtmlFontFace.load() called for font: {0}", fontFamily);
                }
                status = "loading";
                try
                {
                    // Implement font file existence check and loading here
                    // Dummy delay for simulation
                    await Task.Delay(100); // Replace with actual file/network access
                    loaded = true;
                    status = "loaded";
                }
                catch (Exception)
                {
                    loaded = false;
                    status = "error";
                }
                return this;
            });
        }

        private static Dictionary<string, int> createCHtmlFontFaceProperties()
        {
            return new Dictionary<string, int>(StringComparer.Ordinal)
            {
                {"fontFamily", 0},
                {"src", 1},
                {"fontWeight", 2},
                {"fontStyle", 3},
                {"fontStretch", 4},
                {"unicodeRange", 5},
                {"ascentOverride", 6},
                {"descentOverride", 7},
                {"lineGapOverride", 8},
                {"loaded", 9},
                {"status", 10},
                {"style", 11},
                {"source", 12}
            };
        }

        #region IPropertBox メンバ

        public new bool isPrototypeOf(object ___protoObject)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("calling {0}.isPrototpyeOf('{1}') ", this, ___protoObject);
            }
            switch (commonHTML.isPrototypeOf_precheck(this, ___protoObject))
            {
                case 0:
                default:
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                        commonLog.LogEntry("TODO:  {0}.isPrototpyeOf('{1}') test needs more test. returns true for now... ", this, ___protoObject);
                    }
                    break;
                case 1:
                    return true;
                case 2:
                    return false;
            }
            return true;
        }

        public new object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("calling GetPropertyValue for {0} {1} '{2}' ", this.GetType(), this, ___name);
            }



            switch (___name)
            {
                case "source":
                    {
                        return this.source;
                    }
                    break;
                case "status":
                    {
                        return this.status;
                    }
                    break;
                case "loaded":
                    {
                        return this.loaded;
                    }
                    break;
                case "fontFamily":
                    {
                        return this.fontFamily;
                    }
                    break;
                case "src":
                    {
                        return this.src;
                    }
                    break;
                case "fontWeight":
                    return this.fontWeight;
                case "style":
                    return this.style;
                case "fontStyle":
                    return this.fontStyle;
                case "fontStretch":
                    return this.fontStretch;
                case "unicodeRange":
                    return this.unicodeRange;
                case "ascentOverride":
                    return this.ascentOverride;
                case "descentOverride":
                    return this.descentOverride;
                case "lineGapOverride":
                    return this.lineGapOverride;



            }


            return null;
        }
         public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlFontFace>(parameter, this);
        }



        public new void ___setPropertyByName(string ___name, object val)
        {
            bool ___ValueStored = false;
            switch (___name)
            {
                default:
                    break;
            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("SetPropertyValue for {0} {1}  '{2}' = {3} Success : {4}", this.GetType(), this, ___name, val, ___ValueStored);
            }
        }

        public new void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("TODO : SetPropertyValueIndex for {0} \'{1}\' {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }

        public new object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("TODO : ___getPropertyByName by index {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public new bool ___hasPropertyByName(string ___name)
        {
            return false;
        }

        public new bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }
        public new object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public new void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public new void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }
        }
        public new object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public new string ___getClassName()
        {
            return this.GetType().Name;
        }
        public new object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public new object ___getParentScope()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public new void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public new object ___getProtoType()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public new bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public new bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public new void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public new bool hasOwnProperty(string ___name)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry(" {0}.hasOwnProperty {1} called : {2}", this.GetType(), this, ___name);
            }
            return this.___hasPropertyByName(___name);
        }
        public new IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.File;
            }
        }
        public override string ToString()
        {
            return "[object " + this.___multiversalClassType.ToString() + "]";
        }

        #endregion
        #region IDyamicMetaObjectProvider support to get and set properties

        
        public object GetDynamicMember(string name)
        {
            object objValue = null;
            if(CHtmlFontFaceProperties.ContainsKey(name))
            {
                objValue = this.___getPropertyByName(name);
            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.GetDynamicMember({1} returns : {2}", this, name, objValue);
            }

            return objValue;
        }
        public void SetDynamicMember(string name, object value)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
            {
                commonLog.LogEntry("{0}.SettDynamicMember({1} is called value: {2}", this, name, value);
            }
            //this.___properties[name] = value;
        }
        public IEnumerable<string> GetDynamicMemberNames()
        {
            List<string> members = new List<string>();

            members.AddRange(CHtmlFontFaceProperties.Keys);

            return members;
        }
        #endregion
    }
}
