using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.Ply.Infrastructure
{
    public partial class InstallationLanguage
    {
        public InstallationLanguage()
        {
            Resources = new List<InstallationLocaleResource>();
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsDefault { get; set; }
        public bool IsRightToLeft { get; set; }

        public List<InstallationLocaleResource> Resources { get; protected set; }
    }

    public partial class InstallationLocaleResource
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
