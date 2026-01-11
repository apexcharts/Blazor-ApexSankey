using System.Text.Json.Serialization;

namespace Blazor_ApexSankey.Models;

/// <summary>
/// options specific to the data structure (ordering, alignment)
/// </summary>
public class SankeyDataOptions
{
    /// <summary>
    /// custom node ordering as nested lists: layers -> bands -> node ids
    /// </summary>
    [JsonPropertyName("order")]
    public List<List<List<string>>>? Order { get; set; }

    /// <summary>
    /// whether to align link types across nodes
    /// </summary>
    [JsonPropertyName("alignLinkTypes")]
    public bool? AlignLinkTypes { get; set; }
}
