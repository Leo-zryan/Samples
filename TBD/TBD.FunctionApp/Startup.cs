using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBD.FunctionApp.Interfaces;
using TBD.FunctionApp.Services;

[assembly: FunctionsStartup(typeof(TBD.FunctionApp.Startup))]

namespace TBD.FunctionApp;
public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton<IFeatureService, EnvVarFeatureService>();
    }

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
    {
        builder.ConfigurationBuilder.AddEnvironmentVariables();
    }
}
