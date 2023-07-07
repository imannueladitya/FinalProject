using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Xamarin.Essentials;
using System.Transactions;
using System.Diagnostics;

namespace tugasakhir.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderPage : ContentPage
	{
        int produkIDA;
        int produkIDB;
        int produkIDC;

        int countA=0;
        int countB=0;
        int countC=0;


        int hargaA = 0;
        int hargaB = 0;
        int hargaC = 0;

        int totalA = 0;
        int totalB = 0;
        int totalC = 0;
        int total = 0;
        async void GoToWaitingPage(object sender, EventArgs e)
        {

            using (var client = new HttpClient())
            {
                var url = "http://192.168.1.4:8000/api/orderproduk";

                var data = new
                {
                    user_id = Profile.id ,
                    product_idA = produkIDA,
                    id_qtyA = countA,
                    id_totalA = totalA,
                    product_idB = produkIDB,
                    id_qtyB = countB,
                    id_totalB = totalB,
                    product_idC = produkIDC,
                    id_qtyC = countC,
                    id_totalC = totalC,
                    transaction_totalprice = total,
                    
                 };

                Debug.WriteLine(data);

                string jsonData = JsonConvert.SerializeObject(data);
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                string content1 = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content1);
                JObject jresponse = JObject.Parse(content1);
                var transactionID = (int)jresponse["transaction_id"];

                var Page = new WaitingPage(namaA.Text, namaB.Text, namaC.Text, countA, countB, countC, totalA, totalB, totalC, total, transactionID);
                Application.Current.MainPage = Page;
            }


        }

        private void Button_Clicked_Plus_BarangA(object sender, EventArgs e)
        {
            if (countA + countB + countC < 3)
            {
                countA++;
                countLabelBarangA.Text = countA.ToString();
                totalharga();
            }
        }

        private void Button_Clicked_Minus_BarangA(object sender, EventArgs e)
        {
           
            countA--;
            if(countA < 0)
            {
                countA = 0;
            }
            countLabelBarangA.Text = countA.ToString();
            totalharga();
        }

        private void Button_Clicked_Plus_BarangB(object sender, EventArgs e)
        {
            if (countA + countB + countC < 3)
            {
                countB++;
                countLabelBarangB.Text = countB.ToString();
                totalharga();
            }
        }

        private void Button_Clicked_Minus_BarangB(object sender, EventArgs e)
        {

            countB--;
            if (countB < 0)
            {
                countB = 0;
            }
            countLabelBarangB.Text = countB.ToString();
            totalharga();
        }

        private void Button_Clicked_Plus_BarangC(object sender, EventArgs e)
        {
            if (countA + countB + countC < 3)
            {
                countC++;
                countLabelBarangC.Text = countC.ToString();
                totalharga();
            }
        }

        private void Button_Clicked_Minus_BarangC(object sender, EventArgs e)
        {

            countC--;
            if (countC < 0)
            {
                countC = 0;
            }
            countLabelBarangC.Text = countC.ToString();
            totalharga();
        }

        private void totalharga ()
        {
            totalA = countA * hargaA;
            totalB = countB * hargaB;
            totalC = countC * hargaC;
            total = totalA+ totalB + totalC;

            jumlahA.Text = countA.ToString();
            jumlahB.Text = countB.ToString();
            jumlahC.Text = countC.ToString();

            totalhargaA.Text = totalA.ToString();
            totalhargaB.Text = totalB.ToString();
            totalhargaC.Text = totalC.ToString();

            settotalharga.Text= total.ToString();



        }
        public OrderPage()
        {
            InitializeComponent();
            Task.Run(async () =>
            {
                using (var client = new HttpClient())
                {
                    var url = "http://192.168.1.4:8000/api/gethargaproduk";

                    // Send the GET request
                    HttpResponseMessage response = await client.GetAsync(url);
                    string content1 = await response.Content.ReadAsStringAsync();

                    JObject jresponse = JObject.Parse(content1);

                    hargaA = (int)jresponse["data"][0]["product_price"];
                    hargaB = (int)jresponse["data"][1]["product_price"];
                    hargaC = (int)jresponse["data"][2]["product_price"];

                    namaA.Text = (string)jresponse["data"][0]["product_name"];
                    namaB.Text = (string)jresponse["data"][1]["product_name"];
                    namaC.Text = (string)jresponse["data"][2]["product_name"];

                    atasnamaA.Text = (string)jresponse["data"][0]["product_name"];
                    atasnamaB.Text = (string)jresponse["data"][1]["product_name"];
                    atasnamaC.Text = (string)jresponse["data"][2]["product_name"];

                    produkIDA = (int)jresponse["data"][0]["id"];
                    produkIDB = (int)jresponse["data"][1]["id"];
                    produkIDC = (int)jresponse["data"][2]["id"];
                }
            }).GetAwaiter().GetResult();
        }

    }
}