using Microsoft.Extensions.Configuration;
using TBD.FunctionApp.Interfaces;

namespace TBD.FunctionApp.Services;

public class EnvVarFeatureService : IFeatureService
{
    private readonly IConfiguration _config;

    public EnvVarFeatureService(IConfiguration config)
    {
        _config = config;
    }

    public bool IsEnabled(string featureName) =>
        _config.GetValue<bool>($"FEATUREFLAG_{featureName}");

    public bool IsEnabled(string featureName, bool defaultValue) =>
        _config.GetValue($"FEATUREFLAG_{featureName}", defaultValue);
}

