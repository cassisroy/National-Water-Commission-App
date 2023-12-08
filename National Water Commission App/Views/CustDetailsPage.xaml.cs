using National_Water_Commission_App.ViewModels;

namespace National_Water_Commission_App.Views;

public partial class CustDetailsPage : ContentPage
{
	public CustDetailsPage(CustDetailsViewModel1 custDetailsViewModel1)
	{
		InitializeComponent();
		BindingContext = custDetailsViewModel1;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}