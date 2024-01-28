using NewsCore.MVVM.Pages;

namespace NewsCore
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainNavigationPage), typeof(MainNavigationPage));
            Routing.RegisterRoute(nameof(ViewNewsByDatePage), typeof(ViewNewsByDatePage));
            Routing.RegisterRoute(nameof(DistinctAuthorsPage), typeof(DistinctAuthorsPage));
            Routing.RegisterRoute(nameof(TopHeadingMainCats), typeof(TopHeadingMainCats));
        }
    }
}
