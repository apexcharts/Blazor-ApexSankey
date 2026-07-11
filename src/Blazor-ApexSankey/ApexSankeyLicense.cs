namespace Blazor_ApexSankey;

/// <summary>
/// Manages ApexSankey license configuration.
/// </summary>
public static class ApexSankeyLicense
{
    private static string? _licenseKey;

    /// <summary>
    /// Gets the current license key.
    /// </summary>
    public static string? LicenseKey => _licenseKey;

    /// <summary>
    /// Checks if a license key has been configured.
    /// </summary>
    public static bool HasLicense => !string.IsNullOrWhiteSpace(_licenseKey);

    /// <summary>
    /// Sets the ApexSankey commercial license key.
    /// Call this method in Program.cs before rendering any charts. The key is
    /// stored and applied to the ApexSankey library the first time a chart is
    /// created, so it is guaranteed to take effect before any chart renders.
    /// </summary>
    /// <param name="licenseKey">Your ApexSankey commercial license key.</param>
    /// <example>
    /// <code>
    /// // in Program.cs
    /// ApexSankeyLicense.SetLicense("your-license-key-here");
    /// </code>
    /// </example>
    /// <exception cref="ArgumentException">Thrown when license key is null or empty.</exception>
    public static void SetLicense(string licenseKey)
    {
        if (string.IsNullOrWhiteSpace(licenseKey))
        {
            throw new ArgumentException("License key cannot be null or empty", nameof(licenseKey));
        }

        _licenseKey = licenseKey;
    }
}
