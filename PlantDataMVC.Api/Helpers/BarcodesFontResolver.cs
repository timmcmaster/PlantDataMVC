using PdfSharp.Fonts;
using System;
using System.IO;
using System.Reflection;

namespace PlantDataMVC.Api.Helpers;

public class BarcodeFontResolver : IFontResolver
{
    // Resolve typeface maps a family name + style to a unique face name
    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        if (familyName.Equals("3 of 9 Barcode", StringComparison.OrdinalIgnoreCase))
        {
            return new FontResolverInfo("3OF9_NEW.TTF");
        }
        else if (familyName.Equals("Free 3 of 9", StringComparison.OrdinalIgnoreCase))
        {
            return new FontResolverInfo("free3of9.ttf");
        }
        else if (familyName.Equals("Libre Barcode 39", StringComparison.OrdinalIgnoreCase))
        {
            return new FontResolverInfo("LibreBarcode39-Regular.ttf");
        }
        else if (familyName.Equals("Free 3 of 9", StringComparison.OrdinalIgnoreCase))
        {
            return new FontResolverInfo("LibreBarcode39Text-Regular.ttf");
        }

        // Fallback to a default font if the requested one is not found
        return PlatformFontResolver.ResolveTypeface("Arial", bold, italic);
    }

    public byte[]? GetFont(string faceName)
    {
        // Option 1: Load from a file path
        //var fontPath = Path.Combine(AppContext.BaseDirectory, "Fonts", $"{faceName}");
        //if (File.Exists(fontPath))
        //{
        //    return File.ReadAllBytes(fontPath);
        //}

        // Option 2: Load from an embedded resource
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = $"PlantDataMVC.Api.Fonts.{faceName}";
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream != null)
        {
            using var ms = new MemoryStream();
            stream.CopyTo(ms);
            return ms.ToArray();
        }

        return null;

    }

}
