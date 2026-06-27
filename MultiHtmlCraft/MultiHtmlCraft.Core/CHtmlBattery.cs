using System;
using System.Collections;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
	/// <summary>
    /// CHtmlBattery is window.navigator.battery API set.
    /// Chrome Android and Firefox 16 ___hasInner this feature
	/// </summary>
	
    public sealed class CHtmlBattery : CHtmlNode, ICommonObjectInterface
	{

        private bool ___charging = false;
        public bool charging
        {
            get { return this.___charging; }
        }
        private    double ___chargingTime = 0;
        public double charingTime
        {
            get { return this.___chargingTime; }
        }
    private double ___dischargingTime = 0;
    public double dischargingTime
    {
        get { return this.___dischargingTime; }
    }
    private double              ___level = 1; // 1 : full

    public double level
    {
        get { return this.___level; }
    }
        /*
                attribute EventHandler        onchargingchange;
                attribute EventHandler        onchargingtimechange;
                attribute EventHandler        ondischargingtimechange;
                attribute EventHandler        onlevelchange;
         */
        internal  object ___onchargingchange = null;
        public object onchargingchange
        {
            get { return this.___onchargingchange; }
            set { this.___onchargingchange = value; }
        }
        internal object ___onchargingtimechange = null;
        public object onchargingtimechange
        {
            get { return this.___onchargingtimechange; }
            set { this.___onchargingtimechange = value; }
        }

        internal object ___ondischargingtimechange = null;
        public object ondischargingtimechange
        {
            get { return this.___ondischargingtimechange; }
            set { this.___ondischargingtimechange = value; }
        }
        internal object ___onlevelchange = null;
        public object onlevelchange
        {
            get { return this.___onlevelchange; }
            set { this.___onlevelchange = value; }
        }
        /// <summary>
        /// 0: unkown 1: yes 2: may be error.
        /// </summary>
        static internal byte ___winBatteryAPIavailability = 0; 
        public CHtmlBattery()
		{
            if (___winBatteryAPIavailability == 0)
            {
                ___checkBatteryAPIExistanceOrFill();

            }
		}
  
        public  void ___checkBatteryAPIExistanceOrFill()
        {
            try
            {
  
            }
            catch 
            {
                ___winBatteryAPIavailability = 2;
            }
            ___winBatteryAPIavailability = 2;
        }

   
        public bool hasOwnProperty(object _oname)
        {

            return false;
        }
		private void CleanUp()
		{
			
		}


		#region IPropertBox ƒƒ“ƒo


		
		public object ___getPropertyByName(string ___name)
		{
            switch (___name)
			{
                case "charging":
                    return this.charging;
                case "chargingTime":
                    return this.charingTime;
                case "level":
                    return this.level;
                case "dischargingTime":
                    return this.dischargingTime;
                case "onchargingchange":
                    return this.onchargingchange;
                case "onchargingtimechange":
                    return this.onchargingtimechange;
                case "ondischargingtimechange":
                    return this.ondischargingtimechange;
                case "onlevelchange":
                    return this.onlevelchange;

				default:
					break;
			}
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} '{2}' failed",this.GetType(), this, ___name);
			}
			return null;
		}

		
		public void ___setPropertyByName(string ___name, object val)
		{
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("calling SetPropertyValue for {0} {1}  '{2}' = {3}", this.GetType(), this, ___name, val);
            }
			switch(___name)
			{
                                    case "onchargingchange":
                     this.onchargingchange  = val;
                     return;
                case "onchargingtimechange":
                     this.onchargingtimechange = val;
                     return;
                case "ondischargingtimechange":
                     this.ondischargingtimechange = val;
                     return;
                case "onlevelchange":
                     this.onlevelchange = val;
                     return;
				default:
					bool ___ValueStored = false;
					if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
					{
						commonLog.LogEntry("TODO: SetPropertyValue for {0} {1}  '{2}' = {3} failed : {4}",this.GetType(), this, ___name, val, ___ValueStored );
					}
					break;
			}
		}
		
		public void ___setPropertyByIndex(int ___index, object val)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("TODO : SetPropertyValueIndex for {0} \'{1}\' {2} = {3} failed",this.GetType(), this, ___index, val);
			}
			
		}
		
		public object ___getPropertyByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
			{
				commonLog.LogEntry("TODO : ___getPropertyByName by index {0} {1} {2} failed",this.GetType(), this, ___index);
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
