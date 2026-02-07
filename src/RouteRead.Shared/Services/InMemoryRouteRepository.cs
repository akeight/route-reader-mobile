using RouteRead.Shared.Models;

namespace RouteRead.Shared.Services;

public interface IRouteRepository
{
    Task<IReadOnlyList<RouteSummary>> GetRoutesAsync();
    Task<IReadOnlyList<StopSummary>> GetStopsByRouteAsync(string routeId);
    Task<StopSummary?> GetStopAsync(string stopId);
    Task SaveReadingAsync(string stopId, string reading);
}

public sealed class InMemoryRouteRepository : IRouteRepository
{
    private readonly List<RouteSummary> _routes = new()
    {
        new("r1", "North Loop", 3),
        new("r2", "Downtown", 2),
    };

    private readonly List<StopSummary> _stops = new()
    {
        new("s1", "r1", "Stop 101", "123 Pine St", "4521"),
        new("s2", "r1", "Stop 102", "88 Cedar Ave", "1180"),
        new("s3", "r1", "Stop 103", "9 Spruce Rd", null),
        new("s4", "r2", "Stop 201", "14 Main St", "900"),
        new("s5", "r2", "Stop 202", "77 River Dr", null),
    };

    public Task<IReadOnlyList<RouteSummary>> GetRoutesAsync()
        => Task.FromResult((IReadOnlyList<RouteSummary>)_routes);

    public Task<IReadOnlyList<StopSummary>> GetStopsByRouteAsync(string routeId)
        => Task.FromResult((IReadOnlyList<StopSummary>)_stops.Where(s => s.RouteId == routeId).ToList());

    public Task<StopSummary?> GetStopAsync(string stopId)
        => Task.FromResult(_stops.FirstOrDefault(s => s.Id == stopId));

    public Task SaveReadingAsync(string stopId, string reading)
    {
        var idx = _stops.FindIndex(s => s.Id == stopId);
        if (idx >= 0)
        {
            var s = _stops[idx];
            _stops[idx] = s with { LastReading = reading };
        }
        return Task.CompletedTask;
    }
}