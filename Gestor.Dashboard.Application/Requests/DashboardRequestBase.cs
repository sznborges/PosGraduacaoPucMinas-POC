using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Dashboard.Application.Requests
{
    public class DashboardRequestBase
    {
        public int Limit { get; set; } = 5;
        public DateTime StartRangeDate { get; set; }
        public DateTime EndRangeDate { get; set; }
    }
}
