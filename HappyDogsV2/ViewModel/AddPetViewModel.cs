using HappyDogsV2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HappyDogsV2.ViewModel
{
    public class AddPetViewModel : BaseViewModel
    {
        #region VARIABLES
        string _PetName;
        string _PetRaze;
        #endregion

        #region CONSTRUCTOR
        public AddPetViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJECTS
        public string PetName
        {
            get { return _PetName; }
            set { SetValue(ref _PetName, value); }
        }
        public string PetRaze
        {
            get { return _PetRaze; }
            set { SetValue(ref _PetRaze, value); }
        }
        #endregion

        #region METHODS
        public async Task RegisterPet()
        {
            await DisplayAlert("Registro Exitoso!", $"tu mascota se a registrado correctamente", "OK");
            await Navigation.PopAsync();
        }
        #endregion

        #region COMMANDS
        public ICommand RegisterPetCommand => new Command(async () => await RegisterPet());

        #endregion
    }

}
