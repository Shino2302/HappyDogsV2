using HappyDogsV2.Models;
using HappyDogsV2.ViewModel;

namespace HappyDogsV2.Views.MainMenu.PetProfiles;

public partial class PetProfile : ContentPage
{
	public PetProfile(ReferenceToObservableCollection dataOfPet)
	{
		InitializeComponent();
		BindingContext = new PetProfileViewModel(Navigation, dataOfPet.Imagen, dataOfPet.Nombre);
	}
}