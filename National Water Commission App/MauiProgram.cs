using Microsoft.Extensions.Logging;
using National_Water_Commission_App.Services;
using National_Water_Commission_App.ViewModels;
using National_Water_Commission_App.Views;

namespace National_Water_Commission_App;

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

		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "customer1.db2");

		builder.Services.AddSingleton<CustService>(s => ActivatorUtilities.CreateInstance<CustService>(s,dbPath));
		builder.Services.AddSingleton<CustListViewModel1>();
		builder.Services.AddTransient<CustDetailsViewModel1>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<CustDetailsPage>();

		return builder.Build();
	}
}
