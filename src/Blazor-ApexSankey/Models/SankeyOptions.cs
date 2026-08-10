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

    // projection options

    /// <summary>
    /// which projection of the flow model to draw: "sankey" (the layered diagram)
    /// or "chord" (a radial diagram for dense many-to-many relationships).
    /// (default: "sankey")
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// chord only. corner radius (px) for the rounded outer corners of each node
    /// arc (the inner edge, where ribbons meet, stays flush). 0 gives sharp
    /// corners; clamped to the ring band width. (default: 6)
    /// </summary>
    [JsonPropertyName("arcCornerRadius")]
    public int? ArcCornerRadius { get; set; }

    // theme + palette

    /// <summary>
    /// a named built-in theme ("light", "dark", "midnight", "mint", "sunset"), a
    /// name registered via ApexSankey.registerTheme, or an inline
    /// <see cref="SankeyTheme"/>. seeds coordinated visual defaults (palette,
    /// colors, background); options you set explicitly still win. accepts either
    /// a string or a <see cref="SankeyTheme"/> instance.
    /// </summary>
    [JsonPropertyName("theme")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Theme { get; set; }

    /// <summary>
    /// ordered fill colors cycled across nodes that do not set their own color.
    /// overrides the built-in palette; a theme sets this for you.
    /// </summary>
    [JsonPropertyName("nodePalette")]
    public List<string>? NodePalette { get; set; }

    // layout options

    /// <summary>
    /// flow direction. "horizontal" lays ranks out in columns (flows left to
    /// right); "vertical" lays them in rows (flows top to bottom).
    /// (default: "horizontal")
    /// </summary>
    [JsonPropertyName("orientation")]
    public string? Orientation { get; set; }

    /// <summary>
    /// fraction of vertical space used as margins between nodes (0 to 1). lower
    /// values give taller nodes. (default: 0.18)
    /// </summary>
    [JsonPropertyName("whitespace")]
    public double? Whitespace { get; set; }

    /// <summary>
    /// titles drawn above each column (or beside each row when vertical), one per
    /// rank: the axis/dimension labels of an alluvial diagram. index i labels
    /// rank i.
    /// </summary>
    [JsonPropertyName("axisTitles")]
    public List<string>? AxisTitles { get; set; }

    /// <summary>
    /// internal SVG viewport width in pixels. (default: 800)
    /// </summary>
    [JsonPropertyName("viewPortWidth")]
    public int? ViewPortWidth { get; set; }

    /// <summary>
    /// internal SVG viewport height in pixels. (default: 500)
    /// </summary>
    [JsonPropertyName("viewPortHeight")]
    public int? ViewPortHeight { get; set; }

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

    /// <summary>
    /// allow nodes to be repositioned by dragging with a pointer (mouse, touch,
    /// or pen). connected flows follow the node live; the manual position holds
    /// until the next render recomputes the layout. (default: false)
    /// </summary>
    [JsonPropertyName("draggableNodes")]
    public bool? DraggableNodes { get; set; }

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

    /// <summary>
    /// animate particles drifting along each flow ribbon, with density
    /// proportional to the ribbon's value. purely decorative; skipped under
    /// prefers-reduced-motion. (default: false)
    /// </summary>
    [JsonPropertyName("particleFlow")]
    public bool? ParticleFlow { get; set; }

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
    /// javascript function string for the custom edge (source to target) tooltip
    /// template
    /// </summary>
    [JsonPropertyName("tooltipTemplate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TooltipTemplate { get; set; }

    /// <summary>
    /// javascript function string for the custom per-node tooltip template
    /// </summary>
    [JsonPropertyName("nodeTooltipTemplate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NodeTooltipTemplate { get; set; }

    /// <summary>
    /// tooltip color preset that overrides the tooltip background/border/font
    /// colors. accepts "light" or "dark".
    /// </summary>
    [JsonPropertyName("tooltipTheme")]
    public string? TooltipTheme { get; set; }

    /// <summary>
    /// border color of the tooltip (default: "#E2E8F0")
    /// </summary>
    [JsonPropertyName("tooltipBorderColor")]
    public string? TooltipBorderColor { get; set; }

    /// <summary>
    /// background color of the tooltip (default: "#FFFFFF")
    /// </summary>
    [JsonPropertyName("tooltipBGColor")]
    public string? TooltipBGColor { get; set; }

    /// <summary>
    /// font color inside the tooltip (default: "#1a1a1a")
    /// </summary>
    [JsonPropertyName("tooltipFontColor")]
    public string? TooltipFontColor { get; set; }

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

    // accessibility options

    /// <summary>
    /// WCAG 2.1 AA accessibility settings.
    /// </summary>
    [JsonPropertyName("a11y")]
    public SankeyA11y? A11y { get; set; }

    // localization options

    /// <summary>
    /// localization and text-direction (RTL) settings
    /// </summary>
    [JsonPropertyName("locale")]
    public SankeyLocale? Locale { get; set; }

    // plugins (Blazor convenience)

    /// <summary>
    /// built-in plugins to install after the chart renders (path tracing, time
    /// playback, drill-down). Handled by the interop layer, which calls
    /// <c>use(ApexSankey.plugins.*)</c> for each configured plugin; it is not a
    /// core ApexSankey option.
    /// </summary>
    [JsonPropertyName("plugins")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SankeyPlugins? Plugins { get; set; }
}

/// <summary>
/// an inline theme: coordinated visual defaults seeded before your explicit
/// options. pass to <see cref="SankeyOptions.Theme"/> (which also accepts a
/// named-theme string).
/// </summary>
public class SankeyTheme
{
    /// <summary>
    /// ordered node fill colors, cycled across nodes that do not set their own color
    /// </summary>
    [JsonPropertyName("nodePalette")]
    public List<string>? NodePalette { get; set; }

    /// <summary>css color for node labels</summary>
    [JsonPropertyName("fontColor")]
    public string? FontColor { get; set; }

    /// <summary>opacity of the flow ribbons (0 to 1)</summary>
    [JsonPropertyName("edgeOpacity")]
    public double? EdgeOpacity { get; set; }

    /// <summary>fill ribbons with a source to target gradient</summary>
    [JsonPropertyName("edgeGradientFill")]
    public bool? EdgeGradientFill { get; set; }

    /// <summary>css color for the node border (null disables it)</summary>
    [JsonPropertyName("nodeBorderColor")]
    public string? NodeBorderColor { get; set; }

    /// <summary>css applied to the SVG root container, typically background and border</summary>
    [JsonPropertyName("canvasStyle")]
    public string? CanvasStyle { get; set; }

    /// <summary>tooltip color preset ("dark" or "light")</summary>
    [JsonPropertyName("tooltipTheme")]
    public string? TooltipTheme { get; set; }
}

/// <summary>
/// WCAG 2.1 AA accessibility options for the sankey diagram.
/// </summary>
public class SankeyA11y
{
    /// <summary>whether accessibility features are enabled (default: true)</summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>overrides the auto-generated aria-label on the SVG root</summary>
    [JsonPropertyName("diagramLabel")]
    public string? DiagramLabel { get; set; }

    /// <summary>populates the &lt;desc&gt; element with a longer optional description</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
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
