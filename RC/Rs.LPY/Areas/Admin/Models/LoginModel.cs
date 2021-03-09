using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.LPY.Areas.Admin.Models
{
    public partial record LoginModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
