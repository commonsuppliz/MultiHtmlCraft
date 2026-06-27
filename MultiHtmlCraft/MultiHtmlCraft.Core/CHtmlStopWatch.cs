using System;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlStopWatch 
	/// </summary>
	public sealed class CHtmlStopWatch
	{
		private DateTime __dtStart;
		private TimeSpan __tpSpan;
		private bool __IsTimeSpanObtained = false;
		public CHtmlStopWatch()
		{
			// 
			// 
			//
			__dtStart = DateTime.Now;
		}
		public void Start()
		{
			this.__IsTimeSpanObtained  = false;
			__dtStart = DateTime.Now;
			
		}
		public void Stop()
		{
			this.__tpSpan = DateTime.Now.Subtract(__dtStart);
			__IsTimeSpanObtained = true;
		}
		public double TotalMilliseconds
		{
			get
			{
				if(this.__IsTimeSpanObtained == true)
				{
					return this.__tpSpan.TotalMilliseconds;
				}
				else
				{
					this.Stop();
					return this.__tpSpan.TotalMilliseconds;
				}
			}
		}
		public override string ToString()
		{
			return " Time: " + this.TotalMilliseconds.ToString() + " ms ";
		}

	}
}
