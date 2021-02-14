using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Rs.Config;
using Rs.Ply.Framework.Events;
using Rs.Server;
using Rs.Server.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.Ply.Framework.Mvc
{
    public partial class SlugRouteTransformer: DynamicRouteValueTransformer
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly ILanguageService _languageService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly LocalizationSettings _localizationSettings;

        public SlugRouteTransformer(IEventPublisher eventPublisher,
            ILanguageService languageService,
            IUrlRecordService urlRecordService,
            LocalizationSettings localizationSettings)
        {
            _eventPublisher = eventPublisher;
            _languageService = languageService;
            _urlRecordService = urlRecordService;
            _localizationSettings = localizationSettings;
        }

        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            if (values == null)
                return values;

            if (!values.TryGetValue("SeName", out var slugValue) || string.IsNullOrEmpty(slugValue as string))
                return values;

            var slug = slugValue as string;
            var urlRecord = await _urlRecordService.GetBySlugAsync(slug);

            //no URL record found
            if (urlRecord == null)
                return values;

            //virtual directory path
            var pathBase = httpContext.Request.PathBase;

            //if URL record is not active let's find the latest one
            if (!urlRecord.IsActive)
            {
                var activeSlug = await _urlRecordService.GetActiveSlugAsync(urlRecord.EntityId, urlRecord.EntityName, urlRecord.LanguageId);
                if (string.IsNullOrEmpty(activeSlug))
                    return values;

                //redirect to active slug if found
                values[RsPathRouteDefaults.ControllerFieldKey] = "Common";
                values[RsPathRouteDefaults.ActionFieldKey] = "InternalRedirect";
                values[RsPathRouteDefaults.UrlFieldKey] = $"{pathBase}/{activeSlug}{httpContext.Request.QueryString}";
                values[RsPathRouteDefaults.PermanentRedirectFieldKey] = true;
                httpContext.Items["nop.RedirectFromGenericPathRoute"] = true;

                return values;
            }

            //Ensure that the slug is the same for the current language, 
            //otherwise it can cause some issues when customers choose a new language but a slug stays the same
            if (_localizationSettings.SeoFriendlyUrlsForLanguagesEnabled)
            {
                var urllanguage = values["language"];
                if (urllanguage != null && !string.IsNullOrEmpty(urllanguage.ToString()))
                {
                    var languages = await _languageService.GetAllLanguagesAsync();
                    var language = languages.FirstOrDefault(x => x.UniqueSeoCode.ToLowerInvariant() == urllanguage.ToString().ToLowerInvariant())
                        ?? languages.FirstOrDefault();

                    var slugForCurrentLanguage = await _urlRecordService.GetActiveSlugAsync(urlRecord.EntityId, urlRecord.EntityName, language.Id);
                    if (!string.IsNullOrEmpty(slugForCurrentLanguage) && !slugForCurrentLanguage.Equals(slug, StringComparison.InvariantCultureIgnoreCase))
                    {
                        //we should make validation above because some entities does not have SeName for standard (Id = 0) language (e.g. news, blog posts)

                        //redirect to the page for current language
                        values[RsPathRouteDefaults.ControllerFieldKey] = "Common";
                        values[RsPathRouteDefaults.ActionFieldKey] = "InternalRedirect";
                        values[RsPathRouteDefaults.UrlFieldKey] = $"{pathBase}/{language.UniqueSeoCode}/{slugForCurrentLanguage}{httpContext.Request.QueryString}";
                        values[RsPathRouteDefaults.PermanentRedirectFieldKey] = false;
                        httpContext.Items["nop.RedirectFromGenericPathRoute"] = true;

                        return values;
                    }
                }
            }

            //since we are here, all is ok with the slug, so process URL
            switch (urlRecord.EntityName.ToLowerInvariant())
            {
                case "product":
                    values[RsPathRouteDefaults.ControllerFieldKey] = "Product";
                    values[RsPathRouteDefaults.ActionFieldKey] = "ProductDetails";
                    values[RsPathRouteDefaults.ProductIdFieldKey] = urlRecord.EntityId;
                    values[RsPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "producttag":
                    values[RsPathRouteDefaults.ControllerFieldKey] = "Catalog";
                    values[RsPathRouteDefaults.ActionFieldKey] = "ProductsByTag";
                    values[RsPathRouteDefaults.ProducttagIdFieldKey] = urlRecord.EntityId;
                    values[RsPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "category":
                    values[RsPathRouteDefaults.ControllerFieldKey] = "Catalog";
                    values[RsPathRouteDefaults.ActionFieldKey] = "Category";
                    values[RsPathRouteDefaults.CategoryIdFieldKey] = urlRecord.EntityId;
                    values[RsPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "manufacturer":
                    values[RsPathRouteDefaults.ControllerFieldKey] = "Catalog";
                    values[RsPathRouteDefaults.ActionFieldKey] = "Manufacturer";
                    values[RsPathRouteDefaults.ManufacturerIdFieldKey] = urlRecord.EntityId;
                    values[RsPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "vendor":
                    values[RsPathRouteDefaults.ControllerFieldKey] = "Catalog";
                    values[RsPathRouteDefaults.ActionFieldKey] = "Vendor";
                    values[RsPathRouteDefaults.VendorIdFieldKey] = urlRecord.EntityId;
                    values[RsPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "newsitem":
                    values[RsPathRouteDefaults.ControllerFieldKey] = "News";
                    values[RsPathRouteDefaults.ActionFieldKey] = "NewsItem";
                    values[RsPathRouteDefaults.NewsItemIdFieldKey] = urlRecord.EntityId;
                    values[RsPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "blogpost":
                    values[RsPathRouteDefaults.ControllerFieldKey] = "Blog";
                    values[RsPathRouteDefaults.ActionFieldKey] = "BlogPost";
                    values[RsPathRouteDefaults.BlogPostIdFieldKey] = urlRecord.EntityId;
                    values[RsPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                case "topic":
                    values[RsPathRouteDefaults.ControllerFieldKey] = "Topic";
                    values[RsPathRouteDefaults.ActionFieldKey] = "TopicDetails";
                    values[RsPathRouteDefaults.TopicIdFieldKey] = urlRecord.EntityId;
                    values[RsPathRouteDefaults.SeNameFieldKey] = urlRecord.Slug;
                    break;

                default:
                    //no record found, thus generate an event this way developers could insert their own types
                    await _eventPublisher.PublishAsync(new GenericRoutingEvent(values, urlRecord));
                    break;
            }

            return values;
        }
    }
}
