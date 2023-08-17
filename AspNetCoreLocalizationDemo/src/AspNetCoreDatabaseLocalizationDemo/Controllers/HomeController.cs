using AspNetCoreDatabaseLocalizationDemo.Models;
using AspNetCoreDatabaseLocalizationDemo.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreDatabaseLocalizationDemo.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILanguageService languageService, ILocalizationService localizationService)
        : base(languageService, localizationService)
        {

        }

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Index()
        {
            ViewData["Title"] = Localize("customer.page.create.title");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}