using BepInEx;
using BepInEx.Logging;
using BepInEx.NET.Common;
using BepInExResoniteShim;
using FrooxEngine;

namespace CreateWorldConfig;

[ResonitePlugin(PluginMetadata.GUID, PluginMetadata.NAME, PluginMetadata.VERSION, PluginMetadata.AUTHORS,
    PluginMetadata.REPOSITORY_URL)]
[BepInDependency(BepInExResoniteShim.PluginMetadata.GUID, BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency(BepisResoniteWrapper.PluginMetadata.GUID, BepInDependency.DependencyFlags.HardDependency)]
public class Plugin : BasePlugin
{
#nullable disable
    internal static new ManualLogSource Log;
#nullable enable

    public override void Load()
    {
        Log = base.Log;

        BepisResoniteWrapper.ResoniteHooks.OnEngineReady += () =>
        {
            DevCreateNewForm.AddAction("Editor", "World Configuration",
                s => WorkerInspector.Create(s, s.World.Configuration));
            DevCreateNewForm.AddAction("Editor", "World Permission Controller",
                s => WorkerInspector.Create(s, s.World.Permissions));
        };
    }
}