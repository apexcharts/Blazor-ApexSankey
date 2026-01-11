using System.Text.Json.Serialization;

namespace Blazor_ApexSankey.Models;

/// <summary>
/// complete data structure for the sankey diagram
/// </summary>
public class SankeyData
{
    /// <summary>
    /// list of nodes in the diagram
    /// </summary>
    [JsonPropertyName("nodes")]
    public List<SankeyNode> Nodes { get; set; } = new();

    /// <summary>
    /// list of edges connecting nodes
    /// </summary>
    [JsonPropertyName("edges")]
    public List<SankeyEdge> Edges { get; set; } = new();

    /// <summary>
    /// optional data-level options (ordering, alignment)
    /// </summary>
    [JsonPropertyName("options")]
    public SankeyDataOptions? Options { get; set; }
}
