namespace Blazor_ApexSankey.Models;

/// <summary>
/// represents a node in the sankey diagram
/// </summary>
public class SankeyNode
{
    /// <summary>
    /// unique identifier for the node (required)
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// display title for the node (required)
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// optional color for the node (e.g., "#FF5733")
    /// </summary>
    public string? Color { get; set; }
}
