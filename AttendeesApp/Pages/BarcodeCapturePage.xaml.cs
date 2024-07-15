using System.Text.RegularExpressions;
using ZXing.Net.Maui;

namespace AttendeesApp.Pages;

public partial class BarcodeCapturePage : ContentPage
{
  public BarcodeCapturePage()
  {
    InitializeComponent();
  }

  private void OnBarcodesDetected(object sender, BarcodeDetectionEventArgs e)
  {
    var regex = new Regex(@"/participant/(\d+)/qr");
    var match = regex.Match(e.Results[0].Value);
    if (match.Success && !string.IsNullOrEmpty(match.Groups[1].ToString()))
    {
      barcodeView.IsDetecting = false;
      MainThread.BeginInvokeOnMainThread(async () =>
      {
        var navigationParameter = new Dictionary<string, object>
          {
            {"TournamentName", tournamentName.Text },
            { "Id", match.Groups[1].ToString() }
          };
        await Shell.Current.GoToAsync($"{nameof(RegisterPage)}", navigationParameter);
      });
    }
  }

  protected override void OnAppearing()
  {
    barcodeView.IsDetecting = true;
    base.OnAppearing();
  }

  protected override void OnNavigatedTo(NavigatedToEventArgs args)
  {
    barcodeView.IsDetecting = true;
    base.OnNavigatedTo(args);
  }
}