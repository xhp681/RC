using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Common
{
    public interface IStartupTask
    {
        /// <summary>
        /// Executes a task
        /// </summary>
        Task ExecuteAsync();

        /// <summary>
        /// Gets order of this startup task implementation
        /// </summary>
        int Order { get; }
    }
}
