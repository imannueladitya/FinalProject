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
	public partial class OrderPage : ContentPage
	{
        async void GoToWaitingPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WaitingPage());
        }
        public OrderPage ()
		{
			InitializeComponent ();
		}
	}
}