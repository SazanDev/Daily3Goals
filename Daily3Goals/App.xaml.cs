using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Daily3Goals
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new GoalsPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            MessagingCenter.Send(this, "OnSleep");
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
