using System.Collections.ObjectModel;
using RouteRead.Shared.Models;
using RouteRead.Shared.Services;

namespace RouteRead.Mobile.ViewModels;

public sealed class StopsViewModel
{
    private readonly IRouteRepository _repo;

    public string RouteId { get; private set; } = "";
    public string RouteName { get; private set; } = "";

    public ObservableCollection<StopSummary> Stops { get; } = new();

    public StopsViewModel(IRouteRepository repo) => _repo = repo;

    public async Task LoadAsync(string routeId, string routeName)
    {
        RouteId = routeId;
        RouteName = routeName;

        Stops.Clear();
        var stops = await _repo.GetStopsByRouteAsync(routeId);
        foreach (var s in stops) Stops.Add(s);
    }

    public async Task OpenStopAsync(StopSummary stop)
    {
        if (stop is null) return;

        await Shell.Current.GoToAsync(
            nameof(Views.StopDetailPage),
            new Dictionary<string, object> { ["StopId"] = stop.Id }
        );
    }
}