using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class VendorNote:BaseEntity
    {
        /// <summary>
        /// Gets or sets the vendor identifier
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// Gets or sets the note
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the date and time of vendor note creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
