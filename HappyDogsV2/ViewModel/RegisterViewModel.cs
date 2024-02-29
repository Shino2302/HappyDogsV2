using HappyDogsV2.Data;
using HappyDogsV2.Models;
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
        private string _name;
        private string _password;
        private string _passwordConfirm;
        private string _phoneNumber;
        private string _profileImage;
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
        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
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
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetValue(ref _phoneNumber, value); }
        }
        public string ProfileImage
        {
            get { return _profileImage; }
            set { SetValue(ref _profileImage, value); }
        }
        #endregion

        #region METHODS
        public async Task Register(UsersModel userToInsert)
        {
            var newUser = ConecctionWithFireBase.client.Child("Users").OnceAsync<UsersModel>();

            await DisplayAlert("Registro Exitoso!",$"El usuario con email: {Email} fue registrado exitosamente", "OK");
            await Navigation.PopAsync();
        }
        #endregion

        #region COMMANDS
        public ICommand RegisterCommand => new Command(async () => await Register());
        #endregion
    }
}
