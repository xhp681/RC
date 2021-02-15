using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class CustomerCustomerRoleMapping:BaseEntity
    {
        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer role identifier
        /// </summary>
        public int CustomerRoleId { get; set; }
    }
}
