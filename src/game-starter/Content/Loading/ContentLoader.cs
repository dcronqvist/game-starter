using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using GameStarter.Debugging;
using Symphony;

namespace GameStarter.Content.Loading;

public class TestItem : ContentItem<string>
{
    public TestItem(IContentSource source, string content) : base(source, content)
    {
    }

    public override void Unload()
    {

    }

    protected override void OnContentUpdated(string newContent)
    {

    }
}

public class TestLoadingStage : IContentLoadingStage
{
    public string StageName => "TEST";

    public IEnumerable<ContentEntry> GetAffectedEntries(IEnumerable<ContentEntry> allEntries)
    {
        return allEntries.Where(entry => entry.EntryPath.EndsWith(".png"));
    }

    public void OnStageCompleted()
    {

    }

    public void OnStageStarted()
    {

    }

    public async IAsyncEnumerable<LoadEntryResult> TryLoadEntry(IContentSource source, IContentStructure structure, ContentEntry entry)
    {
        var identifier = Path.GetFileNameWithoutExtension(entry.EntryPath);
        yield return await LoadEntryResult.CreateSuccessAsync(identifier, new TestItem(source, Path.GetFileName(entry.EntryPath)));
    }
}

public class ContentLoader : IContentLoader<ContentMeta>
{
    private Dictionary<string, IContentItemLoader> _loaders = new Dictionary<string, IContentItemLoader>();

    public ContentLoader()
    {

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
        yield return new TestLoadingStage();
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
        // Need to perform overwriting here
        // First entry identifier, and last item is the one that should be used

        // var sourceOrder = GetSourceLoadOrder(entries.Select(entry => entry.Item2.First().Source)).ToList();

        // var entryToSource = entries.ToDictionary(entry => entry.Item1, entry => entry.Item2.First().Source);
        // var entryToItems = entries.ToDictionary(entry => entry.Item1, entry => entry.Item2);

        // var groupedEntries = entryToItems.GroupBy(entry => entry.Key.EntryPath);

        // var sorted = groupedEntries.Select(group =>
        // {
        //     var orderedGroup = group.OrderBy(g => sourceOrder.IndexOf(entryToSource[g.Key]));
        //     var firstEntry = orderedGroup.First().Key;
        //     var firstItems = entryToItems[firstEntry];
        //     var lastEntry = orderedGroup.Last().Key;

        //     return (firstEntry, entryToItems[lastEntry]);
        // }).ToList();

        return entries;
    }
}