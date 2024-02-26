using HappyDogsV2.ViewModel;
using Microsoft.Maui.Controls;

namespace HappyDogsV2.Views;

public partial class AddPet : ContentPage
{
	public AddPet()
	{
		InitializeComponent();
		BindingContext = new AddPetViewModel(Navigation);

	}
}