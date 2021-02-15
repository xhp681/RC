using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class CategoryTemplate:BaseEntity
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
    }
}
