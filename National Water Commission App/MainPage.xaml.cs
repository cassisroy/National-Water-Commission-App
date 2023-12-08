using National_Water_Commission_App.ViewModels;

namespace National_Water_Commission_App;

public partial class MainPage : ContentPage
{
    public MainPage(CustListViewModel1 custListViewModel1)
    {
        InitializeComponent();
        BindingContext = custListViewModel1;

    }

}