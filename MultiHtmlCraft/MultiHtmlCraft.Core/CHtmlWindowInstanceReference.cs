using System;

namespace MultiHtmlCraft.Core
{
	/// <summary>
	/// CHtmlWindowInstanceReference is used to pass the window reference to child or document etc. Handle with care!
	/// </summary>
	
	public class CHtmlWindowInstanceReference
	{
		internal System.WeakReference ____RhinoTopWindowScriptableReference = null;
		internal System.WeakReference ____RhinoParentWindowScriptableReference = null;
		internal System.WeakReference ____RhinoCurrentWindowScriptableReference = null;
        internal string ____CurrentWindoScriptableTargetShortName = "";

		internal System.WeakReference ____TopWindowControlReference = null;
		internal System.WeakReference ____ParentWindowControlReference = null;
		internal System.WeakReference ____CurrentWindowControlReference = null;
       
		internal System.WeakReference ____NavigotorObjectReference = null;
		internal System.WeakReference ____ScreenObjectReference = null;
		internal System.WeakReference ____ConsoleObjectReference = null;
		internal System.WeakReference ____TopDocumentReference = null;
		internal System.WeakReference ____ParentDocumentReference = null;
		internal System.WeakReference ____ExternalWindowReference = null;
		internal System.WeakReference ____ClipboardReference = null;
        internal System.WeakReference ____HistoryReference = null;

		
		public int ____WindowReferenceLevel =0;


		public CHtmlWindowInstanceReference()
		{

		}
		public CHtmlWindowInstanceReference CloneWindowReferenceWithMakingCurrentObjectAsParent()
		{
			CHtmlWindowInstanceReference newRef =new CHtmlWindowInstanceReference();
			newRef.____WindowReferenceLevel = this.____WindowReferenceLevel + 1;
			if(this.____TopWindowControlReference != null)
			{
				newRef.____TopWindowControlReference = new WeakReference(this.____TopWindowControlReference.Target, false);
			}
        
			if(this.____CurrentWindowControlReference != null)
			{
				newRef.____ParentWindowControlReference = new WeakReference(this.____CurrentWindowControlReference.Target, false);
			}
			if(this.____RhinoTopWindowScriptableReference != null)
			{
				newRef.____RhinoTopWindowScriptableReference = new WeakReference(this.____RhinoTopWindowScriptableReference.Target, false);
			}

			if(this.____RhinoCurrentWindowScriptableReference != null)
			{
				newRef.____RhinoParentWindowScriptableReference = new WeakReference(this.____RhinoCurrentWindowScriptableReference.Target, false);
			}
			// windows.navigator
			if(this.____NavigotorObjectReference != null)
			{
				newRef.____NavigotorObjectReference = new WeakReference(this.____NavigotorObjectReference.Target, false);
			}
			// windows.console
			if(this.____ConsoleObjectReference != null)
			{
				newRef.____ConsoleObjectReference = new WeakReference(this.____ConsoleObjectReference.Target, false);
			}
			// windows.clipboard
			if(this.____ClipboardReference != null)
			{
				newRef.____ClipboardReference =new WeakReference(this.____ClipboardReference.Target, false);
			}
			// windows.screen
			if(this.____ScreenObjectReference != null)
			{
				newRef.____ScreenObjectReference = new WeakReference(this.____ScreenObjectReference.Target , false);
			}
			// windows.external
			if(this.____ExternalWindowReference != null)
			{
				newRef.____ExternalWindowReference = new WeakReference(this.____ExternalWindowReference.Target, false);
			}
			if(this.____TopDocumentReference != null)
			{
				newRef.____TopDocumentReference =new WeakReference(this.____TopDocumentReference.Target, false);
			}
			if(this.____ParentDocumentReference != null)
			{
				newRef.____ParentDocumentReference = new WeakReference(this.____ParentDocumentReference.Target, false);
			}
			return newRef;

		}

		public void SetNavigatorObjectReference(CHtmlNavigator __nav)
		{
			this.____NavigotorObjectReference = new WeakReference(__nav, false);
		}

		public void SetConsoleObjectReference(CHtmlConsole __cons)
		{
			this.____ConsoleObjectReference  =new WeakReference(__cons, false);
		}
		public void SetWindowsExternalObjectReference(CHtmlWindowExternal __winexternal)
		{
			this.____ExternalWindowReference  = new WeakReference(__winexternal, false);
		}
		public void SetParentDocumentReference(CHtmlDocument __doc)
		{
			this.____ParentDocumentReference = new WeakReference(__doc, false);
		}


	}
}
