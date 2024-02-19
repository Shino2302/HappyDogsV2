using HappyDogsV2.ViewModel;

namespace HappyDogsV2.Views.MainMenu.PetProfiles;

public partial class ConfigDispenser : ContentPage
{
	public ConfigDispenser()
	{
		InitializeComponent();
		BindingContext = new ConfigDispenserViewModel(Navigation);
	}
}