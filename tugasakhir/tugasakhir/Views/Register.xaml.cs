﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            using (var client = new HttpClient())
            {
                var url = "http://192.168.68.132:8000/api/register";

                var data = new
                {
                    name = name.Text,
                    email = email.Text,
                    password = password.Text
                };
                // password tidak di enkripsi -> gkk bisa login lewat web
                string jsonData = JsonConvert.SerializeObject(data);
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                Console.WriteLine(response);
            }
            var Page = new Login();
            Application.Current.MainPage = Page;
        }




        public Register()
        {
            InitializeComponent();
        }
    }
}