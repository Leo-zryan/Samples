using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace RazorLocalizationWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageChangeController : ControllerBase
    {
        [HttpPost("ChangeLanguage")]
        public IActionResult ChangeLanguage([FromForm]string culture, [FromForm] string returnUrl)
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
    }
}
