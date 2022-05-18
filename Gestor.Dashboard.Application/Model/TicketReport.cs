using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Dashboard.Application.Model
{
    public class TicketReport
    {
        public string TicketId { get; private set; }
        public string Type { get; private set; }
        public string CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public string Category { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public DateTime FinishDate { get; private set; }

    }
}
