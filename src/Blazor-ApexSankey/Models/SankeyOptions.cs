using System.Text.Json.Serialization;

namespace Blazor_ApexSankey.Models;

/// <summary>
/// configuration options for the sankey diagram appearance and behavior
/// </summary>
public class SankeyOptions
{
    // common options

    /// <summary>
    /// width of the graph container (e.g., "800" or "100%")
    /// </summary>
    [JsonPropertyName("width")]
    public string? Width { get; set; }

    /// <summary>
    /// height of the graph container (e.g., "600" or "100%")
    /// </summary>
    [JsonPropertyName("height")]
    public string? Height { get; set; }

    /// <summary>
    /// css styles for the canvas root container
    /// </summary>
    [JsonPropertyName("canvasStyle")]
    public string? CanvasStyle { get; set; }

    /// <summary>
    /// spacing from top and left of graph container (default: 100)
    /// </summary>
    [JsonPropertyName("spacing")]
    public int? Spacing { get; set; }

    /// <summary>
    /// enable/disable the graph toolbar
    /// </summary>
    [JsonPropertyName("enableToolbar")]
    public bool? EnableToolbar { get; set; }

    // node options

    /// <summary>
    /// width of graph nodes in pixels (default: 20)
    /// </summary>
    [JsonPropertyName("nodeWidth")]
    public int? NodeWidth { get; set; }

    /// <summary>
    /// border width of the nodes in pixels (default: 1)
    /// </summary>
    [JsonPropertyName("nodeBorderWidth")]
    public int? NodeBorderWidth { get; set; }

    /// <summary>
    /// border color of the nodes
    /// </summary>
    [JsonPropertyName("nodeBorderColor")]
    public string? NodeBorderColor { get; set; }

    // edge options

    /// <summary>
    /// opacity value for edges, 0 to 1 (default: 0.4)
    /// </summary>
    [JsonPropertyName("edgeOpacity")]
    public double? EdgeOpacity { get; set; }

    /// <summary>
    /// enable gradient fill based on source and target node colors (default: true)
    /// </summary>
    [JsonPropertyName("edgeGradientFill")]
    public bool? EdgeGradientFill { get; set; }

    // font options

    /// <summary>
    /// font size of node labels (e.g., "14px")
    /// </summary>
    [JsonPropertyName("fontSize")]
    public string? FontSize { get; set; }

    /// <summary>
    /// font family of node labels
    /// </summary>
    [JsonPropertyName("fontFamily")]
    public string? FontFamily { get; set; }

    /// <summary>
    /// font weight of node labels (default: "400")
    /// </summary>
    [JsonPropertyName("fontWeight")]
    public string? FontWeight { get; set; }

    /// <summary>
    /// font color of node labels (default: "#000000")
    /// </summary>
    [JsonPropertyName("fontColor")]
    public string? FontColor { get; set; }

    // tooltip options

    /// <summary>
    /// enable tooltip on hover of nodes
    /// </summary>
    [JsonPropertyName("enableTooltip")]
    public bool? EnableTooltip { get; set; }

    /// <summary>
    /// html element id for the tooltip
    /// </summary>
    [JsonPropertyName("tooltipId")]
    public string? TooltipId { get; set; }

    /// <summary>
    /// javascript function string for custom tooltip template
    /// </summary>
    [JsonPropertyName("tooltipTemplate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TooltipTemplate { get; set; }

    /// <summary>
    /// border color of the tooltip (default: "#BCBCBC")
    /// </summary>
    [JsonPropertyName("tooltipBorderColor")]
    public string? TooltipBorderColor { get; set; }

    /// <summary>
    /// background color of the tooltip (default: "#FFFFFF")
    /// </summary>
    [JsonPropertyName("tooltipBGColor")]
    public string? TooltipBGColor { get; set; }
}
