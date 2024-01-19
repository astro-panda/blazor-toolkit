using System.Text.Json.Serialization;

namespace AstroPanda.Blazor.Toolkit;

public class Manifest
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("short_name")]
    public string ShortName { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("version_name")]
    public string VersionName { get; set; }
}
