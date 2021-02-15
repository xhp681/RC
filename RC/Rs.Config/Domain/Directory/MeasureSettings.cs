using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config.Domain
{
    public partial class MeasureSettings:ISettings
    {
        /// <summary>
        /// Base dimension identifier
        /// </summary>
        public int BaseDimensionId { get; set; }

        /// <summary>
        /// Base weight identifier
        /// </summary>
        public int BaseWeightId { get; set; }
    }
}
