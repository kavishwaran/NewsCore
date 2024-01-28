using NewsCore.MVVM.Models;
using NewsCore.MVVM.ViewModel;

namespace NewsCore.MVVM.Pages;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ViewANewArticlePage : ContentPage
{
 
    public ViewANewArticlePage(News selectedNews)
	{
		InitializeComponent();
        BindingContext = new ViewANewArticleViewModel(selectedNews);
    }
}