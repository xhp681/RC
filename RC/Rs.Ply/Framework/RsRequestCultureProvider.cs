using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Rs.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.Ply.Framework
{
    public class RsRequestCultureProvider: RequestCultureProvider
    {
        public RsRequestCultureProvider(RequestLocalizationOptions options)
        {
            Options = options;
        }

        public override async Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            //set working language culture
            var culture = (await EngineContext.Current.Resolve<IWorkContext>().GetWorkingLanguageAsync()).LanguageCulture;

            return new ProviderCultureResult(culture, culture);
        }
    }
}
