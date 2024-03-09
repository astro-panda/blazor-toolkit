namespace AstroPanda.Blazor.Toolkit;

public interface IClipboardService
{
    Task CopyText(string text);

    Task CopySVGImage(string svgElementId);

    Task CopyImage(string imageUrl);
}
