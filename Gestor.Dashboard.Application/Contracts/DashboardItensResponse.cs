
using Gestor.Dashboard.Application.Model;
using System.Diagnostics.CodeAnalysis;

namespace Gestor.Dashboard.Application.Contracts
{
    [ExcludeFromCodeCoverage]
    public class DashboardItensResponse
    {
        public DashboardItem[] Data { get; set; }
    }
}
