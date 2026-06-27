using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Collections;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlWindowExternal = window.external
	/// </summary>
	
	[ComVisible(true)]
	public class CHtmlWindowExternal : CHtmlNode, ICommonObjectInterface
	{




		public CHtmlWindowExternal()
		{
			

		}
		/// <summary>
		/// Presents a dialog box that enables the user to either add the channel specified, or change the channel URL if it is already installed.
		/// </summary>
		/// <param name="s"></param>
		public void AddChannel(string s)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("window.external.AddChanncel({0}) is called", s);
			}
		}
		public void AddDesktopComponent(string sURL,string  sType)
		{
			this.AddDesktopComponent(sURL, sType, -1, -1, -1,-1);
		}
		public void AddDesktopComponent(string sURL,string  sType, int iLeft , int iTop, int iWidth,int iHeight)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("window.external.AddDesktopComponent({0}) is called", sURL);
			}

		}
        public void msSiteModeSetIconOverlay(object ___iconUrl)
        {
            this.___msSiteModeSetIconOverlay_Inner(___iconUrl, null);
        }
        public void msSiteModeSetIconOverlay(object ___iconUrl, object ___descriptionObject)
        {
            this.___msSiteModeSetIconOverlay_Inner(___iconUrl, ___descriptionObject);
        }
        private void ___msSiteModeSetIconOverlay_Inner(object ___iconUrl, object ___descriptionObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("window.external.___msSiteModeSetIconOverlay({0}, {1}) is called", ___iconUrl, ___descriptionObject);
            }
        }
        /// <summary>
        /// Creates a new group of items on the Jump List.
        /// </summary>
        /// <param name="___objHeader"></param>
        public void msSiteModeCreateJumpList(object ___objHeader)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("window.external.msSiteModeCreateJumpList({0}) is called. do nothing.", ___objHeader);
            }
        }
        /// <summary>
        /// Creates a new group of items on the Jump List.
        /// </summary>
        /// <param name="___objHeader"></param>
        public void msSiteModeCreateJumplist(object ___objHeader)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("window.external.msSiteModeCreateJumplist({0}) is called. do nothing.", ___objHeader);
            }
        }
        public void msSiteModeAddJumpListItem(object ___p1, object ___p2, object ___p3, object ___p4)
        {
            this.___msSiteModeAddJumpListItem_Inner(___p1, ___p2, ___p3, ___p4);
        }
        public void msSiteModeAddJumpListItem(object ___p1, object ___p2, object ___p3)
        {
            this.___msSiteModeAddJumpListItem_Inner(___p1, ___p2, ___p3, null);
        }
        public void msSiteModeAddJumpListItem(object ___p1, object ___p2)
        {
            this.___msSiteModeAddJumpListItem_Inner(___p1, ___p2, null, null);
        }
        public void msSiteModeAddJumpListItem(object ___p1)
        {
            this.___msSiteModeAddJumpListItem_Inner(___p1, null, null, null);
        }
        public void msSiteModeAddJumpListItem()
        {
            this.___msSiteModeAddJumpListItem_Inner(null, null, null, null);
        }
        private  void ___msSiteModeAddJumpListItem_Inner(object ___p1, object ___p2, object ___p3, object ___p4)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("window.external.msSiteModeAddJumpListItem() is called. do nothing.");
            }
        }
        /// <summary>
        /// MSIE Only feature filterling functionality
        /// </summary>
        /// <returns></returns>
        public bool InPrivateFilteringEnabled()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("window.external.InPrivateFilteringEnabled()() is called. return false.");
            }
            return false;
        }
        public bool msTrackingProtectionEnabled()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("window.external.msTrackingProtectionEnabled()() is called. return true.");
            }
            return true;
        }
        /// <summary>
        /// Depricated Method only retuns 0.
        /// </summary>
        /// <param name="___str"></param>
        /// <returns></returns>
        public double IsSearchProviderInstalled(string ___str)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("window.external.IsSearchProviderInstalled({0}) is called. returns 0.", ___str);
            }
            return 0;
        }
        public bool isGoogleHomePage()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("window.external.isGoogleHomePage()() is called. returns true");
            }
            return true;
        }
        public void msSiteModeClearIconOverlay()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("window.external.msSiteModeClearIconOverlay() is called");
            }
        }

		public void AddFavorite(string sURL)
		{
			this.AddFavorite(sURL, "");
		}
		public void AddFavorite(string sURL ,string sTitle)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("window.external.AddFavorite({0}) is called", sURL);
			}
		}
		/// <summary>
		/// Saves the specified form in the AutoComplete data store.
		/// </summary>
		/// <param name="oForm"></param>
		public void AutoCompleteSaveForm(CHtmlElement oForm)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("window.external.AutoCompleteSaveForm({0}) is called", oForm);
			}
		}
		public void AutoScan(string sUserQuery,string  sURL)
		{
			this.AutoScan(sUserQuery, sURL);
		}
		public void AutoScan(string sUserQuery,string  sURL ,string sTarget)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("window.external.AutoScan({0}) is called",  sURL);
			}
		}
		/// <summary>
		/// Handles the importing and exporting of MicrosoftR Internet Explorer favorites.
		/// </summary>
		/// <param name="bImportExport"></param>
		/// <param name="sImportExportPath"></param>
		public void ImportExportFavorites(bool bImportExport,string sImportExportPath)
		{

		}
		/// <summary>
		/// Retrieves a value indicating whether the client subscribes to the given channel.
		/// </summary>
		/// <param name="sURLToCDF"></param>
		/// <returns></returns>
		public bool IsSubscribed(string sURLToCDF)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("window.external.IsSubscribed({0}) is called", sURLToCDF);
			}
			return true;
		}
		public void NavigateAndFind(string sLocation,string  sQuery,string sTargetFrame)
		{

		}
		public object ShowBrowserUI(object sUI, object o)
		{
			return null;

		}
		
		public bool hasOwnProperty(object _oname)
		{
            string sName = _oname as string;
            if (sName == null || sName.Length == 0)
                return false;
            object propValue = this.___getPropertyByName(sName);
            if (propValue == null || propValue.ToString().Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
		}
		/// <summary>
		/// Returns the window object where the context menu item was executed. 
		/// </summary>
		public object menuArguments
		{
			get
			{
				if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
				{
					commonLog.LogEntry("window.external.menuArguments is called, but returns null. TODO:");
				}
				return null;

			}
		}
		#region IPropertBox ƒƒ“ƒo


		public object ___getPropertyByName(string ___name)
		{
			string ___nameLow = commonHTML.FasterTrimAndToLower(___name);
			switch(___nameLow)
			{
				
                case "_gauserprefs":
                    return null;
                default:

                    if (this.___properties.ContainsKey(___name))
                    {
                        return this.___properties[___name];
                    }
					
					break;
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed",this.GetType(), this, ___name);

			}
			return null;
		}

		public void ___setPropertyByName(string ___name, object val)
		{
			switch(___name)
			{

				default:
					bool ___ValueStored = false;
					if(this.___properties  != null)
					{

							try
							{
								this.___properties[___name] = val;
								___ValueStored  = true;
							}
							catch{}

						
					}
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
					{
						commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} Success : {4}",this.GetType(), this, ___name, val, ___ValueStored );
					}
					break;
			}
		}
		public void ___setPropertyByIndex(int ___index, object val)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("SetPropertyValueIndex for {0} \'{1}\' {2} = {3} failed",this.GetType(), this, ___index, val);
			}
			
		}
		public object ___getPropertyByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed",this.GetType(), this, ___index);
			}
			return null;
		}

		public bool ___hasPropertyByName(string ___name)
		{

			return false;
		}
		public bool ___hasPropertyByIndex(int ___index)
		{
			return true;
		}
		public object ___common_object_clone()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("x__Clone {0} {1} called",this.GetType(), this);
			}
			return this;
		}
		public void ___deleteByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}",this.GetType(), this, ___index);
			}
		}
		public void ___deleteByName(string ___name)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByName {0} {1} called : {2}",this.GetType(), this, ___name);
			}

		}
		public object[] ___getByIds()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getByIds() {0} {1} called",this.GetType(), this);
			}
			return null;

		}
		public string ___getClassName()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getClassName {0} {1} called",this.GetType(), this);
			}
			return this.GetType().Name;
		}
		public object ___getDefaultValue()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getDefaultValue {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public object ___getParentScope()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getParentScope {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public void ___setParentScope(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___setParentScope {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}
		public object ___getProtoType()
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___getProtoType {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public bool ___hasInstance(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___hasInstance {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return false;
		}
		public bool ___instanceEquals(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___instanceEquals {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return object.ReferenceEquals(this, ___object);
		}
		public void ___setProtoType(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
			{
				commonLog.LogEntry("___setProtoType {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}

		#endregion
	}
}
