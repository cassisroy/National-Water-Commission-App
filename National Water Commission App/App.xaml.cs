using National_Water_Commission_App.Services;

namespace National_Water_Commission_App;

public partial class App : Application
{
	public static CustService CustService { get; private set; }
	public App(CustService custService)
	{
		InitializeComponent();

		MainPage = new AppShell();
		CustService = custService;
	}
}
