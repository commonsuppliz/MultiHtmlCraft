using System;
using System.Drawing;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// HTML4,5 Gradation Class
	/// </summary>
	public class CHtmlWebGradation
	{
		private CHtmlCollection _ColorList = null;
		private string _type = "";
		private string _text = "";
		private float _Degree = 0F;
		
		public CHtmlWebGradation()
		{
			this._ColorList = new CHtmlCollection();
		}
		public CHtmlCollection ColorList
		{
			get{return this._ColorList;}
		}
		public string type
		{
			get{return this._type;}
			set{this._type = value;}
		}
		public string text
		{
			set{this._text =value;}
			get{return this._text;}
		}
		public float Degree
		{
			set{this._Degree = value;}
			get{return this._Degree;}
		}

	}
	public class CHtmlWebGradationColor
	{
		public Color GradationColor = Color.Transparent;
		public float Ratio = 0;
		public CHtmlGradationColorType ColorType =  CHtmlGradationColorType.Normal;
	}
}
