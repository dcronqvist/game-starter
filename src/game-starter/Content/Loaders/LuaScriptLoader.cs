using System.Collections.Generic;
using System.IO;
using GameStarter.Content.Loading;
using GameStarter.Graphics;
using GameStarter.Scripts;
using Symphony;

namespace GameStarter.Content.Loaders;

public class LuaScriptLoader : IContentItemLoader
{
    public async IAsyncEnumerable<LoadEntryResult> TryLoadAsync(IContentSource source, IContentStructure structure, string pathToItem)
    {
        using (var stream = structure.GetEntryStream(pathToItem, out var entry))
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                var code = sr.ReadToEnd();

                yield return await LoadEntryResult.CreateSuccessAsync(pathToItem, new LuaScript(source, code));
            }
        }
    }
}