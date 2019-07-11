# XAMARIN Touch ID/Fingerprint Authentication using Hybrid WebView: Part 1

 In this part we will create new Hybrid App and understand HybridWebView control(custom Webview control) for two way communication between both native and Web applications.

 ### Prerequisites

 Visual Studio setup with Xamarin(Mobile development with .NET).


 ## How can we call javascript function from Xamarin Android project?

 ```
public override void OnPageFinished(Android.Webkit.WebView view, string url)
{
	base.OnPageFinished(view, url);

	string parameter1 = "string parameter";
	int parameter2 = 2;
	string script = string.Format("javascript:myJavascriptFunction('{0}','{1}');", parameter1, parameter2);
	if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
	{
		Device.BeginInvokeOnMainThread(() => view.EvaluateJavascript(script, null));
	}
	else
	{
		Device.BeginInvokeOnMainThread(() => view.LoadUrl(script));
	}
}
 ```


 ## How can we call javascript function from Xamarin iOS project?

 ```
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
 ```


 ## How can we call Xamarin C# function from Web page/Web application using Javascript?

 ```
 document.onload = function() {myFunction()};
	function myFunction() {
      if (window.wx) {//Check if device is Android device 
        window.wx.myXamarinFunctionAndroid(45);
		//above line code for calling C# function from Xamarin Android project
      }
      else if (window.webkit) {//Check if device is IOS device 
        window.webkit.messageHandlers.invokeAction.postMessage("myXamarinFunctionIOS");
		//above line code for calling C# function from Xamarin IOS project
      }
      else {
        console.log('Device OS not recognized');
      }
    }
 ```


 ## Author

 * **Swapnil Dargude** - *Software Developer* (https://github.com/SwapnilDargude)


 ## References

* https://github.com/xamarin/xamarin-forms-samples/tree/master/CustomRenderers/HybridWebView 
* https://www.hackingwithswift.com/example-code/system/how-to-use-touch-id-to-authenticate-users-by-fingerprint
* https://searchsoftwarequality.techtarget.com/definition/hybrid-application-hybrid-app
