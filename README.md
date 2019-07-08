# XAMARIN Touch ID/Fingerprint Authentication using Hybrid WebView: Part 1

 In this part we will create new Hybrid App and understand HybridWebView control(custom Webview control) for two way communication between both native and Web applications.

 ### Prerequisites

 Need Xamarin(Mobile development with .NET) setup in Visual studio.


 ## How can we call javascript function from Xamarin android?

 ```
 string script = string.Format("javascript:myJavascriptFunction('{0}','{1}');", parameter1, parameter2);
if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat){
Device.BeginInvokeOnMainThread(() => webView.EvaluateJavascript(script, null));
}
else{
Device.BeginInvokeOnMainThread(() => webView.LoadUrl(script));
}
 ```

 ## How can we call javascript function from Xamarin iOS?

 ```
 WKJavascriptEvaluationResult handler = (NSObject results, NSError err) =>{
if (err != null){
System.Console.WriteLine(err);
}
if (results != null){
System.Console.WriteLine(results);
}
};
string script = string.Format("javascript:myJavascriptFunction('{0}','{1}');", parameter1, parameter2);
WebViewObj.EvaluateJavaScript(script, handler);
 ```

 ## How can we call Xamarin function from web page?

 ```
 document.onload = function() {myFunction()};
function myFunction() {
if(window.wx){//Check is IOS device 
window.wx.myXamarinFunctionAndroid(45);//call function from Xamarin android 
}
 else if(window.webkit) {//Check is IOS device 
 window.webkit.messageHandlers.invokeAction.postMessage("myXamarinFunctionIOS");//call function from Xamarin IOS
 }
 else{
 console.log('Device not recognized');
 }
}
 ```


 ## Authors

 * **Swapnil Dargude** - *Software Developer* (https://github.com/SwapnilDargude)


 ## References

 * https://github.com/xamarin/xamarin-forms-samples/tree/master/CustomRenderers/HybridWebView 
* https://www.hackingwithswift.com/example-code/system/how-to-use-touch-id-to-authenticate-users-by-fingerprint
* https://searchsoftwarequality.techtarget.com/definition/hybrid-application-hybrid-app
