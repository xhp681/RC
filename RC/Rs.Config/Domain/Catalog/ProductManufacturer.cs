using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class ProductManufacturer:BaseEntity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer identifier
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is featured
        /// </summary>
        public bool IsFeaturedProduct { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
