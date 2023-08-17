using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace AspNetCoreLocalizationDemo.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddLocalizationService(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");

                var cultures = new CultureInfo[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("ja-JP")
                };

                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
        }
    }
}
