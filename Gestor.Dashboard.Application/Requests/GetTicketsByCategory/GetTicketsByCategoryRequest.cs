﻿using Gestor.Dashboard.Application.Contracts;
using MediatR;

namespace Gestor.Dashboard.Application.Requests.GetTicketsByType
{
    public class GetTicketsByCategoryRequest : DashboardRequestBase, IRequest<DashboardItensResponse>
    {
    }
}
