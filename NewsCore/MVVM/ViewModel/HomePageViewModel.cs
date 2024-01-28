using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsCore.MVVM.ViewModel.Common;
using System.Collections.ObjectModel;
using NewsCore.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsCore.MVVM.Pages;

namespace NewsCore.MVVM.ViewModel
{
    public partial class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<News> Article { get; set; } = new();
        public ObservableCollection<News> AllNews { get; set; } = new();
        [ObservableProperty]
        string searchKeyword;
        public HomePageViewModel()
        {
            //  Task.Factory.StartNew(async () => { await OnAppearing(); });
            Task.Run(() => GetDataFromApi().Wait());

            // Task.Factory.StartNew(async () => { await GetDataFromApi(); });

        }

        public async Task GetDataFromApi()
        {
            try
            {

                foreach (var news in NewsList.Take(20))
                {
                    Article.Add(news);
                }


            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                throw;
            }

        }

        public async Task LoadAllArticles()
        {
            try
            {

                foreach (var news in NewsList.Take(20))
                {
                    AllNews.Add(news);
                }


            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                throw;
            }

        }

        partial void OnSearchKeywordChanging(string _searchKeyword)
        {
            try
            {
                if (string.IsNullOrEmpty(_searchKeyword))
                {
                    Article.Clear();
                    LoadAllArticles();
                    return;
                }
                AllNews = Article;
                var FilteredNews = new List<News>();


                var searchKeywordChaArray = _searchKeyword.ToCharArray();
                var GetLasrsearchCh = searchKeywordChaArray.LastOrDefault();

                if (AllNews != null)
                {
                    FilteredNews = AllNews.Where(a => a.Author.StartsWith(_searchKeyword, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (FilteredNews.Count != 0)
                {
                    Article.Clear();
                    foreach (var item in FilteredNews)
                    {
                        Article.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [RelayCommand]
        public async Task GoToViewAArticleVew(News news)
        {
              ProcessId(news.Id.ToString());
        }

        public async void ProcessId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                NewsArticleId = Convert.ToInt32(id);
                //await Shell.Current.GoToAsync($"{nameof(ViewANewArticlePage)}");
                var tmpAllArticle = Article.FirstOrDefault(a => a.Id == NewsArticleId);
                News selectedNews = tmpAllArticle;
                await Application.Current.MainPage.Navigation.PushAsync(new ViewANewArticlePage(selectedNews));
            }
            // Implement your logic here to process the ID
            // You can perform any operations based on the ID received from the button click
            // For example, you can navigate to another page, perform some data manipulation, etc.
            // This function will be called when a button is clicked in your view
            // You can add breakpoints or logging statements to debug and see if the ID is being passed correctly
        }

        [RelayCommand]
        public async Task ViewDetails()
        {
          //  await Shell.Current.GoToAsync($"{nameof(NewsArticleHistoryPage)}");
        }

    }
}
