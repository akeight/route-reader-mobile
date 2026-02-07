using RouteRead.Mobile.ViewModels;
using RouteRead.Shared.Models;

namespace RouteRead.Mobile.Views;

public partial class RoutesPage : ContentPage
{
    private readonly RoutesViewModel _vm;

    public RoutesPage(RoutesViewModel vm)
    {
        InitializeComponent();
        _vm = vm;

        RoutesList.SelectionChanged += async (_, e) =>
        {
            var selected = e.CurrentSelection.FirstOrDefault() as RouteSummary;
            RoutesList.SelectedItem = null;
            if (selected is not null) await _vm.OpenRouteAsync(selected);
        };
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        RoutesList.ItemsSource = _vm.Routes;
        await _vm.LoadAsync();
    }
}