using National_Water_Commission_App.Views;

namespace National_Water_Commission_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CustDetailsPage), typeof(CustDetailsPage));
	}
}
