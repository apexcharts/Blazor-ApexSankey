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

    /// <summary>
    /// A richer energy mix (four sources into the grid, out to two sinks). Used by
    /// the theme, particle-flow and draggable-node demos.
    /// </summary>
    public static SankeyData EnergyMix() => new()
    {
        Nodes = new List<SankeyNode>
        {
            new() { Id = "Coal", Title = "Coal", Color = "#78716c" },
            new() { Id = "Gas", Title = "Gas", Color = "#f59e0b" },
            new() { Id = "Solar", Title = "Solar", Color = "#eab308" },
            new() { Id = "Wind", Title = "Wind", Color = "#38bdf8" },
            new() { Id = "Grid", Title = "Grid", Color = "#6366f1" },
            new() { Id = "Homes", Title = "Homes", Color = "#10b981" },
            new() { Id = "Industry", Title = "Industry", Color = "#ec4899" },
        },
        Edges = new List<SankeyEdge>
        {
            new() { Source = "Coal", Target = "Grid", Value = 150 },
            new() { Source = "Gas", Target = "Grid", Value = 220 },
            new() { Source = "Solar", Target = "Grid", Value = 190 },
            new() { Source = "Wind", Target = "Grid", Value = 180 },
            new() { Source = "Grid", Target = "Homes", Value = 340 },
            new() { Source = "Grid", Target = "Industry", Value = 400 },
        }
    };
}
