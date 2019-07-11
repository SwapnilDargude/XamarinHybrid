using System;
using Android.Webkit;
using Java.Interop;

namespace XamarinHybrid.Droid
{
	public class JSBridge : Java.Lang.Object
	{
		readonly WeakReference<HybridWebViewRenderer> hybridWebViewRenderer;

		public JSBridge (HybridWebViewRenderer hybridRenderer)
		{
			hybridWebViewRenderer = new WeakReference <HybridWebViewRenderer> (hybridRenderer);
		}

		[JavascriptInterface]
		[Export ("invokeAction")]
		public void InvokeAction (string data)
		{
			HybridWebViewRenderer hybridRenderer;

			if (hybridWebViewRenderer != null && hybridWebViewRenderer.TryGetTarget (out hybridRenderer)) 
            {
				hybridRenderer.Element.InvokeAction (data);
			}
		}

		[Export]
		[JavascriptInterface]
		public void myXamarinFunctionAndroid(int data)
		{
			//this function was called from javascript
		}
	}
}

