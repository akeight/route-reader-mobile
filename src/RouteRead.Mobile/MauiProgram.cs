using Microsoft.Extensions.Logging;
using RouteRead.Mobile.Views;
using RouteRead.Mobile.ViewModels;
using RouteRead.Shared.Services;

namespace RouteRead.Mobile;

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
		
		// Repo
		builder.Services.AddSingleton<IRouteRepository, InMemoryRouteRepository>();

		// ViewModels
		builder.Services.AddTransient<RoutesViewModel>();
		builder.Services.AddTransient<StopsViewModel>();
		builder.Services.AddTransient<StopDetailViewModel>();

		// Pages
		builder.Services.AddTransient<RoutesPage>();
		builder.Services.AddTransient<StopsPage>();
		builder.Services.AddTransient<StopDetailPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
