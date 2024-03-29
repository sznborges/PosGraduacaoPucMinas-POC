﻿using System.Diagnostics.CodeAnalysis;

namespace Gestor.Dashboard.Application.Model
{
    [ExcludeFromCodeCoverage]
    public class DashboardItem
    {
        public string? Label { get; set; }
        public long Value { get; set; }
    }
}
