using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class ProductProductTagMapping:BaseEntity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product tag identifier
        /// </summary>
        public int ProductTagId { get; set; }
    }
}
