using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AttendeesApp.Pages
{
  [QueryProperty("TournamentName", "TournamentName")]
  [QueryProperty("Id", "Id")]
  public partial class RegisterViewModel : ObservableObject
  {
    [ObservableProperty]
    private string _id = "";

    [ObservableProperty]
    private string _tournamentName = "";

    [ObservableProperty]
    private string _gameTag = "";

    [ObservableProperty]
    private string _name = "";

    [ObservableProperty]
    private string _attendeeType = "";

    [ObservableProperty]
    private string _result = "";

    [ObservableProperty]
    private bool _doneEnable = false;

    [RelayCommand]
    public async Task Done()
    {
      await Shell.Current.GoToAsync("..");
    }
  }
}
