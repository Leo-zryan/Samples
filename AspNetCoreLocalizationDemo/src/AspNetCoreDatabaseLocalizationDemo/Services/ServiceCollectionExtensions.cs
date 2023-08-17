using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace AspNetCoreDatabaseLocalizationDemo.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddLanguageService(this IServiceCollection services)
        {
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddLocalization();

            var serviceProvider = services.BuildServiceProvider();
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            var languages = languageService.GetLanguages();
            var cultures = languages.Select(x => new CultureInfo(x.Culture)).ToArray();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var englishCulture = cultures.FirstOrDefault(x => x.Name == "en-us");
                options.DefaultRequestCulture = new RequestCulture(englishCulture?.Name ?? "en-us");

                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
        }
    }
}
