using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using WebKit;

namespace XamarinHybrid.iOS
{
	public class NavigationDelegate : WKNavigationDelegate
	{
		private bool IsUserBiometricEnrol { get; set; } = false;
		private WKWebView WebViewObj { get; set; }
		public NavigationDelegate(WKWebView wKWebView)
		{
			this.WebViewObj = wKWebView;
		}
		[Export("webView:didFailNavigation:withError:")]
		public void DidFailNavigation(WKWebView webView, WKNavigation navigation, NSError error)
		{
			// If navigation fails, this gets called
			Console.WriteLine("DidFailNavigation");
		}

		[Export("webView:didFailProvisionalNavigation:withError:")]
		public void DidFailProvisionalNavigation(WKWebView webView, WKNavigation navigation, NSError error)
		{
			// If navigation fails, this gets called
			Console.WriteLine("DidFailProvisionalNavigation");
		}

		[Export("webView:didStartProvisionalNavigation:")]
		public void DidStartProvisionalNavigation(WKWebView webView, WKNavigation navigation)
		{
			// When navigation starts, this gets called
			Console.WriteLine("DidStartProvisionalNavigation");
		}

		[Foundation.Export("webView:didFinishNavigation:")]
		public void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
		{
			string parameter1 = "string parameter";
			int parameter2 = 2;
			WKJavascriptEvaluationResult handler = (NSObject results, NSError err) => {
				if (err != null)
				{
					System.Console.WriteLine(err);
				}
				if (results != null)
				{
					System.Console.WriteLine(results);
				}
			};
			string script = string.Format("javascript:myJavascriptFunction('{0}','{1}');", parameter1, parameter2);
			WebViewObj.EvaluateJavaScript(script, handler);

		}

		[Export("webView:decidePolicyForNavigationAction:decisionHandler:")]
		//public override void DecidePolicy(WKWebView webView, WKNavigationAction navigationAction, Action decisionHandler)
		public override void DecidePolicy(WKWebView webview, WKNavigationAction navigationAction, Action<WKNavigationActionPolicy> decisionHandler)
		{
			var navType = navigationAction.NavigationType;
			var targetFrame = navigationAction.TargetFrame;
			var url = navigationAction.Request.Url;
			bool isHttpUrl = (url.ToString().StartsWith("http") || url.ToString().StartsWith("https"));

			if (isHttpUrl && (targetFrame != null && targetFrame.MainFrame == true))
			{
				decisionHandler(WKNavigationActionPolicy.Allow);
			}
			else if ((isHttpUrl && targetFrame == null) || url.ToString().StartsWith("mailto:") || url.ToString().StartsWith("tel:") || url.ToString().StartsWith("sms:")) //Whatever your test happens to be
			{
				
			} // NEED THIS IN IOS 11
			else if (url.ToString().StartsWith("about"))
			{
				decisionHandler(WKNavigationActionPolicy.Allow);
			}
			else
			{
				//This was allow to fix issue loading content of iframe (Example:Iframe that loads powerBi Report and Apps)
				decisionHandler(WKNavigationActionPolicy.Allow);
			}
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}