using HappyDogsV2.Views.LoginFolder;
using HappyDogsV2.Views.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HappyDogsV2.ViewModel
{
    public class UsersViewModel : BaseViewModel
    {
        #region VARIABLES
        #endregion

        #region CONSTRUCTOR
        public UsersViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJECTS
        #endregion

        #region METHODS
        public async Task CerrarSesion() {
            await Navigation.PushAsync(new Login());
        }
        public async Task EditarUsuario()
        {
            await Navigation.PushAsync(new EditUser());
        }
        #endregion

        #region COMMANDS
        public ICommand CerrarSesionCommand => new Command(async () => await CerrarSesion());

        public ICommand editarUserCommand => new Command(async () => await EditarUsuario());
        #endregion
    }
}
