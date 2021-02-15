using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class ProductTemplate:BaseEntity
    {
        /// <summary>
        /// Gets or sets the template name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the view path
        /// </summary>
        public string ViewPath { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets a comma-separated list of product type identifiers NOT supported by this template
        /// </summary>
        public string IgnoredProductTypes { get; set; }
    }
}
