using NewsCore.MVVM.ViewModel;
using NewsCore.MVVM.ViewModel.Common;

namespace NewsCore.MVVM.Pages;

public partial class TopHeadingMainCats : ContentPage
{
    private readonly TopHeadingMainCatsViewModel _topHeadingMainCatsViewModel;
    private string selectedCategory;
    public TopHeadingMainCats(TopHeadingMainCatsViewModel topHeadingMainCatsViewModel)
	{
		InitializeComponent();
        this.BindingContext = topHeadingMainCatsViewModel;
        _topHeadingMainCatsViewModel = topHeadingMainCatsViewModel; 
    }

    private void OnCategorySelectionChanged(object sender, EventArgs e)
    {
        selectedCategory = Category.SelectedItem.ToString();
    }

    private void Btn_Clicked(object sender, EventArgs e)
    {
         _topHeadingMainCatsViewModel.GetDataFromApi(selectedCategory);
        // Handle Business category button click
        // You can navigate to a different page, display content, or perform any other action
        // Example: Navigation.PushAsync(new BusinessPage());
    }

    // Event handler for Entertainment category button click
    private void EntertainmentButton_Clicked(object sender, EventArgs e)
    {
        // Handle Entertainment category button click
        // Example: Navigation.PushAsync(new EntertainmentPage());
    }

    // Event handler for General category button click
    private void GeneralButton_Clicked(object sender, EventArgs e)
    {
        // Handle General category button click
        // Example: Navigation.PushAsync(new GeneralPage());
    }

    // Event handler for Health category button click
    private void HealthButton_Clicked(object sender, EventArgs e)
    {
        // Handle Health category button click
        // Example: Navigation.PushAsync(new HealthPage());
    }

    // Event handler for Science category button click
    private void ScienceButton_Clicked(object sender, EventArgs e)
    {
        // Handle Science category button click
        // Example: Navigation.PushAsync(new SciencePage());
    }

    // Event handler for Sports category button click
    private void SportsButton_Clicked(object sender, EventArgs e)
    {
        // Handle Sports category button click
        // Example: Navigation.PushAsync(new SportsPage());
    }

    // Event handler for Technology category button click
    private void TechnologyButton_Clicked(object sender, EventArgs e)
    {
        // Handle Technology category button click
        // Example: Navigation.PushAsync(new TechnologyPage());
    }
}