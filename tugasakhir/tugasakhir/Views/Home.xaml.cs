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
    public partial class Home : ContentPage
    {
        async void GoToOrderPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderPage());
        }
        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
           
        }
    }
}