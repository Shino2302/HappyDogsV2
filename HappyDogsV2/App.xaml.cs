using HappyDogsV2.Views.LoginFolder;

namespace HappyDogsV2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Login());
            //MainPage = new NavigationPage(new PetCamera());
        }
    }
}