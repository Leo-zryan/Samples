namespace TBD.FunctionApp.Interfaces;

public interface IFeatureService
{
    bool IsEnabled(string featureName);
    bool IsEnabled(string featureName, bool defaultValue);
}
