using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HappyDogsV2.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        #region VARIABLES
        private string _email;
        private string _password;
        private string _passwordConfirm;
        #endregion

        #region CONSTRUCTOR
        public RegisterViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJECTS
        public string Email
        {
            get { return _email; }
            set { SetValue(ref _email, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetValue(ref _password, value); }
        }public string PasswordConfirm
        {
            get { return _passwordConfirm; }
            set { SetValue(ref _passwordConfirm, value); }
        }
        #endregion

        #region METHODS
        public async Task Register()
        {
            await DisplayAlert("Registro Exitoso!",$"El usuario con email: {Email} fue registrado exitosamente", "OK");
            await Navigation.PopAsync();
        }
        #endregion

        #region COMMANDS
        public ICommand RegisterCommand => new Command(async () => await Register());
        #endregion
    }
}
