using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using GameStarter.Content.Loading;
using LogiX.Graphics;
using StbImageSharp;
using Symphony;

namespace GameStarter.Content.Loaders;

public class TextureLoader : IContentItemLoader
{
    public async IAsyncEnumerable<LoadEntryResult> TryLoadAsync(IContentSource source, IContentStructure structure, string pathToItem)
    {
        using (var stream = structure.GetEntryStream(pathToItem, out var entry))
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);

                var result = ImageResult.FromStream(ms, ColorComponents.RedGreenBlueAlpha);
                var tex = new Texture2D(source, result);
                yield return await LoadEntryResult.CreateSuccessAsync(pathToItem, tex);
            }
        }
    }
}