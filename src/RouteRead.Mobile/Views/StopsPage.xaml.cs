using RouteRead.Mobile.ViewModels;
using RouteRead.Shared.Models;

namespace RouteRead.Mobile.Views;

[QueryProperty(nameof(RouteId), "RouteId")]
[QueryProperty(nameof(RouteName), "RouteName")]
public partial class StopsPage : ContentPage
{
    private readonly StopsViewModel _vm;

    public string RouteId { get; set; } = "";
    public string RouteName { get; set; } = "";

    public StopsPage(StopsViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm;

        StopsList.SelectionChanged += async (_, e) =>
        {
            var selected = e.CurrentSelection.FirstOrDefault() as StopSummary;
            StopsList.SelectedItem = null;
            if (selected is not null) await _vm.OpenStopAsync(selected);
        };
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        StopsList.ItemsSource = _vm.Stops;
        await _vm.LoadAsync(RouteId, RouteName);
    }
}