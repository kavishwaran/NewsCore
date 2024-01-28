using CommunityToolkit.Mvvm.ComponentModel;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsCore.MVVM.Models;
using System.Collections.ObjectModel;

namespace NewsCore.MVVM.ViewModel.Common
{
    public class BaseViewModel : ObservableObject
    {
        protected static List<News> NewsList = new List<News>();
        protected static List<News> NewsTopHeadlinesList = new List<News>();
        protected static List<News> TempNewsList = new List<News>();
        protected static List<Distinct> DistinctsList = new List<Distinct>();
        protected static IEnumerable<string> distinctAuthors = null;

        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "782df1a678734426859239e37dd507f1";
        //private readonly string _apiUrl = "https://newsapi.org/v2/everything?q=tesla&from=2023-12-25&sortBy=publishedAt&apiKey=bde276053dae45b7882738c1b233bf90";
        private readonly string _apiUrl = "https://newsapi.org/v2/top-headlines?sources=cbs-news&";
        private ObservableCollection<News> _newsItem;
        private ObservableCollection<string> Authors;
        private readonly NewsApiClient _newsApiClient;
        public int NewsArticleId = 0;
        public BaseViewModel() {
            _newsItem = new ObservableCollection<News>();
            _newsApiClient = new NewsApiClient(_apiKey);
            Task.Run(() => FetchNewsClicked()).Wait();
            //Task.Run(() => GetDistinctAuthors()).Wait();
            Task.Run(() => GetDistinctContent()).Wait();

        }
        //public async Task<List<News>> OnFetchNewsClicked()
        //{
        //    var articlesResponse = await GetNewsAsync();
        //    if (articlesResponse.Status == Statuses.Ok)
        //    {
        //        List<News> newsList = new List<News>();
        //        foreach (var item in articlesResponse.Articles)
        //        {
        //            News news = new();
        //            news.Author = item.Author;
        //            news.Content = item.Content;
        //            news.Description = item.Description;
        //            news.PublishedAt = item.PublishedAt;
        //            news.Source = item.Source;
        //            news.Title = item.Title;
        //            news.Url = item.Url;
        //            NewsList.Add(news);
        //        }
        //        // Bind the data to the ListView
        //        //newsListView.ItemsSource = articlesResponse.Articles;
        //        return newsList;
        //    }
        //    return null;
        //}
        public async   void FetchNewsClicked()
        {
            int idCounter = 0;
            //var articlesResponse = await GetNewsAsync();
           // var newsApiClient = new NewsApiClient("d236ab8a26cf41108aa1ed56056306bd");
            var articlesResponse = _newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Apple"
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);
                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {
                    idCounter++;
                    var newsArticle = new News
                    {
                        Id = idCounter,
                        Title = article.Title,
                        Author = article.Author,
                        Description = article.Description,
                      Url = LoadImage(article.UrlToImage),
                        //  Url = article.UrlToImage,
                        PublishedAt = article.PublishedAt,
                        Content = article.Content
                    };

                    NewsList.Add(newsArticle);
                }
            }
        }

        public string LoadImage(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return "https://cdn.vectorstock.com/i/preview-1x/65/30/default-image-icon-missing-picture-page-vector-40546530.jpg";
            }

            return url;
        }
        private async Task<ArticlesResult> GetNewsAsync()
        {
            return await _newsApiClient.GetEverythingAsync(new EverythingRequest
            {
                Q = "Apple",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(2024, 01, 10)
            });
        }

        public async void GetDistinctAuthors()
        {
            distinctAuthors = NewsList.Select(news => news.Author).Distinct();
        }
        public async void GetDistinctContent()
        {
            var distinctContentNames = NewsList.Select(news => news.Content).Distinct();
            foreach (var contentName in distinctContentNames)
            {
                // You can add other fields from News as needed
                DistinctsList.Add(new Distinct { Content = contentName });
            } 
        }
        private async Task<ArticlesResult> GetHeadlinesAsync(string selectedCategory)
        {
            if (Enum.TryParse(selectedCategory, out Categories categoryEnum))
            {
                return await _newsApiClient.GetTopHeadlinesAsync(new TopHeadlinesRequest
                {
                    Category = categoryEnum,
                    Language = Languages.EN
                    
                });
            }
            else
            {
                
                throw new ArgumentException("Invalid country Category.");
            }
        }
        public async Task<List<News>> GetAllHeadLines(string selectedCategory)
        {
            int idCounter = 0;
            //var articlesResponse = await GetNewsAsync();
            // var newsApiClient = new NewsApiClient("d236ab8a26cf41108aa1ed56056306bd");
            var articlesResponse = await GetHeadlinesAsync(selectedCategory);
            
            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);
                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {
                    idCounter++;
                    var newsArticle = new News
                    {
                        Id = idCounter,
                        Title = article.Title,
                        Author = article.Author,
                        Description = article.Description,
                        Url = LoadImage(article.UrlToImage),
                        PublishedAt = article.PublishedAt,
                        Content = article.Content
                    };
                    NewsTopHeadlinesList.Add(newsArticle);
                }
                return NewsTopHeadlinesList;
            }
            return null;
        }
    }
}
