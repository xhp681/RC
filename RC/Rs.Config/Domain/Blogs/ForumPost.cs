﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class ForumPost : BaseEntity
    {
        /// <summary>
        /// Gets or sets the forum topic identifier
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the IP address
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the count of votes
        /// </summary>
        public int VoteCount { get; set; }
    }
}
