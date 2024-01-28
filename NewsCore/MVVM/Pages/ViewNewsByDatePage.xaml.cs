using NewsCore.MVVM.ViewModel;

namespace NewsCore.MVVM.Pages;

public partial class ViewNewsByDatePage : ContentPage
{
    private readonly ViewNewsByDatePageViewModel _viewNewsByDatePageViewModel;
    public ViewNewsByDatePage(ViewNewsByDatePageViewModel newsByDatePageViewModel)
	{
		InitializeComponent();
        _viewNewsByDatePageViewModel = newsByDatePageViewModel;
        this.BindingContext = newsByDatePageViewModel; 
    }
    private void StartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        _viewNewsByDatePageViewModel.FilterNewsByDateRange(StartDatePicker.Date, EndDatePicker.Date); 
    }

    private void EndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        // _viewNewsByDatePage.FilterNewsByDateRange();
        _viewNewsByDatePageViewModel.FilterNewsByDateRange(StartDatePicker.Date, EndDatePicker.Date);
    }
}