using AttendeesApp.Models;
using Newtonsoft.Json;

namespace AttendeesApp.Pages;

public partial class RegisterPage : ContentPage
{
  public RegisterPage()
  {
    InitializeComponent();
  }

  protected override void OnNavigatedTo(NavigatedToEventArgs args)
  {
    base.OnNavigatedTo(args);
    Submit().ConfigureAwait(false);
  }

  private async Task Submit()
  {
    var viewModel = BindingContext as RegisterViewModel;
    if (viewModel != null)
    {
      viewModel.Result = "Checking...";
      try
      {
        var client = new HttpClient();

        var tournamentRegisterInfo = new TournamentRegisterInfo();
        tournamentRegisterInfo.tournamentName = viewModel.TournamentName;
        tournamentRegisterInfo.id = viewModel.Id;
        string json = System.Text.Json.JsonSerializer.Serialize(tournamentRegisterInfo);
        StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var response = await client.PostAsync(new Uri(Constants.Url), content);

        if (response != null && response.IsSuccessStatusCode)
        {
          string bodyStr = await response.Content.ReadAsStringAsync();
          var body = JsonConvert.DeserializeObject<AttendeeData>(bodyStr);
          if (body != null && body.statusCode == 200 && body.data != null && !string.IsNullOrEmpty(body.data.firstName) && !string.IsNullOrEmpty(body.data.lastName))
          {
            viewModel.GameTag = body.data.gameTag;
            viewModel.Name = string.Concat(body.data.lastName, body.data.firstName);
            viewModel.AttendeeType = body.data.attendeeType;
            viewModel.Result = "Registered";
            viewModel.DoneEnable = true;
          }
          else
          {
            viewModel.Result = "Error";
            await Shell.Current.GoToAsync("..");
          }
        }
      }
      catch
      {
        viewModel.Result = "Error";
        await Shell.Current.GoToAsync("..");
      }
    }
  }
}