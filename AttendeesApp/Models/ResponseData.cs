using System.Text.Json.Serialization;

namespace AttendeesApp.Models
{
  public partial class ResponseData
  {
    [JsonPropertyName("statusCode")]
    public int statusCode { get; set; }

    [JsonPropertyName("message")]
    public string message { get; set; } = "";
  }
}
