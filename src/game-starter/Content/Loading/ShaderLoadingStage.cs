using System.Collections.Generic;
using GameStarter.Content;

namespace GameStarter.Content.Loading;

public class ShaderLoadingStage : BaseLoadingStage
{
    // Assuming loaders for .vs and .fs
    public ShaderLoadingStage(Dictionary<string, IContentItemLoader> loaders, bool doGLInit, params string[] extensions) : base(loaders, doGLInit, extensions)
    {
    }

    public override string StageName => "Shader Loading";

    public override void OnStageCompleted()
    {

    }

    public override void OnStageStarted()
    {

    }
}