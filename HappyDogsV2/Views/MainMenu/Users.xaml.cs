using HappyDogsV2.ViewModel;

namespace HappyDogsV2.Views;

public partial class Users : ContentPage
{
	public Users()
	{
		InitializeComponent();
		BindingContext = new UsersViewModel(Navigation);
	}
}