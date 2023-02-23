using System.Collections.Generic;
using GameStarter.Content;

namespace GameStarter.Content.Loading;

public class ShaderProgramLoadingStage : BaseLoadingStage
{
    public ShaderProgramLoadingStage(Dictionary<string, IContentItemLoader> loaders, bool doGLInit, params string[] extensions) : base(loaders, doGLInit, extensions)
    {
    }

    public override string StageName => "Shader Program Creation";

    public override void OnStageCompleted()
    {

    }

    public override void OnStageStarted()
    {

    }
}