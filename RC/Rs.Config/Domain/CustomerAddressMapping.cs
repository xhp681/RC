using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class CustomerAddressMapping:BaseEntity
    {
        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the address identifier
        /// </summary>
        public int AddressId { get; set; }
    }
}
