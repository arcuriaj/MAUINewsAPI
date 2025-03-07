using MAUITestAPI.Pages;

namespace MAUITestAPI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NewsHomePage();

        }
    }
}
