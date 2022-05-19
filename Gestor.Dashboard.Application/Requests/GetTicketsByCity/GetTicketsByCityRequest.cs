using Gestor.Dashboard.Application.Contracts;
using MediatR;

namespace Gestor.Dashboard.Application.Requests.GetTicketsByType
{
    public class GetTicketsByCityRequest : DashboardRequestBase, IRequest<DashboardItensResponse>
    {
    }
}
