using Microsoft.JSInterop;

namespace Blazor_ApexSankey.Services;

/// <summary>
/// service for JavaScript interop with the ApexSankey library
/// </summary>
public class ApexSankeyInterop : IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _module;
    private bool _disposed;

    public ApexSankeyInterop(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// ensures the JS module is loaded
    /// </summary>
    private async Task<IJSObjectReference> GetModuleAsync()
    {
        if (_module is null)
        {
            _module = await _jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blazor-ApexSankey/blazor-apexsankey.js");
        }
        return _module;
    }

    /// <summary>
    /// sets the license key for ApexSankey (call before creating any charts)
    /// </summary>
    public static async Task<bool> SetLicenseAsync(IJSRuntime jsRuntime, string licenseKey)
    {
        var module = await jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blazor-ApexSankey/blazor-apexsankey.js");
        
        try
        {
            return await module.InvokeAsync<bool>("setLicense", licenseKey);
        }
        finally
        {
            await module.DisposeAsync();
        }
    }

    /// <summary>
    /// creates a new sankey chart instance
    /// </summary>
    public async Task CreateAsync(string elementId, object options, object data, DotNetObjectReference<object> dotNetRef)
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("create", elementId, options, data, dotNetRef);
    }

    /// <summary>
    /// updates an existing sankey chart with new data
    /// </summary>
    public async Task UpdateAsync(string elementId, object data)
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("update", elementId, data);
    }

    /// <summary>
    /// destroys a sankey chart instance and cleans up resources
    /// </summary>
    public async Task DestroyAsync(string elementId)
    {
        if (_module is not null)
        {
            await _module.InvokeVoidAsync("destroy", elementId);
        }
    }

    /// <summary>
    /// exports the chart as an SVG
    /// </summary>
    public async Task ExportToSvgAsync(string elementId)
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("exportToSvg", elementId);
    }

    public async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            if (_module is not null)
            {
                await _module.DisposeAsync();
            }
            _disposed = true;
        }
        GC.SuppressFinalize(this);
    }
}
