namespace Blazor_ApexSankey.Events;

/// <summary>
/// event arguments for node click events
/// </summary>
public class NodeClickEventArgs : EventArgs
{
    /// <summary>
    /// the node that was clicked
    /// </summary>
    public required SankeyNodeInfo Node { get; init; }
}

/// <summary>
/// information about a clicked node
/// </summary>
public class SankeyNodeInfo
{
    /// <summary>
    /// node identifier
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// node display title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// node color if set
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// any additional data from the node
    /// </summary>
    public Dictionary<string, object>? AdditionalData { get; set; }
}
