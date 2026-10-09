using AgentTester.Config;

namespace AgentTester.Tests;

public class AppConfigLoaderTests
{
    private static readonly string TestDataPath = Path.Combine(AppContext.BaseDirectory, "TestData");

    [Fact]
    public void Load_ValidAppSettingsJson_ReturnsBoundWelcomeMessage()
    {
        // Arrange
        var basePath = TestDataPath;

        // Act
        var settings = AppConfigLoader.Load(basePath);

        // Assert
        Assert.Equal("Test welcome message", settings.WelcomeMessage);
    }

    [Fact]
    public void Load_ValidAppSettingsJson_ReturnsBoundAutoShuffleOnStart()
    {
        // Arrange
        var basePath = TestDataPath;

        // Act
        var settings = AppConfigLoader.Load(basePath);

        // Assert
        Assert.False(settings.AutoShuffleOnStart);
    }

    [Fact]
    public void Load_NonExistentBasePath_ThrowsDirectoryNotFoundException()
    {
        // Arrange
        var basePath = Path.Combine(AppContext.BaseDirectory, "NonExistentFolder");

        // Act
        var act = () => AppConfigLoader.Load(basePath);

        // Assert
        Assert.Throws<DirectoryNotFoundException>(act);
    }

    [Fact]
    public void Load_BasePathMissingAppSettingsJson_ThrowsFileNotFoundException()
    {
        // Arrange
        var basePath = AppContext.BaseDirectory;

        // Act
        var act = () => AppConfigLoader.Load(basePath);

        // Assert
        Assert.Throws<FileNotFoundException>(act);
    }
}
