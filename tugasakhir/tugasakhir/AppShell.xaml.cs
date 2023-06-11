using Xamarin.Forms;

namespace tugasakhir
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, false);
           // Shell.SetTabBarIsVisible(this, false);  

        }

    }
}
