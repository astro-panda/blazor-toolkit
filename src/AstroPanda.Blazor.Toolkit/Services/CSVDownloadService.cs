using System.Text;

namespace AstroPanda.Blazor.Toolkit.Services;

public class CSVDownloadService<T>(IDownloadService _downloads) : ICSVDownloadService<T>
{
    public async Task DownloadLocalAsync(string fileName, IEnumerable<T> collection)
    {
        using var stringWriter = new StringWriter();
        using var csvWriter = new CsvHelper.CsvWriter(stringWriter, System.Globalization.CultureInfo.InvariantCulture, true);

        csvWriter.WriteHeader<T>();
        csvWriter.NextRecord();
        csvWriter.WriteRecords(collection);

        using var receivingStream = new MemoryStream(Encoding.UTF8.GetBytes(stringWriter.ToString()));

        await _downloads.DownloadLocalAsync(fileName, receivingStream);
    }
}
