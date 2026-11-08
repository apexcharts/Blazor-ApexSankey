namespace Blazor_ApexSankey;

/// <summary>
/// Opts the diagrams into Ignite UI theming.
/// </summary>
/// <remarks>
/// With this on, the interop module loads the ApexSankey Ignite UI add-on
/// (_content/Blazor-ApexSankey/apexsankey.ignite-ui.es.min.js) once, before the
/// first diagram renders. Diagrams then follow the Ignite UI theme on the page
/// (its --ig-* tokens) as the lowest-ranked layer above the built-in defaults: an
/// option you pass, an --apex-sankey-* variable, an --apx-* token or a named theme
/// still wins. <see cref="Models.SankeyOptions.DesignSystem"/> = false turns it off
/// for one diagram. The add-on is free and needs no license key.
/// </remarks>
public static class ApexSankeyIgniteUI
{
    /// <summary>
    /// Gets whether the Ignite UI add-on is loaded before the first render.
    /// </summary>
    public static bool IsEnabled { get; private set; }

    /// <summary>
    /// Loads the Ignite UI add-on before the first diagram renders.
    /// Call this method in Program.cs.
    /// </summary>
    /// <example>
    /// <code>
    /// // in Program.cs
    /// ApexSankeyIgniteUI.Enable();
    /// </code>
    /// </example>
    public static void Enable() => IsEnabled = true;
}
