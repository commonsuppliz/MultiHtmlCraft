using System;
using System.Collections;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// Tiny integer List Framework for a single thread usage.
	/// There is no Lis[int] class in .NET Framework 1.1
	/// This list is 50% to 70 & faster than using .NET 1.0 SortedList because it works Box/Unbox.
	/// Capacity needs to be adjust to ___getInner appropriate values. default 300.
	/// 
	/// </summary>
	public class CHtmlNumberList : System.Collections.Generic.SortedList<int, int>
	{


		private int _Min = int.MaxValue;
		private int _Max = int.MinValue;

		

		public CHtmlNumberList(int _Capacity)
		{
            this.Capacity = _Capacity;
            
		}
		public int Max
		{
			get
			{
				if(this._Max != int.MinValue)
				{
					return this._Max;
				}
				return 0;
			}
		}
		public int Min
		{
			get
			{
				if(this._Min != int.MaxValue)
				{
					return _Min;
				}
				else
				{
					return 0;
				}
			}
		}

		public void Add(int i)
		{
            
            base[i] = 0;
			this._Min = Math.Min(this._Min, i);
			this._Max = Math.Max(this._Max, i);
		}



		public int IndexOf(int _key)
		{
            return base.IndexOfKey(_key);
		}

		/// <summary>
		/// Retuns the list of integer. To Work this property. Set   FillBlankWithMinValue = true at contructor
		/// </summary>


	}

}