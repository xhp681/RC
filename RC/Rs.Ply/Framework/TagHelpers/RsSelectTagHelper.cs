﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rs.Ply.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.Ply.Framework.TagHelpers
{
    [HtmlTargetElement("rs-select",TagStructure =TagStructure.WithoutEndTag)]
    public class RsSelectTagHelper: TagHelper
    {
        private const string FOR_ATTRIBUTE_NAME = "asp-for";
        private const string NAME_ATTRIBUTE_NAME = "asp-for-name";
        private const string ITEMS_ATTRIBUTE_NAME = "asp-items";
        private const string DISABLED_ATTRIBUTE_NAME = "asp-multiple";
        private const string REQUIRED_ATTRIBUTE_NAME = "asp-required";
        /// <summary>
        /// An expression to be evaluated against the current model
        /// </summary>
        [HtmlAttributeName(FOR_ATTRIBUTE_NAME)]
        public ModelExpression For { get; set; }

        /// <summary>
        /// Name for a dropdown list
        /// </summary>
        [HtmlAttributeName(NAME_ATTRIBUTE_NAME)]
        public string Name { get; set; }

        /// <summary>
        /// Items for a dropdown list
        /// </summary>
        [HtmlAttributeName(ITEMS_ATTRIBUTE_NAME)]
        public IEnumerable<SelectListItem> Items { set; get; } = new List<SelectListItem>();

        /// <summary>
        /// Indicates whether the field is required
        /// </summary>
        [HtmlAttributeName(REQUIRED_ATTRIBUTE_NAME)]
        public string IsRequired { set; get; }

        /// <summary>
        /// Indicates whether the input is multiple
        /// </summary>
        [HtmlAttributeName(DISABLED_ATTRIBUTE_NAME)]
        public string IsMultiple { set; get; }

        /// <summary>
        /// ViewContext
        /// </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        private readonly IHtmlHelper _htmlHelper;
        public RsSelectTagHelper(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }
        /// <summary>
        /// Asynchronously executes the tag helper with the given context and output
        /// </summary>
        /// <param name="context">Contains information associated with the current HTML tag</param>
        /// <param name="output">A stateful HTML element used to generate an HTML tag</param>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            //clear the output
            output.SuppressOutput();

            //required asterisk
            if (bool.TryParse(IsRequired, out var required) && required)
            {
                output.PreElement.SetHtmlContent("<div class='input-group input-group-required'>");
                output.PostElement.SetHtmlContent("<div class=\"input-group-btn\"><span class=\"required\">*</span></div></div>");
            }

            //contextualize IHtmlHelper
            var viewContextAware = _htmlHelper as IViewContextAware;
            viewContextAware?.Contextualize(ViewContext);

            //get htmlAttributes object
            var htmlAttributes = new Dictionary<string, object>();
            var attributes = context.AllAttributes;
            foreach (var attribute in attributes)
            {
                if (!attribute.Name.Equals(FOR_ATTRIBUTE_NAME) &&
                    !attribute.Name.Equals(NAME_ATTRIBUTE_NAME) &&
                    !attribute.Name.Equals(ITEMS_ATTRIBUTE_NAME) &&
                    !attribute.Name.Equals(DISABLED_ATTRIBUTE_NAME) &&
                    !attribute.Name.Equals(REQUIRED_ATTRIBUTE_NAME))
                {
                    htmlAttributes.Add(attribute.Name, attribute.Value);
                }
            }

            //generate editor
            var tagName = For != null ? For.Name : Name;
            bool.TryParse(IsMultiple, out var multiple);
            if (!string.IsNullOrEmpty(tagName))
            {
                IHtmlContent selectList;
                if (multiple)
                {
                    selectList = _htmlHelper.Editor(tagName, "MultiSelect", new { htmlAttributes, SelectList = Items });
                }
                else
                {
                    if (htmlAttributes.ContainsKey("class"))
                        htmlAttributes["class"] += " form-control";
                    else
                        htmlAttributes.Add("class", "form-control");

                    selectList = _htmlHelper.DropDownList(tagName, Items, htmlAttributes);
                }
                output.Content.SetHtmlContent(await selectList.RenderHtmlContentAsync());
            }
        }
    }
}
