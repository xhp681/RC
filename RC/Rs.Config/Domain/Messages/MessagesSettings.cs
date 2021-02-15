using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class MessagesSettings:ISettings
    {
        /// <summary>
        /// A value indicating whether popup notifications set as default 
        /// </summary>
        public bool UsePopupNotifications { get; set; }
    }
}
