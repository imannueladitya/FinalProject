using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tugasakhir.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        //public static string barangA_home,barangB_home,barangC_home;
        async void GoToOrderPage(object sender, EventArgs e)
        {
            var Page = new OrderPage();
            Application.Current.MainPage = Page;
        }
        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            Task.Run(async () => {
                using (var client = new HttpClient())
                {
                    var url = "http://192.168.1.4:8000/api/gethargaproduk";
                    // Send the POST request
                    HttpResponseMessage response = await client.GetAsync(url);
                    string content1 = await response.Content.ReadAsStringAsync();
                    JObject jresponse = JObject.Parse(content1);

                    namaAhome.Text = (string)jresponse["data"][0]["product_name"];
                    namaBhome.Text = (string)jresponse["data"][1]["product_name"];
                    namaChome.Text = (string)jresponse["data"][2]["product_name"];
                }
            });
        }
    }
}