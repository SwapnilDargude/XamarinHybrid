using Android.OS;
using Android.Webkit;
using Xamarin.Forms;

namespace XamarinHybrid.Droid
{
    public class JavascriptWebViewClient : WebViewClient
    {
        string _javascript;

        public JavascriptWebViewClient(string javascript)
        {
            _javascript = javascript;
        }

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
    }
}
