using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;

public class LanguageMiddleware
{
    private readonly RequestDelegate _next;

    public LanguageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var cultureQuery = context.Request.Query["culture"];
        var cultureCookie = context.Request.Cookies["culture"];

        if (!string.IsNullOrWhiteSpace(cultureQuery))
        {
            var culture = new CultureInfo(cultureQuery);
            SetCulture(context, culture);
        }
        else if (!string.IsNullOrWhiteSpace(cultureCookie))
        {
            var culture = new CultureInfo(cultureCookie);
            SetCulture(context, culture);
        }

        await _next(context);
    }

    private void SetCulture(HttpContext context, CultureInfo culture)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = culture;
        System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
        context.Response.Cookies.Append("culture", culture.Name);
    }
}

