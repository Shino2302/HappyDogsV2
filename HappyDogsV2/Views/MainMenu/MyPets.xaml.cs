using HappyDogsV2.ViewModel;

namespace HappyDogsV2.Views;

public partial class MyPets : ContentPage
{
	public MyPets()
	{
		InitializeComponent();
		BindingContext = new MyPetsViewModel(Navigation);
	}
}