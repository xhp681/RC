using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class Warehouse:BaseEntity
    {
        /// <summary>
        /// Gets or sets the warehouse name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// Gets or sets the address identifier of the warehouse
        /// </summary>
        public int AddressId { get; set; }
    }
}
