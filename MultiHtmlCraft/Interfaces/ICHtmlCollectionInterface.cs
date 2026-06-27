using System.Collections;

namespace MultiHtmlCraft.Interfaces
{
    /// <summary>
    /// Interface for HTMLCollection-like objects
    /// </summary>
    public interface ICHtmlCollectionInterface : IEnumerable
    {
        int length { get; }
        object item(int index);
        object item(string name);
        object[] toArray();
        int Count { get; }
        public ICHtmlCollectionInterface childNodes { get; }
    }
}
