namespace Blazor_ApexSankey.Models;

/// <summary>
/// built-in plugins to install after the chart renders. The interop layer reads
/// each configured entry and calls <c>sankey.use(ApexSankey.plugins.*)</c> with
/// the matching options. Leave a property null to skip that plugin.
///
/// Property names serialize as camelCase to match the JavaScript API.
/// </summary>
public class SankeyPlugins
{
    /// <summary>
    /// animate a comet pulse along the path from a picked node (see
    /// <see cref="PathTracePlugin"/>).
    /// </summary>
    public PathTracePlugin? PathTrace { get; set; }

    /// <summary>
    /// step the diagram through a sequence of data frames with a control bar
    /// (see <see cref="TimePlaybackPlugin"/>).
    /// </summary>
    public TimePlaybackPlugin? TimePlayback { get; set; }

    /// <summary>
    /// collapse groups of nodes into super-nodes and expand them on click (see
    /// <see cref="DrillDownPlugin"/>).
    /// </summary>
    public DrillDownPlugin? DrillDown { get; set; }
}

/// <summary>
/// options for the path-tracing plugin: a comet pulse cascading along the flow
/// path from the node the user picks.
/// </summary>
public class PathTracePlugin
{
    /// <summary>what starts a trace: "click" or "hover" (default: "click")</summary>
    public string? Trigger { get; set; }

    /// <summary>
    /// which way flow is traced from the picked node: "downstream", "upstream",
    /// or "both" (default: "downstream")
    /// </summary>
    public string? Direction { get; set; }

    /// <summary>pulse color (default: "#ffffff")</summary>
    public string? Color { get; set; }

    /// <summary>milliseconds for a pulse to cross one ribbon (default: 700)</summary>
    public int? Duration { get; set; }

    /// <summary>milliseconds added per hop, so the trace cascades outward (default: 220)</summary>
    public int? Stagger { get; set; }
}

/// <summary>
/// options for the time-playback plugin: step through ordered data frames,
/// driven by the chart's own update() so topology-stable frames morph smoothly.
/// </summary>
public class TimePlaybackPlugin
{
    /// <summary>the ordered frames to play through (required)</summary>
    public List<TimePlaybackFrame> Frames { get; set; } = new();

    /// <summary>milliseconds each frame is shown before advancing (default: 1600)</summary>
    public int? Interval { get; set; }

    /// <summary>start playing on install (default: false)</summary>
    public bool? Autoplay { get; set; }

    /// <summary>loop back to the first frame after the last (default: false)</summary>
    public bool? Loop { get; set; }

    /// <summary>render the built-in control bar (play/pause + scrubber) (default: true)</summary>
    public bool? Controls { get; set; }
}

/// <summary>
/// one time step for <see cref="TimePlaybackPlugin"/>. Frames that share
/// topology (same nodes and flows, differing values) morph smoothly.
/// </summary>
public class TimePlaybackFrame
{
    /// <summary>the nodes for this frame</summary>
    public List<SankeyNode> Nodes { get; set; } = new();

    /// <summary>the flows for this frame</summary>
    public List<SankeyEdge> Edges { get; set; } = new();

    /// <summary>label shown in the control bar for this frame (defaults to a frame counter)</summary>
    public string? Label { get; set; }
}

/// <summary>
/// options for the drill-down plugin: render a set of super-nodes and expand one
/// into its constituent flows on click (collapse by clicking a child).
/// </summary>
public class DrillDownPlugin
{
    /// <summary>the full, detailed leaf nodes before any collapsing (required)</summary>
    public List<SankeyNode> Nodes { get; set; } = new();

    /// <summary>the full, detailed flows between the leaf nodes (required)</summary>
    public List<SankeyEdge> Edges { get; set; } = new();

    /// <summary>group definitions; each collapses its children into one super-node (required)</summary>
    public List<DrillDownGroup> Groups { get; set; } = new();

    /// <summary>group ids expanded on install; every other group starts collapsed (default: none)</summary>
    public List<string>? Expanded { get; set; }
}

/// <summary>
/// a drill-down group: its children collapse into a single super-node.
/// </summary>
public class DrillDownGroup
{
    /// <summary>the super-node id (required)</summary>
    public required string Id { get; set; }

    /// <summary>the super-node title (required)</summary>
    public required string Title { get; set; }

    /// <summary>optional color for the super-node</summary>
    public string? Color { get; set; }

    /// <summary>the leaf node ids this group collapses (required)</summary>
    public List<string> Children { get; set; } = new();
}
