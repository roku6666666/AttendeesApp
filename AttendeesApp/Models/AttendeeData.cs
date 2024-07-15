using System.Text.Json.Serialization;

namespace AttendeesApp.Models
{
  public partial class AttendeeData : ResponseData
  {
    public class Data : ResponseData
    {
      [JsonPropertyName("firstName")]
      public string firstName { get; set; } = "";

      [JsonPropertyName("lastName")]
      public string lastName { get; set; } = "";

      [JsonPropertyName("gameTag")]
      public string gameTag { get; set; } = "";

      [JsonPropertyName("attendeeType")]
      public string attendeeType { get; set; } = "";
    }

    [JsonPropertyName("data")]
    public Data data { get; set; } = new Data();
  }
}
