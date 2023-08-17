using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace RazorLocalizationWeb
{
    public static class ServiceCollectionExtensions
    {
        public static void AddLocalizationService(this IServiceCollection services)
        {
            services.AddLocalization(options=>options.ResourcesPath="Resources");

            // Add services to the container.
            services.AddControllersWithViews()
                .AddViewLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");

                var cultures = new CultureInfo[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("ja-JP")
                };

                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
        }
    }
}
