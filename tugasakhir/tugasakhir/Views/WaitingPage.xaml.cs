using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tugasakhir.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WaitingPage : ContentPage
	{
        public static string namaw;
        async void GoToHome(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }
        public WaitingPage (string namaA,string namaB,string namaC,int countA, int countB, int countC, int totalA, int totalB, int totalC,int total, int transactionID)
		{
			InitializeComponent ();
            namadiwaiting.Text = namaw;
            waiting_id.Text = transactionID.ToString();
            waiting_barangA.Text = namaA;
            waiting_barangB.Text = namaB;
            waiting_barangC.Text = namaC;
            waiting_countA.Text = countA.ToString();
            waiting_countB.Text = countB.ToString();
            waiting_countC.Text = countC.ToString();
            waiting_totalA.Text = "Rp. " + totalA;
            waiting_totalB.Text = "Rp. " + totalB;
            waiting_totalC.Text = "Rp. " + totalC;
            waiting_total.Text = "Rp. " + total;
        }
	}
}