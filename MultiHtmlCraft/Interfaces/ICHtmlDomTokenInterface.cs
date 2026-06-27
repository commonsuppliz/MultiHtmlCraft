using System;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// ICHtmlDomTokenInterface is DomTokenInterface
	/// interface DOMTokenList {
	/// readonly attribute unsigned long length;
	/// getter DOMString? item(unsigned long index);
	/// boolean contains(DOMString token);
	/// void add(DOMString... tokens);
	/// void remove(DOMString... tokens);
	/// boolean toggle(DOMString token, optional boolean force);
	/// stringifier;
    /// };
	/// </summary>
	public interface ICHtmlDomTokenInterface
	{
		 bool contains(object tokens);
		 void add(object tokens);
		 void remove(object tokens);
		 bool toggle(string token,  bool force);
		 bool toggle(string token);
	}
}
