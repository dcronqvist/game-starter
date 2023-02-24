using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Symphony;

namespace GameStarter.Content.Loading;

public class NormalLoadingStage : BaseLoadingStage
{
    public override string StageName => "Normal Loading";

    public NormalLoadingStage(Dictionary<string, IContentItemLoader> loaders, bool doGLInit, params string[] extensions) : base(loaders, doGLInit, extensions)
    {
    }

    public override IEnumerable<ContentEntry> GetAffectedEntries(IEnumerable<ContentEntry> allEntries)
    {
        return base.GetAffectedEntries(allEntries).Where(entry => !entry.EntryPath.StartsWith("core"));
    }

    public override void OnStageStarted()
    {

    }

    public override void OnStageCompleted()
    {

    }
}