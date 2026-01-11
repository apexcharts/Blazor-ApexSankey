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

In your `index.html`, add the svg.js dependency before the Blazor script:

```html
<script src="https://cdn.jsdelivr.net/npm/@svgdotjs/svg.js"></script>
<script src="_framework/blazor.webassembly.js"></script>
```

### 2. Add the using statement

In your `_Imports.razor`:

```razor
@using Blazor-ApexSankey
@using Blazor-ApexSankey.Components
@using Blazor-ApexSankey.Models
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
| `Width`              | `string` | `"800"`     | Container width            |
| `Height`             | `string` | `"800"`     | Container height           |
| `CanvasStyle`        | `string` | `null`      | CSS styles for canvas      |
| `Spacing`            | `int`    | `100`       | Top/left spacing           |
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
