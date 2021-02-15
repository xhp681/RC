using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public class DiscountManufacturerMapping:DiscountMapping
    {
        /// <summary>
        /// Gets or sets the manufacturer identifier
        /// </summary>
        public override int EntityId { get; set; }
    }
}
