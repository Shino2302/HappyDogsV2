using HappyDogsV2.ViewModel;

namespace HappyDogsV2.Views.LoginFolder
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }
    }
}