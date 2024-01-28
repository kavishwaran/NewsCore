using Microsoft.Extensions.Logging;
using NewsCore.Database;
using NewsCore.MVVM.Pages;
using NewsCore.MVVM.ViewModel;
using NewsCore.MVVM.ViewModel.Common;

namespace NewsCore
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //View           
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<ViewANewArticlePage>();
            builder.Services.AddTransient<MainNavigationPage>();
            builder.Services.AddTransient<DistinctAuthorsPage>();
            builder.Services.AddTransient<ViewNewsByDatePage>();
            builder.Services.AddTransient<TopHeadingMainCats>();


            //view model
            builder.Services.AddTransient<HomePageViewModel>();
            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<BaseViewModel>();
            builder.Services.AddTransient<ViewANewArticleViewModel>();
            builder.Services.AddTransient<MainNavigationPageViewModel>();
            builder.Services.AddTransient<DistinctAuthorsPageViewModel>();
            builder.Services.AddTransient<ViewNewsByDatePageViewModel>();
            builder.Services.AddTransient<TopHeadingMainCatsViewModel>();
       

            //database
            builder.Services.AddTransient<LocalDatabase>();
            return builder.Build();
        }
    }
}
