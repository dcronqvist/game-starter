using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.Json;
using GameStarter.Content.Loading;
using LogiX.Graphics;
using Symphony;

namespace GameStarter.Content.Loaders;

public class ShaderProgramLoader : IContentItemLoader
{
    public async IAsyncEnumerable<LoadEntryResult> TryLoadAsync(IContentSource source, IContentStructure structure, string pathToItem)
    {
        var fileName = Path.GetFileNameWithoutExtension(pathToItem);
        using (var stream = structure.GetEntryStream(pathToItem, out var entry))
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                var json = sr.ReadToEnd();
                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var programDescription = JsonSerializer.Deserialize<ShaderProgramDescription>(json, options);

                var sp = new ShaderProgram(source, programDescription);
                yield return await LoadEntryResult.CreateSuccessAsync(pathToItem, sp);
            }
        }
    }
}