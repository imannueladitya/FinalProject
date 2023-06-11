using tugasakhir.Views;
using Xamarin.Forms;

namespace tugasakhir
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
           MainPage = new Login();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
