using NewsAPI.Models;
using NewsCore.MVVM.Models;
using NewsCore.MVVM.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewsCore.MVVM.ViewModel
{
    public class ViewNewsByDatePageViewModel : BaseViewModel
    {
        private IEnumerable<News> _allNews;
        public IEnumerable<News> AllNews
        {
            get => _allNews;
            set
            {
                _allNews = value;
                OnPropertyChanged(nameof(AllNews));
                //FilterNewsByDateRange(); // Filter news initially
            }
        }

        private IEnumerable<News> _filteredNews;
        public IEnumerable<News> FilteredNews
        {
            get => _filteredNews;
            set
            {
                _filteredNews = value;
                OnPropertyChanged(nameof(FilteredNews));
            }
        }

        public ICommand StartDatePickerCommand { get; }
        public ICommand EndDatePickerCommand { get; }

        public ViewNewsByDatePageViewModel()
        {
            // Initialize commands 
            //StartDatePickerCommand = new Command(() => FilterNewsByDateRange());
            //EndDatePickerCommand = new Command(() => FilterNewsByDateRange());
            Task.Run(() => GetAllNewsFromBase().Wait());
            
           
        }
        public async Task GetAllNewsFromBase()
        {
            try
            {

                AllNews = NewsList.Take(20);


            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                throw;
            }

        }

        public void FilterNewsByDateRange(DateTime startDate, DateTime endDate)
        {
            if (AllNews == null)
                return;

            FilteredNews = AllNews.Where(news => news.PublishedAt >= startDate && news.PublishedAt <= endDate);
        }
    }
}
