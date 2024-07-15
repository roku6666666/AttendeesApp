using System.Text.Json.Serialization;

namespace AttendeesApp.Models
{
  public partial class TournamentDataSet
  {
    [JsonPropertyName("tournamentDataList")]
    public List<TournamentData> TournamentDataList { get; set; } = new List<TournamentData> ();

    [JsonPropertyName("tournamentTypeDataList")]
    public List<TournamentTypeData> TournamentTypeDataList { get; set; } = new List<TournamentTypeData> ();
  }
}
