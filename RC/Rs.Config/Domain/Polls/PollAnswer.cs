using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class PollAnswer:BaseEntity
    {
        /// <summary>
        /// Gets or sets the poll identifier
        /// </summary>
        public int PollId { get; set; }

        /// <summary>
        /// Gets or sets the poll answer name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the current number of votes
        /// </summary>
        public int NumberOfVotes { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
