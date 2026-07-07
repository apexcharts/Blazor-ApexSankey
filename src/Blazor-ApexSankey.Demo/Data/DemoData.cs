using System.Collections.Generic;
using Blazor_ApexSankey.Models;

namespace Blazor_ApexSankey.Demo;

/// <summary>
/// Shared sample data for demo pages.
/// </summary>
public static class DemoData
{
    /// <summary>
    /// A small two-level energy-flow diagram used by several sample pages.
    /// </summary>
    public static SankeyData Flows() => new()
    {
        Nodes = new List<SankeyNode>
        {
            new() { Id = "Solar", Title = "Solar" },
            new() { Id = "Wind", Title = "Wind" },
            new() { Id = "Grid", Title = "Grid" },
            new() { Id = "Home", Title = "Home" },
            new() { Id = "Factory", Title = "Factory" },
        },
        Edges = new List<SankeyEdge>
        {
            new() { Source = "Solar", Target = "Grid", Value = 8 },
            new() { Source = "Wind", Target = "Grid", Value = 6 },
            new() { Source = "Grid", Target = "Home", Value = 9 },
            new() { Source = "Grid", Target = "Factory", Value = 5 },
        }
    };
}
