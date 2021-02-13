using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Rs.Config;
using Rs.DataBase;

namespace Rs.Ply.Framework
{
    public class BaseRouteProvider
    {
        protected string GetRouterPattern(IEndpointRouteBuilder endpointRouteBuilder, string seoCode = null)
        {
            if (DataSettingsManager.IsDatabaseInstalled())
            {
                var localizationSettings = endpointRouteBuilder.ServiceProvider.GetRequiredService<LocalizationSettings>();
                if (localizationSettings.SeoFriendlyUrlsForLanguagesEnabled)
                    return $"{{{RsPathRouteDefaults.LanguageRouteValue}:maxlength(2):{RsPathRouteDefaults.LanguageParameterTransformer}=en}}/{seoCode}";
            }

            return seoCode ?? string.Empty;
        }
    }
}