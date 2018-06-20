using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            var homePageViewModel = new HomePageViewModel();
            BindingContext = homePageViewModel;

            webview.Navigated += (sender, e) => {
                if (e.Url != null)
                {
                    homePageViewModel.IsBusy = false;
                }
            };
        }
	}
}