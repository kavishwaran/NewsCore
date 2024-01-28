using NewsCore.MVVM.ViewModel;

namespace NewsCore.MVVM.Pages;

public partial class MainNavigationPage : ContentPage
{
    private readonly MainNavigationPageViewModel _mainNavigationPageViewModel;

    
    public MainNavigationPage(MainNavigationPageViewModel mainNavigationPageViewModel)
	{
       
        InitializeComponent();
        _mainNavigationPageViewModel = mainNavigationPageViewModel;
        this.BindingContext = mainNavigationPageViewModel;
    }
    private async void btnViewAll_Clicked(object sender, EventArgs e)
    {
        try
        {
            var homePageViewModel = new HomePageViewModel();
            await Navigation.PushAsync(new HomePage(homePageViewModel)); 
            //await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        }
        catch (Exception ex)
        {

            throw;
        } 
    }
    private async void btnViewByCategory_Clicked(object sender, EventArgs e)
    {
        try
        {
            var distinctAuthorsPageViewModel = new DistinctAuthorsPageViewModel();
            await Navigation.PushAsync(new DistinctAuthorsPage(distinctAuthorsPageViewModel));
            //await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        }
        catch (Exception ex)
        {

            throw;
        }


    }
    private async void btnViewByDate_Clicked(object sender, EventArgs e)
    {
        try
        {
            var newsByDatePageViewModel = new ViewNewsByDatePageViewModel();
            await Navigation.PushAsync(new ViewNewsByDatePage(newsByDatePageViewModel));
            //await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    private async void btnViewMajCats_Clicked(object sender, EventArgs e)
    {
        try
        {
            var headingMainCatsViewModel = new TopHeadingMainCatsViewModel();
            await Navigation.PushAsync(new TopHeadingMainCats(headingMainCatsViewModel));
            //await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        }
        catch (Exception ex)
        {

            throw;
        }


    }
    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}