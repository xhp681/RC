using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class MultiFactorAuthenticationSettings:ISettings
    {
        public MultiFactorAuthenticationSettings()
        {
            ActiveAuthenticationMethodSystemNames = new List<string>();
        }

        /// <summary>
        /// Gets or sets system names of active multi-factor authentication methods
        /// </summary>
        public List<string> ActiveAuthenticationMethodSystemNames { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to force multi-factor authentication
        /// </summary>
        public bool ForceMultifactorAuthentication { get; set; }
    }
}
