# Blazor-ApexSankey

A Blazor component library for creating interactive Sankey diagrams using [ApexSankey](https://github.com/apexcharts/apexsankey). Built for Blazor WebAssembly with full support for two-way data binding, customizable styling, and event handling.

![Blazor-ApexSankey](https://github.com/apexcharts/projects/assets/17950663/51e00ff0-79d1-45eb-8815-f8d11e2dd981)

## Features

-   🔗 **Two-Way Binding** - Automatic re-rendering when data changes
-   🎨 **Fully Customizable** - Control nodes, edges, fonts, colors, and tooltips
-   ⚡ **Event Handling** - Handle node clicks and render callbacks
-   📱 **WebAssembly** - Built specifically for Blazor WebAssembly
-   🛠️ **TypeScript Definitions** - Full IntelliSense support
-   📦 **Easy Integration** - Simple NuGet package installation

## Installation

```bash
dotnet add package Blazor-ApexSankey
```

## Quick Start

### 1. Add the script reference

The core library is self-contained (no external dependencies), so the standard Blazor script is all you need in your `index.html`:

```html
<script src="_framework/blazor.webassembly.js"></script>
```

### 2. Add the using statement

In your `_Imports.razor`:

```razor
@using Blazor_ApexSankey.Components
@using Blazor_ApexSankey.Models
@using Blazor_ApexSankey.Events
@using Blazor_ApexSankey.Services
```

### 3. Use the component

```razor
@page "/my-sankey"

<ApexSankey Data="@sankeyData"
            Options="@options"
            OnNodeClick="@HandleNodeClick" />

@code {
    private SankeyData sankeyData = new()
    {
        Nodes = new List<SankeyNode>
        {
            new() { Id = "A", Title = "Source A" },
            new() { Id = "B", Title = "Source B" },
            new() { Id = "C", Title = "Target C" }
        },
        Edges = new List<SankeyEdge>
        {
            new() { Source = "A", Target = "C", Value = 10 },
            new() { Source = "B", Target = "C", Value = 20 }
        }
    };

    private SankeyOptions options = new()
    {
        Width = "800",
        Height = "600",
        NodeWidth = 20,
        FontFamily = "Arial, sans-serif"
    };

    private void HandleNodeClick(NodeClickEventArgs args)
    {
        Console.WriteLine($"Clicked node: {args.Node.Title}");
    }
}
```

## Configuration Options

| Option               | Type     | Default     | Description                |
| -------------------- | -------- | ----------- | -------------------------- |
| `Width`              | `string` | `"100%"`    | Container width            |
| `Height`             | `string` | `"auto"`    | Container height           |
| `CanvasStyle`        | `string` | `null`      | CSS styles for canvas      |
| `Spacing`            | `int`    | `20`        | Horizontal spacing between node columns |
| `NodeWidth`          | `int`    | `20`        | Width of nodes             |
| `NodeBorderWidth`    | `int`    | `1`         | Node border width          |
| `NodeBorderColor`    | `string` | `null`      | Node border color          |
| `EdgeOpacity`        | `double` | `0.4`       | Edge opacity (0-1)         |
| `EdgeGradientFill`   | `bool`   | `true`      | Enable gradient fill       |
| `EnableTooltip`      | `bool`   | `false`     | Show tooltips              |
| `EnableToolbar`      | `bool`   | `false`     | Show toolbar               |
| `TooltipTemplate`    | `string` | `null`      | Custom tooltip JS function |
| `TooltipBorderColor` | `string` | `"#BCBCBC"` | Tooltip border color       |
| `TooltipBGColor`     | `string` | `"#FFFFFF"` | Tooltip background         |
| `FontSize`           | `string` | `"14px"`    | Node label font size       |
| `FontFamily`         | `string` | `null`      | Font family                |
| `FontWeight`         | `string` | `"400"`     | Font weight                |
| `FontColor`          | `string` | `"#000000"` | Label color                |

## Data Models

### SankeyNode

```csharp
public class SankeyNode
{
    public string Id { get; set; }      // required
    public string Title { get; set; }   // required
    public string? Color { get; set; }  // optional
}
```

### SankeyEdge

```csharp
public class SankeyEdge
{
    public string Source { get; set; }  // required
    public string Target { get; set; }  // required
    public double Value { get; set; }   // required
    public string? Type { get; set; }   // optional
    public string? Color { get; set; }  // optional
}
```

### Custom Ordering

You can specify custom node ordering:

```csharp
var data = new SankeyData
{
    Nodes = nodes,
    Edges = edges,
    Options = new SankeyDataOptions
    {
        Order = new List<List<List<string>>>
        {
            new() { new() { "A", "B" } },
            new() { new() { "C" } }
        }
    }
};
```

## Events

| Event         | Type                                | Description                  |
| ------------- | ----------------------------------- | ---------------------------- |
| `OnNodeClick` | `EventCallback<NodeClickEventArgs>` | Fired when a node is clicked |
| `OnRender`    | `EventCallback`                     | Fired after chart renders    |

## Ignite UI theming

From the Blazor-ApexSankey release that bundles apexsankey 1.14.0, diagrams can follow the Ignite UI theme on the page: the node palette, label text, the focus ring, the font, the tooltip, light or dark. It is an add-on, it is free, and it needs no license key. Turn it on once in `Program.cs`:

```csharp
ApexSankeyIgniteUI.Enable();
```

The component then loads `_content/Blazor-ApexSankey/apexsankey.ignite-ui.es.min.js` before the first diagram renders. To load it yourself instead, add the script-tag build to `index.html` (or `App.razor`), before or after the Blazor script:

```html
<script src="_content/Blazor-ApexSankey/apexsankey.ignite-ui.min.js"></script>
```

The Ignite UI tokens (`--ig-*`) are the lowest-ranked layer above the built-in defaults. Anything above them wins:

| Rank | Source |
| ---- | ------ |
| 1 | An option you pass in `SankeyOptions` |
| 2 | An `--apex-sankey-*` CSS variable |
| 3 | An `--apx-*` family token |
| 4 | A named or registered `Theme` |
| 5 | The Ignite UI theme (`--ig-*`), with the add-on loaded |
| 6 | The built-in defaults |

To turn it off for one diagram, set `DesignSystem = false`; the `--apx-*` tokens still apply. `Tokens = false` stops every token read (`--apx-*` and `--ig-*`). Without the add-on the `--ig-*` tokens are ignored, with no error.

The diagram reads its theme on every render. After a change that does not render, such as swapping the Ignite UI stylesheet for its dark variant, call `RefreshTokensAsync()` on the component (through `@ref`); node positions are kept.

The font comes from `--ig-font-family`, which is usually a web font, and the Ignite UI theme sheets do not load it. Load the font on the page; if it finishes loading after the first render, call `RefreshTokensAsync()` so the labels are measured with it.

## Licensing

To use with a commercial license:

```csharp
// set before creating any chart instances
await ApexSankeyInterop.SetLicenseAsync(jsRuntime, "your-license-key");
```

## Browser Support

Blazor-ApexSankey supports all modern browsers that support WebAssembly:

-   Chrome 57+
-   Firefox 52+
-   Safari 11+
-   Edge 16+

## License

See [LICENSE](LICENSE) for details.

## Links

-   [GitHub Repository](https://github.com/apexcharts/Blazor-ApexSankey)
-   [ApexSankey Documentation](https://apexcharts.com/apexsankey/docs/installation-usage/)
-   [NuGet Package](https://www.nuget.org/packages/Blazor-ApexSankey)
