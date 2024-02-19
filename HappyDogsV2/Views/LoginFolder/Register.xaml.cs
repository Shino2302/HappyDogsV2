using HappyDogsV2.ViewModel;

namespace HappyDogsV2.Views.LoginFolder;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel(Navigation);
	}
}