using System.Text.Json.Serialization;

namespace AstroPanda.Blazor.Toolkit.Models;
public class DeviceOrientation
{
    [JsonPropertyName("angle")]
    public int Angle { get; set; } = 0;

    [JsonPropertyName("type")]
    public string Type { get; set; } = "portrait-primary";

    public bool IsLandscape => Type.Contains("landscape", StringComparison.OrdinalIgnoreCase);

    public bool IsPortrait => Type.Contains("portrait", StringComparison.OrdinalIgnoreCase);
}
