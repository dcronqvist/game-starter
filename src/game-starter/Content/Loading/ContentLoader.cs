using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using GameStarter.Content.Loaders;
using GameStarter.Debugging;
using Symphony;

namespace GameStarter.Content.Loading;

public class ContentLoader : IContentLoader<ContentMeta>
{
    private Dictionary<string, IContentItemLoader> _loaders = new Dictionary<string, IContentItemLoader>();

    public ContentLoader()
    {
        _loaders.Add(".png", new TextureLoader());
        _loaders.Add(".fs", new ShaderLoader());
        _loaders.Add(".vs", new ShaderLoader());
        _loaders.Add(".shader", new ShaderProgramLoader());
        _loaders.Add(".lua", new LuaScriptLoader());
        // _loaders.Add(".dll", new AssemblyLoader());
        _loaders.Add(".font", new FontLoader());
        // _loaders.Add(".md", new MarkdownFileLoader());
    }

    public string GetIdentifierForSource(IContentSource source)
    {
        using var structure = source.GetStructure();

        using (var stream = structure.GetEntryStream("meta.json", out var entry))
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var metadata = JsonSerializer.Deserialize<ContentMeta>(stream, options);

            return metadata.Name;
        }
    }

    public IEnumerable<IContentLoadingStage> GetLoadingStages()
    {
        yield return new ShaderLoadingStage(_loaders, true, ".vs", ".fs");
        yield return new ShaderProgramLoadingStage(_loaders, true, ".shader");

        yield return new CoreLoadingStage(_loaders, true, ".png", ".font", ".lua");
        yield return new NormalLoadingStage(_loaders, true, ".png", ".lua");
    }

    public IEnumerable<IContentSource> GetSourceLoadOrder(IEnumerable<IContentSource> sources)
    {
        var resolver = new LoadOrderResolver(this, sources);
        var order = resolver.GetSourceLoadOrder().ToList();

        Logging.Log(LogLevel.Info, $"Loading content from {order.Count} sources in the following order:");

        foreach (var source in order)
        {
            Logging.Log(LogLevel.Info, $"  {this.GetIdentifierForSource(source)}");
        }

        return order;
    }

    public IEnumerable<(ContentEntry, ContentItem[])> PostProcessEntries(IEnumerable<(ContentEntry, ContentItem[])> entries)
    {
        return entries;
    }
}