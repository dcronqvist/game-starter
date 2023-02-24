using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System.Text.Json.Serialization;
using GameStarter.Content.Loading;
using GameStarter.Graphics;
using StbImageSharp;
using Symphony;

namespace GameStarter.Content.Loaders;

public class FontLoader : IContentItemLoader
{
    public async IAsyncEnumerable<LoadEntryResult> TryLoadAsync(IContentSource source, IContentStructure structure, string pathToItem)
    {
        var fileName = Path.GetFileNameWithoutExtension(pathToItem);
        using (var stream = structure.GetEntryStream(pathToItem, out var entry))
        {
            var zip = new ZipArchive(stream, ZipArchiveMode.Read);

            var mtsdfInfo = zip.GetEntry("mtsdf.json");
            if (mtsdfInfo is null) throw new Exception("mtsdf.json not found");

            FontData fontData = new();
            using (var bmfontinfoStream = mtsdfInfo.Open())
            {
                using (var ms = new MemoryStream())
                {
                    bmfontinfoStream.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    fontData = await JsonSerializer.DeserializeAsync<FontData>(ms, new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                }
            }

            var mtsdfFile = zip.GetEntry("mtsdf.png");
            if (mtsdfFile is null) throw new Exception("mtsdf.png not found");

            ImageResult sdfTextureData;

            using (var sdfStream = mtsdfFile.Open())
            {
                using (var ms = new MemoryStream())
                {
                    sdfStream.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    sdfTextureData = ImageResult.FromStream(ms, ColorComponents.RedGreenBlueAlpha);
                }
            }

            fontData.TextureAtlasData = sdfTextureData;

            var font = new Font(source, fontData);
            yield return await LoadEntryResult.CreateSuccessAsync(pathToItem, font);
        }
    }
}