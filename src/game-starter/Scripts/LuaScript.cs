using Symphony;
using NLua;
using GameStarter.Debugging;

namespace GameStarter.Scripts;

public class LuaScript : ContentItem<string>
{
    public LuaScript(IContentSource source, string content) : base(source, content)
    {

    }

    public override void Unload()
    {

    }

    protected override void OnContentUpdated(string newContent)
    {

    }
}