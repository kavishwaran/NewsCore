using NewsAPI.Models;
using NewsCore.MVVM.Models;
using NewsCore.MVVM.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsCore.MVVM.ViewModel
{
    public class TopHeadingMainCatsViewModel : BaseViewModel
    {
        public ObservableCollection<News> Article { get; set; } = new();
        public List<string> Categories { get; set; } = new List<string> { "Business", "Entertainment", "General", "Health", "Science", "Sports", "Technology" };
        public ObservableCollection<News> AllNews { get; set; } = new();
        public string SelectedCategory = "";
        public TopHeadingMainCatsViewModel()
        {
            //  Task.Factory.StartNew(async () => { await OnAppearing(); });
            //Task.Run(() => GetDataFromApi().Wait());

            // Task.Factory.StartNew(async () => { await GetDataFromApi(); });

        }

        public async Task GetDataFromApi( string selectedCategory)
        {
            try
            {
                await GetAllHeadLines(selectedCategory);
                foreach (var news in NewsTopHeadlinesList.Take(20))
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
    }
}
