using NeosModLoader;
using FrooxEngine;

namespace CreateWorldConfig
{
    public class CreateWorldConfig : NeosMod
    {
        public override string Name => "CreateWorldConfig";
        public override string Author => "art0007i";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/art0007i/CreateWorldConfig/";
        public override void OnEngineInit()
        {
            // no harmony required :)
            //Harmony harmony = new Harmony("me.art0007i.CreateWorldConfig");
            var getConfig = typeof(World).GetField("Configuration", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            Engine.Current.RunPostInit(() =>
            {
                DevCreateNewForm.AddAction("Editor", "World Configuration", delegate (Slot s)
                {
                    InspectorHelper.OpenInspectorForTarget((IWorldElement)getConfig.GetValue(s.World), null, true);
                }); 
                DevCreateNewForm.AddAction("Editor", "World Permission Controller", delegate (Slot s)
                {
                    InspectorHelper.OpenInspectorForTarget(s.World.Permissions, null, true);
                });
            });
        }
    }
}