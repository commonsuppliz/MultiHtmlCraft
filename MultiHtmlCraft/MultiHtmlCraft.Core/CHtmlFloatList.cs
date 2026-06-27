using System;
using System.Drawing;
using System.Collections;
namespace MultiHtmlCraft.Core
{
	internal sealed class CHtmlFloatList : System.Collections.ArrayList 
	{
		public CHtmlFloatType FloatType = CHtmlFloatType.Undefined;
		public CHtmlElement ownerElement;
		public double floatTotalWidth = 0;
		public double floatTotalHeight = 0;
		public int StartElement = -1;
		public int EndElement = -1;
		public PointF NextElementPossibleStartPoint = PointF.Empty;
		private int LevelShiftElementPos = 0;
		public ArrayList PriorList = null;
		public bool IsRecord = false;
		public bool IsCleanUp = false;
	
		
		public CHtmlFloatList(CHtmlFloatType _fType)
		{
			this.FloatType = _fType;
			this.PriorList = new ArrayList();
		}
		~CHtmlFloatList()
		{
			this.IsCleanUp = true;
			this.CleanUp();
		}
		private void CleanUp()
		{
			if(this.ownerElement != null)
			{
				this.ownerElement = null;
			}
			if(this.PriorList != null)
			{
				this.PriorList.Clear();
				this.PriorList = null;
			}
		}

		public int JustAdd(object value)
		{
			return base.Add(value);	
		}
		/// <summary>
		/// CHtmlElement を追加すると
		/// 位置がセットされる (Left Right の場合)
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public override int Add(object value)
		{
			int _AddResult = -1;
			if(value is CHtmlElement)
			{
				CHtmlElement floatElement =  value as CHtmlElement;
				if(this.ownerElement == null)
				{
					this.ownerElement = floatElement.___parent as CHtmlElement;
				}
				if(StartElement == -1)
				{
					StartElement = floatElement.___elementOID;
				}
				EndElement = floatElement.___elementOID;
				_AddResult=  base.Add (value);
				if(floatElement.___IsElementVisible == false)
				{
					return _AddResult;
				}
				switch(this.FloatType)
				{
					case CHtmlFloatType.Left:
						if(NextElementPossibleStartPoint.X + floatElement.___offsetWidth <= this.ownerElement.___availWidth)
						{
							floatElement.___offsetLeft = NextElementPossibleStartPoint.X;
							floatElement.___offsetTop = NextElementPossibleStartPoint.Y;
							if(this.floatTotalWidth + floatElement.___offsetWidth <= this.ownerElement.___availWidth)
							{
								this.floatTotalWidth += floatElement.___offsetWidth;
							}
                            NextElementPossibleStartPoint.X = (float)(NextElementPossibleStartPoint.X + floatElement.___offsetWidth);
							try
							{
								this.floatTotalHeight =  GetMaximumHeightFromLastShiftPoint(this.Count, LevelShiftElementPos);
							} 
							catch(Exception ex)
							{
								commonLog.LogEntry("FloatTotalHeight", ex);
							}

						}
						else
						{
							// -------------------------------------------------------------------------
							// Left May Over Flow
							// -------------------------------------------------------------------------
							NextElementPossibleStartPoint.Y += (float)GetMaximumHeightFromLastShiftPoint(this.Count -1, LevelShiftElementPos);
							LevelShiftElementPos = this.Count;
							this.floatTotalHeight += floatElement.___offsetHeight;
							//this.IsNextElementWillBePositionShift = true;
							NextElementPossibleStartPoint.X = 0;
							floatElement.___offsetLeft = NextElementPossibleStartPoint.X;
							floatElement.___offsetTop = NextElementPossibleStartPoint.Y;
							floatElement.___IsFloatStyleTopShiftOccurred = true;
                            NextElementPossibleStartPoint.X = (float)floatElement.___offsetWidth;
							if(this.ownerElement.___offsetHeight < NextElementPossibleStartPoint.Y + floatElement.___offsetHeight)
							{
								this.ownerElement.___offsetHeight = NextElementPossibleStartPoint.Y + floatElement.___offsetHeight;
								this.floatTotalHeight = this.ownerElement.___offsetHeight;
							}
						}
						break;
					case CHtmlFloatType.Right:
						if(this.Count == 1)
						{
                            NextElementPossibleStartPoint.X = (float)this.ownerElement.___availWidth;
							NextElementPossibleStartPoint.Y = 0;

						}
						if(NextElementPossibleStartPoint.X  - floatElement.___offsetWidth >= 0)
						{
							floatElement.___offsetLeft = NextElementPossibleStartPoint.X - floatElement.___offsetWidth;
							floatElement.___offsetTop = NextElementPossibleStartPoint.Y;
                            NextElementPossibleStartPoint.X = (float)(NextElementPossibleStartPoint.X - floatElement.___offsetWidth);
							if(this.floatTotalWidth + floatElement.___offsetWidth <= this.ownerElement.___availWidth)
							{
								this.floatTotalWidth += floatElement.___offsetWidth;
							}
							try
							{
								this.floatTotalHeight =  GetMaximumHeightFromLastShiftPoint(this.Count, LevelShiftElementPos);
							} 
							catch(Exception ex)
							{
								commonLog.LogEntry("FloatTotalHeight", ex);
							}

						}
						else
						{
							// -------------------------------------------------------------------------
							// Right May Over Flow
							// -------------------------------------------------------------------------
                            NextElementPossibleStartPoint.Y += (float)GetMaximumHeightFromLastShiftPoint(this.Count - 1, LevelShiftElementPos);
							floatElement.___offsetLeft = this.ownerElement.___availWidth - floatElement.___offsetWidth;
							floatElement.___offsetTop = NextElementPossibleStartPoint.Y;
							//IsNextElementWillBePositionShift = true;
							floatElement.___IsFloatStyleTopShiftOccurred = true;
							LevelShiftElementPos = this.Count;
							this.floatTotalHeight += floatElement.___offsetHeight;
                            NextElementPossibleStartPoint.X = (float)(this.ownerElement.___availWidth - floatElement.___offsetWidth);
							if(this.ownerElement.___offsetHeight < NextElementPossibleStartPoint.Y + floatElement.___offsetHeight)
							{
								this.ownerElement.___offsetHeight = NextElementPossibleStartPoint.Y + floatElement.___offsetHeight;
								this.floatTotalHeight = this.ownerElement.___offsetHeight;
							}
						}
						break;
					case CHtmlFloatType.Center:
						break;
				}
			}
			else
			{
				commonLog.LogEntry("Invalid Type ___hasInner been added {0}. Ignore it", value);
			}
			return _AddResult;
		}
		public override void Clear()
		{
			// =================================================================
			// Clear may be called at clean up time. Watch out.
			// ==================================================================
			try
			{
				NextElementPossibleStartPoint = Point.Empty;
				this.floatTotalWidth  = 0;
				this.floatTotalHeight = 0;
				LevelShiftElementPos = 0;
				
				
				if(this.IsRecord == false && this.IsCleanUp == false)
				{
					if(this.Count > 0)
					{
						if(this.PriorList != null)
						{
							this.PriorList.Add(this.CloneList());
						}
						if(this.IsCleanUp == false && this.IsRecord == false && this.PriorList != null)
						{
							//commonLog.LogEntry("ChtmlFloatList {0} Clear called : {1} History : {2}", this.CHtmlFloatType, this.Count, this.PriorList.Count);
						}
					}
				}
				
				
				base.Clear();

			} 
			catch
			{
				commonLog.LogEntry("Error During Clear ChtmlFloatList {0} Clear called, but count...", this.FloatType);
			}
		}
		private double  GetMaximumHeightFromLastShiftPoint(int ___Current, int ___Last)
		{
		    double ___CurMaxHeight = 0;
			if(___Last > 0 && ___Current ==  ___Last)
			{
				CHtmlElement el = base[___Last - 1] as CHtmlElement;
				if(el != null)
				{

					if(___CurMaxHeight < el.___offsetHeight)
					{
						return el.___offsetHeight;
					}
				}
			}
			else
			{
				for(int i = ___Current - 1 ; i >= ___Last ; i --)
				{
					CHtmlElement el = base[i] as CHtmlElement;
					if(el != null)
					{
						if(el.___IsElementVisible == false)
						{
							continue;
						}
						if(___CurMaxHeight < el.___offsetHeight)
						{
							___CurMaxHeight = el.___offsetHeight;
						}

					}
				}
			}
			return ___CurMaxHeight;
		}
		public CHtmlFloatList CloneList()
		{
			CHtmlFloatList cloneList = new CHtmlFloatList(this.FloatType);
			cloneList.ownerElement = this.ownerElement;
			cloneList.NextElementPossibleStartPoint = this.NextElementPossibleStartPoint;
			cloneList.floatTotalWidth = this.floatTotalWidth;
			cloneList.floatTotalHeight = this.floatTotalHeight;
			cloneList.StartElement = this.StartElement;
			cloneList.EndElement = this.EndElement;
			cloneList.FloatType = this.FloatType;
			cloneList.IsRecord = true;
			foreach(CHtmlElement element in this)
			{
				cloneList.JustAdd(element);
			}
			return cloneList;
		}
	}
	internal sealed class FloatInfo
	{
		public FloatInfo()
		{

		}
		public int DocumentIndex;
		public string tagName;
		public int X;
		public int Y;
		public int Width;
		public int Height;
		public FloatInfo Clone()
		{
			FloatInfo _newFloat = new FloatInfo();
			_newFloat.X      = this.X;
			_newFloat.Y      = this.Y;
			_newFloat.Width  = this.Width;
			_newFloat.Height = this.Height;
			_newFloat.tagName = this.tagName;
			_newFloat.DocumentIndex = this.DocumentIndex;
			return  _newFloat ;
		}
	}
}
