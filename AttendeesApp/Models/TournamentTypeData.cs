using System.Text.Json.Serialization;

namespace AttendeesApp.Models
{
  public partial class TournamentTypeData
  {
    [JsonPropertyName("type")]
    public string Type { get; set; } = "";

    [JsonPropertyName("color")]
    public string Color { get; set; } = "";
  }
}
