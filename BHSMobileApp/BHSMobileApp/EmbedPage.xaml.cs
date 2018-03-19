using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BHSMobileApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmbedPage : ContentPage
	{
        private WebView webView;

		public EmbedPage ()
		{
			InitializeComponent ();

            Button button = new Button {  Text = "Invoke JS" };
            button.Clicked += OnButtonClicked;


            webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "https://www.w3schools.com/jsref/tryit.asp?filename=tryjsref_regexp_test2",
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    button,
                    webView
                }
            };

            webView.Navigated += (o, s) => { webView.Eval("alert('text1')"); };
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            //webView.Eval("alert('text2: '+document.getElementById(\"framesize\").innerHTML)");

            webView.Eval("alert('text3: '+document.getElementById('iframeResult').contentWindow.myFunction())");         
        }
    }
}