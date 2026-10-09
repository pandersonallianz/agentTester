using Microsoft.Extensions.Configuration;

namespace AgentTester.Config;

public static class AppConfigLoader
{
    public static AppSettings Load(string basePath)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        var settings = new AppSettings();
        configuration.GetSection("AppSettings").Bind(settings);
        return settings;
    }
}
