using System;
using System.Collections.Generic;
using System.Drawing;
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
            var Page = new WaitingPage();
            Application.Current.MainPage = Page;
        }

        private void Button_Clicked_Plus_BarangA(object sender, EventArgs e)
        {
            var count = int.Parse(countLabelBarangA.Text);
            count++;
            if (count > 3)
            {
                count = 3;
            }
            countLabelBarangA.Text = count.ToString();
        }

        private void Button_Clicked_Minus_BarangA(object sender, EventArgs e)
        {
            var count = int.Parse(countLabelBarangA.Text);
            count--;
            if(count < 0)
            {
                count = 0;
            }
            countLabelBarangA.Text = count.ToString();
        }
        public OrderPage ()
		{
			InitializeComponent ();
		}
	}
}