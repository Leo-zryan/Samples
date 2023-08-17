using AspNetCoreDatabaseLocalizationDemo.Models;

namespace AspNetCoreDatabaseLocalizationDemo.Services
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguageByCulture(string culture);
    }
}
