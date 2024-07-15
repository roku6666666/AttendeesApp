using AttendeesApp.Pages;

namespace AttendeesApp
{
  public partial class AppShell : Shell
  {
    public AppShell()
    {
      InitializeComponent();

      InitRoutes();
    }

    private void InitRoutes()
    {
      Routing.RegisterRoute(nameof(SelectTournamentPage), typeof(SelectTournamentPage));
      Routing.RegisterRoute(nameof(BarcodeCapturePage), typeof(BarcodeCapturePage));
      Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
    }
  }
}
