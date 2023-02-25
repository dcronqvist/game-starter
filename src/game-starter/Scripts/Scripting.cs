using System.Collections.Generic;
using System.Linq;
using GameStarter.Debugging;
using NLua;

namespace GameStarter.Scripts;

public static class Scripting
{
    public static Lua LuaState { get; private set; }
    public static bool IsInitialized => LuaState != null;

    public static void Initialize()
    {
        Logging.Log(LogLevel.Info, "Initializing scripting...");
        LuaState = new Lua();
        LuaState.DoString("data = {}");

        LuaState["table.extend"] = (LuaTable table1, LuaTable table2) => ExtendData(table1, table2);
        LuaState["require"] = (string file) =>
        {
            var script = MainGame.ContentManager.GetContentItem<LuaScript>(file);
            if (script == null)
            {
                Logging.Log(LogLevel.Error, $"Could not find script: {file}");
            }

            LuaState.DoString(script.Content);
        };

        var allDataScripts = MainGame.ContentManager.GetContentItems().Where(x => x is LuaScript && x.Identifier.EndsWith(":data.lua")).Cast<LuaScript>().ToList();

        foreach (var script in allDataScripts)
        {
            Logging.Log(LogLevel.Debug, $"Loading data script: {script.Identifier}");
            LuaState.DoString(script.Content);
        }
    }

    public static void Unload()
    {
        Logging.Log(LogLevel.Info, "Unloading scripting...");
        LuaState.Dispose();
    }

    public static void ExtendData(LuaTable table1, LuaTable table2)
    {
        if (table1.Keys.Cast<object>().All(x => x is long))
        {
            // If all keys are integers, we just concat the two tables
            for (int i = 0; i < table2.Keys.Count; i++)
            {
                table1[table1.Keys.Count + i + 1] = table2[i + 1];
            }

            return;
        }

        throw new System.NotImplementedException("ExtendData is not implemented for non-integer keys");
    }
}