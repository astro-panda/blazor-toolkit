namespace AstroPanda.Blazor.Toolkit.Test;

public class ServiceCollectionExtensionsTests : TestContext
{

    [Fact]
    public void AddBlazorToolkit_Adds_All_Services_To_ServiceCollection()
    {
        // Act
        Services.AddBlazorToolkit();

        // Assert
        Assert.NotNull(Services.GetService<IDownloadService>());
        Assert.NotNull(Services.GetService<IPrintService>());
    }
}
