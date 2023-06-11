using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tugasakhir.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{

        async void GoToHome(object sender, EventArgs e)
        {
            var Page = new AppShell();
            NavigationPage.SetHasNavigationBar(Page, false);
            Application.Current.MainPage = Page ;
        }

        async void GoToRegister(object sender, EventArgs e)
        {
            var Page = new Register();
            Application.Current.MainPage = Page;

        }
        public Login ()
		{
            InitializeComponent();
        }
	}
}