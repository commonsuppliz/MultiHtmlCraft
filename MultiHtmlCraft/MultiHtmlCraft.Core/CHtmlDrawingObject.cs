using System;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
	
	/// <summary>
	/// CHtmlDrawingObject is drawingElement
	/// </summary>
	public class CHtmlDrawingObject 
	{
        public CHtmlDrawingObjectType DrawElementType;
        /// <summary>
        /// Weak Refence to ownerObject
        /// </summary>
		public System.WeakReference ___parentWeakReference;
		public string DrawingText;
		private string ___TextToString;
        public int ___DocumentElementIndex;
		public double maximumHeightForDrawLine;
		/// <summary>
		/// Since DrawingElements are used internal only, make this as field not property
		/// </summary>
		public RectangleFSpec offsetBounds = RectangleFSpec.Empty;

        public PointFSpec ___offfsetParentPoint = PointFSpec.Empty;

		private RectangleFSpec _BaseControlDisplayRectangle = RectangleFSpec.Empty;
        public RectangleFSpec ___ScreenRectangle = RectangleFSpec.Empty;
        public CHtmlDrawingObject()
        {
            ___offfsetParentPoint = PointFSpec.Empty;
            offsetBounds = RectangleFSpec.Empty;
            _BaseControlDisplayRectangle = RectangleFSpec.Empty;
            ___ScreenRectangle = RectangleFSpec.Empty;
            maximumHeightForDrawLine = 0;
            ___DocumentElementIndex = -1;
        }



		public RectangleFSpec offsetParentBounds
		{
			get { return new RectangleFSpec(this.___offfsetParentPoint.X, this.___offfsetParentPoint.Y, this.offsetBounds.Width, this.offsetBounds.Height); }
		}
		public RectangleFSpec GetElementBoundsOnScreen()
		{

            return this.___ScreenRectangle;

		}
		private void CalucuateElementsBoundsOnScreeen()
		{
            this.___ScreenRectangle = new RectangleFSpec(
                this.___offfsetParentPoint.X - this.BaseControlDisplayRectangle.X,
                this.___offfsetParentPoint.Y - this.BaseControlDisplayRectangle.Y,
                this.offsetBounds.Width,
                this.offsetBounds.Height);
		}
		public RectangleFSpec BaseControlDisplayRectangle
		{
			get{return this._BaseControlDisplayRectangle;}
			set
			{
				if(this._BaseControlDisplayRectangle.Equals(value))
				{
					return;
				}
				else
				{
					this._BaseControlDisplayRectangle = value;
					CalucuateElementsBoundsOnScreeen();
				}
			}
		}
		public override string ToString()
		{
			if(string.IsNullOrEmpty(___TextToString) == true )
			{
                if (string.IsNullOrEmpty(DrawingText) == true)
                    return "<#DRAW value=''>";
				if(this.DrawingText.Length <= 20)
				{
					___TextToString = "<#DRAW value='" + this.DrawingText + "' bounds='" + this.offsetBounds.ToString() + "' />";
				}
				else
				{
					___TextToString = "<#DRAW value='" + this.DrawingText.Substring(0, 20) + "...' bounds='" + this.offsetBounds.ToString() + "' />";

				}
				return this.___TextToString;
			}
			else
			{
				return this.___TextToString;
			}
			
		}

		
        /// <summary>
        /// ---------------------------------------------------------
        /// do not change this type other than float offsetWidth, offsetHeight, offsetLeft, offsetRight should e use offsetBounds.
        /// ---------------------------------------------------------
        /// </summary>



    }
}
