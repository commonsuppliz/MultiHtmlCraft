using System;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlImageClass For Support JScript 'new Image();'
	/// </summary>
	public class CHtmlImage : CHtmlElement
	{
		private double _x = 0;
		private double _y = 0;
		public CHtmlImage()
		{
			this.tagName = "IMG";
			this.___IsDynamicElement = true;
		}
		public CHtmlImage(double x, double y):base()
		{
			this.tagName = "IMG";
			this._x = x;
			this._y = y;
			this.___IsDynamicElement = true;
		}
	}
}
