using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Dashboard.Application.Requests
{
    public class DashboardRequestBase
    {
        /// <summary>
        /// Record Limit
        /// </summary>
        public int Limit { get; set; } = 5;
        /// <summary>
        /// Start range date (yyyy-mm-dd)
        /// </summary>
        public DateTime StartRangeDate { get; set; }
        /// <summary>
        /// End range date (yyyy-mm-dd)
        /// </summary>
        public DateTime EndRangeDate { get; set; }
    }
}
