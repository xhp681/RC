using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.Ply.Framework.Models
{
    public interface ILocalizedLocaleModel
    {
        /// <summary>
        /// Gets or sets the language identifier
        /// </summary>
        int LanguageId { get; set; }
    }
}
