using System;

namespace MultiHtmlCraft.Core
{
	#region WebHistory
	public sealed class CHtmlWebHistory
	{
		public string Url = "";
		public string Title = "";
		public string ResponseStatus = "";
		public string Keywords = "";
		public string Category = "";
		public bool IsSelected = false;
        public object State = null;
		public CHtmlWebHistory()
		{

		}
	}
	#endregion
}
