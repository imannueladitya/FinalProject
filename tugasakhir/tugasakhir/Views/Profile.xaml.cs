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
    public partial class Profile : ContentPage
    {
        public static string nama, email;
        public static int id;


        

        public Profile()
        {
            InitializeComponent();

            namapengguna.Text = nama;
            emailpengguna.Text = email; 
        }
    }
}