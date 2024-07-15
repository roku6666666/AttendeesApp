using AttendeesApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AttendeesApp.Pages
{
  [QueryProperty("TournamentData", "TournamentData")]
  public partial class BarcodeCaptureViewModel : ObservableObject
  {
    [ObservableProperty]
    private TournamentData _tournamentData;
  }
}
