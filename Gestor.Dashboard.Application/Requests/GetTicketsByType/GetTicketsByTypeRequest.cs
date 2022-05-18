using Gestor.Dashboard.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Dashboard.Application.Requests.GetTicketsByType
{
    public class GetTicketsByTypeRequest : IRequest<DashboardItensResponse>
    {
        public DateTime StartRangeDate { get; set; }
        public DateTime EndRangeDate { get; set; }
    }
}
