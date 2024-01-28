using NewsCore.MVVM.ViewModel;

namespace NewsCore.MVVM.Pages;

public partial class Login : ContentPage
{
	public Login(LoginPageViewModel loginPageViewModel)
	{
		this.BindingContext = loginPageViewModel;
		InitializeComponent();
	}
}