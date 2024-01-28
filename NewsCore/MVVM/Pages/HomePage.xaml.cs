using NewsCore.Database;
using NewsCore.MVVM.Models;
using NewsCore.MVVM.ViewModel;
using NewsCore.MVVM.ViewModel.Common;

namespace NewsCore.MVVM.Pages;

public partial class HomePage : ContentPage
{
    private readonly HomePageViewModel _homePageViewModel; 

    public HomePage(HomePageViewModel homePageViewModel  )
	{ 
        InitializeComponent();
        _homePageViewModel = homePageViewModel;  
        this.BindingContext = homePageViewModel;
          

    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        //  ID of the clicked item
        var button = sender as Button;
       // var id = button?.CommandParameter as string;
        var id = button.CommandParameter;

        _homePageViewModel.ProcessId(id.ToString());
        
    }
    //private async void InitializeData()
    //{
    //    try
    //    {
    //        List<News> newsList = new();
    //        newsList = await _baseViewModel.OnFetchNewsClicked();
    //        if (newsList is not null)
    //        {
    //            var news = await _localDatabase.GetAllAsync<News>();
    //            if (news.Any())
    //            {
    //                await _localDatabase.DeleteAllAsync<News>();
    //            }
    //            await _localDatabase.AddRangeAsync(newsList);
    //            var newsFromLocalDb = await _localDatabase.GetAllAsync<News>();
    //            newsListView.ItemsSource = news;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        // Handle exceptions here
    //        Console.WriteLine("Exception occurred: " + ex.Message);
    //    }
    //}



}