using NewsCore.MVVM.ViewModel;

namespace NewsCore.MVVM.Pages;

public partial class DistinctAuthorsPage : ContentPage
{
    private readonly DistinctAuthorsPageViewModel _authorsPageViewModel;
    public DistinctAuthorsPage(DistinctAuthorsPageViewModel distinctAuthorsPageViewModel)
	{
		InitializeComponent();
		this.BindingContext = distinctAuthorsPageViewModel;
		_authorsPageViewModel = distinctAuthorsPageViewModel;
	}
}