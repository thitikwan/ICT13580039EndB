using ICT13580039EndB.Helper;
using Xamarin.Forms;

namespace ICT13580039EndB
{
    public partial class App : Application
    {
        public static DBHelper DBHelper
        {
            get;
            set;
        }

        public App(string dbPath)
        {
            InitializeComponent();

            DBHelper = new DBHelper(dbPath);

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
