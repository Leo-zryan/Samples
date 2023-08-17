using AspNetCoreDatabaseLocalizationDemo.Models;

namespace AspNetCoreDatabaseLocalizationDemo.Services
{
    public interface ILocalizationService
    {
        StringResource GetStringResource(string resourceKey, int languageId);
    }
}
