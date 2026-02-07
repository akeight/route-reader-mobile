using RouteRead.Mobile.ViewModels;

namespace RouteRead.Mobile.Views;

[QueryProperty(nameof(StopId), "StopId")]
public partial class StopDetailPage : ContentPage
{
    private readonly StopDetailViewModel _vm;

    public string StopId { get; set; } = "";

    public StopDetailPage(StopDetailViewModel vm)
    {
        InitializeComponent();
        _vm = vm;

        SaveBtn.Clicked += async (_, __) =>
        {
            _vm.Reading = ReadingEntry.Text ?? "";
            await _vm.SaveAsync();
        };
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _vm.LoadAsync(StopId);

        StopName.Text = _vm.Stop?.Name ?? "Unknown Stop";
        StopAddress.Text = _vm.Stop?.Address ?? "";
        ReadingEntry.Text = _vm.Reading;
    }
}