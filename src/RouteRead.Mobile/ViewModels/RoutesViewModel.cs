using System.Collections.ObjectModel;
using RouteRead.Shared.Models;
using RouteRead.Shared.Services;

namespace RouteRead.Mobile.ViewModels;

public sealed class RoutesViewModel
{
    private readonly IRouteRepository _repo;

    public ObservableCollection<RouteSummary> Routes { get; } = new();

    public RoutesViewModel(IRouteRepository repo) => _repo = repo;

    public async Task LoadAsync()
    {
        Routes.Clear();
        var routes = await _repo.GetRoutesAsync();
        foreach (var r in routes) Routes.Add(r);
    }

    public async Task OpenRouteAsync(RouteSummary route)
    {
        if (route is null) return;

        await Shell.Current.GoToAsync(
            nameof(Views.StopsPage),
            new Dictionary<string, object> { ["RouteId"] = route.Id, ["RouteName"] = route.Name }
        );
    }
}