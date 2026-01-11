namespace Blazor_ApexSankey.Models;

/// <summary>
/// represents an edge (connection) between two nodes in the sankey diagram
/// </summary>
public class SankeyEdge
{
    /// <summary>
    /// id of the source node (required)
    /// </summary>
    public required string Source { get; set; }

    /// <summary>
    /// id of the target node (required)
    /// </summary>
    public required string Target { get; set; }

    /// <summary>
    /// value/weight of the edge, determines thickness (required)
    /// </summary>
    public required double Value { get; set; }

    /// <summary>
    /// optional type for grouping edges
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// optional color for the edge (e.g., "#FF5733")
    /// </summary>
    public string? Color { get; set; }
}
