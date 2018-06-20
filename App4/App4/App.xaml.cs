using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace App4
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //	MainPage = new MainPage();
            MainPage = new NavigationPage(new Views.HomePage())
            {
                BarBackgroundColor = Color.FromHex("#533F95"),
                BarTextColor = Color.White
            };
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
