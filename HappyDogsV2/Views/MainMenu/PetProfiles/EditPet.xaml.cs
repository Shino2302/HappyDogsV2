using HappyDogsV2.ViewModel;
namespace HappyDogsV2.Views.MainMenu.PetProfiles;

public partial class EditPet : ContentPage
{
	public EditPet()
	{
		InitializeComponent();
		BindingContext = new EditPetViewModel(Navigation);
	}
}