using CommunityToolkit.Mvvm.ComponentModel;
using NewsAPI.Models;
using NewsCore.MVVM.Models;
using NewsCore.MVVM.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewsCore.MVVM.ViewModel
{
    public partial class DistinctAuthorsPageViewModel: BaseViewModel
    {
       // public static List<Distinct> DistinctsListToView = new List<Distinct>();
        public ObservableCollection<Distinct> DistinctsListToView { get; set; } = new();
        [ObservableProperty]
        string searchKeyword;
        public DistinctAuthorsPageViewModel()
        {
            Task.Run(() => GetDistinctAuthors().Wait());
        }
        public async Task GetDistinctAuthors()
        {
            try
            {
                foreach (var item in DistinctsList.Take(20))
                {
                    DistinctsListToView.Add(item);
                } 
            }
            catch (Exception)
            {

                throw;
            }
        } 
          
        partial void OnSearchKeywordChanging(string _searchKeyword)
        {
            try
            {
                if (string.IsNullOrEmpty(_searchKeyword))
                {
                    //Article.Clear();
                    //LoadAllArticles();
                    //return;
                }
                //AllNews = Article;
                var FilteredNews = new List<Distinct>();


                var searchKeywordChaArray = _searchKeyword.ToCharArray();
                var GetLasrsearchCh = searchKeywordChaArray.LastOrDefault();

                if (DistinctsListToView != null)
                {
                    FilteredNews = DistinctsListToView.Where(a => a.Content.StartsWith(_searchKeyword, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (FilteredNews.Count != 0)
                {
                    DistinctsListToView.Clear();
                    foreach (var item in FilteredNews)
                    {
                        DistinctsListToView.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
