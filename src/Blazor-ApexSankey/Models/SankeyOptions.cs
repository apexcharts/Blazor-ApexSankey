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

    /// <summary>
    /// pixel gap between adjacent edges at a node connection point (default: 0)
    /// </summary>
    [JsonPropertyName("edgeGap")]
    public int? EdgeGap { get; set; }

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

    // interaction options

    /// <summary>
    /// when true, hovering a node or edge highlights the connected flow path (default: true)
    /// </summary>
    [JsonPropertyName("highlightConnectedPath")]
    public bool? HighlightConnectedPath { get; set; }

    /// <summary>
    /// opacity for dimmed (unrelated) elements when path highlighting is active (default: 0.15)
    /// </summary>
    [JsonPropertyName("dimOpacity")]
    public double? DimOpacity { get; set; }

    // animation options

    /// <summary>
    /// entrance animation settings for nodes and edges on initial render
    /// </summary>
    [JsonPropertyName("animation")]
    public SankeyAnimation? Animation { get; set; }

    // localization options

    /// <summary>
    /// localization and text-direction (RTL) settings
    /// </summary>
    [JsonPropertyName("locale")]
    public SankeyLocale? Locale { get; set; }
}

/// <summary>
/// entrance animation settings for the sankey diagram
/// </summary>
public class SankeyAnimation
{
    /// <summary>
    /// whether the entrance animation is enabled. automatically disabled when the
    /// user's prefers-reduced-motion setting is on (default: true)
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// total duration of the animation in milliseconds (default: 800)
    /// </summary>
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }
}

/// <summary>
/// localization and text-direction options for the sankey diagram
/// </summary>
public class SankeyLocale
{
    /// <summary>
    /// text and layout direction. "rtl" mirrors the diagram horizontally and sets
    /// dir="rtl" on the container; "auto" defers to the document/element direction.
    /// accepts "ltr", "rtl", or "auto" (default: "ltr")
    /// </summary>
    [JsonPropertyName("direction")]
    public string? Direction { get; set; }

    /// <summary>
    /// overrides for screen-reader strings, keyed by message name (e.g. "nodesGroupLabel").
    /// unset keys keep their English defaults.
    /// </summary>
    [JsonPropertyName("messages")]
    public Dictionary<string, string>? Messages { get; set; }
}
