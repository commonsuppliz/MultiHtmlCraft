using System;

namespace MultiHtmlCraft.Interfaces
{


    public class MultiversalUniqueTag
    {
        [Flags]
        public enum UniqueType : byte
        {
            NotSet,
            Undefined,
            Not_Found
        }
        public MultiversalUniqueTag(UniqueType __type)
        {
            value = __type;
        }

        public UniqueType value;

    }
    [Flags]
    public enum UniqueTagType : byte
    {
        NotSet,
        Undefined,
        Not_Found
    }
    public interface MulversalUniqueValue
    {
        UniqueTagType uniqueType { set; get; }
    }
}
