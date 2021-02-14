using Microsoft.AspNetCore.Routing;
using Rs.Config.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.Ply.Framework.Events
{
    public class GenericRoutingEvent
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="values">Route values</param>
        /// <param name="urlRecord">Found URL record</param>
        public GenericRoutingEvent(RouteValueDictionary values, UrlRecord urlRecord)
        {
            RouteValues = values;
            UrlRecord = urlRecord;
        }

        /// <summary>
        /// Gets route values
        /// </summary>
        public RouteValueDictionary RouteValues { get; private set; }

        /// <summary>
        /// Gets URL record found by the route slug
        /// </summary>
        public UrlRecord UrlRecord { get; private set; }
    }
}
