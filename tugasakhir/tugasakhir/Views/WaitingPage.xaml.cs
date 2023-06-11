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
	public partial class WaitingPage : ContentPage
	{
        async void GoToHome(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Home());
        }
        public WaitingPage ()
		{
			InitializeComponent ();
		}
	}
}