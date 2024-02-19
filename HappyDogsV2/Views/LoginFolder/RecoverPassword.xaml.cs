using HappyDogsV2.ViewModel;
namespace HappyDogsV2.Views.LoginFolder;

public partial class RecoverPassword : ContentPage
{
	public RecoverPassword()
	{
		InitializeComponent();
		BindingContext = new RecoverPasswordViewModel(Navigation);
	}
}