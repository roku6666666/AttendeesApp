using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Text.Json.Serialization;
using AttendeesApp.Pages;

namespace AttendeesApp.Models
{
  public partial class TournamentData : ObservableObject
  {
    [ObservableProperty, JsonPropertyName("name")]
    private string name = "";

    [ObservableProperty, JsonPropertyName("date")]
    private string date = "";

    [ObservableProperty, JsonPropertyName("type")]
    private string type = "";

    public string Color { get; set; } = "";

    public Brush ColorBrush
    {
      get
      {
        return new SolidColorBrush(Microsoft.Maui.Graphics.Color.Parse(Color));
      }
    }

    [RelayCommand]
    private async Task Select()
    {
      try
      {
        var navigationParameter = new Dictionary<string, object>
            {
                { "TournamentData", this }
            };
        await Shell.Current.GoToAsync($"{nameof(BarcodeCapturePage)}", navigationParameter);
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
      }
    }
  }
}
