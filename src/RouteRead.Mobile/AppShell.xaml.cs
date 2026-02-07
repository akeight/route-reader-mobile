using RouteRead.Mobile.Views;

namespace RouteRead.Mobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(StopsPage), typeof(StopsPage));
		Routing.RegisterRoute(nameof(StopDetailPage), typeof(StopDetailPage));
	}
}
