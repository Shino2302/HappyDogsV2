﻿using HappyDogsV2.Models;
using HappyDogsV2.Views.MainMenu.PetProfiles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HappyDogsV2.ViewModel
{
    public class PetProfileViewModel : BaseViewModel
    {
        #region VARIABLES
        private string _nameOfPet;
        private string _image;
        #endregion

        #region CONSTRUCTOR
        public PetProfileViewModel(INavigation navigation, string image, string name)
        {
            Navigation = navigation;
            _image = image;
            _nameOfPet = name;
        }
        #endregion

        #region OBJECTS
        public string Image
        {
            get { return _image; }
            set { SetValue(ref _image, value); }
        }
        public string NameOfPet
        {
            get { return _nameOfPet; }
            set { SetValue(ref _nameOfPet, value); }
        }
        #endregion

        #region METHODS
        public async Task PetToDelete()
        {
            var request = await DisplayAlert("CUIDADO", $"¿Estas seguro que deseas eliminar a {NameOfPet}?", "Si", "No");
            if(request == true)
            {
                await DisplayAlert("Que triste noticia", "Nunca olvides a tus seres queridos, ellos no te olvidaran", "Aceptar");
                await Navigation.PopAsync();
            }
        }
        public async Task GoToPetCamera()
        {
            await Navigation.PushAsync(new PetCamera());
        }
        public async Task GoToStatisticsPet()
        {
            await Navigation.PushAsync(new PetStatistics());
        }
        public async Task GoToDispenserConfig()
        {
            await Navigation.PushAsync(new ConfigDispenser());
        }
        #endregion

        #region COMMANDS
        public ICommand DeleteCommand => new Command(async () => await PetToDelete());
        public ICommand GoToCameraCommand => new Command(async (pet) => await GoToPetCamera());
        public ICommand GoToStatisticsCommand => new Command(async () => await GoToStatisticsPet());
        public ICommand GoToDispenserConfigCommand => new Command(async () => await GoToDispenserConfig());

        #endregion
    }
}
