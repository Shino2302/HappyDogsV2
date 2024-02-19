using HappyDogsV2.ViewModel;

namespace HappyDogsV2.Views;

public partial class AddPet : ContentPage
{
	public AddPet()
	{
		InitializeComponent();
		BindingContext = new AddPetViewModel(Navigation);
	}
}