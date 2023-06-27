using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                var url = "http://192.168.51.56:8000/api/login";

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
                string content1=await response.Content.ReadAsStringAsync();
                JObject jresponse = JObject.Parse(content1);
                if ((bool)jresponse["success"])
                {
                    Profile.id = (int)jresponse["data"]["id"];
                    Profile.nama = (string)jresponse["data"]["name"] ;
                    Profile.email = (string)jresponse["data"]["email"];

                    WaitingPage.namaw = (string)jresponse["data"]["name"];

                    var Page = new AppShell();
                    Application.Current.MainPage = Page;
                }

                else
                {
                    await DisplayAlert("Alert", (string)jresponse["message"],"OK");
                }

                
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