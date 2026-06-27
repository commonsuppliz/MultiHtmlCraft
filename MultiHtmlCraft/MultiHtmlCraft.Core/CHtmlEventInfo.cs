using System;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlEventInfo. Function can be script self or JSFuction
	/// </summary>
	public sealed class CHtmlEventInfo 
	{
		public int DocumentIndex;
		internal string Name;
		public object Function;
		public int Timeout;
		public string URL;
		public DateTime LastCallTime;
		public bool IsCompleted = false;

        public bool IsAnimationFrameTimer = false;
        /// <summary>
        /// -1 : Not Timer
        /// 1 : Interval
        /// 10 : Timeout
        /// </summary>
        public int TimerType = -1;
		public CHtmlEventInfo()
		{
		}
		public CHtmlEventInfo(string __Name, int __DocIndex)
		{
			this.DocumentIndex = __DocIndex;
            this.LastCallTime = new DateTime(1900, 01, 01);
			this.IsCompleted = false;
			this.Timeout = 1000;

		}

		public override string ToString()
		{
			return string.Format("Script Event : {0} ID: {1} Function: {2} Done: {3}", this.Name, this.DocumentIndex, this.Function, this.IsCompleted);
		}

	}
	/// <summary>
	/// CHtmlStyleElementKeyClassComparerer 
	/// </summary>
	public sealed class CHtmlEventInfoComparer : System.Collections.IComparer, System.Collections.Generic.IComparer<CHtmlEventInfo>
	{

		#region IComparer メンバ
		/*

		   0 より小さい値 a が b より小さい。 
		   0 a と b は等しい。 
		   0 より大きい値 a が b より大きい。 
		   
		*/
        public int Compare(CHtmlEventInfo evtX, CHtmlEventInfo evtY)
        {

            if (evtX == null && evtY == null)
            {
                return 0;
            }
            if (evtX == null)
            {
                return -1;
            }
            if (evtY == null)
            {
                return 1;
            }

            int indexCompare = evtX.DocumentIndex.CompareTo(evtY.DocumentIndex);
            if (indexCompare != 0)
            {
                return indexCompare;
            }

            return string.Compare(evtX.Name, evtY.Name, StringComparison.Ordinal);
            

        }
        public int Compare(object x, object y)
        {
            try
            {
                CHtmlEventInfo evtX = x as CHtmlEventInfo;
                CHtmlEventInfo evtY = y as CHtmlEventInfo;
                if (evtX == null && evtY == null)
                {
                    return 0;
                }
                if (evtX == null)
                {
                    return -1;
                }
                if (evtY == null)
                {
                    return 1;
                }

                int indexCompare = evtX.DocumentIndex.CompareTo(evtY.DocumentIndex);
                if (indexCompare != 0)
                {
                    return indexCompare;
                }

                return string.Compare(evtX.Name, evtY.Name, StringComparison.Ordinal);
            }
             
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("CHtmlEventInfoComparer", ex);
                }
                return 0;
            }
		}
		#endregion
	}
}
