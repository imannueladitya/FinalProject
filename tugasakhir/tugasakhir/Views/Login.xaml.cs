using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using tugasakhir.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tugasakhir.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{

        async void GoToHome(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var url = "http://192.168.68.132:8000/api/login";

                var data = new
                {
                    email = email.Text,
                    password = password.Text
                };

                // Convert the data to JSON string
                string jsonData = JsonConvert.SerializeObject(data);

                // Create the HttpContent for the JSON data
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = await client.PostAsync(url, content);
                Console.WriteLine(response);
                var Page = new Home();
                Application.Current.MainPage = Page;
            }
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