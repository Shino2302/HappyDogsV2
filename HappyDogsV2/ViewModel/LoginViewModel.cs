using HappyDogsV2.Views;
using HappyDogsV2.Views.LoginFolder;
using System.Windows.Input;

namespace HappyDogsV2.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        #region VARIABLES
        private string _email;
        private string _password;
        #endregion

        #region CONSTRUCTOR
        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJECTS
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value);}
        }
        #endregion

        #region METHODS
        public async Task GoToMainMenu()
        {
            if(Email == string.Empty || Password == string.Empty)
            {
                await DisplayAlert("Hace falta algo", "Alguno de los campos esta vácio, verifica tú información!", "Ok");
            }
            else
            {
                await Navigation.PushAsync(new Main());
            }
        }

        public async Task GoToRegister()
        {
            await Navigation.PushAsync(new Register());
        }

        public async Task GoToRecoverPassword()
        {
            await Navigation.PushAsync(new RecoverPassword());
        }

        #endregion

        #region COMMANDS
        public ICommand GoToMainMenuCommand => new Command(async () => await GoToMainMenu());
        public ICommand GoToRegisterCommand => new Command(async () => await GoToRegister());
        public ICommand GoToRecoverCommand => new Command(async () => await GoToRecoverPassword());
        #endregion
    }
}
