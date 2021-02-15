﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config
{
    public enum WwwRequirement
    {
        /// <summary>
        /// Doesn't matter (do nothing)
        /// </summary>
        NoMatter = 0,

        /// <summary>
        /// Pages should have WWW prefix
        /// </summary>
        WithWww = 10,

        /// <summary>
        /// Pages should not have WWW prefix
        /// </summary>
        WithoutWww = 20
    }
}
