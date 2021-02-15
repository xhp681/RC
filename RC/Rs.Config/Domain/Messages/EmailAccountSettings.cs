using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class EmailAccountSettings:ISettings
    {
        /// <summary>
        /// Gets or sets a store default email account identifier
        /// </summary>
        public int DefaultEmailAccountId { get; set; }
    }
}
