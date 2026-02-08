using RouteRead.Shared.Models;
using RouteRead.Shared.Services;

namespace RouteRead.Mobile.ViewModels;

public sealed class StopDetailViewModel
{
    private readonly IRouteRepository _repo;

    public StopSummary? Stop { get; private set; }
    public string Reading { get; set; } = "";

    public StopDetailViewModel(IRouteRepository repo) => _repo = repo;

    public async Task LoadAsync(string stopId)
    {
        Stop = await _repo.GetStopAsync(stopId);
        Reading = Stop?.LastReading ?? "";
    }

    public async Task SaveAsync()
    {
        if (Stop is null) return;
        if (string.IsNullOrWhiteSpace(Reading)) return;

        await _repo.SaveReadingAsync(Stop.Id, Reading);
        await Shell.Current.DisplayAlert("Saved", "Reading saved (in-memory for now).", "OK");
    }
}