using AttendeesApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace AttendeesApp.Pages
{
  public partial class SelectTournamentViewModel : ObservableObject
  {
    [ObservableProperty]
    private ObservableCollection<TournamentData> _tournamentDataList;

    [ObservableProperty]
    private string pageCurrentState = "Loading";

    public SelectTournamentViewModel()
    {
      _tournamentDataList = new ObservableCollection<TournamentData>();
      LoadTournamentDataList().ConfigureAwait(false);
    }

    private async Task LoadTournamentDataList()
    {
      var client = new HttpClient();
      try
      {
        var response = await client.GetStringAsync(new Uri(Constants.Url));
        if (response != null)
        {
          var body = JsonConvert.DeserializeObject<TournamentDataSet>(response);
          if (body != null)
          {
            var tournamentDataList = body.TournamentDataList;
            tournamentDataList
              .ForEach(data =>
              {
                data.Date = DateTime.Parse(data.Date).Date.ToString("yyyy/MM/dd");
                var typeData = body.TournamentTypeDataList.FirstOrDefault(typeData => typeData.Type == data.Type);
                if (typeData != null)
                {
                  data.Color = typeData.Color;
                }
              });
            TournamentDataList = new ObservableCollection<TournamentData>(tournamentDataList.OrderByDescending(data => data.Date));
          }
          PageCurrentState = "Loaded";
        }
      }
      catch
      {
        PageCurrentState = "Loaded";
      }
    }
  }
}
