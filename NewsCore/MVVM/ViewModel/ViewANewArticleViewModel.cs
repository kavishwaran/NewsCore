using NewsCore.MVVM.Models;
using NewsCore.MVVM.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsCore.MVVM.ViewModel
{
    public class ViewANewArticleViewModel : INotifyPropertyChanged
    {
        private News _selectedNews;

        public event PropertyChangedEventHandler PropertyChanged;
        public ViewANewArticleViewModel(News selectedNews)
        {
            SelectedNews = selectedNews;
        }
        public News SelectedNews
        {
            get { return _selectedNews; }
            set
            {
                if (_selectedNews != value)
                {
                    _selectedNews = value;
                    OnPropertyChanged(nameof(SelectedNews));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
