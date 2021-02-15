using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config
{
    public enum TaxBasedOn
    {
        /// <summary>
        /// Billing address
        /// </summary>
        BillingAddress = 1,

        /// <summary>
        /// Shipping address
        /// </summary>
        ShippingAddress = 2,

        /// <summary>
        /// Default address
        /// </summary>
        DefaultAddress = 3
    }
}
