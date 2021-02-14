using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.Ply.Framework.Mvc
{
    public class LanguageParameterTransformer: IOutboundParameterTransformer
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LanguageParameterTransformer(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string TransformOutbound(object value)
        {
            var lang = _httpContextAccessor.HttpContext.Request.RouteValues[RsPathRouteDefaults.LanguageRouteValue];
            //Validate SEO language only 2 letter
            return (lang != null && lang.ToString().Length == 2) ? lang.ToString() : value?.ToString();
        }
    }
}
