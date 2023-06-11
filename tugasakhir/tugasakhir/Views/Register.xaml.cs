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
    public partial class Register : ContentPage
    {
        async void GoToLogin(object sender, EventArgs e)
        {
            var Page = new Login();
            Application.Current.MainPage = Page;
        }
        public Register()
        {
            InitializeComponent();
        }
    }
}